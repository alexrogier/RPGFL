using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.AlertModule.Models
{
    public class AlertController
    {
        public IList<Alert> GetActiveAlerts()
        {
            return CBO.FillCollection<Alert>(DataProvider.Instance().ExecuteReader("RPGFL_GetActiveAlerts"));
        }
    }
}