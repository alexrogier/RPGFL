<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.CreateLeagueModule.View" %>
<script type="text/javascript">
    var userId = '<%= UserController.Instance.GetCurrentUserInfo().UserID %>';
</script>
<script type="text/javascript" src="/DesktopModules/CreateLeagueModule/js/modulecreateleague.js"></script>
<div class="row container">
    <h1>Create League</h1>
</div>
<div class="row">
    <div class="col-md-7 col-xs-7">
        <form class="form-horizontal">
            <div class="form-group form-group-lg">
                <input class="form-control" type="text" id="input_leaguename" maxlength="55" placeholder="League Name" />
            </div>
        </form>
        <form class="form-horizontal">
            <div class="form-group form-group-md">
                <div class="col-md-12 col-sm-12">
                    <input class="form-control" type="text" id="input_leaguedescription" maxlength="255" placeholder="League Description" />
                </div>
            </div>
        </form>
    </div>
    <div class="col-md-5 col-xs-5">
        <div class="col-md-6 col-xs-6">
            <img id="img_leagueicon" src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="..." class="img-rounded center-img" />
        </div>
    </div>
</div>
<div class="panel panel-default">
    <div class="panel-body">
        <div class="col-md-2 col-xs-2">
            <h4>Game Mode</h4>
            <select class="form-control" id="dropdown_leaguemode">
                <option value="1">Normal</option>
                <option value="2">Damage Dealt</option>
                <option value="3">Damage Taken</option>
                <option value="4">Voting</option>
                <option value="5">Survival</option>
            </select>
            <p>Select specific win types for your league</p>
        </div>
        <div class="col-md-2 col-xs-2">
            <h4>League Duration</h4>
            <select class="form-control" id="dropdown_leagueduration">
                <option value="1">1 Campaign</option>
                <option value="2">2 Campaigns</option>
                <option value="3">3 Campaigns</option>
                <option selected="selected" value="4">Series Long</option>
            </select>
            <p>Select the duration of how long the league will last</p>
        </div>
        <div class="col-md-2 col-xs-2">
            <div class="checkbox">
                <label><input type="checkbox" id="input_leaguerenew" checked="checked" />Renew Enabled</label>
            </div>
            <p>With Renew League activated, this league will automatically be recreated with the same settings at the end of the league's duration</p>
        </div>
        <div class="col-md-2 col-xs-2">
            <div class="checkbox">
                <label><input type="checkbox" id="input_leaguetradeday" checked="checked" />Trade Day Endabled</label>
            </div>
            <p>With Trade Day activated, players will be able to trade out characters from their active draft with other characters that are not currently drafted</p>
        </div>
        <div class="col-md-2 col-xs-2">
            <div class="checkbox">
                <label><input type="checkbox" id="input_leaguerandomize" />Randomize Enabled</label>
            </div>
            <p>With Randomize activated, players will be given a randomly selected draft instead of drafting their own</p>
        </div>
         <div class="col-md-2 col-xs-2">
            <div class="checkbox">
                <label><input type="checkbox" id="input_leagueinvite" />Invite Only</label>
            </div>
            <p>Configures whether any player on the site may join this league or if the league is joinable by invite only</p>
        </div>
    </div>
</div>
<div class="panel panel-default">
    <div class="row">
        <div class="panel-heading">
            <h3 class="panel-title">Invite Friends</h3>
             <div class="input-group" style="width:100%;">
                    <input  type="text" class="form-control" id="input_invite" placeholder="Enter recipient emails here. Seperate emails with a comma." aria-describedby="basic-addon2" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="panel-body text-center">
                <div class="col-md-12 col-xs-12">
                    <button id="btn_createleague" type="button" class="btn primary-button btn-lg">Create League</button>
                    <button id="btn_cancel" type="button" class="btn secondary-button btn-lg">Cancel</button>
                </div>
            </div>
        </div>
    </div>
</div>
