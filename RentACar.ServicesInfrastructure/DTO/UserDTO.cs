namespace RentACar.ServicesInfrastructure.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public PhotoDTO Photo { get; set; }
        public RoleDTO Role { get; set; }
    }
}
