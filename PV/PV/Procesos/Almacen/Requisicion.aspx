<%@ Page Title="Inventario" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Requisicion.aspx.vb" Inherits="PV.Inventario" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
		<link href="../../Content/StyleSheet.css" rel="stylesheet" type="text/css">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="VRegistro" runat="server">
				<br />
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 169px" colspan="3">
                            <asp:ImageButton ID="BTNuevo" runat="server" Text="Nuevo" ImageUrl="~/Imagenes/IMNuevo.png" />
                            <asp:ImageButton ID="BTNGuardar" runat="server" Text="Guardar" ImageUrl="~/Imagenes/IMGuardar.png" CausesValidation="true" ValidationGroup="BTNGuardar" />
							<asp:ImageButton ID="BTNConsultar" runat="server" Text="Consultar" ImageUrl="~/Imagenes/IMConsultar.png" CausesValidation="true" ValidationGroup="BTNGuardar" />
                            <asp:ImageButton ID="BTNSalir" runat="server" Text="Salir" ImageUrl="~/Imagenes/IMSalir.png" CssClass="button" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="width: 169px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 108px">ID Requisicion</td>
                        <td style="width: 731px">
                            <asp:TextBox ID="TBIdRequisicionEncabezado" runat="server" Width="150" Enabled="False" CssClass="TB5"></asp:TextBox>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width: 108px; height: 24px;">Sucursal</td>
                        <td style="height: 24px; width: 731px;">
                            <asp:DropDownList ID="DDIdSucursal" runat="server" Width="150" CssClass="select" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width: 108px">Almacen</td>
                        <td style="width: 731px">
                            <asp:DropDownList ID="DDIdAlmacen" runat="server" Width="150" CssClass="select"></asp:DropDownList>
							<asp:Label ID="LBCampoRequerido" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width: 108px; height: 24px;">Fecha</td>
                        <td style="height: 24px; width: 731px;">
                            <asp:TextBox ID="TBFechaRegistro" runat="server" Enabled="False" Width="150" CssClass="TB5"></asp:TextBox>
                        </td>
                        
                    </tr>
                       <tr>
                        <td style="width: 108px; height: 24px;">Descripcion</td>
                        <td style="height: 24px; width: 731px;">
                            <asp:TextBox ID="TBDescripcion" runat="server" Width="300" CssClass="TB5"></asp:TextBox>
                        </td>
                        
                    </tr>
					 <tr>
                        <td style="width: 108px">Observaciones</td>
						<td style="height: 24px; width: 731px;">
							<asp:TextBox ID="TBObservacion" runat="server" Enabled="True" TextMode="MultiLine" Height="30px" Width="500px" CssClass="form-control" />
						</td>
						
                    </tr>
                    <tr>
                        <td style="width: 108px">&nbsp;</td>
						<td style="height: 24px; width: 731px;">
							<asp:Button ID="BTNConsultarProductos" runat="server" CausesValidation="true" CssClass="button" Text="Consultar Productos" />
						</td>
						
                    </tr>
                    <tr>
                        <td colspan="2">
                        <div style="overflow:auto; width:1200px; height:200px;">
                            <asp:GridView ID="GVProductos" runat="server" AllowPaging="false" HorizontalAlign="Center" Width="100%" CssClass="gridView">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CBGVProducto" runat="server" AutoPostBack="false" Checked="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ID_PRODUCTO" HeaderText="Id Producto" SortExpression="ID_PRODUCTO" />
                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" SortExpression="DESCRIPCION" />
                                    <asp:BoundField DataField="MARCA" HeaderText="Marca" SortExpression="MARCA" />
                                    <asp:BoundField DataField="ALMACEN" HeaderText="Almacen" SortExpression="ALMACEN" />
                                    <asp:TemplateField HeaderText="Cantidad">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TBCantidadRequisicion" runat="server" AutoPostBack="false" Text='<%# DataBinder.Eval(Container.DataItem, "Cantidad")%>' Visible="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </div>
                        </td>
                    </tr>
					<tr>
                        <td style="width: 108px"><asp:Button ID="BTNAgregar" runat="server" Text="Agregar a requisicion" CssClass="button" CausesValidation="true" Visible="false" /></td>
                    </tr>
					 <tr>
						 <td colspan="3">
							 <asp:GridView ID="GVAgregados" runat="server" AllowPaging="false" CssClass="gridView" HorizontalAlign="Center" Width="100%">
								 <Columns>
									<asp:TemplateField>
										<HeaderTemplate>
											Eliminar
										</HeaderTemplate>

										<ItemTemplate>
											<asp:LinkButton ID="BTNSeleccionar" runat="server" ForeColor="Blue" OnClick="BTNSeleccionar_OnClick" ShowSelectButton="True" Text="Eliminar" />
										</ItemTemplate>

									</asp:TemplateField>
								</Columns>
							 </asp:GridView>
						 </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="VConsulta" runat="server">
				<br />
                <table style="width: 100%;">
                    <tr style="text-align: left;">
						<td style="width: 104px">Fecha Inicio</td>
						<td style="width: 104px">
							<%--<ajaxToolkit:CalendarExtender ID="CalendarExtender1" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFecha" />--%>
						</td>
						<td style="width: 108px">Fecha Fin</td>
						<td style="width: 104px">
							&nbsp;</td>
						<td >
							&nbsp;</td>
                    </tr>
					<tr style="text-align: left;">
                        <td colspan="6"></td>
                    </tr>
					<tr style="text-align: left;">
                        <td colspan="6"></td>
                    </tr>
                    <tr style="text-align: center;">
                        <td colspan="6">
							<asp:GridView ID="GVConsulta" runat="server" AllowPaging="false" HorizontalAlign="Center" CssClass="gridView" Width="100%">
							</asp:GridView>
						</td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
</asp:Content>
