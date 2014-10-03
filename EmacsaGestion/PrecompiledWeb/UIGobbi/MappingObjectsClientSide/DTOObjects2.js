//Variable globales

var idPago=1;

function Cheque()
{
   this.importe=0;
   this.numCheque=0;
   this.vencimiento='';
   this.fechaEmision='';
   this.banco='';
   this.sucursal='';
   this.cuit='';
   this.cuenta='';
   this.cp='';
   
}

Cheque.prototype.AsignarControlToObject=function(tipoPago)
{
 var tipoPagoC;
 var hdPagosCargados;
 
 var panelGeneral=document.getElementById('ctl00_Contentplaceholder1_panelGeneralCuerpoPagina');
 if (panelGeneral.disabled==true)
 {
   return;
 }
 
 var chkMoneda = document.getElementById('ctl00_Contentplaceholder1_chkPestreificar');
 if (chkMoneda.checked)idPagoString='DOLARES';
 if (!chkMoneda.checked)idPagoString='PESOS';
 
 



    switch (tipoPago)
    {

         case 0:
                 if (Page_ClientValidate('chequeGroup')==true)
                 {  
                           if (!confirm("¿Verificó si el cheque tiene firma?"))
                             return;
                         this.importe=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtImporte');
                         this.numCheque=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtCheque');
                         this.vencimiento=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtFechaVencimiento');
                         this.fechaEmision=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtFechaEmision');
                         this.banco=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtBanco');
                         this.sucursal=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtSucursal');
                         this.cuit=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtCuitEmisor');
                         this.cuenta=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtCuenta');
                         this.cp=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtCp');

                         var fecEmision=new Date(this.fechaEmision.value.substring(6,10),this.fechaEmision.value.substring(3,5),this.fechaEmision.value.substring(0,2));
                         var venci=new Date(this.vencimiento.value.substring(6,10),this.vencimiento.value.substring(3,5),this.vencimiento.value.substring(0,2));
                         
                         var mes=venci.getMonth()-1;
                         var dia=venci.getDate();
                         var anio=venci.getYear();
                         var venciNew=new Date(anio,mes,dia);
                         
                         mes=fecEmision.getMonth()-1;
                         dia=fecEmision.getDate();
                         anio=fecEmision.getYear();
                         var fecEmisionNew=new Date(anio,mes,dia);
//                         alert(fecEmision);
//                         alert(venciNew);
//                         if (venciNew<=fecEmision)
//                         {
//                            alert('La fecha de vencimiento debe ser mayor a la fecha de emisión');
//                            return;
//                         }
                         
                         hoy= new Date();
                         tiempo=hoy.getTime();
                         var fecha1=venciNew.getTime();
                         var fecha2=tiempo;
                         var fechaEmi=fecEmisionNew.getTime();
                         
                         fecha1=fecha1/86400000;
                         fecha2=fecha2/86400000;
                         fechaEmi=fechaEmi/86400000;   
                         
                         fechaRes=fecha1-fecha2;
                         if (fechaRes<0) fechaRes=fechaRes*-1;
                         if (fechaRes>31)
                         {
                                if(!confirm("La fecha de vencimiento del cheque tiene más de 30 días al día de la fecha. ¿Desea continuar?")) 
                                  { 
                                    return true;
                                  }
                        }
                        
                         fechaRes=fecha1-fechaEmi;
                         if (fechaRes<0) fechaRes=fechaRes*-1;
                         if (fechaRes>365)
                         {
                                alert("No se puede poner Fecha de Cheques, con más de 365 días entre Fecha Emisión y Fecha Vencimiento.");
                                return false;
                         }

                        
                        
                         hdUltimoPagoCargado=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldUltimoPagoCargado');
                         hdUltimoPagoCargado.value="";
                         hdPagosCargados=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldPagosCargados');
                
                         tipoPagoC='[CHEQUE]';
                         
                         hdUltimoPagoCargado.value = idPagoString + ';' + tipoPagoC + ';importe=' +  this.importe.value.replace(',','').replace('.',',') + ';cheque=' + this.numCheque.value  + ';fechaVencimiento=' + this.vencimiento.value  + ';fechaEmision=' + this.fechaEmision.value  + ';banco=' + this.banco.value  + ';sucursal=' + this.sucursal.value  + ';cuitEmisor=' + this.cuit.value  + ';cuenta=' + this.cuenta.value  + ';cp=' + this.cp.value  + ';totalPesificado=' + PesificarImporte2(this.importe.value,idPagoString).replace(',','').replace('.',',') +';@';
                         hdPagosCargados.value=hdPagosCargados.value + hdUltimoPagoCargado.value;
                         //CargarPagoAGrilla(hdUltimoPagoCargado.value,idPagoString);
                         AsignarHiddenFieldATabla();
                        // ActualizarSumaPagos(ObtenerValorDeAtributo(hdUltimoPagoCargado.value,'importe'));
                         ActualizarDiferenciaPagosFacturas();
                         this.importe.value='';
                         this.numCheque.value='';
                         this.vencimiento.value='';
                         this.fechaEmision.value='';
                         this.banco.value='';
                         this.sucursal.value='';
                         this.cuit.value='';
                         this.cuenta.value='';
                         this.cp.value='';
                         chkMoneda.checked=false;
                }       
         break;
         
         case 1:
                 if (Page_ClientValidate('retencionesGroup')==true)
                 {  
                 
                         var txtNumeroRetencion=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_txtNumeroRetencion');
                         var txtImporteRetencion=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_txtImporteRetencion');
                          if (chkMoneda.checked)
                         {
                             var txtCambio=document.getElementById('ctl00_Contentplaceholder1_txtCambio');
                             txtImporteRetencion.value=txtCambio.value*txtImporteRetencion.value;
                         }    
                         var ddlRetenciones=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_cmbRetenciones');
                         var ddlSubTipo=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_ddlSubTipo');                      
                         var txtFechaRetencion=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_txtFechaRetencion');                      
                         
                         hdUltimoPagoCargado=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldUltimoPagoCargado');
                         hdPagosCargados=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldPagosCargados');
                         tipoPagoC='[RETENCION]';
                         hdUltimoPagoCargado.value = idPagoString + ';' + tipoPagoC + ';concepto=' +  ddlRetenciones.value + ';subtipo=' + ddlSubTipo.value  + ';numeroRetencion=' + txtNumeroRetencion.value  + ';importe=' + txtImporteRetencion.value.replace(',','').replace('.',',')  + ';fechaRetencion=' + txtFechaRetencion.value  +';totalPesificado=' + PesificarImporte2(txtImporteRetencion.value,idPagoString).replace(',','').replace('.',',') +';@';
                         hdPagosCargados.value=hdPagosCargados.value + hdUltimoPagoCargado.value;
                         AsignarHiddenFieldATabla();
                         ActualizarDiferenciaPagosFacturas();
                         txtNumeroRetencion.value='';
                         txtImporteRetencion.value='';
                         ddlRetenciones.selectedIndex=0;
                         //ddlSubTipo.selectedIndex=1;
                         ddlSubTipo.selectedIndex=0;
                         txtFechaRetencion.value='';
                         chkMoneda.checked=false;
                 }       
         break;  
         
         case 2:
                 if (Page_ClientValidate('efectivosGroup')==true)
                 {  
                         var txtImporteEfectivo=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel3_txtImporteEfectivo');
                         var txtFechaPago=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel3_txtFechaPagoEfectivo');
                         if (chkMoneda.checked)
                         {
                             var txtCambio=document.getElementById('ctl00_Contentplaceholder1_txtCambio');
                             txtImporteEfectivo.value=txtCambio.value*txtImporteEfectivo.value;
                         }    
                         
                         hdUltimoPagoCargado=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldUltimoPagoCargado');
                         hdPagosCargados=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldPagosCargados');
                         tipoPagoC='[EFECTIVO]';
                         
                         
                         hdUltimoPagoCargado.value = idPagoString + ';' + tipoPagoC + ';importe=' +  txtImporteEfectivo.value.replace(',','').replace('.',',') + ';fechaPago=' + txtFechaPago.value  + ';totalPesificado=' + PesificarImporte2(txtImporteEfectivo.value,idPagoString).replace(',','').replace('.',',') +';@';
                         hdPagosCargados.value=hdPagosCargados.value + hdUltimoPagoCargado.value;
                         AsignarHiddenFieldATabla();
                         ActualizarDiferenciaPagosFacturas();   
                         txtImporteEfectivo.value='';
                         txtFechaPago.value='';
                         chkMoneda.checked=false;
                        
                }       
         break;    
         
         case 3:
                 if (Page_ClientValidate('depositosGroup')==true)
                 {  
                         var ddlCuenta=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel4_cmbCuentasClientes');
                         var txtSucursal=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel4_txtSucursalDeposito');
                         var txtFechaDeposito=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel4_txtFechaDeposito');
                         var txtNumComprobante=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel4_txtNumComprob');                      
                         var txtImporteDeposito=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel4_txtImporteDeposito');                      
                          if (chkMoneda.checked)
                         {
                             var txtCambio=document.getElementById('ctl00_Contentplaceholder1_txtCambio');
                             txtImporteDeposito.value=txtCambio.value*txtImporteDeposito.value;
                         }    
                         hdUltimoPagoCargado=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldUltimoPagoCargado');
                         hdPagosCargados=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldPagosCargados');
                         tipoPagoC='[DEPOSITO]';
                         
                         hdUltimoPagoCargado.value = idPagoString + ';' + tipoPagoC + ';cuenta=' +  ddlCuenta.value + ';sucursal=' + txtSucursal.value  + ';fechaDeposito=' + txtFechaDeposito.value + ';importe=' + txtImporteDeposito.value.replace(',','').replace('.',',') + ';numComprobante=' + txtNumComprobante.value +';totalPesificado=' + PesificarImporte2(txtImporteDeposito.value,idPagoString).replace(',','').replace('.',',') +';@';
                         hdPagosCargados.value=hdPagosCargados.value + hdUltimoPagoCargado.value;
                         AsignarHiddenFieldATabla();
                         ActualizarDiferenciaPagosFacturas();   
                         txtSucursal.value='';
                         txtFechaDeposito.value='';
                         ddlCuenta.selectedIndex=0;
                         txtNumComprobante.value='';
                         txtImporteDeposito.value='';
                         chkMoneda.checked=false;
                }       
         break;         
         
          case 4:
                 if (Page_ClientValidate('transferenciasGroup')==true)
                 {  
                         var ddlCuentaCredito=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel5_cmbCuentaCredito');
                         var txtCuentaDebito=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel5_txtCuentaDebito');
                         var txtFechaTransferencia=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel5_txtFechaTransferencia');
                         var txtNumComprobante=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel5_txtNumComprobTrans');                      
                         var txtImporteTransferencia=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel5_txtImporteTransferencia');                      
                          if (chkMoneda.checked)
                         {
                             var txtCambio=document.getElementById('ctl00_Contentplaceholder1_txtCambio');
                             txtImporteTransferencia.value=txtCambio.value*txtImporteTransferencia.value;
                         }    
                         hdUltimoPagoCargado=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldUltimoPagoCargado');
                         hdPagosCargados=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldPagosCargados');
                         tipoPagoC='[TRANSFERENCIA]';
                         
                         hdUltimoPagoCargado.value = idPagoString + ';' + tipoPagoC + ';cuentaCredito=' +  ddlCuentaCredito.value + ';cuentaDebito=' + txtCuentaDebito.value  + ';fechaTransferencia=' + txtFechaTransferencia.value  + ';importe=' + txtImporteTransferencia.value.replace(',','').replace('.',',') +';numComprobante=' + txtNumComprobante.value  + ';totalPesificado=' + PesificarImporte2(txtImporteTransferencia.value,idPagoString).replace(',','').replace('.',',') +';@';
                         hdPagosCargados.value=hdPagosCargados.value + hdUltimoPagoCargado.value;
                         AsignarHiddenFieldATabla();
                         ActualizarDiferenciaPagosFacturas();   
                         txtCuentaDebito.value='';
                         txtFechaTransferencia.value='';
                         ddlCuentaCredito.selectedIndex=0;
                         txtNumComprobante.value='';
                         txtImporteTransferencia.value='';
                         chkMoneda.checked=false;
                }       
         break;
         
            case 5:
                 if (Page_ClientValidate('otrosPagosGroup')==true)
                 {  
                         var ddlTipoPago=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel6_cmbTipoPagoRaro');
                         var txtFechaPago=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel6_txtFechaPagoRaro');
                         var txtNumComprobante=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel6_txtNumCompRaro');                      
                         var txtImporteRaro=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel6_txtImporteRaro');                      
                          if (chkMoneda.checked)
                         {
                             var txtCambio=document.getElementById('ctl00_Contentplaceholder1_txtCambio');
                             txtImporteRaro.value=txtCambio.value*txtImporteRaro.value;
                         }    
                         hdUltimoPagoCargado=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldUltimoPagoCargado');
                         hdPagosCargados=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldPagosCargados');
                         tipoPagoC='[OTROPAGO]';
                         
                         hdUltimoPagoCargado.value = idPagoString + ';' + tipoPagoC + ';tipoPago=' +  ddlTipoPago.value + ';fechaPago=' + txtFechaPago.value  + ';importe=' + txtImporteRaro.value.replace(',','').replace('.',',') + ';txtNumComprobante=' + txtNumComprobante.value    + ';totalPesificado=' + PesificarImporte2(txtImporteRaro.value,idPagoString).replace(',','').replace('.',',')+';@';
                         hdPagosCargados.value=hdPagosCargados.value + hdUltimoPagoCargado.value;
                         AsignarHiddenFieldATabla();
                         ActualizarDiferenciaPagosFacturas();   
                         txtFechaPago.value='';
                         txtNumComprobante.value='';
                         ddlTipoPago.selectedIndex=0;
                         txtImporteRaro.value='';
                         chkMoneda.checked=false;
                }       
         break;   
         
          case 6:
                 if (Page_ClientValidate('descuentosGroup')==true)
                 {  
                         var ddlConcepto=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel7_cmbDescuentos');
                         var txtImporte=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel7_txtImporteDescuento');
                           if (chkMoneda.checked)
                         {
                             var txtCambio=document.getElementById('ctl00_Contentplaceholder1_txtCambio');
                             txtImporte.value=txtCambio.value*txtImporte.value;
                         }    
                         hdUltimoPagoCargado=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldUltimoPagoCargado');
                         hdPagosCargados=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldPagosCargados');
                         tipoPagoC='[DESCUENTO]';
                         
                         hdUltimoPagoCargado.value = idPagoString + ';' + tipoPagoC + ';importe=' + txtImporte.value.replace(',','').replace('.',',') +';concepto=' +  ddlConcepto.value + ';totalPesificado=' + PesificarImporte2(txtImporte.value,idPagoString).replace(',','').replace('.',',')+';@';
                         hdPagosCargados.value=hdPagosCargados.value + hdUltimoPagoCargado.value;
                         AsignarHiddenFieldATabla();
                         ddlConcepto.selectedIndex=0;
                         txtImporte.value='';
                         ActualizarDiferenciaPagosFacturas();
                         chkMoneda.checked=false;
                }       
         break;               

    }
    FocusInFirstControle();
}


function CargarPagoAGrilla(TablaAModificar,nuevoPago,idPago)
{
     var Tabla = document.getElementById('gvResultadosPagosLight');
     var countRows=Tabla.rows;
     var lastRow = Tabla.rows.length;

    // INSERTAR FILA
    var row = Tabla.insertRow(lastRow);
    row.className="gvItem";

    //INSERTAR CELDA
    var cell1 = row.insertCell(0);
    var textNode1 = document.createTextNode(lastRow);
    cell1.appendChild(textNode1);

    var cell2 = row.insertCell(1);
    var textNode2 = document.createTextNode(nuevoPago.split(";")[1]);
    cell2.appendChild(textNode2);

    var tipoP= "\'" + cell2.innerText + "\'";
    var cell3 = row.insertCell(2);

    var textNode3;

    if (nuevoPago.split(";")[0]=='DOLARES')
    {

      textNode3 = document.createTextNode('DOLARES');
    }
    else
    {

      textNode3 = document.createTextNode('PESOS');
    }
    cell3.appendChild(textNode3);

     var moneda= "\'" + cell3.innerText + "\'";

    var cell4 = row.insertCell(3);
    var textNode4 = document.createTextNode(ObtenerValorDeAtributo(nuevoPago,'importe'));
    cell4.appendChild(textNode4);

    var cell5 = row.insertCell(4);
    var textNode5= document.createElement('a');
    var href=document.createAttribute('href');
    textNode5.setAttribute('href','javascript:EliminarPago(['+ idPago + ']);');
    textNode5.innerText='Eliminar';
    cell5.appendChild(textNode5);


        var cell6 = row.insertCell(5);
        var textNode6=document.createElement('a');
        var href2 = document.createAttribute('href');
        textNode6.setAttribute('href','javascript:EditarPago(['+ idPago + '],' + tipoP + ','+ moneda +');');
        textNode6.innerText='Editar';
        cell6.appendChild(textNode6);

        if (cell2.innerText!='[CHEQUE]')
                          cell6.style.visibility='hidden';

    //Gato
  
}


function ObtenerValorDeAtributo(cadena,nombreAtributo)
{
var arregloCadena=cadena.split(";");

for (var i = 0; i < arregloCadena.length; i++ )
{

 if (arregloCadena[i].indexOf(nombreAtributo)!=-1)
 {
   var valorAtributo=arregloCadena[i].substring(arregloCadena[i].indexOf("=")+1,arregloCadena[i].length);

    return valorAtributo;
 }
 
 
}

return 0;
}

function ActualizarSumaPagos(pago)
{
  var txtPagos=document.getElementById('ctl00_Contentplaceholder1_txtPagos'); 
  
  var suma=parseFloat(txtPagos.value) + parseFloat(pago);
  suma=suma.toFixed(4);
  txtPagos.value=suma;
  return;
}

function ActualizarDiferenciaPagosFacturas()
{
var txtSumaMonLoc = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturas');
                   
var txtPagos=document.getElementById('ctl00_Contentplaceholder1_txtPagos'); 
var DifPe = document.getElementById("ctl00_Contentplaceholder1_txtDiferenciaPe");
                
var fDifPe = parseFloat(txtPagos.value) - parseFloat(txtSumaMonLoc.value);
DifPe.value = fDifPe.toFixed(4).toString();


}


function ActualizarDiferenciaPagosFacturasPantallaEdicion()
{
var txtSumaMonLoc = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturas');
if (txtSumaMonLoc.value=='' ||  txtSumaMonLoc.value=='0')
                    txtSumaMonLoc.value="0.00";
                    
var txtPagos=document.getElementById('ctl00_Contentplaceholder1_txtPagos'); 
var DifPe = document.getElementById("ctl00_Contentplaceholder1_txtDiferenciaPe");
                
var fDifPe = parseFloat(txtPagos.value) - parseFloat(txtSumaMonLoc.value.replace(',','.')); 
DifPe.value = fDifPe.toFixed(4);


}


function PesificarImporte(importeExtranjero)
{
    var chkMoneda = document.getElementById('ctl00_Contentplaceholder1_chkPestreificar');
    var txtCambio = document.getElementById('ctl00_Contentplaceholder1_txtCambio');  
    var importePesificado;
    if (chkMoneda.checked)
    {
        var importePesificado=parseFloat(txtCambio.value) * parseFloat(importeExtranjero.value);
         importePesificado= importePesificado.toFixed(4);
        
         chkMoneda.checked=false;
        return importePesificado;
    }
    else
    {
      return importeExtranjero.value;
    }
}

function PesificarImporte2(importeExtranjero,idPagoString)
{
    var txtCambio = document.getElementById('ctl00_Contentplaceholder1_txtCambio');  
    var importePesificado;
    
    
    if (idPagoString=='DOLARES')
    {
         importePesificado=parseFloat(txtCambio.value) * parseFloat(importeExtranjero);
         importePesificado= importePesificado.toFixed(4);
         return importePesificado;
    
    }
    else
    {
    
       importePesificado=parseFloat(importeExtranjero);
       importePesificado= importePesificado.toFixed(4);
    
       return importePesificado;
    }
}

function EliminarPago(filaPago)
{
    var pagos=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldPagosCargados');
    
    var hdPagosCargadosArray;
    hdPagosCargadosArray=pagos.value.split("@");
    
    delete hdPagosCargadosArray[filaPago-1];
     pagos.value="";
      for (var i = 0; i < hdPagosCargadosArray.length; i++ )
          {
             if (hdPagosCargadosArray[i]!=undefined && hdPagosCargadosArray[i]!='')
             {
               pagos.value=pagos.value + hdPagosCargadosArray[i] + '@';
              }
           
          }
  AsignarHiddenFieldATabla();
  ActualizarDiferenciaPagosFacturas();
}

function EditarPago(filaPago,tipoPago,moneda)
{
    var pagos=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldPagosCargados');
    
    var hdPagosCargadosArray;
    hdPagosCargadosArray=pagos.value.split("@");
    var pago = hdPagosCargadosArray[filaPago-1];
    pagoArray=pago.split(";");
    var chkMoneda = document.getElementById('ctl00_Contentplaceholder1_chkPestreificar');
    switch (tipoPago)
    {

         case '[CHEQUE]':
                          this.importe=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtImporte');
                         this.numCheque=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtCheque');
                         this.vencimiento=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtFechaVencimiento');
                         this.fechaEmision=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtFechaEmision');
                         this.banco=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtBanco');
                         this.sucursal=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtSucursal');
                         this.cuit=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtCuitEmisor');
                         this.cuenta=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtCuenta');
                         this.cp=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtCp');

                          this.importe.value=ObtenerValorDeAtributo(pago,'importe').replace(',','.');
                          this.numCheque.value=ObtenerValorDeAtributo(pago,'cheque');
                          this.vencimiento.value=ObtenerValorDeAtributo(pago,'fechaVencimiento');
                          this.fechaEmision.value=ObtenerValorDeAtributo(pago,'fechaEmision');
                          this.banco.value=ObtenerValorDeAtributo(pago,'banco');
                          this.sucursal.value=ObtenerValorDeAtributo(pago,'sucursal');
                          this.cuit.value=ObtenerValorDeAtributo(pago,'cuitEmisor');
                          this.cuenta.value=ObtenerValorDeAtributo(pago,'cuenta');
                          this.cp.value=ObtenerValorDeAtributo(pago,'cp');
                          EliminarPago(filaPago);
                          if (moneda!='PESOS')
                                         chkMoneda.checked=true;

                   
         break; 
         
         
         }
//    delete hdPagosCargadosArray[filaPago-1];
//     pagos.value="";
//      for (var i = 0; i < hdPagosCargadosArray.length; i++ )
//          {
//             if (hdPagosCargadosArray[i]!=undefined && hdPagosCargadosArray[i]!='')
//             {
//               pagos.value=pagos.value + hdPagosCargadosArray[i] + '@';
//              }
//           
//          }
//  AsignarHiddenFieldATabla();
//  ActualizarDiferenciaPagosFacturas();
}


function EliminarFilaDeTablaPagos(numeroFila)
{
 var Tabla = document.getElementById('gvResultadosPagosLight');
 Tabla.deleteRow(numeroFila);

}

function BlanquearHiddenFieldPagosCargados()
{
 var hdPagosCargados=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldPagosCargados');
 hdPagosCargados.value='';
}

function AsignarHiddenFieldATabla()
{
    LimpiarTablaPagos();
    var hdPagosCargados1=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldPagosCargados');
    var Tabla = document.getElementById('gvResultadosPagosLight');
    var pagos=hdPagosCargados1.value.split("@");
    for (var i =0; i < pagos.length; i++ )
        {
        
              if (pagos[i]!="")
              {
              
                CargarPagoAGrilla(Tabla,pagos[i],i+1);
              }
        }
        RecalcularSumaPagos();
}

function LimpiarTablaPagos()
{
    var table = document.getElementById('gvResultadosPagosLight');
    for (var i=table.rows.length-1; i>0;i--)
    {
     table.deleteRow(i);
    }
}

function RecalcularSumaPagos()
{
    var table = document.getElementById('gvResultadosPagosLight');
    var txtPagos=document.getElementById('ctl00_Contentplaceholder1_txtPagos'); 
    var suma;
    suma=0;
    txtPagos.value=0;
    var importe;
    for (var i=table.rows.length-1; i>0;i--)
    {

        if (table.rows[i].cells[2].innerHTML=='PESOS')
        {
             suma=suma + parseFloat(table.rows[i].cells[3].innerHTML.replace(',','.'));
         }
         else
         {
  
            suma=suma + parseFloat(PesificarImporte2(table.rows[i].cells[3].innerHTML,'DOLARES').replace(',','.'));
         
         }    
        
    }
   
    suma=suma.toFixed(4);
    txtPagos.value=suma;
}

function ReCalcularSumaClientSide(value)
{
var txtSumaMonLoc = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturas');
txtSumaMonLoc.value=value;

}

function RecuperarEstadoDeGrillaFacturas()
{

var tablaFactura = document.getElementById('ctl00_Contentplaceholder1_GvResultadosFacturas');
var hdEstadoGrillaFacturas=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldEstadoGrillaFacturas');





}