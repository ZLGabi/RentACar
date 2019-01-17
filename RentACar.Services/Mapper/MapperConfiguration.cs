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
