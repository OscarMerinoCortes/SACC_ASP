<%@ Page Title="Clientes" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.vb" Inherits="PV.Clientes" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
		<link href="../../Content/StyleSheet.css" rel="stylesheet" type="text/css">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="VRegistro" runat="server">
				<br />
                <table style="width: 100%;">
                    <tr>
                        <td colspan="4">
                            <asp:ImageButton ID="BTNGuardar" runat="server" Text="Guardar" ImageUrl="~/Imagenes/IMGuardar.png" CausesValidation="true" ValidationGroup="BTNGuardar" Width="80px" />
							<asp:ImageButton ID="BTNConsultar" runat="server" Text="Consultar" ImageUrl="~/Imagenes/IMConsultar.png" CausesValidation="true" ValidationGroup="BTNGuardar" Width="80px" />
                            <asp:ImageButton ID="BTNSalir" runat="server" Text="Salir" ImageUrl="~/Imagenes/IMSalir.png" CssClass="button" Width="80px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 28px" ></td>
                    </tr>
                    <tr>
                        <td>ID</td>
                        <td>
							<asp:TextBox ID="TBID" runat="server" Enabled="False" Width="150px" CssClass="form-control"></asp:TextBox>
						</td>
                        <td>Pais</td>
						<td>
							<asp:TextBox ID="TBPais" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						</td>
                    </tr>
                     <tr>
                        <td>Nombre</td>
                        <td>
							<asp:TextBox ID="TBNombre" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						 </td>
                        <td>CP</td>
						<td>
							<asp:TextBox ID="TBCP" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						 </td>
                    </tr>
                  <tr>
                        <td>Nombre Comercial</td>
                        <td>
							<asp:TextBox ID="TBNombreComercial" runat="server" Width="300px" CssClass="form-control"></asp:TextBox>
						</td>
                        <td>Fax</td>
						<td>
							<asp:TextBox ID="TBFax" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						</td>
                    </tr>
                  <tr>
                        <td>RFC</td>
                        <td>
							<asp:TextBox ID="TBRFC" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						</td>
                        <td>Correo Electronico</td>
						<td>
							<asp:TextBox ID="TBCorreoElectronico" runat="server" Width="300px" CssClass="form-control"></asp:TextBox>
						</td>
                    </tr>
					 <tr>
                        <td style="height: 20px">CURP</td>
                        <td style="height: 20px">
							<asp:TextBox ID="TBCURP" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						 </td>
                        <td style="height: 20px">Limite de Credito</td>
						<td style="height: 20px">
							<asp:TextBox ID="TBLimiteCredito" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						 </td>
                    </tr>
					<tr>
                        <td>Celular / Telefono Casa</td>
                        <td>
							<asp:TextBox ID="TBTelefono" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						</td>
                        <td>Valoracion</td>
						<td>
							<asp:TextBox ID="TBValoracion" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						</td>
                    </tr>
					<tr>
                        <td>Direccion</td>
                        <td>
							<asp:TextBox ID="TBDireccion" runat="server" Width="300px" CssClass="form-control"></asp:TextBox>
						</td>
                        <td>Contacto</td>
						<td>
							<asp:TextBox ID="TBContacto" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						</td>
                    </tr>
					 <tr>
                        <td style="height: 20px">Numero Exterior</td>
                        <td style="height: 20px">
							<asp:TextBox ID="TBNumeroExterior" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						 </td>
                        <td style="height: 20px">Agente</td>
						<td style="height: 20px">
							<asp:TextBox ID="TBAgente" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						 </td>
                    </tr>
					 <tr>
                        <td style="height: 20px">Numero Interior</td>
                        <td style="height: 20px">
							<asp:TextBox ID="TBNumeroInterior" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						 </td>
                        <td style="height: 20px">Clave CFDI</td>
						<td style="height: 20px">
							<asp:TextBox ID="TBClaveCFDI" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						 </td>
                    </tr>
					 <tr>
                        <td style="height: 20px">Colonia</td>
                        <td style="height: 20px">
							<asp:TextBox ID="TBColonia" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						 </td>
                        <td style="height: 20px">Cuenta pago</td>
						<td style="height: 20px">
							<asp:TextBox ID="TBCuentaPago" runat="server" Width="300px" CssClass="form-control"></asp:TextBox>
						 </td>
                    </tr>
					<tr>
                        <td>Ciudad</td>
                        <td>
							<asp:TextBox ID="TBCiudad" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						</td>
                        <td>&nbsp;</td>
						<td>
							<asp:CheckBox ID="ChkExtranjero" runat="server" Text="Extranjero" CssClass="form-control" />
						</td>
                    </tr>
                    <tr>
                        <td>Estado</td>
                        <td>
							<asp:TextBox ID="TBEstado" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
						</td>
                        <td>Comentarios</td>
						<td>
							<asp:TextBox ID="TBComentarios" runat="server" Height="51px" TextMode="MultiLine" Width="500px" CssClass="form-control"></asp:TextBox>
						</td>
                    </tr>
                    <tr>
						<td></td>
						<td></td>
						<td></td>
						<td>
							&nbsp;</td>
					</tr>
					<tr>
						<td colspan="4">&nbsp;</td>
					</tr>
				</table>
			</asp:View>
			<asp:View ID="VConsulta" runat="server">
				<table style="width: 100%;">
					<tr style="text-align: left;">
						<td style="width: 85px; height: 17px;"></td>
						<td style="height: 17px"></td>
					</tr>
					<tr style="text-align: left;">
						<td style="width: 85px; height: 20px;"></td>
						<td style="height: 20px">
							<asp:ImageButton ID="BTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" Text="Nuevo" Width="80px" />
						</td>
                    </tr>
					<tr style="text-align: left;">
                        <td style="width: 85px"></td>
						<td>&nbsp;</td>
                    </tr>
					<tr >
                        <td style="width: 10px">
							<asp:Label ID="Label1" runat="server" Text="Nombre" Font-Bold="True"></asp:Label>
						</td>
						<td>
							<asp:TextBox ID="TBFiltroDescripcion" runat="server" Width="600px" CssClass="form-control"></asp:TextBox>
						</td>
                    </tr>
					<tr style="text-align: left;">
                        <td style="width: 85px; height: 33px;"></td>
						<td style="height: 33px">
							<asp:Button ID="BTNFiltroBuscar" runat="server" Text="Filtrar" CssClass="form-control" Width="100px" />
						</td>
                    </tr>
					<tr style="text-align: left;">
                        <td style="width: 85px; height: 19px;"></td>
						<td style="height: 19px"></td>
                    </tr>
                    <tr style="text-align: left;">
                        <td colspan="6">
							<div style="overflow:auto; width:1200px; height:500px;">
                            <asp:GridView ID="GVListaClientes" runat="server" AllowPaging="false" CssClass="mGrid" HorizontalAlign="Center" Width="100%">
								 <Columns>
									<asp:TemplateField>
										<HeaderTemplate>
											Seleccionar
										</HeaderTemplate>
										<ItemTemplate>
											<asp:LinkButton ID="BTNSeleccionar" runat="server" ForeColor="Blue" OnClick="BTNSeleccionar_OnClick" ShowSelectButton="True" Text="Seleccionar" />
										</ItemTemplate>
									</asp:TemplateField>
									 <asp:BoundField DataField="ID_CLIENTE" HeaderText="Id Cliente" SortExpression="ID_CLIENTE" />
									 <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE" />
									 <asp:BoundField DataField="NOMBRE_COMERCIAL" HeaderText="Nombre Comercial" SortExpression="NOMBRE_COMERCIAL" />
									 <asp:BoundField DataField="RFC" HeaderText="RFC" SortExpression="RFC" />
									 <asp:BoundField DataField="CIUDAD" HeaderText="Ciudad" SortExpression="CIUDAD" />
									 <asp:BoundField DataField="TELEFONO_CASA" HeaderText="Telefono Casa" SortExpression="TELEFONO_CASA" />
									 <asp:BoundField DataField="TELEFONO_TRABAJO" HeaderText="Telefono Trabajo" SortExpression="TELEFONO_TRABAJO" />
								 </Columns>
							</asp:GridView>
							</div>
						</td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
</asp:Content>
