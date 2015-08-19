var leagueId;
var bIsInLeague, bDisableLeagueJoin, bIsLeagueOwner;

$(document).ready(function () {
    leagueId = getUrlParameter("leagueid");

    //if (leagueId <= 0 || isNaN(leagueId))) return; DOESN'T FUNCTION RIGHT

    $("#404_league_not_found").hide();
    $("#league_permissions").hide();
    getLeagueData();
    $("#league_data").show();

    // handlers
    $("#btn_cancel").click(function () {

    });
    $("#btn_joinleague").click(function () {
        joinLeague();
    });
    $("#btn_leaveleague").click(function () {
        leaveLeague();
    });
});

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

function getLeagueData() {
    var leagueData = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/SingleLeagueModule/API/ModuleSingleLeague/GetSingleLeagueData",
        data: {
            FILTER_leaguefk: leagueId
        },
        dataType: "json",
        success: function (data) {
            leagueData = JSON.parse(data);
        }
    });
    if (leagueData == null) return;
    console.log(leagueData);

    // check if league is private and if user should be able to view it
    if (!leagueData.System_Public) {
        // league is private
        var bIsAllowedAccess = false;
        for (var user = 0; user < leagueData.League_Users.length; user++) {
            if (userId == leagueData.League_Users[user].User_FK) bIsAllowedAccess = true;
            // will need to check League Invitations as well
        }

        if (!bIsAllowedAccess) {
            // user is not allowed to view this league
            $("#leage_data").hide();
            $("#league_permissions").show();
            return;
        }
    }

    // populate league data
    $("#league_name").text(leagueData.League_Name);
    $("#league_gamemode").text(_GETLEAGUESETTINGTEXT("GAME_MODE", leagueData.Game_Mode))
    $("#league_duration").text(_GETLEAGUESETTINGTEXT("LEAGUE_DURATION", leagueData.League_Duration));
    $("#league_renew").text(_GETLEAGUESETTINGTEXT("RENEW_DURATION", leagueData.Renew_Duration));
    $("#league_tradeday").text(_GETLEAGUESETTINGTEXT("TRADE_DAY_ENABLED", leagueData.Trade_Day_Enabled));
    $("#league_randomize").text(_GETLEAGUESETTINGTEXT("RANDOMIZE_ENABLED", leagueData.Randomize_Enabled));
    $("#league_invite").text(_GETLEAGUESETTINGTEXT("JOIN_ALLOW_ANYONE", leagueData.Join_Allow_Anyone));

    // check if user is league owner
    if (leagueData.Creator_User_Fk == userId) {
        // enable editting controls ONLY IF league has not been activated by the system yet
        bIsLeagueOwner = true;
    }

    // loop through league users
    for (var user = 0; user < leagueData.League_Users.length; user++) {
        var userData = leagueData.League_Users[user];
        // check if user is in the league
        if (userId == userData.User_FK) {
            $("#btn_joinleague").hide();
            $("#btn_cancel").hide();
            $("#btn_leaveleague").show();
            bIsInLeague = true;
        }

        // populate league user data
        $("#user_" + (user + 1) + "_score").text(userData.Accolade_Points);
        // populate user icon here
    }

    if (!bIsInLeague) {
        // check how many leagues the user is in
        var leagueCount = null;
        $.ajax({
            async: false,
            type: "GET",
            url: "/DesktopModules/SingleLeagueModule/API/ModuleSingleLeague/GetLeagueCountByUser",
            data: {
                FILTER_userfk: userId
            },
            dataType: "json",
            success: function (data) {
                leagueCount = parseInt(data);
            }
        });
        if (leagueCount == null) return;

        // disable joining any league if user is already in 3 leagues
        if (leagueCount >= 3) {
            $("#btn_joinleague").hide();
            bDisableLeagueJoin = true;
        }
    }

    // get user's drafted characters in this league - already sorted by accolade points
    var charDraftInfo = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/SingleLeagueModule/API/ModuleSingleLeague/GetCharacterDraftByLeague",
        data: {
            FILTER_userfk: userId,
            FILTER_leaguefk: leagueId
        },
        dataType: "json",
        success: function (data) {
            charDraftInfo = data;
        }
    });
    if (charDraftInfo == null) return;
    
    for (var i = 0; i < charDraftInfo.length; i++) {
        var char = charDraftInfo[i];
        $("#char_" + (i + 1) + "_score").text(char.Accolade_Points);
        $("#char_" + (i + 1) + "_img").attr("src", _GETCHARACTERICON(char.Character_Name));

        // rig character images for character viewer
        var img = $("#char_" + (i + 1) + "_img");
        document.getElementById($(img).attr("id")).setAttribute("data-charpk", char.Character_PK);
        img.attr("rel", "popover");
        img.attr("data-content", "<strong>" + char.Character_Name + "</strong><br/><em>" + char.Archetype + "</em>");
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

function leaveLeague() {
    bootbox.confirm("Are you sure you want to leave the league? [WARNING: If you are the league owner this will delete the league]",
        function (result) {
            if (result) {
                $("#btn_joinleague").prop("disabled", true);
                $("#btn_leaveleague").prop("disabled", true);
                $("#btn_cancel").prop("disabled", true);
                // delete user from league
                $.ajax({
                    async: false,
                    type: "GET",
                    url: "/DesktopModules/SingleLeagueModule/API/ModuleSingleLeague/DeleteUserFromLeague",
                    data: {
                        FILTER_leaguefk: leagueId,
                        FILTER_userfk: userId,
                        bLeagueOwner: bIsLeagueOwner
                    },
                    dataType: "json",
                    success: function (data) {
                        window.location = "/leagues";
                    }
                });
            }
        });
}

function joinLeague() {
    if (!bDisableLeagueJoin && !bIsInLeague) {
        $("#btn_joinleague").prop("disabled", true);
        $("#btn_leaveleague").prop("disabled", true);
        $("#btn_cancel").prop("disabled", true);
        // add user to league
        console.log(leagueId + " " + userId);
        $.ajax({
            async: false,
            type: "GET",
            url: "/DesktopModules/SingleLeagueModule/API/ModuleSingleLeague/InsertUserInLeague",
            data: {
                FILTER_leaguefk: leagueId,
                FILTER_userfk: userId
            },
            dataType: "json",
            success: function (data) {
                location.reload();
            }
        });
    }
}