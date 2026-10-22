Imports MySqlConnector
Imports System.Data

Public Class CatalogoDAO

    ' =========================================================
    ' ACTIVIDADES
    ' =========================================================

    Public Function ListarActividades() As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_actividad, nombre, descripcion, " &
                                    "duracion_min, cupo_maximo, activo " &
                                    "FROM actividades"

                Using cmd As New MySqlCommand(sql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al listar las actividades: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    Public Function InsertarActividad(nombre As String,
                                      descripcion As String,
                                      duracionMin As Integer,
                                      cupoMaximo As Integer,
                                      activo As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "INSERT INTO actividades " &
                                    "(nombre, descripcion, duracion_min, cupo_maximo, activo) " &
                                    "VALUES " &
                                    "(@nombre, @descripcion, @duracion_min, @cupo_maximo, @activo)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@descripcion", descripcion)
                    cmd.Parameters.AddWithValue("@duracion_min", duracionMin)
                    cmd.Parameters.AddWithValue("@cupo_maximo", cupoMaximo)
                    cmd.Parameters.AddWithValue("@activo", activo)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al insertar la actividad: " & ex.Message)
            End Try
        End Using
    End Function


    Public Function ActualizarActividad(idActividad As Integer,
                                        nombre As String,
                                        descripcion As String,
                                        duracionMin As Integer,
                                        cupoMaximo As Integer,
                                        activo As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "UPDATE actividades SET " &
                                    "nombre = @nombre, " &
                                    "descripcion = @descripcion, " &
                                    "duracion_min = @duracion_min, " &
                                    "cupo_maximo = @cupo_maximo, " &
                                    "activo = @activo " &
                                    "WHERE id_actividad = @id_actividad"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_actividad", idActividad)
                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@descripcion", descripcion)
                    cmd.Parameters.AddWithValue("@duracion_min", duracionMin)
                    cmd.Parameters.AddWithValue("@cupo_maximo", cupoMaximo)
                    cmd.Parameters.AddWithValue("@activo", activo)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al actualizar la actividad: " & ex.Message)
            End Try
        End Using
    End Function


    ' =========================================================
    ' SALAS
    ' =========================================================

    Public Function ListarSalas() As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_sala, nombre, capacidad, activo " &
                                    "FROM salas"

                Using cmd As New MySqlCommand(sql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al listar las salas: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    Public Function InsertarSala(nombre As String,
                                 capacidad As Integer,
                                 activo As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "INSERT INTO salas " &
                                    "(nombre, capacidad, activo) " &
                                    "VALUES (@nombre, @capacidad, @activo)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@capacidad", capacidad)
                    cmd.Parameters.AddWithValue("@activo", activo)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al insertar la sala: " & ex.Message)
            End Try
        End Using
    End Function


    Public Function ActualizarSala(idSala As Integer,
                                   nombre As String,
                                   capacidad As Integer,
                                   activo As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "UPDATE salas SET " &
                                    "nombre = @nombre, " &
                                    "capacidad = @capacidad, " &
                                    "activo = @activo " &
                                    "WHERE id_sala = @id_sala"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_sala", idSala)
                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@capacidad", capacidad)
                    cmd.Parameters.AddWithValue("@activo", activo)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al actualizar la sala: " & ex.Message)
            End Try
        End Using
    End Function


    ' =========================================================
    ' TIPOS DE MEMBRESÍA
    ' =========================================================

    Public Function ListarTiposMembresia() As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_tipo, nombre, descripcion, precio, " &
                                    "duracion_dias, incluye_clases, activo " &
                                    "FROM tipos_membresia"

                Using cmd As New MySqlCommand(sql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al listar los tipos de membresía: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    Public Function InsertarTipoMembresia(nombre As String,
                                          descripcion As String,
                                          precio As Decimal,
                                          duracionDias As Integer,
                                          incluyeClases As Integer,
                                          activo As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "INSERT INTO tipos_membresia " &
                                    "(nombre, descripcion, precio, duracion_dias, " &
                                    "incluye_clases, activo) " &
                                    "VALUES " &
                                    "(@nombre, @descripcion, @precio, @duracion_dias, " &
                                    "@incluye_clases, @activo)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@descripcion", descripcion)
                    cmd.Parameters.AddWithValue("@precio", precio)
                    cmd.Parameters.AddWithValue("@duracion_dias", duracionDias)
                    cmd.Parameters.AddWithValue("@incluye_clases", incluyeClases)
                    cmd.Parameters.AddWithValue("@activo", activo)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al insertar el tipo de membresía: " & ex.Message)
            End Try
        End Using
    End Function


    Public Function ActualizarTipoMembresia(idTipo As Integer,
                                            nombre As String,
                                            descripcion As String,
                                            precio As Decimal,
                                            duracionDias As Integer,
                                            incluyeClases As Integer,
                                            activo As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "UPDATE tipos_membresia SET " &
                                    "nombre = @nombre, " &
                                    "descripcion = @descripcion, " &
                                    "precio = @precio, " &
                                    "duracion_dias = @duracion_dias, " &
                                    "incluye_clases = @incluye_clases, " &
                                    "activo = @activo " &
                                    "WHERE id_tipo = @id_tipo"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_tipo", idTipo)
                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@descripcion", descripcion)
                    cmd.Parameters.AddWithValue("@precio", precio)
                    cmd.Parameters.AddWithValue("@duracion_dias", duracionDias)
                    cmd.Parameters.AddWithValue("@incluye_clases", incluyeClases)
                    cmd.Parameters.AddWithValue("@activo", activo)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al actualizar el tipo de membresía: " & ex.Message)
            End Try
        End Using
    End Function


    ' =========================================================
    ' ROLES
    ' =========================================================

    Public Function ListarRoles() As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_rol, nombre, descripcion " &
                                    "FROM roles"

                Using cmd As New MySqlCommand(sql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al listar los roles: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    Public Function InsertarRol(nombre As String,
                                descripcion As String) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "INSERT INTO roles " &
                                    "(nombre, descripcion) " &
                                    "VALUES (@nombre, @descripcion)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@descripcion", descripcion)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al insertar el rol: " & ex.Message)
            End Try
        End Using
    End Function


    Public Function ActualizarRol(idRol As Integer,
                                  nombre As String,
                                  descripcion As String) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "UPDATE roles SET " &
                                    "nombre = @nombre, " &
                                    "descripcion = @descripcion " &
                                    "WHERE id_rol = @id_rol"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_rol", idRol)
                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@descripcion", descripcion)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al actualizar el rol: " & ex.Message)
            End Try
        End Using
    End Function

End Class
