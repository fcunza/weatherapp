using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Dto
{
    public class Weather
    {
        public City City { get; set; }
        public List<ApiData> ApiDataCollection { get; set; }
    }
}
