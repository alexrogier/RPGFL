using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Services.Scheduling;
using System.IO;
using DotNetNuke.Common.Utilities;

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
        IList<Character_Track_Log> globalCharacterTrackLog = new List<Character_Track_Log>();
        IList<Skill> globalSkills = new List<Skill>();
        IList<Initiative_Track> globalInitTrack = new List<Initiative_Track>();
        IList<Votes> globalVotes = new List<Votes>();
        IList<Combat_Log> globalCombatLog = new List<Combat_Log>();
        IList<Accolades> globalAccolades = new List<Accolades>();
        StreamWriter logger;

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

                // get accolades
                globalAccolades = controller.GetAccolades();

                foreach (Skirmish skirmish in globalSkirmishes)
                {
                    // create log file for skirmish
                    logger = File.CreateText(AppDomain.CurrentDomain.BaseDirectory + "/DesktopModules/BattleFrameworkModule/logs/" + skirmish.Skirmish_PK + "_" + skirmish.SkirmishDate + ".txt");

                    // skirmish interface
                    Int32 activeCharacterPk = -1;

                    // get all data for data warehouse object arrays
                    globalCharacters = controller.GetSkirmishCharacters(skirmish.Skirmish_PK);
                    logger.WriteLine(DateTime.Now + "DATA globalCharacters: " + string.Join(",", globalCharacters));
                    globalSkills = controller.GetSkillDataFromSkirmishCharacters(skirmish.Skirmish_PK);
                    logger.WriteLine(DateTime.Now + "DATA globalSkills: " + string.Join(",", globalSkills));
                    globalInitTrack = controller.GetInitiativeTrackFromSkirmish(skirmish.Skirmish_PK);
                    logger.WriteLine(DateTime.Now + "DATA globalInitTrack: " + string.Join(",", globalInitTrack));
                    globalVotes = controller.GetVoteDataFromSkirmish(skirmish.Skirmish_PK);
                    logger.WriteLine(DateTime.Now + "DATA globalVotes: " + string.Join(",", globalVotes));
                    // object array that holds all pending skills triggered by a specific event
                    List<Prepared_Skills> skirmishPreparedSkills = new List<Prepared_Skills>();

                    logger.WriteLine("");
                    logger.WriteLine(DateTime.Now + "BEGIN CHARACTER INITIALIZATION");
                    // initialize characters
                    foreach(var character in globalCharacters)
                    {
                        logger.WriteLine(DateTime.Now + "SETTING [" + character.Character_Name + "] Max_Health to " + character.Health);
                        character.Max_Health = character.Health;

                        logger.WriteLine(DateTime.Now + "SYSTEM Creating character track log for character ...");
                        globalCharacterTrackLog.Add(new Character_Track_Log(){ Character_FK = character.Character_PK });
                    }
                    logger.WriteLine(DateTime.Now + "END CHARACTER INITIALIZATION");

                    // perform skills following initiatve track (should already be sorted from SQL)
                    logger.WriteLine("");
                    logger.WriteLine(DateTime.Now + "BEGIN SKIRMISH");
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
                         *      8 - special character skills
                         *      9 - determine if attack has advantage or disadvantage
                         *      10 - roll attack dice for attack and add base modifier
                         * Perform Damage Roll
                         *      11 - determine if attacks are successful and determine damage
                         *      12 - special character skills (pre-damage)
                         *      13 - inflict damage on target
                         *      14 - special character skills (post-damage)
                         * Target Conditions
                         *      15 - determine if target receives any afflictions 
                         *      16 - special character skills
                         * End Turn
                         * 
                         * */
                        #endregion

                        // interface
                        Skill FavoredSkill = new Skill();
                        List<Character> FavoredSkillFavoredTargets = new List<Character>();
                        var lastTrackStep = 16;
                        
                        #region TURN TRACK 
                        // cycle through turn track
                        for (var currTrackStep = 1; currTrackStep <= lastTrackStep; currTrackStep++)
                        {
                            var currChar = GetCharacter(currAct.Character_FK);
                            logger.WriteLine(DateTime.Now + "BEGIN TRACK STEP [" + currTrackStep + "] for [" + currChar.Character_Name + "]");

                            switch (currTrackStep)
                            {
                                #region BEGIN TURN
                                case 1:
                                    // 1 - set active character to this character
                                    logger.WriteLine("SETTING [" + currChar.Character_Name + "](pk=" + currChar.Character_PK + ") as active character");
                                    activeCharacterPk = currAct.Character_FK;
                                    break;
                                case 2:
                                    // 2 - is character stunned?
                                    if (currChar.Conditions.bStunned){
                                        logger.WriteLine("CONDITION Character is stunned, skip to end turn step");
                                        currTrackStep = lastTrackStep;
                                    }
                                    break;
                                case 3:
                                    // 3 - special character skills
                                    CheckSpecialSkills(currTrackStep, currChar);
                                    break;
                                #endregion
                                #region DETERMINE SKILL
                                case 4:
                                    // 4 - find favored skill
                                    logger.WriteLine(DateTime.Now + "SYSTEM Finding favored skill for character to perform ...");
                                    FavoredSkill = GetSkill(globalVotes.OrderByDescending(x => x.Vote_Count).FirstOrDefault(x => x.Character_FK == currChar.Character_PK).Skill_FK);
                                    logger.WriteLine(DateTime.Now + "SYSTEM Found favored skill. Skill_Name: [" + FavoredSkill.Skill_Name + "](pk=" + FavoredSkill.Skill_PK + ")");
                                    break;
                                case 5:
                                    // 5 - find favored targets for skill
                                    // targets are separated by commas
                                    logger.WriteLine(DateTime.Now + "SYSTEM Finding favored targets for skill ...");
                                    var tmpTargets = Array.ConvertAll( globalVotes.FirstOrDefault(x =>
                                                    x.Skill_FK == FavoredSkill.Skill_PK &&
                                                    x.Character_FK == currChar.Character_PK).Targets.Split(','), int.Parse);
                                    FavoredSkillFavoredTargets.AddRange(tmpTargets.Select(target => GetCharacter(target)));
                                    logger.WriteLine(DateTime.Now + "SYSTEM Found favored targets [" + string.Join(",", FavoredSkillFavoredTargets) + "]");
                                    break;
                                #endregion
                                #region PRELIMINARY SKILL EXECUTION
                                case 6:
                                    logger.WriteLine(DateTime.Now + "SYSTEM Determine target legibility");
                                    // 6 - target legibility (Invisiblity, Knocked Out, Charmed, ect)
                                    foreach (var target in FavoredSkillFavoredTargets)
                                    {
                                        logger.WriteLine(DateTime.Now + "SYSTEM target=[" + target.Character_Name + "] | " +
                                                                        "bInvisible:" + target.Conditions.bInvisible + " | bKnockedOut:" + target.Conditions.bKnockedOut + 
                                                                        "bCharmed:" + target.Conditions.bCharmed + " | bTaunted:" + target.Conditions.bTaunted + 
                                                                        "bBlinded:" + target.Conditions.bBlinded);

                                        // check if character has skills to bypass normal targetting rules
                                        CheckSpecialSkills(currTrackStep, currChar);

                                        // target is either Invisible or Knocked Out, reassign to random enemy
                                        if (target.Conditions.bInvisible || target.Conditions.bKnockedOut)
                                        {
                                            // remove old target from target list
                                            logger.WriteLine(DateTime.Now + "SYSTEM target is invisible or knocked out, remove target from favored target list and assign a new target | Skill_Type:"+ FavoredSkill.Skill_Type);
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
                                                    logger.WriteLine(DateTime.Now + "SYSTEM New target found | {" + newTarget.ToString() + "}");
                                                    break;
                                                case "Heal":
                                                    // find new target that is on this character's team
                                                    // case "Blessing"? Don't know what blessing types there would be
                                                    newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK && x.Health < x.Max_Health && !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));
                                                    logger.WriteLine(DateTime.Now + "SYSTEM New target found | {" + newTarget.ToString() + "}");
                                                    break;
                                            }
                                            
                                            // ensure a target was found, then add it
                                            if (newTarget != null)
                                            {
                                                logger.WriteLine(DateTime.Now + "SYSTEM adding new target to favored targets");
                                                FavoredSkillFavoredTargets.Add(newTarget);
                                            }
                                        }

                                        // if character is Charmed
                                        if (currChar.Conditions.bCharmed)
                                        {
                                            logger.WriteLine(DateTime.Now + "SYSTEM target is charmed, reassign target to random ally");

                                            // remove old target from target list
                                            FavoredSkillFavoredTargets.Remove(target);
                                            Character newTarget = new Character();

                                            // assign new target to random ally
                                            newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK && currChar.Conditions.Charm_Character_PK != x.Character_PK && !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));

                                            // ensure a target was found, then add it
                                            if (newTarget != null)
                                            {
                                                logger.WriteLine(DateTime.Now + "SYSTEM target acquired, add to favored targets | newTarget:{" + newTarget.ToString() + "}");
                                                FavoredSkillFavoredTargets.Add(newTarget);
                                            }
                                        }

                                        // if character is Taunted
                                        if (currChar.Conditions.bTaunted)
                                        {
                                            // ensure taunter is still a legal target - otherwise maintain favored targets
                                            Boolean bTaunterTargettable = globalCharacters.Contains(globalCharacters.FirstOrDefault(x =>
                                                            x.Character_PK == currChar.Conditions.Taunted_Character_PK &&
                                                            !x.Conditions.bInvisible && 
                                                            !x.Conditions.bKnockedOut));

                                            logger.WriteLine(DateTime.Now + "SYSTEM target is taunted, reassign target to taunter if able | TaunterCharPK:"+ target.Conditions.Taunted_Character_PK + " | bTaunterTargettable:" + bTaunterTargettable);

                                            if (bTaunterTargettable)
                                            {
                                                // remove old target from target list
                                                FavoredSkillFavoredTargets.Remove(target);
                                                Character newTarget = new Character();

                                                // assign new target to taunter
                                                newTarget = globalCharacters.FirstOrDefault(x => x.Character_PK == currChar.Conditions.Taunted_Character_PK);

                                                // ensure a target was found, then add it
                                                if (newTarget != null)
                                                {
                                                    logger.WriteLine(DateTime.Now + "SYSTEM taunter is targettable, add to favored targets | newTarget:{" + newTarget.ToString() + "}");
                                                    FavoredSkillFavoredTargets.Add(newTarget);
                                                }
                                            }
                                        }

                                        if (currChar.Conditions.bBlinded)
                                        {
                                            logger.WriteLine(DateTime.Now + "SYSTEM target is blinded, reassign target to random character");

                                            // remove old target from target list
                                            FavoredSkillFavoredTargets.Remove(target);
                                            Character newTarget = new Character();

                                            // assign new target to random character (even ally)
                                            newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));

                                            // ensure a target was found, then add it
                                            if (newTarget != null)
                                            {
                                                logger.WriteLine(DateTime.Now + "SYSTEM target acquired, add to favored targets | newTarget:{" + newTarget.ToString() + "}");
                                                FavoredSkillFavoredTargets.Add(newTarget);
                                            }
                                        }
                                    }

                                    // ensure at least one target exists after validation
                                    if (FavoredSkillFavoredTargets.Count == 0)
                                    {
                                        logger.WriteLine(DateTime.Now + "SYSTEM no valid targets available - end the turn");
                                        currTrackStep = lastTrackStep;
                                    }
                                    break;
                                case 7:
                                    // 7 - special character skills
                                    if (FavoredSkill.Skill_Type == "Special,Prepare")
                                    {
                                        // prepare special skill
                                        logger.WriteLine(DateTime.Now + "SYSTEM favoredskill is special type, prepare it");
                                        skirmishPreparedSkills.Add(new Prepared_Skills() { Exec_Track_Step = FavoredSkill.Exec_Track_Step, Preparer_Character_FK = currChar.Character_PK, Skill_PK = FavoredSkill.Skill_PK });
                                    }

                                    CheckSpecialSkills(currTrackStep, currChar);
                                    break;
                                #endregion
                                #region PERFORM ATTACK ROLL
                                case 8:
                                    // 8 - special character skills
                                    CheckSpecialSkills(currTrackStep, currChar);
                                    break;
                                case 9:
                                    // 9 - determine if attack is rolled with advantage or disadvantage
                                    logger.WriteLine(DateTime.Now + "SYSTEM preliminary attack calculation | bAttackAdvantage:" + currChar.Conditions.bAttackAdvantage + " | bAttackDisadvantage:" + currChar.Conditions.bAttackDisadvantage);
                                    if (currChar.Conditions.bAttackAdvantage || currChar.Conditions.bAttackDisadvantage)
                                    {
                                        var finalAdvDis = 0; // 0 = roll normally. -1 = roll disadvantage. 1 = roll advantage

                                        if (currChar.Conditions.bAttackAdvantage) finalAdvDis++;
                                        if (currChar.Conditions.bAttackDisadvantage) finalAdvDis--;

                                        // determine final result (coded this way because character could have both advantage & disadvantage)
                                        logger.WriteLine(DateTime.Now + "SYSTEM final preliminary attack calculation | finalAdvDis:" + finalAdvDis);
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
                                case 10:
                                    // 10 - roll attack dice for attack and add base modifier

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

                                        logger.WriteLine(DateTime.Now + "SYSTEM rolling attack against [" + target.Character_Name + "] ...");

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

                                        logger.WriteLine(DateTime.Now + "SYSTEM roll(s) achieved | Attack_Values:" + newCombatLogEntry.Attack_Values);

                                        // record accolades
                                        if (rollDiceRoll == 1)
                                        {
                                            // critical failure achieved
                                            UpdateCharacterTrackLog(currChar.Character_PK, "Critical_Fails", 1);
                                        }
                                        else if (rollDiceRoll == 20)
                                        {
                                            // critical success achieved
                                            UpdateCharacterTrackLog(currChar.Character_PK, "Critical_Fails", 1);
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
                                        newCombatLogEntry.Attack_Final_Result = rollDiceRoll;
                                        logger.WriteLine(DateTime.Now + "SYSTEM final attack result with modifier[" + FavoredSkill.Attribute_FK + "] | Attack_Final_Result:" + rollDiceRoll);

                                        // record new combat log
                                        globalCombatLog.Add(newCombatLogEntry);

                                        // check for special character skills after rolling attack
                                        CheckSpecialSkills(currTrackStep, currChar);
                                    }
                                    break;
                            #endregion
                                #region PERFORM DAMAGE ROLL
                                case 11:
                                    // 11 - determine if attacks are successful and determine damage

                                    // get combat logs regarding this character performed favored skill - it is possible this attack targets multiple targets
                                    var relativeAttackCombatLogs = globalCombatLog.Where(x => x.Action_Order == globalInitTrack.FirstOrDefault(y => y.Character_FK == currChar.Character_PK).Act_Order);

                                    foreach (var log in relativeAttackCombatLogs)
                                    {
                                        Character targetChar = GetCharacter(log.Target_Character_FK);

                                        // determine if attack is successful
                                        logger.WriteLine(DateTime.Now + "SYSTEM calculating if attack was successful ... | Attack_Final_Result:" + log.Attack_Final_Result + " | Target's Dodge:" + targetChar.Dodge);
                                        log.bAttackSuccessful = (log.Attack_Final_Result >= targetChar.Dodge || FavoredSkill.bAutoSuccess);
                                        if (log.bAttackSuccessful)
                                        {
                                            // attack is successful - roll damage
                                            List<string> rollArray = FavoredSkill.Damage_Roll.Split(',').ToList();
                                            List<int> damageRolls = new List<int>(); // stores all damage rolls

                                            logger.WriteLine(DateTime.Now + "SYSTEM attack successful, rolling damage ...");
                                            foreach (var roll in rollArray)
                                            {
                                                logger.WriteLine(DateTime.Now + "SYSTEM rolling [" + roll + "]");
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

                                                log.tmpDamage_Final_Result.Add(rollFinalResult);
                                                log.Damage_Types = FavoredSkill.Damage_Types;

                                                logger.WriteLine(DateTime.Now + "SYSTEM final damage calculation | Damage_Final_Result:" + rollFinalResult + " | Damage_Types:" + FavoredSkill.Damage_Types);
                                            }
                                        }
                                        else
                                        {
                                            // attack missed, end the turn
                                            currTrackStep = lastTrackStep;
                                        }
                                    }
                                    break;
                                case 12:
                                    // 12 - special character skills (pre-damage)
                                    CheckSpecialSkills(currTrackStep, currChar);
                                    break;
                                case 13:
                                    // 13 - inflict damage on target

                                    // get combat logs regarding this character performed favored skill - it is possible this attack targets multiple targets
                                    var relativeDamageCombatLogs = globalCombatLog.Where(x => x.Action_Order == globalInitTrack.FirstOrDefault(y => y.Character_FK == currChar.Character_PK).Act_Order);

                                    foreach (var log in relativeDamageCombatLogs)
                                    {
                                        List<int> tmpDamageResults = log.tmpDamage_Final_Result;
                                        List<int> tmpDamageValues = new List<int>();
                                        List<string> tmpDamageTypes = log.Damage_Types.Split(',').ToList();
                                        Character target = GetCharacter(log.Target_Character_FK);
                                        Int32 overallDamageResult = 0;

                                        foreach (var dmgRoll in tmpDamageResults)
                                        {
                                            var finalDamageResult = dmgRoll;

                                            logger.WriteLine(DateTime.Now + "SYSTEM inflict damage on target | finalDamageResult:" + dmgRoll + " | Vulnerabilities:[" + target.Vulnerabilities + "] | Resistances:[" + target.Resistances + "] | Immunities:[" + target.Immunities + "]");

                                            if (target.Vulnerabilities != null)
                                            {
                                                // consider target vulnerabilities
                                                List<string> vulnerabilities = target.Vulnerabilities.Split(',').ToList();
                                                var bVulnerableToAttack = tmpDamageTypes.Exists(x => x == vulnerabilities[tmpDamageResults.IndexOf(dmgRoll)]);

                                                // target is vulnerable to damage - deal double damage
                                                if (bVulnerableToAttack) finalDamageResult += dmgRoll * 2;
                                            }

                                            if (target.Resistances != null)
                                            {
                                                // consider target resistances
                                                List<string> resistances = target.Resistances.Split(',').ToList();
                                                var bResistantToAttack = tmpDamageTypes.Exists(x => x == resistances[tmpDamageResults.IndexOf(dmgRoll)]);

                                                // target is resistance to damage - deal half damage, rounded up
                                                if (bResistantToAttack) finalDamageResult += (int)Math.Ceiling((double)dmgRoll / 2);
                                            }

                                            if (target.Immunities != null)
                                            {
                                                // consider target immunities
                                                List<string> immunities = target.Immunities.Split(',').ToList();
                                                var bImmuneToAttack = tmpDamageTypes.Exists(x => x == immunities[tmpDamageResults.IndexOf(dmgRoll)]);

                                                // target is immune to damage - negate all damage
                                                if (bImmuneToAttack) finalDamageResult = 0;
                                            }

                                            // inflict damage on target
                                            logger.WriteLine(DateTime.Now + "SYSTEM [" + target.Character_Name + "] taking (" + finalDamageResult + ") damage");
                                            target.TakeDamage(finalDamageResult);

                                            // accumulate overall damage for combat log
                                            overallDamageResult += finalDamageResult;
                                            tmpDamageValues.Add(finalDamageResult);
                                        }

                                        // record overall damage
                                        log.Damage_Final_Result = overallDamageResult;
                                        log.Damage_Values = tmpDamageValues.ToJson();
                                    }
                                    break;
                                case 14:
                                    // 14 - special character skills (post-damage)
                                    CheckSpecialSkills(currTrackStep, currChar);
                                    break;
                                #endregion
                                #region TARGET CONDITIONS
                                case 15:
                                    // 15 - determine if target receives any afflictions

                                    // get combat logs regarding this character performed favored skill - it is possible this attack targets multiple targets
                                    var relativeConditionCombatLogs = globalCombatLog.Where(x => x.Action_Order == globalInitTrack.FirstOrDefault(y => y.Character_FK == currChar.Character_PK).Act_Order);

                                    foreach (var log in relativeConditionCombatLogs)
                                    {
                                        Character targetChar = GetCharacter(log.Target_Character_FK);

                                        // determine conditions if attack was successful
                                        if (log.bAttackSuccessful)
                                        {
                                            bool bSpecialRuleInflictCondition = true;

                                            // skill requires a minimum attack result to inflict condition
                                            if (FavoredSkill.Special_Min_Roll != null)
                                            {
                                                // check if minimum result required was met
                                                if (log.Attack_Final_Result < FavoredSkill.Special_Min_Roll) bSpecialRuleInflictCondition = false;
                                            }

                                            if (bSpecialRuleInflictCondition)
                                            {
                                                // inflict afflictions
                                                if (FavoredSkill.Skill_Type.Contains("Affliction"))
                                                {
                                                    var affliction = FavoredSkill.Skill_Type.Substring(FavoredSkill.Skill_Type.IndexOf(',') + 1);

                                                    logger.WriteLine(DateTime.Now + "SYSTEM inflict Affliction(" + affliction + ") on target ");

                                                    switch (affliction)
                                                    {
                                                        case "Stunned":
                                                            targetChar.Conditions.bStunned = true;
                                                            log.Conditions = 1;
                                                            break;
                                                        case "Blinded":
                                                            targetChar.Conditions.bBlinded = true;
                                                            log.Conditions = 2;
                                                            break;
                                                        case "Charmed":
                                                            targetChar.Conditions.bCharmed = true;
                                                            log.Conditions = 6;
                                                            targetChar.Conditions.Charm_Character_PK = currChar.Character_PK;
                                                            break;
                                                    }
                                                }

                                                // inflict taunt
                                                if (FavoredSkill.Skill_Type == "Taunt")
                                                {
                                                    logger.WriteLine(DateTime.Now + "SYSTEM inflict Taunt on target");
                                                    targetChar.Conditions.bTaunted = true;
                                                    targetChar.Conditions.Taunted_Character_PK = currChar.Character_PK;
                                                    log.Conditions = 8;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case 16:
                                    // 16 - special character skills
                                    CheckSpecialSkills(currTrackStep, currChar);
                                    break;
                                #endregion
                            }

                            logger.WriteLine(DateTime.Now + "END TRACK STEP [" + currTrackStep + "] for [" + currChar.Character_Name + "]");
                        }
                        #endregion
                        #region COMBAT LOG MANAGEMENT
                        // push combat log to server
                        #endregion
                        #region ACCOLADE MANAGEMENT
                        logger.WriteLine(DateTime.Now + "SYSTEM Recording character accolades ...");
                        foreach (var log in globalCombatLog)
                        {
                            Skill performedSkill = globalSkills.FirstOrDefault(x => x.Skill_PK == log.Skill_FK);
                            Character assailantCharacter = globalCharacters.FirstOrDefault(x => x.Character_PK == log.Assasilant_Character_FK);
                            Character targetCharacter = globalCharacters.FirstOrDefault(x => x.Character_PK == log.Target_Character_FK);
                            
                            switch (performedSkill.Skill_Type)
                            {
                                // special skills need to track accolades in their own way
                                case "Taunt":
                                case "Affliction,Disadvantage":
                                case "Affliction,Advantage":
                                case "Affliction,Blinded":
                                case "Affliction,Charmed":
                                case "Affliction,Stunned":
                                case "Attack":
                                    if (log.bAttackSuccessful)
                                    {
                                        UpdateCharacterTrackLog(assailantCharacter.Character_PK, "Damage_Dealt",
                                            log.Damage_Final_Result);

                                        if (targetCharacter.Archetype.Contains("Tank") ||
                                            targetCharacter.Archetype.Contains("Bruiser"))
                                            UpdateCharacterTrackLog(targetCharacter.Character_PK, "Damage_Taken",
                                                log.Damage_Final_Result);

                                        var characterHealth = targetCharacter.Max_Health;
                                        List<int> assistedKnockOuts = new List<int>();
                                        foreach (var i in globalCombatLog)
                                        {
                                            // iterate through logs to determine if this combat log knocked the target character out
                                            if (i.Target_Character_FK == targetCharacter.Character_PK)
                                            {
                                                characterHealth -= i.Damage_Final_Result;
                                                if (i.Assasilant_Character_FK != assailantCharacter.Character_PK) assistedKnockOuts.Add(i.Assasilant_Character_FK);
                                            }

                                            if (i == log) break;
                                        }
                                        if (characterHealth <= 0)
                                        {
                                            // this combat log knocked the target character out
                                            UpdateCharacterTrackLog(assailantCharacter.Character_PK,
                                                "Opponent_Knock_Outs", 1);
                                            foreach (var assistant in assistedKnockOuts)
                                                UpdateCharacterTrackLog(assistant, "Assist_Knock_Outs", 1);
                                            UpdateCharacterTrackLog(targetCharacter.Character_PK, "Self_Knock_Outs", 1);
                                        }
                                    }
                                    else
                                    {
                                        // target dodged attack
                                        UpdateCharacterTrackLog(targetCharacter.Character_PK, "Attacks_Dodged", 1);
                                    }
                                    break;
                                case "Heal":
                                    UpdateCharacterTrackLog(assailantCharacter.Character_PK, "Health_Regained", log.Damage_Final_Result);
                                    break;

                            }
                        }

                        // check for all who survived
                        foreach (var character in globalCharacters)
                        {
                            if (character.Health > 0) UpdateCharacterTrackLog(character.Character_PK, "Skirmishes_Survived", 1);
                        }

                        // accolade for character that acted first
                        UpdateCharacterTrackLog(
                            globalInitTrack.OrderBy(x => x.Act_Order).FirstOrDefault().Character_FK,
                            "Initiative_Acted_First", 1);

                        // push character track log to server
                        // server needs to record User, Character, and Guild accolades
                        #endregion
                        #region CHARACTER MANAGEMENT
                        // update character energy for each character that performed a skill in the skirmish
                        logger.WriteLine(DateTime.Now + " SYSTEM Updating all character energy ...");
                        List<Energy_Consumption> newEnergyValues = globalCombatLog.Select(log => new Energy_Consumption {Character_FK = log.Assasilant_Character_FK, 
                                                                                                                         Campaign_FK = skirmish.Campaign_FK, 
                                                                                                                         Consume_Energy = globalSkills.FirstOrDefault(x => x.Skill_PK == log.Skill_FK).Energy_Cost}).ToList();
                        controller.UpdateCharacterEnergy(newEnergyValues);
                        #endregion
                    }
                    logger.WriteLine("");
                    logger.WriteLine(DateTime.Now + "END SKIRMISH");
                }

                //Show success
                this.ScheduleHistoryItem.Succeeded = true;
            }
            catch (Exception ex)
            {
                this.ScheduleHistoryItem.Succeeded = false;
                this.ScheduleHistoryItem.AddLogNote("ERROR: " + ex.Message);
                logger.WriteLine(DateTime.Now + "CRITICAL ERROR: " + ex.Message);
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
        public Skill GetSkill(int Skill_PK)
        {
            return globalSkills.FirstOrDefault(x => x.Skill_PK == Skill_PK);
        }
        public void CheckSpecialSkills(int Track_Step, Character Current_Character)
        {
            foreach (var skill in GetSkillsForTrackStep(Track_Step)) ExecuteSkill(skill, Current_Character);
        }
        public void ExecuteSkill(Skill currSkill, Character currChar)
        {

        }

        public void UpdateCharacterTrackLog(int Character_PK, string AccoladeType, int inVal)
        {
            Character_Track_Log updateLog = globalCharacterTrackLog.FirstOrDefault(x => x.Character_FK == Character_PK);
            int accoladePointWorth = globalAccolades.FirstOrDefault(x => x.Accolade_Identifier == AccoladeType).Accolade_Point_Value;

            switch (AccoladeType)
            {
                
                case "Damage_Dealt":
                    updateLog.Damage_Dealt += inVal * accoladePointWorth;
                    break;
                case "Damage_Taken":
                    updateLog.Damage_Taken += inVal * accoladePointWorth;
                    break;
                case "Opponent_Knock_Outs":
                    updateLog.Opponent_Knock_Outs += inVal * accoladePointWorth;
                    break;
                case "Self_Knock_Outs":
                    updateLog.Self_Knock_Outs += inVal * accoladePointWorth;
                    break;
                case "Assist_Knock_Outs":
                    updateLog.Assist_Knock_Outs += inVal * accoladePointWorth;
                    break;
                case "Attacks_Dodged":
                    updateLog.Attacks_Dodged += inVal * accoladePointWorth;
                    break;
                case "Critical_Successes":
                    updateLog.Critical_Successes += inVal * accoladePointWorth;
                    break;
                case "Critical_Fails":
                    updateLog.Critical_Fails += inVal * accoladePointWorth;
                    break;
                case "Health_Regained":
                    updateLog.Health_Regained += inVal * accoladePointWorth;
                    break;
                case "Ally_Bonus_Damage":
                    updateLog.Ally_Bonus_Damage += inVal * accoladePointWorth;
                    break;
                case "Enemy_Less_Damage":
                    updateLog.Enemy_Less_Damage += inVal * accoladePointWorth;
                    break;
                case "Afflictions_Inflicted":
                    updateLog.Afflictions_Inflicted += inVal * accoladePointWorth;
                    break;
                case "Initiative_Acted_First":
                    updateLog.Initiative_Acted_First += inVal * accoladePointWorth;
                    break;
            }
        }
    }
}