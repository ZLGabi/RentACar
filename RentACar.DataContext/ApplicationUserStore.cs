using Microsoft.AspNet.Identity.EntityFramework;
using RentACar.DataContext.Models;

namespace RentACar.DataContext
{
    public class ApplicationUserStore : UserStore<User>
    {
        public ApplicationUserStore(IdentityDbContext context)
            : base(context)
        {
        }
    }
}
