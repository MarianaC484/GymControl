Imports MySqlConnector
Imports System.Data

Public Class BitacoraDAO

    ' Listar todos los registros de bitácora
    Public Function Listar() As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_bitacora, id_usuario, usuario_intento, " &
                                    "fecha_hora, resultado, equipo " &
                                    "FROM bitacora_accesos " &
                                    "ORDER BY fecha_hora DESC"

                Using cmd As New MySqlCommand(sql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al listar la bitácora: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Buscar registros de bitácora por usuario
    Public Function ListarPorUsuario(idUsuario As Integer) As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_bitacora, id_usuario, usuario_intento, " &
                                    "fecha_hora, resultado, equipo " &
                                    "FROM bitacora_accesos " &
                                    "WHERE id_usuario = @id_usuario " &
                                    "ORDER BY fecha_hora DESC"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario)

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al consultar la bitácora del usuario: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Registrar un acceso o intento de acceso
    Public Function Registrar(idUsuario As Integer,
                              usuarioIntento As String,
                              fechaHora As DateTime,
                              resultado As String,
                              equipo As String) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "INSERT INTO bitacora_accesos " &
                                    "(id_usuario, usuario_intento, fecha_hora, resultado, equipo) " &
                                    "VALUES " &
                                    "(@id_usuario, @usuario_intento, @fecha_hora, @resultado, @equipo)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario)
                    cmd.Parameters.AddWithValue("@usuario_intento", usuarioIntento)
                    cmd.Parameters.AddWithValue("@fecha_hora", fechaHora)
                    cmd.Parameters.AddWithValue("@resultado", resultado)
                    cmd.Parameters.AddWithValue("@equipo", equipo)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al registrar el acceso en la bitácora: " & ex.Message)
            End Try
        End Using
    End Function


    ' Registrar un intento cuando el usuario no existe
    Public Function RegistrarIntento(usuarioIntento As String,
                                     fechaHora As DateTime,
                                     resultado As String,
                                     equipo As String) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "INSERT INTO bitacora_accesos " &
                                    "(id_usuario, usuario_intento, fecha_hora, resultado, equipo) " &
                                    "VALUES " &
                                    "(NULL, @usuario_intento, @fecha_hora, @resultado, @equipo)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@usuario_intento", usuarioIntento)
                    cmd.Parameters.AddWithValue("@fecha_hora", fechaHora)
                    cmd.Parameters.AddWithValue("@resultado", resultado)
                    cmd.Parameters.AddWithValue("@equipo", equipo)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al registrar el intento: " & ex.Message)
            End Try
        End Using

        Return False
    End Function

End Class
