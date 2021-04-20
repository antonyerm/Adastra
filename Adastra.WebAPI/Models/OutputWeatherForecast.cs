using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adastra.WebAPI.Models
{
    // output model
    public class OutputWeatherForecast
    {
        public decimal Temperature { get; set; }
        public List<OutputWeatherCondition> WeatherConditions { get; set; }
        public int Clouds { get; set; }
        public int Wind { get; set; }
    }
}
