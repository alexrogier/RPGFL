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
        public IList<Standings> GetStandings(string FILTER_accolade, string FILTER_context, int User_PK, int FILTER_leaguefk = -1)
        {
            StandingsQueryFilter masterFilter = new StandingsQueryFilter(){ User_PK = User_PK, FILTER_accolade = FILTER_accolade, FILTER_context = FILTER_context, FILTER_leaguefk = FILTER_leaguefk }

            switch (FILTER_accolade)
            {
               
            }

            //switch (FILTER_context)
            //{
            //    case "SHOWONLYME":
            //        break;
            //    case "SHOWEVERYONE":
            //        break;
            //}

            //if (FILTER_leaguefk != -1)
            //{

            //}

            IList<Standings> masterResults = CBO.FillCollection<Standings>(DataProvider.Instance().ExecuteReader("RPGFL_GetActiveAlerts", masterFilter));

            return masterResults;
        }
    }
}