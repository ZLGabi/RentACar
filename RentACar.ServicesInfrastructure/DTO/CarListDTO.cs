namespace RentACar.ServicesInfrastructure.DTO
{
    public class CarListDTO
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public CarPhotoDTO MainPhoto { get; set; }
        public string PortfolioName { get; set; }
        public int PortfolioId { get; set; }
    }
}
