Imports System.Data
Imports System.Windows.Forms

Public Class frmBitacora

    ' ============================================================
    ' VARIABLES
    ' ============================================================

    Private dtBitacora As New DataTable()


    ' ============================================================
    ' CARGAR FORMULARIO
    ' ============================================================

    Private Sub frmBitacora_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        Try

            CargarBitacora()

        Catch ex As Exception

            MessageBox.Show(
                "Ocurrió un error al cargar la bitácora:" &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' CARGAR BITÁCORA
    ' ============================================================

    Private Sub CargarBitacora()

        Try

            dtBitacora =
                New BitacoraDAO().Listar()


            If dtBitacora Is Nothing Then

                dtBitacora =
                    New DataTable()

            End If


            dgvBitacora.DataSource =
                dtBitacora


            ConfigurarColumnas()

            ActualizarEstado()


        Catch ex As Exception

            MessageBox.Show(
                "No se pudo cargar la bitácora:" &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' CONFIGURAR COLUMNAS
    ' ============================================================

    Private Sub ConfigurarColumnas()

        If dgvBitacora.Columns.Count = 0 Then
            Return
        End If


        If dgvBitacora.Columns.Contains("id_bitacora") Then

            dgvBitacora.Columns("id_bitacora").HeaderText =
                "ID"

        End If


        If dgvBitacora.Columns.Contains("id_usuario") Then

            dgvBitacora.Columns("id_usuario").HeaderText =
                "ID Usuario"

        End If


        If dgvBitacora.Columns.Contains("usuario_intento") Then

            dgvBitacora.Columns("usuario_intento").HeaderText =
                "Usuario"

        End If


        If dgvBitacora.Columns.Contains("fecha_hora") Then

            dgvBitacora.Columns("fecha_hora").HeaderText =
                "Fecha y hora"

            dgvBitacora.Columns("fecha_hora").
                DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm:ss"

        End If


        If dgvBitacora.Columns.Contains("resultado") Then

            dgvBitacora.Columns("resultado").HeaderText =
                "Resultado"

        End If


        If dgvBitacora.Columns.Contains("equipo") Then

            dgvBitacora.Columns("equipo").HeaderText =
                "Equipo"

        End If

    End Sub


    ' ============================================================
    ' BUSCAR
    ' ============================================================

    Private Sub txtBuscar_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtBuscar.TextChanged

        Try

            Dim texto As String =
                txtBuscar.Text.Trim()


            ' ----------------------------------------------------
            ' SIN TEXTO: MOSTRAR TODO
            ' ----------------------------------------------------

            If texto = "" Then

                dtBitacora =
                    New BitacoraDAO().Listar()


                ' ----------------------------------------------------
                ' CON TEXTO
                ' ----------------------------------------------------

            Else

                ' El DAO actual busca por ID de usuario,
                ' por lo que aquí intentamos convertir el texto
                ' introducido a un número.

                Dim idUsuario As Integer

                If Integer.TryParse(
                    texto,
                    idUsuario
                ) Then

                    dtBitacora =
                        New BitacoraDAO().
                        ListarPorUsuario(idUsuario)

                Else

                    ' Si no es un ID numérico,
                    ' mostramos nuevamente todos los registros.

                    dtBitacora =
                        New BitacoraDAO().Listar()

                End If

            End If


            If dtBitacora Is Nothing Then

                dtBitacora =
                    New DataTable()

            End If


            dgvBitacora.DataSource =
                dtBitacora


            ConfigurarColumnas()

            ActualizarEstado()


        Catch ex As Exception

            MessageBox.Show(
                "Ocurrió un error durante la búsqueda:" &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' BOTÓN ACTUALIZAR
    ' ============================================================

    Private Sub btnActualizar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnActualizar.Click

        txtBuscar.Clear()

        CargarBitacora()

    End Sub


    ' ============================================================
    ' BOTÓN LIMPIAR
    ' ============================================================

    Private Sub btnLimpiar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnLimpiar.Click

        txtBuscar.Clear()

        CargarBitacora()

    End Sub


    ' ============================================================
    ' ACTUALIZAR ESTADO
    ' ============================================================

    Private Sub ActualizarEstado()

        If dtBitacora Is Nothing Then

            lblEstadoBitacora.Text =
                "Registros encontrados: 0"

            Return

        End If


        lblEstadoBitacora.Text =
            "Registros encontrados: " &
            dtBitacora.Rows.Count.ToString()

    End Sub

End Class