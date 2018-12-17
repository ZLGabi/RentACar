using System.Collections.Generic;
using RentACar.RepositoryInfrastructure;
using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System.Data.Entity;
using RentACar.DataContext.Models;
using System;
using System.Linq;

namespace RentACar.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _carRepository = _unitOfWork.GetRepository<Car>();
        }

        public CarListDTO GetCarById(int id)
        {
            var car = _carRepository.Get(id);
            var carDTO = AutoMapper.Mapper.Map<CarListDTO>(car);
            return carDTO;
        }

        public IEnumerable<CarListDTO> GetCarsByPortfolioId(int id)
        {
            var cars = _carRepository.Find(p => p.Portfolio.PortfolioId == id);
            var carsDTO = AutoMapper.Mapper.Map<IEnumerable<CarListDTO>>(cars);
            return carsDTO;
        }

        // public IEnumerable<CarListDTO> GetCarsByName(string name)
        // {
        //     var cars = _carRepository.Find(c => (c.Brand.StartsWith(name) || c.Model.StartsWith(name)));
        //     var carsDTO = AutoMapper.Mapper.Map<IEnumerable<CarListDTO>>(cars);
        //     return carsDTO;
        // }

        public CarDetailsDTO GetCarDetails(int id)
        {
            var car = _carRepository.GetAll().Include(p => p.Photos).Include(r => r.Reviews).FirstOrDefault(c => c.CarId == id);
            var carDTO = AutoMapper.Mapper.Map<CarDetailsDTO>(car);
            return carDTO;
        }

        public IEnumerable<CarListDTO> GetCars()
        {
            var cars = _carRepository.GetAll();
            var carsDTO = AutoMapper.Mapper.Map<IEnumerable<CarListDTO>>(cars);
            return carsDTO;
        }

        public void AddCar(CarCreationDTO carDTO)
        {
            var car = AutoMapper.Mapper.Map<Car>(carDTO);
            car.CreatedDate = DateTime.Now.Date.ToUniversalTime();
            car.ModifiedDate = DateTime.Now.Date.ToUniversalTime();
            _carRepository.Add(car);
            _unitOfWork.Commit();
        }

        public void UpdateCar(CarCreationDTO carDTO)
        {
            var car = AutoMapper.Mapper.Map<Car>(carDTO);
            car.ModifiedDate = DateTime.Now.Date.ToUniversalTime();
            _carRepository.Update(car);
            _unitOfWork.Commit();
        }

        public void RemoveCar(CarCreationDTO carDTO)
        {
            var car = AutoMapper.Mapper.Map<Car>(carDTO);
            _carRepository.Delete(car);
            _unitOfWork.Commit();
        }
    }
}
