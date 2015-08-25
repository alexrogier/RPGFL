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
    public class Character_Track_Log
    {
        public int Character_FK { get; set; }
        public int Damage_Dealt { get; set; }
        public int Damage_Taken { get; set; }
        public int Opponent_Knock_Outs { get; set; }
        public int Self_Knock_Outs { get; set; }
        public int Assist_Knock_Outs { get; set; }
        public int Attacks_Dodged { get; set; }
        public int Critical_Successes { get; set; }
        public int Critical_Fails { get; set; }
        public int Skirmishes_Participated { get; set; }
        public int Health_Regained { get; set; }
        public int Skirmishes_Survived { get; set; }
        public int Ally_Bonus_Damage { get; set; }
        public int Enemy_Less_Damage { get; set; }
        public int Afflictions_Inflicted { get; set; }
        public int Initiative_Acted_First { get; set; }
        public int Guild_Win_Bonus { get; set; }
        public int Series_FK { get; set; }
    }
}