using demopro.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace demopro.Services
{
    public static class GeoJsonParser
    {
        public static List<CoffeeShop> Parse(string json)
        {
            var geoData = JsonSerializer.Deserialize<GeoJsonRoot>(json);
            var shops = new List<CoffeeShop>();
            var rand = new Random();

            if (geoData?.Features != null)
            {
                foreach (var feature in geoData.Features)
                {
                    if (feature.Properties?.Name == null || feature.Geometry?.Coordinates == null)
                        continue;

                    shops.Add(new CoffeeShop
                    {
                        Id = feature.Properties.OSMId ?? feature.Id,
                        Name = feature.Properties.Name ?? "Unnamed coffee shop",
                        Latitude = feature.Geometry.Coordinates[1],
                        Longitude = feature.Geometry.Coordinates[0],
                        Rating = Math.Round(rand.NextDouble() * 2 + 3.5, 1)
                    });
                }
            }
            return shops;

        }
    }
}
