<%@ Page Title="Reporte de Ventas" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="ReporteVentas.aspx.vb" Inherits="PV.ReporteVentas" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Estilos.css" rel="stylesheet" type="text/css">
    <h2>Reporte de Ventas.</h2>
    <p>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="VRegistro" runat="server">
                <table style="width:100%;">
            <tr>
                <td colspan="3">
                    <asp:Button ID="BTNImprimir" runat="server" Text="Imprimir" CssClass="button" />
                </td>               
            </tr>
            <tr>
                <td style="width: 169px">&nbsp;</td>
                <td style="width: 1182px">
                    &nbsp;</td>
                <td style="width: 128px">&nbsp;</td>
            </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="GVImprimir" runat="server" AllowPaging="false"  HorizontalAlign="Center" Width="100%" CssClass="gridView">
                             </asp:GridView>
                        </td>                       
                    </tr>
        </table>
            </asp:View>
            <asp:View ID="VConsulta" runat="server">

            </asp:View>
        </asp:MultiView>        
    </p>

</asp:Content>

