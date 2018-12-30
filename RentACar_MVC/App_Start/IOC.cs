using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using RentACar.DataContext;
using RentACar.DataContext.Models;
using RentACar.RepositoryInfrastructure;
using RentACar.Services;
using RentACar.ServicesInfrastructure;
using System.Web.Mvc;

namespace RentACar_MVC.App_Start
{
    public static class IOC
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();

            //Register MVC controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Register DB connection
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.Register<IdentityDbContext<User>>(c => new RentACarDataContext());

            //Register Services
            builder.RegisterType<CarService>().As<ICarService>().InstancePerRequest();
            builder.RegisterType<PortfolioService>().As<IPortfolioService>().InstancePerRequest();
            builder.RegisterType<ReservationService>().As<IReservationService>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();

            //Set the Dependency Resolver
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}