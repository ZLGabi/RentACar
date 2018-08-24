using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace RentACar.RepositoryInfrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly IDbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity Get(int id, params string[] includeProperties)
        {
            var propertyName = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)_context).ObjectContext
        .CreateObjectSet<TEntity>().EntitySet.ElementType.KeyMembers.Single().Name;

            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var predicate = Expression.Lambda<Func<TEntity, bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(parameter, propertyName),
                    Expression.Constant(id)),
                parameter);

            var query = _dbSet.AsQueryable();
            if (includeProperties != null && includeProperties.Length > 0)
                query = includeProperties.Aggregate(query, System.Data.Entity.QueryableExtensions.Include);
            return query.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>> selector = null)
        {
            if (selector != null)
            {
                var propertyName = RepositoryHelper.GetPropertyName(selector);
                return _dbSet.Include(propertyName).ToList();
            }
            return _dbSet.ToList();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> selector = null)
        {
            if (selector != null)
            {
                var propertyName = RepositoryHelper.GetPropertyName(selector);
                return _dbSet.Where(predicate).Include(propertyName);
            }
            return _dbSet.Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
