using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.RPGFLScheduledJobs.Models
{
    public class Series
    {
        public int Series_PK { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public bool bIsLive { get; set; }
    }

    public class Skirmish
    {
        public int Skirmish_PK { get; set; }
        public DateTime Skirmish_Date { get; set; }
        public int Campaign_FK { get; set; }
        public int Guild_1_FK { get; set; }
        public int Guild_2_FK { get; set; }
        public int Guild_1_Accolade_Points { get; set; }
        public int Guild_2_Accolade_Points { get; set; }
        public int Skirmish_Victor_FK { get; set; }
    }

    public class Campaign
    {
        public int Campaign_PK { get; set; }
        public DateTime Campaign_Start_Date { get; set; }
        public DateTime Campaign_End_Date { get; set; }
        public int Series_FK { get; set; }
    }
}