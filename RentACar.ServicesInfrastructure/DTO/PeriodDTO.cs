using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.ServicesInfrastructure.DTO
{
    public class PeriodDTO
    {
        public int PeriodId { get; set; }
        public int Days { get; set; }
        public int PriceModifier { get; set; }
    }
}
