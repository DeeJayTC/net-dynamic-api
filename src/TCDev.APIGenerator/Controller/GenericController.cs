// TCDev.de 2022/03/16
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
using Microsoft.Identity.Web.Resource;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Data;
using TCDev.ApiGenerator.Interfaces;

namespace TCDev.ApiGenerator;

[Route("api/[controller]")]
[Produces("application/json")]
[ApiAuthAttribute]
public class GenericController<T, TEntityId> : ODataController
   where T : class,
   IObjectBase<TEntityId>
{
   private bool UseCache { get; set; }
   private bool FireEvent { get; set; }

   private readonly IAuthorizationService authorizationService;
   private readonly IGenericRespository<T, TEntityId> repository;

   public ApiMethodsToGenerate MethodsToGenerate;

   public GenericController(IAuthorizationService authorizationService, IGenericRespository<T, TEntityId> repository)
   {
      this.repository = repository;
      this.authorizationService = authorizationService;

      ConfigureController();
   }

   private void ConfigureController()
   {
      // Get attribute config from underlying type T
      var attrs = Attribute.GetCustomAttributes(typeof(T));
      if (attrs.FirstOrDefault(p => p.GetType() == typeof(ApiAttribute)) is ApiAttribute optionAttrib)
      {
         this.UseCache = optionAttrib.Options.Cache;
         this.FireEvent = optionAttrib.Options.FireEvents;
         this.MethodsToGenerate = optionAttrib.Options.Methods;

         // Check if we need to remove methods.
      }
      else
      {
         throw new Exception($"Could not find ApiAttribute on Class: {typeof(T)}");
      }
   }

   /// <summary>
   ///    Returns a list of <see cref="T" /> entries
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
   public IActionResult Query()
   {
      // Check if post is enabled
      if (!this.MethodsToGenerate.HasFlag(ApiMethodsToGenerate.Get))
         return BadRequest($"GET is disabled for {typeof(T).Name}");

      HttpContext.VerifyUserHasAnyAcceptedScope("read_all");


      if (!this.ModelState.IsValid)
         return BadRequest();

      return Ok(this.repository.Get());
   }

   [HttpGet("{id}")]
   public async Task<IActionResult> Find(TEntityId id)
   {
      // Check if post is enabled
      if (!this.MethodsToGenerate.HasFlag(ApiMethodsToGenerate.Get))
         return BadRequest($"GET is disabled for {typeof(T).Name}");


      

      if (!this.ModelState.IsValid)
         return BadRequest();

      var record = await this.repository.GetAsync(id);


      return Ok(record);
   }


   [HttpPost]
   public async Task<IActionResult> Create([FromBody] T record)
   {
      try
      {
         // Check if post is enabled
         if (!this.MethodsToGenerate.HasFlag(ApiMethodsToGenerate.Insert))
            return BadRequest($"POST is disabled for {record.GetType().Name}");

         // Check if payload is valid
         if (!this.ModelState.IsValid)
            return BadRequest();

         // Create the new entry
         this.repository.Create(record);
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
         if (!this.MethodsToGenerate.HasFlag(ApiMethodsToGenerate.Update))
            return BadRequest($"PUT is disabled for {record.GetType().Name}");

         if (!this.ModelState.IsValid)
            return BadRequest();

         var existingRecord = await this.repository.GetAsync(id);
         if (existingRecord == null) return NotFound();

         this.repository.Update(record, existingRecord);
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
         if (!this.MethodsToGenerate.HasFlag(ApiMethodsToGenerate.Delete))
            return BadRequest("DELETE is disabled");

         if (!this.ModelState.IsValid)
            return BadRequest();

         var existingRecord = await this.repository.GetAsync(id);
         if (existingRecord == null) return NotFound();

         this.repository.Delete(id);
         if (await this.repository.SaveAsync() == 0)
            return BadRequest();

         return NoContent();
      }
      catch (Exception ex)
      {
         return BadRequest(ex.Message);
      }
   }
}
