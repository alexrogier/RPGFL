﻿using System;
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
        public HttpResponseMessage GetStandings(string FILTER_accolade, string FILTER_context, int User_PK, int FILTER_leaguefk = -1)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetStandings(FILTER_accolade, FILTER_context, User_PK, FILTER_leaguefk).ToJson());
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}