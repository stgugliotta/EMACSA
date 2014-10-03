<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="ViewNotAvailable.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

<html>
<head>
<title>
        Aplicación no Disponible

</title>
 <boby>
      <table style="height: 442px; width: 100%">
       <tr>
          <td background="../Images/FotoEmacsa.PNG" align="center" style="background-repeat:no-repeat; background-position:center;">
             
          
              <%--<asp:Image ID="Image4" runat="server" ImageUrl="~/Images/FotoEmacsa.PNG" />--%>
              <asp:label ID="Label1" runat="server"  text="Aplicación no disponible" CssClass="bigLabelAvailable"></asp:label>
              <br />
              <asp:label ID="Label2" runat="server"  CssClass="bigLabelAvailable" text="Temporalmente fuera de servicio. Estamos trabajando para usted."></asp:label>
             
          
          </td>
       </tr>

</table>

 
 </boby>

</head>

</html>
   

