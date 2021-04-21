using Adastra.WebAPI.Models;
using Adastra.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adastra.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ForecastController : ControllerBase
    {
        private IOpenWeatherService openWeatherService;

        public ForecastController(IOpenWeatherService openWeatherService)
        {
            this.openWeatherService = openWeatherService;
        }

        [HttpGet]
        public string ShowApiString()
        {
            return this.openWeatherService.GetApi();
        }

        [HttpGet]
        public async Task<List<WeatherForecast>> ShowFiveDays()
        {
            var forecastForFiveDays = await this.openWeatherService.GetWeatherForecast("Almaty");
            return forecastForFiveDays;
        }
    }
}
