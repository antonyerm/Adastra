using Adastra.WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adastra.WebAPI.Services.Interfaces
{
    public interface IOpenWeatherService
    {
        string GetApi();
        Task<List<WeatherForecast>> GetWeatherForecast(string city);
    }

}