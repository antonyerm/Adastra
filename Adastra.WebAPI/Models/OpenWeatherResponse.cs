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
        public List<InputForecast> Forecasts { get; set; }
    }
}
