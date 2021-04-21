using Adastra.WebAPI.Config;
using Adastra.WebAPI.Models;
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

        public async Task<List<WeatherForecast>> GetWeatherForecast(string city)
        {
            OpenWeatherResponse openWeatherResponse = null;
            var weatherForecasts = new List<WeatherForecast>();

            var client = this.httpClientFactory.CreateClient();
            string uri = $"http://api.openweathermap.org/data/2.5/forecast?q={city}&appid={this.openWeatherConfig.ApiKey}";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                openWeatherResponse = JsonSerializer.Deserialize<OpenWeatherResponse>(jsonString);
            }

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
                foreach(var condition in forecast.WeatherConditions)
                {
                    currentForecast.WeatherConditions.Add(new WeatherCondition
                    {
                        WeatherConditionName = condition.WeatherConditionName,
                        WeatherConditionDescription = condition.WeatherConditionDescription
                    });
                }

                weatherForecasts.Add(currentForecast);
            }

            return weatherForecasts;
        }
    }
}
