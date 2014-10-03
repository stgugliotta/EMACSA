var CP = new Array();
function AgregarQuitarSeleccion(obj) 
{
    var Fila = obj.parentNode.parentNode;
    if (obj.checked == true)
        CP.push(Fila.cells[2].innerHTML);
    else 
    {
        for (var i = 0; i < CP.length; i++) 
        {
            if (CP[i] == Fila.cells[2].innerHTML)
                CP.splice(i, 1);
        }
    }
    BindearCP();
}
function BindearCP() 
{
    CP.sort();
    document.getElementById("ctl00_Contentplaceholder1_lblCodigosSeleccionados").innerHTML = CP.toString();
    var Tabla = document.getElementById("ctl00_Contentplaceholder1_GvResultados");
    for (var i = 1; i <= 5; i++) 
    {
        for (var j = 0; j < CP.length; j++) 
        {
            if (Tabla.rows[i].cells[2].innerHTML == CP[j]) 
            {
                var Check = Tabla.rows[i].cells[0].firstChild;
                Check.checked = true;
            }
        }
    }
}
function VaciarArray() 
{
    CP.splice(0, CP.length);
}
function ConfirmarAltaZona() 
{
    //Verificamos que al menos haya un CP
    if (CP.length == 0) 
    {
        alert("Seleccione al menos un CP.");
        return false;
    }
    if (document.getElementById("ctl00_Contentplaceholder1_txtDescripcion").value == null || document.getElementById("ctl00_Contentplaceholder1_txtDescripcion").value == "") 
    {
        alert("Complete descripcion.");
        return false;
    }
    if (confirm("¿Está seguro que desea confirmar?")) 
    {
        document.getElementById("ctl00_Contentplaceholder1_txtCP").value = CP.toString();
        VaciarArray();
        return true;
    }
    else
        return false;
}
function ValidarCobrador() 
{
    alert("Validacion de datos...");
    return true;
}