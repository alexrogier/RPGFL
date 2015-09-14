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
                
                // get today's skirmishes
                globalSkirmishes = controller.GetCurrentSkirmishes();

                // get accolades
                globalAccolades = controller.GetAccolades();

                foreach (Skirmish skirmish in globalSkirmishes)
                {
                    #region Skirmish Initialization
                    // create log file for skirmish
                    this.ScheduleHistoryItem.AddLogNote("CREATE LOG FILE");
                    logger = File.CreateText(HttpRuntime.AppDomainAppPath + "/DesktopModules/BattleFrameworkModule/logs/" + skirmish.Skirmish_PK + ".txt");

                    // get all data for data warehouse object arrays
                    globalCharacters = controller.GetSkirmishCharacters(skirmish.Skirmish_PK);
                    logger.WriteLine(DateTime.Now + " DATA globalCharacters: " + Json.Serialize(globalCharacters));
                    globalSkills = controller.GetSkillDataFromSkirmishCharacters(skirmish.Skirmish_PK);
                    logger.WriteLine(DateTime.Now + " DATA globalSkills: " + Json.Serialize(globalSkills));
                    globalInitTrack = controller.GetInitiativeTrackFromSkirmish(skirmish.Skirmish_PK);
                    logger.WriteLine(DateTime.Now + " DATA globalInitTrack: " + Json.Serialize(globalInitTrack));
                    globalVotes = controller.GetVoteDataFromSkirmish(skirmish.Skirmish_PK);
                    logger.WriteLine(DateTime.Now + " DATA globalVotes: " + Json.Serialize(globalVotes));

                    logger.WriteLine("");
                    logger.WriteLine(DateTime.Now + " BEGIN CHARACTER INITIALIZATION");
                    // initialize characters
                    foreach(var character in globalCharacters)
                    {
                        logger.WriteLine(DateTime.Now + " SETTING [" + character.Character_Name + "] Max_Health to " + character.Health);
                        character.Max_Health = character.Health;
                        character.Conditions = new Conditions();
                        character.Conditions.Shield_Enchanters_Character_PK = new List<int>();
                        character.Conditions.DamageBonus_Enchanters_Character_PK = new List<int>();
                        character.Conditions.Guarded_Characters_PK = new List<int>();

                        logger.WriteLine(DateTime.Now + " SYSTEM Creating character track log for character ...");
                        globalCharacterTrackLog.Add(new Character_Track_Log(){ Character_FK = character.Character_PK });
                    }
                    logger.WriteLine(DateTime.Now + " END CHARACTER INITIALIZATION");
                    logger.WriteLine("");
                    logger.WriteLine(DateTime.Now + " BEGIN SKILL INITIALIZATION");
                    // initialize passive skills
                    //foreach (var skill in globalSkills)
                    //{
                    //    if (skill.bIsPassive)
                    //    {
                    //        logger.WriteLine(DateTime.Now + " PREPARING [" + skill.Skill_Name + "](pk=" + skill.Skill_PK + ") | Exec_Track_Step: " + skill.Exec_Track_Step);
                    //        skirmishPreparedSkills.Add(new Prepared_Skills()
                    //        {
                    //            Skill_PK = skill.Skill_PK,
                    //            Preparer_Character_FK = globalVotes.FirstOrDefault(x => x.Skill_FK == skill.Skill_PK).Character_FK,
                    //            Exec_Track_Step = skill.Exec_Track_Step
                    //        });
                    //    }
                    //}
                    logger.WriteLine(DateTime.Now + " END SKILL INITIALIZATION");
                    #endregion

                    // perform skills following initiatve track (should already be sorted from SQL)
                    logger.WriteLine("");
                    logger.WriteLine(DateTime.Now + " BEGIN SKIRMISH");
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
                            logger.WriteLine(DateTime.Now + " BEGIN TRACK STEP [" + currTrackStep + "] for [" + currChar.Character_Name + "]");
                            _GAMESTATE.Current_Track_Step = currTrackStep;

                            switch (currTrackStep)
                            {
                                #region BEGIN TURN
                                case 1:
                                    // 1 - set active character to this character
                                    logger.WriteLine("SETTING [" + currChar.Character_Name + "](pk=" + currChar.Character_PK + ") as active character");
                                    _GAMESTATE.Active_Character = currChar;
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
                                    CheckSpecialSkills();
                                    break;
                                #endregion
                                #region DETERMINE SKILL
                                case 4:
                                    // 4 - find favored skill
                                    logger.WriteLine(DateTime.Now + " SYSTEM Finding favored skill for character to perform ...");
                                    FavoredSkill = GetSkill(globalVotes.OrderByDescending(x => x.Vote_Count).FirstOrDefault(x => x.Character_FK == currChar.Character_PK).Skill_FK);
                                    logger.WriteLine(DateTime.Now + " SYSTEM Found favored skill. Skill_Name: [" + FavoredSkill.Skill_Name + "](pk=" + FavoredSkill.Skill_PK + ") | " + Json.Serialize(FavoredSkill));
                                    _GAMESTATE.Pending_Skill = FavoredSkill;
                                    break;
                                case 5:
                                    // 5 - find favored targets for skill
                                    // targets are separated by commas
                                    logger.WriteLine(DateTime.Now + " SYSTEM Finding favored targets for skill ...");
                                    if(globalVotes.FirstOrDefault(x => x.Skill_FK == FavoredSkill.Skill_PK && x.Character_FK == currChar.Character_PK).Targets == "")
                                    {
                                        logger.WriteLine(DateTime.Now + " SYSTEM No targets for this skill");
                                    }
                                    else
                                    {
                                        // check for multi attack restrictions
                                        if (FavoredSkill.Skill_Type == "MultiAttack,Single")
                                        {
                                            // character can only attack the same target again
                                            var skill = FavoredSkill; // declared because of loop closure
                                            var relativeCombatLog = globalCombatLog.FirstOrDefault(x => x.Assasilant_Character_FK == currChar.Character_PK && x.Skill_FK == skill.Skill_PK);

                                             // if relativeCombatLog is null, this is the first time this attack is happening
                                            if (relativeCombatLog == null)
                                            {
                                                var target = globalCharacters.FirstOrDefault(x => x.Character_PK == Int32.Parse(globalVotes.FirstOrDefault(v => v.Character_FK == currChar.Character_PK && v.Skill_FK == FavoredSkill.Skill_PK).Targets) && x.Guild_FK != currChar.Guild_FK && !x.Conditions.bKnockedOut && !x.Conditions.bInvisible);
                                                FavoredSkillFavoredTargets.Add(target);
                                                logger.WriteLine(DateTime.Now + " SYSTEM performing same attack against [" + target.Character_Name + "]");
                                            } else {
                                                FavoredSkillFavoredTargets.Add(GetCharacter(relativeCombatLog.Target_Character_FK));
                                                logger.WriteLine(DateTime.Now + " SYSTEM performing same attack against same target");
                                            }
                                        }
                                        else if (FavoredSkill.Skill_Type == "MultiAttack,Multi")
                                        {
                                            // character must attack a different target than before
                                            var skill = FavoredSkill; // declared because of loop closure
                                            var relativeCombatLog = globalCombatLog.OrderByDescending(x => x.Action_Order).FirstOrDefault(x => x.Assasilant_Character_FK == currChar.Character_PK && x.Skill_FK == skill.Skill_PK);

                                            // if relativeCombatLog is null, this is the first time this attack is happening
                                            if (relativeCombatLog == null)
                                            {
                                                var target = globalCharacters.FirstOrDefault(x => x.Character_PK == Int32.Parse(globalVotes.FirstOrDefault(v => v.Character_FK == currChar.Character_PK && v.Skill_FK == FavoredSkill.Skill_PK).Targets) && x.Guild_FK != currChar.Guild_FK && !x.Conditions.bKnockedOut && !x.Conditions.bInvisible);
                                                FavoredSkillFavoredTargets.Add(target);
                                                logger.WriteLine(DateTime.Now + " SYSTEM performing same attack against [" + target.Character_Name + "]");

                                            }
                                            else
                                            {
                                                var target = globalCharacters.FirstOrDefault(x => x.Character_PK != relativeCombatLog.Target_Character_FK && x.Guild_FK != currChar.Guild_FK && !x.Conditions.bKnockedOut && !x.Conditions.bInvisible);
                                                FavoredSkillFavoredTargets.Add(target);
                                                logger.WriteLine(DateTime.Now + " SYSTEM performing same attack against [" + target.Character_Name + "]");
                                            }
                                        }
                                        else
                                        {
                                            var tmpTargets = Array.ConvertAll(globalVotes.FirstOrDefault(x =>
                                                x.Skill_FK == FavoredSkill.Skill_PK &&
                                                x.Character_FK == currChar.Character_PK).Targets.Split(','), int.Parse);
                                            FavoredSkillFavoredTargets.AddRange(
                                                tmpTargets.Select(target => GetCharacter(target)));
                                        }
                                        logger.WriteLine(DateTime.Now + " SYSTEM Found favored targets [" + Json.Serialize(FavoredSkillFavoredTargets) + "]");
                                    }
                                    _GAMESTATE.Pending_Targets = FavoredSkillFavoredTargets;
                                    break;
                                #endregion
                                #region PRELIMINARY SKILL EXECUTION
                                case 6:
                                    logger.WriteLine(DateTime.Now + " SYSTEM Determine target legibility");
                                    // 6 - target legibility (Invisiblity, Knocked Out, Charmed, ect)
                                    foreach (var target in FavoredSkillFavoredTargets.ToList())
                                    {
                                        logger.WriteLine(DateTime.Now + " SYSTEM target=[" + target.Character_Name + "] |" +
                                                                        " bInvisible:" + target.Conditions.bInvisible + " | bKnockedOut:" + target.Conditions.bKnockedOut + 
                                                                        " bCharmed:" + target.Conditions.bCharmed + " | bTaunted:" + target.Conditions.bTaunted + 
                                                                        " bBlinded:" + target.Conditions.bBlinded + " | bGuarded:" + target.Conditions.bGuarded);

                                        // check if character has skills to bypass normal targetting rules
                                        CheckSpecialSkills();

                                        // target is either Invisible or Knocked Out, reassign to random enemy
                                        if (target.Conditions.bInvisible || target.Conditions.bKnockedOut)
                                        {
                                            // remove old target from target list
                                            logger.WriteLine(DateTime.Now + " SYSTEM target is invisible or knocked out, remove target from favored target list and assign a new target | Skill_Type:"+ FavoredSkill.Skill_Type);
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
                                                case "Affliction,StatDebuff":
                                                case "MultiAttack,Single":
                                                case "MultiAttack,Multi":
                                                    // find new target not on this character's team
                                                    newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK != currChar.Guild_FK && !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));
                                                    logger.WriteLine(DateTime.Now + " SYSTEM New target found | {" + Json.Serialize(newTarget) + "}");
                                                    break;
                                                case "Heal":
                                                    // find new target that is on this character's team that has less than full health
                                                    newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK && x.Health < x.Max_Health && !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));
                                                    logger.WriteLine(DateTime.Now + " SYSTEM New target found | {" + Json.Serialize(newTarget) + "}");
                                                    break;
                                                case "Blessing,Disadvantage":
                                                case "Blessing,Advantage":
                                                case "Blessing,Damage":
                                                    // find new target on this character's team
                                                    newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK && !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));
                                                    logger.WriteLine(DateTime.Now + " SYSTEM New target found | {" + Json.Serialize(newTarget) + "}");
                                                    break;
                                                case "Blessing,StatBuff":
                                                case "Blessing,Shield":
                                                    // find new target on this character's team that is NOT this character
                                                    newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK && !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut && x.Character_PK != currChar.Character_PK));
                                                    logger.WriteLine(DateTime.Now + " SYSTEM New target found | {" + Json.Serialize(newTarget) + "}");
                                                    break;
                                            }
                                            
                                            // ensure a target was found, then add it
                                            if (newTarget != null)
                                            {
                                                logger.WriteLine(DateTime.Now + " SYSTEM adding new target to favored targets");
                                                FavoredSkillFavoredTargets.Add(newTarget);
                                            }
                                        }

                                        // if character is Charmed
                                        if (currChar.Conditions.bCharmed)
                                        {
                                            logger.WriteLine(DateTime.Now + " SYSTEM target is charmed, reassign target to random ally");

                                            // remove old target from target list
                                            FavoredSkillFavoredTargets.Remove(target);
                                            Character newTarget = new Character();

                                            // assign new target to random ally
                                            newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => x.Guild_FK == currChar.Guild_FK && currChar.Conditions.Charm_Character_PK != x.Character_PK && !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));

                                            // ensure a target was found, then add it
                                            if (newTarget != null)
                                            {
                                                logger.WriteLine(DateTime.Now + " SYSTEM target acquired, add to favored targets | newTarget:{" + newTarget.Character_Name + "}");
                                                FavoredSkillFavoredTargets.Add(newTarget);
                                            }
                                        }

                                        // if character is Taunted - AoE skills ignore taunts
                                        if (currChar.Conditions.bTaunted && FavoredSkill.Max_Targets < 12)
                                        {
                                            // ensure taunter is still a legal target - otherwise maintain favored targets
                                            Boolean bTaunterTargettable = globalCharacters.Contains(globalCharacters.FirstOrDefault(x =>
                                                            x.Character_PK == currChar.Conditions.Taunted_Character_PK &&
                                                            !x.Conditions.bInvisible && 
                                                            !x.Conditions.bKnockedOut));

                                            logger.WriteLine(DateTime.Now + " SYSTEM character is taunted, reassign target to taunter if able | TaunterCharPK:"+ target.Conditions.Taunted_Character_PK + " | bTaunterTargettable:" + bTaunterTargettable);

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
                                                    logger.WriteLine(DateTime.Now + " SYSTEM taunter is targettable, add to favored targets | newTarget:{" + Json.Serialize(newTarget) + "}");
                                                    FavoredSkillFavoredTargets.Add(newTarget);
                                                }
                                            }
                                        }

                                        // if character is Blinded
                                        if (currChar.Conditions.bBlinded)
                                        {
                                            logger.WriteLine(DateTime.Now + " SYSTEM target is blinded, reassign target to random character");

                                            // remove old target from target list
                                            FavoredSkillFavoredTargets.Remove(target);
                                            Character newTarget = new Character();

                                            // assign new target to random character (even ally)
                                            newTarget = globalCharacters.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => !FavoredSkillFavoredTargets.Exists(y => y.Character_PK == x.Character_PK && x.Conditions.bInvisible && x.Conditions.bKnockedOut));

                                            // ensure a target was found, then add it
                                            if (newTarget != null)
                                            {
                                                logger.WriteLine(DateTime.Now + " SYSTEM target acquired, add to favored targets | newTarget:{" + Json.Serialize(newTarget) + "}");
                                                FavoredSkillFavoredTargets.Add(newTarget);
                                            }
                                        }

                                        // if target is Guarded
                                        if (target.Conditions.bGuarded)
                                        {
                                            logger.WriteLine(DateTime.Now + " SYSTEM target is guarded, reassign target to guard character");

                                            // remove old target from target list
                                            FavoredSkillFavoredTargets.Remove(target);
                                            Character newTarget = new Character();

                                            // assign new target to guard
                                            newTarget = globalCharacters.FirstOrDefault(x => x.Character_PK == target.Conditions.Guarded_Characters_PK.OrderByDescending(y => y).FirstOrDefault());

                                            // ensure a target was found, then add it
                                            if (newTarget != null)
                                            {
                                                logger.WriteLine(DateTime.Now + " SYSTEM target acquired, add to favored targets | newTarget:{" + Json.Serialize(newTarget) + "}");
                                                FavoredSkillFavoredTargets.Add(newTarget);
                                            }
                                        }
                                    }

                                    // ensure at least one target exists after validation, unless skill is a prepared skill
                                    if (FavoredSkillFavoredTargets.Count == 0)
                                    {
                                        logger.WriteLine(DateTime.Now + " SYSTEM no valid targets available - end the turn");
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
                                    foreach (var target in FavoredSkillFavoredTargets)
                                    {
                                        Combat_Log newCombatLogEntry = new Combat_Log();
                                        newCombatLogEntry.Action_Order = globalInitTrack.FirstOrDefault(x => x.Character_FK == currChar.Character_PK).Act_Order;
                                        //newCombatLogEntry.Conditions
                                        newCombatLogEntry.Assasilant_Character_FK = currChar.Character_PK;
                                        newCombatLogEntry.Skill_FK = FavoredSkill.Skill_PK;
                                        newCombatLogEntry.Target_Character_FK = target.Character_PK;
                                        newCombatLogEntry.Skirmish_FK = skirmish.Skirmish_PK;

                                        var bEndTheTurn = false;

                                        switch (FavoredSkill.Skill_Type)
                                        {
                                            case "Blessing,Advantage":
                                                logger.WriteLine(DateTime.Now + " SYSTEM casting Blessing,Advantage on [" + target.Character_Name + "]");
                                                target.Conditions.bAttackAdvantage = true;
                                               
                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Disadvantage":
                                                logger.WriteLine(DateTime.Now + " SYSTEM casting Blessing,Disadvantage on [" + target.Character_Name + "]");
                                                target.Conditions.bDefendAdvantage = true;

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Shield":
                                                logger.WriteLine(DateTime.Now + " SYSTEM casting Blessing,Shield(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Conditions.bShielded = true;
                                                target.Conditions.Shield += Int32.Parse(FavoredSkill.Damage_Roll);
                                                target.Conditions.Shield_Enchanters_Character_PK.Add(currChar.Character_PK);

                                                newCombatLogEntry.Damage_Final_Result = Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Bestow", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Damage":
                                                logger.WriteLine(DateTime.Now + " SYSTEM casting Blessing,Shield(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Conditions.bDamageBonus = true;
                                                target.Conditions.DamageBonus += Int32.Parse(FavoredSkill.Damage_Roll);
                                                target.Conditions.DamageBonus_Enchanters_Character_PK.Add(currChar.Character_PK);

                                                newCombatLogEntry.Damage_Final_Result = Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Bestow", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,AllStats":
                                                logger.WriteLine(DateTime.Now + " SYSTEM casting Blessing,AllStats(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
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
                                                logger.WriteLine(DateTime.Now + " SYSTEM casting Blessing,Finesse(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Finesse += Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Agility":
                                                logger.WriteLine(DateTime.Now + " SYSTEM casting Blessing,Agility(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Agility += Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Senses":
                                                logger.WriteLine(DateTime.Now + " SYSTEM casting Blessing,Senses(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Senses += Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Mana":
                                                logger.WriteLine(DateTime.Now + " SYSTEM casting Blessing,Mana(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
                                                target.Mana += Int32.Parse(FavoredSkill.Damage_Roll);

                                                // record accolade
                                                UpdateCharacterTrackLog(currChar.Character_PK, "Blessing_Stat_Buff", 1);
                                                bEndTheTurn = true;
                                                break;
                                            case "Blessing,Dodge":
                                                logger.WriteLine(DateTime.Now + " SYSTEM casting Blessing,Dodge(" + FavoredSkill.Damage_Roll + ") on [" + target.Character_Name + "]");
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
                                                logger.WriteLine(DateTime.Now + " SYSTEM guarding [" + target.Character_Name + "]");
                                                target.Conditions.bGuarded = true;
                                                target.Conditions.Guarded_Characters_PK.Add(currChar.Character_PK);
                                            }
                                            bEndTheTurn = true;
                                        }

                                        if (bEndTheTurn)
                                        {
                                            // end the turn
                                            currTrackStep = lastTrackStep;
                                        }
                                    }
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
                                        newCombatLogEntry.Assasilant_Character_FK = currChar.Character_PK;
                                        newCombatLogEntry.Skill_FK = FavoredSkill.Skill_PK;
                                        newCombatLogEntry.Target_Character_FK = target.Character_PK;
                                        newCombatLogEntry.Skirmish_FK = skirmish.Skirmish_PK;
                                        newCombatLogEntry.tmpDamage_Final_Result = new List<int>();

                                        logger.WriteLine(DateTime.Now + " SYSTEM preliminary attack calculation | (bAttackAdvantage:" + currChar.Conditions.bAttackAdvantage + " | bAttackDisadvantage:" + currChar.Conditions.bAttackDisadvantage + ") | TARGET (bAttackAdvantage:" + target.Conditions.bAttackAdvantage + " | bAttackDisadvantage:" + target.Conditions.bAttackDisadvantage + ")");
                                        if (currChar.Conditions.bAttackAdvantage || currChar.Conditions.bAttackDisadvantage)
                                        {
                                            var finalAdvDis = 0; // 0 = roll normally. -1 = roll disadvantage. 1 = roll advantage

                                            if (currChar.Conditions.bAttackAdvantage) finalAdvDis++;
                                            if (currChar.Conditions.bAttackDisadvantage) finalAdvDis--;
                                            if (target.Conditions.bDefendAdvantage) finalAdvDis++;
                                            if (target.Conditions.bDefendDisadvantage) finalAdvDis--;

                                            // determine final result (coded this way because character could have both advantage & disadvantage)
                                            logger.WriteLine(DateTime.Now + " SYSTEM final preliminary attack calculation | finalAdvDis:" + finalAdvDis);

                                            if (finalAdvDis == 0){
                                                currChar.Conditions.bAttackAdvantage = false;
                                                currChar.Conditions.bAttackDisadvantage = false;
                                            } else if (finalAdvDis > 0){
                                                currChar.Conditions.bAttackAdvantage = true;
                                                currChar.Conditions.bAttackDisadvantage = false;
                                            } else if (finalAdvDis < 0){
                                                currChar.Conditions.bAttackAdvantage = false;
                                                currChar.Conditions.bAttackDisadvantage = true;
                                            }
                                        }

                                        logger.WriteLine(DateTime.Now + " SYSTEM rolling attack against [" + target.Character_Name + "] ...");

                                        // don't roll if the attack is auto successful or the skill is a heal
                                        if (!FavoredSkill.bAutoSuccess || FavoredSkill.Skill_Type != "Heal")
                                        {
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

                                            logger.WriteLine(DateTime.Now + " SYSTEM roll(s) achieved | Attack_Values:" +
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
                                            logger.WriteLine(DateTime.Now + " SYSTEM final attack result with modifier[" +
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
                                    //var relativeAttackCombatLogs = globalCombatLog.Where(x => x.Action_Order == globalInitTrack.FirstOrDefault(y => y.Character_FK == currChar.Character_PK).Act_Order);
                                    var relativeAttackCombatLogs = globalCombatLog.Where(x => x.Assasilant_Character_FK == currChar.Character_PK && x.Skill_FK == FavoredSkill.Skill_PK && x.Action_Order == currAct.Act_Order);

                                    if (FavoredSkill.Skill_Type.Contains("MultiAttack"))
                                    {
                                        // work around when multiattacking to implant last entry into IEnumerable
                                        var lastEntry = globalCombatLog.Last(x => x.Assasilant_Character_FK == currChar.Character_PK && x.Skill_FK == FavoredSkill.Skill_PK && x.Action_Order == currAct.Act_Order);
                                        relativeAttackCombatLogs = globalCombatLog.Where(x => x == lastEntry);
                                    }

                                    foreach (var log in relativeAttackCombatLogs)
                                    {
                                        Character targetChar = GetCharacter(log.Target_Character_FK);

                                        // determine if attack is successful
                                        logger.WriteLine(DateTime.Now + " SYSTEM calculating if attack was successful ... | Attack_Final_Result:" + log.Attack_Final_Result + " | Target's Dodge:" + targetChar.Dodge + " | bAutoSuccess:" +FavoredSkill.bAutoSuccess );
                                        log.bAttackSuccessful = (log.Attack_Final_Result >= targetChar.Dodge || FavoredSkill.bAutoSuccess);
                                        if (log.bAttackSuccessful)
                                        {
                                            // attack is successful - roll damage
                                            List<string> rollArray = FavoredSkill.Damage_Roll.Split(',').ToList();
                                            List<int> damageRolls = new List<int>(); // stores all damage rolls

                                            logger.WriteLine(DateTime.Now + " SYSTEM attack successful, rolling damage ...");
                                            foreach (var roll in rollArray)
                                            {
                                                // ignore roll if 0d0+0 (shouldn't deal any damage)
                                                if (roll == "0d0+0") continue;

                                                logger.WriteLine(DateTime.Now + " SYSTEM rolling [" + roll + "]");
                                                string rollSet = roll.Substring(0, roll.IndexOf("+")); // extract "XdX" from "XdX+X"
                                                Int32 rollDiceAmt = Int32.Parse(rollSet.Substring(0, rollSet.IndexOf("d")));
                                                Int32 rollDiceType = Int32.Parse(rollSet.Substring(rollSet.IndexOf("d")+ 1));
                                                Int32 rollModifier = Int32.Parse(roll.Substring(roll.IndexOf("+") + 1)); // extract "+X" from "XdX+X"
                                                Int32 rollFinalResult = 0;

                                                // roll dice for each amount required
                                                for (var x = 1; x <= rollDiceAmt; x++)
                                                {
                                                    Int32 rollResult = rand.Next(1, rollDiceType);

                                                    // record damage roll
                                                    damageRolls.Add(rollResult);

                                                    // accumulate results
                                                    rollFinalResult += rollResult;
                                                }

                                                // add modifiers
                                                switch (FavoredSkill.Attribute_FK)
                                                {
                                                    case "Finesse": rollFinalResult += currChar.Finesse; break;
                                                    case "Agility": rollFinalResult += currChar.Agility; break;
                                                    case "Senses": rollFinalResult += currChar.Senses; break;
                                                    case "Mana": rollFinalResult += currChar.Mana; break;
                                                }
                                                rollFinalResult += rollModifier;

                                                log.tmpDamage_Final_Result.Add(rollFinalResult);
                                                log.Damage_Types = FavoredSkill.Damage_Types;

                                                logger.WriteLine(DateTime.Now + " SYSTEM final damage calculation | Damage_Final_Result:" + rollFinalResult + " | Damage_Types:" + FavoredSkill.Damage_Types);
                                            }
                                        }
                                    }

                                    // all attacks missed, end the turn
                                    if (relativeAttackCombatLogs.Count(x => x.bAttackSuccessful == true) == 0)
                                    {
                                        logger.WriteLine(DateTime.Now + " SYSTEM all attacks missed, end turn");
                                        // attack missed, end the turn
                                        currTrackStep = lastTrackStep;
                                    }
                                    break;
                                case 12:
                                    // 12 - special character skills (pre-damage)
                                    CheckSpecialSkills();
                                    break;
                                case 13:
                                    // 13 - inflict damage on target

                                    // get combat logs regarding this character performed favored skill - it is possible this attack targets multiple targets
                                    var relativeDamageCombatLogs = globalCombatLog.Where(x => x.Assasilant_Character_FK == currChar.Character_PK && x.Skill_FK == FavoredSkill.Skill_PK && x.Action_Order == currAct.Act_Order);

                                    if (FavoredSkill.Skill_Type.Contains("MultiAttack"))
                                    {
                                        // work around when multiattacking to implant last entry into IEnumerable
                                        var lastEntry = globalCombatLog.Last(x => x.Assasilant_Character_FK == currChar.Character_PK && x.Skill_FK == FavoredSkill.Skill_PK && x.Action_Order == currAct.Act_Order);
                                        relativeAttackCombatLogs = globalCombatLog.Where(x => x == lastEntry);
                                    }

                                     // skip this step if skill damage is 0d0+0
                                    if (globalSkills.FirstOrDefault(x => x.Skill_PK == FavoredSkill.Skill_PK).Damage_Roll == "0d0+0") continue;

                                    foreach (var log in relativeDamageCombatLogs)
                                    {
                                        if (log.bAttackSuccessful)
                                        {
                                            List<int> tmpDamageResults = log.tmpDamage_Final_Result;
                                            List<int> tmpDamageValues = new List<int>();
                                            List<string> tmpDamageTypes = log.Damage_Types.Split(',').ToList();
                                            Character target = GetCharacter(log.Target_Character_FK);
                                            Int32 overallDamageResult = 0;

                                            foreach (var dmgRoll in tmpDamageResults)
                                            {
                                                var finalDamageResult = dmgRoll;

                                                logger.WriteLine(DateTime.Now + " SYSTEM inflict damage on target | finalDamageResult:" + dmgRoll + " | Vulnerabilities:[" + target.Vulnerabilities + "] | Resistances:[" + target.Resistances + "] | Immunities:[" + target.Immunities + "] | " + Json.Serialize(target));

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
                                                    if (currChar.Conditions.bDamageBonus)
                                                    {
                                                        foreach (var enchanter in currChar.Conditions.DamageBonus_Enchanters_Character_PK.OrderByDescending(x => x))
                                                        {
                                                            // find relative combat log
                                                            var relativeCombatLog = globalCombatLog.FirstOrDefault(x => x.Target_Character_FK == currChar.Character_PK && x.Assasilant_Character_FK == enchanter);
                                                            // determine how much damage bonus enchanter granted
                                                            Int32 grantedBonusDamage = Int32.Parse(globalSkills.FirstOrDefault(x => x.Skill_PK == relativeCombatLog.Skill_FK).Damage_Roll);

                                                            // buff damage
                                                            finalDamageResult += grantedBonusDamage;

                                                            // record accolades
                                                            UpdateCharacterTrackLog(enchanter, "Blessing_Bonus_Damage", grantedBonusDamage);
                                                        }
                                                        // clear out character bonus damage
                                                        currChar.Conditions.bDamageBonus = false;
                                                        currChar.Conditions.DamageBonus = 0;
                                                        currChar.Conditions.DamageBonus_Enchanters_Character_PK.Clear();
                                                    }

                                                    // skill type inflicts damage
                                                    logger.WriteLine(DateTime.Now + " SYSTEM [" + target.Character_Name + "] taking (" + finalDamageResult + ") damage");

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
                                                            var relativeCombatLog = globalCombatLog.FirstOrDefault(x => x.Target_Character_FK == target.Character_PK && x.Assasilant_Character_FK == enchanter);

                                                            // determine how much shield the enchanter provided
                                                            Int32 shieldAmtGranted = Int32.Parse(globalSkills.FirstOrDefault(x => x.Skill_PK == relativeCombatLog.Skill_FK).Damage_Roll);

                                                            // accumulate how much damage the target has taken prior to this attack
                                                            int previousDamage = globalCombatLog.Where(x => x.Target_Character_FK == target.Character_PK && x.Action_Order < currAct.Act_Order).Sum(x => x.Damage_Final_Result);

                                                            // perform calculations
                                                            tmpAttackDmg -= (shieldAmtGranted - previousDamage);
                                                            if (tmpAttackDmg > 0)
                                                            {
                                                                // shield did not absorb all damage

                                                                UpdateCharacterTrackLog(enchanter, "Blessing_Shield_Absorb", shieldAmtGranted);
                                                                logger.WriteLine(DateTime.Now + " SYSTEM [" + globalCharacters.FirstOrDefault(x => x.Character_PK == enchanter).Character_Name + "] shielded [" + target.Character_Name + "] for " + shieldAmtGranted + " damage");
                                                                target.Conditions.Shield_Enchanters_Character_PK.Remove(enchanter);
                                                            }
                                                            else
                                                            {
                                                                // shield absorbed all damage
                                                                UpdateCharacterTrackLog(enchanter, "Blessing_Shield_Absorb", finalDamageResult);
                                                                logger.WriteLine(DateTime.Now + " SYSTEM [" + globalCharacters.FirstOrDefault(x => x.Character_PK == enchanter).Character_Name + "] shielded [" + target.Character_Name + "] for " + finalDamageResult + " damage");
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
                                                        // target is not shielded, take damage normally
                                                        target.TakeDamage(finalDamageResult);
                                                    }
                                                }
                                                else
                                                {
                                                    // skill type heals health
                                                    logger.WriteLine(DateTime.Now + " SYSTEM [" + target.Character_Name + "] healing (" + finalDamageResult + ") health");
                                                    target.Heal(finalDamageResult);
                                                }

                                                // accumulate overall damage for combat log
                                                overallDamageResult += finalDamageResult;
                                                tmpDamageValues.Add(finalDamageResult);
                                            }

                                            // record overall damage
                                            log.Damage_Final_Result = overallDamageResult;
                                            log.Damage_Values = tmpDamageValues.ToJson();
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

                                                    logger.WriteLine(DateTime.Now + " SYSTEM inflict Affliction(" + affliction + ") on target ");

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
                                                }

                                                // inflict taunt
                                                if (FavoredSkill.Skill_Type == "Taunt")
                                                {
                                                    logger.WriteLine(DateTime.Now + " SYSTEM inflict Taunt on target");
                                                    targetChar.Conditions.bTaunted = true;
                                                    targetChar.Conditions.Taunted_Character_PK = currChar.Character_PK;
                                                    log.Conditions = 8;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case 16:
                                    // 16 - check if skill can perform multiple attacks
                                    if (FavoredSkill.Skill_Type.Contains("MultiAttack"))
                                    {
                                        var relativeCombatLog = globalCombatLog.FirstOrDefault(x => x.Assasilant_Character_FK == currChar.Character_PK && x.Skill_FK == FavoredSkill.Skill_PK);

                                        // perform another turn if attack was successful or attack result equals or exceeds minimum roll required
                                        if(relativeCombatLog.bAttackSuccessful && (relativeCombatLog.Attack_Final_Result > FavoredSkill.Special_Min_Roll || FavoredSkill.Special_Min_Roll == 0))
                                            currTrackStep = 1;

                                        // EXCEPTION
                                        // Cannot perform additional turns if skill type is a single target multi attack and the target has been knocked out
                                        if (FavoredSkill.Skill_Type == "MultiAttack,Single" &&
                                            globalCharacters.FirstOrDefault(
                                                x => x.Character_PK == relativeCombatLog.Target_Character_FK)
                                                .Conditions.bKnockedOut)
                                            currTrackStep = 16;

                                        // remove Taunt if taunted - multi attacks ignore taunts after first attack
                                        currChar.Conditions.bTaunted = false;
                                        currChar.Conditions.Taunted_Character_PK = 0;
                                    }
                                    break;
                                case 17:
                                    // 17 - special character skills
                                    CheckSpecialSkills();
                                    break;
                                #endregion
                            }

                            logger.WriteLine(DateTime.Now + " END TRACK STEP [" + currTrackStep + "] for [" + currChar.Character_Name + "]");
                        }
                        #endregion
                        #region COMBAT LOG MANAGEMENT
                        // push combat log to server
                        #endregion
                        #region ACCOLADE MANAGEMENT
                        logger.WriteLine(DateTime.Now + " SYSTEM Recording character accolades ...");
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
                        logger.WriteLine(DateTime.Now + "  SYSTEM Updating all character energy ...");
                        List<Energy_Consumption> newEnergyValues = globalCombatLog.Select(log => new Energy_Consumption {Character_FK = log.Assasilant_Character_FK, 
                                                                                                                         Campaign_FK = skirmish.Campaign_FK, 
                                                                                                                         Consume_Energy = globalSkills.FirstOrDefault(x => x.Skill_PK == log.Skill_FK).Energy_Cost}).ToList();
                        // UNCOMMENT LATER
                        //controller.UpdateCharacterEnergy(newEnergyValues);
                        #endregion
                    }
                    logger.WriteLine("");
                    logger.WriteLine(DateTime.Now + " END SKIRMISH");

                    logger.WriteLine(DateTime.Now + " SYSTEM End Skirmish Combat Log:");
                    logger.WriteLine(Json.Serialize(globalCombatLog));

                    logger.WriteLine(DateTime.Now + " SYSTEM End Skirmish State of all characters:");
                    logger.WriteLine(Json.Serialize(globalCharacters));

                    logger.WriteLine(DateTime.Now + " SYSTEM End Skirmish accolade tracker:");
                    logger.WriteLine(Json.Serialize(globalCharacterTrackLog));

                    logger.Close();
                }

                //Show success
                this.ScheduleHistoryItem.Succeeded = true;
            }
            catch (Exception ex)
            {
                this.ScheduleHistoryItem.Succeeded = false;
                this.ScheduleHistoryItem.AddLogNote("ERROR: " + ex.Message);
                logger.WriteLine(DateTime.Now + " CRITICAL ERROR: " + ex.Message);
                logger.Close();
                this.Errored(ref ex);
                DotNetNuke.Services.Exceptions.Exceptions.LogException(ex);
            }
        }

        public Character GetCharacter(int Character_PK)
        {
            return globalCharacters.FirstOrDefault(x => x.Character_PK == Character_PK);
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
            Character skillOwner = globalCharacters.FirstOrDefault(x => x.Character_PK == currSkill.Preparer_Character_FK);

            // ensure skillOwner is not Stunned or KnockedOut
            if (skillOwner.Conditions.bStunned || skillOwner.Conditions.bKnockedOut) return;

            logger.WriteLine(DateTime.Now + " SYSTEM INTERRUPT [" + skillOwner.Character_Name + "] interupts with [" + globalSkills.FirstOrDefault(x => x.Skill_PK == currSkill.Skill_PK).Skill_Name + "]");

            // hardcoded operations for special skills
            switch (currSkill.Skill_PK)
            {
                case 1:
                    #region Paladin's Protection
                    // Redirect 2 damage from all attack actions performed against each ally to this character
                    foreach (var target in _GAMESTATE.Pending_Targets.Where(x => x.Guild_FK == skillOwner.Guild_FK &&
                                                                                 x.Character_PK != skillOwner.Character_PK))
                    {
                        var ally = target; // declared because of loop closure
                        foreach (
                            var relativeLog in
                                globalCombatLog.Where(x =>
                                        x.Target_Character_FK == ally.Character_PK &&
                                        x.Assasilant_Character_FK == _GAMESTATE.Active_Character.Character_PK))
                        {
                            var damageDealt = 0;
                            if (relativeLog.Damage_Final_Result > 2)
                            {
                                damageDealt = 2;
                                relativeLog.Damage_Final_Result -= damageDealt;
                            }
                            else
                            {
                                damageDealt = 1;
                                relativeLog.Damage_Final_Result -= damageDealt;
                                if (relativeLog.Damage_Final_Result < 0) relativeLog.Damage_Final_Result = 0;
                            }

                            logger.WriteLine(DateTime.Now + " SYSTEM [" + skillOwner.Character_Name + "] taking (" + damageDealt + ") damage");
                            skillOwner.TakeDamage(damageDealt);

                            globalCombatLog.Add(new Combat_Log()
                            {
                                Action_Order = relativeLog.Action_Order,
                                Assasilant_Character_FK = _GAMESTATE.Active_Character.Character_PK,
                                Attack_Final_Result = 0,
                                Attack_Values = "",
                                bAttackSuccessful = true,
                                bInterrupt = true,
                                Conditions = -1,
                                Damage_Final_Result = damageDealt,
                                Damage_Values = damageDealt.ToString(),
                                Damage_Types = "Physical"
                            });
                        }
                    }
                    #endregion
                    break;
                case 13:
                    #region Divine Blessing
                    // At the beginning of your turn, heal all characters on your team by 2 Health
                    foreach (var target in _GAMESTATE.Pending_Targets.Where(x => x.Guild_FK == skillOwner.Guild_FK &&
                                                                                 !x.Conditions.bKnockedOut))
                    {
                        var ally = target; // declared because of loop closure

                        logger.WriteLine(DateTime.Now + " SYSTEM [" + skillOwner.Character_Name + "] heals [" + ally.Character_Name + "] for (2) Health");
                        ally.Heal(2);

                        globalCombatLog.Add(new Combat_Log()
                        {
                            Action_Order = _GAMESTATE.Current_Act_Order,
                            Assasilant_Character_FK = skillOwner.Character_PK,
                            Attack_Final_Result = 0,
                            Attack_Values = "",
                            bAttackSuccessful = true,
                            bInterrupt = true,
                            Conditions = -1,
                            Damage_Final_Result = 2,
                            Damage_Values = "2",
                            Damage_Types = "Healing"
                        });
                    }
                    #endregion
                    break;
                case 17:
                    // Luck
                    break;
                case 21:
                    // Holy Cure
                    break;
                case 25:
                    // Physical Buffer
                    break;
                case 29:
                    // Agile
                    break;
                case 37:
                    // Blessed Blood
                    break;
                case 47:
                    // Take Action
                    break;
                case 56:
                    // Cloak of the Arcane
                    break;
                case 62:
                    // Radiant Shroud
                    break;
                case 70:
                    // Formless
                    break;
                case 74:
                    // Phylactery Vamp
                    break;
                case 81:
                    // Bodily Regeneration
                    break;
                case 85:
                    // 360 Defense
                    break;
                case 88: 
                    // Ethereal
                    break;
                case 95:
                    // Undead Aura
                    break;
                case 99:
                    // Nauseous Innards
                    break;
                case 103:
                    // Feed The Graves
                    break;
                case 110:
                    // Vampiric Aura
                    break;
                case 114:
                    // We Are Many
                    break;
                case 118:
                    // Purity Scent
                    break;
                case 126:
                    // Parry
                    break;
                case 130:
                    // Cognizant Insight
                    break;
                case 135:
                    // Take Flight
                    break;
                case 144:
                    // Ent Summoning
                    break;
                case 149:
                    // Spirit of the Forest
                    break;
                case 158:
                    // Deep Wounds
                    break;
                case 159:
                    // Shapeshift
                    break;
                case 164:
                    // Camouflage
                    break;
                case 168:
                    // Forgetful
                    break;
                case 173:
                    // Rock Form
                    break;
                case 175:
                    // Goading Hammer Strike
                    break;
                case 177:
                    // Hungry Wildlife
                    break;
                case 182:
                    // Rock Form
                    break;
                case 183:
                    // Crumbling State
                    break;
                case 189:
                    // Small Form
                    break;
                case 193:
                    // Wolf Companion
                    break;
                case 194:
                    // Headshot
                    break;
                case 197:
                    // Ethereal Existence
                    break;
                case 207:
                    // Charging Up
                    break;
                case 211:
                    // Hot Touch
                    break;
                case 231:
                    // Speed Demon
                    break;
                case 235:
                    // Dung Collector
                    break;
                case 239:
                    // Auto Target
                    break;
                case 253:
                    // New Appendages
                    break;
            }
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
                case "Afflictions_Inflicted":
                    updateLog.Afflictions_Inflicted += inVal * accoladePointWorth;
                    break;
                case "Initiative_Acted_First":
                    updateLog.Initiative_Acted_First += inVal * accoladePointWorth;
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