using MetaWeather.Models;
using System.Globalization;
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

        public async Task<WeatherLocation[]> GetInfoByName(string name, CancellationToken cancel = default)
        {
            return await Client
                .GetFromJsonAsync<WeatherLocation[]>($"/api/location/search/?query={name}", /*serializerOptions*/ cancel)
                .ConfigureAwait(false);
        }

        public async Task<WeatherLocation[]> GetInfoByLattLong((double latitude, double longitude) coordinates, CancellationToken cancel = default)
        {
            return await Client
                .GetFromJsonAsync<WeatherLocation[]>($"/api/location/search/?lattlong={coordinates.latitude.ToString(CultureInfo.InvariantCulture)},{coordinates.longitude.ToString(CultureInfo.InvariantCulture)}", /*serializerOptions*/ cancel)
                .ConfigureAwait(false);
        }

        public async Task<LocationInfo> GetInfoById(int id, CancellationToken cancel = default)
        {
            return await Client
                .GetFromJsonAsync<LocationInfo>($"/api/location/{id}", cancel)
                .ConfigureAwait(false);
        }

        public Task<LocationInfo> GetInfoById(WeatherLocation location, CancellationToken cancel = default) => GetInfoById(location.Id, cancel);
    }
}
