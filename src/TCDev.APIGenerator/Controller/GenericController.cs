// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

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
using TCDev.ApiGenerator.Interfaces;

namespace TCDev.ApiGenerator
{
   [Route("api/[controller]")]
   [Produces("application/json")]
   public class GenericController<T, TEntityId> : ODataController
      where T : class,
      IObjectBase<TEntityId>
   {
      public GenericController(IAuthorizationService authorizationService, IGenericRespository<T, TEntityId> repository)
      {
         _repository = repository;
         _authorizationService = authorizationService;

         ConfigureController();
      }

      private readonly IAuthorizationService _authorizationService;
      private readonly IGenericRespository<T, TEntityId> _repository;
      private bool useCache { get; set; }
      private bool fireEvent { get; set; }

      private void ConfigureController()
      {
         // Get attribute config from underlying type T
         var attrs = Attribute.GetCustomAttributes(typeof(T));
         if (attrs.FirstOrDefault(p => p.GetType() == typeof(GeneratedControllerAttribute)) is GeneratedControllerAttribute optionAttrib)
         {
            useCache = optionAttrib.Options.Cache;
            fireEvent = optionAttrib.Options.FireEvents;
         }
         else
         {
            throw new Exception($"Could not find GeneratedControllerAttribute on Class: {typeof(T)}");
         }
      }

      /// <summary>
      ///    Returns a list of <see cref="T" /> entries
      /// </summary>
      /// <param name="includeUnpublished"></param>
      /// <returns cref="List{T}"></returns>
      [Produces("application/json")]
      [ProducesErrorResponseType(typeof(BadRequestResult))]
      [HttpGet]
      [EnableQuery(
         AllowedQueryOptions = AllowedQueryOptions.All,
         AllowedFunctions = AllowedFunctions.All,
         MaxTop = 200,
         MaxSkip = 199,
         PageSize = 20)]
      public IActionResult Query(bool includeUnpublished = false)
      {
         if (!ModelState.IsValid) return BadRequest();

         return Ok(_repository.Get());
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> Find(TEntityId id)
      {
         if (!ModelState.IsValid)
            return BadRequest();

         var record = await _repository.GetAsync(id);


         return Ok(record);
      }

      [HttpPost]
      public async Task<IActionResult> Create([FromBody] T record)
      {
         if (!ModelState.IsValid)
            return BadRequest();

         _repository.Create(record);
         if (await _repository.SaveAsync() == 0)
            return BadRequest();

         return CreatedAtAction("Find", new {id = record.Id}, record);
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> Update(TEntityId id, [FromBody] T record)
      {
         try
         {
            if (!ModelState.IsValid)
               return BadRequest();

            _repository.Update(record);
            await _repository.SaveAsync();

            return Ok(record);
         }
         catch (Exception ex)
         {
            return BadRequest();
         }
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(TEntityId id)
      {
         if (!ModelState.IsValid)
            return BadRequest();

         _repository.Delete(id);
         if (await _repository.SaveAsync() == 0)
            return BadRequest();

         return NoContent();
      }
   }
}