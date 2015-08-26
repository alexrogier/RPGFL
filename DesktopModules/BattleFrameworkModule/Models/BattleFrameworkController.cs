using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.BattleFrameworkModule.Models
{
    public class BattleFrameworkController
    {
        public IList<Skirmish> GetCurrentSkirmishes()
        {
            return CBO.FillCollection<Skirmish>(DataProvider.Instance().ExecuteReader("RPGFL_GetCurrentSkirmishes")); 
        }
        public IList<Skirmish> GetSkirmishData(int Skirmish_PK)
        {
            return CBO.FillCollection<Skirmish>(DataProvider.Instance().ExecuteReader("RPGFL_GetSkirmishData", Skirmish_PK));
        }

        public IList<Skirmish> GetSkillDataFromSkirmishCharacters(int Skirmish_PK)
        {
            return CBO.FillCollection<Skirmish>(DataProvider.Instance().ExecuteReader("RPGFL_GetSkillDataFromSkirmishCharacters", Skirmish_PK));
        }

        public IList<Combat_Log> GetCombatLogData(int Skirmish_PK)
        {
            return CBO.FillCollection<Combat_Log>(DataProvider.Instance().ExecuteReader("RPGFL_GetCombatLogData", Skirmish_PK));
        }

        public bool CreateSkirmishCharacterDraft(int Skirmish_PK)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_CreateSkirmishCharacterDraft", Skirmish_PK);
            return true;
        }
    }
}