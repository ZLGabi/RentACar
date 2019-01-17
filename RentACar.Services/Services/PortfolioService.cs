using RentACar.DataContext.Models;
using RentACar.RepositoryInfrastructure;
using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RentACar.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IRepository<Portfolio> _portfolioRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PortfolioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _portfolioRepository = _unitOfWork.GetRepository<Portfolio>();
        }

        public PortfolioDTO GetPortfolioById(int id)
        {
            var portfolio = _portfolioRepository.Get(id);
            var portfolioDTO = AutoMapper.Mapper.Map<PortfolioDTO>(portfolio);
            return portfolioDTO;
        }

        public PortfolioDTO GetPortfolioDetails(int id)
        {
            var portfolio = _portfolioRepository.GetAll()
                .Include(i => i.Photo)
                .Include(c => c.Cars.Select(x => x.MainPhoto))
                .FirstOrDefault(p => p.PortfolioId == id);
            var portfolioDTO = AutoMapper.Mapper.Map<PortfolioDTO>(portfolio);
            return portfolioDTO;
        }

        public IEnumerable<PortfolioListDTO> GetPortfolios()
        {
            var portfolios = _portfolioRepository.GetAll().Include(p => p.Photo).Include(c => c.Cars).ToList();
            var portfoliosDTO = AutoMapper.Mapper.Map<List<PortfolioListDTO>>(portfolios);
            return portfoliosDTO;
        }

        public void AddPortfolio(PortfolioDTO portfolioDTO)
        {
            var portfolio = AutoMapper.Mapper.Map<Portfolio>(portfolioDTO);
            _portfolioRepository.Add(portfolio);
            _unitOfWork.Commit();
        }

        public void UpdatePortfolio(PortfolioDTO portfolioDTO)
        {
            var portfolio = AutoMapper.Mapper.Map<Portfolio>(portfolioDTO);
            _portfolioRepository.Update(portfolio);
            _unitOfWork.Commit();
        }

        public void DeletePortfolio(PortfolioDTO portfolioDTO)
        {
            var portfolio = AutoMapper.Mapper.Map<Portfolio>(portfolioDTO);
            _portfolioRepository.Delete(portfolio);
            _unitOfWork.Commit();
        }
    }
}
