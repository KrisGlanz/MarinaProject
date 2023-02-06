namespace MarinaProject.Models
{
    public class Boat
    {
        public int BoatId { get; set; }
        public int CustomerId { get; set; }
        public int BoatType { get; set; }
        public Boolean Registration { get; set; }
        public int BoatLength { get; set; }
        public string Manufacturer { get; set; }
    }
}
