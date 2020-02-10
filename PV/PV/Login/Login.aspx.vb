Imports System.Data.SqlClient
Public Class Login1
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TBUsuario.Text = ""
            TBPassword.Text = ""
            abrir()
        End If
    End Sub
    Protected Sub BTNAceptar_Click(sender As Object, e As EventArgs) Handles BTNAceptar.Click
        Consultar()
        Dim TablaChecar As New DataTable
        TablaChecar = Session("Tabla")
        For Each fila As DataRow In TablaChecar.Rows
            If fila.Item("Usuario") = TBUsuario.Text And fila.Item("Contrasena") = TBPassword.Text And fila.Item("TipoUsuario") = 0 Then
                Response.Redirect("~/DefaultVentas.aspx")
            End If
            If fila.Item("Usuario") = TBUsuario.Text And fila.Item("Contrasena") = TBPassword.Text And fila.Item("TipoUsuario") = 1 Then
                Response.Redirect("~/Default.aspx")
            Else
                LBMensaje.Text = "Usuario y/o contraseña incorrecto(s)"
            End If
        Next
    End Sub
    Public Sub Consultar()
        Dim Tabla As New DataTable
        Dim sqldat1 As SqlDataAdapter
        sqldat1 = New SqlDataAdapter("VerifUser", cnn)
        sqldat1.Fill(Tabla)
        Session("Tabla") = Tabla
    End Sub
End Class