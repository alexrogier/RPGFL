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
        public IList<Character> GetAllCharacters()
        {
            IList<Character> masterResults = CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetAllCharacters"));

            return masterResults;
        }
    }
}