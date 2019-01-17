using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;

namespace RentACar.ServicesInfrastructure
{
    public interface ICarService
    {
        CarListDTO GetCarById(int id);
        CarDetailsDTO GetCarDetails(int id);
        IEnumerable<CarListDTO> GetCarsByPortfolioId(int id);
        IEnumerable<CarListDTO> GetCars();
        void AddCar(CarCreationDTO carDTO);
        void UpdateCar(CarCreationDTO carDTO);
        void RemoveCar(CarCreationDTO carDTO);
    }
}
