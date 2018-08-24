using RentACar.RepositoryInfrastructure;
using RentACar.Services;
using RentACar.ServicesInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortfoliosService _portfolioService;
        private readonly ICarService _carService;
        public HomeController()
        {
            _portfolioService= new PortfolioService(new UnitOfWork());
            _carService = new CarService(new UnitOfWork());
        }
        public ActionResult Index()
        {
                return View(_portfolioService.GetPortfoliosByName("Portfolio"));
        }

        public ActionResult About()
        {
            return View(_carService.GetCars());
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}