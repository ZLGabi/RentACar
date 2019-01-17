using Microsoft.AspNet.Identity;
using RentACar.DataContext.Models;

namespace RentACar.DataContext
{
    public class ApplicationRoleManager : RoleManager<Role>
    {
        public ApplicationRoleManager(IRoleStore<Role, string> store) : base(store)
        {

        }
    }
}
