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
        private readonly IPortfolioService _portfolioService;
        private readonly ICarService _carService;
        public HomeController(IPortfolioService portfolioService, ICarService carService)
        {
            _portfolioService= portfolioService;
            _carService = carService;
        }
        public ActionResult Index()
        {
                return View(_portfolioService.GetPortfolios());
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