<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Vistas_ViewHojaDeRutaAlta, App_Web_nu_04hm5" %>

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
 
  
    <script type="text/javascript">
       
           var ModalPopupCargando='<%= ModalPopupCargando.ClientID %>';
           Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
           Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
           
//        function  toogleDSG(visible) {
//            try {
//                        var oDivDSG = document.getElementById('divDSG');
//                        if (oDivDSG != undefined) {
//                                if (visible) {
//                                    oDivDSG.style.visibility = 'visible';
//                                } else {
//                                    oDivDSG.style.visibility = 'hidden';
//                                }
//                        }
//               } 
//               catch (e){
//                     alert (el);
//              }
//      }
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
                    mce_src = "../Images/Expand_button_white.jpg";
                    
                }
                else 
                {
                    img.src = "../Images/Expand_button_white_down.jpg";
                    mce_src = "../Images/Expand_button_white.jpg";
                    
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
 $find(ModalPopupCargando).show();
}

function endReq(sender, args)
{
 $find(ModalPopupCargando).hide();
} 

   
function  showProcesando() {
        try {
                var oDivProcesando = document.getElementById('divProcesando');
                if (oDivProcesando != undefined) 
                    {
                    oDivProcesando.style.visibility = 'visible';
                    }
             } 
             catch (e)
             {
                alert (el);
             }

}
    </script>
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
    
        <asp:updatepanel id="upHojaDeRutaABM" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlPrincipal" runat="server" Width="100%" Height="600px">
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
                                                                            <div id="div<%# Eval("IdDeudor") %>"  style="display: none; position: relative; left: 5px">
                                                                           
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
