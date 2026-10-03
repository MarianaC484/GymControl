Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySqlConnector

Public Class frmHorarios

    '========================================================
    ' VARIABLES
    '========================================================

    Private dtHorarios As New DataTable()

    Private idHorarioSeleccionado As Integer = 0
    Private modoEdicion As Boolean = False

    Private bnvHorarios As BindingNavigator


    '========================================================
    ' CARGA DEL FORMULARIO
    '========================================================

    Private Sub frmHorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ConfigurarFormulario()
        ConfigurarBindingNavigator()

        CargarDias()
        CargarInstructores()
        CargarActividades()
        CargarSalas()
        CargarHorarios()

        LimpiarCampos()

    End Sub


    '========================================================
    ' CONFIGURACIÓN GENERAL
    '========================================================

    Private Sub ConfigurarFormulario()

        Me.Text = "Gestión de Horarios"
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Horas
        dtpHoraInicio.Format = DateTimePickerFormat.Time
        dtpHoraInicio.ShowUpDown = True

        dtpHoraFin.Format = DateTimePickerFormat.Time
        dtpHoraFin.ShowUpDown = True

        ' ComboBox
        cboInstructor.DropDownStyle = ComboBoxStyle.DropDownList
        cboActividad.DropDownStyle = ComboBoxStyle.DropDownList
        cboSala.DropDownStyle = ComboBoxStyle.DropDownList
        cboDia.DropDownStyle = ComboBoxStyle.DropDownList

        ' DataGridView
        dgvHorarios.AutoGenerateColumns = True
        dgvHorarios.AllowUserToAddRows = False
        dgvHorarios.AllowUserToDeleteRows = False
        dgvHorarios.ReadOnly = True
        dgvHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvHorarios.MultiSelect = False
        dgvHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Botones
        btnGuardar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        btnCancelar.Enabled = False

    End Sub


    '========================================================
    ' BINDINGNAVIGATOR
    '========================================================

    Private Sub ConfigurarBindingNavigator()

        If bnvHorarios IsNot Nothing Then
            Me.Controls.Remove(bnvHorarios)
        End If

        bnvHorarios = New BindingNavigator(False)

        bnvHorarios.Name = "bnvHorarios"
        bnvHorarios.Dock = DockStyle.Bottom
        bnvHorarios.Height = 35

        Dim btnPrimero As New ToolStripButton("|<")
        Dim btnAnterior As New ToolStripButton("<")
        Dim btnSiguiente As New ToolStripButton(">")
        Dim btnUltimo As New ToolStripButton(">|")

        AddHandler btnPrimero.Click,
            Sub()
                IrPrimero()
            End Sub

        AddHandler btnAnterior.Click,
            Sub()
                IrAnterior()
            End Sub

        AddHandler btnSiguiente.Click,
            Sub()
                IrSiguiente()
            End Sub

        AddHandler btnUltimo.Click,
            Sub()
                IrUltimo()
            End Sub

        bnvHorarios.Items.Add(btnPrimero)
        bnvHorarios.Items.Add(btnAnterior)

        bnvHorarios.Items.Add(
            New ToolStripSeparator()
        )

        bnvHorarios.Items.Add(btnSiguiente)
        bnvHorarios.Items.Add(btnUltimo)

        Me.Controls.Add(bnvHorarios)

        bnvHorarios.BringToFront()

    End Sub


    '========================================================
    ' CARGAR DÍAS
    '========================================================

    Private Sub CargarDias()

        cboDia.Items.Clear()

        cboDia.Items.Add("Lunes")
        cboDia.Items.Add("Martes")
        cboDia.Items.Add("Miércoles")
        cboDia.Items.Add("Jueves")
        cboDia.Items.Add("Viernes")
        cboDia.Items.Add("Sábado")
        cboDia.Items.Add("Domingo")

        cboDia.SelectedIndex = -1

    End Sub


    '========================================================
    ' CARGAR INSTRUCTORES
    '========================================================

    Private Sub CargarInstructores()

        Try

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "SELECT * FROM instructores ORDER BY 1"

                Using cmd As New MySqlCommand(sql, cn)

                    Using da As New MySqlDataAdapter(cmd)

                        Dim dt As New DataTable()

                        da.Fill(dt)

                        If dt.Columns.Count = 0 Then
                            MessageBox.Show(
                                "La tabla instructores no contiene columnas.",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            )
                            Return
                        End If

                        Dim columnaId As String =
                            BuscarColumna(dt,
                                          "id_instructor")

                        If columnaId = "" Then
                            MessageBox.Show(
                                "No se encontró la columna id_instructor en instructores.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            )
                            Return
                        End If

                        Dim columnaTexto As String =
                            BuscarColumna(dt,
                                          "nombre",
                                          "nombres",
                                          "nombre_instructor",
                                          "descripcion")

                        If columnaTexto = "" Then
                            columnaTexto = PrimeraColumnaTexto(dt, columnaId)
                        End If

                        If columnaTexto = "" Then
                            columnaTexto = columnaId
                        End If

                        Dim tabla As New DataTable()

                        tabla.Columns.Add("id_instructor", GetType(Integer))
                        tabla.Columns.Add("nombre_mostrar", GetType(String))

                        For Each fila As DataRow In dt.Rows

                            If IsDBNull(fila(columnaId)) Then Continue For

                            Dim id As Integer =
                                Convert.ToInt32(fila(columnaId))

                            Dim texto As String =
                                ObtenerTextoInstructor(fila, dt)

                            If String.IsNullOrWhiteSpace(texto) Then
                                texto = fila(columnaTexto).ToString()
                            End If

                            tabla.Rows.Add(id, texto)

                        Next

                        cboInstructor.DataSource = Nothing
                        cboInstructor.DataSource = tabla
                        cboInstructor.DisplayMember = "nombre_mostrar"
                        cboInstructor.ValueMember = "id_instructor"
                        cboInstructor.SelectedIndex = -1

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los instructores:" &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' CARGAR ACTIVIDADES
    '========================================================

    Private Sub CargarActividades()

        Try

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "SELECT * FROM actividades ORDER BY 1"

                Using cmd As New MySqlCommand(sql, cn)

                    Using da As New MySqlDataAdapter(cmd)

                        Dim dt As New DataTable()

                        da.Fill(dt)

                        Dim columnaId As String =
                            BuscarColumna(dt,
                                          "id_actividad")

                        If columnaId = "" Then
                            MessageBox.Show(
                                "No se encontró id_actividad en actividades.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            )
                            Return
                        End If

                        Dim columnaTexto As String =
                            BuscarColumna(dt,
                                          "nombre",
                                          "nombre_actividad",
                                          "descripcion")

                        If columnaTexto = "" Then
                            columnaTexto = PrimeraColumnaTexto(dt, columnaId)
                        End If

                        If columnaTexto = "" Then
                            columnaTexto = columnaId
                        End If

                        Dim tabla As New DataTable()

                        tabla.Columns.Add("id_actividad", GetType(Integer))
                        tabla.Columns.Add("nombre_mostrar", GetType(String))

                        For Each fila As DataRow In dt.Rows

                            If IsDBNull(fila(columnaId)) Then Continue For

                            Dim id As Integer =
                                Convert.ToInt32(fila(columnaId))

                            Dim texto As String =
                                fila(columnaTexto).ToString()

                            tabla.Rows.Add(id, texto)

                        Next

                        cboActividad.DataSource = Nothing
                        cboActividad.DataSource = tabla
                        cboActividad.DisplayMember = "nombre_mostrar"
                        cboActividad.ValueMember = "id_actividad"
                        cboActividad.SelectedIndex = -1

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar las actividades:" &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' CARGAR SALAS
    '========================================================

    Private Sub CargarSalas()

        Try

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "SELECT * FROM salas ORDER BY 1"

                Using cmd As New MySqlCommand(sql, cn)

                    Using da As New MySqlDataAdapter(cmd)

                        Dim dt As New DataTable()

                        da.Fill(dt)

                        Dim columnaId As String =
                            BuscarColumna(dt,
                                          "id_sala")

                        If columnaId = "" Then
                            MessageBox.Show(
                                "No se encontró id_sala en salas.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            )
                            Return
                        End If

                        Dim columnaTexto As String =
                            BuscarColumna(dt,
                                          "nombre",
                                          "nombre_sala",
                                          "descripcion")

                        If columnaTexto = "" Then
                            columnaTexto = PrimeraColumnaTexto(dt, columnaId)
                        End If

                        If columnaTexto = "" Then
                            columnaTexto = columnaId
                        End If

                        Dim tabla As New DataTable()

                        tabla.Columns.Add("id_sala", GetType(Integer))
                        tabla.Columns.Add("nombre_mostrar", GetType(String))

                        For Each fila As DataRow In dt.Rows

                            If IsDBNull(fila(columnaId)) Then Continue For

                            Dim id As Integer =
                                Convert.ToInt32(fila(columnaId))

                            Dim texto As String =
                                fila(columnaTexto).ToString()

                            tabla.Rows.Add(id, texto)

                        Next

                        cboSala.DataSource = Nothing
                        cboSala.DataSource = tabla
                        cboSala.DisplayMember = "nombre_mostrar"
                        cboSala.ValueMember = "id_sala"
                        cboSala.SelectedIndex = -1

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar las salas:" &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' BUSCAR COLUMNA
    '========================================================

    Private Function BuscarColumna(
        tabla As DataTable,
        ParamArray nombres() As String
    ) As String

        For Each nombre As String In nombres

            For Each columna As DataColumn In tabla.Columns

                If columna.ColumnName.Equals(
                    nombre,
                    StringComparison.OrdinalIgnoreCase
                ) Then

                    Return columna.ColumnName

                End If

            Next

        Next

        Return ""

    End Function


    '========================================================
    ' PRIMERA COLUMNA DE TEXTO
    '========================================================

    Private Function PrimeraColumnaTexto(
        tabla As DataTable,
        columnaId As String
    ) As String

        For Each columna As DataColumn In tabla.Columns

            If columna.ColumnName.Equals(
                columnaId,
                StringComparison.OrdinalIgnoreCase
            ) Then Continue For

            If columna.DataType = GetType(String) Then
                Return columna.ColumnName
            End If

        Next

        Return ""

    End Function


    '========================================================
    ' OBTENER NOMBRE DEL INSTRUCTOR
    '========================================================

    Private Function ObtenerTextoInstructor(
        fila As DataRow,
        tabla As DataTable
    ) As String

        Dim columnaNombres As String =
            BuscarColumna(
                tabla,
                "nombres",
                "nombre"
            )

        Dim columnaApellidos As String =
            BuscarColumna(
                tabla,
                "apellidos",
                "apellido"
            )

        Dim resultado As String = ""

        If columnaNombres <> "" AndAlso
           Not IsDBNull(fila(columnaNombres)) Then

            resultado =
                fila(columnaNombres).ToString().Trim()

        End If

        If columnaApellidos <> "" AndAlso
           Not IsDBNull(fila(columnaApellidos)) Then

            If resultado <> "" Then
                resultado &= " "
            End If

            resultado &=
                fila(columnaApellidos).ToString().Trim()

        End If

        Return resultado

    End Function


    '========================================================
    ' CARGAR HORARIOS
    '========================================================

    Private Sub CargarHorarios()

        Try

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "SELECT " &
                    "h.id_horario, " &
                    "h.id_instructor, " &
                    "h.id_actividad, " &
                    "h.id_sala, " &
                    "h.dia_semana, " &
                    "h.hora_inicio, " &
                    "h.hora_fin, " &
                    "h.activo " &
                    "FROM horarios h " &
                    "WHERE h.activo = 1 " &
                    "ORDER BY h.dia_semana, h.hora_inicio"

                Using cmd As New MySqlCommand(sql, cn)

                    Using da As New MySqlDataAdapter(cmd)

                        dtHorarios.Clear()
                        da.Fill(dtHorarios)

                        dgvHorarios.DataSource = Nothing
                        dgvHorarios.DataSource = dtHorarios

                    End Using

                End Using

            End Using

            ConfigurarColumnasHorarios()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los horarios:" &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' CONFIGURAR COLUMNAS DEL DATAGRIDVIEW
    '========================================================

    Private Sub ConfigurarColumnasHorarios()

        If dgvHorarios.Columns.Count = 0 Then Return

        If dgvHorarios.Columns.Contains("id_horario") Then
            dgvHorarios.Columns("id_horario").HeaderText =
                "ID"
            dgvHorarios.Columns("id_horario").Visible = False
        End If

        If dgvHorarios.Columns.Contains("id_instructor") Then
            dgvHorarios.Columns("id_instructor").HeaderText =
                "Instructor ID"
            dgvHorarios.Columns("id_instructor").Visible = False
        End If

        If dgvHorarios.Columns.Contains("id_actividad") Then
            dgvHorarios.Columns("id_actividad").HeaderText =
                "Actividad ID"
            dgvHorarios.Columns("id_actividad").Visible = False
        End If

        If dgvHorarios.Columns.Contains("id_sala") Then
            dgvHorarios.Columns("id_sala").HeaderText =
                "Sala ID"
            dgvHorarios.Columns("id_sala").Visible = False
        End If

        If dgvHorarios.Columns.Contains("dia_semana") Then
            dgvHorarios.Columns("dia_semana").HeaderText =
                "Día"
        End If

        If dgvHorarios.Columns.Contains("hora_inicio") Then
            dgvHorarios.Columns("hora_inicio").HeaderText =
                "Hora inicio"
        End If

        If dgvHorarios.Columns.Contains("hora_fin") Then
            dgvHorarios.Columns("hora_fin").HeaderText =
                "Hora fin"
        End If

        If dgvHorarios.Columns.Contains("activo") Then
            dgvHorarios.Columns("activo").HeaderText =
                "Activo"
        End If

    End Sub


    '========================================================
    ' NUEVO
    '========================================================

    Private Sub btnNuevo_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnNuevo.Click

        modoEdicion = False
        idHorarioSeleccionado = 0

        LimpiarCampos()

        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False

        cboInstructor.Focus()

    End Sub


    '========================================================
    ' GUARDAR
    '========================================================

    Private Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnGuardar.Click

        If Not ValidarCampos() Then
            Return
        End If

        If dtpHoraFin.Value.TimeOfDay <=
           dtpHoraInicio.Value.TimeOfDay Then

            MessageBox.Show(
                "La hora de fin debe ser mayor que la hora de inicio.",
                "Horario inválido",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        If ExisteChoqueHorario() Then
            Return
        End If

        Try

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                cn.Open()

                If modoEdicion Then

                    Dim sql As String =
                        "UPDATE horarios SET " &
                        "id_instructor=@id_instructor, " &
                        "id_actividad=@id_actividad, " &
                        "id_sala=@id_sala, " &
                        "dia_semana=@dia, " &
                        "hora_inicio=@inicio, " &
                        "hora_fin=@fin " &
                        "WHERE id_horario=@id"

                    Using cmd As New MySqlCommand(sql, cn)

                        AgregarParametrosHorario(cmd)

                        cmd.Parameters.AddWithValue(
                            "@id",
                            idHorarioSeleccionado
                        )

                        cmd.ExecuteNonQuery()

                    End Using

                    MessageBox.Show(
                        "Horario actualizado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    )

                Else

                    Dim sql As String =
                        "INSERT INTO horarios " &
                        "(id_instructor, id_actividad, id_sala, " &
                        "dia_semana, hora_inicio, hora_fin, activo) " &
                        "VALUES " &
                        "(@id_instructor, @id_actividad, @id_sala, " &
                        "@dia, @inicio, @fin, 1)"

                    Using cmd As New MySqlCommand(sql, cn)

                        AgregarParametrosHorario(cmd)

                        cmd.ExecuteNonQuery()

                    End Using

                    MessageBox.Show(
                        "Horario guardado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    )

                End If

            End Using

            CargarHorarios()
            LimpiarCampos()

            modoEdicion = False
            idHorarioSeleccionado = 0

            ActualizarBotones()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo guardar el horario:" &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' PARÁMETROS DEL HORARIO
    '========================================================

    Private Sub AgregarParametrosHorario(
        cmd As MySqlCommand
    )

        cmd.Parameters.AddWithValue(
            "@id_instructor",
            Convert.ToInt32(cboInstructor.SelectedValue)
        )

        cmd.Parameters.AddWithValue(
            "@id_actividad",
            Convert.ToInt32(cboActividad.SelectedValue)
        )

        cmd.Parameters.AddWithValue(
            "@id_sala",
            Convert.ToInt32(cboSala.SelectedValue)
        )

        cmd.Parameters.AddWithValue(
            "@dia",
            cboDia.Text
        )

        cmd.Parameters.AddWithValue(
            "@inicio",
            dtpHoraInicio.Value.TimeOfDay
        )

        cmd.Parameters.AddWithValue(
            "@fin",
            dtpHoraFin.Value.TimeOfDay
        )

    End Sub


    '========================================================
    ' VALIDAR CAMPOS
    '========================================================

    Private Function ValidarCampos() As Boolean

        If cboInstructor.SelectedIndex = -1 Then

            MessageBox.Show(
                "Seleccione un instructor.",
                "Datos incompletos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            cboInstructor.Focus()
            Return False

        End If

        If cboActividad.SelectedIndex = -1 Then

            MessageBox.Show(
                "Seleccione una actividad.",
                "Datos incompletos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            cboActividad.Focus()
            Return False

        End If

        If cboSala.SelectedIndex = -1 Then

            MessageBox.Show(
                "Seleccione una sala.",
                "Datos incompletos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            cboSala.Focus()
            Return False

        End If

        If cboDia.SelectedIndex = -1 Then

            MessageBox.Show(
                "Seleccione un día.",
                "Datos incompletos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            cboDia.Focus()
            Return False

        End If

        Return True

    End Function


    '========================================================
    ' VERIFICAR CHOQUES
    '========================================================

    Private Function ExisteChoqueHorario() As Boolean

        Try

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "SELECT COUNT(*) " &
                    "FROM horarios " &
                    "WHERE activo = 1 " &
                    "AND dia_semana = @dia " &
                    "AND ( " &
                    "id_instructor = @instructor " &
                    "OR id_sala = @sala " &
                    ") " &
                    "AND hora_inicio < @fin " &
                    "AND hora_fin > @inicio "

                If modoEdicion Then
                    sql &= "AND id_horario <> @id "
                End If

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@dia",
                        cboDia.Text
                    )

                    cmd.Parameters.AddWithValue(
                        "@instructor",
                        Convert.ToInt32(cboInstructor.SelectedValue)
                    )

                    cmd.Parameters.AddWithValue(
                        "@sala",
                        Convert.ToInt32(cboSala.SelectedValue)
                    )

                    cmd.Parameters.AddWithValue(
                        "@inicio",
                        dtpHoraInicio.Value.TimeOfDay
                    )

                    cmd.Parameters.AddWithValue(
                        "@fin",
                        dtpHoraFin.Value.TimeOfDay
                    )

                    If modoEdicion Then

                        cmd.Parameters.AddWithValue(
                            "@id",
                            idHorarioSeleccionado
                        )

                    End If

                    Dim cantidad As Integer =
                        Convert.ToInt32(cmd.ExecuteScalar())

                    If cantidad > 0 Then

                        MessageBox.Show(
                            "Existe un conflicto de horario." &
                            Environment.NewLine &
                            "Revise el instructor, la sala, el día y las horas.",
                            "Conflicto de horario",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        )

                        Return True

                    End If

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo comprobar el conflicto de horario:" &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            Return True

        End Try

        Return False

    End Function


    '========================================================
    ' SELECCIONAR HORARIO
    '========================================================

    Private Sub dgvHorarios_SelectionChanged(
        sender As Object,
        e As EventArgs
    ) Handles dgvHorarios.SelectionChanged

        If dgvHorarios.CurrentRow Is Nothing Then
            Return
        End If

        If dgvHorarios.CurrentRow.Index < 0 Then
            Return
        End If

        If modoEdicion Then
            Return
        End If

        Try

            Dim fila As DataGridViewRow =
                dgvHorarios.CurrentRow

            If fila.Cells("id_horario").Value Is Nothing Then
                Return
            End If

            idHorarioSeleccionado =
                Convert.ToInt32(
                    fila.Cells("id_horario").Value
                )

            Dim idInstructor As Integer =
                Convert.ToInt32(
                    fila.Cells("id_instructor").Value
                )

            Dim idActividad As Integer =
                Convert.ToInt32(
                    fila.Cells("id_actividad").Value
                )

            Dim idSala As Integer =
                Convert.ToInt32(
                    fila.Cells("id_sala").Value
                )

            cboInstructor.SelectedValue =
                idInstructor

            cboActividad.SelectedValue =
                idActividad

            cboSala.SelectedValue =
                idSala

            cboDia.Text =
                fila.Cells("dia_semana").Value.ToString()

            If Not IsDBNull(
                fila.Cells("hora_inicio").Value
            ) Then

                dtpHoraInicio.Value =
                    Date.Today.Add(
                        CType(
                            fila.Cells("hora_inicio").Value,
                            TimeSpan
                        )
                    )

            End If

            If Not IsDBNull(
                fila.Cells("hora_fin").Value
            ) Then

                dtpHoraFin.Value =
                    Date.Today.Add(
                        CType(
                            fila.Cells("hora_fin").Value,
                            TimeSpan
                        )
                    )

            End If

            btnEditar.Enabled = True
            btnEliminar.Enabled = True

        Catch
            'Evita interrupciones durante la carga inicial.
        End Try

    End Sub


    '========================================================
    ' EDITAR
    '========================================================

    Private Sub btnEditar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnEditar.Click

        If idHorarioSeleccionado <= 0 Then

            MessageBox.Show(
                "Seleccione un horario para editar.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        modoEdicion = True

        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False

        cboInstructor.Focus()

    End Sub


    '========================================================
    ' ELIMINAR
    '========================================================

    Private Sub btnEliminar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnEliminar.Click

        If idHorarioSeleccionado <= 0 Then

            MessageBox.Show(
                "Seleccione un horario.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Dim respuesta As DialogResult =
            MessageBox.Show(
                "¿Desea desactivar este horario?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

        If respuesta <> DialogResult.Yes Then
            Return
        End If

        Try

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "UPDATE horarios " &
                    "SET activo = 0 " &
                    "WHERE id_horario = @id"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@id",
                        idHorarioSeleccionado
                    )

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show(
                "Horario eliminado correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            CargarHorarios()
            LimpiarCampos()

            idHorarioSeleccionado = 0
            ActualizarBotones()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo eliminar el horario:" &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' CANCELAR
    '========================================================

    Private Sub btnCancelar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancelar.Click

        modoEdicion = False
        idHorarioSeleccionado = 0

        LimpiarCampos()
        ActualizarBotones()

    End Sub


    '========================================================
    ' LIMPIAR CAMPOS
    '========================================================

    Private Sub LimpiarCampos()

        cboInstructor.SelectedIndex = -1
        cboActividad.SelectedIndex = -1
        cboSala.SelectedIndex = -1
        cboDia.SelectedIndex = -1

        dtpHoraInicio.Value =
            Date.Today.AddHours(8)

        dtpHoraFin.Value =
            Date.Today.AddHours(9)

        ActualizarBotones()

    End Sub


    '========================================================
    ' ACTUALIZAR BOTONES
    '========================================================

    Private Sub ActualizarBotones()

        If modoEdicion Then

            btnNuevo.Enabled = False
            btnGuardar.Enabled = True
            btnEditar.Enabled = False
            btnEliminar.Enabled = False
            btnCancelar.Enabled = True

        Else

            btnNuevo.Enabled = True
            btnGuardar.Enabled = False
            btnCancelar.Enabled = False

            If idHorarioSeleccionado > 0 Then
                btnEditar.Enabled = True
                btnEliminar.Enabled = True
            Else
                btnEditar.Enabled = False
                btnEliminar.Enabled = False
            End If

        End If

    End Sub


    '========================================================
    ' BINDING NAVIGATOR - PRIMERO
    '========================================================

    Private Sub IrPrimero()

        If dgvHorarios.Rows.Count = 0 Then Return

        dgvHorarios.ClearSelection()
        dgvHorarios.Rows(0).Selected = True

        dgvHorarios.CurrentCell =
            dgvHorarios.Rows(0).Cells(0)

    End Sub


    '========================================================
    ' BINDING NAVIGATOR - ANTERIOR
    '========================================================

    Private Sub IrAnterior()

        If dgvHorarios.CurrentRow Is Nothing Then
            Return
        End If

        Dim posicion As Integer =
            dgvHorarios.CurrentRow.Index

        If posicion > 0 Then

            dgvHorarios.ClearSelection()

            dgvHorarios.Rows(posicion - 1).Selected = True

            dgvHorarios.CurrentCell =
                dgvHorarios.Rows(posicion - 1).Cells(0)

        End If

    End Sub


    '========================================================
    ' BINDING NAVIGATOR - SIGUIENTE
    '========================================================

    Private Sub IrSiguiente()

        If dgvHorarios.CurrentRow Is Nothing Then
            Return
        End If

        Dim posicion As Integer =
            dgvHorarios.CurrentRow.Index

        If posicion <
           dgvHorarios.Rows.Count - 1 Then

            dgvHorarios.ClearSelection()

            dgvHorarios.Rows(posicion + 1).Selected = True

            dgvHorarios.CurrentCell =
                dgvHorarios.Rows(posicion + 1).Cells(0)

        End If

    End Sub


    '========================================================
    ' BINDING NAVIGATOR - ÚLTIMO
    '========================================================

    Private Sub IrUltimo()

        If dgvHorarios.Rows.Count = 0 Then Return

        Dim posicion As Integer =
            dgvHorarios.Rows.Count - 1

        dgvHorarios.ClearSelection()

        dgvHorarios.Rows(posicion).Selected = True

        dgvHorarios.CurrentCell =
            dgvHorarios.Rows(posicion).Cells(0)

    End Sub

    Private Sub lblTitulo_Click(sender As Object, e As EventArgs) Handles lblTitulo.Click

    End Sub
End Class