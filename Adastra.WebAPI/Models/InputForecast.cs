using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Adastra.WebAPI.Models
{
    // input model
    public class InputForecast
    {
        [JsonPropertyName("temp")]
        public decimal Temperature { get; set; }
        [JsonPropertyName("weather")]
        public List<InputWeatherCondition> WeatherConditions { get; set; }
        [JsonPropertyName("clouds")]
        public int Clouds { get; set; }
        [JsonPropertyName("wind")]
        public int Wind { get; set; }
    }
}