<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCViewDatosDeudor.ascx.cs" Inherits="UserControls_UCViewDatosDeudor" %>

<link href="../Css/GobbiStyle.css" rel="stylesheet" type="text/css" />
<link href="../Css/GobbiMagicStyle.css" rel="stylesheet" type="text/css" />

                                                <div  style="font-family: Tahoma, Arial, MS Sans Serif; color: #666666;font-weight: bold;font-size: 16px;background-color: #EDEBEB;border-right: #cccccc 2px solid;border-bottom: #cccccc 1px inset;text-align: left; height:20px; width:400px; text-align:center;">
                                                <table>
                                                
                                                <tr>
                                                
                                                        <td align="center">
                                                            <asp:Label ID="Label4" runat="server" Text="   Datos Del Deudor" />
                                                    </td>
                                                    </tr>
                                                    
                                                    </table>
                                                </div>
                                                <div style="height:179px; width:400px; background-color: #ffffff;  border-right: #cccccc 2px solid;border-bottom: #cccccc 1px inset; text-align:center;">
                                                   <br />
                                                    <table style="width: 310px">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"  CssClass="labelBold"/>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNombre" runat="server" CssClass="textboxEditor" ></asp:TextBox>
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                            
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                    ErrorMessage="Ingrese el nombre" ControlToValidate="txtNombre" 
                                                                    Enabled="False"></asp:RequiredFieldValidator>
                                                            
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio:" CssClass="labelBold"/>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDomicilio" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                    ErrorMessage="Ingrese el domicilio" ControlToValidate="txtDomicilio" 
                                                                    Enabled="False"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="labelBold"/>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                                    ErrorMessage="Ingrese el teléfono" ControlToValidate="txtTelefono" 
                                                                    Enabled="False"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTelefonoAux" runat="server" Text="Teléfono Aux.:" CssClass="labelBold"/>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTelefonoAux" runat="server" CssClass="textboxEditor"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                                    ErrorMessage="Ingrese el teléfono auxiliar" ControlToValidate="txtTelefonoAux" 
                                                                    Enabled="False"></asp:RequiredFieldValidator>
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div style="height:30px; width:400px; background-color: #ffffff;border-right: #cccccc 2px solid;border-bottom: #cccccc 1px inset; text-align:center;">
                                                <table>
                                                <tr>
                                                <td>
                                                <asp:Button ID="btnAceptar" runat="server" Text="Guardar" CssClass="button_back" 
                                                        Width="98px"/>
                                                </td>
                                                <td align="right">
                                                <asp:Button  ID="btnCancelar" runat="server"   Text="Cancelar" 
                                                        CssClass="button_back" Width="98px"/>
                                                </td>
                                                </tr>
                                                </table>
                                                    
                                                                                                      
                                                </div>
