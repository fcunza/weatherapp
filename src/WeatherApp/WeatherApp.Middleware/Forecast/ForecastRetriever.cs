using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.DataLoader;
using WeatherApp.Middleware.Api;

namespace WeatherApp.Middleware.Forecast
{
    public class ForecastRetriever : IWeatherRetriever
    {
        private readonly IRestServiceLoader<Forecast> _loader;

        public ForecastRetriever(IRestServiceLoader<Forecast> loader)
        {
            _loader = loader;
        }

        public Dto.ApiData GetWeather(WeatherRetrieverRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Dto.ApiData> GetWeatherAsync(WeatherRetrieverRequest request)
        {
            var requestStr = string.Format(CultureInfo.InvariantCulture, "{0}/{1:n},{2:n}", ForecastData.ApiKey, request.Latitude, request.Longitude);

            var rawData = await _loader.GetAsync(ForecastData.Uri, requestStr);

            return ForecastMapper.ToApiData(rawData);
        }
    }
}