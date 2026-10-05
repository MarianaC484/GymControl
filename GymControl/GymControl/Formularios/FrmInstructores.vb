Imports System.Data

Public Class FrmInstructores

    Private ReadOnly dao As New InstructorDAO()

    Private modoNuevo As Boolean = False
    Private modoEdicion As Boolean = False
    Private idInstructorSeleccionado As Integer = 0

    Private ReadOnly bnvInstructores As New BindingNavigator(False)


    ' ============================================================
    ' CARGAR FORMULARIO
    ' ============================================================

    Private Sub FrmInstructores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Gestión de Instructores - GymControl"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Maximized

        ConfigurarGrid()
        ConfigurarNavegador()
        ConfigurarEstado()

        CargarInstructores()
        LimpiarCampos()
        BloquearCampos()

    End Sub


    ' ============================================================
    ' CONFIGURAR DATAGRIDVIEW
    ' ============================================================

    Private Sub ConfigurarGrid()

        dgvInstructores.ReadOnly = True
        dgvInstructores.AllowUserToAddRows = False
        dgvInstructores.AllowUserToDeleteRows = False
        dgvInstructores.AutoGenerateColumns = True
        dgvInstructores.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvInstructores.MultiSelect = False
        dgvInstructores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    End Sub


    ' ============================================================
    ' CONFIGURAR BINDINGNAVIGATOR
    ' ============================================================

    Private Sub ConfigurarNavegador()

        bnvInstructores.Dock = DockStyle.Bottom
        bnvInstructores.Height = 35
        bnvInstructores.Visible = True

        ' Limpiar botones predeterminados
        bnvInstructores.Items.Clear()

        ' Primero
        Dim btnPrimero As New ToolStripButton("<<")
        btnPrimero.ToolTipText = "Primer registro"

        AddHandler btnPrimero.Click,
            Sub()
                If dgvInstructores.Rows.Count > 0 Then
                    dgvInstructores.ClearSelection()
                    dgvInstructores.Rows(0).Selected = True
                    dgvInstructores.CurrentCell =
                        dgvInstructores.Rows(0).Cells(0)
                End If
            End Sub

        ' Anterior
        Dim btnAnterior As New ToolStripButton("<")
        btnAnterior.ToolTipText = "Registro anterior"

        AddHandler btnAnterior.Click,
            Sub()
                If dgvInstructores.CurrentRow IsNot Nothing Then

                    Dim indice As Integer =
                        dgvInstructores.CurrentRow.Index

                    If indice > 0 Then
                        dgvInstructores.ClearSelection()
                        dgvInstructores.Rows(indice - 1).Selected = True
                        dgvInstructores.CurrentCell =
                            dgvInstructores.Rows(indice - 1).Cells(0)
                    End If

                End If
            End Sub

        ' Siguiente
        Dim btnSiguiente As New ToolStripButton(">")
        btnSiguiente.ToolTipText = "Siguiente registro"

        AddHandler btnSiguiente.Click,
            Sub()
                If dgvInstructores.CurrentRow IsNot Nothing Then

                    Dim indice As Integer =
                        dgvInstructores.CurrentRow.Index

                    If indice < dgvInstructores.Rows.Count - 1 Then
                        dgvInstructores.ClearSelection()
                        dgvInstructores.Rows(indice + 1).Selected = True
                        dgvInstructores.CurrentCell =
                            dgvInstructores.Rows(indice + 1).Cells(0)
                    End If

                End If
            End Sub

        ' Último
        Dim btnUltimo As New ToolStripButton(">>")
        btnUltimo.ToolTipText = "Último registro"

        AddHandler btnUltimo.Click,
            Sub()
                If dgvInstructores.Rows.Count > 0 Then

                    Dim ultimo As Integer =
                        dgvInstructores.Rows.Count - 1

                    dgvInstructores.ClearSelection()
                    dgvInstructores.Rows(ultimo).Selected = True
                    dgvInstructores.CurrentCell =
                        dgvInstructores.Rows(ultimo).Cells(0)

                End If
            End Sub


        ' Separador
        Dim separador As New ToolStripSeparator()


        ' Botón Nuevo
        Dim navNuevo As New ToolStripButton("Nuevo")
        navNuevo.ToolTipText = "Nuevo instructor"

        AddHandler navNuevo.Click,
            Sub()
                NuevoInstructor()
            End Sub


        ' Botón Editar
        Dim navEditar As New ToolStripButton("Editar")
        navEditar.ToolTipText = "Editar instructor"

        AddHandler navEditar.Click,
            Sub()
                EditarInstructor()
            End Sub


        ' Botón Guardar
        Dim navGuardar As New ToolStripButton("Guardar")
        navGuardar.ToolTipText = "Guardar instructor"

        AddHandler navGuardar.Click,
            Sub()
                GuardarInstructor()
            End Sub


        ' Botón Eliminar
        Dim navEliminar As New ToolStripButton("Desactivar")
        navEliminar.ToolTipText = "Desactivar instructor"

        AddHandler navEliminar.Click,
            Sub()
                DesactivarInstructor()
            End Sub


        ' Botón Cancelar
        Dim navCancelar As New ToolStripButton("Cancelar")
        navCancelar.ToolTipText = "Cancelar operación"

        AddHandler navCancelar.Click,
            Sub()
                CancelarOperacion()
            End Sub


        ' Agregar todos los botones
        bnvInstructores.Items.Add(btnPrimero)
        bnvInstructores.Items.Add(btnAnterior)
        bnvInstructores.Items.Add(btnSiguiente)
        bnvInstructores.Items.Add(btnUltimo)

        bnvInstructores.Items.Add(separador)

        bnvInstructores.Items.Add(navNuevo)
        bnvInstructores.Items.Add(navEditar)
        bnvInstructores.Items.Add(navGuardar)
        bnvInstructores.Items.Add(navEliminar)
        bnvInstructores.Items.Add(navCancelar)

        Me.Controls.Add(bnvInstructores)

    End Sub


    ' ============================================================
    ' CONFIGURAR STATUS
    ' ============================================================

    Private Sub ConfigurarEstado()

        lblEstadoInstructores.Text = "Listo"

    End Sub


    ' ============================================================
    ' CARGAR INSTRUCTORES
    ' ============================================================

    Private Sub CargarInstructores()

        Try

            Dim tabla As DataTable = dao.Listar()

            bsInstructores.DataSource = tabla
            dgvInstructores.DataSource = bsInstructores

            ConfigurarNombresColumnas()

            lblEstadoInstructores.Text =
                "Instructores encontrados: " & tabla.Rows.Count.ToString()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub


    ' ============================================================
    ' NOMBRES DE COLUMNAS
    ' ============================================================

    Private Sub ConfigurarNombresColumnas()

        If dgvInstructores.Columns.Count = 0 Then
            Return
        End If

        If dgvInstructores.Columns.Contains("id_instructor") Then
            dgvInstructores.Columns("id_instructor").HeaderText = "ID"
        End If

        If dgvInstructores.Columns.Contains("cedula") Then
            dgvInstructores.Columns("cedula").HeaderText = "Cédula"
        End If

        If dgvInstructores.Columns.Contains("nombres") Then
            dgvInstructores.Columns("nombres").HeaderText = "Nombres"
        End If

        If dgvInstructores.Columns.Contains("apellidos") Then
            dgvInstructores.Columns("apellidos").HeaderText = "Apellidos"
        End If

        If dgvInstructores.Columns.Contains("especialidad") Then
            dgvInstructores.Columns("especialidad").HeaderText = "Especialidad"
        End If

        If dgvInstructores.Columns.Contains("telefono") Then
            dgvInstructores.Columns("telefono").HeaderText = "Teléfono"
        End If

        If dgvInstructores.Columns.Contains("correo") Then
            dgvInstructores.Columns("correo").HeaderText = "Correo"
        End If

        If dgvInstructores.Columns.Contains("fecha_contratacion") Then
            dgvInstructores.Columns("fecha_contratacion").HeaderText =
                "Fecha de contratación"
        End If

        If dgvInstructores.Columns.Contains("activo") Then
            dgvInstructores.Columns("activo").HeaderText = "Activo"
        End If

    End Sub


    ' ============================================================
    ' SELECCIONAR INSTRUCTOR
    ' ============================================================

    Private Sub dgvInstructores_SelectionChanged(
        sender As Object,
        e As EventArgs) Handles dgvInstructores.SelectionChanged

        If modoNuevo OrElse modoEdicion Then
            Return
        End If

        If dgvInstructores.CurrentRow Is Nothing Then
            Return
        End If

        If dgvInstructores.CurrentRow.Index < 0 Then
            Return
        End If

        CargarInstructorSeleccionado()

    End Sub


    Private Sub CargarInstructorSeleccionado()

        Try

            Dim fila As DataGridViewRow =
                dgvInstructores.CurrentRow

            If fila Is Nothing Then
                Return
            End If

            If fila.Cells("id_instructor").Value Is Nothing Then
                Return
            End If

            idInstructorSeleccionado =
                Convert.ToInt32(fila.Cells("id_instructor").Value)

            txtCedula.Text =
                fila.Cells("cedula").Value.ToString()

            txtNombres.Text =
                fila.Cells("nombres").Value.ToString()

            txtApellidos.Text =
                fila.Cells("apellidos").Value.ToString()

            txtEspecialidad.Text =
                fila.Cells("especialidad").Value.ToString()

            txtTelefono.Text =
                fila.Cells("telefono").Value.ToString()

            txtCorreo.Text =
                fila.Cells("correo").Value.ToString()

            If Not IsDBNull(fila.Cells("fecha_contratacion").Value) Then

                dtpFechaContratacion.Value =
                    Convert.ToDateTime(
                        fila.Cells("fecha_contratacion").Value)

            End If

            If Not IsDBNull(fila.Cells("activo").Value) Then

                chkActivo.Checked =
                    Convert.ToInt32(
                        fila.Cells("activo").Value) = 1

            End If

        Catch ex As Exception

            ' Evita mostrar errores mientras se actualiza el DataGridView.

        End Try

    End Sub


    ' ============================================================
    ' BUSCAR
    ' ============================================================

    Private Sub txtBuscar_TextChanged(
        sender As Object,
        e As EventArgs) Handles txtBuscar.TextChanged

        Dim filtro As String =
            txtBuscar.Text.Trim()

        If filtro = "" Then

            CargarInstructores()

        Else

            Try

                Dim tabla As DataTable =
                    dao.Listar()

                Dim vista As DataView =
                    tabla.DefaultView

                vista.RowFilter =
                    "cedula LIKE '%" & filtro.Replace("'", "''") & "%' " &
                    "OR nombres LIKE '%" & filtro.Replace("'", "''") & "%' " &
                    "OR apellidos LIKE '%" & filtro.Replace("'", "''") & "%' " &
                    "OR especialidad LIKE '%" & filtro.Replace("'", "''") & "%'"

                bsInstructores.DataSource = vista
                dgvInstructores.DataSource = bsInstructores

                ConfigurarNombresColumnas()

                lblEstadoInstructores.Text =
                    "Resultados encontrados: " &
                    vista.Count.ToString()

            Catch ex As Exception

                MessageBox.Show(
                    ex.Message,
                    "Error de búsqueda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

            End Try

        End If

    End Sub


    ' ============================================================
    ' NUEVO
    ' ============================================================

    Private Sub btnNuevo_Click(
        sender As Object,
        e As EventArgs) Handles btnNuevo.Click

        NuevoInstructor()

    End Sub


    Private Sub NuevoInstructor()

        modoNuevo = True
        modoEdicion = False
        idInstructorSeleccionado = 0

        LimpiarCampos()
        DesbloquearCampos()

        txtCedula.Focus()

        lblEstadoInstructores.Text =
            "Nuevo instructor"

    End Sub


    ' ============================================================
    ' EDITAR
    ' ============================================================

    Private Sub btnEditar_Click(
        sender As Object,
        e As EventArgs) Handles btnEditar.Click

        EditarInstructor()

    End Sub


    Private Sub EditarInstructor()

        If idInstructorSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un instructor para editar.",
                "Editar instructor",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Return

        End If

        modoNuevo = False
        modoEdicion = True

        DesbloquearCampos()

        txtCedula.Focus()

        lblEstadoInstructores.Text =
            "Editando instructor"

    End Sub


    ' ============================================================
    ' GUARDAR
    ' ============================================================

    Private Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs) Handles btnGuardar.Click

        GuardarInstructor()

    End Sub


    Private Sub GuardarInstructor()

        If Not ValidarCampos() Then
            Return
        End If

        Try

            Dim cedula As String =
                txtCedula.Text.Trim()

            Dim nombres As String =
                txtNombres.Text.Trim()

            Dim apellidos As String =
                txtApellidos.Text.Trim()

            Dim especialidad As String =
                txtEspecialidad.Text.Trim()

            Dim telefono As String =
                txtTelefono.Text.Trim()

            Dim correo As String =
                txtCorreo.Text.Trim()

            Dim fechaContratacion As Date =
                dtpFechaContratacion.Value.Date

            Dim activo As Integer

            If chkActivo.Checked Then
                activo = 1
            Else
                activo = 0
            End If


            If modoNuevo Then

                ' Verificar cédula duplicada
                Dim existente As DataTable =
                    dao.BuscarPorCedula(cedula)

                If existente.Rows.Count > 0 Then

                    MessageBox.Show(
                        "Ya existe un instructor con esa cédula.",
                        "Cédula duplicada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

                    Return

                End If


                If dao.Insertar(
                    cedula,
                    nombres,
                    apellidos,
                    especialidad,
                    telefono,
                    correo,
                    fechaContratacion,
                    activo) Then

                    MessageBox.Show(
                        "Instructor registrado correctamente.",
                        "Registro exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

                End If

            ElseIf modoEdicion Then

                If dao.Actualizar(
                    idInstructorSeleccionado,
                    cedula,
                    nombres,
                    apellidos,
                    especialidad,
                    telefono,
                    correo,
                    fechaContratacion,
                    activo) Then

                    MessageBox.Show(
                        "Instructor actualizado correctamente.",
                        "Actualización exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

                End If

            Else

                MessageBox.Show(
                    "Seleccione Nuevo o Editar antes de guardar.",
                    "Guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                Return

            End If

            modoNuevo = False
            modoEdicion = False

            CargarInstructores()
            LimpiarCampos()
            BloquearCampos()

            lblEstadoInstructores.Text =
                "Operación realizada correctamente."

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Error al guardar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub


    ' ============================================================
    ' DESACTIVAR
    ' ============================================================

    Private Sub btnEliminar_Click(
        sender As Object,
        e As EventArgs) Handles btnEliminar.Click

        DesactivarInstructor()

    End Sub


    Private Sub DesactivarInstructor()

        If idInstructorSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un instructor.",
                "Desactivar instructor",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Return

        End If


        Dim respuesta As DialogResult =
            MessageBox.Show(
                "¿Está seguro de desactivar este instructor?",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

        If respuesta <> DialogResult.Yes Then
            Return
        End If


        Try

            If dao.Desactivar(idInstructorSeleccionado) Then

                MessageBox.Show(
                    "Instructor desactivado correctamente.",
                    "Operación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                CargarInstructores()
                LimpiarCampos()
                BloquearCampos()

            End If

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Error al desactivar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub


    ' ============================================================
    ' CANCELAR
    ' ============================================================

    Private Sub btnCancelar_Click(
        sender As Object,
        e As EventArgs) Handles btnCancelar.Click

        CancelarOperacion()

    End Sub


    Private Sub CancelarOperacion()

        modoNuevo = False
        modoEdicion = False

        LimpiarCampos()
        BloquearCampos()

        lblEstadoInstructores.Text =
            "Operación cancelada."

    End Sub


    ' ============================================================
    ' VALIDAR CAMPOS
    ' ============================================================

    Private Function ValidarCampos() As Boolean

        If String.IsNullOrWhiteSpace(txtCedula.Text) Then

            MessageBox.Show(
                "Ingrese la cédula del instructor.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtCedula.Focus()
            Return False

        End If


        If String.IsNullOrWhiteSpace(txtNombres.Text) Then

            MessageBox.Show(
                "Ingrese los nombres del instructor.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtNombres.Focus()
            Return False

        End If


        If String.IsNullOrWhiteSpace(txtApellidos.Text) Then

            MessageBox.Show(
                "Ingrese los apellidos del instructor.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtApellidos.Focus()
            Return False

        End If


        If String.IsNullOrWhiteSpace(txtEspecialidad.Text) Then

            MessageBox.Show(
                "Ingrese la especialidad del instructor.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtEspecialidad.Focus()
            Return False

        End If


        Return True

    End Function


    ' ============================================================
    ' LIMPIAR CAMPOS
    ' ============================================================

    Private Sub LimpiarCampos()

        txtCedula.Clear()
        txtNombres.Clear()
        txtApellidos.Clear()
        txtEspecialidad.Clear()
        txtTelefono.Clear()
        txtCorreo.Clear()

        dtpFechaContratacion.Value = Date.Today

        chkActivo.Checked = True

        idInstructorSeleccionado = 0

    End Sub


    ' ============================================================
    ' BLOQUEAR CAMPOS
    ' ============================================================

    Private Sub BloquearCampos()

        txtCedula.ReadOnly = True
        txtNombres.ReadOnly = True
        txtApellidos.ReadOnly = True
        txtEspecialidad.ReadOnly = True
        txtTelefono.ReadOnly = True
        txtCorreo.ReadOnly = True

        dtpFechaContratacion.Enabled = False
        chkActivo.Enabled = False

    End Sub


    ' ============================================================
    ' DESBLOQUEAR CAMPOS
    ' ============================================================

    Private Sub DesbloquearCampos()

        txtCedula.ReadOnly = False
        txtNombres.ReadOnly = False
        txtApellidos.ReadOnly = False
        txtEspecialidad.ReadOnly = False
        txtTelefono.ReadOnly = False
        txtCorreo.ReadOnly = False

        dtpFechaContratacion.Enabled = True
        chkActivo.Enabled = True

    End Sub

End Class