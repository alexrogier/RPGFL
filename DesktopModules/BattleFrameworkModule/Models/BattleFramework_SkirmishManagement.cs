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

                // get today's skirmishes
                IList<Skirmish> globalSkirmishes = controller.GetCurrentSkirmishes();

                foreach (Skirmish skirmish in globalSkirmishes)
                {
                    // get all data for data warehouse object arrays
                    IList<Character> globalCharacters = controller.GetSkirmishCharacters(skirmish.Skirmish_PK);
                    IList<Skill> globalSkills = controller.GetSkillDataFromSkirmishCharacters(skirmish.Skirmish_PK);
                    IList<Initiative_Track> globalInitTrack = controller.GetInitiativeTrackFromSkirmish(skirmish.Skirmish_PK);
                    IList<Votes> globalVotes = controller.GetVoteDataFromSkirmish(skirmish.Skirmish_PK);

                    // perform skills following initiatve track (should already be sorted from SQL)
                    foreach (var currAct in globalInitTrack)
                    {
                        // check character's most voted skill
                        Votes favoredVote = globalVotes.Where(w => w.Character_FK == currAct.Character_FK).OrderByDescending(o => o.Vote_Count).FirstOrDefault();
                        // perform most voted skill
                        
                        // TO PERFORM SKILL
                        // get skill data from globalSkills
                        /***
                         * 
                         * Damage_Roll_1: 3d6,2,Burning (XdX,BASEDMG,TYPE)
                         * Damage_Roll_2: 3d6,0,Lightning
                         * Damage_Roll_3: 3d6,0,Acid
                         * Damage_Roll_4: 2d10,0,Healing
                         * Damage_Roll_5: NULL
                         * Damage_Roll_6: NULL
                         * Damage_Roll_7: NULL
                         * Damage_Roll_8: NULL
                         * Skill_Type: Attack/Heal/Bless/Affliction/Passive/Taunt/Special
                         * 
                         * */


                        // determine who it is targetting
                        // resolve any "before-attack" effects
                        // execute skill against targets [more logic here]
                        // inflict damage/afflictions/buffs
                        // record resolution in combat log
                        // record accolades (both character and user based)
                    }


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