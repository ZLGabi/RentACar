using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DataContext.Models
{
    public class PortfolioPhoto
    {
        [ForeignKey("Portfolio")]
        public int PortfolioPhotoId { get; set; }
        public string Url { get; set; }

        public virtual Portfolio Portfolio { get; set; }
    }
}
