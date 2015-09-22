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

namespace Christoc.Modules.EmailTokenModule.Models
{
    public class ModuleLeagueController : DnnApiController
    {
        EmailTokenController controller = new EmailTokenController();

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage AcceptLeagueInvitation(string Email, string Token)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.AttemptLeagueInvitationAcceptance(Email, Token).ToJson());
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}