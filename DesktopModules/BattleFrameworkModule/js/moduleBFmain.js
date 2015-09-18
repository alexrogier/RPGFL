$(document).ready(function () {
    // **** SETUP SKIRMISH ****
    // get skirmishpk from url paramter
    skirmishId = getUrlParameter("skirmishid");
    getSkirmishData(skirmishId);
    populateSkirmishData();

    // **** SETUP CHARACTERS ****
    getAllCharacterDataInSkirmish();

    // **** SETUP COMBAT LOG ****
    getCombatLogData();

    // **** SETUP SKILLS ****
    getSkillDataFromSkirmishCharacters();
});

/****************************************************************************************************
    BEGIN Global Interface 
****************************************************************************************************/
// **** CHARACTER MANAGEMENT ****

// character interface
function character(charData){
    this.Character_PK = charData.Character_PK;
    this.Character_Name = charData.Character_Name;
    this.Title_Desc = charData.Title_Desc;
    this.Health = charData.Health;
    this.Dodge = charData.Dodge;
    this.Archetype = charData.Archetype;
    this.Finesse = charData.Finesse;
    this.Agility = charData.Agility;
    this.Senses = charData.Senses;
    this.Mana = charData.Mana;
    this.Immunities = charData.Immunities;
    this.Vulnerabilities = charData.Vulnerabilities;
    this.Resistances = charData.Resistances;
    this.Guild_FK = charData.Guild_FK;
    this.Initiative = charData.Initiative;
    this.Max_Energy = charData.Max_Energy;
}
var globalCharactersInSkirmish = []; // character warehouse to store all characters who are in skirmish
// character methods
function addCharacterToSkirmish(charData) {
    globalCharactersInSkirmish.push(new character(charData));
}
function getCharacterById(charId) {
    // search globalCharactersInSkirmish for matching charpk and return it as a character object
    for (var char in globalCharactersInSkirmish) {
        if (char.Character_PK == charId) return char;
    }

    return null;
}
// character ajax handlers
function getAllCharacterDataInSkirmish() {
    var characterData = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/BattleFrameworkModule/API/ModuleBattleFramework/GetAllCharacterDataInSkirmish",
        data: {
            Skirmish_PK: globalSkirmish.Skirmish_PK
        },
        dataType: "json",
        success: function (data) {
            characterData = JSON.parse(data);
        }
    });

    // add each character returned to the skirmish
    for (var i = 0; i < characterData.length; i++) {
        addCharacterToSkirmish(characterData[i]);
    }
}

// **** SKIRMISH MANAGEMENT ****

// skirmish interface
function skirmish(skirmishData) {
    this.Skirmish_PK = skirmishData[0].Skirmish_PK;
    this.Skirmish_Date = new Date(skirmishData[0].Skirmish_Date).toDateString("yyyy-mm-dd");
    this.Campaign_FK = skirmishData[0].Campaign_FK;
    this.Guild_1_FK = skirmishData[0].Guild_1_FK;
    this.Guild_2_FK = skirmishData[0].Guild_2_FK;
    this.Guild_1_Accolade_Points = skirmishData[0].Guild_1_Accolade_Points;
    this.Guild_2_Accolade_Points = skirmishData[0].Guild_2_Accolade_Points;
    this.Skirmish_Victor_FK = skirmishData[0].Skirmish_Victor_FK;
    this.Series_FK = skirmishData[0].Series_FK;
}
var globalSkirmish; // holds data regarding this skirmish
// skirmish methods
function populateSkirmishData() {
    $("#guild_1_logo").attr("src", _GETGUILDLOGO(globalSkirmish.Guild_1_FK));
    $("#guild_2_logo").attr("src", _GETGUILDLOGO(globalSkirmish.Guild_2_FK));
    $("#skirmish_date").text(globalSkirmish.Skirmish_Date);
}
function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
}
// skirmish ajax handlers
function getSkirmishData(skirmishPK){
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/BattleFrameworkModule/API/ModuleBattleFramework/GetSkirmishData",
        data: {
            Skirmish_PK: skirmishPK
        },
        dataType: "json",
        success: function (data) {       
            globalSkirmish = new skirmish(JSON.parse(data));
        }
    });
}

// **** COMBATLOG MANAGEMENT ****

// combatlog interface
function combatlog(logData) {
    this.CombatLog_PK = logData.CombatLog_PK;
    this.Skirmish_FK = logData.Skirmish_FK;
    this.Assassilant_Character_FK = logData.Assassilant_Character_FK;
    this.Target_Character_FK = logData.Target_Character_FK;
    this.Skill_FK = logData.Skill_FK;
    this.Action_Order = logData.Action_Order;
    this.Attack_Final_Result = logData.Attack_Final_Result;
    this.Attack_Values = logData.Attack_Values;
    this.Damage_Final_Result = logData.Damage_Final_Result;
    this.Damage_Values = logData.Damage_Values;
    this.Damage_Types = logData.Damage_Types;
    this.Conditions = logData.Conditions;
}
var globalCombatLog = []; // combatlog warehouse that contains all the actions to display during the skirmish
// combatlog methods
function addCombatLogEntry(logData) {
    globalCombatLog.push(new combatlog(logData));
}
// combatlog ajax handlers
function getCombatLogData() {
    var combatlogData = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/BattleFrameworkModule/API/ModuleBattleFramework/GetCombatLogData",
        data: {
            Skirmish_PK: globalSkirmish.Skirmish_PK
        },
        dataType: "json",
        success: function (data) {
            combatlogData = JSON.parse(data);
        }
    });

    // add each combatlog entry to the global combat log. SQL has already sorted action order
    for (var i = 0; i < combatlogData.length; i++) {
        addCombatLogEntry(combatlogData[i]);
    }
}

// **** SKILL MANAGEMENT ****

// skill interface
function skill(skillData) {
    this.Skill_PK = skillData.Skill_PK;
    this.Skill_Name = skillData.Skill_Name;
    this.Skill_Description = skillData.Skill_Description;
    this.Energy_Cost = skillData.Energy_Cost;
    this.Attribute_FK = skillData.Attribute_FK;
    this.bIsPassive = skillData.bIsPassive;
}
var globalSkills = []; // skill warehouse that contains all skills each character in this skirmish can perform
// skill methods
function addSkillData(skillData) {
    globalSkills.push(new skill(skillData));
}
function getSkillById(skillid) {
    // search globalSkills for matching skillpk and return it as a skill object
    for (var skill in globalSkills) {
        if (skill.Skill_PK == skillId) return skill;
    }

    return null;
}
// skill ajax handlers
function getSkillDataFromSkirmishCharacters() {
    var skillData = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/BattleFrameworkModule/API/ModuleBattleFramework/GetSkillDataFromSkirmishCharacters",
        data: {
            Skirmish_PK: globalSkirmish.Skirmish_PK
        },
        dataType: "json",
        success: function (data) {
            skillData = JSON.parse(data);
        }
    });

    // add each combatlog entry to the global combat log. SQL has already sorted action order
    for (var i = 0; i < skillData.length; i++) {
        addSkillData(skillData[i]);
    }
}

// **** BATTLEFRAMEWORK MANAGEMENT ****

// battleframework interface
var currentActionStep = 0; // keep track of where the battle is according to the combat log
var lastActionStep = globalCombatLog[globalCombatLog.length - 1].Action_Order;
var actionWaitInterval = 3; // amount of seconds to wait between executing each action step
// battleframework methods
function nextActionStep() {
    // advance the actionstep order by 1
    currentActionStep++;
}
/****************************************************************************************************
    END Global Interface 
****************************************************************************************************/

/****************************************************************************************************
    DICE ROLLING 
****************************************************************************************************/
function rollDice(numOfDice, diceType, baseModifier, bAdvDis) {
// COMMENTED BECAUSE CODE BELONGS IN BACK END

//    // @numOfDice: number of dice to roll 
//    // @diceType: what sided die to roll (d4, d6, d8, d10, d12, d20) as an INT value
//    // @baseModifier: modifier to be added to the final result after all rolls. Default 0
//    // @bAdvDis: boolean to determine whether to roll dice with advantage or disadvantage. Default None
//    // Description
//    // Random number generator that mimics the process of rolling physical dice and returns the result as an object

//    var finalResult = {
//        totalValue: 0,      // final accumulation value of all dice rolls
//        rollResults: []     // storage array that contains each individual dice roll
//    };

//    // roll dice
//    for (var i = 1; i <= numOfDice; i++) {
//        switch (bAdvDis) {
//            case undefined:
//                // neither advantage or disadvantage
//                var roll = Math.round(Math.random() * (diceType - 1) + 1);
//                finalResult.totalValue += roll;
//                finalResult.rollResults.push(roll);
//                break;
//            case 'advantage':
//                // roll two dice and record the higher value
//                var roll1 = Math.round(Math.random() * (diceType - 1) + 1);
//                var roll2 = Math.round(Math.random() * (diceType - 1) + 1);
//                var betterRoll = (roll1 > roll2 ? roll1 : roll2);
//                finalResult.totalValue += betterRoll;
//                finalResult.rollResults.push(betterRoll);
//                break;
//            case 'disadvantage':
//                // roll two dice and record the lower value
//                var roll1 = Math.round(Math.random() * (diceType - 1) + 1);
//                var roll2 = Math.round(Math.random() * (diceType - 1) + 1);
//                var worseRoll = (roll1 < roll2 ? roll1 : roll2);
//                finalResult.totalValue += worseRoll;
//                finalResult.rollResults.push(worseRoll);
//                break;
//        }
//    }

//    // add base modifiers
//    if (typeof baseModifier === 'undefined') baseModifier = 0;
//    finalResult.totalValue += baseModifier;

//    return finalResult;
}
function bCritical(roll, critMin) {
    // @roll: a singular dice roll to determine if it is a critical success or failure
    // @critMin: lowest roll result to achieve a critical success on a d20. Default 20
    // Description
    // Determines whether a dice roll was a critical success or failure. Will return a -1 if neither are achieved, 1 if a
    // a critical success was achieved, and 0 if a critical failure was achieved. This function should only be used when rolling
    // a single d20

    var finalResult = -1;
    if (typeof critMin === 'undefined') critMin = 20;

    if (roll >= critMin) 
    { 
        finalResult = 1; 
    } 
    else if(roll == 1){
        finalResult = 0;
    }

    return finalResult;
}