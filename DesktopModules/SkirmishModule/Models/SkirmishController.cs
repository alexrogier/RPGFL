using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.SkirmishModule.Models
{
    public class SkirmishController
    {
        public IList<Skirmish> GetSkirmishes()
        {
            return CBO.FillCollection<Skirmish>(DataProvider.Instance().ExecuteReader("RPGFL_GetSkirmishes"));
        }
    }
}