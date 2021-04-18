using Adastra.WebAPI.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adastra.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureUserSecrets(this IServiceCollection services, IConfiguration configuration)
        {
            var secretsConfiguration = configuration.GetSection("OpenWeather");
            services.Configure<OpenWeather>(secretsConfiguration);
        }

    }
}
