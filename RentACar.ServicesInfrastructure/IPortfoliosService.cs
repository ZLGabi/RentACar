using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;

namespace RentACar.ServicesInfrastructure
{
    public interface IPortfoliosService 
    {
        PortfolioDTO GetPortfolioById(int id);
        PortfolioDTO GetPortfolioByName(string name);
        IEnumerable<PortfolioDTO> GetPortfolios();
        void AddPortfolio(PortfolioDTO portfolioDTO);
        void UpdatePortfolio(PortfolioDTO portfolioDTO);
        void DeletePortfolio(PortfolioDTO portfolioDTO);
    }
}
