using System.Text.Json.Serialization;

namespace demopro.Services
{
    public class GeoJsonProperties
    {
        [JsonPropertyName("@id")]
        public string OSMId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("amenity")]
        public string Amenity { get; set; }

        [JsonPropertyName("building")]
        public string Building { get; set; }
    }
}
