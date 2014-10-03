<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Theme="SampleSiteTheme"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="ViewMapaHojaDeRuta.aspx.cs"
    Inherits="Vistas_ViewMapaHojaDeRuta" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="../GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>

 
    <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
	            var ModalProgress = '<%= ModalProgress.ClientID %>';   
                	
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
                
                

function beginReq(sender, args) 
{
	// shows the Popup 
	var controlCaller=args.get_postBackElement().id;
    if(controlCaller.indexOf('UpdateTimer')==-1){$find(ModalPopupCargando).show()};
        	 
}

function endReq(sender, args)
{
    //  shows the Popup 
    $find(ModalProgress).hide();
} 




    </script>

    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
    <asp:panel id="panelUpdateProgress" runat="server" cssclass="updateProgress">

     
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <ProgressTemplate>
                <div style="position: relative; top: 30%; text-align: center;">
                    <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                    Procesando...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
    <table align="center" style="height: 1000px">
        <tr style="height: 400px;">
            <td valign="top">
                <table style="width: 800px; height: 98%;" class="borderCompleto" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" style="height: 400px">
                                <tr>
                                    <td align="center">
                                        <asp:updatepanel>
                                            <ContentTemplate>
                                                <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" Visible="true" EnableTheming="true" />
                                            </ContentTemplate>
                                        </asp:updatepanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="ContentHeader">
    <asp:hiddenfield id="idcli" runat="server" />
    <asp:hiddenfield id="hdnLat" runat="server" value="-58.3657287" />
    <asp:hiddenfield id="hdnLng" runat="server" value="-34.7504784" />
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="menuJQUERY">
    <style type="text/css">
        .style5
        {
            height: 30px;
            width: 942px;
        }
    </style>
</asp:Content>
