Imports System.Data

Public Class FrmTipoDeMembresia

    Private dtTipos As New DataTable()

    Private modoNuevo As Boolean = False
    Private modoEdicion As Boolean = False

    Private idTipoSeleccionado As Integer = 0

    Private ReadOnly bnvTipos As New BindingNavigator(False)


    ' =========================================================
    ' LOAD
    ' =========================================================
    Private Sub FrmTipoDeMembresia_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        ConfigurarFormulario()
        ConfigurarBindingNavigator()
        CargarTipos()
        LimpiarCampos()
        BloquearCampos()

    End Sub


    ' =========================================================
    ' CONFIGURAR FORMULARIO
    ' =========================================================
    Private Sub ConfigurarFormulario()

        Me.Text = "Gestión de Tipos de Membresía - GymControl"
        Me.StartPosition = FormStartPosition.CenterScreen

        dgvTiposMembresia.ReadOnly = True
        dgvTiposMembresia.AllowUserToAddRows = False
        dgvTiposMembresia.AllowUserToDeleteRows = False
        dgvTiposMembresia.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect
        dgvTiposMembresia.MultiSelect = False
        dgvTiposMembresia.AutoGenerateColumns = True

        nudDuracion.Minimum = 1
        nudDuracion.Maximum = 3650

        nudPrecio.Minimum = 0
        nudPrecio.Maximum = 1000000
        nudPrecio.DecimalPlaces = 2

        chkActivo.Checked = True

    End Sub


    ' =========================================================
    ' BINDING NAVIGATOR
    ' =========================================================
    Private Sub ConfigurarBindingNavigator()

        bnvTipos.Dock = DockStyle.Bottom
        bnvTipos.Height = 35
        bnvTipos.BackColor = Color.WhiteSmoke

        Me.Controls.Add(bnvTipos)

        bnvTipos.Items.Clear()

        ' PRIMER REGISTRO
        Dim btnPrimero As New ToolStripButton("<<")
        btnPrimero.ToolTipText = "Primer registro"

        AddHandler btnPrimero.Click,
            Sub()
                If bsTiposMembresia.Count > 0 Then
                    bsTiposMembresia.MoveFirst()
                End If
            End Sub

        ' ANTERIOR
        Dim btnAnterior As New ToolStripButton("<")
        btnAnterior.ToolTipText = "Registro anterior"

        AddHandler btnAnterior.Click,
            Sub()
                If bsTiposMembresia.Count > 0 Then
                    bsTiposMembresia.MovePrevious()
                End If
            End Sub

        ' SIGUIENTE
        Dim btnSiguiente As New ToolStripButton(">")
        btnSiguiente.ToolTipText = "Registro siguiente"

        AddHandler btnSiguiente.Click,
            Sub()
                If bsTiposMembresia.Count > 0 Then
                    bsTiposMembresia.MoveNext()
                End If
            End Sub

        ' ÚLTIMO
        Dim btnUltimo As New ToolStripButton(">>")
        btnUltimo.ToolTipText = "Último registro"

        AddHandler btnUltimo.Click,
            Sub()
                If bsTiposMembresia.Count > 0 Then
                    bsTiposMembresia.MoveLast()
                End If
            End Sub

        bnvTipos.Items.Add(btnPrimero)
        bnvTipos.Items.Add(btnAnterior)
        bnvTipos.Items.Add(btnSiguiente)
        bnvTipos.Items.Add(btnUltimo)

        bnvTipos.Items.Add(
            New ToolStripSeparator()
        )

        ' NUEVO
        Dim btnNavNuevo As New ToolStripButton("Nuevo")

        AddHandler btnNavNuevo.Click,
            AddressOf btnNuevo_Click

        ' EDITAR
        Dim btnNavEditar As New ToolStripButton("Editar")

        AddHandler btnNavEditar.Click,
            AddressOf btnEditar_Click

        ' GUARDAR
        Dim btnNavGuardar As New ToolStripButton("Guardar")

        AddHandler btnNavGuardar.Click,
            AddressOf btnGuardar_Click

        ' ELIMINAR
        Dim btnNavEliminar As New ToolStripButton("Desactivar")

        AddHandler btnNavEliminar.Click,
            AddressOf btnEliminar_Click

        ' CANCELAR
        Dim btnNavCancelar As New ToolStripButton("Cancelar")

        AddHandler btnNavCancelar.Click,
            AddressOf btnCancelar_Click

        bnvTipos.Items.Add(btnNavNuevo)
        bnvTipos.Items.Add(btnNavEditar)
        bnvTipos.Items.Add(btnNavGuardar)
        bnvTipos.Items.Add(btnNavEliminar)
        bnvTipos.Items.Add(btnNavCancelar)

    End Sub


    ' =========================================================
    ' CARGAR DATOS
    ' =========================================================
    Private Sub CargarTipos()

        dtTipos = TipoMembresiaDAO.Listar()

        bsTiposMembresia.DataSource = dtTipos

        dgvTiposMembresia.DataSource = bsTiposMembresia

        ConfigurarColumnas()

    End Sub


    ' =========================================================
    ' CONFIGURAR COLUMNAS
    ' =========================================================
    Private Sub ConfigurarColumnas()

        If dgvTiposMembresia.Columns.Contains("id_tipo") Then
            dgvTiposMembresia.Columns("id_tipo").Visible = False
        End If

        If dgvTiposMembresia.Columns.Contains("nombre") Then
            dgvTiposMembresia.Columns("nombre").HeaderText =
                "Nombre"
        End If

        If dgvTiposMembresia.Columns.Contains("descripcion") Then
            dgvTiposMembresia.Columns("descripcion").HeaderText =
                "Descripción"
        End If

        If dgvTiposMembresia.Columns.Contains("duracion_dias") Then
            dgvTiposMembresia.Columns("duracion_dias").HeaderText =
                "Duración (días)"
        End If

        If dgvTiposMembresia.Columns.Contains("precio") Then
            dgvTiposMembresia.Columns("precio").HeaderText =
                "Precio"

            dgvTiposMembresia.Columns("precio").
                DefaultCellStyle.Format = "C2"
        End If

        If dgvTiposMembresia.Columns.Contains("incluye_clases") Then
            dgvTiposMembresia.Columns("incluye_clases").HeaderText =
                "Incluye clases"
        End If

        If dgvTiposMembresia.Columns.Contains("activo") Then
            dgvTiposMembresia.Columns("activo").HeaderText =
                "Activo"
        End If

        dgvTiposMembresia.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

    End Sub


    ' =========================================================
    ' SELECCIONAR FILA
    ' =========================================================
    Private Sub dgvTiposMembresia_SelectionChanged(
        sender As Object,
        e As EventArgs
    ) Handles dgvTiposMembresia.SelectionChanged

        If modoNuevo OrElse modoEdicion Then
            Return
        End If

        If dgvTiposMembresia.CurrentRow Is Nothing Then
            Return
        End If

        If dgvTiposMembresia.CurrentRow.IsNewRow Then
            Return
        End If

        Try

            Dim fila As DataGridViewRow =
                dgvTiposMembresia.CurrentRow

            If fila.Cells("id_tipo").Value Is Nothing Then
                Return
            End If

            idTipoSeleccionado =
                Convert.ToInt32(fila.Cells("id_tipo").Value)

            txtNombre.Text =
                fila.Cells("nombre").Value.ToString()

            txtDescripcion.Text =
                fila.Cells("descripcion").Value.ToString()

            nudDuracion.Value =
                Convert.ToDecimal(
                    fila.Cells("duracion_dias").Value
                )

            nudPrecio.Value =
                Convert.ToDecimal(
                    fila.Cells("precio").Value
                )

            chkIncluyeClases.Checked =
                Convert.ToBoolean(
                    fila.Cells("incluye_clases").Value
                )

            chkActivo.Checked =
                Convert.ToBoolean(
                    fila.Cells("activo").Value
                )

        Catch ex As Exception

            ' Evita errores durante la carga inicial.

        End Try

    End Sub


    ' =========================================================
    ' BUSCAR
    ' =========================================================
    Private Sub txtBuscar_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtBuscar.TextChanged

        If modoNuevo OrElse modoEdicion Then
            Return
        End If

        Dim filtro As String =
            txtBuscar.Text.Trim()

        If filtro = "" Then
            CargarTipos()
        Else
            dtTipos = TipoMembresiaDAO.Buscar(filtro)

            bsTiposMembresia.DataSource = dtTipos
            dgvTiposMembresia.DataSource = bsTiposMembresia

            ConfigurarColumnas()
        End If

    End Sub


    ' =========================================================
    ' NUEVO
    ' =========================================================
    Private Sub btnNuevo_Click(
        sender As Object,
        e As EventArgs
    )

        modoNuevo = True
        modoEdicion = False

        idTipoSeleccionado = 0

        LimpiarCampos()
        HabilitarCampos()

        txtNombre.Focus()

    End Sub


    ' =========================================================
    ' EDITAR
    ' =========================================================
    Private Sub btnEditar_Click(
        sender As Object,
        e As EventArgs
    )

        If idTipoSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un tipo de membresía para editar.",
                "Editar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        modoNuevo = False
        modoEdicion = True

        HabilitarCampos()

        txtNombre.Focus()

    End Sub


    ' =========================================================
    ' GUARDAR
    ' =========================================================
    Private Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs
    )

        If String.IsNullOrWhiteSpace(txtNombre.Text) Then

            MessageBox.Show(
                "Ingrese el nombre del tipo de membresía.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtNombre.Focus()
            Return

        End If

        If nudDuracion.Value <= 0 Then

            MessageBox.Show(
                "La duración debe ser mayor que cero.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            nudDuracion.Focus()
            Return

        End If

        If nudPrecio.Value < 0 Then

            MessageBox.Show(
                "El precio no puede ser negativo.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            nudPrecio.Focus()
            Return

        End If


        Dim resultado As Boolean = False


        If modoNuevo Then

            resultado =
                TipoMembresiaDAO.Insertar(
                    txtNombre.Text.Trim(),
                    txtDescripcion.Text.Trim(),
                    Convert.ToInt32(nudDuracion.Value),
                    nudPrecio.Value,
                    chkIncluyeClases.Checked
                )

            If resultado Then

                MessageBox.Show(
                    "Tipo de membresía registrado correctamente.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

            End If


        ElseIf modoEdicion Then

            resultado =
                TipoMembresiaDAO.Actualizar(
                    idTipoSeleccionado,
                    txtNombre.Text.Trim(),
                    txtDescripcion.Text.Trim(),
                    Convert.ToInt32(nudDuracion.Value),
                    nudPrecio.Value,
                    chkIncluyeClases.Checked,
                    chkActivo.Checked
                )

            If resultado Then

                MessageBox.Show(
                    "Tipo de membresía actualizado correctamente.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

            End If

        End If


        If resultado Then

            modoNuevo = False
            modoEdicion = False

            CargarTipos()
            BloquearCampos()

        End If

    End Sub


    ' =========================================================
    ' ELIMINAR / DESACTIVAR
    ' =========================================================
    Private Sub btnEliminar_Click(
        sender As Object,
        e As EventArgs
    )

        If idTipoSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un tipo de membresía.",
                "Desactivar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        Dim respuesta As DialogResult =
            MessageBox.Show(
                "¿Está seguro de desactivar este tipo de membresía?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )


        If respuesta = DialogResult.Yes Then

            If TipoMembresiaDAO.Desactivar(
                idTipoSeleccionado
            ) Then

                MessageBox.Show(
                    "Tipo de membresía desactivado correctamente.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

                CargarTipos()
                LimpiarCampos()
                BloquearCampos()

            End If

        End If

    End Sub


    ' =========================================================
    ' CANCELAR
    ' =========================================================
    Private Sub btnCancelar_Click(
        sender As Object,
        e As EventArgs
    )

        modoNuevo = False
        modoEdicion = False

        CargarTipos()

        BloquearCampos()

    End Sub


    ' =========================================================
    ' LIMPIAR CAMPOS
    ' =========================================================
    Private Sub LimpiarCampos()

        txtNombre.Clear()
        txtDescripcion.Clear()

        nudDuracion.Value = 1
        nudPrecio.Value = 0

        chkIncluyeClases.Checked = True
        chkActivo.Checked = True

    End Sub


    ' =========================================================
    ' HABILITAR CAMPOS
    ' =========================================================
    Private Sub HabilitarCampos()

        txtNombre.Enabled = True
        txtDescripcion.Enabled = True
        nudDuracion.Enabled = True
        nudPrecio.Enabled = True
        chkIncluyeClases.Enabled = True
        chkActivo.Enabled = True

        btnGuardar.Enabled = True
        btnCancelar.Enabled = True

    End Sub


    ' =========================================================
    ' BLOQUEAR CAMPOS
    ' =========================================================
    Private Sub BloquearCampos()

        txtNombre.Enabled = False
        txtDescripcion.Enabled = False
        nudDuracion.Enabled = False
        nudPrecio.Enabled = False
        chkIncluyeClases.Enabled = False
        chkActivo.Enabled = False

        btnGuardar.Enabled = False
        btnCancelar.Enabled = True

    End Sub

    Private Sub chkActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivo.CheckedChanged

    End Sub

    Private Sub chkIncluyeClases_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluyeClases.CheckedChanged

    End Sub

    Private Sub nudPrecio_ValueChanged(sender As Object, e As EventArgs) Handles nudPrecio.ValueChanged

    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged

    End Sub
End Class