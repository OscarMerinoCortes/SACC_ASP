<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="PV.Login1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style8 {
            width: 66px;
            height: 134px;
        }
        .auto-style9 {
            height: 134px;
        }
        .auto-style11 {
            height: 225px;
        }
        .auto-style15 {
            width: 66px;
        }
        .auto-style16 {
            width: 66px;
            height: 27px;
        }        
        .azul:focus {
            box-shadow: 0 0 5px rgba(0,0,255,1);
            border:1px solid rgba(0,0,255,0.8);}
        .img {
            margin: 20px;
            border: 5px solid #eee;
            -webkit-box-shadow: 4px 4px 4px rgba(0,0,0,0.2);
            -moz-box-shadow: 4px 4px 4px rgba(0,0,0,0.2);
            box-shadow: 4px 4px 4px rgba(0,0,0,0.2);
            -webkit-transition: all 0.5s ease-out;
            -moz-transition: all 0.5s ease;
            -o-transition: all 0.5s ease;
        }

            .img:hover {
                -webkit-transform: rotate(-7deg);
                -moz-transform: rotate(-7deg);
                -o-transform: rotate(-7deg);
            }
            .p {
                font-family: "Homer Simpson", cursive;
                }
        .btn {
            background: #051d2e;
            background-image: -webkit-linear-gradient(top, #051d2e, #1f7a00);
            background-image: -moz-linear-gradient(top, #051d2e, #1f7a00);
            background-image: -ms-linear-gradient(top, #051d2e, #1f7a00);
            background-image: -o-linear-gradient(top, #051d2e, #1f7a00);
            background-image: linear-gradient(to bottom, #051d2e, #1f7a00);
            -webkit-border-radius: 10;
            -moz-border-radius: 10;
            border-radius: 10px;
            -webkit-box-shadow: 0px 1px 3px #030303;
            -moz-box-shadow: 0px 1px 3px #030303;
            box-shadow: 0px 1px 3px #030303;
            font-family: Courier New;
            color: #f2f2f2;
            font-size: 20px;
            padding: 9px 22px 10px 20px;
            text-decoration: none;
        }

            .btn:hover {
                background: #051d2e;
                background-image: -webkit-linear-gradient(top, #051d2e, #0dff00);
                background-image: -moz-linear-gradient(top, #051d2e, #0dff00);
                background-image: -ms-linear-gradient(top, #051d2e, #0dff00);
                background-image: -o-linear-gradient(top, #051d2e, #0dff00);
                background-image: linear-gradient(to bottom, #051d2e, #0dff00);
                text-decoration: none;
            }
       
        </style>
</head>
<body>   
    <form id="form1" runat="server" >
    <table style="width: 100%;">
        <tr>
            <td colspan="3" class="auto-style11">
                <asp:Panel ID="PaneLogin" runat="server" BackColor="#a9c673">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="3">
                                <asp:Panel ID="Panel1" runat="server" BackColor="White" ForeColor="Black" HorizontalAlign="Center">
                                    <asp:Label ID="LBInicio" runat="server" Text="Iniciar Sesión" CssClass="p"></asp:Label>
                                </asp:Panel>
                                </td>                          
                        </tr>
                        <tr align="center">                            
                            <td colspan="3">                              
                                 <asp:Image ID="ImagePass" runat="server" Height="119px" ImageUrl="~/Imagenes/15135572_1262447740479348_495129347_n.jpg" Width="209px" CssClass="img"/>
                            </td>                           
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td align="center" class="auto-style18">
                                Usuario&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="TBUsuario" runat="server" Width="150" CssClass="azul"></asp:TextBox>
                            </td>
                            <td class="auto-style23">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td align="center" class="auto-style18">
                                Contraseña
                                <asp:TextBox ID="TBPassword" runat="server" Width="150" TextMode="Password" CssClass="azul"></asp:TextBox>
                            </td>
                            <td class="auto-style23">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">
                                &nbsp;</td>
                            <td align="center" class="auto-style18">
                                &nbsp;</td>
                            <td class="auto-style23">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style16">&nbsp;</td>
                            <td align="center" class="auto-style19">
                                <asp:Button ID="BTNAceptar" runat="server" CssClass="btn" Text="Aceptar" />
                            </td>
                            <td class="auto-style24"></td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                &nbsp;</td>
                            
                            <td align="center" class="auto-style19">
                                <asp:Label ID="LBMensaje" runat="server"></asp:Label>
                            </td>
                            <td class="auto-style24">&nbsp;</td>
                            
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Panel ID="Panel2" runat="server" BackColor="White" HorizontalAlign="Center">
                                    <asp:Label ID="LBMarca" runat="server" CssClass="p" Text="Materias Primas Delicias S.A de C.V."></asp:Label>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>            
        </tr>        
    </table> 
    </form>
</body>
</html>
