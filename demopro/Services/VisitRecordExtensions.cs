using demopro.Models;

namespace demopro.Services
{
    public static class VisitRecordExtensions
    {
        public static CoffeeShop ToCoffeeShop(this UserVisitRecord record)
        {
            return new CoffeeShop
            {
                Name = record.CoffeeShopName,
                VisitCount = record.VisitCount,
                // Add dummy location if needed
                Latitude = 0,
                Longitude = 0,
                Rating = 0
            };
        }
    }
}
// This extension method converts a UserVisitRecord to a CoffeeShop object.