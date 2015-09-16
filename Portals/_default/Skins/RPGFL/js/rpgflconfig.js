var _GLOBALsettings = {
    webservicesurl: "http:localhost:53126",
    _ICONS: {
        // guilds
        guildpk_1: "/portals/0/RPGFL/guild_icons/defenders_of_light.png",
        guildpk_2: "/portals/0/RPGFL/guild_icons/netherling.png",
        guildpk_3: "/portals/0/RPGFL/guild_icons/seed_of_the_grove.png",
        guildpk_4: "/portals/0/RPGFL/guild_icons/artifact_guild.png"  
    }
};

function _GETGUILDLOGO(guildPk){
    switch (guildPk) {
        case 1:
            return _GLOBALsettings._ICONS.guildpk_1;
            break;
        case 2:
            return _GLOBALsettings._ICONS.guildpk_2;
            break;
		case 3:
		    return _GLOBALsettings._ICONS.guildpk_3;
            break;
		case 4:
		    return _GLOBALsettings._ICONS.guildpk_4;
            break;
    }

    return null;
}

function _GETCHARACTERPORTRAIT(characterName) {
    var searchName = characterName.split(" ").join("_");
    return "/portals/0/RPGFL/characters/portraits/" + searchName + ".jpg";
}

function _GETCHARACTERICON(characterName) {
    var searchName = characterName.split(" ").join("_").toLowerCase();
    return "/portals/0/RPGFL/characters/icons/" + searchName + ".jpg";
}

function _GETCHARACTERDATA(id) {
    // reset modal data
    
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/AdminCharacterManagerModule/API/ModuleAdmChaMan/GetCharacterData",
        data: {
            Character_PK: id
        },
        dataType: "json",
        success: function (data) {
            data = JSON.parse(data);
            // set modal data
            $("#charactermodal_title").text(data[0].Character_Name);
            $("#charactermodal_portrait").attr("src", _GETCHARACTERPORTRAIT(data[0].Character_Name));
            $("#charactermodal_motto").text(data[0].Title_Desc);
            $("#charactermodal_stats_health").text(data[0].Health);
            $("#charactermodal_stats_dodge").text(data[0].Dodge);
            $("#charactermodal_stats_archetype").text(data[0].Archetype);
            $("#charactermodal_stats_maxenergy").text(data[0].Max_Energy);
            $("#charactermodal_stats_initiative").text(data[0].Initiative);
            $("#charactermodal_stats_guild").text(data[0].Guild_Name);
            $("#charactermodal_stats_finesse").text(data[0].Finesse);
            $("#charactermodal_stats_agility").text(data[0].Agility);
            $("#charactermodal_stats_senses").text(data[0].Senses);
            $("#charactermodal_stats_mana").text(data[0].Mana);
            $("#charactermodal_stats_immunities").text(data[0].Immunities || "None");
            $("#charactermodal_stats_vulnerabilities").text(data[0].Vulnerabilities || "None");
            $("#charactermodal_stats_resistances").text(data[0].Resistances || "None");
            $("#charactermodal_stats_resistances").text(data[0].Resistances || "None");

        }
    });
    // skills
    var skillData = _GETSKILLDATA(id);

    $("#charactermodal_skills").empty();
    $("#charactermodal_skills").append('<ul style="list-style-type:none;" id="characterskills">');

    for (var skill = 0; skill < skillData.length; skill++)
    {
        var PassiveText = "Passive";

        if (skillData[skill].Skill_Type != 'Passive') PassiveText = skillData[skill].Energy_Cost + " Energy";

        $("#characterskills").append("<li><p><strong>" + skillData[skill].Skill_Name + " [" + skillData[skill].Attribute_FK + "] [" + PassiveText + "]</strong> " + skillData[skill].Skill_Description + "</p></li>")

    }

    $("#charactermodal_skills").append("</ul>");
}

function _GETSKILLDATA(id) {
    var skillData = null
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/CharacterViewer/API/ModuleCharacterViewer/GetAllSkills",
        data: { Character_PK: id },
        dataType: "json",
        success: function (data) {
            skillData = data;
        }
    });

    if (skillData == null) return;
    return skillData;
}

function _GETLEAGUESETTINGTEXT(setting, val) {
    var returnText = null;

    if (val == 1) {
        returnText = "Enabled";
    } else {
        returnText = "Disabled";
    }

    // handle unique expressions
    switch (setting) {
        case "GAME_MODE":
            switch (val) {
                case 1: returnText = "Normal"; break;
                case 2: returnText = "Damage Dealt"; break;
                case 3: returnText = "Damage Taken"; break;
                case 4: returnText = "Voting"; break;
                case 5: returnText = "Survival"; break;
            }
            break;
        case "LEAGUE_DURATION":
            switch (val) {
                case 1: returnText = "1 Campaign"; break;
                case 2: returnText = "2 Campaigns"; break;
                case 3: returnText = "3 Campaigns"; break;
                case 4: returnText = "Series Long"; break;
            }
            break;
        case "JOIN_ALLOW_ANYONE":
            // inverse expressions
            switch (val) {
                case false: returnText = "Enabled"; break;
                case true: returnText = "Disabled"; break;
            }
            break;
    }

    return returnText;
}