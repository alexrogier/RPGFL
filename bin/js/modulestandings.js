$(document).ready(function () {
    $.getJSON("/DesktopModules/StandingsModule/API/ModuleStandings/GetStandings",
        function (result) {
            var parsedTaskJSONObject = jQuery.parseJSON(result);
            console.log(parsedTaskJSONObject);
        });
});