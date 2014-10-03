<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewGestionCobradores.aspx.cs" Inherits="Vistas_ViewGestionCobradores" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
    <link href="/UIControls/MenuJQuery/styleMenu.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/cssUpdateProgress.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>

   <%-- <asp:scriptmanager id="ScriptManager1" runat="server" enablepagemethods="true" enablepartialrendering="true"></asp:scriptmanager>--%>
   
   <table align="center" style="height: 557px">
        <tr>
            <td valign=top >
                <asp:updatepanel id="upGestionDeCobradores" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" >
            <tr>
        
               <td style="width: 50%; height: 30px;" class="fondo_Titulo">
                            Gesti&oacute;n de Recibos
                </td>
               
            </tr>
            <tr>
                
                <td valign="top" align =center>
                         <%--       <asp:Panel ID="pnlAgregarRecibo" runat="server">--%>
                <table cellpadding="0" cellspacing="0" class="borderCompleto" >
                <tr align="left">
                    <td class="labelCliente" align="left">Cliente</td>
                    <td align="left">
                        <asp:DropDownList ID="cmbClientes" runat="server" AutoCompleteMode="SuggestAppend" DropDownStyle="DropDownList" Height="18px" MaxLength="0" 
                            BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="11px" BackColor="#FFFFCC" Width="177px" AutoPostBack="true" OnSelectedIndexChanged="cmbClientes_SelectedIndexChanged">                    
                        </asp:DropDownList>
                    </td>
                </tr>        
                    <tr align="left">
                        <td class="labelCliente" align="left">Nro. Recibo Desde</td>
                        <td align="left">                
                            <asp:TextBox ID="txtRecibo" runat="server" CssClass="textboxEditor" Height="16px" Width="113px" MaxLength="13">0000-</asp:TextBox>
                            <asp:RegularExpressionValidator ID="revRecibo" runat="server" ControlToValidate="txtRecibo" ErrorMessage="Error, no respeta el formato." ValidationExpression="\d{4}-\d{8}"></asp:RegularExpressionValidator>                    
                        </td>
                    </tr>
                    <tr align="left">
                        <td class="labelCliente" align="left">Nro. Recibo Hasta</td>
                        <td align="left">                
                            <asp:TextBox ID="txtReciboHasta" runat="server" CssClass="textboxEditor" Height="16px" Width="113px" MaxLength="13">0000-</asp:TextBox>
                            <asp:RegularExpressionValidator ID="revReciboHasta" runat="server" ControlToValidate="txtReciboHasta" ErrorMessage="Error, no respeta el formato." ValidationExpression="\d{4}-\d{8}"></asp:RegularExpressionValidator>                    
                        </td>
                    </tr>
                    <tr>
                        <td class="labelCliente" align="left">Cobrador</td>
                        <td align="left">
                            <table>
                            <tr>
                            <td>
                            <asp:DropDownList ID="ddlMotoquero" runat="server" AutoCompleteMode="SuggestAppend" DropDownStyle="DropDownList" Height="18px" MaxLength="0" 
                                BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="11px" BackColor="#FFFFCC" >
                            </asp:DropDownList>
                            </td>
                            <td>
                            <asp:Button ID="btnAsignar" runat="server" Text="Cambiar Cobrador" CssClass="button_back" OnClick="btnAsignar_Click" />    
                            </td>
                            </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="1" align="center">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="button_back" OnClick="btnAgregar_Click" />
                            
                        </td>
                    </tr>
                    <tr>
                    <td>
                                    
                    </td>
                    </tr> 
                </table>    
                
      <%--      </asp:Panel> --%>
                </td>                        
            </tr>
            </table>
            <table>
                   <tr>
                      <td align=center>
                          <asp:Panel ID="Panel2" runat="server" Height="180px" ScrollBars="Horizontal" Width="700px">
                                                            <ma:XGridView ID="XGridViewRecibos" runat="server" AllowPaging="True" 
                                                                    AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" 
                                                                    DataKeyNames="Id" EmptyDataText="No se hallaron resultados" 
                                                                    ExecutePageIndexChanging="True"
                                                                    PageSize="5" 
                                                                    Width="100%"
                                                                    OnFilling="XGridViewRecibos_Filling"
                                                                    OnPageIndexChanging="XGridViewRecibos_PageIndexChanging" 
                                                                    >
                                                                    <AlternatingRowStyle CssClass="gvAlternatingItem" />
                                                                         <Columns>
                                                                             <asp:BoundField DataField="numero" HeaderText="Número" Visible="true"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField  DataFormatString="{0:dd/MM/yyyy}"  DataField="fechaCarga" HeaderText="Fecha Carga" ItemStyle-HorizontalAlign="Center"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="nombreCobrador" HeaderText="Cobrador" Visible="true"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="nombreCliente" HeaderText="Cliente" Visible="true"><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                             <asp:BoundField DataField="usadoRemisionSiNo" HeaderText="Usado Remision" Visible="true"  ><HeaderStyle Font-Bold="True" /></asp:BoundField>
                                                                         </Columns>
                                                                         <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" />
                                                                         <EmptyDataTemplate>No se hallaron resultados.</EmptyDataTemplate>
                                                                         <FooterStyle CssClass="gvHeader grayGvHeader" />
                                                                         <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                                                                         <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                                                                         <RowStyle CssClass="gvItem" />
                                                                         
                                                             </ma:XGridView>
                          </asp:Panel>
                      </td>
                   </tr>
            </table>
            <br />
            

        </ContentTemplate>    
    </asp:updatepanel>
            
            
            </td>
        
        </tr>
   
   </table>
   
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
