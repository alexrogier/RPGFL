using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.SkirmishModule.Models
{
    public class Skirmish
    {
        public int Skirmish_PK { get; set; }
        public DateTime Skirmish_Date { get; set; }
        public int Campaign_FK { get; set; }
        public int Guild_1_FK { get; set; }
        public int Guild_2_FK { get; set; }
        public int Guild_1_Accolade_Points { get; set; }
        public int Guild_2_Accolade_Points { get; set; }
    }
}