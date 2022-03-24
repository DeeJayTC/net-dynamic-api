// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCDev.ApiGenerator.Interfaces;
using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.ApiGenerator.Data
{
   public class GenericRespository<TEntity, TEntityId> : IGenericRespository<TEntity, TEntityId>
      where TEntity : class, IObjectBase<TEntityId>
   {
      public GenericRespository(GenericDbContext context)
      {
         _context = context;
      }

      private DbContext _context;

      public IQueryable<TEntity> Get()
      {
         return _context.Set<TEntity>();
      }

      public TEntity Get(TEntityId id)
      {
         return Get().SingleOrDefault(e => e.Id.ToString() == id.ToString());
      }

      public async Task<TEntity> GetAsync(TEntityId id)
      {
         return await Get().SingleOrDefaultAsync(e => e.Id.ToString() == id.ToString());
      }

      public void Create(TEntity record)
      {
         var now = DateTime.UtcNow;


         _context.Add(record);


         if (typeof(TEntity).IsAssignableFrom(typeof(IHasTrackingFields))) _context.Entry(record).Property<DateTime>("Created").CurrentValue = now;
      }

      public async void Update(TEntity newRecord, TEntity oldRecord)
      {
         // We have a before update handler
         if (typeof(TEntity).IsAssignableTo(typeof(IBeforeUpdate<TEntity>)))
         {
            var baseEntity = newRecord as IBeforeUpdate<TEntity>;
            newRecord = await baseEntity.BeforeUpdate(newRecord, oldRecord);
         }

         _context.Set<TEntity>().Attach(oldRecord);
         oldRecord = newRecord;

         if (typeof(TEntity).IsAssignableFrom(typeof(IHasTrackingFields)))
         {
            _context.Entry(newRecord).Property<DateTime>("LastModified").CurrentValue = DateTime.UtcNow;
            _context.Entry(newRecord).State = EntityState.Modified;
         }

         await _context.SaveChangesAsync();

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
               _context.Entry(record).Property<DateTime>("Deleted").CurrentValue = DateTime.UtcNow;
               _context.Entry(record).Property<bool>("IsDeleted").CurrentValue = true;
               _context.Entry(record).State = EntityState.Modified;
            }
            else
            {
               _context.Remove(record);
            }
         }
      }

      public Task<int> SaveAsync()
      {
         return _context.SaveChangesAsync();
      }


      public int Save()
      {
         return _context.SaveChanges();
      }

      public IQueryable<TEntity> GetQuery(Type EntityType)
      {
         var pq = from p in GetType().GetProperties()
            where p.PropertyType.IsGenericType
                  && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)
                  && p.PropertyType.GenericTypeArguments[0] == EntityType
            select p;
         var prop = pq.Single();

         return (IQueryable<TEntity>) prop.GetValue(this);
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
            if (_context != null)
            {
               _context.Dispose();
               _context = null;
            }
      }

      #endregion
   }
}