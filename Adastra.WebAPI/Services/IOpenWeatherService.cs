using Adastra.WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adastra.WebAPI.Services
{
    public interface IOpenWeatherService
    {
        string GetApi();
        Task<OpenWeatherResponse> GetWeatherForecast(string city);
    }
}