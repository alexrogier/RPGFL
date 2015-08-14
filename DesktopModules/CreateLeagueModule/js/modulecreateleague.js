// External Script Variables
// @userId - defined in View.ascx

$(document).ready(function () {
    // handlers
    $("#btn_cancel").click(function () {
        window.location = "/leagues";
    });
    $("#btn_createleague").click(function () {
        // validate user data
        submitEntries();
    });
    $("#img_leagueicon").click(function () {
        // select league icon
    });
    $("#input_leaguename").keyup(function () {
        // allow only A-Z or 0-9 string values
        var regex = /[^a-z0-9 _]/gi;
        $(this).val($(this).val().replace(regex, ""));
    });
});

function validateEntries() {
    var leagueName;

    // validate league name
    var regex = /[^a-z0-9 _]/gi;
    $("#input_leaguename").val($("#input_leaguename").val().replace(regex, ""));

    // validate emails
}

function submitEntries() {
    validateEntries();

    $("#btn_createleague, #btn_cancel").prop("disabled", true);

    $.ajax({
        async: false,
        type: "GET",
        url: "/DesktopModules/CreateLeagueModule/API/ModuleCreateLeague/CreateNewLeague",
        data: {
            League_Name: $("#input_leaguename").val(),
            League_Description: $("#input_leaguedescription").val(),
            Join_Allow_Anyone: $("#input_leagueinvite").prop("checked"),
            Creator_User_FK: userId,
            Trade_Day_Enabled: $("#input_leaguetradeday").prop("checked"),
            Randomize_Enabled: $("#input_leaguerandomize").prop("checked"),
            Game_Mode: $("#dropdown_leaguemode").val(),
            League_Duration: $("#dropdown_leagueduration").val(),
            Renew_Duration: $("#input_leaguerenew").prop("checked"),
            League_Icon: 'none', // fill in later
            System_Public: false,
        },
        dataType: "json",
        success: function (data) {
            // redirect to individual league view with newly created league
            console.log(data);
            console.log(JSON.stringify(data));
            window.location = "/leagues"; // temporary until the individual league view is completed
        }
    });
}