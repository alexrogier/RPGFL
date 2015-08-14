using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Api;

namespace Christoc.Modules.CreateLeagueModule.Models
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("CreateLeagueModule", "default", "{controller}/{action}", new[] { "Christoc.Modules.CreateLeagueModule.Models" });
        }
    }
}