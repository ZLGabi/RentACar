using RentACar.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RentACar.RepositoryInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentACarDbContext _context;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork()
        {
            _context = new RentACarDbContext();
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;

            var repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
