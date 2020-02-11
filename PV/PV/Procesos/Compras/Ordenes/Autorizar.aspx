<%@ Page Title="Autorizar Orden" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Autorizar.aspx.vb" Inherits="PV.Autorizar" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
		<link href="../../../Content/StyleSheet.css" rel="stylesheet" type="text/css">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="VRegistro" runat="server">
				<table style="width: 100%;">
					<tr>
						<td colspan="3">
							<asp:ImageButton ID="BTNAutorizar" runat="server" CausesValidation="true" CssClass="button" ImageUrl="~/Imagenes/IMAutorizar.png" Text="Autorizar" ValidationGroup="BTNAutorizar" OnClientClick="return confirm('Estas seguro que los datos son correctos?')" Width="80px"/>
							<asp:ImageButton ID="BTNRechazar" runat="server" ImageUrl="~/Imagenes/IMCancelar.png" CssClass="button" OnClientClick="return confirm('Estas seguro de que deseas rechazar estar orden de compra?')" Width="80px" />
							<asp:ImageButton ID="BTNAdministracion" runat="server" ImageUrl="~/Imagenes/IMAdministracion.png" Width="80px" />
							<asp:ImageButton ID="BTNSalir" runat="server" Text="Salir" ImageUrl="~/Imagenes/IMSalir.png" CssClass="button" Width="80px" />
						</td>
					</tr>
					<tr>
						<td colspan="3"></td>
					</tr>
					<tr>
						<td colspan="3">
							<asp:Label ID="Label2" runat="server" Text="Tipo de Orden" Font-Bold="True"></asp:Label>
						</td>
					</tr>
					<tr>
						<td colspan="3"></td>
					</tr>
					<tr>
						<td colspan="3">
							<asp:DropDownList ID="DDTipoOrdeCompra" runat="server" Width="200px" CssClass="form-control">
								<asp:ListItem Selected="True" Value="I">Internacionales</asp:ListItem>
								<asp:ListItem Value="N">Nacionales</asp:ListItem>
								<asp:ListItem Value="X">Indirectas</asp:ListItem>
							</asp:DropDownList></td>
					</tr>
					<tr>
						<td colspan="3">
							<asp:Button ID="BTNFiltar" runat="server" Text="Filtrar" CssClass="form-control" Width="100px" /></td>
					</tr>
					<tr>
						<td colspan="3" style="height: 40px"></td>
					</tr>
					<tr>
						<td colspan="3">
							<div style="overflow: auto; width: 1200px; height: 200px;">
								<asp:GridView ID="GVOrdenes" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="false" HorizontalAlign="Center"
									CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
									PageSize="7" Width="100%" OnPageIndexChanging="GVOrdenes_PageIndexChanging">
									<Columns>
										<asp:TemplateField>
											<HeaderTemplate>
												Seleccionar
											</HeaderTemplate>
											<ItemTemplate>
												<asp:LinkButton ID="BTNSeleccionar" runat="server" ForeColor="Blue" OnClick="BTNSeleccionar_OnClick" ShowSelectButton="True" Text="Seleccionar" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:BoundField DataField="Id_Orden_Compra" HeaderText="ID Orden de Compra" SortExpression="Id_Orden_Compra" />
										<asp:BoundField DataField="NUM_ORDEN" HeaderText="Numero de Orden" SortExpression="NUM_ORDEN" />
										<asp:BoundField DataField="Id_Proveedor" HeaderText="ID Proveedor" SortExpression="Id_Proveedor" />
										<asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
											<asp:BoundField DataField="Total_Pagar" HeaderText="Monto" SortExpression="Total_Pagar" />
											<asp:BoundField DataField="COMENTARIO" HeaderText="Comentario" SortExpression="COMENTARIO" />
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
						<td colspan="3" style="height: 40px"></td>
					</tr>
					<tr>
						<td colspan="3">
							<div style="overflow: auto; width: 1200px; height: 200px;">
								<asp:GridView ID="GVProductosOrdenes" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="false" HorizontalAlign="Center"
									CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
									PageSize="7" Width="100%" OnPageIndexChanging="GVProductosOrdenes_PageIndexChanging">
									<Columns>
										<asp:BoundField DataField="ID_PRODUCTO" HeaderText="ID Producto" SortExpression="ID_PRODUCTO" />
										<asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" SortExpression="DESCRIPCION" />
										<asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" SortExpression="CANTIDAD" />
										<asp:BoundField DataField="PRECIO" HeaderText="Precio" SortExpression="PRECIO" />
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
						<td colspan="3" style="height: 46px"></td>
					</tr>
					<tr>
						<td style="height: 21px">
							<asp:Label ID="Label11" runat="server" Text="FOLIO" Font-Bold="True"></asp:Label></td>
						<td colspan="2" style="height: 21px">
							<asp:TextBox ID="TBFolio" runat="server" CssClass="form-control" Width="150px" Enabled="False"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="height: 21px">
							<asp:Label ID="Label8" runat="server" Text="MONEDA" Font-Bold="True"></asp:Label></td>
						<td colspan="2" style="height: 21px">
							<asp:TextBox ID="TBMoneda" runat="server" CssClass="form-control" Width="223px" Enabled="False"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="height: 21px">
							<asp:Label ID="Label1" runat="server" Text="SUBTOTAL" Font-Bold="True"></asp:Label></td>
						<td colspan="2" style="height: 21px">
							<asp:TextBox ID="TBSubtotal" runat="server" CssClass="form-control" Width="223px" Enabled="False">0</asp:TextBox>
						</td>
					</tr>
					<tr>
						<td>
						<asp:Label ID="Label3" runat="server" Text="DESCUENTO" Font-Bold="True"></asp:Label></td>
					<td style="width: 223px" colspan="2">
						<asp:TextBox ID="TBDescuento" runat="server" CssClass="form-control" AutoPostBack="True">0</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label4" runat="server" Text="OTROS CARGOS" Font-Bold="True"></asp:Label></td>
					<td style="width: 223px" colspan="2">
						<asp:TextBox ID="TBOtrosCargos" runat="server" CssClass="form-control" AutoPostBack="True">0</asp:TextBox>
					</td>
				</tr>
					<tr>
						<td style="height: 20px">
							<asp:Label ID="Label5" runat="server" Text="FLETE" Font-Bold="True"></asp:Label></td>
						<td style="width: 223px;" colspan="2">
							<asp:TextBox ID="TBFlete" runat="server" CssClass="form-control" AutoPostBack="True">0</asp:TextBox>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label ID="Label6" runat="server" Text="IMPUESTO" Font-Bold="True"></asp:Label></td>
						<td style="width: 223px" colspan="2">
							<asp:TextBox ID="TBImpuestos" runat="server" CssClass="form-control" Enabled="False">0</asp:TextBox>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label ID="Label7" runat="server" Text="TOTAL" Font-Bold="True"></asp:Label></td>
						<td style="width: 223px" colspan="2">
							<asp:TextBox ID="TBTotal" runat="server" CssClass="form-control" Enabled="False">0</asp:TextBox>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label ID="Label9" runat="server" Text="COMENTARIOS" Font-Bold="True"></asp:Label></td>
						<td style="width: 223px" colspan="2">
							<asp:TextBox ID="TBComentarios" runat="server" Width="600px" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td>
						<asp:Label ID="Label10" runat="server" Text="ENVIAR" Font-Bold="True"></asp:Label></td>
					<td style="width: 223px" colspan="2">
						<asp:TextBox ID="TBEnviar" runat="server" Width="600px" CssClass="form-control"></asp:TextBox>
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
						<td colspan="3"></td>
					</tr>
				</table>
			</asp:View>
			<asp:View ID="VAdministracion" runat="server">
				<table style="width: 100%;">
					<tr>
						<td colspan="3">
							<asp:ImageButton ID="IMBRegresar" runat="server" Text="Regresar" ImageUrl="~/Imagenes/IMRegresar.png" CssClass="button" Width="80px" />
							<asp:ImageButton ID="IMAplicar" runat="server" ImageUrl="~/Imagenes/IMAutorizar.png" OnClientClick="return confirm('Estas seguro de realizar esta accion')" Width="80px" />
							<asp:ImageButton ID="IMSalir" runat="server" Text="Salir" ImageUrl="~/Imagenes/IMSalir.png" CssClass="button" Width="80px" />
						</td>
					</tr>
					<tr>
						<td colspan="3">
							
						</td>
					</tr>
					<tr>
						<td colspan="3">
							
							<asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Orden de compra"></asp:Label>
							
						</td>
					</tr>
					<tr>
						<td colspan="3">
							
						</td>
					</tr>
					<tr>
						<td style="height: 21px">
							<asp:Label ID="Label13" runat="server" Text="Tipo" Font-Bold="True"></asp:Label>
						</td>
						<td colspan="2" style="height: 21px">
							<asp:DropDownList ID="DDTipoOrdenCompra2" runat="server" Width="200px" CssClass="form-control">
								<asp:ListItem Selected="True" Value="I">Internacionales</asp:ListItem>
								<asp:ListItem Value="N">Nacionales</asp:ListItem>
								<asp:ListItem Value="X">Indirectas</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="height: 21px">
							
							<asp:Label ID="Label14" runat="server" Text="Accion" Font-Bold="True"></asp:Label>
							
						</td>
						<td colspan="2" style="height: 21px">
							<asp:DropDownList ID="DDAccion" runat="server" Width="200px" CssClass="form-control">
								<asp:ListItem Selected="True" Value="1">Cancelar</asp:ListItem>
								<asp:ListItem Value="2">Regresar</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="height: 21px">
							<asp:Label ID="Label15" runat="server" Text="No. de Orden" Font-Bold="True"></asp:Label>
						</td>
						<td colspan="2" style="height: 21px">
							<asp:TextBox ID="TBNoOrden" runat="server" CssClass="form-control" Width="150px" Enabled="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="height: 21px">
							<asp:Label ID="Label16" runat="server" Text="Comentarios" Font-Bold="True"></asp:Label>
						</td>
						<td colspan="2" style="height: 21px">
							<asp:TextBox ID="TBComentariosAccion" runat="server" CssClass="form-control" Width="500px" Enabled="True" TextMode="MultiLine"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="height: 21px"></td>
						<td colspan="2" style="height: 21px"></td>
					</tr>
						<tr>
						<td style="height: 21px"></td>
						<td colspan="2" style="height: 21px"></td>
					</tr>
						<tr>
						<td style="height: 21px"></td>
						<td colspan="2" style="height: 21px"></td>
					</tr>
						<tr>
						<td style="height: 21px"></td>
						<td colspan="2" style="height: 21px"></td>
					</tr>
						<tr>
						<td style="height: 21px"></td>
						<td colspan="2" style="height: 21px"></td>
					</tr>
						<tr>
						<td style="height: 21px"></td>
						<td colspan="2" style="height: 21px"></td>
					</tr>
				</table>
			</asp:View>
		</asp:MultiView>
</asp:Content>
