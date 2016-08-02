using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Dto
{
    public class ApiData
    {
        public string SourceApi { get; set; }
        public List<DailyData> DailyData { get; set; }
    }
}
