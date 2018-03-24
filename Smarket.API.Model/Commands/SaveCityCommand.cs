namespace Smarket.API.Model.Commands
{
    public class SaveCityCommand
    {
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
