// External Script Variables
// @userId - defined in View.ascx

$(document).ready(function () {
    // remove "Show My Leagues" if user isn't logged in
    if (userId == -1) {
        $("#dropdown_context option[value='SHOWUSERLEAGUES']").remove();
    }

    populateLeagues();

    // handlers
    $("#dropdown_context").change(function () {
        populateLeagues();
    });

    $("#filter_search").keydown(function () {
        if (event.keyCode == 13) {
            event.preventDefault();

            // don't allow searching when user is on "Show My Leagues" context
            if ($("#dropdown_context").val() == "SHOWUSERLEAGUES") return false;

            populateLeagues();
            return false;
        }
    });

    $("#img_matchmaking").click(function() {
        bootbox.confirm("This will insert you into a random public guild where you will play against strangers with default league settings. Are you sure you want to Matckmake?", function(result) {
            if (result) {
                matchmakeUser();
            } 
        });
    });
});

function matchmakeUser() {
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/LeagueModule/API/ModuleLeague/InsertUserIntoMatchmaking",
        data: {
            FILTER_userfk: userId
        },
        dataType: "json",
        success: function (data) {
            location.reload();
        }
    });
}

function populateLeagues() {
    var leagueData = null;

    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/LeagueModule/API/ModuleLeague/GetLeagues",
        data: {
            FILTER_userfk: userId,
            FILTER_context: $("#dropdown_context").val(),
            FILTER_search: (($("#filter_search").val() == "") ? 'null' : $("#filter_search").val())

        },
        dataType: "json",
        success: function (data) {
            leagueData = JSON.parse(data);
        }
    });

    // populate league table with data
    if (leagueData == null) return;

    var rowRankHTML_TEMPLATE = '';
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/LeagueModule/htmltemplate/leaguedata_htmltemplate.html",
        success: function (data) {
            rowRankHTML_TEMPLATE = data;
        }
    });

    $("#table_tbody_leaguedata").empty();
    for (var league = 0; league < leagueData.length; league++) {
        var currLeague = leagueData[league];

        // hide full leagues
        if (currLeague.Slots_Filled >= 8) continue;

        // hide invite-only leagues
        if ($("#dropdown_context").val() != "SHOWUSERLEAGUES") {
            if (!currLeague.Join_Allow_Anyone) continue;
        }

        // append master standings row template for new table row
        $("#table_tbody_leaguedata").append('<tr id="league_data_league_' + currLeague.League_PK + '" class="offical-black-border div-center">' + rowRankHTML_TEMPLATE + '</tr>');

        // insert league specific values
        $("#table_tbody_leaguedata > tr#league_data_league_" + currLeague.League_PK + " > td > div > strong > p.leaguename").text(currLeague.League_Name);
        $("#table_tbody_leaguedata > tr#league_data_league_" + currLeague.League_PK + " > td > div > div > div > p > span.slotsfilled").text(currLeague.Slots_Filled);
        $("#table_tbody_leaguedata > tr#league_data_league_" + currLeague.League_PK + " > td > div > div > div > div > p.league_gamemode").text(_GETLEAGUESETTINGTEXT("GAME_MODE", currLeague.Game_Mode));
        $("#table_tbody_leaguedata > tr#league_data_league_" + currLeague.League_PK + " > td > div > div > div > div > p.league_duration").text(_GETLEAGUESETTINGTEXT("LEAGUE_DURATION", currLeague.League_Duration));
        $("#table_tbody_leaguedata > tr#league_data_league_" + currLeague.League_PK + " > td > div > div > div > div > p.league_renew").text(_GETLEAGUESETTINGTEXT("RENEW_DURATION", currLeague.Renew_Duration));
        $("#table_tbody_leaguedata > tr#league_data_league_" + currLeague.League_PK + " > td > div > div > div > div > p.league_tradeday").text(_GETLEAGUESETTINGTEXT("TRADE_DAY_ENABLED", currLeague.Trade_Day_Enabled));
        $("#table_tbody_leaguedata > tr#league_data_league_" + currLeague.League_PK + " > td > div > div > div > div > p.league_randomize").text(_GETLEAGUESETTINGTEXT("RANDOMIZE_ENABLED", currLeague.Randomize_Enabled));
        $("#table_tbody_leaguedata > tr#league_data_league_" + currLeague.League_PK + " > td > div > div > div > div > p.league_invite").text(_GETLEAGUESETTINGTEXT("JOIN_ALLOW_ANYONE", currLeague.Join_Allow_Anyone));

        // populate league icon
        $("#table_tbody_leaguedata > tr#league_data_league_" + currLeague.League_PK + " > td > div > div > a >img.league_icon").attr("src", currLeague.League_Icon);
        $("#table_tbody_leaguedata > tr#league_data_league_" + currLeague.League_PK + " > td > div > div > a.league_navigation").attr("href", "/viewleague?leagueid=" + currLeague.League_PK);

        // navigation 
    }
}