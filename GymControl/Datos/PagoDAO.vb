Imports MySqlConnector
Imports System.Data

Public Class PagoDAO

    ' Listar todos los pagos
    Public Function Listar() As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_pago, id_membresia, id_usuario_registro, " &
                                    "monto, metodo_pago, referencia, observacion, " &
                                    "fecha_pago, anulado " &
                                    "FROM pagos"

                Using cmd As New MySqlCommand(sql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al listar los pagos: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Buscar un pago por ID
    Public Function BuscarPorId(idPago As Integer) As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_pago, id_membresia, id_usuario_registro, " &
                                    "monto, metodo_pago, referencia, observacion, " &
                                    "fecha_pago, anulado " &
                                    "FROM pagos " &
                                    "WHERE id_pago = @id_pago"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_pago", idPago)

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al buscar el pago: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Listar pagos de una membresía
    Public Function ListarPorMembresia(idMembresia As Integer) As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_pago, id_membresia, id_usuario_registro, " &
                                    "monto, metodo_pago, referencia, observacion, " &
                                    "fecha_pago, anulado " &
                                    "FROM pagos " &
                                    "WHERE id_membresia = @id_membresia"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_membresia", idMembresia)

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al listar los pagos de la membresía: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Insertar un pago
    Public Function Insertar(idMembresia As Integer,
                             idUsuarioRegistro As Integer,
                             monto As Decimal,
                             metodoPago As String,
                             referencia As String,
                             observacion As String,
                             fechaPago As DateTime,
                             anulado As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "INSERT INTO pagos " &
                                    "(id_membresia, id_usuario_registro, monto, metodo_pago, " &
                                    "referencia, observacion, fecha_pago, anulado) " &
                                    "VALUES " &
                                    "(@id_membresia, @id_usuario_registro, @monto, @metodo_pago, " &
                                    "@referencia, @observacion, @fecha_pago, @anulado)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_membresia", idMembresia)
                    cmd.Parameters.AddWithValue("@id_usuario_registro", idUsuarioRegistro)
                    cmd.Parameters.AddWithValue("@monto", monto)
                    cmd.Parameters.AddWithValue("@metodo_pago", metodoPago)
                    cmd.Parameters.AddWithValue("@referencia", referencia)
                    cmd.Parameters.AddWithValue("@observacion", observacion)
                    cmd.Parameters.AddWithValue("@fecha_pago", fechaPago)
                    cmd.Parameters.AddWithValue("@anulado", anulado)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al insertar el pago: " & ex.Message)
            End Try
        End Using
    End Function


    ' Actualizar un pago
    Public Function Actualizar(idPago As Integer,
                               idMembresia As Integer,
                               idUsuarioRegistro As Integer,
                               monto As Decimal,
                               metodoPago As String,
                               referencia As String,
                               observacion As String,
                               fechaPago As DateTime,
                               anulado As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "UPDATE pagos SET " &
                                    "id_membresia = @id_membresia, " &
                                    "id_usuario_registro = @id_usuario_registro, " &
                                    "monto = @monto, " &
                                    "metodo_pago = @metodo_pago, " &
                                    "referencia = @referencia, " &
                                    "observacion = @observacion, " &
                                    "fecha_pago = @fecha_pago, " &
                                    "anulado = @anulado " &
                                    "WHERE id_pago = @id_pago"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_pago", idPago)
                    cmd.Parameters.AddWithValue("@id_membresia", idMembresia)
                    cmd.Parameters.AddWithValue("@id_usuario_registro", idUsuarioRegistro)
                    cmd.Parameters.AddWithValue("@monto", monto)
                    cmd.Parameters.AddWithValue("@metodo_pago", metodoPago)
                    cmd.Parameters.AddWithValue("@referencia", referencia)
                    cmd.Parameters.AddWithValue("@observacion", observacion)
                    cmd.Parameters.AddWithValue("@fecha_pago", fechaPago)
                    cmd.Parameters.AddWithValue("@anulado", anulado)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al actualizar el pago: " & ex.Message)
            End Try
        End Using
    End Function


    ' Anular un pago
    Public Function Anular(idPago As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "UPDATE pagos SET anulado = 1 " &
                                    "WHERE id_pago = @id_pago"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_pago", idPago)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            Catch ex As MySqlException
                Throw New Exception("Error al anular el pago: " & ex.Message)
            End Try
        End Using
    End Function

End Class
