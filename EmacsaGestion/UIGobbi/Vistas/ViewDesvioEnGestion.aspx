<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewDesvioEnGestion.aspx.cs" Inherits="Vistas_ViewDesvioEnGestion" %>

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
    
    <script type="text/javascript" src="../Js/HojaDeRuta.js"></script>
    
    <script type="text/javascript">
    <!--
        $(document).ready
        (
            function() 
            {
                var options =
                { 
                    minWidth: 120, arrowSrc: '/UIControls/MenuJQuery/Menu/arrow_right.gif', copyClassAttr: true, onClick: function(e, menuItem) 
                    {
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
        function ValidarBusqueda() 
        {
            var txtLocalidad = document.getElementById("ctl00_Contentplaceholder1_txtLocalidad");
            var txtCodigoPostal = document.getElementById("ctl00_Contentplaceholder1_txtCodigoPostal");
            
            //Si los dos campos tienen texto, o no completó ninguno
            if ((txtLocalidad.value.length > 0 && txtCodigoPostal.value.length > 0) || (txtLocalidad.value.length == 0 && txtCodigoPostal.value.length == 0))
            {
                alert("Complete solo un campo de búsqueda.");
                return false;
            }
            if (txtCodigoPostal.value.length > 0) 
            {
                //Hay algo escrito en CP, valida que sea numérico
                if (/^[0-9]+$/.test(txtCodigoPostal.value))
                    return true;
                else 
                {
                    alert("El código postal debe ser numérico.");
                    return false;
                }
            }
        }
        
    </script>
    
    <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />    
    <link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
    <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />
    <asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="upZonas">
            <ProgressTemplate>
                <div style="position: relative; top: 30%; text-align: center;">
                    <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                    Procesando...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress" BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />

   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <!--Desde aqui desarrollarlo-->    
    
    
    <asp:UpdatePanel ID="upZonas" runat="server">
    <ContentTemplate >
    
     <asp:Panel ID="Panel2" runat="server"  align="center">
        <table cellpadding="0" cellspacing="0" class="borderCompleto" 
            style="width:730px; height:88%;">
            <tr>
                <td align="left" class="fondo_Titulo" style="height: 23px" width="100%;">
                    <table width="100%">
                        <tr>
                            <td style="width:100%; height:30px;">Desvio de gestiones por analista: </td><td valign="top"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" style="background-color: #EDEBEB; border-style: none groove outset none;
                                                border-bottom-color: #FFFFFF; border-right-color: #C0C0C0; border-width: thin 2px 2px 1px;
                                                border-spacing: 2px; border-collapse: collapse">
                    <asp:Panel ID="pnlAsociarDatos" runat="server">
                        
                            <table style="width: 482px" border="0">
                            <tr align="left">
                         <%--       <td class="labelBold">Zona:</td>--%>
                                <td align="center">
                                <asp:Label runat="server" class="labelBold" Text="Zona"></asp:Label>
                                    <ajaxToolkit:ComboBox ID="cmbAnalistas" runat="server" OnSelectedIndexChanged="cmbAnalistas_SelectedIndexChanged" AutoPostBack="true" AutoCompleteMode="SuggestAppend" BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px" DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px" MaxLength="0" Width="160px"></ajaxToolkit:ComboBox>                               
                                </td>
                            </tr>
                                 </table>
                        
                    </asp:Panel>
                </td>
           </tr>
           <tr>
               <td align="center" style="background-color: #EDEBEB; border-style: none groove outset none;
                                                border-bottom-color: #FFFFFF; border-right-color: #C0C0C0; border-width: thin 2px 2px 1px;
                                                border-spacing: 2px; border-collapse: collapse">
                  <asp:Label runat="server" class="labelBold" Text="Localidades Asignadas"></asp:Label>
                  <br />                              
                  <asp:Panel ID="PnlListaCarga" runat="server" CssClass="scrollbar" 
                            Height="218px" Width="647px">                                                
                        <ma:XGridView ID="GvResultados" runat="server" AllowPaging="True" 
                                AllowSorting="True" AutoGenerateColumns="False"
                            BorderWidth="0px" EmptyDataText="No se encontraron resultados" ExecutePageIndexChanging="True" 
                            OnFilling="GvResultados_Filling" OnPageIndexChanging="GvResultados_PageIndexChanging"
                            PageSize="7" Width="642px" ShowFooter="True">
                            <AlternatingRowStyle CssClass="gvAlternatingItem" />
                            <Columns>
                                                                    
                                <asp:BoundField DataField="idFactura" HeaderText="Factura" 
                                    HeaderStyle-Font-Bold="true" SortExpression="localidad" >
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="fechaAGestionar" HeaderText="Fe" 
                                    HeaderStyle-Font-Bold="true" SortExpression="cp" >                            
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle CssClass="gvEmptyData" HorizontalAlign="Center" /><EmptyDataTemplate>No se hallaron resultados.</EmptyDataTemplate>
                            <HeaderStyle CssClass="gvHeader grayGvHeader" HorizontalAlign="Center" />
                            <RowStyle CssClass="gvItem" HorizontalAlign="Center" />
                            <FooterStyle CssClass="gvHeader grayGvHeader" />
                            <PagerStyle CssClass="fondo_Titulo" HorizontalAlign="Center" />
                        </ma:XGridView>
                        <asp:HiddenField ID="txtCP" runat="server" />                    
                        </asp:Panel>
                 
               </td>
           
           </tr>
           <tr>
              <td align="center" style="background-color: #EDEBEB; border-style: none groove outset none;
                                                border-bottom-color: #FFFFFF; border-right-color: #C0C0C0; border-width: thin 2px 2px 1px;
                                                border-spacing: 2px; border-collapse: collapse">
                  <asp:Label runat="server" class="labelBold" Text="Cobradores Asignados"></asp:Label>
                  <br />
                  <asp:ListBox runat="server" ID="listBoxCobradores">
                  </asp:ListBox>
              </td>
           
           </tr>
       </table>
    </asp:Panel>
      
 
    </ContentTemplate>
    </asp:UpdatePanel>
   
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPie" Runat="Server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeader" Runat="Server"></asp:Content>