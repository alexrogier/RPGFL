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

    <!-- CHARACTER PREVIEW MODAL -->
    <div id="characterPreviewModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 id="charactermodal_title" class="modal-title">CHARACTER NAME</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <center><img style="width: 40%;" id="charactermodal_portrait" alt="" src="" /></center>
                    </div>
                    <div class="row">
                        <h4 class="smallpadding">STATS</h4>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-md-6">
                            <div class="row"><label class="col-sm-5 col-md-5"><strong>Health:</strong></label><p class="borderless col-sm-7 col-md-7" id="charactermodal_stats_health" /></div>
                            <div class="row"><label class="col-sm-5 col-md-5"><strong>Dodge:</strong></label><p class="borderless col-sm-7 col-md-7" id="charactermodal_stats_dodge" /></div>
                            <div class="row"><label class="col-sm-5 col-md-5"><strong>Archetype:</strong></label><p class="borderless col-sm-7 col-md-7" id="charactermodal_stats_archetype" /></div>
                        </div>
                        <div class="col-sm-6 col-md-6">
                            <div class="row"><label class="col-sm-5 col-md-5"><strong>Max Energy:</strong></label><p class="borderless col-sm-7 col-md-7" id="charactermodal_stats_maxenergy" /></div>
                            <div class="row"><label class="col-sm-5 col-md-5"><strong>Intiative:</strong></label><p class="borderless col-sm-7 col-md-7" id="charactermodal_stats_initiative" /></div>
                            <div class="row"><label class="col-sm-5 col-md-5"><strong>Guild:</strong></label><p class="borderless col-sm-7 col-md-7" id="charactermodal_stats_guild" /></div>
                        </div>
                    </div>
                    <br />
                    <div class="row text-center">
                        <div class="row">
                            <div class="col-sm-2 col-md-2"></div>
                            <div class="col-sm-2 col-md-2"><label><strong>Finesse</strong></label></div>
                            <div class="col-sm-2 col-md-2"><label><strong>Agility</strong></label></div>
                            <div class="col-sm-2 col-md-2"><label><strong>Senses</strong></label></div>
                            <div class="col-sm-2 col-md-2"><label><strong>Mana</strong></label></div>
                            <div class="col-sm-2 col-md-2"></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 col-md-2"></div>
                            <div class="col-sm-2 col-md-2"><p id="charactermodal_stats_finesse"></p></div>
                            <div class="col-sm-2 col-md-2"><p id="charactermodal_stats_agility"></p></div>
                            <div class="col-sm-2 col-md-2"><p id="charactermodal_stats_senses"></p></div>
                            <div class="col-sm-2 col-md-2"><p id="charactermodal_stats_mana"></p></div>
                            <div class="col-sm-2 col-md-2"></div>
                        </div>
                    </div>
                    <div class="row text-center">
                        <div class="row">
                            <div class="col-sm-1 col-md-1"></div>
                            <div class="col-sm-3 col-md-3"><label><strong>Immunities</strong></label></div>
                            <div class="col-sm-3 col-md-3"><label><strong>Vulnerabilities</strong></label></div>
                            <div class="col-sm-3 col-md-3"><label><strong>Resistances</strong></label></div>
                            <div class="col-sm-1 col-md-1"></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-1 col-md-1"></div>
                            <div class="col-sm-3 col-md-3"><p id="charactermodal_stats_immunities"></p></div>
                            <div class="col-sm-3 col-md-3"><p id="charactermodal_stats_vulnerabilities"></p></div>
                            <div class="col-sm-3 col-md-3"><p id="charactermodal_stats_resistances"></p></div>
                            <div class="col-sm-1 col-md-1"></div>
                        </div>
                    </div>
                    <div class="row">
                        <h4 class="smallpadding">SKILLS</h4>
                    </div>
                    <div id="charactermodal_skills" class="row">

                    </div>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
    <!-- END CHARACTER PREVIEW MODAL -->
</div>

