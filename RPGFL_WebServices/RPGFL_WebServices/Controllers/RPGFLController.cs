using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RPGFL_WebServices.Models;

namespace RPGFL_WebServices.Controllers
{
    public class RPGFLController : Controller
    {
        public RPGFLEntities ctx = new RPGFLEntities();

        // GET: RPGFL
        //public ActionResult Index(){ return View(); }

        public JsonResult GetAllCharacters()
        {
            var characters = (from character in ctx.Characters select character);

            List<RPGFLCharacter> charList = new List<RPGFLCharacter>();

            foreach (var a in characters)
            {
                var newData = new RPGFLCharacter(){ Character_Name = a.Character_Name , Title_Desc = a.Title_Desc, Health = a.Health, Dodge = a.Dodge, Archetype = a.Archetype, Finesse = a.Finesse,
                                                    Agility = a.Agility, Senses = a.Senses, Mana = a.Mana, Immunities = a.Immunities, Vulnerabilites = a.Vulnerabilities, Resistances = a.Resistances,
                                                    Guild_FK = a.Guild_FK, Initiative = a.Initiative };
                charList.Add(newData);
            }

            return Json(charList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllLeagues()
        {
            var leagues = from league in ctx.Leagues
                             select league;
            return Json(leagues);
        }

        public JsonResult GetAllskirmishs()
        {
            var skirmishs = from skirmish in ctx.Skirmishes
                          select skirmish;
            return Json(skirmishs);
        }

        public void UpdateAccolades()
        {
            var acolades = (from a in ctx.Accolades
                           select a).FirstOrDefault();
            acolades.Accolade_Point_Value++;

            ctx.SaveChanges();
        }
    }
}