using System.ComponentModel;

namespace RentACar.ServicesInfrastructure.DTO
{
    public class UserLoginDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
