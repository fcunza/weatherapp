using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherApp.Dto;
using WeatherApp.Middleware;
using WeatherApp.Service.Common;

namespace WeatherApp.Service.Controllers
{
    public class WeatherController : ApiController
    {
        private readonly IWeatherResponseBuilder _weatherResponseBuilder;

        public WeatherController()
        {
            _weatherResponseBuilder = new WeatherResponseBuilder(new WeatherRetrieverFactory());
        }

        public async Task<Weather> Post(WeatherRequest request)
        {
            return await _weatherResponseBuilder.BuildWeatherResponseAsync(request);
        }
    }
}