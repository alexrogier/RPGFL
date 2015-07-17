using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Api;

namespace Christoc.Modules.StandingsModule.Models
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("StandingsModule", "default", "{controller}/{action}", new[] { "Christoc.Modules.StandingsModule.Models" });
        }
    }
}