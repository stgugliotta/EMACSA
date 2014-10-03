<%@ Page Language="C#"  AutoEventWireup="true"
    CodeFile="ViewLocalizarFactura.aspx.cs" Inherits="UIGobbi.Vistas.ViewLocalizarFactura" Title="Localizar Factura" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Recibos Cargados</title>
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Funciones.js" type="text/javascript"></script>

    <script language="JavaScript" src="../js/Modal.js" type="text/javascript"></script>
    </head>
<body onbeforeunload="salir(event)">
    <form id="form1" runat="server">
    
       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
</asp:ScriptManager>

    <table cellpadding="0" border="0" cellspacing="0" style=" height: 195px;
        left: 0; width: 652px;">
        <tr>
            <td valign="middle" align="center" style="height: 10px; font-family: Tahoma, Arial, MS Sans Serif;
                color: #666666; font-weight: bold; font-size: 12px; background-color: #EDEBEB;
                border-right: #cccccc 2px solid; border-bottom: #cccccc 1px inset; text-align: left;"
                valign="top">
                <asp:Label ID="lblAdmCasos" runat="server">Búsqueda de Factura</asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <table style=" height: 100%;" class="border" cellpadding="0" 
                    cellspacing="0">
                    <tr>
                        <td>
                            <table style="width: 605px; height: 88%;" class="borderCompleto" cellpadding="0"
                                cellspacing="0">
                                <tr>
                                    <td width="500px;" class="fondo_Titulo" align="left" style="height: 23px">
                                        Filtros de Búsqueda
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="80%">
                                            <tr align="left" style="border: 3px; height: 20px;">
                                                <td align="left" bgcolor="#F2F2F2" class="border" style="width: 40px; border-width: 1px;
                                                    border-style: solid;" valign="top">
                                                 
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td align="left" style="width: 40px; border-width: 1px; border-style: solid;" valign="top">
                                                    <table>
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:Panel ID="panelCliente" runat="server">
                                                                    <asp:Label ID="lblNumFactura" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                        Text="N° Factura"></asp:Label><br />
                                                                    <asp:TextBox ID="txtNumFactura" runat="server" CssClass="textboxEditor" ValidationGroup="MKE"
                                                                        Width="83px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Ingrese valor" ValidationGroup="MKE" ControlToValidate="txtNumFactura"></asp:RequiredFieldValidator>
                                                                        <br />
                                                                        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtNumFactura" ValidationGroup="MKE" ErrorMessage="Formato incorrecto" ValidationExpression="^[0-9]{1,6}$"></asp:RegularExpressionValidator>
                                                                        
                                                                </asp:Panel>
                                                            </td>
                                                            <td style="border-right-width: 2px; border-right-style: solid; border-left-width: 2px;
                                                                border-left-style: solid;">
                                                                <asp:Panel ID="panelFacturas" runat="server">
                                                                    <asp:Label ID="lblFiltrosFacturas" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                        Text="Estado Factura" Enabled="False"></asp:Label><br />
                                                                    <asp:RadioButtonList ID="radioEstadoFactura" runat="server" AutoPostBack="True" Font-Names="Verdana" Enabled="False"
                                                                        Font-Size="9px" >
                                                                        <asp:ListItem Value="1">Todos</asp:ListItem>
                                                                        <asp:ListItem Value="2">A vencer 5 días</asp:ListItem>
                                                                        <asp:ListItem Value="3">A vencer 5 a 15 días</asp:ListItem>
                                                                        <asp:ListItem Value="4">A vencer + 15 días</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </asp:Panel>
                                                            </td>
                                                            <td valign="top">
                                                                <asp:Panel ID="panelFechaCheque" runat="server" Enabled="False">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:RadioButton ID="radioAVencer" runat="server" AutoPostBack="true" 
                                                                                    Style="font-family: Verdana; font-size: 9px;" Text="A vencer entre" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label1" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                    Text="Fecha desde"></asp:Label><br />
                                                                                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="textboxEditor" ValidationGroup="MKE"
                                                                                    Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"
                                                                                        Enabled="True" Format="dd/MM/yyyy" PopupButtonID="imgFechaDesde" TargetControlID="txtFechaDesde" />
                                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaDesde" runat="server"
                                                                                    AcceptNegative="Left" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                    CultureTimePlaceholder="" DisplayMoney="Left" Enabled="True" ErrorTooltipEnabled="True"
                                                                                    Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaDesde" />
                                                                                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtenderFechaDesde"
                                                                                    ControlToValidate="txtFechaDesde" Display="None" EmptyValueMessage="El campo fecha desde no puede esta vacío"
                                                                                    ErrorMessage="MaskedEditValidator1" InvalidValueMessage="Fecha Desde invalida"
                                                                                    IsValidEmpty="False" /><img id="imgFechaDesde" alt="FechaDesde" onmouseover="this.style.cursor='pointer'"
                                                                                        src="../Images/Calendar.png" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblFEnvioLegajo" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                    Text="Fecha hasta"></asp:Label><br />
                                                                                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="textboxEditor" ValidationGroup="MKE"
                                                                                    Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server"
                                                                                        Enabled="True" Format="dd/MM/yyyy" PopupButtonID="imgFechaHasta" TargetControlID="txtFechaHasta" />
                                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaHasta" runat="server"
                                                                                    AcceptNegative="Left" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                    CultureTimePlaceholder="" DisplayMoney="Left" Enabled="True" ErrorTooltipEnabled="True"
                                                                                    Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaHasta" />
                                                                                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtenderFechaHasta"
                                                                                    ControlToValidate="txtFechaHasta" Display="None" EmptyValueMessage="El campo fecha hasta no puede esta vacío"
                                                                                    ErrorMessage="MaskedEditValidator1" InvalidValueMessage="Fecha Hasta invalida"
                                                                                    IsValidEmpty="False" /><img id="imgFechaHasta" alt="imgFechaHasta" onmouseover="this.style.cursor='pointer'"
                                                                                        src="../Images/Calendar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td align="right">
                                                    <asp:Button ID="btnVisualizar" runat="server" CssClass="button_back" 
                                                        Text="Visualizar" 
                                                        onclick="btnVisualizar_Click" CausesValidation="True" ValidationGroup="MKE"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <table cellpadding="0" cellspacing="0" class="borderCompleto" 
                                >
                                <tr>
                                    <td align="left" class="fondo_Titulo" style="height: 23px">
                                        <table>
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="height: 30px;">
                                                    Resultados
                                                </td>
                                                <td valign="top">
                                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/excel_small.gif"
                                                         />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:500px;" align="center">
                                        <asp:Panel ID="PnlListaCarga" runat="server" CssClass="scrollbar" Height="77px"
                                             ScrollBars="Horizontal">
                                            <ma:XGridView ID="gvResultados" runat="server"  AllowSorting="True"
                                                AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No se encontraron resultados"
                                                ExecutePageIndexChanging="True" Width="200px"
                                                Style="text-align: center; margin-left: 10%" 
                                                onselectedindexchanged="gvResultados_SelectedIndexChanged" Height="80px">
                                                <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                <Columns>
                                                    <asp:BoundField DataField="ComprobanteFormateado" HeaderText="Nro Factura" />
                                                    <asp:BoundField DataField="idCliente" HeaderText="IdCliente" />
                                                    <asp:BoundField DataField="IdDeudor" HeaderText="IdDeudor" />
                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                                    <asp:BoundField DataField="idRemision" HeaderText="Remision n°" />
                                                    <asp:BoundField DataField="EstadoRemision" HeaderText="Estado Remision" />
                                                    <asp:BoundField DataField="NumeroRecibo" HeaderText="Recibo n°" />
                                                </Columns>
                                                <SelectedRowStyle BackColor="#99CCFF" />
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
                                    </td>
                                </tr>
                            </table>
                         
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</form>
</body>
</html>
