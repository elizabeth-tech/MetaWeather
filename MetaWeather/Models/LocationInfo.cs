using System;
using System.Text.Json.Serialization;

namespace MetaWeather.Models
{
    public class LocationInfo : WeatherLocationBase
    {
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("timezone_name")]
        public string TimezoneName { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("consolidated_weather")]      
        public WeatherInfo[] Weathers { get; set; }

        [JsonPropertyName("sun_rise")]
        public DateTime SunRiseTime { get; set; }

        [JsonPropertyName("sun_set")]
        public DateTime SunSetTime { get; set; }

        [JsonPropertyName("parent")]
        public WeatherLocationBase Parent { get; set; }

        public class Source
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("slug")]
            public string Slug { get; set; }

            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("crawl_rate")]
            public int CrawlRate { get; set; }
        }

        [JsonPropertyName("sources")]
        public Source[] Sources { get; set; }   
    }
}
