<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"   Theme="SampleSiteTheme"  EnableEventValidation="false" AutoEventWireup="true" CodeFile="ViewDetalleUltimaImportacionCliente.aspx.cs" Inherits="Vistas_ViewDetalleUltimaImportacionCliente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"	Namespace="System.Web.UI" TagPrefix="asp" %>




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
	
});
-->
 
</script>	


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
		    
 <%--   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>--%>

	
		<ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
			BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
			
	
<asp:HiddenField ID="idcli" runat="server"  />
<table align="center" style="height: 1000px">
<tr style="height:300px;">
    <td valign="top">
        <table style="width:1000px; height:60%;"  class="borderCompleto" cellpadding="0" cellspacing="0" >
         <tr >
            <td valign="top">

                <table width="100%" cellpadding="0" cellspacing="0" style="height: 380px" >
                 <tr align="left" class="topTxt" >
                     <td align="left" class="topTxt" style="width:100%;" >
                        <div class="topTxt" style="height: 100%; vertical-align: bottom ;">
                            <asp:Table runat="server">
                                <asp:TableRow>
                                    <asp:TableCell  VerticalAlign="Middle" HorizontalAlign="Left">
                                        Detalle Última importación:
                                    </asp:TableCell>
                                    <asp:TableCell  HorizontalAlign="Left">
                                        <asp:Label runat="server" ID="nombreCliente" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
				         </div>
                     </td>
                 </tr>
                 <tr align="center"  style="height:400px;" >
                     <td valign="top" style="width: 900px; margin-left: 80px; text-align:center;" align="center">

                         <asp:Panel ID="panelCliente" runat="server" Width="900px" Height="400px" align="center">
                                  <ajaxToolkit:Accordion ID="Accordion1" runat="server" TransitionDuration="250" FramesPerSecond="40"    FadeTransitions="true" HeaderCssClass="acc-header" ContentCssClass="acc-content" HeaderSelectedCssClass="acc-selected">
                                    <Panes>
                                           <ajaxToolkit:AccordionPane ID="AccordionRegistrosRechazados" runat="server" >
                                            <Header>
                                            <table cellpadding="0" border="0" cellspacing="0" style="width:100%;">
                                                <tr>
                                                    <td valign="middle"   align="left" class="fondo_Titulo" style="height:50px;">
                                                        <asp:Label ID="Label7" runat="server" >Registros Rechazados: No existe el deudor</asp:Label>
                                                        <asp:Label ID="lblCantidadNoExisteDeudor" runat="server" />
                                                    </td>
                                                </tr>
                                             </table>
                                             </Header>
                                            
                                             <Content>
                                             
                                             <table style="width:850px; height:98%;" class="borderCompleto" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    
                                                    <td align="center">
                                                         <asp:Panel ID="Panel2" runat="server" CssClass="scrollbar" Height="280px" ScrollBars="Horizontal" Width="850px">
                                                            <ma:XGridView ID="XGridViewRegistrosRechazados" runat="server" AllowPaging="True" 
                                                                    AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" 
                                                                    DataKeyNames="idCliente" EmptyDataText="No se encontraron resultados" 
                                                                    ExecutePageIndexChanging="True"
                                                                    PageSize="400" 
                                                                    Width="100%"
                                                                    OnFilling="XGridViewRegistrosRechazados_Filling"
                                                                    OnPageIndexChanging="XGridViewRegistrosRechazados_PageIndexChanging" 
                                                                    >
                                                                    <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                         <Columns>
                                                                             <asp:BoundField DataField="estado" HeaderText="estado" Visible="false"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="idCliente" HeaderText="idCliente" Visible="false"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:HyperLinkField  DataNavigateUrlFormatString="~/Vistas/ViewAltaDeudor.aspx?idCliente={0}&amp;idDeudor={1}&amp;" DataNavigateUrlFields="idCliente,idDeudor"  DataTextField="idDeudor" HeaderText="Id. Deudor" ><HeaderStyle Font-Bold="True" /></asp:HyperLinkField>
                                                                             <asp:BoundField DataField="letra" HeaderText="Letra" ItemStyle-HorizontalAlign="Center" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="emision" HeaderText="Emisión" ItemStyle-HorizontalAlign="Center" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="nroComprobante" HeaderText="Nro Comprobante" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="importe" HeaderText="Importe" ItemStyle-HorizontalAlign= "Right" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="saldo" HeaderText="Saldo" ItemStyle-HorizontalAlign= "Right" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="idMoneda" HeaderText="Id Moneda" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField  DataFormatString="{0:dd/MM/yyyy}"  DataField="fechaEmision" HeaderText="Fecha Emisión" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="fechaVencimiento" HeaderText="Fecha Venc." SortExpression="documentosBaja" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="observaciones" HeaderText="Motivo Rechazo" Visible="true"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:HyperLinkField  Visible="false" DataNavigateUrlFormatString="~/Vistas/ViewAyudaMotivoRechazo.aspx?idCliente={0}&amp;observacion={1}&amp;estado={2}&amp;" DataNavigateUrlFields="idCliente,observaciones,estado"  DataTextField="observaciones" HeaderText="Motivo Rechazo" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:HyperLinkField>
                                                                         </Columns>
                                                                         <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                         <EmptyDataTemplate>No se hallaron resultados.</EmptyDataTemplate>
                                                                         <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                                         <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                         <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                         <RowStyle CssClass="gvItem" />
                                                                         
                                                             </ma:XGridView>
                                                         </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="height: 30px;" class="fondo_Titulo" width="100%;">
                                                        
                                                    </td>
                                                </tr>
                                             </table>
                                             </Content>
                                             </ajaxToolkit:AccordionPane>
                                           <ajaxToolkit:AccordionPane ID="AccordionErrorSigno" runat="server" >
                                            <Header>
                                            <table cellpadding="0" border="0" cellspacing="0" style="width:100%;">
                                                <tr>
                                                    <td valign="middle"   align="left" class="fondo_Titulo" style="height:50px;">
                                                        <asp:Label ID="Label3" runat="server" >Registros Rechazados: Error en el signo del importe</asp:Label>
                                                        <asp:Label ID="lblCantidadErrorSigno" runat="server" />
                                                    </td>
                                                </tr>
                                             </table>
                                             </Header>
                                            
                                             <Content>
                                             <table style="width:850px; height:95%;" class="borderCompleto" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                         <asp:Panel ID="Panel4" runat="server" CssClass="scrollbar" Height="280px" ScrollBars="Horizontal" Width="850px">
                                                            <ma:XGridView ID="XGridViewErrorSigno" runat="server" AllowPaging="True" 
                                                                    AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" 
                                                                    DataKeyNames="idCliente" EmptyDataText="No se encontraron resultados" 
                                                                    ExecutePageIndexChanging="True"
                                                                    PageSize="10" 
                                                                    Width="100%"
                                                                    OnFilling="XGridViewErrorSigno_Filling"
                                                                    OnPageIndexChanging="XGridViewErrorSigno_PageIndexChanging" 
                                                                    >
                                                                    <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                         <Columns>
                                                                             <asp:BoundField DataField="estado" HeaderText="estado" Visible="false"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="idCliente" HeaderText="idCliente" SortExpression="idCliente" Visible="false"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="idDeudor" HeaderText="Id. Deudor" SortExpression="idDeudor" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="letra" HeaderText="Letra" SortExpression="letra"  ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="emision" HeaderText="Emisión" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <%--<asp:HyperLinkField  DataNavigateUrlFormatString="~/Vistas/ViewDetalleFactura.aspx?idCliente={0}&amp;idFactura={1}&amp;" DataNavigateUrlFields="idCliente,nroComprobante"  DataTextField="nroComprobante" ItemStyle-HorizontalAlign="Center" HeaderText="Id. Factura" ><HeaderStyle Font-Bold="True" /></asp:HyperLinkField>                                                                             --%>
                                                                             <asp:BoundField DataField="nroComprobante" HeaderText="Nro Comprobante" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="importe" HeaderText="Importe" ItemStyle-HorizontalAlign= "Right" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="saldo" HeaderText="Saldo" ItemStyle-HorizontalAlign= "Right" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="idMoneda" HeaderText="Id Moneda" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField  DataFormatString="{0:dd/MM/yyyy}"  DataField="fechaEmision" HeaderText="Fecha Emisión" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="fechaVencimiento" HeaderText="Fecha Venc." ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="observaciones" HeaderText="Motivo Rechazo" Visible="true"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:HyperLinkField  Visible="false"  DataNavigateUrlFormatString="~/Vistas/ViewAyudaMotivoRechazo.aspx?idCliente={0}&amp;observacion={1}&amp;estado={2}&amp;" DataNavigateUrlFields="idCliente,observaciones,estado"  DataTextField="observaciones" HeaderText="Motivo Rechazo" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:HyperLinkField>
                                                                         </Columns>
                                                                         <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                         <EmptyDataTemplate>No se hallaron resultados.</EmptyDataTemplate>
                                                                         <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                                         <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                         <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                         <RowStyle CssClass="gvItem" />
                                                             </ma:XGridView>
                                                         </asp:Panel>
                                                    </td>
                                                </tr>
                                             </table>
                                             </Content>
                                             </ajaxToolkit:AccordionPane>
                                           <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" >
                                            <Header>
                                            <table cellpadding="0" border="0" cellspacing="0" style="width:100%;">
                                                <tr>
                                                    <td valign="middle"   align="left" class="fondo_Titulo" style="height:50px;">
                                                        <asp:Label ID="Label2" runat="server" >Documentos ya existentes</asp:Label>
                                                        <asp:Label ID="lblCantidadFacturasExistentes" runat="server" />
                                                    </td>
                                                </tr>
                                             </table>
                                             </Header>
                                            
                                             <Content>
                                             <table style="width:850px; height:95%;" class="borderCompleto" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                         <asp:Panel ID="Panel3" runat="server" CssClass="scrollbar" Height="280px" ScrollBars="Horizontal" Width="850px">
                                                            <ma:XGridView ID="XGridViewFacturasExistentes" runat="server" AllowPaging="True" 
                                                                    AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" 
                                                                    DataKeyNames="idCliente" EmptyDataText="No se encontraron resultados" 
                                                                    ExecutePageIndexChanging="True"
                                                                    PageSize="10" 
                                                                    Width="100%"
                                                                    OnFilling="XGridViewFacturasExistentes_Filling"
                                                                    OnPageIndexChanging="XGridViewFacturasExistentes_PageIndexChanging" 
                                                                    >
                                                                    <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                         <Columns>
                                                                             <asp:BoundField DataField="estado" HeaderText="estado" Visible="false"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="idCliente" HeaderText="idCliente" SortExpression="idCliente" Visible="false"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="idDeudor" HeaderText="Id. Deudor" SortExpression="idDeudor" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="letra" HeaderText="Letra" SortExpression="letra"  ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="emision" HeaderText="Emisión" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                              <asp:BoundField DataField="nroComprobante" HeaderText="Nro Comprobante" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <%--<asp:HyperLinkField  DataNavigateUrlFormatString="~/Vistas/ViewDetalleFactura.aspx?idCliente={0}&amp;idFactura={1}&amp;" DataNavigateUrlFields="idCliente,nroComprobante"  DataTextField="nroComprobante" ItemStyle-HorizontalAlign="Center" HeaderText="Id. Factura" Enabled="false"><HeaderStyle Font-Bold="True"  /></asp:HyperLinkField>                                                                             --%>
                                                                             <asp:BoundField DataField="importe" HeaderText="Importe" ItemStyle-HorizontalAlign= "Right" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="saldo" HeaderText="Saldo" ItemStyle-HorizontalAlign= "Right" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="idMoneda" HeaderText="Id Moneda" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField  DataFormatString="{0:dd/MM/yyyy}"  DataField="fechaEmision" HeaderText="Fecha Emisión" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="fechaVencimiento" HeaderText="Fecha Venc." ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="observaciones" HeaderText="Motivo Rechazo" Visible="true"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:HyperLinkField   Visible="false" DataNavigateUrlFormatString="~/Vistas/ViewAyudaMotivoRechazo.aspx?idCliente={0}&amp;observacion={1}&amp;estado={2}&amp;" DataNavigateUrlFields="idCliente,observaciones,estado"  DataTextField="observaciones" HeaderText="Motivo Rechazo" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:HyperLinkField>
                                                                         </Columns>
                                                                         <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                         <EmptyDataTemplate>No se hallaron resultados.</EmptyDataTemplate>
                                                                         <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                                         <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                         <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                         <RowStyle CssClass="gvItem" />
                                                             </ma:XGridView>
                                                         </asp:Panel>
                                                    </td>
                                                </tr>
                                             </table>
                                             </Content>
                                             </ajaxToolkit:AccordionPane>
                                                                                 
                                           <ajaxToolkit:AccordionPane ID="AccordionRegistrosBajaInterfaz" runat="server" >
                                            <Header>
                                            <table cellpadding="0" border="0" cellspacing="0" style="width:100%;"><tr><td valign="middle"   align="left"
                                                 class="fondo_Titulo" style="height:50px;">
                                                 <asp:Label ID="Label1" runat="server" >Documentos Baja: Documentos dados de baja por interfaz</asp:Label>
                                                 <asp:Label ID="lblCantidadFacturasBaja" runat="server" CssClass="red"/>
                                             </td></tr></table>
                                             </Header>
                                            
                                             <Content>
                                             <table style="width:850px; height:88%;" class="borderCompleto" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                         <asp:Panel ID="Panel1" runat="server" CssClass="scrollbar" Height="280px" ScrollBars="Horizontal" Width="850px">
                                                            <ma:XGridView ID="XGridFacturasBajaPorInterfaz" runat="server" AllowPaging="True" 
                                                                    AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" 
                                                                    DataKeyNames="idCliente" EmptyDataText="No se encontraron resultados" 
                                                                    ExecutePageIndexChanging="True"
                                                                    PageSize="10" 
                                                                    Width="100%"
                                                                    OnFilling="XGridFacturasBajaPorInterfaz_Filling"
                                                                    OnPageIndexChanging="XGridFacturasBajaPorInterfaz_PageIndexChanging" 
                                                                    >
                                                                    <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                         <Columns>
                                                                             <asp:BoundField DataField="estado" HeaderText="estado" Visible="false"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="idCliente" HeaderText="idCliente" SortExpression="idCliente" Visible="false"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="idDeudor" HeaderText="Id. Deudor" SortExpression="idDeudor" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="letra" HeaderText="Letra" SortExpression="letra" ItemStyle-HorizontalAlign="Center"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="emision" HeaderText="Emisión" ItemStyle-HorizontalAlign="Center" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <%--<asp:HyperLinkField  DataNavigateUrlFormatString="~/Vistas/ViewDetalleFactura.aspx?idCliente={0}&amp;idFactura={1}&amp;" DataNavigateUrlFields="idCliente,nroComprobante"  DataTextField="nroComprobante" HeaderText="Id. Factura" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:HyperLinkField>                                                                             --%>
                                                                             <asp:BoundField DataField="nroComprobante" HeaderText="Nro Comprobante" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="importe" HeaderText="Importe" ItemStyle-HorizontalAlign= "Right" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="saldo" HeaderText="Saldo" ItemStyle-HorizontalAlign= "Right" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="idMoneda" HeaderText="Id Moneda" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField  DataFormatString="{0:dd/MM/yyyy}"  DataField="fechaEmision" HeaderText="Fecha Emisión" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="fechaVencimiento" HeaderText="Fecha Venc." ItemStyle-HorizontalAlign="Center" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="observaciones" HeaderText="Motivo Rechazo" Visible="true"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:HyperLinkField  Visible="false" DataNavigateUrlFormatString="~/Vistas/ViewAyudaMotivoRechazo.aspx?idCliente={0}&amp;observacion={1}&amp;estado={2}&amp;" DataNavigateUrlFields="idCliente,observaciones,estado"  DataTextField="observaciones" HeaderText="Motivo Rechazo" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:HyperLinkField>
                                                                         </Columns>
                                                                         <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                         <EmptyDataTemplate>No se hallaron resultados.</EmptyDataTemplate>
                                                                         <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                                         <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                         <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                         <RowStyle CssClass="gvItem" />
                                                             </ma:XGridView>
                                                         </asp:Panel>
                                                    </td>
                                                </tr>
                                             </table>
                                             </Content>
                                             </ajaxToolkit:AccordionPane>
                                    </Panes>                                    
                                  </ajaxToolkit:Accordion>                                         
                                  
                          </asp:Panel>
                      </td>
                  </tr>
                 <tr align="left" valign="top" >
                     <td align="left" style="width:100%;" >

                     </td>
                 </tr>

         </table>
    </td>
</tr>
</table>
<table>
         <tr>
         <td>
          <asp:Button runat="server" Text="Volver" CssClass="button_back" 
                             ID="btnVolver" Height="24px" Width="176px" Visible="true" onclick="btnVolver_Click" 
                             ></asp:Button>
         </td>
         </tr>
         </table>
    </td>
</tr>
</table>

<%--    </form>
</body>--%>


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

