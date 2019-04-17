using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DataContext.Models
{
    public class UserPhoto
    {
        [ForeignKey("User")]
        public int UserPhotoId { get; set; }
        public string Url { get; set; }

        public virtual User User { get; set; }
    }
}
