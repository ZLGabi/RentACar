using Microsoft.AspNet.Identity;
using RentACar.DataContext.Models;

namespace RentACar.DataContext
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
        }
    }
}
