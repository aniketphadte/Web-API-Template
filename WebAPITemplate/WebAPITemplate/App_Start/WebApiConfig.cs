using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebAPITemplate.Util.Handler;
using WebAPITemplate.Util.Logger;

namespace WebAPITemplate
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Services.Add(typeof(IExceptionLogger), new ApiExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new ApiExceptionHandler());
            //config.Filters.Add(new GeneralExceptionFilterAttribute());

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
