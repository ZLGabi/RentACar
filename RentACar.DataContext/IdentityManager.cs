using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RentACar.DataContext.Models;
using System.Collections.Generic;

namespace RentACar.DataContext
{
    public class IdentityManager
    {
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new RentACarDataContext()));
            return rm.RoleExists(name);
        }


        public bool CreateRole(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new RentACarDataContext()));
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }


        public bool CreateUser(User user, string password)
        {
            var um = new UserManager<User>(
                new UserStore<User>(new RentACarDataContext()));
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }


        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<User>(
                new UserStore<User>(new RentACarDataContext()));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }


        public void ClearUserRoles(string userId)
        {
            var um = new UserManager<User>(
                new UserStore<User>(new RentACarDataContext()));
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new RentACarDataContext()));
            var user = um.FindById(userId);
            var currentUserRoles = new List<IdentityUserRole>();
            currentUserRoles.AddRange(user.Roles);
            foreach (var userRole in currentUserRoles)
            {
                um.RemoveFromRole(userId, rm.FindById(userRole.RoleId).Name);
            }
        }
    }
}
