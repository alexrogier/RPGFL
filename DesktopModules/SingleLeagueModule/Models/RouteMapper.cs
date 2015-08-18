using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Api;


namespace Christoc.Modules.SingleLeagueModule.Models
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("SingleLeagueModule", "default", "{controller}/{action}", new[] { "Christoc.Modules.SingleLeagueModule.Models" });
        }
    }
}