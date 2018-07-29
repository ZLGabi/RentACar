using RentACar_MVC.DBContext;
using RentACar_MVC.Repositories;

namespace RentACar_MVC.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentingContext _context;
        public UnitOfWork(RentingContext context)
        {
            _context = context;
            Cars = new CarRepository(_context);
            Portfolios = new PortfolioRepository(_context);
            Reservations = new ReservationRepository(_context);
        }
        public ICarRepository Cars { get; }
        public IPortfoliosRepository Portfolios { get; }
        public IReservationRepository Reservations { get; }

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