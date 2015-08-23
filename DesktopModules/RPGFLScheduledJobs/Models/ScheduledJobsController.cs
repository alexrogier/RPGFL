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

        public Campaign GetActiveCampaign()
        {
            return CBO.FillCollection<Campaign>(DataProvider.Instance().ExecuteReader("RPGFL_GetActiveCampaign"))[0];

        }

        public Series CreateNewSeries(int CurrentSeriesPK)
        {
            // create new Series and return newly created Series data
            return CBO.FillCollection<Series>(DataProvider.Instance().ExecuteReader("RPGFL_CreateNewSeries", CurrentSeriesPK))[0];
        }

        public bool CreateSeriesSkirmishSchedule()
        {
         DataProvider.Instance().ExecuteReader("RPGFL_CreateSeriesSkirmishSchedule");
         return true;
        }

        public bool CreateSeriesCharacterDraft()
        {
            // create new draft list for current series
            DataProvider.Instance().ExecuteReader("RPGFL_CreateSeriesCharacterDraft");
            return true;
        }

        public bool CreateNewCampaignDataForCharacters()
        {
            DataProvider.Instance().ExecuteReader("RPGFL_CreateNewCampaignDataForCharacters");
            return true;
        }

        public bool DeleteArchivedSkirmishesFromInterval(int DeleteInterval)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_DeleteArchivedSkirmishesFromInterval", DeleteInterval);
            return true;
        }
    }
}