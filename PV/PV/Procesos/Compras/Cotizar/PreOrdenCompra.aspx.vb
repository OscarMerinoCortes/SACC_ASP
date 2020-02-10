Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.IO


Public Class PreOrdenCompra
	Inherits System.Web.UI.Page
	Dim sqlQuery As String
	Dim cnn As New SqlConnection(abrirConexion)
	Public TablaGuardar As New DataTable()
	Dim VistaGuardar As DataView
	Dim Cont As Integer
	Dim Tipo As String
	Dim IdProveedor As Integer
	Dim orden As Integer
	Dim numordena As Integer
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Page.IsPostBack Then
			Nuevo()
			Llenar_Lista_Proveedores()
			MultiView1.SetActiveView(VRegistro)
		End If
	End Sub

	Protected Sub BTNNuevo_Click(sender As Object, e As ImageClickEventArgs)
		'Dim ParamCte As New ParameterDiscreteValue
		'Dim Parametro1, Parametro2 As Integer

		''ParamIni.Value = Me.txtcliente.Text 'Aqui indicas de donde va a tomar el valor para el parametro
		'Parametro1 = 1479
		'Parametro2 = 261218

		'Dim ParamList As New ParameterFields
		'Dim ParamTemp As ParameterField

		'ParamTemp = New ParameterField
		'ParamTemp.ParameterFieldName = "@nIdOrdenCompra" 'Aqui asignas el parametro que usas
		'ParamTemp.CurrentValues.Add(Parametro1)
		'ParamTemp.ParameterFieldName = "@cIdUsuario" 'Aqui asignas el parametro que usas
		'ParamTemp.CurrentValues.Add(Parametro2)
		'ParamList.Add(ParamTemp)

		'MsgBox("Espere un momento mientras se carga el catalogo", MsgBoxStyle.Information, " ::Sistema Wa Wa ::")

		''Me.crystalreport1.ParameterFieldInfo = ParamList
		''Me.crystalreport1.ReportSource = New rpt_Cliente 'es el nombre de mi reporte
		Nuevo()
	End Sub

	Protected Sub BTNGuardar_Click1(sender As Object, e As ImageClickEventArgs) Handles BTNGuardar.Click
		Dim FormaPago As String
		Dim nLvw As Integer
		Dim NUM_ORDENS As String
		Dim num_orden As Integer
		Dim Total As String
		Dim TAX As String
		Dim OTROS As String
		Dim FREIGHT As String
		Dim DISCOUNT As String
		Dim ID_ORDEN_COMPRA As Integer
		Dim ID_PRODUCTO As String
		Dim Descripcion As String
		Dim CANTIDAD As String
		Dim Precio As String
		Dim DIAS_ENTREGA As Integer
		Dim IDC As String
		If ChkBNacional.Checked = False And ChkBInternacional.Checked = False And ChkBIndirecta.Checked = False And ChkBContado.Checked = False And ChkBCredito.Checked = False And TBSubtotal.Text = 0 And TBTotal.Text = 0 Then
			Response.Write("<script>window.alert('Seleccionar el tipo de orden de compra');</script>")
		Else
			If ChkBInternacional.Checked = True Then
				Tipo = "I"
				nLvw = 1
				DDMoneda.SelectedValue = "DOLARES"
				DDMoneda.Enabled = False
			ElseIf ChkBNacional.Checked = True Then
				Tipo = "N"
				nLvw = 2
				DDMoneda.SelectedValue = "PESOS"
				DDMoneda.Enabled = True
			Else
				Tipo = "X"
				nLvw = 3
				DDMoneda.SelectedValue = "PESOS"
				DDMoneda.Enabled = True
			End If
			Cont = 1
			NUM_ORDENS = ""
			For i As Integer = 0 To GVProductosProveedor.Rows.Count - 1
				Dim row As GridViewRow = GVProductosProveedor.Rows(i)
				If row.Cells(11).Text <> " " And NUM_ORDENS <> "" Then
					NUM_ORDENS = row.Cells(11).Text
				End If
			Next
			If NUM_ORDENS = "" Then 'NO EXISTE UNA ORDEN DE COMPRA
				cnn.Open()
				num_orden = 0
				sqlQuery = "SELECT TOP 1 NUM_ORDEN FROM ORDEN_COMPRA WHERE TIPO = '" & Tipo & "' ORDER BY NUM_ORDEN DESC"
				Dim cmd As New SqlCommand(sqlQuery, cnn)
				cmd.ExecuteNonQuery()
				Dim da As New SqlDataAdapter(cmd)
				Dim dt As New DataTable
				da.Fill(dt)
				If dt.Rows.Count <> 0 Then
					num_orden = dt.Rows(0).Item("NUM_ORDEN")
					num_orden = num_orden + 1
					numordena = num_orden
				End If
				If ChkBCredito.Checked Then
					FormaPago = "F"
				Else
					FormaPago = "C"
				End If
				DISCOUNT = TBDescuento.Text
				Total = TBTotal.Text
				TAX = TBImpuestos.Text
				OTROS = TBFlete.Text
				FREIGHT = TBOtrosCargos.Text
				IdProveedor = Session("IdProveeedor")
				'CAMBIAR EL CAMPO DE USUARIO CUANDO SE TENGAN LOS PERMISOS
				sqlQuery = "INSERT INTO ORDEN_COMPRA (ID_PROVEEDOR, FECHA, TOTAL, ENVIARA, TAX, CONFIRMADA, TIPO, NUM_ORDEN, MONEDA, COMENTARIO, ID_USUARIO, FORMA_PAGO, DIAS_CREDITO,DISCOUNT,FREIGHT, OTROS_CARGOS) VALUES ('" & IdProveedor & "', '" & Format(Date.Today, "dd/MM/yyyy") & "', " & Total & ", " & "' '" & ", " & TAX & ", 'N', '" & Tipo & "', " & num_orden & ", '" & DDMoneda.SelectedValue & "','" & TBComentarios.Text & "', " & 50 & ", '" & FormaPago & "', " & CDbl(DDDiasCredito.Text) & ", " & TBDescuento.Text & ", " & TBFlete.Text & ", " & TBOtrosCargos.Text & ");"
				Dim cmd2 As New SqlCommand(sqlQuery, cnn)
				cmd2.ExecuteNonQuery()
				sqlQuery = "SELECT TOP 1 ID_ORDEN_COMPRA FROM ORDEN_COMPRA ORDER BY ID_ORDEN_COMPRA DESC"
				Dim cmd3 As New SqlCommand(sqlQuery, cnn)
				cmd3.ExecuteNonQuery()
				Dim da2 As New SqlDataAdapter(cmd3)
				Dim dt2 As New DataTable
				da2.Fill(dt2)
				If dt2.Rows.Count <> 0 Then
					ID_ORDEN_COMPRA = dt2.Rows(0).Item("ID_ORDEN_COMPRA")
					'Session("ID_ORDEN_COMPRA") = dt2.Rows(0).Item("ID_ORDEN_COMPRA")
				End If
				For i As Integer = 0 To GVProductosProveedor.Rows.Count - 1
					Dim Row As GridViewRow = GVProductosProveedor.Rows(i)
					ID_PRODUCTO = Row.Cells(4).Text 'ID_PRODUCTO
					Descripcion = Row.Cells(5).Text 'DESCRIPCION
					CANTIDAD = CType(Row.FindControl("TBCantidad"), TextBox).Text 'CANTIDAD
					DIAS_ENTREGA = Row.Cells(7).Text 'DIAS DE ENTREGA
					Precio = Row.Cells(8).Text 'PRECIO
					sqlQuery = "INSERT INTO ORDEN_COMPRA_DETALLE (ID_ORDEN_COMPRA, ID_PRODUCTO, DESCRIPCION, CANTIDAD, PRECIO, DIAS_ENTREGA) VALUES (" & ID_ORDEN_COMPRA & ", '" & ID_PRODUCTO & "', '" & Descripcion & "', " & CANTIDAD & ", " & Precio & ", " & DIAS_ENTREGA & ");"
					Dim cmd4 As New SqlCommand(sqlQuery, cnn)
					cmd4.ExecuteNonQuery()
					IDC = GVProductosProveedor.Rows(i).Cells(1).Text 'ID_COTIZACION
					If GVProductosProveedor.Rows(i).Cells(10).Text <> " " Then 'IDC EN EL GRID
						IDC = IDC & "," & GVProductosProveedor.Rows(i).Cells(10).Text 'CONCANTENAR LOS IDC
					End If
					sqlQuery = "UPDATE COTIZA_REQUI SET NUMOC = " & ID_ORDEN_COMPRA & " WHERE ID_COTIZACION IN (" & IDC & ")"
					Dim cmd5 As New SqlCommand(sqlQuery, cnn)
					cmd5.ExecuteNonQuery()
					num_orden = ID_ORDEN_COMPRA
					orden = num_orden
				Next
				Response.Write("<script>window.alert('Registro guardado con éxito');</script>")
				cnn.Close()
			Else
				cnn.Open()
				DISCOUNT = TBDescuento.Text
				Total = TBTotal.Text
				TAX = TBImpuestos.Text
				OTROS = TBFlete.Text
				FREIGHT = TBOtrosCargos.Text
				sqlQuery = "UPDATE ORDEN_COMPRA SET TOTAL = " & Total & " ,  TAX = " & TAX & ", FREIGHT=" & FREIGHT & " ,OTROS_CARGOS=" & OTROS & "  WHERE ID_ORDEN_COMPRA = " & NUM_ORDENS
				Dim cmd As New SqlCommand(sqlQuery, cnn)
				cmd.ExecuteNonQuery()
				sqlQuery = "UPDATE ORDEN_COMPRA SET COMENTARIO ='" & TBComentarios.Text & "',DISCOUNT='" & DISCOUNT & "' WHERE ID_ORDEN_COMPRA = " & NUM_ORDENS
				Dim cmd2 As New SqlCommand(sqlQuery, cnn)
				cmd2.ExecuteNonQuery()
				For i As Integer = 1 To GVProductosProveedor.Rows.Count - 1
					Dim Row As GridViewRow = GVProductosProveedor.Rows(i)
					ID_PRODUCTO = Row.Cells(4).Text 'ID_PRODUCTO
					Descripcion = Row.Cells(5).Text 'DESCRIPCION
					CANTIDAD = CType(Row.FindControl("TBCantidad"), TextBox).Text 'CANTIDAD
					DIAS_ENTREGA = Row.Cells(7).Text 'DIAS DE ENTREGA
					Precio = Row.Cells(8).Text 'PRECIO
					NUM_ORDENS = Row.Cells(11).Text
					If NUM_ORDENS = "" Then
						sqlQuery = "INSERT INTO ORDEN_COMPRA_DETALLE (ID_ORDEN_COMPRA, ID_PRODUCTO, DESCRIPCION, CANTIDAD, PRECIO, DIAS_ENTREGA) VALUES (" & ID_ORDEN_COMPRA & ", '" & ID_PRODUCTO & "', '" & Descripcion & "', " & CANTIDAD & ", " & Precio & ", " & DIAS_ENTREGA & ");"
						Dim cmd3 As New SqlCommand(sqlQuery, cnn)
						cmd3.ExecuteNonQuery()
						NUM_ORDENS = ID_ORDEN_COMPRA
					Else
						sqlQuery = "UPDATE ORDEN_COMPRA_DETALLE SET CANTIDAD = " & CANTIDAD & ",  PRECIO = " & Precio & ", DIAS_ENTREGA = " & DIAS_ENTREGA & "  WHERE ID_PRODUCTO = '" & ID_PRODUCTO & "' AND ID_ORDEN_COMPRA = " & NUM_ORDENS
						Dim cmd4 As New SqlCommand(sqlQuery, cnn)
						cmd4.ExecuteNonQuery()
					End If
					IDC = GVProductosProveedor.Rows(i).Cells(1).Text 'ID_COTIZACION
					If GVProductosProveedor.Rows(i).Cells(10).Text <> " " Then 'IDC EN EL GRID
						IDC = IDC & "," & GVProductosProveedor.Rows(i).Cells(10).Text 'CONCANTENAR LOS IDC
					End If
					sqlQuery = "UPDATE COTIZA_REQUI SET NUMOC = " & ID_ORDEN_COMPRA & " WHERE ID_COTIZACION IN (" & IDC & ")"
					Dim cmd5 As New SqlCommand(sqlQuery, cnn)
					cmd5.ExecuteNonQuery()
				Next
				num_orden = Val(NUM_ORDENS)
				Response.Write("<script>window.alert('Registro actualizado con éxito');</script>")
				cnn.Close()
			End If
			'CAMBIAR ESTADO DE LA COTIZACION
			If MsgBox("Desea guardar la orden de compra", vbYesNo, "Información") = vbYes Then
				cnn.Open()
				For i As Integer = 0 To GVProductosProveedor.Rows.Count - 1
					Dim Row As GridViewRow = GVProductosProveedor.Rows(i)
					IDC = GVProductosProveedor.Rows(i).Cells(1).Text 'ID_COTIZACION
					If GVProductosProveedor.Rows(i).Cells(10).Text <> " " Then 'IDC EN EL GRID
						IDC = IDC & "," & GVProductosProveedor.Rows(i).Cells(10).Text 'CONCANTENAR LOS IDC
					End If
					sqlQuery = "UPDATE COTIZA_REQUI SET ESTADO_ACTUAL = 'C' WHERE ID_COTIZACION IN (" & IDC & ")"
					Dim cmd6 As New SqlCommand(sqlQuery, cnn)
					cmd6.ExecuteNonQuery()
				Next
				sqlQuery = "UPDATE ORDEN_COMPRA SET CONFIRMADA = 'P' WHERE ID_ORDEN_COMPRA = " & num_orden
				Dim cmd7 As New SqlCommand(sqlQuery, cnn)
				cmd7.ExecuteNonQuery()
				cnn.Close()
			End If
			'IMPRIMIR REPORTE ORDEN DE COMPRA
			If MsgBox("Desea imprimir la orden de compra", vbYesNo, "Información") = vbYes Then
				If num_orden <> 0 Then
					Dim Rapida As String
					Dim IdordenCompra As Integer = num_orden
					Dim Usuario As Integer = 50 'CAMBIAR A LOS USUARIOS DEPENDIENDO  DEL ROL
					Dim URL As String = Request.RawUrl
					If ChkBNacional.Checked = True Then
						Rapida = "N"
					ElseIf ChkBIndirecta.Checked = True Then
						Rapida = "S"
					ElseIf ChkBInternacional.Checked = True Then
						Rapida = "N"
					End If
					Response.Redirect("~/Procesos/RPT/ReporteOrdenCompra.aspx?IdordenCompra=" & IdordenCompra & "&Usuario=" & Usuario & "&URL=" & URL & "&Rapida=" & Rapida)
				End If
			End If
			Nuevo()
			Llenar_Lista_Proveedores()
		End If
    End Sub

	Protected Sub BTNSalir_Click(sender As Object, e As ImageClickEventArgs)
		Response.Redirect("~/Default")
	End Sub

	Sub Llenar_Lista_Proveedores()
		cnn.Open()
		sqlQuery = "SELECT P.ID_PROVEEDOR, P.NOMBRE, P.DIRECCION, P.COLONIA, P.CIUDAD, P.CP, P.RFC, P.TELEFONO1, P.TELEFONO2, P.TELEFONO3, P.NOTAS, P.ESTADO, P.PAIS FROM PROVEEDOR AS P JOIN COTIZA_REQUI AS C ON C.ID_PROVEEDOR = P.ID_PROVEEDOR WHERE P.ELIMINADO = 'N' AND C.ESTADO_ACTUAL = 'X' AND (C.ID_PRODUCTO <> '') GROUP BY P.ID_PROVEEDOR, P.NOMBRE, P.DIRECCION, P.COLONIA, P.CIUDAD, P.CP, P.RFC, P.TELEFONO1, P.TELEFONO2, P.TELEFONO3, P.NOTAS, P.ESTADO, P.PAIS ORDER BY P.NOMBRE"
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
		Dim index As Integer = 0
		Dim TablaProveedores As New DataTable
		TablaProveedores = Session("TablaProveedores")
		If Renglon > -1 Then
			Try
				cnn.Open()
				Session("IdProveeedor") = TablaProveedores(Renglon).Item("ID_PROVEEDOR")
				sqlQuery = "SELECT ISNULL(' ',NUMOC) AS NUMOC, ID_COTIZACION, ID_REQUISICION, ID_PROVEEDOR, ID_PRODUCTO, DESCRIPCION, CANTIDAD, DIAS_ENTREGA, PRECIO, FECHA, ' ' AS IDS, ISNULL(MONEDA, '') AS MONEDA, NO_PEDIDO FROM COTIZA_REQUI WHERE ESTADO_ACTUAL = 'X' AND ID_PROVEEDOR = " & TablaProveedores(Renglon).Item("ID_PROVEEDOR") & " AND (ID_PRODUCTO <> '')"
				Dim objCmd As New SqlCommand(sqlQuery, cnn)
				objCmd.ExecuteNonQuery()
				Dim da As New SqlDataAdapter(objCmd)
				Dim dt As New DataTable
				da.Fill(dt)
				GVProductosProveedor.AutoGenerateColumns = False
				GVProductosProveedor.DataSource = dt
				GVProductosProveedor.DataBind()
				Session("TablaCotizar") = dt
				SumarImporte()
				cnn.Close()
			Catch ex As InvalidCastException
			End Try
		End If
	End Sub

	Protected Sub BTNEliminar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
		Dim IDC As String
		Dim TBResponsable As LinkButton = CType(sender, LinkButton)
		Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
		Dim Renglon As Integer = gvrFilaActual.RowIndex
		'Select Case MsgBox("ESTA SEGURO QUE DESEA ELIMINAR ESTE PRODUCTO DE LA ORDEN DE COMPRA?", MsgBoxStyle.YesNo, "Información")
		'	Case MsgBoxResult.Yes
		IDC = GVProductosProveedor.Rows(Renglon).Cells(1).Text 'ID_COTIZACION
		If GVProductosProveedor.Rows(Renglon).Cells(10).Text <> " " Then 'IDC EN EL GRID
			IDC = IDC & "," & GVProductosProveedor.Rows(Renglon).Cells(10).Text 'CONCANTENAR LOS IDC
		End If
		If GVProductosProveedor.Rows(Renglon).Cells(11).Text <> " " Then 'NUMERO DE ORDEN DE COMPRA CELL(9)
			cnn.Open()
			sqlQuery = "DELETE FROM ORDEN_COMPRA_DETALLE WHERE ID_PRODUCTO = '" & GVProductosProveedor.Rows(Renglon).Cells(4).Text & "' AND ID_ORDEN_COMPRA = " & GVProductosProveedor.Rows(Renglon).Cells(11).Text
			Dim Comando1 As New SqlCommand(sqlQuery, cnn)
			Comando1.ExecuteNonQuery()
			sqlQuery = "DELETE FROM COTIZA_REQUI WHERE ID_PRODUCTO = '" & GVProductosProveedor.Rows(Renglon).Cells(4).Text & "' AND ID_PROVEEDOR = '" & GVProductosProveedor.Rows(Renglon).Cells(3).Text & " ' AND ESTADO_ACTUAL = 'X'"
			Dim Comando2 As New SqlCommand(sqlQuery, cnn)
			Comando2.ExecuteNonQuery()
			cnn.Close()
		End If
		cnn.Open()
		sqlQuery = "UPDATE COTIZA_REQUI SET ESTADO_ACTUAL = 'Z' WHERE ID_COTIZACION IN (" & IDC & ")"
		Dim Comando3 As New SqlCommand(sqlQuery, cnn)
		Comando3.ExecuteNonQuery()
		cnn.Close()
		Nuevo()
		Llenar_Lista_Proveedores()
		'cnn.Close()
		'Case MsgBoxResult.No
		'End Select
	End Sub

	Protected Sub TBCantidad(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Private Sub SumarImporte()
		TBSubtotal.Text = 0
		TBImpuestos.Text = 0
		TBTotal.Text = 0
		For i As Integer = 0 To GVProductosProveedor.Rows.Count - 1
			Dim row As GridViewRow = GVProductosProveedor.Rows(i)
			TBSubtotal.Text = CDbl(CDbl(TBSubtotal.Text) + (CStr(CType(row.FindControl("TBCantidad"), TextBox).Text) * row.Cells(8).Text))
			If ChkBInternacional.Checked = False Then
				TBImpuestos.Text = CDbl(CDbl(TBSubtotal.Text) * 0.16)
			Else
				TBImpuestos.Text = 0
			End If
			TBTotal.Text = CDbl(CDbl((TBSubtotal.Text) - CDbl(TBDescuento.Text)) + (CDbl(TBImpuestos.Text) + CDbl(TBOtrosCargos.Text) + CDbl(TBFlete.Text)))
		Next
	End Sub

	Private Sub ActualizarCantidadesPorProducto()
		Dim index As Integer = 0
		Dim TablaCotizar As New DataTable
		TablaCotizar = Session("TablaCotizar")
		For Each Row As GridViewRow In GVProductosProveedor.Rows
			index = Convert.ToUInt64(Row.RowIndex)
			If TablaCotizar.Rows.Count >= 1 Then
				cnn.Open()
				sqlQuery = "UPDATE COTIZA_REQUI SET CANTIDAD = " & CStr(CType(Row.FindControl("TBCantidad"), TextBox).Text) & " WHERE ID_COTIZACION = " & TablaCotizar.Rows(index).Item("ID_COTIZACION") & " AND ID_PRODUCTO = " & "'" & TablaCotizar.Rows(index).Item("ID_PRODUCTO") & "'"
				Dim objCmd As New SqlCommand(sqlQuery, cnn)
				objCmd.ExecuteNonQuery()
				cnn.Close()
			End If
		Next
	End Sub

	Private Sub Agregar()
		'Dim TablaAux As New DataTable()
		'Dim bandera As Boolean = False
		'TablaGuardar = Session("TablaGuardar")
		'TablaAux = Session("TablaCotizar")
		'For Each MiDataRow As GridViewRow In GVProductosProveedor.Rows
		'	Dim RenglonAInsertar As DataRow
		'	Dim index As Integer = 0
		'	index = Convert.ToUInt64(MiDataRow.RowIndex)
		'	If CType(MiDataRow.FindControl("CBGVProducto"), CheckBox).Checked = True Then
		'		bandera = False
		'		For Each row As DataRow In TablaGuardar.Rows
		'			If TablaAux.Rows(index).Item("ID_PRODUCTO") = row.Item("ID_PRODUCTO") Then
		'				MsgBox("El producto" + " " + TablaAux.Rows(index).Item("DESCRIPCION") + " " + "ya esta en la lista",, "Informacion")
		'				bandera = True
		'				Exit For
		'			End If
		'		Next
		'		If bandera = True Then
		'		Else
		'			RenglonAInsertar = TablaGuardar.NewRow()
		'			RenglonAInsertar("ID_COTIZACION") = TablaAux.Rows(index).Item("ID_COTIZACION")
		'			RenglonAInsertar("ID_REQUISICION") = TablaAux.Rows(index).Item("ID_REQUISICION")
		'			RenglonAInsertar("ID_PROVEEDOR") = TablaAux.Rows(index).Item("ID_PROVEEDOR")
		'			RenglonAInsertar("ID_PRODUCTO") = TablaAux.Rows(index).Item("ID_PRODUCTO")
		'			RenglonAInsertar("CANTIDAD") = GVProductosProveedor.Rows(index).Cells(6).Text
		'			RenglonAInsertar("DIAS_ENTREGA") = CStr(CType(MiDataRow.FindControl("TBDiasEntrega"), TextBox).Text)
		'			RenglonAInsertar("PRECIO") = CStr(CType(MiDataRow.FindControl("TBPrecio"), TextBox).Text)
		'			RenglonAInsertar("MONEDA") = CStr(CType(MiDataRow.FindControl("Combo1"), DropDownList).Text)
		'			TablaGuardar.Rows.Add(RenglonAInsertar)
		'		End If
		'	End If
		'Next
		'Session("TablaGuardar") = TablaGuardar
	End Sub

	Protected Sub Guardar()
		'Dim tabla As New DataTable()
		'tabla = Session("TablaGuardar")
		'If tabla.Rows.Count = 0 Then
		'	MsgBox("No hay productos en la lista",, "Informacion")
		'	Exit Sub
		'Else
		'	Dim cnn As New SqlConnection(abrirConexion)
		'	Try
		'		cnn.Open()
		'		Dim index As Integer = 0
		'		For Each MiDataRow As DataRow In tabla.Rows
		'			sqlQuery = "UPDATE COTIZA_REQUI SET ESTADO_ACTUAL = 'A',  DIAS_ENTREGA = " & tabla.Rows(index).Item("DIAS_ENTREGA") & ", PRECIO = " & tabla.Rows(index).Item("PRECIO") & ", MONEDA = '" & tabla.Rows(index).Item("MONEDA") & "' WHERE ID_COTIZACION = " & tabla.Rows(index).Item("ID_COTIZACION")
		'			Dim objCmd As New SqlCommand(sqlQuery, cnn)
		'			objCmd.ExecuteNonQuery()
		'			sqlQuery = "UPDATE REQUISICION SET COTIZADA = 1, ACTIVO = 0 WHERE ID_REQUISICION = " & tabla.Rows(index).Item("ID_REQUISICION")
		'			Dim objCmd2 As New SqlCommand(sqlQuery, cnn)
		'			objCmd2.ExecuteNonQuery()
		'			index = index + 1
		'		Next
		'		cnn.Close()
		'	Catch ex As Exception
		'		ex.Message.ToString()
		'	End Try
		'End If
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
		'#########################CONTROLES#######################
		TBSubtotal.Text = 0
		TBDescuento.Text = 0
		TBOtrosCargos.Text = 0
		TBFlete.Text = 0
		TBImpuestos.Text = 0
		TBTotal.Text = 0
		TBComentarios.Text = ""
		Label10.Visible = False
		DDDiasCredito.Visible = False
	End Sub

	Protected Sub BTNNuevo_Click(sender As Object, e As EventArgs) Handles BTNuevo.Click

	End Sub

	Protected Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
		Response.Redirect("~/")
	End Sub

	Protected Sub ChkBNacional_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBNacional.CheckedChanged
		If ChkBNacional.Checked = True Then
			ChkBInternacional.Checked = False
			ChkBIndirecta.Checked = False
			Dim totiva As Double
			TBImpuestos.Text = 0
			TBTotal.Text = 0
			totiva = 0
			TBImpuestos.Text = CDbl((TBSubtotal.Text - TBDescuento.Text + TBFlete.Text + TBOtrosCargos.Text) * 0.16)
			totiva = CDbl((TBSubtotal.Text - TBDescuento.Text + TBFlete.Text) * 0.16)
			TBTotal.Text = CDbl(TBSubtotal.Text - TBDescuento.Text + TBFlete.Text + TBOtrosCargos.Text + TBImpuestos.Text)
			DDMoneda.Enabled = True
			DDMoneda.SelectedValue = "PESOS"
		End If
	End Sub

	Protected Sub ChkBInternacional_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBInternacional.CheckedChanged
		If ChkBInternacional.Checked = True Then
			ChkBNacional.Checked = False
			ChkBIndirecta.Checked = False
			TBImpuestos.Text = 0
			TBTotal.Text = 0
			TBTotal.Text = CDbl((TBSubtotal.Text) + CDbl(TBImpuestos.Text) + CDbl(TBFlete.Text) + CDbl(TBOtrosCargos.Text) - CDbl(TBDescuento.Text))
			DDMoneda.Enabled = False
			DDMoneda.SelectedValue = "DOLARES"
		End If
	End Sub

	Protected Sub ChkBIndirecta_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBIndirecta.CheckedChanged
		If ChkBIndirecta.Checked = True Then
			ChkBNacional.Checked = False
			ChkBInternacional.Checked = False
			TBImpuestos.Text = 0
			TBTotal.Text = 0
			TBImpuestos.Text = CDbl(CDbl((TBSubtotal.Text) - CDbl(TBDescuento.Text)) + (CDbl(TBFlete.Text) * 0.16))
			TBTotal.Text = CDbl((TBSubtotal.Text) + CDbl(TBImpuestos.Text) + CDbl(TBFlete.Text) + CDbl(TBOtrosCargos.Text))
			DDMoneda.Enabled = True
			DDMoneda.SelectedValue = "PESOS"
		End If
	End Sub

	Protected Sub ChkBCredito_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBCredito.CheckedChanged
		If ChkBCredito.Checked = True Then
			ChkBContado.Checked = False
			DDDiasCredito.Visible = True
			Label10.Visible = True
		End If
	End Sub

	Protected Sub ChkBContado_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBContado.CheckedChanged
		If ChkBContado.Checked = True Then
			ChkBCredito.Checked = False
			DDDiasCredito.Visible = False
			Label10.Visible = False
		End If
	End Sub

	Protected Sub TBDescuento_TextChanged(sender As Object, e As EventArgs) Handles TBDescuento.TextChanged
		SumarImporte()
	End Sub

	Protected Sub TBOtrosCargos_TextChanged(sender As Object, e As EventArgs) Handles TBOtrosCargos.TextChanged
		SumarImporte()
	End Sub

	Protected Sub TBFlete_TextChanged(sender As Object, e As EventArgs) Handles TBFlete.TextChanged
		SumarImporte()
	End Sub

	Protected Sub BTNActualizar_Click(sender As Object, e As ImageClickEventArgs) Handles BTNActualizar.Click
		If TBTotal.Text = 0 Then
			Response.Write("<script>window.alert('Seleccionar el tipo de orden de compra');</script>")
		Else
			ActualizarCantidadesPorProducto()
			Nuevo()
			Llenar_Lista_Proveedores()
		End If
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