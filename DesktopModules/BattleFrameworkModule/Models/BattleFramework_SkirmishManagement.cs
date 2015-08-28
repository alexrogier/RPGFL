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
        IList<Skirmish> globalSkirmishes = new List<Skirmish>();
        IList<Character> globalCharacters = new List<Character>();
        IList<Skill> globalSkills = new List<Skill>();
        IList<Initiative_Track> globalInitTrack = new List<Initiative_Track>();
        IList<Votes> globalVotes = new List<Votes>();
        IList<Combat_Log> globalCombatLog = new List<Combat_Log>();

            // skirmish interface
        Int32 activeCharacterPk = -1;

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
                globalSkirmishes = controller.GetCurrentSkirmishes();

                foreach (Skirmish skirmish in globalSkirmishes)
                {
                    // get all data for data warehouse object arrays
                    globalCharacters = controller.GetSkirmishCharacters(skirmish.Skirmish_PK);
                    globalSkills = controller.GetSkillDataFromSkirmishCharacters(skirmish.Skirmish_PK);
                    globalInitTrack = controller.GetInitiativeTrackFromSkirmish(skirmish.Skirmish_PK);
                    globalVotes = controller.GetVoteDataFromSkirmish(skirmish.Skirmish_PK);

                    // initialize characters
                    foreach(var character in globalCharacters)
                    {
                        character.Max_Health = character.Health;
                    }

                    // perform skills following initiatve track (should already be sorted from SQL)
                    foreach (var currAct in globalInitTrack)
                    {
                        // setup turn track
                        #region TURN TRACK OVERVIEW
                        /**
                         * 
                         * TURN TRACK STEPS
                         * Begin Turn
                         *      1 - set active character to this character
                         *      2 - is character stunned?
                         *      3 - special character skills
                         * Determine Skill
                         *      4 - find favored skill
                         *      5 - find favored targets for skill
                         * Preliminary Skill Execution
                         *      6 - target legibility (Invisiblity, Knocked Out, Charmed, ect)
                         *      7 - special character skills
                         * Perform Attack Roll
                         *      8 - determine if attack has advantage or disadvantage
                         *      9 - roll attack dice for attack and add base modifier
                         *      10 - compare result against target's dodge
                         *      12 - determine if successful or not
                         *      13 - if attack fails, skip step 5
                         *      14 - special character skills 
                         * Perform Damage Roll
                         *      18 - roll all damage dice for attack
                         *      19 - compare damage type to target's resistances/vulnerabilities/immunities
                         *      20 - special character skills (pre-damage)
                         *      21 - inflict damage on target
                         *      22 - special character skills (post-damage)
                         * Target Conditions
                         *      23 - check if target's HP has reached 0
                         *      24 - special character skills
                         *      25 - if target is less than or at 0 HP, classify them as "Knocked Out"
                         *      26 - determine if target receives any afflictions 
                         *      27 - special character skills
                         *      28 - determine if target receives any blessings
                         * End Turn
                         *      29 - special character skills
                         * 
                         * */
                        #endregion

                        // interface
                        Skill FavoredSkill = new Skill();
                        List<Character> FavoredSkillFavoredTargets = new List<Character>();
                        var lastTrackStep = 29;
                        
                        #region TURN TRACK 
                        // cycle through turn track
                        for (var currTrackStep = 1; currTrackStep <= lastTrackStep; currTrackStep++)
                        {
                            var currChar = GetCharacter(currAct.Character_FK);
                            switch (currTrackStep)
                            {
                                #region BEGIN TURN
                                case 1:
                                    // 1 - set active character to this character
                                    activeCharacterPk = currAct.Character_FK;
                                    break;
                                case 2:
                                    // 2 - is character stunned?
                                    if (currChar.Conditions.bStunned) currTrackStep = 29; // !!! CHANGE 29 TO LAST STEP OF TRACK !!!
                                    break;
                                case 3:
                                    // 3 - special character skills
                                    CheckSpecialSkills(currTrackStep, currChar);
                                    break;
                                #endregion
                                #region DETERMINE SKILL
                                case 4:
                                    // 4 - find favored skill
                                    FavoredSkill = GetSkill(globalVotes.OrderByDescending(x => x.Vote_Count).FirstOrDefault(x => x.Character_FK == currChar.Character_PK).Skill_FK);
                                    break;
                                case 5:
                                    // 5 - find favored targets for skill
                                    // targets are separated by commas
                                    var tmpTargets = Array.ConvertAll( globalVotes.FirstOrDefault(x =>
                                                    x.Skill_FK == FavoredSkill.Skill_PK &&
                                                    x.Character_FK == currChar.Character_PK).Targets.Split(','), int.Parse);
                                    FavoredSkillFavoredTargets.AddRange(tmpTargets.Select(target => GetCharacter(target)));
                                    break;
                                #endregion
                                #region PRELIMINARY SKILL EXECUTION
                                case 6:
                                    // 6 - target legibility (Invisiblity, Knocked Out, Charmed, ect)
                                    foreach (var target in FavoredSkillFavoredTargets)
                                    {
                                        // target is either Invisible or Knocked Out, reassign to random enemy
                                        if (target.Conditions.bInvisible || target.Conditions.bKnockedOut)
                                        {
                                            // remove old target from target list
                                            FavoredSkillFavoredTargets.Remove(target);
                                            Character newTarget = new Character();
                                            switch (FavoredSkill.Skill_Type)
                                            {
                                                case "Attack":
                                                case "Taunt":
                                                case "Affliction,Stunned":
                                                case "Affliction,Blinded":
                                                case "Affliction,Disadvantage":
                                                case "Affliction,Advantage":
                                                    // find new target not on this character's team
                                                    newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK != currChar.Guild_FK && !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));
                                                    break;
                                                case "Heal":
                                                    // find new target that is on this character's team
                                                    // case "Blessing"? Don't know what blessing types there would be
                                                    newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK && x.Health < x.Max_Health && !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));
                                                    break;
                                            }
                                            
                                            // ensure a target was found, then add it
                                            if(newTarget != null) FavoredSkillFavoredTargets.Add(newTarget);
                                        }

                                        // if character is Charmed
                                        if (currChar.Conditions.bCharmed)
                                        {
                                            // remove old target from target list
                                            FavoredSkillFavoredTargets.Remove(target);
                                            Character newTarget = new Character();

                                            // assign new target to random character (even ally), but cannot target the charmer
                                            newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => currChar.Conditions.Charm_Character_PK != x.Character_PK && !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));

                                            // ensure a target was found, then add it
                                            if (newTarget != null) FavoredSkillFavoredTargets.Add(newTarget);
                                        }

                                        // if character is Taunted
                                        if (currChar.Conditions.bTaunted)
                                        {
                                            // ensure taunter is still a legal target - otherwise maintain favored targets
                                            Boolean bTaunterTargettable = globalCharacters.Contains(globalCharacters.FirstOrDefault(x =>
                                                            x.Character_PK == currChar.Conditions.Taunted_Character_PK &&
                                                            !x.Conditions.bInvisible && 
                                                            !x.Conditions.bKnockedOut));

                                            if (bTaunterTargettable)
                                            {
                                                // remove old target from target list
                                                FavoredSkillFavoredTargets.Remove(target);
                                                Character newTarget = new Character();

                                                // assign new target to taunter
                                                newTarget = globalCharacters.FirstOrDefault(x => x.Character_PK == currChar.Conditions.Taunted_Character_PK);

                                                // ensure a target was found, then add it
                                                if (newTarget != null) FavoredSkillFavoredTargets.Add(newTarget);
                                            }
                                        }

                                        if (currChar.Conditions.bBlinded)
                                        {
                                            // remove old target from target list
                                            FavoredSkillFavoredTargets.Remove(target);
                                            Character newTarget = new Character();

                                            // assign new target to random character (even ally)
                                            newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));

                                            // ensure a target was found, then add it
                                            if (newTarget != null) FavoredSkillFavoredTargets.Add(newTarget);
                                        }
                                    }

                                    // ensure at least one target exists after validation
                                    if (FavoredSkillFavoredTargets.Count == 0) currTrackStep = lastTrackStep;
                                    break;
                                case 7:
                                    // 7 - special character skills
                                    CheckSpecialSkills(currTrackStep, currChar);
                                    break;
                                #endregion
                                #region Perform Attack Roll
                                case 8:
                                    // 8 - determine if attack is rolled with advantage or disadvantage
                                    if (currChar.Conditions.bAttackAdvantage || currChar.Conditions.bAttackDisadvantage)
                                    {
                                        var finalAdvDis = 0; // 0 = roll normally. -1 = roll disadvantage. 1 = roll advantage

                                        if (currChar.Conditions.bAttackAdvantage) finalAdvDis++;
                                        if (currChar.Conditions.bAttackDisadvantage) finalAdvDis--;

                                        // determine final result (coded this way because character could have both advantage & disadvantage)
                                        switch (finalAdvDis)
                                        {
                                            case 0:
                                                currChar.Conditions.bAttackAdvantage = false;
                                                currChar.Conditions.bAttackDisadvantage = false;
                                                break;
                                            case 1:
                                                currChar.Conditions.bAttackAdvantage = true;
                                                currChar.Conditions.bAttackDisadvantage = false;
                                                break;
                                            case -1:
                                                currChar.Conditions.bAttackAdvantage = false;
                                                currChar.Conditions.bAttackDisadvantage = true;
                                                break;
                                        }
                                    }
                                    break;
                                case 9:
                                    // 9 - roll attack dice for attack and add base modifier

                                    // loop through all targets and perform attacks
                                    foreach (var target in FavoredSkillFavoredTargets)
                                    {
                                        // create new combat log entry
                                        Combat_Log newCombatLogEntry = new Combat_Log();
                                        newCombatLogEntry.Action_Order = globalInitTrack.FirstOrDefault(x => x.Character_FK == currChar.Character_PK).Act_Order;
                                        //newCombatLogEntry.Conditions
                                        newCombatLogEntry.Assasilant_Character_FK = currChar.Character_PK;
                                        newCombatLogEntry.Skill_FK = FavoredSkill.Skill_PK;
                                        newCombatLogEntry.Target_Character_FK = target.Character_PK;
                                        newCombatLogEntry.Skirmish_FK = skirmish.Skirmish_PK;

                                        Random rand = new Random();

                                        // perform roll with a d20
                                        Int32 rollDiceRoll = 0;

                                        // reroll if character has advantage or disadvantage
                                        if (currChar.Conditions.bAttackAdvantage)
                                        {
                                            // perform roll with two d20's, taking the higher roll
                                            Int32 rollDiceReroll = rand.Next(1, 20);

                                            // record roll data
                                            newCombatLogEntry.Attack_Values = rollDiceRoll + "," + rollDiceReroll;

                                            if (rollDiceReroll > rollDiceRoll) rollDiceRoll = rollDiceReroll;
                                        }
                                        else if (currChar.Conditions.bAttackDisadvantage)
                                        {
                                            // perform roll with two d20's, taking the lower roll
                                            Int32 rollDiceReroll = rand.Next(1, 20);

                                            // record roll data
                                            newCombatLogEntry.Attack_Values = rollDiceRoll + "," + rollDiceReroll;

                                            if (rollDiceReroll < rollDiceRoll) rollDiceRoll = rollDiceReroll;
                                        }
                                        else
                                        {
                                            // perform roll with a d20
                                            rollDiceRoll = rand.Next(1, 20);

                                            // record roll data
                                            newCombatLogEntry.Attack_Values = rollDiceRoll.ToString();
                                        }

                                        // add base modifiers
                                        switch (FavoredSkill.Attribute_FK)
                                        {
                                            case "Finesse":
                                                rollDiceRoll += currChar.Finesse;
                                                break;
                                            case "Agility":
                                                rollDiceRoll += currChar.Agility;
                                                break;
                                            case "Senses":
                                                rollDiceRoll += currChar.Senses;
                                                break;
                                            case "Mana":
                                                rollDiceRoll += currChar.Mana;
                                                break;
                                        }

                                        // record roll result
                                        newCombatLogEntry.Damage_Final_Result = rollDiceRoll;

                                        // record new combat log
                                        globalCombatLog.Add(newCombatLogEntry);
                                    }
                                    break;
                                case 10:
                                    // 10 - determine if attacks are successful and determine damage

                                    // get combat logs regarding this character performed favored skill - it is possible this attack targets multiple targets
                                    var relativeCombatLogs = globalCombatLog.Where(x => x.Action_Order == globalInitTrack.FirstOrDefault(y => y.Character_FK == currChar.Character_PK).Act_Order);

                                    foreach (var log in relativeCombatLogs)
                                    {
                                        Character targetChar = GetCharacter(log.Target_Character_FK);

                                        // determine if attack is successful
                                        if (log.Attack_Final_Result >= targetChar.Dodge || FavoredSkill.bAutoSuccess)
                                        {
                                            // attack is successful - roll damage
                                            List<string> rollArray = FavoredSkill.Damage_Roll.Split(',').ToList();
                                            List<int> damageRolls = new List<int>(); // stores all damage rolls

                                            foreach (var roll in rollArray)
                                            {
                                                string rollSet = roll.Substring(0, roll.IndexOf("+")); // extract "XdX" from "XdX+X"
                                                Int32 rollDiceAmt = Int32.Parse(rollSet.Substring(0, rollSet.IndexOf("d")));
                                                Int32 rollDiceType = Int32.Parse(rollSet.Substring(rollSet.IndexOf("d")+ 1));
                                                Int32 rollModifier = Int32.Parse(roll.Substring(roll.IndexOf("+") + 1)); // extract "+X" from "XdX+X"
                                                Int32 rollFinalResult = 0;

                                                // roll dice for each amount required
                                                for (var x = 1; x <= rollDiceAmt; x++)
                                                {
                                                    Random rand = new Random();
                                                    Int32 rollResult = rand.Next(1, rollDiceType);

                                                    // record damage roll
                                                    damageRolls.Add(rollResult);

                                                    // accumulate results
                                                    rollFinalResult += rollResult;
                                                }

                                                // add modifier
                                                rollFinalResult += rollModifier;

                                                // WHAT TO DO WITH rollFinalResult?
                                            }

                                            //newCombatLogEntry.Damage_Final_Result
                                            //newCombatLogEntry.Damage_Values
                                        }
                                    }
                                    break;
                                #endregion
                            }
                        }
                        #endregion

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

        public Character GetCharacter(int Character_PK)
        {
            return globalCharacters.FirstOrDefault(x => x.Character_PK == Character_PK);
        }
        public List<Skill> GetSkillsForTrackStep(int Track_Step)
        {
            return globalSkills.Where(skill => skill.Exec_Track_Step == Track_Step).ToList();
        }
        public void ExecuteSkill(Skill currSkill, Character currChar)
        {
            
        }
        public Skill GetSkill(int Skill_PK)
        {
            return globalSkills.FirstOrDefault(x => x.Skill_PK == Skill_PK);
        }

        public void CheckSpecialSkills(int Track_Step, Character Current_Character)
        {
            foreach (var skill in GetSkillsForTrackStep(Track_Step)) ExecuteSkill(skill, Current_Character);
        }
    }
}