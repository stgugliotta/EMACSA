//begin desabilitar teclas 
document.onkeydown = function(){  
//116->f5 
//122->f11 
if (window.event && (window.event.keyCode == 122 || window.event.keyCode == 116)){ 
window.event.keyCode = 505;  
} 

if (window.event.keyCode == 505){  
return false;  
}  

if (window.event && (window.event.keyCode == 8)) 
{ 
valor = document.activeElement.value; 
if (valor==undefined) { return false; } //Evita Back en página. 
else 
{ 
if (document.activeElement.getAttribute('type')=='select-one') 
    { return false; } //Evita Back en select. 
if (document.activeElement.getAttribute('type')=='button') 
    { return false; } //Evita Back en button. 
if (document.activeElement.getAttribute('type')=='radio') 
    { return false; } //Evita Back en radio. 
if (document.activeElement.getAttribute('type')=='checkbox') 
    { return false; } //Evita Back en checkbox. 
if (document.activeElement.getAttribute('type')=='file') 
    { return false; } //Evita Back en file. 
if (document.activeElement.getAttribute('type')=='reset') 
    { return false; } //Evita Back en reset. 
if (document.activeElement.getAttribute('type')=='submit') 
    { return false; } //Evita Back en submit. 
else //Text, textarea o password 
{ 
    if (document.activeElement.value.length==0) 
        { return false; } //No realiza el backspace(largo igual a 0). 
    else 
        { document.activeElement.value.keyCode = 8; } //Realiza el backspace. 
} 
} 
} 
} 
//end desabilitar teclas 
function GatoHabilita(objeto)
{
 var textBoxSeleccionado = objeto.id;  
 textboxAImputar = document.getElementById(textBoxSeleccionado.replace('chk','txtAImputarPorFactura'));
   if (objeto.checked)
    {
       textboxAImputar.disabled = true;
       }
       else
       {
       textboxAImputar.disabled = false;
       }
}

function SumarImporte(objeto,cont,valorReal,valorProntoPago,btnPPSeleccionado,saldo)
{
try{
    var myCheck;
    var myTextbox;
    var buttonProntoPago;
    var resultado;
    var suma;
    var textBoxSeleccionado = objeto.id;   
    var signo;
    
    valorReal=parseFloat(valorReal);
    txtSaldo=parseFloat(saldo);
     // Step1: Análisis Del importe de factura a considerar (con o sin pronto pago)

    textboxAImputar = document.getElementById(textBoxSeleccionado.replace('chk','txtAImputarPorFactura'));
    var idRemision=document.getElementById('ctl00_Contentplaceholder1_lblRemisionEnUso').innerHTML;    
    buttonProntoPago = document.getElementById(btnPPSeleccionado);
//    alert(idRemision); 
//    alert('bien a'); 
    if (idRemision=='')
    {
        alert('Debe crear la remisión antes de imputar una factura.');
       objeto.checked=false;
        return false;
    }
           
    if (objeto.checked)
    {
        if (textboxAImputar.value == ''  ||  isNaN(parseFloat(textboxAImputar.value)) || !ValidateEnteredValue(textboxAImputar.value)) 
        {
            objeto.checked=false;
            return false;
        }                 
               
        if (valorProntoPago != 0)
            valorReal = valorProntoPago;               
        importeFinal = textboxAImputar.value;
        importeFinal = importeFinal.split(",").join("");
                
                  
       if(parseFloat(importeFinal) > txtSaldo || parseFloat(importeFinal)==0)
        {
            alert('El valor que esta ingresando no es permitido');
            objeto.checked = false;
            return true;
        }
               
        signo = 1;
        textboxAImputar.disabled = true;
         
        buttonProntoPago.disabled = true;
        
    }
    else
    {
        signo = -1;
        textboxAImputar.disabled= true;
        textboxAImputar.disabled = false;
        buttonProntoPago.disabled = true;
        buttonProntoPago.disabled = false;
        
    }

    //Step1: FIN --------------------------------------------------------------------------------------------

    //Step2: INICIO - 

    var txtSumaMonLoc = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturas');
    // var txtSumaMonExt = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturasExt');        
    var txtCambio = document.getElementById('ctl00_Contentplaceholder1_txtCambio');     
                  
        
    var sumaMonLoc = txtSumaMonLoc.value;                  //Levanta el resultado actual de la suma
    //  sumaMonLoc = sumaMonLoc.replace(',','.');                     //Le da formato de flotante
    
    importeGrilla = textboxAImputar.value;                    //Levanta el importe de la grilla
    importeGrilla = importeGrilla.replace(',', '');    //Le da formato flotante
    
    //Define el cambio por si no está ingresado o si es 1,00
       var Fila = textboxAImputar.parentNode.parentNode;
    var celda = Fila.cells[5].innerHTML;
    var Cambio = 1.0000;
    if (txtCambio.value != "1,0000" && txtCambio.value != "" && celda != "PE")     //Si es distinto de dicho valor, pisa el valor de cambio
        Cambio = txtCambio.value;
   
    importeGrilla = parseFloat(importeGrilla) * signo;

    if (celda != "PE")//Agregado gato
    importeGrilla = importeGrilla * parseFloat(Cambio);   //Se Multiplica por el valor de cambio
    
    suma = parseFloat(sumaMonLoc) + parseFloat(importeGrilla); //Actualiza la suma 
    suma = suma.toFixed(4); //Formato de 4 decimales separados por un punto    
        
    txtSumaMonLoc.value = parseFloat(suma);    //Moneda local: Dividir por cambio
   
    //Diferencias:
    var DifPe = document.getElementById("ctl00_Contentplaceholder1_txtDiferenciaPe");
   
    var txtPagos = document.getElementById('ctl00_Contentplaceholder1_txtPagos');
                     
    var fDifPe = parseFloat(txtPagos.value) - parseFloat(txtSumaMonLoc.value);
    DifPe.value = fDifPe.toFixed(4);
}
catch(e)
{
  alert("JsHelper.js - SumarImporte. " + e.name + " - "+e.message);
}
      
}


function SumarSaldos(objeto,cont,valorReal)
{
try
{
    var myCheck;
    var myTextbox;
    var buttonProntoPago;
    var resultado;
    var suma;
    var textBoxSeleccionado = objeto.id;   
    var signo;
    
    valorReal=parseFloat(valorReal);

     // Step1: Análisis Del importe de factura a considerar (con o sin pronto pago)

    textboxAImputar = document.getElementById(textBoxSeleccionado.replace('chk','txtAImputarPorFactura'));
        
    buttonProntoPago = document.getElementById(btnPPSeleccionado);


    if (objeto.checked)
    {
        if (textboxAImputar.value == ''  ||  isNaN(parseFloat(textboxAImputar.value)) || !ValidateEnteredValue(textboxAImputar.value)) 
        {
            objeto.checked=false;
            return false;
        }                 
               
        if (valorProntoPago != 0)
            valorReal = valorProntoPago;               
        importeFinal = textboxAImputar.value;
        importeFinal = importeFinal.split(",").join("");
                
                  
       if(parseFloat(importeFinal) > valorReal || parseFloat(importeFinal)==0)
        {
            alert('El valor que esta ingresando no es permitido');
            objeto.checked = false;
            return true;
        }
               
        signo = 1;
        textboxAImputar.disabled = true;
         
        buttonProntoPago.disabled = true;
        
    }
    else
    {
        signo = -1;
        textboxAImputar.disabled= true;
        textboxAImputar.disabled = false;
        buttonProntoPago.disabled = true;
        buttonProntoPago.disabled = false;
        
    }

    //Step1: FIN --------------------------------------------------------------------------------------------

    //Step2: INICIO - 

    var txtSumaMonLoc = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturas');
    // var txtSumaMonExt = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturasExt');        
    var txtCambio = document.getElementById('ctl00_Contentplaceholder1_txtCambio');     
                  
        
    var sumaMonLoc = txtSumaMonLoc.value;                  //Levanta el resultado actual de la suma
    //  sumaMonLoc = sumaMonLoc.replace(',','.');                     //Le da formato de flotante
    
    importeGrilla = textboxAImputar.value;                    //Levanta el importe de la grilla
    importeGrilla = importeGrilla.replace(',', '');    //Le da formato flotante
    
    //Define el cambio por si no está ingresado o si es 1,00
       var Fila = textboxAImputar.parentNode.parentNode;
    var celda = Fila.cells[5].innerHTML;
    var Cambio = 1.0000;
    if (txtCambio.value != "1,0000" && txtCambio.value != "" && celda != "PE")     //Si es distinto de dicho valor, pisa el valor de cambio
        Cambio = txtCambio.value;
   
    importeGrilla = parseFloat(importeGrilla) * signo;

    if (celda != "PE")//Agregado gato
    importeGrilla = importeGrilla * parseFloat(Cambio);   //Se Multiplica por el valor de cambio
    
    suma = parseFloat(sumaMonLoc) + parseFloat(importeGrilla); //Actualiza la suma 
    suma = suma.toFixed(4); //Formato de 4 decimales separados por un punto    
        
    txtSumaMonLoc.value = parseFloat(suma);    //Moneda local: Dividir por cambio
   
    //Diferencias:
    var DifPe = document.getElementById("ctl00_Contentplaceholder1_txtDiferenciaPe");
   
    var txtPagos = document.getElementById('ctl00_Contentplaceholder1_txtPagos');
                     
    var fDifPe = parseFloat(txtPagos.value) - parseFloat(txtSumaMonLoc.value);
    DifPe.value = fDifPe.toFixed(4);
}
catch(e)
{
  alert("JsHelper.js - SumarImporte. " + e.name + " - "+e.message);
}
      
}





function BloquearFila(objeto,cont)
{
    var myCheck;
    var myTextbox;
    var buttonProntoPago;
    var resultado;
    var suma;
   // var textBoxSeleccionado = objeto.id;   
    var signo;
    alert('ok');
}




function SumarImporteEdicionRecibo(objeto,cont,valorReal,valorProntoPago,btnPPSeleccionado,saldo)
{
try
{
    var myCheck;
    var myTextbox;
    var buttonProntoPago;
    var resultado;
    var suma;
    var textBoxSeleccionado = objeto.id;   
    var signo;
    var txtSaldo;
    valorReal=parseFloat(valorReal);
    txtSaldo=parseFloat(saldo);
     // Step1: Análisis Del importe de factura a considerar (con o sin pronto pago)

    textboxAImputar = document.getElementById(textBoxSeleccionado.replace('chk','txtAImputarPorFactura'));
        
    buttonProntoPago = document.getElementById(btnPPSeleccionado);


    if (objeto.checked)
    {
        if (textboxAImputar.value == ''  ||  isNaN(parseFloat(textboxAImputar.value)) || !ValidateEnteredValue(textboxAImputar.value)) 
        {
            objeto.checked=false;
            return false;
        }                 
               
        if (valorProntoPago != 0)
            valorReal = valorProntoPago;               
        importeFinal = textboxAImputar.value;
        importeFinal = importeFinal.split(",").join("");
                
                  
       if(parseFloat(importeFinal) > txtSaldo || parseFloat(importeFinal)==0)
        {
            alert('El valor que esta ingresando no es permitido');
            objeto.checked = false;
            return true;
        }
               
        signo = 1;
        textboxAImputar.disabled = true;
         
        buttonProntoPago.disabled = true;
        
    }
    else
    {
        signo = -1;
        textboxAImputar.disabled= true;
        textboxAImputar.disabled = false;
        buttonProntoPago.disabled = true;
        buttonProntoPago.disabled = false;
        
    }

    //Step1: FIN --------------------------------------------------------------------------------------------

    //Step2: INICIO - 

    var txtSumaMonLoc = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturas');
    // var txtSumaMonExt = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturasExt');        
    var txtCambio = document.getElementById('ctl00_Contentplaceholder1_txtCambio');     
                  
        
    var sumaMonLoc = txtSumaMonLoc.value.replace(',', '.');                  //Levanta el resultado actual de la suma
    //  sumaMonLoc = sumaMonLoc.replace(',','.');                     //Le da formato de flotante
    
    importeGrilla = textboxAImputar.value;                    //Levanta el importe de la grilla
    importeGrilla = importeGrilla.replace(',', '');    //Le da formato flotante
    
    //Define el cambio por si no está ingresado o si es 1,00
       var Fila = textboxAImputar.parentNode.parentNode;
    var celda = Fila.cells[5].innerHTML;
    var Cambio = 1.0000;
    if (txtCambio.value != "1,0000" && txtCambio.value != "" && celda != "PE")     //Si es distinto de dicho valor, pisa el valor de cambio
        Cambio = txtCambio.value;
   
    importeGrilla = parseFloat(importeGrilla) * signo;

    if (celda != "PE")//Agregado gato
    importeGrilla = importeGrilla * parseFloat(Cambio);   //Se Multiplica por el valor de cambio
    
    suma = parseFloat(sumaMonLoc) + parseFloat(importeGrilla); //Actualiza la suma 
    suma = suma.toFixed(4); //Formato de 4 decimales separados por un punto    
        
    txtSumaMonLoc.value = parseFloat(suma);    //Moneda local: Dividir por cambio
   
    //Diferencias:
    var DifPe = document.getElementById("ctl00_Contentplaceholder1_txtDiferenciaPe");
   
    var txtPagos = document.getElementById('ctl00_Contentplaceholder1_txtPagos');
                     
    var fDifPe = parseFloat(txtPagos.value) - parseFloat(txtSumaMonLoc.value);
    DifPe.value = fDifPe.toFixed(4);
}
catch(e)
{
  alert("JsHelper.js - SumarImporte. " + e.name + " - "+e.message);
}
      
}


function SumarImporteEdicionReciboError(objeto,cont,valorReal,valorProntoPago,btnPPSeleccionado)
{
  try
  {
  
    var myCheck;
    var myTextbox;
    var buttonProntoPago;
    var resultado;
    var suma;
    var textBoxSeleccionado = objeto.id;   
    var signo;


// Step1: Análisis Del importe de factura a considerar (con o sin pronto pago)

    textboxAImputar = document.getElementById(textBoxSeleccionado.replace('chk','txtAImputarPorFactura'));
        
    buttonProntoPago = document.getElementById(btnPPSeleccionado);
    buttonProntoPago.disabled=true;

    if (objeto.checked)
    {
        if (textboxAImputar.value == ''  ||  isNaN(parseFloat(textboxAImputar.value)) || !ValidateEnteredValue(textboxAImputar.value)) 
        {
            objeto.checked=false;
            return false;
        }                 
               
        if (valorProntoPago != 0)
            valorReal = valorProntoPago;               
        importeFinal = textboxAImputar.value;
        importeFinal = importeFinal.split(",").join("");
                
                  
        if(parseFloat(importe) > valorReal)
        {
            alert('El valor que esta ingresando no es permitido');
            objeto.checked = false;
            return true;
        }
               
        signo = 1;
        textboxAImputar.disabled = true;

        
    }
    else
    {
        signo = -1;
        textboxAImputar.disabled= true;
        textboxAImputar.disabled = false;
        
    }

//Step1: FIN --------------------------------------------------------------------------------------------

//Step2: INICIO - 

    var txtSumaMonLoc = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturas');
   // var txtSumaMonExt = document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturasExt');        
    var txtCambio = document.getElementById('ctl00_Contentplaceholder1_txtCambio');     
                  
        
    var sumaMonLoc = txtSumaMonLoc.value;                  //Levanta el resultado actual de la suma
    //sumaMonLoc = sumaMonLoc.replace(',','.');                     //Le da formato de flotante
    
    importeGrilla = textboxAImputar.value;                    //Levanta el importe de la grilla
    //importeGrilla = importeGrilla.replace(',', '.');    //Le da formato flotante
    
    //Define el cambio por si no está ingresado o si es 1,00
       var Fila = textboxAImputar.parentNode.parentNode;
    var celda = Fila.cells[5].innerHTML;
    var Cambio = 1.0000;
    if (txtCambio.value != "1,0000" && txtCambio.value != "" && celda != "PE")     //Si es distinto de dicho valor, pisa el valor de cambio
        Cambio = txtCambio.value;
        //Cambio = txtCambio.value.replace(',', '.');             //Formato flotante


    //var fValorConvertido = parseFloat(importeGrilla) * signo;   //Se sumará o restará según el signo (check)
//    fValorConvertido = fValorConvertido / parseFloat(Cambio);   //Se divide por el cambio el valor

    importeGrilla = parseFloat(importeGrilla) * signo;

    if (celda != "PE")//Agregado gato
    importeGrilla = importeGrilla * parseFloat(Cambio);   //Se Multiplica por el valor de cambio
    
    suma = parseFloat(sumaMonLoc) + parseFloat(importeGrilla); //Actualiza la suma 
    suma = suma.toFixed(4); //Formato de 4 decimales separados por un punto    
        
    txtSumaMonLoc.value = parseFloat(suma);    //Moneda local: Dividir por cambio
    //txtSumaMonExt.value = parseFloat(txtSumaMonLoc.value) / parseFloat(Cambio);    //Moneda extranjera: Multiplicar por cambio


    //txtSumaMonLoc.value = parseFloat(txtSumaMonLoc.value).toFixed(4);
    //txtSumaMonExt.value = parseFloat(txtSumaMonExt.value).toFixed(4);
        
    //txtSumaMonLoc.value = txtSumaMonLoc.value.replace('.',','); //Formato con coma
    //txtSumaMonExt.value = txtSumaMonExt.value.replace('.',','); //Forma con coma
    
        
    //Diferencias:
    var DifPe = document.getElementById("ctl00_Contentplaceholder1_txtDiferenciaPe");
   // var DifDol = document.getElementById("ctl00_Contentplaceholder1_txtDiferenciaDo");


    var txtPagos = document.getElementById('ctl00_Contentplaceholder1_txtPagos');
    //var txtPagosExt = document.getElementById('ctl00_Contentplaceholder1_txtPagosExt');


    /*var fDifDol = parseFloat(txtPagosExt.value.replace(',', '.')) - parseFloat(txtSumaMonExt.value.replace(',', '.'));
    DifDol.value = fDifDol.toFixed(4);
    DifDol.value = DifDol.value.replace('.', ',');*/
                     
    var fDifPe = parseFloat(txtPagos.value) - parseFloat(txtSumaMonLoc.value);
    DifPe.value = fDifPe.toFixed(4);
    
  }
  catch(e)
  {
      alert("JsHelper.js - SumarImporteEdicionRecibo. " + e.name + " - "+e.message);
  }
    
}




function SumarImporteImputado()
{  
  try
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
    catch(e)
    {
      alert("JsHelper.js - SumarImporteImputado. " + e.name + " - "+e.message);
    }
}

function SumarImporteImputado2(cont)
{
 
try
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
catch(e)
{
  alert("JsHelper.js - SumarImporteImputado2. " + e.name + " - "+e.message);
}

}


function ValidateEnteredValue(valueToValidate)
{
    var RegExPattern =/^[0-9]{1,7}(\,[0-9]{1,4})|[0-9]{1,7}$/;

    if (!valueToValidate.match(RegExPattern))
    {
      return false;
    }else
    {
      return true;
    }
}


function ReDisabledCheckedRows()
{
       var grillaFacturas = document.getElementById('ctl00_Contentplaceholder1_GvResultadosFacturas');
       var filas=grillaFacturas.rows;
       var fila;
       
       fila=filas[1];
       
       var celdas=fila.cells;
}


function AplicarFocoAgregarPago()
{
 var btnAgregarPago = document.getElementById('btnAgregarPagoClientSide');
 btnAgregarPago.focus();

}

function AplicarFocoAgregarPagoYEjecutar()
{
 var btnAgregarPago = document.getElementById('btnAgregarPagoClientSide');
 btnAgregarPago.focus();
 btnAgregarPago.click();

}

function AlmacenarEstadoGrillaFacturas()
{
 var grillaFacturas = document.getElementById('ctl00_Contentplaceholder1_GvResultadosFacturas');
 var hdEstadoGrillaFacturas=document.getElementById('ctl00_Contentplaceholder1_HiddenFieldEstadoGrillaFacturas');
 var textBoxAImputar; 

}