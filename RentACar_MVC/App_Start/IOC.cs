using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
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
            builder.Register<IdentityDbContext>(c => new RentACarDataContext());

            //Register UserManager and RoleManager
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationRoleStore>().As<IRoleStore<Role, string>>().InstancePerRequest();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();

            //Register Services
            builder.RegisterType<CarService>().As<ICarService>().InstancePerRequest();
            builder.RegisterType<PortfolioService>().As<IPortfolioService>().InstancePerRequest();
            builder.RegisterType<ReservationService>().As<IReservationService>().InstancePerRequest();
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerRequest();

            //Set the Dependency Resolver
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}