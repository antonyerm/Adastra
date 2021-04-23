using Adastra.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adastra.MVC.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet]
        public IActionResult RequestForecast()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RequestForecast(string city)
        {
            return RedirectToAction(nameof(ShowForecast), new { city = city});
        }

        [HttpGet]
        public async Task<IActionResult> ShowForecast(string city)
        {
            var forecast = await weatherService.GetForecastForFiveDays(city);
            //return Content(forecast[0]?.Time.ToString());
            ViewData["city"] = city;
            return View(forecast);
        }
    }
}
