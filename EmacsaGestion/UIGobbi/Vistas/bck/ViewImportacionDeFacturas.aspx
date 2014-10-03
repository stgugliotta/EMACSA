<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Theme="SampleSiteTheme"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="ViewImportacionDeFacturas.aspx.cs"
    Inherits="Vistas_ViewImportacionDeFacturas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>

    <script type="text/javascript">
<!--
$(document).ready(function()
{
	var options = {minWidth: 120, arrowSrc: '/UIControls/MenuJQuery/Menu/arrow_right.gif', copyClassAttr: true, onClick: function(e, menuItem){
	    //openMenu(
	    
	    
	    
	    document.location='http://localhost/vistas/ViewImportacionDeFacturas.aspx';
	            
	    
	    
	    //);
		//alert('you clicked item "' + $(this).text() + e  + '"');
	}};
	/*$('#menuone').menu(options);
 
	var items = [	{src: 'test', url:'http://www.jquery.com'},
					{src: ''}, // separator
					{src: 'test2', subMenu: [	{src: 'sub 1'},
												{src: 'sub 2', url: 'http://p.sohei.org', target: '_blank'},
												{src: 'sub 3'}]}];
	$('#menutwo').menu(options, items);
	$('#menuthree').menu(options);
	$('#menufive>img').menu(options, '#menufivelist');

	//creating a menu without items
	var menu = new $.Menu('#menufour', null, options);
	//adding items to the menu
	menu.addItems([
		new $.MenuItem({src: 'test', url:'http://www.jquery.com'}, options),
		new $.MenuItem({src: ''}) // separator
	]);
	var itemWithSubmenu = new $.MenuItem({src: 'test2'}, options);
	//creating a menu with items (as child of itemWithSubmenu)
	new $.Menu(itemWithSubmenu, [
		new $.MenuItem({src: 'sub 1'}, options),
		new $.MenuItem({src: 'sub 2', url: 'http://p.sohei.org', target: '_blank'}, options),
		new $.MenuItem({src: 'sub 3'}, options)
	], options);
	//adding the submenu to the main menu
	menu.addItem(itemWithSubmenu); */

	//highlight stuff..
	///dp.SyntaxHighlighter.ClipboardSwf = 'http://p.sohei.org/wp-content/plugins/syntaxhighlighter-plus/files/clipboard.swf';
	//dp.SyntaxHighlighter.HighlightAll('code');
});
-->
 
    </script>

    <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
	       
	        var ModalProgress = '<%= ModalProgress.ClientID %>';   
	       
//	       
              		
Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
                
function beginReq(sender, args) 
{  
    $find(ModalProgress).show();
       
 }

function endReq(sender, args)
{
	                        //  shows the Popup 
	                        $find(ModalProgress).hide();
} 




//    function  showProcesando() {
//    try {
//        var oDivProcesando = document.getElementById('divProcesando');
//        if (oDivProcesando != undefined) {
//            oDivProcesando.style.visibility = 'visible';
//        }
//    } catch (e){
//        alert (el);
//    }

//    }
//    
//    
//    function IniciarProcesando()
//    {
//      if (Page_ClientValidate()==true)
//                 {  showProcesando();
//                 }
//                 return true;
//    }

    </script>

    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>--%>
    
    
 <%-- <div id="divProcesando" style="position: relative; top: 30%; text-align: center;
        visibility: hidden">
 
    
        
       <span>
        <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
        Procesando...</span>
    </div>--%>
    
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

    <table align="center" style="height: 557px">
        <tr style="height: 200px;">
            <td valign="top">
                <table style="width: 950px; height: 88%;" class="borderCompleto" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td width="100%;" class="fondo_Titulo" align="left" style="height: 34px">
                            Seleccione el Cliente y luego el Archivo con las Facturas
                            <asp:Panel runat="server" ID="panelCliente0">
                                <br />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="95%" cellpadding="0" cellspacing="0" style="height: 172px">
                                <tr align="left" style="height: 20px;">
                                    <td style="width: 192px">
                                        <span style="font-family: Verdana; font-size: 9px;">Seleccione el Cliente: </span>
                                    </td>
                                    <td valign="top" style="width: 610px; margin-left: 80px;">
                                        <asp:DropDownList ID="cmbClientes" runat="server" AutoCompleteMode="SuggestAppend"
                                            AutoPostBack="False" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid"
                                            BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px"
                                             MaxLength="0" Width="177px">
                                        </asp:DropDownList>
                                        <asp:Button runat="server" Text="Descargar Formato" CssClass="button_back" ID="btnDescargarResultados"
                                            Height="24px" Width="176px" Visible="true" onclick="btnDescargarResultados_Click"  
                                            ></asp:Button>
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td align="left" style="width: 192px" valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td style="width: 192px">
                                        <span style="font-family: Verdana; font-size: 9px;">Seleccione el Archivo: </span>
                                    </td>
                                    <td align="left" style="width: 610px; border-width: 0px" valign="top">
                                      <%--  <asp:FileUpload ID="archivo" runat="server" Width="611px" />--%>
                                      <%--  <asp:requiredfieldvalidator runat="server" errormessage="Especifique la interfaz a subir." ControlToValidate="archivo" ValidationGroup="uploadGroup"></asp:requiredfieldvalidator>--%>
                                        
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td align="left" style="width: 192px; border-width: 0px" valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td align="left" style="width: 100%;">
                                        <asp:Button runat="server" Text="Importar las facturas" CssClass="button_back" ID="Button1"
                                            OnClick="Visualizar_Click" Height="24px" Width="176px"    >
                                        </asp:Button>
                                        <br />
                                    </td>
                                    <td align="left" style="width: 100%;">
                                        <asp:Button runat="server" Text="Últimas importaciones" CssClass="button_back" ID="btnResultados"
                                            Height="24px" Width="176px" Visible="true" OnClick="btnResultados_Click" ></asp:Button>
                                        <br />
                                    </td>
                                    <!--td align="right" >
                                             &nbsp;</td-->
                                </tr>
                                <tr>
                                    <td align="left" class="smallTitle" colspan="2" valign="top" style="width: 800px;
                                        border-width: 0px">
                                        <asp:Panel ID="resultados" CssClass="smallTitle" runat="server">
                                            <asp:Literal ID="lblResultado" runat="server" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
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
</asp:Content>
