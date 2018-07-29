using RentACar_MVC.DBContext;
using RentACar_MVC.Models;

namespace RentACar_MVC.Repositories
{
    public class CarRepository:Repository<Car>, ICarRepository
    {
        public CarRepository(RentingContext context):base(context)
        {

        }

    }
}