using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.LeagueModule.Models
{
    public class League
    {
        public int League_PK { get; set; }
        public int League_Type { get; set; }
        public string League_Name { get; set; }
        public string League_Description { get; set; }
        public bool Trade_Day_Enabled { get; set; }
        public bool System_Public { get; set; }
        public bool Join_Allow_Anyone { get; set; }
    }
}