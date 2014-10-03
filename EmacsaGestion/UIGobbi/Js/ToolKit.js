    var ModalPopupCargando='<%= ModalPopupCargando.ClientID %>';
                var ModalPopupDetalleCheques='<%= ModalPopupDetalleCheques.ClientID %>';
                var ModalPopupProntoPago='<%= ModalPopupProntoPago.ClientID %>';
                var ModalPopupDetalleControlConcurrencia='<%= ModalPopupDetalleControlConcurrencia.ClientID %>';
                
                                                 
              		
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
                
                

function beginReq(sender, args) 
{

	var controlCaller=args.get_postBackElement().id;
   
    if(controlCaller.indexOf('btnGuardarRecibo')!=-1){$find(ModalPopupCargando).show()};
    if(controlCaller.indexOf('btnAgregarPago')!=-1){$find(ModalPopupCargando).show()};
    
       
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


function endReq(sender, args)
{
	                        //  shows the Popup 
	                        $find(ModalPopupCargando).hide();
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


function SumarImporte(objeto,cont,valorReal,valorProntoPago,btnPPSeleccionado)
{

try
{
{alert('bien2');
  var myCheck;
  var myTextbox;
  var buttonProntoPago;
  var resultado;
  var suma;
  var textBoxSeleccionado= objeto.id;
   alert(valorReal);
   var signo;

         myTextbox=document.getElementById(textBoxSeleccionado.replace('chk','txtAImputarPorFactura'));
         buttonProntoPago=document.getElementById(btnPPSeleccionado);

               
        if (objeto.checked)
        {
           if (myTextbox.value==''  ||  isNaN(parseFloat(myTextbox.value))) 
           {
               objeto.checked=false;
               return false;
           }
                        
           if (valorProntoPago!=0)
           {
             valorReal=valorProntoPago;
           }
           
           
           importe=myTextbox.value;
           importe=importe.split(",").join("");
                   
                      
        if(parseFloat(importe) > valorReal)
        {
            alert('El valor que esta ingresando no es permitido');
            objeto.checked = false;
            return true;
        }
               
           signo=1;
            myTextbox.disabled=true;
            buttonProntoPago.disabled=true;
            //btnPPSeleccionado.disabled=true;
        
        }
        else
        {
          signo=-1;
           myTextbox.disabled=false;
           buttonProntoPago.disabled=false;
        }

         
           resultado=document.getElementById('ctl00_Contentplaceholder1_txtSumaFacturas');
           
           
           
           
           res=resultado.value;
          // res=res.split(",").join(".");
           
           
           importeGrilla=myTextbox.value;
           //importeGrilla=importeGrilla.split(".").join("");
           importeGrilla=importeGrilla.split(",").join("");

           suma=parseFloat(res)  + (parseFloat(importeGrilla)*signo); 
 
           resultado.value=suma.toFixed(3);
           
           nuevoRes=resultado.value;
           
           //nuevoRes=nuevoRes.split(".").join(",");
           
           resultado.value=nuevoRes;
           
 }
 catch(e)
 {
  alert("Toolkit.js - SumarImporte. " + e.name + " - "+e.message);
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
  alert("Toolkit.js - SumarImporteImputado. " + e.name + " - "+e.message);
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
   
   
 
 return true;
}
catch(e)
{
  alert("Toolkit.js - SumarImporteImputado2. " + e.name + " - "+e.message);
}
}