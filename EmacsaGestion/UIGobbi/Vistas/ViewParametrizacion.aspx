<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"   Theme="SampleSiteTheme"  EnableEventValidation="false" AutoEventWireup="true" CodeFile="ViewParametrizacion.aspx.cs" inherits="Vistas_Parametrizacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 
<%@ Register Assembly="EvaWebControls" Namespace="EvaWebControls" TagPrefix="ma" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"	Namespace="System.Web.UI" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder1" Runat="Server">
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
	    
	    alert('you clicked item "' + $(this).text() + e  + '"');
	    
	    document.location='http://localhost/vistas/ViewImportacionDeFacturas.aspx';
	            

	}};

});
-->
 
</script>	
<link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
     <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />


<table cellpadding="0" border="0" cellspacing="0" style="width:100%;height:332px; left:0;">
                <tr>
                    <td valign="top"  
                    style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666;font-weight: bold;font-size: 12px;background-color: #EDEBEB;border-right: #cccccc 2px solid;border-bottom: #cccccc 1px inset;text-align: left;" 
                    valign="middle"><asp:Label ID="lblAdmCasos" runat="server" >Parametrizaciones</asp:Label></td></tr>
                <tr><td align="left" style="height: 149px" valign="top"><br />

                    <asp:gridview runat="server" AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="id_configuracion" HeaderText="id_configuracion" 
                                SortExpression="id_configuracion" />
                            <asp:BoundField DataField="nombre" HeaderText="nombre" 
                                SortExpression="nombre" />
                            <asp:BoundField DataField="valor" HeaderText="valor" SortExpression="valor" />
                        </Columns>
                    </asp:gridview>
                      
                      

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:Gobbi %>" 
                        SelectCommand="SELECT * FROM [CFG_Application]"></asp:SqlDataSource>
                      <br/>
                    <asp:gridview runat="server" AllowPaging="True" AllowSorting="True" 
                        AutoGenerateColumns="False" DataKeyNames="idFiltro" 
                        DataSourceID="SqlDataSource2">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                                ShowSelectButton="True" />
                            <asp:BoundField DataField="idFiltro" HeaderText="idFiltro" ReadOnly="True" 
                                SortExpression="idFiltro" />
                            <asp:BoundField DataField="filtro" HeaderText="filtro" 
                                SortExpression="filtro" />
                        </Columns>
                    </asp:gridview>

                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConflictDetection="CompareAllValues" 
                        ConnectionString="<%$ ConnectionStrings:Gobbi %>" 
                        DeleteCommand="DELETE FROM [CFG_Filtros_Facturas_Vencidas] WHERE [idFiltro] = @original_idFiltro AND (([filtro] = @original_filtro) OR ([filtro] IS NULL AND @original_filtro IS NULL))" 
                        InsertCommand="INSERT INTO [CFG_Filtros_Facturas_Vencidas] ([idFiltro], [filtro]) VALUES (@idFiltro, @filtro)" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectCommand="SELECT * FROM [CFG_Filtros_Facturas_Vencidas]" 
                        UpdateCommand="UPDATE [CFG_Filtros_Facturas_Vencidas] SET [filtro] = @filtro WHERE [idFiltro] = @original_idFiltro AND (([filtro] = @original_filtro) OR ([filtro] IS NULL AND @original_filtro IS NULL))">
                            <DeleteParameters>
                                <asp:Parameter Name="original_idFiltro" Type="Int32" />
                                <asp:Parameter Name="original_filtro" Type="String" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="filtro" Type="String" />
                                <asp:Parameter Name="original_idFiltro" Type="Int32" />
                                <asp:Parameter Name="original_filtro" Type="String" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="idFiltro" Type="Int32" />
                                <asp:Parameter Name="filtro" Type="String" />
                            </InsertParameters>
                    </asp:SqlDataSource>
                     <br/>
                    <asp:gridview runat="server" AllowPaging="True" AllowSorting="True" 
                        AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource3">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                                ShowSelectButton="True" />
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                                ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="idDeudor" HeaderText="idDeudor" 
                                SortExpression="idDeudor" />
                            <asp:BoundField DataField="idCliente" HeaderText="idCliente" 
                                SortExpression="idCliente" />
                            <asp:BoundField DataField="diasDeAnticipacion" HeaderText="diasDeAnticipacion" 
                                SortExpression="diasDeAnticipacion" />
                            <asp:BoundField DataField="porcentajeAplicacion" 
                                HeaderText="porcentajeAplicacion" SortExpression="porcentajeAplicacion" />
                            <asp:CheckBoxField DataField="activo" HeaderText="activo" 
                                SortExpression="activo" />
                        </Columns>
                    </asp:gridview>
                     
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConflictDetection="CompareAllValues" 
                        ConnectionString="<%$ ConnectionStrings:Gobbi %>" 
                        DeleteCommand="DELETE FROM [CFG_Pronto_Pago] WHERE [id] = @original_id AND [idDeudor] = @original_idDeudor AND [idCliente] = @original_idCliente AND (([diasDeAnticipacion] = @original_diasDeAnticipacion) OR ([diasDeAnticipacion] IS NULL AND @original_diasDeAnticipacion IS NULL)) AND (([porcentajeAplicacion] = @original_porcentajeAplicacion) OR ([porcentajeAplicacion] IS NULL AND @original_porcentajeAplicacion IS NULL)) AND (([activo] = @original_activo) OR ([activo] IS NULL AND @original_activo IS NULL))" 
                        InsertCommand="INSERT INTO [CFG_Pronto_Pago] ([idDeudor], [idCliente], [diasDeAnticipacion], [porcentajeAplicacion], [activo]) VALUES (@idDeudor, @idCliente, @diasDeAnticipacion, @porcentajeAplicacion, @activo)" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectCommand="SELECT * FROM [CFG_Pronto_Pago]" 
                        UpdateCommand="UPDATE [CFG_Pronto_Pago] SET [idDeudor] = @idDeudor, [idCliente] = @idCliente, [diasDeAnticipacion] = @diasDeAnticipacion, [porcentajeAplicacion] = @porcentajeAplicacion, [activo] = @activo WHERE [id] = @original_id AND [idDeudor] = @original_idDeudor AND [idCliente] = @original_idCliente AND (([diasDeAnticipacion] = @original_diasDeAnticipacion) OR ([diasDeAnticipacion] IS NULL AND @original_diasDeAnticipacion IS NULL)) AND (([porcentajeAplicacion] = @original_porcentajeAplicacion) OR ([porcentajeAplicacion] IS NULL AND @original_porcentajeAplicacion IS NULL)) AND (([activo] = @original_activo) OR ([activo] IS NULL AND @original_activo IS NULL))">
                            <DeleteParameters>
                                <asp:Parameter Name="original_id" Type="Int32" />
                                <asp:Parameter Name="original_idDeudor" Type="Int32" />
                                <asp:Parameter Name="original_idCliente" Type="Int32" />
                                <asp:Parameter Name="original_diasDeAnticipacion" Type="Int32" />
                                <asp:Parameter Name="original_porcentajeAplicacion" Type="Double" />
                                <asp:Parameter Name="original_activo" Type="Boolean" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="idDeudor" Type="Int32" />
                                <asp:Parameter Name="idCliente" Type="Int32" />
                                <asp:Parameter Name="diasDeAnticipacion" Type="Int32" />
                                <asp:Parameter Name="porcentajeAplicacion" Type="Double" />
                                <asp:Parameter Name="activo" Type="Boolean" />
                                <asp:Parameter Name="original_id" Type="Int32" />
                                <asp:Parameter Name="original_idDeudor" Type="Int32" />
                                <asp:Parameter Name="original_idCliente" Type="Int32" />
                                <asp:Parameter Name="original_diasDeAnticipacion" Type="Int32" />
                                <asp:Parameter Name="original_porcentajeAplicacion" Type="Double" />
                                <asp:Parameter Name="original_activo" Type="Boolean" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="idDeudor" Type="Int32" />
                                <asp:Parameter Name="idCliente" Type="Int32" />
                                <asp:Parameter Name="diasDeAnticipacion" Type="Int32" />
                                <asp:Parameter Name="porcentajeAplicacion" Type="Double" />
                                <asp:Parameter Name="activo" Type="Boolean" />
                            </InsertParameters>
                    </asp:SqlDataSource>
                     <br/>
                    <asp:gridview runat="server" AllowPaging="True" AllowSorting="True" 
                        AutoGenerateColumns="False" DataKeyNames="GroupID,PermissionID" 
                        DataSourceID="SqlDataSource4">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                                ShowSelectButton="True" />
                            <asp:BoundField DataField="GroupID" HeaderText="GroupID" ReadOnly="True" 
                                SortExpression="GroupID" />
                            <asp:BoundField DataField="PermissionID" HeaderText="PermissionID" 
                                ReadOnly="True" SortExpression="PermissionID" />
                            <asp:BoundField DataField="dvh" HeaderText="dvh" SortExpression="dvh" />
                        </Columns>
                    </asp:gridview>
                     
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                        ConflictDetection="CompareAllValues" 
                        ConnectionString="<%$ ConnectionStrings:Gobbi %>" 
                        DeleteCommand="DELETE FROM [GROUP_PERMISSION] WHERE [GroupID] = @original_GroupID AND [PermissionID] = @original_PermissionID AND (([dvh] = @original_dvh) OR ([dvh] IS NULL AND @original_dvh IS NULL))" 
                        InsertCommand="INSERT INTO [GROUP_PERMISSION] ([GroupID], [PermissionID], [dvh]) VALUES (@GroupID, @PermissionID, @dvh)" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectCommand="SELECT * FROM [GROUP_PERMISSION]" 
                        UpdateCommand="UPDATE [GROUP_PERMISSION] SET [dvh] = @dvh WHERE [GroupID] = @original_GroupID AND [PermissionID] = @original_PermissionID AND (([dvh] = @original_dvh) OR ([dvh] IS NULL AND @original_dvh IS NULL))">
                            <DeleteParameters>
                                <asp:Parameter Name="original_GroupID" Type="Int32" />
                                <asp:Parameter Name="original_PermissionID" Type="Int32" />
                                <asp:Parameter Name="original_dvh" Type="Int32" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="dvh" Type="Int32" />
                                <asp:Parameter Name="original_GroupID" Type="Int32" />
                                <asp:Parameter Name="original_PermissionID" Type="Int32" />
                                <asp:Parameter Name="original_dvh" Type="Int32" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="GroupID" Type="Int32" />
                                <asp:Parameter Name="PermissionID" Type="Int32" />
                                <asp:Parameter Name="dvh" Type="Int32" />
                            </InsertParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="GroupId" 
                        DataSourceID="SqlDataSource5">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                                ShowSelectButton="True" />
                            <asp:BoundField DataField="GroupId" HeaderText="GroupId" InsertVisible="False" 
                                ReadOnly="True" SortExpression="GroupId" />
                            <asp:BoundField DataField="Description" HeaderText="Description" 
                                SortExpression="Description" />
                            <asp:BoundField DataField="dvh" HeaderText="dvh" SortExpression="dvh" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                        ConflictDetection="CompareAllValues" 
                        ConnectionString="<%$ ConnectionStrings:Gobbi %>" 
                        DeleteCommand="DELETE FROM [GROUPS] WHERE [GroupId] = @original_GroupId AND (([Description] = @original_Description) OR ([Description] IS NULL AND @original_Description IS NULL)) AND (([dvh] = @original_dvh) OR ([dvh] IS NULL AND @original_dvh IS NULL))" 
                        InsertCommand="INSERT INTO [GROUPS] ([Description], [dvh]) VALUES (@Description, @dvh)" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectCommand="SELECT * FROM [GROUPS]" 
                        UpdateCommand="UPDATE [GROUPS] SET [Description] = @Description, [dvh] = @dvh WHERE [GroupId] = @original_GroupId AND (([Description] = @original_Description) OR ([Description] IS NULL AND @original_Description IS NULL)) AND (([dvh] = @original_dvh) OR ([dvh] IS NULL AND @original_dvh IS NULL))">
                        <DeleteParameters>
                            <asp:Parameter Name="original_GroupId" Type="Int32" />
                            <asp:Parameter Name="original_Description" Type="String" />
                            <asp:Parameter Name="original_dvh" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="dvh" Type="Int32" />
                            <asp:Parameter Name="original_GroupId" Type="Int32" />
                            <asp:Parameter Name="original_Description" Type="String" />
                            <asp:Parameter Name="original_dvh" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="dvh" Type="Int32" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PermissionID" 
                        DataSourceID="SqlDataSource6">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                                ShowSelectButton="True" />
                            <asp:BoundField DataField="PermissionID" HeaderText="PermissionID" 
                                InsertVisible="False" ReadOnly="True" SortExpression="PermissionID" />
                            <asp:BoundField DataField="path" HeaderText="path" SortExpression="path" />
                            <asp:BoundField DataField="dvh" HeaderText="dvh" SortExpression="dvh" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                        ConflictDetection="CompareAllValues" 
                        ConnectionString="<%$ ConnectionStrings:Gobbi %>" 
                        DeleteCommand="DELETE FROM [PERMISSION] WHERE [PermissionID] = @original_PermissionID AND [path] = @original_path AND (([dvh] = @original_dvh) OR ([dvh] IS NULL AND @original_dvh IS NULL))" 
                        InsertCommand="INSERT INTO [PERMISSION] ([path], [dvh]) VALUES (@path, @dvh)" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectCommand="SELECT * FROM [PERMISSION]" 
                        UpdateCommand="UPDATE [PERMISSION] SET [path] = @path, [dvh] = @dvh WHERE [PermissionID] = @original_PermissionID AND [path] = @original_path AND (([dvh] = @original_dvh) OR ([dvh] IS NULL AND @original_dvh IS NULL))">
                        <DeleteParameters>
                            <asp:Parameter Name="original_PermissionID" Type="Int32" />
                            <asp:Parameter Name="original_path" Type="String" />
                            <asp:Parameter Name="original_dvh" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="path" Type="String" />
                            <asp:Parameter Name="dvh" Type="Int32" />
                            <asp:Parameter Name="original_PermissionID" Type="Int32" />
                            <asp:Parameter Name="original_path" Type="String" />
                            <asp:Parameter Name="original_dvh" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="path" Type="String" />
                            <asp:Parameter Name="dvh" Type="Int32" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="Id_Cliente" DataSourceID="SqlDataSource7">
                        <Columns>
                            <asp:BoundField DataField="Id_Cliente" HeaderText="Id_Cliente" ReadOnly="True" 
                                SortExpression="Id_Cliente" />
                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" 
                                SortExpression="NOMBRE" />
                            <asp:BoundField DataField="CUIT" HeaderText="CUIT" SortExpression="CUIT" />
                            <asp:BoundField DataField="CALLE" HeaderText="CALLE" SortExpression="CALLE" />
                            <asp:BoundField DataField="ALTURA" HeaderText="ALTURA" 
                                SortExpression="ALTURA" />
                            <asp:BoundField DataField="DEPARTAMENTO" HeaderText="DEPARTAMENTO" 
                                SortExpression="DEPARTAMENTO" />
                            <asp:BoundField DataField="LOCALIDAD" HeaderText="LOCALIDAD" 
                                SortExpression="LOCALIDAD" />
                            <asp:BoundField DataField="CP" HeaderText="CP" SortExpression="CP" />
                            <asp:BoundField DataField="PROVINCIA" HeaderText="PROVINCIA" 
                                SortExpression="PROVINCIA" />
                            <asp:BoundField DataField="TELEFONOS" HeaderText="TELEFONOS" 
                                SortExpression="TELEFONOS" />
                            <asp:BoundField DataField="FAX" HeaderText="FAX" SortExpression="FAX" />
                            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" />
                            <asp:BoundField DataField="NOMBRECORTO" HeaderText="NOMBRECORTO" 
                                SortExpression="NOMBRECORTO" />
                            <asp:BoundField DataField="MONEDA_CREDITO" HeaderText="MONEDA_CREDITO" 
                                SortExpression="MONEDA_CREDITO" />
                            <asp:BoundField DataField="OBSERVACIONES" HeaderText="OBSERVACIONES" 
                                SortExpression="OBSERVACIONES" />
                            <asp:BoundField DataField="SOLOGESTION" HeaderText="SOLOGESTION" 
                                SortExpression="SOLOGESTION" />
                            <asp:BoundField DataField="ACTIVO" HeaderText="ACTIVO" 
                                SortExpression="ACTIVO" />
                            <asp:BoundField DataField="GRU_REC" HeaderText="GRU_REC" 
                                SortExpression="GRU_REC" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
                        ConflictDetection="CompareAllValues" 
                        ConnectionString="<%$ ConnectionStrings:Gobbi %>" 
                        DeleteCommand="DELETE FROM [MTR_Cliente] WHERE [Id_Cliente] = @original_Id_Cliente AND (([NOMBRE] = @original_NOMBRE) OR ([NOMBRE] IS NULL AND @original_NOMBRE IS NULL)) AND (([CUIT] = @original_CUIT) OR ([CUIT] IS NULL AND @original_CUIT IS NULL)) AND (([CALLE] = @original_CALLE) OR ([CALLE] IS NULL AND @original_CALLE IS NULL)) AND (([ALTURA] = @original_ALTURA) OR ([ALTURA] IS NULL AND @original_ALTURA IS NULL)) AND (([DEPARTAMENTO] = @original_DEPARTAMENTO) OR ([DEPARTAMENTO] IS NULL AND @original_DEPARTAMENTO IS NULL)) AND (([LOCALIDAD] = @original_LOCALIDAD) OR ([LOCALIDAD] IS NULL AND @original_LOCALIDAD IS NULL)) AND (([CP] = @original_CP) OR ([CP] IS NULL AND @original_CP IS NULL)) AND (([PROVINCIA] = @original_PROVINCIA) OR ([PROVINCIA] IS NULL AND @original_PROVINCIA IS NULL)) AND (([TELEFONOS] = @original_TELEFONOS) OR ([TELEFONOS] IS NULL AND @original_TELEFONOS IS NULL)) AND (([FAX] = @original_FAX) OR ([FAX] IS NULL AND @original_FAX IS NULL)) AND (([EMAIL] = @original_EMAIL) OR ([EMAIL] IS NULL AND @original_EMAIL IS NULL)) AND (([NOMBRECORTO] = @original_NOMBRECORTO) OR ([NOMBRECORTO] IS NULL AND @original_NOMBRECORTO IS NULL)) AND (([MONEDA_CREDITO] = @original_MONEDA_CREDITO) OR ([MONEDA_CREDITO] IS NULL AND @original_MONEDA_CREDITO IS NULL)) AND (([OBSERVACIONES] = @original_OBSERVACIONES) OR ([OBSERVACIONES] IS NULL AND @original_OBSERVACIONES IS NULL)) AND (([SOLOGESTION] = @original_SOLOGESTION) OR ([SOLOGESTION] IS NULL AND @original_SOLOGESTION IS NULL)) AND (([ACTIVO] = @original_ACTIVO) OR ([ACTIVO] IS NULL AND @original_ACTIVO IS NULL)) AND (([GRU_REC] = @original_GRU_REC) OR ([GRU_REC] IS NULL AND @original_GRU_REC IS NULL))" 
                        InsertCommand="INSERT INTO [MTR_Cliente] ([Id_Cliente], [NOMBRE], [CUIT], [CALLE], [ALTURA], [DEPARTAMENTO], [LOCALIDAD], [CP], [PROVINCIA], [TELEFONOS], [FAX], [EMAIL], [NOMBRECORTO], [MONEDA_CREDITO], [OBSERVACIONES], [SOLOGESTION], [ACTIVO], [GRU_REC]) VALUES (@Id_Cliente, @NOMBRE, @CUIT, @CALLE, @ALTURA, @DEPARTAMENTO, @LOCALIDAD, @CP, @PROVINCIA, @TELEFONOS, @FAX, @EMAIL, @NOMBRECORTO, @MONEDA_CREDITO, @OBSERVACIONES, @SOLOGESTION, @ACTIVO, @GRU_REC)" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectCommand="SELECT * FROM [MTR_Cliente]" 
                        UpdateCommand="UPDATE [MTR_Cliente] SET [NOMBRE] = @NOMBRE, [CUIT] = @CUIT, [CALLE] = @CALLE, [ALTURA] = @ALTURA, [DEPARTAMENTO] = @DEPARTAMENTO, [LOCALIDAD] = @LOCALIDAD, [CP] = @CP, [PROVINCIA] = @PROVINCIA, [TELEFONOS] = @TELEFONOS, [FAX] = @FAX, [EMAIL] = @EMAIL, [NOMBRECORTO] = @NOMBRECORTO, [MONEDA_CREDITO] = @MONEDA_CREDITO, [OBSERVACIONES] = @OBSERVACIONES, [SOLOGESTION] = @SOLOGESTION, [ACTIVO] = @ACTIVO, [GRU_REC] = @GRU_REC WHERE [Id_Cliente] = @original_Id_Cliente AND (([NOMBRE] = @original_NOMBRE) OR ([NOMBRE] IS NULL AND @original_NOMBRE IS NULL)) AND (([CUIT] = @original_CUIT) OR ([CUIT] IS NULL AND @original_CUIT IS NULL)) AND (([CALLE] = @original_CALLE) OR ([CALLE] IS NULL AND @original_CALLE IS NULL)) AND (([ALTURA] = @original_ALTURA) OR ([ALTURA] IS NULL AND @original_ALTURA IS NULL)) AND (([DEPARTAMENTO] = @original_DEPARTAMENTO) OR ([DEPARTAMENTO] IS NULL AND @original_DEPARTAMENTO IS NULL)) AND (([LOCALIDAD] = @original_LOCALIDAD) OR ([LOCALIDAD] IS NULL AND @original_LOCALIDAD IS NULL)) AND (([CP] = @original_CP) OR ([CP] IS NULL AND @original_CP IS NULL)) AND (([PROVINCIA] = @original_PROVINCIA) OR ([PROVINCIA] IS NULL AND @original_PROVINCIA IS NULL)) AND (([TELEFONOS] = @original_TELEFONOS) OR ([TELEFONOS] IS NULL AND @original_TELEFONOS IS NULL)) AND (([FAX] = @original_FAX) OR ([FAX] IS NULL AND @original_FAX IS NULL)) AND (([EMAIL] = @original_EMAIL) OR ([EMAIL] IS NULL AND @original_EMAIL IS NULL)) AND (([NOMBRECORTO] = @original_NOMBRECORTO) OR ([NOMBRECORTO] IS NULL AND @original_NOMBRECORTO IS NULL)) AND (([MONEDA_CREDITO] = @original_MONEDA_CREDITO) OR ([MONEDA_CREDITO] IS NULL AND @original_MONEDA_CREDITO IS NULL)) AND (([OBSERVACIONES] = @original_OBSERVACIONES) OR ([OBSERVACIONES] IS NULL AND @original_OBSERVACIONES IS NULL)) AND (([SOLOGESTION] = @original_SOLOGESTION) OR ([SOLOGESTION] IS NULL AND @original_SOLOGESTION IS NULL)) AND (([ACTIVO] = @original_ACTIVO) OR ([ACTIVO] IS NULL AND @original_ACTIVO IS NULL)) AND (([GRU_REC] = @original_GRU_REC) OR ([GRU_REC] IS NULL AND @original_GRU_REC IS NULL))">
                        <DeleteParameters>
                            <asp:Parameter Name="original_Id_Cliente" Type="Decimal" />
                            <asp:Parameter Name="original_NOMBRE" Type="String" />
                            <asp:Parameter Name="original_CUIT" Type="String" />
                            <asp:Parameter Name="original_CALLE" Type="String" />
                            <asp:Parameter Name="original_ALTURA" Type="Double" />
                            <asp:Parameter Name="original_DEPARTAMENTO" Type="String" />
                            <asp:Parameter Name="original_LOCALIDAD" Type="String" />
                            <asp:Parameter Name="original_CP" Type="Double" />
                            <asp:Parameter Name="original_PROVINCIA" Type="String" />
                            <asp:Parameter Name="original_TELEFONOS" Type="String" />
                            <asp:Parameter Name="original_FAX" Type="String" />
                            <asp:Parameter Name="original_EMAIL" Type="String" />
                            <asp:Parameter Name="original_NOMBRECORTO" Type="String" />
                            <asp:Parameter Name="original_MONEDA_CREDITO" Type="String" />
                            <asp:Parameter Name="original_OBSERVACIONES" Type="String" />
                            <asp:Parameter Name="original_SOLOGESTION" Type="String" />
                            <asp:Parameter Name="original_ACTIVO" Type="String" />
                            <asp:Parameter Name="original_GRU_REC" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="NOMBRE" Type="String" />
                            <asp:Parameter Name="CUIT" Type="String" />
                            <asp:Parameter Name="CALLE" Type="String" />
                            <asp:Parameter Name="ALTURA" Type="Double" />
                            <asp:Parameter Name="DEPARTAMENTO" Type="String" />
                            <asp:Parameter Name="LOCALIDAD" Type="String" />
                            <asp:Parameter Name="CP" Type="Double" />
                            <asp:Parameter Name="PROVINCIA" Type="String" />
                            <asp:Parameter Name="TELEFONOS" Type="String" />
                            <asp:Parameter Name="FAX" Type="String" />
                            <asp:Parameter Name="EMAIL" Type="String" />
                            <asp:Parameter Name="NOMBRECORTO" Type="String" />
                            <asp:Parameter Name="MONEDA_CREDITO" Type="String" />
                            <asp:Parameter Name="OBSERVACIONES" Type="String" />
                            <asp:Parameter Name="SOLOGESTION" Type="String" />
                            <asp:Parameter Name="ACTIVO" Type="String" />
                            <asp:Parameter Name="GRU_REC" Type="String" />
                            <asp:Parameter Name="original_Id_Cliente" Type="Decimal" />
                            <asp:Parameter Name="original_NOMBRE" Type="String" />
                            <asp:Parameter Name="original_CUIT" Type="String" />
                            <asp:Parameter Name="original_CALLE" Type="String" />
                            <asp:Parameter Name="original_ALTURA" Type="Double" />
                            <asp:Parameter Name="original_DEPARTAMENTO" Type="String" />
                            <asp:Parameter Name="original_LOCALIDAD" Type="String" />
                            <asp:Parameter Name="original_CP" Type="Double" />
                            <asp:Parameter Name="original_PROVINCIA" Type="String" />
                            <asp:Parameter Name="original_TELEFONOS" Type="String" />
                            <asp:Parameter Name="original_FAX" Type="String" />
                            <asp:Parameter Name="original_EMAIL" Type="String" />
                            <asp:Parameter Name="original_NOMBRECORTO" Type="String" />
                            <asp:Parameter Name="original_MONEDA_CREDITO" Type="String" />
                            <asp:Parameter Name="original_OBSERVACIONES" Type="String" />
                            <asp:Parameter Name="original_SOLOGESTION" Type="String" />
                            <asp:Parameter Name="original_ACTIVO" Type="String" />
                            <asp:Parameter Name="original_GRU_REC" Type="String" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Id_Cliente" Type="Decimal" />
                            <asp:Parameter Name="NOMBRE" Type="String" />
                            <asp:Parameter Name="CUIT" Type="String" />
                            <asp:Parameter Name="CALLE" Type="String" />
                            <asp:Parameter Name="ALTURA" Type="Double" />
                            <asp:Parameter Name="DEPARTAMENTO" Type="String" />
                            <asp:Parameter Name="LOCALIDAD" Type="String" />
                            <asp:Parameter Name="CP" Type="Double" />
                            <asp:Parameter Name="PROVINCIA" Type="String" />
                            <asp:Parameter Name="TELEFONOS" Type="String" />
                            <asp:Parameter Name="FAX" Type="String" />
                            <asp:Parameter Name="EMAIL" Type="String" />
                            <asp:Parameter Name="NOMBRECORTO" Type="String" />
                            <asp:Parameter Name="MONEDA_CREDITO" Type="String" />
                            <asp:Parameter Name="OBSERVACIONES" Type="String" />
                            <asp:Parameter Name="SOLOGESTION" Type="String" />
                            <asp:Parameter Name="ACTIVO" Type="String" />
                            <asp:Parameter Name="GRU_REC" Type="String" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:GridView ID="GridView4" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" 
                        
                        DataSourceID="SqlDataSource8">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                                ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="numRemision" HeaderText="numRemision" 
                                SortExpression="numRemision" />
                            <asp:BoundField DataField="fechaInicioLock" HeaderText="fechaInicioLock" 
                                SortExpression="fechaInicioLock" />
                            <asp:BoundField DataField="usuarioLock" HeaderText="usuarioLock" 
                                SortExpression="usuarioLock" />
                            <asp:BoundField DataField="estadoLock" HeaderText="estadoLock" 
                                SortExpression="estadoLock" />
                            <asp:CheckBoxField DataField="forceUnlock" HeaderText="forceUnlock" 
                                SortExpression="forceUnlock" />
                            <asp:BoundField DataField="usuarioForceUnlock" HeaderText="usuarioForceUnlock" 
                                SortExpression="usuarioForceUnlock" />
                            <asp:BoundField DataField="fechaForceUnlock" HeaderText="fechaForceUnlock" 
                                SortExpression="fechaForceUnlock" />
                            <asp:BoundField DataField="datoBloqueado" HeaderText="datoBloqueado" 
                                SortExpression="datoBloqueado" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:Gobbi %>" 
                        SelectCommand="SELECT * FROM [TBL_Control_Concurrencia_Remision]"
                        DeleteCommand="DELETE FROM [TBL_Control_Concurrencia_Remision] WHERE [id] = @id">
                        <DeleteParameters>
                            <asp:Parameter Name="id" Type="Int32" />
                        </DeleteParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:GridView ID="GridView5" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="UserID" 
                        DataSourceID="SqlDataSource9">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                                ShowSelectButton="True" />
                            <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" 
                                ReadOnly="True" SortExpression="UserID" />
                            <asp:BoundField DataField="UserName" HeaderText="UserName" 
                                SortExpression="UserName" />
                            <asp:BoundField DataField="password" HeaderText="password" 
                                SortExpression="password" />
                            <asp:BoundField DataField="dvh" HeaderText="dvh" SortExpression="dvh" />
                            <asp:BoundField DataField="GroupId" HeaderText="GroupId" 
                                SortExpression="GroupId" />
                            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                            <asp:BoundField DataField="passwordMail" HeaderText="passwordMail" 
                                SortExpression="passwordMail" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource9" runat="server" 
                        ConflictDetection="CompareAllValues" 
                        ConnectionString="<%$ ConnectionStrings:Gobbi %>" 
                        DeleteCommand="DELETE FROM [USERS] WHERE [UserID] = @original_UserID AND [UserName] = @original_UserName AND (([password] = @original_password) OR ([password] IS NULL AND @original_password IS NULL)) AND (([dvh] = @original_dvh) OR ([dvh] IS NULL AND @original_dvh IS NULL)) AND (([GroupId] = @original_GroupId) OR ([GroupId] IS NULL AND @original_GroupId IS NULL))" 
                        InsertCommand="INSERT INTO [USERS] ([UserName], [password], [dvh], [GroupId]) VALUES (@UserName, @password, @dvh, @GroupId)" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectCommand="SELECT * FROM [USERS]" 
                        UpdateCommand="UPDATE [MTR_Analista]
SET nombre=@UserName
WHERE nombre=@original_UserName

UPDATE [USERS] SET [UserName] = @UserName, [password] = @password, [dvh] = @dvh, [GroupId] = @GroupId WHERE [UserID] = @original_UserID AND [UserName] = @original_UserName AND (([password] = @original_password) OR ([password] IS NULL AND @original_password IS NULL)) AND (([dvh] = @original_dvh) OR ([dvh] IS NULL AND @original_dvh IS NULL)) AND (([GroupId] = @original_GroupId) OR ([GroupId] IS NULL AND @original_GroupId IS NULL))

">
                        <DeleteParameters>
                            <asp:Parameter Name="original_UserID" Type="Int64" />
                            <asp:Parameter Name="original_UserName" Type="String" />
                            <asp:Parameter Name="original_password" Type="String" />
                            <asp:Parameter Name="original_dvh" Type="Int32" />
                            <asp:Parameter Name="original_GroupId" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="UserName" Type="String" />
                            <asp:Parameter Name="original_UserName" Type="String" />
                            <asp:Parameter Name="password" Type="String" />
                            <asp:Parameter Name="dvh" Type="Int32" />
                            <asp:Parameter Name="GroupId" Type="Int32" />
                            <asp:Parameter Name="original_UserID" Type="Int64" />
                            <asp:Parameter Name="original_password" Type="String" />
                            <asp:Parameter Name="original_dvh" Type="Int32" />
                            <asp:Parameter Name="original_GroupId" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="UserName" Type="String" />
                            <asp:Parameter Name="password" Type="String" />
                            <asp:Parameter Name="dvh" Type="Int32" />
                            <asp:Parameter Name="GroupId" Type="Int32" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                     
                        <br />
                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="idAlerta" DataSourceID="SqlDataSource10">
                        <Columns>
                            <asp:CommandField ShowEditButton="True" />
                            <asp:BoundField DataField="idAlerta" HeaderText="idAlerta" ReadOnly="True" 
                                SortExpression="idAlerta" />
                            <asp:BoundField DataField="alerta" HeaderText="alerta" 
                                SortExpression="alerta" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource10" runat="server" 
                        ConflictDetection="CompareAllValues" 
                        ConnectionString="<%$ ConnectionStrings:Gobbi %>" 
                        DeleteCommand="DELETE FROM [MTR_Alerta] WHERE [idAlerta] = @original_idAlerta AND (([alerta] = @original_alerta) OR ([alerta] IS NULL AND @original_alerta IS NULL))" 
                        InsertCommand="INSERT INTO [MTR_Alerta] ([idAlerta], [alerta]) VALUES (@idAlerta, @alerta)" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectCommand="SELECT [idAlerta], [alerta] FROM [MTR_Alerta]" 
                        UpdateCommand="UPDATE [MTR_Alerta] SET [alerta] = @alerta WHERE [idAlerta] = @original_idAlerta AND (([alerta] = @original_alerta) OR ([alerta] IS NULL AND @original_alerta IS NULL))">
                        <DeleteParameters>
                            <asp:Parameter Name="original_idAlerta" Type="Int32" />
                            <asp:Parameter Name="original_alerta" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="alerta" Type="String" />
                            <asp:Parameter Name="original_idAlerta" Type="Int32" />
                            <asp:Parameter Name="original_alerta" Type="String" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="idAlerta" Type="Int32" />
                            <asp:Parameter Name="alerta" Type="String" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                     <br />
                     
                     <asp:GridView ID="GridViewCambio" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="idCambio" DataSourceID="SqlDataSource11" >
                         <Columns>
                             <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                                 ShowSelectButton="True" />
                             <asp:BoundField DataField="idCambio" HeaderText="idCambio" 
                                 InsertVisible="False" ReadOnly="True" SortExpression="idCambio" />
                             <asp:BoundField DataField="nombre" HeaderText="nombre" 
                                 SortExpression="nombre" />
                             <asp:BoundField DataField="cambio" HeaderText="cambio" 
                                 SortExpression="cambio" />
                             <asp:BoundField DataField="fechaVigencia" HeaderText="fechaVigencia" 
                                 SortExpression="fechaVigencia" />
                             <asp:BoundField DataField="idMoneda" HeaderText="idMoneda" 
                                 SortExpression="idMoneda" />
                         </Columns>
                    </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource11" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:Gobbi %>" 
                        DeleteCommand="PA_MG_FRONT_Cambio_Delete" DeleteCommandType="StoredProcedure" 
                        InsertCommand="PA_MG_FRONT_Cambio_Insert" InsertCommandType="StoredProcedure" 
                        SelectCommand="PA_MG_FRONT_Cambio_SelectALL" 
                        SelectCommandType="StoredProcedure" UpdateCommand="PA_MG_FRONT_Cambio_Update" 
                        UpdateCommandType="StoredProcedure">
                            <DeleteParameters>
                                <asp:Parameter Name="idCambio" Type="Int32" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="idCambio" Type="Int32" />
                                <asp:Parameter Name="nombre" Type="String" />
                                <asp:Parameter Name="cambio" Type="Decimal" />
                                <asp:Parameter DbType="Date" Name="fechaVigencia" />
                                <asp:Parameter Name="idMoneda" Type="Int32" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="idCambio" Type="Int32" />
                                <asp:Parameter Name="nombre" Type="String" />
                                <asp:Parameter Name="cambio" Type="Decimal" />
                                <asp:Parameter DbType="Date" Name="fechaVigencia" />
                                <asp:Parameter Name="idMoneda" Type="Int32" />
                            </InsertParameters>
                    </asp:SqlDataSource>
                        </td>
                        </tr>
                        </table>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" Runat="Server">

    <br />
	

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" Runat="Server">

                    
		     
</asp:Content>