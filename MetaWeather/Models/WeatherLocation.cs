using MetaWeather.Services;
using System.Text.Json.Serialization;

namespace MetaWeather.Models
{
    public class WeatherLocation
    {
        [JsonPropertyName("woeid")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("location_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LocationType Type { get; set; }

        [JsonPropertyName("latt_long")]
        [JsonConverter(typeof(JsonCoordinateconverter))]
        public (double Latitude, double Longitude) Location { get; set; }

        [JsonPropertyName("distance")]
        public int Distance { get; set; }

        public override string ToString() => $"[{Id}]{Title}({Type}):{Location} ({Distance})";
    }
}
