using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adastra.WebAPI.Config
{
    /// <summary>
    /// class OpenWeather
    /// A class for storing configuration models as Options.
    /// </summary>
    public class OpenWeather
    {
        /// <summary>
        /// Model for storing the registered API key from 3rd party API supplier.
        /// </summary>
        public string ApiKey { get; set; }
    }
}
