using Adastra.WebAPI.Config;
using Adastra.WebAPI.Models;
using Adastra.WebAPI.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Adastra.WebAPI.Services
{
    /// <summary>
    /// class OpenWeatherService
    /// Provides a method for reading external API and returning the data is a model class object.
    /// </summary>
    public class OpenWeatherService : IOpenWeatherService
    {
        private OpenWeather openWeatherConfig;
        private IHttpClientFactory httpClientFactory;

        public OpenWeatherService(IOptions<OpenWeather> options, IHttpClientFactory httpClientFactory)
        {
            this.openWeatherConfig = options.Value;
            this.httpClientFactory = httpClientFactory;
        }

        public string GetApi()
        {
            return this.openWeatherConfig.ApiKey;
        }

        /// <summary>
        /// Method which requests data from external API into <see cref="OpenWeatherResponse"/> object and returns data in a <see cref="WeatherForecast"/> object.
        /// </summary>
        /// <param name="city">User submitted city name in which the forecast is requested.</param>
        /// <returns>Model class object.</returns>
        public async Task<List<WeatherForecast>> GetWeatherForecast(string city)
        {
            OpenWeatherResponse openWeatherResponse;
            var weatherForecasts = new List<WeatherForecast>();

            var client = this.httpClientFactory.CreateClient();
            string uri = $"http://api.openweathermap.org/data/2.5/forecast?q={city}&appid={this.openWeatherConfig.ApiKey}";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                openWeatherResponse = JsonSerializer.Deserialize<OpenWeatherResponse>(jsonString);

                foreach (var forecast in openWeatherResponse.Forecasts)
                {
                    var currentForecast = new WeatherForecast
                    {
                        Time = DateTimeOffset.FromUnixTimeSeconds(forecast.DateTime).DateTime,
                        Temperature = forecast.Temperatures.Temperature,
                        Clouds = forecast.Clouds.CloudPercent,
                        Wind = forecast.Wind.WindSpeed,
                        WeatherConditions = new List<WeatherCondition>()
                    };
                    foreach (var condition in forecast.WeatherConditions)
                    {
                        currentForecast.WeatherConditions.Add(new WeatherCondition
                        {
                            WeatherConditionName = condition.WeatherConditionName,
                            WeatherConditionDescription = condition.WeatherConditionDescription
                        });
                    }

                    weatherForecasts.Add(currentForecast);
                }
            }

            return weatherForecasts;
        }
    }
}
