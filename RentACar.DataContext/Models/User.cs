using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DataContext.Models
{
    public class User : IdentityUser
    {
        public override string Id { get; set; }
        public virtual UserPhoto Photo { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
