using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adastra.WebAPI.Models
{
    /// <summary>
    /// Model for parameters sent from Adastra.WebAPI
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Date and time of the forecast
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// Temperature in C
        /// </summary>
        public decimal Temperature { get; set; }
        /// <summary>
        /// List of weather conditions (rain, snow, extreme etc)
        /// </summary>
        public List<WeatherCondition> WeatherConditions { get; set; }
        /// <summary>
        /// Cloudness percentage
        /// </summary>
        public int Clouds { get; set; }
        /// <summary>
        /// Wind speed
        /// </summary>
        public decimal Wind { get; set; }
    }

    /// <summary>
    /// Model of weather conditions group of parameters
    /// </summary>
    public class WeatherCondition
    {
        /// <summary>
        /// Name of weather condition (rain, snow, extreme etc)
        /// </summary>
        public string WeatherConditionName { get; set; }
        /// <summary>
        /// Description of weather condition
        /// </summary>
        public string WeatherConditionDescription { get; set; }
    }

}
