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

namespace Christoc.Modules.SkirmishModule.Models
{
    public class ModuleSkirmishController : DnnApiController
    {
        SkirmishController controller = new SkirmishController();

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetSkirmishes(string FILTER_context)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, controller.GetSkirmishes(FILTER_context).ToJson());
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}