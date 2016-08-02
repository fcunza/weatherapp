using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Middleware.OpenWeaterMap
{
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public Int64 population { get; set; }
    }

    public class MainData
    {
        public decimal temp { get; set; }
        public decimal temp_min { get; set; }
        public decimal temp_max { get; set; }
        public decimal pressure { get; set; }
        public decimal sea_level { get; set; }
        public decimal grnd_level { get; set; }
        public decimal humidity { get; set; }
        public decimal temp_kf { get; set; }
    }

    public class WeatherData
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class DataPoint
    {
        public double dt { get; set; }
        public MainData main { get; set; }
        public WeatherData[] weather { get; set; }
        public string dt_txt { get; set; }
    }

    public class OpenWeatherMap
    {
        public City city { get; set; }
        public string cod { get; set; }
        public decimal message { get; set; }
        public int cnt { get; set; }
        public DataPoint[] List { get; set; }
    }
}
