using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Christoc.Modules.AlertModule.Models
{
    public class Alert
    {
        public int Alert_PK { get; set; }
        public string Alert_Name { get; set; }
        public string Alert_Message { get; set; }
        public DateTime Alert_StartTime { get; set; }
        public DateTime Alert_EndTime { get; set; }
    }
}