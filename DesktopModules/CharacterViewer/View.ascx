<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.CharacterViewer.View" %>
<script type="text/javascript">
    var userId = '<%= UserController.Instance.GetCurrentUserInfo().UserID %>';
</script><script type="text/javascript" src="/DesktopModules/CharacterViewer/js/modulecharviewer.js"></script>
  <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
<h1>Character Viewer</h1>
<div class="row">
    <div class="col-md-12 col-xs-12">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-md-4 col-xs-4">
                    <select class="form-control" id="dropdown_guilds">
                        <option value="-1" selected>All Guilds</option>
                    </select>
                </div>
                <div class="col-md-2 col-xs-2">
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="filter_classes" checked="checked" id="filter_allclasses" />All Classes</label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="filter_classes" id="filter_healer" />Healer</label>
                    </div>
                </div>
                <div class="col-md-2 col-xs-2">
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="filter_classes" id="filter_assassin" />Assassin</label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="filter_classes" id="filter_hunter" />Hunter</label>
                    </div>
                </div>
                <div class="col-md-2 col-xs-2">
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="filter_classes" id="filter_bruiser" />Bruiser</label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="filter_classes" id="filter_sorcerer" />Sorcerer</label>
                    </div>
                </div>
                <div class="col-md-2 col-xs-2">
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="filter_classes" id="filter_enchanter" />Enchanter</label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="filter_classes" id="filter_tank" />Tank</label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<center><button class="btn primary-button btn-lg" id="btn_editpriority" type="button">Edit Character Draft Priorities</button></center>
<br />
<div class="row">
    <div class="panel panel-default">
        <div class="panel-body">
            <!--<table class="table-padding">
                <tbody id="characterviewer_table_data"></tbody>
            </table>!-->
            <ul id="characterviewer_table_data" class="mobile-ul-ui"></ul>
        </div>
    </div>
</div>