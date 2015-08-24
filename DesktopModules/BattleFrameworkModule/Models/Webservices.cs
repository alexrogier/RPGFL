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


namespace Christoc.Modules.BattleFrameworkModule.Models
{
    public class ModuleBattleFrameworkController : DnnApiController
    {
        BattleFrameworkController controller = new BattleFrameworkController();

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetSkirmishData(int Skirmish_PK)
        {
            return Request.CreateResponse(HttpStatusCode.OK, controller.GetSkirmishData(Skirmish_PK).ToJson());
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetSkillDataFromSkirmishCharacters(int Skirmish_PK)
        {
            return Request.CreateResponse(HttpStatusCode.OK, controller.GetSkillDataFromSkirmishCharacters(Skirmish_PK).ToJson());
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetCombatLogData(int Skirmish_PK)
        {
            return Request.CreateResponse(HttpStatusCode.OK, controller.GetCombatLogData(Skirmish_PK).ToJson());
        }
    }
}