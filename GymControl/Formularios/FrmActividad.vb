Imports System.Data

Public Class FrmActividad

    ' ==========================================================
    ' VARIABLES
    ' ==========================================================

    Private actividadDAO As New ActividadDAO()

    Private dtActividades As New DataTable()

    Private modoNuevo As Boolean = False
    Private modoEdicion As Boolean = False

    Private idActividadSeleccionado As Integer = 0

    Private WithEvents bnvActividades As BindingNavigator


    ' ==========================================================
    ' CARGA DEL FORMULARIO
    ' ==========================================================

    Private Sub FrmActividad_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        ConfigurarFormulario()
        CrearBindingNavigator()
        CargarActividades()
        ConfigurarColumnas()

        LimpiarCampos()
        BloquearCampos()

    End Sub


    ' ==========================================================
    ' CONFIGURACIÓN GENERAL
    ' ==========================================================

    Private Sub ConfigurarFormulario()

        Me.Text = "GymControl - Gestión de Actividades"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Maximized

        lblTitulo.Text = "Gestión de Actividades"

        dgvActividades.AutoGenerateColumns = True
        dgvActividades.AllowUserToAddRows = False
        dgvActividades.AllowUserToDeleteRows = False
        dgvActividades.ReadOnly = True
        dgvActividades.MultiSelect = False
        dgvActividades.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        nudDuracion.Minimum = 1
        nudDuracion.Maximum = 600
        nudDuracion.Value = 60

        nudCupo.Minimum = 1
        nudCupo.Maximum = 500
        nudCupo.Value = 20

    End Sub


    ' ==========================================================
    ' CREAR BINDINGNAVIGATOR
    ' ==========================================================

    Private Sub CrearBindingNavigator()

        bnvActividades = New BindingNavigator(False)

        bnvActividades.Dock = DockStyle.Bottom

        bnvActividades.Height = 45

        bnvActividades.BackColor =
            SystemColors.Control


        ' ------------------------------------------------------
        ' PRIMER REGISTRO
        ' ------------------------------------------------------

        Dim btnPrimero As New ToolStripButton("<<")

        btnPrimero.Name = "btnPrimero"

        AddHandler btnPrimero.Click,
            AddressOf btnPrimero_Click

        bnvActividades.Items.Add(btnPrimero)


        ' ------------------------------------------------------
        ' REGISTRO ANTERIOR
        ' ------------------------------------------------------

        Dim btnAnterior As New ToolStripButton("<")

        btnAnterior.Name = "btnAnterior"

        AddHandler btnAnterior.Click,
            AddressOf btnAnterior_Click

        bnvActividades.Items.Add(btnAnterior)


        ' ------------------------------------------------------
        ' POSICIÓN ACTUAL
        ' ------------------------------------------------------

        Dim lblPosicion As New ToolStripLabel("Registro:")

        bnvActividades.Items.Add(lblPosicion)


        Dim txtNavPosicion As New ToolStripTextBox()

        txtNavPosicion.Name = "txtNavPosicion"

        txtNavPosicion.Width = 50

        txtNavPosicion.ReadOnly = True

        txtNavPosicion.Text = "0"

        bnvActividades.Items.Add(txtNavPosicion)


        ' ------------------------------------------------------
        ' TOTAL
        ' ------------------------------------------------------

        Dim lblDe As New ToolStripLabel("de")

        bnvActividades.Items.Add(lblDe)


        Dim lblTotal As New ToolStripLabel("0")

        lblTotal.Name = "lblNavTotal"

        bnvActividades.Items.Add(lblTotal)


        ' ------------------------------------------------------
        ' SIGUIENTE
        ' ------------------------------------------------------

        Dim btnSiguiente As New ToolStripButton(">")

        btnSiguiente.Name = "btnSiguiente"

        AddHandler btnSiguiente.Click,
            AddressOf btnSiguiente_Click

        bnvActividades.Items.Add(btnSiguiente)


        ' ------------------------------------------------------
        ' ÚLTIMO REGISTRO
        ' ------------------------------------------------------

        Dim btnUltimo As New ToolStripButton(">>")

        btnUltimo.Name = "btnUltimo"

        AddHandler btnUltimo.Click,
            AddressOf btnUltimo_Click

        bnvActividades.Items.Add(btnUltimo)


        ' ------------------------------------------------------
        ' SEPARADOR
        ' ------------------------------------------------------

        bnvActividades.Items.Add(
            New ToolStripSeparator()
        )


        ' ------------------------------------------------------
        ' NUEVO
        ' ------------------------------------------------------

        Dim btnNuevo As New ToolStripButton("Nuevo")

        btnNuevo.Name = "btnNuevo"

        AddHandler btnNuevo.Click,
            AddressOf btnNuevo_Click

        bnvActividades.Items.Add(btnNuevo)


        ' ------------------------------------------------------
        ' EDITAR
        ' ------------------------------------------------------

        Dim btnEditar As New ToolStripButton("Editar")

        btnEditar.Name = "btnEditar"

        AddHandler btnEditar.Click,
            AddressOf btnEditar_Click

        bnvActividades.Items.Add(btnEditar)


        ' ------------------------------------------------------
        ' GUARDAR
        ' ------------------------------------------------------

        Dim btnGuardar As New ToolStripButton("Guardar")

        btnGuardar.Name = "btnGuardar"

        AddHandler btnGuardar.Click,
            AddressOf btnGuardar_Click

        bnvActividades.Items.Add(btnGuardar)


        ' ------------------------------------------------------
        ' CANCELAR
        ' ------------------------------------------------------

        Dim btnCancelar As New ToolStripButton("Cancelar")

        btnCancelar.Name = "btnCancelar"

        AddHandler btnCancelar.Click,
            AddressOf btnCancelar_Click

        bnvActividades.Items.Add(btnCancelar)


        ' ------------------------------------------------------
        ' DESACTIVAR
        ' ------------------------------------------------------

        Dim btnEliminar As New ToolStripButton("Desactivar")

        btnEliminar.Name = "btnEliminar"

        AddHandler btnEliminar.Click,
            AddressOf btnEliminar_Click

        bnvActividades.Items.Add(btnEliminar)


        ' ------------------------------------------------------
        ' AGREGAR AL FORMULARIO
        ' ------------------------------------------------------

        Me.Controls.Add(bnvActividades)

        bnvActividades.BringToFront()

    End Sub


    ' ==========================================================
    ' CARGAR ACTIVIDADES
    ' ==========================================================

    Private Sub CargarActividades()

        Try

            dtActividades = actividadDAO.Listar()

            dgvActividades.DataSource = dtActividades

            ConfigurarColumnas()

            ActualizarNavegador()


            If dgvActividades.Rows.Count > 0 Then

                dgvActividades.Rows(0).Selected = True

                CargarFilaSeleccionada()

            Else

                LimpiarCampos()

            End If


        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ==========================================================
    ' CONFIGURAR COLUMNAS
    ' ==========================================================

    Private Sub ConfigurarColumnas()

        If dgvActividades.Columns.Count = 0 Then
            Return
        End If


        If dgvActividades.Columns.Contains(
            "id_actividad"
        ) Then

            dgvActividades.Columns(
                "id_actividad"
            ).HeaderText = "ID"

            dgvActividades.Columns(
                "id_actividad"
            ).Visible = False

        End If


        If dgvActividades.Columns.Contains(
            "nombre"
        ) Then

            dgvActividades.Columns(
                "nombre"
            ).HeaderText = "Nombre"

        End If


        If dgvActividades.Columns.Contains(
            "descripcion"
        ) Then

            dgvActividades.Columns(
                "descripcion"
            ).HeaderText = "Descripción"

        End If


        If dgvActividades.Columns.Contains(
            "duracion_min"
        ) Then

            dgvActividades.Columns(
                "duracion_min"
            ).HeaderText = "Duración (min)"

        End If


        If dgvActividades.Columns.Contains(
            "cupo_maximo"
        ) Then

            dgvActividades.Columns(
                "cupo_maximo"
            ).HeaderText = "Cupo máximo"

        End If


        If dgvActividades.Columns.Contains(
            "activo"
        ) Then

            dgvActividades.Columns(
                "activo"
            ).HeaderText = "Activo"

        End If

    End Sub


    ' ==========================================================
    ' CARGAR FILA SELECCIONADA
    ' ==========================================================

    Private Sub CargarFilaSeleccionada()

        If dgvActividades.CurrentRow Is Nothing Then
            Return
        End If


        If dgvActividades.CurrentRow.IsNewRow Then
            Return
        End If


        Try

            If dgvActividades.CurrentRow.Cells(
                "id_actividad"
            ).Value Is Nothing Then

                Return

            End If


            idActividadSeleccionado =
                Convert.ToInt32(
                    dgvActividades.CurrentRow.Cells(
                        "id_actividad"
                    ).Value
                )


            txtNombre.Text =
                Convert.ToString(
                    dgvActividades.CurrentRow.Cells(
                        "nombre"
                    ).Value
                )


            txtDescripcion.Text =
                Convert.ToString(
                    dgvActividades.CurrentRow.Cells(
                        "descripcion"
                    ).Value
                )


            nudDuracion.Value =
                Convert.ToDecimal(
                    dgvActividades.CurrentRow.Cells(
                        "duracion_min"
                    ).Value
                )


            nudCupo.Value =
                Convert.ToDecimal(
                    dgvActividades.CurrentRow.Cells(
                        "cupo_maximo"
                    ).Value
                )


            If dgvActividades.Columns.Contains(
                "activo"
            ) Then

                Dim activo As Boolean =
                    Convert.ToBoolean(
                        dgvActividades.CurrentRow.Cells(
                            "activo"
                        ).Value
                    )


                If activo Then

                    lblEstadoValor.Text = "Activa"

                Else

                    lblEstadoValor.Text = "Inactiva"

                End If

            End If


            ActualizarPosicionNavegador()


        Catch ex As Exception

            MessageBox.Show(
                "No se pudo cargar la actividad seleccionada." &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ==========================================================
    ' CAMBIO DE SELECCIÓN
    ' ==========================================================

    Private Sub dgvActividades_SelectionChanged(
        sender As Object,
        e As EventArgs
    ) Handles dgvActividades.SelectionChanged

        If modoNuevo OrElse modoEdicion Then
            Return
        End If

        CargarFilaSeleccionada()

    End Sub


    ' ==========================================================
    ' NUEVO
    ' ==========================================================

    Private Sub btnNuevo_Click(
        sender As Object,
        e As EventArgs
    )

        modoNuevo = True

        modoEdicion = False

        idActividadSeleccionado = 0

        LimpiarCampos()

        HabilitarCampos()

        txtNombre.Focus()

    End Sub


    ' ==========================================================
    ' EDITAR
    ' ==========================================================

    Private Sub btnEditar_Click(
        sender As Object,
        e As EventArgs
    )

        If idActividadSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione una actividad para editar.",
                "Editar actividad",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If


        modoNuevo = False

        modoEdicion = True

        HabilitarCampos()

        txtNombre.Focus()

    End Sub


    ' ==========================================================
    ' GUARDAR
    ' ==========================================================

    Private Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs
    )

        If Not modoNuevo AndAlso
           Not modoEdicion Then

            MessageBox.Show(
                "No hay cambios para guardar.",
                "Guardar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If


        If Not ValidarDatos() Then
            Return
        End If


        Try

            If modoNuevo Then

                actividadDAO.Insertar(
                    txtNombre.Text.Trim(),
                    txtDescripcion.Text.Trim(),
                    Convert.ToInt32(
                        nudDuracion.Value
                    ),
                    Convert.ToInt32(
                        nudCupo.Value
                    )
                )


                MessageBox.Show(
                    "La actividad se registró correctamente.",
                    "Actividad registrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )


            ElseIf modoEdicion Then

                actividadDAO.Actualizar(
                    idActividadSeleccionado,
                    txtNombre.Text.Trim(),
                    txtDescripcion.Text.Trim(),
                    Convert.ToInt32(
                        nudDuracion.Value
                    ),
                    Convert.ToInt32(
                        nudCupo.Value
                    )
                )


                MessageBox.Show(
                    "La actividad se actualizó correctamente.",
                    "Actividad actualizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

            End If


            modoNuevo = False

            modoEdicion = False

            BloquearCampos()

            CargarActividades()


        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Error al guardar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ==========================================================
    ' CANCELAR
    ' ==========================================================

    Private Sub btnCancelar_Click(
        sender As Object,
        e As EventArgs
    )

        modoNuevo = False

        modoEdicion = False

        BloquearCampos()


        If dgvActividades.Rows.Count > 0 Then

            CargarFilaSeleccionada()

        Else

            LimpiarCampos()

        End If

    End Sub


    ' ==========================================================
    ' DESACTIVAR
    ' ==========================================================

    Private Sub btnEliminar_Click(
        sender As Object,
        e As EventArgs
    )

        If idActividadSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione una actividad.",
                "Desactivar actividad",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If


        Dim respuesta As DialogResult =
            MessageBox.Show(
                "¿Está seguro de que desea desactivar esta actividad?",
                "Desactivar actividad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )


        If respuesta <> DialogResult.Yes Then
            Return
        End If


        Try

            actividadDAO.Desactivar(
                idActividadSeleccionado
            )


            MessageBox.Show(
                "La actividad fue desactivada correctamente.",
                "Actividad desactivada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )


            CargarActividades()


        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ==========================================================
    ' VALIDAR DATOS
    ' ==========================================================

    Private Function ValidarDatos() As Boolean

        If String.IsNullOrWhiteSpace(
            txtNombre.Text
        ) Then

            MessageBox.Show(
                "Ingrese el nombre de la actividad.",
                "Datos incompletos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtNombre.Focus()

            Return False

        End If


        If nudDuracion.Value <= 0 Then

            MessageBox.Show(
                "La duración debe ser mayor que cero.",
                "Datos incorrectos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            nudDuracion.Focus()

            Return False

        End If


        If nudCupo.Value <= 0 Then

            MessageBox.Show(
                "El cupo máximo debe ser mayor que cero.",
                "Datos incorrectos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            nudCupo.Focus()

            Return False

        End If


        Return True

    End Function


    ' ==========================================================
    ' LIMPIAR CAMPOS
    ' ==========================================================

    Private Sub LimpiarCampos()

        txtNombre.Clear()

        txtDescripcion.Clear()

        nudDuracion.Value = 60

        nudCupo.Value = 20

        lblEstadoValor.Text = "-"

    End Sub


    ' ==========================================================
    ' HABILITAR CAMPOS
    ' ==========================================================

    Private Sub HabilitarCampos()

        txtNombre.ReadOnly = False

        txtDescripcion.ReadOnly = False

        nudDuracion.Enabled = True

        nudCupo.Enabled = True

    End Sub


    ' ==========================================================
    ' BLOQUEAR CAMPOS
    ' ==========================================================

    Private Sub BloquearCampos()

        txtNombre.ReadOnly = True

        txtDescripcion.ReadOnly = True

        nudDuracion.Enabled = False

        nudCupo.Enabled = False

    End Sub


    ' ==========================================================
    ' BUSCAR
    ' ==========================================================

    Private Sub btnBuscar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBuscar.Click

        Try

            Dim texto As String =
                txtBuscar.Text.Trim()


            If texto = "" Then

                CargarActividades()

            Else

                dtActividades =
                    actividadDAO.Buscar(texto)

                dgvActividades.DataSource =
                    dtActividades

                ConfigurarColumnas()

                ActualizarNavegador()


                If dgvActividades.Rows.Count > 0 Then

                    dgvActividades.Rows(0).Selected = True

                    CargarFilaSeleccionada()

                Else

                    LimpiarCampos()

                    MessageBox.Show(
                        "No se encontraron actividades.",
                        "Búsqueda",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    )

                End If

            End If


        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Error en la búsqueda",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ==========================================================
    ' LIMPIAR BÚSQUEDA
    ' ==========================================================

    Private Sub btnLimpiar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnLimpiar.Click

        txtBuscar.Clear()

        CargarActividades()

    End Sub


    ' ==========================================================
    ' PRIMER REGISTRO
    ' ==========================================================

    Private Sub btnPrimero_Click(
        sender As Object,
        e As EventArgs
    )

        If dgvActividades.Rows.Count = 0 Then
            Return
        End If


        dgvActividades.CurrentCell =
            dgvActividades.Rows(0).Cells(0)


        dgvActividades.Rows(0).Selected = True

        CargarFilaSeleccionada()

    End Sub


    ' ==========================================================
    ' REGISTRO ANTERIOR
    ' ==========================================================

    Private Sub btnAnterior_Click(
        sender As Object,
        e As EventArgs
    )

        If dgvActividades.CurrentRow Is Nothing Then
            Return
        End If


        Dim posicion As Integer =
            dgvActividades.CurrentRow.Index


        If posicion > 0 Then

            dgvActividades.CurrentCell =
                dgvActividades.Rows(
                    posicion - 1
                ).Cells(0)


            dgvActividades.Rows(
                posicion - 1
            ).Selected = True


            CargarFilaSeleccionada()

        End If

    End Sub


    ' ==========================================================
    ' SIGUIENTE
    ' ==========================================================

    Private Sub btnSiguiente_Click(
        sender As Object,
        e As EventArgs
    )

        If dgvActividades.CurrentRow Is Nothing Then
            Return
        End If


        Dim posicion As Integer =
            dgvActividades.CurrentRow.Index


        If posicion <
            dgvActividades.Rows.Count - 1 Then

            dgvActividades.CurrentCell =
                dgvActividades.Rows(
                    posicion + 1
                ).Cells(0)


            dgvActividades.Rows(
                posicion + 1
            ).Selected = True


            CargarFilaSeleccionada()

        End If

    End Sub


    ' ==========================================================
    ' ÚLTIMO REGISTRO
    ' ==========================================================

    Private Sub btnUltimo_Click(
        sender As Object,
        e As EventArgs
    )

        If dgvActividades.Rows.Count = 0 Then
            Return
        End If


        Dim ultimo As Integer =
            dgvActividades.Rows.Count - 1


        dgvActividades.CurrentCell =
            dgvActividades.Rows(
                ultimo
            ).Cells(0)


        dgvActividades.Rows(
            ultimo
        ).Selected = True


        CargarFilaSeleccionada()

    End Sub


    ' ==========================================================
    ' ACTUALIZAR NAVEGADOR
    ' ==========================================================

    Private Sub ActualizarNavegador()

        If bnvActividades Is Nothing Then
            Return
        End If


        For Each item As ToolStripItem In
            bnvActividades.Items

            If item.Name = "lblNavTotal" Then

                item.Text =
                    dgvActividades.Rows.Count.ToString()

            End If

        Next


        ActualizarPosicionNavegador()

    End Sub


    ' ==========================================================
    ' ACTUALIZAR POSICIÓN
    ' ==========================================================

    Private Sub ActualizarPosicionNavegador()

        If bnvActividades Is Nothing Then
            Return
        End If


        Dim posicion As Integer = 0


        If dgvActividades.CurrentRow IsNot Nothing Then

            posicion =
                dgvActividades.CurrentRow.Index + 1

        End If


        For Each item As ToolStripItem In
            bnvActividades.Items

            If item.Name = "txtNavPosicion" Then

                item.Text =
                    posicion.ToString()

            End If

        Next

    End Sub

End Class