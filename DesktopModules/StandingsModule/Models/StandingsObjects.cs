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
    }

    public class DraftPick
    {
        public int Character_PK { get; set; }
        public int League_FK { get; set; }
    }

    public class StandingsQueryFilter {
        public string FILTER_accolade { get; set; }
        /* POOSIBLE <FILTER_accolade> VALUES
         * 'Overall'
         * 'Damage_Dealt'
         * 'Damage_Taken'
         * 'Opponent_Knock_Outs'
         * 'Critical_Successes'
         * 'Healt_Regained'
         * 'Ally_Bonus_Damage' ** Accolade relative to 'Enemy_Less_Damage'. Use term 'Enchanter_Hunter' for filtering
         * 'Enemy_Less_Damage' ** Accolade relative to 'Ally_Bonus_Damage'. Use term 'Enchanter_Hunter' for filtering
         * 'Afflictions_Inflicted'
         */

        public string FILTER_context { get; set; }
        public int FILTER_leaguefk { get; set; }
    }
}