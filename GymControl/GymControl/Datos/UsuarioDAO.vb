Imports System.Data
Imports MySqlConnector
Imports GymControl.Seguridad

Public Class UsuarioDAO

    ' =========================================================
    ' BUSCAR USUARIO POR NOMBRE
    ' =========================================================
    Public Shared Function ObtenerUsuarioPorNombre(
        nombreUsuario As String
    ) As DataTable

        Dim tabla As New DataTable()

        Dim query As String =
            "SELECT id_usuario, nombre_usuario, contrasena_hash, sal, " &
            "id_rol, id_socio, id_instructor, intentos_fallidos, activo, ultimo_acceso " &
            "FROM usuarios " &
            "WHERE nombre_usuario = @nombre_usuario " &
            "LIMIT 1"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue(
                    "@nombre_usuario",
                    nombreUsuario
                )

                Try

                    conn.Open()

                    Using da As New MySqlDataAdapter(cmd)

                        da.Fill(tabla)

                    End Using

                Catch ex As MySqlException

                    Throw New Exception(
                        "Error al buscar el usuario: " &
                        ex.Message
                    )

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

        Dim salt As String =
            Seguridad.GenerarSalt()

        Dim hash As String =
            Seguridad.HashContrasena(
                contrasena,
                salt
            )

        Dim query As String =
            "INSERT INTO usuarios " &
            "(nombre_usuario, contrasena_hash, sal, id_rol, " &
            "id_socio, id_instructor, intentos_fallidos, activo, ultimo_acceso) " &
            "VALUES " &
            "(@nombre_usuario, @contrasena_hash, @sal, @id_rol, " &
            "@id_socio, @id_instructor, 0, 1, NULL)"

        Using conn As MySqlConnection =
            ConexionBD.ObtenerConexion()

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue(
                    "@nombre_usuario",
                    nombreUsuario
                )

                cmd.Parameters.AddWithValue(
                    "@contrasena_hash",
                    hash
                )

                cmd.Parameters.AddWithValue(
                    "@sal",
                    salt
                )

                cmd.Parameters.AddWithValue(
                    "@id_rol",
                    idRol
                )

                If idSocio.HasValue Then

                    cmd.Parameters.AddWithValue(
                        "@id_socio",
                        idSocio.Value
                    )

                Else

                    cmd.Parameters.AddWithValue(
                        "@id_socio",
                        DBNull.Value
                    )

                End If

                If idInstructor.HasValue Then

                    cmd.Parameters.AddWithValue(
                        "@id_instructor",
                        idInstructor.Value
                    )

                Else

                    cmd.Parameters.AddWithValue(
                        "@id_instructor",
                        DBNull.Value
                    )

                End If

                Try

                    conn.Open()

                    Return cmd.ExecuteNonQuery() > 0

                Catch ex As MySqlException

                    Throw New Exception(
                        "Error al registrar el usuario: " &
                        ex.Message
                    )

                End Try

            End Using

        End Using

    End Function


    ' =========================================================
    ' CAMBIAR CONTRASEÑA
    ' =========================================================
    Public Shared Function CambiarContrasena(
        idUsuario As Integer,
        nuevaContrasena As String
    ) As Boolean

        ' Generar un nuevo salt para la nueva contraseña
        Dim nuevoSalt As String =
            Seguridad.GenerarSalt()

        ' Generar nuevo hash
        Dim nuevoHash As String =
            Seguridad.HashContrasena(
                nuevaContrasena,
                nuevoSalt
            )

        Dim query As String =
            "UPDATE usuarios " &
            "SET contrasena_hash = @contrasena_hash, " &
            "sal = @sal, " &
            "intentos_fallidos = 0, " &
            "activo = 1 " &
            "WHERE id_usuario = @id_usuario"

        Using conn As MySqlConnection =
            ConexionBD.ObtenerConexion()

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue(
                    "@contrasena_hash",
                    nuevoHash
                )

                cmd.Parameters.AddWithValue(
                    "@sal",
                    nuevoSalt
                )

                cmd.Parameters.AddWithValue(
                    "@id_usuario",
                    idUsuario
                )

                Try

                    conn.Open()

                    Return cmd.ExecuteNonQuery() > 0

                Catch ex As MySqlException

                    Throw New Exception(
                        "Error al cambiar la contraseña: " &
                        ex.Message
                    )

                End Try

            End Using

        End Using

    End Function


    ' =========================================================
    ' ACTUALIZAR INTENTOS Y ESTADO
    ' =========================================================
    Public Shared Sub ActualizarIntentosYEstado(
        idUsuario As Integer,
        intentos As Integer,
        nuevoEstado As Integer
    )

        Dim query As String =
            "UPDATE usuarios " &
            "SET intentos_fallidos = @intentos, " &
            "activo = @activo " &
            "WHERE id_usuario = @id"

        Using conn As MySqlConnection =
            ConexionBD.ObtenerConexion()

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue(
                    "@intentos",
                    intentos
                )

                cmd.Parameters.AddWithValue(
                    "@activo",
                    nuevoEstado
                )

                cmd.Parameters.AddWithValue(
                    "@id",
                    idUsuario
                )

                Try

                    conn.Open()

                    cmd.ExecuteNonQuery()

                Catch ex As MySqlException

                    Throw New Exception(
                        "Error al actualizar el usuario: " &
                        ex.Message
                    )

                End Try

            End Using

        End Using

    End Sub

End Class