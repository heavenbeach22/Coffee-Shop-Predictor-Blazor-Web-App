namespace demopro.Models
{
    public class CoffeeShop
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } = "Tân Bình, HCMC";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Rating { get; set; }
        public double DistanceFromUser { get; set;}
        public int VisitCount { get; set; } = 0;
        

    }
}
