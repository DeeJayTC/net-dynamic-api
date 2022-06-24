// TCDev.de 2022/03/16
// TCDev.APIGenerator.GenericRepository.cs
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TCDev.APIGenerator.Interfaces;
using TCDev.APIGenerator.Schema.Interfaces;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Hooks;

namespace TCDev.APIGenerator.Data;

public class GenericRespository<TEntity, TEntityId> : IGenericRespository<TEntity, TEntityId>
   where TEntity : class, IObjectBase<TEntityId>
{
    private readonly IApplicationDataService<GenericDbContext, AuthDbContext> data;

    public GenericRespository(IApplicationDataService<GenericDbContext, AuthDbContext> data)
    {
        this.data = data;
    }

    public IQueryable<TEntity> Get()
    {
        return this.data.GenericData.Set<TEntity>();
    }

    public TEntity Get(TEntityId id)
    {
        return Get()
           .SingleOrDefault(e => e.Id.ToString() == id.ToString());
    }

    public async Task<TEntity> GetAsync(TEntityId id, IApplicationDataService<GenericDbContext, AuthDbContext> data)
    {
        return await Get()
           .SingleOrDefaultAsync(e => e.Id.ToString() == id.ToString());
    }

    public async void Create(TEntity record, IApplicationDataService<GenericDbContext, AuthDbContext> data)
    {
        // We have a before update handler
        if (typeof(TEntity).IsAssignableTo(typeof(IBeforeCreate<TEntity>)))
        {
            var baseEntity = record as IBeforeCreate<TEntity>;
            record = await baseEntity.BeforeCreate(record, data);
        }


        this.data.GenericData.Add(record);

        if (typeof(TEntity).IsAssignableFrom(typeof(IHasTrackingFields)))
            this.data.GenericData.Entry(record)
                .Property<DateTime>("Created")
                .CurrentValue = DateTime.UtcNow;



        if (typeof(TEntity).IsAssignableTo(typeof(IAfterCreate<TEntity>)))
        {
            var baseEntity = record as IBeforeCreate<TEntity>;
            await baseEntity.BeforeCreate(record, data);
        }
    }

    public async void Update(TEntity newRecord, TEntity oldRecord, IApplicationDataService<GenericDbContext, AuthDbContext> data)
    {
        // We have a before update handler
        if (typeof(TEntity).IsAssignableTo(typeof(IBeforeUpdate<TEntity>)))
        {
            var baseEntity = newRecord as IBeforeUpdate<TEntity>;
            newRecord = await baseEntity.BeforeUpdate(newRecord, oldRecord, data);
        }

        this.data.GenericData.Set<TEntity>()
         .Attach(oldRecord);
        oldRecord = newRecord;

        if (typeof(TEntity).IsAssignableFrom(typeof(IHasTrackingFields)))
        {
            this.data.GenericData.Entry(newRecord)
            .Property<DateTime>("LastModified")
            .CurrentValue = DateTime.UtcNow;
            this.data.GenericData.Entry(newRecord)
            .State = EntityState.Modified;
        }

        await this.data.GenericData.SaveChangesAsync();

        // We have a after update handler
        if (typeof(TEntity).IsAssignableTo(typeof(IAfterUpdate<TEntity>)))
        {
            var baseEntity = newRecord as IAfterUpdate<TEntity>;
            await baseEntity.AfterUpdate(newRecord, oldRecord, data);
        }
    }

    public void Delete(TEntityId id, IApplicationDataService<GenericDbContext, AuthDbContext> data)
    {
        var record = Get(id);

        if (record != null)
        {
            // If the entity is using softdelete -> only mark as deleted
            if (typeof(TEntity).IsAssignableFrom(typeof(ISoftDelete)))
            {
                this.data.GenericData.Entry(record)
                .Property<DateTime>("Deleted")
                .CurrentValue = DateTime.UtcNow;
                this.data.GenericData.Entry(record)
                .Property<bool>("IsDeleted")
                .CurrentValue = true;
                this.data.GenericData.Entry(record)
                .State = EntityState.Modified;
            }
            else
            {
                this.data.GenericData.Remove(record);
            }
        }
    }


    public Task<int> SaveAsync()
    {
        return this.data.GenericData.SaveChangesAsync();
    }


    public int Save()
    {
        return this.data.GenericData.SaveChanges();
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
            if (this.data.GenericData != null)
            {
                this.data.GenericData.Dispose();
                this.data.GenericData = null;
            }
    }

    #endregion

}
