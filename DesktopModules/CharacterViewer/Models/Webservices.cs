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

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetAllCharacters(int FILTER_guildfk)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetAllCharacters(FILTER_guildfk).ToJson());
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