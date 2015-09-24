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
namespace Christoc.Modules.SingleLeagueModule.Models
{
    public class ModuleSingleLeagueController : DnnApiController
    {
        SingleLeagueController controller = new SingleLeagueController();

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage DeleteUserFromLeague(int FILTER_leaguefk, int FILTER_userfk, bool bLeagueOwner)
        {
            try
            {
                controller.DeleteUserFromLeague(FILTER_leaguefk, FILTER_userfk, bLeagueOwner);
                return Request.CreateResponse(HttpStatusCode.OK, "SUCCESS");
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetSingleLeagueData(int FILTER_leaguefk)
        {
            try
            {
                League leagueData = controller.GetSingleLeagueData(FILTER_leaguefk)[0];
                leagueData.League_Users = controller.GetLeagueUsers(FILTER_leaguefk);
                return Request.CreateResponse(HttpStatusCode.OK, leagueData.ToJson());
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetLeagueCountByUser(int FILTER_userfk)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetLeagueCountByUser(FILTER_userfk));
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetCharacterDraftByLeague(int FILTER_userfk, int FILTER_leaguefk)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetCharacterDraftByLeague(FILTER_userfk, FILTER_leaguefk));
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage InsertUserInLeague(int FILTER_leaguefk, int FILTER_userfk)
        {
            try
            {
                controller.InsertUserInLeague(FILTER_leaguefk, FILTER_userfk);
                return Request.CreateResponse(HttpStatusCode.OK, "SUCCESS");
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage InviteEmails(string Emails, int User_PK, int League_PK)
        {
            try
            {
                //controller.InviteEmailsByUser(Emails, User_PK, League_PK);
                return Request.CreateResponse(HttpStatusCode.OK, controller.InviteEmailsByUser(Emails, User_PK, League_PK));
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}