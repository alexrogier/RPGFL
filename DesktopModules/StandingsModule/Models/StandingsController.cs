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
        public IList<Standings> GetStandings(string FILTER_accolade, string FILTER_context, int FILTER_leaguefk = -1)
        {
            StandingsQueryFilter masterFilter = new StandingsQueryFilter() { FILTER_accolade = FILTER_accolade, FILTER_context = FILTER_context, FILTER_leaguefk = FILTER_leaguefk };
            IList<Standings> masterResults = CBO.FillCollection<Standings>(DataProvider.Instance().ExecuteReader("RPGFL_GetStandings", masterFilter));

            // configure data if needed here

            return masterResults;
        }
    }
}