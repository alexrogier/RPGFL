using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.StandingsModule.Models
{
    public class Standings
    {
        public int TotalValue { get; set; }
        public int UserPK { get; set; }
        public int LeaguePK { get; set; }
        public int Rank { get; set; }
    }

    public class DraftPick
    {
        public int Character_PK { get; set; }
        public int League_FK { get; set; }
    }

    public class UserInfo
    {
        public int UserID { get; set; }
        public string DisplayName { get; set; }
    }
}