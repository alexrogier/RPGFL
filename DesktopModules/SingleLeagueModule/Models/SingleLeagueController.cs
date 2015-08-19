using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.SingleLeagueModule.Models
{
    public class SingleLeagueController
    {
        #region Get Operations
        public IList<League> GetSingleLeagueData(int FILTER_leaguefk)
        {
            return CBO.FillCollection<League>(DataProvider.Instance().ExecuteReader("RPGFL_GetSingleLeagueData", FILTER_leaguefk));
        }

        public IList<LeagueUsers> GetLeagueUsers(int FILTER_leaguefk)
        {
            return CBO.FillCollection<LeagueUsers>(DataProvider.Instance().ExecuteReader("RPGFL_GetLeagueUsers", FILTER_leaguefk));
        }

        public int GetLeagueCountByUser(int FILTER_userfk)
        {
            return CBO.FillCollection<int>(DataProvider.Instance().ExecuteReader("RPGFL_GetLeagueCountByUser", FILTER_userfk))[0];
        }

        public IList<Character> GetCharacterDraftByLeague(int FILTER_userfk, int FILTER_leaguefk)
        {
            return CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetCharacterDraftByLeague", FILTER_userfk, FILTER_leaguefk));
        }
        #endregion

        #region Delete Operations
        public void DeleteUserFromLeague(int FILTER_leaguefk, int FILTER_userfk, bool bLeagueOwner)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_DeleteUserFromLeague", FILTER_leaguefk, FILTER_userfk, bLeagueOwner);
        }
        #endregion

        #region Insert Operations
        public void InsertUserInLeague(int FILTER_leaguefk, int FILTER_userfk)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_InsertUserInLeague", FILTER_leaguefk, FILTER_userfk);
        }
        #endregion
    }
}