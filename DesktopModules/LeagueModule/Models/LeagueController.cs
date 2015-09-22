using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.LeagueModule.Models
{
    public class LeagueController
    {
        public IList<League> GetLeagues(int? FILTER_userfk = null, string FILTER_context = "SHOWUSERLEAGUES", string FILTER_search = "")
        {
            return CBO.FillCollection<League>(DataProvider.Instance().ExecuteReader("RPGFL_GetLeagues", FILTER_userfk, FILTER_context, FILTER_search));
        }
        public bool InsertUserIntoMatchmaking(int FILTER_userfk)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_InsertUserIntoMatchmaking", FILTER_userfk);
            return true;
        }
    }
}