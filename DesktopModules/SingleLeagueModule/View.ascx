<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.SingleLeagueModule.View" %>
<script type="text/javascript">
    var userId = '<%= UserController.Instance.GetCurrentUserInfo().UserID %>';
</script>
<script src="/DesktopModules/SingleLeagueModule/js/modulesingleleague.js"></script>
<div id="404_league_not_found">
    <h1>LEAGUE NOT FOUND</h1>
</div>
<div id="league_permissions">
    <h1>THIS LEAGUE IS PRIVATE</h1>
</div>
<div id="league_data" style="display:none">
    <div class="row">
        <div class="panel panel-default">
            <div class="panel-body">
                <h1 class="text-center" id="league_name">League Name</h1>
                <hr />
                <ul class="mobile-ul-ui">
                    <li class="ui-state-default mobile-li-ui" >
                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="user_1_score" class="offical-black-border text-center">-</p>
                    </li>
                    <li class="ui-state-default mobile-li-ui" >
                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="user_2_score" class="offical-black-border text-center">-</p>
                    </li>
                    <li class="ui-state-default mobile-li-ui" >
                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="user_3_score" class="offical-black-border text-center">-</p>
                    </li>
                    <li class="ui-state-default mobile-li-ui" >
                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="user_4_score" class="offical-black-border text-center">-</p>
                    </li>
                    <li class="ui-state-default mobile-li-ui" >
                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="user_5_score" class="offical-black-border text-center">-</p>
                    </li>
                    <li class="ui-state-default mobile-li-ui" >
                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="user_6_score" class="offical-black-border text-center">-</p>
                    </li>
                    <li class="ui-state-default mobile-li-ui" >
                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="user_7_score" class="offical-black-border text-center">-</p>
                    </li>
                    <li class="ui-state-default mobile-li-ui" >
                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="user_8_score" class="offical-black-border text-center">-</p>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-6 col-xs-6" style="padding-left:24%">
                    <div class="row">
                        <label class="col-md-6 col-xs-6">Game Mode: </label>
                        <p id="league_gamemode" class="col-md-6 col-xs-6">&nbsp;</p>
                    </div>
                    <div class="row">
                        <label class="col-md-6 col-xs-6">League Duration: </label>
                        <p id="league_duration" class="col-md-6 col-xs-6">&nbsp;</p>
                    </div>
                    <div class="row">
                        <label class="col-md-6 col-xs-6">Renew Duration: </label>
                        <p id="league_renew" class="col-md-6 col-xs-6">&nbsp;</p>
                    </div>
                </div>
                <div class="col-md-6 col-xs-6" style="padding-right:24%">
                    <div class="row">
                        <label class="col-md-6 col-xs-6">Trade Day: </label>
                        <p id="league_tradeday" class="col-md-6 col-xs-6">&nbsp;</p>
                    </div>
                    <div class="row">
                        <label class="col-md-6 col-xs-6">Randomized: </label>
                        <p id="league_randomize" class="col-md-6 col-xs-6">&nbsp;</p>
                    </div>
                    <div class="row">
                        <label class="col-md-6 col-xs-6">Invite Only: </label>
                        <p id="league_invite" class="col-md-6 col-xs-6">&nbsp;</p>
                    </div>
                </div>
                <div class="col-md-2 col-xs-2"></div>
            </div>
            <div class="row text-center">
                <div>
                    <button id="btn_joinleague" type="button" class="btn primary-button btn-lg">Join League</button>
                    <button id="btn_leaveleague" type="button" class="btn primary-button btn-lg" style="display: none">Leave League</button>
                    <button id="btn_cancel" type="button" class="btn secondary-button btn-lg">Cancel</button>
                </div>
            </div>
            <div class="row text-center">
                 <label id="label_loggedout" style="display:none;">You must be logged in to join a league</label>
            </div>
        </div>
    </div>
    <div id="league_characterlineup" class="panel panel-default">
        <div class="panel-body">
            <div class="row">
                <h1 class="text-center">Character Lineup</h1>
                <h5 class="text-center"><a href="/characterviewer">Character Preferences</a></h5>
                <hr />
            </div>
            <div class="row" style="margin: 20px;">
                <ul class="mobile-ul-ui">
                    <li class="ui-state-default mobile-li-ui">
                        <img id="char_1_img" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="char_1_score" class="offical-black-border text-center">-</p>

                    </li>
                    <li class="ui-state-default mobile-li-ui">
                        <img id="char_2_img" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="char_2_score" class="offical-black-border text-center">-</p>

                    </li>
                    <li class="ui-state-default mobile-li-ui">
                        <img id="char_3_img" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="char_3_score" class="offical-black-border text-center">-</p>

                    </li>
                    <li class="ui-state-default mobile-li-ui">
                        <img id="char_4_img" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="char_4_score" class="offical-black-border text-center">-</p>

                    </li>
                    <li class="ui-state-default mobile-li-ui">
                        <img id="char_5_img" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="char_5_score" class="offical-black-border text-center">-</p>

                    </li>
                    <li class="ui-state-default mobile-li-ui">
                        <img id="char_6_img" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="char_6_score" class="offical-black-border text-center">-</p>

                    </li>
                    <li class="ui-state-default mobile-li-ui">
                        <img id="char_7_img" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="char_7_score" class="offical-black-border text-center">-</p>

                    </li>
                    <li class="ui-state-default mobile-li-ui">
                        <img id="char_8_img" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="char_8_score" class="offical-black-border text-center">-</p>

                    </li>
                    <li class="ui-state-default mobile-li-ui">
                        <img id="char_9_img" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="char_9_score" class="offical-black-border text-center">-</p>

                    </li>
                    <li class="ui-state-default mobile-li-ui">
                        <img id="char_10_img" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="char_10_score" class="offical-black-border text-center">-</p>

                    </li>
                    <li class="ui-state-default mobile-li-ui">
                        <img id="char_11_img" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="char_11_score" class="offical-black-border text-center">-</p>

                    </li>
                    <li class="ui-state-default mobile-li-ui">
                        <img id="char_12_img" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="" />
                        <p id="char_12_score" class="offical-black-border text-center">-</p>

                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
