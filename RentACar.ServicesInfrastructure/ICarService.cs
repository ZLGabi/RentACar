using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;

namespace RentACar.ServicesInfrastructure
{
    public interface ICarService
    {
        IEnumerable<CarDTO> GetCarsByPortfolioId(int id);
    }
}
