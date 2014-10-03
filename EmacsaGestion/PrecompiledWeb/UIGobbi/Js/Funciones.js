// JScript File

var globalWindowArray1;
var globalWindowArray2;
var globalWindowArray3;
var globalWindowArray4;
var globalWindowArray5;
var globalWindowArray6;
var globalWindowArray7;
var globalWindowArray8;
var globalWindowArray9;
var globalWindowArray10;

globalWindowArray1=null;
globalWindowArray2=null;
globalWindowArray3=null;
globalWindowArray4=null;
globalWindowArray5=null;
globalWindowArray6=null;
globalWindowArray7=null;
globalWindowArray8=null;
globalWindowArray9=null;
globalWindowArray10=null;

function AbreSelector(urlPagina,nombrePagina,urlPaginaARecgargar)
{
    AbrirModal(urlPagina,nombrePagina,urlPaginaARecgargar,800,600)
}

function AbreReporte(urlPagina, nombrePagina, urlPaginaARecgargar) {
    AbrirModal(urlPagina, nombrePagina, urlPaginaARecgargar, 1024, 768)
}

function mostrarImagenCarga(muestra, cursor)
{
   var imgCargar = document.getElementById('imgCargar');
   imgCargar.style.display = muestra;
   document.body.style.cursor = cursor;
}

function AbrirModal(urlPagina,nombrePagina,urlPaginaARecgargar, ancho, alto)
{
    var sUrl = urlPagina;
    showPopWin(sUrl, nombrePagina, ancho, alto, '');
    if(ValorDeRetorno == '1')
    {
        var intIndex = urlPaginaARecgargar.indexOf( "|" );
        while (intIndex != -1)
        {
            urlPaginaARecgargar = urlPaginaARecgargar.replace('|','&');
            intIndex = urlPaginaARecgargar.indexOf( "|" );
        }
         window.location.replace(urlPaginaARecgargar);
    }
}

function AbrirVentana(urlPagina,nombrePagina)
{
    var sUrl = urlPagina;
 
    
    window.open(urlPagina, nombrePagina,"width=540,height=630,scrollbars=NO,screenX=0,screenY=100,resizable=yes");
    
    
}

function AbrirVentanaPopUpHItoFactura(urlPagina,nombrePagina)
{
try
{
    var sUrl = urlPagina;
    var pos;
    if (globalWindowArray1==null){
         globalWindowArray1=window.open(urlPagina+"?window=globalWindowArray1", nombrePagina,"width=575,height=630,scrollbars=YES,screenX=0,screenY=100,resizable=yes");
         return;
         }
    if (globalWindowArray2==null){
         globalWindowArray2=window.open(urlPagina, nombrePagina,"width=575,height=630,scrollbars=YES,screenX=0,screenY=100,resizable=yes");
         globalWindowArray2.opener=self;
         globalWindowArray2.creator=self;
         return;
         }
    if (globalWindowArray3==null){
         globalWindowArray3=window.open(urlPagina, nombrePagina,"width=575,height=630,scrollbars=YES,screenX=0,screenY=100,resizable=yes");
         return;
         }
    if (globalWindowArray4==null){
         globalWindowArray4=window.open(urlPagina, nombrePagina,"width=575,height=630,scrollbars=YES,screenX=0,screenY=100,resizable=yes");
         return;
         }
    if (globalWindowArray5==null){
         globalWindowArray5=window.open(urlPagina, nombrePagina,"width=575,height=630,scrollbars=YES,screenX=0,screenY=100,resizable=yes");
         return;
         }
    if (globalWindowArray6==null){
         globalWindowArray6=window.open(urlPagina, nombrePagina,"width=575,height=630,scrollbars=YES,screenX=0,screenY=100,resizable=yes");
         return;
         }
    if (globalWindowArray7==null){
         globalWindowArray7=window.open(urlPagina, nombrePagina,"width=575,height=630,scrollbars=YES,screenX=0,screenY=100,resizable=yes");
         return;
         }
    if (globalWindowArray8==null){
         globalindowArray8=window.open(urlPagina, nombrePagina,"width=575,height=630,scrollbars=YES,screenX=0,screenY=100,resizable=yes");
         return;
         }
    if (globalWindowArray9==null){
         globalWindowArray9=window.open(urlPagina, nombrePagina,"width=575,height=630,scrollbars=YES,screenX=0,screenY=100,resizable=yes");
         return;
         }
    if (globalWindowArray10==null){
         globalWindowArray10=window.open(urlPagina, nombrePagina,"width=575,height=630,scrollbars=YES,screenX=0,screenY=100,resizable=yes");
         return;
         }
}
catch(e)
{
 alert("Funciones.js - AbrirVentanaPopUpHItoFactura. " + e.name + " - "+e.message);
}
    
}

function AbrirVentanaPopUpHItoFacturaConScroll(urlPagina,nombrePagina)
{
try
{
    var sUrl = urlPagina;
    var pos;
    var left = (screen.width/2)-(575/2);
    var top = (screen.height/2)-(600/2);
    if (globalWindowArray1==null){
         globalWindowArray1=window.open(urlPagina+"?window=globalWindowArray1", nombrePagina,"width=575,height=600,scrollbars=YES,screenX=0,screenY=100,resizable=no,top=" + top +", left=" + left);
         return;
         }
    if (globalWindowArray2==null){
         globalWindowArray2=window.open(urlPagina, nombrePagina,"width=575,height=600,scrollbars=YES,screenX=0,screenY=100,resizable=no,top=" + top +", left=" + left);
         globalWindowArray2.opener=self;
         globalWindowArray2.creator=self;
         return;
         }
    if (globalWindowArray3==null){
         globalWindowArray3=window.open(urlPagina, nombrePagina,"width=575,height=600,scrollbars=YES,screenX=0,screenY=100,resizable=no,top=" + top +", left=" + left);
         return;
         }
    if (globalWindowArray4==null){
         globalWindowArray4=window.open(urlPagina, nombrePagina,"width=575,height=600,scrollbars=YES,screenX=0,screenY=100,resizable=no,top=" + top +", left=" + left);
         return;
         }
    if (globalWindowArray5==null){
         globalWindowArray5=window.open(urlPagina, nombrePagina,"width=575,height=600,scrollbars=YES,screenX=0,screenY=100,resizable=no,top=" + top +", left=" + left);
         return;
         }
    if (globalWindowArray6==null){
         globalWindowArray6=window.open(urlPagina, nombrePagina,"width=575,height=600,scrollbars=YES,screenX=0,screenY=100,resizable=no,top=" + top +", left=" + left);
         return;
         }
    if (globalWindowArray7==null){
         globalWindowArray7=window.open(urlPagina, nombrePagina,"width=575,height=630,scrollbars=YES,screenX=0,screenY=100,resizable=no,top=" + top +", left=" + left);
         return;
         }
    if (globalWindowArray8==null){
         globalindowArray8=window.open(urlPagina, nombrePagina,"width=575,height=600,scrollbars=YES,screenX=0,screenY=100,resizable=no,top=" + top +", left=" + left);
         return;
         }
    if (globalWindowArray9==null){
         globalWindowArray9=window.open(urlPagina, nombrePagina,"width=575,height=600,scrollbars=YES,screenX=0,screenY=100,resizable=no,top=" + top +", left=" + left);
         return;
         }
    if (globalWindowArray10==null){
         globalWindowArray10=window.open(urlPagina, nombrePagina,"width=575,height=600,scrollbars=YES,screenX=0,screenY=100,resizable=no,top=" + top +", left=" + left);
         return;
         }
}
catch(e)
{
 alert("Funciones.js - AbrirVentanaPopUpHItoFacturaConScroll. " + e.name + " - "+e.message);
}
    
}

function AbrirVentanaWithScroll(urlPagina,nombrePagina)
{
    var sUrl = urlPagina;
 
    
    window.open(urlPagina, nombrePagina,"width=600,height=600,scrollbars=YES,screenX=0,screenY=100,resizable=yes");
    
    
}

function AbrirVentana2(urlPagina,nombrePagina, w, h)
{
    var sUrl = urlPagina;
 
    
    window.open(urlPagina, nombrePagina,"width=" + w + ",height=" + h +",scrollbars=YES,screenX=0,screenY=100,resizable=no");
    
    
}

function AbrirVentana2Maximizable(urlPagina,nombrePagina, w, h)
{
    var sUrl = urlPagina;
 
    
    window.open(urlPagina, nombrePagina,"width=" + w + ",height=" + h +",scrollbars=YES,screenX=0,screenY=100,resizable=yes");
    
    
}


function AbrirVentana3(urlPagina,nombrePagina,w,h)
{
    var sUrl = urlPagina;
 
    
    window.open(urlPagina, nombrePagina,"width=" + w + ",height=" + h +",scrollbars=NO,screenX=0,screenY=100,resizable=yes");
    
    
}
function AbrirVentanaParaCambiarEstado(urlPagina,nombrePagina)
{
    var sUrl = urlPagina;
 
    
    window.open(urlPagina, nombrePagina,"width=560,height=450,scrollbars=NO,screenX=0,screenY=100,resizable=no");
    
    
}
function AbrirVentanaParaEstadoDeCuenta(urlPagina,nombrePagina)
{
    var sUrl = urlPagina;
 
    
    window.open(urlPagina, nombrePagina,"width=800,height=700,scrollbars=YES,screenX=0,screenY=100,resizable=no");
    
    
}
function AbrirVentanaAjustable(urlPagina,nombrePagina, width, height)
{
    var sUrl = urlPagina;
 
    
    window.open(urlPagina, nombrePagina,"width="+width+",height="+height+",scrollbars=YES,screenX=0,screenY=100,resizable=no");
    
    
}

function AbrirVentanaPequenia(urlPagina,nombrePagina)
{
    var sUrl = urlPagina;
 
    
    window.open(urlPagina, nombrePagina,"width=5,height=5,scrollbars=NO,screenX=0,screenY=0,resizable=no");
    
    
}

function AbrirVentanaPequenia2(urlPagina,nombrePagina)
{
    var sUrl = urlPagina;
 
    
    window.open(urlPagina, nombrePagina,"width=100,height=100,scrollbars=NO,screenX=0,screenY=0,resizable=yes");
    
    
}


function KeyPress() 
{
  if (window.event.keyCode == 13)
     return false;
  else
     return true;
}


function PopupSinRecursoConTiempo()
{
       setTimeout("alert('No tiene permisos para acceder a éste recurso.');", 1000);
}

function CerrarTodosLosPopups()
{
try
{
             if (globalWindowArray1!=null)
             {
                 try
                 {
                   if (globalWindowArray1.closed)globalWindowArray1=null;
                   
                 }
                 catch(Error)
                 {
                  globalWindowArray1=null;
                 }       
             }
             
             if (globalWindowArray2!=null)
             {
                 try
                 {
                   if (globalWindowArray2.closed)globalWindowArray2=null;
                   
                 }
                 catch(Error)
                 {
                  globalWindowArray2=null;
                 }       
             }
             
              if (globalWindowArray3!=null)
             {
                 try
                 {
                   if (globalWindowArray3.closed)globalWindowArray3=null;
                   
                 }
                 catch(Error)
                 {
                  globalWindowArray3=null;
                 }       
             }
             
              if (globalWindowArray4!=null)
             {
                 try
                 {
                   if (globalWindowArray4.closed)globalWindowArray4=null;
                   
                 }
                 catch(Error)
                 {
                  globalWindowArray4=null;
                 }       
             }
              if (globalWindowArray5!=null)
             {
                 try
                 {
                   if (globalWindowArray5.closed)globalWindowArray5=null;
                   
                 }
                 catch(Error)
                 {
                  globalWindowArray5=null;
                 }       
             }
              if (globalWindowArray6!=null)
             {
                 try
                 {
                   if (globalWindowArray6.closed)globalWindowArray6=null;
                   
                 }
                 catch(Error)
                 {
                  globalWindowArray6=null;
                 }       
             }
              if (globalWindowArray7!=null)
             {
                 try
                 {
                   if (globalWindowArray7.closed)globalWindowArray7=null;
                   
                 }
                 catch(Error)
                 {
                  globalWindowArray7=null;
                 }       
             }
              if (globalWindowArray8!=null)
             {
                 try
                 {
                   if (globalWindowArray8.closed)globalWindowArray8=null;
                   
                 }
                 catch(Error)
                 {
                  globalWindowArray8=null;
                 }       
             }
              if (globalWindowArray9!=null)
             {
                 try
                 {
                   if (globalWindowArray9.closed)globalWindowArray9=null;
                   
                 }
                 catch(Error)
                 {
                  globalWindowArray9=null;
                 }       
             }
              if (globalWindowArray10!=null)
             {
                 try
                 {
                   if (globalWindowArray10.closed)globalWindowArray10=null;
                   
                 }
                 catch(Error)
                 {
                  globalWindowArray10=null;
                 }       
             }
             

            if (globalWindowArray1!=null || globalWindowArray2!=null || globalWindowArray3!=null ||globalWindowArray4!=null || globalWindowArray5!=null || globalWindowArray6!=null || globalWindowArray7!=null || globalWindowArray8!=null || globalWindowArray9!=null ||  globalWindowArray10!=null)
            {
            
                    if(confirm("ATENCION. ¿Desea cerrar los popups que se encuentren abiertos?")) 
                      { 
                      
                        if (globalWindowArray1!=null){
                        
                        globalWindowArray1.close();
                        globalWindowArray1=null;
                        }
                        if (globalWindowArray2!=null){
                             globalWindowArray2.close();
                             globalWindowArray2=null;
                             }
                        if (globalWindowArray3!=null)
                        {
                             globalWindowArray3.close();
                             globalWindowArray3=null;}
                             
                        if (globalWindowArray4!=null)
                        {
                             globalWindowArray4.close();
                             globalWindowArray4=null;}
                             
                        if (globalWindowArray5!=null)
                        {
                             globalWindowArray5.close();
                             globalWindowArray5=null;
                             }
                             
                        if (globalWindowArray6!=null){
                             globalWindowArray6.close();
                             globalWindowArray6=null;
                             }
                        if (globalWindowArray7!=null){
                             globalWindowArray7.close();
                             globalWindowArray7=null;
                             }
                             
                        if (globalWindowArray8!=null){
                        globalWindowArray8.close();
                             globalWindowArray8=null;
                             }
                             
                        if (globalWindowArray9!=null){
                        globalWindowArray9.close();
                             globalWindowArray9=null;
                             }
                             
                        if (globalWindowArray10!=null){
                        globalWindowArray10.close();
                             globalWindowArray10=null;
                             }
                             
                        return true;
                      }
                      else
                      {
                        return false;
                      }

            }
            
            }
            
            catch(e)
            {
            alert("Funciones.js - CerrarTodosLosPopups. " + e.name + " - "+e.message);
            }
           
    
}

