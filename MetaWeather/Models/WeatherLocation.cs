using System.Text.Json.Serialization;

namespace MetaWeather.Models
{
    public class WeatherLocation : WeatherLocationBase
    {
        [JsonPropertyName("distance")]
        public int Distance { get; set; }

        public override string ToString() => $"[{Id}]{Title}({Type}):{Coordinates} ({Distance})";
    }
}
