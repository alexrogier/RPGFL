$(document).ready(function () {
    // **** SETUP SKIRMISH ****
    // get skirmishpk from url paramter
    var skirmishId = getUrlParameter("skirmishid");
    getSkirmishData(skirmishId);
    populateSkirmishData();

    if (globalSkirmish.Skirmish_Victor_FK == -1 && new Date(globalSkirmish.Skirmish_Date) > new Date()) {
        // future skirmish
        $('#battleskirmish').empty();
        $('#battleskirmish').append('<p class="text-center">Sorry, this skirmish is not ready for voting. Please check back later.</p>');
        return;
    }
    // **** SETUP CHARACTERS ****
    getAllCharacterDataInSkirmish();

    // **** SETUP SKILLS ****
    getSkillDataFromSkirmishCharacters();

    // **** SETUP GUILDS ****
    getGuildData();
    populateGuilds();

    // **** SETUP COMBAT LOG ****
    getCombatLogData();
    
    // **** SETUP ACCOLADE MANAGEMENT **** 
    globalAccoladeManager = accoladeManager();
    getAccoladeData();

    if (globalSkirmish.Skirmish_Victor_FK != -1) {
        // **** BEGIN SKIRMISH ****
        var trackManager = new turnTrackManager();
        trackManager.buildDisplayQueue();
        showDisplayQueue(trackManager);
    } else {
        // start voting
        getInitiativeData(globalSkirmish.Skirmish_PK);

        // **** SETUP VOTE DATA ****
        getUserVoteData();
        getUserCharacters();

        populateActionStep();
    }
});

/****************************************************************************************************
    BEGIN Global Interface 
****************************************************************************************************/
// **** CHARACTER MANAGEMENT ****

// character interface
function character(charData) {
    this.Character_PK = charData.Character_PK;
    this.Character_Name = charData.Character_Name;
    this.Title_Desc = charData.Title_Desc;
    this.Health = charData.Health;
    this.Max_Health = charData.Health;
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
    this.bVote = false;
    this.Conditions = {
        bTaunted: false,
        bAfflicted: false,
        bBlessed: false,
        bCharmed: false,
        bBlinded: false,
        bInvisible: false,
        bKnockedOut: false,
        bGuarded: false,
        bStunned: false
    };
    this.takeDamage = function (damage) {
        this.Health -= damage;

        if (this.Health < 0) this.Health = 0;
        if (this.Health == 0) {
            this.recieveCondition("Knocked_Out");
            this.removeCondition("Taunted");
            this.removeCondition("Blessed");
            this.removeCondition("Charmed");
            this.removeCondition("Blinded");
            this.removeCondition("Invisible");
            this.removeCondition("Guarded");
            this.removeCondition("Stunned");
        }

        var charMapIndex = globalCharactersToMap.indexOf(this.Character_PK) + 1;
        if (charMapIndex > 12) charMapIndex -= 12;

        $("#guild_" + (this.Guild_FK == globalSkirmish.Guild_1_FK ? 1 : 2) + "_char_" + charMapIndex + "_healthbar").css("width", (this.Health / this.Max_Health) * 64);
        $("#guild_" + (this.Guild_FK == globalSkirmish.Guild_1_FK ? 1 : 2) + "_char_" + charMapIndex + "_healthtext").text(this.Health + " / " + this.Max_Health);
        // damage dealing visual affects here

        // IMAGE RUMBLE - causes horrible browser performance
        //var animTime = 100,
        //    rotateDeg = 10;
        //$({ deg: 0 }).animate({ deg: rotateDeg }, {
        //    duration: animTime,
        //    step: function (now) {
        //        $("#guild_" + (this.Guild_FK == globalSkirmish.Guild_1_FK ? 1 : 2) + "_char_" + charMapIndex).css({
        //            transform: 'rotate(' + now + 'deg)'
        //        });
        //    }, done: function () {
        //        $({ deg: 0 }).animate({ deg: -rotateDeg }, {
        //            duration: animTime,
        //            step: function (now) {
        //                $("#guild_" + (this.Guild_FK == globalSkirmish.Guild_1_FK ? 1 : 2) + "_char_" + charMapIndex).css({
        //                    transform: 'rotate(' + now + 'deg)'
        //                });
        //            }, done: function () {
        //                $("#guild_" + (this.Guild_FK == globalSkirmish.Guild_1_FK ? 1 : 2) + "_char_" + charMapIndex).css({
        //                    transform: 'rotate(0deg)'
        //                });
        //            }
        //        });
        //    }
        //});
    };
    this.healDamage = function (damage) {
        this.Health += damage;

        if (this.Health > this.Max_Health) {
            this.Health = this.Max_Health;
        }

        var charMapIndex = globalCharactersToMap.indexOf(this.Character_PK) + 1;
        if (charMapIndex > 12) charMapIndex -= 12;

        $("#guild_" + (this.Guild_FK == globalSkirmish.Guild_1_FK ? 1 : 2) + "_char_" + charMapIndex + "_healthbar").css("width", (this.Health / this.Max_Health) * 64);
        $("#guild_" + (this.Guild_FK == globalSkirmish.Guild_1_FK ? 1 : 2) + "_char_" + charMapIndex + "_healthtext").text(this.Health + " / " + this.Max_Health);
        // healing visual affects here
    };
    this.getCharMapSlot = function () {
        var charMapIndex = globalCharactersToMap.indexOf(this.Character_PK) + 1;
        if (charMapIndex > 12) charMapIndex -= 12;

        return "#guild_" + (this.Guild_FK == globalSkirmish.Guild_1_FK ? 1 : 2) + "_char_" + charMapIndex;
    };
    this.populateConditions = function () {
        //reset status bar
        $(this.getCharMapSlot() + '_statusbar').empty();
        //Do they have more than 3 conditions?

        //populate with current conditions
        var tauntedHTML = '<img src="/Portals/0/RPGFL/battle_icons/condition_taunted.png" />';
        var afflictedHTML = '<img src="/Portals/0/RPGFL/battle_icons/condition_afflicted.png" />';
        var blessedHTML = '<img src="/Portals/0/RPGFL/battle_icons/condition_blessed.png" />';
        var charmedHTML = '<img src="/Portals/0/RPGFL/battle_icons/condition_charmed.png" />';
        var blindedHTML = '<img src="/Portals/0/RPGFL/battle_icons/condition_blinded.png" />';
        var invisibleHTML = '<img src="/Portals/0/RPGFL/battle_icons/condition_invisible.png" />';
        var guardedHTML = '<img src="/Portals/0/RPGFL/battle_icons/condition_guarded.png" />';
        var stunnedHTML = '<img src="/Portals/0/RPGFL/battle_icons/condition_stunned.png" />';
        var elipseHTML = '<img src="/Portals/0/RPGFL/battle_icons/condition_elipse.png" />';
        var numOfConditions = 0;
        var bUseElipse = (this.numOfConditions() >= 4);
        var conditions = ['Afflicted', 'Blessed', 'Taunted', 'Charmed', 'Blinded', 'Invisible', 'Guarded', 'Stunned'];


        for (var i = 0; i < conditions.length; i++) {
            switch (conditions[i]) {
                case 'Afflicted':
                    if (this.Conditions.bAfflicted) {
                        numOfConditions++;
                        $(this.getCharMapSlot() + '_statusbar').append(afflictedHTML);
                    }
                    break;
                case 'Blessed':
                    if (this.Conditions.bBlessed) {
                        numOfConditions++;
                        $(this.getCharMapSlot() + '_statusbar').append(blessedHTML);
                    }
                    break;
                case 'Taunted':
                    if (this.Conditions.bTaunted) {
                        numOfConditions++;
                        if (numOfConditions == 3 && bUseElipse) {
                            $(this.getCharMapSlot() + '_statusbar').append(elipseHTML);
                            //append nature of condition in text form
                        } else {
                            if (numOfConditions < 4) {
                                $(this.getCharMapSlot() + '_statusbar').append(tauntedHTML);
                            } else {
                                //append nature of condition in text form
                            }
                        }
                    }
                    break;
                case 'Charmed':
                    if (this.Conditions.bCharmed) {
                        numOfConditions++;
                        if (numOfConditions == 3 && bUseElipse) {
                            $(this.getCharMapSlot() + '_statusbar').append(elipseHTML);
                            //append nature of condition in text form
                        } else {
                            if (numOfConditions < 4) {
                                $(this.getCharMapSlot() + '_statusbar').append(charmedHTML);
                            } else {
                                //append nature of condition in text form
                            }
                        }
                    }
                    break;
                case 'Blinded':
                    if (this.Conditions.bBlinded) {
                        numOfConditions++;
                        if (numOfConditions == 3 && bUseElipse) {
                            $(this.getCharMapSlot() + '_statusbar').append(elipseHTML);
                            //append nature of condition in text form
                        } else {
                            if (numOfConditions < 4) {
                                $(this.getCharMapSlot() + '_statusbar').append(blindedHTML);
                            } else {
                                //append nature of condition in text form
                            }
                        }
                    }
                    break;
                case 'Invisible':
                    if (this.Conditions.bInvisible) {
                        numOfConditions++;
                        if (numOfConditions == 3 && bUseElipse) {
                            $(this.getCharMapSlot() + '_statusbar').append(elipseHTML);
                            //append nature of condition in text form
                        } else {
                            if (numOfConditions < 4) {
                                $(this.getCharMapSlot() + '_statusbar').append(invisibleHTML);
                            } else {
                                //append nature of condition in text form
                            }
                        }
                    }
                    break;
                case 'Guarded':
                    if (this.Conditions.bGuarded) {
                        numOfConditions++;
                        if (numOfConditions == 3 && bUseElipse) {
                            $(this.getCharMapSlot() + '_statusbar').append(elipseHTML);
                            //append nature of condition in text form
                        } else {
                            if (numOfConditions < 4) {
                                $(this.getCharMapSlot() + '_statusbar').append(guardedHTML);
                            } else {
                                //append nature of condition in text form
                            }
                        }
                    }
                    break;
                case 'Stunned':
                    if (this.Conditions.bStunned) {
                        numOfConditions++;
                        if (numOfConditions == 3 && bUseElipse) {
                            $(this.getCharMapSlot() + '_statusbar').append(elipseHTML);
                            //append nature of condition in text form
                        } else {
                            if (numOfConditions < 4) {
                                $(this.getCharMapSlot() + '_statusbar').append(stunnedHTML);
                            } else {
                                //append nature of condition in text form
                            }
                        }
                    }
                    break;
            }
        }
        if (this.Conditions.bKnockedOut) {
            // grey out character picture here
        }
    };
    this.recieveCondition = function (condition) {
        switch (condition) {
            case "Afflicted":
                this.Conditions.bAfflicted = true;
                break;
            case "Blessed":
                this.Conditions.bBlessed = true;
                break;
            case "Taunted":
                this.Conditions.bTaunted = true;
                break;
            case "Charmed":
                this.Conditions.bCharmed = true;
                break;
            case "Blinded":
                this.Conditions.bBlinded = true;
                break;
            case "Invisible":
                this.Conditions.bInvisible = true;
                break;
            case "Guarded":
                this.Conditions.bGuarded = true;
                break;
            case "Stunned":
                this.Conditions.bStunned = true;
                break;
            case "Knocked_Out":
                this.Conditions.bKnockedOut = true;
                $(this.getCharMapSlot()).addClass("knockedout");
                break;
        }
        this.populateConditions();
    };
    this.removeCondition = function (condition) {
        switch (condition) {
            case "Afflicted":
                this.Conditions.bAfflicted = false;
                break;
            case "Blessed":
                this.Conditions.bBlessed = false;
                break;
            case "Taunted":
                this.Conditions.bTaunted = false;
                break;
            case "Charmed":
                this.Conditions.bCharmed = false;
                break;
            case "Blinded":
                this.Conditions.bBlinded = false;
                break;
            case "Invisible":
                this.Conditions.bInvisible = false;
                break;
            case "Guarded":
                this.Conditions.bGuarded = false;
                break;
            case "Stunned":
                this.Conditions.bStunned = false;
                break;
            case "Knocked_Out":
                this.Conditions.bKnockedOut = false;
                break;
        }
        this.populateConditions();
    };
    this.numOfConditions = function () {
        var numConditions = 0;

        if (this.Conditions.bTaunted) numConditions++;
        if (this.Conditions.bAfflicted) numConditions++;
        if (this.Conditions.bBlessed) numConditions++;
        if (this.Conditions.bCharmed) numConditions++;
        if (this.Conditions.bBlinded) numConditions++;
        if (this.Conditions.bInvisible) numConditions++;
        if (this.Conditions.bGuarded) numConditions++;
        if (this.Conditions.bStunned) numConditions++;

        return numConditions;
    };
    return this;
}
var globalCharactersInSkirmish = []; // character warehouse to store all characters who are in skirmish
var globalCharactersToMap = []; // indexed list to map where characters are displayed on the page
// character methods
function addCharacterToSkirmish(charData) {
    globalCharactersInSkirmish.push(new character(charData));
}
function addCharactersToMap(charData) {
    for (var i = 0; i < charData.length; i++) {
        var currChar = charData[i];
        globalCharactersToMap.push(currChar.Character_PK);
        var guildSlot = (currChar.Guild_FK == globalSkirmish.Guild_1_FK ? 1 : 2);
        // set character health
        $("#guild_" + guildSlot + "_char_" + (i <= 11 ? (i + 1) : (i + 1) - 12) + "_healthtext").text(currChar.Health + " / " + currChar.Health);


        // initiate character modal
        var img = $("#guild_" + guildSlot + "_char_" + (i <= 11 ? (i + 1) : (i + 1) - 12));
        img.attr("src", _GETCHARACTERICON(currChar.Character_Name));
        document.getElementById($(img).attr("id")).setAttribute("data-charpk", currChar.Character_PK);
        img.attr("rel", "popover");
        img.attr("data-content", "<strong>" + currChar.Character_Name + "</strong><br/><em>" + currChar.Archetype + "</em>");
        img.attr("data-trigger", "hover");
        img.attr("data-placement", "top");
        img.attr("data-html", "true");
        img.attr("data-toggle", "modal");
        img.attr("data-target", "#characterPreviewModal");
    }

    // character modal handler
    $(".char_img").click(function () {
        _GETCHARACTERDATA(this.getAttribute("data-charpk"));
    });

    // initialize character image tooltip
    $(".char_img").popover();
}
function getCharacterById(charId) {
    // search globalCharactersInSkirmish for matching charpk and return it as a character object
    for (var i = 0; i < globalCharactersInSkirmish.length; i++) {
        if (globalCharactersInSkirmish[i].Character_PK == charId) {
            return globalCharactersInSkirmish[i];
        }
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

    addCharactersToMap(characterData);
}

// **** SKIRMISH MANAGEMENT ****

// skirmish interface
function skirmish(skirmishData) {
    this.Skirmish_PK = skirmishData[0].Skirmish_PK;
    this.Skirmish_Date = new Date(skirmishData[0].Skirmish_Date);
    this.Campaign_FK = skirmishData[0].Campaign_FK;
    this.Guild_1_FK = skirmishData[0].Guild_1_FK;
    this.Guild_2_FK = skirmishData[0].Guild_2_FK;
    this.Guild_1_Accolade_Points = skirmishData[0].Guild_1_Accolade_Points;
    this.Guild_2_Accolade_Points = skirmishData[0].Guild_2_Accolade_Points;
    this.Skirmish_Victor_FK = skirmishData[0].Skirmish_Victor_FK;
    this.Series_FK = skirmishData[0].Series_FK;
}
var globalSkirmish; // holds data regarding this skirmish
var globalInitative;
// skirmish methods
function populateSkirmishData() {
    $("#skirmish_date").text(globalSkirmish.Skirmish_Date.toDateString("yyyy-mm-dd"));
}
function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split("&"),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split("=");

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
}
function populateActionStep() {
    for (var i = 0; i < globalInitative.length; i++) {
        var actionStep = globalInitative[i];
        $(getCharacterById(actionStep.Character_FK).getCharMapSlot() + "_activeicon_left").append("<p>" + actionStep.Act_Order + "</p>");
    }
}
// skirmish ajax handlers
function getSkirmishData(skirmishPK) {
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
function getInitiativeData() {
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/BattleFrameworkModule/API/ModuleBattleFramework/GetInitiativeTrackFromSkirmish",
        data: {
            Skirmish_PK: globalSkirmish.Skirmish_PK
        },
        dataType: "json",
        success: function (data) {
            globalInitative = JSON.parse(data);
        }
    });
}

// **** GUILD MANAGEMENT ****

// guild interface
function guild(guildData) {
    this.Guild_PK = guildData[0].Guild_PK;
    this.Guild_Name = guildData[0].Guild_Name;
}
var globalGuilds; // holds data regarding all guilds
// guild methods
function getGuildById(guildId) {
    for (var i = 0; i < globalGuilds.length; i++) {
        if (globalGuilds[i].Guild_PK == guildId) {
            return globalGuilds[i];
        }
    }
    return null;
}
function populateGuilds() {
    $("#guild_1_name").text(getGuildById(globalSkirmish.Guild_1_FK).Guild_Name);
    $("#guild_2_name").text(getGuildById(globalSkirmish.Guild_2_FK).Guild_Name);
    $("#guild_1_logo").attr("src", _GETGUILDLOGO(globalSkirmish.Guild_1_FK));
    $("#guild_2_logo").attr("src", _GETGUILDLOGO(globalSkirmish.Guild_2_FK));
}
// guild ajax handlers
function getGuildData() {
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/BattleFrameworkModule/API/ModuleBattleFramework/GetAllGuilds",
        data: {},
        dataType: "json",
        success: function (data) {
            globalGuilds = JSON.parse(data);
        }
    });
}

// **** COMBATLOG MANAGEMENT ****

// combatlog interface
function combatlog(logData) {
    this.CombatLog_PK = logData.CombatLog_PK;
    this.Skirmish_FK = logData.Skirmish_FK;
    this.Assailant_Character_FK = logData.Assailant_Character_FK;
    this.Target_Character_FK = logData.Target_Character_FK;
    this.Skill_FK = logData.Skill_FK;
    this.Action_Order = logData.Action_Order;
    this.Attack_Final_Result = logData.Attack_Final_Result;
    this.Attack_Values = logData.Attack_Values;
    this.Damage_Final_Result = logData.Damage_Final_Result;
    this.Damage_Values = logData.Damage_Values;
    this.Damage_Types = logData.Damage_Types;
    this.Conditions = logData.Conditions;
    this.bAttackSuccessful = logData.bAttackSuccessful;
    this.bInterrupt = logData.bInterrupt;
}
var globalCombatLog = []; // combatlog warehouse that contains all the actions to display during the skirmish
// combatlog methods
function addCombatLogEntry(logData) {
    globalCombatLog.push(new combatlog(logData));
}
function getCombatLogById(logId) {
    for (var i = 0; i < globalCombatLog.length; i++) {
        if (globalCombatLog[i].CombatLog_PK == logId) {
            return globalCombatLog[i];
        }
    }
    return null;
}
// combatlog ajax handlers
function getCombatLogData() {
    var combatLogData = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/BattleFrameworkModule/API/ModuleBattleFramework/GetCombatLogData",
        data: {
            Skirmish_PK: globalSkirmish.Skirmish_PK
        },
        dataType: "json",
        success: function (data) {
            combatLogData = JSON.parse(data);
        }
    });

    // add each combatlog entry to the global combat log. SQL has already sorted action order
    for (var i = 0; i < combatLogData.length; i++) {
        addCombatLogEntry(combatLogData[i]);
    }
}

// **** SKILL MANAGEMENT ****

// skill interface
function skill(skillData) {
    this.Skill_PK = skillData.Skill_PK;
    this.Character_FK = skillData.Character_FK;
    this.Skill_Name = skillData.Skill_Name;
    this.Skill_Description = skillData.Skill_Description;
    this.Energy_Cost = skillData.Energy_Cost;
    this.Attribute_FK = skillData.Attribute_FK;
    this.bIsPassive = skillData.bIsPassive;
    this.Damage_Roll = skillData.Damage_Roll;
    this.Damage_Types = skillData.Damage_Types;
    this.Skill_Type = skillData.Skill_Type;
    this.Max_Targets = skillData.Max_Targets;
    this.bAutoSuccess = skillData.bAutoSuccess;
    this.Special_Min_Roll = skillData.Special_Min_Roll;
    this.Exec_Track_Step = skillData.Exec_Track_Step;
}
var globalSkills = []; // skill warehouse that contains all skills each character in this skirmish can perform
// skill methods
function addSkillData(skillData) {
    globalSkills.push(new skill(skillData));
}
function getSkillById(skillId) {
    // search globalSkills for matching skillpk and return it as a skill object
    for (var i = 0; i < globalSkills.length; i++) {
        if (globalSkills[i].Skill_PK == skillId) return globalSkills[i];
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
var actionWaitInterval = 100; // amount of miliseconds to wait between executing each action step
var currActionStep = 0; // tracks current action step
// battleframework methods
function getRelevantCombatLogs(actionOrder) {
    var relevantLogs = [];

    for (var i = 0; i < globalCombatLog.length; i++) {
        if (globalCombatLog[i].Action_Order == actionOrder) relevantLogs.push(globalCombatLog[i]);
    }

    return relevantLogs;
}

// **** ACCOLADE MANAGEMENT **** 

// accolade interface
function accoladeManager() {
    this.grantAccolade = function (inChar, value, accoladeType) {
        var pointTotal = 0;
        switch (accoladeType) {
            case "Damage_Dealt":
                pointTotal = this.accoladeTypes.damageDealt * value;
                break;
                // create a case for each accolade type. In database in accolades table. There is a column for the script identifier. Must match case.
        };
        if (inChar.Guild_FK == globalSkirmish.Guild_1_FK) {
            // increase guild1 score
        } else {
            //increase guild2 score
        }
        // update value on the page
    };
    this.accoladeTypes = {
        damageDealt: 0, 
        // need to define all accolade types here. In accolades table. Seperated by comma
    };
}
var globalAccoladeManager;
// accolade methods

// accolade ajax handlers
function getAccoladeData() {
    // ajax handler to read accolade point amount for each type of accolade
    var accoladeData = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/BattleFrameworkModule/API/ModuleBattleFramework/GetAccolades",
        data: {},
        dataType: "json",
        success: function (data) {
            accoladeData = JSON.parse(data);
        }
    });
    if (accoladeData == null) return;
    globalAccoladeManager.accoladeType.damageDealt = accoladeData[0].Accolade_Point_Value
    // assign accolade point value for each type of accolades. Based on getAccolade in stored procedures
}

// **** VOTE MANAGEMENT ****
// vote interface
var globalVoteData; // warehouse for all vote data for characters in skirmish
var globalUserDraftCharacters = []; // warehouse for all characters this user has drafted
// vote methods
// vote ajax handlers

// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//  NOTES FOR DUSTIN
// + getUserVoteData will give you all vote data by the user they've submitted. Keep in mind, this will come up with nothing
// if they haven't submitted any votes yet
// + getUserCharacters will provide you with all the characters the user has drafted. Some of the returned characters will
// not be in the skirmish.
// Overall, I suggest you look at the storedprocedure if you have any questions on what data is being returned for you
//
// You can delete these notes once you're done with them
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
function getUserVoteData() {
    // get vote data by user
    var voteData = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/BattleFrameworkModule/API/ModuleBattleFramework/GetVoteDataFromSkirmish",
        data: {
            Skirmish_PK: globalSkirmish.Skirmish_PK,
            User_PK: userId
        },
        dataType: "json",
        success: function (data) {
            voteData = JSON.parse(data);
        }
    });
    if (voteData == null) return;
    globalVoteData = voteData;
}
function getUserCharacters() {
    // get vote data by user
    var charData = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/BattleFrameworkModule/API/ModuleBattleFramework/GetCharacterDraftByUser",
        data: {
            User_PK: userId
        },
        dataType: "json",
        success: function (data) {
            charData = JSON.parse(data);
        }
    });
    if (charData == null) return;
    
    for (var i = 0; i < charData.length; i++) {
        globalUserDraftCharacters.push(getCharacterById(charData[i].Character_FK));
    }
}
/****************************************************************************************************
    END Global Interface 
****************************************************************************************************/
function turnTrackManager() {
    this.displayQueue = [];
    this.buildDisplayQueue = function () {
        for (var actionstep = 1; actionstep <= 24; actionstep++) {
            var actionStepLogs = getRelevantCombatLogs(actionstep);
            if (actionStepLogs.length == 0) continue;

            var assailant, interrupters = [];

            for (var i = 0; i < actionStepLogs.length; i++) {
                var currLog = actionStepLogs[i];
                if (currLog.bInterrupt == false) {
                    assailant = getCharacterById(currLog.Assailant_Character_FK);
                } else {
                    // check if interrupter is already in array
                    var bExists = false;
                    for (var j = 0; j < interrupters.length; j++) {
                        if (interrupters[j].Character_PK == getCharacterById(currLog.Assailant_Character_FK).Character_PK) bExists = true;
                    }
                    if (!bExists) interrupters.push(getCharacterById(currLog.Assailant_Character_FK));
                }
            }

            //get main characters logs
            var assailantLogs = [];

            for (var i = 0; i < actionStepLogs.length; i++) {
                var currLog = actionStepLogs[i];

                if (assailant.Character_PK == currLog.Assailant_Character_FK && currLog.bInterrupt == false) {
                    assailantLogs.push(currLog);
                }
            }

            //get interrupter logs
            var interrupterLogs = [];

            for (var x = 0; x < interrupters.length; x++) {
                var interrupter = interrupters[x];
                var batchLogs = []; 

                for (var i = 0; i < actionStepLogs.length; i++) {
                    var currLog = actionStepLogs[i];

                    if (interrupter.Character_PK == currLog.Assailant_Character_FK && currLog.bInterrupt == true) {
                        batchLogs.push(currLog);
                    }
                }

                interrupterLogs.push(batchLogs);
            }

            // push logs to displayQueue
            this.displayQueue.push(assailantLogs);
            for (var i = 0; i < interrupterLogs.length; i++) {
                this.displayQueue.push(interrupterLogs[i]);
            }
            console.log(assailantLogs);
            console.log(interrupterLogs);
        }       
    }
    this.displayTracker = 0;

    this.endSkirmish = function () {
        // Skirmish Cleanup
        $(".char_img").removeClass("pic-border-target");
        $(".char_img").removeClass("pic-border-assailant");
        $(".char_img").addClass("pic-border-light");
        $(".container_activeicon").empty();
        console.log("END SKIRMISH");
    };
    return this;
}
function showDisplayQueue(trackManager) {
    setTimeout(function () {
        var displayLogs = trackManager.displayQueue[trackManager.displayTracker];

        // determine if new action step has been reached
        if (displayLogs[0].Action_Order == currActionStep) {
            displayCombatResult(displayLogs);
        } else {
            currActionStep = displayLogs[0].Action_Order;
            displayActionStep(currActionStep);
            displayCombatResult(displayLogs);
        }

        trackManager.displayTracker++;
        if (trackManager.displayTracker < trackManager.displayQueue.length) {
            showDisplayQueue(trackManager);
        } else {
            trackManager.endSkirmish();
        }
    }, actionWaitInterval);

}
function displayCombatResult(displayLogs) {
    for (var i = 0; i < displayLogs.length; i++) {
        var currLog = displayLogs[i];
        var skillType = getSkillById(currLog.Skill_FK).Skill_Type;
        var logIcon;

        var assailant = getCharacterById(currLog.Assailant_Character_FK);
        var target = getCharacterById(currLog.Target_Character_FK);

        // highlight target
        $(target.getCharMapSlot()).removeClass("pic-border-light");
        $(target.getCharMapSlot()).addClass("pic-border-target");
        // highlight assailant
        $(assailant.getCharMapSlot()).removeClass("pic-border-light");
        $(assailant.getCharMapSlot()).removeClass("pic-border-target");
        $(assailant.getCharMapSlot()).addClass("pic-border-assailant");

        if (!currLog.bInterrupt) {
            $(assailant.getCharMapSlot() + "_activeicon_left").html('<img src="/Portals/0/RPGFL/battle_icons/active_character.png" alt="" />');
            $(assailant.getCharMapSlot() + "_activeicon_right").html('<img src="/Portals/0/RPGFL/battle_icons/active_character.png" alt="" />');
        } else {
            $(assailant.getCharMapSlot() + "_activeicon_left").html('<img src="/Portals/0/RPGFL/battle_icons/interrupt.png" alt="" />');
            $(assailant.getCharMapSlot() + "_activeicon_right").html('<img src="/Portals/0/RPGFL/battle_icons/interrupt.png" alt="" />');
        }

        // COMBAT LOG MANAGMENT

        // check if attack was successful
        var skill = getSkillById(currLog.Skill_FK);
        if (currLog.bAttackSuccessful || skill.Skill_Type.indexOf("Guard") > -1 || skill.Skill_Type.indexOf("Blessing") > -1) {
            if (skill.Skill_Type == "Attack" || skill.Skill_Type == "Taunt" || skill.Skill_Type.indexOf("Affliction") > -1) {
                // hostile action, deal damage
                target.takeDamage(currLog.Damage_Final_Result);
                target.removeCondition("Guarded");
                //granting accolades for damage dealt. Logic needs to happen for each type of accolade
                globalAccoladeManager.grantAccolade(assailant, currLog.Damage_Final_Result, "Damage_Dealt");

                if (skill.Special_Min_Roll != null && skill.Special_Min_Roll <= currLog.Attack_Final_Result) {
                    // show target is taunted or afflicted
                    if (skill.Skill_Type == "Taunt") {
                        target.recieveCondition("Taunted");
                    } else if (skill.Skill_Type.indexOf("Affliction") > -1) {
                        target.recieveCondition("Afflicted");
                        // write additional affliction logic - charmed, blinded, stunned etc
                    }
                }
            }
            else if (skill.Skill_Type == "Heal") {
                target.healDamage(currLog.Damage_Final_Result);
            }
            else if (skill.Skill_Type.indexOf("Guard") > -1) {
                // show that target is guarded
                target.recieveCondition("Guarded");
            }
            else if (skill.Skill_Type.indexOf("Blessing") > -1) {
                //show that target has recieved a blessing
                target.recieveCondition("Blessed");
            }
        }


        if (skillType == "Attack" || skillType.indexOf("Affliction") > -1 || skillType == "Taunt" || skillType == "Passive") {
            logIcon = "/portals/0/RPGFL/battle_icons/attackicon.png";
        } else if (skillType.indexOf("Blessing") > -1) {
            logIcon = "/portals/0/RPGFL/battle_icons/casticon.png";
        } else if (skillType == "Heal") {
            logIcon = "/portals/0/RPGFL/battle_icons/healicon.png";
        } else if (skillType.indexOf("Guard") > -1) {
            logIcon = "/portals/0/RPGFL/battle_icons/guardicon.png";
        }

        var logHTML =
        '<div class="accordion" id="accordionlog_' + currLog.CombatLog_PK + '">' +
            '<div class="accordion-group">' +
                '<div class="accordion-heading middle-accordion">' +
                    '<a class="accordion-toggle" data-toggle="collapse" data-parent="accordionbody_' + currLog.Action_Order + '" href="#collapseInner_' + currLog.CombatLog_PK + '">' +
                        '<p class="inline text-center guild' + assailant.Guild_FK + ' font-verdana">' + assailant.Character_Name + '  </p>' +
                        '<img class="inline" src="' + logIcon + '" />' +
                        '<p class="inline text-center guild' + target.Guild_FK + ' font-verdana">' + target.Character_Name + '  </p>' +
                    '</a>' +
                '</div>' +
                '<div id="collapseInner_' + currLog.CombatLog_PK + '" class="accordion-body collapse">' +
                    '<div class="accordion-inner bottom-accordion">' +
                        '<p>Attack roll: ' + '<span data-toggle="tooltip" data-placement="top" title="' + currLog.Attack_Values + '  ">' + currLog.Attack_Final_Result + '</span> | Damage roll: ' + '<span data-toggle="tooltip" data-placement="top" title="' + currLog.Damage_Values + '  ">' + currLog.Damage_Final_Result + ' </span></p>' +
                    '</div>' +
                '</div>' +
            '</div>' +
        '</div>';

        $("#accordionbody_" + currLog.Action_Order + " .accordion-inner").html(logHTML + $("#accordionbody_" + currLog.Action_Order + " .accordion-inner").html());
    }
}
function displayActionStep(actionStep) {
    $(".char_img").removeClass("pic-border-target");
    $(".char_img").removeClass("pic-border-assailant");
    $(".char_img").addClass("pic-border-light");
    $(".container_activeicon").empty();

    var relevantCombatLogs = getRelevantCombatLogs(actionStep);
    if (relevantCombatLogs.length == 0) return;

    console.log(actionStep);
    console.log(relevantCombatLogs);

    var assailant, logIcon, skillType;

    for (var i = 0; i < relevantCombatLogs.length; i++) {
        var currLog = relevantCombatLogs[i];
        if (currLog.bInterrupt == false) {
            assailant = getCharacterById(currLog.Assailant_Character_FK);
            skillType = getSkillById(currLog.Skill_FK).Skill_Type;
        } 
    }

    if (skillType == "Attack" || skillType.indexOf("Affliction") > -1 || skillType == "Taunt" || skillType == "Passive") {
        logIcon = "/portals/0/RPGFL/battle_icons/attackicon.png";
    } else if (skillType.indexOf("Blessing") > -1) {
        logIcon = "/portals/0/RPGFL/battle_icons/casticon.png";
    } else if (skillType == "Heal") {
        logIcon = "/portals/0/RPGFL/battle_icons/healicon.png";
    } else if (skillType.indexOf("Guard") > -1) {
        logIcon = "/portals/0/RPGFL/battle_icons/guardicon.png";
    }

    var logHTML =
    '<div class="accordion" id="accordionlog_actionstep' + actionStep + '">' +
        '<div class="accordion-group">' +
            '<div class="accordion-heading top-accordion">' +
                '<a class="accordion-toggle" data-toggle="collapse" data-parent="combatlogcontainer" href="#accordionbody_' + actionStep + '">' +
                    '<span>' + actionStep + ')</span><p class="inline text-center guild' + assailant.Guild_FK + ' font-verdana">  ' + assailant.Character_Name + '  </p>' +
                    '<img class="inline" src="' + logIcon + '" />' +
                '</a>' +
            '</div>' +
            '<div id="accordionbody_' + actionStep + '" class="accordion-body collapse">' +
                '<div class="accordion-inner text-center"></div>' +
            '</div>' +
        '</div>' +
    '</div>';
    $("#combatlogcontainer").html(logHTML + $("#combatlogcontainer").html());
}
