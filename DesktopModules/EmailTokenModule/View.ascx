<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.EmailTokenModule.View" %>
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

    $(document).ready(function() {
        // ajax call for token
        var email = getUrlParameter("email");
        var token = getUrlParameter("token");

        console.log(email);
        console.log(token);
        if (email == null || token == null) {
            // redirect to home page if invalid
            window.location = "/";
        } else {

            var tokenData = null;
            $.ajax({
                async: false,
                type: "GET",
                url: "/DesktopModules/EmailTokenModule/API/ModuleEmailToken/AttemptLeagueInvitationAcceptance",
                data: {
                    Token: token,
                    Email: email
                },
                dataType: "json",
                success: function(data) {
                    tokenData = JSON.parse(data);
                }
            });

            console.log(tokenData);
            if (tokenData == null || tokenData == false) {
                // display message that invitation wasn't accepted
                $("#token_msg").text("The invitation request you have submitted has not been accepted because it is invalid. Please ensure you have an account with RPGFL registered with the email inside the invitation.");
            } else {
                // invitation accepted, redirect user to leagues page
                window.location = "/leagues";   
            }
        }
    });
</script>
<h3 id="token_msg"></h3>