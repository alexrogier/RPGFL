<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.BattleFrameworkModule.View" %>
<script type="text/javascript">
    var userId = '<%= UserController.Instance.GetCurrentUserInfo().UserID %>';
</script>
<script type="text/javascript" src="/DesktopModules/BattleFrameworkModule/js/moduleBFmain.js"></script>