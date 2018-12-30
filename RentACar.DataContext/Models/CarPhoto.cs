using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DataContext.Models
{
    public class CarPhoto
    {
        [ForeignKey("CarMainPhoto")]
        public int CarPhotoId { get; set; }
        public string Url { get; set; }
        
        public virtual Car CarMainPhoto { get; set; }
    }
}
