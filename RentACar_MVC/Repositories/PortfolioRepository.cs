using RentACar_MVC.DBContext;
using RentACar_MVC.Models;

namespace RentACar_MVC.Repositories
{
    public class PortfolioRepository:Repository<Portfolio>,IPortfoliosRepository
    {
        public PortfolioRepository(RentingContext context) : base(context)
        {
            
        }
    }
}