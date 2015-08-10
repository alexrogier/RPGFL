<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.LeagueModule.View" %>
<script type="text/javascript">
    var userId = '<%= UserController.Instance.GetCurrentUserInfo().UserID %>';
</script>
<script src="/DesktopModules/LeagueModule/js/moduleleagues.js"></script>
<div class="container">
    <div class="panel panel-default">
        <div class="panel-body">
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
    </div>
</div>