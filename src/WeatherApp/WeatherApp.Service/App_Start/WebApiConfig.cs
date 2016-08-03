using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WeatherApp.Service.App_Start;

namespace WeatherApp.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            IoCBuilder.Configure();

            config.DependencyResolver = new UnityResolver(IoCBuilder.Container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
