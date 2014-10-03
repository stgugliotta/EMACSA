<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewHistorialFacturasPorDeudor.aspx.cs" Inherits="Vistas_ViewHistorialFacturasPorDeudor" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewHistorialFacturasPorDeudor</title>
    <link rel="Stylesheet" type="text/css" href="../Css/GobbiMagicStyle.css" />
    <link rel="Stylesheet" type="text/css" href="../Css/GobbiStyle.css" />
    <style type="text/css">
        .style1
        {
            width:926px;
        }
        .style2
        {
            font-family: Tahoma, Arial, "MS Sans Serif";
            font-size: 10px;
            color: #666666;
            font-weight: bold;
            vertical-align: middle;
            height: 23px;
            width: 926px;
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
	    background: url("../Images/tableft1.gif");
	    display: block;
	    background: url("../Images/tabright1.gif") no-repeat right top;
	    color: #627EB7;
	    font-weight: bold;
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
            var rdoFechas = document.getElementById("rdoFechas");
            var rdoIdFactura = document.getElementById("rdoIdFactura");
            if (rdoFechas.checked == true) 
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
            else
            if (rdoIdFactura.checked == true) 
            {
                var txtIdFactura = document.getElementById("txtIdFactura");
                if (txtIdFactura.value == "" || txtIdFactura.value == null ) 
                {
                    alert("Complete el Id Factura.");
                    return false;
                }
                
//                if (!IsNumeric(txtIdFactura.value)) {
//                    alert("Id Factura debe ser numérico.");
//                    return false;
//                }
                
            }
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
    <ajaxToolkit:ToolkitScriptManager ID="tsmScriptManager" runat="server"></ajaxToolkit:ToolkitScriptManager>
    <div style="background-image: url('/Images/TemplateEstadoCuenta.JPG'); height: 600px">
        <table>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblTitulo" runat="server" Text="Historial de Facturas" Font-Bold="True" 
                        Font-Names="Verdana" ForeColor="White" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
        </table>    
        <br /><br /><br /><br />
        <asp:Panel ID="pnlContenido" runat="server" ScrollBars="Vertical" Height="400px">
            <table style="width:499px; font-family:Verdana;font-size:11px;color:#000000;background-color:White;" 
                border="1" class="borderCompleto">
                <tr><th colspan="2" class="style2"><asp:Label ID="lblDeudor" runat="server"></asp:Label></th></tr>
                <tr>
                    <td style="font-family: Verdana; font-size: 10px;font-weight: bold;">
                        <table border="0" width="100%">
                            <tr>
                                <th colspan="2"><asp:RadioButton ID="rdoFechas" runat="server" Checked="true" AutoPostBack="true" OnCheckedChanged="rdoFechas_CheckedChanged" GroupName="Radios" />Filtrar por fechas</th>
                            </tr>
                            <tr>
                                <th align="left">Desde:</th>
                                <td align="right">
                                    <asp:TextBox ID="txtFechaDesde" runat="server" Width="64" CssClass="textboxEditor"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="ceFechaDesde" runat="server" TargetControlID="txtFechaDesde" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <th align="left">Hasta:</th>
                                <td align="right">
                                    <asp:TextBox ID="txtFechaHasta" runat="server" Width="64" CssClass="textboxEditor"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="ceFechaHasta" runat="server" TargetControlID="txtFechaHasta" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                        </table>                                                
                    </td>
                    <td style="font-family: Verdana; font-size: 10px;font-weight: bold;" valign="top" align="left">
                        <table border="0" style="width: 98%">
                            <tr><th colspan="2">
                                <asp:RadioButton ID="rdoIdFactura" runat="server" AutoPostBack="true" OnCheckedChanged="rdoIdFactura_CheckedChanged" GroupName="Radios" />
                                Filtrar por Factura                            
                            </th></tr>
                            <tr>
                                <th align="left">Factura (Letra Emision Num. Ej: A 25 234):</th>
                                <td align="right"><asp:TextBox ID="txtIdFactura" runat="server" Width="64" 
                                        MaxLength="15" CssClass="textboxEditor"></asp:TextBox></td>
                                <asp:CustomValidator ID="CustomValidator1" 
                                  ControlToValidate="txtIdFactura"
                                  Text="Ingrese un número"
                                  ValidateEmptyText="False"
                                  OnServerValidate="NumericValidator_ServerValidate" 
                                  runat="server" ErrorMessage="Ingrese un número" ValidationGroup="datosGroup"/>

                            </tr>                                                
                        </table>
                    </td>
                </tr>
                <tr><td colspan="2"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" style="margin-left:40%;" OnClientClick="return ValidarFechas();" OnClick="btnBuscar_Click" CssClass="button_back" /></td></tr>
                
               
            </table> 
            <!-- Grilla de Facturas -->
             <table align="left">
                <tr>
                   <td align=left>
                   <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="false" CellPadding="3" style="color:#446688;font-family:Verdana;font-size:11px;"
                    RowStyle-BackColor="#DDEEFF" AlternatingRowStyle-BackColor="#CCDDEE" HeaderStyle-BackColor="#BBCCDD" DataKeyNames="NumeroComp" OnRowDataBound="gvFacturas_RowDataBound">
                <Columns>
                    <asp:TemplateField>
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
                    </asp:TemplateField>
                    <asp:BoundField DataField="IdFactura" HeaderText="IdFactura"  InsertVisible="false">
                        <HeaderStyle CssClass="HiddenColumn" /> 
                        <ItemStyle CssClass="HiddenColumn" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ComprobanteFormateado" HeaderText="Factura" />
                    <asp:BoundField DataField="FechaVenc" HeaderText="Fecha Vencimiento" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="FechaCobro" HeaderText="Fecha Cobro"  ConvertEmptyStringToNull="true"/>
                    <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                   <asp:TemplateField>
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
                    </asp:TemplateField>              
                </Columns>
            </asp:GridView>    
      
  
            </table>               
                    
            
        </asp:Panel>        
    </div>
    </form>
</body>
</html>
