<%@ page language="C#" masterpagefile="~/MasterPage.master" theme="SampleSiteTheme" enableeventvalidation="false" autoeventwireup="true" inherits="Vistas_ViewGestionDeDeudores, App_Web_nu_04hm5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
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
	    
	    alert('you clicked item "' + $(this).text() + e  + '"');
	    
	    document.location='http://localhost/vistas/ViewImportacionDeFacturas.aspx';
	            

	}};

});
-->
 
    </script>

    <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
	            var ModalProgress = '<%= ModalProgress.ClientID %>';   
                var ModalNuevoDeudor = '<%= ModalNuevoDeudor.ClientID %>';
                var ModalmpeSeleccion = '<%= mpeSeleccion.ClientID %>';
                var ModalextPnlEditarGrilla = '<%= extPnlEditarGrilla.ClientID %>';
                
              		
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
                
                

function beginReq(sender, args) 
{

	var controlCaller=args.get_postBackElement().id;
   
    if(controlCaller.indexOf('Button1')!=-1){$find(ModalProgress).show();}
    if(controlCaller.indexOf('btnAgregarDeudor')!=-1){$find(ModalProgress).show()};
    if(controlCaller.indexOf('GvResultados')!=-1){$find(ModalProgress).show()};
       
 }

function endReq(sender, args)
{
	                        //  shows the Popup 
	                        $find(ModalProgress).hide();
} 

                    
function ShowConfirma() 
{
                       // $find(ModalNuevoDeudor).show();
}

function HideConfirma() 
{
             //           $find(ModalNuevoDeudor).hide();
}
function HideConfirma2() 
{
                        $find(ModalmpeSeleccion).hide();
}
function HideModalNuevoDeudor() 
{
                        $find(ModalmpeSeleccion).hide();
}

function HideEdicionDeudor() 
{
                        $find(ModalextPnlEditarGrilla).hide();
}

function ValidarEliminacion()
{
if (!confirm('Esta seguro que desa eliminar el registro seleccionado?'))
{

__doPostBack('ctl00$Contentplaceholder1$TabContainer1$TabPanel1$btnDelete','1');


}
else{



__doPostBack('ctl00$Contentplaceholder1$TabContainer1$TabPanel1$btnDelete','2');
              

}
}


function CambiarTab()
{

var a=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_ClientState'); 
alert('si');
a.value='{&quot;ActiveTabIndex&quot;:2,&quot;TabState&quot;:[true,true,true]}';

}

    </script>

    <script type="text/javascript"> 
    function actualizar() 
    { 
        PageMethods.actualizar (actualizarOK, actualizarFAIL);  
    } 
    function actualizarOK(result) 
    {        
        $get('l1').innerHTML = result;            
    } 

    function actualizarFAIL(error) 
    { 
        $get('l1').innerHTML = "Intentelo mas tarde"; 
    } 
    
    
    function QuitarValidatorsDesdeElCliente()
    {

       Array.remove(Page_Validators, document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_RequiredFieldValidatorNombreNuevo'));
       Array.remove(Page_Validators, document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_RequiredFieldValidatorCuitNuevo'));
       Array.remove(Page_Validators, document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_RequiredFieldValidatorDomicilioNuevo'));
       Array.remove(Page_Validators, document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_RequiredFieldValidatorLocaNuevo'));
       Array.remove(Page_Validators, document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_RequiredFieldValidatorProvNuevo'));
       Array.remove(Page_Validators, document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_RequiredFieldValidatorCPNuevo'));
       Array.remove(Page_Validators, document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_RequiredFieldValidatorTelNuevo'));
       Array.remove(Page_Validators, document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel1_RequiredFieldValidatorTelAuxNuevo'));
       
       var checkDeudor=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_radioDeudor');
       var descriptionDeudor=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_rdoDescripcion');
       var textboxDescription=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtDescDeudor');
       var textboxIdDeudor=document.getElementById('ctl00_Contentplaceholder1_TabContainer1_TabPanel2_txtId_Deudor');
       var fieldError = document.getElementById('ctl00$Contentplaceholder1$hiddenFieldError');
       fieldError.value='NoError';
       if (checkDeudor.checked)
       {
         if (descriptionDeudor.checked)
         {
           if (textboxDescription.value=='')
           {
             alert('Ingrese el nombre o parte de él para realizar la búsqueda.');
             fieldError.value='Error';
             return;
           }
           
         }else
         {
         
             if (textboxIdDeudor.value=='')
             {
                 alert('Ingrese el id de deudor para realizar la búsqueda.');
                 fieldError.value='Error';
                 return;
             }
             
             if (isNaN(textboxIdDeudor.value))
             {
                 alert('Ingrese un valor numérico para el id de deudor a buscar.');
                 fieldError.value='Error';
                 return;
             }
             
         }
       }
  
  
  
}
  
    </script>

    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
    <%--    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>--%>
    <asp:panel id="panelUpdateProgress" runat="server" cssclass="updateProgress">
			<asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
				<ProgressTemplate>
					<div style="position: relative; top: 30%; text-align: center;">
						<img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
						Procesando...
					</div>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</asp:panel>
    <asp:panel id="pnlNuevoDeudor" runat="server">
		<div id="div2">
            <table border="0" cellpadding="0" cellspacing ="7">
                <tr>
                     <td class="FondoCelda"> &nbsp;</td>
                     <td class="FondoCelda" colspan="2">
                         <asp:Label runat="server" ID="Label3" CssClass="label" 
                         Text="¿Confirma que desea realiza los cambios en la base de datos? "></asp:Label>
                    </td>
                     <td class="FondoCelda"> &nbsp;</td>
               </tr>
                <tr>
                    <td class="FondoCelda">&nbsp;</td>
                    <td class="FondoCelda" align="right" valign="middle">
                            
                     </td>
                     <td class="FondoCelda" align="left" valign="middle">
                        
                     </td>
                      <td class="FondoCelda"> &nbsp;</td>
                </tr>
              </table>
              </div>
    </asp:panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
    <ajaxToolkit:ModalPopupExtender ID="ModalNuevoDeudor" runat="server" TargetControlID="pnlNuevoDeudor"
        BackgroundCssClass="modalBackground" PopupControlID="pnlNuevoDeudor" />
    <asp:hiddenfield runat="server" id="hiddenFieldError"></asp:hiddenfield>
    <table align="center" style="height: 557px; width: 768px;">
        <tr style="height: 200px;">
            <td valign="top">
                <asp:updatepanel runat="server" id="UpdatePanelTabContainer" updatemode="Conditional">         
   <ContentTemplate>
    <ajaxToolkit:TabContainer runat="server" ID="TabContainer1" 
        Height="480px" Width="100%" ActiveTabIndex="0"
        onactivetabchanged="TabContainer1_ActiveTabChanged" AutoPostBack="true" >

        <ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="Factura" Enabled="true" Visible="true"><HeaderTemplate>Gestiones</HeaderTemplate><ContentTemplate>
            <table cellpadding="0" border="0" cellspacing="0" style="width:100%;height:332px; left:0;">
                <tr>
                    <td valign="top"  
                    style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666;font-weight: bold;font-size: 12px;background-color: #EDEBEB;border-right: #cccccc 2px solid;border-bottom: #cccccc 1px inset;text-align: left;" 
                    valign="middle"><asp:Label ID="lblAdmCasos" runat="server" >Análisis de Deudores</asp:Label></td></tr>
                <tr><td align="center" style="height: 149px" valign="top"><br />
                    <asp:UpdatePanel runat="server" ID="editionPanel">
                        <ContentTemplate><table style="width:768px; height:88%;" class="borderCompleto" cellpadding="0" cellspacing="0"><tr><td width="100%;" class="fondo_Titulo" align="left" style="height: 23px">Filtros de Búsqueda </td></tr><tr><td><table width="80%"><tr align="left" style="border:3px; height:20px;"><td 
                                    align="left" bgcolor="#F2F2F2" class="border" 
                                    style="width:40px;border-width:1px; border-style:solid;" valign="top"><asp:UpdatePanel 
                                    ID="updatePanelRadio" runat="server"><ContentTemplate>
                                    
                                    
                                    <asp:RadioButton ID="radioDeudor" runat="server" 
                                        AutoPostBack="true" CssClass="subtitle" OnCheckedChanged="CambioDeFiltro" 
                                        Text="Deudor" />
                                        
                                        
                                        </ContentTemplate></asp:UpdatePanel></td><td align="left" bgcolor="#F2F2F2" 
                                    style="width:40px;border-width:1px; border-style:solid;" valign="top"><asp:RadioButton 
                                            ID="radioCliente" runat="server" AutoPostBack="true" CssClass="subtitle" 
                                            OnCheckedChanged="CambioDeFiltro" Text="Cliente" /></td><td 
                                    align="left" bgcolor="#F2F2F2" 
                                    style="width:70px;border-width:1px; border-style:solid;" valign="top"><asp:RadioButton 
                                        ID="radioAnalista" runat="server" AutoPostBack="true" CssClass="subtitle" 
                                        OnCheckedChanged="CambioDeFiltro" Text="Analista" /></td></tr><tr 
                                    align="left"><td align="left" style="width:70px; border-width:1px; border-style:solid;" 
                                        valign="top"><asp:Panel ID="panelDeudor" runat="server" Height="62px">
                                        <asp:RadioButton ID="rdoDescripcion" runat="server" GroupName="FiltroDeudor" Checked="true"/>
                                        <asp:Label ID="lblDescripcion" runat="server" style="font-family: Verdana;font-size: 9px;" 
                                                Text="Descripción"></asp:Label><br />
                                        <asp:TextBox ID="txtDescDeudor" runat="server"  CssClass="textboxEditor" MaxLength="50"></asp:TextBox><br /><br />
                                        <asp:RadioButton ID="rdoIdDeudor" runat="server" GroupName="FiltroDeudor" />
                                                <asp:Label ID="lblIdDeudor" runat="server" style="font-family: Verdana;font-size: 9px;" 
                                                    Text="Id Deudor"></asp:Label><br /><asp:TextBox ID="txtId_Deudor" runat="server"
                                                        CssClass="textboxEditor" MaxLength="6"></asp:TextBox>
                                                        
                                                
                                                </asp:Panel></td><td align="left" style="width:40px;border-width:1px; border-style:solid;" 
                                        valign="top"><table><tr><td valign="top"><asp:Panel ID="panelCliente" runat="server"><asp:Label ID="lblCliente" 
                                                        runat="server" style="font-family: Verdana;font-size: 9px;" Text="Nombre"></asp:Label><br /><ajaxToolkit:ComboBox 
                                                        ID="cmbClientes" runat="server" AutoCompleteMode="SuggestAppend" 
                                                        BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" 
                                                        DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" 
                                                        Height="16px" MaxLength="0" Width="100px"><asp:ListItem>gps</asp:ListItem><asp:ListItem>Fravega</asp:ListItem><asp:ListItem>Sony</asp:ListItem><asp:ListItem>Avely</asp:ListItem><asp:ListItem>RsSoft</asp:ListItem><asp:ListItem>Garbarino</asp:ListItem></ajaxToolkit:ComboBox></asp:Panel></td><td 
                                                    style="border-right-width:2px; border-right-style:solid;border-left-width:2px; border-left-style:solid;"><asp:Panel 
                                                        ID="panelFacturas" runat="server"><asp:Label ID="lblFiltrosFacturas" 
                                                            runat="server" style="font-family: Verdana;font-size: 9px;" 
                                                            Text="Estado Factura"></asp:Label><br /><asp:RadioButtonList 
                                                            ID="radioEstadoFactura" runat="server" AutoPostBack="True" Font-Names="Verdana" 
                                                            Font-Size="9px" OnSelectedIndexChanged="CambioDeFiltro"><asp:ListItem Value="1">Todos</asp:ListItem><asp:ListItem 
                                                                Value="2">A vencer 5 días</asp:ListItem><asp:ListItem Value="3">A vencer 5 a 15 días</asp:ListItem><asp:ListItem 
                                                                Value="4">A vencer + 15 días</asp:ListItem></asp:RadioButtonList></asp:Panel></td><td valign="top"><asp:Panel ID="panelFechaCheque" runat="server"><table><tr><td><asp:RadioButton 
                                                        ID="radioAVencer" runat="server" AutoPostBack="true" 
                                                        OnCheckedChanged="CambioDeFiltro" style="font-family: Verdana;font-size: 9px;" 
                                                        Text="A vencer entre" /></td></tr><tr><td><asp:Label ID="Label1" runat="server" 
                                                            style="font-family: Verdana;font-size: 9px;" Text="Fecha desde"></asp:Label><br /><asp:TextBox 
                                                            ID="txtFechaDesde" runat="server" CssClass="textboxEditor" 
                                                            ValidationGroup="MKE" Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender 
                                                            ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                                            PopupButtonID="imgFechaDesde" TargetControlID="txtFechaDesde" /><ajaxToolkit:MaskedEditExtender 
                                                            ID="MaskedEditExtenderFechaDesde" runat="server" AcceptNegative="Left" 
                                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" DisplayMoney="Left" 
                                                            Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" 
                                                            TargetControlID="txtFechaDesde" /><ajaxToolkit:MaskedEditValidator 
                                                            ID="MaskedEditValidator1" runat="server" 
                                                            ControlExtender="MaskedEditExtenderFechaDesde" 
                                                            ControlToValidate="txtFechaDesde" Display="None" 
                                                            EmptyValueMessage="El campo fecha desde no puede esta vacío" 
                                                            ErrorMessage="MaskedEditValidator1" InvalidValueMessage="Fecha Desde invalida" 
                                                            IsValidEmpty="False" /><img id="imgFechaDesde" alt="FechaDesde" onmouseover="this.style.cursor='pointer'"
                                                            src="../Images/Calendar.png" /></td></tr><tr><td><asp:Label 
                                                            ID="lblFEnvioLegajo" runat="server" 
                                                            style="font-family: Verdana;font-size: 9px;" Text="Fecha hasta"></asp:Label><br /><asp:TextBox 
                                                            ID="txtFechaHasta" runat="server" CssClass="textboxEditor" 
                                                            ValidationGroup="MKE" Width="83px"></asp:TextBox><ajaxToolkit:CalendarExtender 
                                                            ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                                            PopupButtonID="imgFechaHasta" TargetControlID="txtFechaHasta" /><ajaxToolkit:MaskedEditExtender 
                                                            ID="MaskedEditExtenderFechaHasta" runat="server" AcceptNegative="Left" 
                                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" DisplayMoney="Left" 
                                                            Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" 
                                                            TargetControlID="txtFechaHasta" /><ajaxToolkit:MaskedEditValidator 
                                                            ID="MaskedEditValidator2" runat="server" 
                                                            ControlExtender="MaskedEditExtenderFechaHasta" 
                                                            ControlToValidate="txtFechaHasta" Display="None" 
                                                            EmptyValueMessage="El campo fecha hasta no puede esta vacío" 
                                                            ErrorMessage="MaskedEditValidator1" InvalidValueMessage="Fecha Hasta invalida" 
                                                            IsValidEmpty="False" /><img id="imgFechaHasta" alt="imgFechaHasta" onmouseover="this.style.cursor='pointer'"
                                                            src="../Images/Calendar.png" />
                                                            <br/>
                                                            
                                                            <asp:CompareValidator runat="server" ErrorMessage="*" ControlToCompare="txtFechaDesde" ControlToValidate="txtFechaHasta" Operator="GreaterThan" Type="Date"></asp:CompareValidator>
                                                            
                                                            </td></tr></table></asp:Panel></td></tr></table></td><td style="width:70px; border-width:1px; border-style:solid;" valign="top"><asp:Panel 
                                            ID="panelAnalista" runat="server"><asp:Label ID="Label2" runat="server" 
                                            style="font-family: Verdana;font-size: 9px;" Text="Nombre"></asp:Label><br />
                                            <ajaxToolkit:ComboBox ID="cmbAnalistas" runat="server" AutoCompleteMode="SuggestAppend"                                             
                                            BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px"                                             
                                            Height="16px" MaxLength="0" Width="100px"></ajaxToolkit:ComboBox></asp:Panel></td></tr><tr align="left"><td align="left" style="width:70px;">&#160;</td><td align="left" 
                                        style="width:70px;">&#160;</td><td align="right"><asp:Button ID="Button1" 
                                            runat="server" CssClass="button_back" OnClientClick="QuitarValidatorsDesdeElCliente();" OnClick="Visualizar_Click" 
                                             Text="Visualizar"></asp:Button></td></tr></table></td></tr><tr><td></td></tr><tr><td>
                                            
                                            <table cellpadding="0" cellspacing="0" class="borderCompleto" 
                                             style="width:900px; height:88%;"><tr><td align="left" class="fondo_Titulo" style="height: 23px" width="100%;"><table width="100%"><tr><td></td><td style="width:100%; height:30px;">Resultados </td><td valign="top"><asp:ImageButton ID="ImageButton3" runat="server"  ImageUrl="~/Images/excel_small.gif" OnClick="GvResultados_Exporting"/></td></tr></table></td></tr><tr><td valign="top"><asp:Panel ID="PnlListaCarga" runat="server" CssClass="scrollbar" 
                                                         Height="112px" Width="768px" ScrollBars="Horizontal">
                                                         
                                                         <ma:XGridView ID="GvResultados" runat="server" AllowPaging="True" 
                                                             AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" 
                                                             DataKeyNames="idDeudor" EmptyDataText="No se encontraron resultados" 
                                                             ExecutePageIndexChanging="True" OnFilling="GvResultados_Filling" 
                                                             OnPageIndexChanging="GvResultados_PageIndexChanging" 
                                                             OnRowDataBound="GvResultados_RowDataBound" PageSize="5" Width="768px" 
                                                             onrowediting="GvResultados_RowEditing" OnRowDeleting="GvResultados_RowDeleting" 
                                                             OnRowCommand="GvResultados_RowCommand"  onExporting="GvResultados_Exporting"
                                                               ShowFooter="True"><AlternatingRowStyle CssClass="gvAlternatingItem" /><Columns><asp:TemplateField><HeaderTemplate><asp:CheckBox ID="chkAll" Runat="Server" AutoPostBack="true" 
                                                                             OnCheckedChanged="chkAll_CheckedChanged" /></HeaderTemplate><ItemTemplate><asp:CheckBox ID="chk" Runat="Server" /></ItemTemplate></asp:TemplateField><asp:CommandField  ButtonType="Image"                                                                                                        
                                                                                                          EditImageUrl="~/Images/editar.gif"
                                                                                                         ShowEditButton="True" 
                                                                                                         HeaderText="Editar" ><HeaderStyle Font-Bold="True" /><itemstyle width="5%"  HorizontalAlign="Center"  /></asp:CommandField><asp:TemplateField HeaderText="Eliminar"><ItemTemplate><asp:ImageButton    OnClientClick ="return confirm('¿Esta seguro que desea eliminar el registro?');" Visible="true" ID="btnDelete" runat="server" ImageUrl="~/Images/delete.gif" CommandName="Delete"  /></ItemTemplate><HeaderStyle Font-Bold="True" /></asp:TemplateField>
                                                                                            <asp:BoundField DataField="idDeudor" HeaderText="idDeudor" 
                                                                     SortExpression="idDeudor" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                     
                                                                     <asp:BoundField DataField="Cliente" HeaderText="Cliente" 
                                                                     SortExpression="Cliente" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                     
                                                                     <asp:BoundField DataField="nombre" HeaderText="Nombre" 
                                                                     SortExpression="nombre"  ><HeaderStyle Font-Bold="True" /></asp:BoundField><asp:BoundField DataField="Cuit" HeaderText="Cuit" ><HeaderStyle Font-Bold="True" /></asp:BoundField><asp:BoundField DataField="domicilio" HeaderText="Domicilio" 
                                                                     SortExpression="domicilio" ><HeaderStyle Font-Bold="True" /></asp:BoundField><asp:BoundField DataField="localidad" HeaderText="Localidad" 
                                                                     SortExpression="localidad" ><HeaderStyle Font-Bold="True" /></asp:BoundField><asp:BoundField DataField="provincia" HeaderText="Provincia" ><HeaderStyle Font-Bold="True" /></asp:BoundField><asp:BoundField DataField="cp" HeaderText="Código Postal" ><HeaderStyle Font-Bold="True" /></asp:BoundField><asp:BoundField DataField="telefono" HeaderText="telefono" 
                                                                     SortExpression="telefono" ><HeaderStyle Font-Bold="True" /></asp:BoundField><asp:BoundField DataField="Telefono_Aux" HeaderText="Tel. Auxiliar" ><HeaderStyle Font-Bold="True" /></asp:BoundField><asp:BoundField DataField="fax" HeaderText="Fax" ><HeaderStyle Font-Bold="True" /></asp:BoundField><asp:BoundField DataField="email" HeaderText="Email" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                     <asp:BoundField DataField="anticipoGestion" HeaderText="Anticipo" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                      <asp:BoundField DataField="idDomicilioDeudor" HeaderText="idDomicilioDeudor" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                     <asp:BoundField HeaderText="Observaciones" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                     
                                                                     
                                                                     </Columns><EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" /><EmptyDataTemplate>No se hallaron resultados.</EmptyDataTemplate><FooterStyle CssClass="gvHeader grayGvHeader" /><HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" /><PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" /><RowStyle CssClass="gvItem" /></ma:XGridView>
                                                          
                                                          <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource></asp:Panel></td><tr><td><table width="100%"><tr><td align="left" valign="top" align="center" 
                                                                     style="height: 10px; font-family: Tahoma, Arial, MS Sans Serif; color: #666666;font-weight: bold;font-size: 12px;text-align: left;padding-left:60px; width:30px;"></td><td align="left" 
                                                                     valign="top"></td><td></td><td align="right" style="padding-right:32px;"><ma:SecureButton ID="btnExportar" runat="server" CssClass="button_back" 
                                                                         OnClick="Exportar_Click" 
                                                                         OnClientClick="Javascript:VerificarResultado(); return true;" Text="Exportar" 
                                                                         Visible="False" Height="20px" /><asp:Label ID="lblResultado" runat="server"   CssClass="bigLabel" Text="Resultados Obtenidos:"></asp:Label></td></tr></table></td></tr></tr>
                                                                         
                                                                         </table>
                                                                         
                                                                         
                                                                         </td></tr></table></ContentTemplate></asp:UpdatePanel></td></tr>
                <tr><td align="left">
                    <table><tr><td style="width:191px;"></td><td>
                            <asp:Panel ID="pnlSeleccionarDatos" runat="server" Style="display: none;"><asp:UpdatePanel 
                                    ID="pnlNuevoDeudorAjax" runat="server"><ContentTemplate>
                                        <div 
                                        style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666;font-weight: bold;font-size: 16px;background-color: #EDEBEB;border-right: #cccccc 2px solid;border-bottom: #cccccc 1px inset;text-align: left; height:20px; width:400px; text-align:center;"><table><tr>
                                                <td align="center"><asp:Label ID="Label4" runat="server" 
                                                        Text="   Datos Del Deudor" /></td></tr></table></div>
                                        <div 
                                        style="height:179px; width:400px; background-color: #ffffff;  border-right: #cccccc 2px solid;border-bottom: #cccccc 1px inset; text-align:center;"><br /><table 
                                                style="width: 310px"><tr><td>
                                                    <asp:Label ID="lblNombre" runat="server" CssClass="labelBold" Text="Nombre:" /></td><td>
                                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombreNuevo" 
                                                            runat="server" ControlToValidate="txtNombre" Enabled="false" 
                                                            ErrorMessage="Ingrese el nombre"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblCuit" runat="server" CssClass="labelBold" Text="Cuit:" /></td>
                                                    <td><asp:TextBox ID="txtCuit" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCuitNuevo" runat="server" 
                                                            ControlToValidate="txtCuit" Enabled="false" ErrorMessage="Ingrese el Cuit"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblDomicilio" runat="server" CssClass="labelBold" 
                                                        Text="Domicilio:" /></td>
                                                    <td><asp:TextBox ID="txtDomicilio" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDomicilioNuevo" 
                                                            runat="server" ControlToValidate="txtDomicilio" Enabled="false" 
                                                            ErrorMessage="Ingrese el domicilio"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblLocalidad" runat="server" CssClass="labelBold" 
                                                        Text="Localidad:" /></td>
                                                    <td><asp:TextBox ID="txtLocalidad" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocaNuevo" runat="server" 
                                                            ControlToValidate="txtLocalidad" Enabled="false" 
                                                            ErrorMessage="Ingrese la localidad"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblProvincia" runat="server" CssClass="labelBold" 
                                                        Text="Provincia:" /></td>
                                                    <td><asp:TextBox ID="txtProvincia" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorProvNuevo" runat="server" 
                                                            ControlToValidate="txtProvincia" Enabled="false" 
                                                            ErrorMessage="Ingrese la provincia"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblCp" runat="server" CssClass="labelBold" 
                                                        Text="Código Postal:" /></td><td><asp:TextBox ID="txtCp" runat="server" 
                                                            CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td></td><td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCPNuevo" runat="server" 
                                                        ControlToValidate="txtCp" Enabled="false" 
                                                        ErrorMessage="Ingrese el Código Postal"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblTelefono" runat="server" CssClass="labelBold" 
                                                        Text="Teléfono:" /></td>
                                                    <td><asp:TextBox ID="txtTelefono" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelNuevo" runat="server" 
                                                            ControlToValidate="txtTelefono" Enabled="false" 
                                                            ErrorMessage="Ingrese el teléfono"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblTelAux" runat="server" CssClass="labelBold" 
                                                        Text="Teléfono Aux.:" /></td><td>
                                                        <asp:TextBox ID="txtTelefonoAux" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelAuxNuevo" 
                                                            runat="server" ControlToValidate="txtTelefonoAux" Enabled="false" 
                                                            ErrorMessage="Ingrese el teléfono auxiliar"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblFax" runat="server" CssClass="labelBold" Text="Fax:" /></td>
                                                    <td><asp:TextBox ID="txtFax" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td></td></tr><tr>
                                                <td><asp:Label ID="lblEmail" runat="server" CssClass="labelBold" Text="Email:" /></td>
                                                <td><asp:TextBox ID="txtEmail" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td></td><td></td></tr>
                                                <tr><td><asp:Label ID="lblAnticipo" runat="server" CssClass="labelBold" 
                                                        Text="Anticipo Gestión:" /></td><td>
                                                        <asp:TextBox ID="txtAnticipo" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td></td><td></td></tr></table></div>
                                        <div 
                                        style="height:30px; width:400px; background-color: #ffffff;border-right: #cccccc 2px solid;border-bottom: #cccccc 1px inset; text-align:center;"><table><tr>
                                                <td>
                                                    <asp:Button ID="btnAceptar" runat="server" CssClass="button_back" 
                                                        onclick="btnAceptar_Click" Text="Guardar" /></td>
                                                <td align="right"><input id="btnCancelar" class="button_back" 
                                                        onclick="javascript:HideConfirma2();" type="button" value="Cancelar" /> </td></tr></table></div>
                                </ContentTemplate>
                                </asp:UpdatePanel></asp:Panel>
                                
                            <ajaxToolkit:ModalPopupExtender ID="mpeSeleccion" runat="server" 
                            BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True" 
                            PopupControlID="pnlSeleccionarDatos" TargetControlID="HiddenField2" />
                            
                            <asp:HiddenField 
                            ID="HiddenField2" runat="server" />
                            
                            
                            <asp:UpdatePanel ID="UpdatePanel1" 
                            runat="server"><ContentTemplate>
                                    <asp:ImageButton ID="btnSubirMasivo" runat="server" 
                                ImageUrl="~/Images/upload2.gif" OnClick="NuevoDeudor" />
                                    <asp:Label ID="lblSubirMasivo" runat="server" CssClass="labelBold" 
                                Text="Subir Deudores Masivamente"></asp:Label>&nbsp;&nbsp;
                                
                                    <asp:ImageButton ID="btnGestionDomicilios" runat="server" 
                                ImageUrl="~/Images/nuevoDomicilio.png" OnClick="GestionarDomicilios" />
                                    <asp:Label ID="lblGestionarDomicilios" runat="server" CssClass="labelBold" 
                                Text="Gestionar Domicilios"></asp:Label>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        
                        
                        
                            <asp:Panel ID="pnlEditarDatosGrilla" runat="server" Style="display: none;"><asp:UpdatePanel 
                                    ID="pnlEditarDatos_Grilla" runat="server">
                                    <ContentTemplate>
                                        <div 
                                            style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666;font-weight: bold;font-size: 16px;background-color: #EDEBEB;border-right: #cccccc 2px solid;border-bottom: #cccccc 1px inset;text-align: left; height:20px; width:400px; text-align:center;"><table><tr>
                                                <td align="center"><asp:Label ID="Label5" runat="server" 
                                                        Text="  Edicion de los datos del deudor" /></td></tr></table></div>
                                        <div 
                                            style="height:479px; width:400px; background-color: #ffffff;  border-right: #cccccc 2px solid;border-bottom: #cccccc 1px inset; text-align:center;"><br /><table 
                                                style="width: 310px"><tr><td>
                                                    <asp:Label ID="lblNombre2" runat="server" CssClass="labelBold" Text="Nombre:" /></td><td>
                                                        <asp:TextBox ID="txtNombre2" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombreEdicion" 
                                                            runat="server" ControlToValidate="txtNombre2" Enabled="false" 
                                                            ErrorMessage="Ingrese el nombre"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblCuit2" runat="server" CssClass="labelBold" Text="Cuit:" /></td>
                                                    <td><asp:TextBox ID="txtCuit2" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td></td></tr><tr>
                                                <td><asp:Label ID="lblDomicilio2" runat="server" CssClass="labelBold" 
                                                        Text="Domicilio:" /></td>
                                                <td><asp:TextBox ID="txtDomicilio2" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDomicilioEdicion" 
                                                            runat="server" ControlToValidate="txtDomicilio2" Enabled="false" 
                                                            ErrorMessage="Ingrese el domicilio"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblLocalidad2" runat="server" CssClass="labelBold" 
                                                        Text="Localidad:" /></td>
                                                    <td><asp:TextBox ID="txtLocalidad2" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocaEdicion" 
                                                            runat="server" ControlToValidate="txtLocalidad2" Enabled="false" 
                                                            ErrorMessage="Ingrese la localidad"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblProvincia2" runat="server" CssClass="labelBold" 
                                                        Text="Provincia:" /></td>
                                                    <td><asp:TextBox ID="txtProvincia2" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorProvEdicion" 
                                                            runat="server" ControlToValidate="txtProvincia2" Enabled="false" 
                                                            ErrorMessage="Ingrese la provincia"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblCp2" runat="server" CssClass="labelBold" 
                                                        Text="Código Postal:" /></td><td>
                                                        <asp:TextBox ID="txtCp2" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td></td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCPEdicion" runat="server" 
                                                            ControlToValidate="txtCp2" Enabled="false" 
                                                            ErrorMessage="Ingrese el Código Postal"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblTelefono2" runat="server" CssClass="labelBold" 
                                                        Text="Teléfono:" /></td>
                                                    <td><asp:TextBox ID="txtTelefono2" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelEdicion" 
                                                            runat="server" ControlToValidate="txtTelefono2" Enabled="false" 
                                                            ErrorMessage="Ingrese el teléfono"></asp:RequiredFieldValidator></td></tr>
                                                <tr><td><asp:Label ID="lblTelAux2" runat="server" CssClass="labelBold" 
                                                        Text="Teléfono Aux.:" /></td><td>
                                                        <asp:TextBox ID="txtTelefonoAux2" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td></td></tr><tr>
                                                <td><asp:Label ID="lblFax2" runat="server" CssClass="labelBold" Text="Fax:" /></td>
                                                <td><asp:TextBox ID="txtFax2" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td>&#160;</td>
                                                    <td></td></tr><tr>
                                                <td><asp:Label ID="lblEmail2" runat="server" CssClass="labelBold" Text="Email:" /></td>
                                                <td><asp:TextBox ID="txtEmail2" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td></td>
                                                    <td></td></tr><tr>
                                                <td><asp:Label ID="lblAnticipo2" runat="server" CssClass="labelBold" 
                                                        Text="Anticipo Gestión:" /></td>
                                                <td><asp:TextBox ID="txtAnticipo2" runat="server" CssClass="textboxEditor"></asp:TextBox></td></tr>
                                                <tr><td></td>
                                                    <td></td></tr><tr>
                                                <td></td><td>
                                                <asp:TextBox ID="txtIdDeudor2" runat="server" CssClass="textboxEditor" 
                                                    Visible="false"></asp:TextBox></td></tr></table></div>
                                        <div 
                                            style="height:30px; width:400px; background-color: #ffffff;border-right: #cccccc 2px solid;border-bottom: #cccccc 1px inset; text-align:center;"><table><tr>
                                                <td><asp:Button ID="btnGuardar2" runat="server" CssClass="button_back" 
                                                        onclick="GuardarEdicion" Text="Guardar" /></td><td align="right"><input 
                                                        id="btnCancelar2" class="button_back" onclick="javascript:HideEdicionDeudor();" 
                                                        type="button" value="Cancelar" /> </td></tr></table></div>
                                </ContentTemplate>
                                </asp:UpdatePanel></asp:Panel>
                                
                            <ajaxToolkit:ModalPopupExtender ID="extPnlEditarGrilla" runat="server" 
                            BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True" 
                            PopupControlID="pnlEditarDatosGrilla" TargetControlID="fielHidden" />
                            <asp:HiddenField ID="fielHidden" runat="server" />
 
                            </td>
                        <td></td></tr></table></td></tr></table></ContentTemplate></ajaxToolkit:TabPanel>                                
        
        </ajaxToolkit:TabContainer>
    
</ContentTemplate>

</asp:updatepanel>
            </td>
        </tr>
    </table>
    <%--    </form>
</body>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="Server">
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
