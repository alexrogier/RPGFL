<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.BattleFrameworkModule.View" %>
<%@ Import Namespace="DotNetNuke.Entities.Users" %>

<script type="text/javascript">
    var userId = '<%= UserController.Instance.GetCurrentUserInfo().UserID %>';
</script>
<script type="text/javascript" src="/DesktopModules/BattleFrameworkModule/js/moduleBFmain.js"></script>

<div id="battleskirmish">
    <!-- BODY CONTENT -->
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="col-md-1 col-xs-1">
                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" id="guild_1_logo" alt="" />
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
                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" id="guild_2_logo" alt="" />
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

                        <div class="text-center row">
                            <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_1_char_1_statusbar">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 col-xs-2">
                                        <p>1</p>
                                    </div>
                                    <div class="col-md-5 col-xs-5">
                                        <div class="row">
                                            <div style="position: relative">
                                                <img id="guild_1_char_1" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                                <div id="guild_1_char_1_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                                <div id="guild_1_char_1_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                                <div id="guild_1_char_1_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                                    <p id="guild_1_char_1_healthtext" class="pill" style="color: black">x / x</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-5 col-xs-5">
                                        <div style="height: 100%; background-color: gray; width: 100%; border-top: 3px solid black; border-right: 2px solid black; border-bottom: 3px solid black; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_1_char_2_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_1_char_2" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_1_char_2_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_1_char_2_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_1_char_2_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_1_char_2_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-xs-1"></div>
                        </div>

                        <div class="text-center row">
                            <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_1_char_3_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_1_char_3" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_1_char_3_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_1_char_3_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_1_char_3_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_1_char_3_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_1_char_4_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_1_char_4" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_1_char_4_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_1_char_4_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_1_char_4_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_1_char_4_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-xs-1"></div>
                        </div>

                        <div class="text-center row">
                            <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_1_char_5_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_1_char_5" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_1_char_5_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_1_char_5_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_1_char_5_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_1_char_5_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_1_char_6_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_1_char_6" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_1_char_6_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_1_char_6_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_1_char_6_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_1_char_6_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-xs-1"></div>
                        </div>

                        <div class="text-center row">
                            <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_1_char_7_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_1_char_7" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_1_char_7_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_1_char_7_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_1_char_7_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_1_char_7_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_1_char_8_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_1_char_8" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_1_char_8_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_1_char_8_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_1_char_8_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_1_char_8_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-xs-1"></div>
                        </div>
                        <div class="text-center row">
                            <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_1_char_9_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_1_char_9" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_1_char_9_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_1_char_9_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_1_char_9_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_1_char_9_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_1_char_10_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_1_char_10" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_1_char_10_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_1_char_10_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_1_char_10_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_1_char_10_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-xs-1"></div>
                        </div>

                        <div class="text-center row">
                            <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_1_char_11_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_1_char_11" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_1_char_11_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_1_char_11_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_1_char_11_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_1_char_11_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_1_char_12_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_1_char_12" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_1_char_12_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_1_char_12_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_1_char_12_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_1_char_12_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-xs-1"></div>
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

                        <div class="text-center row">
                            <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_2_char_1_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_2_char_1" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_2_char_1_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_2_char_1_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_2_char_1_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_2_char_1_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_2_char_2_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_2_char_2" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_2_char_2_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_2_char_2_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_2_char_2_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_2_char_2_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-xs-1"></div>
                        </div>

                        <div class="text-center row">
                            <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_2_char_3_statusbar">
                                    </div>
                                    <div style="position: relative">
                                        <img id="guild_2_char_3" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                        <div id="guild_2_char_3_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                        <div id="guild_2_char_3_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                    </div>
                                    <div class="row">
                                        <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                            <div id="guild_2_char_3_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                                <p id="guild_2_char_3_healthtext" class="pill" style="color: black">x / x</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_2_char_4_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_2_char_4" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_2_char_4_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_2_char_4_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_2_char_4_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_2_char_4_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-xs-1"></div>
                        </div>

                        <div class="text-center row">
                            <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_2_char_5_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_2_char_5" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_2_char_5_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_2_char_5_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_2_char_5_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_2_char_5_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_2_char_6_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_2_char_6" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_2_char_6_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_2_char_6_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_2_char_6_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_2_char_6_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-xs-1"></div>
                        </div>

                        <div class="text-center row">
                            <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_2_char_7_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_2_char_7" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_2_char_7_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_2_char_7_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_2_char_7_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_2_char_7_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_2_char_8_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_2_char_8" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_2_char_8_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_2_char_8_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_2_char_8_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_2_char_8_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-xs-1"></div>
                        </div>

                        <div class="text-center row">
                            <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_2_char_9_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_2_char_9" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_2_char_9_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_2_char_9_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_2_char_9_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_2_char_9_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_2_char_10_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_2_char_10" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_2_char_10_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_2_char_10_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_2_char_10_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_2_char_10_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-xs-1"></div>
                        </div>

                        <div class="text-center row">
                            <div class="col-md-1 col-xs-1"></div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_2_char_11_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_2_char_11" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_2_char_11_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_2_char_11_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_2_char_11_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_2_char_11_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 col-xs-5">
                                <div class="row">
                                    <div class="conditionbar" id="guild_2_char_12_statusbar">
                                    </div>
                                </div>
                                <div style="position: relative">
                                    <img id="guild_2_char_12" class="char_img pic-border-light" src="/portals/0/RPGFL/standings_avatar_64x64.jpg" />
                                    <div id="guild_2_char_12_activeicon_left" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: 29%; z-index: 10;"></div>
                                    <div id="guild_2_char_12_activeicon_right" class="container_activeicon" style="position: absolute; width: 100%; height: 100%; top: -8%; left: -29%; z-index: 10;"></div>
                                </div>
                                <div class="row">
                                    <div class="progress offical-black-border pill text-center inline-block text-right" style="background-color: #d9534f">
                                        <div id="guild_2_char_12_healthbar" class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 64px; background-color: #B20000">
                                            <p id="guild_2_char_12_healthtext" class="pill" style="color: black">x / x</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-xs-1"></div>
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
                <div id="combatlogcontainer" class="primary-button scrollable offical-black-border" style="height: 200px;">

                    <div class="accordion" id="accordion_">
                        <div class="accordion-group">
                            <div class="accordion-heading">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion_" href="#accordionbody_"></a>
                            </div>
                            <div id="accordionbody_" class="accordion-body collapse in">
                                <div class="accordion-inner">
                                    <div class="text-center topbotpadding offical-black-border name-container-color font-verdana">
                                        <p class="inline text-center guild'+ assailant.Guild_FK +' font-verdana">'+ assailant.Character_Name +'</p>
                                        <img class="inline" src="'+ logIcon +'" />

                                        <p class="inline text-center guild' + target.Guild_FK + ' font-verdana">' + target.Character_Name + '</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class="col-md-3 col-xs-3"></div>
        </div>
    </div>
</div>
