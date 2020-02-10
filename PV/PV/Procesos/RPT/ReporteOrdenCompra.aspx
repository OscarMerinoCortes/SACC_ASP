<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReporteOrdenCompra.aspx.vb" Inherits="PV.ReporteOrdenCompra" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
	<form id="forma1" runat="server">
		<table>
			<tr>
				<td>
					<CR:CrystalReportViewer ID="CRVOrdenCompra" runat="server" AutoDataBind="true" ReportSourceID="CRSOrdenCompra" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ToolPanelView="ParameterPanel" Width="1104px" />
					<CR:CrystalReportSource ID="CRSOrdenCompra" runat="server">
						<Report FileName="C:\Users\DESARROLLO\Desktop\Respaldo PV\PV\PV\Procesos\CrystalReportsReportes\REPORTEORDENDECOMPRANACIONAL.rpt">
						</Report>
					</CR:CrystalReportSource>
				</td>
			</tr>
			<tr>
				<td>
					<CR:CrystalReportViewer ID="CRVOrdenCompraCopia" runat="server" AutoDataBind="True" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CRSOrdenCompraCopia" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
					<CR:CrystalReportSource ID="CRSOrdenCompraCopia" runat="server">
						<Report FileName="C:\Users\DESARROLLO\Desktop\Respaldo PV\PV\PV\Procesos\CrystalReportsReportes\REPORTEORDENDECOMPRANACIONALCOPIA.rpt">
						</Report>
					</CR:CrystalReportSource>
				</td>
			</tr>
			<tr>
				<td>
					<CR:CrystalReportViewer ID="CRVOrdenCompraRapida" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReportSourceID="CRSOrdenCompraRapida" />
					<CR:CrystalReportSource ID="CRSOrdenCompraRapida" runat="server">
						<Report FileName="C:\Users\DESARROLLO\Desktop\Respaldo PV\PV\PV\Procesos\CrystalReportsReportes\REPORTEORDENDECOMPRARAPIDA.rpt">
						</Report>
					</CR:CrystalReportSource>
				</td>
			</tr>
			<tr>
				<td>
					<CR:CrystalReportViewer ID="CRVOrdenCompraRapidaCopia" runat="server" AutoDataBind="true" ReportSourceID="CRSOrdenCompraRapidaCopia" />
					<CR:CrystalReportSource ID="CRSOrdenCompraRapidaCopia" runat="server">
						<Report FileName="C:\Users\DESARROLLO\Desktop\Respaldo PV\PV\PV\Procesos\CrystalReportsReportes\REPORTEORDENDECOMPRARAPIDACOPIA.rpt">
						</Report>
					</CR:CrystalReportSource>
				</td>
			</tr>
		</table>
	</form>
</body>
</html>
