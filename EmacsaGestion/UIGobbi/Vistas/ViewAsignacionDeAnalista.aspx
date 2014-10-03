<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Theme="SampleSiteTheme" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ViewAsignacionDeAnalista.aspx.cs" Inherits="Vistas_ViewAsignacionDeAnalista" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" Runat="Server">
    <link rel="stylesheet" type="text/css" href="/UIControls/MenuJQuery/styleMenu.css" />

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/jquery.dimensions.min.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/jquery.menu.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shCore.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushXml.js"></script>

    <script type="text/javascript" src="/UIControls/MenuJQuery/Menu/shBrushJScript.js"></script>
    
    <script tpe="text/javascript">
<!--
        $(document).ready(function() {
            var options = { minWidth: 120, arrowSrc: '/UIControls/MenuJQuery/Menu/arrow_right.gif', copyClassAttr: true, onClick: function(e, menuItem) {
                //openMenu(



                document.location = 'http://localhost/vistas/ViewImportacionDeFacturas.aspx';



                //);
                //alert('you clicked item "' + $(this).text() + e  + '"');
            } 
            };
        });
-->
 
    </script>

    <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />    
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
    
 <%--   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>--%>
    
     <script type="text/javascript">
                var ModalPopupCargando='<%= ModalPopupCargando.ClientID %>';
                                   
              		
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
                
function EndRequestHandler(sender,args)
{
if (args.get_error()!=undefined)
alert("There was an error" + args.get_error().message);
}


function beginReq(sender, args) 
{

	var controlCaller=args.get_postBackElement().id;

	if(controlCaller.indexOf('UpdateTimer')==-1){$find(ModalPopupCargando).show()};
   
 }
 
function endReq(sender, args)
{
if (args.get_error()!=undefined)
alert("There was an error" + args.get_error().message);

   //var controlCaller=args.get_postBackElement().id;
	                        //  shows the Popup 
	                        
	                        $find(ModalPopupCargando).hide();
	                       // if(controlCaller.indexOf('btnNuevaRemisionTemporal')!=-1){$find(btnNuevaRemisionTemporal).disabled=false;};
} 

 
 
</script>
    
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


     <ajaxToolkit:ModalPopupExtender ID="ModalPopupCargando" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
        
        
    <!--Desde aqui comenzar a realizarlo -->
    <div align="center">
    <table cellpadding="0" cellspacing="0" class="borderCompleto">
        <tr>
            <td align="left" class="fondo_Titulo" colspan="3">
                <table>
                    <tr>
                        <td>
                            Asignaci&oacute;n de Deudores
                        </td>
                        <td valign="top">
                            &nbsp;
                        </td>                        
                    </tr>
                </table>
            </td>        
        </tr>
        <tr><th class="labelBold" style="font-size:11px;">Cliente</th><th class="labelBold" style="font-size:11px;">Deudor</th><th class="labelBold" style="font-size:11px;">Analista</th></tr>
        <tr>
            <asp:UpdatePanel ID="UpdateCombos" runat="server">
                <ContentTemplate>
                    <td><ajaxToolkit:ComboBox ID="cmbClientes" runat="server" OnSelectedIndexChanged="cmbClientes_SelectedIndexChanged" AutoPostBack="true" AutoCompleteMode="SuggestAppend" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px" MaxLength="0" Width="160px"></ajaxToolkit:ComboBox></td>
                    <td><ajaxToolkit:ComboBox ID="cmbDeudores" runat="server" AutoCompleteMode="SuggestAppend" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px" MaxLength="0" Width="160px"></ajaxToolkit:ComboBox></td>
                    <td><ajaxToolkit:ComboBox ID="cmbAnalistas" runat="server" OnSelectedIndexChanged="cmbAnalistas_SelectedIndexChanged" AutoPostBack="true" AutoCompleteMode="SuggestAppend" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px" MaxLength="0" Width="160px"></ajaxToolkit:ComboBox></td>
                </ContentTemplate>
            </asp:UpdatePanel>
        </tr>
        <tr><th colspan="3"><asp:Button ID="btnAsignar" runat="server" Text="Asignar" OnClick="btnAsignar_Click" CssClass="button_back" /></th></tr>
    </table>    
    <span class="labelBold">Deudores asociados para el Analista seleccionado:</span><br />
    <table><tr><td>
    <ma:XGridView ID="gvResultados" runat="server"  AllowSorting="true" AutoGenerateColumns="false"  
        BorderWidth="0px" EmptyDataText="No se encontraron resultados" ExecutePageIndexChanging="true"  Width="436"
        OnFilling="gvResultados_Filling" OnPageIndexChanging="gvResultados_PageIndexChanging"
        OnRowDeleting="gvResultados_RowDeleting">
        <AlternatingRowStyle CssClass="gvAlternatingItem" />
        <Columns>
            <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton OnClientClick="return confirm('¿Esta seguro que desea eliminar el registro?');" Visible="true" ID="btnDelete" runat="server" ImageUrl="~/Images/delete.gif" CommandName="Delete" />                    
                </ItemTemplate>
                <HeaderStyle Font-Bold="true" />
            </asp:TemplateField>
            <asp:BoundField DataField="idDeudor" HeaderText="idDeudor" SortExpression="idDeudor" ItemStyle-HorizontalAlign="Center">
                <HeaderStyle Font-Bold="true" />
            </asp:BoundField>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
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
    </td></tr></table>
    </div>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPie" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeader" Runat="Server">
</asp:Content>