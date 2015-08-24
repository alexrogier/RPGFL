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
        public Skirmish GetCurrentSkirmish()
        {
            return CBO.FillCollection<Skirmish>(DataProvider.Instance().ExecuteReader("RPGFL_GetCurrentSkirmish"))[0]; 
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

        public bool InsertInitativeForSkirmishCharacters(int Skirmish_PK)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_InsertInitativeForSkirmishCharacters", Skirmish_PK);
            return true;
        }
    }
}