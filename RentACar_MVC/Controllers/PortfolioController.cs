using RentACar.ServicesInfrastructure;
using System.Web.Mvc;

namespace RentACar_MVC.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        // GET: Portfolios
        public ActionResult Index()
        {
            var portfolios = _portfolioService.GetPortfolios();
            return View(portfolios);
        }

        // GET: Portfolios/Details/5
        public ActionResult Details(int id)
        {
            var portfolio = _portfolioService.GetPortfolioDetails(id);
            return View(portfolio);
        }

        // GET: Portfolios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfolios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Portfolios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Portfolios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Portfolios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Portfolios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
