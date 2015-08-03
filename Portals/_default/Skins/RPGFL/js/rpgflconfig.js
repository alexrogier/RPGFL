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
	console.log(guildPk);
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