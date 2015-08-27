using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Services.Scheduling;


namespace Christoc.Modules.BattleFrameworkModule.Models
{
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

                IList<Skirmish> currentSkirmishes = controller.GetCurrentSkirmishes();
                // determine iniative & act order for each character in upcoming skirmish
                foreach (var skirmish in currentSkirmishes)
                {
                    this.ScheduleHistoryItem.AddLogNote("DoWork: Create skirmish character draft and initiatives for [" + skirmish.Skirmish_PK + "]");
                    controller.CreateSkirmishCharacterDraft(skirmish.Skirmish_PK);
                }

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