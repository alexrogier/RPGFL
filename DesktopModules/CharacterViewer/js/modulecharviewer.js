// External Script Variables
// @userId - defined in View.ascx

var bPriorityEditting = false;

$(document).ready(function () {
    if (userId == -1) $("#btn_editpriority").hide();
    
    populateGuildFilter();

    populateCharacters();

    // handlers
    $("#dropdown_guilds, input[name='filter_classes'").change(function () {
        populateCharacters();
    });

    $("#btn_editpriority").click(function () {
        if (bPriorityEditting) {
            postDraftPriority();
            $("#btn_editpriority").text("Edit Character Draft Priorities");
        } else {
            getDraftPriority();
            $("#btn_editpriority").text("Close Character Draft Priorities");
        }
        bPriorityEditting = !bPriorityEditting;
    });

    //$(function () {
    //    $(".sortable").sortable({
    //        revert: true
    //    });
    //    $(".draggable").draggable({
    //        connectToSortable: "#sortable",
    //        helper: "clone",
    //        revert: "invalid"
    //    });
    //    $("ul, li").disableSelection();
    //});
});

function populateGuildFilter(){
    $("#dropdown_guilds").empty();
    $("#dropdown_guilds").append('<option value="-1" selected>All Guilds</option>');

    var guildInfo = null;
    // get all guilds
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/CharacterViewer/API/ModuleCharacterViewer/GetAllGuilds",
        data: {},
        dataType: "json",
        success: function (data) {
            guildInfo = JSON.parse(data);
        }
    });
    if (guildInfo == null) return;

    // populate guild's dropdown
    for (var guild in guildInfo) {
        $("#dropdown_guilds").append("<option value=" + guild.Guild_PK + ">" + Guilde_Name + "</option>");
    }
}

function getDraftPriority() {
    // ignore filters in ajax
    // reset & disable filters
    $("input[name='filter_classes").each(function () {
        $(this).prop("disabled", true);
        $(this).prop("checked", false);
    });
    $("#filter_allclasses").prop("checked", true);
    $("#dropdown_guilds").prop("disabled", true);
    $("#dropdown_guilds").val(0);

    var userDraftInfo = null;
    // get user's draft priority
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/CharacterViewer/API/ModuleCharacterViewer/GetAllCharacters",
        data: {
            FILTER_userfk: userId
        },
        dataType: "json",
        success: function (data) {
            userDraftInfo = JSON.parse(data);
        }
    });
    if (userDraftInfo == null) return;

    // populate characters (already in priority order)
}

function postDraftPriority() {
    // reenable filters
    $("input[name='filter_classes").each(function () {
        $(this).prop("disabled", false);
    });
    $("#dropdown_guilds").prop("disabled", false);
}

function populateCharacters() {
    var charData = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/CharacterViewer/API/ModuleCharacterViewer/GetAllCharacters",
        data: {
            FILTER_guildfk: $("#dropdown_guild").val(),
        },
        dataType: "json",
        success: function (data) {
            charData = JSON.parse(data);
        }
    });

    if (charData == null) return;

    var rowRankHTML_TEMPLATE = '';
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/CharacterViewer/htmltemplate/characterviewerdata_htmltemplate.html",
        success: function (data) {
            rowRankHTML_TEMPLATE = data;
        }
    });

    $("#characterviewer_table_data").empty();
    var row = 1;
    var maxColumnsPerRow = 13;
    var column = 13;
    for (var char = 0; char < charData.length; char++) {
        // append master standings row template for new table row
        column++;
        if (column > maxColumnsPerRow) {
            row++;
            $("#characterviewer_table_data").append('<tr id="row_' + row + '"></tr>');
            column = 1;
        }
        $("#row_" + row).append(rowRankHTML_TEMPLATE);
        var img = $("#characterviewer_table_data > tr#row_" + row + " > td > img.new_char");
        $(img).removeClass("new_char");
        img.attr("src", _GETCHARACTERICON(charData[char].Character_Name));
        img.attr("id", "char_" + charData[char].Character_PK);
        document.getElementById($(img).attr("id")).setAttribute("data-charpk", charData[char].Character_PK);
        img.attr("rel", "popover");
        img.attr("data-content", "<strong>" + charData[char].Character_Name + "</strong><br/><em>" + charData[char].Archetype + "</em>");
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