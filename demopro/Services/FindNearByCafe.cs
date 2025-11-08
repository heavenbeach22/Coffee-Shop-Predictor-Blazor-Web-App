using demopro.Models;

namespace demopro.Services
{
    public class FindNearByCafe
    {
        private DataManager _dataManager;

        public FindNearByCafe(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        // Main method: Get all shops near user's location
        public async Task<List<CoffeeShop>> GetNearbyCoffeeShops(double userLat, double userLng, double maxDistanceKm = 20.0)
        {
            var allShops = await _dataManager.LoadCafesAsync();
            var nearby = new List<CoffeeShop>();

            foreach (var shop in allShops)
            {
                double distance = CalculateDistance(userLat, userLng, shop.Latitude, shop.Longitude);
                Console.WriteLine($"{shop.Name} is {distance:F2} km away");
                if (distance <= maxDistanceKm)
                {
                    shop.DistanceFromUser = Math.Round(distance, 2); // Optional: display to user
                    nearby.Add(shop);
                }
            }

            // Sort by distance
            return nearby.OrderBy(s => s.DistanceFromUser).ToList();
            
        }

        //  Print nicely in console
        public void DisplayNearbyCoffeeShops(List<CoffeeShop> shops)
        {
            if (shops.Count == 0)
            {
                Console.WriteLine("No coffee shops nearby 🥲");
                return;
            }

            Console.WriteLine("☕ Nearby Coffee Shops:");
            foreach (var shop in shops)
            {
                Console.WriteLine($"- {shop.Name} | {shop.Address} | {shop.DistanceFromUser} km away");
            }
        }

        // Distance calculation using GeoCoordinate (Haversine formula under the hood)
        public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Earth radius in km

            double dLat = DegreesToRadians(lat2 - lat1);
            double dLon = DegreesToRadians(lon2 - lon1);

            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }

        public double DegreesToRadians(double deg)
        {
            return deg * (Math.PI / 180);
        }
    }
}
