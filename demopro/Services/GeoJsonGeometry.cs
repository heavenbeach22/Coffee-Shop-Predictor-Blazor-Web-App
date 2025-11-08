using System.Text.Json.Serialization;

namespace demopro.Services
{
    public class GeoJsonGeometry
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }  // [longitude, latitude]
    }
}
