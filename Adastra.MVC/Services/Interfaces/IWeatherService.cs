using Adastra.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adastra.MVC.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<List<OpenWeatherForecast>> GetForecastForFiveDays(string city);
    }
}
