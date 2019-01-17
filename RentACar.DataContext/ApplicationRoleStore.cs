using Microsoft.AspNet.Identity.EntityFramework;
using RentACar.DataContext.Models;

namespace RentACar.DataContext
{
    public class ApplicationRoleStore : RoleStore<Role>
    {
        public ApplicationRoleStore(IdentityDbContext context)
           : base(context)
        {
        }
    }
}
