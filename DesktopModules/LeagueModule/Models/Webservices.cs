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
        public HttpResponseMessage GetLeagues(int? FILTER_userfk = null, string FILTER_context = "SHOWUSERLEAGUES", string FILTER_search = "")
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetLeagues(FILTER_userfk, FILTER_context, FILTER_search).ToJson());
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage InsertUserIntoMatchmaking(int FILTER_userfk)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.InsertUserIntoMatchmaking(FILTER_userfk).ToJson());
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}