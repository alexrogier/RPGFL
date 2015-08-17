using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.ModuleCharacterViewer.Models
{
    public class CharViewController
    {
        public IList<Character> GetAllCharacters(int FILTER_guildfk)
        {
            IList<Character> masterResults = CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetAllCharacters"));

            return masterResults;
        }

        public IList<Guild> GetAllGuilds()
        {
            IList<Guild> masterResults = CBO.FillCollection<Guild>(DataProvider.Instance().ExecuteReader("RPGFL_GetAllGuilds"));

            return masterResults;
        }
    }
}