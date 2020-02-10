Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls
Imports System.Web.UI

Public Class RequisicionCompra
	Inherits System.Web.UI.Page
	Public TablaGuardar As New DataTable()
	Public VistaGuardar As New DataView()
	Private TablaGeneral As New DataTable()
	Private cnn As New SqlConnection(abrirConexion)
	Dim tRs As ADODB.Recordset
	Dim sqlQuery As String
	Dim tLi As ListItem
	Dim ID_REQUISICION As Integer
	Dim ID_PROVEEDOR As Integer
	Dim ID_PRODUCTO As String
	Dim DESCRIPCION As String
	Dim CANTIDAD As Double
	Dim DIAS_ENTREGA As Integer
	Dim Precio As Double
	Dim Cont As Integer
	Dim CONT2 As Integer
	Dim FECHA As DateTime

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Page.IsPostBack Then
			GenerarTablaLimpia()
			LlenarCombos()
			Llenar_Lista_Proveedores()
			Llenar_Lista_Requisiciones()
			MultiView1.SetActiveView(VRegistro)
		End If
	End Sub

	Sub Llenar_Lista_Proveedores()
		cnn.Open()
		Dim Cond As String = ""
		GVProvedores.DataSource = Nothing
		If Combo1.SelectedValue <> 0 Then
			If Combo1.SelectedValue = 1 Then
				Cond = " AND ALMACEN1 = 'S' "
			End If
			If Combo1.SelectedValue = 2 Then
				Cond = " And ALMACEN2 = 'S' "
			End If
			If Combo1.SelectedValue = 3 Then
				Cond = " AND ALMACEN3 = 'S' "
			End If
			Cond = Cond & " AND NOMBRE LIKE '%" & Text6.Text & "%'"
			Cond = Cond & " ORDER BY NOMBRE"
		Else
			Cond = "AND NOMBRE LIKE '%" & Text6.Text & "%' ORDER BY NOMBRE"
		End If
		sqlQuery = "SELECT ID_PROVEEDOR, NOMBRE, DIRECCION, COLONIA, CIUDAD, CP, RFC, TELEFONO1, TELEFONO2, TELEFONO3, NOTAS, ESTADO, PAIS FROM PROVEEDOR WHERE ELIMINADO = 'N' " & Cond
		Dim objCmd As New SqlCommand(sqlQuery, cnn)
		objCmd.ExecuteNonQuery()
		Dim da As New SqlDataAdapter(objCmd)
		Dim dt As New DataTable
		da.Fill(dt)
		GVProvedores.AutoGenerateColumns = False
		GVProvedores.DataSource = dt
		GVProvedores.DataBind()
		Session("TablaProveedores") = dt
		cnn.Close()
	End Sub

	Sub Llenar_Lista_Requisiciones()
		Dim Cond As String
		Dim sqlQuery2 As String
		Dim sqlQuery3 As String
		cnn.Open()
		Cond = ""
		sqlQuery = "UPDATE REQUISICION SET CONTADOR = 0 WHERE (CONTADOR = '')"
		Dim objCmd As New SqlCommand(sqlQuery, cnn)
		objCmd.ExecuteNonQuery()
		GVProductos.DataSource = Nothing
		If Combo1.SelectedValue <> 0 Then
			Cond = " AND ALMACEN = 'A" & Right(Combo1.Text, 1) & "'"
		End If
		If Combo2.SelectedValue <> 0 And Combo2.Enabled Then
			If Cond = "" Then
				Cond = " AND MARCA = '" & Combo2.Text & "'"
			Else
				Cond = Cond & " AND MARCA = '" & Combo2.Text & "'"
			End If
		End If
		If Text2.Text <> "" Then
			If Cond = "" Then
				Cond = " AND ID_PRODUCTO LIKE '%" & Text2.Text & "%'"
			Else
				Cond = Cond & " AND ID_PRODUCTO LIKE '%" & Text2.Text & "%'"
			End If
		End If
		sqlQuery2 = "SELECT ID_REQUISICION, ID_PRODUCTO, DESCRIPCION, COMENTARIO, CANTIDAD, FECHA, CONTADOR, URGENTE, MARCA FROM REQUISICION WHERE ACTIVO = 0 AND FOLIO = 0" & Cond
		Dim objCmd2 As New SqlCommand(sqlQuery2, cnn)
		objCmd2.ExecuteNonQuery()
		Dim da2 As New SqlDataAdapter(objCmd2)
		Dim dt2 As New DataTable
		da2.Fill(dt2)
		GVProductos.AutoGenerateColumns = False
		GVProductos.DataSource = dt2
		GVProductos.DataBind()
		Session("TablaRequisiciones") = dt2
		For Each Row As GridViewRow In GVProductos.Rows
			Dim index As Integer = 0
			index = Convert.ToUInt64(Row.RowIndex)
			Dim str As String = GVProductos.Rows(index).Cells(7).Text
			If str = "S" Then
				Row.BackColor = System.Drawing.Color.IndianRed
			End If
		Next
		sqlQuery3 = "SELECT FOLIO FROM REQUISICION WHERE ACTIVO = 0 AND FOLIO <> 0 AND ID_REQUISICION IN (SELECT ID_REQUISICION FROM COTIZA_REQUI) GROUP BY FOLIO"
		Dim objCmd3 As New SqlCommand(sqlQuery3, cnn)
		objCmd3.ExecuteNonQuery()
		Dim da3 As New SqlDataAdapter(objCmd3)
		Dim dt3 As New DataTable
		da3.Fill(dt3)
		GVRequisicionesPendientes.AutoGenerateColumns = False
		GVRequisicionesPendientes.DataSource = dt3
		GVRequisicionesPendientes.DataBind()
		Session("TablaRequisicionesPendientes") = dt3
		cnn.Close()
	End Sub

	Protected Sub BTNFiltar_Click(sender As Object, e As EventArgs) Handles BTNFiltar.Click
		Llenar_Lista_Proveedores()
	End Sub

	Protected Sub BTNNuevo_Click(sender As Object, e As EventArgs) Handles BTNuevo.Click
		LlenarCombos()
		GenerarTablaLimpia()
		Llenar_Lista_Proveedores()
		Llenar_Lista_Requisiciones()
		Limpiar()
	End Sub

	Private Sub LlenarCombos()
		'MARCAS
		Dim cnn As New SqlConnection(abrirConexion)
		cnn.Open()
		sqlQuery = "SELECT ID_MARCA, MARCA FROM MARCA ORDER BY ID_MARCA"
		Dim objCmd As New SqlCommand(sqlQuery, cnn)
		objCmd.ExecuteNonQuery()
		Dim da As New SqlDataAdapter(objCmd)
		Dim dt As New DataTable
		da.Fill(dt)
		Dim row1 As DataRow
		row1 = dt.NewRow()
		row1("ID_MARCA") = 0
		row1("MARCA") = "Todos"
		dt.Rows.Add(row1)
		Combo2.DataSource = dt
		Combo2.DataTextField = "MARCA"
		Combo2.DataValueField = "ID_MARCA"
		Combo2.SelectedValue = 0
		Combo2.DataBind()
		cnn.Close()
	End Sub

	Protected Sub BTNAgregar_Click(sender As Object, e As EventArgs) Handles BTNAgregar.Click
		Agregar()
	End Sub

	Private Sub Agregar()
		Dim TablaAux As New DataTable()
		Dim bandera As Boolean = False
		If TBIdRequisicionPendiente.Text = "" Then
			GenerarTablaLimpia()
			TablaGuardar = Session("TablaGuardar")
			TablaAux = Session("TablaRequisiciones")
			For Each MiDataRow As GridViewRow In GVProductos.Rows
				Dim RenglonAInsertar As DataRow
				Dim index As Integer = 0
				index = Convert.ToUInt64(MiDataRow.RowIndex)
				If CType(MiDataRow.FindControl("CBGVProducto"), CheckBox).Checked = True Then
					bandera = False
					For Each row As DataRow In TablaGuardar.Rows
						If TablaAux.Rows(index).Item("ID_PRODUCTO") = row.Item("ID_PRODUCTO") Then
							MsgBox("EL PRODUCTO" + " " + TablaAux.Rows(index).Item("DESCRIPCION") + " " + "YA  ESTA EN LA LISTA",, "Información")
							bandera = True
							Exit For
						End If
					Next
					If bandera = True Then
					Else
						RenglonAInsertar = TablaGuardar.NewRow()
						RenglonAInsertar("ID_REQUISICION") = TablaAux.Rows(index).Item("ID_REQUISICION")
						RenglonAInsertar("ID_PRODUCTO") = TablaAux.Rows(index).Item("ID_PRODUCTO")
						RenglonAInsertar("DESCRIPCION") = TablaAux.Rows(index).Item("DESCRIPCION")
						RenglonAInsertar("CANTIDAD") = TablaAux.Rows(index).Item("CANTIDAD")
						RenglonAInsertar("FECHA") = TablaAux.Rows(index).Item("FECHA")
						'RenglonAInsertar("COMENTARIO") = TablaAux.Rows(index).Item("COMENTARIO")
						'RenglonAInsertar("URGENTE") = TablaAux.Rows(index).Item("URGENTE")
						TablaGuardar.Rows.Add(RenglonAInsertar)
					End If
				End If
			Next
			If TablaGuardar.Rows.Count = 0 Then
				MsgBox("NO SE HA SELECCIONADO NINGUN PRODUCTO", vbInformation, "Información")
			Else
				Session("TablaGuardar") = TablaGuardar
				GVAgregados.AutoGenerateColumns = False
				GVAgregados.DataSource = TablaGuardar
				GVAgregados.DataBind()
				MultiView1.SetActiveView(VAsignarProvedor)
			End If
		Else
			Select Case MsgBox("TIENE UNA REQUISICION ABIERTA PENDIENTE DE CERRAR, DESEA CANCELARLA?", MsgBoxStyle.YesNo, "Información")
				Case MsgBoxResult.Yes
					GenerarTablaLimpia()
					GVAgregados.DataSource = Nothing
					TBIdRequisicionPendiente.Text = ""
					GVProductosRequisicionesPendientes.DataSource = Nothing
				Case MsgBoxResult.No
			End Select
		End If
	End Sub

	Protected Sub BTNAgregarProductos_Click(sender As Object, e As EventArgs) Handles BTNAgregarProductos.Click
		If TBIdRequisicionPendiente.Text = "" Then
			MultiView1.SetActiveView(VRegistro)
		Else
			Select Case MsgBox("TIENE UNA REQUISICION ABIERTA PENDIENTE DE CERRAR, DESEA CANCELARLA?", MsgBoxStyle.YesNo, "Información")
				Case MsgBoxResult.Yes
					GenerarTablaLimpia()
					GVAgregados.DataSource = Nothing
					GVAgregados.DataBind()
					TBIdRequisicionPendiente.Text = ""
					GVProductosRequisicionesPendientes.DataSource = Nothing
					GVProductosRequisicionesPendientes.DataBind()
				Case MsgBoxResult.No
			End Select
		End If
	End Sub

	Protected Sub BTNEliminar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
		Dim TBResponsable As LinkButton = CType(sender, LinkButton)
		Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
		Dim Renglon As Integer = gvrFilaActual.RowIndex
		TablaGeneral = Session("TablaGuardar")
		If Renglon > -1 Then
			Try
				TablaGeneral(Renglon).Delete()
			Catch ex As InvalidCastException
			End Try

			Session("TablaGuardar") = TablaGeneral
			GVAgregados.DataSource = TablaGeneral
			GVAgregados.DataBind()
		End If
	End Sub

	Protected Sub BTNSeleccionar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
		Dim TBResponsable As LinkButton = CType(sender, LinkButton)
		Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
		Dim Renglon As Integer = gvrFilaActual.RowIndex
		Dim TablaProveedores As New DataTable
		TablaProveedores = Session("TablaProveedores")
		If Renglon > -1 Then
			Try
				TBIdProveedor.Text = TablaProveedores(Renglon).Item("ID_PROVEEDOR")
				TBNombreProveedor.Text = TablaProveedores(Renglon).Item("NOMBRE")
			Catch ex As InvalidCastException
			End Try
		End If
	End Sub

	Protected Sub BTNSeleccionarRequiPend_OnClick(ByVal sender As Object, ByVal e As EventArgs)
		Dim TBResponsable As LinkButton = CType(sender, LinkButton)
		Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
		Dim Renglon As Integer = gvrFilaActual.RowIndex
		Dim TablaRequisicionesPendientes As New DataTable
		TablaRequisicionesPendientes = Session("TablaRequisicionesPendientes")
		If Renglon > -1 Then
			Try
				TBIdRequisicionPendiente.Text = TablaRequisicionesPendientes(Renglon).Item("FOLIO")
				'TBNombreProveedor.Text = TablaProveedores(Renglon).Item("NOMBRE")
			Catch ex As InvalidCastException
			End Try
		End If
	End Sub

	Protected Sub BTNConsultarRequisiciones_Click(sender As Object, e As ImageClickEventArgs) Handles BTNConsultarRequisiciones.Click
		MultiView1.SetActiveView(VRequisicionesNoCerradas)
	End Sub

	Protected Sub BTNBuscarRequisicionId_Click(sender As Object, e As EventArgs) Handles BTNBuscarRequisicionId.Click
		Dim sBuscar As String
		If TBIdRequisicionPendiente.Text <> "" Then
			sBuscar = "SELECT * FROM VsREQUISICION WHERE ACTIVO = 0 AND FOLIO = " & TBIdRequisicionPendiente.Text
			cnn.Open()
			Dim objCmd As New SqlCommand(sBuscar, cnn)
			objCmd.ExecuteNonQuery()
			Dim da As New SqlDataAdapter(objCmd)
			Dim dt As New DataTable
			da.Fill(dt)
			If dt.Rows.Count <> 0 Then
				GVProductosRequisicionesPendientes.AutoGenerateColumns = False
				GVProductosRequisicionesPendientes.DataSource = dt
				GVProductosRequisicionesPendientes.DataBind()
				Session("TablaProductosRequisicionesPendientes") = dt
			Else
				MsgBox("EL NUMERO DE REQUISICION NO EXISTE O YA ESTA CERRADO", vbInformation, "Información")
			End If
		Else
			MsgBox("SELECCIONE UNA REQUISICION", vbInformation, "Información")
		End If
		cnn.Close()
	End Sub

	Protected Sub BTNGuardar_Click(sender As Object, e As EventArgs) Handles BTNGuardar.Click
		Dim NoPed As String
		Dim Uno As Boolean
		Dim Dos As Boolean
		Dim FolioC As Integer
		Dim TablaRequisicionesAGuardar As DataTable
		Dim FolioR As Integer
		If TBIdProveedor.Text = "" And TBNombreProveedor.Text = "" Then
			MsgBox("SELECCIONE A UN PROVEEDOR", vbInformation, "Información")
		Else
			TablaRequisicionesAGuardar = Session("TablaGuardar")
			If TablaRequisicionesAGuardar.Rows.Count = 0 Then
				MsgBox("NO HAY PRODUCTOS SELECCIONADOS PARA GUARDAR", vbInformation, "Información")
			Else
				If TBIdRequisicionPendiente.Text <> "" Then
					FolioR = CDbl(TBIdRequisicionPendiente.Text)
					Uno = False
				Else
					FolioR = 0
					Uno = True
				End If
				Dos = True
				ID_PROVEEDOR = TBIdProveedor.Text    'ID DEL PROVEEDOR
				For Each row As DataRow In TablaRequisicionesAGuardar.Rows
					ID_REQUISICION = CStr(row("ID_REQUISICION"))
					ID_PRODUCTO = CStr(row("ID_PRODUCTO"))
					DESCRIPCION = CStr(row("DESCRIPCION"))
					CANTIDAD = CStr(row("CANTIDAD"))
					'ID_PROVEEDOR = CStr(row("ID_PROVEEDOR"))
					'FECHA = CStr(row("FECHA"))
					cnn.Open()
					sqlQuery = "SELECT * FROM COTIZA_REQUI WHERE ID_REQUISICION = " & ID_REQUISICION & " AND ID_PROVEEDOR = " & ID_PROVEEDOR & " AND ID_PRODUCTO = '" & ID_PRODUCTO & "' AND CANTIDAD = " & CANTIDAD & " AND FECHA = '" & Convert.ToDateTime(CStr(row("FECHA"))) & "'"
					Dim objCmd As New SqlCommand(sqlQuery, cnn)
					objCmd.ExecuteNonQuery()
					Dim da As New SqlDataAdapter(objCmd)
					Dim dt As New DataTable
					da.Fill(dt)
					If dt.Rows.Count = 0 Then
						If Dos Then
							sqlQuery = "SELECT FOLIO FROM COTIZA_REQUI ORDER BY FOLIO DESC"
							Dim objCmdFolio As New SqlCommand(sqlQuery, cnn)
							objCmdFolio.ExecuteNonQuery()
							Dim daFolio As New SqlDataAdapter(objCmdFolio)
							Dim dtFolio As New DataTable
							daFolio.Fill(dtFolio)
							If dtFolio.Rows.Count = 0 Then
								FolioC = 1
							Else
								FolioC = CDbl(dtFolio.Rows(0).Item("FOLIO")) + 1
							End If
							Dos = False
						End If
						sqlQuery = "SELECT FOLIO, NO_PEDIDO FROM REQUISICION ORDER BY FOLIO DESC"
						Dim objCmdFolioPed As New SqlCommand(sqlQuery, cnn)
						objCmdFolioPed.ExecuteNonQuery()
						Dim daFolioPed As New SqlDataAdapter(objCmdFolioPed)
						Dim dtFolioPed As New DataTable
						daFolioPed.Fill(dtFolioPed)
						If dtFolioPed.Rows(0).Item("NO_PEDIDO") Is String.Empty Then
							NoPed = CDbl(dtFolioPed.Rows(0).Item("NO_PEDIDO"))
						Else
							NoPed = 0
						End If
						If Uno Then
							FolioR = CDbl(dtFolioPed.Rows(0).Item("FOLIO")) + 1
							Uno = False
						End If
						sqlQuery = "INSERT INTO COTIZA_REQUI (ID_REQUISICION, ID_PROVEEDOR, ID_PRODUCTO, DESCRIPCION, CANTIDAD, FECHA, FOLIO, FOLIOREQUI, NO_PEDIDO) VALUES (" & ID_REQUISICION & ", " & ID_PROVEEDOR & ", '" & ID_PRODUCTO & "', '" & DESCRIPCION & "', " & CANTIDAD & ", '" & Format(Date.Today, "dd/MM/yyyy") & "', " & FolioC & ", " & FolioR & ", '" & NoPed & "');"
						Dim objCmdIns As New SqlCommand(sqlQuery, cnn)
						objCmdIns.ExecuteNonQuery()
						sqlQuery = "UPDATE REQUISICION SET CONTADOR = CONTADOR + 1, FOLIO = " & FolioR & " WHERE ID_REQUISICION = " & ID_REQUISICION
						Dim objCmdUpd As New SqlCommand(sqlQuery, cnn)
						objCmdUpd.ExecuteNonQuery()
						cnn.Close()
					Else
						MsgBox("PRODUCTO " & DESCRIPCION & " YA ASIGNADO", vbInformation, "Información")
					End If
				Next
				If FolioR > 0 Then
					TBIdRequisicionPendiente.Text = FolioR
				End If
				Llenar_Lista_Requisiciones()
				Limpiar()
			End If
		End If
	End Sub
	Protected Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
		Response.Redirect("~/")
	End Sub

	Private Sub Limpiar()
		Text2.Text = ""
		Text6.Text = ""
		TBIdProveedor.Text = ""
		TBNombreProveedor.Text = ""
		GVAgregados.DataSource = Nothing
		GVAgregados.DataBind()
		TBIdRequisicionPendiente.Text = ""
		GVProductosRequisicionesPendientes.DataSource = Nothing
		GVProductosRequisicionesPendientes.DataBind()
	End Sub

	Protected Sub GVAgregados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVAgregados.SelectedIndexChanged

	End Sub

	Protected Sub BTNConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles BTNConsultar.Click
		MultiView1.SetActiveView(VRequisicionesNoCerradas)
	End Sub
	Private Sub ConsultarRequisiciones()
		MultiView1.SetActiveView(VRequisicionesNoCerradas)
	End Sub

	Protected Sub BTNCerrarRequisicion_Click(sender As Object, e As EventArgs) Handles BTNCerrarRequisicion.Click
		Dim TablaAux As New DataTable()
		Dim bandera As Boolean = False
		If TBIdRequisicionPendiente.Text = "" Then
			MsgBox("NO HAY REQUISICION PENDIENTE SELECCIONADA", vbInformation, "Información")
		Else
			TablaGuardar.Clear()
			GenerarTablaLimpia()
			TablaGuardar = Session("TablaGuardar")
			TablaAux = Session("TablaProductosRequisicionesPendientes")
			For Each MiDataRow As GridViewRow In GVProductosRequisicionesPendientes.Rows
				Dim RenglonAInsertar As DataRow
				Dim index As Integer = 0
				index = Convert.ToUInt64(MiDataRow.RowIndex)
				If CType(MiDataRow.FindControl("CBGVProducto"), CheckBox).Checked = True Then
					bandera = False
					For Each row As DataRow In TablaGuardar.Rows
						If TablaAux.Rows(index).Item("ID_PRODUCTO") = row.Item("ID_PRODUCTO") Then
							MsgBox("EL PRODUCTO" + " " + TablaAux.Rows(index).Item("DESCRIPCION") + " " + "YA ESTA  EN LA LISTA",, "Información")
							bandera = True
							Exit For
						End If
					Next
					If bandera = True Then
					Else
						RenglonAInsertar = TablaGuardar.NewRow()
						RenglonAInsertar("ID_REQUISICION") = TablaAux.Rows(index).Item("ID_REQUISICION")
						RenglonAInsertar("ID_PRODUCTO") = TablaAux.Rows(index).Item("ID_PRODUCTO")
						RenglonAInsertar("DESCRIPCION") = TablaAux.Rows(index).Item("DESCRIPCION")
						RenglonAInsertar("CANTIDAD") = TablaAux.Rows(index).Item("CANTIDAD")
						RenglonAInsertar("FECHA") = TablaAux.Rows(index).Item("FECHA")
						'RenglonAInsertar("COMENTARIO") = TablaAux.Rows(index).Item("COMENTARIO")
						'RenglonAInsertar("URGENTE") = TablaAux.Rows(index).Item("URGENTE")
						TablaGuardar.Rows.Add(RenglonAInsertar)
					End If
				End If
			Next
			If TablaGuardar.Rows.Count = 0 Then
				MsgBox("NO SE HA SELECCIONADO NINGUN PRODUCTO", vbInformation, "Información")
			Else
				Session("TablaGuardar") = TablaGuardar
				GVAgregados.AutoGenerateColumns = False
				GVAgregados.DataSource = TablaGuardar
				GVAgregados.DataBind()
				MultiView1.SetActiveView(VAsignarProvedor)
			End If
		End If
	End Sub

	Private Sub GenerarTablaLimpia()
		'######################### TABLA PRODUCTOS GUARDAR #######################
		TablaGuardar.Columns.Clear()
		TablaGuardar.Columns.Add(New DataColumn("ID_REQUISICION", System.Type.GetType("System.Int32")))
		TablaGuardar.Columns.Add(New DataColumn("ID_PRODUCTO", System.Type.GetType("System.String")))
		TablaGuardar.Columns.Add(New DataColumn("DESCRIPCION", System.Type.GetType("System.String")))
		TablaGuardar.Columns.Add(New DataColumn("CANTIDAD", System.Type.GetType("System.Int32")))
		TablaGuardar.Columns.Add(New DataColumn("FECHA", System.Type.GetType("System.String")))
		'TablaGuardar.Columns.Add(New DataColumn("COMENTARIO", System.Type.GetType("System.String")))
		'TablaGuardar.Columns.Add(New DataColumn("URGENTE", System.Type.GetType("System.String")))
		VistaGuardar = TablaGuardar.DefaultView
		Session("TablaGuardar") = TablaGuardar
		Session("VistaGuardar") = VistaGuardar
	End Sub

	Protected Sub BTNRegresar_Click(sender As Object, e As ImageClickEventArgs) Handles BTNRegresar.Click
		MultiView1.SetActiveView(VAsignarProvedor)
	End Sub

	Protected Sub GVProductos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
		Llenar_Lista_Requisiciones()
		GVProductos.PageIndex = e.NewPageIndex
		GVProductos.DataBind()
	End Sub

	Protected Sub GVProvedores_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
		Llenar_Lista_Proveedores()
		GVProvedores.PageIndex = e.NewPageIndex
		GVProvedores.DataBind()
	End Sub

	Protected Sub GVAgregados_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
		GVAgregados.DataSource = Session("TablaGuardar")
		GVAgregados.PageIndex = e.NewPageIndex
		GVAgregados.DataBind()
	End Sub

	Protected Sub GVRequisicionesPendientes_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
		GVRequisicionesPendientes.DataSource = Session("TablaRequisicionesPendientes")
		GVRequisicionesPendientes.PageIndex = e.NewPageIndex
		GVRequisicionesPendientes.DataBind()
	End Sub

	Protected Sub GVProductosRequisicionesPendientes_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
		GVProductosRequisicionesPendientes.DataSource = Session("TablaProductosRequisicionesPendientes")
		GVProductosRequisicionesPendientes.PageIndex = e.NewPageIndex
		GVProductosRequisicionesPendientes.DataBind()
	End Sub

	Protected Sub BTNSalir_Click(sender As Object, e As ImageClickEventArgs)
		Response.Redirect("~/Default")
	End Sub

	Protected Sub BTNRegresarx2_Click(sender As Object, e As ImageClickEventArgs) Handles BTNRegresarx2.Click
		MultiView1.SetActiveView(VRegistro)
	End Sub
End Class