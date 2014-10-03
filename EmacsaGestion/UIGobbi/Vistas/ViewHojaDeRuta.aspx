<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewHojaDeRuta.aspx.cs" Inherits="Vistas_ViewHojaDeRuta" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" runat="Server">
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
    <asp:panel id="panelUpdateProgress" runat="server" cssclass="updateProgress">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="upZonas">
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
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <!--Desde aqui desarrollarlo-->
    <asp:updatepanel id="upZonas" runat="server">
    <ContentTemplate >
    
        <asp:Panel runat="server" align="center">
            <table cellpadding="0" cellspacing="0" class="borderCompleto" 
                style="width:733px; height:88%;">
                <tr>
                    <td align="center" class="fondo_Titulo" style="height: 23px" width="100%;">
                        <table width="100%">
                            <tr>
                                <td></td>
                                <td style="width:100%; height:30px;">Alta de Zonas: </td><td valign="top"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>                    
                    <td valign="top">                    
                            <table style="width: 413px; height: 62px;" border="0">
                            <tr align="left">
                                <td class="labelBold">Buscar Localidad:</td>                                    
                                <td align="left"><asp:TextBox ID="txtLocalidad" runat="server" CssClass="textboxEditor" Width="96"></asp:TextBox></td>                                                        
                                <td class="labelBold">Buscar Código Postal:</td>
                                <td align="left"><asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="textboxEditor" Width="96"></asp:TextBox></td>
                                <td align="right"><asp:ImageButton ID="imgBuscar" runat="server" ImageUrl="~/Images/Lupa_chica.gif" OnClientClick="javascript: return ValidarBusqueda();" OnClick="imgBuscar_Click" /></td>
                                <td align="right" style="padding-left:20px;"> <a href="ViewHojaDeRutaDetalle.aspx" class="labelBold">   Ver detalle de Zonas</a></td>
                            </tr>
                        </table>
                        <asp:Panel ID="PnlListaCarga" runat="server" CssClass="scrollbar" 
                            Height="218px" Width="647px">                                                
                        <ma:XGridView ID="GvResultados" runat="server" AllowPaging="True" 
                                AllowSorting="True" AutoGenerateColumns="False"
                            BorderWidth="0px" EmptyDataText="No se encontraron resultados" ExecutePageIndexChanging="True" 
                            OnFilling="GvResultados_Filling" OnPageIndexChanging="GvResultados_PageIndexChanging"
                            PageSize="7" Width="642px" ShowFooter="True">
                            <AlternatingRowStyle CssClass="gvAlternatingItem" />
                            <Columns>
                                <asp:TemplateField HeaderText="Seleccionar">                                
                                    <ItemTemplate><asp:CheckBox ID="chk" runat="Server" onclick="return AgregarQuitarSeleccion(this);" /></ItemTemplate>
                                </asp:TemplateField>                                       
                                <asp:BoundField DataField="localidad" HeaderText="Localidad" 
                                    HeaderStyle-Font-Bold="true" SortExpression="localidad" >
                                    <HeaderStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cp" HeaderText="Codigo Postal" 
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
                <tr><td align="left" class="fondo_Titulo" style="height: 8px;" width="100%;">Códigos Postales Seleccionados:</td></tr>
                <tr><td align="left" class="fondo_Titulo" style="height: 16px;" width="100%"><asp:Label ID="lblCodigosSeleccionados" runat="server"></asp:Label></td></tr>
                <tr>            
                    <td align="center" class="fondo_Titulo" style="height: 23px" width="100%;">
                        Descripcion: <asp:TextBox ID="txtDescripcion" style="font-family:Verdana;font-size:11px;" runat="server" MaxLength="35"></asp:TextBox>
                        <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="button_back3" OnClientClick="return ConfirmarAltaZona();" OnClick="btnCargar_Click" />
                    </td>
                </tr>            
            </table>        
        </asp:Panel>
    </ContentTemplate>
    </asp:updatepanel>
    <asp:updateprogress id="upProgreso" displayafter="0" runat="server" associatedupdatepanelid="upZonas">
        <ProgressTemplate>
            <div style="position: relative; top: 30%; text-align: left;">
                <img src="../Images/procesando.gif" style="vertical-align: middle" alt="Processing" />
                Procesando...
            </div>
        </ProgressTemplate>
    </asp:updateprogress>
    <br />
    <br />
    <asp:panel id="Panel1" runat="server" align="center">
        <table cellpadding="0" cellspacing="0" class="borderCompleto" 
            style="width:735px; height:190px;">
            <tr>
                <td align="left" class="fondo_Titulo" style="height: 23px" width="100%;">
                    <table width="100%">
                        <tr>
                            <td style="width:100%; height:30px;">Alta de Cobradores: </td><td valign="top"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlSeleccionarDatos" runat="server">
                        
                            <table style="width: 413px; height: 122px;" border="0">
                            <tr align="left">
                                <td class="labelBold">Nombre:</td>                                    
                                <td align="left"><asp:TextBox ID="txtNombre" runat="server" CssClass="textboxEditor" Width="96"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Ingrese el nombre" ControlToValidate="txtNombre" ValidationGroup="cobradorGroup"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="left">
                                <td class="labelBold">Apellido:</td>
                                <td align="left"><asp:TextBox ID="txtApellido" runat="server" CssClass="textboxEditor" Width="96"></asp:TextBox>
                                  <br />
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Ingrese el apellido" ControlToValidate="txtApellido" ValidationGroup="cobradorGroup"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr align="left">
                                <td class="labelBold">DNI:</td>
                                <td><asp:TextBox ID="txtDNI" runat="server" CssClass="textboxEditor" Width="96"></asp:TextBox>
                                  <br />
                                
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDNI"
        ErrorMessage="DNI debe ser numérico" ValidationExpression="^\d*[0-9]$"
        ValidationGroup="cobradorGroup"></asp:RegularExpressionValidator>
                                
                                </td>                                
                                
                            </tr>
                            <tr align="left">
                                <td class="labelBold">Telefono:</td>
                                <td><asp:TextBox ID="txtTelefono" runat="server" CssClass="textboxEditor" Width="96" ></asp:TextBox>
                                  <br />
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Ingrese el teléfono" ControlToValidate="txtTelefono" ValidationGroup="cobradorGroup"></asp:RequiredFieldValidator></td>                                
                            </tr>
                            <tr align="left">
                                <td class="labelBold">Horario de Trabajo:</td>
                                <td><asp:DropDownList ID="ddlHorario" runat="server" style="border-color:#B9B9B9;background-color:#FFFFCC;border-style:solid;border-width:1px;font-family:Verdana;font-size:11px;height:17px;width:100px;"><asp:ListItem Text="AM" Value="AM"></asp:ListItem><asp:ListItem Text="PM" Value="PM"></asp:ListItem></asp:DropDownList></td>
                            </tr>
                            <tr align="left">                                
                                <td>&nbsp;</td>
                                <td><asp:Button ID="btnAltaCobrador" runat="server" CssClass="button_back" Text="Guardar" CausesValidation="True" ValidationGroup="cobradorGroup" OnClick="btnAltaCobrador_Click" /></td>
                            </tr>
                            </table>
                        
                    </asp:Panel>
                </td>
            </tr>
        </table>    
    </asp:panel>
    <br />
    <br />
    <asp:panel id="Panel2" runat="server" align="center">
        <table cellpadding="0" cellspacing="0" class="borderCompleto" 
            style="width:730px; height:88%;">
            <tr>
                <td align="left" class="fondo_Titulo" style="height: 23px" width="100%;">
                    <table width="100%">
                        <tr>
                            <td style="width:100%; height:30px;">Asociar Cobradores - Zona: </td><td valign="top"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlAsociarDatos" runat="server">
                        
                            <table style="width: 482px" border="0">
                            <tr align="left">
                                <td class="labelBold">Cobrador:</td>                                    
                                <td align="left">
                                    <ajaxToolkit:ComboBox ID="cmbCobrador" runat="server" AutoCompleteMode="SuggestAppend"
                                        BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                        DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                        MaxLength="0" Width="60px">
                                    </ajaxToolkit:ComboBox>
                                </td>
                            </tr>
                            <tr align="left">
                                <td class="labelBold">Zona:</td>
                                <td align="left">
                                    <ajaxToolkit:ComboBox ID="cmbZona" runat="server" AutoCompleteMode="SuggestAppend"
                                        BackColor="#FFFFCC" BorderColor="#B9B9B9" BorderStyle="Solid" BorderWidth="1px"
                                        DropDownStyle="DropDownList" Font-Names="Verdana" Font-Size="11px" Height="15px"
                                        MaxLength="0" Width="60px">
                                    </ajaxToolkit:ComboBox>                                
                                </td>
                            </tr>
                            <tr align="left">            
                                <td>&nbsp;</td>
                                <td><asp:Button ID="btnAsociar" runat="server" CssClass="button_back" OnClick="btnAsociar_Click" Text="Asociar" Width="83" /></td>
                            </tr>
                            </table>
                        
                    </asp:Panel>
                </td>
           </tr>
       </table>
    </asp:panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPie" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeader" runat="Server">
</asp:Content>
