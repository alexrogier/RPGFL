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

namespace Christoc.Modules.MyFirstModule.models
{
    public class ModuleTaskController : DnnApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetTasks(int moduleId)
        {
            try
            {
                var tasks = new TaskController().GetTasks(moduleId).ToJson();
                return Request.CreateResponse(HttpStatusCode.OK, tasks);
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}