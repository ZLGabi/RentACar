using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;

namespace RentACar.ServicesInfrastructure
{
    public interface IAccountService
    {
        UserDTO GetUser(int id);
        List<UserDTO> GetUsers();
        List<UserDTO> GetManagers();
        List<UserDTO> GetCustomers();
        void AddUser(UserDTO userDTO);
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(UserDTO userDTO);
        bool UserExists(string username);
        void AddUserToRole(string username, string roleName);
        void ClearUserRoles(int userId);
        void Login(UserLoginDTO userLoginDTO);
        void Logout();
    }
}