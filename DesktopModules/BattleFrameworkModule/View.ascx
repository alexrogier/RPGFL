<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.BattleFrameworkModule.View" %>
<%@ Import Namespace="DotNetNuke.Entities.Users" %>

<script type="text/javascript">
    var userId = '<%= UserController.Instance.GetCurrentUserInfo().UserID %>';
</script>
<script type="text/javascript" src="/DesktopModules/BattleFrameworkModule/js/moduleBFmain.js"></script>

<!-- BODY CONTENT -->
<div class="panel panel-default">
    <div class="panel-body">
        <div class="col-md-1 col-xs-1">
            <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" id="guild_1_logo"  alt="" />
        </div>
        <div class="col-ms-2 col-xs-2">
            <h3 class="text-center" id="guild_1_score">0</h3>
        </div>
        <div class="col-md-6 col-xs-6">
            <h2 class="text-center" id="skirmish_date"></h2>
        </div>
        <div class="col-ms-2 col-xs-2">
            <h3 class="text-center" id="guild_2_score">0</h3>
        </div>
        <div class="col-md-1 col-xs-1">
            <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" id="guild_2_logo"  alt="" />
        </div>
    </div>
</div>
<div class="panel panel-default">
    <div class="panel-body">
        <div class="col-md-5 col-xs-5">
            <div class="panel panel-default">
                <div class="panel-body backgroundcolorgray">
                    <div class="row">
                        <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-10 col-xs-10">
                                <h2 class="text-center" id="guild_1_name">Guild Name</h2>
                            </div>
                        <div class="col-md-1 col-xs-1"></div>
                    </div>

                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_1_char_1" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_1_char_1_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_1_char_1_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_1_char_2" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_1_char_2_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_1_char_2_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_1_char_3" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_1_char_3_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_1_char_3_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_1_char_4" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_1_char_4_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_1_char_4_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_1_char_5" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_1_char_5_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_1_char_5_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_1_char_6" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_1_char_6_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_1_char_6_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_1_char_7" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_1_char_7_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_1_char_7_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_1_char_8" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_1_char_8_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_1_char_8_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_1_char_9" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_1_char_9_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_1_char_9_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>  
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_1_char_10" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_1_char_10_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_1_char_10_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_1_char_11" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_1_char_11_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_1_char_11_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_1_char_12" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_1_char_12_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_1_char_12_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-2 col-xs-2">
            <div class="row voffset"></div>
            <div class="row">
                <h2 class="text-center">vs.</h2>
            </div>
        </div>
        <div class="col-md-5 col-xs-5">
            <div class="panel panel-default">
                <div class="panel-body backgroundcolorgray">
                    <div class="row">
                        <div class="col-md-1 col-xs-1"></div>
                        <div class="col-md-11 col-xs-11">
                            <h2 class="text-center" id="guild_2_name">Guild Name</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_2_char_1" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_2_char_1_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_2_char_1_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_2_char_2" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_2_char_2_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_2_char_2_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_2_char_3" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_2_char_3_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_2_char_3_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_2_char_4" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_2_char_4_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_2_char_4_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_2_char_5" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_2_char_5_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_2_char_5_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_2_char_6" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_2_char_6_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_2_char_6_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_2_char_7" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_2_char_7_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_2_char_7_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_2_char_8" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_2_char_8_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_2_char_8_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_2_char_9" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_2_char_9_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_2_char_9_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                     <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_2_char_10" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_2_char_10_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_2_char_10_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_2_char_11" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_2_char_11_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_2_char_11_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img id="guild_2_char_12" class="char_img pic-border-light" src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div id="guild_2_char_12_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p id="guild_2_char_12_healthtext" class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="panel panel-default">
    <div class="panel-body">
        <div class="col-md-3 col-xs-3"></div>
        <div class="col-md-6 col-xs-6">
            <div class="scrollable offical-black-border" style="height: 200px; background-color: darkgray">
                <hr />
                <p class="text-center">
                    <div class="offical-black-border name-container-color font-verdana">
                        <h4 class="text-center defenders-of-light font-verdana">[Gantar the Honorable]</h4>
                    </div>
                    <p class="text-center toppadding">
                        <img src="portals/0/RPGFL/battle_icons/attackicon.png" />
                    </p>
                    <div class="offical-black-border name-container-color">
                        <h4 class="text-center the-netherling font-verdana">[Necromancer]</h4>
                    </div>
                    <h5 class="text-center font-verdana">Roll: x | Dmg: x (Damage type)</h5>
                </p>
                <hr />
                <p class="text-center">
                    <div class="offical-black-border name-container-color font-verdana">
                        <h4 class="text-center seed-of-the-grove font-verdana">[Dwarf Ritualist]</h4>
                    </div>
                    <p class="text-center toppadding">
                        <img src="portals/0/RPGFL/battle_icons/healicon.png" />
                    </p>
                    <div class="offical-black-border name-container-color">
                        <h4 class="text-center seed-of-the-grove font-verdana">[Ent Summoner]</h4>
                    </div>
                    <h5 class="text-center font-verdana">Roll: x | Heal: x </h5>
                </p>
                <hr />
                <p class="text-center">
                    <div class="offical-black-border name-container-color">
                        <h4 class="text-center the-netherling font-verdana">[Lich King]</h4>
                    </div>
                    <p class="text-center toppadding">
                        <img src="portals/0/RPGFL/battle_icons/casticon.png" />
                    </p>
                    <div class="offical-black-border name-container-color">
                        <h4 class="text-center seed-of-the-grove font-verdana">[Ent Summoner]</h4>
                    </div>
                    <h5 class="text-center font-verdana">Roll: x | Eft: x</h5>
                </p>
                <hr />
            </div>
        </div>
    </div>
</div>
<div class="col-md-3 col-xs-3"></div>
