using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Common;
using WeatherApp.Middleware;
using WeatherApp.Middleware.Api;

namespace WeatherApp.Service.App_Start
{
    public class IoCBuilder
    {
        public static IUnityContainer Container = new UnityContainer();

        public static void Configure()
        {
            Container.RegisterType<IWeatherResponseBuilder, WeatherResponseBuilder>();
            Container.RegisterType<IWeatherRetrieverFactory, WeatherRetrieverFactory>();
        }
    }
}