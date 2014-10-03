<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ViewResultadosImportacion.aspx.cs" Inherits="Vistas_ViewResultadosImportacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"	Namespace="System.Web.UI" TagPrefix="asp" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Resultado Importación</title>
        <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />    
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
      <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" Runat="Server">
<link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />	--%>      	 
<%--<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script>
<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>
<script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>
<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>
<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>
<script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>	--%>

<%-- <script type="text/javascript">
<!--
$(document).ready(function()
{
	var options = {minWidth: 120, arrowSrc: '/UIControls/MenuJQuery/Menu/arrow_right.gif', copyClassAttr: true, onClick: function(e, menuItem){
	    //openMenu(
	    
	    
	    
	    document.location='http://localhost/vistas/ViewImportacionDeFacturas.aspx';
	            
	    
	    
	    //);
		//alert('you clicked item "' + $(this).text() + e  + '"');
	}};
	
});
-->
 
</script>	--%>


  
    	 	 
  


<script type="text/javascript" language="javascript">
	            var ModalProgress = '<%= ModalProgress.ClientID %>';   
                	
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
                
                

function beginReq(sender, args) 
{
	// shows the Popup 
	var controlCaller=args.get_postBackElement().id;
   
    $find(ModalProgress).show();
        	 
}





function endReq(sender, args)
{
	                        //  shows the Popup 
	                        $find(ModalProgress).hide();
} 


	</script>
	

<link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
 <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />



    	<asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
    	
			<asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
				<ProgressTemplate>
					<div style="position: relative; top: 30%; text-align: center;">
						<img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
						Procesando...
					</div>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</asp:Panel>
<%--		    
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>--%>

	
		<ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
			BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
			
	
<table align="center" style="height: 1000px">
<tr style="height:200px;">
    <td valign="top">
        <table style="width:1000px; height:88%;"  class="borderCompleto" cellpadding="0" cellspacing="0" >
         <tr >
         <td valign="top">
             <table width="100%" cellpadding="0" cellspacing="0" style="height: 172px" >
                 <tr align="left"  style="height:20px;" >
                     <td valign="top" style=" margin-left: 80px;">

                         <asp:Panel ID="panelCliente" runat="server" Width="750px" ScrollBars="Vertical">
            
                                  <table cellpadding="0" cellspacing="0" class="borderCompleto" 
                                                 style="width:710px; height:88%;">
                                                 <tr>
                                                     <td align="left" class="fondo_Titulo" style="height: 23px" width="100%;">
                                                          <table width="100%" >
                                                          <tr>
                                                          <td class="style5">Últimas importaciones</td>
                                                                 <td valign="top">
                                                                     <asp:ImageButton ID="ImageButton3" runat="server" 
                                                                         ImageUrl="~/Images/excel_small.gif"  OnClick="Exportar_Click"/>
                                                          </td>
                                                          </tr>
                                                          </table>
                                                     </td>
                                                 </tr>
                                                 <ma:XGridView ID="GvResultados" runat="server" AllowPaging="True" 
                                                                 AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" 
                                                                 DataKeyNames="idCliente" EmptyDataText="No se encontraron resultados" 
                                                                 ExecutePageIndexChanging="True" 
                                                                 PageSize="40" Width="700px" 
                                                                 OnRowCommand="GvResultados_RowCommand">
                                                                 <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                         <Columns>
                                                                              <asp:CommandField  ButtonType="Image" SelectImageUrl="~/Images/detalle.gif" ShowSelectButton ="true" HeaderText="Detalle"  >
                                                                                <HeaderStyle Font-Bold="True" /><itemstyle width="5%"  HorizontalAlign="Center"  />
                                                                              </asp:CommandField>
                                                                             <asp:BoundField DataField="idCliente" HeaderText="idCliente" SortExpression="idCliente" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="Cuit" HeaderText="Cuit" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="registrosEnviados" HeaderText="Registros Enviados" SortExpression="registrosEnviados" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="registrosIngresados" HeaderText="Registros Ingresados" SortExpression="registrosIngresados" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="registrosRechazados" HeaderText="Registros Rechazados" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="documentosBaja" HeaderText="Documentos Baja" SortExpression="documentosBaja" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="fechaProceso" HeaderText="Fecha Proceso" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                         </Columns>
                                                                         <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                         <EmptyDataTemplate>No se hallaron resultados.</EmptyDataTemplate>
                                                                         <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                                         <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                         <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" /><RowStyle CssClass="gvItem" />
                                                               </ma:XGridView>
                                  </table>
                                         
                          </asp:Panel>
                      </td>
                  </tr>
         <tr align="left" >
             <td align="left" style="width:100%;" >
                 <asp:Button runat="server" Text="Volver" CssClass="button_back" 
                     ID="btnVolver" Height="24px" Width="176px" Visible="true" onclick="btnVolver_Click" 
                     ></asp:Button>
                 <br />
             </td>
                 <!--td align="right" >
                     &nbsp;</td-->
             </tr>
             </table>
         </td>
         </tr>
         <tr align="left" >
             <td align="left" style="width:192px; border-width:0px" 
             valign="top" >
             &nbsp;</td>
         </tr>
         <tr align="left" >
             <td align="left" style="width:100%;" >
                 <br />
             </td>
             <td align="left" style="width:100%;" >
                 <br />
             </td>
         </tr>
         <tr>
            <td align="left" class="smallTitle" colspan="2" valign="top" style="width:800px; border-width:0px" >
            <asp:Panel ID="resultados" CssClass="smallTitle" runat ="server"> 
            </asp:Panel>
            </td>
         </tr>
         
         </table>
    </td>
</tr>
<tr >
         <td >

         </td>
                         
</tr>                      
</table>

    </form>
</body>
</html>

<%--
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" Runat="Server">
	     
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentHeader">
     
 
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="menuJQUERY">
    <style type="text/css">
        .style5
        {
            height: 30px;
            width: 942px;
        }
        .style6
        {
            width: 192px;
            height: 27px;
        }
    </style>
</asp:Content>
--%>
