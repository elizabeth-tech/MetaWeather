using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace MetaWeather
{
    public class MetaWeatherClient
    {
        private readonly HttpClient Client;

        private static readonly JsonSerializerOptions serializerOptions = new()
        {
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        public MetaWeatherClient(HttpClient client) => Client = client;

        public async Task<WeatherLocation[]> GetLocationByName(string name, CancellationToken cancel = default)
        {
            return await Client
                .GetFromJsonAsync<WeatherLocation[]>($"/api/location/search/?query={name}", serializerOptions, cancel)
                .ConfigureAwait(false);
        }
    }

    public class WeatherLocation
    {
        [JsonPropertyName("woeid")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("location_type")]
        public LocationType Type { get; set; }

        [JsonPropertyName("latt_long")]
        public string Location { get; set; }

        [JsonPropertyName("distance")]
        public int Distance { get; set; }
    }

    public enum LocationType
    {
        City,
        Region,
        State,
        Province,
        Country,
        Continent
    }
}
