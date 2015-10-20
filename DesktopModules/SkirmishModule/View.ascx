<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.SkirmishModule.View" %>
<script type="text/javascript" src="/DesktopModules/SkirmishModule/js/moduleskirmishes.js"></script>
<div class="content">
    <h1>Skirmishes</h1>
    <div class="row">
        <div class="col-md-10 col-xs-10">
            <div class="scrollable offical-black-border" style="height: 791px;">
                <table class="table-stacked table-width-100" style="width: 100%;">
                    <tbody id="table_tbody_skirmishdata"></tbody>
                </table>
            </div>
            <br />
            <div class="btn-toolbar" id="button-center" role="toolbar" aria-label="...">
                <div class="btn-group" role="group" aria-label="...">
                    <button type="button" class="btn secondary-button btn-sm">Previous</button>
                </div>
                <div class="btn-group" role="group" aria-label="...">
                    <button type="button" class="btn secondary-button btn-sm">1</button>
                </div>
                <div class="btn-group" role="group" aria-label="...">
                    <button type="button" class="btn secondary-button btn-sm">2</button>
                </div>
                <div class="btn-group" role="group" aria-label="...">
                    <button type="button" class="btn secondary-button btn-sm">3</button>
                </div>
                <div class="btn-group" role="group" aria-label="...">
                    <button type="button" class="btn secondary-button btn-sm">4</button>
                </div>
                <div class="btn-group" role="group" aria-label="...">
                    <button type="button" class="btn secondary-button btn-sm">5</button>
                </div>
                <div class="btn-group" role="group" aria-label="...">
                    <button type="button" class="btn secondary-button btn-sm">Next</button>
                </div>
            </div>
        </div>
        <div class="col-md-2 col-xs-2">
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <h4>Filter Skirmishes</h4>
                        <select id="dropdown_context" class="form-control">
                            <option value="SHOWCURRENT">Current</option>
                            <option value="SHOWFUTURE">Future</option>
                            <option value="SHOWPREVIOUS">Previous</option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 col-xs-2 smallpadding" style="padding-left: 0px">
                    <img alt="" src="/portals/0/RPGFL/skirmish_tall_175x770.jpg" class="pic-border-light" />
                </div>
            </div>
        </div>
    </div>
</div>
