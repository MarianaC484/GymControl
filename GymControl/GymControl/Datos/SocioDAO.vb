Imports System.Data
Imports MySqlConnector

Public Class SocioDAO

    ' ============================================================
    ' LISTAR
    ' ============================================================

    Public Shared Function Listar() As DataTable

        Dim dt As New DataTable()

        Dim query As String =
            "SELECT id_socio, cedula, nombres, apellidos, " &
            "fecha_nacimiento, genero, telefono, correo, direccion, " &
            "fecha_registro, activo " &
            "FROM socios " &
            "ORDER BY apellidos, nombres"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                Try
                    conn.Open()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                Catch ex As MySqlException
                    Throw New Exception(
                        "Error al listar los socios: " & ex.Message)
                End Try

            End Using
        End Using

        Return dt

    End Function


    ' ============================================================
    ' BUSCAR
    ' ============================================================

    Public Shared Function Buscar(filtro As String) As DataTable

        Dim dt As New DataTable()

        Dim query As String =
            "SELECT id_socio, cedula, nombres, apellidos, " &
            "fecha_nacimiento, genero, telefono, correo, direccion, " &
            "fecha_registro, activo " &
            "FROM socios " &
            "WHERE cedula LIKE @filtro " &
            "OR nombres LIKE @filtro " &
            "OR apellidos LIKE @filtro " &
            "OR telefono LIKE @filtro " &
            "OR correo LIKE @filtro " &
            "ORDER BY apellidos, nombres"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue(
                    "@filtro",
                    "%" & filtro & "%")

                Try
                    conn.Open()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                Catch ex As MySqlException
                    Throw New Exception(
                        "Error al buscar socios: " & ex.Message)
                End Try

            End Using
        End Using

        Return dt

    End Function


    ' ============================================================
    ' INSERTAR
    ' ============================================================

    Public Shared Function Insertar(
        cedula As String,
        nombres As String,
        apellidos As String,
        fechaNacimiento As Date,
        genero As String,
        telefono As String,
        correo As String,
        direccion As String
    ) As Boolean

        Dim query As String =
            "INSERT INTO socios " &
            "(cedula, nombres, apellidos, fecha_nacimiento, genero, " &
            "telefono, correo, direccion, fecha_registro, activo) " &
            "VALUES " &
            "(@cedula, @nombres, @apellidos, @fechaNacimiento, @genero, " &
            "@telefono, @correo, @direccion, CURDATE(), 1)"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@cedula", cedula)
                cmd.Parameters.AddWithValue("@nombres", nombres)
                cmd.Parameters.AddWithValue("@apellidos", apellidos)
                cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento)
                cmd.Parameters.AddWithValue("@genero", genero)
                cmd.Parameters.AddWithValue("@telefono", telefono)
                cmd.Parameters.AddWithValue("@correo", correo)
                cmd.Parameters.AddWithValue("@direccion", direccion)

                Try
                    conn.Open()

                    Return cmd.ExecuteNonQuery() > 0

                Catch ex As MySqlException
                    Throw New Exception(
                        "Error al registrar el socio: " & ex.Message)
                End Try

            End Using
        End Using

    End Function


    ' ============================================================
    ' ACTUALIZAR
    ' ============================================================

    Public Shared Function Actualizar(
        idSocio As Integer,
        cedula As String,
        nombres As String,
        apellidos As String,
        fechaNacimiento As Date,
        genero As String,
        telefono As String,
        correo As String,
        direccion As String
    ) As Boolean

        Dim query As String =
            "UPDATE socios SET " &
            "cedula = @cedula, " &
            "nombres = @nombres, " &
            "apellidos = @apellidos, " &
            "fecha_nacimiento = @fechaNacimiento, " &
            "genero = @genero, " &
            "telefono = @telefono, " &
            "correo = @correo, " &
            "direccion = @direccion " &
            "WHERE id_socio = @idSocio"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@idSocio", idSocio)
                cmd.Parameters.AddWithValue("@cedula", cedula)
                cmd.Parameters.AddWithValue("@nombres", nombres)
                cmd.Parameters.AddWithValue("@apellidos", apellidos)
                cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento)
                cmd.Parameters.AddWithValue("@genero", genero)
                cmd.Parameters.AddWithValue("@telefono", telefono)
                cmd.Parameters.AddWithValue("@correo", correo)
                cmd.Parameters.AddWithValue("@direccion", direccion)

                Try
                    conn.Open()

                    Return cmd.ExecuteNonQuery() > 0

                Catch ex As MySqlException
                    Throw New Exception(
                        "Error al actualizar el socio: " & ex.Message)
                End Try

            End Using
        End Using

    End Function


    ' ============================================================
    ' DESACTIVAR
    ' ============================================================

    Public Shared Function Desactivar(
        idSocio As Integer
    ) As Boolean

        Dim query As String =
            "UPDATE socios " &
            "SET activo = 0 " &
            "WHERE id_socio = @idSocio"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue(
                    "@idSocio",
                    idSocio)

                Try
                    conn.Open()

                    Return cmd.ExecuteNonQuery() > 0

                Catch ex As MySqlException
                    Throw New Exception(
                        "Error al desactivar el socio: " & ex.Message)
                End Try

            End Using
        End Using

    End Function

End Class