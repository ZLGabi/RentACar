using RentACar.DataContext.Models;
using RentACar.RepositoryInfrastructure;
using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System.Data.Entity;

namespace RentACar.Services
{
    public class PortfolioService : IPortfoliosService
    {
        private readonly Repository<Portfolio> _portfolioRepository;
        public PortfolioService(DbContext context)
        {
            _portfolioRepository = new Repository<Portfolio>(context);
        }

        public PortfolioDTO GetPortfolioByName(string name)
        {
            var portfolio = _portfolioRepository.Find(p=>p.Name==name);
            return portfolio;
        }
    }
}
