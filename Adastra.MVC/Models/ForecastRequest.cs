using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adastra.MVC.Models
{
    /// <summary>
    /// class ForecastRequest
    /// Model containing the request parameters.
    /// </summary>
    public class ForecastRequest
    {
        /// <summary>
        /// Name of the city in which the weather is reported
        /// </summary>
        public string City { get; set; }
    }
}
