using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DataContext.Models
{
    public class CarGallery
    {
        public int CarGalleryId { get; set; }
        public string Url { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
