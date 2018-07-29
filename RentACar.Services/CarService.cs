using System.Collections.Generic;
using RentACar.RepositoryInfrastructure;
using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System.Data.Entity;
using RentACar.DataContext.Models;

namespace RentACar.Services
{
    public class CarService : ICarService
    {
        private readonly Repository<Car> _carRepository;
        public CarService(DbContext context)
        {
            _carRepository = new Repository<Car>(context);
        }

        public IEnumerable<CarDTO> GetCarsByPortfolioId(int id)
        {
            var cars = _carRepository.Find(p => p.Portfolio.PortfolioId == id);
            return cars;
        }
    }
}
