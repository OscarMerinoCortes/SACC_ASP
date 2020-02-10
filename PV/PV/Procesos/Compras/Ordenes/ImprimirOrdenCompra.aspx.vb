Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Web.Security

Public Class ImprimirOrdenCompra
	Inherits System.Web.UI.Page
	Dim sqlQuery As String
	Dim cnn As New SqlConnection(abrirConexion)
	Public TablaGuardar As New DataTable()
	Public VistaGuardar As DataView
	Public Cantidad As Integer = 0
	Public IdCotizacion As Integer = 0
	Public IdRequisicion As Integer = 0
	Public Dolar As Double = 0
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Page.IsPostBack Then
			'Nuevo()
			'ObtenerUltimoPrecioDolar()
			Llenar_Lista_Requisiciones()
			MultiView1.SetActiveView(VRegistro)
		End If
	End Sub

	Protected Sub BTNFiltar_Click(sender As Object, e As EventArgs) Handles BTNFiltar.Click
		Nuevo()
		Llenar_Lista_Requisiciones()
	End Sub

	Protected Sub BTNNuevo_Click(sender As Object, e As ImageClickEventArgs)
		'Nuevo()
	End Sub

	Protected Sub BTNReimprimir_Click(sender As Object, e As ImageClickEventArgs) Handles BTNReimprimir.Click
		MultiView1.SetActiveView(VAdministracion)
	End Sub

	Protected Sub BTNImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles BTNImprimir.Click
		If TBFolio.Text <> "" Then
			cnn.Open()
			sqlQuery = "SELECT*FROM ORDEN_COMPRA WHERE ID_ORDEN_COMPRA = " & TBFolio.Text
			Dim cmdVerificar As New SqlCommand(sqlQuery, cnn)
			cmdVerificar.ExecuteNonQuery()
			Dim da As New SqlDataAdapter(cmdVerificar)
			Dim dt As New DataTable
			da.Fill(dt)
			If dt.Rows.Count = 0 Then
				Response.Write("<script language='javascript'>window.alert('No existe esta orden de compra');</script>")
			Else
				sqlQuery = "UPDATE ORDEN_COMPRA SET TOTAL = '" & TBSubtotal.Text & "', ENVIARA = '" & TBEnviar.Text & "', DISCOUNT = " & TBDescuento.Text & ", FREIGHT = " & TBFlete.Text & ", TAX = " & TBImpuestos.Text & ", OTROS_CARGOS = '" & TBOtrosCargos.Text & "', COMENTARIO = '" & TBComentarios.Text & "'  WHERE ID_ORDEN_COMPRA = " & TBFolio.Text
				Dim objCmd As New SqlCommand(sqlQuery, cnn)
				objCmd.ExecuteNonQuery()
				If MsgBox("Desea cerrar la orden de compra", vbYesNo, "Información") = vbYes Then
					If TBFolio.Text <> 0 Then
						Dim Rapida As String
						If DDTipoOrdeCompra.SelectedValue = "X" Then
							Rapida = "S"
						Else
							Rapida = "N"
						End If
						Dim IdordenCompra As Integer = TBFolio.Text
						Dim Usuario As Integer = Session("Usuario") 'CAMBIAR A LOS USUARIOS DEPENDIENDO  DEL ROL
						Dim URL As String = Request.RawUrl
						Response.Redirect("~/Procesos/RPT/ReporteOrdenCompra.aspx?IdordenCompra=" & IdordenCompra & "&Usuario=" & Usuario & "&URL=" & URL & "&Rapida=" & Rapida)
						sqlQuery = "UPDATE ORDEN_COMPRA SET TOTAL = " & TBSubtotal.Text & ", ENVIARA = '" & TBEnviar.Text & "', DISCOUNT = " & TBDescuento.Text & ", FREIGHT = " & TBFlete.Text & ", TAX = " & TBImpuestos.Text & ", OTROS_CARGOS = " & TBOtrosCargos.Text & ", COMENTARIO = '" & TBComentarios.Text & "', CONFIRMADA = 'X' WHERE ID_ORDEN_COMPRA = " & TBFolio.Text
						Dim Cmd As New SqlCommand(sqlQuery, cnn)
						Cmd.ExecuteNonQuery()
					End If
				End If
			End If
			cnn.Close()
			Nuevo()
			Llenar_Lista_Requisiciones()
		Else
			Response.Write("<script language='javascript'>window.alert('Seleccione una orden de compra');</script>")
		End If
	End Sub

	Protected Sub BTNSalir_Click1(sender As Object, e As ImageClickEventArgs) Handles BTNSalir.Click
		Response.Redirect("~/Default")
	End Sub

	Protected Sub IMImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles IMImprimir.Click
		'CODIGO PARA REIMPRIMIR UNA ORDEN CERRADA
		If TBNoOrden.Text = "" Then
			Response.Write("<script language='javascript'>window.alert('Ingrese un numero de orden');</script>")
		Else
			cnn.Open()
			sqlQuery = "SELECT * FROM ORDEN_COMPRA WHERE NUM_ORDEN = " & TBNoOrden.Text & " AND TIPO = " & "'" & DDTipoOrdenCompra2.SelectedValue & "'" & " AND CONFIRMADA <> 'A'"
			Dim cmd As New SqlCommand(sqlQuery, cnn)
			cmd.ExecuteNonQuery()
			Dim da As New SqlDataAdapter(cmd)
			Dim dt As New DataTable
			da.Fill(dt)
			If dt.Rows.Count = 0 Then
				Response.Write("<script language='javascript'>window.alert('No se encuentra la orden de compra solicitada, revise si esta cancelada o aun no se genere un folio');</script>")
			Else
				Session("UsuarioReimprimir") = dt.Rows(0).Item("ID_USUARIO")
				Session("ID_ORDEN_COMPRA") = dt.Rows(0).Item("ID_ORDEN_COMPRA")
				Dim Rapida As String
				If DDTipoOrdenCompra2.SelectedValue = "X" Then
					Rapida = "S"
				Else
					Rapida = "N"
				End If
				Dim IdordenCompra As Integer = Session("ID_ORDEN_COMPRA")
				Dim Usuario As Integer = Session("UsuarioReimprimir") 'CAMBIAR A LOS USUARIOS DEPENDIENDO  DEL ROL
				Dim URL As String = Request.RawUrl
				Response.Redirect("~/Procesos/RPT/ReporteOrdenCompra.aspx?IdordenCompra=" & IdordenCompra & "&Usuario=" & Usuario & "&URL=" & URL & "&Rapida=" & Rapida)
			End If
		End If
	End Sub

	Protected Sub BTNGuardar2_Click(sender As Object, e As ImageClickEventArgs) Handles BTNGuardar.Click
		'If TBSubtotal.Text <> 0 And TBTotal.Text <> 0 And TBFolio.Text <> "" Then
		'	cnn.Open()
		'	sqlQuery = "UPDATE ORDEN_COMPRA SET CONFIRMADA = 'S', COMENTARIO = '" & TBComentarios.Text & "', ENVIARA = '" & TBEnviar.Text & "', ID_USUARIO_AUT = " & 55 & " WHERE ID_ORDEN_COMPRA = " & TBFolio.Text
		'	Dim objCmd As New SqlCommand(sqlQuery, cnn)
		'	objCmd.ExecuteNonQuery()
		'	cnn.Close()
		'	Nuevo()
		'	Llenar_Lista_Requisiciones()
		'End If

		'Dim TablaCotizacionesEliminar As New DataTable
		'Dim index As Integer = 0
		'IdCotizacion = Session("IdCotizacion")
		'IdRequisicion = Session("IdRequisicion")
		'Cantidad = Session("Cantidad")
		'Dolar = Session("Dolar")
		'TablaCotizacionesEliminar = Session("TablaCotizaciones")
		'If IdCotizacion = 0 Then
		'	MsgBox("SELECCIONE LA COTIZACION AUTORIZADA", vbInformation, "Informacion")
		'Else
		'	Try
		'		cnn.Open()
		'		sqlQuery = "UPDATE COTIZA_REQUI SET ESTADO_ACTUAL = 'X', CANTIDAD = " & Cantidad & " WHERE ID_COTIZACION = " & IdCotizacion
		'		Dim objCmd As New SqlCommand(sqlQuery, cnn)
		'		objCmd.ExecuteNonQuery()
		'		sqlQuery = "UPDATE REQUISICION SET ACTIVO = '1' WHERE ID_REQUISICION = " & IdRequisicion
		'		Dim objCmd2 As New SqlCommand(sqlQuery, cnn)
		'		objCmd2.ExecuteNonQuery()
		'		For Each row As DataRow In TablaCotizacionesEliminar.Rows
		'			If TablaCotizacionesEliminar.Rows(index).Item("ID_COTIZACION") <> IdCotizacion Then
		'				sqlQuery = "DELETE FROM COTIZA_REQUI WHERE ESTADO_ACTUAL <> 'X' AND ID_COTIZACION = " & IdCotizacion
		'				Dim objCmd3 As New SqlCommand(sqlQuery, cnn)
		'				objCmd3.ExecuteNonQuery()
		'			End If
		'		Next
		'		cnn.Close()
		'		Nuevo()
		'		ObtenerUltimoPrecioDolar()
		'		Llenar_Lista_Requisiciones()
		'	Catch ex As Exception
		'		MsgBox("Error: " & Err.Number & " " & Err.Description, vbCritical, "Informacion")
		'	End Try
		'End If
	End Sub

	Sub Llenar_Lista_Requisiciones()
		cnn.Open()
		sqlQuery = "SELECT  OC.Id_Orden_Compra, OC.Id_Proveedor, P.Nombre, ((OC.Total - OC.Discount) + OC.TAX + OC.Freight + OC.Otros_Cargos) AS Total_Pagar, oc.COMENTARIO FROM ORDEN_COMPRA AS OC JOIN PROVEEDOR AS P ON P.Id_Proveedor = OC.Id_Proveedor WHERE OC.Tipo = " & "'" & DDTipoOrdeCompra.SelectedValue & "'" & " AND OC.Confirmada = 'S'"
		Dim objCmd As New SqlCommand(sqlQuery, cnn)
		objCmd.ExecuteNonQuery()
		Dim da As New SqlDataAdapter(objCmd)
		Dim dt As New DataTable
		da.Fill(dt)
		GVOrdenes.AutoGenerateColumns = False
		GVOrdenes.DataSource = dt
		GVOrdenes.DataBind()
		Session("TablaOrdenesCompra") = dt
		cnn.Close()
	End Sub

	Protected Sub BTNSeleccionar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
		Dim TBResponsable As LinkButton = CType(sender, LinkButton)
		Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
		Dim Renglon As Integer = gvrFilaActual.RowIndex
		Dim TablaOrdenCompraEncabezado As New DataTable
		Dim index As Integer = 0
		Dim Subtotal As Double = 0
		Dim NO As Integer
		TablaOrdenCompraEncabezado = Session("TablaOrdenesCompra")
		If TablaOrdenCompraEncabezado.Rows.Count <> 0 Then
			TBFolio.Text = TablaOrdenCompraEncabezado.Rows(Renglon).Item("ID_ORDEN_COMPRA")
			If Renglon > -1 Then
				Try
					'LLENAR EL ENCABEZADO
					cnn.Open()
					sqlQuery = "SELECT * FROM ORDEN_COMPRA WHERE ID_ORDEN_COMPRA = " & TBFolio.Text
					Dim objCmd As New SqlCommand(sqlQuery, cnn)
					objCmd.ExecuteNonQuery()
					Dim da As New SqlDataAdapter(objCmd)
					Dim dt As New DataTable
					da.Fill(dt)
					If dt.Rows(0).Item("TIPO") = "I" Then
						TBMoneda.Text = "DOLARES"
					ElseIf dt.Rows(0).Item("TIPO") = "N" Then
						TBMoneda.Text = "PESOS"
					End If
					TBDescuento.Text = dt.Rows(0).Item("DISCOUNT")
					TBImpuestos.Text = dt.Rows(0).Item("TAX")
					TBFlete.Text = dt.Rows(0).Item("FREIGHT")
					TBOtrosCargos.Text = dt.Rows(0).Item("OTROS_CARGOS")
					TBEnviar.Text = dt.Rows(0).Item("ENVIARA")
					TBComentarios.Text = dt.Rows(0).Item("COMENTARIO")
					TBMoneda.Text = dt.Rows(0).Item("MONEDA")
					Subtotal = 0
					Session("Usuario") = dt.Rows(0).Item("ID_USUARIO")
					Session.Timeout = 5
					'LLENAR EL DETALLES
					sqlQuery = "SELECT * FROM ORDEN_COMPRA_DETALLE WHERE ID_ORDEN_COMPRA = " & TBFolio.Text
					Dim objCmd2 As New SqlCommand(sqlQuery, cnn)
					objCmd2.ExecuteNonQuery()
					Dim da2 As New SqlDataAdapter(objCmd2)
					Dim dt2 As New DataTable
					da2.Fill(dt2)
					For Each Row As DataRow In dt2.Rows
						If dt2.Rows(index).Item("PRECIO") <> 0 And dt2.Rows(index).Item("CANTIDAD") <> 0 Then
							Subtotal = Subtotal + CDbl(dt2.Rows(index).Item("PRECIO") * dt2.Rows(index).Item("CANTIDAD"))
						End If
						index = index + 1
					Next
					TBSubtotal.Text = Subtotal
					TBTotal.Text = CDbl(Subtotal - TBDescuento.Text + TBImpuestos.Text + TBFlete.Text + TBOtrosCargos.Text)
					GVProductosOrdenes.AutoGenerateColumns = False
					GVProductosOrdenes.DataSource = dt2
					GVProductosOrdenes.DataBind()
					Session("TablaProductosOrdenes") = dt2
					cnn.Close()
				Catch ex As InvalidCastException
				End Try
			End If
		Else
			Response.Write("<script language='javascript'>window.alert('Falta de informacion, contacte al area de sistemas');</script>")
		End If
	End Sub

	Protected Sub BTNSeleccionarCotizacion_OnClick(ByVal sender As Object, ByVal e As EventArgs)
		'Dim TBResponsable As LinkButton = CType(sender, LinkButton)
		'Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
		'Dim Renglon As Integer = gvrFilaActual.RowIndex
		''For Each Row As GridViewRow In GVCotizaciones.Rows
		''	Dim index As Integer = 0
		''	index = Convert.ToUInt64(Row.RowIndex)
		''	If index = Renglon Then
		''		Row.BackColor = System.Drawing.Color.SkyBlue
		''	End If
		''Next
		'Dim TablaCotizaciones As New DataTable
		'TablaCotizaciones = Session("TablaCotizaciones")
		'If Renglon > -1 Then
		'	Try
		'		Session("IdCotizacion") = TablaCotizaciones.Rows(Renglon).Item("ID_COTIZACION")
		'		Session("IdRequisicion") = TablaCotizaciones.Rows(Renglon).Item("ID_REQUISICION")
		'		Session("Cantidad") = TablaCotizaciones.Rows(Renglon).Item("CANTIDAD")
		'	Catch ex As InvalidCastException
		'	End Try
		'End If
	End Sub

	Private Sub Nuevo()
		TBMoneda.Text = ""
		TBSubtotal.Text = 0
		TBDescuento.Text = 0
		TBOtrosCargos.Text = 0
		TBFlete.Text = 0
		TBImpuestos.Text = 0
		TBTotal.Text = 0
		TBComentarios.Text = ""
		TBEnviar.Text = ""
		TBFolio.Text = ""
		GVProductosOrdenes.DataSource = Nothing
		GVProductosOrdenes.DataBind()
	End Sub

	Private Sub LimpiarView2()
		'TBNoOrden.Text = ""
		'TBComentariosAccion.Text = ""
	End Sub

	Sub ObtenerUltimoPrecioDolar()
		'cnn.Open()
		'sqlQuery = "SELECT TOP 1 isnull(VENTA, 0) AS VENTA FROM DOLAR ORDER BY FECHA"
		'Dim objCmd As New SqlCommand(sqlQuery, cnn)
		'objCmd.ExecuteNonQuery()
		'Dim da As New SqlDataAdapter(objCmd)
		'Dim dt As New DataTable
		'da.Fill(dt)
		'If dt.Rows.Count = 0 Then
		'	Session("Dolar") = 1
		'	MsgBox("NO EXISTEN REGISTROS DEL TIPO DE CAMBIO DEL DOLAR", vbInformation, "Informacion")
		'Else
		'	Session("Dolar") = dt.Rows(0).Item("VENTA")
		'End If
		'cnn.Close()
	End Sub

	Protected Sub GVOrdenes_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
		'Llenar_Lista_Requisiciones()
		'GVOrdenes.PageIndex = e.NewPageIndex
		'GVOrdenes.DataBind()
	End Sub

	Protected Sub GVProductosOrdenes_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
		'GVProductosOrdenes.DataSource = Session("TablaProductosOrdenes")
		'GVProductosOrdenes.PageIndex = e.NewPageIndex
		'GVProductosOrdenes.DataBind()
	End Sub

	Protected Sub IMBRegresar_Click(sender As Object, e As ImageClickEventArgs) Handles IMBRegresar.Click
		MultiView1.SetActiveView(VRegistro)
	End Sub

	Protected Sub IMSalir_Click(sender As Object, e As ImageClickEventArgs) Handles IMSalir.Click
		Response.Redirect("~/Default")
	End Sub

	Protected Sub BTNGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles BTNGuardar.Click
		'If TBNoOrden.Text = "" Or TBComentariosAccion.Text = "" Then
		'	Response.Write("<script language='javascript'>window.alert('No se ha especificado un numero de orden o agregado un comentario');</script>")
		'Else
		'	cnn.Open()
		'	If DDAccion.SelectedValue = 1 Then
		'		sqlQuery = "SELECT ID_ORDEN_COMPRA, CONFIRMADA FROM ORDEN_COMPRA WHERE NUM_ORDEN = " & TBNoOrden.Text & " AND TIPO = '" & DDTipoOrdenCompra2.SelectedValue & "'"
		'		Dim objCmd As New SqlCommand(sqlQuery, cnn)
		'		objCmd.ExecuteNonQuery()
		'		Dim da As New SqlDataAdapter(objCmd)
		'		Dim dt As New DataTable
		'		da.Fill(dt)
		'		If dt.Rows.Count <> 0 Then
		'			If dt.Rows(0).Item("CONFIRMADA") = "Y" Then
		'				Response.Write("<script language='javascript'>window.alert('Esta orden ya tiene un pago, imposible cancelarla');</script>")
		'				TBNoOrden.Text = ""
		'			Else
		'				sqlQuery = "SELECT SUM(SURTIDO) AS ENTRADA, ID_ORDEN_COMPRA FROM ORDEN_COMPRA_DETALLE WHERE ID_ORDEN_COMPRA = " & dt.Rows(0).Item("ID_ORDEN_COMPRA") & " GROUP BY ID_ORDEN_COMPRA"
		'				Dim objCmd2 As New SqlCommand(sqlQuery, cnn)
		'				objCmd2.ExecuteNonQuery()
		'				Dim da2 As New SqlDataAdapter(objCmd2)
		'				Dim dt2 As New DataTable
		'				da2.Fill(dt2)
		'				If dt2.Rows.Count <> 0 Then
		'					If dt2.Rows(0).Item("ENTRADA") = 0 Then
		'						'MODIFICAR AL USUARIO DEPENDIENDO EL ROL
		'						sqlQuery = "INSERT INTO ORDEN_CANCE (ORDEN, TIPO, COMENTARIO, FECHA, ID_USUARIO) VALUES (" & TBNoOrden.Text & ", '" & DDTipoOrdenCompra2.SelectedValue & "','" & TBComentariosAccion.Text & "','" & Format(Date.Now, "dd/MM/yyyy") & "','" & 55 & "');"
		'						Dim objCmd3 As New SqlCommand(sqlQuery, cnn)
		'						objCmd3.ExecuteNonQuery()
		'						sqlQuery = "UPDATE ORDEN_COMPRA SET CONFIRMADA = 'E' WHERE NUM_ORDEN = " & TBNoOrden.Text & " AND TIPO = '" & DDTipoOrdenCompra2.SelectedValue & "'"
		'						Dim objCmd4 As New SqlCommand(sqlQuery, cnn)
		'						objCmd4.ExecuteNonQuery()
		'						sqlQuery = "DELETE FROM ORDEN_COMPRA WHERE NUM_ORDEN = " & TBNoOrden.Text & " AND TIPO = '" & DDTipoOrdenCompra2.SelectedValue & "'"
		'						Dim objCmd5 As New SqlCommand(sqlQuery, cnn)
		'						objCmd5.ExecuteNonQuery()
		'						sqlQuery = "DELETE FROM ORDEN_COMPRA_DETALLE WHERE ID_ORDEN_COMPRA = " & dt.Rows(0).Item("ID_ORDEN_COMPRA")
		'						Dim objCmd6 As New SqlCommand(sqlQuery, cnn)
		'						objCmd6.ExecuteNonQuery()
		'						Response.Write("<script language='javascript'>window.alert('Orden de compra eliminada');</script>")
		'						LimpiarView2()
		'					Else
		'						Response.Write("<script language='javascript'>window.alert('La orden tiene entrada imposible cancelarla');</script>")
		'					End If
		'				End If
		'			End If
		'		Else
		'			Response.Write("<script language='javascript'>window.alert('La orden no existe o fue cancelada');</script>")
		'		End If
		'	ElseIf DDAccion.SelectedValue = 2 Then
		'		If TBNoOrden.Text <> "" Then
		'			sqlQuery = "SELECT CONFIRMADA FROM ORDEN_COMPRA WHERE NUM_ORDEN = " & TBNoOrden.Text & " AND TIPO = '" & DDTipoOrdenCompra2.SelectedValue & "'"
		'			Dim objCmd As New SqlCommand(sqlQuery, cnn)
		'			objCmd.ExecuteNonQuery()
		'			Dim da As New SqlDataAdapter(objCmd)
		'			Dim dt As New DataTable
		'			da.Fill(dt)
		'			If dt.Rows.Count <> 0 Then
		'				If dt.Rows(0).Item("CONFIRMADA") <> "Y" Then
		'					sqlQuery = "UPDATE ORDEN_COMPRA SET CONFIRMADA = 'P' WHERE NUM_ORDEN = " & TBNoOrden.Text & " AND TIPO = '" & DDTipoOrdenCompra2.SelectedValue & "'"
		'					Dim objCmd2 As New SqlCommand(sqlQuery, cnn)
		'					objCmd2.ExecuteNonQuery()
		'				Else
		'					sqlQuery = "SELECT NUMCHEQUE, FECHA FROM ABONOS_PAGO_OC WHERE NUM_ORDEN = " & TBNoOrden.Text & " AND TIPO = '" & DDTipoOrdenCompra2.SelectedValue & "'"
		'					Dim objCmd3 As New SqlCommand(sqlQuery, cnn)
		'					objCmd3.ExecuteNonQuery()
		'					Dim da3 As New SqlDataAdapter(objCmd3)
		'					Dim dt3 As New DataTable
		'					da3.Fill(dt3)
		'					If dt3.Rows.Count <> 0 Then
		'						MsgBox("La orden ya esta pagada, si la regresa se anulara el pago anterior, ¿Está seguro que desea regresarla?", MsgBoxStyle.YesNo, "Informacion")
		'						If MsgBoxResult.Yes Then
		'							sqlQuery = "UPDATE ORDEN_COMPRA SET CONFIRMADA = 'P' WHERE NUM_ORDEN = " & TBNoOrden.Text & " AND TIPO = '" & DDTipoOrdenCompra2.SelectedValue & "'"
		'							Dim objCmd4 As New SqlCommand(sqlQuery, cnn)
		'							objCmd4.ExecuteNonQuery()
		'							Response.Write("<script language='javascript'>window.alert('Orden de compra regresada con exito');</script>")
		'						End If
		'					End If
		'				End If
		'			Else
		'				Response.Write("<script language='javascript'>window.alert('Orden no encontrada, posiblemente no ha sido creada o fue eliminada!');</script>")
		'			End If
		'		End If
		'	End If
		'	cnn.Close()
		'	Llenar_Lista_Requisiciones()
		'End If
	End Sub
End Class