Imports MySqlConnector
Imports System.Data

Public Class ActividadDAO

    ' ==========================================
    ' LISTAR ACTIVIDADES
    ' ==========================================
    Public Function Listar() As DataTable

        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()

            Try
                conn.Open()

                Dim sql As String =
                    "SELECT id_actividad, nombre, descripcion, " &
                    "duracion_min, cupo_maximo, activo " &
                    "FROM actividades " &
                    "ORDER BY nombre"

                Using cmd As New MySqlCommand(sql, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(tabla)
                    End Using
                End Using

            Catch ex As Exception
                Throw New Exception(
                    "Error al listar las actividades: " & ex.Message)
            End Try

        End Using

        Return tabla

    End Function


    ' ==========================================
    ' BUSCAR ACTIVIDADES
    ' ==========================================
    Public Function Buscar(texto As String) As DataTable

        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()

            Try
                conn.Open()

                Dim sql As String =
                    "SELECT id_actividad, nombre, descripcion, " &
                    "duracion_min, cupo_maximo, activo " &
                    "FROM actividades " &
                    "WHERE nombre LIKE @texto " &
                    "OR descripcion LIKE @texto " &
                    "ORDER BY nombre"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@texto", "%" & texto & "%")

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(tabla)
                    End Using

                End Using

            Catch ex As Exception
                Throw New Exception(
                    "Error al buscar actividades: " & ex.Message)
            End Try

        End Using

        Return tabla

    End Function


    ' ==========================================
    ' INSERTAR ACTIVIDAD
    ' ==========================================
    Public Sub Insertar(
        nombre As String,
        descripcion As String,
        duracionMin As Integer,
        cupoMaximo As Integer
    )

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()

            Try
                conn.Open()

                Dim sql As String =
                    "INSERT INTO actividades " &
                    "(nombre, descripcion, duracion_min, cupo_maximo, activo) " &
                    "VALUES " &
                    "(@nombre, @descripcion, @duracion_min, @cupo_maximo, 1)"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@descripcion", descripcion)
                    cmd.Parameters.AddWithValue("@duracion_min", duracionMin)
                    cmd.Parameters.AddWithValue("@cupo_maximo", cupoMaximo)

                    cmd.ExecuteNonQuery()

                End Using

            Catch ex As Exception
                Throw New Exception(
                    "Error al registrar la actividad: " & ex.Message)
            End Try

        End Using

    End Sub


    ' ==========================================
    ' ACTUALIZAR ACTIVIDAD
    ' ==========================================
    Public Sub Actualizar(
        idActividad As Integer,
        nombre As String,
        descripcion As String,
        duracionMin As Integer,
        cupoMaximo As Integer
    )

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()

            Try
                conn.Open()

                Dim sql As String =
                    "UPDATE actividades SET " &
                    "nombre = @nombre, " &
                    "descripcion = @descripcion, " &
                    "duracion_min = @duracion_min, " &
                    "cupo_maximo = @cupo_maximo " &
                    "WHERE id_actividad = @id"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@descripcion", descripcion)
                    cmd.Parameters.AddWithValue("@duracion_min", duracionMin)
                    cmd.Parameters.AddWithValue("@cupo_maximo", cupoMaximo)
                    cmd.Parameters.AddWithValue("@id", idActividad)

                    cmd.ExecuteNonQuery()

                End Using

            Catch ex As Exception
                Throw New Exception(
                    "Error al actualizar la actividad: " & ex.Message)
            End Try

        End Using

    End Sub


    ' ==========================================
    ' DESACTIVAR ACTIVIDAD
    ' ==========================================
    Public Sub Desactivar(idActividad As Integer)

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()

            Try
                conn.Open()

                Dim sql As String =
                    "UPDATE actividades " &
                    "SET activo = 0 " &
                    "WHERE id_actividad = @id"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@id", idActividad)

                    cmd.ExecuteNonQuery()

                End Using

            Catch ex As Exception
                Throw New Exception(
                    "Error al desactivar la actividad: " & ex.Message)
            End Try

        End Using

    End Sub

End Class
