using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Datalayer.Entities;
using Datalayer.Infrastructure;

namespace Datalayer.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly IDbContextProvider dbContextProvider;

        public EntityRepository(IDbContextProvider dbContextProvider)
        {
            this.dbContextProvider = dbContextProvider;
        }

        private DbSet<TEntity> GetTableInternal<TEntity>() where TEntity : class, IEntity
        {
            return dbContextProvider.GetContext().Set<TEntity>();
        }

        public IQueryable<TEntity> GetTable<TEntity>() where TEntity : class, IEntity
        {
            return dbContextProvider.GetContext().Set<TEntity>();
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            GetTableInternal<TEntity>().Add(entity);
        }

        public void Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            GetTableInternal<TEntity>().AddRange(entities);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            GetTableInternal<TEntity>().Remove(entity);
        }

        public void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            GetTableInternal<TEntity>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            dbContextProvider.GetContext().SaveChanges();
        }
    }
}