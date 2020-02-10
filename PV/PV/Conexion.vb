Imports System.Data.Sql
Imports System.Data.SqlClient
Public Module Conexion
	Public cnn As SqlConnection
	Public consulta As SqlCommand
	Public respuesta As SqlDataReader

	Public Function abrirConexion()
		'cnn = New SqlConnection("Data Source=DESARROLLO-PC;Initial Catalog=SACCJEEN;Persist Security Info=True;User ID=sa;Password=Usuario01") '***** CONEXION A SERVIDOR PRINCIPAL 
		'cnn.Open()
		Return ("Data Source=DESARROLLO-PC;Initial Catalog=SACCJEEN;Persist Security Info=True;User ID=sa;Password=Usuario01")
	End Function
End Module
