using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.AdminCharacterManagerModule.Models
{
    public class AdminCharacterController
    {
        public IList<Character> GetAllCharacters()
        {
            return CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetAllCharacters"));
        }

        public IList<Character> GetCharacterData(int Character_PK)
        {
            return CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetCharacterData", Character_PK));
        }
    }
}