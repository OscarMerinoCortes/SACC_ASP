<%@ Page Title="Pre Orden de Compra" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreOrdenCompra.aspx.vb" Inherits="PV.PreOrdenCompra" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<link href="../../../Content/StyleSheet.css" rel="stylesheet" type="text/css">
	<%--<link href="../../../Content/bootstrap.min.css" rel="stylesheet" />--%>
	<asp:MultiView ID="MultiView1" runat="server">
		<asp:View ID="VRegistro" runat="server">
			<table style="width: 100%;">
				<tr>
					<td colspan="3">
						<asp:ImageButton ID="BTNuevo" runat="server" Text="Nuevo" ImageUrl="~/Imagenes/IMNuevo.png" CssClass="button" />
						<asp:ImageButton ID="BTNGuardar" runat="server" CausesValidation="true" CssClass="button" ImageUrl="~/Imagenes/IMGuardar.png" Text="Guardar" ValidationGroup="BTNGuardar" OnClientClick="return confirm('Esta seguro que los datos son los correctos?');" />
						<asp:ImageButton ID="BTNActualizar" runat="server" Text="Actualizar" ImageUrl="~/Imagenes/IMActualizar.png" CssClass="button" OnClientClick="return confirm('Se actualizaran las cantidades, estas seguro que son las correctas?');" />
						<asp:ImageButton ID="BTNSalir" runat="server" Text="Salir" ImageUrl="~/Imagenes/IMSalir.png" CssClass="button" />
						</td>
					</tr>
					<tr>
						<td colspan="3" style="width: 115px; height: 21px;"></td>
					</tr>
					<tr>
						<td colspan="2" style="height: 21px">
							<asp:Panel ID="PaneTipoOrden" runat="server" Height="112px" Width="179px" CssClass="form-control">
								<asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Tipo de Orden"></asp:Label>
								<br />
								<asp:CheckBox ID="ChkBNacional" runat="server" Text="Nacional" AutoPostBack ="true"/>
								<br />
								<asp:CheckBox ID="ChkBInternacional" runat="server" Text="Internacional" AutoPostBack ="true"/>
								<br />
								<asp:CheckBox ID="ChkBIndirecta" runat="server" Text="Indirecto" AutoPostBack ="true"/>
								<br />
								<br />
							</asp:Panel>
						</td>
						<td colspan="2" style="width: 169px; height: 21px;">
							<asp:Panel ID="Panel1" runat="server" Height="112px" Width="299px" CssClass="form-control">
								<asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Tipo de Pago"></asp:Label>
								<br />
								<asp:CheckBox ID="ChkBCredito" runat="server" Text="Credito" AutoPostBack="True" />
								<br />
								<asp:CheckBox ID="ChkBContado" runat="server" Text="Contado" AutoPostBack="True" />
							</asp:Panel>
						</td>
					</tr>
					<tr>
						<td colspan="2">
							
						</td>
						<td colspan="2" style="width: 169px; height: 21px;">
							<asp:Label ID="Label10" runat="server" Text="Dias" Font-Bold="True" Font-Italic="False" Font-Overline="False"></asp:Label>
							<asp:DropDownList ID="DDDiasCredito" runat="server" CssClass="form-control" Visible="False" Width ="150px">
								<asp:ListItem Selected="True" Value="15"></asp:ListItem>
								<asp:ListItem>30</asp:ListItem>
								<asp:ListItem>45</asp:ListItem>
								<asp:ListItem>60</asp:ListItem>
								<asp:ListItem>90</asp:ListItem>
							</asp:DropDownList>
							
						</td>
					</tr>
					<tr>
						<td colspan="3" style="width: 115px; height: 21px;">
							&nbsp;</td>
					</tr>
					<tr>
						<td colspan="3" style="width: 169px; height: 21px;">
							<div style="overflow: auto; width: 1200px; height: 200px;">
									<asp:GridView ID="GVProveedores" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="false" HorizontalAlign="Center"
									CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
									PageSize="7" Width="100%" OnPageIndexChanging="GVProveedores_PageIndexChanging">
										<Columns>
											<asp:TemplateField>
												<HeaderTemplate>
													Seleccionar
												</HeaderTemplate>
												<ItemTemplate>
													<asp:LinkButton ID="BTNSeleccionar" runat="server" ForeColor="Blue" OnClick="BTNSeleccionar_OnClick" ShowSelectButton="True" Text="Seleccionar" />
												</ItemTemplate>
											</asp:TemplateField>
											<asp:BoundField DataField="ID_PROVEEDOR" HeaderText="ID" SortExpression="ID_PROVEEDOR" />
											<asp:BoundField DataField="NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE" />
											<%--<asp:BoundField DataField="TELEFONO1" HeaderText="Telefono" SortExpression="TELEFONO1" />--%>
											<%--<asp:BoundField DataField="DIRECCION" HeaderText="Direccion" SortExpression="DIRECCION" />--%>
											<%--<asp:BoundField DataField="NOTAS" HeaderText="Notas" SortExpression="NOTAS" />--%>
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
						<td colspan="3"></td>
					</tr>
					<tr>
						<td colspan="3" style="height: 33px">
							<div style="overflow: auto; width: 1200px; height: 200px;">
								<asp:GridView ID="GVProductosProveedor" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="false" HorizontalAlign="Center"
									CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
									PageSize="7" Width="100%" OnPageIndexChanging="GVProductosProveedor_PageIndexChanging">
										<Columns>
											<%--<asp:TemplateField>
												<ItemTemplate>
													<asp:CheckBox ID="CBGVProducto" runat="server" AutoPostBack="false" Checked="false" />
												</ItemTemplate>
											</asp:TemplateField>--%>
											<asp:TemplateField>
												<HeaderTemplate>
													Eliminar
												</HeaderTemplate>
												<ItemTemplate>
													<asp:LinkButton ID="BTNEliminar" runat="server" ForeColor="Blue" OnClick="BTNEliminar_OnClick" ShowSelectButton="True" Text="Eliminar" OnClientClick="return confirm('Esta seguro que desea eliminar este producto?');" />
												</ItemTemplate>
											</asp:TemplateField>
											<asp:BoundField DataField="ID_COTIZACION" HeaderText="Id Cotizacion" SortExpression="ID_COTIZACION" />
											<asp:BoundField DataField="ID_REQUISICION" HeaderText="Id Requisicion" SortExpression="ID_REQUISICION" visible="false"/>
											<asp:BoundField DataField="ID_PROVEEDOR" HeaderText="Id Proveedor" SortExpression="ID_PROVEEDOR" />
											<asp:BoundField DataField="ID_PRODUCTO" HeaderText="Id Producto" SortExpression="ID_PRODUCTO" />
											<asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" SortExpression="DESCRIPCION" />
											<asp:TemplateField HeaderText="Cantidad">
												<ItemTemplate>
													<asp:TextBox ID="TBCantidad" runat="server" AutoPostBack="false" Text='<%# DataBinder.Eval(Container.DataItem, "CANTIDAD")%>' Visible="true"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:BoundField DataField="DIAS_ENTREGA" HeaderText="Dias de Entrega" SortExpression="DIAS_ENTREGA" />
											<asp:BoundField DataField="PRECIO" HeaderText="Precio" SortExpression="PRECIO" />
											<%--<asp:TemplateField HeaderText="Dias de entrega">
												<ItemTemplate>
													<asp:TextBox ID="TBDiasEntrega" runat="server" AutoPostBack="false" Text='<%# DataBinder.Eval(Container.DataItem, "DIAS_ENTREGA")%>' Visible="true"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateField>--%>
										<%--	<asp:TemplateField HeaderText="Precio">
												<ItemTemplate>
													<asp:TextBox ID="TBPrecio" runat="server" AutoPostBack="false" Text='<%# DataBinder.Eval(Container.DataItem, "PRECIO")%>' Visible="true"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateField>--%>
											<asp:BoundField DataField="FECHA" HeaderText="Fecha" SortExpression="FECHA" Visible ="false"/>
											<asp:BoundField DataField="IDS" HeaderText="IDS" SortExpression="IDS"/>
											<asp:BoundField DataField="NUMOC" HeaderText="Orden de Compra" SortExpression="NUMOC"/>
											<%--<asp:TemplateField HeaderText="Moneda">
												<ItemTemplate>
													<asp:DropDownList ID="Combo1" runat="server" CssClass="form-control" Width="150">
														<asp:ListItem Selected="True" Value="PESOS">PESOS</asp:ListItem>
														<asp:ListItem Value="DOLARES">DOLARES</asp:ListItem>
													</asp:DropDownList>
												</ItemTemplate>
											</asp:TemplateField>--%>
											<%--<asp:BoundField DataField="MONEDA" HeaderText="Moneda" SortExpression="MONEDA" />--%>
											<asp:BoundField DataField="NO_PEDIDO" HeaderText="Numero de Pedido" SortExpression="NO_PEDIDO" Visible="false" />
											<%--<asp:BoundField DataField="COMENTARIO" HeaderText="Comentarios" SortExpression="COMENTARIO" />
											<asp:BoundField DataField="URGENTE" HeaderText="Prioridad" SortExpression="URGENTE" />--%>
										</Columns>
								</asp:GridView>
							</div>
						</td>
					</tr>
				<tr>
					<td colspan="3"></td>
				</tr>
				<tr>
					<td colspan="3"></td>
				</tr>
				<tr>
					<td style="height: 21px">
						<asp:Label ID="Label11" runat="server" Text="MONEDA" Font-Bold="True"></asp:Label></td>
					<td colspan="2" style="height: 21px">
						<asp:DropDownList ID="DDMoneda" runat="server" CssClass="form-control" Width="150px">
							<asp:ListItem Selected="True">PESOS</asp:ListItem>
							<asp:ListItem>DOLARES</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td style="height: 21px">
						<asp:Label ID="Label1" runat="server" Text="SUBTOTAL" Font-Bold="True"></asp:Label></td>
					<td colspan="2" style="height: 21px">
						<asp:TextBox ID="TBSubtotal" runat="server" CssClass="form-control" Width="150px" Enabled="False">0</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label2" runat="server" Text="DESCUENTO" Font-Bold="True"></asp:Label></td>
					<td style="width: 223px" colspan="2">
						<asp:TextBox ID="TBDescuento" runat="server" CssClass="form-control" AutoPostBack="True">0</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label3" runat="server" Text="OTROS CARGOS" Font-Bold="True"></asp:Label></td>
					<td style="width: 223px" colspan="2">
						<asp:TextBox ID="TBOtrosCargos" runat="server" CssClass="form-control" AutoPostBack="True">0</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="height: 20px">
						<asp:Label ID="Label4" runat="server" Text="FLETE" Font-Bold="True"></asp:Label></td>
					<td style="width: 223px;" colspan="2">
						<asp:TextBox ID="TBFlete" runat="server" CssClass="form-control" AutoPostBack="True">0</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label5" runat="server" Text="IMPUESTO" Font-Bold="True"></asp:Label></td>
					<td style="width: 223px" colspan="2">
						<asp:TextBox ID="TBImpuestos" runat="server" CssClass="form-control" Enabled="False">0</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label6" runat="server" Text="TOTAL" Font-Bold="True"></asp:Label></td>
					<td style="width: 223px" colspan="2">
						<asp:TextBox ID="TBTotal" runat="server" CssClass="form-control" Enabled="False">0</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="3"></td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label7" runat="server" Text="COMENTARIOS" Font-Bold="True"></asp:Label></td>
					<td style="width: 223px" colspan="2">
						<asp:TextBox ID="TBComentarios" runat="server" TextMode="MultiLine" Width="600px" CssClass="form-control"></asp:TextBox>
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
							&nbsp;</td>
					</tr>
				</table>
			</asp:View>
		</asp:MultiView>
</asp:Content>
