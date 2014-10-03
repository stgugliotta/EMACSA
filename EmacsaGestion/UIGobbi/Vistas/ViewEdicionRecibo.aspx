<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewEdicionRecibo.aspx.cs" Inherits="Vistas_ViewEdicionRecibo" %>

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

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>
   
    
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
    if(controlCaller.indexOf('btnNuevaRemisionTemporal')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('btnCrearRemision')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('btnRefreshCmbDeudores')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('btnRemisionEnUso')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('gvResultadosConcurrencia')!=-1){$find(ModalPopupCargando).show()};
    
    
    disableReClick(controlCaller,'btnNuevaRemisionTemporal');
     
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
function AplicarProntoPago(objeto,cont,valorReal)
{


  var myCheck;
  var myTextbox;
  var resultado;
  var suma;
  var textBoxSeleccionado= objeto.id;
   
   var signo;

      

}

function HolaGato(objeto)
{
alert('aa');
}

//function CheckearFacturasPersistidas(objeto)
//{

//alert(objeto.id);
//objeto.checked=true;
//return true;

//}


function SumarImporte(objeto,cont,valorReal,valorProntoPago,btnPPSeleccionado)
{
    var myCheck;
    var myTextbox;
    var buttonProntoPago;
    var resultado;
    var suma;
    var textBoxSeleccionado = objeto.id;   
    var signo;


    myTextbox = document.getElementById(textBoxSeleccionado.replace('chk','txtAImputarPorFactura'));
    buttonProntoPago = document.getElementById(btnPPSeleccionado);
                  
    if (objeto.checked)
    {
        if (myTextbox.value == ''  ||  isNaN(parseFloat(myTextbox.value))) 
        {
            objeto.checked=false;
            return false;
        }                        
        if (valorProntoPago != 0)
            valorReal = valorProntoPago;               
        importe = myTextbox.value;
        importe = importe.split(",").join("");
                   
        if(parseFloat(importe) > valorReal ||parseFloat(importe)==0 )
        {
            alert('El valor que esta ingresando no es permitido');
            objeto.checked = false;
            return true;
        }
               
        signo = 1;
        myTextbox.disabled = true;
        buttonProntoPago.disabled = true;
        //btnPPSeleccionado.disabled=true;
        
    }
    else
    {
        signo = -1;
        myTextbox.disabled = false;
        buttonProntoPago.disabled = false;
    }


    var txtSumaMonLoc = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturas');
    var txtSumaMonExt = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturasExt');        
    var txtCambio = document.getElementById('ctl00_Contentplaceholder1_txtCambio');                   
        
    var res = txtSumaMonLoc.value;                  //Levanta el resultado actual de la suma
    res = res.replace(',','.');                     //Le da formato de flotante
    
    importeGrilla = myTextbox.value;                    //Levanta el importe de la grilla
    importeGrilla = importeGrilla.replace(',', '');    //Le da formato flotante
    
    //Define el cambio por si no está ingresado o si es 1,00
       var Fila = myTextbox.parentNode.parentNode;
    var celda = Fila.cells[5].innerHTML;
    var Cambio = 1.0000;
    if (txtCambio.value != "1,0000" && txtCambio.value != "" && celda != "PE")     //Si es distinto de dicho valor, pisa el valor de cambio
        Cambio = txtCambio.value.replace(',', '.');             //Formato flotante




    var fValorConvertido = parseFloat(importeGrilla) * signo;   //Se sumará o restará según el signo (check)
    fValorConvertido = fValorConvertido / parseFloat(Cambio);   //Se divide por el cambio el valor
    
    suma = parseFloat(res) + parseFloat(fValorConvertido); //Actualiza la suma 
    suma = suma.toFixed(4); //Formato de 4 decimales separados por un punto    
        
    txtSumaMonLoc.value = parseFloat(suma);    //Moneda local: Dividir por cambio
    //txtSumaMonExt.value = parseFloat(txtSumaMonLoc.value) / parseFloat(Cambio);    //Moneda extranjera: Multiplicar por cambio


    txtSumaMonLoc.value = parseFloat(txtSumaMonLoc.value).toFixed(4);
    //txtSumaMonExt.value = parseFloat(txtSumaMonExt.value).toFixed(4);
        
    txtSumaMonLoc.value = txtSumaMonLoc.value.replace('.',','); //Formato con coma
    //txtSumaMonExt.value = txtSumaMonExt.value.replace('.',','); //Forma con coma
    
        
    //Diferencias:
    var DifPe = document.getElementById("ctl00_Contentplaceholder1_txtDiferenciaPe");
   // var DifDol = document.getElementById("ctl00_Contentplaceholder1_txtDiferenciaDo");


    var txtPagos = document.getElementById('ctl00_Contentplaceholder1_txtPagos');
    //var txtPagosExt = document.getElementById('ctl00_Contentplaceholder1_txtPagosExt');


    /*var fDifDol = parseFloat(txtPagosExt.value.replace(',', '.')) - parseFloat(txtSumaMonExt.value.replace(',', '.'));
    DifDol.value = fDifDol.toFixed(4);
    DifDol.value = DifDol.value.replace('.', ',');*/
                     
    var fDifPe = parseFloat(txtPagos.value.replace(',','.')) - parseFloat(txtSumaMonLoc.value.replace(',','.'));
    DifPe.value = fDifPe.toFixed(4);
    DifPe.value = DifPe.value.replace('.', ',');
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


function SumarImporteImputado()
{

  
    var input = getElementsByType("checkbox");
    var myCheck;
    var elementWithName;

    for ( var i = 0; i < input.length; i++ )
    {
            myCheck=document.getElementById(input[i].name);         
		    elementWithName=myCheck.id;
	    if ( input[i].checked == true)
	    {
		    alert( input[i].value+" "+input[i].name );
		    

	    }
    }
}

function SumarImporteImputado2(cont)
{
 
  var textBoxImputado;
  var textBoxCeldaMarcada;
  
  
   textBoxImputado=document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturas');         
   textBoxCeldaMarcada=document.getElementById('ctl00_Contentplaceholder1_GvResultadosFacturas_ctl0'+ cont.toString() + '_chk');
   alert(textBoxImputado.value);
   alert(textBoxCeldaMarcada.value);
   textBoxImputado.value=textBoxImputado.value + textBoxCeldaMarcada.value;

   textBoxImputadoExt = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturasExt');
   cambio = document.getElementById('ctl00_Contentplaceholder1_txtCambio');
   textBoxImputadoExt.value = textBoxImputado.value / cambio.value;
 
 return true;

}


    </script>

    <script type="text/javascript">
<!--
$(document).ready(function()
{
	var options = {minWidth: 120, arrowSrc: '/UIControls/MenuJQuery/Menu/arrow_right.gif', copyClassAttr: true, onClick: function(e, menuItem){
	    //openMenu(
	    
	    
	    
	    document.location='http://localhost/vistas/ViewImportacionDeFacturas.aspx';
	            
	    
	    
	    //);
		//alert('you clicked item "' + $(this).text() + e  + '"');
	}};
	
});
-->




 
    </script>

    <script language="javascript">

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
alert('df');
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
function ValidarProntoPagoSeleccionado()
{
alert('asd');
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
   
 var txtPagos;  
 
 
  txtPagos=document.getElementById('ctl00_Contentplaceholder1_txtPagos');  
  btnGuardarRecibo=document.getElementById('<%=this.btnGuardarRecibo.ClientID %>');
  txtSumaFacturas=document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturas');
  
  pagos=txtPagos.value;
  facturas=txtSumaFacturas.value;
  
           pagos=pagos.split(".").join("");
           pagos=pagos.split(",").join(".");
           
           facturas=facturas.split(".").join("");
           facturas=facturas.split(",").join(".");
           
           
           if (parseFloat(pagos)==0){
           alert('Ingrese por favor algun pago.');
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
  
  
}

function VerificarEliminar()
{

 if(confirm("¿Desea eliminar el recibo cargado temporalmente?")) 
  { 
    return true;
  }
  else {
        return false;
      }   
}



    </script>

<%--    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>--%>
    <asp:Panel ID="panelLectoraCheque" runat="server"  CssClass="pdateProgressLectoraCheque">
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
    </asp:Panel>
    
    <asp:Panel ID="panelConfirmaRemisionTemporal" runat="server">
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
    </asp:Panel>
    
    <asp:Panel ID="panelCargaObservacion" runat="server" CssClass="updateProgress">
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
    </asp:Panel>
    <asp:Panel ID="panelProntoPago" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <table style="height: 100px; width: 590px;">
                    <tr>
                        <td style="background-color: #EDEBEB; border-style: none groove outset none; border-bottom-color: #FFFFFF;
                            border-right-color: #C0C0C0; border-width: thin 2px 2px 1px; 
                            border-collapse: collapse" class="fondo_Titulo" height="100px">
                            DESCUENTOS DISPONIBLES
                            <br />
                            <br />
                            <asp:Panel ID="PanelPronto" runat="server" CssClass="scrollbar" ScrollBars="Vertical"
                                Width="100%">
                                <ma:XGridView ID="gvProntoPago" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                    DataKeyNames="id" EmptyDataText="No se encontraron resultados" ExecutePageIndexChanging="False"
                                    Width="99%" OnSelectedIndexChanging="gvProntoPago_SelectedIndexChanging">
                                    <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" ItemStyle-Width="10">
                                            <HeaderStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nombreCliente" HeaderText="Cliente" SortExpression="nombreCliente">
                                            <HeaderStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nombreDeudor" HeaderText="Deudor" SortExpression="nombreDeudor">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fechaLimiteDescuento" HeaderText="Hasta el" SortExpression="fechaLimiteDescuento"
                                            DataFormatString="{0:d/MM/yyyy}" ItemStyle-Width="40">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PorcentajeAplicacion" HeaderText="Porcentaje(%)" SortExpression="PorcentajeAplicacion"
                                            ItemStyle-Width="40">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:CommandField ButtonType="Image" ShowHeader="True" ShowSelectButton="True" HeaderText="Selección"
                                            SelectImageUrl="~/Images/correcto.gif" SelectText="" ItemStyle-Width="10">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
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
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="White">
                            <table width="100%">
                                <tr>
                                    <td align="rigth" valign="top">
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
                                            Height="20px" TabIndex="1" Text="Aplicar" Width="95px" CausesValidation="true"
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
    </asp:Panel>
    <asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <ProgressTemplate>
                <div style="position: relative; top: 30%; text-align: center; height: 100%; width: 100%">
                    <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                    Procesando...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:Panel>
    <asp:Panel ID="pnlDetalleCheques" runat="server" CssClass="updateProgress">
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
    </asp:Panel>
    
    <asp:Panel ID="panelRemisionesAbiertas" runat="server">
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
    </asp:Panel>
    
    
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupDetalleCheques" runat="server" TargetControlID="fielHidden"
        BackgroundCssClass="modalBackground" PopupControlID="pnlDetalleCheques" />
    <asp:HiddenField ID="fielHidden" runat="server" />
    
        <asp:HiddenField ID="hdPostbackControl" runat="server" 
    onvaluechanged="hdPostbackControl_ValueChanged" />
    
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupConfirmaNuevaRemision" runat="server" TargetControlID="fieldHiddenPanelConfirmaNuevaRemision"
        BackgroundCssClass="modalBackground" PopupControlID="panelConfirmaRemisionTemporal" />
    <asp:HiddenField ID="fieldHiddenPanelConfirmaNuevaRemision" runat="server" />
    
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupCargando" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
    <ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelLectoraCheque"
        BackgroundCssClass="modalBackground" PopupControlID="panelLectoraCheque" />
    <ajaxToolkit:ModalPopupExtender ID="ModalCargaObservacion" runat="server" TargetControlID="panelCargaObservacion"
        BackgroundCssClass="modalBackground" PopupControlID="panelCargaObservacion" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupProntoPago" runat="server" TargetControlID="HiddenFieldProntoPago"
        BackgroundCssClass="modalBackground" PopupControlID="panelProntoPago" />
        
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupDetalleControlConcurrencia" runat="server" TargetControlID="HiddenFieldRemisionesAbiertas"
        BackgroundCssClass="modalBackground" PopupControlID="panelRemisionesAbiertas" />
        
        
        
    <asp:HiddenField ID="HiddenFieldProntoPago" runat="server" />
    <asp:HiddenField ID="HiddenFieldRemisionesAbiertas" runat="server" />
    <table align="center" style="height: 557px">
        <tr style="height: 200px;">
            <td valign="top">
                <table style="width: 950px; height: 88%;" class="borderCompleto" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td width="100%;" class="fondo_Titulo" align="left" style="height: 34px">
                            
                           <asp:UpdatePanel runat="server" ID="updatePanelRemisionEnUso" UpdateMode="Conditional">
                                <ContentTemplate>
                                            Remisión de Valores N°: <asp:Label ID="lblRemisionEnUso" runat="server" Text=""></asp:Label>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:Panel runat="server" ID="panelCliente0">
                                <br />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="center">
                            <asp:UpdatePanel runat="server" ID="UpdatePanelIndice" UpdateMode="Conditional">
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
                                                                BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px"
                                                                Height="16px" MaxLength="0" OnSelectedIndexChanged="cmbClientes_SelectedIndexChanged"
                                                                Width="177px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <%--<asp:Label ID="lblDeudor" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                font-weight: bold;" Text="Deudor: " EnableViewState="False"></asp:Label>--%>
                                                                
                                                                 <a style="font-family: Verdana; font-size: 10px; font-weight: bold;">Deudor: </a>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:DropDownList ID="cmbDeudores" runat="server" AutoCompleteMode="SuggestAppend"
                                                                AutoPostBack="True" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid"
                                                                BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px"
                                                                Height="16px" MaxLength="0" OnDataBound="cmbDeudores_DataBound" OnSelectedIndexChanged="cmbDeudores_SelectedIndexChanged"
                                                                OnTextChanged="cmbDeudores_TextChanged" Width="177px">
                                                            </asp:DropDownList>
                                                            <asp:ImageButton ID="btnRefreshCmbDeudores" runat="server"  
                                                                ImageUrl="~/Images/Reasignar.gif" onclick="btnRefreshCmbDeudores_Click"/>
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
                                                                         <asp:Button ID="btnNuevaRemisionTemporal" runat="server" Text="Crear Remision" 
                                                                             CssClass="button_back3" CommandName="cmdCrearRemision" 
                                                                             CommandArgument="CREAR" oncommand="btnNuevaRemisionTemporal_Command"  />
                                                                     
                                                                     </td>
                     
                                                               </tr>
                                                               <tr>
                                                                   <td>
                                                                      <br />
                                                                   </td>
                                                               </tr>
                                                
                                                               <tr>
                                                        <td>
                                                        
                                                        <asp:Label ID="lblRemisionEnUsoTitle" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                font-weight: bold;" Text="Remisión en uso: "></asp:Label>
                                                            <br />
                                                            <tr>
                                                                <td align="center" style="text-align:center;">
                                                                                         <asp:Button ID="btnRemisionEnUso" runat="server" Text="        Abrir        "  
                                                                                             CssClass="button_back3" onclick="btnRemisionEnUso_Click" Width="130px"/>           
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
                                                            <asp:Panel ID="Panel1" runat="server" Height="323px">
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
                                                                            <td align="left">
                                                                                <asp:ImageButton ID="btnEliminarRecibo" runat="server" 
                                                                                    ImageUrl="~/Images/delete.gif" onclick="btnEliminarRecibo_Click" 
                                                                                    OnClientClick="return VerificarEliminar();" />
                                                                                &nbsp;
                                                                                <asp:Label ID="lblEliminar" runat="server" 
                                                                                    Style="font-family: Verdana; font-size: 9px;" 
                                                                                    Text="Eliminar Recibo Seleccionado" EnableViewState="False"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblRemisiones" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                                font-weight: bold;" Text="Buscar Remisión: " EnableViewState="False"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
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
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                       
                                                       </td>
                                                    </tr>
                                                    
                                                    
                                                </table>
                                            </td>
                                            <td valign="top"  style="background-color: #EDEBEB; border-style: none groove outset none;
                                                border-bottom-color: #FFFFFF; border-right-color: #C0C0C0; border-width: thin 2px 2px 1px;
                                                border-spacing: 2px; border-collapse: collapse" align="left">
                                                <asp:Panel ID="panelGeneralCuerpoPagina" runat="server" Width="1000px">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label runat="server" Id="lblRemision" Style="font-family: Verdana; font-size: 10px;
                                                                    font-weight: bold;" Text="RECIBO: "></asp:Label>
                                                                <asp:TextBox ID="txtRecibo" runat="server" CssClass="textboxEditor" Height="16px"
                                                                    ValidationGroup="reciboGroup" Width="113px" MaxLength="13">0000-</asp:TextBox>
                                                                &nbsp;
                                                                <asp:Label ID="lblFechaRecibo" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                    font-weight: bold;" Text="Fecha Recibo: "> </asp:Label>
                                                                <asp:TextBox ID="txtFechaRecibo" runat="server" CssClass="textboxEditor" Height="16px"
                                                                    TabIndex="3" ValidationGroup="reciboGroup" Width="83px"></asp:TextBox>
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
                                                                &nbsp;
                                                                <asp:Label ID="lblCambio" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                    font-weight: bold;" Text="Cambio: ">
                                                                </asp:Label>
                                                                <asp:TextBox ID="txtCambio" runat="server" CssClass="textboxEditor" Height="16px"
                                                                    ValidationGroup="reciboGroup" Width="40px" Text="1,00"></asp:TextBox>
                                                                <br />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtRecibo"
                                                                    ErrorMessage="Error, no respeta el formato." ValidationExpression="\d{4}-\d{8}"
                                                                    ValidationGroup="reciboGroup"></asp:RegularExpressionValidator>
                                                                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtenderFechaRecibo"
                                                                    ControlToValidate="txtFechaRecibo" Display="None" EmptyValueMessage="El campo Fecha Recibo no puede esta vacío"
                                                                    ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                    ValidationGroup="reciboGroup" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCambio"
                                                                    ErrorMessage="Ingrese el tipo de cambio" ValidationGroup="reciboGroup"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCambio"
                                                                    ErrorMessage="Error en el tipo de cambio." ValidationExpression="[0-9],[0-9][0-9]?"
                                                                    ValidationGroup="reciboGroup"></asp:RegularExpressionValidator>
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
                                                                    Width="113px"></asp:TextBox>
                                                                &nbsp; &nbsp;
                                                                <asp:ImageButton ID="btnBuscarFactura" runat="server" CausesValidation="False" Height="16px"
                                                                    ImageUrl="~/Images/Ico12.gif" OnClick="btnBuscarFactura_Click" Width="23px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="fondo_Titulo" style="height: 23px">
                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td style="width: 100%; height: 30px;">
                                                                            Pagos
                                                                        </td>
                                                                        <td valign="top">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="fondo_Titulo" style="height: 23px">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td style="width: 100%; height: 30px;">
                                                                            Documentos
                                                                        </td>
                                                                        <td valign="top">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <asp:UpdatePanel ID="UpdatePanelTabContainer" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table style="width: 350px; margin-right: 0px;">
                                                                            <tr>
                                                                                <td>
                                                                                    <ajaxToolkit:TabContainer runat="server" ID="TabContainer1" Height="337px" Width="463px"
                                                                                        ActiveTabIndex="0" AutoPostBack="true" OnActiveTabChanged="TabContainer1_ActiveTabChanged"
                                                                                        TabStripPlacement="Top" TabIndex="6">
                                                                                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="Factura" Enabled="true"
                                                                                            Visible="true">
                                                                                            <HeaderTemplate>
                                                                                                Cheques</HeaderTemplate>
                                                                                            <ContentTemplate>
                                                                                                <table style="margin-top: 15px;">
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblImporte" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Importe"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtImporte" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="15" TabIndex="4" ValidationGroup="chequeGroup" Width="83px"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorImporte" runat="server" ControlToValidate="txtImporte"
                                                                                                                    ErrorMessage="Ingrese el importe" ValidationGroup="chequeGroup"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblCheque" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="N° Cheque" EnableViewState="False"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtCheque" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="15" TabIndex="5" ValidationGroup="chequeGroup" Width="83px"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorCheque" runat="server" ControlToValidate="txtCheque"
                                                                                                                    ErrorMessage="Ingrese el número de cheque" ValidationGroup="chequeGroup"></asp:RequiredFieldValidator>&#160;&#160;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblFechaVenc" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Vencimiento" EnableViewState="False"></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                TabIndex="6" ValidationGroup="chequeGroup" Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender
                                                                                                                    ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="imgFecha4"
                                                                                                                    TargetControlID="txtFechaVencimiento">
                                                                                                                </ajaxToolkit:CalendarExtender>
                                                                                                            <ajaxToolkit:MaskedEditExtender ID="txtFechaVencimiento_MaskedEditExtender" runat="server"
                                                                                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                                                CultureTimePlaceholder="" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999"
                                                                                                                MaskType="Date" TargetControlID="txtFechaVencimiento">
                                                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="txtFechaVencimiento_MaskedEditExtender"
                                                                                                                ControlToValidate="txtFechaVencimiento" Display="None" EmptyValueMessage="El campo Fecha Vencimiento no puede esta vacío"
                                                                                                                ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                                                                ValidationGroup="chequeGroup" />
                                                                                                            <asp:ImageButton ID="imgFecha4" runat="server" ImageUrl="~/Images/Calendar.png" />
																										 <asp:CheckBox ID="chkCP" runat="server" Text="Cheque de Pago" AutoPostBack="true" OnCheckedChanged="chkCP_CheckedChanged" Style="font-family: Verdana; font-size: 9px;" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblFechaEmision" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Fecha Emisión" EnableViewState="False"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtFechaEmision" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                ValidationGroup="chequeGroup" Width="83px" TabIndex="7"></asp:TextBox><ajaxToolkit:CalendarExtender
                                                                                                                    ID="txtFechaEmision_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                                                                    PopupButtonID="imgFecha3" TargetControlID="txtFechaEmision">
                                                                                                                </ajaxToolkit:CalendarExtender>
                                                                                                            <ajaxToolkit:MaskedEditExtender ID="txtFechaEmision_MaskedEditExtender" runat="server"
                                                                                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                                                CultureTimePlaceholder="" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999"
                                                                                                                MaskType="Date" TargetControlID="txtFechaEmision">
                                                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="txtFechaEmision_MaskedEditExtender"
                                                                                                                ControlToValidate="txtFechaEmision" Display="None" EmptyValueMessage="El campo Fecha Emisión no puede esta vacío"
                                                                                                                ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                                                                ValidationGroup="chequeGroup" />
                                                                                                            <asp:ImageButton ID="imgFecha3" runat="server" ImageUrl="~/Images/Calendar.png" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblBanco" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Banco" EnableViewState="False"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtBanco" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                ValidationGroup="chequeGroup" Width="83px" MaxLength="20" TabIndex="8"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorBanco" runat="server" ControlToValidate="txtBanco"
                                                                                                                    ValidationGroup="chequeGroup" ErrorMessage="Ingrese el banco"></asp:RequiredFieldValidator>&#160;&#160;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblSucursal" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Sucursal"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtSucursal" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="20" TabIndex="9" ValidationGroup="chequeGroup" Width="83px"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorSucursal" runat="server" ControlToValidate="txtSucursal"
                                                                                                                    ErrorMessage="Ingrese la sucursal" ValidationGroup="chequeGroup"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblCuitEmisor" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Cuit" EnableViewState="False"></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtCuitEmisor" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                Width="83px" MaxLength="20" AutoPostBack="True" OnPreRender="txtCuitEmisor_PreRender"
                                                                                                                OnTextChanged="txtCuitEmisor_TextChanged1" TabIndex="10"></asp:TextBox>&#160;&#160;<asp:LinkButton
                                                                                                                    ID="linkButtonCuit" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                    Width="150px" CausesValidation="False" OnClick="linkButtonCuit_Click">Cuit deudor</asp:LinkButton>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblCuenta" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Cuenta" EnableViewState="False"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtCuenta" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                ValidationGroup="chequeGroup" Width="83px" MaxLength="20" TabIndex="11"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCuenta" ValidationGroup="chequeGroup"
                                                                                                                    ErrorMessage="Ingrese la cuenta del cheque"></asp:RequiredFieldValidator>&#160;&#160;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblCp" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Código Postal" EnableViewState="False"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtCp" runat="server" CssClass="textboxEditor" Height="16px" ValidationGroup="chequeGroup"
                                                                                                                Width="83px" MaxLength="20" TabIndex="12"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorCp" runat="server" ControlToValidate="txtCp" ValidationGroup="chequeGroup"
                                                                                                                    ErrorMessage="Ingrese el código Postal"></asp:RequiredFieldValidator>&#160;&#160;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="2">
                                                                                                            <table style="width: 100%;">
                                                                                                                <tr>
                                                                                                                    <td align="right" style="width: 94%;">
                                                                                                                        <asp:Label ID="lblActivarLectora" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                            Text="Reactivar Lectora" EnableViewState="False"></asp:Label>
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:ImageButton ID="imgBtnLectora" runat="server" CausesValidation="False" Height="24px"
                                                                                                                            ImageUrl="~/Images/lectoraCheque.jpg" OnClick="imgBtnLectora_Click" OnClientClick="javascript:alert('La activación del dispositivo fué realizado con éxito.');"
                                                                                                                            Width="28px" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="right" style="width: 94%;">
                                                                                                                        <asp:Label ID="lblChequesDetalle" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                            Text="Ver detalle cheques" EnableViewState="False"></asp:Label>
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:ImageButton ID="imgBtnCheques" runat="server" CausesValidation="False" Height="24px"
                                                                                                                            ImageUrl="~/Images/detalleCheques.jpg" OnClick="VerDetalleCheques" Width="28px" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ContentTemplate>
                                                                                        </ajaxToolkit:TabPanel>
                                                                                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="Retencion" Enabled="true"
                                                                                            Visible="true">
                                                                                            <HeaderTemplate>
                                                                                                Reten.</HeaderTemplate>
                                                                                            <ContentTemplate>
                                                                                                <asp:UpdatePanel runat="server" ID="UpdatePanelSubtipoRetencion" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <table style="margin-top: 15px;">
                                                                                                            <tr>
                                                                                                                <td align="left">
                                                                                                                    <asp:Label ID="lblSubtipoRetencion" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                        Text="Concepto"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="cmbRetenciones" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                        BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                        DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="16px"
                                                                                                                        MaxLength="0" Width="177px" OnSelectedIndexChanged="cmbRetenciones_SelectedIndexChanged"
                                                                                                                        AutoPostBack="True">
                                                                                                                        <asp:ListItem>Retencion de Iva</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left">
                                                                                                                    <asp:Label ID="lblSubtipo" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                        Text="Subtipo"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="ddlSubTipo" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                        BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                        DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="16px"
                                                                                                                        MaxLength="0" Width="177px">
                                                                                                                        <asp:ListItem>Retencion de Iva</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblNumeroRetencion" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                        Text="N° Retencion"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtNumeroRetencion" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                        MaxLength="15" ValidationGroup="retencionesGroup" Width="83px"></asp:TextBox>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNumeroRetencion"
                                                                                                                        ErrorMessage="Ingrese el número de retención" ValidationGroup="retencionesGroup"></asp:RequiredFieldValidator>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblImporteRetencion" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                        Text="Importe"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtImporteRetencion" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                        Width="83px" MaxLength="15" ValidationGroup="retencionesGroup"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtImporteRetencion"
                                                                                                                            ErrorMessage="Ingrese el importe de la retención" ValidationGroup="retencionesGroup"></asp:RequiredFieldValidator>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="lblFechaRetencion" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                        Text="Fecha Retención"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtFechaRetencion" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                        ValidationGroup="retencionGroup" Width="83px" TabIndex="13"></asp:TextBox>
                                                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True"
                                                                                                                        Format="dd/MM/yyyy" PopupButtonID="ImageButtonRet" TargetControlID="txtFechaRetencion">
                                                                                                                    </ajaxToolkit:CalendarExtender>
                                                                                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                                                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                                                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaRetencion">
                                                                                                                    </ajaxToolkit:MaskedEditExtender>
                                                                                                                    <asp:ImageButton ID="ImageButtonRet" runat="server" ImageUrl="~/Images/Calendar.png" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                            </ContentTemplate>
                                                                                        </ajaxToolkit:TabPanel>
                                                                                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel3" HeaderText="Efectivo" Enabled="true"
                                                                                            Visible="true">
                                                                                            <HeaderTemplate>
                                                                                                Efectivo</HeaderTemplate>
                                                                                            <ContentTemplate>
                                                                                                <table style="margin-top: 15px;">
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblImporteEfectivo" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Importe: "></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtImporteEfectivo" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                Width="83px" MaxLength="15" ValidationGroup="efectivosGroup"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator8" runat="server" ErrorMessage="Ingrese el importe"
                                                                                                                    ValidationGroup="efectivosGroup" ControlToValidate="txtImporteEfectivo"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblFechaPagoEfectivo" runat="server" Style="font-family: Verdana;
                                                                                                                font-size: 9px;" Text="Fecha Pago"></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtFechaPagoEfectivo" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                TabIndex="14" ValidationGroup="efectivoGroup" Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender
                                                                                                                    ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="ImgFechaEfectivo"
                                                                                                                    TargetControlID="txtFechaPagoEfectivo">
                                                                                                                </ajaxToolkit:CalendarExtender>
                                                                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                                                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaPagoEfectivo">
                                                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidatorr4" runat="server" ControlExtender="MaskedEditExtender1"
                                                                                                                ControlToValidate="txtFechaPagoEfectivo" Display="None" EmptyValueMessage="El campo Fecha no puede estar vacío"
                                                                                                                ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                                                                ValidationGroup="efectivoGroup" /><asp:ImageButton ID="ImgFechaEfectivo" runat="server"
                                                                                                                    ImageUrl="~/Images/Calendar.png" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ContentTemplate>
                                                                                        </ajaxToolkit:TabPanel>
                                                                                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel4" HeaderText="Deposito" Enabled="true"
                                                                                            Visible="true">
                                                                                            <HeaderTemplate>
                                                                                                Deposito</HeaderTemplate>
                                                                                            <ContentTemplate>
                                                                                                <table style="margin-top: 15px;">
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblCuentaDeudor" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Cuenta"></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList ID="cmbCuentasClientes" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="16px"
                                                                                                                MaxLength="0" Width="177px">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblSucursalDeposito" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Sucursal"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtSucursalDeposito" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="20" TabIndex="15" ValidationGroup="depositosGroup" Width="83px"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSucursalDeposito"
                                                                                                                    ErrorMessage="Ingrese la sucursal" ValidationGroup="depositosGroup"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            &#160;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblFechaDeposito" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Fecha"></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtFechaDeposito" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                TabIndex="16" ValidationGroup="depositosGroup" Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender
                                                                                                                    ID="CalendarExtenderFechaDeposito" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                                                                    PopupButtonID="ImgFechaDeposito" TargetControlID="txtFechaDeposito">
                                                                                                                </ajaxToolkit:CalendarExtender>
                                                                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaDeposito" runat="server"
                                                                                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                                                CultureTimePlaceholder="" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999"
                                                                                                                MaskType="Date" TargetControlID="txtFechaDeposito">
                                                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidatorFechaDeposito" runat="server"
                                                                                                                ControlExtender="MaskedEditExtenderFechaDeposito" ControlToValidate="txtFechaDeposito"
                                                                                                                Display="None" EmptyValueMessage="El campo Fecha de depósito no puede estar vacío"
                                                                                                                ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                                                                ValidationGroup="depositosGroup" /><asp:ImageButton ID="ImgFechaDeposito" runat="server"
                                                                                                                    ImageUrl="~/Images/Calendar.png" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblNumComprobante" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="N° Comprobante: "></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtNumComprob" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="15" Width="83px" ValidationGroup="depositosGroup"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNumComprob"
                                                                                                                    ErrorMessage="Ingrese el n° de comprobante" ValidationGroup="depositosGroup"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblImporteDeposito" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Importe "></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtImporteDeposito" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="15" ValidationGroup="depositosGroup" Width="83px"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtImporteDeposito"
                                                                                                                    ErrorMessage="Ingrese el importe" ValidationGroup="depositosGroup"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ContentTemplate>
                                                                                        </ajaxToolkit:TabPanel>
                                                                                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel5" HeaderText="Transferencia" Enabled="true"
                                                                                            Visible="true">
                                                                                            <HeaderTemplate>
                                                                                                Transf.</HeaderTemplate>
                                                                                            <ContentTemplate>
                                                                                                <table style="margin-top: 15px;">
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblCuentaCredito" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Cuenta Crédito"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:DropDownList ID="cmbCuentaCredito" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="16px"
                                                                                                                MaxLength="0" Width="177px" ValidationGroup="transferenciasGroup">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblCuentaDebito" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Cuenta Débito"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left">
                                                                                                            <asp:TextBox ID="txtCuentaDebito" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="20" TabIndex="17" ValidationGroup="transferenciasGroup" Width="83px"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorCuentaDebito" runat="server" ControlToValidate="txtCuentaDebito"
                                                                                                                    ErrorMessage="Ingrese la cuenta débito" ValidationGroup="transferenciasGroup"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblFechaTransferencia" runat="server" Style="font-family: Verdana;
                                                                                                                font-size: 9px;" Text="Fecha Depósito"></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtFechaTransferencia" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                TabIndex="18" ValidationGroup="transferenciasGroup" Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender
                                                                                                                    ID="CalendarExtenderFechaTrans" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                                                                    PopupButtonID="ImgFechaTransf" TargetControlID="txtFechaTransferencia">
                                                                                                                </ajaxToolkit:CalendarExtender>
                                                                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFechaTrans" runat="server"
                                                                                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                                                CultureTimePlaceholder="" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999"
                                                                                                                MaskType="Date" TargetControlID="txtFechaTransferencia">
                                                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidatorFechaTrans" runat="server"
                                                                                                                ControlExtender="MaskedEditExtenderFechaTrans" ControlToValidate="txtFechaTransferencia"
                                                                                                                Display="None" EmptyValueMessage="El campo Fecha de transeferencia no puede estar vacío"
                                                                                                                ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                                                                ValidationGroup="transferenciasGroup" /><asp:ImageButton ID="ImgFechaTransf" runat="server"
                                                                                                                    ImageUrl="~/Images/Calendar.png" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                     <%-- <tr>
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
                                                                                                    </tr>--%>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblNumComprobTrans" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="N° Comprobante: "></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtNumComprobTrans" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="15" Width="83px" ValidationGroup="transferenciasGroup"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorNumTran" runat="server" ControlToValidate="txtNumComprobTrans"
                                                                                                                    ErrorMessage="Ingrese el n° de comprobante" ValidationGroup="transferenciasGroup"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="Label7" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Importe "></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtImporteTransferencia" runat="server" CssClass="textboxEditor"
                                                                                                                Height="16px" MaxLength="15" Width="83px" ValidationGroup="transferenciasGroup"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorImporteTransferencia" runat="server" ControlToValidate="txtImporteTransferencia"
                                                                                                                    ErrorMessage="Ingrese el importe" ValidationGroup="transferenciasGroup"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ContentTemplate>
                                                                                        </ajaxToolkit:TabPanel>
                                                                                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel6" HeaderText="OtrosPagos" Enabled="true"
                                                                                            Visible="true">
                                                                                            <HeaderTemplate>
                                                                                                Otros Pagos</HeaderTemplate>
                                                                                            <ContentTemplate>
                                                                                                <table style="margin-top: 15px;">
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblTipoPagoRaro" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Tipo Pago"></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList ID="cmbTipoPagoRaro" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="16px"
                                                                                                                MaxLength="0" Width="177px">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblFechaPagoRaro" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Fecha Pago"></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtFechaPagoRaro" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                TabIndex="19" ValidationGroup="otrosPagosGroup" Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender
                                                                                                                    ID="CalendarExtenderOtros" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                                                                    PopupButtonID="ImgFechaRara" TargetControlID="txtFechaPagoRaro">
                                                                                                                </ajaxToolkit:CalendarExtender>
                                                                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderOtros" runat="server" CultureAMPMPlaceholder=""
                                                                                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaPagoRaro">
                                                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidatorOtros" runat="server" ControlExtender="MaskedEditExtenderOtros"
                                                                                                                ControlToValidate="txtFechaPagoRaro" Display="None" EmptyValueMessage="El campo Fecha Pago no puede estar vacío"
                                                                                                                ErrorMessage="Error en la fecha" InvalidValueMessage="Fecha invalida" IsValidEmpty="False"
                                                                                                                ValidationGroup="otrosPagosGroup" /><asp:ImageButton ID="ImgFechaRara" runat="server"
                                                                                                                    ImageUrl="~/Images/Calendar.png" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblNumCompRaro" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="N° Comprobante: "></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtNumCompRaro" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="15" Width="83px" ValidationGroup="otrosPagosGroup"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorNumCompRaro" runat="server" ControlToValidate="txtNumCompRaro"
                                                                                                                    ErrorMessage="Ingrese el n° de comprobante" ValidationGroup="otrosPagosGroup"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="lblImporteRaro" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Importe "></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtImporteRaro" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                MaxLength="15" ValidationGroup="otrosPagosGroup" Width="83px"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidatorImporteRaro" runat="server" ControlToValidate="txtImporteRaro"
                                                                                                                    ErrorMessage="Ingrese el importe" ValidationGroup="otrosPagosGroup"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ContentTemplate>
                                                                                        </ajaxToolkit:TabPanel>
                                                                                        <ajaxToolkit:TabPanel ID="TabPanel7" runat="server" HeaderText="TabPanel7">
                                                                                            <HeaderTemplate>
                                                                                                Desc.</HeaderTemplate>
                                                                                            <ContentTemplate>
                                                                                                <table style="margin-top: 15px;">
                                                                                                    <tr>
                                                                                                        <td align="left">
                                                                                                            <asp:Label ID="Label2" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Concepto"></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList ID="cmbDescuentos" runat="server" AutoCompleteMode="SuggestAppend"
                                                                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="16px"
                                                                                                                MaxLength="0" Width="177px">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblImporteDescuento" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                                                Text="Importe"></asp:Label>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtImporteDescuento" runat="server" CssClass="textboxEditor" Height="16px"
                                                                                                                Width="83px" MaxLength="15" ValidationGroup="descuentosGroup"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator7" runat="server" ErrorMessage="Ingrese el importe del descuento"
                                                                                                                    ControlToValidate="txtImporteDescuento" ValidationGroup="descuentosGroup"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ContentTemplate>
                                                                                        </ajaxToolkit:TabPanel>
                                                                                    </ajaxToolkit:TabContainer>
                                                                                </td>
                                                                            </tr>
                                                                          
                                                                                <tr>
                                                                                    <td>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td style="width: 75%;">
                                                                                                    <table style="width: 321px">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <ma:SecureButton ID="btnEditarPago" runat="server" CausesValidation="True" CssClass="button_back"
                                                                                                                    Height="20px" OnClick="btnEditarPago_Click" Text="Guardar Edicion de Pago" Width="95px" />
                                                                                                                <td>
                                                                                                                    <ma:SecureButton ID="btnCancelarEdicion" runat="server" CausesValidation="True" CssClass="button_back"
                                                                                                                        Height="20px" OnClick="btnCancelarEditarPago_Click" Text="Cancelar Edición de Pago"
                                                                                                                        Width="95px" />
                                                                                                                </td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>                                                                                                
                                                                                                <td align="left">
                                                                                                     
																							    <asp:CheckBox ID="chkPesificar" runat="server" Checked="false" Text="Moneda Extranjera" style="font-family:Verdana;font-size:9px;position:absolute;margin-left:-120px;" />
                                                                                                <asp:UpdatePanel runat="server" ID="updatePanelBtnAgregarPago" UpdateMode="Conditional">
                                                                                                <ContentTemplate>
                                                                                                    
                                                                                                    <ma:SecureButton ID="btnAgregarPago" runat="server" CausesValidation="True" CssClass="button_back"
                                                                                                        Height="20px" OnClick="btnAgregarPago_Click" TabIndex="20" Text="Agregar Valor"
                                                                                                        ValidationGroup="chequeGroup" Width="95px" />
                                                                                                        
                                                                                                        </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="height: 50px;">
                                                                                                    <asp:Panel ID="pnlPagosIngresados" runat="server" CssClass="scrollbar" Height="77px"
                                                                                                        ScrollBars="Vertical" Width="470px">
                                                                                                        <ma:XGridView ID="gvResultadosPagos" runat="server" AllowSorting="True" AutoGenerateColumns="False"
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
                                                                                                        </ma:XGridView>
                                                                                                    </asp:Panel>
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
                                                                <asp:Panel ID="pnlFacturas" runat="server" Height="365px" CssClass="scrollbar" 
                                                                    ScrollBars="Vertical" Width="492px">
                                                                    <asp:UpdatePanel runat="server" ID="updatePanelGvFacturas" UpdateMode="Conditional" >
                                                                        <ContentTemplate>
                                                                            <ma:XGridView ID="GvResultadosFacturas" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                BorderWidth="0px" DataKeyNames="idFactura" EmptyDataText="No se encontraron resultados"
                                                                                ExecutePageIndexChanging="False" OnFilling="GvResultadosFacturas_Filling" OnPreRender="GvResultadosFacturas_PreRender"
                                                                                OnRowEditing="GvResultadosFacturas_RowEditing" OnSorted="GvResultadosFacturas_Sorted" OnRowDataBound="GvResultadosFacturas_RowDataBound"
                                                                                Width="430px" OnSelectedIndexChanging="GvResultadosFacturas_SelectedIndexChanging">
                                                                                <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                                <Columns>
                                                                                    <asp:CommandField ButtonType="Image" EditImageUrl="~/Images/Lupa_chica.gif" HeaderText="Ver Historial"
                                                                                        ShowEditButton="True">
                                                                                        <HeaderStyle Font-Bold="True" />
                                                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                                    </asp:CommandField>
                                                                                    <asp:BoundField DataField="idFactura" HeaderText="id Factura" SortExpression="idFactura">
                                                                                        <HeaderStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="fechaVenc" HeaderText="Vencimiento" SortExpression="fechaVenc"
                                                                                        DataFormatString="{0:d/MM/yyyy}">
                                                                                        <HeaderStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="importe" HeaderText="Importe" SortExpression="importe" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:F4}" />
                                                                                    <asp:BoundField DataField="saldo" HeaderText="Saldo" SortExpression="saldo" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:F4}">
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
                                                                                            <asp:ImageButton ID="imgBtnObservacion" runat="server" CausesValidation="false" ImageUrl="~/Images/agregar.gif"
                                                                                                OnClientClick="MostrarPanelObservaciones()" />
                                                                                            <asp:TextBox ID="txtObs" runat="server" CssClass="textboxEditor" Height="12" Visible="false"
                                                                                                Width="52"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:CommandField ButtonType="Button" HeaderText="Pronto"  ControlStyle-Width="48"  ShowSelectButton="True"
                                                                                        SelectText="Aplicar" ControlStyle-CssClass="button_back"/>
                                                                                    <asp:TemplateField HeaderText="Seleccionar">
                                                                                        <ItemTemplate>
                                                                                            <!--<input id="Checkbox1" type="checkbox" onclick="javascript:alert('sssss');"/>-->
                                                                                            <asp:CheckBox ID="chk" runat="Server" />
                                                                                        </ItemTemplate>
                                                                                        <HeaderTemplate>
                                                                                            <asp:CheckBox ID="chkAll" runat="Server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
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
                                                                </asp:Panel>
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblResultadoCantFacts" runat="server" Style="font-family: Verdana;
                                                                                font-size: 9px;" Text="Cantidad de Facturas: " EnableViewState="False"></asp:Label>
                                                                            <asp:Label ID="lblResResultadoCantFacts" runat="server" Style="font-family: Verdana;
                                                                                font-size: 9px;" EnableViewState="False"></asp:Label>
                                                                            <br />
                                                                            <asp:Label ID="lblAplicaProntoPago" runat="server" ForeColor="#009900" Style="font-family: Verdana;
                                                                                font-size: 9px;"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style7" style="border-style: groove groove outset outset; border-bottom-color: #FFFFFF;
                                                                border-right-color: #C0C0C0; border-width: thin 2px 2px 1px; border-spacing: 2px;
                                                                border-collapse: collapse;" align="left">
                                                                                                                                
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
                                                            </td>
                                                            <td style="border-style: groove groove outset outset; border-bottom-color: #FFFFFF;
                                                                border-right-color: #C0C0C0; border-width: thin 2px 2px 1px; border-spacing: 2px;
                                                                border-collapse: collapse">
                                                               <!-- <asp:Label ID="lblImportesSeleccionados" runat="server" Style="font-family: Verdana;
                                                                    font-size: 10px; font-weight: bold;" Text="Imputado: " 
                                                                    EnableViewState="False"></asp:Label>-->
                                                                &nbsp;
                                                                <asp:UpdatePanel ID="UpdatePanelResultados" runat="server" UpdateMode="Conditional">
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="btnGuardarRecibo" />
                                                                    </Triggers>
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="Label8" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                            font-weight: bold;" Text="Imputado Mon. Loc.: ">
                                                                        </asp:Label>
                                                                        <asp:TextBox ID="txtSumaFacturas" runat="server" AutoPostBack="True" BackColor="#CCCCCC"
                                                                            CssClass="textboxEditor" Height="16px"
                                                                            ReadOnly="True" Width="113px"></asp:TextBox>
                                                                            <asp:Label ID="Label9" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                            font-weight: bold;" Text="Imputado Mon. Ext.: " Visible="false">
                                                                        </asp:Label>
                                                                            <asp:TextBox ID="txtSumaFacturasExt" runat="server" AutoPostBack="True" BackColor="#CCCCCC"
                                                                            CssClass="textboxEditor" Height="16px"
                                                                            ReadOnly="True" Width="113px" Visible="false"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>                                                            
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblDiferenciaPe" runat="server" Text="Diferencia Mon. Loc." Style="font-family: Verdana; font-size: 10px;font-weight:bold"></asp:Label>
                                                                            <asp:TextBox ID="txtDiferenciaPe" runat="server" ReadOnly="true" CssClass="textboxEditor" Width="74px"></asp:TextBox>
                                                                            <asp:Label ID="lblDiferenciaDo" runat="server" Text="Diferencia Mon. Ext." Style="font-family: Verdana; font-size: 10px;font-weight:bold" Visible="false"></asp:Label>
                                                                            <asp:TextBox ID="txtDiferenciaDo" runat="server" ReadOnly="true" CssClass="textboxEditor" Width="74px" Visible="false"></asp:TextBox>
                                                                        </td>                                                                        
                                                                    </tr>
                                                                </table>                                                            
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table width="100%">
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
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="right">
                                                                            &nbsp; &nbsp;&nbsp;
                                                                            <ma:SecureButton ID="btnCrearRemision" runat="server" CssClass="button_back3" Height="20px"
                                                                                OnClick="btnCrearRemision_Click" Text="Cerrar Remisión Definitivamente" 
                                                                                Width="147px" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                </ContentTemplate>
                             
                            </asp:UpdatePanel>
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
            width: 510px;
        }
        .style8
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
            width: 510px;
        }
    </style>
</asp:Content>
