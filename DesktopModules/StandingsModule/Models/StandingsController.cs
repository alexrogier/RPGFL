using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.StandingsModule.Models
{
    public class StandingsController
    {
        public IList<Standings> GetStandings(String FILTER_accolade = "OVERALL", String FILTER_context = "SHOWEVERYONE", Int32 FILTER_leaguefk = -1)
        {
            /* @FILTER_accolade
             *      "Overall"
             *      "Damage_Dealt"
             *      "Damage_Taken"
             *      "Opponent_Knock_Outs"
             *      "Critical_Successes"
             *      "Health_Regained"
             *      "Enchanter_Hunter" (Ally Bonus Damage + Enemy Less Damage)
             *      "Afflictions_Inflicted"
             * @FILTER_context
             *      "SHOWLEAGUE"
             * @FILTER_leaguefk
             *      <[RPGFL].[dbo].[Leagues].[League_PK]> (Only use with FILTER_context "SHOWLEAGUE")
             */

            IList<Standings> masterResults = CBO.FillCollection<Standings>(DataProvider.Instance().ExecuteReader("RPGFL_GetStandings", FILTER_accolade, FILTER_context, FILTER_leaguefk));
             
            // index rankings within returned results
            foreach (var result in masterResults) {
                result.Rank = masterResults.IndexOf(result) + 1;
            }

            return masterResults;
        }
    }
}