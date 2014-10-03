<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"   Theme="SampleSiteTheme"  EnableEventValidation="false" AutoEventWireup="true" CodeFile="ViewAyudaMotivoRechazo.aspx.cs" Inherits="Vistas_ViewAyudaMotivoRechazo" %>
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
	    
	    
	    
	    document.location='http://localhost/vistas/ViewImportacionDeFacturas.aspx';
	            
	    
	    
	    //);
		//alert('you clicked item "' + $(this).text() + e  + '"');
	}};

});
-->
 
</script>	


    <link href="../Css/cssUpdateProgress.css" rel="stylesheet" type="text/css" />
    	 	 
  


<script type="text/javascript" language="javascript">
	            var ModalProgress = '<%= ModalProgress.ClientID %>';   
                	
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
                
                

function beginReq(sender, args) 
{
	// shows the Popup 
	var controlCaller=args.get_postBackElement().id;
   
    $find(ModalProgress).show();
        	 
}





function endReq(sender, args)
{
	                        //  shows the Popup 
	                        $find(ModalProgress).hide();
} 


	</script>
<link href="../Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet" />
 <link href="../Css/GobbiStyle.css" type="text/css" rel="stylesheet" />

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
		    
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>--%>

	
		<ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
			BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
			
	
<table align="center" style="height: 1000px">
<tr style="height:200px;">
    <td valign="top">
        <table style="width:1000px; height:88%;"  class="borderCompleto" cellpadding="0" cellspacing="0" >
         <tr >
         <td valign="top">
             <table width="100%" cellpadding="0" cellspacing="0" style="height: 172px" >
                 <tr align="left"  style="height:20px;" >
                     <td valign="top" style="width: 900px; margin-left: 80px;">

                         <asp:Panel ID="panelCliente" runat="server" Width="1000px">
            
                                  <table cellpadding="0" cellspacing="0" class="borderCompleto" 
                                                 style="width:900px; height:88%;">
                                                 <tr>
                                                     <td align="left" class="fondo_Titulo" style="height: 23px" width="100%;">
                                                          <table width="100%" >
                                                          <tr>
                                                          <td class="style5">Últimas importaciones</td>
                                                                 <td valign="top">
                                                                     <asp:ImageButton ID="ImageButton3" runat="server" 
                                                                         ImageUrl="~/Images/excel_small.gif"  OnClick="Exportar_Click"/>
                                                          </td>
                                                          </tr>
                                                          </table>
                                                     </td>
                                                 </tr>
                                  </table>
                                         
                          </asp:Panel>
                      </td>
                  </tr>
         <tr align="left" >
             <td align="left" style="width:100%;" >
                 <asp:Button runat="server" Text="Volver" CssClass="button_back" 
                     ID="btnVolver" Height="24px" Width="176px" Visible="true" onclick="btnVolver_Click" 
                     ></asp:Button>
                 <br />
             </td>
                 <!--td align="right" >
                     &nbsp;</td-->
             </tr>
             </table>
         </td>
         </tr>
         <tr align="left" >
             <td align="left" style="width:192px; border-width:0px" 
             valign="top" >
             &nbsp;</td>
         </tr>
         <tr align="left" >
             <td align="left" style="width:100%;" >
                 <br />
             </td>
             <td align="left" style="width:100%;" >
                 <br />
             </td>
         </tr>
         <tr>
            <td align="left" class="smallTitle" colspan="2" valign="top" style="width:800px; border-width:0px" >
            <asp:Panel ID="resultados" CssClass="smallTitle" runat ="server"> 
            </asp:Panel>
            </td>
         </tr>
         
         </table>
    </td>
</tr>
<tr >
         <td >

         </td>
                         
</tr>                      
</table>

<%--    </form>
</body>--%>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPie" Runat="Server">
	     
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentHeader">
     
</asp:Content>

<asp:Content ID="Content5" runat="server" contentplaceholderid="menuJQUERY">
    <style type="text/css">
        .style5
        {
            height: 30px;
            width: 942px;
        }
        .style6
        {
            width: 192px;
            height: 27px;
        }
    </style>
</asp:Content>

