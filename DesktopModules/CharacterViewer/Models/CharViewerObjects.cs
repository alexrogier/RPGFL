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
    }
}