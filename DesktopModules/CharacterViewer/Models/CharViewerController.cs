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
        public IList<Character> GetAllCharacters(int FILTER_guildfk, bool FILTER_allclasses, bool FILTER_healer, bool FILTER_assassin,
                                                    bool FILTER_hunter, bool FILTER_bruiser, bool FILTER_sorcerer, bool FILTER_enchanter,
                                                    bool FILTER_tank)
        {
            IList<Character> masterResults = CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetAllCharacters", FILTER_guildfk, FILTER_allclasses, FILTER_healer, FILTER_assassin,
                                                                                            FILTER_hunter, FILTER_bruiser, FILTER_sorcerer, FILTER_enchanter, FILTER_tank));

            return masterResults;
        }

        public IList<Character> GetUserDraftPriority(int FILTER_userfk)
        {
            IList<Character> masterResults = CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetUserDraftPriority", FILTER_userfk));

            return masterResults;
        }

        public IList<Guild> GetAllGuilds()
        {
            IList<Guild> masterResults = CBO.FillCollection<Guild>(DataProvider.Instance().ExecuteReader("RPGFL_GetAllGuilds"));

            return masterResults;
        }
    }
}