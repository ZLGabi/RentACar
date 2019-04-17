using System.Collections.Generic;

namespace RentACar.DataContext.Models
{
    public class User 
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual UserPhoto Photo { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
