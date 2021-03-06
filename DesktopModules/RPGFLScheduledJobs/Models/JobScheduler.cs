﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Services.Scheduling;
using System.IO;
using System.Text;

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
                this.ScheduleHistoryItem.AddLogNote("STARTING JOB");

                // create a log file and write all events

                #region Series Management
                // check for new series
                this.ScheduleHistoryItem.AddLogNote("DoWork: Series Management");
                Series activeSeries = controller.GetActiveSeries();
                this.ScheduleHistoryItem.AddLogNote("DoWork: activeSeries.Series_PK [" + activeSeries.Series_PK + "]");

                if (activeSeries.End_Date < DateTime.Today)
                {
                    // old series has ended, make a new one
                    this.ScheduleHistoryItem.AddLogNote("DoWork: Old series has ended, create new series ...");
                    CreateNewSeries(activeSeries);
                }
                #endregion

                #region Campaign Management
                this.ScheduleHistoryItem.AddLogNote("DoWork: Campaign Management");
                var activeCampaign = controller.GetActiveCampaign();
                this.ScheduleHistoryItem.AddLogNote("DoWork: activeCampaign.Campaign_PK [" + activeCampaign.Campaign_PK + "]");

                if (activeCampaign.Campaign_Start_Date == DateTime.Today)
                {
                    // old campaign has ended, create character data for new one
                    this.ScheduleHistoryItem.AddLogNote("DoWork: setup character energy for newly active campaign");
                    controller.CreateNewCampaignDataForCharacters();
                    // perform character drafting logic for leagues
                    controller.CreateLeagueCharacterDraft();
                }
                #endregion

                //Show success
                this.ScheduleHistoryItem.Succeeded = true;
            }
            catch (Exception ex)
            {
                this.ScheduleHistoryItem.Succeeded = false;
                this.ScheduleHistoryItem.AddLogNote("ERROR: " + ex.Message);
                this.Errored(ref ex);
                DotNetNuke.Services.Exceptions.Exceptions.LogException(ex);
            }
        }

        public void CreateNewSeries(Series activeSeries)
        {
            // current series has ended, start a new one
            this.ScheduleHistoryItem.AddLogNote("CreateNewSeries: Creating new series ...");
            controller.CreateNewSeries(activeSeries.Series_PK);

            // archive data
            this.ScheduleHistoryItem.AddLogNote("CreateNewSeries: Archiving data ...");
            // delete skirmish data older than interval @SkirmishDeletionInterval
            controller.DeleteArchivedSkirmishesFromInterval(SkirmishDeletionInterval);
            // draft new pool of characters for series
            this.ScheduleHistoryItem.AddLogNote("CreateNewSeries: Drafting new pool of characters ...");
            controller.CreateSeriesCharacterDraft();
            // generate schedule of skirmishes for entire series
            this.ScheduleHistoryItem.AddLogNote("CreateNewSeries: Generating skirmish schedule ...");
            controller.CreateSeriesSkirmishSchedule();
        }
    }
    public class EmailInviteManagement : SchedulerClient
    {
        public EmailInviteManagement(ScheduleHistoryItem oItem)
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
                this.ScheduleHistoryItem.AddLogNote("STARTING JOB");

                // check for email invites older than a month and delete them
                controller.GetExpiredEmailInvites();

                //Show success
                this.ScheduleHistoryItem.Succeeded = true;
            }
            catch (Exception ex)
            {
                this.ScheduleHistoryItem.Succeeded = false;
                this.ScheduleHistoryItem.AddLogNote("ERROR: " + ex.Message);
                this.Errored(ref ex);
                DotNetNuke.Services.Exceptions.Exceptions.LogException(ex);
            }
        }
    }
}