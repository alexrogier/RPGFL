// External Script Variables
// @userId - defined in View.ascx

var bPriorityEditting = false;

$(document).ready(function () {
    if (userId == -1) $("#btn_editpriority").hide();
    
    populateGuildFilter();

    getCharacterData();
    
    // handlers
    $("#dropdown_guilds, input[name='filter_classes']").change(function () {
        if ($(this).attr("id") == "filter_allclasses") {
            // when all_classes filter is selected

            // don't perform operations if all classes is already checked
            if (!$(this).prop("checked")) {
                $(this).prop("checked", true);
                return;
            }

            // disable all filters
            $("input[name='filter_classes']").each(function () {
                $(this).prop("checked", false);
            });

            // check all_classes filter
            $(this).prop("checked", true);
        } else {
            // if any other filter is selected, unselect all_classes
            $("#filter_allclasses").prop("checked", false);
        }

        getCharacterData();
    });

    $("#btn_editpriority").click(function () {
        if (bPriorityEditting) {
            postDraftPriority();
            $("#btn_editpriority").text("Edit Character Draft Priorities");
        } else {
            getDraftPriority();
            $("#btn_editpriority").text("Save Character Draft Priorities");
        }
        bPriorityEditting = !bPriorityEditting;
    });
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
    for (var guild = 0; guild < guildInfo.length; guild++) {
        $("#dropdown_guilds").append("<option value=" + guildInfo[guild].Guild_PK + ">" + guildInfo[guild].Guild_Name + "</option>");
    }
}

function getDraftPriority() {
    // ignore filters in ajax
    // reset & disable filters
    $("input[name='filter_classes']").each(function () {
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
        url: "/DesktopModules/CharacterViewer/API/ModuleCharacterViewer/GetUserDraftPriority",
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
    populateCharacters(userDraftInfo);

    // sortable / draggable jQuery code
    $("#characterviewer_table_data").sortable();
    $(".draggable").draggable({
        connectToSortable: '#characterviewer_table_data',
        helper: 'clone',
        revert: 'invalid'
    });
    $("ul, li").disableSelection();
}

function postDraftPriority() {
    var postDraftArray = [];
    // record priority list
    $(".char_img").each(function (index, value) {
        var arrayItem = {
            Character_PK: $(this).attr("data-charpk"),
            Priority: (index + 1)
        }
        postDraftArray.push(arrayItem);
    });

    console.log(postDraftArray);

    // post new draft priorities to server
    $.ajax({
        async: false,
        type: "POST",
        url: "/DesktopModules/CharacterViewer/API/ModuleCharacterViewer/UpdateUserDraftPriority",
        data: {
            DraftPriorities: JSON.stringify(postDraftArray),
            UserFK: userId
        },
        dataType: "json"
    });

    // reenable filters
    $("input[name='filter_classes']").each(function () {
        $(this).prop("disabled", false);
    });
    $("#dropdown_guilds").prop("disabled", false);
    getCharacterData();

    // sortable / draggable jQuery code
    $("#characterviewer_table_data").sortable("destroy");
    $(".draggable").draggable("destroy");
}

function getCharacterData() {
    var charData = null;
    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/CharacterViewer/API/ModuleCharacterViewer/GetAllCharacters",
        data: {
            FILTER_guildfk: $("#dropdown_guilds").val(),
            FILTER_allclasses: $("#filter_allclasses").prop("checked"),
            FILTER_healer: $("#filter_healer").prop("checked"),
            FILTER_assassin: $("#filter_assassin").prop("checked"),
            FILTER_hunter: $("#filter_hunter").prop("checked"),
            FILTER_bruiser: $("#filter_bruiser").prop("checked"),
            FILTER_sorcerer: $("#filter_sorcerer").prop("checked"),
            FILTER_enchanter: $("#filter_enchanter").prop("checked"),
            FILTER_tank: $("#filter_tank").prop("checked")
        },
        dataType: "json",
        success: function (data) {
            charData = JSON.parse(data);
        }
    });

    if (charData == null) return;
    populateCharacters(charData);
}

function populateCharacters(charData){
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
    //var row = 1;
    //var maxColumnsPerRow = 13;
    //var column = 13;
    for (var char = 0; char < charData.length; char++) {
        // append master standings row template for new table row
        //column++;
        //if (column > maxColumnsPerRow) {
        //    row++;
        //    $("#characterviewer_table_data").append('<tr id="row_' + row + '"></tr>');
        //    column = 1;
        //}
        $("#characterviewer_table_data").append(rowRankHTML_TEMPLATE);
        var img = $("#characterviewer_table_data > li > img.new_char");
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