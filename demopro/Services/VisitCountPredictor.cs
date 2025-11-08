using demopro.Models;

namespace demopro.Services
{
    public class VisitCountPredictor : ICoffeePredictor
    {
        public CoffeeShop? Predict(List<UserVisitRecord> history, List<CoffeeShop> allShops)
        {
            var mostVisited = history.MaxBy(c => c.VisitCount);
            if (mostVisited == null) return null;

            return new CoffeeShop
            {
                Name = mostVisited.CoffeeShopName,
                VisitCount = mostVisited.VisitCount,
                // Optional: add dummy coordinates or additional metadata if needed
                Latitude = 0,
                Longitude = 0,
                Rating = 0
            };
        }
    }
}
