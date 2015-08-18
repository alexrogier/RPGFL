<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.SingleLeagueModule.View" %>
<script type="text/javascript">
    var userId = '<%= UserController.Instance.GetCurrentUserInfo().UserID %>';
</script>
<script src="/DesktopModules/SingleLeagueModule/js/modulesingleleague.js"></script>
<div id="404_league_not_found">
    <h1>LEAGUE NOT FOUND</h1>
</div>
<div id="league_data" style="display:none">
    <div class="row">
        <div class="panel panel-default">
            <div class="panel-body">
                <h1 class="text-center" id="league_name">League Name</h1>
                <hr />
                <div class="col-md-2 col-xs-2"></div>
                <div class="col-md-1 col-xs-1">
                    <div class="smallpadding leagues-pill-width">
                        <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                            <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                        </a>
                        <p id="user_1_score" class="offical-black-border text-center">-</p>
                    </div>
                </div>
                <div class="col-md-1 col-xs-1">
                    <div class="smallpadding leagues-pill-width">
                        <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                            <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                        </a>
                        <p id="user_2_score" class="offical-black-border text-center">-</p>
                    </div>
                </div>
                <div class="col-md-1 col-xs-1">
                    <div class="smallpadding leagues-pill-width">
                        <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                            <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                        </a>
                        <p id="user_3_score" class="offical-black-border text-center">-</p>
                    </div>
                </div>
                <div class="col-md-1 col-xs-1">
                    <div class="smallpadding leagues-pill-width">
                        <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                            <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                        </a>
                        <p id="user_4_score" class="offical-black-border text-center">-</p>
                    </div>
                </div>
                <div class="col-md-1 col-xs-1">
                    <div class="smallpadding leagues-pill-width">
                        <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                            <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                        </a>
                        <p id="user_5_score" class="offical-black-border text-center">-</p>
                    </div>
                </div>
                <div class="col-md-1 col-xs-1">
                    <div class="smallpadding leagues-pill-width">
                        <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                            <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                        </a>
                        <p id="user_6_score" class="offical-black-border text-center">-</p>
                    </div>
                </div>
                <div class="col-md-1 col-xs-1">
                    <div class="smallpadding leagues-pill-width">
                        <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                            <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                        </a>
                        <p id="user_7_score" class="offical-black-border text-center">-</p>
                    </div>
                </div>
                <div class="col-md-1 col-xs-1">
                    <div class="smallpadding leagues-pill-width">
                        <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                            <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                        </a>
                        <p id="user_8_score" class="offical-black-border text-center">-</p>
                    </div>
                </div>
                <div class="col-md-1 col-xs-1"></div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="row text-center">
                <div class="col-md-4 col-xs-4"></div>
                <div class="col-md-3 col-xs-3">
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
                <div class="col-md-3 col-xs-3">
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
            <div class="row">
                <div class="col-md-5 col-xs-5"></div>
                <div class="col-md-4 col-xs-4">
                    <button id="btn_joinleague" type="button" class="btn primary-button btn-lg">Join League</button>
                    <button id="btn_leaveleague" type="button" class="btn primary-button btn-lg" style="display: none">Leave League</button>
                    <button id="btn_cancel" type="button" class="btn secondary-button btn-lg">Cancel</button>
                </div>
                <div class="col-md-2 col-xs-3"></div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="row">
                <h1 class="text-center">Character Lineup</h1>
                <h5 class="text-center"><a href="#">Character Preferences</a></h5>
                <hr />
            </div>
            <div class="row" style="width: 50%; margin: 20px;">
                <table>
                    <tbody>
                        <tr class="div-center">
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">-</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">-</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">-</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">-</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">-</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">-</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">-</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">-</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">-</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">-</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">-</p>
                                </div>
                            </td>
                            <td>
                                <div class="smallpadding">
                                    <a href="#" class="media" data-toggle="tooltip" title="Character Tooltip">
                                        <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" alt="Character 1" />
                                    </a>
                                    <p class="offical-black-border text-center">-</p>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
<!-- CHARACTER PREVIEW MODAL -->
    <div id="userPreviewModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 id="charactermodal_title" class="modal-title">CHARACTER NAME</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-6 col-md-6">
                            <div class="row">
                                <center><img id="charactermodal_portrait" alt="" src="" /></center>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-6">
                            <div class="row text-center">
                                <h4 class="smallpadding">STATS</h4>
                            </div>
                            <div class="row">
                                <div class="col-sm-6 col-md-6">
                                    <div class="row"><label class="col-sm-6 col-md-6"><strong>Health</strong></label><p class="borderless col-sm-6 col-md-6" id="charactermodal_stats_health" /></div>
                                    <div class="row"><label class="col-sm-6 col-md-6"><strong>Dodge</strong></label><p class="borderless col-sm-6 col-md-6" id="charactermodal_stats_dodge" /></div>
                                    <div class="row"><label class="col-sm-6 col-md-6"><strong>Archetype</strong></label></div>
                                    <div class="row"><p class="borderless col-sm-12 col-md-12" id="charactermodal_stats_archetype" /></div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="row"><label class="col-sm-6 col-md-6"><strong>Energy</strong></label><p class="borderless col-sm-6 col-md-6" id="charactermodal_stats_maxenergy" /></div>
                                    <div class="row"><label class="col-sm-6 col-md-6"><strong>Intiative</strong></label><p class="borderless col-sm-6 col-md-6" id="charactermodal_stats_initiative" /></div>
                                    <div class="row"><label class="col-sm-6 col-md-6"><strong>Guild</strong></label></div>
                                    <div class="row"><p class="borderless col-sm-12 col-md-12" id="charactermodal_stats_guild" /></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="text-center">
                                    <div class="row col-sm-12 col-md-12">
                                        <div class="col-sm-3 col-md-3"><label><strong>Finesse</strong></label></div>
                                        <div class="col-sm-3 col-md-3"><label><strong>Agility</strong></label></div>
                                        <div class="col-sm-3 col-md-3"><label><strong>Senses</strong></label></div>
                                        <div class="col-sm-3 col-md-3"><label><strong>Mana</strong></label></div>
                                    </div>
                                    <div class="row  col-sm-12 col-md-12">
                                        <div class="col-sm-3 col-md-3"><p id="charactermodal_stats_finesse"></p></div>
                                        <div class="col-sm-3 col-md-3"><p id="charactermodal_stats_agility"></p></div>
                                        <div class="col-sm-3 col-md-3"><p id="charactermodal_stats_senses"></p></div>
                                        <div class="col-sm-3 col-md-3"><p id="charactermodal_stats_mana"></p></div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-1 col-md-1"></div>
                                <div class="col-sm-10 col-md-10">
                                    <div class="row"><label class="col-sm-5 col-md-5"><strong>Immunities</strong></label><p class="col-sm-4 col-md-4" id="charactermodal_stats_immunities"></p></div>
                                    <div class="row"><label class="col-sm-5 col-md-5"><strong>Vulnerabilities</strong></label><p class="col-sm-4 col-md-4" id="charactermodal_stats_vulnerabilities"></p></div>
                                    <div class="row"><label class="col-sm-5 col-md-5"><strong>Resistances</strong></label><p class="col-sm-4 col-md-4" id="charactermodal_stats_resistances"></p></div>
                                </div>
                                <div class="col-sm-1 col-md-1"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <h4 class="smallpadding">SKILLS</h4>
                    </div>
                    <div id="charactermodal_skills" class="row">

                    </div>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
    <!-- END CHARACTER PREVIEW MODAL -->
