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
        public int CharacterPK { get; set; }
        public string CharacterName { get; set; }
        public string Archetype { get; set; }
        public int LeaguePK { get; set; }
        public int UserPK { get; set; }
        public int TotalValue { get; set; }
    }

    public class UserInfo
    {
        public int UserID { get; set; }
        public string DisplayName { get; set; }
    }
}