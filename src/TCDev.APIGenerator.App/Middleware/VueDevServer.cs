// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.SpaServices;

namespace TCDev.ApiGenerator.App.Middleware
{
   public static class Connection
   {
      private static int Port { get; } = 8080;
      private static Uri DevelopmentServerEndpoint { get; } = new($"http://localhost:{Port}");
      private static TimeSpan Timeout { get; } = TimeSpan.FromSeconds(60);

      private static string DoneMessage { get; } = "DONE  Compiled successfully in";

      public static void UseVueDevelopmentServer(this ISpaBuilder spa)
      {
         spa.UseProxyToSpaDevelopmentServer(async () =>
         {
            var loggerFactory = spa.ApplicationBuilder.ApplicationServices.GetService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("Vue");

            if (IsRunning()) return DevelopmentServerEndpoint;


            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            var processInfo = new ProcessStartInfo
            {
               FileName = isWindows ? "cmd" : "npm", Arguments = $"{(isWindows ? "/c npm " : "")}run serve", WorkingDirectory = "Client", RedirectStandardError = true, RedirectStandardInput = true, RedirectStandardOutput = true, UseShellExecute = false
            };
            var process = Process.Start(processInfo);
            var tcs = new TaskCompletionSource<int>();
            _ = Task.Run(() =>
            {
               try
               {
                  string line;
                  while ((line = process.StandardOutput.ReadLine()) != null)
                  {
                     logger.LogInformation(line);
                     if (!tcs.Task.IsCompleted && line.Contains(DoneMessage)) tcs.SetResult(1);
                  }
               }
               catch (EndOfStreamException ex)
               {
                  logger.LogError(ex.ToString());
                  tcs.SetException(new InvalidOperationException("'npm run serve' failed.", ex));
               }
            });
            _ = Task.Run(() =>
            {
               try
               {
                  string line;
                  while ((line = process.StandardError.ReadLine()) != null) logger.LogError(line);
               }
               catch (EndOfStreamException ex)
               {
                  logger.LogError(ex.ToString());
                  tcs.SetException(new InvalidOperationException("'npm run serve' failed.", ex));
               }
            });

            var timeout = Task.Delay(Timeout);
            if (await Task.WhenAny(timeout, tcs.Task) == timeout) throw new TimeoutException();

            return DevelopmentServerEndpoint;
         });
      }

      private static bool IsRunning()
      {
         return IPGlobalProperties.GetIPGlobalProperties()
            .GetActiveTcpListeners()
            .Select(x => x.Port)
            .Contains(Port);
      }
   }
}