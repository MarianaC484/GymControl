Imports MySqlConnector
Imports System.Data

Public Class SalaDAO

    ' ============================================================
    ' LISTAR SALAS
    ' ============================================================

    Public Function Listar() As DataTable

        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()

            Try

                conn.Open()

                Dim sql As String =
                    "SELECT id_sala, nombre, capacidad, activo " &
                    "FROM salas " &
                    "ORDER BY id_sala ASC"

                Using cmd As New MySqlCommand(sql, conn)

                    Using adapter As New MySqlDataAdapter(cmd)

                        adapter.Fill(tabla)

                    End Using

                End Using

            Catch ex As MySqlException

                Throw New Exception(
                    "Error al listar las salas: " &
                    ex.Message
                )

            End Try

        End Using

        Return tabla

    End Function


    ' ============================================================
    ' BUSCAR SALAS
    ' ============================================================

    Public Function Buscar(texto As String) As DataTable

        Dim tabla As New DataTable()

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()

            Try

                conn.Open()

                Dim sql As String =
                    "SELECT id_sala, nombre, capacidad, activo " &
                    "FROM salas " &
                    "WHERE nombre LIKE @texto " &
                    "ORDER BY id_sala ASC"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue(
                        "@texto",
                        "%" & texto & "%"
                    )

                    Using adapter As New MySqlDataAdapter(cmd)

                        adapter.Fill(tabla)

                    End Using

                End Using

            Catch ex As MySqlException

                Throw New Exception(
                    "Error al buscar las salas: " &
                    ex.Message
                )

            End Try

        End Using

        Return tabla

    End Function


    ' ============================================================
    ' INSERTAR SALA
    ' ============================================================

    Public Function Insertar(
        nombre As String,
        capacidad As Integer,
        activo As Integer
    ) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()

            Try

                conn.Open()

                Dim sql As String =
                    "INSERT INTO salas " &
                    "(nombre, capacidad, activo) " &
                    "VALUES " &
                    "(@nombre, @capacidad, @activo)"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue(
                        "@nombre",
                        nombre
                    )

                    cmd.Parameters.AddWithValue(
                        "@capacidad",
                        capacidad
                    )

                    cmd.Parameters.AddWithValue(
                        "@activo",
                        activo
                    )

                    Return cmd.ExecuteNonQuery() > 0

                End Using

            Catch ex As MySqlException

                Throw New Exception(
                    "Error al registrar la sala: " &
                    ex.Message
                )

            End Try

        End Using

    End Function


    ' ============================================================
    ' ACTUALIZAR SALA
    ' ============================================================

    Public Function Actualizar(
        idSala As Integer,
        nombre As String,
        capacidad As Integer,
        activo As Integer
    ) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()

            Try

                conn.Open()

                Dim sql As String =
                    "UPDATE salas SET " &
                    "nombre = @nombre, " &
                    "capacidad = @capacidad, " &
                    "activo = @activo " &
                    "WHERE id_sala = @id_sala"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue(
                        "@id_sala",
                        idSala
                    )

                    cmd.Parameters.AddWithValue(
                        "@nombre",
                        nombre
                    )

                    cmd.Parameters.AddWithValue(
                        "@capacidad",
                        capacidad
                    )

                    cmd.Parameters.AddWithValue(
                        "@activo",
                        activo
                    )

                    Return cmd.ExecuteNonQuery() > 0

                End Using

            Catch ex As MySqlException

                Throw New Exception(
                    "Error al actualizar la sala: " &
                    ex.Message
                )

            End Try

        End Using

    End Function


    ' ============================================================
    ' DESACTIVAR SALA
    ' ============================================================

    Public Function Desactivar(
        idSala As Integer
    ) As Boolean

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()

            Try

                conn.Open()

                Dim sql As String =
                    "UPDATE salas " &
                    "SET activo = 0 " &
                    "WHERE id_sala = @id_sala"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue(
                        "@id_sala",
                        idSala
                    )

                    Return cmd.ExecuteNonQuery() > 0

                End Using

            Catch ex As MySqlException

                Throw New Exception(
                    "Error al desactivar la sala: " &
                    ex.Message
                )

            End Try

        End Using

    End Function

End Class
