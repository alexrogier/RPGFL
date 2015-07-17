using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.AdminCharacterManagerModule.Models
{
    public class LeagueController
    {
        public IList<Character> GetAllCharacters()
        {
            return CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetAllCharacters"));
        }
    }
}