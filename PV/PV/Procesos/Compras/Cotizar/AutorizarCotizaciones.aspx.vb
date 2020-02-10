Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls
Imports System.Web.UI

Public Class AutorizarCotizaciones
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
			Nuevo()
			ObtenerUltimoPrecioDolar()
			Llenar_Lista_Requisiciones()
			MultiView1.SetActiveView(VRegistro)
		End If
	End Sub

	Protected Sub BTNNuevo_Click(sender As Object, e As ImageClickEventArgs)
		Nuevo()
	End Sub

	Protected Sub BTNAutorizar_Click(sender As Object, e As ImageClickEventArgs) Handles BTNAutorizar.Click
		Dim TablaCotizacionesEliminar As New DataTable
		Dim index As Integer = 0
		IdCotizacion = Session("IdCotizacion")
		IdRequisicion = Session("IdRequisicion")
		Cantidad = Session("Cantidad")
		Dolar = Session("Dolar")
		TablaCotizacionesEliminar = Session("TablaCotizaciones")
		If IdCotizacion = 0 Then
			MsgBox("SELECCIONE LA COTIZACION AUTORIZADA", vbInformation, "Informacion")
		Else
			Try
				cnn.Open()
				sqlQuery = "UPDATE COTIZA_REQUI SET ESTADO_ACTUAL = 'X', CANTIDAD = " & Cantidad & " WHERE ID_COTIZACION = " & IdCotizacion
				Dim objCmd As New SqlCommand(sqlQuery, cnn)
				objCmd.ExecuteNonQuery()
				sqlQuery = "UPDATE REQUISICION SET ACTIVO = '1' WHERE ID_REQUISICION = " & IdRequisicion
				Dim objCmd2 As New SqlCommand(sqlQuery, cnn)
				objCmd2.ExecuteNonQuery()
				For Each row As DataRow In TablaCotizacionesEliminar.Rows
					If TablaCotizacionesEliminar.Rows(index).Item("ID_COTIZACION") <> IdCotizacion Then
						sqlQuery = "DELETE FROM COTIZA_REQUI WHERE ESTADO_ACTUAL <> 'X' AND ID_COTIZACION = " & IdCotizacion
						Dim objCmd3 As New SqlCommand(sqlQuery, cnn)
						objCmd3.ExecuteNonQuery()
					End If
				Next
				cnn.Close()
				Nuevo()
				ObtenerUltimoPrecioDolar()
				Llenar_Lista_Requisiciones()
			Catch ex As Exception
				MsgBox("Error: " & Err.Number & " " & Err.Description, vbCritical, "Informacion")
			End Try
		End If
	End Sub

	Protected Sub BTNSalir_Click(sender As Object, e As ImageClickEventArgs)

	End Sub

	Sub Llenar_Lista_Requisiciones()
		cnn.Open()
		sqlQuery = "SELECT ID_REQUISICION, ID_PRODUCTO, DESCRIPCION, CANTIDAD, FECHA, isnull(CONTADOR,0) as CONTADOR FROM REQUISICION AS R WHERE (ACTIVO = 0) AND (COTIZADA = 1) AND (ID_PRODUCTO IN (SELECT ID_PRODUCTO From COTIZA_REQUI WHERE (ID_PRODUCTO = R.ID_PRODUCTO) AND (ID_REQUISICION = R.ID_REQUISICION) AND (ESTADO_ACTUAL = 'A')))"
		Dim objCmd As New SqlCommand(sqlQuery, cnn)
		objCmd.ExecuteNonQuery()
		Dim da As New SqlDataAdapter(objCmd)
		Dim dt As New DataTable
		da.Fill(dt)
		GVRequisiciones.AutoGenerateColumns = False
		GVRequisiciones.DataSource = dt
		GVRequisiciones.DataBind()
		Session("TablaRequisiciones") = dt
		cnn.Close()
	End Sub

	Protected Sub BTNSeleccionar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
		Dim TBResponsable As LinkButton = CType(sender, LinkButton)
		Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
		Dim Renglon As Integer = gvrFilaActual.RowIndex
		Dim TablaRequisiciones As New DataTable
		Dim index As Integer = 0
		TablaRequisiciones = Session("TablaRequisiciones")
		If Renglon > -1 Then
			Try
				cnn.Open()
				sqlQuery = "SELECT C.ID_COTIZACION, C.ID_REQUISICION, P.NOMBRE, C.ID_PROVEEDOR, C.ID_PRODUCTO, C.Descripcion, C.CANTIDAD, C.DIAS_ENTREGA, C.PRECIO, C.FECHA, ISNULL(C.MONEDA, '0') AS MONEDA FROM COTIZA_REQUI AS C JOIN PROVEEDOR AS P ON P.ID_PROVEEDOR= C.ID_PROVEEDOR WHERE C.ESTADO_ACTUAL = 'A' AND C.ID_PRODUCTO = '" & TablaRequisiciones.Rows(Renglon).Item("ID_PRODUCTO") & "' AND C.PRECIO <> 0 AND ID_REQUISICION = " & TablaRequisiciones.Rows(Renglon).Item("ID_REQUISICION") & " ORDER BY C.PRECIO, C.DIAS_ENTREGA"
				Dim objCmd As New SqlCommand(sqlQuery, cnn)
				objCmd.ExecuteNonQuery()
				Dim da As New SqlDataAdapter(objCmd)
				Dim dt As New DataTable
				da.Fill(dt)
				For Each Row As DataRow In dt.Rows
					If dt.Rows(index).Item("MONEDA") = "DOLARES" Then
						dt.Rows(index).Item("PRECIO") = CDbl(dt.Rows(index).Item("PRECIO") * Dolar)
					End If
					index = index + 1
				Next
				GVCotizaciones.AutoGenerateColumns = False
				GVCotizaciones.DataSource = dt
				GVCotizaciones.DataBind()
				Session("TablaCotizaciones") = dt
				cnn.Close()
			Catch ex As InvalidCastException
			End Try
		End If
	End Sub

	Protected Sub BTNSeleccionarCotizacion_OnClick(ByVal sender As Object, ByVal e As EventArgs)
		Dim TBResponsable As LinkButton = CType(sender, LinkButton)
		Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
		Dim Renglon As Integer = gvrFilaActual.RowIndex
		For Each Row As GridViewRow In GVCotizaciones.Rows
			Dim index As Integer = 0
			index = Convert.ToUInt64(Row.RowIndex)
			If index = Renglon Then
				Row.BackColor = System.Drawing.Color.SkyBlue
			End If
		Next
		Dim TablaCotizaciones As New DataTable
		TablaCotizaciones = Session("TablaCotizaciones")
		If Renglon > -1 Then
			Try
				Session("IdCotizacion") = TablaCotizaciones.Rows(Renglon).Item("ID_COTIZACION")
				Session("IdRequisicion") = TablaCotizaciones.Rows(Renglon).Item("ID_REQUISICION")
				Session("Cantidad") = TablaCotizaciones.Rows(Renglon).Item("CANTIDAD")
			Catch ex As InvalidCastException
			End Try
		End If
	End Sub

	Private Sub Nuevo()
		Cantidad = 0
		IdCotizacion = 0
		IdRequisicion = 0
		Dolar = 0
		Session("IdCotizacion") = IdCotizacion
		Session("IdRequisicion") = IdRequisicion
		Session("Cantidad") = Cantidad
		Session("Dolar") = Dolar
		GVCotizaciones.DataSource = Nothing
		GVCotizaciones.DataBind()
	End Sub

	Sub ObtenerUltimoPrecioDolar()
		cnn.Open()
		sqlQuery = "SELECT TOP 1 isnull(VENTA, 0) AS VENTA FROM DOLAR ORDER BY FECHA"
		Dim objCmd As New SqlCommand(sqlQuery, cnn)
		objCmd.ExecuteNonQuery()
		Dim da As New SqlDataAdapter(objCmd)
		Dim dt As New DataTable
		da.Fill(dt)
		If dt.Rows.Count = 0 Then
			Session("Dolar") = 1
			MsgBox("NO EXISTEN REGISTROS DEL TIPO DE CAMBIO DEL DOLAR", vbInformation, "Informacion")
		Else
			Session("Dolar") = dt.Rows(0).Item("VENTA")
		End If
		cnn.Close()
	End Sub

	Protected Sub GVRequisiciones_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
		Llenar_Lista_Requisiciones()
		GVRequisiciones.PageIndex = e.NewPageIndex
		GVRequisiciones.DataBind()
	End Sub

	Protected Sub GVCotizaciones_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
		GVCotizaciones.DataSource = Session("TablaCotizaciones")
		GVCotizaciones.PageIndex = e.NewPageIndex
		GVCotizaciones.DataBind()
	End Sub

	Protected Sub BTNSalir_Click1(sender As Object, e As ImageClickEventArgs) Handles BTNSalir.Click
		Response.Redirect("~/Default")
	End Sub
End Class