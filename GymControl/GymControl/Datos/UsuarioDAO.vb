Imports System.Data
Imports MySqlConnector
Imports GymControl.Seguridad

Public Class UsuarioDAO

    ' =========================================================
    ' BUSCAR USUARIO POR NOMBRE
    ' Usado por frmLogin
    ' =========================================================
    Public Shared Function ObtenerUsuarioPorNombre(nombreUsuario As String) As DataTable

        Dim tabla As New DataTable()

        Dim query As String =
            "SELECT id_usuario, nombre_usuario, contrasena_hash, sal, " &
            "id_rol, id_socio, id_instructor, intentos_fallidos, activo, ultimo_acceso " &
            "FROM usuarios " &
            "WHERE nombre_usuario = @nombre_usuario " &
            "LIMIT 1"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@nombre_usuario", nombreUsuario)

                Try
                    conn.Open()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(tabla)
                    End Using

                Catch ex As MySqlException
                    MessageBox.Show(
                        "Error al buscar el usuario: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                End Try

            End Using
        End Using

        Return tabla

    End Function


    ' =========================================================
    ' REGISTRAR NUEVO USUARIO
    ' =========================================================
    Public Shared Function RegistrarUsuario(
        nombreUsuario As String,
        contrasena As String,
        idRol As Integer,
        idSocio As Integer?,
        idInstructor As Integer?
    ) As Boolean

        ' Generamos un salt nuevo para ESTE usuario
        Dim salt As String = Seguridad.GenerarSalt()

        ' Generamos el hash usando el mismo método que usa el login
        Dim hash As String = Seguridad.HashContrasena(contrasena, salt)

        Dim query As String =
            "INSERT INTO usuarios " &
            "(nombre_usuario, contrasena_hash, sal, id_rol, id_socio, " &
            "id_instructor, intentos_fallidos, activo, ultimo_acceso) " &
            "VALUES " &
            "(@nombre_usuario, @contrasena_hash, @sal, @id_rol, @id_socio, " &
            "@id_instructor, 0, 1, NULL)"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@nombre_usuario", nombreUsuario)
                cmd.Parameters.AddWithValue("@contrasena_hash", hash)
                cmd.Parameters.AddWithValue("@sal", salt)
                cmd.Parameters.AddWithValue("@id_rol", idRol)

                If idSocio.HasValue Then
                    cmd.Parameters.AddWithValue("@id_socio", idSocio.Value)
                Else
                    cmd.Parameters.AddWithValue("@id_socio", DBNull.Value)
                End If

                If idInstructor.HasValue Then
                    cmd.Parameters.AddWithValue("@id_instructor", idInstructor.Value)
                Else
                    cmd.Parameters.AddWithValue("@id_instructor", DBNull.Value)
                End If

                Try
                    conn.Open()
                    Return cmd.ExecuteNonQuery() > 0

                Catch ex As MySqlException
                    MessageBox.Show(
                        "Error al registrar el usuario:" &
                        Environment.NewLine &
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)

                    Return False
                End Try

            End Using
        End Using

    End Function


    ' =========================================================
    ' ACTUALIZAR INTENTOS Y ESTADO
    ' Usado por frmLogin
    ' =========================================================
    Public Shared Sub ActualizarIntentosYEstado(
        idUsuario As Integer,
        intentos As Integer,
        nuevoEstado As Integer)

        Dim query As String =
            "UPDATE usuarios " &
            "SET intentos_fallidos = @intentos, " &
            "activo = @activo " &
            "WHERE id_usuario = @id"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@intentos", intentos)
                cmd.Parameters.AddWithValue("@activo", nuevoEstado)
                cmd.Parameters.AddWithValue("@id", idUsuario)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()

                Catch ex As MySqlException
                    MessageBox.Show(
                        "Error al actualizar el usuario: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                End Try

            End Using
        End Using

    End Sub

End Class