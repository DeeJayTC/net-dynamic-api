// TCDev.de 2022/04/15
// TCDev.APIGenerator.GenericController.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCDev.APIGenerator.Attributes;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Events;
using TCDev.APIGenerator.Hooks;
using TCDev.APIGenerator.Interfaces;
using TCDev.APIGenerator.Schema.Interfaces;
using TCDev.APIGenerator.Services;

namespace TCDev.APIGenerator
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiAuthAttribute]
    public class GenericController<T, TEntityId> : Controller
        where T : class, IObjectBase<TEntityId>
    {
        private readonly ApplicationDataService<GenericDbContext, AuthDbContext> appDataService;
        private readonly IAuthorizationService authorizationService;
        private readonly IGenericRespository<T, TEntityId> repository;
        private ApiAttributeAttributeOptions options;
        private CachableAttribute cacheOptions;
        private EventAttribute eventOptions;
        private ApiGeneratorConfig apiGenConfig;


        public GenericController(
            IAuthorizationService authorizationService,
            IGenericRespository<T, TEntityId> repository,
            ApplicationDataService<GenericDbContext, AuthDbContext> dataService,
            ApiGeneratorConfig apiGenConfig)
        {
            this.repository = repository;
            this.authorizationService = authorizationService;
            this.appDataService = dataService;
            this.apiGenConfig = apiGenConfig;

            ConfigureController();
        }



        private void ConfigureController()
        {
            // Get attribute config from underlying type T
            var attrs = Attribute.GetCustomAttributes(typeof(T));
            if (attrs.FirstOrDefault(p => p.GetType() == typeof(ApiAttribute)) is ApiAttribute optionAttrib)
            {
                this.options = optionAttrib.Options;
            }
            else
            {
                throw new Exception($"Could not find ApiAttribute on Class: {typeof(T)}");
            }
            
            // Get Cache Settings
            var cacheAttr = Attribute.GetCustomAttributes(typeof(CachableAttribute));
            if (attrs.FirstOrDefault(p => p.GetType() == typeof(CachableAttribute)) is CachableAttribute cacheAttrib)
            {
                this.cacheOptions = cacheAttrib;
            }

            // Get Cache Settings
            var eventAttr = Attribute.GetCustomAttributes(typeof(EventAttribute));
            if (attrs.FirstOrDefault(p => p.GetType() == typeof(EventAttribute)) is EventAttribute eventAttrib)
            {
                this.eventOptions = eventAttrib;
            }

        }

        /// <summary>
        ///     Returns a list of <see cref="T" /> entries
        /// </summary>
        /// <returns cref="List{T}"></returns>
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        [HttpGet]
        public IActionResult Query()
        {
            // Check if post is enabled
            if (!this.options.Methods.HasFlag(ApiMethodsToGenerate.Get))
            {
                return BadRequest($"GET is disabled for {typeof(T).Name}");
            }

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(this.repository.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(TEntityId id)
        {
            // Check if post is enabled
            if (!this.options.Methods.HasFlag(ApiMethodsToGenerate.Get))
            {
                return BadRequest($"GET is disabled for {typeof(T).Name}");
            }

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }


            // Check if we are using Redis
            var redisService = (ICacheService)HttpContext.RequestServices.GetService(typeof(ICacheService));
            if(redisService != null)
            {
                // generate cachekey
                var keys = string.Format(cacheOptions.cacheKey, id);
                var value = await redisService.GetData<T>(keys);
                if (value != null) return Ok(value);
            }

            var record = await this.repository.GetAsync(id, this.appDataService);

            return Ok(record);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T record)
        {
            try
            {
                IActionResult validator = ValidateCall(ApiMethodsToGenerate.Insert, true);
                if (validator.GetType() != typeof(OkResult)) return validator;

                // Create the new entry
                this.repository.Create(record, this.appDataService);
                await this.repository.SaveAsync();

                if (eventOptions != null && eventOptions.events.HasFlag(AMQPEvents.Created))  CheckAndSendEvent(record, typeof(T).Name + ".CREATED", null);

                // respond with the newly created record
                return CreatedAtAction("Find", new
                {
                    id = record.Id
                }, record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        private void CheckAndSendEvent(T record, string Name, T oldRecord)
        {
            try
            {
                // Check if we are using AMQP to send message and remember the value globally
                // We only want to check this once!
                if (!apiGenConfig.RuntimeOptions.AQMPChecked)
                {
                    var amqpService = (IMessageProducer)HttpContext.RequestServices.GetService(typeof(IMessageProducer));
                    if (amqpService != null)
                    {
                        apiGenConfig.RuntimeOptions.AMQPService = amqpService;
                    }
                    apiGenConfig.RuntimeOptions.AQMPChecked = true;
                }
                if (apiGenConfig.RuntimeOptions.AMQPService != null)
                {

                    apiGenConfig.RuntimeOptions.AMQPService.SendMessage(new AMQPPayload<T>() { data = record, eventName = Name, oldData = oldRecord });
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine("Could not send AMQP Message: ", ex);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(TEntityId id, [FromBody] T record)
        {
            try
            {
                try
                {
                    IActionResult validator = ValidateCall(ApiMethodsToGenerate.Update, true);
                    if (validator.GetType() != typeof(OkResult)) return validator;

                    var existingRecord = await this.repository.GetAsync(id, this.appDataService);
                    if (existingRecord == null)
                    {
                        return NotFound();
                    }


                    if (typeof(T).IsAssignableTo(typeof(IBeforeUpdate<T>)))
                    {
                        var baseEntity = record as IBeforeUpdate<T>;
                        record = await baseEntity.BeforeUpdate(record, existingRecord, this.appDataService);
                    }

                    if (typeof(T).IsAssignableFrom(typeof(IHasTrackingFields)))
                    {
                        this.appDataService.GenericDataContext.Entry(record)
                        .Property<DateTime>("LastModified")
                        .CurrentValue = DateTime.UtcNow;
                        this.appDataService.GenericDataContext.Entry(record)
                        .State = EntityState.Modified;
                    }

                    this.appDataService.GenericDataContext.ChangeTracker.Clear();
                    this.appDataService.GenericDataContext.Update(record);
                    await this.appDataService.GenericDataContext.SaveChangesAsync();

                    // We have a after update handler
                    if (typeof(T).IsAssignableTo(typeof(IAfterUpdate<T>)))
                    {
                        var baseEntity = record as IAfterUpdate<T>;
                        await baseEntity.AfterUpdate(record, existingRecord, this.appDataService);
                    }

                    if (eventOptions != null && eventOptions.events.HasFlag(AMQPEvents.Updated)) CheckAndSendEvent(record, typeof(T).Name.ToUpper() + ".UPDATED", existingRecord);


                    return Ok(record);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(TEntityId id)
        {
            try
            {
                IActionResult validator = ValidateCall(ApiMethodsToGenerate.Delete, true);
                if (validator.GetType() != typeof(OkResult)) return validator;


                var existingRecord = await this.repository.GetAsync(id, this.appDataService);
                if (existingRecord == null)
                {
                    return NotFound();
                }

                this.repository.Delete(id, this.appDataService);


                if (eventOptions != null && eventOptions.events.HasFlag(AMQPEvents.Deleted)) CheckAndSendEvent(existingRecord, typeof(T).Name.ToUpper() + ".DELETED", null);
                if (await this.repository.SaveAsync() == 0)
                {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        private IActionResult ValidateCall(ApiMethodsToGenerate method, bool isWritingCall = false)
        {
            if (!this.options.Methods.HasFlag(method))
            {
                return BadRequest($"{method} is disabled");
            }

            var requiredScopes = isWritingCall ? this.options.RequiredWriteScopes : this.options.RequiredReadScopes;

            if (this.options.Authorize && !this.HttpContext.ValidateScopes(requiredScopes, ""))
            {
                return Forbid();
            }

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
