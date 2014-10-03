<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewParte.aspx.cs" Inherits="Vistas_ViewParte"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewMailEstadoCuenta</title>
    <style type="text/css">
        .style1
        {
            width: 826px;
        }
        .button_back
        {
            font-family: Tahoma, Arial, MS Sans Serif;
            font-size: 11px;
            color: #0099FF;
            border-bottom: 1px solid #BCD2E6;
            background: url( "../Images/tableft1.gif" );
            display: block;
            background: url( "../Images/tabright1.gif" ) no-repeat right top;
            color: #627EB7;
            font-weight: bold;
        }
    </style>
</head>

<script type="text/javascript">
    var ModalPopupCargando = '<%= ModalPopupCargando.ClientID %>';
    var ModalPopupPosiblesDestinatarios = '<%= ModalPopupPosiblesDestinatarios.ClientID %>';


    function beginReq(sender, args) {

        var controlCaller = args.get_postBackElement().id;


        if (controlCaller.indexOf('btnGuardarRecibo') != -1) { $find(ModalPopupCargando).show() };

    }


    function endReq(sender, args) {

        //var controlCaller=args.get_postBackElement().id;
        //  shows the Popup 
        $find(ModalPopupCargando).hide();
        // if(controlCaller.indexOf('btnNuevaRemisionTemporal')!=-1){$find(btnNuevaRemisionTemporal).disabled=false;};
    }


    function HideConfirma2() {

        var ModalPopupPosiblesDestinatarios = '<%= ModalPopupPosiblesDestinatarios.ClientID%>';
        $find(ModalPopupPosiblesDestinatarios).hide();
    }	                 
</script>

<asp:scriptmanager id="ScriptManager1" runat="server" enablepagemethods="true" enablepartialrendering="true">
    </asp:scriptmanager>
<asp:panel id="pnlPosiblesDestinatarios" runat="server">
<%--        <asp:UpdatePanel ID="pnlNuevoDeudorAjax" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>
                <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                    font-size: 16px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 20px; width: 420px;
                    text-align: center;">
                    <table>
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label4" runat="server" Text="   Posibles Destinatarios" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 350px; width: 399px; background-color: #ffffff; border-right: #cccccc 2px solid;
                    border-bottom: #cccccc 1px inset; text-align: center;">
                    <br />
                    <asp:Panel ID="Panel2" runat="server" CssClass="scrollbar" Height="346px" Width="416px"
                        ScrollBars="Vertical">
                        <ma:XGridView ID="gvResultadosMails" runat="server" AutoGenerateColumns="False"
                            BorderWidth="0px" DataKeyNames="IdMail" EmptyDataText="No se encontraron resultados"
                            ExecutePageIndexChanging="False" Width="358px">
                            <AlternatingRowStyle CssClass="gvAlternatingItem" />
                            <Columns>
                                <asp:BoundField DataField="IdMail" HeaderText="IdMail" SortExpression="IdMail">
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                               
                                <asp:BoundField DataField="Contacto" HeaderText="Contacto" SortExpression="Contacto" />
                                <asp:TemplateField HeaderText="Selección">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSeleccion" runat="Server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                            <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                No se hallaron resultados.
                            </EmptyDataTemplate>
                            <FooterStyle CssClass="gvHeader grayGvHeader" />
                            <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                            <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                            <RowStyle CssClass="gvItem" />
                        </ma:XGridView>
                    </asp:Panel>
                </div>
                <div style="height: 30px; width: 400px; background-color: #ffffff; border-right: #cccccc 2px solid;
                    border-bottom: #cccccc 1px inset; text-align: center;">
                    <table>
                        <tr>
                            <td align="right">
                               <input id="btnCancelar" class="button_back" onclick="javascript:HideConfirma2();"
                                    type="button" value="Aceptar" />
  
                            </td>
                            
                        </tr>
                       <%-- <tr>
                            <td align="right">
                                 <asp:Button runat="server" Text="Aceptar" class="button_back" ID="btnAceptarDestinatarios" onclick="btnAceptarDestinatarios_Click"></asp:Button>                 
                            </td>
                            
                        </tr>--%>
                        
                    </table>
                </div>
<%--            </ContentTemplate>
        </asp:UpdatePanel>--%>
    </asp:panel>
<asp:panel id="panelUpdateProgress" runat="server" cssclass="updateProgress">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <ProgressTemplate>
                <div style="position: relative; top: 30%; text-align: center; height: 100%; width: auto;">
                    <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                    Procesando...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:panel>
<ajaxToolkit:ModalPopupExtender ID="ModalPopupPosiblesDestinatarios" runat="server"
    TargetControlID="fielHidden" BackgroundCssClass="modalBackground" PopupControlID="pnlPosiblesDestinatarios" />
<asp:hiddenfield id="fielHidden" runat="server" />
<asp:hiddenfield id="hdPostbackControl" runat="server" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopupCargando" runat="server" TargetControlID="panelUpdateProgress"
    BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
<body>
    <form id="form1" runat="server">
    <div style="background-image: url('/Images/TemplateEstadoCuenta.JPG'); height: 600px;">
        <table>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblTitulo" runat="server" Text="PARTE" Font-Bold="True" Font-Names="Verdana"
                        ForeColor="White" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Panel ID="pnlContenido" runat="server">
            <table border="0" style="margin-left: 15%; width: 596px; font-family: Arial; font-size: 14px;">
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    N° de Parte:
                                </td>
                                <td>
                                    <asp:Label ID="lblNumeroParte" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                                <td>
                                    Fecha de Emisión:
                                </td>
                                <td>
                                     <asp:Label ID="lblFechaEmision" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Cobrador - Gestor:
                                </td>
                                <td>
                                     <asp:Label ID="lblCobrado" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                                <td>
                                    Fecha del 1° Vencimiento:
                                </td>
                                <td>
                                     <asp:Label ID="lblFechaPrimVencim" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    
                                </td>
                                <td>
                                    
                                </td>
                                <td>
                                    Fecha de Generación:
                                </td>
                                <td>
                                      <asp:Label ID="lblFechaGeneracion" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                Dirección Cliente:
                                </td>
                            </tr>
                            <tr>
                                <td>
                                
                                </td>
                                <td>
                                    <asp:Label ID="lblDireccionCliente" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                              <tr>
                                <td>
                                    Teléfonos:
                                </td>
                                <td>
                                     <asp:Label ID="lblTelefonoCliente" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                                <td>
                                    Fax:
                                </td>
                                <td>
                                      <asp:Label ID="lblResFax" runat="server" Font-Bold="true"></asp:Label>
                                </td>

                               
                            </tr>
                            <tr>
                               <td>
                               Para el cliente:
                               </td>
                               <td colspan="3">
                                   <asp:Label ID="lblNombreCliente" runat="server" Font-Bold="true"></asp:Label>
                               </td>
                            </tr>
                             <tr>
                               <td>
                                 Deudor:
                               </td>
                               <td colspan="3">
                                   <asp:Label ID="lblDeudor" runat="server" Font-Bold="true"></asp:Label>
                               </td>
                            </tr>
                              <tr>
                               <td>
                                 Clave del deudor para el cliente:
                               </td>
                               <td colspan="3">
                                   <asp:Label ID="lblAlfanum" runat="server" Font-Bold="true"></asp:Label>
                               </td>
                            </tr>
                            <tr>
                               <td>
                                 Dirección del Deudor:
                               </td>
                               <td colspan="3">
                                   <asp:Label ID="lblDireccionDeudor" runat="server" Font-Bold="true"></asp:Label>
                               </td>
                            </tr>
                             <tr>
                               <td>
                                 Teléfono del Deudor:
                               </td>
                               <td colspan="3">
                                   <asp:Label ID="lblTelefonoDeudor" runat="server" Font-Bold="true"></asp:Label>
                               </td>
                            </tr>
                            <tr>
                                <td>
                                    Observaciones:   
                                </td>
                                <td> 
                                    <asp:Label ID="lblObservaciones" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                        </table>
                      
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" BorderStyle="Solid" Height="166px" 
                            Width="598px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="false" CellPadding="4"
                            OnRowDataBound="gvFacturas_RowDataBound" Style="text-align: center; color: #111111;">
                            <Columns>
                                <asp:TemplateField HeaderText="Factura"></asp:TemplateField>
                                <asp:BoundField DataField="Id_Tipo_Comprobante" HeaderText="TipoComprobante" />
                                <asp:BoundField DataField="Letra" HeaderText="Letra" />
                                <asp:BoundField DataField="Emision" HeaderText="Emision" />
                                <asp:BoundField DataField="NumeroComp" HeaderText="NComprobante" />
                                <asp:BoundField DataField="Importe" HeaderText="Importe" />
                                <asp:BoundField DataField="Saldo" HeaderText="Saldo" />
                                <asp:BoundField DataField="FechaEmision" HeaderText="Fecha de Emision" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="FechaVenc" HeaderText="Fecha de Vencimiento" DataFormatString="{0:dd/MM/yyyy}" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSaldoTotal" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar Mail" OnClick="btnEnviar_Click"
            Style="margin-left: 33%" CssClass="button_back"  Visible="false" />
        <asp:Label ID="lblAgregarDestinatario" runat="server" Style="font-family: Verdana;
            font-size: 9px;" Text="Agregar Destinatarios" EnableViewState="False" Visible="true"></asp:Label>
        <asp:ImageButton ID="imgBtnAgregarDestinatario" runat="server" CausesValidation="False"
            Height="24px" ImageUrl="~/Images/agregar.gif" Width="18px" OnClick="VerPosiblesDestinatarios"  Visible="false"/>
    </div>
    </form>
</body>
</html>
