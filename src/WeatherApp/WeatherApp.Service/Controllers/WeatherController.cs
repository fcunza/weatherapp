using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherApp.Common;
using WeatherApp.Dto;
using WeatherApp.Middleware;

namespace WeatherApp.Service.Controllers
{
    public class WeatherController : ApiController
    {
        private readonly IWeatherResponseBuilder _weatherResponseBuilder;

        public WeatherController(IWeatherResponseBuilder weatherResponseBuilder)
        {
            _weatherResponseBuilder = weatherResponseBuilder;
        }

        public async Task<Weather> Post(WeatherRequest request)
        {
            return await _weatherResponseBuilder.BuildWeatherResponseAsync(request);
        }
    }
}