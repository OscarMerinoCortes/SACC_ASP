Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls
Imports System.Web.UI

Public Class RevisarCotizaciones
	Inherits System.Web.UI.Page
	Dim sqlQuery As String
	Dim cnn As New SqlConnection(abrirConexion)
	Public TablaGuardar As New DataTable()
	Dim VistaGuardar As DataView
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Page.IsPostBack Then
			Nuevo()
			Llenar_Lista_Proveedores()
			MultiView1.SetActiveView(VRegistro)
		End If
	End Sub

	Protected Sub BTNNuevo_Click(sender As Object, e As ImageClickEventArgs)
		Nuevo()
	End Sub

	Protected Sub BTNGuardar_Click1(sender As Object, e As ImageClickEventArgs) Handles BTNGuardar.Click
		Agregar()
		Guardar()
		Nuevo()
		Llenar_Lista_Proveedores()
	End Sub

	Protected Sub BTNConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles BTNConsultar.Click

	End Sub

	Protected Sub BTNSalir_Click(sender As Object, e As ImageClickEventArgs)
		Response.Redirect("~/Default")
	End Sub

	Sub Llenar_Lista_Proveedores()
		cnn.Open()
		sqlQuery = "SELECT P.ID_PROVEEDOR, P.NOMBRE, P.DIRECCION, P.COLONIA, P.CIUDAD, P.CP, P.RFC, P.TELEFONO1, P.TELEFONO2, P.TELEFONO3, P.NOTAS, P.ESTADO, P.PAIS FROM PROVEEDOR AS P JOIN COTIZA_REQUI AS C ON C.ID_PROVEEDOR = P.ID_PROVEEDOR WHERE P.ELIMINADO = 'N' AND ESTADO_ACTUAL = 'A' GROUP BY P.ID_PROVEEDOR, P.NOMBRE, P.DIRECCION, P.COLONIA, P.CIUDAD, P.CP, P.RFC, P.TELEFONO1, P.TELEFONO2, P.TELEFONO3, P.NOTAS, P.ESTADO, P.PAIS ORDER BY P.NOMBRE"
		Dim objCmd As New SqlCommand(sqlQuery, cnn)
		objCmd.ExecuteNonQuery()
		Dim da As New SqlDataAdapter(objCmd)
		Dim dt As New DataTable
		da.Fill(dt)
		GVProveedores.AutoGenerateColumns = False
		GVProveedores.DataSource = dt
		GVProveedores.DataBind()
		Session("TablaProveedores") = dt
		cnn.Close()
	End Sub

	Protected Sub BTNSeleccionar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
		Dim TBResponsable As LinkButton = CType(sender, LinkButton)
		Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
		Dim Renglon As Integer = gvrFilaActual.RowIndex
		Dim TablaProveedores As New DataTable
		TablaProveedores = Session("TablaProveedores")
		If Renglon > -1 Then
			Try
				cnn.Open()
				sqlQuery = "SELECT ID_COTIZACION, ID_REQUISICION, ID_PROVEEDOR, ID_PRODUCTO, DESCRIPCION, CANTIDAD, DIAS_ENTREGA, PRECIO, FECHA, MONEDA FROM COTIZA_REQUI WHERE ESTADO_ACTUAL = 'A' AND ID_PROVEEDOR = " & TablaProveedores(Renglon).Item("ID_PROVEEDOR")
				Dim objCmd As New SqlCommand(sqlQuery, cnn)
				objCmd.ExecuteNonQuery()
				Dim da As New SqlDataAdapter(objCmd)
				Dim dt As New DataTable
				da.Fill(dt)
				GVProductosProveedor.AutoGenerateColumns = False
				GVProductosProveedor.DataSource = dt
				GVProductosProveedor.DataBind()
				Session("TablaCotizar") = dt
				For Each Row As GridViewRow In GVProductosProveedor.Rows
					Dim index As Integer = 0
					index = Convert.ToUInt64(Row.RowIndex)
					Dim sBuscar As String
					sBuscar = "SELECT TOP 1 PRECIO FROM VsComprasProveedor WHERE ID_PROVEEDOR = " & TablaProveedores(Renglon).Item("ID_PROVEEDOR") & " AND ID_PRODUCTO = '" & GVProductosProveedor.Rows(index).Cells(4).Text & "' ORDER BY FECHA DESC"
					Dim objCmd2 As New SqlCommand(sBuscar, cnn)
					objCmd2.ExecuteNonQuery()
					If dt.Rows(index).Item("DIAS_ENTREGA").ToString = "" And dt.Rows(index).Item("PRECIO").ToString = "" Then
						Dim da2 As New SqlDataAdapter(objCmd2)
						Dim dt2 As New DataTable
						da2.Fill(dt2)
						Dim Precio As Double
						If dt2.Rows.Count = 0 Then
							Precio = 0
						Else
							Precio = dt2.Rows(0).Item("PRECIO")
						End If
						CType(Row.FindControl("TBPrecio"), TextBox).Text = Precio
						CType(Row.FindControl("TBDiasEntrega"), TextBox).Text = 1
					End If
				Next
				cnn.Close()
			Catch ex As InvalidCastException
			End Try
		End If
	End Sub

	Private Sub Agregar()
		Dim TablaAux As New DataTable()
		Dim bandera As Boolean = False
		TablaGuardar = Session("TablaGuardar")
		TablaAux = Session("TablaCotizar")
		For Each MiDataRow As GridViewRow In GVProductosProveedor.Rows
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
					RenglonAInsertar("ID_COTIZACION") = TablaAux.Rows(index).Item("ID_COTIZACION")
					RenglonAInsertar("ID_REQUISICION") = TablaAux.Rows(index).Item("ID_REQUISICION")
					RenglonAInsertar("ID_PROVEEDOR") = TablaAux.Rows(index).Item("ID_PROVEEDOR")
					RenglonAInsertar("ID_PRODUCTO") = TablaAux.Rows(index).Item("ID_PRODUCTO")
					RenglonAInsertar("CANTIDAD") = GVProductosProveedor.Rows(index).Cells(6).Text
					RenglonAInsertar("DIAS_ENTREGA") = CStr(CType(MiDataRow.FindControl("TBDiasEntrega"), TextBox).Text)
					RenglonAInsertar("PRECIO") = CStr(CType(MiDataRow.FindControl("TBPrecio"), TextBox).Text)
					RenglonAInsertar("MONEDA") = CStr(CType(MiDataRow.FindControl("Combo1"), DropDownList).Text)
					TablaGuardar.Rows.Add(RenglonAInsertar)
				End If
			End If
		Next
		Session("TablaGuardar") = TablaGuardar
	End Sub

	Protected Sub Guardar()
		Dim tabla As New DataTable()
		tabla = Session("TablaGuardar")
		If tabla.Rows.Count = 0 Then
			MsgBox("No hay productos en la lista",, "Informacion")
			Exit Sub
		Else
			Dim cnn As New SqlConnection(abrirConexion)
			Try
				cnn.Open()
				Dim index As Integer = 0
				For Each MiDataRow As DataRow In tabla.Rows
					sqlQuery = "UPDATE COTIZA_REQUI SET ESTADO_ACTUAL = 'A',  DIAS_ENTREGA = " & tabla.Rows(index).Item("DIAS_ENTREGA") & ", PRECIO = " & tabla.Rows(index).Item("PRECIO") & ", MONEDA = '" & tabla.Rows(index).Item("MONEDA") & "' WHERE ID_COTIZACION = " & tabla.Rows(index).Item("ID_COTIZACION")
					Dim objCmd As New SqlCommand(sqlQuery, cnn)
					objCmd.ExecuteNonQuery()
					sqlQuery = "UPDATE REQUISICION SET COTIZADA = 1, ACTIVO = 0 WHERE ID_REQUISICION = " & tabla.Rows(index).Item("ID_REQUISICION")
						Dim objCmd2 As New SqlCommand(sqlQuery, cnn)
					objCmd2.ExecuteNonQuery()
					index = index + 1
				Next
				cnn.Close()
			Catch ex As Exception
				ex.Message.ToString()
			End Try
		End If
	End Sub

	Private Sub Nuevo()
		'######################### TABLA PRODUCTOS GUARDAR #######################
		TablaGuardar.Columns.Clear()
		TablaGuardar.Columns.Add(New DataColumn("ID_COTIZACION", System.Type.GetType("System.Int32")))
		TablaGuardar.Columns.Add(New DataColumn("ID_REQUISICION", System.Type.GetType("System.Int32")))
		TablaGuardar.Columns.Add(New DataColumn("ID_PROVEEDOR", System.Type.GetType("System.Int32")))
		TablaGuardar.Columns.Add(New DataColumn("ID_PRODUCTO", System.Type.GetType("System.String")))
		TablaGuardar.Columns.Add(New DataColumn("CANTIDAD", System.Type.GetType("System.Int32")))
		TablaGuardar.Columns.Add(New DataColumn("DIAS_ENTREGA", System.Type.GetType("System.Int32")))
		TablaGuardar.Columns.Add(New DataColumn("PRECIO", System.Type.GetType("System.Double")))
		TablaGuardar.Columns.Add(New DataColumn("MONEDA", System.Type.GetType("System.String")))
		VistaGuardar = TablaGuardar.DefaultView
		Session("TablaGuardar") = TablaGuardar
		Session("VistaGuardar") = VistaGuardar
		GVProductosProveedor.DataSource = Nothing
		GVProductosProveedor.DataBind()
	End Sub

	Protected Sub BTNNuevo_Click(sender As Object, e As EventArgs) Handles BTNuevo.Click

	End Sub

	Protected Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
		Response.Redirect("~/")
	End Sub

	Protected Sub GVProveedores_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
		Llenar_Lista_Proveedores()
		GVProveedores.PageIndex = e.NewPageIndex
		GVProveedores.DataBind()
	End Sub

	Protected Sub GVProductosProveedor_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
		GVProductosProveedor.DataSource = Session("TablaCotizar")
		GVProductosProveedor.PageIndex = e.NewPageIndex
		GVProductosProveedor.DataBind()
	End Sub
End Class