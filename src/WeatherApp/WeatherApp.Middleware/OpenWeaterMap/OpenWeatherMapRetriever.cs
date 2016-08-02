using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.DataLoader;
using WeatherApp.Middleware.Api;

namespace WeatherApp.Middleware.OpenWeaterMap
{
    public class OpenWeatherMapRetriever : IWeatherRetriever
    {
        private readonly IRestServiceLoader<OpenWeatherMap> _loader;

        public OpenWeatherMapRetriever(IRestServiceLoader<OpenWeatherMap> loader)
        {
            _loader = loader;
        }

        public Dto.ApiData GetWeather(WeatherRetrieverRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Dto.ApiData> GetWeatherAsync(WeatherRetrieverRequest request)
        {
            var requestStr = string.Format(CultureInfo.InvariantCulture, "forecast?lat={0}&lon={1}&units=imperial&appid={2}", request.Latitude, request.Longitude, OpenWeatherMapData.Api);

            var rawData = await _loader.GetAsync(OpenWeatherMapData.Uri, requestStr);

            return OpenWeatherMapMapper.ToApiData(rawData);
        }
    }
}
