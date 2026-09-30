Imports MySqlConnector
Imports System.Data

Public Class UsuarioDAO

    ' Función para buscar un usuario por su nombre (Para el Login)
    Public Shared Function ObtenerUsuarioPorNombre(nombreUsuario As String) As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT id_usuario, contrasena_hash, sal, intentos_fallidos, activo, id_rol FROM usuarios WHERE nombre_usuario = @usuario"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@usuario", nombreUsuario.Trim())
                Try
                    conn.Open()
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                Catch ex As MySqlException
                    Console.WriteLine("Error en UsuarioDAO.ObtenerUsuarioPorNombre: " & ex.Message)
                End Try
            End Using
        End Using
        Return dt
    End Function

    ' Función para actualizar los intentos fallidos y el estado de bloqueo
    Public Shared Sub ActualizarIntentosYEstado(idUsuario As Integer, intentos As Integer, nuevoEstado As Integer)
        Dim query As String = "UPDATE usuarios SET intentos_fallidos = @intentos, activo = @activo WHERE id_usuario = @id"
        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@intentos", intentos)
                cmd.Parameters.AddWithValue("@activo", nuevoEstado)
                cmd.Parameters.AddWithValue("@id", idUsuario)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As MySqlException
                    Console.WriteLine("Error en UsuarioDAO.ActualizarIntentosYEstado: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

End Class
