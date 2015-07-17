using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Api;

namespace Christoc.Modules.MyFirstModule.models
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("MyFirstModule", "default", "{controller}/{action}", new[] { "Christoc.Modules.MyFirstModule.Models" });
        }
    }
}