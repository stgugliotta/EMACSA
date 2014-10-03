<%@ page language="C#" autoeventwireup="true" inherits="Vistas_ViewPopUpRecibosCargados, App_Web_nu_04hm5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb"%>
    


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recibos Cargados</title>
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Funciones.js" type="text/javascript"></script>

    <script language="JavaScript" src="../js/Modal.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        function ValidarFechaCobro() 
        {            
            var ddlAccion = document.getElementById("cmbAccion").selectedIndex;
            var hdDiaCobro = document.getElementById("hdDiaCobro").value;
            var arrDias = hdDiaCobro.split("-");
            var pszFecha = document.getElementById("txtFecha").value;
            var FechaACobrar = new Date(pszFecha.substr(6, 4), parseInt(pszFecha.substr(3, 2)) - 1, pszFecha.substr(0, 2));            
            var alertar = true;
            for (var i = 0; i < arrDias.length - 1; i++) 
            {
                var trunkada = FechaACobrar.getDay();
                if(trunkada == 0)
                    trunkada = 5;
                else
                if (trunkada == 1)
                    trunkada = 6;
                else
                if (trunkada >= 2 || trunkada <= 4)
                    trunkada = trunkada - 2;                
                if (trunkada == arrDias[i]) 
                {
                    alertar = false;
                    break;
                }
            }
            
            if (ddlAccion == 2 && alertar == true) 
            {
               var dias = document.getElementById("hdDiasDeCobro").value;
               return confirm("Sr./a Analista: El deudor paga los dias " + dias + ".\n¿Desea continuar?");
            }
            else
                return true;                
            
        }
        
function salir(e) 
{ 

//var hdWindowsName= document.getElementById("HiddenFieldWindowsName");
//CloseWindow(hdWindowsName.value);

                        
                        //globalWindowArray1.close();
                        
                    //    window.globalWindowArray1=null;
             

//var message='Si cierra esta ventana, puede perder los datos no guardados. ¿Está seguro de continuar? (Presione OK para salir del sitio o Cancel para continuar en él.)'; 
//var evtobj=window.event? event : e; 
// 
//    if(evtobj == e) 
//    { 
//        //firefox 
//        if (!evtobj.clientY) 
//        { 
//             evtobj.returnValue = message; 
//        } 
//    } 
//    else //IE
//    {
//        if (evtobj.clientY < 0) 
//        { 
//            evtobj.returnValue = message; 
//        }
//    }
}
        
        
        
function AbrirVentanaEdicionRecibos(url)
{
        window.opener.location.href= url;

}
    </script>

    <style type="text/css">
        .style1
        {
            font-family: Tahoma, Arial, MS Sans Serif;
            font-size: 10px;
            color: #666666;
            background-image: url( '../Images/fdo_tile.gif' );
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
<body onbeforeunload="salir(event)">
    <form id="form1" runat="server">
    
       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
</asp:ScriptManager>
    <div>
        <table style="width: 490px; border-style: solid; border-width: 1px;">
            <tr>
                <td style="background-color: #F2F2F2;">

                </td>
            </tr>
            <tr>
                <td align="left" class="style1">
                    Recibos cargados
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel runat="server" Height="161px" CssClass="scrollbar"  Width ="690px"
                        ScrollBars="Both">

                                                                            
<%--                        <ma:XGridView ID="GvResultados" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" BorderWidth="0px" DataKeyNames="NumRecibo" EmptyDataText="No se encontraron resultados"
                            Width="100%" Height="156px" ExecutePageIndexChanging="True" 
                             ><AlternatingRowStyle CssClass="gvAlternatingItem" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images/Lupa_chica.gif" ShowEditButton="True"
                                    HeaderText="Ver Historial"><HeaderStyle Font-Bold="True" /><ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="NumRecibo" HeaderText="NumRecibo" SortExpression="NumRecibo"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                              
                           </Columns>
                           <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" /><EmptyDataTemplate>No se hallaron resultados.</EmptyDataTemplate><FooterStyle CssClass="gvHeader grayGvHeader" /><HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" /><PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" /><RowStyle CssClass="gvItem" /></ma:XGridView>--%>
                            <ma:XGridView ID="GvResultados" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No se encontraron resultados"
                                                  Width="436px" DataKeyNames="NumRecibo"
                                                Style="text-align: center; margin-left: 10%" 
                                                 onselectedindexchanged="GvResultados_SelectedIndexChanged"
                                                >
                                                <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                <Columns>
                                                <asp:BoundField DataField="nombreDeudor" HeaderText="Nombre Deudor" />
                                                <asp:BoundField DataField="numRecibo" HeaderText="N° Recibo" />
                                                <asp:BoundField DataField="fechaCreacion" HeaderText="Fecha Creación" />
                                                <asp:BoundField DataField="tipoDeCambio" HeaderText="Tipo de Cambio" />
                                                <asp:BoundField DataField="usuarioCreador" HeaderText="Usuario" />
                                                <asp:BoundField DataField="idRemision" HeaderText="N° Remisión" />
                                                <asp:BoundField DataField="idCliente" HeaderText="ID Cliente" />
                                                <asp:BoundField DataField="idDeudor" HeaderText="ID Deudor" />
                                                <asp:CommandField HeaderText="Editar Recibo" ShowSelectButton="True" />
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
    </div>
      <asp:HiddenField ID="HiddenFieldWindowsName" runat="server" />
    </form>
  
</body>
</html>
