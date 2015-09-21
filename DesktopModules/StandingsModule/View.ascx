<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.StandingsModule.View" %>
<%@ Import Namespace="DotNetNuke.Entities.Users" %>
<script type="text/javascript">
    var userId = '<%= UserController.Instance.GetCurrentUserInfo().UserID %>';
    var displayName = '<%= UserController.Instance.GetCurrentUserInfo().DisplayName %>';
</script>
<script type="text/javascript" src="/DesktopModules/StandingsModule/js/modulestandings.js"></script>
<div class="content">
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
    <div class="scrollable" style="height: 800px;">
        <table>
            <tbody id="table_tbody_standingsdata">
            </tbody>
        </table>

        <br />
      
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
