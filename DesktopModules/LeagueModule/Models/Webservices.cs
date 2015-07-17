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

namespace Christoc.Modules.LeagueModule.Models
{
    public class ModuleLeagueController : DnnApiController
    {
        LeagueController controller = new LeagueController();

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetAllLeagues()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetAllLeagues().ToJson());
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}