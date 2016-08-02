using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WeatherApp.Dto;
using WeatherApp.Middleware;
using WeatherApp.Middleware.Api;

namespace WeatherApp.Service.Common
{
    public interface IWeatherResponseBuilder
    {
        Task<Weather> BuildWeatherResponseAsync(WeatherRequest request);
    }

    public class WeatherResponseBuilder : IWeatherResponseBuilder
    {
        private readonly IWeatherRetrieverFactory _weatherRetrieverFactory;

        public WeatherResponseBuilder(IWeatherRetrieverFactory weatherRetrieverFactory)
        {
            _weatherRetrieverFactory = weatherRetrieverFactory;
        }

        public async Task<Weather> BuildWeatherResponseAsync(WeatherRequest request)
        {
            return new Weather
            {
                City = new City
                {
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Name = request.CityName
                },
                ApiDataCollection = await GetApiDataAsync(request)
            };
        }

        private async Task<List<ApiData>> GetApiDataAsync(WeatherRequest request)
        {
            var apiDataCollection = new List<ApiData>();

            foreach (var source in request.Sources)
            {
                ApiData data = null;

                var retrieverRequest = new WeatherRetrieverRequest
                {
                    Longitude = request.Longitude,
                    Latitude = request.Latitude
                };

                IWeatherRetriever retriever = null;

                switch (source.ToLowerInvariant())
                {
                    case "forecast":
                        retriever = _weatherRetrieverFactory.GetWeatherRetriever(WeatherServiceSource.Forecast);                                                
                        break;
                    case "openweathermap":
                        retriever = _weatherRetrieverFactory.GetWeatherRetriever(WeatherServiceSource.OpenWeaterMap);
                        break;
                }

                if (retriever != null) data = await retriever.GetWeatherAsync(retrieverRequest);

                if (data != null) apiDataCollection.Add(data);
            }

            return apiDataCollection;
        }
    }
}