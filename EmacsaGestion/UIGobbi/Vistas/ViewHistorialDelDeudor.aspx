<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewHistorialDelDeudor.aspx.cs"
    Inherits="Vistas_HistorialDelDeudor" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewHistorialFacturas</title>
    <link rel="Stylesheet" type="text/css" href="../Css/GobbiMagicStyle.css" />
    <link rel="Stylesheet" type="text/css" href="../Css/GobbiStyle.css" />
    <style type="text/css">
        .style1
        {
            width: 843px;
            height: 50px;
        }
        .style2
        {
            font-family: Tahoma, Arial, "MS Sans Serif";
            font-size: 10px;
            color: #666666;
            font-weight: bold;
            vertical-align: middle;
            height: 23px;
            width: 834px;
            background-color: white;
            background-image: url('../Images/fdo_tile.gif');
            background-position: 50% top;
        }
        table.borderCompleto
        {
            padding: 2px;
            border-right: gainsboro 1px solid;
            border-left: gainsboro 1px solid;
            border-bottom: gainsboro 1px solid;
            border-top: gainsboro 1px solid;
        }
        .button_back
        {
            font-family: Tahoma, Arial, MS Sans Serif;
            font-size: 11px;
            color: #0099FF;
            border-bottom: 1px solid #BCD2E6;
            background: url(   "../Images/tableft1.gif" );
            display: block;
            background: url(   "../Images/tabright1.gif" ) no-repeat right top;
            color: #627EB7;
            font-weight: bold;
            margin-bottom: 0px;
        }
        .style13
        {
            width: 834px;
        }
        .style14
        {
            width: 594px;
        }
    </style>

    <script type="text/javascript">
    
    function IsNumeric(strString)
   //  check for valid numeric strings	
   {
   var strValidChars = "0123456789";
   var strChar;
   var blnResult = true;

   if (strString.length == 0) return false;

   //  test strString consists of valid characters listed above
   for (i = 0; i < strString.length && blnResult == true; i++)
      {
      strChar = strString.charAt(i);
      if (strValidChars.indexOf(strChar) == -1)
         {
         blnResult = false;
         }
      }
   return blnResult;
   }
        function ValidarFechas() 
        {
                var txtFechaDesde = document.getElementById("txtFechaDesde");
                var txtFechaHasta = document.getElementById("txtFechaHasta");

                if (txtFechaDesde.value == "" || txtFechaDesde.value == null || txtFechaHasta.value == "" || txtFechaHasta.value == null) 
                {
                    alert("Complete ambas fechas.");
                    return false;
                }
                return true;
           
        }
        function CambiarVistas(obj, row) 
        {
            var div = document.getElementById(obj);
            var img = document.getElementById('img' + obj);

            if (div.style.display == "none") {
                div.style.display = "inline";
                if (row == 'alt') {
                    img.src = "../Images/Expand_button_white_down.jpg";
                    mce_src = "../Images/Expand_button_white_down.jpg";
                }
                else {
                    img.src = "../Images/Expand_button_white_down.jpg";
                    mce_src = "../Images/Expand_button_white_down.jpg";
                }
                img.alt = "Cerrar para ver otros detalles.";
            }
            else {
                div.style.display = "none";
                if (row == 'alt') {
                    img.src = "../Images/Expand_button_white.jpg";
                    mce_src = "../Images/Expand_button_white.jpg";
                }
                else {
                    img.src = "../Images/Expand_button_white.jpg";
                    mce_src = "../Images/Expand_button_white.jpg";
                }
                img.alt = "Expandir para ver otros detalles.";
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tsmScriptManager" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div>
        <table>
            <tr>
                <td align="center" class="style1" style="background-image: url('/Images/CabeceraHistorialEmacsa3.png');
                    background-repeat: no-repeat;">
                    <asp:Label ID="lblTitulo" runat="server" Text="Historial del deudor" Font-Bold="True"
                        Font-Names="Verdana" ForeColor="White" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlContenido" runat="server" ScrollBars="Vertical" 
            Height="400px" Width="912px">
            <table style="width: 500px; font-family: Verdana; font-size: 11px; color: #000000;
                background-color: White;" class="borderCompleto">
                <tr>
                    <th class="style2" align="center">
                        <asp:Label ID="lblDeudor" runat="server"></asp:Label>
                    </th>
                </tr>
                <tr>
                    <td class="style13">
                       <asp:UpdatePanel runat="server" ID="UpdatePanelIndice" UpdateMode="Conditional">
                       <ContentTemplate>
                                
                        <table style="width: 892px; height: 97px;" style="background-color: #EDEBEB; border-style: none groove outset none;
                            border-bottom-color: #FFFFFF; border-right-color: #C0C0C0; border-width: thin 2px 2px 1px;
                            border-spacing: 2px; border-collapse: collapse">
                            <tr>
                                <td>
                                    <asp:Label ID="lblClientes" runat="server" Style="font-family: Verdana; font-size: 10px;
                                        font-weight: bold;" Text="Cliente: " EnableViewState="False"></asp:Label>
                                    &nbsp;
                                    <asp:DropDownList ID="cmbClientes" runat="server" AutoCompleteMode="SuggestAppend"
                                        BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                        DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="10px" Height="20px"
                                        MaxLength="0" onselectedindexchanged="cmbClientes_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                 <td>
                                    <asp:Label ID="lblDeudor2" runat="server" Style="font-family: Verdana; font-size: 10px;
                                        font-weight: bold;" Text="Deudor: " EnableViewState="False"></asp:Label>
                                    &nbsp;
                                    <asp:DropDownList ID="cmbDeudores" runat="server" AutoCompleteMode="SuggestAppend"
                                        BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                        DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="10px" Height="20px"
                                        MaxLength="0">
                                    </asp:DropDownList>
                                </td>
                                
                                <td class="style14">
                                    <asp:Label ID="lblClientes0" runat="server" EnableViewState="False" Style="font-family: Verdana;
                                        font-size: 10px; font-weight: bold;" Text="Rango de fechaa: "></asp:Label>
                                    &nbsp;&nbsp;
                                    <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="textboxEditor" Width="64"></asp:TextBox>
                                    &nbsp;&nbsp;
                                    <ajaxToolkit:CalendarExtender ID="ceFechaDesde" runat="server" Format="dd-MM-yyyy"
                                        TargetControlID="txtFechaDesde">
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="textboxEditor" Width="64"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="ceFechaHasta" runat="server" Format="dd-MM-yyyy"
                                        TargetControlID="txtFechaHasta">
                                    </ajaxToolkit:CalendarExtender>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                            <td colspan="2" align ="right">
                                    <asp:Button ID="btnBuscar" runat="server" CssClass="button_back" 
                                        OnClick="btnBuscar_Click" OnClientClick="return ValidarFechas();" 
                                        Text="    Buscar    " />
                            
                            </td>
                            </tr>
                        </table>
                        <!-- Grilla de Facturas -->
                        <table align="left">
                            <tr>
                                <td align="left">
                                    <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="false" CellPadding="3"
                                        Style="color: #446688; font-family: Verdana; font-size: 11px;" RowStyle-BackColor="#DDEEFF"
                                        AlternatingRowStyle-BackColor="#CCDDEE" HeaderStyle-BackColor="#BBCCDD" DataKeyNames="NumeroComp"
                                        OnRowDataBound="gvFacturas_RowDataBound">
                                        <Columns>
                                            <%--                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="javascript:CambiarVistas('div<%# Eval("NumeroComp") %>','one');">
                                <img id="imgdiv<%# Eval("NumeroComp") %>" alt="Click para expandir/contraer" border="0" src="../Images/Expand_button_white.jpg" />
                            </a>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <a href="javascript:CambiarVistas('div<%# Eval("NumeroComp") %>','alt');">
                                <img id="imgdiv<%# Eval("NumeroComp") %>" alt="Click para expandir/contraer" border="0" src="../Images/Expand_button_white.jpg" />
                            </a>
                        </AlternatingItemTemplate>
                    </asp:TemplateField>--%>
                                            <asp:BoundField DataField="FechaActividad" HeaderText="FechaActividad" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="IdFactura" HeaderText="IdFactura" InsertVisible="false">
                                                <HeaderStyle CssClass="HiddenColumn" />
                                                <ItemStyle CssClass="HiddenColumn" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Letra" HeaderText="Letra" />
                                            <asp:BoundField DataField="ComprobanteFormateado" HeaderText="Factura" />
                                            <asp:BoundField DataField="FechaVenc" HeaderText="Fecha Vencimiento" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="Importe" HeaderText="Importe" />
                                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                            <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                            <%-- <asp:TemplateField>
                        <ItemTemplate>
                            </td></tr>
                            <tr>
                                <td colspan="100%" align="left" >
                                    <div id="div<%# Eval("NumeroComp") %>"  style="display:none;">
                                        <asp:Table ID="tblDetalles" runat="server"></asp:Table>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:TemplateField>              --%>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
