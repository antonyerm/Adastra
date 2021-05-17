using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adastra.MVC.Models
{
    /// <summary>
    /// class OpenWeatherForecast
    /// Model for values from API response.
    /// </summary>
    public class OpenWeatherForecast
    {
        /// <summary>
        /// Time and date for which the forecast is made.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Forecasted temperature in Kelvin.
        /// </summary>
        public decimal Temperature { get; set; }

        /// <summary>
        /// Forecasted general weather conditions.
        /// </summary>
        public List<WeatherCondition> WeatherConditions { get; set; }

        /// <summary>
        /// Forecasted percentage of clouds covering the sky.
        /// </summary>
        public int Clouds { get; set; }

        /// <summary>
        /// Forecasted wind speed in m/s.
        /// </summary>
        public decimal Wind { get; set; }

    }

    /// <summary>
    /// class WeatherCondition
    /// A part of model of values from API repsonse. Contains general weather condition info.
    /// </summary>
    public class WeatherCondition
    {
        /// <summary>
        /// Name of weather condition (e.g. rain, snow, strong wind...).
        /// </summary>
        public string WeatherConditionName { get; set; }

        /// <summary>
        /// State of weather condition mentioned in <see cref="WeatherConditionName"/>.
        /// </summary>
        public string WeatherConditionDescription { get; set; }

    }
}
