Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class ReporteOrdenCompra
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Page.IsPostBack Then
			'PARAMETROS DE CONEXION
			Dim oConexInfo As ConnectionInfo
			oConexInfo = New ConnectionInfo()
			oConexInfo.ServerName = "DESARROLLO-PC"
			oConexInfo.DatabaseName = "SACCJEEN"
			oConexInfo.UserID = "sa"
			oConexInfo.Password = "Usuario01"
			'PARAMETROS UTILIZADOS PARA IDENTIFICAR LA ORDEN DE COMPRA
			Dim IdOrden As Integer = Request.QueryString("IdordenCompra")
			Dim Usuario As Integer = Request.QueryString("Usuario")
			Dim URL As String = Request.QueryString("URL")
			Dim Rapida As String = Request.QueryString("Rapida")
			'CONDICION PARA IMPRIMIR REPORTE NACIONAL O RAPIDA
			If Rapida = "S" Then
				'IMPRIMIR REPORTE PRIMARIO
				Dim ReporteOCRapida As New REPORTEORDENDECOMPRARAPIDA
				ReporteOCRapida.SetParameterValue("@nIdOrdenCompra", IdOrden)
				ReporteOCRapida.SetParameterValue("@cIdUsuario", Usuario)
				ReporteOCRapida.DataSourceConnections(0).SetConnection(oConexInfo.ServerName, oConexInfo.DatabaseName, oConexInfo.UserID, oConexInfo.Password)
				CRVOrdenCompraRapida.ReportSource = ReporteOCRapida
				ReporteOCRapida.PrintToPrinter(1, False, 0, 0)
				'IMPRIMIR REPORTE SECUNDARIO CON LA MARCA DE AGUA DE COPIA
				Dim ReporteOCRapidaCopia As New REPORTEORDENDECOMPRARAPIDACOPIA
				ReporteOCRapidaCopia.SetParameterValue("@nIdOrdenCompra", IdOrden)
				ReporteOCRapidaCopia.SetParameterValue("@cIdUsuario", Usuario)
				ReporteOCRapidaCopia.DataSourceConnections(0).SetConnection(oConexInfo.ServerName, oConexInfo.DatabaseName, oConexInfo.UserID, oConexInfo.Password)
				CRVOrdenCompraRapidaCopia.ReportSource = ReporteOCRapidaCopia
				ReporteOCRapidaCopia.PrintToPrinter(1, False, 0, 0)
			Else
				'IMPRIMIR REPORTE PRIMARIO
				Dim Reporte As New REPORTEORDENDECOMPRANACIONAL
				Reporte.SetParameterValue("@nIdOrdenCompra", IdOrden)
				Reporte.SetParameterValue("@cIdUsuario", Usuario)
				Reporte.DataSourceConnections(0).SetConnection(oConexInfo.ServerName, oConexInfo.DatabaseName, oConexInfo.UserID, oConexInfo.Password)
				CRVOrdenCompra.ReportSource = Reporte
				Reporte.PrintToPrinter(1, False, 0, 0)
				'IMPRIMIR REPORTE SECUNDARIO CON LA MARCA DE AGUA DE COPIA
				Dim ReportecCopia As New REPORTEORDENDECOMPRANACIONALCOPIA
				ReportecCopia.SetParameterValue("@nIdOrdenCompra", IdOrden)
				ReportecCopia.SetParameterValue("@cIdUsuario", Usuario)
				ReportecCopia.DataSourceConnections(0).SetConnection(oConexInfo.ServerName, oConexInfo.DatabaseName, oConexInfo.UserID, oConexInfo.Password)
				CRVOrdenCompraCopia.ReportSource = ReportecCopia
				ReportecCopia.PrintToPrinter(1, False, 0, 0)
			End If
			'REDIRIGIR A LA PAGINA PRIMARIA
			Response.Redirect(URL)
		End If
	End Sub
End Class