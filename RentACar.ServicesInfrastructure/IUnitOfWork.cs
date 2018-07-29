using System;

namespace RentACar.ServicesInfrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ICarService CarService { get; }
        IPortfoliosService PortfolioService { get; }
        IReservationService ReservationService { get; }
        int Save();
    }
}
