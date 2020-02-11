<%@ Page Title="Requisicion de Compra" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequisicionCompra.aspx.vb" Inherits="PV.RequisicionCompra" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
		<link href="../../../Content/StyleSheet.css" rel="stylesheet" type="text/css">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="VRegistro" runat="server">
				<br />
                <table style="width: 100%;">
                    <tr>
                        <td colspan="3">
                            <asp:ImageButton ID="BTNuevo" runat="server" Text="Nuevo" ImageUrl="~/Imagenes/IMNuevo.png"  CssClass="button" Width="80px"/>
                            
							<asp:ImageButton ID="BTNConsultar" runat="server" Text="Consultar" ImageUrl="~/Imagenes/IMConsultar.png" CausesValidation="true" ValidationGroup="BTNGuardar" CssClass="button" Width="80px"/>
							<asp:ImageButton ID="BTNSalir" runat="server" Text="Salir" ImageUrl="~/Imagenes/IMSalir.png" CssClass="button" Width="80px" />
						</td>
					</tr>
					<tr>
						<td colspan="3" style="width: 169px; height: 21px;"></td>
					</tr>
					<tr>
						<td style="width: 21px"><label>Clave</label></td>
						<td style="height: 24px; width: 731px;">
							<asp:TextBox ID="Text2" runat="server" CssClass="form-control" Width="122px"></asp:TextBox>
						</td>
                    </tr>
					   <tr>
                        <td style="width: 21px; height: 24px;"><label>Marcas</label></td>
						<td style="height: 24px; width: 731px;">
							
							<asp:DropDownList ID="Combo2" runat="server" CssClass="form-control" Width="150">
								<asp:ListItem Selected="True" Value="0">Todas</asp:ListItem>
							</asp:DropDownList>
							
						</td>

					   </tr>
					<tr>
						<td style="width: 21px"><label>Almacen</label></td>
						<td style="height: 24px; width: 731px;">

							<asp:DropDownList ID="Combo1" runat="server" CssClass="form-control" Width="150">
								<asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
								<asp:ListItem Value="1">ALMACEN 1</asp:ListItem>
								<asp:ListItem Value="2">ALMACEN 2</asp:ListItem>
								<asp:ListItem Value="3">ALMACEN 3</asp:ListItem>
							</asp:DropDownList>

						</td>

					</tr>
					<tr>
						<td style="width: 21px">&nbsp;</td>
						<td style="height: 24px; width: 731px;"></td>
						<tr>
							<td colspan="2">
								<div style="overflow: auto; width: 1200px; height: 200px;">
									<asp:GridView ID="GVProductos" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="false" HorizontalAlign="Center"
									CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
									PageSize="7" Width="100%" OnPageIndexChanging="GVProductos_PageIndexChanging">
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
											<asp:BoundField DataField="FECHA" HeaderText="Fecha" SortExpression="FECHA" />
											<asp:BoundField DataField="COMENTARIO" HeaderText="Comentarios" SortExpression="COMENTARIO" />
											<asp:BoundField DataField="URGENTE" HeaderText="Prioridad" SortExpression="URGENTE" />
										<%--	<asp:TemplateField HeaderText="Cantidad">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TBCantidadRequisicion" runat="server" AutoPostBack="false" Text='<%# DataBinder.Eval(Container.DataItem, "Cantidad")%>' Visible="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
										</Columns>
									</asp:GridView>
                            </div>
                        </td>
                    </tr>
					<tr>
						<td colspan="3" style="height: 33px">
							
						 </td>
                    </tr>
					<tr>
                        <td style="width: 21px"><asp:Button ID="BTNAgregar" runat="server" Text="Agregar a requisicion" CssClass="form-control" CausesValidation="true" Width="186px" /></td>
                    </tr>
					<tr>
						<td colspan="3">
							
						 </td>
                    </tr>
                </table>
            </asp:View>
			 <asp:View ID="VAsignarProvedor" runat="server">
                <table style="width: 100%;">
					<tr style="text-align: left;">
						<td colspan="6" style="height: 30px"></td>
					</tr>
					<tr style="text-align: left;">
						<td colspan="6" style="height: 28px">
							<asp:ImageButton ID="BTNGuardar" runat="server" CausesValidation="true" CssClass="button" ImageUrl="~/Imagenes/IMGuardar.png" Text="Guardar" ValidationGroup="BTNGuardar" Width="80px" />
							<asp:ImageButton ID="BTNConsultarRequisiciones" runat="server" CausesValidation="true" CssClass="button" ImageUrl="~/Imagenes/IMConsultar.png" Text="Guardar" ValidationGroup="BTNGuardar" Width="80px" />
						<asp:ImageButton ID="BTNRegresarx2" runat="server" CausesValidation="true" CssClass="button" ImageUrl="~/Imagenes/IMRegresar.png" Text="Regresar" ValidationGroup="BTNRegresar" Width="80px" />
						</td>
					</tr>
					<tr style="text-align: left;">
						<td colspan="6" style="height: 30px"></td>
					</tr>
					<tr style="text-align: left;">
						<td style="width: 110px"><label style="width: 163px">Nombre del proveedor</label></td>
						<td style="height: 24px; width: 731px;">
							<asp:TextBox ID="Text6" runat="server" Width="475px" CssClass="form-control"></asp:TextBox>
							<asp:Button ID="BTNFiltar" runat="server" CssClass="form-control" Text="Filtrar" Width="100px" />
						</td>
						<td colspan="6">

							&nbsp;</td>
					</tr>
					<tr style="text-align: left;">
						<td style="width: 110px"></td>
						<td style="height: 24px; width: 731px;">
							
						</td>
						<td colspan="6">
							&nbsp;</td>
					</tr>
					<tr>
						<td colspan="6">
							<div style="overflow: auto; width: 1200px; height: 300px;">
								<asp:GridView ID="GVProvedores" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="false" HorizontalAlign="Center"
									CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
									PageSize="7" Width="100%" OnPageIndexChanging="GVProvedores_PageIndexChanging">
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
										<asp:BoundField DataField="TELEFONO1" HeaderText="Telefono" SortExpression="TELEFONO1" />
										<asp:BoundField DataField="DIRECCION" HeaderText="Direccion" SortExpression="DIRECCION" />
										<asp:BoundField DataField="NOTAS" HeaderText="Notas" SortExpression="NOTAS" />
										<%--<asp:BoundField DataField="Observaciones" HeaderText="Observacion" SortExpression="Observaciones" />--%>
										<%--<asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />--%>
									</Columns>
								</asp:GridView>
							</div>
						</td>
					</tr>
					<tr style="text-align: left;">
						<td style="width: 110px"></td>
						<td style="height: 24px; width: 731px;">
							
						</td>
						<td colspan="6">&nbsp;</td>
					</tr>
					<tr style="text-align: left;">
						<td style="width: 110px"><label style="width: 163px">ID del proveedor</label></td>
						<td style="height: 24px; width: 731px;">
							<asp:TextBox ID="TBIdProveedor" runat="server" CssClass="form-control" Width="122px"></asp:TextBox>
						</td>
						<td colspan="6">&nbsp;</td>
					</tr>
					<tr style="text-align: left;">
						<td style="width: 110px"><label style="width: 163px">Nombre</label></td>
						<td style="height: 24px; width: 731px;">
							<asp:TextBox ID="TBNombreProveedor" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
							<asp:Button ID="BTNAgregarProductos" runat="server" Text="Agregar productos" CssClass="form-control" Width="300px" />
						</td>
						<td colspan="6">&nbsp;</td>
					</tr>
					<tr style="text-align: left;">
						<td style="width: 110px"></td>
						<td style="height: 24px; width: 731px;">
							
						</td>
						<td colspan="6">
							&nbsp;</td>
					</tr>
					<tr style="text-align: center;">
						<td colspan="6">
							<div style="overflow: auto; width: 1200px; height: 300px;">
								<asp:GridView ID="GVAgregados" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="false" HorizontalAlign="Center"
									CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
									PageSize="7" Width="100%" OnPageIndexChanging="GVAgregados_PageIndexChanging">
									<Columns>
										<asp:TemplateField>
											<HeaderTemplate>
												Eliminar
											</HeaderTemplate>
											<ItemTemplate>
												<asp:LinkButton ID="BTNEliminar" runat="server" ForeColor="Blue" OnClick="BTNEliminar_OnClick" ShowSelectButton="True" Text="Eliminar" AutoPostBack="false" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:BoundField DataField="ID_PRODUCTO" HeaderText="ID Producto" SortExpression="ID_PRODUCTO" />
										<asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" SortExpression="DESCRIPCION" />
										<asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" SortExpression="CANTIDAD" />
										<asp:BoundField DataField="FECHA" HeaderText="Fecha" SortExpression="FECHA" />
										<%--<asp:BoundField DataField="URGENTE" HeaderText="Urgente" SortExpression="URGENTE" />--%>
									</Columns>
								</asp:GridView>
							</div>
						</td>
					</tr>
				</table>
            </asp:View>
			   <asp:View ID="VRequisicionesNoCerradas" runat="server">
                <table style="width: 100%;">
					<tr style="text-align: left;">
                        <td colspan="7" style="height: 44px"></td>
                    </tr>
					<tr style="text-align: left;">
                        <td colspan="7" style="height: 38px"><asp:ImageButton ID="BTNRegresar" runat="server" CausesValidation="true" CssClass="button" ImageUrl="~/Imagenes/IMRegresar.png" Text="Regresar" ValidationGroup="BTNRegresar" Width="80px" Height="33px" /></td>
                    </tr>
					<tr style="text-align: left;">
                        <td colspan="7"></td>
                    </tr>
					<tr style="text-align: left;">
                        <td style="width: 151px"><label>No. de Requisicion</label></td>
						<td style="height: 24px; width: 731px;">
							<asp:TextBox ID="TBIdRequisicionPendiente" runat="server" CssClass="form-control" Width="122px"></asp:TextBox>
							<asp:Button ID="BTNBuscarRequisicionId" runat="server" CssClass="form-control" Text="Buscar" Width="100px" />
						</td>
                    </tr>
					<tr style="text-align: left;">
						<td colspan="7"></td>
					</tr>
					<tr style="text-align: center;">
						<td colspan="7">
							<div style="overflow: auto; width: 1200px; height: 200px;">
								<asp:GridView ID="GVRequisicionesPendientes" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="false" HorizontalAlign="Center"
									CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
									PageSize="7" Width="100%" OnPageIndexChanging ="GVRequisicionesPendientes_PageIndexChanging">
								<Columns>
										<asp:TemplateField>
											<HeaderTemplate>
												Seleccionar
											</HeaderTemplate>
											<ItemTemplate>
												<asp:LinkButton ID="BTNSeleccionarRequiPend" runat="server" ForeColor="Blue" OnClick="BTNSeleccionarRequiPend_OnClick" ShowSelectButton="True" Text="Seleccionar" AutoPostBack="false" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:BoundField DataField="FOLIO" HeaderText="Folio" SortExpression="FOLIO" />
										<%--<asp:BoundField DataField="ID_PROVEEDOR" HeaderText="ID Proveedor" SortExpression="ID_PROVEEDOR" />
										<asp:BoundField DataField="NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE" />--%>
										<%--<asp:BoundField DataField="COMENTARIO" HeaderText="Comentario" SortExpression="COMENTARIO" />--%>
										<%--<asp:BoundField DataField="URGENTE" HeaderText="Urgente" SortExpression="URGENTE" />--%>
									</Columns>
								</asp:GridView>
							</div>
						</td>
					</tr>
					<tr style="text-align: left;">
						<td colspan="6"></td>
					</tr>
					<tr style="text-align: left;">
						<td colspan="6"></td>
					</tr>
					<tr style="text-align: center;">
						<td colspan="7">
							<div style="overflow: auto; width: 1200px; height: 200px;">
								<asp:GridView ID="GVProductosRequisicionesPendientes" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="false" HorizontalAlign="Center"
									CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
									PageSize="7" Width="100%" OnPageIndexChanging ="GVProductosRequisicionesPendientes_PageIndexChanging">
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
											<asp:BoundField DataField="FECHA" HeaderText="Fecha" SortExpression="FECHA" />
											<%--<asp:BoundField DataField="COMENTARIO" HeaderText="Comentarios" SortExpression="COMENTARIO" />
											<asp:BoundField DataField="URGENTE" HeaderText="Prioridad" SortExpression="URGENTE" />--%>
											<%--<asp:TemplateField HeaderText="Cantidad">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TBCantidadRequisicion" runat="server" AutoPostBack="false" Text='<%# DataBinder.Eval(Container.DataItem, "Cantidad")%>' Visible="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
										</Columns>
									</asp:GridView>
							</div>
						</td>
					</tr>
					<tr style="text-align: left;">
						<td colspan="6"></td>
					</tr>
					<tr style="text-align: left;">
                        <td colspan="6"><asp:Button ID="BTNCerrarRequisicion" runat="server" Text="Cerrar Requisicion" CssClass="form-control" Width="300px" /></td>
					</tr>
                </table>
            </asp:View>
        </asp:MultiView>
</asp:Content>
