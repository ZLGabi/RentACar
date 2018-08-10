using RentACar.RepositoryInfrastructure;
using System;

namespace RentACar.RepositoryInfrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Commit();
    }
}
