using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Api;

namespace Christoc.Modules.BattleFrameworkModule.Models
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("BattleFrameworkModule", "default", "{controller}/{action}", new[] { "Christoc.Modules.BattleFrameworkModule.Models" });
        }
    }
}