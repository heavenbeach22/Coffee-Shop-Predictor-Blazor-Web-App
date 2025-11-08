using System.Text.Json.Serialization;

namespace demopro.Services
{
    public class GeoJsonFeature
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("properties")]
        public GeoJsonProperties Properties { get; set; }

        [JsonPropertyName("geometry")]
        public GeoJsonGeometry Geometry { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
