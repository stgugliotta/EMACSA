<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewHojaDeRutaABM.aspx.cs" Inherits="Vistas_ViewHojaDeRutaABM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>

    <script type="text/javascript" src="../Js/HojaDeRuta.js"></script>

    <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
        <div id="divProcesando" style="position: relative; top: 30%; text-align: center;
        visibility: hidden">
        <span>
            <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
            Procesando...</span>
    </div>
    <asp:panel id="panelUpdateProgress" runat="server" cssclass="updateProgress">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="upHojaDeRutaABM">
            <ProgressTemplate>
                <div style="position: relative; top: -262%; text-align: center; left: -11px;">
                    <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                    Procesando...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:panel>
    <cc1:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
        
    <cc1:ModalPopupExtender ID="ModalPopupCargando" runat="server" TargetControlID="panelUpdateProgress"
    BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
  
    <script type="text/javascript">
       
           var ModalPopupCargando='<%= ModalPopupCargando.ClientID %>';

                                                 
              		
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
        function  toogleDSG(visible) {
            try {
                        var oDivDSG = document.getElementById('divDSG');
                        if (oDivDSG != undefined) {
                                if (visible) {
                                    oDivDSG.style.visibility = 'visible';
                                } else {
                                    oDivDSG.style.visibility = 'hidden';
                                }
                        }
               } 
               catch (e){
                     alert (el);
              }
      }
     function CambiarVistas(obj, row) 
        {
            var div = document.getElementById(obj);
            var img = document.getElementById('img' + obj);

            if (div.style.display == "none") 
            {
                div.style.display = "inline";
                if (row == 'alt') 
                {
                    img.src = "../Images/Expand_button_white_down.jpg";
                    mce_src = "../Images/Expand_button_white_down.jpg";
                }
                else 
                {
                    img.src = "../Images/Expand_button_white_down.jpg";
                    mce_src = "../Images/Expand_button_white_down.jpg";
                }
                img.alt = "Cerrar para ver otros detalles.";
            }
            else 
            {
                div.style.display = "none";
                if (row == 'alt') 
                {
                    img.src = "../Images/Expand_button_white.jpg";
                    mce_src = "../Images/Expand_button_white.jpg";
                }
                else 
                {
                    img.src = "../Images/Expand_button_white.jpg";
                    mce_src = "../Images/Expand_button_white.jpg";
                }
                img.alt = "Expandir para ver otros detalles.";
            }
        }
        
        
function beginReq(sender, args) 
{

	//var controlCaller=args.get_postBackElement().id;
$find(ModalPopupCargando).show();

//    if(controlCaller.indexOf('btnGuardarRecibo')!=-1){$find(ModalPopupCargando).show()};
//    if(controlCaller.indexOf('btnAgregarPago')!=-1){$find(ModalPopupCargando).show()};
//    if(controlCaller.indexOf('cmbDeudores')!=-1){$find(ModalPopupCargando).show()};
//    if(controlCaller.indexOf('cmbClientes')!=-1){$find(ModalPopupCargando).show()};
//    if(controlCaller.indexOf('cmbRecibosDisponibles')!=-1){$find(ModalPopupCargando).show()};
//    if(controlCaller.indexOf('btnNuevaRemisionTemporal')!=-1){$find(ModalPopupCargando).show()};
//    if(controlCaller.indexOf('btnCrearRemision')!=-1){$find(ModalPopupCargando).show()};
//    if(controlCaller.indexOf('btnRefreshCmbDeudores')!=-1){$find(ModalPopupCargando).show()};
//    if(controlCaller.indexOf('btnRemisionEnUso')!=-1){$find(ModalPopupCargando).show()};
//    if(controlCaller.indexOf('gvResultadosConcurrencia')!=-1){$find(ModalPopupCargando).show()};
//    disableReClick(controlCaller,'btnNuevaRemisionTemporal');
 }

function endReq(sender, args)
{


              $find(ModalPopupCargando).hide();

} 

       
    function  showProcesando() {
            try {
                    var oDivProcesando = document.getElementById('divProcesando');
                    if (oDivProcesando != undefined) {
                        oDivProcesando.style.visibility = 'visible';
                    }
            } catch (e){
                alert (el);
            }

    }
    </script>
      <div id="divDSG" style="text-align: center; visibility: hidden">
        <table width="100%">
            <tr>
                <td style="width: 100%; height: 30px;" class="fondo_Titulo">
                    Importación de Deudores Sin Gestión
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 40px;" class="fondo_Titulo">
                    <asp:dropdownlist id="cmbClientes" runat="server" autocompletemode="SuggestAppend"
                        autopostback="False" backcolor="#FFFFCC" bordercolor="#B9B9B9" borderstyle="Solid"
                        borderwidth="1px" dropdownstyle="DropDownList" font-names="Verdana" font-size="11px"
                        maxlength="0" width="177px">
                </asp:dropdownlist>
                    <asp:fileupload id="archivo" runat="server" width="611px" />
                    <asp:button id="btnImportarDSG" runat="server" text="Importar" cssclass="button"
                        onclick="btnImportarDSG_Click" height="24px" width="176px" onclientclick="showProcesando()">
                </asp:button>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="resultados" CssClass="smallTitle" runat="server">
                        <asp:Literal ID="lblResultadoImportacion" runat="server" />
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 100%; height: 40px;" class="fondo_Titulo">
                     
                    <asp:button id="btnExportarExcel" runat="server" cssclass="button" onclick="btnExportarExcel_Click"
                        text="Hoja de Ruta a XLS" />
                    <asp:button id="btnExportarExcelDSG" runat="server" cssclass="button" onclick="btnExportarExcelDSG_Click"
                        text="Hoja de Ruta Sin Gestión a XLS"  />
                </td>
            </tr>
        </table>
    </div>
        <asp:updatepanel id="upHojaDeRutaABM" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlPrincipal" runat="server" Width="100%" Height="600px">
                    <cc1:Accordion ID="AccordionCtrl" runat="server" HeaderCssClass="acc-header" ContentCssClass="acc-content"
            HeaderSelectedCssClass="acc-selected" Style="margin-right: 258px" SelectedIndex="0"
            AutoSize="None" FadeTransitions="true">
            <Panes>
             <cc1:AccordionPane ID="pnlConsulta" runat="server"  Visible="true">
                                <Header>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="width: 100%; height: 30px;" class="fondo_Titulo">
                                                Hojas de Ruta activas
                                            </td>
                                            <td valign="top">
                                            </td>
                                        </tr>
                                    </table>
                                </Header>
                                <Content>
                                    <table style="width: 863px; font-family: Verdana; font-size: 11px; color: #224466;
                                        height: 221px;" border="0">
                                        <tr>
                                            <td align="left">
                                                Hoja de Ruta Nro.:
                                                <asp:TextBox ID="txtHojaDeRuta" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                            </td>
                                            <td align="left" class="labelCliente">
                                                Desde:
                                            </td>
                                            <td align="left" class="labelCliente">
                                                &nbsp;<asp:TextBox ID="txtFechaDesdeActivas" runat="server" Width="64"></asp:TextBox>
                                                <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy"
                                                    TargetControlID="txtFechaDesdeActivas">
                                                </ajaxToolkit:CalendarExtender>
                                                --%>
                                                
                                            </td>
                                            <td align="left" class="labelCliente">
                                                Hasta:
                                            </td>
                                            <td align="left" class="labelCliente">
                                                &nbsp;<asp:TextBox ID="txtFechaHastaActivas" runat="server" Width="64"></asp:TextBox>
                                               <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy"
                                                    TargetControlID="txtFechaHastaActivas">
                                                </ajaxToolkit:CalendarExtender>--%>
                                            </td>                                        
                                            <td>
                                                <asp:Button ID="btnBuscarActivas" runat="server" CssClass="button" OnClick="btnBuscarActivas_Click"
                                                    Text="Buscar" />
                                              <%--  <asp:Button ID="btnNueva" runat="server" CssClass="button" OnClick="btnNueva_Click"
                                                    Text="Nueva" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7" align="left" valign="top">
                                                <asp:Panel ID="Panel1" runat="server" CssClass="scrollbar" Height="124px" Width="863px">
                                                    <asp:GridView ID="gvHojasActivas" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                        PageSize="5" ScrollBars="Horizontal" DataKeyNames="IdHoja" OnRowDataBound="gvHojasActivas_RowDataBound"
                                                        OnRowEditing="gvHojasActivas_RowEditing" AllowSorting="True" BorderWidth="0px"
                                                        Width="100%">
                                                        <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                        <Columns>
                                                            <asp:CommandField ShowEditButton="True" ShowHeader="True" />
                                                            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Creación" DataFormatString="{0:dd/MM/yyyy}"
                                                                ItemStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="IdHoja" HeaderText="Id. Hoja de Ruta" />
                                                            <asp:BoundField DataField="Usuario" HeaderText="Usuario Creador" />
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                        <EmptyDataTemplate>
                                                            No se hallaron resultados.</EmptyDataTemplate>
                                                        <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                        <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                        <RowStyle CssClass="gvItem" />
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </Content> 
                            </cc1:AccordionPane>
             <cc1:AccordionPane ID="pnlAlta" runat="server"  Visible="true"> 
                                <Header>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="width: 100%; height: 30px;" class="fondo_Titulo">
                                                Hoja de Ruta (Alta)
                                            </td>
                                            <td valign="top">
                                            </td>
                                        </tr>
                                </Header>
                                <Content>
                                     <table style="width: 863px; font-family: Verdana; font-size: 11px; color: #224466;
                                        height: 221px;" border="0">
                                        <tr>
                                            <td align="left" class="labelCliente">
                                                Fecha de cobro:
                                            
                                                <asp:TextBox ID="txtFechaDesde" runat="server" Width="64" ValidationGroup="ppGroup"></asp:TextBox>
                                               <%-- <ajaxToolkit:CalendarExtender ID="ceFechaDesde" runat="server" Format="dd-MM-yyyy"
                                                    TargetControlID="txtFechaDesde" >
                                                </ajaxToolkit:CalendarExtender >
                                               --%> 
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorTxtxFechaDesde" runat="server" ErrorMessage="Ingrese fecha."
                                                ControlToValidate="txtFechaDesde" ValidationGroup="ppGroup"></asp:RequiredFieldValidator>
                                            
                                                <asp:Button ID="btnBuscar" runat="server" CssClass="button" OnClick="btnBuscar_Click"
                                                    Text="Buscar" ValidationGroup="ppGroup" CauseValidation="True" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="7" align="left" valign="top" class="style6">
                                               <asp:GridView ID="gvDeudores" runat="server" AutoGenerateColumns="false" CellPadding="3"
                                                        PageSize="5" ScrollBars="Horizontal" DataKeyNames="IdDeudor" OnRowDataBound="gvDeudores_RowDataBound"
                                                        AllowSorting="True" BorderWidth="0px" Width="100%">
                                                        <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <a href="javascript:CambiarVistas('div<%# Eval("IdDeudor") %>','one');">
                                                                        <img id="img1" alt="Click para expandir/contraer" border="0"
                                                                            src="../Images/Expand_button_white.jpg" />
                                                                    </a>
                                                                </ItemTemplate>
                                                                <AlternatingItemTemplate>
                                                                    <a href="javascript:CambiarVistas('div<%# Eval("IdDeudor") %>','alt');">
                                                                        <img id="img2" alt="Click para expandir/contraer" border="0"
                                                                            src="../Images/Expand_button_white.jpg" />
                                                                    </a>
                                                                </AlternatingItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="idCliente" HeaderText="IdCli" ShowHeader="false"  />
                                                            <asp:BoundField DataField="cliente" HeaderText="Cliente" />
                                                            <asp:BoundField DataField="AlfaNumDelCliente" HeaderText="Alfanum" />
                                                            <asp:BoundField DataField="idDeudor" HeaderText="Id. Deudor" InsertVisible="false">
                                                                <HeaderStyle CssClass="HiddenColumn" />
                                                                <ItemStyle CssClass="HiddenColumn"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="deudor" HeaderText="Deudor" />
                                                            <asp:BoundField DataField="domicilio" HeaderText="Domicilio" />
                                                            <asp:BoundField DataField="localidad" HeaderText="Localidad" />
                                                            <asp:BoundField DataField="provincia" HeaderText="Provincia" Visible="false" />
                                                            <asp:BoundField DataField="cp" HeaderText="CP" Visible="false"/>
                                                            <asp:BoundField DataField="horario" HeaderText="Horario de Cobro" />
                                                            <asp:BoundField DataField="cobrador" HeaderText="Cobrador" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                   
                                                                    <tr>
                                                                        <td colspan="100%">
                                                                            <div id="div1" style="display: none; position: relative; left: 5px">
                                                                                <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="false" CellPadding="3"
                                                                                    DataKeyNames="IdFactura"  BorderWidth="0px"
                                                                                Width="65%" Font-Bold="false">
                                                                                    <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="ComprobanteFormateado" HeaderText="IdFactura" />
                                                                                        <asp:BoundField DataField="FechaVenc" HeaderText="Fecha Vencimiento" DataFormatString="{0:dd/MM/yyyy}"
                                                                                            ItemStyle-HorizontalAlign="Center" />
                                                                                        <asp:BoundField DataField="FechaCobro" HeaderText="Fecha Cobro" DataFormatString="{0:dd/MM/yyyy}"
                                                                                            ItemStyle-HorizontalAlign="Center" />
                                                                                        <asp:BoundField DataField="Importe" HeaderText="Importe" ItemStyle-HorizontalAlign="Right" />
                                                                                        <asp:BoundField DataField="Saldo" HeaderText="Saldo" ItemStyle-HorizontalAlign="Right" />
                                                                                        <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" Visible="false" />
                                                                                    </Columns>
                                                                                    <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                                    <EmptyDataTemplate>
                                                                                        No se hallaron resultados.</EmptyDataTemplate>
                                                                                    <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                                                    <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                                    <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                                    <RowStyle CssClass="gvItem" />
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                        <EmptyDataTemplate>
                                                            No se hallaron resultados.</EmptyDataTemplate>
                                                        <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                        <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                        <RowStyle CssClass="gvItem" />
                                                    </asp:GridView>
                                                    <br />
                                                    <br />
                                                    <asp:Button ID="btnCrearHoja" runat="server" CssClass="button" OnClick="btnCrear_Click"
                                                        Style="margin-left: 40%;" Text="Crear Hoja" Visible="false" />
                                            
                                            </td>
                                        </tr>
                                    </table>
                                </Content>
                            </cc1:AccordionPane>
             <cc1:AccordionPane ID="pnlModificacion" runat="server"  Visible="true">
                                <Header>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="width: 100%; height: 30px;" class="fondo_Titulo">
                                                <table  >
                                                <tr>
                                                <td>
                                                Hoja de Ruta (Modificación)
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td>Filtrar cobrador:</td>
                                                <td>
                                                    <asp:DropDownList ID="cmbCobrador" runat="server" DataTextField="Nombre" DataValueField="Id"
                                                         AutoPostBack="true" CssClass="combo" OnSelectedIndexChanged="cmbCobrador_SelectedIndexChanged"
                                                         Height="20px">
                                                    </asp:DropDownList>
                                                </td>
                                                </tr>
                                                </table>
                                                
                                            </td>
                                            
                                            <td valign="top">
                                            </td>
                                        </tr>
                                    </table>
                                </Header>
                                <Content>
                                    <table style="width: 100%; height: 300px; font-family: Verdana; font-size: 11px;
                                        color: #224466;" border="0">
                                        <tr>
                                        <td>
                                        
                           
                                                         
                                        </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7" align="left" valign="top" class="style6">
                                                <asp:GridView ID="gvModificacion" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                    DataKeyNames="IdDeudor" OnRowDataBound="gvModificacion_RowDataBound" AllowSorting="False"
                                                    BorderWidth="0px" Width="100%" Font-Bold="true">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <a href="javascript:CambiarVistas('div<%# Eval("IdDeudor") %>','one');" style="visibility:<%# Eval("NroItem") == null || Int32.Parse(Eval("NroItem").ToString()) == 0 ? "visible" : "hidden" %> ">
                                                                    <img id="imgdiv<%# Eval("IdDeudor") %>" alt="Click para expandir/contraer" border="0"
                                                                        src="../Images/Expand_button_white.jpg" />
                                                                </a>
                                                            </ItemTemplate>
                                                            <AlternatingItemTemplate>
                                                                <a href="javascript:CambiarVistas('div<%# Eval("IdDeudor") %>','alt');" style="visibility:<%# Eval("NroItem") == null || Int32.Parse(Eval("NroItem").ToString()) == 0 ? "visible" : "hidden" %>">
                                                                    <img id="imgdiv<%# Eval("IdDeudor") %>" alt="Click para expandir/contraer" border="0"
                                                                        src="../Images/Expand_button_white.jpg" />
                                                                </a>
                                                            </AlternatingItemTemplate>
                                                        </asp:TemplateField>
                                                      
                                                        <asp:BoundField DataField="idCliente" HeaderText="IdCli"  ShowHeader="false" />
                                                        <asp:BoundField DataField="cliente" HeaderText="Cliente" />
                                                        <asp:BoundField DataField="AlfaNumDelCliente" HeaderText="Alfanum" />
                                                        <asp:BoundField DataField="idDeudor" HeaderText="Id. Deudor" InsertVisible="false">
                                                            <HeaderStyle CssClass="HiddenColumn" />
                                                            <ItemStyle CssClass="HiddenColumn"/>
                                                        </asp:BoundField>
                                                        
                                                        <asp:BoundField DataField="deudor" HeaderText="Deudor" />
                                                        <asp:BoundField DataField="domicilio" HeaderText="Domicilio" />
                                                        <asp:BoundField DataField="localidad" HeaderText="Localidad" />
                                                        <asp:BoundField DataField="provincia" HeaderText="Provincia" Visible="false" />
                                                        <asp:BoundField DataField="cp" HeaderText="CP"  Visible="false"/>
                                                        <asp:BoundField DataField="horario" HeaderText="Horario de Cobro" htmlencode="false" />
                                                        
                                                        <asp:TemplateField SortExpression="Cobrador" HeaderText="Cobrador">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlCobrador" runat="server" DataTextField="Nombre" DataValueField="Id" DataSource='<%# GetTableCobrador() %>'
                                                                    AutoPostBack="true" SelectedValue='<%# Bind("IdCobrador") %>' CssClass="comboEditor" OnSelectedIndexChanged="gvModificacion_OnChanged">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Observ. Historia">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" OnClick="verObservacionesHistoria" Text="Ver..." Visible='<%# Eval("TieneObservacionesHistoria") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="Ingresada" HeaderText="Ingresada">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlIngresada" runat="server" DataTextField="Descripcion" DataValueField="Ingresada"
                                                                    AutoPostBack="true" SelectedValue='<%# Bind("Ingresada") %>' CssClass="comboEditor" OnSelectedIndexChanged="gvModificacion_OnChanged">
                                                                    <asp:ListItem Value="False" Text="No Ingresada" />
                                                                    <asp:ListItem Value="True" Text="Ingresada" />
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="Estado" HeaderText="Estado">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlEstadosHoja" runat="server" DataTextField="Descripcion"
                                                                    DataValueField="IdEstadoHoja" AutoPostBack="true" SelectedValue='<%# Bind("IdEstadoHoja") %>'
                                                                    CssClass="comboEditor" OnSelectedIndexChanged="gvModificacion_OnChanged" >
                                                                    <asp:ListItem Value="0" Text="--- Sin Selección ---" />
                                                                    <asp:ListItem Value="1" Text="Cobrado" />
                                                                    <asp:ListItem Value="2" Text="No cobrado" />
                                                                    <asp:ListItem Value="3" Text="Cobrado y entregado " />
                                                                    <asp:ListItem Value="4" Text="Entregado" />
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Observaciones">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="textboxEditor" Height="30"
                                                                    Width="132" TextMode="MultiLine" Columns="45" Rows="2" Text='<%# Bind("Observaciones") %>' OnTextChanged="gvModificacion_OnChanged" AutoPostBack="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgBtnConfirmarEdicion" runat="server" CausesValidation="false"
                                                                    ImageUrl="~/Images/ConfirmarEdicion.PNG" OnClick="btnActualizarDeudorHoja_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ObservacionesHistoria" HeaderText="ObservacionesHistoria" InsertVisible="false">
                                                            <HeaderStyle CssClass="HiddenColumn" /> 
                                                            <ItemStyle CssClass="HiddenColumn" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="nroItem" HeaderText="NroItem" InsertVisible="false">
                                                            <HeaderStyle CssClass="HiddenColumn" /> 
                                                            <ItemStyle CssClass="HiddenColumn" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                </td></tr>
                                                                <tr>
                                                                    <td colspan="100%">
                                                                   
                                                                        <div id="div<%# Eval("IdDeudor") %>" style="display: none; position: relative; left: 5px">
                                                                            <asp:GridView ID="gvFacturasModificacion" runat="server" AutoGenerateColumns="false"
                                                                                CellPadding="3" DataKeyNames="IdFactura" OnRowEditing="gvFacturasModificacion_RowEditing"
                                                                                OnRowDataBound="gvFacturasModificacion_RowDataBound" AllowSorting="False" BorderWidth="0px"
                                                                                Width="65%" Font-Bold="false">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="IdCliente" HeaderText="IdCliente" InsertVisible="false">
                                                                                        <HeaderStyle CssClass="HiddenColumn" />
                                                                                        <ItemStyle CssClass="HiddenColumn"/>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="idDeudor" HeaderText="IdDeudor" InsertVisible="false">
                                                                                        <HeaderStyle CssClass="HiddenColumn" />
                                                                                        <ItemStyle CssClass="HiddenColumn"/>
                                                                                    </asp:BoundField>

                                                                                    
                                                                                    <asp:BoundField DataField="NroItem" HeaderText="NroItem" InsertVisible="false">
                                                                                        <HeaderStyle CssClass="HiddenColumn" />
                                                                                        <ItemStyle CssClass="HiddenColumn"/>
                                                                                    </asp:BoundField>

                                                                                    <asp:BoundField DataField="IdHoja" HeaderText="IdHoja" InsertVisible="false">
                                                                                        <HeaderStyle CssClass="HiddenColumn" />
                                                                                        <ItemStyle CssClass="HiddenColumn"/>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="ComprobanteFormateado" HeaderText="IdFactura" />
                                                                                    <asp:BoundField DataField="FechaVenc" HeaderText="Fecha Vencimiento" DataFormatString="{0:dd/MM/yyyy}"
                                                                                        ItemStyle-HorizontalAlign="Center" />
                                                                                    <asp:BoundField DataField="FechaCobro" HeaderText="Fecha Cobro" DataFormatString="{0:dd/MM/yyyy}"
                                                                                        ItemStyle-HorizontalAlign="Center" />
                                                                                    <asp:BoundField DataField="Importe" HeaderText="Importe" ItemStyle-HorizontalAlign="Right" />
                                                                                    <asp:BoundField DataField="Saldo" HeaderText="Saldo" ItemStyle-HorizontalAlign="Right" />
                                                                                    <asp:TemplateField HeaderText="Importe Modificado" Visible="true" ItemStyle-HorizontalAlign="Right">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtImporteModificado" runat="server" CssClass="textboxEditorRight" Width="50"
                                                                                                Text='<%# Bind("ImporteModificado") %>'  OnTextChanged="gvFacturasModificacion_OnChanged" AutoPostBack="true" CausesValidation="true">
                                                                                            </asp:TextBox>
                                                                                            <asp:CompareValidator ID="txtImporteModificadoValidator" runat="server" ControlToValidate="txtImporteModificado"
                                                                                                ErrorMessage="Debe ingresar un importe válido mayor que 0.00." ForeColor="" Operator="GreaterThanEqual"
                                                                                                Type="Currency" ValueToCompare="0" Display="Dynamic" EnableClientScript='true' Enabled="true">
                                                                                            </asp:CompareValidator>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Se pagó" Visible="true">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkSePago" runat="server" Checked='<%# Bind("SePago") %>'  OnCheckedChanged="gvFacturasModificacion_OnChanged" AutoPostBack="true"/>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField SortExpression="Ingresada" HeaderText="Ingresada" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:DropDownList ID="ddlIngresada" runat="server" DataTextField="Descripcion" DataValueField="Ingresada"
                                                                                                AutoPostBack="false" SelectedValue='<%# Bind("Ingresada") %>' CssClass="comboEditor">
                                                                                                <asp:ListItem Value="False" Text="No Ingresada" />
                                                                                                <asp:ListItem Value="True" Text="Ingresada" />
                                                                                            </asp:DropDownList>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField SortExpression="Estado" HeaderText="Estado" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:DropDownList ID="ddlEstadosHoja" runat="server" DataTextField="Descripcion"
                                                                                                DataValueField="IdEstadoHoja" AutoPostBack="false" SelectedValue='<%# Bind("IdEstadoHoja") %>'
                                                                                                CssClass="comboEditor">
                                                                                                <asp:ListItem Value="0" Text="--- Sin Selección ---" />
                                                                                                <asp:ListItem Value="1" Text="Cobrado" />
                                                                                                <asp:ListItem Value="2" Text="No cobrado" />
                                                                                                <asp:ListItem Value="3" Text="Cobrado y entregado " />
                                                                                                <asp:ListItem Value="4" Text="Entregado" />
                                                                                            </asp:DropDownList>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Observaciones" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="textboxEditor" Height="30"
                                                                                                Width="152" TextMode="MultiLine" Columns="50" Rows="2" Text='<%# Bind("Observaciones") %>'></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="imgBtnConfirmarEdicion" runat="server" CausesValidation="true"
                                                                                                ImageUrl="~/Images/ConfirmarEdicion.PNG" OnClick="btnActuualizarItemHoja_Click"  />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                                <EmptyDataTemplate>
                                                                                    No se hallaron resultados.</EmptyDataTemplate>
                                                                                <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                                                <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                                <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                                <RowStyle CssClass="gvItem" />
                                                                            </asp:GridView>
                                                                        </div>
                                                      
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                    <EmptyDataTemplate>
                                                        No se hallaron resultados.</EmptyDataTemplate>
                                                    <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                    <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                    <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                    <RowStyle CssClass="gvItem" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </Content>
                            </cc1:AccordionPane>
             <cc1:AccordionPane ID="pnlModificacionDeudoresSinGestion" runat="server" Visible="true">
                                <Header>
                                    <table width="100%" style="visibility: hidden">
                                        <tr>
                                            <td style="width: 100%; height: 30px; visibility:hidden " class="fondo_Titulo"  >
                                                Hoja de Ruta (Modificación de Deudores Sin Gestión)
                                            </td>
                                        </tr>
                                    </table>
                                </Header>
                                <Content>
                                    <table style="width: 100%; height: 300px; font-family: Verdana; font-size: 11px;
                                        color: #224466;" border="0">
                                        <tr>
                                            <td colspan="7" align="left" valign="top" class="style6">
                                                <asp:GridView ID="gvModificacionDeudoresSinGestion" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                    DataKeyNames="IdDeudor" AllowSorting="False"
                                                    BorderWidth="0px" Width="100%" Font-Bold="true" Visible="false">
                                                    <Columns>
                                                        <asp:BoundField DataField="nroItem" HeaderText="NroItem" InsertVisible="false">
                                                            <HeaderStyle CssClass="HiddenColumn" /> 
                                                            <ItemStyle CssClass="HiddenColumn" />
                                                        </asp:BoundField>
                                                        
                                                        <asp:BoundField DataField="idCliente" HeaderText="IdCli"  ShowHeader="false" />
                                                        <asp:BoundField DataField="cliente" HeaderText="Cliente" />
                                                        <asp:BoundField DataField="IdDeudor" HeaderText="Alfanum" />
                                                        <asp:BoundField DataField="deudor" HeaderText="Deudor" />
                                                        <asp:BoundField DataField="domicilio" HeaderText="Domicilio" />
                                                        <asp:BoundField DataField="localidad" HeaderText="Localidad" />
                                                        <asp:BoundField DataField="provincia" HeaderText="Provincia" Visible="false" />
                                                        <asp:BoundField DataField="cp" HeaderText="CP"  Visible="false"/>
                                                        <asp:BoundField DataField="horario" HeaderText="Horario de Cobro" htmlencode="false" />
                                                        <asp:TemplateField SortExpression="Cobrador" HeaderText="Cobrador">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlCobrador" runat="server" DataTextField="Nombre" DataValueField="Id" DataSource='<%# GetTableCobrador() %>'
                                                                    AutoPostBack="true" SelectedValue='<%# Bind("IdCobrador") %>' CssClass="comboEditor" OnSelectedIndexChanged="gvModificacionDeudoresSinGestion_OnChanged">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Observ. Historia">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" OnClick="verObservacionesHistoria" Text="Ver..." Visible='<%# Eval("TieneObservacionesHistoria") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="Ingresada" HeaderText="Ingresada">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlIngresada" runat="server" DataTextField="Descripcion" DataValueField="Ingresada"
                                                                    AutoPostBack="true" SelectedValue='<%# Bind("Ingresada") %>' CssClass="comboEditor" OnSelectedIndexChanged="gvModificacionDeudoresSinGestion_OnChanged">
                                                                    <asp:ListItem Value="False" Text="No Ingresada" />
                                                                    <asp:ListItem Value="True" Text="Ingresada" />
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="Estado" HeaderText="Estado">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlEstadosHoja" runat="server" DataTextField="Descripcion"
                                                                    DataValueField="IdEstadoHoja" AutoPostBack="true" SelectedValue='<%# Bind("IdEstadoHoja") %>'
                                                                    CssClass="comboEditor" OnSelectedIndexChanged="gvModificacionDeudoresSinGestion_OnChanged" >
                                                                    <asp:ListItem Value="0" Text="--- Sin Selección ---" />
                                                                    <asp:ListItem Value="1" Text="Cobrado" />
                                                                    <asp:ListItem Value="2" Text="No cobrado" />
                                                                    <asp:ListItem Value="3" Text="Cobrado y entregado " />
                                                                    <asp:ListItem Value="4" Text="Entregado" />
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Observaciones">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="textboxEditor" Height="30"
                                                                    Width="132" TextMode="MultiLine" Columns="45" Rows="2" Text='<%# Bind("Observaciones") %>' OnTextChanged="gvModificacionDeudoresSinGestion_OnChanged" AutoPostBack="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgBtnConfirmarEdicion" runat="server" CausesValidation="false"
                                                                    ImageUrl="~/Images/ConfirmarEdicion.PNG" OnClick="btnActualizarDeudorSinGestionHoja_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                    <EmptyDataTemplate>
                                                        No se hallaron resultados.</EmptyDataTemplate>
                                                    <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                    <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                    <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                    <RowStyle CssClass="gvItem" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </Content>
                            </cc1:AccordionPane>
                      
            </Panes>
        </cc1:Accordion>
                </asp:Panel>
            </ContentTemplate>
    </asp:updatepanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="menuJQUERY">
</asp:Content>
