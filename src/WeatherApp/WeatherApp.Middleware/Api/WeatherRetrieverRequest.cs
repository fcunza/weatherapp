using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Middleware.Api
{
    public class WeatherRetrieverRequest
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}