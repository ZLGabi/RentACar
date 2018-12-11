using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DataContext.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Url { get; set; }

        public virtual Car CarMainPhoto { get; set; }
        public int? CarPhotosId { get; set; }
        [ForeignKey("CarPhotosId")]
        public virtual Car CarPhotos { get; set; }

        public virtual User UserPhoto { get; set; }

        public virtual Portfolio PortfolioPhoto { get; set; }
    }
}
