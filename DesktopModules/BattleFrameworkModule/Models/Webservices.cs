using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Scheduling;
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
        public HttpResponseMessage GetAllGuilds()
        {
            return Request.CreateResponse(HttpStatusCode.OK, controller.GetAllGuilds().ToJson());
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetCharacterDraftByUser(int User_PK)
        {
            return Request.CreateResponse(HttpStatusCode.OK, controller.GetCharacterDraftByUser(User_PK).ToJson());
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetAccolades()
        {
            return Request.CreateResponse(HttpStatusCode.OK, controller.GetAccolades().ToJson());
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

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetAllCharacterDataInSkirmish(int Skirmish_PK)
        {
            return Request.CreateResponse(HttpStatusCode.OK, controller.GetAllCharacterDataInSkirmish(Skirmish_PK).ToJson());
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetInitiativeTrackFromSkirmish(int Skirmish_PK)
        {
            return Request.CreateResponse(HttpStatusCode.OK, controller.GetInitiativeTrackFromSkirmish(Skirmish_PK).ToJson());
        }

        [HttpGet]
        public HttpResponseMessage ProcessSkirmish(int Skirmish_PK)
        {
            BattleFramework_SkirmishManagement skirmishManager = new BattleFramework_SkirmishManagement(new ScheduleHistoryItem());
            skirmishManager.Skirmish_PK = Skirmish_PK;
            skirmishManager.DoWork();
            //return Request.CreateResponse(HttpStatusCode.OK, controller.GetAllCharacterDataInSkirmish(Skirmish_PK).ToJson());
            return Request.CreateResponse(HttpStatusCode.OK, "SUCCESS");
        }
    }
}