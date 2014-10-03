<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Vistas_ViewGestionAnalista, App_Web_nu_04hm5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="mkb" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
    <%--                         <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chk" runat="Server" /></ItemTemplate>
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="chkAll" runat="Server" AutoPostBack="true" 
                                                                                        OnCheckedChanged="chkAll_CheckedChanged" />
                                                                                </HeaderTemplate>
                                                                            </asp:TemplateField>
                                                            --%>
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />
    <script src="/Js/JsHelper.js" type="text/javascript"></script>
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

    <script type="text/javascript">
        function ValidarFechaReclamo() 
        {
         var cuandoCobrar = document.getElementById("ctl00_Contentplaceholder1_lblCuandoCobrar").innerHTML;
         if (cuandoCobrar=='')
         {
          alert('Para poder gestionar debe cargar día y horario de cobro');
          return false;
         }
        
            var pszFecha_reclamo = document.getElementById("ctl00_Contentplaceholder1_hdFecha_Reclamo").value;
            var arrDias = pszFecha_reclamo.split("-");
            var alertar = true;
            var Hoy = new Date();
            Hoy = Hoy.getDay();
            if (Hoy == 0)
                Hoy = 7;
            for (var i = 0; i < arrDias.length; i++) 
            {
                if (arrDias[i] == Hoy) 
                {
                    alertar = false;
                    break;
                }
            }
            if (alertar == true)
                return confirm("El día de reclamo no coincide con el día de hoy.¿Desea continuar?");
            else
                return true;
        }
    </script>

    <script type="text/javascript">
        var ModalPopupProntoPago = '<%= ModalPopupProntoPago.ClientID %>';
        function HideConfirma3() {

            var ModalPopupProntoPago = '<%= ModalPopupProntoPago.ClientID%>';
            $find(ModalPopupProntoPago).hide();
        }
        
        function HideHorariosReclamo() {

            var ModalPopupHorariosReclamo = '<%= ModalPopupHorariosReclamo.ClientID%>';
            $find(ModalPopupHorariosReclamo).hide();
        }	
        function HideHorariosCobro() {

            var ModalPopupHorariosCobro= '<%= ModalPopupHorariosCobro.ClientID%>';
            $find(ModalPopupHorariosCobro).hide();
        }	
        	    
    	  var ModalPopupCargando='<%= ModalPopupCargando.ClientID %>';
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
    
    function beginReq(sender, args) 
{

	var controlCaller=args.get_postBackElement().id;

    if(controlCaller.indexOf('btnBuscar')!=-1){$find(ModalPopupCargando).show()};

    
     
 }



function endReq(sender, args)
{

	                        $find(ModalPopupCargando).hide();
	                   
} 
    </script>
    

    <asp:panel id="panelUpdateProgress" runat="server" cssclass="updateProgress">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <ProgressTemplate>
                <div style="position: relative; top: 30%; text-align: center; height: 100%; width: 100%">
                    <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                    Procesando...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupCargando" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
    <table align="center" style="height: 557px; width: 1244px;">
        <tr style="height: 200px;">
            <td valign="top" class="style12">
                <table style="width: 950px; height: 100%;" class="borderCompleto" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td class="style17" align="left">
                            Gestión de facturas
                            <asp:panel runat="server" id="panelCliente0">
                                <br />
                            </asp:panel>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="center" class="style18">
                            <asp:panel id="Panel2" runat="server" cssclass="scrollbar" height="100%" width="98%"
                                scrollbars="None">
                             <asp:UpdatePanel runat="server" ID="UpdatePanelDatosDeudor" UpdateMode="Conditional">         
                             <ContentTemplate>
                                                                 
                            <table style="height: 432px">
                                <tr>
                                    <td valign="top" class="gvAlternatingItem">
                                        <table style="margin-top: 15px; height: 240px; width: 216px; margin-right: 0px; line-height: normal; left: 0px;" 
                                            align="left" class="gvAlternatingItem" rules="all" 
                                            title="Datos del Deudor" id="tblDeudorSeleccionado">
                                             <tr>
                                                <td align="left" class="style16">
                                                    <asp:Label ID="lblClienteDelDeudor" runat="server" Style="font-family: Verdana;
                                                        font-size: 10px; font-weight: bold;" Text="Cliente:"></asp:Label>
                                                        <asp:Label ID="lblClienteDelDeudorRes" runat="server" Height="16px" Style="font-family: Verdana;
                                                        font-size: 9px;" Width="200px"></asp:Label>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td align="left" class="style13">
                                                    <asp:Label ID="labelAlfaNumDelCliente" runat="server" Style="font-family: Verdana;
                                                        font-size: 10px; font-weight: bold;" Text="N° de Cliente:"></asp:Label>
                                                    <asp:Label ID="lblAlfaNumDelCliente" runat="server" Height="16px" Style="font-family: Verdana;
                                                        font-size: 9px;" Width="200px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style16">
                                                    <asp:Label ID="lblDeudorSeleccionado" runat="server" Style="font-family: Verdana;
                                                        font-size: 10px; font-weight: bold;" Text="Deudor Seleccionado"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style14" rowspan="1">
                                                    <asp:Label ID="lblResIdentificarDeudor" runat="server" Style="font-family: Verdana;
                                                        font-size: 9px;" visible="false"></asp:Label>
                                                    <asp:Label ID="lblResDeudorSeleccionado" runat="server" Style="font-family: Verdana;
                                                        font-size: 9px;" Height="16px" Width="200px"></asp:Label>
                                                </td>
                                            </tr>
                                            
                                            <tr  Height="11px">
                                            <td>
                                            </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style13">
                                                    <asp:Label ID="lblIdentificadorDeudor3" runat="server" Style="font-family: Verdana;
                                                        font-size: 10px; font-weight: bold;" Text="CUIT:"></asp:Label>
                                                    <asp:Label ID="lblCUIT" runat="server" Height="16px" Style="font-family: Verdana;
                                                        font-size: 9px;" Width="200px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr  Height="11px">
                                            <td>
                                            </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style38">
                                                    <asp:Label ID="labelDelTelefono" runat="server" Style="font-family: Verdana;
                                                        font-size: 10px; font-weight: bold;" Text="Tel"></asp:Label>
                                                    &nbsp;<asp:Label ID="lblTelefono" runat="server" Style="font-family: Verdana;
                                                        font-size: 9px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr  Height="11px">
                                            <td>
                                            </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style39">
                                                    <asp:Label ID="lblIdentificadorDeudor1" runat="server" Style="font-family: Verdana;
                                                        font-size: 10px; font-weight: bold;" Text="Domicilio"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style22" dir="ltr">
                                                    <asp:Label ID="lblDomicilio" runat="server" Style="font-family: Verdana;
                                                        font-size: 9px;" Height="16px" Width="200px"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblLocalidad" runat="server" Style="font-family: Verdana;
                                                        font-size: 9px;" Height="16px" Width="200px"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblProvincia" runat="server" Style="font-family: Verdana;
                                                        font-size: 9px;" Height="16px" Width="200px"></asp:Label>
                                                    </td>
                                            </tr>
                                            <tr  Height="11px">
                                            <td>
                                            </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style23" >
                                                    <asp:Label ID="lblDatoEmail" runat="server" Style="font-family: Verdana;
                                                        font-size: 10px; font-weight: bold;" Text="Email"></asp:Label>
                                                   <%-- &nbsp;<asp:HyperLink  ID="lnkEmail" runat="server" ToolTip="Enviar email al Deudor">---</asp:HyperLink>--%>
                                                   
                                                    <asp:Table ID="tblEmails" runat="server">
                                                    </asp:Table>
                                                   
                                                </td>
                                            </tr>
                                            <tr  Height="11px">
                                            <td>
                                            </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style13">
                                                    <asp:Label ID="lblIdentificadorDeudor2" runat="server" Style="font-family: Verdana;
                                                        font-size: 10px; font-weight: bold;" Text="Cuando Reclamar"></asp:Label>
                                                        <asp:Button ID="btnShowPopupHorariosReclamo" runat="server" Text="..." CssClass="button"  OnClick="btnShowPopupHorariosReclamo_Click" />
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style13">
                                                    <asp:Label ID="lblCuandoReclamar" runat="server" Style="font-family: Verdana;
                                                        font-size: 9px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr Height="11px">
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style13">
                                                    <asp:Label ID="lblIdentificadorCobro" runat="server" Style="font-family: Verdana;
                                                        font-size: 10px;font-weight: bold;" Text="Cuando Cobrar"></asp:Label>
                                                     <asp:Button ID="btnShowPopupHorariosCobro" runat="server" Text="..." CssClass="button"  OnClick="btnShowPopupHorariosCobro_Click" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style13">
                                                    <asp:Label ID="lblCuandoCobrar" runat="server" Style="font-family: Verdana;
                                                        font-size: 9px;"></asp:Label>
                                                </td>                                                
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: auto; " align="left" class="style6">
                                        <table cellpadding="0" cellspacing="0" style="height: 482px; width: 482px;">
                                            <tr>
                                                <td class="style11">
                                                    <table cellpadding="0" cellspacing="0" class="borderCompleto" style="width: 480px;
                                                        height: 93%;">
                                                        <tr>
                                                            <td align="left" class="style31">
                                                                <table style="height: 38px; width: 104%">
                                                                    <tr>
                                                                        <td class="style27">
                                                                            Deudores Asociados
                                                                        </td>
                                                                        <td valign="top">
                                                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/excel_small.gif"
                                                                                OnClick="GvResultados_Exporting" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" class="style10">
                                                                <asp:Panel ID="PnlListaCarga" runat="server" CssClass="scrollbar" Height="445px"
                                                                    Width="470px" ScrollBars="None">
                                                            <asp:UpdatePanel runat="server" ID="UpdatePanelIndice" UpdateMode="Conditional">         
                                                                 <ContentTemplate>
                                                                    
                                                                    <table style="width: 450px; height: 138px;">
                                                                    <tr>
                                                                        <td class="style32">
                                                                            <asp:Label ID="lblAnalista" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                                font-weight: bold;" Text="Analista: ">
                                                                            </asp:Label>
                                                                            <asp:Label ID="lblNombreAnalista" runat="server" Style="font-family: Verdana; font-size: 9px;"
                                                                                Text="Moira"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblCliente" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                                font-weight: bold;" Text="Cliente: ">
                                                                            </asp:Label>
                                                                            <asp:Label ID="lblIdClienteSeleccionado" runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblClienteSeleccionado" runat="server" Style="font-family: Verdana;
                                                                                font-size: 9px;"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                    <td class="style33">
                                                                    <asp:Label ID="lblClientesAsociados" runat="server" Style="font-family: Verdana;
                                                                        font-size: 10px; font-weight: bold;" Text="Cuenta: ">
                                                                    </asp:Label>
                                                                    &nbsp;
                                                                    </td>
                                                                        <td class="style34">
                                                                            <asp:DropDownList ID="cmbClientesAsociados" runat="server" 
                                                                                AutoCompleteMode="SuggestAppend" AutoPostBack="True" BackColor="#FFFFCC" 
                                                                                BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" 
                                                                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" 
                                                                                Height="18px" MaxLength="0" 
                                                                                OnSelectedIndexChanged="cmbClientesAsociados_SelectedIndexChanged" 
                                                                                Width="177px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                        <tr>
                                                                            <td class="style35">
                                                                                <asp:Label ID="lblDeudores" runat="server" Style="font-family: Verdana;
                                                                        font-size: 10px; font-weight: bold;" Text="Deudor:"></asp:Label>
                                                                            </td>
                                                                            <td class="style36">
                                                                                <asp:TextBox ID="txtFindDeudor" runat="server" CssClass="textboxEditor" 
                                                                                    Height="14px" Width="174px" ></asp:TextBox>
                                                                                <asp:ImageButton ID="btnBuscarDeudor" runat="server" CausesValidation="False" 
                                                                                    Height="16px" ImageUrl="~/Images/Ico12.gif" onclick="btnBuscarDeudor_Click" 
                                                                                    Width="23px" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                         <td class="style35">
                                                                            <asp:Label ID="lblId_Deudores" runat="server" 
                                                                                 Style="font-family: Verdana;font-size: 10px; font-weight: bold;" 
                                                                                 Text="AlfaNum:"></asp:Label>                                                                            
                                                                         </td>
                                                                         <td class="style36">
                                                                            <asp:TextBox ID="txtFindIdDeudor" runat="server" CssClass="textboxEditor" Height="14px" Width="174px"></asp:TextBox>
                                                                            <asp:ImageButton ID="btnBuscarIdDeudor" runat="server" CausesValidation="false"
                                                                            Height="16px" ImageUrl="~/Images/Ico12.gif" onclick="btnBuscarIdDeudor_Click"  Width="23px" />
                                                                         </td>
                                                                        </tr>                                                                        
                                                                        <tr>
                                                                            <td class="style32">
                        
                                                                                <asp:RadioButton ID="rbTodos" runat="server" Font-Bold="True" 
                                                                                    Font-Names="Verdana" Font-Size="X-Small" GroupName="rbgfiltroDeudor" 
                                                                                    Text="Todas" Checked="true"
                                                                                    oncheckedchanged="rbTodos_CheckedChanged" AutoPostBack="True" />
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style32">
                                                                                <asp:RadioButton ID="rbAVencer" runat="server" Font-Bold="True" 
                                                                                    Font-Names="Verdana" Font-Size="X-Small" GroupName="rbgfiltroDeudor" 
                                                                                    Text="Con vencimientos hasta:" 
                                                                                    oncheckedchanged="rbAVencer_CheckedChanged" AutoPostBack="True" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCantidadDias" runat="server" CssClass="textboxEditor"
                                                                                    Height="14px" Width="18px" Enabled="False"></asp:TextBox>
                                                                                 <ajaxToolkit:MaskedEditExtender ID="MaskedEditCantidadDias" runat="server" Mask="99" MaskType="Number" TargetControlID="txtCantidadDias"></ajaxToolkit:MaskedEditExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style32">
                                                                                <asp:RadioButton ID="rbFiltroFechaReclamo" runat="server" Font-Bold="True" 
                                                                                    Font-Names="Verdana" Font-Size="X-Small" GroupName="rbgfiltroDeudor" 
                                                                                    Text="Filtrar por fecha reclamo:" 
                                                                                     AutoPostBack="True" 
                                                                                    oncheckedchanged="rbFiltroFechaReclamo_CheckedChanged" />
                                                                            </td>
                                                                            <td>
                                                                               <asp:TextBox ID="txtFechaDesde" runat="server" Width="64" CssClass="textboxEditor"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="ceFechaDesde" runat="server" TargetControlID="txtFechaDesde" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style32">
                                                                                <asp:CheckBox ID="chkIncluirVencidas" runat="server" Enabled="false"
                                                                                    Checked="False" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"                                                                                     
                                                                                    Text="Incluye Vencidas" />
                                                                            </td>
                                                                            <td class="style32">
                                                                                <asp:CheckBox ID="chkFechaReclamo" runat="server" Checked="true" Font-Bold="true" Font-Names="Verdana" Font-Size="X-Small" Text="A Reclamar Hoy" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                             
                                                            <table>
                                                            
                                                                <tr>
                                                                    <td>
                                                                        <ma:SecureButton ID="btnBuscar" runat="server" CssClass="button_back" 
                                                                            Height="20px" OnClick="btnBuscar_Click" Text="Buscar" Width="82px" />
                                                                    </td>
                                                                    <td align="right" width="320px;">
                                                                        <ma:SecureButton ID="btnVerAgenda" runat="server" CssClass="button_back" 
                                                                            Height="20px" OnClick="btnVerAgenda_Click" Text="Ver Agenda" Width="82px" />
                                                                    </td>
                                                                    <td align="right" width="320px;">
                                                                        <ma:SecureButton ID="btnVerProximasGestiones" runat="server" CssClass="button_back" 
                                                                            Height="20px" OnClick="btnVerProximasGestiones_Click" Text="Ver Próx. Gest." Width="100px" />
                                                                    </td>
                                                                    <td align="right" width="320px;">
                                                                        <ma:SecureButton ID="btnHistorialDeudor" runat="server" CssClass="button_back" 
                                                                            Height="20px" OnClick="btnHistorialCliente_Click" Text="Hist. x cliente" 
                                                                            Width="100px" />
                                                                    </td>
                                                                </tr>
                                                               
                                                            </table>
                            <asp:Panel ID="pnlGvResultados" runat="server" Height="245px" ScrollBars="Vertical" CssClass="scrollbar" >
                                                                    <ma:XGridView ID="GvResultados" runat="server" AllowPaging="True" AllowSorting="True"
                                                                        AutoGenerateColumns="False" BorderWidth="0px" DataKeyNames="idDeudor" EmptyDataText="No se encontraron resultados"
                                                                        ExecutePageIndexChanging="True" OnFilling="GvResultados_Filling" OnPageIndexChanging="GvResultados_PageIndexChanging"
                                                                        OnRowDataBound="GvResultados_RowDataBound" OnRowEditing="GvResultados_RowEditing"
                                                                        OnRowDeleting="GvResultados_RowDeleting" OnRowCommand="GvResultados_RowCommand"
                                                                        OnSelectedIndexChanged="GvResultados_SelectedIndexChanged"
                                                                        OnPreRender="GvResultados_PreRender" Height="46px" Width="453px" >
                                                                        <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                        <Columns>
                                                   <%--                         <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chk" runat="Server" /></ItemTemplate>
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="chkAll" runat="Server" AutoPostBack="true" 
                                                                                        OnCheckedChanged="chkAll_CheckedChanged" />
                                                                                </HeaderTemplate>
                                                                            </asp:TemplateField>
                                                            --%>
                                                                           
                                                                          
                                                                            <asp:BoundField DataField="AlfanumDelCliente" HeaderText="AlfaNum" Visible="True">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                          
                                                                            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" Visible="True">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            
                                                                              <asp:BoundField DataField="idDeudor" HeaderText="Id" SortExpression="idDeudor" InsertVisible="false">
                                                                                <HeaderStyle CssClass="HiddenColumn" />
                                                                                <ItemStyle CssClass="HiddenColumn"/>
                                                                                
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="cuit" Visible="False">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                                
                                                                            </asp:BoundField>
                                                                             
                                                                            <asp:BoundField DataField="domicilio" HeaderText="Domicilio" SortExpression="domicilio"
                                                                                Visible="False">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="localidad" HeaderText="Localidad" SortExpression="localidad"
                                                                                Visible="False">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="provincia" HeaderText="Provincia" SortExpression="provincia"
                                                                                Visible="False">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="cp" HeaderText="Código Postal" SortExpression="cp" Visible="False">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="telefono" HeaderText="telefono" SortExpression="telefono"
                                                                                Visible="False">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="Tel. Auxiliar" Visible="False">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="fax" HeaderText="Fax" SortExpression="fax" Visible="False">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" Visible="False">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="anticipoGestion" HeaderText="Anticipo" SortExpression="anticipoGestion"
                                                                                Visible="False">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="Observaciones" SortExpression="observaciones" Visible="False">
                                                                                <HeaderStyle Font-Bold="True" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="Fecha Reclamo" DataField="FechaReclamo" Visible="false"><HeaderStyle Font-Bold="true" /></asp:BoundField>
                                                                        </Columns>
                                                                        <SelectedRowStyle BackColor="#99CCFF" />
                                                                        <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                        <EmptyDataTemplate>
                                                                            No se hallaron resultados.</EmptyDataTemplate>
                                                                        <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                                        <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                        <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                        <RowStyle CssClass="gvItem" />
                                                                    </ma:XGridView>
                                                                    </asp:Panel>
                                                                    
                                                                    
                                                                       </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                                                                    <br />
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <table cellpadding="0" cellspacing="0" style="width: 400px;
                                            height: 495px; margin-left: 0px;" align="left" dir="ltr" frame="below" class="borderCompleto">
                                            <tr>
                                                <td align="left" class="style9" valign="top">
                                                    <table style="width: 90%; height: 34px;">
                                                        <tr>
                                                            <td class="style28">
                                                                Facturas del deudor
                                                            </td>
                                                            <td valign="top" align="left">
                                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/excel_small.gif"
                                                                    OnClick="GvResultadosFacturas_Exporting" Height="17px" Width="16px" 
                                                                    style="margin-left: 14px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                           <%-- <tr>
                                                <td class="style21">
                                                    <table>
                                                        <tr>
                                                            <td style="visibility: hidden">
                                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Font-Bold="True"
                                                                    Font-Names="verdana" Font-Size="X-Small" RepeatDirection="Horizontal" 
                                                                    OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Visible="False">
                                                                    <asp:ListItem Selected="True" Value="0">Todas</asp:ListItem>
                                                                    <asp:ListItem Value="1">&lt; 5 días</asp:ListItem>
                                                                    <asp:ListItem Value="2">Entre 5 y 15 días</asp:ListItem>
                                                                    <asp:ListItem Value="3">más 15 días</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td> 
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td valign="top">
                                                  <asp:UpdatePanel runat="server" ID="UpdatePanelGrillaFacturas" UpdateMode="Conditional">         
                                                                 <ContentTemplate>
                                                      
                                                    <asp:Panel ID="Panel1" runat="server" CssClass="scrollbar" Height="356px" Width="450px"
                                                        ScrollBars="Vertical">
                                                            
                                                        <ma:XGridView ID="GvResultadosFacturas" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            BorderWidth="0px" DataKeyNames="idFactura" EmptyDataText="No se encontraron resultados"
                                                            ExecutePageIndexChanging="False" OnPageIndexChanging="GvResultadosFacturas_PageIndexChanging"
                                                            OnRowDataBound="GvResultadosFacturas_RowDataBound" Width="400px" OnRowEditing="GvResultadosFacturas_RowEditing"
                                                            OnRowDeleting="GvResultadosFacturas_RowDeleting" OnRowCommand="GvResultadosFacturas_RowCommand"
                                                            OnFilling="GvResultadosFacturas_Filling" Height="76px"   PageSize="20" OnSelectedIndexChanging="GvResultadosFacturas_SelectedIndexChanging">
                                                            <AlternatingRowStyle CssClass="gvAlternatingItem"  />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Seleccionar">
                                                                  <%--  <HeaderTemplate>
                                                                        <asp:CheckBox ID="chkAll" runat="Server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChangedFacturas" />
                                                                    </HeaderTemplate>
                                                                  --%>  <ItemTemplate>
                                                                        <asp:CheckBox ID="chk" runat="Server"   OnCheckedChanged="chk_CheckedChanged" AutoPostBack="True" /></ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:BoundField DataField="Id_Tipo_Comprobante" HeaderText="Tipo Comp." SortExpression="Id_Tipo_Comprobante">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ComprobanteFormateado" HeaderText="Nro Factura" />
                                                                <asp:BoundField DataField="idFactura" HeaderText="N°" InsertVisible="false">
                                                                    <HeaderStyle CssClass="HiddenColumn" /> 
                                                                    <ItemStyle CssClass="HiddenColumn" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="fechaVenc" HeaderText="Vencimiento"
                                                                    SortExpression="fechaVenc">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="saldo" HeaderText="Saldo" SortExpression="saldo">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Moneda" HeaderText="Moneda" SortExpression="moneda">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="importe" HeaderText="Importe" SortExpression="importe">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" Visible="True">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>
                                                                
                                                  <%--              <asp:BoundField DataField="ProximaGestion" HeaderText="Proxima Gestion" Visible="False">
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </asp:BoundField>--%>
                                                                <asp:CommandField ButtonType="Button" HeaderText="Pronto" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center"
                                                                    SelectText=" Ver " ControlStyle-CssClass="button_back"/>                                                                
                                                            </Columns>
                                                            <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                            <EmptyDataTemplate>
                                                                No se hallaron resultados.</EmptyDataTemplate>
                                                            <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                            <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                            <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                          <RowStyle CssClass="gvItem" />
                                                        </ma:XGridView>
                                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
                                                        
                                                    </asp:Panel>
                                                                     <table width="100%">
                                                            <tr>
                                                                <td align="left" valign="top" style="font-family: Tahoma, Arial, MS Sans Serif;
                                                                    color: #666666; font-weight: bold; font-size: 12px; text-align: left; padding-left: 60px;
                                                                    " class="style30">
                                                                    <ma:SecureButton ID="btnGestionar" runat="server" CssClass="button_back" OnClientClick="return ValidarFechaReclamo();"
                                                                        Height="20px" OnClick="btnGestionar_Click" Text="Gestionar" Width="103px" />
                                                                </td>
                                                                <td align="left" valign="top"><asp:HiddenField ID="hdFecha_Reclamo" runat="server" /></td>                                                                
                                                                <td align="center"><asp:Button ID="btnHistorial" runat="server" Text="Ver Historial" CssClass="button_back" Width="103px" OnClick="btnHistorial_Click" /></td>
                                                                
                                                                <td align="right" style="padding-right: 32px;">
                                                                         <asp:Button ID="anclaPrueba" runat="server" CssClass="button_back"  
                                                                              Text="Ver Estado de Cuenta" Font-Overline="False" Font-Strikeout="False"  OnClick="anclaPrueba_Click">
                                                                              </asp:Button>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                               <td colspan="4">
                                                                <asp:Label ID="Label8" runat="server" Style="font-family: Verdana; font-size: 10px;
                                                                            font-weight: bold;" Text="Imputado Mon. Loc.: ">
                                                                        </asp:Label>
                                                                        <asp:TextBox ID="txtSumaFacturas" runat="server" BackColor="#CCCCCC"
                                                                            CssClass="textboxEditor" Height="16px"
                                                                            ReadOnly="True" Width="113px"></asp:TextBox>
                                                               </td>
                                                            </tr>
                                                        </table>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="cmbClientesAsociados" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />    
                                                        </Triggers>
                                                        </asp:UpdatePanel>
                                        
                                                </td>
                                                <tr>
                                                    <td class="style19">
                                                       
                                                    </td>
                                                </tr>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                </table>
                             </ContentTemplate>
                             </asp:UpdatePanel>
                         </asp:panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style18">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:hiddenfield id="HiddenFieldProntoPago" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupProntoPago" runat="server" TargetControlID="HiddenFieldProntoPago"
        BackgroundCssClass="modalBackground" PopupControlID="panelProntoPago" />
    <asp:panel id="panelProntoPago" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <table style="height: 68px; width: 590px;">
                    <tr>
                        <td style="background-color: #EDEBEB; border-style: none groove outset none; border-bottom-color: #FFFFFF;
                            border-right-color: #C0C0C0; border-width: thin 2px 2px 1px; 
                            border-collapse: collapse" class="fondo_Titulo">
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
                                        &nbsp;&nbsp;<asp:Label ID="lblImporteActual" runat="server" Style="font-family: Verdana;
                                            font-size: 10px; font-weight: bold;" Text="Importe Factura: "> </asp:Label>
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
                                    <td align="center">
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
    <asp:hiddenfield id="HiddenFieldHorariosReclamo" runat="server" />
    
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupHorariosReclamo" runat="server" TargetControlID="HiddenFieldHorariosReclamo"
        BackgroundCssClass="modalBackground" PopupControlID="panelHorariosReclamo" />
         <asp:panel id="panelHorariosReclamo" runat="server">
					 <asp:UpdatePanel runat="server" UpdateMode="Always" >
                                            <ContentTemplate>
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; width: 400px;
                                                text-align: center;">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label2" runat="server" Text="   Horarios de Reclamo" />
                                                             <input id="Button2" class="button_back" onclick="javascript:HideHorariosReclamo();" type="button"
                                            value="Salir" />
                                                        </td>
                                             </tr>
                                                </table>
                                            </div>
                                            <div style="height: 150px; width: 700px; background-color: #ffffff; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: center; width: 400px;" >
                                                <table width="400px">
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
                                                           <%-- <mkb:TimeSelector ID="tsHorarioDesde" runat="server" MinuteIncrement="10"  SelectedTimeFormat="TwentyFour" />--%>
                                                             <asp:DropDownList ID="tsHorarioDesde" runat="server" EnableViewState="true">
                                                             <asp:ListItem value ="0:00"> 0:00 </asp:ListItem>
                                                            <asp:ListItem value ="0:30"> 0:30 </asp:ListItem>
                                                            <asp:ListItem value ="1:00"> 1:00 </asp:ListItem>
                                                            <asp:ListItem value ="1:30"> 1:30 </asp:ListItem>
                                                            <asp:ListItem value ="2:00"> 2:00 </asp:ListItem>
                                                            <asp:ListItem value ="2:30"> 2:30 </asp:ListItem>
                                                            <asp:ListItem value ="3:00"> 3:00 </asp:ListItem>
                                                            <asp:ListItem value ="3:30"> 3:30 </asp:ListItem>
                                                            <asp:ListItem value ="4:30"> 4:30 </asp:ListItem>
                                                            <asp:ListItem value ="5:00"> 5:00 </asp:ListItem>
                                                            <asp:ListItem value ="5:30"> 5:30 </asp:ListItem>
                                                            <asp:ListItem value ="6:00">6:00 </asp:ListItem>
                                                            <asp:ListItem value ="6:30">6:30 </asp:ListItem>
                                                            <asp:ListItem value ="7:00">7:00</asp:ListItem>
                                                            <asp:ListItem value ="7:30"> 7:30 </asp:ListItem>
                                                            <asp:ListItem value ="8:00"> 8:00 </asp:ListItem>
                                                            <asp:ListItem value ="8:30"> 8:30 </asp:ListItem>
                                                            <asp:ListItem value ="9:00"> 9:00 </asp:ListItem>
                                                            <asp:ListItem value ="9:30"> 9:30 </asp:ListItem>
                                                            <asp:ListItem value ="10:00"> 10:00 </asp:ListItem>
                                                            <asp:ListItem value ="10:30"> 10:30 </asp:ListItem>
                                                            <asp:ListItem value ="11:00"> 11:00 </asp:ListItem>
                                                            <asp:ListItem value ="11:30"> 11:30 </asp:ListItem>
                                                            <asp:ListItem value ="12:00"> 12:00 </asp:ListItem>
                                                            <asp:ListItem value ="12:30"> 12:30 </asp:ListItem>
                                                            <asp:ListItem value ="13:00"> 13:00 </asp:ListItem>
                                                            <asp:ListItem value ="13:30"> 13:30 </asp:ListItem>
                                                            <asp:ListItem value ="14:00"> 14:00 </asp:ListItem>
                                                            <asp:ListItem value ="14:30"> 14:30 </asp:ListItem>
                                                            <asp:ListItem value ="15:00"> 15:00 </asp:ListItem>
                                                            <asp:ListItem value ="15:30"> 15:30 </asp:ListItem>
                                                            <asp:ListItem value ="16:00"> 16:00 </asp:ListItem>
                                                            <asp:ListItem value ="16:30"> 16:30 </asp:ListItem>
                                                            <asp:ListItem value ="17:00"> 17:00 </asp:ListItem>
                                                            <asp:ListItem value ="17:30"> 17:30 </asp:ListItem>
                                                            <asp:ListItem value ="18:00"> 18:00 </asp:ListItem>
                                                            <asp:ListItem value ="18:30"> 18:30 </asp:ListItem>
                                                            <asp:ListItem value ="19:00"> 19:00 </asp:ListItem>
                                                            <asp:ListItem value ="19:30"> 19:30 </asp:ListItem>
                                                            <asp:ListItem value ="20:00"> 20:00 </asp:ListItem>
                                                            <asp:ListItem value ="20:30"> 20:30 </asp:ListItem>
                                                            <asp:ListItem value ="21:00"> 21:00 </asp:ListItem>
                                                            <asp:ListItem value ="21:30"> 21:30 </asp:ListItem>
                                                            <asp:ListItem value ="22:00"> 22:00 </asp:ListItem>
                                                            <asp:ListItem value ="22:30"> 22:30 </asp:ListItem>
                                                            <asp:ListItem value ="23:00"> 23:00 </asp:ListItem>
                                                            <asp:ListItem value ="23:30"> 23:30 </asp:ListItem>
                                                            <asp:ListItem value ="24:00"> 24:00 </asp:ListItem>
                                                            
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <%--<mkb:TimeSelector ID="tsHorarioHasta" runat="server" MinuteIncrement="10" SelectedTimeFormat="TwentyFour" />--%>
                                                            
                                                             <asp:DropDownList ID="tsHorarioHasta" runat="server" EnableViewState="true">
                                                             <asp:ListItem value ="0:00"> 0:00 </asp:ListItem>
                                                            <asp:ListItem value ="0:30"> 0:30 </asp:ListItem>
                                                            <asp:ListItem value ="1:00"> 1:00 </asp:ListItem>
                                                            <asp:ListItem value ="1:30"> 1:30 </asp:ListItem>
                                                            <asp:ListItem value ="2:00"> 2:00 </asp:ListItem>
                                                            <asp:ListItem value ="2:30"> 2:30 </asp:ListItem>
                                                            <asp:ListItem value ="3:00"> 3:00 </asp:ListItem>
                                                            <asp:ListItem value ="3:30"> 3:30 </asp:ListItem>
                                                            <asp:ListItem value ="4:30"> 4:30 </asp:ListItem>
                                                            <asp:ListItem value ="5:00"> 5:00 </asp:ListItem>
                                                            <asp:ListItem value ="5:30"> 5:30 </asp:ListItem>
                                                            <asp:ListItem value ="6:00">6:00 </asp:ListItem>
                                                            <asp:ListItem value ="6:30">6:30 </asp:ListItem>
                                                            <asp:ListItem value ="7:00">7:00</asp:ListItem>
                                                            <asp:ListItem value ="7:30"> 7:30 </asp:ListItem>
                                                            <asp:ListItem value ="8:00"> 8:00 </asp:ListItem>
                                                            <asp:ListItem value ="8:30"> 8:30 </asp:ListItem>
                                                            <asp:ListItem value ="9:00"> 9:00 </asp:ListItem>
                                                            <asp:ListItem value ="9:30"> 9:30 </asp:ListItem>
                                                            <asp:ListItem value ="10:00"> 10:00 </asp:ListItem>
                                                            <asp:ListItem value ="10:30"> 10:30 </asp:ListItem>
                                                            <asp:ListItem value ="11:00"> 11:00 </asp:ListItem>
                                                            <asp:ListItem value ="11:30"> 11:30 </asp:ListItem>
                                                            <asp:ListItem value ="12:00"> 12:00 </asp:ListItem>
                                                            <asp:ListItem value ="12:30"> 12:30 </asp:ListItem>
                                                            <asp:ListItem value ="13:00"> 13:00 </asp:ListItem>
                                                            <asp:ListItem value ="13:30"> 13:30 </asp:ListItem>
                                                            <asp:ListItem value ="14:00"> 14:00 </asp:ListItem>
                                                            <asp:ListItem value ="14:30"> 14:30 </asp:ListItem>
                                                            <asp:ListItem value ="15:00"> 15:00 </asp:ListItem>
                                                            <asp:ListItem value ="15:30"> 15:30 </asp:ListItem>
                                                            <asp:ListItem value ="16:00"> 16:00 </asp:ListItem>
                                                            <asp:ListItem value ="16:30"> 16:30 </asp:ListItem>
                                                            <asp:ListItem value ="17:00"> 17:00 </asp:ListItem>
                                                            <asp:ListItem value ="17:30"> 17:30 </asp:ListItem>
                                                            <asp:ListItem value ="18:00"> 18:00 </asp:ListItem>
                                                            <asp:ListItem value ="18:30"> 18:30 </asp:ListItem>
                                                            <asp:ListItem value ="19:00"> 19:00 </asp:ListItem>
                                                            <asp:ListItem value ="19:30"> 19:30 </asp:ListItem>
                                                            <asp:ListItem value ="20:00"> 20:00 </asp:ListItem>
                                                            <asp:ListItem value ="20:30"> 20:30 </asp:ListItem>
                                                            <asp:ListItem value ="21:00"> 21:00 </asp:ListItem>
                                                            <asp:ListItem value ="21:30"> 21:30 </asp:ListItem>
                                                            <asp:ListItem value ="22:00"> 22:00 </asp:ListItem>
                                                            <asp:ListItem value ="22:30"> 22:30 </asp:ListItem>
                                                            <asp:ListItem value ="23:00"> 23:00 </asp:ListItem>
                                                            <asp:ListItem value ="23:30"> 23:30 </asp:ListItem>
                                                            <asp:ListItem value ="24:00"> 24:00 </asp:ListItem>
                                                            
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnAgregarHorarioReclamo" runat="server" Text="+" Visible="true"
                                                                OnClick="btnAgregarHorarioReclamo_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Table ID="tblHorariosReclamo" runat="server" Width="400px">
                                                </asp:Table>
                                            </div>
   						</ContentTemplate>
                    </asp:UpdatePanel>
			</asp:panel>
                 <asp:hiddenfield id="HiddenFieldHorariosCobro" runat="server" />
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupHorariosCobro" runat="server" TargetControlID="HiddenFieldHorariosCobro"
                    BackgroundCssClass="modalBackground" PopupControlID="panelHorariosCobro" />
                <asp:panel id="panelHorariosCobro" runat="server">
		
 					<asp:UpdatePanel runat="server" UpdateMode="Always" >
                                            <ContentTemplate>
                                            <div style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666; font-weight: bold;
                                                font-size: 12px; background-color: #EDEBEB; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: left; width: 400px;
                                                text-align: center;">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label5" runat="server" Text="   Horarios de Cobro" />
                                                             <input id="Button3" class="button_back" onclick="javascript:HideHorariosCobro();" type="button"
                                            value="Salir" />
                                    </td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>

                                            <div style="height: 150px; width: 700px; background-color: #ffffff; border-right: #cccccc 2px solid;
                                                border-bottom: #cccccc 1px inset; text-align: center; width: 400px;">
                                                <table width="400px">
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
                                                            <%--<mkb:TimeSelector ID="tsHorarioDesdeCobro" runat="server"  MinuteIncrement="10" EnableClock="false"  SelectedTimeFormat="TwentyFour" />--%>
                                                            <asp:DropDownList ID="tsHorarioDesdeCobro" runat="server" EnableViewState="true">
                                                            <asp:ListItem value ="0:00"> 0:00 </asp:ListItem>
                                                            <asp:ListItem value ="0:30"> 0:30 </asp:ListItem>
                                                            <asp:ListItem value ="1:00"> 1:00 </asp:ListItem>
                                                            <asp:ListItem value ="1:30"> 1:30 </asp:ListItem>
                                                            <asp:ListItem value ="2:00"> 2:00 </asp:ListItem>
                                                            <asp:ListItem value ="2:30"> 2:30 </asp:ListItem>
                                                            <asp:ListItem value ="3:00"> 3:00 </asp:ListItem>
                                                            <asp:ListItem value ="3:30"> 3:30 </asp:ListItem>
                                                            <asp:ListItem value ="4:30"> 4:30 </asp:ListItem>
                                                            <asp:ListItem value ="5:00"> 5:00 </asp:ListItem>
                                                            <asp:ListItem value ="5:30"> 5:30 </asp:ListItem>
                                                            <asp:ListItem value ="6:00">6:00 </asp:ListItem>
                                                            <asp:ListItem value ="6:30">6:30 </asp:ListItem>
                                                            <asp:ListItem value ="7:00">7:00</asp:ListItem>
                                                            <asp:ListItem value ="7:30"> 7:30 </asp:ListItem>
                                                            <asp:ListItem value ="8:00"> 8:00 </asp:ListItem>
                                                            <asp:ListItem value ="8:30"> 8:30 </asp:ListItem>
                                                            <asp:ListItem value ="9:00"> 9:00 </asp:ListItem>
                                                            <asp:ListItem value ="9:30"> 9:30 </asp:ListItem>
                                                            <asp:ListItem value ="10:00"> 10:00 </asp:ListItem>
                                                            <asp:ListItem value ="10:30"> 10:30 </asp:ListItem>
                                                            <asp:ListItem value ="11:00"> 11:00 </asp:ListItem>
                                                            <asp:ListItem value ="11:30"> 11:30 </asp:ListItem>
                                                            <asp:ListItem value ="12:00"> 12:00 </asp:ListItem>
                                                            <asp:ListItem value ="12:30"> 12:30 </asp:ListItem>
                                                            <asp:ListItem value ="13:00"> 13:00 </asp:ListItem>
                                                            <asp:ListItem value ="13:30"> 13:30 </asp:ListItem>
                                                            <asp:ListItem value ="14:00"> 14:00 </asp:ListItem>
                                                            <asp:ListItem value ="14:30"> 14:30 </asp:ListItem>
                                                            <asp:ListItem value ="15:00"> 15:00 </asp:ListItem>
                                                            <asp:ListItem value ="15:30"> 15:30 </asp:ListItem>
                                                            <asp:ListItem value ="16:00"> 16:00 </asp:ListItem>
                                                            <asp:ListItem value ="16:30"> 16:30 </asp:ListItem>
                                                            <asp:ListItem value ="17:00"> 17:00 </asp:ListItem>
                                                            <asp:ListItem value ="17:30"> 17:30 </asp:ListItem>
                                                            <asp:ListItem value ="18:00"> 18:00 </asp:ListItem>
                                                            <asp:ListItem value ="18:30"> 18:30 </asp:ListItem>
                                                            <asp:ListItem value ="19:00"> 19:00 </asp:ListItem>
                                                            <asp:ListItem value ="19:30"> 19:30 </asp:ListItem>
                                                            <asp:ListItem value ="20:00"> 20:00 </asp:ListItem>
                                                            <asp:ListItem value ="20:30"> 20:30 </asp:ListItem>
                                                            <asp:ListItem value ="21:00"> 21:00 </asp:ListItem>
                                                            <asp:ListItem value ="21:30"> 21:30 </asp:ListItem>
                                                            <asp:ListItem value ="22:00"> 22:00 </asp:ListItem>
                                                            <asp:ListItem value ="22:30"> 22:30 </asp:ListItem>
                                                            <asp:ListItem value ="23:00"> 23:00 </asp:ListItem>
                                                            <asp:ListItem value ="23:30"> 23:30 </asp:ListItem>
                                                            <asp:ListItem value ="24:00"> 24:00 </asp:ListItem>
                                                            
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <%--<mkb:TimeSelector ID="tsHorarioHastaCobro" runat="server" MinuteIncrement="10" SelectedTimeFormat="TwentyFour"  />--%>
                                                            <asp:DropDownList ID="tsHorarioHastaCobro" runat="server" EnableViewState="true">
                                                                 <asp:ListItem value ="0:00"> 0:00 </asp:ListItem>
                                                            <asp:ListItem value ="0:30"> 0:30 </asp:ListItem>
                                                            <asp:ListItem value ="1:00"> 1:00 </asp:ListItem>
                                                            <asp:ListItem value ="1:30"> 1:30 </asp:ListItem>
                                                            <asp:ListItem value ="2:00"> 2:00 </asp:ListItem>
                                                            <asp:ListItem value ="2:30"> 2:30 </asp:ListItem>
                                                            <asp:ListItem value ="3:00"> 3:00 </asp:ListItem>
                                                            <asp:ListItem value ="3:30"> 3:30 </asp:ListItem>
                                                            <asp:ListItem value ="4:30"> 4:30 </asp:ListItem>
                                                            <asp:ListItem value ="5:00"> 5:00 </asp:ListItem>
                                                            <asp:ListItem value ="5:30"> 5:30 </asp:ListItem>
                                                            <asp:ListItem value ="6:00">6:00 </asp:ListItem>
                                                            <asp:ListItem value ="6:30">6:30 </asp:ListItem>
                                                            <asp:ListItem value ="7:00">7:00</asp:ListItem>
                                                            <asp:ListItem value ="7:30"> 7:30 </asp:ListItem>
                                                            <asp:ListItem value ="8:00"> 8:00 </asp:ListItem>
                                                            <asp:ListItem value ="8:30"> 8:30 </asp:ListItem>
                                                            <asp:ListItem value ="9:00"> 9:00 </asp:ListItem>
                                                            <asp:ListItem value ="9:30"> 9:30 </asp:ListItem>
                                                            <asp:ListItem value ="10:00"> 10:00 </asp:ListItem>
                                                            <asp:ListItem value ="10:30"> 10:30 </asp:ListItem>
                                                            <asp:ListItem value ="11:00"> 11:00 </asp:ListItem>
                                                            <asp:ListItem value ="11:30"> 11:30 </asp:ListItem>
                                                            <asp:ListItem value ="12:00"> 12:00 </asp:ListItem>
                                                            <asp:ListItem value ="12:30"> 12:30 </asp:ListItem>
                                                            <asp:ListItem value ="13:00"> 13:00 </asp:ListItem>
                                                            <asp:ListItem value ="13:30"> 13:30 </asp:ListItem>
                                                            <asp:ListItem value ="14:00"> 14:00 </asp:ListItem>
                                                            <asp:ListItem value ="14:30"> 14:30 </asp:ListItem>
                                                            <asp:ListItem value ="15:00"> 15:00 </asp:ListItem>
                                                            <asp:ListItem value ="15:30"> 15:30 </asp:ListItem>
                                                            <asp:ListItem value ="16:00"> 16:00 </asp:ListItem>
                                                            <asp:ListItem value ="16:30"> 16:30 </asp:ListItem>
                                                            <asp:ListItem value ="17:00"> 17:00 </asp:ListItem>
                                                            <asp:ListItem value ="17:30"> 17:30 </asp:ListItem>
                                                            <asp:ListItem value ="18:00"> 18:00 </asp:ListItem>
                                                            <asp:ListItem value ="18:30"> 18:30 </asp:ListItem>
                                                            <asp:ListItem value ="19:00"> 19:00 </asp:ListItem>
                                                            <asp:ListItem value ="19:30"> 19:30 </asp:ListItem>
                                                            <asp:ListItem value ="20:00"> 20:00 </asp:ListItem>
                                                            <asp:ListItem value ="20:30"> 20:30 </asp:ListItem>
                                                            <asp:ListItem value ="21:00"> 21:00 </asp:ListItem>
                                                            <asp:ListItem value ="21:30"> 21:30 </asp:ListItem>
                                                            <asp:ListItem value ="22:00"> 22:00 </asp:ListItem>
                                                            <asp:ListItem value ="22:30"> 22:30 </asp:ListItem>
                                                            <asp:ListItem value ="23:00"> 23:00 </asp:ListItem>
                                                            <asp:ListItem value ="23:30"> 23:30 </asp:ListItem>
                                                            <asp:ListItem value ="24:00"> 24:00 </asp:ListItem>
                                                            
                                                            </asp:DropDownList>
                                                            
                                                            
                                                            
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnAgregarHorarioCobro" runat="server" Text="+" Visible="true"
                                                                OnClick="btnAgregarHorarioCobro_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Table ID="tblHorariosCobro" runat="server" Width="400px">
                                                </asp:Table>
                                            </div>
   					            </ContentTemplate>
                          </asp:UpdatePanel>
				</asp:panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="ContentHeader">
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="menuJQUERY">
    <style type="text/css">
        .style6
        {
            width: 560px;
        }
        .style9
        {
            font-family: Tahoma, Arial, "MS Sans Serif";
            font-size: 10px;
            color: #666666;
            font-weight: bold;
            vertical-align: top;
            height: 23px;
            width: 513px;
            background-color: white;
            background-image: url(      '../Images/fdo_tile.gif' );
            background-position: 50% top;
        }
        .style10
        {
            width: 465px;
            height: 320px;
        }
        .style11
        {
            width: 474px;
            height: 352px;
        }
        .style12
        {
            width: 1391px;
        }
        .style13
        {
            width: 181px;
            text-align: left;
        }
        .style14
        {
            width: 181px;
            height: 25px;
        }
        .style16
        {
            width: 181px;
            height: 26px;
        }
        .style17
        {
            font-family: Tahoma, Arial, "MS Sans Serif";
            font-size: 10px;
            color: #666666;
            font-weight: bold;
            vertical-align: top;
            height: 34px;
            width: 1275px;
            background-color: white;
            background-image: url(      '../Images/fdo_tile.gif' );
            background-position: 50% top;
        }
        .style18
        {
            width: 1275px;
        }
        .style19
        {
            width: 513px;
        }
        .style22
        {
            width: 181px;
            text-align: left;
            height: 53px;
        }
        .style23
        {
            width: 181px;
            text-align: left;
            height: 20px;
        }
        .style27
        {
            width: 445px;
        }
        .style28
        {
            height: 30px;
            width: 437px;
        }
        .style30
        {
            height: 10px;
        }
        .style31
        {
            font-family: Tahoma, Arial, "MS Sans Serif";
            font-size: 10px;
            color: #666666;
            font-weight: bold;
            vertical-align: top;
            height: 23px;
            width: 465px;
            background-color: white;
            background-image: url(      '../Images/fdo_tile.gif' );
            background-position: 50% top;
        }
        .style32
        {
            width: 165px;
        }
        .style33
        {
            width: 165px;
            height: 27px;
        }
        .style34
        {
            height: 27px;
        }
        .style35
        {
            width: 165px;
            height: 20px;
        }
        .style36
        {
            height: 20px;
        }
        .style38
        {
            width: 181px;
            text-align: left;
            height: 14px;
        }
        .style39
        {
            width: 181px;
            text-align: left;
            height: 18px;
        }
    </style>
</asp:Content>
