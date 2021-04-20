using System.Text.Json.Serialization;

namespace Adastra.WebAPI.Models
{
    public class InputWeatherCondition
    {
        [JsonPropertyName("main")]
        public string WeatherConditionName { get; set; }
        [JsonPropertyName("description")]
        public string WeatherConditionDescription { get; set; }
    }
}