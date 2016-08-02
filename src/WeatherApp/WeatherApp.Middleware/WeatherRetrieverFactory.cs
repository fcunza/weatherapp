using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.DataLoader;
using WeatherApp.Middleware.Api;
using WeatherApp.Middleware.Forecast;
using WeatherApp.Middleware.OpenWeaterMap;

namespace WeatherApp.Middleware
{
    public class WeatherRetrieverFactory : IWeatherRetrieverFactory
    {
        public IWeatherRetriever GetWeatherRetriever(WeatherServiceSource source)
        {
            switch (source)
            {
                case WeatherServiceSource.Forecast: return new ForecastRetriever(new RestServiceLoader<Forecast.Forecast>());
                case WeatherServiceSource.OpenWeaterMap: return new OpenWeatherMapRetriever(new RestServiceLoader<OpenWeatherMap>());
                default: throw new NotImplementedException(string.Format("{0} is not implemented yet", source));
            }
        }
    }
}