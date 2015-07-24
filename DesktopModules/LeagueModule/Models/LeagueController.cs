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
        public IList<League> GetLeagues(int? User_PK = null)
        {
            return CBO.FillCollection<League>(DataProvider.Instance().ExecuteReader("RPGFL_GetLeagues", User_PK));
        }
    }
}