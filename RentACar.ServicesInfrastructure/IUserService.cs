using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;

namespace RentACar.ServicesInfrastructure
{
    public interface IUserService
    {
        UserDTO GetUserById(int id);
        IEnumerable<UserDTO> GetUsers();
        void AddUser(UserDTO userDTO, string password);
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(UserDTO userDTO);
    }
}