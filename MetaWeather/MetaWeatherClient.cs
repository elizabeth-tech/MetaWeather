﻿using MetaWeather.Models;
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

        public async Task<WeatherLocation[]> GetInfoByLattLong((double latitude, double longitude) location, CancellationToken cancel = default)
        {
            return await Client
                .GetFromJsonAsync<WeatherLocation[]>($"/api/location/search/?lattlong={location.latitude.ToString(CultureInfo.InvariantCulture)},{location.longitude.ToString(CultureInfo.InvariantCulture)}", /*serializerOptions*/ cancel)
                .ConfigureAwait(false);
        }

        public async Task<LocationInfo> GetInfoById(int woeid, CancellationToken cancel = default)
        {
            return await Client
                .GetFromJsonAsync<LocationInfo>($"/api/location/{woeid}", cancel)
                .ConfigureAwait(false);
        }
    }
}
