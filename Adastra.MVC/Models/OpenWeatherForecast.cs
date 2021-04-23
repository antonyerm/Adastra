using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adastra.MVC.Models
{
    public class OpenWeatherForecast
    {
        public DateTime Time { get; set; }
        public decimal Temperature { get; set; }
        public List<WeatherCondition> WeatherConditions { get; set; }
        public int Clouds { get; set; }
        public decimal Wind { get; set; }
    }

    public class WeatherCondition
    {
        public string WeatherConditionName { get; set; }
        public string WeatherConditionDescription { get; set; }
    }
}
