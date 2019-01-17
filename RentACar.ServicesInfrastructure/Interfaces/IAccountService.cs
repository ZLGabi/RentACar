using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace RentACar.ServicesInfrastructure
{
    public interface IAccountService
    {
        UserDTO GetUser(string id);
        List<UserDTO> GetUsers();
        IdentityResult AddUser(UserDTO userDTO, string password);
        IdentityResult UpdateUser(UserDTO userDTO);
        IdentityResult DeleteUser(UserDTO userDTO);
        bool UserExists(string username);
        IdentityResult AddUserToRole(string username, string roleName);
        void ClearUserRoles(string userId);
        void Login(UserLoginDTO userLoginDTO);
        void Logout();
    }
}