$(document).ready(function () {
    //var test = '';
    //$.when($.getJSON("/DesktopModules/StandingsModule/API/ModuleStandings/GetStandings",
    //    function (result) {
    //        var parsedTaskJSONObject = jQuery.parseJSON(result);
    //        console.log(parsedTaskJSONObject);
    //        test = parsedTaskJSONObject;
    //    })).done(function(){
    //        alert(JSON.stringify(test));
    //    });

    // @userId - defined in view.ascx

    var userLeagues = getUserLeagues(userId);
    console.log(userLeagues);
});

function getUserLeagues(userId){
    $.getJSON("/DesktopModules/LeagueModule/API/ModuleLeague/GetLeagues", { User_PK: userId })
        .done(function (result) {
            var jsonResult = jQuery.parseJSON(result);
            return jsonResult;
        });
}