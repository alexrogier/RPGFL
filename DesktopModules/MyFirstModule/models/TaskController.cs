using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
    
namespace Christoc.Modules.MyFirstModule.models
{
    public class TaskController
    {
        public IList<Task> GetTasks(int ModuleID)
        {
            return CBO.FillCollection<Task>(DataProvider.Instance().ExecuteReader("CBP_GetTasks", ModuleID));
        }
    }
}