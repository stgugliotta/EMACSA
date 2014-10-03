<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewProntoPago.aspx.cs" Inherits="Vistas_ViewProntoPago" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" runat="Server"  >
    <link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>

    <script type="text/javascript">
    <!--
        $(document).ready
        (
            function() {
                var options =
                {
                    minWidth: 120, arrowSrc: '/UIControls/MenuJQuery/Menu/arrow_right.gif', copyClassAttr: true, onClick: function(e, menuItem) {
                        //openMenu(
                        document.location = 'http://localhost/vistas/ViewImportacionDeFacturas.aspx';
                        //);
                        //alert('you clicked item "' + $(this).text() + e  + '"');
                    }
                };
            }
        );
    -->
    </script>

    <script type="text/javascript">
        function ValidarNumero(valor) {
            var PatronNumerico = /\d/;
            if (!PatronNumerico.test(valor)) {
                alert("-Dias de Anticipo debe ser numerico.\n-No debe estar vacio.");
                return false;
            }
            return true;
        }
    </script>

    <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
    
    
    
<script type="text/javascript" language="javascript">
	            var ModalProgress = '<%= ModalProgress.ClientID %>';   
         		
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
                
                

function beginReq(sender, args) 
{
	var controlCaller=args.get_postBackElement().id;
   
    if(controlCaller.indexOf('btnConfirmar')!=-1){$find(ModalProgress).show();}
    if(controlCaller.indexOf('cmbClientes')!=-1){$find(ModalProgress).show()};
    if(controlCaller.indexOf('cmbDeudores')!=-1){$find(ModalProgress).show()};
       
 }

function endReq(sender, args)
{
	                        //  shows the Popup 
	                        $find(ModalProgress).hide();
} 

 </script>
 
<%--     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>--%>
    
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

    <!--Desde aqui desarrollarlo-->
    <table style="text-align:center;" align="center">
           <tr>
                <td align="center">
        
                     <table cellpadding="0" cellspacing="0"  class="borderCompleto" style="width: 900px;height: 88%; text-align:center;">
        <tr align="center">
            <td class="fondo_Titulo" style="height: 23px" width="100%;" align="center">
                <table width="100%">
                    <tr>
                        <td>
                            Alta Pronto Pago
                        </td>
                        <td valign="top">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
   
                <table class="borderCompleto">
                    <tr>
                    <td>
                        <asp:Label ID="lblImporte" runat="server" CssClass="labelBold"
                            Text="Cliente:"></asp:Label>
                            </td>
                            
                        <td>
                            <ajaxToolkit:ComboBox ID="cmbClientes" runat="server" OnSelectedIndexChanged="cmbClientes_SelectedIndexChanged"
                                AutoPostBack="true" RenderMode="Block" AutoCompleteMode="SuggestAppend" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px" MaxLength="0" Width="160px">
                            </ajaxToolkit:ComboBox>
                        </td>
                    </tr>
                    <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="labelBold"
                            Text="Deudor:"></asp:Label>
                            </td>
                            
                        
                        <td>
                            <ajaxToolkit:ComboBox ID="cmbDeudores" runat="server" OnSelectedIndexChanged="cmbDeudores_SelectedIndexChanged"
                                 AutoPostBack="true" RenderMode="Block" AutoCompleteMode="SuggestAppend" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px" MaxLength="0" Width="160px">
                            </ajaxToolkit:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign ="top" style="width:40px;">
                        <asp:Label ID="Label3" runat="server" CssClass="labelBold"
                            Text="Días de anticipación:"></asp:Label>
                            </td>
                            
                    
                        <td>
                            <asp:TextBox ID="txtDiasAnticipacion" runat="server" Width="16" MaxLength="2" CssClass="textboxEditor"></asp:TextBox>
                            <br />
                            <asp:requiredfieldvalidator runat="server" errormessage="Ingrese un valor" ControlToValidate="txtDiasAnticipacion" ValidationGroup="prontoPagoGroup"></asp:requiredfieldvalidator>
                            <br />
                            <asp:RegularExpressionValidator runat="server" ErrorMessage="Formato Incorrecto" ControlToValidate="txtDiasAnticipacion" ValidationGroup="prontoPagoGroup" ValidationExpression="^[0-9]{1,1000}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign ="top" style="width:40px;">
                        <asp:Label ID="Label4" runat="server" CssClass="labelBold"
                            Text="Porcentaje:"></asp:Label>
                        </td>
                            
                    
                        <td>
<%--                            <asp:DropDownList ID="ddlPorcentaje" runat="server" AutoCompleteMode="SuggestAppend" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px">
                            </asp:DropDownList>
                            --%>
                             <asp:TextBox ID="txtPorcentaje" runat="server" CssClass="textboxEditor" Height="16px"
                                                MaxLength="8" TabIndex="10" ValidationGroup="prontoPagoGroup" Width="20px"></asp:TextBox>
                                                <br />
                                                <asp:RequiredFieldValidator
                                                ID="RequiredFieldValidatorImporte" runat="server" ControlToValidate="txtPorcentaje"
                                                ErrorMessage="Ingrese porcentaje" ValidationGroup="prontoPagoGroup"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator runat="server" ErrorMessage="Formato Incorrecto" ControlToValidate="txtPorcentaje" ValidationGroup="prontoPagoGroup" ValidationExpression="^[0-9]{1,7}(\,[0-9]{1,4})|[0-9]{1,7}$"></asp:RegularExpressionValidator>
                                                                                                                
                        </td>
                    </tr>
                    <tr>
                       <td>
                        <asp:Label ID="Label5" runat="server" CssClass="labelBold"
                            Text="Activo:"></asp:Label>
                            </td>
                            
                        <td>
                                                <asp:CheckBox ID="chkActivo" runat="server" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <%--<asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClientClick="return ValidarNumero(ctl00_Contentplaceholder1_txtDiasAnticipacion.value);"
                                OnClick="btnConfirmar_Click" CssClass="button_back3" CausesValidation="True" ValidationGroup="prontoPagoGroup" />--%>
                                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" CssClass="button_back3" CausesValidation="True" ValidationGroup="prontoPagoGroup" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="Label1" runat="server" CssClass="labelBold"
                    Text="Descuentos por pronto pago para el cliente y deudor seleccionado: "> </asp:Label>
                <br />
                <!--Grid View con el select de resultados -->
                <ma:XGridView ID="gvResultados" runat="server" AllowPaging="true" AllowSorting="true"
                    AutoGenerateColumns="false" BorderWidth="0px" EmptyDataText="No se encontraron resultados"
                    ExecutePageIndexChanging="true" PageSize="5" Width="436" OnFilling="gvResultados_Filling"
                    OnPageIndexChanging="gvResultados_PageIndexChanging"  DataKeyNames="Id" 
                    OnRowDeleting="gvResultados_RowDeleting" Style="text-align: center; margin-left: 10%">
                    <AlternatingRowStyle CssClass="gvAlternatingItem" />
                    <Columns>
                        <%--<asp:CommandField ButtonType="Image" EditImageUrl="~/Images/editar.gif" ShowEditButton="true"
                            HeaderText="Editar">
                            <HeaderStyle Font-Bold="true" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:CommandField>--%>
                    
                                                                      
                        <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton OnClientClick="return confirm('¿Esta seguro que desea eliminar el registro?');"
                                    Visible="true" ID="btnDelete" runat="server" ImageUrl="~/Images/delete.gif" CommandName="Delete" />
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="true" />
                        </asp:TemplateField>
                            <asp:BoundField DataField="idDeudor" SortExpression="id" HeaderText="id" />
                        <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" SortExpression="NombreCliente"
                            ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle Font-Bold="true" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NombreDeudor" HeaderText="Deudor" SortExpression="NombreDeudor">
                            <HeaderStyle Font-Bold="true" />
                        </asp:BoundField>
                        <asp:BoundField DataField="diasDeAnticipacion" HeaderText="Dias de Anticipacion">
                            <HeaderStyle Font-Bold="true" />
                        </asp:BoundField>
                        <asp:BoundField DataField="porcentajeAplicacion" HeaderText="Porcentaje de Aplicacion (%)">
                            <HeaderStyle Font-Bold="true" />
                        </asp:BoundField>
                    </Columns>
                    <SelectedRowStyle BackColor="#99CCFF" />
                    <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        No se hallaron resultados.
                    </EmptyDataTemplate>
                    <FooterStyle CssClass="gvHeader grayGvHeader" />
                    <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                    <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                    <RowStyle CssClass="gvItem" />
                </ma:XGridView>

            </td>
        </tr>
    </table>
    
               </td>
           </tr>
    
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeader" runat="Server">
</asp:Content>
