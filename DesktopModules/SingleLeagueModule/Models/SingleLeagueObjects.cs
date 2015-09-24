using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.SingleLeagueModule.Models
{
    public class League
    {
        public int League_PK { get; set; }
        public string League_Name { get; set; }
        public string League_Description { get; set; }
        public bool System_Public { get; set; }
        public bool Join_Allow_Anyone { get; set; }
        public int Creator_User_Fk { get; set; }
        public bool Trade_Day_Enabled { get; set; }
        public bool Randomized_Enabled { get; set; }
        public int Game_Mode { get; set; }
        public int League_Duration { get; set; }
        public bool Renew_Duration { get; set; }
        public string League_Icon { get; set; }
        public DateTime Creation_Date { get; set; }
        public IList<LeagueUsers> League_Users { get; set; }
    }

    public class LeagueUsers
    {
        public int User_FK { get; set; }
        public string DisplayName { get; set; }
        public int Accolade_Points { get; set; }
        // will need user icon as well
    }

    public class Character
    {
        public int Character_PK { get; set; }
        public string Character_Name { get; set; }
        public string Archetype { get; set; }
        public int Accolade_Points { get; set; }
    }

    public class EmailInvite
    {
        public int League_PK { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}