<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewPopUpHistoriaFactura.aspx.cs"
    Inherits="Vistas_ViewPopUpHistoriaFactura" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Observaciones para realizar la cobranza</title>
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Funciones.js" type="text/javascript"></script>

    <script language="JavaScript" src="../js/Modal.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            font-family: Tahoma, Arial, MS Sans Serif;
            font-size: 10px;
            color: #666666;
            background-image: url(  '../Images/fdo_tile.gif' );
            background-position: 50% top;
            background-color: white;
            font-weight: bold;
            vertical-align: top;
            height: 23px;
            width: 511px;
        }
        .style3
        {
            width: 276px;
            height: 24px;
        }
        .style6
        {
            width: 179px;
        }
        .style7
        {
            height: 101px;
        }
        .style8
        {
            height: 37px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div>
        <table style="width: 490px; border-style: solid; border-width: 1px;">
            <tr>
                <td style="background-color: #F2F2F2;">
                    <asp:Label ID="lblNombreCliente" runat="server" Text="Observaciones para realizar la cobranza" CssClass="bigLabelBold"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #F2F2F2;" class="style7">
                 <div style="overflow:auto; width:458px;">
                    <asp:ListBox ID="lstResHistorial" runat="server" Height="84px" Width="928px" CssClass="textboxEditor">
                    </asp:ListBox>
                 </div>
                </td>
            </tr>
            <tr>
                <td style="background-color: #F2F2F2;">
                    <ma:SecureButton ID="btnCerrar" runat="server" CssClass="button_back" Text="Cerrar"
                        Height="19px" Width="104px" OnClick="btnCerrar_Click" />
                </td>
        </table>
    </div>
    </form>
</body>
</html>
