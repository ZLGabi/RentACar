using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentACar.DataContext.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        [Required]
        public virtual Photo Photo { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
