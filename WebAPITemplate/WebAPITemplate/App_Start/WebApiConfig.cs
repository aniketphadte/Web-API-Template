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

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            /* Apply CORS globally
            var cors = new EnableCorsAttribute("http://www.DemoWebapp.com", "*", "*");
            config.EnableCors(cors);
             */

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
