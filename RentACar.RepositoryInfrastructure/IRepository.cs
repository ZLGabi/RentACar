using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RentACar.RepositoryInfrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id, params string[] includeProperties);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>> selectors = null);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> selector = null);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
