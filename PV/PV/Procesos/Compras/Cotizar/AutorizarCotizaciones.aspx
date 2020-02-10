<%@ Page Title="Autorizar cotizaciones" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AutorizarCotizaciones.aspx.vb" Inherits="PV.AutorizarCotizaciones" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
		<link href="../../../Content/StyleSheet.css" rel="stylesheet" type="text/css">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="VRegistro" runat="server">
				<br />
                <table style="width: 100%;">
                    <tr>
                        <td colspan="3">
                            <asp:ImageButton ID="BTNuevo" runat="server" Text="Nuevo" ImageUrl="~/Imagenes/IMNuevo.png"  CssClass="button"/>
                            <asp:ImageButton ID="BTNAutorizar" runat="server" CausesValidation="true" CssClass="button" ImageUrl="~/Imagenes/IMAutorizar.png" Text="Autorizar" ValidationGroup="BTNAutorizar" />
							<asp:ImageButton ID="BTNSalir" runat="server" Text="Salir" ImageUrl="~/Imagenes/IMSalir.png" CssClass="button" />
						</td>
					</tr>
					<tr>
						<td colspan="3" style="width: 169px; height: 21px;"></td>
					</tr>
					<tr>
						<td colspan="3" style="width: 169px; height: 21px;">
							<div style="overflow: auto; width: 1200px; height: 200px;">
									<asp:GridView ID="GVRequisiciones" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="false" HorizontalAlign="Center"
									CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
									PageSize="7" Width="100%" OnPageIndexChanging ="GVRequisiciones_PageIndexChanging">
										<Columns>
											<asp:TemplateField>
												<HeaderTemplate>
													Seleccionar
												</HeaderTemplate>
												<ItemTemplate>
													<asp:LinkButton ID="BTNSeleccionar" runat="server" ForeColor="Blue" OnClick="BTNSeleccionar_OnClick" ShowSelectButton="True" Text="Seleccionar" />
												</ItemTemplate>
											</asp:TemplateField>
											<asp:BoundField DataField="ID_REQUISICION" HeaderText="ID Requisicion" SortExpression="ID_REQUISICION" />
											<asp:BoundField DataField="ID_PRODUCTO" HeaderText="ID Producto" SortExpression="ID_PRODUCTO" />
											<asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" SortExpression="DESCRIPCION" />
											<asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" SortExpression="CANTIDAD" />
											<asp:BoundField DataField="FECHA" HeaderText="Fecha" SortExpression="FECHA" />
											<asp:BoundField DataField="CONTADOR" HeaderText="Contador" SortExpression="CONTADOR" />
											<%--<asp:BoundField DataField="Observaciones" HeaderText="Observacion" SortExpression="Observaciones" />--%>
											<%--<asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />--%>
										</Columns>
									</asp:GridView>
									<%--<asp:GridView ID="GVProductos" runat="server" AllowPaging="false" HorizontalAlign="Center" Width="100%" CssClass="form-control">
										<Columns>
											<asp:TemplateField>
												<ItemTemplate>
													<asp:CheckBox ID="CBGVProducto" runat="server" AutoPostBack="false" Checked="false" />
												</ItemTemplate>
											</asp:TemplateField>
											<asp:BoundField DataField="ID_REQUISICION" HeaderText="Id Requisicion" SortExpression="ID_REQUISICION" />
											<asp:BoundField DataField="ID_PRODUCTO" HeaderText="Id Producto" SortExpression="ID_PRODUCTO" />
											<asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" SortExpression="DESCRIPCION" />
											<asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" SortExpression="CANTIDAD" />
											<asp:BoundField DataField="FECHA" HeaderText="Fecha" SortExpression="FECHA" />--%>
									<%--<asp:BoundField DataField="COMENTARIO" HeaderText="Comentarios" SortExpression="COMENTARIO" />
											<asp:BoundField DataField="URGENTE" HeaderText="Prioridad" SortExpression="URGENTE" />--%>
									<%--<asp:TemplateField HeaderText="Cantidad">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TBCantidadRequisicion" runat="server" AutoPostBack="false" Text='<%# DataBinder.Eval(Container.DataItem, "Cantidad")%>' Visible="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
									<%--	</Columns>
									</asp:GridView>--%>
								</div>
						</td>
					</tr>
					<tr>
						<td colspan="3" style="width: 169px; height: 21px;"></td>
					</tr>
					<tr>
						<td colspan="3" style="height: 33px">
							<div style="overflow: auto; width: 1200px; height: 200px;">
								<asp:GridView ID="GVCotizaciones" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="false" HorizontalAlign="Center"
									CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
									PageSize="7" Width="100%" OnPageIndexChanging ="GVCotizaciones_PageIndexChanging">
										<Columns>
											<asp:TemplateField>
												<HeaderTemplate>
													Seleccionar
												</HeaderTemplate>
												<ItemTemplate>
													<asp:LinkButton ID="BTNSeleccionarCotizacion" runat="server" ForeColor="Blue" OnClick="BTNSeleccionarCotizacion_OnClick" ShowSelectButton="True" Text="Aceptar" />
												</ItemTemplate>
											</asp:TemplateField>
											<asp:BoundField DataField="ID_COTIZACION" HeaderText="Id Cotizacion" SortExpression="ID_COTIZACION" Visible ="false"/>
											<asp:BoundField DataField="ID_REQUISICION" HeaderText="Id Requisicion" SortExpression="ID_REQUISICION" Visible ="false"/>
											<asp:BoundField DataField="ID_PROVEEDOR" HeaderText="Id Proveedor" SortExpression="ID_PROVEEDOR" Visible ="false"/>
											<asp:BoundField DataField="NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE"/>
											<asp:BoundField DataField="ID_PRODUCTO" HeaderText="Id Producto" SortExpression="ID_PRODUCTO" visible ="false"/>
											<asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" SortExpression="DESCRIPCION" visible ="false"/>
											<asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" SortExpression="CANTIDAD" visible ="false"/>
											<asp:BoundField DataField="DIAS_ENTREGA" HeaderText="Dias de Entrega" SortExpression="DIAS_ENTREGA" />
											<asp:BoundField DataField="PRECIO" HeaderText="Precio" SortExpression="PRECIO" />
											<asp:BoundField DataField="FECHA" HeaderText="Fecha" SortExpression="FECHA" />
											<%--<asp:TemplateField HeaderText="Dias de entrega">
												<ItemTemplate>
													<asp:TextBox ID="TBDiasEntrega" runat="server" AutoPostBack="false" Text='<%# DataBinder.Eval(Container.DataItem, "DIAS_ENTREGA")%>' Visible="true"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateField>--%>
											<%--<asp:TemplateField HeaderText="Precio">
												<ItemTemplate>
													<asp:TextBox ID="TBPrecio" runat="server" AutoPostBack="false" Text='<%# DataBinder.Eval(Container.DataItem, "PRECIO")%>' Visible="true"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateField>--%>
										<%--	<asp:TemplateField HeaderText="Moneda">
												<ItemTemplate>
													<asp:DropDownList ID="Combo1" runat="server" CssClass="form-control" Width="150">
														<asp:ListItem Selected="True" Value="PESOS">PESOS</asp:ListItem>
														<asp:ListItem Value="DOLARES">DOLARES</asp:ListItem>
													</asp:DropDownList>
												</ItemTemplate>
											</asp:TemplateField>--%>
											<%--<asp:BoundField DataField="MONEDA" HeaderText="Moneda" SortExpression="MONEDA" />--%>
											<%--<asp:BoundField DataField="FECHA" HeaderText="Fecha" SortExpression="FECHA" />--%>
											<%--<asp:BoundField DataField="COMENTARIO" HeaderText="Comentarios" SortExpression="COMENTARIO" />
											<asp:BoundField DataField="URGENTE" HeaderText="Prioridad" SortExpression="URGENTE" />--%>
											
										</Columns>
									</asp:GridView>
							</div>
						 </td>
                    </tr>
					<tr>
						<td colspan="3" style="height: 33px">
							
						 </td>
                    </tr>
				<%--	<tr>
						<td style="width: 144px"><label>Dias de entrega</label></td>
						<td style="height: 24px; width: 731px;">
							<asp:TextBox ID="txtDias" runat="server" CssClass="form-control" Width="122px" style="margin-left: 35"></asp:TextBox>
						</td>
                    </tr>--%>
					  <%-- <tr>
                        <td style="width: 144px; height: 24px;"><label>Precio</label></td>
						<td style="height: 24px; width: 731px;">
							
							<asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Width="122px" style="margin-left: 35"></asp:TextBox>
							
						</td>

					   </tr>--%>
					<%--<tr>
						<td style="width: 144px"><label>Moneda</label></td>
						<td style="height: 24px; width: 731px;">

							<asp:DropDownList ID="Combo1" runat="server" CssClass="form-control" Width="150">
								<asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
								<asp:ListItem Value="1">PESOS</asp:ListItem>
								<asp:ListItem Value="2">DOLARES</asp:ListItem>
							</asp:DropDownList>

						</td>

					</tr>--%>
				<%--	<tr>
						<td style="width: 144px">&nbsp;</td>
						<td style="height: 24px; width: 731px;"></td>
					</tr>--%>
					<tr>
						<td colspan="3">
							
						 </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
</asp:Content>
