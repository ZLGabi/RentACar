using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;

namespace RentACar.ServicesInfrastructure
{
    public interface ICarService
    {
        CarDTO GetCarById(int id, params string[] includeProperties);
        IEnumerable<CarDTO> GetCarsByPortfolioId(int id);
        IEnumerable<CarDTO> GetCarsByName(string name);
        IEnumerable<CarDTO> GetCars();
        void AddCar(CarDTO carDTO);
        void UpdateCar(CarDTO carDTO);
        void RemoveCar(CarDTO carDTO);
    }
}
