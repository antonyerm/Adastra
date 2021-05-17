using Adastra.MVC.Services;
using Adastra.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adastra.MVC.Controllers
{
    /// <summary>
    /// class WeatherController
    /// Controller for reading and sending parameters of weather forecast request.
    /// </summary>
    public class WeatherController : Controller
    {
        private IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        /// <summary>
        /// Controller action asking for the parameters of weather forecast request.
        /// </summary>
        /// <returns>HTML page with a form.</returns>
        [HttpGet]
        public IActionResult RequestForecast()
        {
            return View();
        }

        /// <summary>
        /// Controller action receiving the parameters for the weather forecast request and 
        /// sending them to the action which actually shows the forecast <see cref="ShowForecast"/>
        /// </summary>
        /// <param name="city">User submitted city name.</param>
        /// <returns>Redirection to action showing the forecast.</returns>
        [HttpPost]
        public IActionResult RequestForecast(string city)
        {
            return RedirectToAction(nameof(ShowForecast), new { city = city});
        }

        /// <summary>
        /// Controller action showing the weather forecast.
        /// </summary>
        /// <param name="city">user submitted city name.</param>
        /// <returns>HTML page with the forecast.</returns>
        [HttpGet]
        public async Task<IActionResult> ShowForecast(string city)
        {
            var forecast = await weatherService.GetForecastForFiveDays(city);
            ViewData["city"] = city;
            return View(forecast);
        }
    }
}
