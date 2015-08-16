<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.CharacterViewer.View" %>
<script type="text/javascript">
    var userId = '<%= UserController.Instance.GetCurrentUserInfo().UserID %>';
</script>
<h1>Character Viewer</h1>
    <div class="row">
        <div class="col-md-12 col-xs-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-4 col-xs-4">
                        <select class="form-control">
                            <option>All Guilds</option>
                            <option>Defenders of Light</option>
                            <option>The Netherling</option>
                            <option>Seed of the Grove</option>
                            <option>Artificer Guild</option>
                            <option>The Underdark Menace</option>
                            <option>Thieves Guild</option>
                            <option>Flame Guild(?)</option>
                            <option>Guild Slot(?)</option>
                        </select>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" />All Classes</label>
                        </div>
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" />Healer</label>
                        </div>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" />Assassin</label>
                        </div>
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" />Hunter</label>
                        </div>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" />Bruiser</label>
                        </div>
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" />Sorcerer</label>
                        </div>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" />Enchanter</label>
                        </div>
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" />Tank</label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="panel panel-default">
            <div class="panel-body">
                <table class="table-padding">
                    <tbody>
                        <tr>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                            <td>
                                <img src="/portals/0/RPGFL/standings_avatar_64x64.jpg" class="img-responsive" alt="Responsive image" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
