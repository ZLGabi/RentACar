using RentACar.DataContext;
using RentACar.ServicesInfrastructure;
using System.Data.Entity;

namespace RentACar.Services
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
            CarService = new CarService(_context);
            PortfolioService = new PortfolioService(_context);
            ReservationService = new ReservationService(_context);
        }
        public ICarService CarService { get; }
        public IPortfoliosService PortfolioService { get; }
        public IReservationService ReservationService { get; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
