<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ViewPopUpAgenda.aspx.cs" Inherits="Vistas_ViewPopUpAgenda" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Agenda</title>
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
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!--Desde aqui comenzar a realizarlo -->
    <div style="background-image: url('/Images/TemplateEstadoCuenta.JPG'); height: 600px;">
    <table>
        <tr><td><asp:Label ID="lblTituloMiPortafolio" runat="server" style="font-family: Verdana;font-size: 18px; font-weight:bold;color:#EFEFEF;margin-left:248px;margin-top:58px;position:absolute;" Text="Agenda "></asp:Label></td></tr>
    </table>
    <br /><br /><br /><br /><br />    
    <table style="margin-left:4px;">
    <tr>
        <td valign="top">            
            <table style=" height: 444px; width: 354px;">
            <tr>
                <td align="left">
                    <asp:Label ID="lblDeudoresAsignados" runat="server" style="font-family: Verdana;font-size: 9px;font-weight:bold;" Text="Deudores Asignados "></asp:Label>
                 </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="lstDeudoresAsignados" runat="server" CssClass="textboxEditor" 
                         Height="89px" Width="184px"></asp:ListBox>
                         
                </td>
            </tr>
            <tr>
                <td style="border-bottom-width:thin ; border-bottom-style:solid;">
                    <br />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lblTareasAsignadas" runat="server" style="font-family: Verdana;font-size: 9px;font-weight:bold;" Text="Tareas del día "></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="textboxEditor" Width="71px" Height="16px" AutoPostBack="True"
                        ontextchanged="txtFecha_TextChanged"></asp:TextBox>                   
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" 
                        PopupButtonID="ImgFecha" TargetControlID="txtFecha" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaDesde" runat="server" AcceptNegative="Left" 
                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" DisplayMoney="Left" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" 
                        TargetControlID="txtFecha" />
                    &nbsp;
                    <asp:ImageButton ID="ImgFecha" runat="server" ImageUrl="~/Images/Calendar.png" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="lstTareasAsignadas" runat="server" CssClass="textboxEditor" Height="89px" Width="292px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td style="border-bottom-width:thin ; border-bottom-style:solid;">
                    <br />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lblCrearTarea" runat="server" style="font-family: Verdana;font-size: 9px;font-weight:bold;" Text="Nueva Tarea "></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel runat="server" ID="UpdatePanelNuevaTarea" UpdateMode="Conditional">         
                        <ContentTemplate>
                            <table style="width: 340px; height: 101px;">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblDescripcion" runat="server" style="font-family: Verdana;font-size: 9px;font-weight:bold;" Text="Descripcion "></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtTareaDescripcion" runat="server" CssClass="textboxEditor" Width="113px" Height="16px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblFechaDeAviso" runat="server" style="font-family: Verdana;font-size: 9px;font-weight:bold;" Text="Fecha de Tarea "></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFechaNuevaTarea" runat="server" CssClass="textboxEditor" ValidationGroup="MKE" Width="83px" Height="16px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"                                                             
                                            PopupButtonID="imgFecha2" TargetControlID="txtFechaNuevaTarea" />                                                            
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"                                                             
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" DisplayMoney="Left" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" 
                                            TargetControlID="txtFechaNuevaTarea" />
                                        &nbsp;
                                        <asp:ImageButton ID="imgFecha2" runat="server" ImageUrl="~/Images/Calendar.png" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblHoraTarea" runat="server" style="font-family: Verdana;font-size: 9px;font-weight:bold;" Text="Hora Tarea "></asp:Label>
                                    </td>
                                    <td align="left">
                                        <MKB:timeselector ID="TimeSelector1" runat="server" MinuteIncrement="15" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblPrioridad" runat="server" style="font-family: Verdana;font-size: 9px;font-weight:bold;" Text="Prioridad "></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="cmbCriticidad" runat="server" AutoCompleteMode="SuggestAppend" 
                                            BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" 
                                            DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" MaxLength="0" Width="167px">                                
                                            <asp:ListItem>Critica</asp:ListItem>
                                            <asp:ListItem>Moderada</asp:ListItem>
                                            <asp:ListItem>Baja</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <ma:SecureButton ID="btnCrearTarea" runat="server"  Text="Crear" Height="20px" Width="95px" onclick="btnCrearTarea_Click" CssClass="button_back" />
                                    </td>
                                </tr>                             
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </td>
    </tr>
</table>
</div>

</form>
</body>
</html>