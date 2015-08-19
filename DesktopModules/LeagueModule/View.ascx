<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.LeagueModule.View" %>
<script type="text/javascript">
    var userId = '<%= UserController.Instance.GetCurrentUserInfo().UserID %>';
</script>
<script src="/DesktopModules/LeagueModule/js/moduleleagues.js"></script>
<div class="content">
    <div class="row">
        <div class="col-md-3">
            <a href="#">
                <img src="/portals/0/RPGFL/matchmaking.jpg" class="img-responsive" alt="Responsive image" /></a>
        </div>
        <div class="col-md-6">
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eu metus nec libero fermentum rhoncus. Duis ut elementum magna. Donec commodo, lacus vel pellentesque bibendum, ipsum odio faucibus sem, non luctus augue sapien sit amet purus. Donec hendrerit et erat ac aliquam. Etiam vestibulum pulvinar mi vel ornare. Praesent vel leo purus. Sed semper aliquet lorem in viverra. Curabitur pretium ornare varius. Morbi et justo non metus tristique vehicula et ut neque. Quisque ac ex purus. Maecenas congue pulvinar lorem, nec pharetra arcu tempus id.
            </p>
        </div>
        <div class="col-md-3">
            <a href="#">
                <img src="/portals/0/RPGFL/createleague.jpg" class="img-responsive" alt="Responsive image" /></a>
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-md-3">
            <select id="dropdown_context" class="form-control">
                <option value="SHOWUSERLEAGUES">Show My Leagues</option>
                <option value="SHOWALLLEAGUES">Show Joinable Leagues</option>
            </select>
        </div>
        <div class="col-md-6">
            <h3 class="text-center">Current Leagues</h3>
        </div>
        <div class="col-md-3">
            <div class="input-group" style="text-align: right;">
                <form id="search">
                    <input id="filter_search" type="text" class="form-control" placeholder="Search" />
                </form>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <table class="table-stacked table-width-100" style="width: 100%;">
                <tbody id="table_tbody_leaguedata"></tbody>
            </table>
        </div>
    </div>
</div>