<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.StandingsModule.View" %>
<script type="text/javascript">
    var userId = '<%= UserController.Instance.GetCurrentUserInfo().UserID %>';
    var displayName = '<%= UserController.Instance.GetCurrentUserInfo().DisplayName %>';
</script>
<script type="text/javascript" src="/DesktopModules/StandingsModule/js/modulestandings.js"></script>
<div class="container">
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12 col-xs-12">
                    <h2 class="text-center">User Standings</h2>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <div class="col-md-4 col-xs-4"></div>
                <div class="div-center-text">
                    <div class="col-md-2 col-xs-2">
                        <select class="form-control" style="width: 170px;" id="dropdown_accolade">
                            <option value="Overall">Overall</option>
                            <option value="Damage_Dealt">Damage Dealt</option>
                            <option value="Damage_Taken">Damage Taken</option>
                            <option value="Opponent_Knock_Outs">Opponent Knockouts</option>
                            <option value="Critical_Successes">Critical Rolling</option>
                            <option value="Health_Regained">Healing</option>
                            <option value="Enchanter_Hunter">Enchanter / Hunter</option>
                            <option value="Afflictions_Inflicted">Afflictions</option>
                            <option value="Accolade_Action_Vote">Action Voting</option>
                            <option value="Accolade_Target_Vote">Target Voting</option>
                        </select>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <select class="form-control" style="width: 170px;" id="dropdown_context">
                            <option>Show Everyone</option>
                            <option>Show Only Me</option>
                        </select>
                    </div>
                    <div class="col-md-1 col-xs-1"></div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 col-xs-12">
                <br />
            </div>
        </div>
    </nav>
    <div class="panel panel-default" style="width: 1157px;">
        <div class="panel-body">
            <div class="scrollable" style="height: 800px;">
                <table>
                    <tbody id="table_tbody_standingsdata">
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">1.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">2.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">3.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">4.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">5.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">6.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">7.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">8.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">9.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">10.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <!-- Top 20 -->
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">11.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">12.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">13.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">14.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">15.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">16.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">17.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">18.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">19.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <tr class="offical-black-border div-center">
                            <td>
                                <div class="smallpadding">
                                    <p class="text-center">20.</p>
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_user_75x75.jpg" alt="User" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                    <p>Username</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 2" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 3" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 4" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 5" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 6" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 7" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 8" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 9" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 10" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 11" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 12" />
                                    </a>
                                    <p class="offical-black-border text-center">xxx</p>
                                </div>
                            </td>
                        </tr>
                        <!-- Stop Count -->
                    </tbody>
                </table>
            </div>
        </div>
        <br />
        <!--<nav id="standings-button-center">
                    <ul class="pagination">
                        <li>
                            <a href="#" aria-label="Previous">
                                <span aria-hidden="true">&laquo;</span>
                            </a>
                        </li>
                        <li><a href="#">1</a></li>
                        <li><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#">4</a></li>
                        <li><a href="#">5</a></li>
                        <li>
                            <a href="#" aria-label="Next">
                                <span aria-hidden="true">&raquo;</span>
                            </a>
                        </li>
                    </ul>
                </nav>-->
        <div class="btn-toolbar" id="standings-button-center" role="toolbar" aria-label="...">
            <div class="btn-group" role="group" aria-label="...">
                <button type="button" class="secondary-button btn btn-sm">Previous</button>
            </div>
            <div class="btn-group" role="group" aria-label="...">
                <button type="button" class="secondary-button btn btn-sm">1</button>
            </div>
            <div class="btn-group" role="group" aria-label="...">
                <button type="button" class="secondary-button btn btn-sm">2</button>
            </div>
            <div class="btn-group" role="group" aria-label="...">
                <button type="button" class="secondary-button btn btn-sm">3</button>
            </div>
            <div class="btn-group" role="group" aria-label="...">
                <button type="button" class="secondary-button btn btn-sm">4</button>
            </div>
            <div class="btn-group" role="group" aria-label="...">
                <button type="button" class="secondary-button btn btn-sm">5</button>
            </div>
            <div class="btn-group" role="group" aria-label="...">
                <button type="button" class="secondary-button btn btn-sm">Next</button>
            </div>
        </div>
        <br />
    </div>
</div>
