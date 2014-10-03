<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ViewPopUpProximasGestiones.aspx.cs"
    Inherits="Vistas_ViewPopUpProximasGestiones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Próximas Gestiones</title>
    <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
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
    <ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--Desde aqui comenzar a realizarlo -->
    <div >
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblTituloMiPortafolio" runat="server" Style="font-family: Verdana;
                        font-size: 14px; font-weight: bold; margin-left: 148px; margin-top: 28px;
                        position: absolute;" Text="Próximas Gestiones "></asp:Label>
                </td>
            </tr>
            <tr>
                <td  align="left" class="style18" style="margin-left: 28px; margin-top: 48px;
                        position: absolute;">
                    <asp:Panel ID="pnlGvResultados" runat="server" Height="345px" ScrollBars="Vertical"
                        CssClass="scrollbar">
                        <ma:XGridView ID="GvResultados" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" BorderWidth="0px" DataKeyNames="NombreDeudor" EmptyDataText="No tiene Gestiones cargadas para las próximas 2 horas."
                            Height="50px" Width="453px">
                            <AlternatingRowStyle CssClass="gvAlternatingItem" />
                            <Columns>
                                <asp:BoundField DataField="NombreDeudor" HeaderText="Deudor" Visible="True">
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ComprobanteFormateado" HeaderText="Factura" SortExpression="ComprobanteFormateado"
                                    Visible="True">
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataFormatString="{0:dd/MM/yyyy hh:mm}" DataField="ProximaGestion" HeaderText="Proxima Gestión"
                                    SortExpression="ProximaGestion">
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="#99CCFF" />
                            <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                            <EmptyDataTemplate>No tiene Gestiones cargadas para las próximas 2 horas.</EmptyDataTemplate>
                            <FooterStyle CssClass="gvHeader grayGvHeader" />
                            <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                            <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                            <RowStyle CssClass="gvItem" />
                        </ma:XGridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
