// External Script Variables
// @userId - defined in View.ascx
// @userName - defined in View.ascx

var moduleStandingsSettings = {
    _DROPDOWNCONTEXTPERMOPTIONS: 
        '<option value="SHOWEVERYONE">Show Everyone</option>' +
        '<option value="SHOWONLYME">Show Only Me</option>'
}

$(document).ready(function () {
    // handle league data
    var userLeagues = getUserLeagues();
    populateContextFilter(userLeagues);

    populateStandings();

    // handlers
    $("#dropdown_context, #dropdown_accolade").change(function () {
        // write logic when context dropdown changes here
        populateStandings();
    });
});

function getUserLeagues() {
    var jsonResult = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/LeagueModule/API/ModuleLeague/GetLeagues",
        data: { User_PK: userId },
        dataType: "json",
        success: function (data) {
            jsonResult = JSON.parse(data);
        }
    });
    return jsonResult;
}

function populateContextFilter(leagues) {
    if(leagues == null || leagues == 'undefined') return;

    $("#dropdown_context").empty();

    // append permanent dropdown context options
    $("#dropdown_context").append(moduleStandingsSettings._DROPDOWNCONTEXTPERMOPTIONS);

    // append user's leagues
    for (var league = 0; league < leagues.length; league++) {
        $("#dropdown_context").append('<option value="' + leagues[league].League_PK + '">' + leagues[league].League_Name + '</option>');
    }
}

function populateStandings() {
    var FILTER_accolade = $("#dropdown_accolade").val();
    var FILTER_context = $("#dropdown_context").val();
    
    // check if a specific league has been selected
    var leaguefk = null;
    if ($("#dropdown_context").val != "SHOWONLYME" || $("#dropdown_context").val != "SHOWEVERYBODY") leaguefk = $("#dropdown_context").val();

    var standingsData = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/StandingsModule/API/ModuleStandings/GetStandings",
        data: {
            FILTER_accolade: FILTER_accolade,
            FILTER_context: FILTER_context,
            FILTER_league: leaguefk,
            FILTER_userfk: userId
        },
        dataType: "json",
        success: function (data) {
            standingsData = JSON.parse(data);
        }
    });

    // populate standings table with data
    if (standingsData == null) return;

    var rowRankHTML_TEMPLATE = '';
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/StandingsModule/htmltemplate/standingsdata_htmltemplate.html",
        success: function (data) {
            rowRankHTML_TEMPLATE = data;
        }
    });
    console.log(standingsData);
    $("#table_tbody_standingsdata").empty();
    for (var rank = 0; rank < standingsData.length; rank++) {
        var currRank = standingsData[rank];

        // get user info
        var userInfo = '';
        $.ajax({
            async: false,
            type: "GET",
            url: "/DesktopModules/StandingsModule/API/ModuleStandings/GetUserInfo",
            data: {
                User_PK: currRank.UserPK
            },
            dataType: "json",
            success: function (data) {
                userInfo = JSON.parse(data);
            }
        });
        if (userInfo == null || userInfo == 'undefined') return;

        // get user's draft picks in specific league
        var draftInfo = '';
        $.ajax({
            async: false,
            type: "GET",
            url: "/DesktopModules/StandingsModule/API/ModuleStandings/GetCharAccoladeByUserLeague",
            data: {
                FILTER_userfk: currRank.UserPK,
                FILTER_leaguefk: currRank.LeaguePK,
                FILTER_accolade: FILTER_accolade
            },
            dataType: "json",
            success: function (data) {
                draftInfo = JSON.parse(data);
            }
        });
        if (draftInfo == null || draftInfo == 'undefined') return;
        console.log(draftInfo);

        // append master standings row template for new table row
        $("#table_tbody_standingsdata").append('<tr id="standings_data_user_' + currRank.UserPK + '_' + currRank.LeaguePK + '" class="offical-black-border div-center">' + rowRankHTML_TEMPLATE + '</tr>');

        // insert user specific values
        console.log(JSON.stringify(currRank));
        $("#table_tbody_standingsdata > tr#standings_data_user_" + currRank.UserPK + "_" + currRank.LeaguePK + " > td > div > p.user_rank").text(currRank.Rank);
        $("#table_tbody_standingsdata > tr#standings_data_user_" + currRank.UserPK + "_" + currRank.LeaguePK + " > td > div > p.user_totalValue").text(currRank.TotalValue);
        $("#table_tbody_standingsdata > tr#standings_data_user_" + currRank.UserPK + "_" + currRank.LeaguePK + " > td > div > p.user_username").text(userInfo[0].DisplayName);
    }
}