using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MetaWeather
{
    public class MetaWeatherClient
    {
        private readonly HttpClient Client;

        public MetaWeatherClient(HttpClient client) => Client = client;

        public async Task<WeatherLocation[]> GetLocationByName(string name)
        {
            return await Client.GetFromJsonAsync<WeatherLocation[]>($"/api/location/search/?query={name}");
        }
    }

    public class WeatherLocation
    {
        [JsonPropertyName("woeid")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("location_type")]
        public string Type { get; set; }

        [JsonPropertyName("latt_long")]
        public string Location { get; set; }

        [JsonPropertyName("distance")]
        public int Distance { get; set; }
    }
}
