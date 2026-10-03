Imports MySqlConnector
Imports System.Data

Public Class HorarioDAO

    ' Listar todos los horarios
    Public Function Listar() As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_horario, id_instructor, id_actividad, " &
                                    "id_sala, dia_semana, hora_inicio, hora_fin, activo " &
                                    "FROM horarios"

                Using cmd As New MySqlCommand(sql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al listar los horarios: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Buscar un horario por ID
    Public Function BuscarPorId(idHorario As Integer) As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_horario, id_instructor, id_actividad, " &
                                    "id_sala, dia_semana, hora_inicio, hora_fin, activo " &
                                    "FROM horarios " &
                                    "WHERE id_horario = @id_horario"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_horario", idHorario)

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al buscar el horario: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Listar horarios de un instructor
    Public Function ListarPorInstructor(idInstructor As Integer) As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_horario, id_instructor, id_actividad, " &
                                    "id_sala, dia_semana, hora_inicio, hora_fin, activo " &
                                    "FROM horarios " &
                                    "WHERE id_instructor = @id_instructor"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_instructor", idInstructor)

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al listar los horarios del instructor: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Insertar un horario
    Public Function Insertar(idInstructor As Integer,
                             idActividad As Integer,
                             idSala As Integer,
                             diaSemana As Integer,
                             horaInicio As TimeSpan,
                             horaFin As TimeSpan,
                             activo As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "INSERT INTO horarios " &
                                    "(id_instructor, id_actividad, id_sala, dia_semana, " &
                                    "hora_inicio, hora_fin, activo) " &
                                    "VALUES " &
                                    "(@id_instructor, @id_actividad, @id_sala, @dia_semana, " &
                                    "@hora_inicio, @hora_fin, @activo)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_instructor", idInstructor)
                    cmd.Parameters.AddWithValue("@id_actividad", idActividad)
                    cmd.Parameters.AddWithValue("@id_sala", idSala)
                    cmd.Parameters.AddWithValue("@dia_semana", diaSemana)
                    cmd.Parameters.AddWithValue("@hora_inicio", horaInicio)
                    cmd.Parameters.AddWithValue("@hora_fin", horaFin)
                    cmd.Parameters.AddWithValue("@activo", activo)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al insertar el horario: " & ex.Message)
            End Try
        End Using
    End Function


    ' Actualizar un horario
    Public Function Actualizar(idHorario As Integer,
                               idInstructor As Integer,
                               idActividad As Integer,
                               idSala As Integer,
                               diaSemana As Integer,
                               horaInicio As TimeSpan,
                               horaFin As TimeSpan,
                               activo As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "UPDATE horarios SET " &
                                    "id_instructor = @id_instructor, " &
                                    "id_actividad = @id_actividad, " &
                                    "id_sala = @id_sala, " &
                                    "dia_semana = @dia_semana, " &
                                    "hora_inicio = @hora_inicio, " &
                                    "hora_fin = @hora_fin, " &
                                    "activo = @activo " &
                                    "WHERE id_horario = @id_horario"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_horario", idHorario)
                    cmd.Parameters.AddWithValue("@id_instructor", idInstructor)
                    cmd.Parameters.AddWithValue("@id_actividad", idActividad)
                    cmd.Parameters.AddWithValue("@id_sala", idSala)
                    cmd.Parameters.AddWithValue("@dia_semana", diaSemana)
                    cmd.Parameters.AddWithValue("@hora_inicio", horaInicio)
                    cmd.Parameters.AddWithValue("@hora_fin", horaFin)
                    cmd.Parameters.AddWithValue("@activo", activo)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al actualizar el horario: " & ex.Message)
            End Try
        End Using
    End Function


    ' Desactivar un horario
    Public Function Desactivar(idHorario As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "UPDATE horarios SET activo = 0 " &
                                    "WHERE id_horario = @id_horario"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_horario", idHorario)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al desactivar el horario: " & ex.Message)
            End Try
        End Using
    End Function

End Class
