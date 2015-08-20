using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.RPGFLScheduledJobs.Models
{
    public class ScheduledJobsController
    {
        public Series GetActiveSeries()
        {
            return CBO.FillCollection<Series>(DataProvider.Instance().ExecuteReader("RPGFL_GetActiveSeries"))[0];
        }

        public Series CreateNewSeries(int CurrentSeriesPK)
        {
            // create new Series and return newly created Series data
            return CBO.FillCollection<Series>(DataProvider.Instance().ExecuteReader("RPGFL_CreateNewSeries"))[0];
        }

        public bool CreateSeriesCharacterDraft()
        {
            // create new draft list for current series
            DataProvider.Instance().ExecuteReader("RPGFL_CreateSeriesCharacterDraft");
            return true;
        }

        public bool DeleteArchivedSkirmishesFromInterval(int DeleteInterval)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_DeleteArchivedSkirmishesFromInterval", DeleteInterval);
            return true;
        }
    }
}