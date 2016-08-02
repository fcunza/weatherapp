using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Middleware.Forecast
{
    public class DataPoint
    {
        public double time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public decimal sunriseTime { get; set; }
        public decimal sunsetTime { get; set; }
        public decimal precipIntensity { get; set; }
        public decimal precipIntensityError { get; set; }
        public decimal precipIntensityMax { get; set; }
        public decimal precipIntensityMaxTime { get; set; }
        public decimal precipIntensityMaxError { get; set; }
        public decimal precipProbability { get; set; }
        public decimal precipProbabilityError { get; set; }
        public string precipType { get; set; }
        public decimal precipAccumulation { get; set; }
        public decimal precipAccumulationError { get; set; }
        public decimal temperature { get; set; }
        public decimal temperatureError { get; set; }
        public decimal temperatureMin { get; set; }
        public decimal temperatureMinTime { get; set; }
        public decimal temperatureMinError { get; set; }
        public decimal temperatureMax { get; set; }
        public decimal temperatureMaxTime { get; set; }
        public decimal temperatureMaxError { get; set; }
        public decimal dewPoint { get; set; }
        public decimal dewPointError { get; set; }
        public decimal windSpeed { get; set; }
        public decimal windSpeedError { get; set; }
        public decimal windBearing { get; set; }
        public decimal windBearingError { get; set; }
        public decimal cloudCover { get; set; }
        public decimal cloudCoverError { get; set; }
        public decimal humidity { get; set; }
        public decimal humidityError { get; set; }
        public decimal pressure { get; set; }
        public decimal pressureError { get; set; }
        public decimal visibility { get; set; }
        public decimal visibilityError { get; set; }
        public decimal ozone { get; set; }
        public decimal ozoneError { get; set; }
    }

    public class DataBlock
    {
        public DataPoint[] data { get; set; }
        public string icon { get; set; }
        public string summary { get; set; }
    }

    public class Alert
    {
        public string title { get; set; }
        public decimal expires { get; set; }
        public string description { get; set; }
        public string uri { get; set; }
    }

    public class Flags
    {
        [JsonProperty(PropertyName = "darksky-unavailable")]
        public string darkskyUnavailable { get; set; }
        [JsonProperty(PropertyName = "darksky-stations")]
        public string[] darkskyStations { get; set; }
        [JsonProperty(PropertyName = "datapoint-stations")]
        public string[] datapointStations { get; set; }
        [JsonProperty(PropertyName = "isd-stations")]
        public string[] isdStations { get; set; }
        [JsonProperty(PropertyName = "lamp-stations")]
        public string[] lampStations { get; set; }
        [JsonProperty(PropertyName = "metar-stations")]
        public string[] metarStations { get; set; }
        public string[] sources { get; set; }
        [JsonProperty(PropertyName = "metno-license")]
        public string metnoLicense { get; set; }
        public string units { get; set; }
    }

    public class Forecast
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public decimal offset { get; set; }
        public string timezone { get; set; }
        public DataPoint currently { get; set; }
        public DataBlock minutely { get; set; }
        public DataBlock hourly { get; set; }
        public DataBlock daily { get; set; }
        public Alert[] alerts { get; set; }
        public Flags flags { get; set; }
    }
}