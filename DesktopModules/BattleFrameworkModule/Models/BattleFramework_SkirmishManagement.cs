using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Services.Scheduling;

namespace Christoc.Modules.BattleFrameworkModule.Models
{
    public class BattleFramework_SkirmishManagement : SchedulerClient
    {
        public BattleFramework_SkirmishManagement(ScheduleHistoryItem oItem)
            : base()
        {
            this.ScheduleHistoryItem = oItem;
        }

        // RPGFL Interface
        BattleFrameworkController controller = new BattleFrameworkController();

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

    public class BattleFramework_InitiativeManagement : SchedulerClient
    {
        public BattleFramework_InitiativeManagement(ScheduleHistoryItem oItem)
            : base()
        {
            this.ScheduleHistoryItem = oItem;
        }

        // RPGFL Interface
        BattleFrameworkController controller = new BattleFrameworkController();

        public override void DoWork()
        {
            try
            {
                //Perform required items for logging
                this.Progressing();

                //Your code goes here
                //To log note
                this.ScheduleHistoryItem.AddLogNote("STARTING JOB");

                Skirmish currentSkirmish = controller.GetCurrentSkirmish();
                // roll iniative for each character in upcoming skirmish
                controller.CreateSkirmishCharacterDraft(currentSkirmish.Skirmish_PK);

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