// TCDev.de 2022/04/15
// TCDev.APIGenerator.GenericController.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Data;
using TCDev.APIGenerator.Data;
using TCDev.ApiGenerator.Interfaces;
using TCDev.APIGenerator.Services;

namespace TCDev.ApiGenerator
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiAuthAttribute]
    public class GenericController<T, TEntityId> : ODataController
        where T : class,
        IObjectBase<TEntityId>
    {
        private readonly ApplicationDataService appDataService;
        private readonly IAuthorizationService authorizationService;
        private readonly IGenericRespository<T, TEntityId> repository;
        private readonly ODataScopeService<T, TEntityId> scopeLookup;
        private ApiAttributeAttributeOptions options;

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
        }

        /// <summary>
        ///     Returns a list of <see cref="T" /> entries
        /// </summary>
        /// <returns cref="List{T}"></returns>
        [Produces("application/json")]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        [HttpGet]
        [EnableQuery(
            AllowedQueryOptions = AllowedQueryOptions.All,
            AllowedFunctions = AllowedFunctions.All,
            PageSize = 20)
        ]
        public IActionResult Query(ODataQueryOptions<T> ODataOpts)
        {
            // Check if post is enabled
            if (!this.options.Methods.HasFlag(ApiMethodsToGenerate.Get))
            {
                return BadRequest($"GET is disabled for {typeof(T).Name}");
            }

            if (this.options.Authorize && !this.HttpContext.ValidateScopes(this.scopeLookup.GetRequestedScopes(ODataOpts), ""))
            {
                return Forbid();
            }

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(this.repository.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(ODataQueryOptions<T> ODataOpts, TEntityId id)
        {
            // Check if post is enabled
            if (!this.options.Methods.HasFlag(ApiMethodsToGenerate.Get))
            {
                return BadRequest($"GET is disabled for {typeof(T).Name}");
            }

            if (this.options.Authorize && !this.HttpContext.ValidateScopes(this.scopeLookup.GetRequestedScopes(ODataOpts), ""))
            {
                return Forbid();
            }

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            var record = await this.repository.GetAsync(id, this.appDataService);


            return Ok(record);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T record)
        {
            try
            {
                // Check if post is enabled
                if (!this.options.Methods.HasFlag(ApiMethodsToGenerate.Insert))
                {
                    return BadRequest($"POST is disabled for {record.GetType().Name}");
                }

                if (this.options.Authorize && !this.HttpContext.ValidateScopes(this.options.RequiredWriteScopes, ""))
                {
                    return Forbid();
                }

                // Check if payload is valid
                if (!this.ModelState.IsValid)
                {
                    return BadRequest();
                }

                // Create the new entry
                this.repository.Create(record, this.appDataService);
                await this.repository.SaveAsync();

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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(TEntityId id, [FromBody] T record)
        {
            try
            {
                if (!this.options.Methods.HasFlag(ApiMethodsToGenerate.Update))
                {
                    return BadRequest($"PUT is disabled for {record.GetType().Name}");
                }

                if (this.options.Authorize && !this.HttpContext.ValidateScopes(this.options.RequiredWriteScopes, ""))
                {
                    return Forbid();
                }

                if (!this.ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingRecord = await this.repository.GetAsync(id, this.appDataService);
                if (existingRecord == null)
                {
                    return NotFound();
                }

                this.repository.Update(record, existingRecord, this.appDataService);
                await this.repository.SaveAsync();

                return Ok(record);
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
                if (!this.options.Methods.HasFlag(ApiMethodsToGenerate.Delete))
                {
                    return BadRequest("DELETE is disabled");
                }

                if (this.options.Authorize && !this.HttpContext.ValidateScopes(this.options.RequiredWriteScopes, ""))
                {
                    return Forbid();
                }

                if (!this.ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingRecord = await this.repository.GetAsync(id, this.appDataService);
                if (existingRecord == null)
                {
                    return NotFound();
                }

                this.repository.Delete(id, this.appDataService);
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

        public GenericController(
            IAuthorizationService authorizationService,
            IGenericRespository<T, TEntityId> repository,
            ODataScopeService<T, TEntityId> scopeLookup,
            ApplicationDataService dataService)
        {
            this.repository = repository;
            this.authorizationService = authorizationService;
            this.scopeLookup = scopeLookup;
            this.appDataService = dataService;

            ConfigureController();
        }
    }
}
