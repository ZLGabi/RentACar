using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Services.Mapper
{
    public static class MapperConfiguration
    {
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(m => 
            {
                m.AddProfile<RentACarProfile>();
            });
        }
    }
}
