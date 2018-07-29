using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentACar_MVC.DBContext;
using RentACar_MVC.Models;

namespace RentACar_MVC.Repositories
{
    public class ReservationRepository:Repository<Reservation>,IReservationRepository
    {
        public ReservationRepository(RentingContext context) : base(context)
        {
            
        }
    }
}