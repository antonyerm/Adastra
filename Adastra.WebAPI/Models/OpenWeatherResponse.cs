using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Adastra.WebAPI.Models
{
    /// <summary>
    /// Model for parameters returned from https://openweathermap.org/api
    /// </summary>
    public class OpenWeatherResponse
    {
        /// <summary>
        /// List of forecasts for each 3-hour period (data section: list)
        /// </summary>
        [JsonPropertyName("list")]
        public List<Forecast> Forecasts { get; set; }
    }

    /// <summary>
    /// Model for each 3-hour period forecast
    /// </summary>
    public class Forecast
    {
        /// <summary>
        /// Date and time in UNIX format (number of seconds since 01.01.1970 00:00)
        /// </summary>
        [JsonPropertyName("dt")]
        public int DateTime { get; set; }
        /// <summary>
        /// Group of data parameters for temperatures, pressure and humidity. Only temperatures are used.
        /// (data section: list.main)
        /// </summary>
        [JsonPropertyName("main")]
        public Temperatures Temperatures { get; set; }
        /// <summary>
        /// List of weather conditions (data section: list.weather)
        /// </summary>
        [JsonPropertyName("weather")]
        public List<WeatherConditionResponse> WeatherConditions { get; set; }
        /// <summary>
        /// Clouds group of data parameters (data section: list.clouds)
        /// </summary>
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }
        /// <summary>
        /// Wind group of data parameters (data section: list.wind)
        /// </summary>
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
    }

    /// <summary>
    /// Model for temperatures section of responce (list.main.temp)
    /// </summary>
    public class Temperatures
    {
        /// <summary>
        /// Temperature in K
        /// </summary>
        [JsonPropertyName("temp")]
        public decimal Temperature { get; set; }
    }

    /// <summary>
    /// "Weather condition" model (data section: list.weather)
    /// </summary>
    public class WeatherConditionResponse
    {
        /// <summary>
        /// Name of weather condition (rain, snow, extreme etc)
        /// (data section: list.weather.main)
        /// </summary>
        [JsonPropertyName("main")]
        public string WeatherConditionName { get; set; }
        /// <summary>
        /// Description of weather condition (data section: list.weather.description)
        /// </summary>
        [JsonPropertyName("description")]
        public string WeatherConditionDescription { get; set; }
    }

    /// <summary>
    /// Clouds section of weather data
    /// </summary>
    public class Clouds
    {
        /// <summary>
        /// Cloudness percentage (data section: list.clouds.all)
        /// </summary>
        [JsonPropertyName("all")]
        public int CloudPercent { get; set; }
    }

    /// <summary>
    /// Wind section of weather data
    /// </summary>
    public class Wind
    {
        /// <summary>
        /// Wind speed (data section: list.wind.speed)
        /// </summary>
        [JsonPropertyName("speed")]
        public decimal WindSpeed { get; set; }
    }

}

