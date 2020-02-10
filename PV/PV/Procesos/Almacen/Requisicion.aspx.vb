Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls
Imports System.Web.UI

Public Class Inventario
    Inherits System.Web.UI.Page
    Public TablaGuardar As New DataTable()
	Public VistaGuardar As New DataView()
	Private TablaCompraDetalle As New DataTable()
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
			Limpiar()
			LlenarCombos()
			GenerarTablaGuardar()
			MultiView1.SetActiveView(VRegistro)
		End If
    End Sub

	Protected Sub BTNNuevo_Click(sender As Object, e As EventArgs) Handles BTNuevo.Click
		LlenarCombos()
		Limpiar()
	End Sub
	Protected Sub BTNConsultarProductos_Click(sender As Object, e As EventArgs) Handles BTNConsultarProductos.Click
		Consultar()
	End Sub

	Protected Sub BTNGuardar_Click(sender As Object, e As EventArgs) Handles BTNGuardar.Click
		Dim cmdGuardar As SqlCommand
		Dim tabla As New DataTable()
        tabla = Session("TablaGuardar")
        If tabla.Rows.Count = 0 Then
            MsgBox("No hay productos en la lista",, "Informacion")
            Exit Sub
        End If
        Dim cnn As New SqlConnection(abrirConexion)
		Dim sqlcom1 As SqlCommand
        Try
            If TBIdRequisicionEncabezado.Text = "" Then
                TBIdRequisicionEncabezado.Text = 0
            End If
            cnn.Open()
            sqlcom1 = New SqlCommand("InsInvReqEnc", cnn)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdRequisicionEncabezado", TBIdRequisicionEncabezado.Text))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", DDIdSucursal.SelectedValue))
            sqlcom1.Parameters.Add(New SqlParameter("@IVTipo", "D"))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservaciones", TBObservacion.Text))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstatus", 1))
            sqlcom1.Parameters.Add(New SqlParameter("@INUsuarioCreacion", 1))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", Now))
            sqlcom1.Parameters.Add(New SqlParameter("@INUsuarioActualizacion", 1))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", Now))
            If TBIdRequisicionEncabezado.Text = 0 Then
                sqlcom1.Parameters("@INIdRequisicionEncabezado").Direction = ParameterDirection.InputOutput
            End If
            sqlcom1.ExecuteNonQuery()
            TBIdRequisicionEncabezado.Text = sqlcom1.Parameters("@INIdRequisicionEncabezado").Value
            For Each MiDataRow As DataRow In tabla.Rows
                cmdGuardar = New SqlCommand("InsInvReqDet", cnn)
                cmdGuardar.CommandType = CommandType.StoredProcedure
                cmdGuardar.Parameters.Clear()
                cmdGuardar.Parameters.Add(New SqlParameter("@INIdRequisicionDetalle", 0))
                cmdGuardar.Parameters.Add(New SqlParameter("@INIdRequisicionEncabezado", TBIdRequisicionEncabezado.Text))
                cmdGuardar.Parameters.Add(New SqlParameter("@IVIdProducto", MiDataRow("ID_PRODUCTO")))
                cmdGuardar.Parameters.Add(New SqlParameter("@IVDescripcion", MiDataRow("DESCRIPCION")))
                cmdGuardar.Parameters.Add(New SqlParameter("@IVAlmacen", MiDataRow("ALMACEN")))
                cmdGuardar.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("CANTIDAD")))
                cmdGuardar.Parameters.Add(New SqlParameter("@INIdEstatus", 1))
                cmdGuardar.Parameters.Add(New SqlParameter("@INUsuarioCreacion", 1))
                cmdGuardar.Parameters.Add(New SqlParameter("@IDFechaCreacion", Now))
                cmdGuardar.Parameters.Add(New SqlParameter("@INUsuarioActualizacion", 1))
                cmdGuardar.Parameters.Add(New SqlParameter("@IDFechaActualizacion", Now))
                cmdGuardar.ExecuteNonQuery()
            Next
            LBCampoRequerido.Text = ""
            cnn.Close()
        Catch ex As Exception
            ex.Message.ToString()
		End Try
        Limpiar()
        tabla.Clear()
    End Sub
	Protected Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Response.Redirect("~/")
    End Sub
	Private Sub Consultar()
		Dim cnn As New SqlConnection(abrirConexion)
		cnn.Open()
        Dim cmd As New SqlCommand("ConProAlmId", cnn)
		cmd.CommandType = CommandType.StoredProcedure
		cmd.Parameters.Add(New SqlClient.SqlParameter("@IdAlmacen", DDIdAlmacen.SelectedValue))
        cmd.Parameters.Add(New SqlClient.SqlParameter("@Descripcion", TBDescripcion.Text))
        Dim da As New SqlDataAdapter(cmd)
		Dim dt As New DataTable
		da.Fill(dt)
		GVProductos.AutoGenerateColumns = False
		GVProductos.DataSource = dt
		GVProductos.DataBind()
		Session("Tabla") = dt
		cnn.Close()
		If GVProductos.DataSource Is Nothing Then
			BTNAgregar.Visible = False
		Else
			BTNAgregar.Visible = True
		End If
	End Sub
	Private Sub LlenarCombos()
		'SUCURSAL
		Dim cnn As New SqlConnection(abrirConexion)
		Dim da As New SqlDataAdapter("CbConSucId", cnn)
		Dim dt As New DataTable("tabla")
		da.Fill(dt)
		Dim row1 As DataRow
		row1 = dt.NewRow()
		row1("ID") = -1
		row1("SUCURSAL") = "TODOS"
		dt.Rows.Add(row1)
		DDIdSucursal.DataSource = dt
		DDIdSucursal.DataTextField = "SUCURSAL"
		DDIdSucursal.DataValueField = "ID"
		DDIdSucursal.SelectedValue = -1
		DDIdSucursal.DataBind()
		'ALMACEN
		Dim tabla As DataTable = New DataTable("Tabla")
		tabla.Columns.Add("ID")
		tabla.Columns.Add("ALMACEN")
		Dim row As DataRow
		row = tabla.NewRow()
		row("ID") = -1
		row("ALMACEN") = "TODOS"
		tabla.Rows.Add(row)
		row = tabla.NewRow()
		row("ID") = 1
		row("ALMACEN") = "A1"
		tabla.Rows.Add(row)
		row = tabla.NewRow()
		row("ID") = 2
		row("ALMACEN") = "A2"
		tabla.Rows.Add(row)
		row = tabla.NewRow()
		row("ID") = 3
		row("ALMACEN") = "A3"
		tabla.Rows.Add(row)
		DDIdAlmacen.DataSource = tabla
		DDIdAlmacen.DataTextField = "ALMACEN"
		DDIdAlmacen.DataValueField = "ID"
		DDIdAlmacen.Items.Insert(0, New ListItem("Seleccione...", String.Empty))
		DDIdAlmacen.SelectedValue = -1
		DDIdAlmacen.DataBind()
		cnn.Close()
	End Sub
	Public Class Cuadricula
		'Shared Sub AgregarColumna(ByRef GridView1 As Object, ByRef Columna1 As Object, ByRef DSTitulo As String, ByRef DSCampo As String, Optional ByVal DSFormato As String = "", Optional ByVal Alineacion As Object = Nothing)
		'    Columna1.HeaderText = DSTitulo
		'    Columna1.DataField = DSCampo
		'    Columna1.SortExpression = DSCampo
		'    Columna1.ReadOnly = True
		'    If DSFormato <> String.Empty Then
		'        Columna1.DataFormatString = DSFormato
		'    End If
		'    If Alineacion <> Nothing Then
		'        Columna1.ItemStyle.HorizontalAlign = Alineacion
		'    End If
		'    GridView1.Columns.Add(Columna1)
		'End Sub
	End Class

    Protected Sub GVConsulta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVConsulta.SelectedIndexChanged
        'Limpiar()
        'Dim Tabla As New DataTable()
        'Tabla = Session("TablaTest")
        'TBIdProducto.Text = Tabla(GVConsulta.SelectedIndex).Item("IdProducto")
        'TBIdProducto.Text = Tabla.Rows(GVConsulta.SelectedIndex).Item("IdProducto")
        'TBFolio.Text = Tabla.Rows(GVConsulta.SelectedIndex).Item("FechaRegistro")
        'TBDescripcion.Text = Tabla.Rows(GVConsulta.SelectedIndex).Item("Descripcion")
        'DDIdConcepto.SelectedValue = Tabla.Rows(GVConsulta.SelectedIndex).Item("Unidad")
        'TBFechaRegistro.Text = Tabla.Rows(GVConsulta.SelectedIndex).Item("PrecioCompra")
        'TBPrecioVenta.Text = Tabla.Rows(GVConsulta.SelectedIndex).Item("PrecioVenta")
        'TBClasificacion.Text = Tabla.Rows(GVConsulta.SelectedIndex).Item("Clasificacion")
        'TBCantidad.Text = Tabla.Rows(GVConsulta.SelectedIndex).Item("Cantidad")
        'MultiView1.SetActiveView(VRegistro)
    End Sub
	Private Sub Limpiar()
		TBIdRequisicionEncabezado.Text = ""
		DDIdSucursal.SelectedValue = -1
		DDIdAlmacen.SelectedValue = -1
        TBFechaRegistro.Text = Now.Date
        TBDescripcion.Text = ""
        TBObservacion.Text = ""
        GVProductos.DataSource = Nothing
		GVProductos.DataBind()
		GVAgregados.DataSource = Nothing
		GVAgregados.DataBind()
		BTNAgregar.Visible = False
		GenerarTablaGuardar()
	End Sub
	Private Sub Agregar()
		Dim TablaAux As New DataTable()
		Dim bandera As Boolean = False
		TablaGuardar = Session("TablaGuardar")
		TablaAux = Session("Tabla")
		For Each MiDataRow As GridViewRow In GVProductos.Rows
			Dim RenglonAInsertar As DataRow
			Dim index As Integer = 0
			index = Convert.ToUInt64(MiDataRow.RowIndex)
			If CType(MiDataRow.FindControl("CBGVProducto"), CheckBox).Checked = True Then
				bandera = False
				For Each row As DataRow In TablaGuardar.Rows
					If TablaAux.Rows(index).Item("ID_PRODUCTO") = row.Item("ID_PRODUCTO") Then
						MsgBox("El producto" + " " + TablaAux.Rows(index).Item("DESCRIPCION") + " " + "ya esta en la lista",, "Informacion")
						bandera = True
						Exit For
					End If
				Next
				If bandera = True Then
				Else
					RenglonAInsertar = TablaGuardar.NewRow()
					RenglonAInsertar("ID_PRODUCTO") = TablaAux.Rows(index).Item("ID_PRODUCTO")
					RenglonAInsertar("DESCRIPCION") = TablaAux.Rows(index).Item("DESCRIPCION")
					RenglonAInsertar("MARCA") = TablaAux.Rows(index).Item("MARCA")
					RenglonAInsertar("ALMACEN") = TablaAux.Rows(index).Item("ALMACEN")
					RenglonAInsertar("CANTIDAD") = Convert.ToDouble(CType(MiDataRow.FindControl("TBCantidadRequisicion"), TextBox).Text)
					TablaGuardar.Rows.Add(RenglonAInsertar)
				End If
			End If
		Next
		Session("TablaGuardar") = TablaGuardar
		GVAgregados.DataSource = TablaGuardar
		GVAgregados.DataBind()
	End Sub
	Private Sub GenerarTablaGuardar()
		TablaGuardar.Columns.Clear()
		TablaGuardar.Columns.Add(New DataColumn("ID_PRODUCTO", System.Type.GetType("System.String")))
		TablaGuardar.Columns.Add(New DataColumn("DESCRIPCION", System.Type.GetType("System.String")))
		TablaGuardar.Columns.Add(New DataColumn("MARCA", System.Type.GetType("System.String")))
		TablaGuardar.Columns.Add(New DataColumn("ALMACEN", System.Type.GetType("System.String")))
		TablaGuardar.Columns.Add(New DataColumn("CANTIDAD", System.Type.GetType("System.Int32")))
		VistaGuardar = TablaGuardar.DefaultView
		Session("TablaGuardar") = TablaGuardar
	End Sub

	Protected Sub BTNAgregar_Click(sender As Object, e As EventArgs) Handles BTNAgregar.Click
		Agregar()
	End Sub

	Protected Sub GVAgregados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVAgregados.SelectedIndexChanged

	End Sub

	Protected Sub BTNSeleccionar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
		Dim TBResponsable As LinkButton = CType(sender, LinkButton)
		Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
		Dim Renglon As Integer = gvrFilaActual.RowIndex
		TablaCompraDetalle = Session("TablaGuardar")
		If Renglon > -1 Then
			Try
				TablaCompraDetalle(Renglon).Delete()
			Catch ex As InvalidCastException
			End Try

			Session("TablaGuardar") = TablaCompraDetalle
			GVAgregados.DataSource = TablaCompraDetalle
			GVAgregados.DataBind()
		End If
	End Sub

	Protected Sub BTNConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles BTNConsultar.Click
		ConsultarRequisiciones()
		MultiView1.SetActiveView(VConsulta)
	End Sub
	Private Sub ConsultarRequisiciones()
		Dim cnn As New SqlConnection(abrirConexion)
		GVConsulta.Columns.Clear()
		GVConsulta.DataBind()
		cnn.Open()
		Dim cmd As New SqlCommand("ConReqAlmRanFec", cnn)
		cmd.CommandType = CommandType.StoredProcedure
		'If CFechaInicio.SelectedDate = "01-01-0001" And CFechaFin.SelectedDate = "01-01-0001" Then
		'	CFechaInicio.SelectedDate = "1900-01-01"
		'	CFechaFin.SelectedDate = "1900-01-01"
		'End If
		'cmd.Parameters.Add(New SqlClient.SqlParameter("@FechaInicio", CFechaInicio.SelectedDate))
		'cmd.Parameters.Add(New SqlClient.SqlParameter("@FechaFin", CFechaFin.SelectedDate))
		Dim da As New SqlDataAdapter(cmd)
		Dim dt As New DataTable
		da.Fill(dt)
		GVConsulta.AutoGenerateColumns = True
		GVConsulta.DataSource = dt
		GVConsulta.DataBind()
		Session("TablaRequisiciones") = dt
		cnn.Close()
	End Sub
End Class