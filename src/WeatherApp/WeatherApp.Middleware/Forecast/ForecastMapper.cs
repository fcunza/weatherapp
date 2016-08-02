using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Dto;
using WeatherApp.Middleware.Common;

namespace WeatherApp.Middleware.Forecast
{
    internal class ForecastMapper
    {
        internal static ApiData ToApiData(Forecast source)
        {
            return new ApiData
            {
                SourceApi = "Forecast",
                DailyData = MapDailyData(source)
            };
        }

        private static List<DailyData> MapDailyData(Forecast source)
        {
            return source.daily.data.Select(d => new DailyData
            {
                WeatherCondition = MapWeatherCondition(d.icon),
                Date = Utils.UnixTimeStampToDateTime(d.time),
                MinTemperature = new Temperature
                {
                    UnitOfMeasure = UnitOfMeasure.Fahrenheit,
                    Value = d.temperatureMin
                },
                MaxTemperature = new Temperature
                {
                    UnitOfMeasure = UnitOfMeasure.Fahrenheit,
                    Value = d.temperatureMax
                }
            }).ToList();
        }

        private static WeatherCondition MapWeatherCondition(string source)
        {
            switch (source.ToLowerInvariant())
            {
                case "clear-day":
                case "clear-night":
                    return WeatherCondition.Clear;
                case "rain":
                case " sleet":
                case "wind":
                    return WeatherCondition.Rain;
                case "snow":
                    return WeatherCondition.Snow;
                case "fog":
                    return WeatherCondition.Fog;
                case "cloudy":
                    return WeatherCondition.Clowdy;
                case "partly-cloudy-day":
                case "partly-cloudy-night":
                    return WeatherCondition.PartlyClowdy;
                default:
                    return WeatherCondition.Unspecified;
            }
        }
    }
}