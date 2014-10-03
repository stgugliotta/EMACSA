<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Theme="SampleSiteTheme"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="ViewABMDomicilio.aspx.cs"
    Inherits="Vistas_ViewABMDomicilio" %>

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
                	
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);

function beginReq(sender, args) 
{
        	 
}
function endReq(sender, args)
{

} 




    </script>

    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
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
                                        <asp:panel id="pnlSeleccionarDatos" runat="server">
                                         <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; 
                                                 text-align: left; height: 26px; width: 800px;
                                                ">
                                                <table width="50%">
                                                    <tr>
                                                        <td align="left" style="width:50%;">
                                                           
                                                            <asp:RadioButtonList runat="server" id="radioButtonAbm" 
                                                                RepeatDirection="Horizontal" style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB;
                                                text-align: left; height: 20px;
                                                " Width="177px" AutoPostBack="True" 
                                                                onselectedindexchanged="radioButtonAbm_SelectedIndexChanged">
                                                                
                                                                
                                                                <asp:ListItem Selected="True">Edition</asp:ListItem>
                                                                <asp:ListItem>Nuevo</asp:ListItem>
                                                                
                                                                
                                                                </asp:RadioButtonList>
                                                            
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                           
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; height: 20px; width: 800px;
                                                text-align: center;">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label4" runat="server" Text="   Domicilios Del Deudor" /> &nbsp;
                                                            <asp:Label ID="lblDeudor" runat="server" Text="" />&nbsp;
                                                            <asp:Label ID="lblIdDeudor" runat="server" Text="" />
                                                            
                                                            
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                                   
                                                <table style="width: 400px;">
                                                <tr>
                                                    <td colspan="2">
                                                             <ma:XGridView ID="GvResultados" runat="server" AllowPaging="True" 
                                                             AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" 
                                                             DataKeyNames="id" EmptyDataText="No se encontraron resultados" 
                                                             ExecutePageIndexChanging="True" OnFilling="GvResultados_Filling" 
                                                             
                                                             OnRowDataBound="GvResultados_RowDataBound" PageSize="50" Width="768px" 
                                                             onrowediting="GvResultados_RowEditing" OnRowDeleting="GvResultados_RowDeleting"
                                                             
                                                               ShowFooter="True" onselectedindexchanged="GvResultados_SelectedIndexChanged"><AlternatingRowStyle CssClass="gvAlternatingItem" /><Columns>
                                                                     <asp:CommandField HeaderText="Editar" ShowCancelButton="False" 
                                                                         ShowHeader="True" ShowSelectButton="True" SelectText="Editar" />
                                                                     <asp:TemplateField HeaderText="Eliminar"><ItemTemplate><asp:ImageButton    OnClientClick ="return confirm('¿Esta seguro que desea eliminar el registro?');" Visible="true" ID="btnDelete" runat="server" ImageUrl="~/Images/delete.gif" CommandName="Delete"  /></ItemTemplate><HeaderStyle Font-Bold="True" /></asp:TemplateField>
                                                                                           
                                                                                            <asp:BoundField DataField="IdDomicilioDeudorAlternativo" HeaderText="Id. Dom Alt" 
                                                                     SortExpression="Id. Dom Alt" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                      
                                                                                            <asp:BoundField DataField="id" HeaderText="id" 
                                                                     SortExpression="id" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                      
                                                                      <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" 
                                                                     SortExpression="Domicilio" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                      
                                                                      <asp:BoundField DataField="Localidad" HeaderText="Localidad" 
                                                                     SortExpression="Localidad" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                      <asp:BoundField DataField="Partido" HeaderText="Partido" 
                                                                     SortExpression="Partido" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                      <asp:BoundField DataField="Provincia" HeaderText="Provincia" 
                                                                     SortExpression="Provincia" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                      <asp:BoundField DataField="Pais" HeaderText="Pais" 
                                                                     SortExpression="Pais" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                     
                                                                        <asp:BoundField DataField="Cp" HeaderText="Cp" 
                                                                     SortExpression="Cp" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                     
                                                                       <asp:BoundField DataField="DirPpal" HeaderText="Dirección Principal" 
                                                                     SortExpression="Dirección Principal" ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                     
                                                                     
                                                                     </Columns><EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" /><EmptyDataTemplate>No se hallaron resultados.</EmptyDataTemplate><FooterStyle CssClass="gvHeader grayGvHeader" /><HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" /><PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" /><RowStyle CssClass="gvItem" /></ma:XGridView>
                                                                     
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                   <td colspan="2" align="right">
                                                   <br />
                                                      <%-- <ma:SecureButton ID="btnNuevoDomicilio" runat="server" CausesValidation="True" CssClass="button_back"
                                                    Height="20px" OnClick="btnNuevoDomicilio_Click" TabIndex="20" Text="Nuevo Domicilio" ValidationGroup="datosGroup"
                                                     Width="95px" />--%>
                                                   </td>
                                                </tr>

                                                    <tr align="left">
                                                  
                                                        <td>
                                                            <asp:Label ID="lblPais" runat="server" CssClass="labelBold" Text="País:" />
                                                        </td>
                                                        <td>
                                                          <asp:UpdatePanel runat="server" ID="updatePanelPais" UpdateMode="Always">
                                                          <ContentTemplate>
                                                            <ajaxToolkit:ComboBox ID="cmbPais" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="cmbPais_SelectedIndexChanged">
                                                            </ajaxToolkit:ComboBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPaisNuevo" runat="server" ControlToValidate="cmbPais"
                                                                Enabled="false" ErrorMessage="Ingrese el país" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblProvincia" runat="server" CssClass="labelBold" Text="Provincia:" />
                                                        </td>
                                                        <td>
                                                         <asp:UpdatePanel runat="server" ID="updatePanelProvincia" UpdateMode="Always">
                                                          <ContentTemplate>
                                                            <ajaxToolkit:ComboBox ID="cmbProvincia" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="cmbProvincia_SelectedIndexChanged">
                                                            </ajaxToolkit:ComboBox>
                                                            
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorProvNuevo" runat="server" ControlToValidate="cmbProvincia"
                                                                Enabled="false" ErrorMessage="Ingrese la provincia" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblDepartamento" runat="server" CssClass="labelBold" Text="Departamento/Partido:" />
                                                        </td>
                                                        <td>
                                                         <asp:UpdatePanel runat="server" ID="updatePanelDepartamento" UpdateMode="Always">
                                                          <ContentTemplate>
                                                            <ajaxToolkit:ComboBox ID="cmbDepartamento" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="cmbDepartamento_SelectedIndexChanged">
                                                            </ajaxToolkit:ComboBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldDepartamento" runat="server" ControlToValidate="cmbDepartamento"
                                                                Enabled="false" ErrorMessage="Ingrese el departamento" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td>
                                                            <asp:Label ID="lblLocalidad" runat="server" CssClass="labelBold" Text="Localidad:" />
                                                        </td>
                                                        <td>
                                                        <asp:UpdatePanel runat="server" ID="updatePanelLocalidad" UpdateMode="Always">
                                                          <ContentTemplate>
                                                            <ajaxToolkit:ComboBox ID="cmbLocalidad" runat="server" AutoCompleteMode="SuggestAppend"
                                                                BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                                                MaxLength="0" Width="300px">
                                                            </ajaxToolkit:ComboBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocaNuevo" runat="server" ControlToValidate="cmbLocalidad"
                                                                Enabled="false" ErrorMessage="Ingrese la localidad" ValidationGroup="datosGroup"></asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                                </asp:UpdatePanel>
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
                                                            <%--<asp:UpdatePanel UpdateMode="Always">
                                                                <ContentTemplate>--%>
                                                                    <asp:Button ID="btnDomicilioGeolocalizado" runat="server" CssClass="button_back"
                                                                        Text="Domicilio Geolocalizado:" OnClick="btnDomicilioGeolocalizado_Click"  CausesValidation="false"/>
                                                      <%--          </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
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
                                                           <%-- <asp:UpdatePanel>
                                                                <ContentTemplate>--%>
                                                                    <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" Visible="true" EnableTheming="true" />
                                                            <%--    </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                         
                                     <%--     <asp:UpdatePanel runat="server" ID="updatePanelBtnAgregarPago" UpdateMode="Conditional">
                                            <ContentTemplate>--%>
                                                <table>
                                                    <tr>
                                                        <td>
                                                        <ma:SecureButton ID="btnNuevoDomicilio" runat="server" CausesValidation="True" CssClass="button_back"
                                                    Height="20px" OnClick="btnNuevoDomicilio_Click" TabIndex="20" Text="Nuevo Domicilio" ValidationGroup="datosGroup"
                                                     Width="95px" />
                                                        </td>
                                                        <td>
                                                         
                                                     
                                                <ma:SecureButton ID="btnAceptar" runat="server" CausesValidation="True" CssClass="button_back"
                                                    Height="20px" OnClick="btnAceptar_Click" TabIndex="20" Text="Guardar Edición" ValidationGroup="datosGroup"
                                                     Width="95px"  />
                                                    
                                                        </td>
                                                        <td align="right">
                                                            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="button_back" Visible="true"
                                                                OnClientClick="history.back();" Width="87px"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                                               <%--     </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                        </asp:panel>
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
                            <asp:panel id="resultados" cssclass="smallTitle" runat="server">
                            </asp:panel>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="ContentHeader">
    <asp:hiddenfield id="idcli" runat="server" />
    <asp:hiddenfield id="hdnLat" runat="server" value="-58.3657287" />
    <asp:hiddenfield id="hdnLng" runat="server" value="-34.7504784" />
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
