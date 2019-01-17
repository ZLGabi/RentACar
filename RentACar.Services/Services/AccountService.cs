using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RentACar.DataContext;
using RentACar.DataContext.Models;
using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using System.Data.Entity;

namespace RentACar.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationRoleManager _roleManager;

        public AccountService(
            ApplicationUserManager userManager,
            ApplicationRoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public UserDTO GetUser(string id)
        {
            var user = _userManager.Users.Include(p => p.Photo).FirstOrDefault(u => u.Id == id);
            var userDTO = AutoMapper.Mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public List<UserDTO> GetUsers()
        {
            var users = _userManager.Users.Include(p => p.Photo).ToList();
            var usersDTO = AutoMapper.Mapper.Map<List<UserDTO>>(users);
            return usersDTO;
        }

        public IdentityResult AddUser(UserDTO userDTO, string password)
        {
            var user = new User
            {
                UserName = userDTO.Username,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber
            };
            var result = _userManager.Create(user, password);
            return result;
        }

        public IdentityResult UpdateUser(UserDTO userDTO)
        {
            var user = AutoMapper.Mapper.Map<User>(userDTO);
            var result = _userManager.Update(user);
            return result;
        }

        public IdentityResult DeleteUser(UserDTO userDTO)
        {
            var user = AutoMapper.Mapper.Map<User>(userDTO);
            var result = _userManager.Delete(user);
            return result;
        }

        public bool UserExists(string username)
        {
            if (_userManager.Users.Any(x => x.UserName == username))
                return true;

            return false;
        }

        public IdentityResult AddUserToRole(string username, string roleName)
        {
            var userId = _userManager.Users.FirstOrDefault(u => u.UserName == username).Id;
            var result = _userManager.AddToRole(userId, roleName);
            return result;
        }

        public void ClearUserRoles(string userId)
        {
            var user = _userManager.FindById(userId);
            var currentUserRoles = new List<IdentityUserRole>();
            currentUserRoles.AddRange(user.Roles);
            foreach (var userRole in currentUserRoles)
            {
                _userManager.RemoveFromRole(userId, _roleManager.FindById(userRole.RoleId).Name);
            }
        }

        public void Login(UserLoginDTO userLoginDTO)
        {
            var user = _userManager.Find(userLoginDTO.Username, userLoginDTO.Password);
            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

            }
        }

        public void Logout()
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
        }
    }
}