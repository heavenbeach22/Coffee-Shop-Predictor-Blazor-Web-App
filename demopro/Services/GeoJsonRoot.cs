using System.Text.Json.Serialization;

namespace demopro.Services
{
    public class GeoJsonRoot
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("features")]
        public List<GeoJsonFeature> Features { get; set; }
    }
}
