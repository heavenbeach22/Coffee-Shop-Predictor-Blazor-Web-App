namespace demopro.Models
{
    public class UserVisitRecord
    {
        public string CoffeeShopName { get; set; } = "";
        public int VisitCount { get; set; }
        public DateTime? LastVisited { get; set; }
    }
}
