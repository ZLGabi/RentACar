using System.Collections.Generic;

namespace RentACar.DataContext.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
