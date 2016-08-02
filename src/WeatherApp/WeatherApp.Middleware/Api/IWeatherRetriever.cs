using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Middleware.Api
{
    public interface IWeatherRetriever
    {
        WeatherApp.Dto.ApiData GetWeather(WeatherRetrieverRequest request);
        Task<WeatherApp.Dto.ApiData> GetWeatherAsync(WeatherRetrieverRequest request);
    }
}
