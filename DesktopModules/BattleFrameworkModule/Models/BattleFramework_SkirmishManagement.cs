﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using DotNetNuke.Services.Scheduling;
using System.IO;
using DotNetNuke.Common.Utilities;

namespace Christoc.Modules.BattleFrameworkModule.Models
{
    public class BattleFramework_SkirmishManagement : SchedulerClient
    {
        public int Skirmish_PK = -1;
        public BattleFramework_SkirmishManagement(ScheduleHistoryItem oItem)
            : base()
        {
            this.ScheduleHistoryItem = oItem;
        }

        #region RPGFL Interface Declaration
        BattleFrameworkController controller = new BattleFrameworkController();
        Game_State _GAMESTATE = new Game_State();
        IList<Skirmish> globalSkirmishes = new List<Skirmish>();
        IList<Character> globalCharacters = new List<Character>();
        IList<Character_Track_Log> globalCharacterTrackLog = new List<Character_Track_Log>();
        IList<Skill> globalSkills = new List<Skill>();
        IList<Initiative_Track> globalInitTrack = new List<Initiative_Track>();
        IList<Votes> globalVotes = new List<Votes>();
        IList<Combat_Log> globalCombatLog = new List<Combat_Log>();
        IList<Accolades> globalAccolades = new List<Accolades>();
        StreamWriter logger;
        Random rand = new Random();
        Stopwatch stopwatch = new Stopwatch();
        // object array that holds all pending skills triggered by a specific event
        List<Prepared_Skills> skirmishPreparedSkills = new List<Prepared_Skills>(); 
        #endregion

        public override void DoWork()
        {
            try
            {
                //Perform required items for logging
                this.Progressing();

                //Your code goes here
                //To log note
                this.ScheduleHistoryItem.AddLogNote("STARTING JOB");
                stopwatch.Start();
                
                // determine what skirmish to process
                if (Skirmish_PK == -1)
                {
                    // get today's skirmishes
                    globalSkirmishes = controller.GetCurrentSkirmishes();   
                }
                else
                {
                    // process a specific skirmish
                    globalSkirmishes = controller.GetSkirmishData(Skirmish_PK);
                }

                // get accolades
                globalAccolades = controller.GetAccolades();

                foreach (Skirmish skirmish in globalSkirmishes)
                {
                    #region Skirmish Initialization
                    // create log file for skirmish
                    this.ScheduleHistoryItem.AddLogNote("CREATE LOG FILE");
                    logger = File.CreateText(HttpRuntime.AppDomainAppPath + "/DesktopModules/BattleFrameworkModule/logs/" + skirmish.Skirmish_PK + ".txt");

                    _GAMESTATE.Skirmish_FK = skirmish.Skirmish_PK;

                    // get all data for data warehouse object arrays
                    globalCharacters = controller.GetSkirmishCharacters(skirmish.Skirmish_PK);
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms DATA globalCharacters: " + Json.Serialize(globalCharacters));
                    globalSkills = controller.GetSkillDataFromSkirmishCharacters(skirmish.Skirmish_PK);
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms DATA globalSkills: " + Json.Serialize(globalSkills));
                    globalInitTrack = controller.GetInitiativeTrackFromSkirmish(skirmish.Skirmish_PK);
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms DATA globalInitTrack: " + Json.Serialize(globalInitTrack));
                    globalVotes = controller.GetVoteDataFromSkirmish(skirmish.Skirmish_PK, null);
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms DATA globalVotes: " + Json.Serialize(globalVotes));

                    // reset warehouses
                    globalCombatLog.Clear();
                    globalCharacterTrackLog.Clear();
                    skirmishPreparedSkills.Clear();

                    logger.WriteLine("");
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms BEGIN CHARACTER INITIALIZATION");
                    // initialize characters
                    foreach(var character in globalCharacters)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SETTING [" + character.Character_Name + "] Max_Health to " + character.Health);
                        character.Max_Health = character.Health;
                        character.Conditions = new Conditions();
                        character.Conditions.Shield_Enchanters_Character_PK = new List<int>();
                        character.Conditions.DamageBonus_Enchanters_Character_PK = new List<int>();
                        character.Conditions.Guarded_Characters_PK = new List<int>();

                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Creating character track log for character ...");
                        globalCharacterTrackLog.Add(new Character_Track_Log(){ Character_FK = character.Character_PK });
                    }
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms END CHARACTER INITIALIZATION");
                    logger.WriteLine("");
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms BEGIN SKILL INITIALIZATION");
                    // initialize passive skills
                    foreach (var skill in globalSkills)
                    {
                        if (skill.bIsPassive)
                        {
                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms PREPARING [" + skill.Skill_Name + "](pk=" + skill.Skill_PK + ") | Preparer: [" + GetCharacter(skill.Character_FK).Character_Name + "] | Exec_Track_Step: " + skill.Exec_Track_Step);
                            skirmishPreparedSkills.Add(new Prepared_Skills()
                            {
                                Skill_PK = skill.Skill_PK,
                                Preparer_Character_FK = skill.Character_FK,
                                Exec_Track_Step = skill.Exec_Track_Step
                            });
                        }
                    }
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms END SKILL INITIALIZATION");
                    #endregion

                    // perform skills following initiatve track (should already be sorted from SQL)
                    logger.WriteLine("");
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms BEGIN SKIRMISH(pk=" + skirmish.Skirmish_PK + ")");
                    foreach (var currAct in globalInitTrack)
                    {
                        _GAMESTATE.Current_Act_Order = currAct.Act_Order;

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
                         *      8 - determine if skill instantly resolves
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
                        var lastTrackStep = 17;

                        #region TURN TRACK
                        // cycle through turn track
                        var currChar = GetCharacter(currAct.Character_FK);
                        for (var currTrackStep = 1; currTrackStep <= lastTrackStep; currTrackStep++)
                        {
                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms BEGIN TRACK STEP [" + currTrackStep + "] for [" + currChar.Character_Name + "]");
                            _GAMESTATE.Current_Track_Step = currTrackStep;

                            switch (currTrackStep)
                            {
                                #region BEGIN TURN
                                case 1:
                                    // 1 - set active character to this character
                                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SETTING [" + currChar.Character_Name + "](pk=" + currChar.Character_PK + ") as active character");
                                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM active character:" + Json.Serialize(currChar));
                                    _GAMESTATE.Active_Character = currChar;
                                    break;
                                case 2:
                                    // 2 - is character stunned?
                                    if (currChar.Conditions.bStunned)
                                    {
                                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Character is stunned, skip to end turn step");
                                        currTrackStep = lastTrackStep;
                                    }
                                    break;
                                case 3:
                                    // 3 - special character skills
                                    CheckSpecialSkills();
                                    break;
                                #endregion
                                #region DETERMINE SKILL
                                case 4:
                                    // 4 - find favored skill
                                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Finding favored skill for character to perform ...");
                                    //FavoredSkill = GetSkill(globalVotes.OrderByDescending(x => x.Vote_Count).FirstOrDefault(x => x.Character_FK == currChar.Character_PK).Skill_FK);
                                    FavoredSkill = GetFavoredSkill(currChar.Character_PK);
                                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Found favored skill. Skill_Name: [" + FavoredSkill.Skill_Name + "](pk=" + FavoredSkill.Skill_PK + ") | Skill:" + Json.Serialize(FavoredSkill));
                                    _GAMESTATE.Pending_Skill = FavoredSkill;
                                    break;
                                case 5:
                                    // 5 - find favored targets for skill
                                    // targets are separated by commas
                                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Finding favored targets for skill ...");
                                    if (!globalVotes.Any(x => x.Skill_FK == FavoredSkill.Skill_PK && x.Character_FK == currChar.Character_PK))
                                    {
                                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM No targets for this skill, find random target");

                                        if (FavoredSkill.Skill_Type.Contains("Attack") ||
                                            FavoredSkill.Skill_Type.Contains("Affliction") ||
                                            FavoredSkill.Skill_Type.Contains("Taunt"))
                                        {
                                            // skill type is hostile, find random enemy targets
                                            for (var i = 1; i < FavoredSkill.Max_Targets; i++)
                                            {
                                                FavoredSkillFavoredTargets.Add(globalCharacters.FirstOrDefault(x => x.Guild_FK != currChar.Guild_FK && !FavoredSkillFavoredTargets.Contains(x)));
                                            }
                                        }
                                        else
                                        {
                                            // skill type is friendly, find random friendly targets
                                            if (FavoredSkill.Skill_Type == "Blessing,Advantage" ||
                                                FavoredSkill.Skill_Type == "Blessing,Disadvantage" ||
                                                FavoredSkill.Skill_Type == "Blessing,Damage" ||
                                                FavoredSkill.Skill_Type.Contains("Guard"))
                                            {
                                                // skill cannot target self
                                                FavoredSkillFavoredTargets.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK && x.Character_PK != currChar.Character_PK && !FavoredSkillFavoredTargets.Contains(x));
                                            }
                                            else if (FavoredSkill.Skill_Type == "Blessing,AllStats" ||
                                                      FavoredSkill.Skill_Type == "Blessing,Dodge" ||
                                                      FavoredSkill.Skill_Type == "Blessing,Finesse" ||
                                                      FavoredSkill.Skill_Type == "Blessing,Agility" ||
                                                      FavoredSkill.Skill_Type == "Blessing,Senses" ||
                                                      FavoredSkill.Skill_Type == "Blessing,Mana" ||
                                                      FavoredSkill.Skill_Type == "Blessing,Shield" ||
                                                      FavoredSkill.Skill_Type == "Heal")
                                            {
                                                // skill can target self
                                                FavoredSkillFavoredTargets.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK && !FavoredSkillFavoredTargets.Contains(x));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var tmpTargets = Array.ConvertAll(globalVotes.FirstOrDefault(x =>
                                            x.Skill_FK == FavoredSkill.Skill_PK &&
                                            x.Character_FK == currChar.Character_PK).Targets.Split(','), int.Parse);
                                        FavoredSkillFavoredTargets.AddRange(
                                            tmpTargets.Select(target => GetCharacter(target)));
                                        
                                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Found favored targets [" + Json.Serialize(FavoredSkillFavoredTargets) + "]");
                                    }
                                    _GAMESTATE.Pending_Targets = FavoredSkillFavoredTargets;
                                    break;
                                #endregion
                                #region PRELIMINARY SKILL EXECUTION
                                case 6:
                                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Determine target legibility");
                                    // 6 - target legibility (Invisiblity, Knocked Out, Charmed, ect)

                                    // no targets acquired during voting, determine random targets
                                    if (!FavoredSkillFavoredTargets.Any())
                                    {
                                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM no targets were acquired in Voting, determine random targets ...");

                                        for (var i = 0; i < FavoredSkill.Max_Targets; i++)
                                        {
                                            Character newTarget = new Character();
                                            if (FavoredSkill.Skill_Type == "Attack" ||
                                                FavoredSkill.Skill_Type == "Taunt" ||
                                                FavoredSkill.Skill_Type.Contains("Affliction"))
                                            {
                                                // assign target to random enemy
                                                newTarget = globalCharacters.FirstOrDefault(x => x.Guild_FK != currChar.Guild_FK && 
                                                                                                !x.Conditions.bKnockedOut && 
                                                                                                !x.Conditions.bInvisible &&
                                                                                                !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK));
                                            }

                                            if (FavoredSkill.Skill_Type == "Heal")
                                            {
                                                // assign target to random friendly character (can include self)
                                                newTarget = globalCharacters.FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK &&
                                                                                                !x.Conditions.bKnockedOut &&
                                                                                                !x.Conditions.bInvisible &&
                                                                                                !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK));
                                            }

                                            if (FavoredSkill.Skill_Type.Contains("Blessing") ||
                                                FavoredSkill.Skill_Type.Contains("Guard"))
                                            {
                                                // assign target to random ally
                                                newTarget = globalCharacters.FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK &&
                                                                                                x.Character_PK != currChar.Character_PK &&
                                                                                                !x.Conditions.bKnockedOut &&
                                                                                                !x.Conditions.bInvisible &&
                                                                                                !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK));
                                            }

                                            if(newTarget != null) FavoredSkillFavoredTargets.Add(newTarget);
                                        }

                                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM new targets: " + Json.Serialize(FavoredSkillFavoredTargets));
                                    }

                                    foreach (var target in FavoredSkillFavoredTargets.ToList())
                                    {
                                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM target=[" + target.Character_Name + "] |" +
                                                                        " bInvisible:" + target.Conditions.bInvisible + " | bKnockedOut:" + target.Conditions.bKnockedOut +
                                                                        " | bCharmed:" + target.Conditions.bCharmed + " | bTaunted:" + target.Conditions.bTaunted +
                                                                        " | bBlinded:" + target.Conditions.bBlinded + " | bGuarded:" + target.Conditions.bGuarded);

                                        // check if character has skills to bypass normal targetting rules
                                        CheckSpecialSkills();

                                        // target is either Invisible or Knocked Out, reassign to random enemy
                                        if (target.Conditions.bInvisible || target.Conditions.bKnockedOut)
                                        {
                                            // remove old target from target list
                                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM target is invisible or knocked out, remove target from favored target list | Skill_Type:" + FavoredSkill.Skill_Type);
                                            FavoredSkillFavoredTargets.Remove(target);

                                            // ignore target reassignment if skill is an AoE attack that targets the entire team
                                            if (FavoredSkill.Max_Targets < 12)
                                            {
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM assign a new target | Skill_Type:" + FavoredSkill.Skill_Type);
                                                Character newTarget = new Character();
                                                switch (FavoredSkill.Skill_Type)
                                                {
                                                    case "Attack":
                                                    case "Taunt":
                                                    case "Affliction,Stunned":
                                                    case "Affliction,Blinded":
                                                    case "Affliction,Disadvantage":
                                                    case "Affliction,Advantage":
                                                    case "Affliction,StatDebuff":
                                                        // find new target not on this character's team
                                                        newTarget =
                                                            globalCharacters.OrderBy(x => Guid.NewGuid())
                                                                .FirstOrDefault(
                                                                    x =>
                                                                        x.Guild_FK != currChar.Guild_FK &&
                                                                        !FavoredSkillFavoredTargets.Exists(
                                                                            y => y.Character_PK == x.Character_PK) &&
                                                                        !x.Conditions.bInvisible &&
                                                                        !x.Conditions.bKnockedOut);
                                                        logger.WriteLine(DateTime.Today + " " +
                                                                         stopwatch.ElapsedMilliseconds +
                                                                         "ms SYSTEM New target found | {" +
                                                                         Json.Serialize(newTarget) + "}");
                                                        break;
                                                    case "Heal":
                                                        // find new target that is on this character's team that has less than full health
                                                        newTarget =
                                                            globalCharacters.OrderBy(x => Guid.NewGuid())
                                                                .FirstOrDefault(
                                                                    x =>
                                                                        x.Guild_FK == currChar.Guild_FK &&
                                                                        x.Health < x.Max_Health &&
                                                                        !FavoredSkillFavoredTargets.Exists(
                                                                            y => y.Character_PK == x.Character_PK) &&
                                                                        !x.Conditions.bInvisible &&
                                                                        !x.Conditions.bKnockedOut);
                                                        logger.WriteLine(DateTime.Today + " " +
                                                                         stopwatch.ElapsedMilliseconds +
                                                                         "ms SYSTEM New target found | {" +
                                                                         Json.Serialize(newTarget) + "}");
                                                        break;
                                                    case "Blessing,Disadvantage":
                                                    case "Blessing,Advantage":
                                                    case "Blessing,Damage":
                                                        // find new target on this character's team
                                                        newTarget =
                                                            globalCharacters.OrderBy(x => Guid.NewGuid())
                                                                .FirstOrDefault(
                                                                    x =>
                                                                        x.Guild_FK == currChar.Guild_FK &&
                                                                        !FavoredSkillFavoredTargets.Exists(
                                                                            y => y.Character_PK == x.Character_PK) &&
                                                                        !x.Conditions.bInvisible &&
                                                                        !x.Conditions.bKnockedOut);
                                                        logger.WriteLine(DateTime.Today + " " +
                                                                         stopwatch.ElapsedMilliseconds +
                                                                         "ms SYSTEM New target found | {" +
                                                                         Json.Serialize(newTarget) + "}");
                                                        break;
                                                    case "Blessing,StatBuff":
                                                    case "Blessing,Shield":
                                                        // find new target on this character's team that is NOT this character
                                                        newTarget =
                                                            globalCharacters.OrderBy(x => Guid.NewGuid())
                                                                .FirstOrDefault(
                                                                    x =>
                                                                        x.Guild_FK == currChar.Guild_FK &&
                                                                        !FavoredSkillFavoredTargets.Exists(
                                                                            y => y.Character_PK == x.Character_PK) &&
                                                                        !x.Conditions.bInvisible &&
                                                                        !x.Conditions.bKnockedOut &&
                                                                        x.Character_PK != currChar.Character_PK);
                                                        logger.WriteLine(DateTime.Today + " " +
                                                                         stopwatch.ElapsedMilliseconds +
                                                                         "ms SYSTEM New target found | {" +
                                                                         Json.Serialize(newTarget) + "}");
                                                        break;
                                                }

                                                if (FavoredSkill.Skill_Type.Contains("Guard"))
                                                {
                                                    newTarget =
                                                        globalCharacters.OrderBy(x => Guid.NewGuid())
                                                            .FirstOrDefault(
                                                                x =>
                                                                    x.Guild_FK == currChar.Guild_FK &&
                                                                    !FavoredSkillFavoredTargets.Exists(
                                                                        y => y.Character_PK == x.Character_PK) &&
                                                                    !x.Conditions.bInvisible &&
                                                                    !x.Conditions.bKnockedOut &&
                                                                    x.Character_PK != currChar.Character_PK);
                                                    logger.WriteLine(DateTime.Today + " " +
                                                                     stopwatch.ElapsedMilliseconds +
                                                                     "ms SYSTEM New target found | {" +
                                                                     Json.Serialize(newTarget) + "}");
                                                }

                                                // ensure a target was found, then add it
                                                if (newTarget != null)
                                                {
                                                    if (newTarget.Character_PK != 0)
                                                    {
                                                        logger.WriteLine(DateTime.Today + " " +
                                                                         stopwatch.ElapsedMilliseconds +
                                                                         "ms SYSTEM adding new target to favored targets | " +
                                                                         Json.Serialize(newTarget));
                                                        FavoredSkillFavoredTargets.Add(newTarget);
                                                    }
                                                }
                                            }
                                        }

                                        // if character is Charmed
                                        if (currChar.Conditions.bCharmed)
                                        {
                                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM target is charmed, reassign target to random ally");

                                            // remove old target from target list
                                            FavoredSkillFavoredTargets.Remove(target);
                                            Character newTarget = new Character();

                                            // assign new target to random ally
                                            newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK && currChar.Conditions.Charm_Character_PK != x.Character_PK && !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));

                                            // ensure a target was found, then add it
                                            if (newTarget != null)
                                            {
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM target acquired, add to favored targets | newTarget:" + Json.Serialize(newTarget));
                                                FavoredSkillFavoredTargets.Add(newTarget);
                                            }
                                        }

                                        // if character is Taunted - ignore Blessing, Heal, and Guard skill types when Taunted
                                        if (currChar.Conditions.bTaunted && 
                                            FavoredSkill.Max_Targets < 12 &&
                                            !FavoredSkill.Skill_Type.Contains("Blessing") && 
                                            !FavoredSkill.Skill_Type.Contains("Heal") &&
                                            !FavoredSkill.Skill_Type.Contains("Guard"))
                                        {
                                            // ensure taunter is still a legal target - otherwise maintain favored targets
                                            Boolean bTaunterTargettable = globalCharacters.Contains(globalCharacters.FirstOrDefault(x =>
                                                            x.Character_PK == currChar.Conditions.Taunted_Character_PK &&
                                                            !x.Conditions.bInvisible &&
                                                            !x.Conditions.bKnockedOut));

                                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM character is taunted, reassign target to taunter if able | TaunterCharPK:" + target.Conditions.Taunted_Character_PK + " | bTaunterTargettable:" + bTaunterTargettable);

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
                                                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM taunter is targettable, add to favored targets | newTarget:{" + Json.Serialize(newTarget) + "}");
                                                    FavoredSkillFavoredTargets.Add(newTarget);
                                                }
                                            }
                                        }

                                        // if character is Blinded
                                        if (currChar.Conditions.bBlinded)
                                        {
                                            Character newTarget = new Character();
                                            if (FavoredSkill.Skill_Type.Contains("Guard"))
                                            {
                                                // blinded character is attempting to guard, must reassign to random ally
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM character is blinded and attempting to guard, reassign target to random ally");

                                                // remove old target from target list
                                                FavoredSkillFavoredTargets.Remove(target);

                                                // assign new target to random character (even ally)
                                                newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK && !x.Conditions.bInvisible && !x.Conditions.bKnockedOut && x.Character_PK != currChar.Character_PK);                                            
                                            }
                                            else
                                            {
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM character is blinded, reassign target to random character");

                                                // remove old target from target list
                                                FavoredSkillFavoredTargets.Remove(target);

                                                // assign new target to random character (even ally)
                                                newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => !x.Conditions.bInvisible && !x.Conditions.bKnockedOut && x.Character_PK != currChar.Character_PK);                                            
                                            }
                                            // ensure a target was found, then add it
                                            if (newTarget != null)
                                            {
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM target acquired, add to favored targets | newTarget:{" + Json.Serialize(newTarget) + "}");
                                                FavoredSkillFavoredTargets.Add(newTarget);
                                            }
                                            else
                                            {
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM no new target could be found");
                                            }
                                        }

                                        // if target is Guarded - ignore Blessing, Heal, and Guard skill types when Guarded
                                        if (target.Conditions.bGuarded &&
                                            !FavoredSkill.Skill_Type.Contains("Blessing") &&
                                            !FavoredSkill.Skill_Type.Contains("Heal") &&
                                            !FavoredSkill.Skill_Type.Contains("Guard"))
                                        {
                                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM target is guarded, reassign target to guard character");

                                            // remove old target from target list
                                            FavoredSkillFavoredTargets.Remove(target);
                                            Character newTarget = new Character();

                                            // assign new target to guard
                                            newTarget = globalCharacters.FirstOrDefault(x => x.Character_PK == target.Conditions.Guarded_Characters_PK.OrderByDescending(y => y).FirstOrDefault());

                                            // ensure a target was found, then add it
                                            if (newTarget != null)
                                            {
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM target acquired, add to favored targets | newTarget:{" + Json.Serialize(newTarget) + "}");
                                                FavoredSkillFavoredTargets.Add(newTarget);
                                            }
                                        }
                                    }

                                    // ensure at least one target exists after validation, unless skill is a prepared skill
                                    if (FavoredSkillFavoredTargets.Count == 0)
                                    {
                                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM no valid targets available - end the turn");
                                        currTrackStep = lastTrackStep;
                                    }
                                    break;
                                case 7:
                                    // 7 - special character skills
                                    CheckSpecialSkills();
                                    break;
                                #endregion
                                #region PERFORM ATTACK ROLL
                                case 8:
                                    // 8 - determine if skill instantly resolves

                                    // skip this step if skill is hostile and won't instantly resolve
                                    if (!FavoredSkill.Skill_Type.Contains("Blessing") &&
                                        !FavoredSkill.Skill_Type.Contains("Guard"))
                                        continue;

                                    var bEndTheTurn = false;
                                    
                                    foreach (var target in FavoredSkillFavoredTargets)
                                    {
                                        Combat_Log newCombatLogEntry = new Combat_Log();
                                        newCombatLogEntry.Action_Order = currAct.Act_Order;
                                        //newCombatLogEntry.Conditions
                                        newCombatLogEntry.Assailant_Character_FK = currChar.Character_PK;
                                        newCombatLogEntry.Skill_FK = FavoredSkill.Skill_PK;
                                        newCombatLogEntry.Target_Character_FK = target.Character_PK;
                                        newCombatLogEntry.Skirmish_FK = skirmish.Skirmish_PK;
                                        newCombatLogEntry.tmpDamage_Final_Result = new List<int>();
                                        newCombatLogEntry.Skirmish_FK = skirmish.Skirmish_PK;

                                        switch (FavoredSkill.Skill_Type)
                                        {
                                            case "Blessing,Advantage":
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM casting Blessing,Advantage on [" + target.Character_Name + "]");
                                                target.Conditions.bAttackAdvantage = true;

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Disadvantage":
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM casting Blessing,Disadvantage on [" + target.Character_Name + "]");
                                                target.Conditions.bDefendAdvantage = true;

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Shield":
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM casting Blessing,Shield(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Conditions.bShielded = true;
                                                target.Conditions.Shield += Int32.Parse(FavoredSkill.Damage_Roll);
                                                target.Conditions.Shield_Enchanters_Character_PK.Add(currChar.Character_PK);

                                                newCombatLogEntry.Damage_Final_Result = Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Bestow", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Damage":
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM casting Blessing,Damage(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Conditions.bDamageBonus = true;
                                                target.Conditions.DamageBonus += Int32.Parse(FavoredSkill.Damage_Roll);
                                                target.Conditions.DamageBonus_Enchanters_Character_PK.Add(currChar.Character_PK);

                                                newCombatLogEntry.Damage_Final_Result = Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Bestow", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,AllStats":
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM casting Blessing,AllStats(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Finesse += Int32.Parse(FavoredSkill.Damage_Roll);
                                                target.Agility += Int32.Parse(FavoredSkill.Damage_Roll);
                                                target.Senses += Int32.Parse(FavoredSkill.Damage_Roll);
                                                target.Mana += Int32.Parse(FavoredSkill.Damage_Roll);
                                                target.Dodge += Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Finesse":
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM casting Blessing,Finesse(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Finesse += Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Agility":
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM casting Blessing,Agility(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Agility += Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Senses":
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM casting Blessing,Senses(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Senses += Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Mana":
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM casting Blessing,Mana(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Mana += Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Dodge":
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM casting Blessing,Dodge(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Dodge += Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                        }

                                        // dynamic skill types
                                        if (FavoredSkill.Skill_Type.Contains("Guard"))
                                        {
                                            // determine how many guard this character can perform
                                            var amtOfGuard = Int32.Parse(FavoredSkill.Skill_Type.Split(',')[1]);

                                            for (var i = 1; i <= amtOfGuard; i++)
                                            {
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM guarding [" + target.Character_Name + "]");
                                                target.Conditions.bGuarded = true;
                                                target.Conditions.Guarded_Characters_PK.Add(currChar.Character_PK);
                                            }
                                            bEndTheTurn = true;
                                        }

                                        // record entry
                                        globalCombatLog.Add(newCombatLogEntry);
                                    }

                                    // end the turn
                                    if (bEndTheTurn) currTrackStep = lastTrackStep;
                                    break;
                                case 9:
                                    // 9 - determine if attack is rolled with advantage or disadvantage
                                    // REMOVE THIS TRACK STEP
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
                                        newCombatLogEntry.Assailant_Character_FK = currChar.Character_PK;
                                        newCombatLogEntry.Skill_FK = FavoredSkill.Skill_PK;
                                        newCombatLogEntry.Target_Character_FK = target.Character_PK;
                                        newCombatLogEntry.Skirmish_FK = skirmish.Skirmish_PK;
                                        newCombatLogEntry.tmpDamage_Final_Result = new List<int>();

                                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM preliminary attack calculation | (bAttackAdvantage:" + currChar.Conditions.bAttackAdvantage + " | bAttackDisadvantage:" + currChar.Conditions.bAttackDisadvantage + ") | TARGET (bAttackAdvantage:" + target.Conditions.bAttackAdvantage + " | bAttackDisadvantage:" + target.Conditions.bAttackDisadvantage + ")");
                                        if (currChar.Conditions.bAttackAdvantage || currChar.Conditions.bAttackDisadvantage)
                                        {
                                            var finalAdvDis = 0; // 0 = roll normally. -1 = roll disadvantage. 1 = roll advantage

                                            if (currChar.Conditions.bAttackAdvantage) finalAdvDis++;
                                            if (currChar.Conditions.bAttackDisadvantage) finalAdvDis--;
                                            if (target.Conditions.bDefendAdvantage) finalAdvDis++;
                                            if (target.Conditions.bDefendDisadvantage) finalAdvDis--;

                                            // determine final result (coded this way because character could have both advantage & disadvantage)
                                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM final preliminary attack calculation | finalAdvDis:" + finalAdvDis);

                                            if (finalAdvDis == 0)
                                            {
                                                currChar.Conditions.bAttackAdvantage = false;
                                                currChar.Conditions.bAttackDisadvantage = false;
                                            }
                                            else if (finalAdvDis > 0)
                                            {
                                                currChar.Conditions.bAttackAdvantage = true;
                                                currChar.Conditions.bAttackDisadvantage = false;
                                            }
                                            else if (finalAdvDis < 0)
                                            {
                                                currChar.Conditions.bAttackAdvantage = false;
                                                currChar.Conditions.bAttackDisadvantage = true;
                                            }
                                        }

                                        // don't roll if the attack is auto successful or the skill is a heal
                                        if (!FavoredSkill.bAutoSuccess)
                                        {
                                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM rolling attack against [" + target.Character_Name + "] ...");

                                            // perform roll with a d20
                                            Int32 rollDiceRoll = 0;

                                            // reroll if character has advantage or disadvantage
                                            if (currChar.Conditions.bAttackAdvantage)
                                            {
                                                // perform roll with two d20's, taking the higher roll
                                                Int32 rollDiceReroll = rand.Next(1, 21);

                                                // record roll data
                                                newCombatLogEntry.Attack_Values = rollDiceRoll + "," + rollDiceReroll;

                                                if (rollDiceReroll > rollDiceRoll) rollDiceRoll = rollDiceReroll;
                                            }
                                            else if (currChar.Conditions.bAttackDisadvantage)
                                            {
                                                // perform roll with two d20's, taking the lower roll
                                                Int32 rollDiceReroll = rand.Next(1, 21);

                                                // record roll data
                                                newCombatLogEntry.Attack_Values = rollDiceRoll + "," + rollDiceReroll;

                                                if (rollDiceReroll < rollDiceRoll) rollDiceRoll = rollDiceReroll;
                                            }
                                            else
                                            {
                                                // perform roll with a d20
                                                rollDiceRoll = rand.Next(1, 21);

                                                // record roll data
                                                newCombatLogEntry.Attack_Values = rollDiceRoll.ToString();
                                            }

                                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM roll(s) achieved | Attack_Values:" +
                                                             newCombatLogEntry.Attack_Values);

                                            // record accolades
                                            if (rollDiceRoll == 1)
                                            {
                                                // critical failure achieved
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Critical_Fails", 1);
                                            }
                                            else if (rollDiceRoll == 20)
                                            {
                                                // critical success achieved
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Critical_Successes", 1);
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
                                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM final attack result with modifier[" +
                                                             FavoredSkill.Attribute_FK + "] | Attack_Final_Result:" +
                                                             rollDiceRoll);
                                        }

                                        // record new combat log
                                        globalCombatLog.Add(newCombatLogEntry);

                                        // check for special character skills after rolling attack
                                        CheckSpecialSkills();
                                    }
                                    break;
                                #endregion
                                #region PERFORM DAMAGE ROLL
                                case 11:
                                    // 11 - determine if attacks are successful and determine damage

                                    // get combat logs regarding this character performed favored skill - it is possible this attack targets multiple targets
                                    var relativeAttackCombatLogs = globalCombatLog.Where(x => x.Action_Order == globalInitTrack.FirstOrDefault(y => y.Character_FK == currChar.Character_PK).Act_Order && !x.bInterrupt);

                                    foreach (var log in relativeAttackCombatLogs)
                                    {
                                        Character targetChar = GetCharacter(log.Target_Character_FK);

                                        // determine if attack is successful
                                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM calculating if attack was successful ... | Attack_Final_Result:" + log.Attack_Final_Result + " | Target's Dodge:" + targetChar.Dodge + " | bAutoSuccess:" + FavoredSkill.bAutoSuccess);
                                        log.bAttackSuccessful = (log.Attack_Final_Result >= targetChar.Dodge || FavoredSkill.bAutoSuccess);
                                        if (log.bAttackSuccessful)
                                        {
                                            // attack is successful - roll damage
                                            List<string> rollArray = FavoredSkill.Damage_Roll.Split(',').ToList();
                                            List<int> damageRolls = new List<int>(); // stores all damage rolls

                                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds +
                                                             "ms SYSTEM attack successful, rolling damage ...");
                                            foreach (var roll in rollArray)
                                            {
                                                if (roll == "0d0+0")
                                                {
                                                    // don't perform a real roll on 0d0+0
                                                    log.tmpDamage_Final_Result.Add(0);
                                                    log.Damage_Types = FavoredSkill.Damage_Types;
                                                    continue;
                                                }
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds +
                                                                 "ms SYSTEM rolling [" + roll + "]");
                                                string rollSet = roll.Substring(0, roll.IndexOf("+"));
                                                    // extract "XdX" from "XdX+X"
                                                Int32 rollDiceAmt =
                                                    Int32.Parse(rollSet.Substring(0, rollSet.IndexOf("d")));
                                                Int32 rollDiceType =
                                                    Int32.Parse(rollSet.Substring(rollSet.IndexOf("d") + 1));
                                                Int32 rollModifier = Int32.Parse(roll.Substring(roll.IndexOf("+") + 1));
                                                    // extract "+X" from "XdX+X"
                                                Int32 rollFinalResult = 0;

                                                // roll dice for each amount required
                                                for (var x = 1; x <= rollDiceAmt; x++)
                                                {
                                                    Int32 rollResult = rand.Next(1, rollDiceType + 1);

                                                    // record damage roll
                                                    damageRolls.Add(rollResult);

                                                    // accumulate results
                                                    rollFinalResult += rollResult;
                                                }

                                                // add modifiers
                                                switch (FavoredSkill.Attribute_FK)
                                                {
                                                    case "Finesse":
                                                        rollFinalResult += currChar.Finesse;
                                                        break;
                                                    case "Agility":
                                                        rollFinalResult += currChar.Agility;
                                                        break;
                                                    case "Senses":
                                                        rollFinalResult += currChar.Senses;
                                                        break;
                                                    case "Mana":
                                                        rollFinalResult += currChar.Mana;
                                                        break;
                                                }
                                                rollFinalResult += rollModifier;

                                                log.tmpDamage_Final_Result.Add(rollFinalResult);
                                                log.Damage_Types = FavoredSkill.Damage_Types;

                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds +
                                                                 "ms SYSTEM final damage calculation | Damage_Final_Result:" +
                                                                 rollFinalResult + " | Damage_Types:" +
                                                                 FavoredSkill.Damage_Types);
                                            }

                                            // THIS IS PERFORMED IN STEP 13
                                            // check if character has pending bonus damage
                                            //if (currChar.Conditions.bDamageBonus)
                                            //{
                                            //    log.Damage_Final_Result += currChar.Conditions.DamageBonus;
                                            //    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM bonus damage awarded | DamageBonus:" + currChar.Conditions.DamageBonus);
                                            //    foreach (var enchanter in currChar.Conditions.DamageBonus_Enchanters_Character_PK)
                                            //    {
                                            //        // award each enchanter bonus accolades on how much bonus damage current character was granted
                                            //        var enchantSkill = globalCombatLog.FirstOrDefault(x => x.Target_Character_FK == currChar.Character_PK && x.Assailant_Character_FK == enchanter).Skill_FK;

                                            //        UpdateCharacterTrackLog(enchanter, "Blessing_Bonus_Damage", Int32.Parse(globalSkills.FirstOrDefault(x => x.Skill_PK == enchantSkill).Damage_Roll));
                                            //    }

                                            //    // clear out damage bonus
                                            //    currChar.Conditions.bDamageBonus
                                            //}
                                        }
                                        else
                                        {
                                            // target dodged attack
                                            UpdateCharacterTrackLog(targetChar.Character_PK, "Attacks_Dodged", 1);
                                        }
                                    }
                                    break;
                                case 12:
                                    // 12 - special character skills (pre-damage)
                                    CheckSpecialSkills();
                                    break;
                                case 13:
                                    // 13 - inflict damage on target

                                    // get combat logs regarding this character performed favored skill - it is possible this attack targets multiple targets
                                    var relativeDamageCombatLogs = globalCombatLog.Where(x => x.Action_Order == currAct.Act_Order && x.bAttackSuccessful);

                                    foreach (var log in relativeDamageCombatLogs)
                                    {
                                        List<int> tmpDamageResults = log.tmpDamage_Final_Result;
                                        List<int> tmpDamageValues = new List<int>();
                                        List<string> tmpDamageTypes = log.Damage_Types.Split(',').ToList();
                                        Character target = GetCharacter(log.Target_Character_FK);
                                        Character assailant = GetCharacter(log.Assailant_Character_FK);
                                        Int32 overallDamageResult = 0;

                                        foreach (var dmgRoll in tmpDamageResults)
                                        {
                                            var finalDamageResult = dmgRoll;

                                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM inflict damage on target | finalDamageResult:" + dmgRoll + " | Vulnerabilities:[" + target.Vulnerabilities + "] | Resistances:[" + target.Resistances + "] | Immunities:[" + target.Immunities + "] | " + Json.Serialize(target));

                                            if (target.Vulnerabilities != null)
                                            {
                                                // consider target vulnerabilities
                                                List<string> vulnerabilities = target.Vulnerabilities.Split(',').ToList();
                                                var bVulnerableToAttack = vulnerabilities.Exists(x => x == tmpDamageTypes[tmpDamageResults.IndexOf(dmgRoll)]);

                                                // target is vulnerable to damage - deal double damage
                                                if (bVulnerableToAttack) finalDamageResult += dmgRoll;
                                            }

                                            if (target.Resistances != null)
                                            {
                                                // consider target resistances
                                                List<string> resistances = target.Resistances.Split(',').ToList();
                                                var bResistantToAttack = resistances.Exists(x => x == tmpDamageTypes[tmpDamageResults.IndexOf(dmgRoll)]);

                                                // target is resistance to damage - deal half damage, rounded up
                                                if (bResistantToAttack) finalDamageResult -= (int)Math.Ceiling((double)dmgRoll / 2);
                                            }

                                            if (target.Immunities != null)
                                            {
                                                // consider target immunities
                                                List<string> immunities = target.Immunities.Split(',').ToList();
                                                var bImmuneToAttack = immunities.Exists(x => x == tmpDamageTypes[tmpDamageResults.IndexOf(dmgRoll)]);

                                                // target is immune to damage - negate all damage
                                                if (bImmuneToAttack) finalDamageResult = 0;
                                            }

                                            // inflict damage on target
                                            if (FavoredSkill.Skill_Type != "Heal")
                                            {
                                                // check for bonus damage
                                                if (assailant.Conditions.bDamageBonus)
                                                {
                                                    foreach (var enchanter in assailant.Conditions.DamageBonus_Enchanters_Character_PK.OrderByDescending(x => x))
                                                    {
                                                        // find relative combat log
                                                        var relativeCombatLog = globalCombatLog.FirstOrDefault(x => x.Target_Character_FK == assailant.Character_PK && x.Assailant_Character_FK == enchanter);
                                                        // determine how much damage bonus enchanter granted
                                                        Int32 grantedBonusDamage = Int32.Parse(globalSkills.FirstOrDefault(x => x.Skill_PK == relativeCombatLog.Skill_FK).Damage_Roll);

                                                        // buff damage
                                                        finalDamageResult += grantedBonusDamage;

                                                        tmpDamageValues.Add(grantedBonusDamage);
                                                        log.Damage_Types += ",True";

                                                        // record accolades
                                                        UpdateCharacterTrackLog(enchanter, "Blessing_Bonus_Damage", grantedBonusDamage);
                                                    }
                                                    // clear out character bonus damage
                                                    assailant.Conditions.bDamageBonus = false;
                                                    assailant.Conditions.DamageBonus = 0;
                                                    assailant.Conditions.DamageBonus_Enchanters_Character_PK.Clear();
                                                }

                                                // skill type inflicts damage
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + target.Character_Name + "] taking " + finalDamageResult + " " + tmpDamageTypes[tmpDamageResults.IndexOf(dmgRoll)] + " damage");

                                                // check for shield
                                                if (target.Conditions.bShielded)
                                                {
                                                    target.Conditions.Shield -= finalDamageResult;

                                                    if (target.Conditions.Shield < 0)
                                                    {
                                                        target.TakeDamage(target.Conditions.Shield * -1);
                                                        target.Conditions.Shield = 0;
                                                        target.Conditions.bShielded = false;
                                                        target.Conditions.Shield_Enchanters_Character_PK.Clear();
                                                    }

                                                    // record accolades for enchanter who granted shield
                                                    var tmpAttackDmg = finalDamageResult;
                                                    foreach (var enchanter in target.Conditions.Shield_Enchanters_Character_PK.OrderByDescending(x => x))
                                                    {
                                                        // find relative combat log where enchanter shielded target
                                                        var relativeCombatLog = globalCombatLog.FirstOrDefault(x => x.Target_Character_FK == target.Character_PK && x.Assailant_Character_FK == enchanter);

                                                        // determine how much shield the enchanter provided
                                                        Int32 shieldAmtGranted = Int32.Parse(globalSkills.FirstOrDefault(x => x.Skill_PK == relativeCombatLog.Skill_FK).Damage_Roll);

                                                        // accumulate how much damage the target has taken prior to this attack
                                                        int previousDamage = globalCombatLog.Where(x => x.Target_Character_FK == target.Character_PK && x.Action_Order < currAct.Act_Order).Sum(x => x.Damage_Final_Result);

                                                        // perform calculations
                                                        tmpAttackDmg -= (shieldAmtGranted - previousDamage);
                                                        if (tmpAttackDmg > 0)
                                                        {
                                                            if (GetCharacter(enchanter).Archetype.Contains("Enchanter") || GetCharacter(enchanter).Archetype.Contains("Hunter"))
                                                                UpdateCharacterTrackLog(enchanter, "Blessing_Shield_Absorb", shieldAmtGranted);
                                                            // shield did not absorb all damage
                                                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + globalCharacters.FirstOrDefault(x => x.Character_PK == enchanter).Character_Name + "] shielded [" + target.Character_Name + "] for " + shieldAmtGranted + " damage");
                                                            target.Conditions.Shield_Enchanters_Character_PK.Remove(enchanter);
                                                        }
                                                        else
                                                        {
                                                            if (GetCharacter(enchanter).Archetype.Contains("Enchanter") || GetCharacter(enchanter).Archetype.Contains("Hunter"))
                                                                UpdateCharacterTrackLog(enchanter, "Blessing_Shield_Absorb", finalDamageResult);
                                                            // shield absorbed all damage
                                                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + globalCharacters.FirstOrDefault(x => x.Character_PK == enchanter).Character_Name + "] shielded [" + target.Character_Name + "] for " + finalDamageResult + " damage");
                                                            break;
                                                        }
                                                    }

                                                    // reduce total shield
                                                    target.Conditions.Shield -= tmpAttackDmg;
                                                    if (target.Conditions.Shield <= 0)
                                                    {
                                                        // clear out shield data if reduced to 0
                                                        target.Conditions.Shield = 0;
                                                        target.Conditions.bShielded = false;
                                                        target.Conditions.Shield_Enchanters_Character_PK.Clear();
                                                    }

                                                    // take damage if remaining damage after shield calculations
                                                    if (tmpAttackDmg > 0)
                                                    {
                                                        target.TakeDamage(finalDamageResult);
                                                    }
                                                }
                                                else
                                                {
                                                    // take damage
                                                    target.TakeDamage(finalDamageResult);
                                                }
                                            }
                                            else
                                            {
                                                // skill type heals health
                                                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + target.Character_Name + "] healing (" + finalDamageResult + ") health");
                                                target.Heal(finalDamageResult);
                                            }

                                            // accumulate overall damage for combat log
                                            overallDamageResult += finalDamageResult;
                                            tmpDamageValues.Add(finalDamageResult);
                                        }

                                        // record overall damage
                                        log.Damage_Final_Result = overallDamageResult;
                                        log.Damage_Values = tmpDamageValues.ToJson();

                                        // record accolade
                                        if (target.Conditions.bKnockedOut)
                                        {
                                            UpdateCharacterTrackLog(assailant.Character_PK, "Opponent_Knock_Outs", 1);
                                            List<Character> Accolade_Assist_Awarded = new List<Character>();
                                            foreach (var assistant in globalCombatLog.Where(x => x.Target_Character_FK == target.Character_PK && x.Damage_Final_Result > 0 && x.Damage_Types != null && !x.Damage_Types.Contains("Healing") && x.Assailant_Character_FK != assailant.Character_PK))
                                            {
                                                if (!Accolade_Assist_Awarded.Exists(x => x.Character_PK == assistant.Assailant_Character_FK))
                                                {
                                                    UpdateCharacterTrackLog(assistant.Assailant_Character_FK, "Assist_Knock_Outs", 1);
                                                    Accolade_Assist_Awarded.Add(GetCharacter(assistant.Assailant_Character_FK));
                                                }

                                            }
                                        }
                                    }
                                    break;
                                case 14:
                                    // 14 - special character skills (post-damage)
                                    CheckSpecialSkills();
                                    break;
                                #endregion
                                #region TARGET CONDITIONS
                                case 15:
                                    // 15 - determine if target receives any afflictions

                                    // get combat logs regarding this character performed favored skill - it is possible this attack targets multiple targets
                                    var relativeConditionCombatLogs = globalCombatLog.Where(x => x.Action_Order == globalInitTrack.FirstOrDefault(y => y.Character_FK == currChar.Character_PK).Act_Order);

                                    foreach (var log in relativeConditionCombatLogs)
                                    {
                                        // ignore passives that interrupted current action when inflicting conditions
                                        if (log.bInterrupt) continue;

                                        Character targetChar = GetCharacter(log.Target_Character_FK);

                                        // determine conditions if attack was successful
                                        if (log.bAttackSuccessful)
                                        {
                                            bool bSpecialRuleInflictCondition = true;

                                            // skill requires a minimum attack result to inflict condition
                                            if (FavoredSkill.Special_Min_Roll != null)
                                            {
                                                // check if minimum result required was met
                                                // IMPORTANT - always inflict condition if min roll equals 0
                                                if (log.Attack_Final_Result < FavoredSkill.Special_Min_Roll && FavoredSkill.Special_Min_Roll != 0) bSpecialRuleInflictCondition = false;
                                            }

                                            if (bSpecialRuleInflictCondition)
                                            {
                                                // inflict afflictions
                                                if (FavoredSkill.Skill_Type.Contains("Affliction"))
                                                {
                                                    var affliction = FavoredSkill.Skill_Type.Substring(FavoredSkill.Skill_Type.IndexOf(',') + 1);

                                                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM inflict Affliction(" + affliction + ") on target ");

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

                                                    // dynamic afflictions
                                                    if (affliction.Contains("AllStats") || affliction.Contains("Finesse") ||
                                                        affliction.Contains("Agility") || affliction.Contains("Senses") ||
                                                        affliction.Contains("Mana") || affliction.Contains("Dodge"))
                                                    {
                                                        var debuff = affliction.Split('-'); // [0] = type | [1] = amount

                                                        switch (debuff[0])
                                                        {
                                                            case "AllStats":
                                                                targetChar.Finesse -= Int32.Parse(debuff[1]);
                                                                targetChar.Agility -= Int32.Parse(debuff[1]);
                                                                targetChar.Senses -= Int32.Parse(debuff[1]);
                                                                targetChar.Mana -= Int32.Parse(debuff[1]);
                                                                targetChar.Dodge -= Int32.Parse(debuff[1]);
                                                                break;
                                                            case "Finesse":
                                                                targetChar.Finesse -= Int32.Parse(debuff[1]);
                                                                break;
                                                            case "Agility":
                                                                targetChar.Agility -= Int32.Parse(debuff[1]);
                                                                break;
                                                            case "Senses":
                                                                targetChar.Senses -= Int32.Parse(debuff[1]);
                                                                break;
                                                            case "Mana":
                                                                targetChar.Mana -= Int32.Parse(debuff[1]);
                                                                break;
                                                            case "Dodge":
                                                                targetChar.Dodge -= Int32.Parse(debuff[1]);
                                                                break;
                                                        }

                                                        // ensure no stat goes below 0
                                                        if (targetChar.Finesse < 0) targetChar.Finesse = 0;
                                                        if (targetChar.Agility < 0) targetChar.Agility = 0;
                                                        if (targetChar.Senses < 0) targetChar.Senses = 0;
                                                        if (targetChar.Mana < 0) targetChar.Mana = 0;
                                                        if (targetChar.Dodge < 0) targetChar.Dodge = 0;
                                                    }

                                                    // record accolade
                                                    if(currChar.Archetype.Contains("Enchanter") || currChar.Archetype.Contains("Hunter"))
                                                        UpdateCharacterTrackLog(currChar.Character_PK, "Afflictions_Inflicted", 1);
                                                }

                                                // inflict taunt
                                                if (FavoredSkill.Skill_Type == "Taunt")
                                                {
                                                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM inflict Taunt on [" + targetChar.Character_Name + "]");
                                                    targetChar.Conditions.bTaunted = true;
                                                    targetChar.Conditions.Taunted_Character_PK = currChar.Character_PK;
                                                    log.Conditions = 8;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case 16:
                                    //// 16 - check if skill can perform multiple attacks
                                    //if (FavoredSkill.Skill_Type.Contains("MultiAttack"))
                                    //{
                                    //    var relativeCombatLog = globalCombatLog.FirstOrDefault(x => x.Assailant_Character_FK == currChar.Character_PK && x.Skill_FK == FavoredSkill.Skill_PK);

                                    //    // perform another turn if attack was successful or attack result equals or exceeds minimum roll required
                                    //    if(relativeCombatLog.bAttackSuccessful && (relativeCombatLog.Attack_Final_Result > FavoredSkill.Special_Min_Roll || FavoredSkill.Special_Min_Roll == 0))
                                    //        currTrackStep = 1;

                                    //    // EXCEPTION
                                    //    // Cannot perform additional turns if skill type is a single target multi attack and the target has been knocked out
                                    //    if (FavoredSkill.Skill_Type == "MultiAttack,Single" &&
                                    //        globalCharacters.FirstOrDefault(
                                    //            x => x.Character_PK == relativeCombatLog.Target_Character_FK)
                                    //            .Conditions.bKnockedOut)
                                    //        currTrackStep = 16;
                                    //}
                                    break;
                                case 17:
                                    // 17 - special character skills
                                    CheckSpecialSkills();
                                    break;
                                #endregion
                            }

                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms END TRACK STEP [" + currTrackStep + "] for [" + currChar.Character_Name + "]");
                        }
                        #endregion
                    }
                    #region COMBAT LOG MANAGEMENT
                    // push combat log to server
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Push combat log to server ...");
                    controller.CreateCombatLogForSkirmish(globalCombatLog);
                    #endregion
                    #region ACCOLADE MANAGEMENT
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Recording character accolades ...");
                    foreach (var log in globalCombatLog)
                    {
                        Skill performedSkill = globalSkills.FirstOrDefault(x => x.Skill_PK == log.Skill_FK);
                        Character assailantCharacter = globalCharacters.FirstOrDefault(x => x.Character_PK == log.Assailant_Character_FK);
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
                                    UpdateCharacterTrackLog(assailantCharacter.Character_PK, "Damage_Dealt", log.Damage_Final_Result);

                                    if (targetCharacter.Archetype.Contains("Tank") ||
                                        targetCharacter.Archetype.Contains("Bruiser"))
                                        UpdateCharacterTrackLog(targetCharacter.Character_PK, "Damage_Taken",
                                            log.Damage_Final_Result);
                                }
                                break;
                            case "Heal":
                                UpdateCharacterTrackLog(assailantCharacter.Character_PK, "Health_Regained", log.Damage_Final_Result);
                                break;

                        }
                    }

                    logger.WriteLine("");
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms END SKIRMISH");


                    // check for all who survived
                    foreach (var character in globalCharacters)
                    {
                        if (!character.Conditions.bKnockedOut)
                        {
                            UpdateCharacterTrackLog(character.Character_PK, "Skirmishes_Survived", 1);
                        }
                        else
                        {
                            UpdateCharacterTrackLog(character.Character_PK, "Self_Knock_Outs", 1);
                        }
                    }

                    // accolade for character that acted first
                    UpdateCharacterTrackLog(
                        globalInitTrack.OrderBy(x => x.Act_Order).FirstOrDefault().Character_FK,
                        "Initiative_Acted_First", 1);

                    // check for guild win 
                    foreach (var accoladeLog in globalCharacterTrackLog)
                    {
                        var charAccoladeTotal =
                            accoladeLog.Damage_Dealt +
                            accoladeLog.Damage_Taken +
                            accoladeLog.Opponent_Knock_Outs +
                            accoladeLog.Self_Knock_Outs +
                            accoladeLog.Assist_Knock_Outs +
                            accoladeLog.Attacks_Dodged +
                            accoladeLog.Critical_Successes +
                            accoladeLog.Critical_Fails +
                            accoladeLog.Health_Regained +
                            accoladeLog.Skirmishes_Survived +
                            accoladeLog.Afflictions_Inflicted +
                            accoladeLog.Initiative_Acted_First +
                            accoladeLog.Blessing_Bestow +
                            accoladeLog.Blessing_Shield_Absorb +
                            accoladeLog.Blessing_Bonus_Damage +
                            accoladeLog.Blessing_Stat_Buff;


                        if (GetCharacter(accoladeLog.Character_FK).Guild_FK == skirmish.Guild_1_FK)
                        {
                            skirmish.Guild_1_Accolade_Points += charAccoladeTotal;
                        }
                        else if (GetCharacter(accoladeLog.Character_FK).Guild_FK == skirmish.Guild_2_FK)
                        {
                            skirmish.Guild_2_Accolade_Points += charAccoladeTotal;
                        }
                    }

                    // check for victory
                    var victorGuildFK = (skirmish.Guild_1_Accolade_Points > skirmish.Guild_2_Accolade_Points ? skirmish.Guild_1_FK : skirmish.Guild_2_FK);
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Guild Winner: " + victorGuildFK + " | Guild1(pk=" + skirmish.Guild_1_FK + ") : " + skirmish.Guild_1_Accolade_Points + " - Guild2(pk=" + skirmish.Guild_2_FK + "): " + skirmish.Guild_2_Accolade_Points);

                    // update guild win bonus for each character track log
                    foreach (var character in globalCharacters.Where(x => x.Guild_FK == victorGuildFK)) UpdateCharacterTrackLog(character.Character_PK, "Guild_Win_Bonus", 1);

                     logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Push character track log to server ...");
                    // push character track log to server
                    controller.CreateCharacterTrackLogForSkirmish(globalCharacterTrackLog);

                     logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Push accolades to server ...");
                    // update user accolades on server 
                    controller.UpdateUserAccolades(skirmish.Skirmish_PK);
                    #endregion
                    #region CHARACTER MANAGEMENT
                    // update character energy for each character that performed a skill in the skirmish
                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Updating all character energy ...");
                    List<Energy_Consumption> newEnergyValues = globalCombatLog.Select(log => new Energy_Consumption
                    {
                        Character_FK = log.Assailant_Character_FK,
                        Campaign_FK = skirmish.Campaign_FK,
                        Consume_Energy = globalSkills.FirstOrDefault(x => x.Skill_PK == log.Skill_FK).Energy_Cost
                    }).ToList();
                    // UNCOMMENT LATER
                    // logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Push energy costs to server ...");
                    //controller.UpdateCharacterEnergy(newEnergyValues);
                    #endregion
                    #region USER EXPERIENCE MANAGEMENT
                    // record user experience
                    controller.UpdateUserSkirmishExperience(skirmish.Skirmish_PK);
                    #endregion

                    // update skirmish
                    controller.UpdateSkirmish(skirmish.Skirmish_PK, skirmish.Guild_1_Accolade_Points, skirmish.Guild_2_Accolade_Points);

                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM End Skirmish Combat Log:");
                    logger.WriteLine(Json.Serialize(globalCombatLog));

                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM End Skirmish State of all characters:");
                    logger.WriteLine(Json.Serialize(globalCharacters));

                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM End Skirmish accolade for all characters:");
                    logger.WriteLine(Json.Serialize(globalCharacterTrackLog));
                    
                    stopwatch.Stop();
                    logger.Close();
                }

                //Show success
                this.ScheduleHistoryItem.Succeeded = true;
            }
            catch (Exception ex)
            {
                this.ScheduleHistoryItem.Succeeded = false;
                this.ScheduleHistoryItem.AddLogNote(" ERROR: " + ex.Message);
                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms CRITICAL ERROR: " + ex.Message);
                logger.Close();
                this.Errored(ref ex);
                DotNetNuke.Services.Exceptions.Exceptions.LogException(ex);
            }
        }

        public Character GetCharacter(int Character_PK)
        {
            return globalCharacters.FirstOrDefault(x => x.Character_PK == Character_PK);
        }
        public Skill GetFavoredSkill(int Character_PK)
        {
            //FavoredSkill = GetSkill(globalVotes.OrderByDescending(x => x.Vote_Count).FirstOrDefault(x => x.Character_FK == currChar.Character_PK).Skill_FK);
            var relativeVotes = globalVotes.Where(x => x.Character_FK == Character_PK);
            Skill FavoredSkill = new Skill();

            if (!relativeVotes.Any())
            {
                // nobody voted for this character, perform 0 energy skill
                FavoredSkill = GetSkill(globalSkills.FirstOrDefault(x => x.Energy_Cost == 0 && x.Character_FK == Character_PK && !x.bIsPassive).Skill_PK);
            }
            else
            {
                IList<int> relativeSkills = new List<int>();
                foreach (var vote in relativeVotes)
                {

                    if (!relativeSkills.Any(x => x == vote.Skill_FK)) relativeSkills.Add(vote.Skill_FK);
                }

                var favoredSkill = -1;
                var favoredSkillCount = 0;

                foreach (var skill in relativeSkills)
                {
                    var skillCount = globalVotes.Count(x => x.Skill_FK == skill);
                    if (skillCount > favoredSkillCount)
                    {
                        favoredSkill = skill;
                        favoredSkillCount = skillCount;
                    }
                }

                FavoredSkill = GetSkill(favoredSkill);
            }

            return FavoredSkill;
        }
        public Skill GetSkill(int Skill_PK)
        {
            return globalSkills.FirstOrDefault(x => x.Skill_PK == Skill_PK);
        }
        public List<Prepared_Skills> GetPreparedSkillsForTrackStep(int Track_Step)
        {
            return skirmishPreparedSkills.Where(skill => skill.Exec_Track_Step == Track_Step).ToList();
        }
        public void CheckSpecialSkills()
        {
            foreach (var skill in GetPreparedSkillsForTrackStep(_GAMESTATE.Current_Track_Step)) ExecuteSkill(skill);
        }
        public void ExecuteSkill(Prepared_Skills currSkill)
        {
            Character skillOwner = GetCharacter(currSkill.Preparer_Character_FK);

            // ensure skillOwner is not Stunned or KnockedOut
            if (skillOwner.Conditions.bStunned || skillOwner.Conditions.bKnockedOut) return;

            var bSkillExecuted = false;

            // hardcoded operations for special skills
            switch (currSkill.Skill_PK)
            {
               case 17:
                    #region Lucky
                    // When you roll an 18-20 on an attack, deal an additional 1d10 Burning Damage
                    if (_GAMESTATE.Active_Character.Character_PK != skillOwner.Character_PK) return;

                    logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");
                    foreach (var log in globalCombatLog.Where(x => x.Assailant_Character_FK == skillOwner.Character_PK && x.Action_Order == _GAMESTATE.Current_Act_Order).ToList())
                    {
                        // flawed logic? What if character is rolling advantage/disadvantage
                        if ((log.Attack_Values.Contains("15") || 
                            log.Attack_Values.Contains("16") || 
                            log.Attack_Values.Contains("17") || 
                            log.Attack_Values.Contains("18") || 
                            log.Attack_Values.Contains("19") ||
                            log.Attack_Values.Contains("20")) &&
                            log.bAttackSuccessful)
                        {
                            var bonusDamage = rand.Next(1, 21);
                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" +
                                             skillOwner.Character_Name + "] will deal an additional " + bonusDamage + " Burning Damage to [" + GetCharacter(log.Target_Character_FK).Character_Name + "]");
                            log.tmpDamage_Final_Result.Add(bonusDamage);
                            log.Damage_Types += ",Burning";
                        }

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 21:
                    #region Holy Protection
                    // This character takes half damage whenever an enemy would perform an attack against this character that would inflict an Affliction.
                    foreach (var log in globalCombatLog.Where(x =>
                                    x.Target_Character_FK == skillOwner.Character_PK &&
                                    x.Action_Order == _GAMESTATE.Current_Act_Order &&
                                    x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");
                        var relativeSkill = globalSkills.FirstOrDefault(x => x.Skill_PK == log.Skill_FK);

                        if (relativeSkill.Skill_Type.Contains("Affliction"))
                        {
                            for (var dmgRoll = 0; dmgRoll < log.tmpDamage_Final_Result.Count; dmgRoll++)
                            {
                                log.tmpDamage_Final_Result[dmgRoll] = (int)Math.Ceiling((double)log.tmpDamage_Final_Result[dmgRoll] / 2);
                            }
                        }

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 29:
                    #region Agile
                    // If an attack were to deal Physical Damage to this character, increase this character’s Dodge by 1
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        if (GetSkill(log.Skill_FK).Skill_Type == "Passive") continue;

                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        globalCharacters.FirstOrDefault(x => x.Character_PK == currSkill.Preparer_Character_FK).Dodge++;

                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] increasing dodge by 1");
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 37:
                    #region Blessed Blood
                    //  If an enemy deals damage to this character, deal 2d6 Poison Damage to the assailant                    
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // generate combat log
                        var damageDealt = rand.Next(2, 13); // roll 2d6
                        Combat_Log newCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = log.Assailant_Character_FK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = damageDealt,
                            tmpDamage_Final_Result = new List<int>(){ damageDealt },
                            Damage_Values = damageDealt.ToString(),
                            Damage_Types = "Poison",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };
                        
                        globalCombatLog.Add(newCombatLog);
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 56:
                    #region Cloak of the Arcane
                    // This character begins each Skirmish Invisible
                    if (_GAMESTATE.Current_Act_Order == 1 && !skillOwner.Conditions.bInvisible)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] becoming Invisible from [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");
                        skillOwner.Conditions.bInvisible = true;
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 62:
                    #region Radiant Shroud
                        // Whenever an attack action is performed against this character, the assailant is dealt 3d6 Burning Damage
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // generate combat log
                        var damageDealt = rand.Next(3, 19); // roll 3d6
                        Combat_Log newCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = log.Assailant_Character_FK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = damageDealt,
                            tmpDamage_Final_Result = new List<int>(){ damageDealt },
                            Damage_Values = damageDealt.ToString(),
                            Damage_Types = "Burning",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };

                        globalCombatLog.Add(newCombatLog);
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 70:
                    #region Formless
                    // This character receives Shield 5 whenever an attack is performed against them
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        var assailantSkill = GetSkill(log.Skill_FK);
                        if (assailantSkill.Skill_Type.Contains("Heal") ||
                            assailantSkill.Skill_Type.Contains("Guard") ||
                            assailantSkill.Skill_Type.Contains("Blessing")) return;

                        // generate combat log
                        var shieldAmt = 5;
                        skillOwner.Conditions.Shield += shieldAmt;
                        skillOwner.Conditions.Shield_Enchanters_Character_PK.Add(skillOwner.Character_PK);
                        skillOwner.Conditions.bShielded = true;
                        Combat_Log newCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = log.Assailant_Character_FK,
                            Target_Character_FK = skillOwner.Character_PK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = shieldAmt,
                            tmpDamage_Final_Result = new List<int>() { shieldAmt },
                            Damage_Values = shieldAmt.ToString(),
                            Damage_Types = null,
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };

                        globalCombatLog.Add(newCombatLog);
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 74:
                    #region Phylactery Vamp
                    // This character draws from the life force of each enemy and deals 3 Force Damage to each enemy character at the end of the Skirmish

                    if (_GAMESTATE.Current_Act_Order == 24)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        foreach (var enemy in globalCharacters.Where(x => x.Guild_FK != GetCharacter(skillOwner.Character_PK).Guild_FK && !x.Conditions.bKnockedOut).ToList())
                        {
                            Combat_Log newCombatLog = new Combat_Log(){
                                Skirmish_FK = _GAMESTATE.Skirmish_FK,
                                Assailant_Character_FK = skillOwner.Character_PK,
                                Target_Character_FK = enemy.Character_PK,
                                Skill_FK = currSkill.Skill_PK,
                                Action_Order = _GAMESTATE.Current_Act_Order,
                                Attack_Final_Result = 0,
                                Attack_Values = "0",
                                Damage_Final_Result = 3,
                                tmpDamage_Final_Result = new List<int>() { 3 },
                                Damage_Values = "3",
                                Damage_Types = "Force",
                                Conditions = 0,
                                bAttackSuccessful = true,
                                bInterrupt = true
                            };

                            globalCombatLog.Add(newCombatLog);
                        }

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 81:
                    #region Bodily Regeneration
                    // This character heals 3d10 + 10 Health when it begins its turn 
                    if (_GAMESTATE.Active_Character.Character_PK == skillOwner.Character_PK)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        var healthRegainRoll = rand.Next(3, 31) + 10; // roll 3d10+10

                        Combat_Log newCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = skillOwner.Character_PK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = healthRegainRoll,
                            tmpDamage_Final_Result = new List<int>() { healthRegainRoll },
                            Damage_Values = healthRegainRoll.ToString(),
                            Damage_Types = "Healing",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };

                        globalCombatLog.Add(newCombatLog);

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 85:
                    #region 360 Offense
                    // This character is able to fight from all directions. This character is granted Advantage on all attacks.
                    if (_GAMESTATE.Active_Character.Character_PK == skillOwner.Character_PK)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] receiving Advantage on all attacks");
                        skillOwner.Conditions.bAttackAdvantage = true;

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 88:
                    #region Ethereal Purge
                    // Whenever this character begins its turn, deal 5 Force Damage to each enemy character
                    if (_GAMESTATE.Active_Character.Character_PK == skillOwner.Character_PK)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        foreach (var enemy in globalCharacters.Where(x => x.Guild_FK != skillOwner.Guild_FK && !x.Conditions.bKnockedOut).ToList())
                        {
                            Combat_Log newCombatLog = new Combat_Log()
                            {
                                Skirmish_FK = _GAMESTATE.Skirmish_FK,
                                Assailant_Character_FK = skillOwner.Character_PK,
                                Target_Character_FK = enemy.Character_PK,
                                Skill_FK = currSkill.Skill_PK,
                                Action_Order = _GAMESTATE.Current_Act_Order,
                                Attack_Final_Result = 0,
                                Attack_Values = "0",
                                Damage_Final_Result = 5,
                                tmpDamage_Final_Result = new List<int>() { 5 },
                                Damage_Values = "5",
                                Damage_Types = "Force",
                                Conditions = 0,
                                bAttackSuccessful = true,
                                bInterrupt = true
                            };

                            globalCombatLog.Add(newCombatLog);
                        }

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 95:
                    #region Undead Aura
                    // Whenever an attack action is performed against this character, the assailant is dealt 1d10 Poison Damage
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // generate combat log
                        var damageDealt = rand.Next(1, 11); // roll 1d10
                        Combat_Log newCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = log.Assailant_Character_FK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = damageDealt,
                            tmpDamage_Final_Result = new List<int>(){ damageDealt },
                            Damage_Values = damageDealt.ToString(),
                            Damage_Types = "Poison",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };

                        globalCombatLog.Add(newCombatLog);
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 99:
                    #region Nauseous Innards
                    // Whenever an attack action is performed against this character, the assailant is dealt 2d10 Poison Damage
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // generate combat log
                        var damageDealt = rand.Next(2, 21); // roll 2d10
                        Combat_Log newCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = log.Assailant_Character_FK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = damageDealt,
                            tmpDamage_Final_Result = new List<int>(){ damageDealt },
                            Damage_Values = damageDealt.ToString(),
                            Damage_Types = "Poison",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };

                        globalCombatLog.Add(newCombatLog);
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 103:
                    #region Feed The Graves
                    // Whenever another character performs an attack action, this character deals 2 Force Damage to all enemy characters 

                    var bPerformingAttack = false;
                    foreach (var log in globalCombatLog.Where(x => x.Action_Order == _GAMESTATE.Current_Act_Order && _GAMESTATE.Active_Character.Character_PK != skillOwner.Character_PK).ToList())
                    {
                        var performedSkill = GetSkill(log.Skill_FK);
                        if (performedSkill.Skill_Type.Contains("Attack") ||
                            performedSkill.Skill_Type.Contains("Affliction") ||
                            performedSkill.Skill_Type.Contains("Taunt"))
                            bPerformingAttack = true;
                    }

                    if (bPerformingAttack)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        foreach (var enemy in globalCharacters.Where(x => x.Guild_FK != GetCharacter(skillOwner.Character_PK).Guild_FK && !x.Conditions.bKnockedOut).ToList())
                        {
                            Combat_Log newCombatLog = new Combat_Log()
                            {
                                Skirmish_FK = _GAMESTATE.Skirmish_FK,
                                Assailant_Character_FK = skillOwner.Character_PK,
                                Target_Character_FK = enemy.Character_PK,
                                Skill_FK = currSkill.Skill_PK,
                                Action_Order = _GAMESTATE.Current_Act_Order,
                                Attack_Final_Result = 0,
                                Attack_Values = "0",
                                Damage_Final_Result = 2,
                                tmpDamage_Final_Result = new List<int>() { 2 },
                                Damage_Values = "2",
                                Damage_Types = "Force",
                                Conditions = 0,
                                bAttackSuccessful = true,
                                bInterrupt = true
                            };

                            globalCombatLog.Add(newCombatLog);
                        }

                        bSkillExecuted = true;
                    }

                    #endregion
                    break;
                case 110:
                    #region Vampiric Aura
                    // Whenever this character is dealt damage from an attack action, the assailant is dealt 1d10 Poison Damage and this character regains Health equal to the damage dealt this way
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // generate combat log
                        var damageDealt = rand.Next(1, 11); // roll 1d10
                        Combat_Log damageCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = log.Assailant_Character_FK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = damageDealt,
                            tmpDamage_Final_Result = new List<int>() { damageDealt },
                            Damage_Values = damageDealt.ToString(),
                            Damage_Types = "Poison",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };
                        globalCombatLog.Add(damageCombatLog);

                        Combat_Log healCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = skillOwner.Character_PK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = damageDealt,
                            tmpDamage_Final_Result = new List<int>() { damageDealt },
                            Damage_Values = damageDealt.ToString(),
                            Damage_Types = "Healing",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };
                        globalCombatLog.Add(healCombatLog);

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 114:
                    #region We Are Many
                    // This character is granted Advantage on all attacks
                    if (_GAMESTATE.Active_Character.Character_PK == skillOwner.Character_PK)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] receiving Advantage on all attacks");
                        skillOwner.Conditions.bAttackAdvantage = true;

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 118:
                    #region Purity Scent
                    // This creature receives Advantage on Finesse based attack actions
                    if (_GAMESTATE.Active_Character.Character_PK == skillOwner.Character_PK && _GAMESTATE.Pending_Skill.Attribute_FK == "Finesse")
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] receiving Advantage on Finesse based attacks");
                        skillOwner.Conditions.bAttackAdvantage = true;

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 126:
                    #region Parry
                    // Whenever this character is dealt damage from an attack action, the assailant is dealt 2d6 + 2 Physical Damage
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // generate combat log
                        var damageDealt = rand.Next(2, 13) + 2; // roll 2d6+2
                        Combat_Log newCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = log.Assailant_Character_FK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = damageDealt,
                            tmpDamage_Final_Result = new List<int>() { damageDealt },
                            Damage_Values = damageDealt.ToString(),
                            Damage_Types = "Physical",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };

                        globalCombatLog.Add(newCombatLog);
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 130:
                    #region Cognizant Insight
                    // Whenever this character is dealt damage by an attack action, prevent 1d10 of the attack’s damage
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        var lessDamage = rand.Next(1, 11);
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] taking " + lessDamage + " less damage from attack");
                        log.Damage_Final_Result -= lessDamage;
                        if (log.Damage_Final_Result < 0) log.Damage_Final_Result = 0;
                        for (var i = 0; i < log.tmpDamage_Final_Result.Count(); i++)
                        {
                            var dmgResult = log.tmpDamage_Final_Result[i];
                            dmgResult -= lessDamage;
                            if (dmgResult < 0)
                            {
                                lessDamage = dmgResult * -1;
                                dmgResult = 0;
                            }
                            else
                            {
                                break;
                            }
                        }
                        
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 144:
                    #region Ent Summoning
                    // This character summons a large Ent to protect them from harm. After this character performs an action, all damage dealt to this character is halved
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        var lessDamage = (int)Math.Ceiling((double)log.tmpDamage_Final_Result.Sum() / (double)2);
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] taking " + lessDamage + " less damage from attack");
                        log.Damage_Final_Result -= lessDamage;
                        if (log.Damage_Final_Result < 0) log.Damage_Final_Result = 0;
                        for (var i = 0; i < log.tmpDamage_Final_Result.Count(); i++)
                        {
                            var dmgResult = log.tmpDamage_Final_Result[i];
                            dmgResult -= (int)Math.Ceiling((double)dmgResult / (double)2);
                        }

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 149:
                    #region Spirit of the Forest
                    // Whenever this character performs an attack and the attack result is 20 or greater, this character is healed for 1d10 Health
                    foreach(var log in globalCombatLog.Where(x => x.Assailant_Character_FK == skillOwner.Character_PK &&
                                                                  x.Action_Order == _GAMESTATE.Current_Act_Order).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        var relativeSkill = GetSkill(log.Skill_FK);
                        if(relativeSkill.Skill_Type.Contains("Attack") ||
                            relativeSkill.Skill_Type.Contains("Affliction") ||
                            relativeSkill.Skill_Type.Contains("Taunt"))
                        {
                            if (log.Attack_Final_Result >= 20)
                            {
                                // generate combat log
                                var healthRegained = rand.Next(1, 11); // roll 1d10
                                Combat_Log newCombatLog = new Combat_Log()
                                {
                                    Skirmish_FK = _GAMESTATE.Skirmish_FK,
                                    Assailant_Character_FK = skillOwner.Character_PK,
                                    Target_Character_FK = skillOwner.Character_PK,
                                    Skill_FK = currSkill.Skill_PK,
                                    Action_Order = _GAMESTATE.Current_Act_Order,
                                    Attack_Final_Result = 0,
                                    Attack_Values = "0",
                                    Damage_Final_Result = healthRegained,
                                    tmpDamage_Final_Result = new List<int>() { healthRegained },
                                    Damage_Values = healthRegained.ToString(),
                                    Damage_Types = "Healing",
                                    Conditions = 0,
                                    bAttackSuccessful = true,
                                    bInterrupt = true
                                };

                                globalCombatLog.Add(newCombatLog);
                                bSkillExecuted = true;
                            }
                        }

                    }
                    #endregion
                    break;
                case 158:
                    #region Deep Wounds
                    // Whenever this character takes damage from an attack action, it suffers -1 Finesse
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        skillOwner.Finesse -= 1;
                        if (skillOwner.Finesse < 0) skillOwner.Finesse = 0;

                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] suffers -1 Finesse");
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 159:
                    #region Shapeshift
                    // This character assumes a much more powerful form while at 5 or greater Finesse. All attack actions performed by this character while in its higher form deal an additional 2d10 Physical Damage
                    if (_GAMESTATE.Active_Character.Character_PK != skillOwner.Character_PK) return;
                    if (skillOwner.Finesse < 5) return;

                    foreach (var log in globalCombatLog.Where(x =>
                        x.Assailant_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.bAttackSuccessful).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // generate combat log
                        var bonusDamage = rand.Next(2, 21); // roll 2d10
                        log.Damage_Final_Result += bonusDamage;
                        log.Damage_Types += ",Physical";
                        log.Damage_Values += "," + bonusDamage.ToString();

                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] dealing " + bonusDamage + " Physical Damage as bonus damage");

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 164:
                    #region Camouflage
                    // This character begins each Skirmish Invisible
                    if (_GAMESTATE.Current_Act_Order == 1 && !skillOwner.Conditions.bInvisible)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] becoming Invisible from [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");
                        skillOwner.Conditions.bInvisible = true;
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 168:
                    #region Forgetful
                    // This character has a hard time recalling certain things. If this character misses on any attack, this character is dealt 1d10 Physical Damage
                    foreach(var log in globalCombatLog.Where(x => x.Assailant_Character_FK == skillOwner.Character_PK &&
                                                                  x.Action_Order == _GAMESTATE.Current_Act_Order &&
                                                                  !x.bAttackSuccessful).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // generate combat log
                        var damageDealt = rand.Next(1, 11); // roll 1d10
                        Combat_Log newCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = skillOwner.Character_PK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = damageDealt,
                            tmpDamage_Final_Result = new List<int>() { damageDealt },
                            Damage_Values = damageDealt.ToString(),
                            Damage_Types = "Physical",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };

                        globalCombatLog.Add(newCombatLog);

                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] taking " + damageDealt + " Physical Damage for missing attack");
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 173:
                    #region Rock Form
                    // This character is made of jagged rock, causing any Finesse or Agility based attack actions performed against this character to deal 1d8 + 2 Physical Damage to the assailant
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        var assailantSkill = GetSkill(log.Skill_FK);
                        if (assailantSkill.Attribute_FK != "Finesse" || assailantSkill.Attribute_FK != "Agility") continue;

                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // generate combat log
                        var damageDealt = rand.Next(1, 9) + 2; // roll 2d6+2
                        Combat_Log newCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = log.Assailant_Character_FK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = damageDealt,
                            tmpDamage_Final_Result = new List<int>() { damageDealt },
                            Damage_Values = damageDealt.ToString(),
                            Damage_Types = "Physical",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };

                        globalCombatLog.Add(newCombatLog);
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 177:
                    #region Hungry Wildlife
                    // If this character begins the Skirmish with 0 Energy, this character gains Advantage on all attack actions
                    if (_GAMESTATE.Current_Act_Order == 1)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] has Advantage on all attacks from [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");
                        skillOwner.Conditions.bAttackAdvantage = true;
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 182:
                    #region Rock Form
                    // This character is made of jagged rock, causing any Finesse or Agility based attack actions performed against this character to deal 1d4 + Current Finesse Physical Damage to the assailant
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        var assailantSkill = GetSkill(log.Skill_FK);
                        if (assailantSkill.Attribute_FK != "Finesse" || assailantSkill.Attribute_FK != "Agility") continue;

                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // generate combat log
                        var damageDealt = rand.Next(1, 5) + skillOwner.Finesse; // roll 1d4 + Current Finesse
                        Combat_Log newCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = log.Assailant_Character_FK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = damageDealt,
                            tmpDamage_Final_Result = new List<int>() { damageDealt },
                            Damage_Values = damageDealt.ToString(),
                            Damage_Types = "Physical",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };

                        globalCombatLog.Add(newCombatLog);
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 183:
                    #region Crumbling State
                    // This character’s body is ancient and is slowly crumbling away. Whenever this character is dealt damage, it suffers -1 Finesse
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        skillOwner.Finesse -= 1;
                        if (skillOwner.Finesse < 0) skillOwner.Finesse = 0;

                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] suffers -1 Finesse");
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 193:
                    #region Wolf Companion
                    // This character has a companion that protects them whenever enemies attack them. Whenever a character performs a Finesse or Agility based attack action, deal 2d8 + 2 Physical Damage to the assailant
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // generate combat log
                        var damageDealt = rand.Next(2, 17) + 2; // roll 2d8+2
                        Combat_Log newCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = log.Assailant_Character_FK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = damageDealt,
                            tmpDamage_Final_Result = new List<int>() { damageDealt },
                            Damage_Values = damageDealt.ToString(),
                            Damage_Types = "Physical",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };

                        globalCombatLog.Add(newCombatLog);
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 197:
                    #region Ethereal Existence
                    // This character begins each Skirmish Invisible.
                    if (_GAMESTATE.Current_Act_Order == 1 && !skillOwner.Conditions.bInvisible)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] becoming Invisible from [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");
                        skillOwner.Conditions.bInvisible = true;
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 207:
                    #region Charging Up
                    // This character receives +1 Finesse whenever an ally performs an action. 
                    if (_GAMESTATE.Active_Character.Guild_FK == skillOwner.Guild_FK && _GAMESTATE.Active_Character.Character_PK != skillOwner.Character_PK)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] granted +1 Finesse from [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        skillOwner.Finesse++;

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 211:
                    #region Hot Touch
                    // Whenever this character is dealt damage from an attack action, the assailant is dealt 2d8 Burning Damage
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // generate combat log
                        var damageDealt = rand.Next(2, 9); // roll 2d8
                        Combat_Log newCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = log.Assailant_Character_FK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = damageDealt,
                            tmpDamage_Final_Result = new List<int>() { damageDealt },
                            Damage_Values = damageDealt.ToString(),
                            Damage_Types = "Burning",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };

                        globalCombatLog.Add(newCombatLog);
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 235:
                    #region Dung Collector
                    // Whenever an enemy performs an action, this character receives +1 Finesse
                    if (_GAMESTATE.Active_Character.Guild_FK != skillOwner.Guild_FK)
                    {
                        if (_GAMESTATE.Pending_Skill.Skill_Type.Contains("Attack") ||
                            _GAMESTATE.Pending_Skill.Skill_Type.Contains("Affliction") ||
                            _GAMESTATE.Pending_Skill.Skill_Type.Contains("Taunt"))
                        {
                            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] granted +1 Finesse from [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                            skillOwner.Finesse++;

                            bSkillExecuted = true;
                        }
                    }
                    #endregion
                    break;
                case 239:
                    #region Auto Target
                    // After this character’s turn, deal 1d4 Force Damage to three random enemies
                    if (_GAMESTATE.Active_Character.Character_PK == skillOwner.Character_PK)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        // find three random enemies
                        var enemyTargets = new List<Character>();
                        for (var i = 0; i < 3; i++)
                        {
                            var randomEnemyTarget = globalCharacters.FirstOrDefault(x => !enemyTargets.Contains(x) && x.Guild_FK != skillOwner.Guild_FK);
                            if (randomEnemyTarget == null) continue;
                        }

                        foreach (var enemy in enemyTargets)
                        {
                            // generate combat log
                            var damageDealt = rand.Next(1, 5); // roll 1d4
                            Combat_Log newCombatLog = new Combat_Log()
                            {
                                Skirmish_FK = _GAMESTATE.Skirmish_FK,
                                Assailant_Character_FK = skillOwner.Character_PK,
                                Target_Character_FK = enemy.Character_PK,
                                Skill_FK = currSkill.Skill_PK,
                                Action_Order = _GAMESTATE.Current_Act_Order,
                                Attack_Final_Result = 0,
                                Attack_Values = "0",
                                Damage_Final_Result = damageDealt,
                                tmpDamage_Final_Result = new List<int>() { damageDealt },
                                Damage_Values = damageDealt.ToString(),
                                Damage_Types = "Force",
                                Conditions = 0,
                                bAttackSuccessful = true,
                                bInterrupt = true
                            };

                            globalCombatLog.Add(newCombatLog);
                        }
                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 253:
                    #region New Appendages
                    // Whenever this character is damaged by a Finesse or Agility based attack, this character heals for 2d10 Health.
                    foreach (var log in globalCombatLog.Where(x =>
                        x.Target_Character_FK == skillOwner.Character_PK &&
                        x.Action_Order == _GAMESTATE.Current_Act_Order &&
                        x.tmpDamage_Final_Result.Sum() > 0).ToList())
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] Calculating ... [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        var relativeSkill = GetSkill(log.Skill_FK);

                        if (relativeSkill.Attribute_FK != "Finesse" || relativeSkill.Attribute_FK != "Agility") continue;

                        // generate combat log
                        var healthRegained = rand.Next(2, 21); // roll 2d10
                        Combat_Log healCombatLog = new Combat_Log()
                        {
                            Skirmish_FK = _GAMESTATE.Skirmish_FK,
                            Assailant_Character_FK = skillOwner.Character_PK,
                            Target_Character_FK = skillOwner.Character_PK,
                            Skill_FK = currSkill.Skill_PK,
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Attack_Final_Result = 0,
                            Attack_Values = "0",
                            Damage_Final_Result = healthRegained,
                            tmpDamage_Final_Result = new List<int>() { healthRegained },
                            Damage_Values = healthRegained.ToString(),
                            Damage_Types = "Healing",
                            Conditions = 0,
                            bAttackSuccessful = true,
                            bInterrupt = true
                        };
                        globalCombatLog.Add(healCombatLog);

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
                case 261:
                    #region Stealthy
                    // This character becomes Invisible after performing an attack action
                    if (_GAMESTATE.Active_Character.Character_PK == skillOwner.Character_PK)
                    {
                        logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM [" + skillOwner.Character_Name + "] becoming Invisible from [" + GetSkill(currSkill.Skill_PK).Skill_Name + "]");

                        skillOwner.Conditions.bInvisible = true;

                        bSkillExecuted = true;
                    }
                    #endregion
                    break;
            }

            if (bSkillExecuted)
            {
                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM ExecuteSkill _GAMESTATE: " + Json.Serialize(_GAMESTATE));
                logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM INTERRUPT [" + skillOwner.Character_Name + "] interupts with [" + globalSkills.FirstOrDefault(x => x.Skill_PK == currSkill.Skill_PK).Skill_Name + "] " + Json.Serialize(globalSkills.FirstOrDefault(x => x.Skill_PK == currSkill.Skill_PK)));
            }
        }
        public void UpdateCharacterTrackLog(int Character_PK, string AccoladeType, int inVal)
        {
            Character_Track_Log updateLog = globalCharacterTrackLog.FirstOrDefault(x => x.Character_FK == Character_PK);
            int accoladePointWorth = globalAccolades.FirstOrDefault(x => x.Accolade_Identifier == AccoladeType).Accolade_Point_Value;

            logger.WriteLine(DateTime.Today + " " + stopwatch.ElapsedMilliseconds + "ms SYSTEM Grant Accolade [" + AccoladeType + "](" + accoladePointWorth * inVal + " points) to " + GetCharacter(Character_PK).Character_Name);

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
                case "Afflictions_Inflicted":
                    updateLog.Afflictions_Inflicted += inVal * accoladePointWorth;
                    break;
                case "Initiative_Acted_First":
                    updateLog.Initiative_Acted_First += inVal * accoladePointWorth;
                    break;
                case "Guild_Win_Bonus":
                    updateLog.Guild_Win_Bonus += inVal * accoladePointWorth;
                    break;
                case "Blessing_Bestow":
                    updateLog.Blessing_Bestow += inVal * accoladePointWorth;
                    break;
                case "Blessing_Shield_Absorb":
                    updateLog.Blessing_Shield_Absorb += inVal * accoladePointWorth;
                    break;
                case "Blessing_Bonus_Damage":
                    updateLog.Blessing_Bonus_Damage += inVal * accoladePointWorth;
                    break;
                case "Blessing_Stat_Buff":
                    updateLog.Blessing_Stat_Buff += inVal * accoladePointWorth;
                    break;
            }
        }
    }
}