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

namespace Christoc.Modules.ModuleCharacterViewer.Models
{
    public class ModuleCharacterViewerController : DnnApiController
    {
        CharViewController controller = new CharViewController();

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World!");
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public HttpResponseMessage TESTCharPriority()
        //{
        //    controller.TESTCharPriority();
        //    return Request.CreateResponse(HttpStatusCode.OK, "SUCCESS");
        //}

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetAllCharacters(int FILTER_guildfk, bool FILTER_allclasses, bool FILTER_healer, bool FILTER_assassin,
                                                    bool FILTER_hunter, bool FILTER_bruiser, bool FILTER_sorcerer, bool FILTER_enchanter,
                                                    bool FILTER_tank)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetAllCharacters(FILTER_guildfk, FILTER_allclasses, FILTER_healer, FILTER_assassin,
                                                                                            FILTER_hunter, FILTER_bruiser, FILTER_sorcerer, FILTER_enchanter, FILTER_tank).ToJson());
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetAllSkills(int Character_PK)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetAllSkills(Character_PK));
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetUserDraftPriority(int FILTER_userfk)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetUserDraftPriority(FILTER_userfk).ToJson());
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage UpdateUserDraftPriority(HttpPostDraftData DraftPriorities)
        {
            try
            {
                // logger
                //var sw = new System.IO.StreamWriter("C:\\Users\\arogier\\Desktop\\log.txt", true);
                //sw.WriteLine("WEBSERVICES:");
                //sw.WriteLine(DraftPriorities);
                //sw.WriteLine(" ");
                //sw.WriteLine(DraftPriorities.DraftPriorities);
                //sw.WriteLine(DraftPriorities.UserFK);
                //sw.Close();
                
                controller.UpdateUserDraftPriority(DraftPriorities);
                return Request.CreateResponse(HttpStatusCode.OK, "SUCCESS");
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetAllGuilds()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetAllGuilds().ToJson());
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}