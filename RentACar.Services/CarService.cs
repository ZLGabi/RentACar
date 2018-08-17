﻿using System.Collections.Generic;
using RentACar.RepositoryInfrastructure;
using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System.Data.Entity;
using RentACar.DataContext.Models;

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

        public IEnumerable<CarDTO> GetCarsByPortfolioId(int id)
        {
            var cars = _carRepository.Find(p => p.Portfolio.PortfolioId == id);
            var carsDTO = AutoMapper.Mapper.Map<IEnumerable<CarDTO>>(cars);
            return carsDTO;
        }
    }
}
