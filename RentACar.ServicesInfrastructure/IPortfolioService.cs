using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;

namespace RentACar.ServicesInfrastructure
{
    public interface IPortfolioService 
    {
        PortfolioDTO GetPortfolioById(int id, params string[] includeProperties);
        IEnumerable<PortfolioDTO> GetPortfoliosByName(string name);
        IEnumerable<PortfolioDTO> GetPortfolios();
        void AddPortfolio(PortfolioDTO portfolioDTO);
        void UpdatePortfolio(PortfolioDTO portfolioDTO);
        void DeletePortfolio(PortfolioDTO portfolioDTO);
    }
}
