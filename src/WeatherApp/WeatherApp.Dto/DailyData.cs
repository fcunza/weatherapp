using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Dto
{    
    public class DailyData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public WeatherCondition WeatherCondition { get; set; }
        public Temperature MaxTemperature { get; set; }
        public Temperature MinTemperature { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, object> AditionalData { get; set; }
    }
}
