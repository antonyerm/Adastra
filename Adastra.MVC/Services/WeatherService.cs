using Adastra.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Adastra.MVC.Services
{
    public class WeatherService : IWeatherService
    {
        private IHttpClientFactory httpClientFactory;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<List<OpenWeatherForecast>> GetForecastForFiveDays(string city)
        {
            List<OpenWeatherForecast> result = null;
            var client = httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, 
                new UriBuilder("http","localhost", 5000, "Forecast/GetFiveDaysForecast").Uri);

            var adastraAPIResponse = await client.SendAsync(request);
            if (adastraAPIResponse.IsSuccessStatusCode)
            {
                var jsonString = await adastraAPIResponse.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<List<OpenWeatherForecast>>(jsonString,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });
            }

            return result;
        }
    }
}
