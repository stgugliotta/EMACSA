<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCargaDeFacturas.aspx.cs" Inherits="Vistas_ViewCargaDeFacturas" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="menuJQUERY" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder1" Runat="Server">
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
<table style="height: 442px; width: 100%">
       <tr>
          <td background="../Images/loading.gif" align="center" style="background-repeat:no-repeat; background-position:center;">
             
          
              <%--<asp:Image ID="Image4" runat="server" ImageUrl="~/Images/FotoEmacsa.PNG" />--%>
             
          
          </td>
       </tr>

</table>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPie" Runat="Server">
</asp:Content>

