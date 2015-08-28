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


                        /**
                         * 
                         * BATTLE CHECK STEPS
                         * 1) Begin Turn
                         *      - set active character to this character
                         *      - is stunned?
                         *      - if stunned, skip to step 7
                         *      - special character skills
                         * 2) Preliminary Skill Execution
                         *      - target legibility (Invisiblity, Knocked Out, Charmed, ect)
                         *      - special character skills
                         * 3) Confirm Targets
                         *      - on-target effects from target?
                         *      - on-target effects from this character?
                         * 4) Perform Attack Roll
                         *      - attack has advantage?
                         *      - attack has disadvantage?
                         *      - roll attack dice for attack and add base modifier
                         *      - compare result against target's dodge
                         *      - determine if successful or not
                         *      - if attack fails, skip step 5
                         *      - special character skills 
                         * 5) Perform Damage Roll
                         *      - roll all damage dice for attack
                         *      - compare damage type to target's resistances/vulnerabilities/immunities
                         *      - special character skills (pre-damage)
                         *      - inflict damage on target
                         *      - special character skills (post-damage)
                         * 6) Target Conditions
                         *      - check if target's HP has reached 0
                         *      - special character skills
                         *      - if target is less than or at 0 HP, classify them as "Knocked Out"
                         *      - determine if target receives any afflictions 
                         *      - special character skills
                         *      - determine if target receives any blessings
                         * 7) End Turn
                         *      - special character skills
                         * 
                         * */
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