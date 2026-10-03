Imports MySqlConnector
Imports System.Data

Public Class InstructorDAO

    ' Listar todos los instructores
    Public Function Listar() As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_instructor, cedula, nombres, apellidos, " &
                                    "especialidad, telefono, correo, fecha_contratacion, activo " &
                                    "FROM instructores"

                Using cmd As New MySqlCommand(sql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al listar los instructores: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Buscar instructor por ID
    Public Function BuscarPorId(idInstructor As Integer) As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_instructor, cedula, nombres, apellidos, " &
                                    "especialidad, telefono, correo, fecha_contratacion, activo " &
                                    "FROM instructores " &
                                    "WHERE id_instructor = @id_instructor"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_instructor", idInstructor)

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al buscar el instructor: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Buscar instructor por cédula
    Public Function BuscarPorCedula(cedula As String) As DataTable
        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "SELECT id_instructor, cedula, nombres, apellidos, " &
                                    "especialidad, telefono, correo, fecha_contratacion, activo " &
                                    "FROM instructores " &
                                    "WHERE cedula = @cedula"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@cedula", cedula)

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al buscar el instructor por cédula: " & ex.Message)
            End Try
        End Using

        Return tabla
    End Function


    ' Insertar instructor
    Public Function Insertar(cedula As String,
                             nombres As String,
                             apellidos As String,
                             especialidad As String,
                             telefono As String,
                             correo As String,
                             fechaContratacion As Date,
                             activo As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "INSERT INTO instructores " &
                                    "(cedula, nombres, apellidos, especialidad, telefono, " &
                                    "correo, fecha_contratacion, activo) " &
                                    "VALUES " &
                                    "(@cedula, @nombres, @apellidos, @especialidad, @telefono, " &
                                    "@correo, @fecha_contratacion, @activo)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@cedula", cedula)
                    cmd.Parameters.AddWithValue("@nombres", nombres)
                    cmd.Parameters.AddWithValue("@apellidos", apellidos)
                    cmd.Parameters.AddWithValue("@especialidad", especialidad)
                    cmd.Parameters.AddWithValue("@telefono", telefono)
                    cmd.Parameters.AddWithValue("@correo", correo)
                    cmd.Parameters.AddWithValue("@fecha_contratacion", fechaContratacion)
                    cmd.Parameters.AddWithValue("@activo", activo)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al insertar el instructor: " & ex.Message)
            End Try
        End Using
    End Function


    ' Actualizar instructor
    Public Function Actualizar(idInstructor As Integer,
                               cedula As String,
                               nombres As String,
                               apellidos As String,
                               especialidad As String,
                               telefono As String,
                               correo As String,
                               fechaContratacion As Date,
                               activo As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "UPDATE instructores SET " &
                                    "cedula = @cedula, " &
                                    "nombres = @nombres, " &
                                    "apellidos = @apellidos, " &
                                    "especialidad = @especialidad, " &
                                    "telefono = @telefono, " &
                                    "correo = @correo, " &
                                    "fecha_contratacion = @fecha_contratacion, " &
                                    "activo = @activo " &
                                    "WHERE id_instructor = @id_instructor"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_instructor", idInstructor)
                    cmd.Parameters.AddWithValue("@cedula", cedula)
                    cmd.Parameters.AddWithValue("@nombres", nombres)
                    cmd.Parameters.AddWithValue("@apellidos", apellidos)
                    cmd.Parameters.AddWithValue("@especialidad", especialidad)
                    cmd.Parameters.AddWithValue("@telefono", telefono)
                    cmd.Parameters.AddWithValue("@correo", correo)
                    cmd.Parameters.AddWithValue("@fecha_contratacion", fechaContratacion)
                    cmd.Parameters.AddWithValue("@activo", activo)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al actualizar el instructor: " & ex.Message)
            End Try
        End Using
    End Function


    ' Desactivar instructor
    Public Function Desactivar(idInstructor As Integer) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Try
                conn.Open()

                Dim sql As String = "UPDATE instructores SET activo = 0 " &
                                    "WHERE id_instructor = @id_instructor"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id_instructor", idInstructor)

                    Return cmd.ExecuteNonQuery() > 0
                End Using

            Catch ex As MySqlException
                Throw New Exception("Error al desactivar el instructor: " & ex.Message)
            End Try
        End Using
    End Function

End Class
