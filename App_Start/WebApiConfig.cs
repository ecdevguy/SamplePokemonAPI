using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CobbleStone_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            PopulatePokemonDB.PopulateDB();  //<- I'm sure this doesn't belong here but I see no downsides FOR NOW.Move after revision.
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}", //There is a better way to set default api route?
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
