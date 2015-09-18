﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.BattleFrameworkModule.View" %>

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
                            <h2 class="text-center">Guild Name</h2>
                        </div>
                        <div class="col-md-1 col-xs-1"></div>
                    </div>

                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>  
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
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
                            <h2 class="text-center">Guild Name</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 col-xs-2"></div>
                        <div class="text-left col-md-5 col-xs-5">
                            <div class="row">
                                <img src="portals/0/RPGFL/standings_avatar_64x64.jpg" />
                            </div>
                            <div class="row">
                                <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                    <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                        <p class="pill" style="color: black">x / x</p>
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
                    <div class="offical-black-border name-container-color">
                        <h4 class="text-center defenders-of-light">[Gantar the Honorable]</h4>
                    </div>
                    <p class="text-center toppadding">
                        <img src="portals/0/RPGFL/battle_icons/attackicon.png" />
                    </p>
                    <div class="offical-black-border name-container-color">
                        <h4 class="text-center the-netherling">[Necromancer]</h4>
                    </div>
                    <h5 class="text-center">Roll: x | Dmg: x (Damage type)</h5>
                </p>
                <hr />
                <p class="text-center">
                    <div class="offical-black-border name-container-color">
                        <h4 class="text-center seed-of-the-grove">[Dwarf Ritualist]</h4>
                    </div>
                    <p class="text-center toppadding">
                        <img src="portals/0/RPGFL/battle_icons/healicon.png" />
                    </p>
                    <div class="offical-black-border name-container-color">
                        <h4 class="text-center seed-of-the-grove">[Ent Summoner]</h4>
                    </div>
                    <h5 class="text-center">Roll: x | Heal: x </h5>
                </p>
                <hr />
                <p class="text-center">
                    <div class="offical-black-border name-container-color">
                        <h4 class="text-center the-netherling">[Lich King]</h4>
                    </div>
                    <p class="text-center toppadding">
                        <img src="portals/0/RPGFL/battle_icons/casticon.png" />
                    </p>
                    <div class="offical-black-border name-container-color">
                        <h4 class="text-center seed-of-the-grove">[Ent Summoner]</h4>
                    </div>
                    <h5 class="text-center">Roll: x | Eft: x</h5>
                </p>
                <hr />
            </div>
        </div>
    </div>
</div>
<div class="col-md-3 col-xs-3"></div>
