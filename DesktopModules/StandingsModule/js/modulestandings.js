﻿/// <reference path="../htmltemplate/standingsdata_htmltemplate.html" />
/// <reference path="../htmltemplate/standingsdata_htmltemplate.html" />
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
    var userLeagues = getUserLeagues(userId);
    populateContextFilter(userLeagues);

    populateStandings();

    // handlers
    $("#dropdown_context").change(function () {
        // write logic when context dropdown changes here
    });
});

function getUserLeagues(userId) {
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

    $("#table_tbody_standingsdata").empty();
    for (var rank = 0; rank < standingsData.length; rank++) {
        var currRank = standingsData[rank];

        // append master standings row template for new table row
        $("#table_tbody_standingsdata").append('<tr id="standings_data_user_' + userId + '" class="offical-black-border div-center">' + rowRankHTML_TEMPLATE + '</tr>');
        
        // fill in template id's
        $("#table_tbody_standingsdata.tr.td > #userId_rank").attr('id') = userId + "_rank";
        $("#table_tbody_standingsdata.tr.td > #userId_totalvalue").attr('id') = userId + "_totalvalue";
        $("#table_tbody_standingsdata.tr.td > #userId_username").attr('id') = userId + "_username";

        // insert user specific values
        $("#table_tbody_standingsdata > p." + userId + "_rank").text = currRank.Rank;
        $("#table_tbody_standingsdata > p." + userId + "_totalvalue").text = currRank.TotalValue;
        $("#table_tbody_standingsdata > p." + userId + "_username").text = Username;
    }
}