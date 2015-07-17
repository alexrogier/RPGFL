<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="DNNLINK" Src="~/Admin/Skins/DnnLink.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LINKTOMOBILE" Src="~/Admin/Skins/LinkToMobileSite.ascx" %>
<%@ Register TagPrefix="dnn" TagName="META" Src="~/Admin/Skins/Meta.ascx" %>
<%@ Register TagPrefix="dnn" TagName="MENU" src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<%@ Register TagPrefix="dnn" TagName="Alert" Src="~/DesktopModules/AlertModule/View.ascx" %>
<dnn:META ID="mobileScale" runat="server" Name="viewport" Content="width=device-width,initial-scale=1" />
<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="css/main.css" PathNameAlias="SkinPath" Priority="1" />
<dnn:DnnCssInclude ID="DnnCssInclude2" runat="server" FilePath="css/bootstrap.css" PathNameAlias="SkinPath" Priority="13" />
<dnn:DnnJsInclude ID="DnnJsInclude3" runat="server" FilePath="js/rpgflconfig.js" PathNameAlias="SkinPath" Priority="1010" ForceProvider="DnnFormBottomProvider" />
<dnn:DnnJsInclude ID="DnnJsInclude1" runat="server" FilePath="js/main.js" PathNameAlias="SkinPath" Priority="1010" ForceProvider="DnnFormBottomProvider" />
<dnn:DnnJsInclude ID="DnnJsInclude2" runat="server" FilePath="js/bootstrap.min.js" PathNameAlias="SkinPath" Priority="1011" ForceProvider="DnnFormBottomProvider" />

<div id="wrapper">
	<!-- HEADER -->
    <div id="header" class="container opacity-high">
		<!-- BANNER LOGO -->
		<div class="row">
				<!--<center><img src="/portals/_default/skins/rpgfl/img/banner.jpg" alt="" /></center>-->
		</div>
		<div class="row">
				<h1 id="header_title" class="col-sm-10 col-md-10">RPGFL <small id="header_subtitle">Role Playing Game Fantasy League</small></h1>
				<!-- SOCIAL MEDIA -->
				<div class="col-xs-2 col-md-2">
					<a href="/portals/_default/skins/rpgfl/#"><img src="/portals/_default/skins/rpgfl/img/icon_facebook.png" alt="Checkout our Facebook!" /></a>
					<a href="/portals/_default/skins/rpgfl/#"><img src="/portals/_default/skins/rpgfl/img/icon_twitter.png" alt="Checkout our Twitter!" /></a>
				</div>
		</div>
		<!-- GLOBAL NEWS -->
		<div class="row">
            <dnn:Alert runat="server" id="test" />
		</div>
        <!-- LOGIN PANEL -->
        <div class="row">
            <div class="login-strip">
                <%=UserController.Instance.GetCurrentUserInfo.DisplayName%> <dnn:Login runat="server" id="dnnLogin" />
            </div>
        </div>
		<!-- SITE NAV -->
		<div class="row">
				<nav class="navbar navbar-default">
				  <div class="container-fluid">
					<div class="navbar-header col-sm-2 col-md-2">
					  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					  </button>
					  <a class="navbar-brand" href="/">Home</a>
					</div>
					<div class="navbar-header col-sm-2 col-md-2">
					  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					  </button>
					  <a class="navbar-brand" href="/skirmishes">Skirmishes</a>
					</div>
					<div class="navbar-header col-sm-2 col-md-2">
					  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					  </button>
					  <a class="navbar-brand" href="/leagues">Leagues</a>
					</div>
					<div class="navbar-header col-sm-2 col-md-2">
					  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					  </button>
					  <a class="navbar-brand" href="http://rpgfl.freeforums.net/">Forum</a>
					</div>
					<div class="navbar-header col-sm-2 col-md-2">
					  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					  </button>
					  <a class="navbar-brand" href="/standings">Standings</a>
					</div>
                      <div class="navbar-header col-sm-2 col-md-2">
					  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					  </button>
					  <a class="navbar-brand" href="/donate">Donate</a>
					</div>
				  </div>
				</nav>
		</div>
	</div>
	<!-- BODY CONTENT -->
    <div id="content">
        <div id="ContentPane" runat="server" >
		</div>
    </div>
	<!-- FOOTER -->
    <div id="footer" class="opacity-high">
		<center>
            <div class="container">
                <div class="panel panel-default">
				    <div class="panel-body">
			            <p>Help support the site by <a href="/donate">Donating</a></p>
                    </div>
			    </div>
            </div>
		</center>
	</div>
</div>

