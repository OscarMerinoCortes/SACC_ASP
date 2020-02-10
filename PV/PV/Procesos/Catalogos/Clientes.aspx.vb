Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls
Imports System.Web.UI

Public Class Clientes
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Page.IsPostBack Then
			Limpiar()
			ConsultarClientes()
			MultiView1.SetActiveView(VConsulta)
		End If
	End Sub

	Protected Sub BTNNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles BTNuevo.Click
		Limpiar()
		MultiView1.SetActiveView(VRegistro)
	End Sub

	Protected Sub BTNGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles BTNGuardar.Click
		Dim cnn As New SqlConnection(abrirConexion)
		Dim sqlcom1 As SqlCommand
		Try
			If TBID.Text = "" Then
				TBID.Text = 0
			End If
			cnn.Open()
			sqlcom1 = New SqlCommand("InsertarCliente", cnn)
			sqlcom1.CommandType = CommandType.StoredProcedure
			sqlcom1.Parameters.Clear()
			sqlcom1.Parameters.Add(New SqlParameter("@ID_CLIENTE", CInt(TBID.Text)))
			sqlcom1.Parameters.Add(New SqlParameter("@NOMBRE", Convert.ToString(TBNombre.Text)))
			sqlcom1.Parameters.Add(New SqlParameter("@NOMBRE_COMERCIAL", Convert.ToString(TBNombreComercial.Text)))
			sqlcom1.Parameters.Add(New SqlParameter("@RFC", Convert.ToString(TBRFC.Text)))
			sqlcom1.Parameters.Add(New SqlParameter("@TELEFONO_CASA", Convert.ToString(TBTelefono.Text)))
			sqlcom1.Parameters.Add(New SqlParameter("@TELEFONO_TRABAJO", Convert.ToString(TBTelefono.Text)))
			sqlcom1.Parameters.Add(New SqlParameter("@PAIS", TBPais.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@DIAS_CREDITO", Convert.ToString(0)))
			sqlcom1.Parameters.Add(New SqlParameter("@FAX", TBFax.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@CONTACTO", TBContacto.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@DIRECCION", TBDireccion.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@COMENTARIOS", TBComentarios.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@CIUDAD", TBCiudad.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@COLONIA", TBColonia.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@DESCUENTO", 0))
			sqlcom1.Parameters.Add(New SqlParameter("@ID_DESCUENTO", ""))
			sqlcom1.Parameters.Add(New SqlParameter("@ID_AGENTE", Convert.ToString(0)))
			sqlcom1.Parameters.Add(New SqlParameter("@NUMERO_EXTERIOR", Convert.ToString(TBNumeroExterior.Text)))
			sqlcom1.Parameters.Add(New SqlParameter("@NUMERO_INTERIOR", Convert.ToString(TBNumeroInterior.Text)))
			sqlcom1.Parameters.Add(New SqlParameter("@CURP", TBCURP.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@CP", Convert.ToString(TBCP.Text)))
			sqlcom1.Parameters.Add(New SqlParameter("@EMAIL", TBCorreoElectronico.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@WEB_PASSWORD", ""))
			sqlcom1.Parameters.Add(New SqlParameter("@ESTADO", TBEstado.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@FECHA_ALTA", Convert.ToString(Now.Date)))
			sqlcom1.Parameters.Add(New SqlParameter("@LIMITE_CREDITO", TBLimiteCredito.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@DIRECCION_ENVIO", ""))
			sqlcom1.Parameters.Add(New SqlParameter("@VALORACION", TBValoracion.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@LEYENDAS", "S"))
			sqlcom1.Parameters.Add(New SqlParameter("@AGENTE", TBAgente.Text))
			sqlcom1.Parameters.Add(New SqlParameter("@ASIG", "N"))
			sqlcom1.Parameters.Add(New SqlParameter("@RECIBO", ""))
			sqlcom1.Parameters.Add(New SqlParameter("@Adenda_ID_facturaglobal", 0))
			sqlcom1.Parameters.Add(New SqlParameter("@Adenda_proveedor", ""))
			sqlcom1.Parameters.Add(New SqlParameter("@Adenda_contrato", ""))
			sqlcom1.Parameters.Add(New SqlParameter("@Adenda_unidad_negocio", ""))
			sqlcom1.Parameters.Add(New SqlParameter("@Adenda_pedido", ""))
			sqlcom1.Parameters.Add(New SqlParameter("@Adenda_fianza", ""))
			sqlcom1.Parameters.Add(New SqlParameter("@Adenda_afianzadora", ""))
			sqlcom1.Parameters.Add(New SqlParameter("@Adenda_alta", ""))
			sqlcom1.Parameters.Add(New SqlParameter("@Num_cuenta_pago_cliente", Convert.ToString(TBCuentaPago.Text)))
			sqlcom1.Parameters.Add(New SqlParameter("@Flag_extranjero", ChkExtranjero.Checked))
			sqlcom1.Parameters.Add(New SqlParameter("@Clave_CFDI", TBClaveCFDI.Text))
			If TBID.Text = 0 Then
				sqlcom1.Parameters("@ID_CLIENTE").Direction = ParameterDirection.InputOutput
			End If
			sqlcom1.ExecuteNonQuery()
			TBID.Text = sqlcom1.Parameters("@ID_CLIENTE").Value
			cnn.Close()
		Catch ex As Exception
			ex.Message.ToString()
		End Try
	End Sub

	Protected Sub BTNFiltroBuscar_Click(sender As Object, e As EventArgs) Handles BTNFiltroBuscar.Click
		ConsultarClientes()
	End Sub

	Private Sub ConsultarClientes()
		Dim cnn As New SqlConnection(abrirConexion)
		cnn.Open()
		Dim cmd As New SqlCommand("ConsultarClientes", cnn)
		cmd.CommandType = CommandType.StoredProcedure
		cmd.Parameters.Add(New SqlClient.SqlParameter("@Descripcion", TBFiltroDescripcion.Text))
		Dim da As New SqlDataAdapter(cmd)
		Dim dt As New DataTable
		da.Fill(dt)
		GVListaClientes.AutoGenerateColumns = False
		GVListaClientes.DataSource = dt
		GVListaClientes.DataBind()
		Session("TablaClientes") = dt
		cnn.Close()
	End Sub

	Private Sub Limpiar()
		TBID.Text = ""
		TBNombre.Text = ""
		TBNombreComercial.Text = ""
		TBRFC.Text = ""
		TBCURP.Text = ""
		TBTelefono.Text = ""
		TBDireccion.Text = ""
		TBNumeroExterior.Text = ""
		TBNumeroInterior.Text = ""
		TBColonia.Text = ""
		TBCiudad.Text = ""
		TBEstado.Text = ""
		TBPais.Text = ""
		TBCP.Text = ""
		TBFax.Text = ""
		TBCorreoElectronico.Text = ""
		TBLimiteCredito.Text = ""
		TBValoracion.Text = ""
		TBContacto.Text = ""
		TBAgente.Text = ""
		TBComentarios.Text = ""
	End Sub
	Protected Sub BTNSeleccionar_OnClick(sender As Object, e As EventArgs)
		Dim TablaClientes As New DataTable()
		Dim Tabla As New DataTable()
		TablaClientes = Session("TablaClientes")
		Dim cnn As New SqlConnection(abrirConexion)
		Dim TBSeleccionar As LinkButton = CType(sender, LinkButton)
		Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBSeleccionar.Parent, DataControlFieldCell).Parent, GridViewRow)
		Dim Renglon As Integer = gvrFilaActual.RowIndex
		TBID.Text = CInt(TablaClientes.Rows(Renglon).Item("ID_CLIENTE"))
		cnn.Open()
		Dim cmd As New SqlCommand("ConCliPorId", cnn)
		cmd.CommandType = CommandType.StoredProcedure
		cmd.Parameters.Add(New SqlClient.SqlParameter("@IdCliente", TBID.Text))
		Dim da As New SqlDataAdapter(cmd)
		Dim dt As New DataTable
		da.Fill(Tabla)
		TBNombre.Text = Tabla.Rows(0).Item("NOMBRE")
		TBNombreComercial.Text = Tabla.Rows(0).Item("NOMBRE_COMERCIAL")
		TBRFC.Text = Tabla.Rows(0).Item("RFC")
		TBCURP.Text = Tabla.Rows(0).Item("CURP")
		TBTelefono.Text = Tabla.Rows(0).Item("TELEFONO_CASA")
		TBDireccion.Text = Tabla.Rows(0).Item("DIRECCION")
		TBNumeroExterior.Text = Tabla.Rows(0).Item("NUMERO_EXTERIOR")
		TBNumeroInterior.Text = Tabla.Rows(0).Item("NUMERO_INTERIOR")
		TBColonia.Text = Tabla.Rows(0).Item("COLONIA")
		TBCiudad.Text = Tabla.Rows(0).Item("CIUDAD")
		TBEstado.Text = Tabla.Rows(0).Item("ESTADO")
		TBPais.Text = Tabla.Rows(0).Item("PAIS")
		TBCP.Text = Tabla.Rows(0).Item("CP")
		TBFax.Text = Tabla.Rows(0).Item("FAX")
		TBCorreoElectronico.Text = Tabla.Rows(0).Item("EMAIL")
		TBLimiteCredito.Text = Tabla.Rows(0).Item("LIMITE_CREDITO")
		TBValoracion.Text = Tabla.Rows(0).Item("VALORACION")
		TBContacto.Text = Tabla.Rows(0).Item("CONTACTO")
		TBAgente.Text = Tabla.Rows(0).Item("AGENTE")
		TBComentarios.Text = Tabla.Rows(0).Item("COMENTARIOS")
		MultiView1.SetActiveView(VRegistro)
	End Sub

	Protected Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
		Response.Redirect("~/")
	End Sub

	Protected Sub BTNConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles BTNConsultar.Click
		ConsultarClientes()
		MultiView1.SetActiveView(VConsulta)
	End Sub
End Class