Imports System.Data.SqlClient
Public Class ReporteVentas2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Consultar()
			'MultiView1.SetActiveView(VRegistro)
		End If
    End Sub

	Protected Sub BTNImprimir_Click(sender As Object, e As EventArgs)
		Dim TablaReporte As New DataTable()
		TablaReporte = Session("TablaTest")

		Dim COLUMNA As String = ""
		Dim TOTAL As Integer = TablaReporte.Columns.Count - 1
		'Recorre columnas
		For index = 0 To TOTAL
			COLUMNA = COLUMNA + TablaReporte.Columns(index).ToString() + ","
		Next

		Dim FileResponse As String = ""
		FileResponse = ExportarTabla(TablaReporte, False, COLUMNA, COLUMNA)

		Dim Region As String = Request.QueryString("Region")
		Response.AddHeader("Content-disposition", "attachment; filename=ReporteExistencia.csv")
		Response.ContentType = "text/csv"
		Response.Write(FileResponse)
		Response.End()
	End Sub
	Private Sub Consultar()
        Dim TablaTest As New DataTable
        Dim sqldat1 As SqlDataAdapter
        sqldat1 = New SqlDataAdapter("RepVenDia", cnn)
        sqldat1.Fill(TablaTest)
		'GVImprimir.DataSource = TablaTest
		'GVImprimir.DataBind()
		Session("TablaTest") = TablaTest
    End Sub
    Shared Function ExportarTabla(ByRef Tabla1 As Object, ByRef DBTodos As Boolean, ByRef Titulo As String, ByRef Columnas As String) As String
        ExportarTabla = String.Empty
        Try
            ExportarTabla = ExportarTabla + Titulo + System.Environment.NewLine

            For Each Renglon As DataRow In Tabla1.Rows
                Dim Linea As String = String.Empty
                For DINumCol As Integer = 0 To Tabla1.Columns.Count - 1
                    If DBTodos Then
                        Linea = Linea + Renglon.Item(DINumCol).ToString.Trim + ","
                    Else
                        Dim ColumnaABuscar As String = Tabla1.Columns(DINumCol).ColumnName + ","
                        If Columnas.ToUpper.IndexOf(ColumnaABuscar.ToUpper) >= 0 Then
                            Linea = Linea + Renglon.Item(DINumCol).ToString.Trim + ","
                        End If
                    End If
                Next
                Linea = Linea.Remove(Linea.Length - 1, 1)
                ExportarTabla = ExportarTabla + Linea + System.Environment.NewLine
            Next
        Catch ex As Exception
        End Try
        Return ExportarTabla
    End Function
End Class