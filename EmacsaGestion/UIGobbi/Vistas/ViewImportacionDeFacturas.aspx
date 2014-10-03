<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Theme="SampleSiteTheme"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="ViewImportacionDeFacturas.aspx.cs"
    Inherits="Vistas_ViewImportacionDeFacturas" %>

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


    function  showProcesando() {
    try {
        var oDivProcesando = document.getElementById('divProcesando');
        if (oDivProcesando != undefined) {
            oDivProcesando.style.visibility = 'visible';
            
                 var boton=document.getElementById('ctl00_Contentplaceholder1_Button1'); 
                 boton.style.visibility='hidden';
                 var boton2=document.getElementById('ctl00_Contentplaceholder1_btnResultados'); 
                 boton2.style.visibility='hidden';
                 var boton3=document.getElementById('ctl00_Contentplaceholder1_btnDescargarResultados'); 
                 boton3.style.visibility='hidden';
                 var boton4=document.getElementById('ctl00_Contentplaceholder1_imgLoading'); 
                 boton4.style.visibility='visible';
                 var boton5=document.getElementById('ctl00_Contentplaceholder1_ButtonPreliminar'); 
                 boton5.style.visibility='hidden';
                 var boton6=document.getElementById('ctl00_Contentplaceholder1_btnImportacionesPreliminares'); 
                 boton6.style.visibility='hidden';
                 
        }
    } catch (e){
        alert (el);
    }

    }
    
    function HabilitarBotones()
    {

                 var boton=document.getElementById('ctl00_Contentplaceholder1_Button1'); 
                 boton.style.visibility='visible';
                 var boton2=document.getElementById('ctl00_Contentplaceholder1_btnResultados'); 
                 boton2.style.visibility='visible';
                 var boton3=document.getElementById('ctl00_Contentplaceholder1_btnDescargarResultados'); 
                 boton3.style.visibility='visible';
                 var boton4=document.getElementById('ctl00_Contentplaceholder1_imgLoading'); 
                 boton4.style.visibility='hidden';
                 var boton5=document.getElementById('ctl00_Contentplaceholder1_ButtonPreliminar'); 
                 boton5.style.visibility='visible';
                 var boton6=document.getElementById('ctl00_Contentplaceholder1_btnImportacionesPreliminares'); 
                 boton6.style.visibility='visible';
                 
                 
                 
    return true;
    }
    
    function IniciarProcesando()
    {




      if (Page_ClientValidate()==true)
                 {  
                 

                 
                 showProcesando();
                 }
                 return true;
    }

    </script>

    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>--%>
  <div id="divProcesando" style="position: relative; top: 30%; text-align: center;
        visibility: hidden">
 
    
        
       <span>
        <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
        Procesando...</span>
    </div>

 <asp:Panel runat="server" ID="panelBotones">
                                
                            
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
                                    <td class="style5">
                                        <span style="font-family: Verdana; font-size: 9px;">Seleccione el Cliente: </span>
                                    </td>
                                    <td valign="top" style="margin-left: 80px;" class="style6">
                                       <table>
                                             <tr>
                                                <td>
                                                <asp:DropDownList ID="cmbClientes" runat="server" AutoCompleteMode="SuggestAppend"
                                            AutoPostBack="False" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid"
                                            BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px"
                                             MaxLength="0" Width="177px">
                                                 </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <table>
                                                          <tr>
                                                             <td>
                                                             
                                                 <asp:Button runat="server" Text="Descargar Formato" CssClass="button_back" ID="btnDescargarResultados"
                                            Height="24px" Width="176px" Visible="true" onclick="btnDescargarResultados_Click"  
                                             ></asp:Button>
                                           
                                                             </td>
                                                             <td>
                                                                
                                                 <asp:Button ID="btnImportacionesPreliminares" runat="server" 
                                                     CssClass="button_back" Height="24px" 
                                                     OnClick="btnImportacionesPreliminares_Click" Text="Resultado última prueba" 
                                                     Width="176px" />
                                           
                                                             </td>
                                                          </tr>
                                                    </table>
                                                </td>
                                             </tr>
                                       
                                       </table>
                                                 
                                                
                                        
                                           
                                        
                                              
                                    </td>
                                    <td></td>
                                </tr>
                                <tr align="left">
                                    <td align="left" valign="top" class="style5" colspan="3">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td class="style5">
                                        <span style="font-family: Verdana; font-size: 9px;">Seleccione el Archivo: </span>
                                    </td>
                                    <td align="left" style="border-width: 0px" valign="top" class="style6" colspan="2">
                                        <asp:FileUpload ID="archivo" runat="server" Width="611px" />
                                        <asp:requiredfieldvalidator runat="server" errormessage="Especifique la interfaz a subir." ControlToValidate="archivo" ValidationGroup="uploadGroup"></asp:requiredfieldvalidator>
                                        
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td colspan="3" align="left" style="border-width: 0px" valign="top" class="style5">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr align="left">
                                <td align="left">
                                    <table>
                                          <tr>
                                             <td>
                                             <asp:Button runat="server" Text="Importar Facturas (Preliminar)" 
                                                     CssClass="button_back" ID="ButtonPreliminar"
                                            OnClick="Visualizar_Click_Preview" Height="24px" Width="190px"  
                                                     CausesValidation="true" ValidationGroup="uploadGroup" 
                                                     OnclientClick="IniciarProcesando()">
                                        </asp:Button>
                                             </td>
                                             <td>
                                                 &nbsp;</td>
                                          </tr>
                                          
                                    </table>
                                    
                                        
                                        <br />
                                    </td>
                                    <td align="left">
                                    
                                    
                                        <br />
                                    </td>
                                     
                                    
                                    <td align="left" style="width: 100%;">
                                        <asp:Button ID="Button1" runat="server" CausesValidation="true" 
                                            CssClass="button_back" Height="24px" OnClick="Visualizar_Click" 
                                            OnclientClick="IniciarProcesando()" Text="Importar facturas" 
                                            ValidationGroup="uploadGroup" Width="176px" />
                                        <asp:Button ID="btnResultados" runat="server" CssClass="button_back" 
                                            Height="24px" OnClick="btnResultados_Click" Text="Últimas importaciones" 
                                            Visible="true" Width="176px" />
                                        <br />
                                    </td>
                                    <!--td align="right" >
                                             &nbsp;</td-->
                                </tr>
                                <tr>
                                    <td  colspan="3" align="center">
                                        <asp:Image ID="imgLoading" runat="server" ImageUrl="~/Images/loading.gif" style="visibility: hidden" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="smallTitle" colspan="3" valign="top" 
                                        style="border-width: 0px">
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
    
    </asp:Panel>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="ContentHeader">
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="menuJQUERY">
    <style type="text/css">
        .style5
        {
            width: 238px;
        }
        .style6
        {
            width: 598px;
        }
    </style>
</asp:Content>

