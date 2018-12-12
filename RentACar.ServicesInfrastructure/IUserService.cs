using RentACar.ServicesInfrastructure.DTO;

namespace RentACar.ServicesInfrastructure
{
    public interface IUserService
    {
         UserDTO GetUserById(int id);
        IEnumerable<UserDTO> GetUsers();
         void AddUser(UserDTO userDTO);
         void UpdateUser(UserDTO userDTO);
         void DeleteUser(UserDTO userDTO);
    }
}