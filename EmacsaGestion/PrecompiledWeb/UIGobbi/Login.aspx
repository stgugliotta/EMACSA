<%@ page language="C#" autoeventwireup="true" inherits="_Login, App_Web_ndx1vod5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Gobbi</title>
    <link href="Css/GobbiMagicStyle.css" type="text/css" rel="stylesheet"/>
    <link href="Css/GobbiStyle.css" type="text/css" rel="stylesheet"/>
    
    <script type="text/javascript">
        <!--
            /*
             * Función JavaScript que valida que los datos del formulario esten ingresados
             * correctamente.
             *
             */
            function checkFormData(){
                bResult = false;
                
                if (window.document.getElementById('txtUsuario').value.length != 0 && window.document.getElementById('txtClave').value.length != 0){
                    bResult = true
                } else {
                    alert('No se han completado correctamente los datos en el formulario.\nPor favor verifique e intente nuevamente el ingreso.');
                }
                
                return bResult;
            }
        -->
    </script>
    <style type="text/css">
        #tblLogin
        {
            height: 142px;
            width: 444px;
        }
        .style1
        {
            width: 162px;
        }
    </style>
</head>
<body onload="javascript: window.document.getElementById('txtUsuario').focus();">
    <form id="form1" runat="server">
    <div>
         <table id="tblCentrado" cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td align="center" style="height: 359px">
					<table id="tblLogin" cellspacing="0" cellpadding="0" bgcolor="#FBFBFB" 
                        border="0">
                        
                        <tr>
                         <td colspan="11" align="center" style="background-color:White;">
                         <br />
                         <br />
                         
                             <asp:Image ID="Image1" runat="server"  ImageUrl="~/Images/LogoEmacsa.png"/>
                             <br />
                             <br />
                             
                             
                         </td>
                        
                        </tr>
						<tr>
						
							<td style="height: 22px"><img height="22" alt="" src="Images/TablasUpLeft.gif" width="1" border="0"/></td>
							<td style="background-image:url('Images/TablasUp3.gif'); height: 22px;" 
                                colspan="6">
							    <span class="whiteTitle">Inicio de Sesión a Emacsa</span></td>
							<td style="height: 22px"><img height="22" alt="" src="Images/TablasUpRight.gif" width="1" border="0"/></td>
							<td style="height: 22px">&nbsp;</td>
						</tr>
						<tr>
							<td bgcolor="#397dde" rowspan="10"><img height="1" alt="" src="Images/Spacer.gif" width="1" border="0"/></td>
							<td bgcolor="#FBFBFB" colspan="6"><img height="17" alt="" src="Images/Spacer.gif" width="300" border="0"/></td>
							<td bgcolor="#397dde" rowspan="10"><img height="146" alt="" src="Images/Spacer.gif" width="1" border="0"/></td>
							<td>&nbsp;</td>
						</tr>
						<tr>
							<td bgcolor="#FBFBFB" rowspan="9">&nbsp;</td>
							<td align="center" style="padding-left:70px; width: 25px"></td>
							<td valign="top" bgcolor="#FBFBFB">
								<p class="smallTitle" align="right">Usuario:</p>
							</td>
							<td bgcolor="#FBFBFB" rowspan="9">
							    <img height="129" alt="" src="Images/Spacer.gif" width="8" border="0"/>
							</td>
							<td valign="top" bgcolor="#FBFBFB" colspan="2" align="left" style="padding-left:5px">
								<table cellspacing="0" cellpadding="0" border="0" style="width: 199px">
									<tr>
										<td style="width: 59px">
										    <asp:textbox id="txtUsuario" runat="server" MaxLength="19" Width="136px">alejandro</asp:textbox>
										</td>
									</tr>
								</table>
							</td>
							<td>&nbsp;</td>
						</tr>
						<tr>
							<td bgcolor="#FBFBFB" colspan="2"><img height="12" alt="" src="Images/Spacer.gif" width="86" border="0"/></td>
							<td bgcolor="#FBFBFB" colspan="2"><img height="12" alt="" src="Images/Spacer.gif" width="200" border="0"/></td>
							<td>&nbsp;</td>
						</tr>
						<tr>
							<td align="center" rowspan="2" style="padding-left:70px;width: 25px"></td>
							<td valign="top" bgcolor="#FBFBFB">
								<p class="smallTitle" align="right">&nbsp;Clave:</p>
							</td>
							<td valign="top" bgcolor="#FBFBFB" colspan="2" align="left" style="padding-left:5px">
								<table cellspacing="0" cellpadding="0" width="200" border="0">
									<tr>
										<td style="width: 59px">
										    <asp:textbox id="txtClave" runat="server" Width="136px" TextMode="Password">alejandro</asp:textbox>
										</td>
									</tr>
								</table>
							</td>
							<td>&nbsp;</td>
						</tr>
						<tr>
							<td bgcolor="#FBFBFB" rowspan="2"><img height="12" alt="" src="Images/Spacer.gif" width="62" border="0"/></td>
							<td bgcolor="#FBFBFB" colspan="2" rowspan="2" align="left">
							    <asp:button id="btnAceptar" runat="server" Text="Aceptar" OnClick="BtnAceptar_Click"
								        CssClass="button_back" Width="145px"></asp:button>
							</td>
							<td>&nbsp;</td>
						</tr>
						<tr>
							<td bgcolor="#FBFBFB" style="width: 25px"><img height="10" alt="" src="Images/Spacer.gif" width="24" border="0"/></td>
							<td>&nbsp;</td>
						</tr>
						<tr>
							<td style="width: 25px"></td>
							<td valign="top" bgcolor="#FBFBFB">
							</td>
							<td valign="top" bgcolor="#FBFBFB" colspan="2">
							    &nbsp;</td>
							<td></td>
						</tr>
						
						<tr>
							<td bgcolor="#FBFBFB" rowspan="2">&nbsp;</td>
							<td valign="top" bgcolor="#FBFBFB">
								&nbsp;</td>
						</tr>
						<tr>
							<td bgcolor="#FBFBFB"><img height="4" alt="" src="Images/Spacer.gif" width="50" border="0"/></td>
							<td bgcolor="#FBFBFB" class="style1"><img height="4" alt="" src="Images/Spacer.gif" width="50" border="0"/></td>
							<td><img height="4" alt="" src="Images/Spacer.gif" width="1" border="0"/></td>
						</tr>
						<tr>
							<td bgcolor="#397dde"><img height="1" alt="" src="Images/Spacer.gif" width="1" border="0"/></td>
							<td bgcolor="#397dde" colspan="6"><img height="1" alt="" src="Images/Spacer.gif" width="447" border="0"/></td>
							<td bgcolor="#397dde"><img height="1" alt="" src="Images/Spacer.gif" width="1" border="0"/></td>
							<td><img height="1" alt="" src="Images/Spacer.gif" width="1" border="0"/></td>
						</tr>
					</table>
					
					<asp:label id="lblMensaje" runat="server" CssClass="helpText" ForeColor="red"></asp:label><img height="1" alt="" src="Images/Spacer.gif" width="1"/><br />
                         <br />
&nbsp;<table cellspacing="0" cellpadding="1" align="center" border="0" style="width:100%;">
						<tr>
							<td style="height: 1px" valign="bottom">
								<div class="headerText" align="center">M&oacute;dulo de &#149; Revisi&oacute;n: <asp:Label id="lblAppVersion" runat="server"></asp:Label></div>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
    </div>
    </form>
</body>
</html>
