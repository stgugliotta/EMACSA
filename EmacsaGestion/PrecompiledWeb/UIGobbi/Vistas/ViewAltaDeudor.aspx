<%@ page language="C#" masterpagefile="~/MasterPage.master" theme="SampleSiteTheme" enableeventvalidation="false" autoeventwireup="true" inherits="Vistas_ViewAltaDeudor, App_Web_nu_04hm5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="../GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>

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

    <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
	            var ModalProgress = '<%= ModalProgress.ClientID %>';   
                	
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
                
                

function beginReq(sender, args) 
{
	// shows the Popup 
	var controlCaller=args.get_postBackElement().id;
  //  if(controlCaller.indexOf('UpdateTimer')==-1){$find(ModalPopupCargando).show()};
        	 
}



function ReducirTamanioDiv()
{

try
{
  var div= document.getElementById('ctl00_Contentplaceholder1_ctl03');

  div.setAttribute('style', 'BORDER-RIGHT: #cccccc 2px solid; WIDTH: 800px; BORDER-BOTTOM: #cccccc 1px inset; HEIGHT: 300px; BACKGROUND-COLOR: #ffffff; TEXT-ALIGN: center');
  
  }
  catch(er)
  {
  
  }
  return true;
}

function endReq(sender, args)
{
	                        //  shows the Popup 
	                        $find(ModalProgress).hide();
} 


function RecoveryFilters()
{
   var url='http://' + document.location.host + '/Vistas/ViewGestionDeDeudores.aspx?restoreFilters=true';
   document.location=url;
}

    </script>

    <script type="text/javascript">
        function ValidarMails(obj) {
            //var ExprReg = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3,4})+$/;
           // var ExpReg = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/
           // var ExpReg = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
            //var regEx =  /^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$/;
           
            //var regEx = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
            var pattern = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var txtEmail = obj.value;
            
            if (txtEmail == '' || txtEmail == null) {
                
                return true;
            }
            
            var aEmails = txtEmail.split(';');
            for (var i = 0; i < aEmails.length; i++) 
            {
                // bug fix para que se valide solo el mail y no espacios que puedan haber adelante y atras
                if (!pattern.test(jQuery.trim(aEmails[i]))) 
                {
                    return false;
                }
            }
            
            return true;
        }
    </script>

    <script type="text/javascript">
 
    function CPcuitValido(cuit) {
        var vec=new Array(10);
        esCuit=false;
        cuit_rearmado=string.Empty;
        errors = ''
        for (i=0; i < cuit.length; i++) {   
            caracter=cuit.charAt( i);
            if ( caracter.charCodeAt(0) >= 48 && caracter.charCodeAt(0) <= 57 )     {
                cuit_rearmado +=caracter;
            }
        }
        cuit=cuit_rearmado;
        if ( cuit.length != 11) {  // si to estan todos los digitos
            esCuit=false;
            errors = 'Cuit <11 ';
            alert( "CUIT Menor a 11 Caracteres" );
            return false;
        } else {
        x=i=dv=0;
        // Multiplico los dígitos.
        vec[0] = cuit.charAt(  0) * 5;
        vec[1] = cuit.charAt(  1) * 4;
        vec[2] = cuit.charAt(  2) * 3;
        vec[3] = cuit.charAt(  3) * 2;
        vec[4] = cuit.charAt(  4) * 7;
        vec[5] = cuit.charAt(  5) * 6;
        vec[6] = cuit.charAt(  6) * 5;
        vec[7] = cuit.charAt(  7) * 4;
        vec[8] = cuit.charAt(  8) * 3;
        vec[9] = cuit.charAt(  9) * 2;
                    
        // Suma cada uno de los resultado.
        for( i = 0;i<=9; i++) {
            x += vec[i];
        }
        dv = (11 - (x % 11)) % 11;
        if ( dv == cuit.charAt( 10) ) { 
            esCuit=true;
        } 
    }
    if ( !esCuit ) {
        alert( "CUIT Inválido" );
        return false;       
    }
    //return esCuit ;
}
    
    function validate() {
        //TODO: Arreglar esta validacion. No funciona porque nunca valida ok la regex.
        if (!ValidarMails(document.getElementById("<%=txtEmail.ClientID %>"))) {
               alert("Alguno de los emails ingresados es inválido.");
               document.getElementById("<%=txtEmail.ClientID%>").focus();
               return false;
        }
        
        return true;
    }
    

    </script>

    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
    <asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">

     
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <ProgressTemplate>
                <div style="position: relative; top: 30%; text-align: center;">
                    <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                    Procesando...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:Panel>
	
    
    <ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
        
        
    <table align="center" style="height: 1000px">
        <tr style="height: 400px;">
            <td valign="top">
                <table style="width: 800px; height: 98%;" class="borderCompleto" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" style="height: 400px">
                                <tr>
                                    <td align="center">
                                        <asp:Panel ID="pnlSeleccionarDatos" runat="server">
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px; width: 800px;
                                                text-align: center;">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label4" runat="server" Text="   Datos Del Deudor" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>

                                                
                                                <table width="800px">
                                                    <tr class="fondo_Titulo">
                                                        <td>
                                                            Cliente
                                                        </td>
                                                        <td>
                                                            Alfanumérico del Cliente
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr class="fondo_Titulo">
                                               
                                                        <td>
                                                            <ajaxToolkit:ComboBox ID="cmbClientes" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px" ValidationGroup="alfaNumGroup">
                                                            </ajaxToolkit:ComboBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAlfaNumDelCliente" runat="server" Font-Names="Verdana" Font-Size="11px" Height="15px" ValidationGroup="alfaNumGroup"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnAgregarClienteDeudor" runat="server" Text="+" Visible="true"
                                                                OnClick="btnAgregarClienteDeudor_Click" ValidationGroup="alfaNumGroup" CausesValidation="true"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Table ID="tblClientesDeudor" runat="server" Width="800px" ValidationGroup="alfaNumGroup">
                                                </asp:Table>
                                                
                                                <table style="width: 400px;">
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblNombre" runat="server" CssClass="labelBold" Text="Nombre:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNombre" runat="server" CssClass="textboxEditor" Width="300px" ValidationGroup="datosGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombreNuevo" runat="server"
                                                                ControlToValidate="txtNombre" Enabled="false" ErrorMessage="Ingrese el nombre" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblCuit" runat="server" CssClass="labelBold" Text="Cuit:" />
                                                        </td>
                                                        <td>
                                                            <ajaxToolkit:MaskedEditExtender TargetControlID="txtCuit" Mask="99-99999999-9" runat="server"
                                                                Enabled="true" MaskType="Number">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                            <asp:TextBox ID="txtCuit" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                            
                                                            <%--                                                            
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCuitNuevo" runat="server" ControlToValidate="txtCuit"
                                                                Enabled="false" ErrorMessage="Ingrese el Cuit" ValidationGroup="datosGroup">
                                                            </asp:RequiredFieldValidator>
                                                            --%>
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblPais" runat="server" CssClass="labelBold" Text="País:" />
                                                        </td>
                                                        <td>
                                                        <asp:DropDownList ID="cmbPais" runat="server"   AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="cmbPais_SelectedIndexChanged"></asp:DropDownList>
                                                        <%--
                                                            <ajaxToolkit:ComboBox ID="cmbPais" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="cmbPais_SelectedIndexChanged">
                                                            </ajaxToolkit:ComboBox>--%>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPaisNuevo" runat="server" ControlToValidate="cmbPais"
                                                                Enabled="false" ErrorMessage="Ingrese el país" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblProvincia" runat="server" CssClass="labelBold" Text="Provincia:" />
                                                        </td>
                                                        <td>
                                                        <asp:DropDownList ID="cmbProvincia" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="cmbProvincia_SelectedIndexChanged"></asp:DropDownList>
                                                            <%--<ajaxToolkit:ComboBox ID="cmbProvincia" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="cmbProvincia_SelectedIndexChanged">
                                                            </ajaxToolkit:ComboBox>--%>
                                                            
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorProvNuevo" runat="server" ControlToValidate="cmbProvincia"
                                                                Enabled="false" ErrorMessage="Ingrese la provincia" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblDepartamento" runat="server" CssClass="labelBold" Text="Departamento/Partido:" />
                                                        </td>
                                                        <td>
                                                        <asp:DropDownList ID="cmbDepartamento" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="cmbDepartamento_SelectedIndexChanged"></asp:DropDownList>
                                                        
                                                          <%--  <ajaxToolkit:ComboBox ID="cmbDepartamento" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="cmbDepartamento_SelectedIndexChanged">
                                                            </ajaxToolkit:ComboBox>--%>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldDepartamento" runat="server" ControlToValidate="cmbDepartamento"
                                                                Enabled="false" ErrorMessage="Ingrese el departamento" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblLocalidad" runat="server" CssClass="labelBold" Text="Localidad:" />
                                                        </td>
                                                        <td>
                                                        <asp:DropDownList ID="cmbLocalidad" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px"></asp:DropDownList>
                                                        <%--
                                                            <ajaxToolkit:ComboBox ID="cmbLocalidad" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px">
                                                            </ajaxToolkit:ComboBox>--%>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocaNuevo" runat="server" ControlToValidate="cmbLocalidad"
                                                                Enabled="false" ErrorMessage="Ingrese la localidad" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblDomicilio" runat="server" CssClass="labelBold" Text="Calle / Altura:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDomicilio" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDomicilioNuevo" runat="server"
                                                                ControlToValidate="txtDomicilio" Enabled="false" ErrorMessage="Ingrese el domicilio. " ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                            <asp:TextBox ID="txtAltura" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                            
                                                            <asp:RegularExpressionValidator runat="server" ErrorMessage="Formato Inválido" ControlToValidate="txtAltura" ValidationGroup="datosGroup" ValidationExpression="^[0-9]{1,6}$"></asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAltura"
                                                                    ErrorMessage="Altura debe ser numérico" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                                    
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblPiso" runat="server" CssClass="labelBold" Text="Piso:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPiso" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                        </td>
                                                    </tr>                                                    
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblDepto" runat="server" CssClass="labelBold" Text="Depto:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDepto" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                        </td>
                                                    </tr>                                                    
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblCp" runat="server" CssClass="labelBold" Text="Código Postal:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCp" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCPNuevo" runat="server" ControlToValidate="txtCp"
                                                                Enabled="false" ErrorMessage="Ingrese el Código Postal" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:UpdatePanel UpdateMode="Always">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btnDomicilioGeolocalizado" runat="server" CssClass="button_back"
                                                                        Text="Domicilio Geolocalizado:" OnClick="btnDomicilioGeolocalizado_Click"  CausesValidation="false"/>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td valign="bottom">
                                                            <asp:DropDownList ID="cmbGeoLocations" runat="server" Width="400px"
                                                                OnSelectedIndexChanged="cmbGeoLocations_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel>
                                                                <ContentTemplate>
                                                                    <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" Visible="true" EnableTheming="true" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblTelefono" runat="server" CssClass="labelBold" Text="Teléfono:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                         <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelNuevo" runat="server" ControlToValidate="txtTelefono"
                                                                Enabled="false" ErrorMessage="Ingrese el teléfono" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblTelAux" runat="server" CssClass="labelBold" Text="Teléfono Aux.:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTelefonoAux" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorTelAuxNuevo" runat="server"
                                                                ControlToValidate="txtTelefonoAux" Enabled="false" ErrorMessage="Ingrese el teléfono auxiliar" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblFax" runat="server" CssClass="labelBold" Text="Fax:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFax" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                             
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblEmail" runat="server" CssClass="labelBold" Text="Email/s:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textboxEditor" Width="300px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblAnticipo" runat="server" CssClass="labelBold" Text="Anticipo Gestión:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAnticipo" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                            <asp:RegularExpressionValidator runat="server" ErrorMessage="Formato Inválido" ControlToValidate="txtAnticipo" ValidationGroup="datosGroup" ValidationExpression="^[0-9]{1,3}$"></asp:RegularExpressionValidator>    
                                                            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtAnticipo"
                                                                    ErrorMessage="Anticipo debe ser numérico" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                  
                                                </table>
                                                
                                            <asp:UpdatePanel runat="server" UpdateMode="Conditional" visible="false" >
                                            <ContentTemplate>
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px; width: 800px;
                                                text-align: center;">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label2" runat="server" Text="   Horarios de Reclamo" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="height: 150px; width: 800px; background-color: #ffffff; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: center; width: 800px;" >
                                                <table width="800px">
                                                    <tr class="fondo_Titulo">
                                                        <td>
                                                            Día
                                                        </td>
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
                                                            <asp:DropDownList ID="cmbDiasReclamo" runat="server" EnableViewState="true">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <mkb:TimeSelector ID="tsHorarioDesde" runat="server" MinuteIncrement="10" DisplaySeconds="false" SelectedTimeFormat="TwentyFour" />
                                                        </td>
                                                        <td>
                                                            <mkb:TimeSelector ID="tsHorarioHasta" runat="server" MinuteIncrement="10" DisplaySeconds="false" SelectedTimeFormat="TwentyFour" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnAgregarHorarioReclamo" runat="server" Text="+" Visible="true"
                                                                OnClick="btnAgregarHorarioReclamo_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                                                <div style="height: 100px; width: 800px; overflow: auto;">
                                                    <asp:Table ID="tblHorariosReclamo" runat="server" Width="780px" EnableViewState="true">
                                                    </asp:Table>
                                                </div>
                                                
                                            </div>
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px; width: 800px;
                                                text-align: center;">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label5" runat="server" Text="   Horarios de Cobro" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>

                                            <div style="height: 150px; width: 700px; background-color: #ffffff; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: center; width: 800px;">
                                                <table width="800px">
                                                    <tr class="fondo_Titulo">
                                                        <td>
                                                            Día
                                                        </td>
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
                                                            <asp:DropDownList ID="cmbDiasCobro" runat="server" EnableViewState="true">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <mkb:TimeSelector ID="tsHorarioDesdeCobro" runat="server"  MinuteIncrement="10" EnableClock="false" DisplaySeconds="false" SelectedTimeFormat="TwentyFour" />
                                                        </td>
                                                        <td>
                                                            <mkb:TimeSelector ID="tsHorarioHastaCobro" runat="server" MinuteIncrement="10" DisplaySeconds="false" SelectedTimeFormat="TwentyFour" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnAgregarHorarioCobro" runat="server" Text="+" Visible="true"
                                                                OnClick="btnAgregarHorarioCobro_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                                                <div style="height: 100px; width: 800px; overflow: auto;">
                                                    <asp:Table ID="tblHorariosCobro" runat="server" Width="780px">
                                                    </asp:Table>
                                                </div>
                                                
                                            </div>
                                            
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px; width: 800px;
                                                text-align: center;">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label3" runat="server" Text="   Clientes" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                            
                                          <asp:UpdatePanel runat="server" ID="updatePanelBtnAgregarPago" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                <ma:SecureButton ID="btnAceptar" runat="server" CausesValidation="True" CssClass="button_back"
                                                    Height="20px" OnClick="btnAceptar_Click" TabIndex="20" Text="Guardar" ValidationGroup="datosGroup"
                                                     Width="95px" OnClientClick=" return validate()" />
                                                    
                                                        </td>
                                                        <td align="right">
                                                            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="button_back" Visible="true"
                                                                OnClientClick="javascript:RecoveryFilters();" ></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                                                    </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="left" style="width: 192px; border-width: 0px" valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="left" style="width: 100%;">
                            <br />
                        </td>
                        <td align="left" style="width: 100%;">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="smallTitle" colspan="2" valign="top" style="width: 800px;
                            border-width: 0px">
                            <asp:Panel ID="resultados" CssClass="smallTitle" runat="server">
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    <%--    </form>
</body>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="ContentHeader">
    <asp:HiddenField ID="idcli" runat="server" />
    <asp:HiddenField ID="hdnLat" runat="server" Value="-58.3657287" />
    <asp:HiddenField ID="hdnLng" runat="server" Value="-34.7504784" />
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="menuJQUERY">
    <style type="text/css">
        .style5
        {
            height: 30px;
            width: 942px;
        }
    </style>
</asp:Content>
