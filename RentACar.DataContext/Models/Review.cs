using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataContext.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int? CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
