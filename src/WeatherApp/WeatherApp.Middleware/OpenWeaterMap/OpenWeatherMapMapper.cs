using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Dto;
using WeatherApp.Middleware.Common;

namespace WeatherApp.Middleware.OpenWeaterMap
{
    internal class OpenWeatherMapMapper
    {
        internal static ApiData ToApiData(OpenWeatherMap source)
        {
            return new ApiData
            {
                SourceApi = "OpenWeatherMap",
                DailyData = MapDailyData(source)
            };
        }

        private static List<DailyData> MapDailyData(OpenWeatherMap source)
        {
            var allData = source.List.Select(d => new DailyData
            {
                WeatherCondition = MapWeatherCondition(d.weather[0].main, d.weather[0].id),
                Date = Utils.UnixTimeStampToDateTime(d.dt).Date,
                MinTemperature = new Temperature
                {
                    UnitOfMeasure = UnitOfMeasure.Fahrenheit,
                    Value = d.main.temp_min
                },
                MaxTemperature = new Temperature
                {
                    UnitOfMeasure = UnitOfMeasure.Fahrenheit,
                    Value = d.main.temp_max
                }
            }).ToList();

            return SummarizeDailyData(allData);
        }

        private static WeatherCondition MapWeatherCondition(string source, int detail)
        {
            switch (source.ToLowerInvariant())
            {
                case "clear":
                    return WeatherCondition.Clear;
                case "rain":
                case "drizzle":
                case "thunderstorm":
                    return WeatherCondition.Rain;
                case "snow":
                    return WeatherCondition.Snow;
                case "fog":
                    return WeatherCondition.Fog;
                case "clouds":
                    if (detail == 804)
                        return WeatherCondition.Clowdy;
                    else
                        return WeatherCondition.PartlyClowdy;
                default:
                    return WeatherCondition.Unspecified;
            }
        }

        private static List<DailyData> SummarizeDailyData(List<DailyData> source)
        {
            return source.GroupBy(s => s.Date, (k, g) => new DailyData
            {
                WeatherCondition = g.First().WeatherCondition,
                Date = k,
                MinTemperature = new Temperature
                {
                    UnitOfMeasure = UnitOfMeasure.Fahrenheit,
                    Value = g.Sum(d => d.MinTemperature.Value) / g.Count()
                },
                MaxTemperature = new Temperature
                {
                    UnitOfMeasure = UnitOfMeasure.Fahrenheit,
                    Value = g.Sum(d => d.MaxTemperature.Value) / g.Count()
                }
            }).ToList();
        }
    }
}