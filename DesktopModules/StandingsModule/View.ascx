<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.StandingsModule.View" %>

<div class="container">
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="row">
                <div class="col-md-4 col-xs-4">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                    </div>
                </div>
                <div class="col-md-6 col-xs-6">
                    <h2>Global User Standings</h2>
                </div>
                <div class="col-md-2 col-xs-2"></div>
            </div>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="row">
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <div class="col-md-3 col-xs-3"></div>
                <div class="center-div-text">
                    <div class="col-md-2 col-xs-2">
                        <select class="form-control" style="width: 170px;">
                            <option>Overall</option>
                            <option>Damage Dealt</option>
                            <option>Damage Taken</option>
                            <option>Opponent Knockouts</option>
                            <option>Critical Rolling</option>
                            <option>Healing</option>
                            <option>Enchanter / Hunter</option>
                            <option>Afflictions</option>
                            <option>Action Voting</option>
                            <option>Target Voting</option>
                        </select>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <select class="form-control" style="width: 170px;">
                            <option>Show Global</option>
                            <option>Show Only Me</option>
                        </select>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <select class="form-control" style="width: 170px;">
                            <option>No League Filter</option>
                            <option>League 1</option>
                            <option>League 1</option>
                            <option>League 1</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
        <!--<ul class="nav navbar-nav nav-font-size">
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Accolade Filter<span class="caret"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="#">Overall</a></li>
                                        <li><a href="#">Damage Dealt</a></li>
                                        <li><a href="#">Damage Taken</a></li>
                                        <li><a href="#">Opponent Knockouts</a></li>
                                        <li><a href="#">Critical Rolling</a></li>
                                        <li><a href="#">Healing</a></li>
                                        <li><a href="#">Enchanter / Hunter</a></li>
                                        <li><a href="#">Afflictions</a></li>
                                        <li><a href="#">Action Voting</a></li>
                                        <li><a href="#">Target Voting</a></li>
                                    </ul>
                                </li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Stats<span class="caret"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="#">Show Global</a></li>
                                        <li><a href="#">Show Only Me</a></li>
                                    </ul>
                                </li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">No League Filter<span class="caret"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="#">No League Filter</a></li>
                                        <li><a href="#">League 1</a></li>
                                        <li><a href="#">League 2</a></li>
                                        <li><a href="#">League 3</a></li>
                                    </ul>
                                </li>
                            </ul>-->
        <!-- /.navbar-collapse -->
        <!-- /.container-fluid -->
    </nav>
    <div class="panel panel-default" style="width: 1157px;">
        <div class="panel-body">
            <div class="scrollable" style="height: 800px;">
                <table>
                    <!-- Top 10 -->
                    <tbody>
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
                        <tr class="offical-black-border center-div">
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
        <!--<nav id="center-buttons-standings">
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
        <div class="btn-toolbar" id="center-buttons-standings" role="toolbar" aria-label="...">
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
