using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Middleware.Api
{
    public interface IWeatherRetrieverFactory
    {
        IWeatherRetriever GetWeatherRetriever(WeatherServiceSource source);
    }
}
