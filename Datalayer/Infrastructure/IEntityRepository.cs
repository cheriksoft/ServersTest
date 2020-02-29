using System.Collections.Generic;
using System.Linq;
using Datalayer.Entities;

namespace Datalayer.Repositories
{
    /// <summary>
    /// Generic репозиторий для работы с сущностями, для того, чтобы не пихнуть ему левые типы, не сущностей - стоит защита, можно давать только типы, реализующие IEntity
    /// </summary>
    public interface IEntityRepository
    {
        IQueryable<TEntity> GetTable<TEntity>() where TEntity : class, IEntity;
        void Insert<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;
        void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;
        void SaveChanges();
    }
}