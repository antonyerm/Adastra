using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Adastra.WebAPI.Models
{
    // input model
    public class OpenWeatherResponse
    {
        [JsonPropertyName("list")]
        public List<Forecast> Forecasts { get; set; }
    }

    public class Forecast
    {
        // "list" node
        [JsonPropertyName("dt")]
        public int DateTime { get; set; }
        [JsonPropertyName("main")]
        public Temperatures Temperatures { get; set; }
        [JsonPropertyName("weather")]
        public List<WeatherCondition> WeatherConditions { get; set; }
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
    }

    public class Temperatures
    {
        // "list.main" node
        [JsonPropertyName("temp")]
        public decimal Temperature { get; set; }
    }

    public class WeatherCondition
    {
        // "list.weather" node
        [JsonPropertyName("main")]
        public string WeatherConditionName { get; set; }
        [JsonPropertyName("description")]
        public string WeatherConditionDescription { get; set; }
    }

    public class Clouds
    {
        // "list.cloud" node
        [JsonPropertyName("all")]
        public int CloudPercent { get; set; }
    }

    public class Wind
    {
        // "list.wind" node
        [JsonPropertyName("speed")]
        public decimal WindSpeed { get; set; }
    }

}

