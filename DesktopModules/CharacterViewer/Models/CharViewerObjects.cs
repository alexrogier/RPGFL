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
}