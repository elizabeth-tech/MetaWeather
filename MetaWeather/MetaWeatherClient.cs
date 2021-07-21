using MetaWeather.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MetaWeather
{
    public class MetaWeatherClient
    {
        private readonly HttpClient Client;

        //private static readonly JsonSerializerOptions serializerOptions = new()
        //{
        //    Converters =
        //    {
        //        new JsonStringEnumConverter(),
        //        new JsonCoordinateconverter()
        //    }
        //};

        public MetaWeatherClient(HttpClient client) => Client = client;

        public async Task<WeatherLocation[]> GetLocationByName(string name, CancellationToken cancel = default)
        {
            return await Client
                .GetFromJsonAsync<WeatherLocation[]>($"/api/location/search/?query={name}", /*serializerOptions*/ cancel)
                .ConfigureAwait(false);
        }
    }
}
