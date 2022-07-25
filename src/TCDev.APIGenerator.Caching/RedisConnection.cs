using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Redis
{
    public class RedisConnection : IDisposable
    {
        private long _lastReconnectTicks = DateTimeOffset.MinValue.UtcTicks;
        private DateTimeOffset _firstErrorTime = DateTimeOffset.MinValue;
        private DateTimeOffset _previousErrorTime = DateTimeOffset.MinValue;

        // StackExchange.Redis will also be trying to reconnect internally,
        // so limit how often we recreate the ConnectionMultiplexer instance
        // in an attempt to reconnect
        private readonly TimeSpan ReconnectMinInterval = TimeSpan.FromSeconds(60);

        // If errors occur for longer than this threshold, StackExchange.Redis
        // may be failing to reconnect internally, so we'll recreate the
        // ConnectionMultiplexer instance
        private readonly TimeSpan ReconnectErrorThreshold = TimeSpan.FromSeconds(30);
        private readonly TimeSpan RestartConnectionTimeout = TimeSpan.FromSeconds(15);
        private const int RetryMaxAttempts = 5;

        private SemaphoreSlim _reconnectSemaphore = new SemaphoreSlim(initialCount: 1, maxCount: 1);
        private readonly string _connectionString;
        private ConnectionMultiplexer _connection;
        private IDatabase _database;

        private RedisConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static async Task<RedisConnection> InitializeAsync(string connectionString)
        {
            var redisConnection = new RedisConnection(connectionString);
            await redisConnection.ForceReconnectAsync(initializing: true);

            return redisConnection;
        }

        // In real applications, consider using a framework such as
        // Polly to make it easier to customize the retry approach.
        // For more info, please see: https://github.com/App-vNext/Polly
        public async Task<T> BasicRetryAsync<T>(Func<IDatabase, Task<T>> func)
        {
            int reconnectRetry = 0;

            while (true)
            {
                try
                {
                    return await func(_database);
                }
                catch (Exception ex) when (ex is RedisConnectionException || ex is SocketException || ex is ObjectDisposedException)
                {
                    reconnectRetry++;
                    if (reconnectRetry > RetryMaxAttempts)
                    {
                        throw;
                    }

                    try
                    {
                        await ForceReconnectAsync();
                    }
                    catch (ObjectDisposedException) { }

                    return await func(_database);
                }
            }
        }

        /// <summary>
        /// Force a new ConnectionMultiplexer to be created.
        /// NOTES:
        ///     1. Users of the ConnectionMultiplexer MUST handle ObjectDisposedExceptions, which can now happen as a result of calling ForceReconnectAsync().
        ///     2. Call ForceReconnectAsync() for RedisConnectionExceptions and RedisSocketExceptions. You can also call it for RedisTimeoutExceptions,
        ///         but only if you're using generous ReconnectMinInterval and ReconnectErrorThreshold. Otherwise, establishing new connections can cause
        ///         a cascade failure on a server that's timing out because it's already overloaded.
        ///     3. The code will:
        ///         a. wait to reconnect for at least the "ReconnectErrorThreshold" time of repeated errors before actually reconnecting
        ///         b. not reconnect more frequently than configured in "ReconnectMinInterval"
        /// </summary>
        /// <param name="initializing">Should only be true when ForceReconnect is running at startup.</param>
        private async Task ForceReconnectAsync(bool initializing = false)
        {
            long previousTicks = Interlocked.Read(ref _lastReconnectTicks);
            var previousReconnectTime = new DateTimeOffset(previousTicks, TimeSpan.Zero);
            TimeSpan elapsedSinceLastReconnect = DateTimeOffset.UtcNow - previousReconnectTime;

            // We want to limit how often we perform this top-level reconnect, so we check how long it's been since our last attempt.
            if (elapsedSinceLastReconnect < ReconnectMinInterval)
            {
                return;
            }

            try
            {
                await _reconnectSemaphore.WaitAsync(RestartConnectionTimeout);
            }
            catch
            {
                // If we fail to enter the semaphore, then it is possible that another thread has already done so.
                // ForceReconnectAsync() can be retried while connectivity problems persist.
                return;
            }

            try
            {
                var utcNow = DateTimeOffset.UtcNow;
                elapsedSinceLastReconnect = utcNow - previousReconnectTime;

                if (_firstErrorTime == DateTimeOffset.MinValue && !initializing)
                {
                    // We haven't seen an error since last reconnect, so set initial values.
                    _firstErrorTime = utcNow;
                    _previousErrorTime = utcNow;
                    return;
                }

                if (elapsedSinceLastReconnect < ReconnectMinInterval)
                {
                    return; // Some other thread made it through the check and the lock, so nothing to do.
                }

                TimeSpan elapsedSinceFirstError = utcNow - _firstErrorTime;
                TimeSpan elapsedSinceMostRecentError = utcNow - _previousErrorTime;

                bool shouldReconnect =
                    elapsedSinceFirstError >= ReconnectErrorThreshold // Make sure we gave the multiplexer enough time to reconnect on its own if it could.
                    && elapsedSinceMostRecentError <= ReconnectErrorThreshold; // Make sure we aren't working on stale data (e.g. if there was a gap in errors, don't reconnect yet).

                // Update the previousErrorTime timestamp to be now (e.g. this reconnect request).
                _previousErrorTime = utcNow;

                if (!shouldReconnect && !initializing)
                {
                    return;
                }

                _firstErrorTime = DateTimeOffset.MinValue;
                _previousErrorTime = DateTimeOffset.MinValue;

                if (_connection != null)
                {
                    try
                    {
                        await _connection.CloseAsync();
                    }
                    catch
                    {
                        // Ignore any errors from the old connection
                    }
                }

                Interlocked.Exchange(ref _connection, null);
                ConnectionMultiplexer newConnection = await ConnectionMultiplexer.ConnectAsync(_connectionString);
                Interlocked.Exchange(ref _connection, newConnection);

                Interlocked.Exchange(ref _lastReconnectTicks, utcNow.UtcTicks);
                IDatabase newDatabase = _connection.GetDatabase();
                Interlocked.Exchange(ref _database, newDatabase);
            }
            finally
            {
                _reconnectSemaphore.Release();
            }
        }

        public void Dispose()
        {
            try { _connection?.Dispose(); } catch { }
        }
    }
}
