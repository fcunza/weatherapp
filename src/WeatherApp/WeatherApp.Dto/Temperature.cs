using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Dto
{
    public class Temperature
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public decimal Value { get; set; }
    }
}
