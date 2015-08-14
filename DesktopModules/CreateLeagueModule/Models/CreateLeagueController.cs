using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.CreateLeagueModule.Models
{
    public class CreateLeagueController
    {
        public int CreateNewLeague(string League_Name, string League_Description, bool Join_Allow_Anyone, int? Creator_User_FK,
                                    bool Trade_Day_Enabled, bool Randomize_Enabled, int Game_Mode, int League_Duration,
                                    bool Renew_Duration, string League_Icon, bool System_Public = false)
        {
            // create league and return PK of newly created league
            return CBO.FillCollection<NewLeague>(DataProvider.Instance().ExecuteReader("RPGFL_CreateNewLeague",
                                                    League_Name, League_Description, Join_Allow_Anyone, Creator_User_FK, Trade_Day_Enabled,
                                                    Randomize_Enabled, Game_Mode, League_Duration, Renew_Duration, League_Icon, System_Public)
                                                )[0].League_PK;
        }
    }
}