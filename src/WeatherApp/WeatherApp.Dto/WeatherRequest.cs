using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Dto
{
    public class WeatherRequest
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string CityName { get; set; }

        public List<string> Sources { get; set; }
    }
}
