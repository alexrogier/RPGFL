using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.AdminCharacterManagerModule.Models
{
    public class Character
    {
        public int Character_PK { get; set; }
        public string Character_Name { get; set; }
        public string Title_Desc { get; set; }
        public int Health { get; set; }
        public int Dodge { get; set; }
        public string Archetype { get; set; }
        public int Finesse { get; set; }
        public int Agility { get; set; }
        public int Senses { get; set; }
        public int Mana { get; set; }
        public string Immunities { get; set; }
        public string Vulnerabilities { get; set; }
        public string Resistances { get; set; }
        public int Guild_FK { get; set; }
        public int Initiative { get; set; }
        public int Max_Energy { get; set; }
    }

    public class Guild
    {
        public int Guild_PK { get; set; }
        public int Guild_Name { get; set; }
    }
}