<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Vistas_ViewRemisionDeValores, App_Web_nu_04hm5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"> </script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>

    <script type="text/javascript" src="../UIControls/MenuJQuery/Menu/shCore.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>

    <script src="/Js/JsHelper.js" type="text/javascript"></script>

    <script src="/Js/JsMessagesToUser.js" type="text/javascript"></script>

    <script src="/MappingObjectsClientSide/DTOObjects2.js" type="text/javascript"></script>

    <%--<input id="Button2" class="button_back"  onclick ="javascript:HideModalRemisionesAbiertas();"
                                    type="button" value="Cancelar" />--%>
    <style type="text/css">
        #img_container
        {
            height: 120px;
        }
        #img_container ul
        {
            display: block;
            padding: 0;
            margin: 0;
            list-style: none;
        }
        #img_container ul li
        {
            float: left;
            width: 100px;
            margin: 10px;
        }
        #img_container ul li a img
        {
            width: 93px;
            height: 93px;
            border: 1px solid #574331;
            padding: 5px;
            background: #eee;
        }
        #img_container ul li a:hover img
        {
            border-color: Silver;
        }
    </style>

    <script type="text/javascript">

                var ModalPopupCargando='<%= ModalPopupCargando.ClientID %>';
                var ModalPopupDetalleCheques='<%= ModalPopupDetalleCheques.ClientID %>';
                var ModalPopupProntoPago='<%= ModalPopupProntoPago.ClientID %>';
                var ModalPopupDetalleControlConcurrencia='<%= ModalPopupDetalleControlConcurrencia.ClientID %>';
                var btnNuevaRemisionTemporal='<%= btnNuevaRemisionTemporal.ClientID %>';
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
                
function beginReq(sender, args) 
{

	var controlCaller=args.get_postBackElement().id;


    if(controlCaller.indexOf('btnGuardarRecibo')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('btnAgregarPago')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('cmbDeudores')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('cmbClientes')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('cmbRecibosDisponibles')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('btnNuevaRemisionTemporal')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('btnCrearRemision')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('btnRefreshCmbDeudores')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('btnRemisionEnUso')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('gvResultadosConcurrencia')!=-1){
                        $find(ModalPopupCargando).show()
                        var ModalPopupDetalleControlConcurrencia = '<%= ModalPopupDetalleControlConcurrencia.ClientID%>';
                        $find(ModalPopupDetalleControlConcurrencia).hide();
    };
    disableReClick(controlCaller,'btnNuevaRemisionTemporal');
 }

function runScript(e) {
    if (e.keyCode == 13) {
        AplicarFocoAgregarPagoYEjecutar();
        return false;
    }
}
//Para utilizar esta función, control debe ser la propiedad ControlID del control en cuestión. 
function disableReClick(control,caller)
{
    controlToDisable=document.getElementById(control.toString()); 

    if(control.indexOf(caller)!=-1)
               {
                 controlToDisable.disabled=true;
               }
}

function endReq(sender, args)
{

   //var controlCaller=args.get_postBackElement().id;
	                        //  shows the Popup 
	                        $find(ModalPopupCargando).hide();
	                       // if(controlCaller.indexOf('btnNuevaRemisionTemporal')!=-1){$find(btnNuevaRemisionTemporal).disabled=false;};
} 



function ClearRecibos()
{
   var combo=document.getElementById('ctl00_Contentplaceholder1_cmbRecibosDisponibles');
   combo.options.length=0;

}

function HideConfirma2() 
{

var ModalPopupDetalle = '<%= ModalPopupDetalleCheques.ClientID%>';
                        $find(ModalPopupDetalle).hide();
}	    

function HideConfirma3() 
{

var ModalPopupProntoPago = '<%= ModalPopupProntoPago.ClientID%>';
                        $find(ModalPopupProntoPago).hide();
}	    

         
function HideModalRemisionesAbiertas() 
{

var ModalPopupDetalleControlConcurrencia = '<%= ModalPopupDetalleControlConcurrencia.ClientID%>';

                        $find(ModalPopupDetalleControlConcurrencia).hide();
                        return true;
}	    

getElementsByType = function(theType)
{
  var elementArray = [];

  if (typeof document.all != "undefined")
  {
    elementArray = document.all;
  }
  else
  {
    elementArray = document.getElementsByTagName("*");
  }

  var matchedArray = [];
  var pattern = new RegExp("(^| )" + theType + "( |$)");

  for (var i = 0; i < elementArray.length; i++)
  {
    if (pattern.test(elementArray[i].getAttribute("type")))
    {
      matchedArray[matchedArray.length] = elementArray[i];
    }
  }

  return matchedArray;
};

function AgregarEventoClickACheckBox()
{
    var input = getElementsByType("checkbox");
    var myCheck;
    var elementWithName;
    for ( var i = 0; i < input.length; i++ )
    {
           myCheck=document.getElementById(input[i].name);         
           elementWithName=myCheck.id;
           if (elementWithName.indexOf('chkAll')==-1)
           {
            agregarEvento(myCheck,'click',SumarImporteImputado(),false);
           }
   }
}

function CheckearFacturasPersistidas(objeto)
{

alert(objeto.id);
objeto.checked=true;
return true;

}

function AbrirPopUpLocalizarFactura()
{
  var url='http://' + document.location.host + '/Vistas/ViewLocalizarFactura.aspx';
           AbrirVentana3(url,'_blank',660,410);
}

function AbrirPopUpRecibosCargados()
{

    var panelGeneral=document.getElementById('ctl00_Contentplaceholder1_panelGeneralCuerpoPagina');
     if (panelGeneral.disabled==true)
     {

       return;
     }

      if(confirm("Editar un recibo implica eliminar los datos de ésta pantalla que aún no fueron guardados ¿Desea continuar?")) 
      { 
         var idRemision=document.getElementById('ctl00_Contentplaceholder1_lblRemisionEnUso');

            if (idRemision.firstChild.nodeValue=='') return;

            var url='http://' + document.location.host + '/Vistas/ViewPopUpRecibosCargados.aspx?NumeroRemision='+ idRemision.firstChild.nodeValue;
           AbrirVentana3(url,'_blank',710,250);
      }
      else
      {
        return;
      }    
   
}

function agregarEvento(elemento, nombre_evento, funcion, captura){   
    // para IE   
    if (elemento.attachEvent){   
        elemento.attachEvent('on' + nombre_evento, funcion);   
        return true;   
    }else   // para navegadores respetan Estándares DOM(Firefox,safari)   
        if (elemento.addEventListener){   
            elemento.addEventListener(nombre_evento, funcion, captura);   
            return true;   
        }else  
            return false;   
}  



function MostrarPanelCheque()
{
   var ModalProgress = '<%= ModalProgress.ClientID %>';
  var textBoxLectora;  
   textBoxLectora=document.getElementById('ctl00$Contentplaceholder1$txtInputLectora');
   if (textBoxLectora != null) {
       $find(ModalProgress).show();
       textBoxLectora.focus();
   }
}

function MostrarPanelObservaciones()
{

   var ModalCargaObservacion = '<%= ModalCargaObservacion.ClientID %>';
   
   $find(ModalCargaObservacion).show();
}


function llenarChequePredictivamente()
{

var textBoxCuit;  
   textBoxCuit=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtCuitEmisor');  
   __doPostBack('ctl00$Contentplaceholder1$TabContainer1$TabPanel2$txtCuitEmisor','');
}

function OcultarPanelCheque()
{

    var teclaIE = event.keyCode;
	var teclaReal = String.fromCharCode(teclaIE);

    if (teclaIE==27)
        {

            var ModalProgress = '<%= ModalProgress.ClientID %>';
         
           $find(ModalProgress).hide();
           DesactivarLectora();
        }  
    return true;
}

function onBlurTextBox()
{
__doPostBack('ctl00$Contentplaceholder1$TabContainer1$TabPanel2$txtCuitEmisor','1');
return true;
}
function DesactivarLectora(valor)
{
   var textBoxCuit;  
   textBoxCuit=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtCuitEmisor');  
   //textBoxBanco.removeAttribute('onfocus',true);
   textBoxCuit.setAttribute('onfocus','EstaFuncionNoExiste()');
   
   //textBoxCuit.value=valor;
  //__doPostBack('btnCancelarEditarPago','1');
  
   return true;
}

function AgregarObservacionAGrilla()
{

     var ModalCargaObservacion = '<%= ModalCargaObservacion.ClientID %>';
                                        
     $find(ModalCargaObservacion).hide();
        
     return true;
}
         
function VerificarConfirmacionNuevaRemision()
{

     var ModalPopupConfirmaNuevaRemision = '<%= ModalPopupConfirmaNuevaRemision.ClientID %>';
                                        
     $find(ModalPopupConfirmaNuevaRemision).show();
        
     return true;
}

function CancelarCrearNuevaRemision()
{
     var ModalPopupConfirmaNuevaRemision = '<%= ModalPopupConfirmaNuevaRemision.ClientID %>';
     $find(ModalPopupConfirmaNuevaRemision).hide();
     return true;
}

function LimpiarCampoTipoDeCambio()
{
    var txtCambio = document.getElementById('ctl00_Contentplaceholder1_txtCambio');      
    var chkMoneda = document.getElementById('chkPesificar');     
    if (chkMoneda.checked) 
    {
      txtCambio.value="";             
    }
    else
    {
      txtCambio.value="1.0000";             
    }
}

function ValidarProntoPagoSeleccionado()
{

    txtImporteProntoPago=document.getElementById('ctl00_Contentplaceholder1_txtImporteProntoPago');
    if (txtImporteProntoPago!='')
    { 
      __doPostBack('ctl00_Contentplaceholder1_btnAplicarProntoPago','1');
     
    }
    else
    {
     alert('Por favor ingrese un descuento a aplicar.');
    }
}

function ValidarDatosDelRecibo()                
{

  if (Page_ClientValidate('reciboGroup')==false) 
                    return;
  var txtPagos;  
  var idRemision=document.getElementById('ctl00_Contentplaceholder1_lblRemisionEnUso').innerHTML;
  txtPagos=document.getElementById('ctl00_Contentplaceholder1_txtPagos');  
  btnGuardarRecibo=document.getElementById('<%=this.btnGuardarRecibo.ClientID %>');
  txtSumaFacturas=document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturas');
  txtRecibo=document.getElementById('ctl00_Contentplaceholder1_txtRecibo');
  txtImporteTotalDelRecibo=document.getElementById('<%=this.txtImporteTotalDelRecibo.ClientID %>');
  pagos=txtPagos.value;
  facturas=txtSumaFacturas.value;
           
           if (txtRecibo.value==''){
           alert('Por favor seleccione un recibo.');
            return false;
           }   
           if (parseFloat(pagos)==0){
           
           alert('Ingrese por favor algun pago.');
           return false;
           } 
           if (idRemision=='')
           {
            alert('Debe crear la remisión antes de guardar el recibo.');
            return false;
           }
          
  if (parseFloat(pagos)!=parseFloat(txtImporteTotalDelRecibo.value))
  {
   alert('El importe total cargado para el recibo no coincide con los pagos cargados.');
   return false;
  }
           
  if (parseFloat(pagos)<parseFloat(facturas))
  {
  alert('Las facturas a cancelar imputan un valor mayor a los pagos cargados. Quite facturas o agregue pagos.');
  return false;
  
  }else
  {
   return true;
  }
  
  if (parseFloat(pagos)!=parseFloat(facturas))
  {
      res=confirm('No coinciden las imputaciones con los pagos realizados. ¿Desea continuar?');
      if (res==true) return true;
      else return false;
  }
    
}

function VerificarEliminar()
{
     if(confirm("¿Desea eliminar el recibo cargado temporalmente?")) 
        return true;
       else
        return false;
         
}


function OnClick_btnAgregarPago()
{
      
    var tabSeleccionado=$find('<%=TabContainer1.ClientID%>').get_activeTabIndex();

    var idRemision=document.getElementById('ctl00_Contentplaceholder1_lblRemisionEnUso').innerHTML;
    if (idRemision=='')
    {
     alert('Debe crear la remisión antes de cargar algún pago.');
     return false;
    }  
    var cheque=new Cheque();

    cheque.AsignarControlToObject(tabSeleccionado);
    try
    {
      FocusInFirstControle();
    }
    catch(Error)
    {

    }
}

function FocusInFirstControle()
{
try
{
 var tabSeleccionado=$find('<%=TabContainer1.ClientID%>').get_activeTabIndex();

 switch (tabSeleccionado)
    {

         case 0:
               var importe=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtImporte');      
               importe.focus();
         break;
         case 1:
               var ddlRetenciones=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_cmbRetenciones');
               ddlRetenciones.focus();
         break;
         case 2:
               var txtImporteEfectivo=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel3_txtImporteEfectivo');
               txtImporteEfectivo.focus();
         break;
         case 3:
               var ddlCuenta=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel4_cmbCuentasClientes');
               ddlCuenta.focus();
               
         break;
         case 4:
               var ddlCuentaCredito=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel5_cmbCuentaCredito');
               ddlCuentaCredito.focus();
         break;
         case 5:
               var ddlTipoPago=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel6_cmbTipoPagoRaro');
               ddlTipoPago.focus();
         break;
         case 6:
               var ddlConcepto=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel7_cmbDescuentos');
               ddlConcepto.focus();
         break;
   }
 }
 catch(miError)
 {

 } 
}


function SetActiveTab(tabControl,tabNumber)
{
   var ctrl=$find(tabControl);
   ctrl.set_activeTab(ctrl.get_tabs()[tabNumber]);

}

function GenerarPdf()
{
    var panelGeneral=document.getElementById('ctl00_Contentplaceholder1_panelGeneralCuerpoPagina');
     if (panelGeneral.disabled==true)
     {
       return;
     }
 
    var idRemision=document.getElementById('ctl00_Contentplaceholder1_lblRemisionEnUso');

    if (idRemision.firstChild.nodeValue=='') return;

    var url='http://' + document.location.host + '/Vistas/ViewGeneracionPdf.aspx?idRemision='+ idRemision.firstChild.nodeValue;
   AbrirVentana3(url,'_blank',500,500);
}

function GenerarPdfDeCierreDeRemision(idRemision)
{

          if(confirm("La remisión número " + idRemision + " se ha creado con éxito. ¿Desea ver los detalles de la remisión cargada en pdf?")) 
          { 
            var url='http://' + document.location.host + '/Vistas/ViewGeneracionPdf.aspx?idRemision='+ idRemision;
           AbrirVentana3(url,'_blank',500,500);
            return true;
          }
          else
          {
            return true;
          }
}

function ConfirmacionNuevaAccion(operacion)
{
      if (operacion=='remisionenuso')
      {
          if(confirm("Esta operación inicializará la pantalla eliminando aquellos datos que no hayan sido guardados. ¿Desea continuar?")) 
          { 
            return true;
          }
          else
          {
            return false;
          }
      
      }
      else
      {
          var control=document.getElementById('ctl00_Contentplaceholder1_btnNuevaRemisionTemporal');
          
          if (control.value!='Crear Remision')
          {
               if(confirm("Esta operación inicializará la pantalla eliminando aquellos datos que no hayan sido guardados. ¿Desea continuar?")) 
                  { 
                    return true;
                  }
                  else
                  {
                    return false;
                  }
          }
      }   

}



function ConfirmacionCierreDeRemision()
{
          if(confirm('¿Está seguro que desea cerrar la remisión definitivamente? (Esta acción no se puede deshacer)')) 
               return true;
          else
            return false;
}

    </script>

    <script type="text/javascript">
    
    
<!--
var $j=jQuery.noConflict();
$j(document).ready(function()
{

setTimeout(updateSession, 1000*60);//Timeout is 1 min

	var options = {minWidth: 120, arrowSrc: '/UIControls/MenuJQuery/Menu/arrow_right.gif', copyClassAttr: true, onClick: function(e, menuItem){
	    //openMenu(
	    document.location='http://localhost/vistas/ViewImportacionDeFacturas.aspx';
	   
	    //);
		//alert('you clicked item "' + $(this).text() + e  + '"');
	}};
	
});

 function updateSession() {
 //alert('updateSession');
 var pageUrl = '<%=ResolveUrl("~/SessionAlive.asmx")%>' + '/' + 'UpdateSession';
 //alert(pageUrl);
 
        $j.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: pageUrl ,
            data: "{}",
            dataType: "json"
        });
        setTimeout(updateSession, 1000 * 60);
    }

-->

    </script>

    <script language="javascript">




    </script>

    <%--          
                                                                         <asp:ImageButton ID="ibtnBloquearDeudor" runat="server" Height="27px" 
                                                                             ImageUrl="~/Images/ico_candado.jpg" onclick="ibtnBloquearDeudor_Click" 
                                                                             ToolTip="Bloquear Deudor" Width="28px" />--%>
    <asp:panel id="panelLectoraCheque" runat="server" cssclass="pdateProgressLectoraCheque">
        <table>
            <tr>
                <td>
                    <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                    Por favor introduzca el cheque en el dispositivo...
                    <asp:TextBox ID="txtInputLectora" runat="server" CssClass="textboxEditor" Height="16px"
                        Width="113px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:panel>
    <asp:panel id="panelConfirmaRemisionTemporal" runat="server">
            <table style="height: 60px; width: 210px;">
            <tr>
                <td valign="middle" width="20%;" style="background-color: #EDEBEB; border-style: none groove outset none;
                    border-bottom-color: #FFFFFF; border-right-color: #C0C0C0; border-width: thin 2px 2px 1px;
                    border-spacing: 2px; border-collapse: collapse" align="center">
                    <asp:Label ID="lblNuevaRemisionTitle" runat="server" Style="font-family: Verdana; font-size: 10px;
                        font-weight: bold;" Text="¿Desea crear una nueva remisión? ">
                    </asp:Label>
                    <br />
                    <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnNuevaRemision" runat="server" Text="    Sí    " CssClass="button_back3" onclick="btnNuevaRemision_Click"/> 
                        </td>
                        <td>
                            <asp:Button ID="btnCancelarNuevaRemision" runat="server" Text="    No    " CssClass="button_back3"  OnClientClick="javascript:CancelarCrearNuevaRemision();"/>     
                        </td>
                    </tr>
                    
                    
                    
                    </table>
                </td>
                </tr>
                     
        </table>
    </asp:panel>
    <asp:panel id="panelCargaObservacion" runat="server" cssclass="updateProgress">
        <table style="height: 68px; width: 417px;">
            <tr>
                <td valign="middle" width="20%;" style="background-color: #EDEBEB; border-style: none groove outset none;
                    border-bottom-color: #FFFFFF; border-right-color: #C0C0C0; border-width: thin 2px 2px 1px;
                    border-spacing: 2px; border-collapse: collapse">
                    <asp:Label ID="lblObservacionPopUp" runat="server" Style="font-family: Verdana; font-size: 10px;
                        font-weight: bold;" Text="Observación: ">
                    </asp:Label>
                </td>
                <td style="background-color: #EDEBEB; border-style: none groove outset none; border-bottom-color: #FFFFFF;
                    border-right-color: #C0C0C0; border-width: thin 2px 2px 1px; border-spacing: 2px;
                    border-collapse: collapse">
                    <asp:TextBox ID="txtCargarObservacion" runat="server" CssClass="textboxEditor" Height="22px"
                        Width="270px"></asp:TextBox>
                    &nbsp;
                    <asp:ImageButton ID="imgBtnAgregarObservacion" runat="server" ImageUrl="~/Images/correcto.gif"
                        CausesValidation="False" OnClientClick="javascript:AgregarObservacionAGrilla();" />
                </td>
            </tr>
        </table>
    </asp:panel>
    <asp:panel id="panelProntoPago" runat="server">
        <asp:UpdatePanel ID="UpdatePanelProntoPago" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <table style="height: 200px; width: 590px;">
                    <tr>
                        <td style="background-color: #EDEBEB; border-style: none groove outset none; border-bottom-color: #FFFFFF;
                            border-right-color: #C0C0C0; border-width: thin 2px 2px 1px; 
                            border-collapse: collapse"  height="100px" align="center">
                            DESCUENTOS DISPONIBLES
                            <br />
                            <br />
                            <asp:Panel ID="PanelPronto" runat="server" CssClass="scrollbar" ScrollBars="Vertical"
                                Width="100%" Height="165px">
                                                       
                                <ma:XGridView ID="gvProntoPago" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                    DataKeyNames="id" EmptyDataText="No se encontraron resultados" ExecutePageIndexChanging="False"
                                    Width="90%" OnSelectedIndexChanging="gvProntoPago_SelectedIndexChanging">
                                    <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                    
                                    <Columns>
                                   
                                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" ItemStyle-Width="10">
                                            <HeaderStyle Font-Bold="True" />
                                             <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nombreCliente" HeaderText="Cliente" SortExpression="nombreCliente" ItemStyle-Width="30">
                                            <HeaderStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nombreDeudor" HeaderText="Deudor" SortExpression="nombreDeudor" ItemStyle-Width="50">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fechaLimiteDescuento" HeaderText="Hasta el" SortExpression="fechaLimiteDescuento"
                                            DataFormatString="{0:d/MM/yyyy}" ItemStyle-Width="15">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PorcentajeAplicacion" HeaderText="Porcentaje(%)" SortExpression="PorcentajeAplicacion"
                                            ItemStyle-Width="10">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:CommandField ButtonType="Image" ShowHeader="True" ShowSelectButton="True" HeaderText="Selección"
                                             SelectText="Aplicar" ItemStyle-Width="5" SelectImageUrl="~/Images/correcto.gif">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        No se hallaron resultados.
                                    </EmptyDataTemplate>
                                    <FooterStyle CssClass="gvHeader grayGvHeader" />
                                    <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" Height="10"/>
                                    <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                    <RowStyle CssClass="gvItem"/>
                                </ma:XGridView>
                            </asp:Panel>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="White">
                            <table width="100%">
                                <tr>
                                    <td align="right" valign="top">
                                        <asp:Label ID="lblVencimientoFact" runat="server" Style="font-family: Verdana; font-size: 10px;
                                            font-weight: bold;" Text="Vencimiento Factura: "> </asp:Label>
                                        <asp:Label ID="lblVencimientoFactRes" runat="server" Style="font-family: Verdana;
                                            font-size: 10px; font-weight: bold;" Text=""> </asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:label ID="lblImporteActual" runat="server" Style="font-family: Verdana;
                                            font-size: 10px; font-weight: bold;" Text="Importe Factura: " EnableViewState="false"> </asp:Label>
                                           
                                                                        
                                        &nbsp;&nbsp;<asp:TextBox ID="txtImporteActual" runat="server" CssClass="textboxEditor"
                                            Height="16px" Width="113px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td align="rigth" valign="top">
                                        &nbsp; &nbsp;
                                        <asp:Label ID="lblImporteProntoPago" runat="server" Style="font-family: Verdana;
                                            font-size: 10px; font-weight: bold;" Text="Importe Pronto Pago: "> </asp:Label>
                                        &nbsp;&nbsp;<asp:TextBox ID="txtImporteProntoPago" runat="server" CssClass="textboxEditor"
                                            Height="16px" Width="113px" ReadOnly="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Seleccione un porcentaje."
                                            ControlToValidate="txtImporteProntoPago" ValidationGroup="ppGroup"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="White">
                            <table width="75%">
                                <tr>
                                    <td width="30%">
                                        <ma:SecureButton ID="btnAplicarProntoPago" runat="server" CssClass="button_back"
                                            Height="20px" TabIndex="1" Text="Aplicar" Width="95px" CausesValidation="True"
                                            ValidationGroup="ppGroup" OnClick="btnAplicarProntoPago_OnClick" />
                                    </td>
                                    <td width="30%">
                                        <ma:SecureButton ID="btnQuitarProntoPago" runat="server" CssClass="button_back" Height="20px"
                                            TabIndex="2" Text="Quitar Pronto Pago" Width="116px" OnClick="btnQuitarProntoPago_OnClick" />
                                    </td>
                                    <td>
                                        <input id="Button1" class="button_back" onclick="javascript:HideConfirma3();" type="button"
                                            value="Cancelar" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
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
    <asp:panel id="pnlDetalleCheques" runat="server">
        <asp:UpdatePanel ID="pnlNuevoDeudorAjax" runat="server">
            <ContentTemplate>
                <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                    font-size: 16px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 20px; width: 420px;
                    text-align: center;">
                    <table>
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label4" runat="server" Text="   Preliminar De Cheques Cargados" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 350px; width: 399px; background-color: #ffffff; border-right: #cccccc 2px solid;
                    border-bottom: #cccccc 1px inset; text-align: center;">
                    <br />
                    <asp:Panel ID="Panel2" runat="server" CssClass="scrollbar" Height="346px" Width="416px"
                        ScrollBars="Vertical">
                        <ma:XGridView ID="gvResultadosCheques" runat="server" AutoGenerateColumns="False"
                            BorderWidth="0px" DataKeyNames="numero" EmptyDataText="No se encontraron resultados"
                            ExecutePageIndexChanging="False" Width="358px">
                            <AlternatingRowStyle CssClass="gvAlternatingItem" />
                            <Columns>
                                <asp:BoundField DataField="numero" HeaderText="numero" SortExpression="numero">
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="importe" HeaderText="Importe" SortExpression="importe">
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="vencimiento" HeaderText="Vencimiento" 
                                    SortExpression="vencimiento" DataFormatString="{0:d/MM/yyyy}">
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="emision" HeaderText="Fecha Emision" 
                                    SortExpression="emision" DataFormatString="{0:d/MM/yyyy}">
                                </asp:BoundField>
                                <asp:BoundField DataField="banco" HeaderText="Banco" SortExpression="banco" />
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
                                    type="button" value="Cancelar" />
                                    
                                     
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:panel>
    <asp:panel id="panelRemisionesAbiertas" runat="server">
        <asp:UpdatePanel ID="updatePanelRemisionesAbiertas" runat="server" >
            <ContentTemplate>
                <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                    font-size: 16px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                    border-bottom: #cccccc 1px inset; text-align: left; height: 20px; width: 400px;
                    text-align: center;">
                    <table>
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label5" runat="server" Text="Remisiones Abiertas" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 320px; width: 400px; background-color: #ffffff; border-right: #cccccc 2px solid;
                    border-bottom: #cccccc 1px inset; text-align: center;">
                    <br />
                    <asp:Panel ID="Panel4" runat="server" CssClass="scrollbar" Height="300px" Width="400px"
                        ScrollBars="Vertical">
                        <ma:XGridView ID="gvResultadosConcurrencia" runat="server" AutoGenerateColumns="False"
                            BorderWidth="0px" DataKeyNames="NumeroRemision" EmptyDataText="No se encontraron resultados"
                            ExecutePageIndexChanging="False" Width="358px" 
                            onselectedindexchanged="gvResultadosConcurrencia_SelectedIndexChanged">
                            <AlternatingRowStyle CssClass="gvAlternatingItem" />
                            <Columns>
                                <asp:CommandField ButtonType="Button" SelectText="Seleccionar" 
                                    ShowCancelButton="False" ShowSelectButton="True" />
                                <asp:BoundField DataField="NumeroRemision" HeaderText="Numero Remisión" 
                                    SortExpression="NumeroRemision">
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaDeCreacion" HeaderText="Fecha de Creación" 
                                    SortExpression="FechaDeCreacion" DataFormatString="{0:d/MM/yyyy}">
                                </asp:BoundField>
                                <asp:BoundField DataField="AnalistaGeneradorName" HeaderText="Analista Creador" 
                                    SortExpression="AnalistaGeneradorName">
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" 
                                    SortExpression="Estado">
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IDCliente" HeaderText="ID Cliente" 
                                    SortExpression="IDCliente" />
                                     <asp:BoundField DataField="Cliente" HeaderText="Cliente" 
                                    SortExpression="Cliente" />
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
                                <%--<input id="Button2" class="button_back"  onclick ="javascript:HideModalRemisionesAbiertas();"
                                    type="button" value="Cancelar" />--%>
                                    <asp:Button ID="btnCerrarModalRemisionesAbiertas" runat="server" Text="Cancelar" CssClass="button_back3" OnClick="btnCerrarModalRemisionesAbiertas_Click"/>     
                               
                            </td>
                            
                        </tr>
                    </table>
                </div>
                 </ContentTemplate>
        </asp:UpdatePanel>
    </asp:panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupDetalleCheques" runat="server" TargetControlID="fielHidden"
        BackgroundCssClass="modalBackground" PopupControlID="pnlDetalleCheques" />
    <asp:hiddenfield id="fielHidden" runat="server" />
    <asp:hiddenfield id="hdPostbackControl" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupConfirmaNuevaRemision" runat="server"
        TargetControlID="fieldHiddenPanelConfirmaNuevaRemision" BackgroundCssClass="modalBackground"
        PopupControlID="panelConfirmaRemisionTemporal" />
    <asp:hiddenfield id="fieldHiddenPanelConfirmaNuevaRemision" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupCargando" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
    <ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelLectoraCheque"
        BackgroundCssClass="modalBackground" PopupControlID="panelLectoraCheque" />
    <ajaxToolkit:ModalPopupExtender ID="ModalCargaObservacion" runat="server" TargetControlID="panelCargaObservacion"
        BackgroundCssClass="modalBackground" PopupControlID="panelCargaObservacion" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupProntoPago" runat="server" TargetControlID="HiddenFieldProntoPago"
        BackgroundCssClass="modalBackground" PopupControlID="panelProntoPago" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupDetalleControlConcurrencia" runat="server"
        TargetControlID="HiddenFieldRemisionesAbiertas" BackgroundCssClass="modalBackground"
        PopupControlID="panelRemisionesAbiertas" />
    <asp:hiddenfield id="HiddenFieldProntoPago" runat="server" />
    <asp:hiddenfield id="HiddenFieldRemisionesAbiertas" runat="server" />
    <asp:hiddenfield id="HiddenFieldPagosCargados" runat="server" value="" />
    <asp:hiddenfield id="HiddenFieldUltimoPagoCargado" runat="server" value="" />
    <asp:hiddenfield id="HiddenFieldEstadoGrillaFacturas" runat="server" value="" />
    <table align="center" style="height: 557px; width: 750px;">
        <tr style="height: 200px;">
            <td valign="top">
                <table style="width: 750px; height: 88%;" class="borderCompleto" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td width="100%;" class="fondo_Titulo" align="left" style="height: 34px">
                            <table>
                                <tr>
                                    <td width="100%;" align="left" style="height: 34px">
                                        <asp:updatepanel runat="server" id="updatePanelRemisionEnUso" updatemode="Conditional">
                                <ContentTemplate>
                                            Remisión de Valores N°: <asp:Label ID="lblRemisionEnUso" runat="server" Text=""></asp:Label>
                            </ContentTemplate>
                            </asp:updatepanel>
                                        <asp:panel runat="server" id="panelCliente0">
                                <br />
                            </asp:panel>
                                    </td>
                                    <td width="100%;" align="right" style="height: 34px" valign="middle">
                                        <asp:label id="lblTipoRemision" runat="server" text="Nueva"></asp:label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="center">
                            <asp:updatepanel runat="server" id="UpdatePanelIndice" updatemode="Conditional">
                                <ContentTemplate>
                                    <table style="width: 80%; height: 400px;">
                                        <tr>
                                            <td valign="top" style="background-color: #EDEBEB; border-style: none groove outset none;
                                                border-bottom-color: #FFFFFF; border-right-color: #C0C0C0; border-width: thin 2px 2px 1px;
                                                border-spacing: 2px; border-collapse: collapse" class="style5">
                                                <table style="width: 100%">
                                                    
                                                    <tr>
                                                       <td valign="top">
                                                           <asp:Label ID="Label3" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                font-weight: bold;" Text="Crear Remisión: " EnableViewState="False"></asp:Label>
                                                            
                                                           <table width="100%">
                                                               
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblClientes" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                font-weight: bold;" Text="Cliente: " EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:DropDownList ID="cmbClientes" runat="server" AutoCompleteMode="SuggestAppend"
                                                                AutoPostBack="True" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid"
                                                                BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="10px"
                                                                Height="20px" MaxLength="0" OnSelectedIndexChanged="cmbClientes_SelectedIndexChanged" Width="100px" 
                                                                >
                                                            </asp:DropDownList>
                                                            
                                                             
                                                             
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                                                 
                                                                 <a style="font-family: Verdana; font-size: 10px; font-weight: bold;">Deudor: </a>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:DropDownList ID="cmbDeudores" runat="server" AutoCompleteMode="SuggestAppend"
                                                                AutoPostBack="True" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid"
                                                                BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="10px"
                                                                Height="20px" MaxLength="0" OnDataBound="cmbDeudores_DataBound" OnSelectedIndexChanged="cmbDeudores_SelectedIndexChanged" Width="100px" 
                                                                 >
                                                            </asp:DropDownList>
                       
                                                            <asp:ImageButton ID="btnRefreshCmbDeudores" runat="server"  
                                                                ImageUrl="~/Images/Reasignar.gif" onclick="btnRefreshCmbDeudores_Click" 
                                                                TabIndex="100"/>
                                                                                                                              
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td>
                                                                                 
                                                                 <a style="font-family: Verdana; font-size: 10px; font-weight: bold;">Recibo: </a>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                          <asp:UpdatePanel runat="server" ID="updateRecibosDisponibles" UpdateMode="Conditional" >
                                                            <ContentTemplate>
                                                            <!--
                                                            <asp:DropDownList ID="cmbRecibosDisponiblesX" runat="server" AutoCompleteMode="SuggestAppend"
                                                                AutoPostBack="True" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid"
                                                                BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="10px"
                                                                Height="20px" MaxLength="0" OnDataBound="cmbRecibosDisponibles_DataBound" OnTextChanged="cmbRecibosDisponibles_TextChanged" Width="100px">
                                                            </asp:DropDownList>
                                                            -->
                                                             <ajaxToolkit:ComboBox ID="cmbRecibosDisponibles" runat="server" AutoCompleteMode="SuggestAppend" AutoPostBack="true"
                                                              BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="10px" Height="15px"
                                                                MaxLength="0" Width="150px" OnDataBound="cmbRecibosDisponibles_DataBound" OnTextChanged="cmbRecibosDisponibles_TextChanged" >
                                                            </ajaxToolkit:ComboBox>
                                                            
                                                            </ContentTemplate> 
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                       <td>
                                                          <table style="width: 127px">
                                                                 <tr>
                                                                     <td>
                                                                                                                                                                                                              
                                                                    
                                                                        <br />
                                                                         <asp:Label ID="lblSelDeu" runat="server" ForeColor="#FF0000" Style="font-family: Verdana;
                                                                         font-size: 9px;"></asp:Label>
                                                                                
                                                                      <%--          
                                                                         <asp:ImageButton ID="ibtnBloquearDeudor" runat="server" Height="27px" 
                                                                             ImageUrl="~/Images/ico_candado.jpg" onclick="ibtnBloquearDeudor_Click" 
                                                                             ToolTip="Bloquear Deudor" Width="28px" />--%>
                                                                     </td>
                                                                     
                                           <%--                          <asp:ImageButton ID="ibtnDesbloquearDeudor" runat="server" Height="26px" 
                                                                              ImageUrl="~/Images/icono_pq_candado.png" onclick="ibtnDesbloquearDeudor_Click" 
                                                                              ToolTip="Desbloquear Deudor" Width="23px" />--%>
                                                                   
                                                                 </tr>
                                                                
                                                          </table>
                                                       
                                                       </td>
                                                    
                                                    </tr>
                                                               <tr>
                                                                     <td align="center">
                                                                    
                                                                     <br />
                                                                         <asp:Button ID="btnNuevaRemisionTemporal" runat="server" Text="Crear Remision"  OnClientClick="return ConfirmacionNuevaAccion('nuevaoperacion');" 
                                                                             CssClass="button_back3" CommandName="cmdCrearRemision" 
                                                                             CommandArgument="CREAR" oncommand="btnNuevaRemisionTemporal_Command" Width="130px"  />
                                                                     
                                                                     </td>
                     
                                                               </tr>
                                                               <tr>
                                                                   <td>
                                                                      <br />
                                                                   </td>
                                                               </tr>
                                                
                                                               <tr>
                                                        <td>
                                                        
                                                       <%-- <asp:Label ID="lblRemisionEnUsoTitle" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                font-weight: bold;" Text="Remisión en uso: "></asp:Label>
                                                            <br />--%>
                                                            <tr>
                                                                <td align="center" style="text-align:center;">
                                                                                         <asp:Button ID="btnRemisionEnUso" runat="server" Text="Remisiones en Uso"  
                                                                                             CssClass="button_back3" OnClientClick="return ConfirmacionNuevaAccion('remisionenuso');" onclick="btnRemisionEnUso_Click" Width="130px"/>           
                                                                </td>
                                                            </tr>
                                                           
                                                            
                                                             
                                                               
                                                            
                                                        </td>
                                                    </tr>
                                                               </table>
                                                           
                                                           <br />
                                                           
                                                       </td>
                                                    </tr>

                                                    <tr>
                                                       <td>
                                                           <%-- <asp:Panel ID="Panel1" runat="server" Height="323px">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label1" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                                font-weight: bold;" Text="Recibos Cargados Recientemente: " EnableViewState="False"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ListBox ID="lstRecibosCargados" runat="server" CssClass="textboxEditor" 
                                                                                    Height="90px" OnTextChanged="lstRecibosCargados_TextChanged" Width="185px">
                                                                                </asp:ListBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">--%>
                                                                               <%-- <asp:ImageButton ID="btnEliminarRecibo" runat="server" 
                                                                                    ImageUrl="~/Images/delete.gif" onclick="btnEliminarRecibo_Click" 
                                                                                    OnClientClick="return VerificarEliminar();" />
                                                                                &nbsp;
                                                                                <asp:Label ID="lblEliminar" runat="server" 
                                                                                    Style="font-family: Verdana; font-size: 9px;" 
                                                                                    Text="Eliminar Recibo Seleccionado" EnableViewState="False"></asp:Label>--%>
<%--                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                               
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>--%>
                                                                                <%--<ma:XGridView ID="gvResultadosRemisiones" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                BorderWidth="0px" DataKeyNames="Orden" EmptyDataText="Busque remisiones..." ExecutePageIndexChanging="True"
                                                                                OnPreRender="gvResultadosPagos_PreRender" OnRowDeleted="gvResultadosPagos_RowDeleted"
                                                                                OnRowDeleting="gvResultadosPagos_RowDeleting" OnRowEditing="gvResultadosPagos_RowEditing"
                                                                                OnSelectedIndexChanged="gvResultadosPagos_SelectedIndexChanged" OnSelectedIndexChanging="gvResultadosPagos_SelectedIndexChanging"
                                                                                Width="111px">
                                                                                <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="NumRemision" HeaderText="N° Remision" />
                                                                                    <asp:BoundField DataField="FechaCreacion" HeaderText="Creación">
                                                                                        <HeaderStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:CommandField DeleteText="Eliminar" HeaderText="Eliminar" InsertText="juaua"
                                                                                        ShowCancelButton="False" ShowDeleteButton="True" />
                                                                                    <asp:CommandField CausesValidation="False" EditText="Editar" HeaderText="Editar"
                                                                                        ShowEditButton="True" ShowHeader="True" />
                                                                                </Columns>
                                                                                <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                                <EmptyDataTemplate>
                                                                                    Agregue pagos...
                                                                                </EmptyDataTemplate>
                                                                                <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                                                <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                                <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                                <RowStyle CssClass="gvItem" />
                                                                            </ma:XGridView>--%>
                                                                         <%--   </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>--%>
                                                                
                                                                
                                                                <a href="javascript:AbrirPopUpRecibosCargados();" style="font-family: Verdana; font-size: 9px;">Recibos cargados</a>
                                                                <br />
                                                                <br />
                                                                <a href="javascript:AbrirPopUpLocalizarFactura();" style="font-family: Verdana; font-size: 9px;">Localizar Factura</a>
                                                       
                                                       
                                                       
                                                       </td>
                                                    </tr>
                                                    
                                                    
                                                </table>
                                            </td>
                                            <td valign="top"  style="background-color: #EDEBEB; border-style: none groove outset none;
                                                border-bottom-color: #FFFFFF; border-right-color: #C0C0C0; border-width: thin 2px 2px 1px;
                                                border-spacing: 2px; border-collapse: collapse" align="left">
                                                <%--<asp:Panel ID="panelGeneralCuerpoPagina" runat="server" Width="550px">--%>
                                                <asp:Panel ID="panelGeneralCuerpoPagina" runat="server" >
                                                    <table width="95%">
                                                        <tr>
                                                            <td align="left">
                                                            <table width="100%">
                                                              <tr>
                                                              
                                                              <td valign="top" style="width:200px;">
                                                              
                                                           
                                                              
                                                                    
                                                             <asp:UpdatePanel runat="server" ID="updatePanelTxtRecibo" UpdateMode="Conditional" >
                                                          
                                                                <ContentTemplate>
                                                                                                       
                                                                   <asp:Label ID="lblRecibo" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                    font-weight: bold;" Text="Recibo:"> </asp:Label>
                                                                <asp:TextBox ID="txtRecibo" runat="server" CssClass="textboxEditor" Height="16px"
                                                                    ValidationGroup="reciboGroup" Width="110px" MaxLength="13" Enabled="False"></asp:TextBox>
                                                                
               
                                                                <%--&nbsp;--%>
                                                                </ContentTemplate> 
                                                                </asp:UpdatePanel> 
                                                                
                                                                <asp:Label ID="lblFechaRecibo" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                    font-weight: bold;" Text="Fecha    :    "> </asp:Label>
                                                                <asp:TextBox ID="txtFechaRecibo" runat="server" CssClass="textboxEditor" Height="16px"
                                                                    TabIndex="300" ValidationGroup="reciboGroup" Width="111px"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                                    Format="dd/MM/yyyy" PopupButtonID="ImageButton1" TargetControlID="txtFechaRecibo">
                                                                </ajaxToolkit:CalendarExtender>
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaRecibo" runat="server"
                                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                    CultureTimePlaceholder="" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999"
                                                                    MaskType="Date" TargetControlID="txtFechaRecibo">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                                
                                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Calendar.png" />
                                                                
                                                                 <ajaxToolkit:MaskedEditValidator ID="mev3" runat="server" ControlExtender="MaskedEditExtenderFechaRecibo"
                                                                    ControlToValidate="txtFechaRecibo" Display="None" EmptyValueMessage="*"
                                                                    ErrorMessage="*" InvalidValueMessage="*" IsValidEmpty="False"
                                                                    ValidationGroup="reciboGroup" />
                                                             </td>
                                                             <td valign="top">
                                                                <table>
                                                                      <tr>
                                                                         <td>
                                                                             <asp:Label ID="lblCambio" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                                font-weight: bold;" Text="Cambio: ">
                                                                            </asp:Label>
                                                                         </td>
                                                                         <td>
                                                                           <asp:TextBox ID="txtCambio" runat="server" CssClass="textboxEditor" Height="16px"
                                                                            ValidationGroup="reciboGroup" MaxLength="7" Width="60px" Enabled="true" Text="1.0000"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCambio"
                                                                            ErrorMessage="*" ValidationGroup="reciboGroup"></asp:RequiredFieldValidator>
                                                                            
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCambio"
                                                                            ErrorMessage="*" ValidationExpression="^[0-9]{1,2}(\.[0-9]{1,4})|[0-9]{1,7}$"
                                                                            ValidationGroup="reciboGroup"></asp:RegularExpressionValidator>
                                                                         </td>
                                                                      </tr>
                                                                      <tr>
                                                                         <td>
                                                                             <asp:Label ID="lblTotalDelRecibo" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                                 font-weight: bold;" Text="Importe recibo:"> </asp:Label>
                                                                         </td>
                                                                         <td>
                                                                              <asp:TextBox ID="txtImporteTotalDelRecibo" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                ValidationGroup="reciboGroup" Width="60px" MaxLength="13" Text="0"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator09" runat="server" ControlToValidate="txtImporteTotalDelRecibo"
                                                                                    ErrorMessage="*" ValidationGroup="reciboGroup"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator09" runat="server" ControlToValidate="txtCambio"
                                                                                    ErrorMessage="*" ValidationExpression="^[0-9]{1,2}(\.[0-9]{1,4})|[0-9]{1,7}$"
                                                                                    ValidationGroup="reciboGroup"></asp:RegularExpressionValidator>
                                                                         </td>
                                                                      </tr>
                                                                </table>
                                                               
                                                              
                                                                    <br />
                                                                    
                                                               
                                                             </td>    
                                                             </tr>
                                                            </table>     
                                                                    
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblSAP" runat="server" Text="SAP" Style="font-family: Verdana; font-size: 10px;font-weight:bold;"></asp:Label>
                                                                <asp:TextBox ID="txtSAP" runat="server" CssClass="textboxEditor" Height="16px"
                                                                    Width="40px" MaxLength="6"></asp:TextBox>
                                                                &nbsp;                                                                
                                                                
                                                                <asp:Label ID="lblFacturaABuscar" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                    font-weight: bold;" Text="N° Factura: "> </asp:Label>
                                                                &nbsp;
                                                                <asp:TextBox ID="txtNumFactura" runat="server" CssClass="textboxEditor" Height="16px"
                                                                    Width="113px" ValidationGroup="facturasABuscarGroup"></asp:TextBox>
                                                                
                                                                &nbsp; &nbsp;
                                                                <asp:ImageButton ID="btnBuscarFactura" runat="server" CausesValidation="True" Height="16px"
                                                                    ImageUrl="~/Images/Ico12.gif" OnClick="btnBuscarFactura_Click" Width="23px" ValidationGroup="facturasABuscarGroup"/>
                                                                    <br />
                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtNumFactura" ValidationGroup="facturasABuscarGroup" ValidationExpression="^[0-9]{1,7}$" Enabled="false"></asp:RegularExpressionValidator>    
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator99" runat="server" ControlToValidate="txtNumFactura"
                                                                    ErrorMessage="*" ValidationGroup="facturasABuscarGroup"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                               <table>
                                                                     <tr>
                                                                                          <td class="fondo_Titulo" style="height: 23px">
                                                                                <table style="width: 100%">
                                                                                    <tr>
                                                                                        <td style="width: 100%; height: 30px;">
                                                                                            Pagos
                                                                                        </td>
                                  
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td class="fondo_Titulo" style="height: 23px">
                                                                                <table width="90%">
                                                                                    <tr>
                                                      
                                                                                        <td style="width: 100%; height: 30px;">
                                                                                            Documentos
                                                                                        </td>
                                               
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                     </tr>
                                                                      <tr>
                                                            <td align="left" valign="top">
                                                                <asp:UpdatePanel ID="UpdatePanelTabContainer" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table style="width: 340px; margin-right: 0px;">
                                                                            <tr>
                                                                                <td>
                                                                                    <ajaxToolkit:TabContainer runat="server" ID="TabContainer1" Height="337px" Width="310px"
                                                                                        ActiveTabIndex="0" AutoPostBack="false" 
                                                                                        TabStripPlacement="Top">
                                                                                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="Factura" Enabled="true"
                                                                                            Visible="true"><HeaderTemplate>Chq</HeaderTemplate><ContentTemplate>
                                                                                            
                                                                                            <table style="margin-top: 15px;">
                                                                                            <tr>
                                                                                              <td align="left" >
                                                                                                <asp:Label ID="lblImporte" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Importe"></asp:Label></td>
                                                                                               
                                                                                               <td align="left" style="width:195px;">
                                                                                                                <asp:TextBox ID="txtImporte" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="12" TabIndex="10" ValidationGroup="chequeGroup" Width="83px" onkeypress="return runScript(event)"></asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorImporte" runat="server" ControlToValidate="txtImporte"
                                                                                                                    ErrorMessage="*" ValidationGroup="chequeGroup"></asp:RequiredFieldValidator>
                                                                                                                <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtImporte" ValidationGroup="chequeGroup" ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,4})|[0-9]{1,7}$"></asp:RegularExpressionValidator>    
                                                                                                                
                                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                <td align="left"><asp:Label ID="lblCheque" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="N° Cheque" EnableViewState="False"></asp:Label></td>
                                                                                                                <td align="left" style="width:195px;"><asp:TextBox ID="txtCheque" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="8" TabIndex="11" ValidationGroup="chequeGroup" Width="83px" onkeypress="return runScript(event)" ></asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorCheque" runat="server" ControlToValidate="txtCheque"
                                                                                                                    ErrorMessage="*" ValidationGroup="chequeGroup"></asp:RequiredFieldValidator>
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtCheque" ValidationGroup="chequeGroup" ValidationExpression="^[0-9]{1,15}$"></asp:RegularExpressionValidator>
                                                                                                                    &#160;&#160; </td></tr>
                                                                                                                    <tr><td align="left" ><asp:Label ID="lblFechaEmision" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Fecha Emisión" EnableViewState="False"></asp:Label></td>
                                                                                                                <td align="left" style="width:195px;">
                                                                                                                <asp:TextBox ID="txtFechaEmision" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                ValidationGroup="chequeGroup" Width="83px" TabIndex="12" onkeypress="return runScript(event)"></asp:TextBox><ajaxToolkit:CalendarExtender
                                                                                                                    ID="txtFechaEmision_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                                                                    PopupButtonID="imgFecha3" TargetControlID="txtFechaEmision"></ajaxToolkit:CalendarExtender>
                                                                                                                    <asp:RegularExpressionValidator ControlToValidate="txtFechaEmision" runat="server" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ErrorMessage="*" ValidationGroup="chequeGroup"></asp:RegularExpressionValidator>
                                                                                                                      <asp:RequiredFieldValidator
                                                                                                                     runat="server" ControlToValidate="txtFechaEmision"
                                                                                                                    ErrorMessage="*" ValidationGroup="chequeGroup"></asp:RequiredFieldValidator>
                                                                                                                    <asp:ImageButton ID="imgFecha3" runat="server" ImageUrl="~/Images/Calendar.png" /></td>
                                                                                                                </tr>
                                                                                                 <tr>
                                                                                                 <td><asp:Label ID="lblFechaVenc" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Vencimiento" EnableViewState="False"></asp:Label></td>
                                                                                                                <td style="width:210px;" align="left"><asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                TabIndex="13" ValidationGroup="chequeGroup" Width="83px" onkeypress="return runScript(event)"></asp:TextBox>
                                                                                                                
                                                                                                                <ajaxToolkit:CalendarExtender
                                                                                                                    ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="imgFecha4"
                                                                                                                    TargetControlID="txtFechaVencimiento"></ajaxToolkit:CalendarExtender>
                                                                                                                    <asp:RegularExpressionValidator ControlToValidate="txtFechaVencimiento" runat="server" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ErrorMessage="*" ValidationGroup="chequeGroup"></asp:RegularExpressionValidator>
                                                                                                                    <asp:RequiredFieldValidator
                                                                                                                     runat="server" ControlToValidate="txtFechaVencimiento"
                                                                                                                    ErrorMessage="*" ValidationGroup="chequeGroup"></asp:RequiredFieldValidator>
                                                                                                                    
                                                                                                                    <asp:ImageButton ID="imgFecha4" runat="server" ImageUrl="~/Images/Calendar.png" /><asp:CheckBox ID="chkCP" runat="server" Text="Cheq Pago" AutoPostBack="True" 
                                                                                                                OnCheckedChanged="chkCP_CheckedChanged" 
                                                                                                                Style="font-family: Verdana; font-size: 9px;" />
                                                                                                                <asp:CompareValidator runat="server" ErrorMessage="Fecha de venc. inválida" ControlToCompare="txtFechaEmision" ControlToValidate="txtFechaVencimiento" Operator="GreaterThan" Type="Date"></asp:CompareValidator>
                                                                                                                
                                                                                                                </td></tr>
                                                                                                                
                                                                                                                <tr>
                                                                                                                <td align="left"><asp:Label ID="lblBanco" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Banco" EnableViewState="False"></asp:Label></td>
                                                                                                                <td align="left" style="width:195px;"><asp:TextBox ID="txtBanco" onkeypress="return runScript(event)" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                ValidationGroup="chequeGroup" Width="20px" MaxLength="20" TabIndex="14"></asp:TextBox>
                                                                                                                 <asp:DropDownList ID="cmbBanco" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                    AutoPostBack="True" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid"
                                                                                                                    BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="10px"
                                                                                                                    Height="20px" MaxLength="0" Width="130px" 
                                                                                                                        onselectedindexchanged="cmbBanco_SelectedIndexChanged" >
                                                                                                                
                                                                                                                    </asp:DropDownList>
                                                                                                                <asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorBanco" runat="server" ControlToValidate="txtBanco"
                                                                                                                    ValidationGroup="chequeGroup" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                                                                     <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtBanco" ValidationGroup="chequeGroup" ValidationExpression="^[0-9]{1,3}$"></asp:RegularExpressionValidator>
                                                                                                                    &#160;&#160; </td></tr>
                                                                                                                    <tr>
                                                                                                                    <td align="left"><asp:Label ID="lblSucursal" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Sucursal"></asp:Label></td>
                                                                                                                <td align="left" style="width:195px;"><asp:TextBox ID="txtSucursal" onkeypress="return runScript(event)" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="3" TabIndex="16" ValidationGroup="chequeGroup" Width="83px"></asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorSucursal" runat="server" ControlToValidate="txtSucursal"
                                                                                                                    ErrorMessage="*" ValidationGroup="chequeGroup"></asp:RequiredFieldValidator>
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtSucursal" ValidationGroup="chequeGroup" ValidationExpression="^[0-9]{1,15}$"></asp:RegularExpressionValidator>
                                                                                                                    </td></tr>
                                                                                                                    <tr>
                                                                                                                    <td align="left"><asp:Label ID="lblCuitEmisor" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Cuit" EnableViewState="False"></asp:Label></td>
                                                                                                                <td style="width:220px;" align="left">
                                                                                                                <asp:TextBox ID="txtCuitEmisor" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                Width="83px" MaxLength="13" AutoPostBack="False" TabIndex="17" IsValidEmpty="True" onkeypress="return runScript(event)"></asp:TextBox>
                                                                                                                <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtCuitEmisor" ValidationGroup="chequeGroup" ValidationExpression="^[0-9]{11}$" ></asp:RegularExpressionValidator>
                                                                                                                
                                                                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderCuit" runat="server"
                                                                                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                                                CultureTimePlaceholder="" ClearMaskOnLostFocus="true" Enabled="True" ErrorTooltipEnabled="True" Mask="99\-99999999\-9"
                                                                                                                MaskType="none" TargetControlID="txtCuitEmisor" ></ajaxToolkit:MaskedEditExtender>
                                                                                                                
                                                                                                                
                                                                                                                
                                                                                                               <asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorCuit" runat="server" ControlToValidate="txtCuitEmisor"
                                                                                                                    ErrorMessage="*" ValidationGroup="chequeGroup" Enabled="false"></asp:RequiredFieldValidator>
                                                                                                                &#160;&#160;<asp:LinkButton
                                                                                                                    ID="linkButtonCuit" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                    Width="80px" CausesValidation="False" OnClick="linkButtonCuit_Click">Cuit deudor</asp:LinkButton></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                    <td align="left"><asp:Label ID="lblCuenta" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Cuenta" EnableViewState="False"></asp:Label></td>
                                                                                                                <td align="left" style="width:160px;" ><asp:TextBox ID="txtCuenta" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                ValidationGroup="chequeGroup" Width="83px" MaxLength="20" TabIndex="18" onkeypress="return runScript(event)"></asp:TextBox>
                                                                                                                <%--<asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCuenta" ValidationGroup="chequeGroup"
                                                                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtCuenta" ValidationGroup="chequeGroup" ValidationExpression="^[0-9]{1,15}$"></asp:RegularExpressionValidator>
                                                                                                                    &#160;&#160; </td>
                                                                                                                    </tr>
                                                                                                                    <tr><td align="left"><asp:Label ID="lblCp" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Código Postal" EnableViewState="False"></asp:Label></td>
                                                                                                                <td align="left" style="width:160px;" ><asp:TextBox ID="txtCp" runat="server" CssClass="textboxEditor" Height="16px" ValidationGroup="chequeGroup"
                                                                                                                Width="83px" MaxLength="4" TabIndex="19" onkeypress="return runScript(event)"></asp:TextBox>
                                                                                                                <%--<asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorCp" runat="server" ControlToValidate="txtCp" ValidationGroup="chequeGroup"
                                                                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtCP" ValidationGroup="chequeGroup" ValidationExpression="^[A-Z0-9a-z]{1,10}$"></asp:RegularExpressionValidator>--%>
                                                                                                                    &#160;&#160; </td></tr><tr><td colspan="2">
                                                                                                                    
                                                                                                                    <table>
                                                                                                                    <tr>
                                                                                                                    <td align="right" style="width: 94%;">
                                                                                                                    <asp:Label ID="lblActivarLectora" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                            Text="Reactivar Lectora" EnableViewState="False"></asp:Label>
                                                                                                                            <asp:ImageButton ID="imgBtnLectora" runat="server" CausesValidation="False" Height="24px"
                                                                                                                            ImageUrl="~/Images/lectoraCheque.jpg" OnClick="imgBtnLectora_Click" OnClientClick="javascript:alert('La activación del dispositivo fué realizado con éxito.');"
                                                                                                                            Width="28px" Enabled="False"/>
                                                                                                                            </td>
                                                                                                                            <td style="width: 6%;">
                                                                                                                            </td></tr><tr>
                                                                                                                            <td align="right" ><asp:Label ID="lblChequesDetalle" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                            Text="Ver detalle cheques" EnableViewState="False"></asp:Label>
                                                                                                                            <asp:ImageButton ID="imgBtnCheques" runat="server" CausesValidation="False" Height="24px"
                                                                                                                            ImageUrl="~/Images/detalleCheques.jpg" OnClick="VerDetalleCheques" Width="18px" />
                                                                                                                            </td><td></td></tr></table>
                                                                                                                            
                                                                                                                            </td></tr></table>
                                                                                             
                                                                                             </ContentTemplate>
                                                                                             </ajaxToolkit:TabPanel>
                                                                                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="Retencion" Enabled="true"
                                                                                            Visible="true"><HeaderTemplate>Reten</HeaderTemplate><ContentTemplate><asp:UpdatePanel runat="server" ID="UpdatePanelSubtipoRetencion" UpdateMode="Conditional"><ContentTemplate><table style="margin-top: 15px;"><tr><td align="left"><asp:Label ID="lblSubtipoRetencion" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                        Text="Concepto"></asp:Label></td><td>
                                                                                                                        <asp:DropDownList ID="cmbRetenciones" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                        BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                        DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="16px"
                                                                                                                        MaxLength="0" Width="177px" OnSelectedIndexChanged="cmbRetenciones_SelectedIndexChanged" TabIndex="20"
                                                                                                                        AutoPostBack="True"><asp:ListItem>Retencion de Iva</asp:ListItem></asp:DropDownList></td></tr><tr><td align="left"><asp:Label ID="lblSubtipo" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                        Text="Subtipo"></asp:Label></td><td><asp:DropDownList ID="ddlSubTipo" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                        BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" TabIndex="21"
                                                                                                                        DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="16px"
                                                                                                                        MaxLength="0" Width="177px"><asp:ListItem>Retencion de Iva</asp:ListItem></asp:DropDownList></td></tr><tr><td><asp:Label ID="lblNumeroRetencion" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                        Text="N° Retencion"></asp:Label></td><td><asp:TextBox ID="txtNumeroRetencion" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                        MaxLength="8" ValidationGroup="retencionesGroup" Width="83px" TabIndex="22"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNumeroRetencion"
                                                                                                                        ErrorMessage="*" ValidationGroup="retencionesGroup"></asp:RequiredFieldValidator>
                                                                                                                       
                                                                                                                        
                                                                                                                        </td></tr><tr><td><asp:Label ID="lblImporteRetencion" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                        Text="Importe"></asp:Label></td><td><asp:TextBox ID="txtImporteRetencion" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                        Width="83px" MaxLength="15" ValidationGroup="retencionesGroup" TabIndex="23"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtImporteRetencion"
                                                                                                                            ErrorMessage="*" ValidationGroup="retencionesGroup"></asp:RequiredFieldValidator>
                                                                                                                            <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtImporteRetencion" ValidationGroup="retencionesGroup" ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,4})|[0-9]{1,7}$"></asp:RegularExpressionValidator>  
                                                                                                                            </td></tr><tr><td><asp:Label ID="lblFechaRetencion" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                        Text="Fecha Retención"></asp:Label></td><td>
                                                                                                                        
                                                                                                                        <asp:TextBox ID="txtFechaRetencion" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                        ValidationGroup="retencionesGroup" Width="83px" TabIndex="24" OnBlur="AplicarFocoAgregarPago()"></asp:TextBox>
                                                                                                                       
                                                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True"
                                                                                                                        Format="dd/MM/yyyy" PopupButtonID="ImageButtonRet" TargetControlID="txtFechaRetencion"></ajaxToolkit:CalendarExtender>
                                                                                                                        
                                                                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                                                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                                                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaRetencion"></ajaxToolkit:MaskedEditExtender>
                                                                                                                       
                                                                                                                        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator55" runat="server" ControlExtender="MaskedEditExtender2"
                                                                                                                ControlToValidate="txtFechaRetencion" Display="None" EmptyValueMessage="El campo Fecha no puede estar vacío"
                                                                                                                ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                                                                ValidationGroup="retencionesGroup" />                                                                                                                     
                                                                                                                                                         
                                                                                                                                                                                     
                                                                                                                       <asp:ImageButton ID="ImageButtonRet" runat="server" ImageUrl="~/Images/Calendar.png" />
                                                                                                                     <%--  <asp:RangeValidator ID="RangeValidatorMinFecha" runat="server" ErrorMessage="Fecha Inválida." ControlToValidate="txtFechaRetencion" ValidationGroup="retencionesGroup" ></asp:RangeValidator>                                                                                                                                                                                                --%>
                                                                                                               
                                                                                                                       </td></tr></table></ContentTemplate></asp:UpdatePanel></ContentTemplate></ajaxToolkit:TabPanel>
                                                                                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel3" HeaderText="Efectivo" Enabled="true"
                                                                                            Visible="true"><HeaderTemplate>Efec</HeaderTemplate><ContentTemplate><table style="margin-top: 15px;"><tr><td align="left"><asp:Label ID="lblImporteEfectivo" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Importe: "></asp:Label></td><td><asp:TextBox ID="txtImporteEfectivo" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                Width="83px" MaxLength="15" ValidationGroup="efectivosGroup" TabIndex="30"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                                                                                                    ValidationGroup="efectivosGroup" ControlToValidate="txtImporteEfectivo"></asp:RequiredFieldValidator>
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtImporteEfectivo" ValidationGroup="efectivosGroup" ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,4})|[0-9]{1,7}$"></asp:RegularExpressionValidator>  
                                                                                                                    </td></tr><tr><td><asp:Label ID="lblFechaPagoEfectivo" runat="server" Style="font-family: Verdana;
                                                                                                                font-size: 9px;" Text="Fecha Pago"></asp:Label></td><td><asp:TextBox ID="txtFechaPagoEfectivo" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                TabIndex="31" ValidationGroup="efectivosGroup" Width="83px"  OnBlur="AplicarFocoAgregarPago()"></asp:TextBox>
                                                                                                                
                                                                                                                
                                                                                                                
                                                                                                                <ajaxToolkit:CalendarExtender
                                                                                                                    ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="ImgFechaEfectivo"
                                                                                                                    TargetControlID="txtFechaPagoEfectivo"></ajaxToolkit:CalendarExtender>
                                                                                                                    
                                                                                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                                                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaPagoEfectivo"></ajaxToolkit:MaskedEditExtender>
                                                                                                                
                                                                                                                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidatorr4" runat="server" ControlExtender="MaskedEditExtender1"
                                                                                                                ControlToValidate="txtFechaPagoEfectivo" Display="None" EmptyValueMessage="El campo Fecha no puede estar vacío"
                                                                                                                ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                                                                ValidationGroup="efectivosGroup" /><asp:ImageButton ID="ImgFechaEfectivo" runat="server"
                                                                                                                    ImageUrl="~/Images/Calendar.png" />
                                                                                                                    
                                                                                                                    
                                                                                                                    
                                                                                                                    
                                                                                                                    </td></tr></table></ContentTemplate></ajaxToolkit:TabPanel>
                                                                                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel4" HeaderText="Deposito" Enabled="true"
                                                                                            Visible="true"><HeaderTemplate>Dep</HeaderTemplate><ContentTemplate><table style="margin-top: 15px;"><tr><td align="left"><asp:Label ID="lblCuentaDeudor" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Cuenta"></asp:Label></td><td><asp:DropDownList ID="cmbCuentasClientes" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="16px"
                                                                                                                MaxLength="0" Width="177px" TabIndex="41"></asp:DropDownList></td></tr><tr><td align="left"><asp:Label ID="lblSucursalDeposito" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Sucursal"></asp:Label></td><td align="left"><asp:TextBox ID="txtSucursalDeposito" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="20" TabIndex="42" ValidationGroup="depositosGroup" Width="83px"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSucursalDeposito"
                                                                                                                    ErrorMessage="*" ValidationGroup="depositosGroup"></asp:RequiredFieldValidator>
                                                                                                                    
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtSucursalDeposito" ValidationGroup="depositosGroup" ValidationExpression="^[0-9]{1,15}$"></asp:RegularExpressionValidator>  
                                                                                                                    </td><td align="left">&#160;&#160;</td></tr><tr><td><asp:Label ID="lblFechaDeposito" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Fecha"></asp:Label></td><td><asp:TextBox ID="txtFechaDeposito" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                TabIndex="43" ValidationGroup="depositosGroup" Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender
                                                                                                                    ID="CalendarExtenderFechaDeposito" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                                                                    PopupButtonID="ImgFechaDeposito" TargetControlID="txtFechaDeposito"></ajaxToolkit:CalendarExtender><ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaDeposito" runat="server"
                                                                                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                                                CultureTimePlaceholder="" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999"
                                                                                                                MaskType="Date" TargetControlID="txtFechaDeposito"></ajaxToolkit:MaskedEditExtender><ajaxToolkit:MaskedEditValidator ID="MaskedEditValidatorFechaDeposito" runat="server"
                                                                                                                ControlExtender="MaskedEditExtenderFechaDeposito" ControlToValidate="txtFechaDeposito"
                                                                                                                Display="None" EmptyValueMessage="El campo Fecha de depósito no puede estar vacío"
                                                                                                                ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                                                                ValidationGroup="depositosGroup" /><asp:ImageButton ID="ImgFechaDeposito" runat="server"
                                                                                                                    ImageUrl="~/Images/Calendar.png" /></td></tr><tr><td align="left"><asp:Label ID="lblNumComprobante" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="N° Comprobante: "></asp:Label></td><td><asp:TextBox ID="txtNumComprob" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="15" Width="83px" ValidationGroup="depositosGroup" TabIndex="44"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNumComprob"
                                                                                                                    ErrorMessage="*" ValidationGroup="depositosGroup"></asp:RequiredFieldValidator>
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtNumComprob" ValidationGroup="depositosGroup" ValidationExpression="^[0-9]{1,10}$"></asp:RegularExpressionValidator>  
                                                                                                                    </td></tr><tr><td align="left"><asp:Label ID="lblImporteDeposito" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Importe "></asp:Label></td><td><asp:TextBox ID="txtImporteDeposito" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="15" ValidationGroup="depositosGroup" Width="83px" OnBlur="AplicarFocoAgregarPago()" TabIndex="45"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtImporteDeposito"
                                                                                                                    ErrorMessage="*" ValidationGroup="depositosGroup"></asp:RequiredFieldValidator>
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtImporteDeposito" ValidationGroup="depositosGroup" ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,4})|[0-9]{1,7}$"></asp:RegularExpressionValidator>  

                                                                                                                    </td></tr></table></ContentTemplate></ajaxToolkit:TabPanel>
                                                                                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel5" HeaderText="Transferencia" Enabled="true"
                                                                                            Visible="true"><HeaderTemplate>Transf</HeaderTemplate><ContentTemplate><table style="margin-top: 15px;"><tr><td align="left"><asp:Label ID="lblCuentaCredito" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Cuenta Crédito"></asp:Label></td><td align="left"><asp:DropDownList ID="cmbCuentaCredito" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="16px"
                                                                                                                MaxLength="0" Width="177px" ValidationGroup="transferenciasGroup" TabIndex="50"></asp:DropDownList></td></tr><tr><td align="left"><asp:Label ID="lblCuentaDebito" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Cuenta Débito"></asp:Label></td><td align="left"><asp:TextBox ID="txtCuentaDebito" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="20" TabIndex="51" ValidationGroup="transferenciasGroup" Width="83px"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorCuentaDebito" runat="server" ControlToValidate="txtCuentaDebito"
                                                                                                                    ErrorMessage="*" ValidationGroup="transferenciasGroup"></asp:RequiredFieldValidator>
                                                                                                                    
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtCuentaDebito" ValidationGroup="transferenciasGroup" ValidationExpression="^[0-9]{1,10}$"></asp:RegularExpressionValidator>  
                                                                                                                    
                                                                                                                    </td></tr>
                                                                                                                    <tr><td align="left"><asp:Label ID="lblNumComprobTrans" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="N° Comprobante: "></asp:Label></td><td><asp:TextBox ID="txtNumComprobTrans" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="15" Width="83px" ValidationGroup="transferenciasGroup" TabIndex="53"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorNumTran" runat="server" ControlToValidate="txtNumComprobTrans"
                                                                                                                    ErrorMessage="*" ValidationGroup="transferenciasGroup"></asp:RequiredFieldValidator>
                                                                                                                    
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtNumComprobTrans" ValidationGroup="transferenciasGroup" ValidationExpression="^[0-9]{1,10}$"></asp:RegularExpressionValidator>  
                                                                                                                    
                                                                                                                    </td></tr>
                                                                                                                    
                                                                                                                    <tr><td><asp:Label ID="lblFechaTransferencia" runat="server" Style="font-family: Verdana;
                                                                                                                font-size: 9px;" Text="Fecha Depósito"></asp:Label></td><td><asp:TextBox ID="txtFechaTransferencia" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                TabIndex="52" ValidationGroup="transferenciasGroup" Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender
                                                                                                                    ID="CalendarExtenderFechaTrans" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                                                                    PopupButtonID="ImgFechaTransf" TargetControlID="txtFechaTransferencia"></ajaxToolkit:CalendarExtender><ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaTrans" runat="server"
                                                                                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                                                CultureTimePlaceholder="" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999"
                                                                                                                MaskType="Date" TargetControlID="txtFechaTransferencia"></ajaxToolkit:MaskedEditExtender><ajaxToolkit:MaskedEditValidator ID="MaskedEditValidatorFechaTrans" runat="server"
                                                                                                                ControlExtender="MaskedEditExtenderFechaTrans" ControlToValidate="txtFechaTransferencia"
                                                                                                                Display="None" EmptyValueMessage="El campo Fecha de transeferencia no puede estar vacío"
                                                                                                                ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                                                                ValidationGroup="transferenciasGroup" /><asp:ImageButton ID="ImgFechaTransf" runat="server"
                                                                                                                    ImageUrl="~/Images/Calendar.png" /></td></tr><%-- <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblFechaDepositoTransf" runat="server" Style="font-family: Verdana;
                                                                                                                font-size: 9px;" Text="Fecha"></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtFechaDepositoTransf" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                TabIndex="7" ValidationGroup="transferenciasGroup" Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender
                                                                                                                    ID="CalendarExtender5" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                                                                    PopupButtonID="ImgFechaTransf" TargetControlID="txtFechaDepositoTransf">
                                                                                                                </ajaxToolkit:CalendarExtender>
                                                                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaDepoTrans" runat="server"
                                                                                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                                                CultureTimePlaceholder="" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999"
                                                                                                                MaskType="Date" TargetControlID="txtFechaDepositoTransf">
                                                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator4" runat="server"
                                                                                                                ControlExtender="MaskedEditExtenderFechaDepoTrans" ControlToValidate="txtFechaDepositoTransf"
                                                                                                                Display="None" EmptyValueMessage="El campo Fecha de transeferencia no puede estar vacío"
                                                                                                                ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                                                                ValidationGroup="transferenciasGroup" /><asp:ImageButton ID="ImageButton2" runat="server"
                                                                                                                    ImageUrl="~/Images/Calendar.png" />
                                                                                                        </td>
                                                                                                    </tr>--%><tr><td align="left"><asp:Label ID="Label7" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Importe "></asp:Label></td><td><asp:TextBox ID="txtImporteTransferencia" runat="server" CssClass="textboxEditor"
                                                                                                                Height="16px" MaxLength="15" Width="83px" ValidationGroup="transferenciasGroup" OnBlur="AplicarFocoAgregarPago()" TabIndex="54"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorImporteTransferencia" runat="server" ControlToValidate="txtImporteTransferencia"
                                                                                                                    ErrorMessage="*" ValidationGroup="transferenciasGroup"></asp:RequiredFieldValidator>
                                                                                                                    
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtImporteTransferencia" ValidationGroup="transferenciasGroup" ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,4})|[0-9]{1,7}$"></asp:RegularExpressionValidator>  
                                                                                                                    
                                                                                                                    </td></tr></table></ContentTemplate></ajaxToolkit:TabPanel>
                                                                                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel6" HeaderText="OtrosPagos" Enabled="true"
                                                                                            Visible="true"><HeaderTemplate>Otros</HeaderTemplate><ContentTemplate><table style="margin-top: 15px;"><tr><td align="left"><asp:Label ID="lblTipoPagoRaro" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Tipo Pago"></asp:Label></td><td><asp:DropDownList ID="cmbTipoPagoRaro" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="16px"
                                                                                                                MaxLength="0" Width="177px" TabIndex="60"></asp:DropDownList></td></tr><tr><td><asp:Label ID="lblFechaPagoRaro" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Fecha Pago"></asp:Label></td><td><asp:TextBox ID="txtFechaPagoRaro" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                TabIndex="61" ValidationGroup="otrosPagosGroup" Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender
                                                                                                                    ID="CalendarExtenderOtros" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                                                                    PopupButtonID="ImgFechaRara" TargetControlID="txtFechaPagoRaro"></ajaxToolkit:CalendarExtender><ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderOtros" runat="server" CultureAMPMPlaceholder=""
                                                                                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaPagoRaro"></ajaxToolkit:MaskedEditExtender><ajaxToolkit:MaskedEditValidator ID="MaskedEditValidatorOtros" runat="server" ControlExtender="MaskedEditExtenderOtros"
                                                                                                                ControlToValidate="txtFechaPagoRaro" Display="None" EmptyValueMessage="El campo Fecha Pago no puede estar vacío"
                                                                                                                ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                                                                ValidationGroup="otrosPagosGroup" /><asp:ImageButton ID="ImgFechaRara" runat="server"
                                                                                                                    ImageUrl="~/Images/Calendar.png" /></td></tr><tr><td align="left"><asp:Label ID="lblNumCompRaro" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="N° Comprobante: "></asp:Label></td><td><asp:TextBox ID="txtNumCompRaro" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="15" Width="83px" ValidationGroup="otrosPagosGroup" TabIndex="62"></asp:TextBox><%--<asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorNumCompRaro" runat="server" ControlToValidate="txtNumCompRaro"
                                                                                                                    ErrorMessage="*" ValidationGroup="otrosPagosGroup"></asp:RequiredFieldValidator>--%>
                                                                                                                    
                                                                                                                   <%-- <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtNumCompRaro" ValidationGroup="otrosPagosGroup" ValidationExpression="^[0-9]{1,10}$"></asp:RegularExpressionValidator>  
                                                                                                                  --%>  
                                                                                                                    </td></tr><tr><td align="left"><asp:Label ID="lblImporteRaro" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Importe "></asp:Label></td><td><asp:TextBox ID="txtImporteRaro" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="15" ValidationGroup="otrosPagosGroup" Width="83px" OnBlur="AplicarFocoAgregarPago()" TabIndex="63"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorImporteRaro" runat="server" ControlToValidate="txtImporteRaro"
                                                                                                                    ErrorMessage="*" ValidationGroup="otrosPagosGroup"></asp:RequiredFieldValidator>
                                                                                                                    
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*" ControlToValidate="txtImporteRaro" ValidationGroup="otrosPagosGroup" ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,4})|[0-9]{1,7}$"></asp:RegularExpressionValidator>  
                                                                                                                    
                                                                                                                    </td></tr></table></ContentTemplate></ajaxToolkit:TabPanel>
                                                                                        <ajaxToolkit:TabPanel ID="TabPanel7" runat="server" HeaderText="TabPanel7"><HeaderTemplate>Desc</HeaderTemplate><ContentTemplate><table style="margin-top: 15px;"><tr><td align="left"><asp:Label ID="Label2" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Concepto"></asp:Label></td><td><asp:DropDownList ID="cmbDescuentos" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="16px"
                                                                                                                MaxLength="0" Width="177px" TabIndex="70"></asp:DropDownList></td></tr><tr><td><asp:Label ID="lblImporteDescuento" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Importe"></asp:Label></td><td><asp:TextBox ID="txtImporteDescuento" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                Width="83px" MaxLength="15" ValidationGroup="descuentosGroup" OnBlur="AplicarFocoAgregarPago()" TabIndex="71"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                                                                                                    ControlToValidate="txtImporteDescuento" ValidationGroup="descuentosGroup"></asp:RequiredFieldValidator>
                                                                                                                    
                                                                                                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="*rrecto" ControlToValidate="txtImporteDescuento" ValidationGroup="descuentosGroup" ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,4})|[0-9]{1,7}$"></asp:RegularExpressionValidator>  
                                                                                                                    
                                                                                                                    </td></tr></table></ContentTemplate></ajaxToolkit:TabPanel>
                                                                                    </ajaxToolkit:TabContainer>
                                                                                </td>
                                                                            </tr>
                                                                          
                                                                                <tr>
                                                                                    <td>
                                                                                        <table>
                                                                                            <tr>
                                                                                                                                                                                  
                                                                                                <td align="left">
                                                                                                  
                                                                                                                 
                                                                                                <table style="width: 307px">
                                                                                                      
                                                                                                      <tr>
                                                                                                       <td>
                                                                                                           <asp:CheckBox ID="chkPestreificar" runat="server" Checked="false" Text="Moneda Extranjera" style="font-family:Verdana;font-size:9px;" />
                                                                                                          
                                                                                                         </td>
                                                                                                          <td>
                                                                                                                 <asp:UpdatePanel runat="server" ID="updatePanelBtnAgregarPago" UpdateMode="Conditional">
                                                                                                                    <ContentTemplate>
                                                                                                                        
                                                                              
                                                                                                                           
                                                                                                                      <input id="btnAgregarPagoClientSide" type="button" value="Agregar Valor" 
                                                                                                                            onclick="OnClick_btnAgregarPago();" class="button_back3"   tabindex="20" />
                                                                                                                             
                                                                                                                            
                                                                                                                            </ContentTemplate>
                                                                                                                            
                                                                                                                    </asp:UpdatePanel>
                                                                                                          </td>
                                                                                                      </tr>
                                                                                                                                                                                                     
                                                                                                </table>
                                                                                           
																							   <%-- <asp:CheckBox ID="chkPesificar" runat="server" Checked="false" Text="Moneda Extranjera" style="font-family:Verdana;font-size:9px;position:absolute;margin-left:-120px;" OnClientClick="return alert('asd');"/>--%>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="height: 50px;">
                                                                                                    <asp:Panel ID="pnlPagosIngresados" CssClass="scrollbar" Height="77px"
                                                                                                        ScrollBars="Vertical" Width="300px">
                                                                                                        <table id="gvResultadosPagosLight">
                                                                                                                                                                              
                                                                                                         <tr>
                                                                                                             <td class="gvHeader grayGvHeader" style="width:50px; font-weight:bold; text-align:center;">
                                                                                                                 Documento
                                                                                                             </td>
                                                                                                             <td class="gvHeader grayGvHeader" style="width:50px; font-weight:bold;text-align:center;">
                                                                                                                 Tipo
                                                                                                             </td>
                                                                                                             <td class="gvHeader grayGvHeader" style="width:50px; font-weight:bold;">
                                                                                                                  Moneda
                                                                                                             </td>
                                                                                                             <td class="gvHeader grayGvHeader" style="width:50px; font-weight:bold;text-align:center;">
                                                                                                                 Importe
                                                                                                             </td>
                                                                                                             <td class="gvHeader grayGvHeader" style="width:50px; font-weight:bold;text-align:center;"> 
                                                                                                                 Eliminar
                                                                                                             </td>
                                                                                                             <td class="gvHeader grayGvHeader" style="width:50px; font-weight:bold;text-align:center;">
                                                                                                                 Editar
                                                                                                             </td>
                                                                                                         
                                                                                                         </tr>
                                                                                                         </table>
                                                                                                        <%--<ma:XGridView ID="gvResultadosPagos" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                            BorderWidth="0px" DataKeyNames="Orden" EmptyDataText="Agregue pagos..." ExecutePageIndexChanging="True"
                                                                                                            OnPreRender="gvResultadosPagos_PreRender" OnRowDeleted="gvResultadosPagos_RowDeleted"
                                                                                                            OnRowDeleting="gvResultadosPagos_RowDeleting" OnRowEditing="gvResultadosPagos_RowEditing"
                                                                                                            OnSelectedIndexChanged="gvResultadosPagos_SelectedIndexChanged" OnSelectedIndexChanging="gvResultadosPagos_SelectedIndexChanging"
                                                                                                            Width="470px">
                                                                                                            <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                                                            <Columns>
                                                                                                                <asp:BoundField DataField="Orden" HeaderText="Documento" />
                                                                                                                <asp:BoundField DataField="FormaPago" HeaderText="Tipo">
                                                                                                                    <HeaderStyle Font-Bold="True" />
                                                                                                                </asp:BoundField>
                                                                                                                <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                                                                                                                    <HeaderStyle Font-Bold="True" />
                                                                                                                </asp:BoundField>
                                                                                                                
                                                                                                                <asp:BoundField DataField="importe" HeaderText="Importe" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:F4}">
                                                                                                                    <HeaderStyle Font-Bold="True" />
                                                                                                                </asp:BoundField>
                                                                                                                <asp:CommandField DeleteText="Eliminar" HeaderText="Eliminar" InsertText="juaua" ItemStyle-HorizontalAlign="Center"
                                                                                                                    ShowCancelButton="False" ShowDeleteButton="True" />
                                                                                                                <asp:CommandField CausesValidation="False" EditText="Editar" HeaderText="Editar" ItemStyle-HorizontalAlign="Center"
                                                                                                                    ShowEditButton="True" ShowHeader="True" />
                                                                                                            </Columns>
                                                                                                            <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                                                            <EmptyDataTemplate>
                                                                                                                Agregue pagos...
                                                                                                            </EmptyDataTemplate>
                                                                                                            <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                                                                            <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                                                            <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                                                            <RowStyle CssClass="gvItem" />
                                                                                                        </ma:XGridView>--%></asp:Panel>
                                                                                                   
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                          
                                                                        </table>
                   
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                        <td valign="top" align="left">
                            <asp:panel id="pnlFacturas" runat="server" height="365px" cssclass="scrollbar" scrollbars="Vertical"
                                width="576px">
                                                                    <asp:UpdatePanel runat="server" ID="updatePanelGvFacturas" UpdateMode="Conditional" >
                                                                        <ContentTemplate>
                                                                            <ma:XGridView ID="GvResultadosFacturas" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                BorderWidth="0px" DataKeyNames="idFactura" EmptyDataText="No se encontraron resultados"
                                                                                ExecutePageIndexChanging="False" OnFilling="GvResultadosFacturas_Filling" OnPreRender="GvResultadosFacturas_PreRender"
                                                                                 OnSorted="GvResultadosFacturas_Sorted" OnRowDataBound="GvResultadosFacturas_RowDataBound"
                                                                                Width="400px" OnSelectedIndexChanging="GvResultadosFacturas_SelectedIndexChanging">
                                                                                <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                                <Columns>
                                                                                    <%--<asp:CommandField ButtonType="Image" EditImageUrl="~/Images/Lupa_chica.gif" HeaderText="Ver Historial"
                                                                                        ShowEditButton="True" >
                                                                                        <HeaderStyle Font-Bold="True" />
                                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                                    </asp:CommandField>--%>
                                                                                    <asp:BoundField DataField="idFactura" HeaderText="id Factura" InsertVisible="false">
                                                                                        <HeaderStyle CssClass="HiddenColumn" /> 
                                                                                        <ItemStyle CssClass="HiddenColumn" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="ComprobanteFormateado" HeaderText="Nro Factura" />
                                                                                    <asp:BoundField DataField="fechaVenc" HeaderText="Vencimiento" SortExpression="fechaVenc"
                                                                                        DataFormatString="{0:d/MM/yyyy}">
                                                                                        <HeaderStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="ImporteFormateado" HeaderText="Importe" SortExpression="importe" ItemStyle-HorizontalAlign="Right" />
                                                                                    <asp:BoundField DataField="SaldoFormateado" HeaderText="Saldo" SortExpression="saldo" ItemStyle-HorizontalAlign="Right">
                                                                                        <HeaderStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="moneda" HeaderText="Moneda" />
                                                                                    <asp:BoundField DataField="importePP" HeaderText="Importe PP" SortExpression="importePP">
                                                                                        <HeaderStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="A Imputar">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtAImputarPorFactura" runat="server" CssClass="textboxEditor" Height="12"
                                                                                                Width="52"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Obs.">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="imgBtnObservacion" runat="server" CausesValidation="false" Enabled = "false" ImageUrl="~/Images/agregar.gif"
                                                                                                OnClientClick="MostrarPanelObservaciones()" />
                                                                                            <asp:TextBox ID="txtObs" runat="server" CssClass="textboxEditor" Height="12" Visible="false"
                                                                                                Width="52"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:CommandField  ButtonType="Button" HeaderText="Pronto"  ControlStyle-Width="48"  ShowSelectButton="True"
                                                                                        SelectText="+" ControlStyle-CssClass="button_back"/>
                                                                                    <asp:TemplateField HeaderText="Seleccionar">
                                                                                        <ItemTemplate>
                                                                                            <!--<input id="Checkbox1" type="checkbox" onclick="javascript:alert('sssss');"/>-->
                                                                                            <asp:CheckBox ID="chk" runat="Server" EnableViewState="True" />
                                                                                        </ItemTemplate>
                                                                                        <HeaderTemplate>
                                                                                            <asp:CheckBox ID="chkAll" runat="Server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" Enabled="False"/>
                                                                                        </HeaderTemplate>
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
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </asp:panel>
                            <table style="width: 95%;">
                                <tr>
                                    <td>
                                        <asp:label id="lblResultadoCantFacts" runat="server" style="font-family: Verdana;
                                            font-size: 9px;" text="Cantidad de Facturas: " enableviewstate="False"></asp:label>
                                        <asp:label id="lblResResultadoCantFacts" runat="server" style="font-family: Verdana;
                                            font-size: 9px;" enableviewstate="False"></asp:label>
                                        <br />
                                        <asp:label id="lblAplicaProntoPago" runat="server" forecolor="#009900" style="font-family: Verdana;
                                            font-size: 9px;"></asp:label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                       <tr>
                        <td class="style7" style="border-style: groove groove outset outset; border-bottom-color: #FFFFFF;
                            border-right-color: #C0C0C0; border-width: thin 2px 2px 1px; border-spacing: 2px;
                            border-collapse: collapse;" align="left">
                            <asp:updatepanel id="UpdatePanelSumasPagos" runat="server" updatemode="Conditional">
                                                                    
                                                                    <ContentTemplate>   
                                                                                                                                                                                                 
                                                               <asp:Label ID="Label6" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                    font-weight: bold;" Text="Pagos Mon. Ext.: " Visible="false">
                                                                </asp:Label>
                                                               &nbsp;                                                                
                                                                <asp:TextBox ID="txtPagosExt" runat="server" BackColor="#CCCCCC" CssClass="textboxEditor"
                                                                    Height="16px" ReadOnly="True" Width="113px" Visible="false"></asp:TextBox>                                                                
                                                               <asp:Label ID="lblImputado" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                    font-weight: bold;" Text="Pagos Mon. Loc.: ">
                                                                </asp:Label>
                                                               &nbsp;                                                                
                                                                <asp:TextBox ID="txtPagos" runat="server" BackColor="#CCCCCC" CssClass="textboxEditor"
                                                                    Height="16px" ReadOnly="True" Width="113px"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                    </asp:updatepanel>
                        </td>
                        <td style="border-style: groove groove outset outset; border-bottom-color: #FFFFFF;
                            border-right-color: #C0C0C0; border-width: thin 2px 2px 1px; border-spacing: 2px;
                            border-collapse: collapse" valign="middle">
                            <asp:updatepanel id="UpdatePanelResultados" runat="server" updatemode="Conditional">
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="btnGuardarRecibo" />
                                                      
                                                                                                       
                                                                          
                                                                    </Triggers>
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="Label8" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                            font-weight: bold;" Text="Imputado Mon. Loc.: ">
                                                                        </asp:Label>
                                                                        <asp:TextBox ID="txtSumaFacturas" runat="server" BackColor="#CCCCCC"
                                                                            CssClass="textboxEditor" Height="16px"
                                                                            ReadOnly="True" Width="113px"></asp:TextBox>
                                                                            <asp:Label ID="Label9" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                            font-weight: bold;" Text="Imputado Mon. Ext.: " Visible="false">
                                                                        </asp:Label>
                                                                            <asp:TextBox ID="txtSumaFacturasExt" runat="server"  BackColor="#CCCCCC"
                                                                            CssClass="textboxEditor" Height="16px" 
                                                                            ReadOnly="True" Width="113px" Visible="false"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:updatepanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table width="95%">
                                <tr>
                                    <td align="center">
                                        <asp:updatepanel id="UpdatePanelResultadosDiferenciaLocal" runat="server" updatemode="Conditional">
                                                                    
                                                                           <ContentTemplate>
                                                                            <asp:Label ID="lblDiferenciaPe" runat="server" Text="Diferencia Mon. Loc." Style="font-family: Verdana; font-size: 10px;font-weight:bold"></asp:Label>
                                                                            <asp:TextBox ID="txtDiferenciaPe" runat="server" ReadOnly="true" CssClass="textboxEditor" Width="74px"></asp:TextBox>
                                                                            <asp:Label ID="lblDiferenciaDo" runat="server" Text="Diferencia Mon. Ext." Style="font-family: Verdana; font-size: 10px;font-weight:bold" Visible="false"></asp:Label>
                                                                            <asp:TextBox ID="txtDiferenciaDo" runat="server" ReadOnly="true" CssClass="textboxEditor" Width="74px" Visible="false"></asp:TextBox>
                                                                            </ContentTemplate>
                                                                           
                                                                            </asp:updatepanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                                                               </table>                                                      
                                                            </td>
                                                        
                                                           
                                                        </tr>
                                                       
                 
                    <tr>
                        <td colspan="2">
                            <table width="95%">
                                <tr>
                                    <td align="center">
                                        <ma:SecureButton ID="btnGuardarRecibo" runat="server" CausesValidation="True" CssClass="button_back3"
                                            Height="20px" OnClick="btnGuardarRecibo_Click" OnClientClick="return ValidarDatosDelRecibo();"
                                            Text="Guardar Recibo" ValidationGroup="reciboGroup" Width="147px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table width="95%">
                                <tr>
                                    <td align="left">
                                        <%--        <asp:UpdatePanel ID="UpdatePanelVerPdfRemisionEnCurso" runat="server" UpdateMode="Conditional">
                                                                                   <ContentTemplate>--%>
                                        <%--   <asp:LinkButton ID="linkButtonRemisionEncurso" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                    Width="150px" CausesValidation="False" OnClick="linkButtonRemisionEnCurso_Click">Remisión en Curso</asp:LinkButton>--%>
                                        <a href="javascript:GenerarPdf();" style="font-family: Verdana; font-size: 9px;">Remisión
                                            en Curso</a>
                                        <%--          </ContentTemplate>
                                                                                    </asp:UpdatePanel>--%>
                                    </td>
                                    <td align="right">
                                        <asp:checkbox id="chkMail" runat="server" text="Enviar Mail | " style="font-family: Verdana;
                                            font-size: 10px; font-weight: bold;" Visible="false" />
                                        <ma:SecureButton ID="btnCrearRemision" runat="server" CssClass="button_back3" Height="20px"
                                            OnClientClick="return ConfirmacionCierreDeRemision();" OnClick="btnCrearRemision_Click" Text="Cerrar Remisión" Width="130px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
            </td>
            </tr> </table> </ContentTemplate> </asp:updatepanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="ContentHeader">
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="menuJQUERY">
    <style type="text/css">
        .style5
        {
            width: 213px;
        }
        .style7
        {
            width: 400px;
        }
        .style8
        {
            font-family: Tahoma, Arial, MS Sans Serif;
            font-size: 10px;
            color: #666666;
            background-image: url(      '../Images/fdo_tile.gif' );
            background-position: 50% top;
            background-color: white;
            font-weight: bold;
            vertical-align: top;
            height: 23px;
            width: 510px;
        }
    </style>
</asp:Content>
