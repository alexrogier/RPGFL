using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Services.Scheduling;

namespace Christoc.Modules.RPGFLScheduledJobs.Models
{
    public class SkirmishManagement : SchedulerClient
    {
        public SkirmishManagement(ScheduleHistoryItem oItem)
            : base()
        {
            this.ScheduleHistoryItem = oItem;
        }

        // RPGFL Interface
        ScheduledJobsController controller = new ScheduledJobsController();
        public int SkirmishDeletionInterval = 2; // DEFAULT: 2 | DESC: amount of months from current month to delete old skirmish data from site

        public override void DoWork()
        {
            try
            {

                //Perform required items for logging
                this.Progressing();

                //Your code goes here
                //To log note
                //this.ScheduleHistoryItem.AddLogNote("note")

                // create a log file and write all events

                #region Series Management
                // check for new series
                Series activeSeries = controller.GetActiveSeries();

                if (activeSeries.End_Date > DateTime.Today) CreateNewSeries(activeSeries);
                #endregion

                //Show success
                this.ScheduleHistoryItem.Succeeded = true;
            }
            catch (Exception ex)
            {
                this.ScheduleHistoryItem.Succeeded = false;
                //InsertLogNote("Exception= " + ex.ToString());
                this.Errored(ref ex);
                DotNetNuke.Services.Exceptions.Exceptions.LogException(ex);
            }
        }

        public void CreateNewSeries(Series activeSeries)
        {
            // current series has ended, start a new one
            controller.CreateNewSeries(activeSeries.Series_PK);

            // archive data
            // delete skirmish data older than interval @SkirmishDeletionInterval
            controller.DeleteArchivedSkirmishesFromInterval(SkirmishDeletionInterval);
            // draft new pool of characters for series
            controller.CreateSeriesCharacterDraft();
            // generate schedule of skirmishes for entire series
        }
    }
}