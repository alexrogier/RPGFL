// External Script Variables
// @userId - defined in View.ascx
// @userName - defined in View.ascx

$(document).ready(function () {
    populateSkirmishes();

    // handlers
    $("#dropdown_context").change(function () {
        populateSkirmishes();
    });
});

function getSkirmishes() {
    var jsonResult = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/SkirmishModule/API/ModuleSkirmish/GetSkirmishes",
        data: { FILTER_context: $("#dropdown_context").val() },
        dataType: "json",
        success: function (data) {
            jsonResult = JSON.parse(data);
        }
    });
    return jsonResult;
}

function populateSkirmishes() {
    var skirmishData = getSkirmishes();

    // populate skirmish table with data
    if (skirmishData == null) return;

    var rowSkirmishHTML_TEMPLATE = '';
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/SkirmishModule/htmltemplate/skirmishdata_htmltemplate.html",
        success: function (data) {
            rowSkirmishHTML_TEMPLATE = data;
        }
    });

    $("#table_tbody_skirmishdata").empty();
    for (var skirmish = 0; skirmish < skirmishData.length; skirmish++) {
        var currSkirmish = skirmishData[skirmish];

        // get guilds involved in skirmish

        // append master standings row template for new table row
        $("#table_tbody_skirmishdata").append('<tr id="skirmish_data_' + currSkirmish.Skirmish_PK + '" class="offical-black-border div-center">' + rowSkirmishHTML_TEMPLATE + '</tr>');

        console.log(currSkirmish);
        if (currSkirmish.Skirmish_Victor_FK != -1) {
            if (currSkirmish.Guild_1_FK == currSkirmish.Skirmish_Victor_FK) {

                $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_1_winlose").text("VICTORY"); // guild 1 win/lose
                $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_2_winlose").text("LOSS"); // guild 2 win/lose
                $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_1_winlose").addClass("text_skirmish_win")
                $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_2_winlose").addClass("text_skirmish_lose")
            }
            if (currSkirmish.Guild_2_FK == currSkirmish.Skirmish_Victor_FK) {
                $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_1_winlose").text("LOSS"); // guild 1 win/lose
                $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_2_winlose").text("VICTORY"); // guild 2 win/lose
                $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_1_winlose").addClass("text_skirmish_lose")
                $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_2_winlose").addClass("text_skirmish_win")
            }
            $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p > a.btn").attr("href", "/Mock-Module-Pages/Module-BATTLEFRAMEWORK?skirmishid=" + currSkirmish.Skirmish_PK) // change to official battleframework page later!
        } else {
            $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p > button.btn").hide();
        }

        // insert guild specific values
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > img.guild_1_logo").attr("src", _GETGUILDLOGO(currSkirmish.Guild_1_FK)); // guild 1 logo
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > img.guild_2_logo").attr("src", _GETGUILDLOGO(currSkirmish.Guild_2_FK)); // guild 2 logo
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_1_name").text(currSkirmish.Guild_1_Name); // guild 1 name
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_2_name").text(currSkirmish.Guild_2_Name); // guild 2 name
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_1_score").text(currSkirmish.Guild_1_Accolade_Points); // guild 1 score
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_2_score").text(currSkirmish.Guild_2_Accolade_Points); // guild 2 score
        //var skirmish_date = new Date(parseInt(currSkirmish.Skirmish_Date.replace(/\/Date\((-?\d+)\)\//, '$1')));
        var skirmish_date = new Date();
        skirmish_date.setTime(parseInt(currSkirmish.Skirmish_Date.substr(6)));
        // Date.getMonth() returns 1 month short??
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.skirmish_date").text(skirmish_date.getMonth() + 1 + "/" + skirmish_date.getDate() + "/" + skirmish_date.getFullYear()); // skirmish date
        // modify replay button here. CODE LATER

        // hide replay button in 'Future Skirmishes' context
        if ($("#dropdown_context").val() == 'SHOWFUTURE') $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p > button.btn").hide();
    }
}