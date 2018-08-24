using System.Collections.Generic;
using RentACar.RepositoryInfrastructure;
using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System.Data.Entity;
using RentACar.DataContext.Models;
using System;

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

        public CarDTO GetCarById(int id, params string[] includeProperties)
        {
            var car = _carRepository.Get(id, includeProperties);
            var carDTO = AutoMapper.Mapper.Map<CarDTO>(car);
            return carDTO;
        }

        public IEnumerable<CarDTO> GetCarsByPortfolioId(int id)
        {
            var cars = _carRepository.Find(p => p.Portfolio.PortfolioId == id, p => p.Portfolio);
            var carsDTO = AutoMapper.Mapper.Map<IEnumerable<CarDTO>>(cars);
            return carsDTO;
        }

        public IEnumerable<CarDTO> GetCarsByName(string name)
        {
            var cars = _carRepository.Find(c => (c.Brand.StartsWith(name) || c.Model.StartsWith(name)),p=>p.Portfolio);
            var carsDTO = AutoMapper.Mapper.Map<IEnumerable<CarDTO>>(cars);
            return carsDTO;
        }

        public IEnumerable<CarDTO> GetCars()
        {
            var cars = _carRepository.GetAll(c=>c.Portfolio);
            var carsDTO = AutoMapper.Mapper.Map<IEnumerable<CarDTO>>(cars);
            return carsDTO;
        }

        public void AddCar(CarDTO carDTO)
        {
            var car = AutoMapper.Mapper.Map<Car>(carDTO);
            _carRepository.Add(car);
            _unitOfWork.Commit();
        }

        public void UpdateCar(CarDTO carDTO)
        {
            var car = AutoMapper.Mapper.Map<Car>(carDTO);
            _carRepository.Update(car);
            _unitOfWork.Commit();
        }

        public void RemoveCar(CarDTO carDTO)
        {
            var car = AutoMapper.Mapper.Map<Car>(carDTO);
            _carRepository.Delete(car);
            _unitOfWork.Commit();
        }
    }
}
