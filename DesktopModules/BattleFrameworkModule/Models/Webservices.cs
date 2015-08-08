using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Users;
using DotNetNuke.Web.Api;


namespace Christoc.Modules.BattleFrameworkModule.Models
{
    public class ModuleBattleFrameworkController : DnnApiController
    {
        BattleFrameworkController controller = new BattleFrameworkController();

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World!");
        }
    }
}