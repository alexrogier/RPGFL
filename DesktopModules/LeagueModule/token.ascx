<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="token.ascx.cs" Inherits="Christoc.Modules.LeagueModule.token" %>
<script type="text/javascript">
    function getUrlParameter(sParam) {
        var sPageURL = decodeURIComponent(window.location.search.substring(1)),
            sURLVariables = sPageURL.split('&'),
            sParameterName,
            i;

        for (i = 0; i < sURLVariables.length; i++) {
            sParameterName = sURLVariables[i].split('=');

            if (sParameterName[0] === sParam) {
                return sParameterName[1] === undefined ? true : sParameterName[1];
            }
        }
    }

    $(document).ready(function () {
        var email = getUrlParameter("email");
        var token = getUrlParameter("token");

        $.ajax({
            async: false,
            type: "GET",
            url: "/DesktopModules/LeagueModule/API/ModuleLeague/AcceptLeagueInvitation",
            data: {
                Email: email,
                Token: token
            },
            dataType: "json",
            success: function (data) {
                console.log(data);
            }
        });
    });
</script>
