using Adastra.WebAPI.Config;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adastra.WebAPI.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private OpenWeather openWeatherConfig;

        public OpenWeatherService(IOptions<OpenWeather> options)
        {
            this.openWeatherConfig = options.Value;
        }

        public string GetApi()
        {
            return this.openWeatherConfig.ApiKey;
        }
    }
}
