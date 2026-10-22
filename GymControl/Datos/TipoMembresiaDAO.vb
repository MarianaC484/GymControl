Imports MySqlConnector
Imports System.Data

Public Class TipoMembresiaDAO

    Public Shared Function Listar() As DataTable

        Dim dt As New DataTable()

        Dim query As String =
            "SELECT id_tipo, nombre, descripcion, duracion_dias, precio, " &
            "incluye_clases, activo " &
            "FROM tipos_membresia " &
            "ORDER BY nombre"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                Try
                    conn.Open()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                Catch ex As MySqlException
                    MessageBox.Show(
                        "Error al cargar los tipos de membresía: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                End Try

            End Using
        End Using

        Return dt

    End Function


    Public Shared Function Buscar(filtro As String) As DataTable

        Dim dt As New DataTable()

        Dim query As String =
            "SELECT id_tipo, nombre, descripcion, duracion_dias, precio, " &
            "incluye_clases, activo " &
            "FROM tipos_membresia " &
            "WHERE nombre LIKE @filtro " &
            "OR descripcion LIKE @filtro " &
            "ORDER BY nombre"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@filtro", "%" & filtro & "%")

                Try
                    conn.Open()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                Catch ex As MySqlException
                    MessageBox.Show(
                        "Error al buscar tipos de membresía: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                End Try

            End Using
        End Using

        Return dt

    End Function


    Public Shared Function Insertar(
        nombre As String,
        descripcion As String,
        duracionDias As Integer,
        precio As Decimal,
        incluyeClases As Boolean) As Boolean

        Dim query As String =
            "INSERT INTO tipos_membresia " &
            "(nombre, descripcion, duracion_dias, precio, incluye_clases, activo) " &
            "VALUES " &
            "(@nombre, @descripcion, @duracion, @precio, @incluye, 1)"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@nombre", nombre)
                cmd.Parameters.AddWithValue("@descripcion", descripcion)
                cmd.Parameters.AddWithValue("@duracion", duracionDias)
                cmd.Parameters.AddWithValue("@precio", precio)
                cmd.Parameters.AddWithValue("@incluye", incluyeClases)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    Return True

                Catch ex As MySqlException
                    MessageBox.Show(
                        "Error al insertar el tipo de membresía: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)

                    Return False
                End Try

            End Using
        End Using

    End Function


    Public Shared Function Actualizar(
        idTipo As Integer,
        nombre As String,
        descripcion As String,
        duracionDias As Integer,
        precio As Decimal,
        incluyeClases As Boolean,
        activo As Boolean) As Boolean

        Dim query As String =
            "UPDATE tipos_membresia SET " &
            "nombre = @nombre, " &
            "descripcion = @descripcion, " &
            "duracion_dias = @duracion, " &
            "precio = @precio, " &
            "incluye_clases = @incluye, " &
            "activo = @activo " &
            "WHERE id_tipo = @id"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@nombre", nombre)
                cmd.Parameters.AddWithValue("@descripcion", descripcion)
                cmd.Parameters.AddWithValue("@duracion", duracionDias)
                cmd.Parameters.AddWithValue("@precio", precio)
                cmd.Parameters.AddWithValue("@incluye", incluyeClases)
                cmd.Parameters.AddWithValue("@activo", activo)
                cmd.Parameters.AddWithValue("@id", idTipo)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    Return True

                Catch ex As MySqlException
                    MessageBox.Show(
                        "Error al actualizar el tipo de membresía: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)

                    Return False
                End Try

            End Using
        End Using

    End Function


    Public Shared Function Desactivar(idTipo As Integer) As Boolean

        Dim query As String =
            "UPDATE tipos_membresia " &
            "SET activo = 0 " &
            "WHERE id_tipo = @id"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@id", idTipo)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    Return True

                Catch ex As MySqlException
                    MessageBox.Show(
                        "Error al desactivar el tipo de membresía: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)

                    Return False
                End Try

            End Using
        End Using

    End Function

End Class
