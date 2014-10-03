<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewLocalizarRecibo.aspx.cs" Inherits="Vistas_ViewLocalizarRecibo"
    Title="Localizar Recibo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>

<%--    <asp:scriptmanager id="ScriptManager1" runat="server" enablepagemethods="true" enablepartialrendering="true">
    </asp:scriptmanager>--%>
    <table cellpadding="0" border="0" cellspacing="0" style="width: 100%; height: 195px;
        left: 0;">
        <tr>
            <td valign="middle" align="center" style="height: 10px; font-family: Tahoma, Arial, MS Sans Serif;
                color: #666666; font-weight: bold; font-size: 12px; background-color: #EDEBEB;
                border-right: #cccccc 2px solid; border-bottom: #cccccc 1px inset; text-align: left;"
                valign="top">
                <asp:label id="lblAdmCasos" runat="server">Edición de Recibo</asp:label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <table style="width: 900px; height: 100%;" class="border" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table style="width: 950px; height: 88%;" class="borderCompleto" cellpadding="0"
                                cellspacing="0">
                                <tr>
                                    <td width="100%;" class="fondo_Titulo" align="left" style="height: 23px">
                                        Filtros de Búsqueda
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="80%">
                                            <tr align="left" style="border: 3px; height: 20px;">
                                                <td align="left" bgcolor="#F2F2F2" class="border" style="width: 40px; border-width: 1px;
                                                    border-style: solid;" valign="top">
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td align="left" style="width: 800px; border-width: 1px; border-style: solid;" valign="top">
                                                    <table>
                                                        <tr style="width:500px;">
                                                            <td valign="top" align="center">
                                                                <table>
                                                                    <tr style="width:500px;">
                                                                        <td style="width: 300px;">
                                                                            <asp:label id="lblNumRemision" runat="server" style="font-family: Verdana; font-size: 9px;"
                                                                                text="N° Remisión"></asp:label>
                                                                            &nbsp;&nbsp;&nbsp;
                                                                            <asp:textbox id="txtNumRemision" runat="server" cssclass="textboxEditor" validationgroup="MKE"
                                                                                width="100px"></asp:textbox>
                                                                              
                                                                        </td>
                                                                        <td>
                                                                            <asp:button id="btnBuscarPorRemision" runat="server" cssclass="button_back" text="Ver"
                                                                                causesvalidation="True" ValidationGroup="remisionABuscarGroup" width="92px" OnClick="btnBuscarPorRemision_OnClick"></asp:button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td align="center" align="center">
                                                                <table>
                                                                    <tr>
                                                                        <td style="width: 200px;">
                                                                            <asp:label id="lblNumRecibo" runat="server" style="font-family: Verdana; font-size: 9px;"
                                                                                text="N° Recibo"></asp:label>
                                                                            &nbsp;&nbsp;&nbsp;
                                                                            <asp:textbox id="txtNumRecibo" runat="server" cssclass="textboxEditor" validationgroup="MKE"
                                                                                width="100px"></asp:textbox>
                                                                               
                                                                               
                                                                 
                                                                        </td>
                                                                        <td>
                                                                            <asp:button id="btnBuscarPorRecibo" runat="server" cssclass="button_back" text="Ver"
                                                                                 causesvalidation="True" width="92px" OnClick="btnBuscarPorRecibo_OnClick" ValidationGroup="reciboABuscarGroup" ></asp:button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                           <td colspan="2">
                                                           <asp:RegularExpressionValidator runat="server" ErrorMessage="Formato Inválido" ControlToValidate="txtNumRemision" ValidationGroup="remisionABuscarGroup" ValidationExpression="^[0-9]{1,7}$"></asp:RegularExpressionValidator>    
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator99" runat="server" ControlToValidate="txtNumRemision"
                                                                                ErrorMessage="Ingrese número Remision" ValidationGroup="remisionABuscarGroup"></asp:RequiredFieldValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator990" runat="server" ControlToValidate="txtNumRecibo"
                                                                                ErrorMessage="Ingrese número Recibo" ValidationGroup="reciboABuscarGroup"></asp:RequiredFieldValidator>
                                                           </td>
                                                        
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td align="right">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <table cellpadding="0" cellspacing="0" class="borderCompleto" style="width: 900px;
                                height: 88%;">
                                <tr>
                                    <td align="left" class="fondo_Titulo" style="height: 23px" width="100%;">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="width: 100%; height: 30px;">
                                                    Resultados
                                                </td>
                                                <td valign="top">
                                                    <asp:imagebutton id="ImageButton3" runat="server" imageurl="~/Images/excel_small.gif"
                                                        />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <table>
                                            <tr>
                                                <td align="left">
                                                    <asp:panel id="PnlListaCarga" runat="server" cssclass="scrollbar" height="250px"
                                                        width="950px" scrollbars="Horizontal">
                                            <ma:XGridView ID="gvResultados" runat="server"  AllowSorting="True"
                                                AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No se encontraron resultados"
                                                ExecutePageIndexChanging="True" Width="436px"
                                                Style="text-align: center; margin-left: 10%" 
                                                
                                                onselectedindexchanged="gvResultados_SelectedIndexChanged" 
                                                            onrowediting="gvResultados_RowEditing" Height="232px" 
                                                            onrowcommand="gvResultados_RowCommand" >
                                                <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                <Columns>
                                                <asp:BoundField DataField="fechaCreacion" HeaderText="Fecha Creación" />
                                                <asp:BoundField DataField="idRemision" HeaderText="N° Remisión" />
                                                <asp:BoundField DataField="usuarioCreador" HeaderText="Usuario" />
                                                <asp:BoundField DataField="estado" HeaderText="Estado Remisión" />
                                                <asp:BoundField DataField="idRecibo" HeaderText="Id Recibo" />
                                                <asp:BoundField DataField="numRecibo" HeaderText="N° Recibo" />
                                                <asp:BoundField DataField="NSAP" HeaderText="N° SAP" />
                                                <%--<asp:BoundField DataField="tipoDeCambio" HeaderText="Tipo de Cambio" />--%>
                                                <%--<asp:BoundField DataField="usadoRemision" HeaderText="Usado en Remisión" />--%>
                                                <asp:BoundField DataField="idDeudor" HeaderText="ID Deudor" />
                                                <asp:BoundField DataField="nombreDeudor" HeaderText="Nombre Deudor" />
                                                <asp:BoundField DataField="idCliente" HeaderText="ID Cliente" />
                                                <asp:BoundField DataField="nombreCliente" HeaderText="Nombre Cliente" />
                                                <asp:BoundField DataField="cuitCliente" HeaderText="Cuit Cliente" />
                                               <%-- <asp:CommandField HeaderText="Editar Recibo" ShowSelectButton="True" />--%>
                                                    
                                                 <%--   <asp:CommandField HeaderText="Descargar remisión" ShowCancelButton="False" 
                                                        ButtonType="Button" EditText="Pdf" ShowEditButton="True" >--%>
                                                        
                                                          <asp:ButtonField ButtonType="Button" HeaderText="Descargar Remisión" 
                                                        ShowHeader="True" Text="Pdf" CommandName="PFD"  />
                                                        
                                                    
                                                    <%--    <ItemStyle BorderColor="#0066FF" />
                                                    </asp:CommandField>--%>
                                                    
                                                    <asp:CommandField ButtonType="Button" EditText="Excel" 
                                                        HeaderText="Deposito Excel" SelectText="Excel" ShowSelectButton="True" />
                                                    
                                                    <asp:ButtonField ButtonType="Button" HeaderText="Archivos Especiales" 
                                                        ShowHeader="True" Text="Descargar" CommandName="ESP" />
                                                    
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
                                        </asp:panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                
                                                <td align="right">
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table> </td> </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="menuJQUERY">
</asp:Content>
