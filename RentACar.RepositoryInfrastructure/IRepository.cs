using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RentACar.RepositoryInfrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
