using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.CreateLeagueModule.Models
{
    public class NewLeague
    {
        public int League_PK { get; set; }
    }

    public class EmailInvite
    {
        public int League_PK { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}