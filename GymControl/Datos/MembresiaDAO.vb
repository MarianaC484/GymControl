Imports MySqlConnector
Imports System.Data
Imports System.Decimal

Public Class MembresiaDAO

    ' Listar todas las membresías
    Public Function Listar() As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_membresia, id_socio, id_tipo, " &
                                    "fecha_inicio, fecha_vencimiento, precio_pactado, estado " &
                                    "FROM membresias"

                Using cmd As New MySqlCommand(sql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al listar las membresías: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Buscar una membresía por ID
    Public Function BuscarPorId(idMembresia As Integer) As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_membresia, id_socio, id_tipo, " &
                                    "fecha_inicio, fecha_vencimiento, precio_pactado, estado " &
                                    "FROM membresias " &
                                    "WHERE id_membresia = @id_membresia"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_membresia", idMembresia)

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al buscar la membresía: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Buscar membresías de un socio
    Public Function ListarPorSocio(idSocio As Integer) As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_membresia, id_socio, id_tipo, " &
                                    "fecha_inicio, fecha_vencimiento, precio_pactado, estado " &
                                    "FROM membresias " &
                                    "WHERE id_socio = @id_socio"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_socio", idSocio)

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al listar las membresías del socio: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Insertar una membresía
    Public Function Insertar(idSocio As Integer,
                             idTipo As Integer,
                             fechaInicio As Date,
                             fechaVencimiento As Date,
                             precioPactado As Decimal,
                             estado As String) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "INSERT INTO membresias " &
                                    "(id_socio, id_tipo, fecha_inicio, fecha_vencimiento, " &
                                    "precio_pactado, estado) " &
                                    "VALUES " &
                                    "(@id_socio, @id_tipo, @fecha_inicio, @fecha_vencimiento, " &
                                    "@precio_pactado, @estado)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_socio", idSocio)
                    cmd.Parameters.AddWithValue("@id_tipo", idTipo)
                    cmd.Parameters.AddWithValue("@fecha_inicio", fechaInicio)
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", fechaVencimiento)
                    cmd.Parameters.AddWithValue("@precio_pactado", precioPactado)
                    cmd.Parameters.AddWithValue("@estado", estado)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al insertar la membresía: " & ex.Message)
            End Try
        End Using
    End Function


    ' Actualizar una membresía
    Public Function Actualizar(idMembresia As Integer,
                               idSocio As Integer,
                               idTipo As Integer,
                               fechaInicio As Date,
                               fechaVencimiento As Date,
                               precioPactado As Decimal,
                               estado As String) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "UPDATE membresias SET " &
                                    "id_socio = @id_socio, " &
                                    "id_tipo = @id_tipo, " &
                                    "fecha_inicio = @fecha_inicio, " &
                                    "fecha_vencimiento = @fecha_vencimiento, " &
                                    "precio_pactado = @precio_pactado, " &
                                    "estado = @estado " &
                                    "WHERE id_membresia = @id_membresia"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_membresia", idMembresia)
                    cmd.Parameters.AddWithValue("@id_socio", idSocio)
                    cmd.Parameters.AddWithValue("@id_tipo", idTipo)
                    cmd.Parameters.AddWithValue("@fecha_inicio", fechaInicio)
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", fechaVencimiento)
                    cmd.Parameters.AddWithValue("@precio_pactado", precioPactado)
                    cmd.Parameters.AddWithValue("@estado", estado)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al actualizar la membresía: " & ex.Message)
            End Try
        End Using
    End Function


    ' Eliminar una membresía
    Public Function Eliminar(idMembresia As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "DELETE FROM membresias " &
                                    "WHERE id_membresia = @id_membresia"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_membresia", idMembresia)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al eliminar la membresía: " & ex.Message)
            End Try
        End Using
    End Function

End Class
