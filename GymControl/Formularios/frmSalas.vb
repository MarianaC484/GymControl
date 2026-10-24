Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmSalas

    ' ============================================================
    ' VARIABLES
    ' ============================================================

    Private dtSalas As New DataTable()

    Private modoNuevo As Boolean = False
    Private modoEdicion As Boolean = False

    Private idSalaSeleccionada As Integer = 0


    ' ============================================================
    ' CARGAR FORMULARIO
    ' ============================================================

    Private Sub frmSalas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            ConfigurarFormulario()
            CargarSalas()

        Catch ex As Exception

            MessageBox.Show(
                "Ocurrió un error al cargar el formulario:" &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' CONFIGURACIÓN INICIAL
    ' ============================================================

    Private Sub ConfigurarFormulario()

        txtNombre.ReadOnly = True
        txtCapacidad.ReadOnly = True

        chkActivo.Enabled = False

        btnNuevo.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True

        btnGuardar.Enabled = False
        btnCancelar.Enabled = False

        dgvSalas.ReadOnly = True

        dgvSalas.AllowUserToAddRows = False
        dgvSalas.AllowUserToDeleteRows = False
        dgvSalas.AllowUserToResizeRows = False

        dgvSalas.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvSalas.MultiSelect = False

        dgvSalas.AutoGenerateColumns = True

        dgvSalas.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        dgvSalas.RowHeadersVisible = False

    End Sub


    ' ============================================================
    ' CARGAR SALAS
    ' ============================================================

    Private Sub CargarSalas()

        Try

            dtSalas = New SalaDAO().Listar()

            If dtSalas Is Nothing Then

                dtSalas = New DataTable()

            End If


            dgvSalas.DataSource = dtSalas

            ConfigurarColumnas()


            If dtSalas.Rows.Count > 0 Then

                MostrarSalaActual()

            Else

                LimpiarCampos()

            End If


            ActualizarEstado()


        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar las salas:" &
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

        If dgvSalas.Columns.Count = 0 Then
            Return
        End If


        If dgvSalas.Columns.Contains("id_sala") Then

            dgvSalas.Columns("id_sala").HeaderText = "ID"

        End If


        If dgvSalas.Columns.Contains("nombre") Then

            dgvSalas.Columns("nombre").HeaderText = "Nombre"

        End If


        If dgvSalas.Columns.Contains("capacidad") Then

            dgvSalas.Columns("capacidad").HeaderText = "Capacidad"

        End If


        If dgvSalas.Columns.Contains("activo") Then

            dgvSalas.Columns("activo").HeaderText = "Activo"

        End If

    End Sub


    ' ============================================================
    ' MOSTRAR SALA ACTUAL
    ' ============================================================

    Private Sub MostrarSalaActual()

        Try

            If dgvSalas.CurrentRow Is Nothing Then

                LimpiarCampos()
                Return

            End If


            Dim fila As DataGridViewRow =
                dgvSalas.CurrentRow


            If fila.Cells("id_sala").Value IsNot Nothing AndAlso
               Not IsDBNull(fila.Cells("id_sala").Value) Then

                idSalaSeleccionada =
                    Convert.ToInt32(
                        fila.Cells("id_sala").Value
                    )

            Else

                idSalaSeleccionada = 0

            End If


            If fila.Cells("nombre").Value IsNot Nothing AndAlso
               Not IsDBNull(fila.Cells("nombre").Value) Then

                txtNombre.Text =
                    fila.Cells("nombre").Value.ToString()

            Else

                txtNombre.Clear()

            End If


            If fila.Cells("capacidad").Value IsNot Nothing AndAlso
               Not IsDBNull(fila.Cells("capacidad").Value) Then

                txtCapacidad.Text =
                    fila.Cells("capacidad").Value.ToString()

            Else

                txtCapacidad.Clear()

            End If


            If fila.Cells("activo").Value IsNot Nothing AndAlso
               Not IsDBNull(fila.Cells("activo").Value) Then

                chkActivo.Checked =
                    Convert.ToBoolean(
                        fila.Cells("activo").Value
                    )

            Else

                chkActivo.Checked = False

            End If

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo mostrar la sala:" &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' SELECCIÓN DEL DATAGRIDVIEW
    ' ============================================================

    Private Sub dgvSalas_SelectionChanged(
        sender As Object,
        e As EventArgs
    ) Handles dgvSalas.SelectionChanged

        If modoNuevo OrElse modoEdicion Then
            Return
        End If

        MostrarSalaActual()

    End Sub


    ' ============================================================
    ' BOTÓN NUEVO
    ' ============================================================

    Private Sub btnNuevo_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnNuevo.Click

        modoNuevo = True
        modoEdicion = False

        idSalaSeleccionada = 0

        LimpiarCampos()

        HabilitarEdicion(True)

        chkActivo.Checked = True

        txtNombre.Focus()

        lblEstadoSalas.Text =
            "Registrando nueva sala..."

    End Sub


    ' ============================================================
    ' BOTÓN EDITAR
    ' ============================================================

    Private Sub btnEditar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnEditar.Click

        If idSalaSeleccionada = 0 Then

            MessageBox.Show(
                "Seleccione una sala para editar.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        modoNuevo = False
        modoEdicion = True

        HabilitarEdicion(True)

        txtNombre.Focus()

        lblEstadoSalas.Text =
            "Editando sala..."

    End Sub


    ' ============================================================
    ' BOTÓN GUARDAR
    ' ============================================================

    Private Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnGuardar.Click

        Try

            If Not ValidarDatos() Then
                Return
            End If


            Dim capacidad As Integer =
                Convert.ToInt32(txtCapacidad.Text.Trim())


            Dim activo As Integer

            If chkActivo.Checked Then
                activo = 1
            Else
                activo = 0
            End If


            Dim resultado As Boolean = False


            ' ----------------------------------------------------
            ' NUEVA SALA
            ' ----------------------------------------------------

            If modoNuevo Then

                resultado =
                    New SalaDAO().Insertar(
                        txtNombre.Text.Trim(),
                        capacidad,
                        activo
                    )


                If resultado Then

                    MessageBox.Show(
                        "La sala se registró correctamente.",
                        "Registro exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    )

                End If


                ' ----------------------------------------------------
                ' EDITAR SALA
                ' ----------------------------------------------------

            ElseIf modoEdicion Then

                resultado =
                    New SalaDAO().Actualizar(
                        idSalaSeleccionada,
                        txtNombre.Text.Trim(),
                        capacidad,
                        activo
                    )


                If resultado Then

                    MessageBox.Show(
                        "Los datos de la sala se actualizaron correctamente.",
                        "Actualización exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    )

                End If

            End If


            ' ----------------------------------------------------
            ' OPERACIÓN CORRECTA
            ' ----------------------------------------------------

            If resultado Then

                modoNuevo = False
                modoEdicion = False

                HabilitarEdicion(False)

                CargarSalas()

                lblEstadoSalas.Text =
                    "Operación realizada correctamente."

            End If


        Catch ex As Exception

            MessageBox.Show(
                "Ocurrió un error al guardar la sala:" &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' BOTÓN DESACTIVAR
    ' ============================================================

    Private Sub btnEliminar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnEliminar.Click

        If idSalaSeleccionada = 0 Then

            MessageBox.Show(
                "Seleccione una sala.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        Dim respuesta As DialogResult =
            MessageBox.Show(
                "¿Está seguro de desactivar esta sala?",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )


        If respuesta = DialogResult.Yes Then

            Try

                If New SalaDAO().Desactivar(
                    idSalaSeleccionada
                ) Then

                    MessageBox.Show(
                        "La sala fue desactivada correctamente.",
                        "Operación exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    )

                    CargarSalas()

                End If


            Catch ex As Exception

                MessageBox.Show(
                    "No se pudo desactivar la sala:" &
                    Environment.NewLine & Environment.NewLine &
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )

            End Try

        End If

    End Sub


    ' ============================================================
    ' BOTÓN CANCELAR
    ' ============================================================

    Private Sub btnCancelar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancelar.Click

        modoNuevo = False
        modoEdicion = False

        HabilitarEdicion(False)

        MostrarSalaActual()

        lblEstadoSalas.Text =
            "Operación cancelada."

    End Sub


    ' ============================================================
    ' VALIDAR DATOS
    ' ============================================================

    Private Function ValidarDatos() As Boolean

        ' --------------------------------------------------------
        ' NOMBRE
        ' --------------------------------------------------------

        If String.IsNullOrWhiteSpace(
            txtNombre.Text
        ) Then

            MessageBox.Show(
                "Ingrese el nombre de la sala.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtNombre.Focus()

            Return False

        End If


        ' --------------------------------------------------------
        ' CAPACIDAD
        ' --------------------------------------------------------

        Dim capacidad As Integer

        If Not Integer.TryParse(
            txtCapacidad.Text.Trim(),
            capacidad
        ) Then

            MessageBox.Show(
                "La capacidad debe ser un número entero.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtCapacidad.Focus()

            Return False

        End If


        If capacidad <= 0 Then

            MessageBox.Show(
                "La capacidad debe ser mayor que cero.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtCapacidad.Focus()

            Return False

        End If


        Return True

    End Function


    ' ============================================================
    ' HABILITAR / DESHABILITAR EDICIÓN
    ' ============================================================

    Private Sub HabilitarEdicion(
        habilitar As Boolean
    )

        txtNombre.ReadOnly =
            Not habilitar

        txtCapacidad.ReadOnly =
            Not habilitar

        chkActivo.Enabled =
            habilitar


        btnNuevo.Enabled =
            Not habilitar

        btnEditar.Enabled =
            Not habilitar

        btnEliminar.Enabled =
            Not habilitar

        btnGuardar.Enabled =
            habilitar

        btnCancelar.Enabled =
            habilitar

    End Sub


    ' ============================================================
    ' LIMPIAR CAMPOS
    ' ============================================================

    Private Sub LimpiarCampos()

        idSalaSeleccionada = 0

        txtNombre.Clear()
        txtCapacidad.Clear()

        chkActivo.Checked = True

    End Sub


    ' ============================================================
    ' ACTUALIZAR ESTADO
    ' ============================================================

    Private Sub ActualizarEstado()

        If dtSalas Is Nothing Then

            lblEstadoSalas.Text =
                "Salas encontradas: 0"

            Return

        End If


        lblEstadoSalas.Text =
            "Salas encontradas: " &
            dtSalas.Rows.Count.ToString()

    End Sub

End Class