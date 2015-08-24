using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.BattleFrameworkModule.Models
{
    public class Skirmish
    {
        public int Skirmish_PK { get; set; }
        public DateTime SkirmishDate { get; set; }
        public int Campaign_FK { get; set; }
        public int Guild_1_FK { get; set; }
        public int Guild_2_FK { get; set; }
        public int Guild_1_Accolade_Points { get; set; }
        public int Guild_2_Accolade_Points { get; set; }
        public int Skirmish_Victor_FK { get; set; }
        public int Series_FK { get; set; }
    }

    public class Combat_Log
    {
        public int CombatLog_PK { get; set; }
        public int Skirmish_FK { get; set; }
        public int Assasilant_Character_FK { get; set; }
        public int Target_Character_FK { get; set; }
        public int Skill_FK { get; set; }
        public int Action_Order { get; set; }
        public int Attack_Final_Reselt { get; set; }
        public string Attack_Values { get; set; }
        public int Damage_Final_Result { get; set; }
        public string Damage_Values { get; set; }
        public int Conditions { get; set; }
    }

    public class Skill
    {
        public int Skill_PK { get; set; }
        public string Skill_Name { get; set; }
        public string Skill_Description { get; set; }
        public int Energy_Cost { get; set; }
        public int Attribute_FK { get; set; }
        public bool bIsPassive { get; set; }
    }
}