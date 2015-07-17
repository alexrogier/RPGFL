<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.AlertModule.View" %>
<div runat="server" id="alertcontainer" class="container">
    <% foreach (var a in Alerts){ %>
        <div class="alert alert-warning col-xs-12 col-md-12" role="alert">
            <span><strong><%=a.Alert_Name%></strong> <%=a.Alert_Message%></span>
        </div>
    <% } %>
</div>
