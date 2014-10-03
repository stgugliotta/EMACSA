<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewPopUpHitoFactura.aspx.cs"
    Inherits="Vistas_ViewPopUpHitoFactura" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Facturas</title>
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Funciones.js" type="text/javascript"></script>

    <script language="JavaScript" src="../js/Modal.js" type="text/javascript"></script>

    <script type="text/javascript">
        function ValidarFechaCobro() 
        {            
            var ddlAccion = document.getElementById("cmbAccion").selectedIndex;
            var hdDiaCobro = document.getElementById("hdDiaCobro").value;
            //alert (hdDiaCobro);
            var arrDias = hdDiaCobro.split("-");
            var pszFecha = document.getElementById("txtFecha").value;
            var fechaACobrar = new Date(pszFecha.substr(6, 4), parseInt(pszFecha.substr(3, 2)) - 1, pszFecha.substr(0, 2));            
            var alertar = true;
            
            if (ddlAccion==0)
            {
            alert('Seleccione una acción.');
            return false;
            }
            
            for (var i = 0; i < arrDias.length - 1; i++) 
            {
                var trunkada = fechaACobrar.getDay();
               trunkada++;
//                if(trunkada == 0)
//                    trunkada = 7;
                /*else
                if (trunkada == 1)
                    trunkada = 6;
                else
                if (trunkada >= 2 || trunkada <= 4)
                    trunkada = trunkada - 2;   */             
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
        
function  ConfirmarCargarDomicilioSiNoExiste(deudor)
{
 if(confirm("¿Desea cargar el deudor en éste momento?")) 
      { 
        document.location='http://' + document.location.host + '/Vistas/ViewAltaDeudor.aspx?Id_Deudor='+ deudor;
      }
      else
      {
        return false;
      }   
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

function OpenViewParent(url)
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
<body onbeforeunload="salir(event)">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div>
        <table style="width: 490px; border-style: solid; border-width: 1px;">
            <tr>
                <td style="background-color: #F2F2F2;">
                    <asp:Label ID="lblNombreCliente" runat="server" Text="Cliente: " CssClass="bigLabelBold"></asp:Label>
                    <asp:Label ID="lblResNombreCliente" runat="server" CssClass="bigLabelTahoma"></asp:Label> &nbsp;
                    
                    <asp:Label ID="lblNombreDeudor" runat="server" Text="Deudor: " CssClass="bigLabelBold"></asp:Label>
                    <asp:Label ID="lblResNombreDeudor" runat="server" CssClass="bigLabelTahoma"></asp:Label>
                    <asp:HiddenField ID="hdDiaCobro" runat="server" />
                    <asp:HiddenField ID="hdDiasDeCobro" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" class="style1">
                    Facturas seleccionadas del deudor
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel runat="server" Height="61px" CssClass="scrollbar" ScrollBars="Both">
                        <ma:XGridView ID="GvResultados" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            BorderWidth="0px" DataKeyNames="idFactura" EmptyDataText="No se encontraron resultados"
                            Width="100%" Height="60px" ExecutePageIndexChanging="True" 
                            OnRowEditing="GvResultados_RowEditing">
                            <AlternatingRowStyle CssClass="gvAlternatingItem" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images/Lupa_chica.gif" ShowEditButton="True"
                                    HeaderText="Ver Historial">
                                    <HeaderStyle Font-Bold="True" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="idFactura" HeaderText="Factura" InsertVisible="false">
                                    <HeaderStyle CssClass="HiddenColumn" />
                                    <ItemStyle CssClass="HiddenColumn" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ComprobanteFormateado" HeaderText="Nro Factura" />
                                <asp:BoundField DataField="fechaVenc" HeaderText="Vencimiento">
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Saldo" DataField="Saldo"></asp:BoundField>
                                <asp:BoundField DataField="estado" HeaderText="Estado">
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaCobro" HeaderText="Próxima Gestión">
                                    <HeaderStyle Font-Bold="true" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                No se hallaron resultados.</EmptyDataTemplate>
                            <FooterStyle CssClass="gvHeader grayGvHeader" />
                            <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                            <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                            <RowStyle CssClass="gvItem" />
                        </ma:XGridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="background-color: #F2F2F2;">
                    <asp:Label ID="lblObservaciones" runat="server" Style="font-family: Verdana; font-size: 9px;"
                        Text="Observaciones: ">
                    </asp:Label>
                    &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="cmbObservaciones" runat="server" AutoCompleteMode="SuggestAppend"
                        BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                        DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" MaxLength="0"
                        Width="177px">
                        <asp:ListItem>Info Hoja de Ruta</asp:ListItem>
                        <asp:ListItem>No contesta</asp:ListItem>
                        <asp:ListItem>No reconoce factura</asp:ListItem>
                        <asp:ListItem>Pide copia fiel</asp:ListItem>
                        <asp:ListItem>No recibio facturas</asp:ListItem>
                        <asp:ListItem>Llamar en otra fecha</asp:ListItem>
                        <asp:ListItem>Llamar en otro horario</asp:ListItem>
                        <asp:ListItem>No posee fecha de pago</asp:ListItem>
                        <asp:ListItem>Se envía email al cliente</asp:ListItem>
                        <asp:ListItem>Se consulta por web del cliente</asp:ListItem>
                        <asp:ListItem>Pago con deposito</asp:ListItem>
                        <asp:ListItem>Gestión a cargo del cliente</asp:ListItem>
                        <asp:ListItem>Pide NC por esta FC</asp:ListItem>
                        <asp:ListItem>Recibimos Email</asp:ListItem>
                        <asp:ListItem>Se manda a cobrar</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="background-color: #F2F2F2;">
                    <asp:Label ID="lblInfoComplementaria" runat="server" Style="font-family: Verdana;
                        font-size: 9px;" Text="Información Completaria: ">
                    </asp:Label>
                    <asp:TextBox ID="txtInfoComplementaria" runat="server" CssClass="textboxEditor" Width="390px"
                        Height="22px" ReadOnly="false" 
                        ontextchanged="txtInfoComplementaria_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #F2F2F2;">
                    <table>
                        <tr>
                            <td style="background-color: #F2F2F2;" class="style8">
                                <asp:Label ID="lblAgendarPara" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                    Text="Agendar para: ">
                                </asp:Label>
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="textboxEditor" Width="62px" Height="14px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupButtonID="ImgFecha" TargetControlID="txtFecha" />
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaDesde" runat="server"
                                    AcceptNegative="Left" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" DisplayMoney="Left" Enabled="True" ErrorTooltipEnabled="True"
                                    Mask="99/99/9999" MaskType="Date" TargetControlID="txtFecha" />
                                <asp:ImageButton ID="ImgFecha" runat="server" ImageUrl="~/Images/Calendar.png" 
                                   />
                       <%--     <asp:RangeValidator ID="RangeValidatorMinFecha" runat="server" ErrorMessage="Fecha Inválida."
                                    ControlToValidate="txtFecha" MinimumValue='<%=DateTime.Now %>' MaximumValue='<%=DateTime.Parse("01/01/2020") %>' ></asp:RangeValidator>
                 --%>       </td> 
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td style="background-color: #F2F2F2;" class="style8">
                                <mkb:TimeSelector ID="timeSelector" runat="server" MinuteIncrement="15" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
            <td>
                <asp:CheckBox ID="chkDomicilioAlternativo" runat="server" AutoPostBack="true"  Text="Domicilio Alternativo" Style="font-family: Verdana; font-size: 9px;" Checked="false" OnCheckedChanged="HabilitarPanelDomicilioAlternativo_CheckedChanged"/>
                <br/>
                <asp:Panel ID="PanelDomicilioAlternativo" runat="server" CssClass="scrollbar" 
                       >
                <asp:Label ID="lblDomicilioAlt" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                Text="Domicilios disponibles: ">
                                            </asp:Label>
                                            &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="cmbDomicilioAlternativo" runat="server" AutoCompleteMode="SuggestAppend"
                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px"
                                                MaxLength="0" Width="140px">
                                                <asp:ListItem>--- Seleccione ---</asp:ListItem>
                                                <asp:ListItem></asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:Button ID="btnAgregarDomicilioAlternativo" 
                        runat="server" Text="+" Visible="true" onclick="btnAgregarDomicilioAlternativo_Click"
                                             ></asp:Button>
                 </asp:Panel> 

                 <asp:panel id="panelHorariosReclamo" runat="server"  ScrollBars="Vertical" Height="140" >
					 <asp:UpdatePanel ID="UpdatePanelHorariosAlternativos" runat="server" UpdateMode="Conditional"   >
                                            <ContentTemplate>
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; width: 100%;
                                                text-align: center;">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label2" runat="server" Text="   Horarios de Cobro Adicional" />
                                                           
                                                        </td>
                                             </tr>
                                                </table>
                                            </div>
                                           
                                                <table width="100%">
                                                    <tr class="fondo_Titulo">
                                                      
                                                        <td>
                                                            Hora desde
                                                        </td>
                                                        <td>
                                                            Hora hasta
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr class="fondo_Titulo">
                                                        <td>
                                                            <%--<mkb:TimeSelector ID="tsHorarioDesde" runat="server" MinuteIncrement="10"  SelectedTimeFormat="TwentyFour" />--%>
                                                             <asp:DropDownList ID="tsHorarioDesde" runat="server" EnableViewState="true">
                                                            <asp:ListItem value ="0:00"> 0:00 </asp:ListItem>
                                                            <asp:ListItem value ="0:30"> 0:30 </asp:ListItem>
                                                            <asp:ListItem value ="1:00"> 1:00 </asp:ListItem>
                                                            <asp:ListItem value ="1:30"> 1:30 </asp:ListItem>
                                                            <asp:ListItem value ="2:00"> 2:00 </asp:ListItem>
                                                            <asp:ListItem value ="2:30"> 2:30 </asp:ListItem>
                                                            <asp:ListItem value ="3:00"> 3:00 </asp:ListItem>
                                                            <asp:ListItem value ="3:30"> 3:30 </asp:ListItem>
                                                            <asp:ListItem value ="4:30"> 4:30 </asp:ListItem>
                                                            <asp:ListItem value ="5:00"> 5:00 </asp:ListItem>
                                                            <asp:ListItem value ="5:30"> 5:30 </asp:ListItem>
                                                            <asp:ListItem value ="6:00">6:00 </asp:ListItem>
                                                            <asp:ListItem value ="6:30">6:30 </asp:ListItem>
                                                            <asp:ListItem value ="7:00">7:00</asp:ListItem>
                                                            <asp:ListItem value ="7:30"> 7:30 </asp:ListItem>
                                                            <asp:ListItem value ="8:00"> 8:00 </asp:ListItem>
                                                            <asp:ListItem value ="8:30"> 8:30 </asp:ListItem>
                                                            <asp:ListItem value ="9:00"> 9:00 </asp:ListItem>
                                                            <asp:ListItem value ="9:30"> 9:30 </asp:ListItem>
                                                            <asp:ListItem value ="10:00"> 10:00 </asp:ListItem>
                                                            <asp:ListItem value ="10:30"> 10:30 </asp:ListItem>
                                                            <asp:ListItem value ="11:00"> 11:00 </asp:ListItem>
                                                            <asp:ListItem value ="11:30"> 11:30 </asp:ListItem>
                                                            <asp:ListItem value ="12:00"> 12:00 </asp:ListItem>
                                                            <asp:ListItem value ="12:30"> 12:30 </asp:ListItem>
                                                            <asp:ListItem value ="13:00"> 13:00 </asp:ListItem>
                                                            <asp:ListItem value ="13:30"> 13:30 </asp:ListItem>
                                                            <asp:ListItem value ="14:00"> 14:00 </asp:ListItem>
                                                            <asp:ListItem value ="14:30"> 14:30 </asp:ListItem>
                                                            <asp:ListItem value ="15:00"> 15:00 </asp:ListItem>
                                                            <asp:ListItem value ="15:30"> 15:30 </asp:ListItem>
                                                            <asp:ListItem value ="16:00"> 16:00 </asp:ListItem>
                                                            <asp:ListItem value ="16:30"> 16:30 </asp:ListItem>
                                                            <asp:ListItem value ="17:00"> 17:00 </asp:ListItem>
                                                            <asp:ListItem value ="17:30"> 17:30 </asp:ListItem>
                                                            <asp:ListItem value ="18:00"> 18:00 </asp:ListItem>
                                                            <asp:ListItem value ="18:30"> 18:30 </asp:ListItem>
                                                            <asp:ListItem value ="19:00"> 19:00 </asp:ListItem>
                                                            <asp:ListItem value ="19:30"> 19:30 </asp:ListItem>
                                                            <asp:ListItem value ="20:00"> 20:00 </asp:ListItem>
                                                            <asp:ListItem value ="20:30"> 20:30 </asp:ListItem>
                                                            <asp:ListItem value ="21:00"> 21:00 </asp:ListItem>
                                                            <asp:ListItem value ="21:30"> 21:30 </asp:ListItem>
                                                            <asp:ListItem value ="22:00"> 22:00 </asp:ListItem>
                                                            <asp:ListItem value ="22:30"> 22:30 </asp:ListItem>
                                                            <asp:ListItem value ="23:00"> 23:00 </asp:ListItem>
                                                            <asp:ListItem value ="23:30"> 23:30 </asp:ListItem>
                                                            <asp:ListItem value ="24:00"> 24:00 </asp:ListItem>
                                                            
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                           <%-- <mkb:TimeSelector ID="tsHorarioHasta" runat="server" MinuteIncrement="10" SelectedTimeFormat="TwentyFour" />--%>
                                                            <asp:DropDownList ID="tsHorarioHasta" runat="server" EnableViewState="true">
                                                            <asp:ListItem value ="0:00"> 0:00 </asp:ListItem>
                                                            <asp:ListItem value ="0:30"> 0:30 </asp:ListItem>
                                                            <asp:ListItem value ="1:00"> 1:00 </asp:ListItem>
                                                            <asp:ListItem value ="1:30"> 1:30 </asp:ListItem>
                                                            <asp:ListItem value ="2:00"> 2:00 </asp:ListItem>
                                                            <asp:ListItem value ="2:30"> 2:30 </asp:ListItem>
                                                            <asp:ListItem value ="3:00"> 3:00 </asp:ListItem>
                                                            <asp:ListItem value ="3:30"> 3:30 </asp:ListItem>
                                                            <asp:ListItem value ="4:30"> 4:30 </asp:ListItem>
                                                            <asp:ListItem value ="5:00"> 5:00 </asp:ListItem>
                                                            <asp:ListItem value ="5:30"> 5:30 </asp:ListItem>
                                                            <asp:ListItem value ="6:00">6:00 </asp:ListItem>
                                                            <asp:ListItem value ="6:30">6:30 </asp:ListItem>
                                                            <asp:ListItem value ="7:00">7:00</asp:ListItem>
                                                            <asp:ListItem value ="7:30"> 7:30 </asp:ListItem>
                                                            <asp:ListItem value ="8:00"> 8:00 </asp:ListItem>
                                                            <asp:ListItem value ="8:30"> 8:30 </asp:ListItem>
                                                            <asp:ListItem value ="9:00"> 9:00 </asp:ListItem>
                                                            <asp:ListItem value ="9:30"> 9:30 </asp:ListItem>
                                                            <asp:ListItem value ="10:00"> 10:00 </asp:ListItem>
                                                            <asp:ListItem value ="10:30"> 10:30 </asp:ListItem>
                                                            <asp:ListItem value ="11:00"> 11:00 </asp:ListItem>
                                                            <asp:ListItem value ="11:30"> 11:30 </asp:ListItem>
                                                            <asp:ListItem value ="12:00"> 12:00 </asp:ListItem>
                                                            <asp:ListItem value ="12:30"> 12:30 </asp:ListItem>
                                                            <asp:ListItem value ="13:00"> 13:00 </asp:ListItem>
                                                            <asp:ListItem value ="13:30"> 13:30 </asp:ListItem>
                                                            <asp:ListItem value ="14:00"> 14:00 </asp:ListItem>
                                                            <asp:ListItem value ="14:30"> 14:30 </asp:ListItem>
                                                            <asp:ListItem value ="15:00"> 15:00 </asp:ListItem>
                                                            <asp:ListItem value ="15:30"> 15:30 </asp:ListItem>
                                                            <asp:ListItem value ="16:00"> 16:00 </asp:ListItem>
                                                            <asp:ListItem value ="16:30"> 16:30 </asp:ListItem>
                                                            <asp:ListItem value ="17:00"> 17:00 </asp:ListItem>
                                                            <asp:ListItem value ="17:30"> 17:30 </asp:ListItem>
                                                            <asp:ListItem value ="18:00"> 18:00 </asp:ListItem>
                                                            <asp:ListItem value ="18:30"> 18:30 </asp:ListItem>
                                                            <asp:ListItem value ="19:00"> 19:00 </asp:ListItem>
                                                            <asp:ListItem value ="19:30"> 19:30 </asp:ListItem>
                                                            <asp:ListItem value ="20:00"> 20:00 </asp:ListItem>
                                                            <asp:ListItem value ="20:30"> 20:30 </asp:ListItem>
                                                            <asp:ListItem value ="21:00"> 21:00 </asp:ListItem>
                                                            <asp:ListItem value ="21:30"> 21:30 </asp:ListItem>
                                                            <asp:ListItem value ="22:00"> 22:00 </asp:ListItem>
                                                            <asp:ListItem value ="22:30"> 22:30 </asp:ListItem>
                                                            <asp:ListItem value ="23:00"> 23:00 </asp:ListItem>
                                                            <asp:ListItem value ="23:30"> 23:30 </asp:ListItem>
                                                            <asp:ListItem value ="24:00"> 24:00 </asp:ListItem>
                                                            
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnAgregarHorarioReclamo" runat="server" Text="+" Visible="true"
                                                              ValidationGroup="Any" OnClick="btnAgregarHorarioReclamo_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    <asp:Repeater runat="server" ID="myRepeater" >
                                                    
                                                     <HeaderTemplate>
                                                     <table border="1" class="gvAlternatingItem">
                                                        <tr>
                                                           <td><b>Id</b></td>
                                                           <td><b>Desde</b></td>
                                                           <td><b>Hasta</b></td>
                                                        </tr>
                                                  </HeaderTemplate>
                                                     <ItemTemplate>
                                                     
                                                      <tr>
                                                            <td> <%# DataBinder.Eval(Container.DataItem, "Position") %> </td>
                                                            <td> <%# DataBinder.Eval(Container.DataItem, "HorarioDesde") %> </td>
                                                            <td> <%# DataBinder.Eval(Container.DataItem, "HorarioHasta") %> </td>
                                                            <td>    <asp:LinkButton ID="myRepeaterOfDeletes" runat="server" 
                                                                OnCommand="OnDeleteHorarioReclamo" Text='Eliminar' CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Position")%>'  /></td>
                                                            
                                                     </tr>
                                                     </ItemTemplate>
                                                     
                                                     <FooterTemplate>
                                                         </table>
                                                      </FooterTemplate>
          
                                                    </asp:Repeater>
                                                <%-- </asp:Table>--%>
                                         
   						</ContentTemplate>
                    </asp:UpdatePanel>
			</asp:panel>
            </td>
            </tr>
            <tr>
                <td style="background-color: #F2F2F2;">
                    <asp:CustomValidator ID="AgendarParaValidator" ControlToValidate="txtFecha" Display="Static"
                        ErrorMessage="Debe ingresar la fecha para agendar la gestión" Font-Size="10pt"
                        OnServerValidate="agendarParaFieldValidate" runat="server" ValidationGroup="grupoValidation" />
                </td>
            </tr>
            <tr>
                <td style="background-color: #F2F2F2;" valign="top">
                    <asp:Label ID="lblHistorial" runat="server" Style="font-family: Verdana; font-size: 9px;"
                        Text="Historial: ">
                    </asp:Label>
                    
                    <div style="overflow: auto; width: 550px;">
                        <asp:ListBox ID="lstResHistorial" runat="server" Height="55px" Width="928px" 
                            CssClass="textboxEditor">
                        </asp:ListBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style3" style="background-color: #F2F2F2;">
                    <table>
                        <tr>
                            <td align="left" style="background-color: #F2F2F2;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAccion" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                Text="Accion: ">
                                            </asp:Label>
                                            &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="cmbAccion" runat="server" AutoCompleteMode="SuggestAppend"
                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" MaxLength="0"
                                                Width="140px">
                                                <asp:ListItem>--- Seleccione ---</asp:ListItem>
                                                <asp:ListItem>A_GESTION</asp:ListItem>
                                                <asp:ListItem>A_COBRAR</asp:ListItem>
                                                <asp:ListItem>BAJA DEFINITIVA GEST.</asp:ListItem>
                                                </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;
                                            <asp:Label ID="lblEnviarMail" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                Text="Enviar Mail: ">
                                            </asp:Label>
                                        </td>
                                        <td class="style6" align="left">
                                            &nbsp;&nbsp;<asp:CheckBox ID="chkEnviarEmail" runat="server" Checked="false" />
                                        </td>
                                        <td class="style6" align="left">
                                            <ma:SecureButton ID="btnAplicar" runat="server" CssClass="button_back" OnClick="Aplicar_Click"
                                                Text="Aplicar" OnClientClick="javascript: return ValidarFechaCobro();" Height="20px"
                                                Width="95px" CausesValidation="true" ValidationGroup="grupoValidation" />
                                        </td>
                                        <td style="background-color: #F2F2F2;">
                                            <ma:SecureButton ID="btnCerrar" runat="server" CssClass="button_back" Text="Cerrar"
                                                Height="19px" Width="104px" OnClick="btnCerrar_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="HiddenFieldWindowsName" runat="server" />
    </form>
</body>
</html>