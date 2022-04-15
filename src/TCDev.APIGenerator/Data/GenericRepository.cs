// TCDev.de 2022/03/16
// TCDev.APIGenerator.GenericRepository.cs
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCDev.ApiGenerator.Interfaces;
using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.ApiGenerator.Data;

public class GenericRespository<TEntity, TEntityId> : IGenericRespository<TEntity, TEntityId>
   where TEntity : class, IObjectBase<TEntityId>
{
   private DbContext context;

   public GenericRespository(GenericDbContext context)
   {
      this.context = context;
   }

   public IQueryable<TEntity> Get()
   {
      return this.context.Set<TEntity>();
   }

   public TEntity Get(TEntityId id)
   {
      return Get()
         .SingleOrDefault(e => e.Id.ToString() == id.ToString());
   }

   public async Task<TEntity> GetAsync(TEntityId id)
   {
      return await Get()
         .SingleOrDefaultAsync(e => e.Id.ToString() == id.ToString());
   }

   public void Create(TEntity record)
   {
      var now = DateTime.UtcNow;


      this.context.Add(record);


      if (typeof(TEntity).IsAssignableFrom(typeof(IHasTrackingFields)))
         this.context.Entry(record)
            .Property<DateTime>("Created")
            .CurrentValue = now;
   }

   public async void Update(TEntity newRecord, TEntity oldRecord)
   {
      // We have a before update handler
      if (typeof(TEntity).IsAssignableTo(typeof(IBeforeUpdate<TEntity>)))
      {
         var baseEntity = newRecord as IBeforeUpdate<TEntity>;
         newRecord = await baseEntity.BeforeUpdate(newRecord, oldRecord);
      }

      this.context.Set<TEntity>()
         .Attach(oldRecord);
      oldRecord = newRecord;

      if (typeof(TEntity).IsAssignableFrom(typeof(IHasTrackingFields)))
      {
         this.context.Entry(newRecord)
            .Property<DateTime>("LastModified")
            .CurrentValue = DateTime.UtcNow;
         this.context.Entry(newRecord)
            .State = EntityState.Modified;
      }

      await this.context.SaveChangesAsync();

      // We have a after update handler
      if (typeof(TEntity).IsAssignableTo(typeof(IAfterUpdate<TEntity>)))
      {
         var baseEntity = newRecord as IAfterUpdate<TEntity>;
         await baseEntity.AfterUpdate(newRecord, oldRecord);
      }
   }

   public void Delete(TEntityId id)
   {
      var record = Get(id);

      if (record != null)
      {
         // If the entity is using softdelete -> only mark as deleted
         if (typeof(TEntity).IsAssignableFrom(typeof(ISoftDelete)))
         {
            this.context.Entry(record)
               .Property<DateTime>("Deleted")
               .CurrentValue = DateTime.UtcNow;
            this.context.Entry(record)
               .Property<bool>("IsDeleted")
               .CurrentValue = true;
            this.context.Entry(record)
               .State = EntityState.Modified;
         }
         else
         {
            this.context.Remove(record);
         }
      }
   }

   public Task<int> SaveAsync()
   {
      return this.context.SaveChangesAsync();
   }


   public int Save()
   {
      return this.context.SaveChanges();
   }

   public IQueryable<TEntity> GetQuery(Type entityType)
   {
      var pq =
         from p in GetType()
            .GetProperties()
         where p.PropertyType.IsGenericType
               && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)
               && p.PropertyType.GenericTypeArguments[0] == entityType
         select p;
      var prop = pq.Single();

      return (IQueryable<TEntity>)prop.GetValue(this);
   }

   #region Dispose

   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }

   protected virtual void Dispose(bool disposing)
   {
      if (disposing)
         if (this.context != null)
         {
            this.context.Dispose();
            this.context = null;
         }
   }

   #endregion
}
