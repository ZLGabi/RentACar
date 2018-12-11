using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.ServicesInfrastructure.DTO
{
    public class ReviewDTO
    {
        public int Reviewid { get; set; }
        public string Reviewer { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
