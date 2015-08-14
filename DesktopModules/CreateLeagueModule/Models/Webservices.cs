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

namespace Christoc.Modules.CreateLeagueModule.Models
{
    public class ModuleCreateLeagueController : DnnApiController
    {
        CreateLeagueController controller = new CreateLeagueController();

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage CreateNewLeague(string League_Name, string League_Description, bool Join_Allow_Anyone, int? Creator_User_FK,
                                                   bool Trade_Day_Enabled, bool Randomize_Enabled, int Game_Mode, int League_Duration, 
                                                   bool Renew_Duration, string League_Icon, bool System_Public = false)
        {
            return Request.CreateResponse(HttpStatusCode.OK, controller.CreateNewLeague(League_Name, League_Description, Join_Allow_Anyone, Creator_User_FK, Trade_Day_Enabled, Randomize_Enabled,
                                              Game_Mode, League_Duration, Renew_Duration, League_Icon, System_Public).ToJson());
        }
    }
}