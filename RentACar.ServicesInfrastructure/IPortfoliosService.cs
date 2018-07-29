using RentACar.ServicesInfrastructure.DTO;

namespace RentACar.ServicesInfrastructure
{
    public interface IPortfoliosService 
    {
        PortfolioDTO GetPortfolioByName(string name);
    }
}
