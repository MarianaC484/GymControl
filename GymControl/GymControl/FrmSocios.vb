Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmSocios

    ' ============================================================
    ' VARIABLES
    ' ============================================================

    Private dtSocios As New DataTable()

    Private modoNuevo As Boolean = False
    Private modoEdicion As Boolean = False

    Private idSocioSeleccionado As Integer = 0

    ' BindingNavigator creado completamente por código
    Private bnvSocios As BindingNavigator


    ' ============================================================
    ' CARGAR FORMULARIO
    ' ============================================================

    Private Sub frmSocios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            ConfigurarFormulario()

            ' Crear BindingNavigator por código
            ConfigurarBindingNavigator()

            ' Cargar datos
            CargarGeneros()
            CargarSocios()

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
    ' CONFIGURACIÓN INICIAL DEL FORMULARIO
    ' ============================================================

    Private Sub ConfigurarFormulario()

        ' --------------------------------------------------------
        ' CAMPOS
        ' --------------------------------------------------------

        txtCedula.ReadOnly = True
        txtNombres.ReadOnly = True
        txtApellidos.ReadOnly = True

        dtpFechaNacimiento.Enabled = False
        cboGenero.Enabled = False

        txtTelefono.ReadOnly = True
        txtCorreo.ReadOnly = True
        txtDireccion.ReadOnly = True

        chkActivo.Enabled = False


        ' --------------------------------------------------------
        ' BOTONES
        ' --------------------------------------------------------

        btnNuevo.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True

        btnGuardar.Enabled = False
        btnCancelar.Enabled = False


        ' --------------------------------------------------------
        ' DATAGRIDVIEW
        ' --------------------------------------------------------

        dgvSocios.ReadOnly = True

        dgvSocios.AllowUserToAddRows = False
        dgvSocios.AllowUserToDeleteRows = False
        dgvSocios.AllowUserToResizeRows = False

        dgvSocios.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvSocios.MultiSelect = False

        dgvSocios.AutoGenerateColumns = True

        dgvSocios.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        dgvSocios.RowHeadersVisible = False

    End Sub


    ' ============================================================
    ' CREAR BINDING NAVIGATOR POR CÓDIGO
    ' ============================================================

    Private Sub ConfigurarBindingNavigator()

        ' --------------------------------------------------------
        ' CREAR BINDING NAVIGATOR
        ' --------------------------------------------------------

        bnvSocios = New BindingNavigator(False)

        With bnvSocios

            .Name = "bnvSocios"

            .Dock = DockStyle.Bottom

            .GripStyle = ToolStripGripStyle.Hidden

            .AutoSize = True

            .Visible = True

        End With


        ' --------------------------------------------------------
        ' BOTONES DE NAVEGACIÓN
        ' --------------------------------------------------------

        Dim btnPrimero As New ToolStripButton("<<")
        Dim btnAnterior As New ToolStripButton("<")
        Dim btnSiguiente As New ToolStripButton(">")
        Dim btnUltimo As New ToolStripButton(">>")


        btnPrimero.Name = "btnNavPrimero"
        btnAnterior.Name = "btnNavAnterior"
        btnSiguiente.Name = "btnNavSiguiente"
        btnUltimo.Name = "btnNavUltimo"


        btnPrimero.ToolTipText = "Primer socio"
        btnAnterior.ToolTipText = "Socio anterior"
        btnSiguiente.ToolTipText = "Socio siguiente"
        btnUltimo.ToolTipText = "Último socio"


        ' --------------------------------------------------------
        ' SEPARADOR
        ' --------------------------------------------------------

        Dim separador1 As New ToolStripSeparator()


        ' --------------------------------------------------------
        ' INDICADOR DE POSICIÓN
        ' --------------------------------------------------------

        Dim lblRegistro As New ToolStripLabel("Registro:")

        Dim txtPosicion As New ToolStripTextBox()

        txtPosicion.Name = "txtNavPosicion"

        txtPosicion.Width = 55

        txtPosicion.ReadOnly = True

        txtPosicion.TextBoxTextAlign =
            HorizontalAlignment.Center


        ' --------------------------------------------------------
        ' SEPARADOR
        ' --------------------------------------------------------

        Dim separador2 As New ToolStripSeparator()


        ' --------------------------------------------------------
        ' BOTONES DE OPERACIÓN
        ' --------------------------------------------------------

        Dim btnNuevoNav As New ToolStripButton("Nuevo")
        Dim btnEditarNav As New ToolStripButton("Editar")
        Dim btnGuardarNav As New ToolStripButton("Guardar")
        Dim btnEliminarNav As New ToolStripButton("Eliminar")
        Dim btnCancelarNav As New ToolStripButton("Cancelar")


        btnNuevoNav.Name = "btnNavNuevo"
        btnEditarNav.Name = "btnNavEditar"
        btnGuardarNav.Name = "btnNavGuardar"
        btnEliminarNav.Name = "btnNavEliminar"
        btnCancelarNav.Name = "btnNavCancelar"


        btnNuevoNav.ToolTipText = "Nuevo socio"
        btnEditarNav.ToolTipText = "Editar socio"
        btnGuardarNav.ToolTipText = "Guardar cambios"
        btnEliminarNav.ToolTipText = "Desactivar socio"
        btnCancelarNav.ToolTipText = "Cancelar operación"


        ' --------------------------------------------------------
        ' AGREGAR ELEMENTOS AL NAVIGATOR
        ' --------------------------------------------------------

        bnvSocios.Items.Add(btnPrimero)
        bnvSocios.Items.Add(btnAnterior)

        bnvSocios.Items.Add(lblRegistro)
        bnvSocios.Items.Add(txtPosicion)

        bnvSocios.Items.Add(btnSiguiente)
        bnvSocios.Items.Add(btnUltimo)

        bnvSocios.Items.Add(separador1)

        bnvSocios.Items.Add(btnNuevoNav)
        bnvSocios.Items.Add(btnEditarNav)
        bnvSocios.Items.Add(btnGuardarNav)
        bnvSocios.Items.Add(btnEliminarNav)
        bnvSocios.Items.Add(btnCancelarNav)

        bnvSocios.Items.Add(separador2)


        ' --------------------------------------------------------
        ' AGREGAR AL FORMULARIO
        ' --------------------------------------------------------

        Me.Controls.Add(bnvSocios)


        ' --------------------------------------------------------
        ' EVENTOS DE NAVEGACIÓN
        ' --------------------------------------------------------

        AddHandler btnPrimero.Click,
            AddressOf NavegarPrimero

        AddHandler btnAnterior.Click,
            AddressOf NavegarAnterior

        AddHandler btnSiguiente.Click,
            AddressOf NavegarSiguiente

        AddHandler btnUltimo.Click,
            AddressOf NavegarUltimo


        ' --------------------------------------------------------
        ' EVENTOS DE OPERACIÓN
        ' --------------------------------------------------------

        AddHandler btnNuevoNav.Click,
            AddressOf btnNuevo_Click

        AddHandler btnEditarNav.Click,
            AddressOf btnEditar_Click

        AddHandler btnGuardarNav.Click,
            AddressOf btnGuardar_Click

        AddHandler btnEliminarNav.Click,
            AddressOf btnEliminar_Click

        AddHandler btnCancelarNav.Click,
            AddressOf btnCancelar_Click


        ' --------------------------------------------------------
        ' ASOCIAR BINDINGSOURCE
        ' --------------------------------------------------------

        If bsSocios IsNot Nothing Then

            bnvSocios.BindingSource = bsSocios

        End If

    End Sub


    ' ============================================================
    ' CARGAR GÉNEROS
    ' ============================================================

    Private Sub CargarGeneros()

        cboGenero.Items.Clear()

        cboGenero.Items.Add("F")
        cboGenero.Items.Add("M")

        cboGenero.SelectedIndex = -1

    End Sub


    ' ============================================================
    ' CARGAR SOCIOS
    ' ============================================================

    Private Sub CargarSocios()

        Try

            dtSocios = SocioDAO.Listar()

            If dtSocios Is Nothing Then

                dtSocios = New DataTable()

            End If


            ' ----------------------------------------------------
            ' BINDING SOURCE
            ' ----------------------------------------------------

            bsSocios.DataSource = dtSocios


            ' ----------------------------------------------------
            ' DATAGRIDVIEW
            ' ----------------------------------------------------

            dgvSocios.DataSource = bsSocios


            ' ----------------------------------------------------
            ' BINDING NAVIGATOR
            ' ----------------------------------------------------

            If bnvSocios IsNot Nothing Then

                bnvSocios.BindingSource = bsSocios

            End If


            ' ----------------------------------------------------
            ' CONFIGURAR COLUMNAS
            ' ----------------------------------------------------

            ConfigurarColumnas()


            ' ----------------------------------------------------
            ' MOSTRAR PRIMER SOCIO
            ' ----------------------------------------------------

            If bsSocios.Count > 0 Then

                bsSocios.Position = 0

                MostrarSocioActual()

            Else

                LimpiarCampos()

            End If


            ActualizarEstado()


        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los socios:" &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' CONFIGURAR COLUMNAS DEL DATAGRIDVIEW
    ' ============================================================

    Private Sub ConfigurarColumnas()

        If dgvSocios.Columns.Count = 0 Then
            Return
        End If


        If dgvSocios.Columns.Contains("id_socio") Then

            dgvSocios.Columns("id_socio").HeaderText = "ID"

        End If


        If dgvSocios.Columns.Contains("cedula") Then

            dgvSocios.Columns("cedula").HeaderText = "Cédula"

        End If


        If dgvSocios.Columns.Contains("nombres") Then

            dgvSocios.Columns("nombres").HeaderText = "Nombres"

        End If


        If dgvSocios.Columns.Contains("apellidos") Then

            dgvSocios.Columns("apellidos").HeaderText = "Apellidos"

        End If


        If dgvSocios.Columns.Contains("fecha_nacimiento") Then

            dgvSocios.Columns("fecha_nacimiento").HeaderText =
                "Fecha nacimiento"

            dgvSocios.Columns("fecha_nacimiento").DefaultCellStyle.Format =
                "dd/MM/yyyy"

        End If


        If dgvSocios.Columns.Contains("genero") Then

            dgvSocios.Columns("genero").HeaderText = "Género"

        End If


        If dgvSocios.Columns.Contains("telefono") Then

            dgvSocios.Columns("telefono").HeaderText = "Teléfono"

        End If


        If dgvSocios.Columns.Contains("correo") Then

            dgvSocios.Columns("correo").HeaderText = "Correo"

        End If


        If dgvSocios.Columns.Contains("direccion") Then

            dgvSocios.Columns("direccion").HeaderText = "Dirección"

        End If


        If dgvSocios.Columns.Contains("fecha_registro") Then

            dgvSocios.Columns("fecha_registro").HeaderText =
                "Fecha registro"

            dgvSocios.Columns("fecha_registro").DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm"

        End If


        If dgvSocios.Columns.Contains("activo") Then

            dgvSocios.Columns("activo").HeaderText = "Activo"

        End If

    End Sub


    ' ============================================================
    ' MOSTRAR SOCIO ACTUAL
    ' ============================================================

    Private Sub MostrarSocioActual()

        Try

            If bsSocios Is Nothing Then

                LimpiarCampos()

                Return

            End If


            If bsSocios.Current Is Nothing Then

                LimpiarCampos()

                Return

            End If


            Dim fila As DataRowView =
                TryCast(bsSocios.Current, DataRowView)


            If fila Is Nothing Then

                Return

            End If


            ' ----------------------------------------------------
            ' ID
            ' ----------------------------------------------------

            If Not IsDBNull(fila("id_socio")) Then

                idSocioSeleccionado =
                    Convert.ToInt32(fila("id_socio"))

            Else

                idSocioSeleccionado = 0

            End If


            ' ----------------------------------------------------
            ' CÉDULA
            ' ----------------------------------------------------

            If Not IsDBNull(fila("cedula")) Then

                txtCedula.Text =
                    fila("cedula").ToString()

            Else

                txtCedula.Clear()

            End If


            ' ----------------------------------------------------
            ' NOMBRES
            ' ----------------------------------------------------

            If Not IsDBNull(fila("nombres")) Then

                txtNombres.Text =
                    fila("nombres").ToString()

            Else

                txtNombres.Clear()

            End If


            ' ----------------------------------------------------
            ' APELLIDOS
            ' ----------------------------------------------------

            If Not IsDBNull(fila("apellidos")) Then

                txtApellidos.Text =
                    fila("apellidos").ToString()

            Else

                txtApellidos.Clear()

            End If


            ' ----------------------------------------------------
            ' FECHA NACIMIENTO
            ' ----------------------------------------------------

            If Not IsDBNull(fila("fecha_nacimiento")) Then

                Dim fechaNacimiento As DateTime =
                    Convert.ToDateTime(
                        fila("fecha_nacimiento")
                    )

                If fechaNacimiento >= dtpFechaNacimiento.MinDate AndAlso
                   fechaNacimiento <= dtpFechaNacimiento.MaxDate Then

                    dtpFechaNacimiento.Value =
                        fechaNacimiento

                Else

                    dtpFechaNacimiento.Value =
                        Date.Today

                End If

            Else

                dtpFechaNacimiento.Value =
                    Date.Today

            End If


            ' ----------------------------------------------------
            ' GÉNERO
            ' ----------------------------------------------------

            If Not IsDBNull(fila("genero")) Then

                Dim genero As String =
                    fila("genero").ToString()

                cboGenero.SelectedItem = genero

            Else

                cboGenero.SelectedIndex = -1

            End If


            ' ----------------------------------------------------
            ' TELÉFONO
            ' ----------------------------------------------------

            If Not IsDBNull(fila("telefono")) Then

                txtTelefono.Text =
                    fila("telefono").ToString()

            Else

                txtTelefono.Clear()

            End If


            ' ----------------------------------------------------
            ' CORREO
            ' ----------------------------------------------------

            If Not IsDBNull(fila("correo")) Then

                txtCorreo.Text =
                    fila("correo").ToString()

            Else

                txtCorreo.Clear()

            End If


            ' ----------------------------------------------------
            ' DIRECCIÓN
            ' ----------------------------------------------------

            If Not IsDBNull(fila("direccion")) Then

                txtDireccion.Text =
                    fila("direccion").ToString()

            Else

                txtDireccion.Clear()

            End If


            ' ----------------------------------------------------
            ' ACTIVO
            ' ----------------------------------------------------

            If Not IsDBNull(fila("activo")) Then

                chkActivo.Checked =
                    Convert.ToBoolean(fila("activo"))

            Else

                chkActivo.Checked = False

            End If


            ' ----------------------------------------------------
            ' ACTUALIZAR POSICIÓN DEL NAVIGATOR
            ' ----------------------------------------------------

            ActualizarPosicionNavigator()


        Catch ex As Exception

            MessageBox.Show(
                "No se pudo mostrar el socio:" &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' ACTUALIZAR POSICIÓN DEL NAVIGATOR
    ' ============================================================

    Private Sub ActualizarPosicionNavigator()

        If bnvSocios Is Nothing Then
            Return
        End If


        If bsSocios Is Nothing Then
            Return
        End If


        Dim txtPosicion As ToolStripTextBox =
            TryCast(
                bnvSocios.Items("txtNavPosicion"),
                ToolStripTextBox
            )


        If txtPosicion Is Nothing Then
            Return
        End If


        If bsSocios.Count = 0 Then

            txtPosicion.Text = "0/0"

        Else

            txtPosicion.Text =
                (bsSocios.Position + 1).ToString() &
                "/" &
                bsSocios.Count.ToString()

        End If

    End Sub


    ' ============================================================
    ' NAVEGAR AL PRIMER SOCIO
    ' ============================================================

    Private Sub NavegarPrimero(sender As Object, e As EventArgs)

        If modoNuevo OrElse modoEdicion Then
            Return
        End If


        If bsSocios.Count > 0 Then

            bsSocios.MoveFirst()

            MostrarSocioActual()

        End If

    End Sub


    ' ============================================================
    ' NAVEGAR AL SOCIO ANTERIOR
    ' ============================================================

    Private Sub NavegarAnterior(sender As Object, e As EventArgs)

        If modoNuevo OrElse modoEdicion Then
            Return
        End If


        If bsSocios.Count > 0 Then

            bsSocios.MovePrevious()

            MostrarSocioActual()

        End If

    End Sub


    ' ============================================================
    ' NAVEGAR AL SOCIO SIGUIENTE
    ' ============================================================

    Private Sub NavegarSiguiente(sender As Object, e As EventArgs)

        If modoNuevo OrElse modoEdicion Then
            Return
        End If


        If bsSocios.Count > 0 Then

            bsSocios.MoveNext()

            MostrarSocioActual()

        End If

    End Sub


    ' ============================================================
    ' NAVEGAR AL ÚLTIMO SOCIO
    ' ============================================================

    Private Sub NavegarUltimo(sender As Object, e As EventArgs)

        If modoNuevo OrElse modoEdicion Then
            Return
        End If


        If bsSocios.Count > 0 Then

            bsSocios.MoveLast()

            MostrarSocioActual()

        End If

    End Sub


    ' ============================================================
    ' BOTÓN NUEVO
    ' ============================================================

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        modoNuevo = True

        modoEdicion = False

        idSocioSeleccionado = 0


        LimpiarCampos()


        HabilitarEdicion(True)


        txtCedula.Focus()


        lblEstadoSocios.Text =
            "Registrando nuevo socio..."


    End Sub


    ' ============================================================
    ' BOTÓN EDITAR
    ' ============================================================

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        If bsSocios Is Nothing OrElse
           bsSocios.Current Is Nothing Then

            MessageBox.Show(
                "Seleccione un socio para editar.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        modoNuevo = False

        modoEdicion = True


        HabilitarEdicion(True)


        txtCedula.Focus()


        lblEstadoSocios.Text =
            "Editando socio..."

    End Sub


    ' ============================================================
    ' BOTÓN GUARDAR
    ' ============================================================

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try

            If Not ValidarDatos() Then

                Return

            End If


            Dim resultado As Boolean = False


            ' ----------------------------------------------------
            ' NUEVO SOCIO
            ' ----------------------------------------------------

            If modoNuevo Then

                resultado = SocioDAO.Insertar(
                    txtCedula.Text.Trim(),
                    txtNombres.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    dtpFechaNacimiento.Value.Date,
                    cboGenero.Text,
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtDireccion.Text.Trim()
                )


                If resultado Then

                    MessageBox.Show(
                        "El socio se registró correctamente.",
                        "Registro exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    )

                End If


                ' ----------------------------------------------------
                ' EDITAR SOCIO
                ' ----------------------------------------------------

            ElseIf modoEdicion Then

                resultado = SocioDAO.Actualizar(
                    idSocioSeleccionado,
                    txtCedula.Text.Trim(),
                    txtNombres.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    dtpFechaNacimiento.Value.Date,
                    cboGenero.Text,
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtDireccion.Text.Trim()
                )


                If resultado Then

                    MessageBox.Show(
                        "Los datos del socio se actualizaron correctamente.",
                        "Actualización exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    )

                End If

            End If


            ' ----------------------------------------------------
            ' SI GUARDÓ CORRECTAMENTE
            ' ----------------------------------------------------

            If resultado Then

                modoNuevo = False

                modoEdicion = False


                HabilitarEdicion(False)


                CargarSocios()


                lblEstadoSocios.Text =
                    "Operación realizada correctamente."

            End If


        Catch ex As Exception

            MessageBox.Show(
                "Ocurrió un error al guardar el socio:" &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' BOTÓN ELIMINAR / DESACTIVAR
    ' ============================================================

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If idSocioSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un socio.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        Dim respuesta As DialogResult =
            MessageBox.Show(
                "¿Está seguro de desactivar este socio?",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )


        If respuesta = DialogResult.Yes Then

            Try

                If SocioDAO.Desactivar(idSocioSeleccionado) Then

                    MessageBox.Show(
                        "El socio fue desactivado correctamente.",
                        "Operación exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    )


                    CargarSocios()

                End If


            Catch ex As Exception

                MessageBox.Show(
                    "No se pudo desactivar el socio:" &
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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        modoNuevo = False

        modoEdicion = False


        HabilitarEdicion(False)


        MostrarSocioActual()


        lblEstadoSocios.Text =
            "Operación cancelada."

    End Sub


    ' ============================================================
    ' BUSCAR SOCIO
    ' ============================================================

    Private Sub txtBuscar_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtBuscar.TextChanged


        If modoNuevo OrElse modoEdicion Then

            Return

        End If


        Try

            Dim filtro As String =
                txtBuscar.Text.Trim()


            ' ----------------------------------------------------
            ' SIN FILTRO
            ' ----------------------------------------------------

            If filtro = "" Then

                dtSocios = SocioDAO.Listar()


                ' ----------------------------------------------------
                ' CON FILTRO
                ' ----------------------------------------------------

            Else

                dtSocios =
                    SocioDAO.Buscar(filtro)

            End If


            If dtSocios Is Nothing Then

                dtSocios = New DataTable()

            End If


            ' ----------------------------------------------------
            ' ACTUALIZAR BINDINGSOURCE
            ' ----------------------------------------------------

            bsSocios.DataSource = dtSocios

            dgvSocios.DataSource = bsSocios


            If bnvSocios IsNot Nothing Then

                bnvSocios.BindingSource =
                    bsSocios

            End If


            ConfigurarColumnas()


            ' ----------------------------------------------------
            ' MOSTRAR RESULTADO
            ' ----------------------------------------------------

            If bsSocios.Count > 0 Then

                bsSocios.Position = 0

                MostrarSocioActual()

            Else

                LimpiarCampos()

            End If


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
    ' CAMBIO DE REGISTRO
    ' ============================================================

    Private Sub bsSocios_PositionChanged(
        sender As Object,
        e As EventArgs
    ) Handles bsSocios.PositionChanged


        If Not modoNuevo AndAlso
           Not modoEdicion Then

            MostrarSocioActual()

        End If


        ActualizarPosicionNavigator()

    End Sub


    ' ============================================================
    ' CLICK EN DATAGRIDVIEW
    ' ============================================================

    Private Sub dgvSocios_SelectionChanged(
        sender As Object,
        e As EventArgs
    ) Handles dgvSocios.SelectionChanged


        If modoNuevo OrElse modoEdicion Then

            Return

        End If


        If dgvSocios.CurrentRow Is Nothing Then

            Return

        End If


        Dim fila As DataGridViewRow =
            dgvSocios.CurrentRow


        If fila.DataBoundItem IsNot Nothing Then

            Dim filaDatos As DataRowView =
                TryCast(
                    fila.DataBoundItem,
                    DataRowView
                )


            If filaDatos IsNot Nothing Then

                bsSocios.Position =
                    dgvSocios.CurrentRow.Index

            End If

        End If

    End Sub


    ' ============================================================
    ' VALIDAR DATOS
    ' ============================================================

    Private Function ValidarDatos() As Boolean


        ' --------------------------------------------------------
        ' CÉDULA
        ' --------------------------------------------------------

        If String.IsNullOrWhiteSpace(
            txtCedula.Text
        ) Then

            MessageBox.Show(
                "Ingrese la cédula.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtCedula.Focus()

            Return False

        End If


        ' --------------------------------------------------------
        ' NOMBRES
        ' --------------------------------------------------------

        If String.IsNullOrWhiteSpace(
            txtNombres.Text
        ) Then

            MessageBox.Show(
                "Ingrese los nombres.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtNombres.Focus()

            Return False

        End If


        ' --------------------------------------------------------
        ' APELLIDOS
        ' --------------------------------------------------------

        If String.IsNullOrWhiteSpace(
            txtApellidos.Text
        ) Then

            MessageBox.Show(
                "Ingrese los apellidos.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtApellidos.Focus()

            Return False

        End If


        ' --------------------------------------------------------
        ' GÉNERO
        ' --------------------------------------------------------

        If cboGenero.SelectedIndex = -1 Then

            MessageBox.Show(
                "Seleccione el género.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            cboGenero.Focus()

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


        ' --------------------------------------------------------
        ' CAMPOS
        ' --------------------------------------------------------

        txtCedula.ReadOnly =
            Not habilitar

        txtNombres.ReadOnly =
            Not habilitar

        txtApellidos.ReadOnly =
            Not habilitar


        dtpFechaNacimiento.Enabled =
            habilitar


        cboGenero.Enabled =
            habilitar


        txtTelefono.ReadOnly =
            Not habilitar

        txtCorreo.ReadOnly =
            Not habilitar

        txtDireccion.ReadOnly =
            Not habilitar


        chkActivo.Enabled =
            habilitar


        ' --------------------------------------------------------
        ' BOTONES PRINCIPALES
        ' --------------------------------------------------------

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


        ' --------------------------------------------------------
        ' BOTONES DEL NAVIGATOR
        ' --------------------------------------------------------

        If bnvSocios IsNot Nothing Then

            Dim btnNavNuevo =
                bnvSocios.Items("btnNavNuevo")

            Dim btnNavEditar =
                bnvSocios.Items("btnNavEditar")

            Dim btnNavGuardar =
                bnvSocios.Items("btnNavGuardar")

            Dim btnNavEliminar =
                bnvSocios.Items("btnNavEliminar")

            Dim btnNavCancelar =
                bnvSocios.Items("btnNavCancelar")


            If btnNavNuevo IsNot Nothing Then

                btnNavNuevo.Enabled =
                    Not habilitar

            End If


            If btnNavEditar IsNot Nothing Then

                btnNavEditar.Enabled =
                    Not habilitar

            End If


            If btnNavGuardar IsNot Nothing Then

                btnNavGuardar.Enabled =
                    habilitar

            End If


            If btnNavEliminar IsNot Nothing Then

                btnNavEliminar.Enabled =
                    Not habilitar

            End If


            If btnNavCancelar IsNot Nothing Then

                btnNavCancelar.Enabled =
                    habilitar

            End If

        End If

    End Sub


    ' ============================================================
    ' LIMPIAR CAMPOS
    ' ============================================================

    Private Sub LimpiarCampos()

        idSocioSeleccionado = 0


        txtCedula.Clear()

        txtNombres.Clear()

        txtApellidos.Clear()

        txtTelefono.Clear()

        txtCorreo.Clear()

        txtDireccion.Clear()


        dtpFechaNacimiento.Value =
            Date.Today


        cboGenero.SelectedIndex = -1


        chkActivo.Checked = True


        ActualizarPosicionNavigator()

    End Sub


    ' ============================================================
    ' ACTUALIZAR ESTADO
    ' ============================================================

    Private Sub ActualizarEstado()

        If bsSocios Is Nothing Then

            lblEstadoSocios.Text =
                "Socios encontrados: 0"

            Return

        End If


        lblEstadoSocios.Text =
            "Socios encontrados: " &
            bsSocios.Count.ToString()


        ActualizarPosicionNavigator()

    End Sub

End Class
