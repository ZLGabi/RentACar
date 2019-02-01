using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System;
using System.Web.Mvc;

namespace RentACar_MVC.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public ActionResult Index()
        {
            var reservations = _reservationService.GetReservations(HttpContext.User.Identity.Name);
            return View(reservations);
        }

        // GET: Reservations/Create
        public ActionResult Create(int carId)
        {
            return View();
        }

        // POST: Reservations/Create
        [HttpPost]
        public ActionResult Create(ReservationCreationDTO reservationDTO)
        {
                if (ModelState.IsValid)
                {
                    _reservationService.AddReservation(reservationDTO);
                    return RedirectToAction("Index");
                }

                return View();
        }

        [ChildActionOnly]
        public ActionResult ReservedCar(int carId)
        {
            var car = _reservationService.GetCarForReservation(carId);
            return PartialView("_ReservedCar", car);
        }

        [ChildActionOnly]
        public ActionResult Periods()
        {
            var periods = _reservationService.GetPeriods();
            return PartialView("_Periods", periods);
        }

        [HttpPut]
        public ActionResult Cancel(int id)
        {
            var reservationDTO = _reservationService.GetReservation(User.Identity.Name, id);
            _reservationService.CancelReservation(reservationDTO);
            return RedirectToAction("Index");
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservations/Edit/5
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

        // GET: Reservations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservations/Delete/5
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
