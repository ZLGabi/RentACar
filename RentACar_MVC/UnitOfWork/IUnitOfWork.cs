using RentACar_MVC.Repositories;
using System;

namespace RentACar_MVC.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        ICarRepository Cars { get; }
        IPortfoliosRepository Portfolios { get; }
        IReservationRepository Reservations { get; }
        int Save();
    }
}
