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

namespace Christoc.Modules.StandingsModule.Models
{
    public class ModuleStandingsController : DnnApiController
    {
        StandingsController controller = new StandingsController();

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetStandings(string FILTER_accolade = "OVERALL", string FILTER_context = "SHOWEVERYONE", int FILTER_leaguefk = -1, int FILTER_userfk = -1)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetStandings(FILTER_accolade, FILTER_context, FILTER_leaguefk, FILTER_userfk).ToJson());
            }
            catch (Exception exc) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetUserInfo(int User_PK)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetUserInfo(User_PK).ToJson());
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}