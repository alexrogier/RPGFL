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
    console.log(jsonResult);
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
        }

        // insert guild specific values
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > img.guild_1_logo").attr("src", _GETGUILDLOGO(currSkirmish.Guild_1_FK)); // guild 1 logo
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > img.guild_2_logo").attr("src", _GETGUILDLOGO(currSkirmish.Guild_2_FK)); // guild 2 logo
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_1_name").text(currSkirmish.Guild_1_Name); // guild 1 name
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_2_name").text(currSkirmish.Guild_2_Name); // guild 2 name
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_1_score").text(currSkirmish.Guild_1_Accolade_Points); // guild 1 score
        $("#table_tbody_skirmishdata > tr#skirmish_data_" + currSkirmish.Skirmish_PK + " > td > p.guild_2_score").text(currSkirmish.Guild_2_Accolade_Points); // guild 2 score
        // modify replay button here. CODE LATER
    }
}