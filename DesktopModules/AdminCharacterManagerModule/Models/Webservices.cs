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

namespace Christoc.Modules.AdminCharacterManagerModule.Models
{
    public class ModuleAdmChaManController : DnnApiController
    {
        AdminCharacterController controller = new AdminCharacterController();

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetAllCharacters()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetAllCharacters().ToJson());
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetCharacterData(int Character_PK)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetCharacterData(Character_PK).ToJson());
            } 
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}