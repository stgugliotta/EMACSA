<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewReportes.aspx.cs" Inherits="ViewReportes" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" Runat="Server">
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
 <table cellpadding="0" border="0" cellspacing="0"  
        style="width:100%;height:195px; left:0;">
        <tr>
            <td valign="middle"  align="center" style="height: 10px; font-family: Tahoma, Arial, MS Sans Serif; color: #666666;font-weight: bold;font-size: 12px;background-color: #EDEBEB;border-right: #cccccc 2px solid;border-bottom: #cccccc 1px inset;text-align: left;" valign="top" >
              <asp:Label ID="lblAdmCasos" runat="server" >Administración de Reportes</asp:Label></td>
        </tr>
                       
        <tr>
            <td align="center">
            
                <br />
                  
                    
                    <table style="width:900px; height:100%;" class="border" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="100%;" class="fondo_Titulo" align="left" style="height: 23px">
                                                Reportes Disponibles</td>
                                    </tr>
                                    <tr>
                                        <td>
                       <%--             
                   <asp:DropDownList runat="server" ID="ddlListadoDeReportes" CssClass="listBox">
                    </asp:DropDownList>--%>
                    <br />
                    <br />
                    
                    <table>
                         <tr>
                             <td align="left" style="width:10px;">
                                 <asp:radiobutton runat="server" Checked="true"  ID="reportesInternos" AutoPostBack="true" OnCheckedChanged="reportesInternos_CheckedChanged" ></asp:radiobutton>
                             </td>
                            <td align="left" style="width:300px; text-align:left;">
                                  <asp:Label ID="Label3" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                font-weight: bold;" Text="Reportes de gestión interna" EnableViewState="False"></asp:Label>
                                    
                             </td>
                         
                         </tr>
                         
                         <tr>
                             <td colspan="2" align="left">
                                      <asp:DropDownList ID="ddlListadoDeReportes" runat="server" CssClass="comboEditor"  AutoPostBack="false" 
                                                Width="100%"  
                                                />
                             </td>
                         </tr>
                    
                          <tr>
                             <td align="left" style="width:10px; text-align:left;">
                                  <asp:radiobutton runat="server"  ID="reportesExternos" OnCheckedChanged="reportesExternos_CheckedChanged" AutoPostBack="true" ></asp:radiobutton>
                             </td>
                            <td align="left" style="width:300px;">
                                     <asp:Label ID="Label4" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                font-weight: bold;" Text="Reportes de gestión externa" EnableViewState="False"></asp:Label>
                                      
                             </td>
                         
                         </tr>
                         <tr>
                         <td colspan="2" align="left">
                                    <asp:DropDownList ID="ddlListadoDeReportesExsternos" runat="server" CssClass="comboEditor"  AutoPostBack="false" Enabled=false
                                                Width="100%"  
                                                 />
                             </td>
                             </tr>
                    </table>
                                            
                                                   <%-- <ma:SecureDropDownList ID="ddlListadoDeReportes" runat="server"  ResourceID="ddlListadoDeReportes" AuthorizeResource="false" VisibleOnNotAuthorized="true" EnabledOnNotAuthorized="true" CssClass="comboEditor" Width="100%">
                                                                </ma:SecureDropDownList>--%>
                    
                                           
                                                 
                  
                                                
                    <br />
                    <br />
                  
                <asp:Button ID="Button1" Text="Visualizar Reporte" runat="server" onclick="VisualizarReporte_Click" CssClass="button_back"/>    
                            
                                    <br />
                                      <br />
                                        </td>
                                    
                                    </tr>
                                    </table>
                    
                    
            
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" Runat="Server">
	     
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeader" Runat="Server">
</asp:Content>

