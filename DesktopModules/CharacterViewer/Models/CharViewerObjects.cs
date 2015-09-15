using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.ModuleCharacterViewer.Models
{
    public class Character
    {
        public int Character_PK { get; set; }
        public string Character_Name { get; set; }
        public string Archetype { get; set; }
        public int Priority { get; set; }
    }
    public class Guild
    {
        public int Guild_PK { get; set; }
        public string Guild_Name { get; set; }
    }
    public class HttpPostDraftData
    {
        public string DraftPriorities { get; set; }
        public int UserFK { get; set; }
    }
    public class PostData
    {
        public IList<PriorityData> newData { get; set; }
    }
    public class PriorityData
    {
        public int Priority { get; set; }
        public int Character_PK { get; set; }
    }
    public class Skill
    {
        public int Skill_PK { get; set; }
        public int Character_FK { get; set; }
        public string Skill_Name { get; set; }
        public string Skill_Description { get; set; }
        public int Energy_Cost { get; set; }
        public string Attribute_FK { get; set; }
        public bool blsPassive { get; set; }
        public string Damage_Roll { get; set; }
        public string Damage_Types { get; set; }
        public string Skill_Type { get; set; }
        public int Max_Targets { get; set; }
        public bool bAutoSuccess { get; set; }
        public int Special_Min_Roll { get; set; }
        public int Exec_Track_Step { get; set; }

    }
}