using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Api;

namespace Christoc.Modules.CharacterViewerModule.Models
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("CharacterViewModule", "default", "{controller}/{action}", new[] { "Christoc.Modules.CharacterViewerModule.Models" });
        }
    }
}