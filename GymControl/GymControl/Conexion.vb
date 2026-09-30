Imports MySqlConnector
Imports MySql.Data.MySqlClient

Public Class Conexion
    Private Shared ReadOnly servidor As String = "localhost"
    Private Shared ReadOnly baseDatos As String = "gimnasio_db"
    Private Shared ReadOnly usuario As String = "gym_app"
    Private Shared ReadOnly contrasena As String = "Gym#2026app"
    Private Shared ReadOnly puerto As String = "3307"


    Private Shared ReadOnly cadenaConexion As String = $"Server={servidor};Port={puerto};Database={baseDatos};Uid={usuario};Pwd={contrasena};"

    Public Shared Function ObtenerConexion() As MySqlConnection
        Return New MySqlConnection(cadenaConexion)
    End Function

    ' Método rápido para probar si todo conecta bien
    Public Shared Function ProbarConexion() As Boolean
        Using conn As MySqlConnection = ObtenerConexion()
            Try
                conn.Open()
                Return True ' Conexión exitosa
            Catch ex As MySqlException
                ' Si hay un error, lo mostrará en la consola de salida
                Console.WriteLine("Error de conexión: " & ex.Message)
                Return False ' Falló la conexión
            End Try
        End Using
    End Function
End Class
