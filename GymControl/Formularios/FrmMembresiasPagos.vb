Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing
Imports MySqlConnector

Public Class frmMembresiasPagos

    ' ============================================================
    ' VARIABLES
    ' ============================================================

    Private dtMembresias As New DataTable()
    Private dtPagos As New DataTable()

    Private idSocioSeleccionado As Integer = 0
    Private idMembresiaSeleccionada As Integer = 0

    Private modoNuevaMembresia As Boolean = False

    ' BindingNavigator creado por código
    Private bnvMembresias As BindingNavigator


    ' ============================================================
    ' CARGAR FORMULARIO
    ' ============================================================

    Private Sub frmMembresiasPagos_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        Try

            ConfigurarFormulario()

            ConfigurarBindingNavigator()

            CargarEstados()

            CargarMetodosPago()

            CargarTiposMembresia()

            LimpiarCampos()

        Catch ex As Exception

            MessageBox.Show(
                "Ocurrió un error al cargar el formulario:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' CONFIGURAR FORMULARIO
    ' ============================================================

    Private Sub ConfigurarFormulario()

        ' --------------------------------------------------------
        ' SOCIO
        ' --------------------------------------------------------

        txtNombreSocio.ReadOnly = True


        ' --------------------------------------------------------
        ' MEMBRESÍA
        ' --------------------------------------------------------

        dtpFechaInicio.Value = Date.Today

        dtpFechaVencimiento.Value = Date.Today

        dtpFechaVencimiento.Enabled = False

        txtPrecioPactado.ReadOnly = True


        ' --------------------------------------------------------
        ' DATAGRID MEMBRESÍAS
        ' --------------------------------------------------------

        dgvMembresias.ReadOnly = True

        dgvMembresias.AllowUserToAddRows = False

        dgvMembresias.AllowUserToDeleteRows = False

        dgvMembresias.AllowUserToResizeRows = False

        dgvMembresias.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvMembresias.MultiSelect = False

        dgvMembresias.AutoGenerateColumns = True

        dgvMembresias.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        dgvMembresias.RowHeadersVisible = False


        ' --------------------------------------------------------
        ' DATAGRID PAGOS
        ' --------------------------------------------------------

        dgvPagos.ReadOnly = True

        dgvPagos.AllowUserToAddRows = False

        dgvPagos.AllowUserToDeleteRows = False

        dgvPagos.AllowUserToResizeRows = False

        dgvPagos.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvPagos.MultiSelect = False

        dgvPagos.AutoGenerateColumns = True

        dgvPagos.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        dgvPagos.RowHeadersVisible = False


        ' --------------------------------------------------------
        ' BOTONES
        ' --------------------------------------------------------

        btnGuardarMembresia.Enabled = False

        btnCancelarMembresia.Enabled = False

        btnRegistrarPago.Enabled = False


        ' --------------------------------------------------------
        ' TOTALES
        ' --------------------------------------------------------

        lblTotal.Text = "Total: C$0.00"

        lblPagado.Text = "Pagado: C$0.00"

        lblSaldo.Text = "Saldo: C$0.00"

    End Sub


    ' ============================================================
    ' BINDING NAVIGATOR
    ' ============================================================

    Private Sub ConfigurarBindingNavigator()

        bnvMembresias =
            New BindingNavigator(False)

        With bnvMembresias

            .Name = "bnvMembresias"

            .Dock = DockStyle.Bottom

            .GripStyle =
                ToolStripGripStyle.Hidden

            .AutoSize = True

            .Visible = True

        End With


        Dim btnPrimero As New ToolStripButton("<<")

        Dim btnAnterior As New ToolStripButton("<")

        Dim btnSiguiente As New ToolStripButton(">")

        Dim btnUltimo As New ToolStripButton(">>")


        btnPrimero.Name = "btnNavPrimero"

        btnAnterior.Name = "btnNavAnterior"

        btnSiguiente.Name = "btnNavSiguiente"

        btnUltimo.Name = "btnNavUltimo"


        Dim separador As New ToolStripSeparator()


        Dim lblRegistro As New ToolStripLabel("Membresía:")


        Dim txtPosicion As New ToolStripTextBox()

        txtPosicion.Name =
            "txtNavPosicion"

        txtPosicion.Width = 55

        txtPosicion.ReadOnly = True

        txtPosicion.TextBoxTextAlign =
            HorizontalAlignment.Center


        bnvMembresias.Items.Add(btnPrimero)

        bnvMembresias.Items.Add(btnAnterior)

        bnvMembresias.Items.Add(lblRegistro)

        bnvMembresias.Items.Add(txtPosicion)

        bnvMembresias.Items.Add(btnSiguiente)

        bnvMembresias.Items.Add(btnUltimo)

        bnvMembresias.Items.Add(separador)


        Me.Controls.Add(bnvMembresias)


        AddHandler btnPrimero.Click,
            AddressOf NavegarPrimero

        AddHandler btnAnterior.Click,
            AddressOf NavegarAnterior

        AddHandler btnSiguiente.Click,
            AddressOf NavegarSiguiente

        AddHandler btnUltimo.Click,
            AddressOf NavegarUltimo

    End Sub


    ' ============================================================
    ' CARGAR ESTADOS
    ' ============================================================

    Private Sub CargarEstados()

        cboEstadoMembresia.Items.Clear()

        cboEstadoMembresia.Items.Add("Activa")

        cboEstadoMembresia.Items.Add("Vencida")

        cboEstadoMembresia.Items.Add("Suspendida")

        cboEstadoMembresia.Items.Add("Cancelada")

        cboEstadoMembresia.SelectedIndex = 0

    End Sub


    ' ============================================================
    ' CARGAR MÉTODOS DE PAGO
    ' ============================================================

    Private Sub CargarMetodosPago()

        cboMetodoPago.Items.Clear()

        cboMetodoPago.Items.Add("Efectivo")

        cboMetodoPago.Items.Add("Tarjeta")

        cboMetodoPago.Items.Add("Transferencia")

        cboMetodoPago.SelectedIndex = 0

    End Sub


    ' ============================================================
    ' CARGAR TIPOS DE MEMBRESÍA
    ' ============================================================

    Private Sub CargarTiposMembresia()

        Try

            cboTipoMembresia.Items.Clear()

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "SELECT * FROM tipos_membresia ORDER BY 1"

                Using cmd As New MySqlCommand(sql, cn)

                    Using da As New MySqlDataAdapter(cmd)

                        Dim dt As New DataTable()

                        da.Fill(dt)

                        cboTipoMembresia.DisplayMember = "nombre"

                        cboTipoMembresia.ValueMember = "id_tipo"

                        cboTipoMembresia.DataSource = dt

                    End Using

                End Using

            End Using

            cboTipoMembresia.SelectedIndex = -1

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los tipos de membresía:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' BUSCAR SOCIO
    ' ============================================================

    Private Sub btnBuscarSocio_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBuscarSocio.Click

        Try

            If String.IsNullOrWhiteSpace(txtCedula.Text) Then

                MessageBox.Show(
                    "Ingrese la cédula del socio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                txtCedula.Focus()

                Return

            End If


            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()


                Dim sql As String =
                    "SELECT id_socio, nombres, apellidos " &
                    "FROM socios " &
                    "WHERE cedula = @cedula " &
                    "AND activo = 1 " &
                    "LIMIT 1"


                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@cedula",
                        txtCedula.Text.Trim()
                    )


                    Using rd As MySqlDataReader =
                        cmd.ExecuteReader()

                        If rd.Read() Then

                            idSocioSeleccionado =
                                Convert.ToInt32(
                                    rd("id_socio")
                                )


                            txtNombreSocio.Text =
                                rd("nombres").ToString() &
                                " " &
                                rd("apellidos").ToString()


                            CargarMembresias()

                            MessageBox.Show(
                                "Socio encontrado correctamente.",
                                "Socio encontrado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            )

                        Else

                            idSocioSeleccionado = 0

                            txtNombreSocio.Clear()

                            dgvMembresias.DataSource = Nothing

                            dgvPagos.DataSource = Nothing

                            LimpiarTotales()


                            MessageBox.Show(
                                "No se encontró un socio activo con esa cédula.",
                                "Socio no encontrado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            )

                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo buscar el socio:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' NUEVA MEMBRESÍA
    ' ============================================================

    Private Sub btnNuevaMembresia_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnNuevaMembresia.Click

        If idSocioSeleccionado = 0 Then

            MessageBox.Show(
                "Primero debe buscar y seleccionar un socio.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtCedula.Focus()

            Return

        End If


        modoNuevaMembresia = True

        LimpiarDatosMembresia()


        dtpFechaInicio.Value =
            Date.Today


        cboEstadoMembresia.SelectedIndex = 0


        btnNuevaMembresia.Enabled = False

        btnGuardarMembresia.Enabled = True

        btnCancelarMembresia.Enabled = True


        cboTipoMembresia.Enabled = True

        dtpFechaInicio.Enabled = True


        lblTotal.Text = "Total: C$0.00"

        lblPagado.Text = "Pagado: C$0.00"

        lblSaldo.Text = "Saldo: C$0.00"


        cboTipoMembresia.Focus()

    End Sub


    ' ============================================================
    ' CAMBIO DE TIPO DE MEMBRESÍA
    ' ============================================================

    Private Sub cboTipoMembresia_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cboTipoMembresia.SelectedIndexChanged

        Try

            If cboTipoMembresia.SelectedIndex = -1 Then

                Return

            End If


            If cboTipoMembresia.SelectedValue Is Nothing Then

                Return

            End If


            Dim idTipo As Integer

            If Not Integer.TryParse(
                cboTipoMembresia.SelectedValue.ToString(),
                idTipo
            ) Then

                Return

            End If


            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()


                Dim sql As String =
                    "SELECT * " &
                    "FROM tipos_membresia " &
                    "WHERE id_tipo = @id_tipo"


                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@id_tipo",
                        idTipo
                    )


                    Using rd As MySqlDataReader =
                        cmd.ExecuteReader()

                        If rd.Read() Then

                            ' ------------------------------------------------
                            ' IMPORTANTE:
                            ' Aquí usamos las columnas habituales:
                            ' precio y duracion_dias.
                            ' ------------------------------------------------

                            If rd.GetSchemaTable() IsNot Nothing Then

                                If ExisteColumna(
                                    rd,
                                    "precio"
                                ) Then

                                    txtPrecioPactado.Text =
                                        Convert.ToDecimal(
                                            rd("precio")
                                        ).ToString("0.00")

                                ElseIf ExisteColumna(
                                    rd,
                                    "precio_mensual"
                                ) Then

                                    txtPrecioPactado.Text =
                                        Convert.ToDecimal(
                                            rd("precio_mensual")
                                        ).ToString("0.00")

                                End If


                                Dim duracion As Integer = 30


                                If ExisteColumna(
                                    rd,
                                    "duracion_dias"
                                ) Then

                                    duracion =
                                        Convert.ToInt32(
                                            rd("duracion_dias")
                                        )

                                ElseIf ExisteColumna(
                                    rd,
                                    "duracion"
                                ) Then

                                    duracion =
                                        Convert.ToInt32(
                                            rd("duracion")
                                        )

                                End If


                                dtpFechaVencimiento.Value =
                                    dtpFechaInicio.Value.Date.AddDays(
                                        duracion
                                    )

                            End If

                        End If

                    End Using

                End Using

            End Using


        Catch ex As Exception

            MessageBox.Show(
                "No se pudo cargar la información del tipo de membresía:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' CAMBIO FECHA INICIO
    ' ============================================================

    Private Sub dtpFechaInicio_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles dtpFechaInicio.ValueChanged

        If cboTipoMembresia.SelectedIndex = -1 Then

            Return

        End If


        Try

            Dim idTipo As Integer

            If Not Integer.TryParse(
                cboTipoMembresia.SelectedValue.ToString(),
                idTipo
            ) Then

                Return

            End If


            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()


                Dim sql As String =
                    "SELECT * FROM tipos_membresia " &
                    "WHERE id_tipo = @id"


                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@id",
                        idTipo
                    )


                    Using rd As MySqlDataReader =
                        cmd.ExecuteReader()

                        If rd.Read() Then

                            Dim duracion As Integer = 30


                            If ExisteColumna(
                                rd,
                                "duracion_dias"
                            ) Then

                                duracion =
                                    Convert.ToInt32(
                                        rd("duracion_dias")
                                    )

                            ElseIf ExisteColumna(
                                rd,
                                "duracion"
                            ) Then

                                duracion =
                                    Convert.ToInt32(
                                        rd("duracion")
                                    )

                            End If


                            dtpFechaVencimiento.Value =
                                dtpFechaInicio.Value.Date.AddDays(
                                    duracion
                                )

                        End If

                    End Using

                End Using

            End Using

        Catch
            ' Se evita mostrar mensajes cada vez que cambia la fecha.
        End Try

    End Sub


    ' ============================================================
    ' COMPROBAR SI EXISTE COLUMNA
    ' ============================================================

    Private Function ExisteColumna(
        rd As MySqlDataReader,
        nombre As String
    ) As Boolean

        For i As Integer = 0 To rd.FieldCount - 1

            If String.Equals(
                rd.GetName(i),
                nombre,
                StringComparison.OrdinalIgnoreCase
            ) Then

                Return True

            End If

        Next

        Return False

    End Function


    ' ============================================================
    ' GUARDAR MEMBRESÍA
    ' ============================================================

    Private Sub btnGuardarMembresia_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnGuardarMembresia.Click

        Try

            If idSocioSeleccionado = 0 Then

                MessageBox.Show(
                    "Debe seleccionar un socio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            If cboTipoMembresia.SelectedIndex = -1 Then

                MessageBox.Show(
                    "Seleccione el tipo de membresía.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                cboTipoMembresia.Focus()

                Return

            End If


            Dim precio As Decimal


            If Not Decimal.TryParse(
                txtPrecioPactado.Text,
                precio
            ) Then

                MessageBox.Show(
                    "El precio de la membresía no es válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            Dim idTipo As Integer =
                Convert.ToInt32(
                    cboTipoMembresia.SelectedValue
                )


            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()


                Dim sql As String =
                    "INSERT INTO membresias " &
                    "(id_socio, id_tipo, fecha_inicio, " &
                    "fecha_vencimiento, precio_pactado, estado) " &
                    "VALUES " &
                    "(@id_socio, @id_tipo, @fecha_inicio, " &
                    "@fecha_vencimiento, @precio, @estado)"


                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@id_socio",
                        idSocioSeleccionado
                    )

                    cmd.Parameters.AddWithValue(
                        "@id_tipo",
                        idTipo
                    )

                    cmd.Parameters.AddWithValue(
                        "@fecha_inicio",
                        dtpFechaInicio.Value.Date
                    )

                    cmd.Parameters.AddWithValue(
                        "@fecha_vencimiento",
                        dtpFechaVencimiento.Value.Date
                    )

                    cmd.Parameters.AddWithValue(
                        "@precio",
                        precio
                    )

                    cmd.Parameters.AddWithValue(
                        "@estado",
                        cboEstadoMembresia.Text
                    )


                    cmd.ExecuteNonQuery()

                End Using

            End Using


            MessageBox.Show(
                "La membresía se registró correctamente.",
                "Registro exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )


            modoNuevaMembresia = False


            btnNuevaMembresia.Enabled = True

            btnGuardarMembresia.Enabled = False

            btnCancelarMembresia.Enabled = False


            CargarMembresias()


        Catch ex As Exception

            MessageBox.Show(
                "No se pudo guardar la membresía:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' CARGAR MEMBRESÍAS DEL SOCIO
    ' ============================================================

    Private Sub CargarMembresias()

        Try

            If idSocioSeleccionado = 0 Then

                Return

            End If


            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()


                Dim sql As String =
                    "SELECT " &
                    "m.id_membresia, " &
                    "m.id_socio, " &
                    "m.id_tipo, " &
                    "tm.nombre AS tipo_membresia, " &
                    "m.fecha_inicio, " &
                    "m.fecha_vencimiento, " &
                    "m.precio_pactado, " &
                    "m.estado " &
                    "FROM membresias m " &
                    "INNER JOIN tipos_membresia tm " &
                    "ON m.id_tipo = tm.id_tipo " &
                    "WHERE m.id_socio = @id_socio " &
                    "ORDER BY m.fecha_inicio DESC"


                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@id_socio",
                        idSocioSeleccionado
                    )


                    Using da As New MySqlDataAdapter(cmd)

                        dtMembresias = New DataTable()

                        da.Fill(dtMembresias)

                    End Using

                End Using

            End Using


            dgvMembresias.DataSource =
                dtMembresias


            ConfigurarColumnasMembresias()


            If dtMembresias.Rows.Count > 0 Then

                dgvMembresias.Rows(0).Selected = True

                SeleccionarMembresia(
                    dgvMembresias.Rows(0)
                )

            Else

                idMembresiaSeleccionada = 0

                dgvPagos.DataSource = Nothing

                LimpiarTotales()

            End If


        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar las membresías:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' CONFIGURAR COLUMNAS MEMBRESÍAS
    ' ============================================================

    Private Sub ConfigurarColumnasMembresias()

        If dgvMembresias.Columns.Count = 0 Then

            Return

        End If


        If dgvMembresias.Columns.Contains(
            "id_membresia"
        ) Then

            dgvMembresias.Columns(
                "id_membresia"
            ).HeaderText = "ID"

        End If


        If dgvMembresias.Columns.Contains(
            "id_socio"
        ) Then

            dgvMembresias.Columns(
                "id_socio"
            ).Visible = False

        End If


        If dgvMembresias.Columns.Contains(
            "id_tipo"
        ) Then

            dgvMembresias.Columns(
                "id_tipo"
            ).Visible = False

        End If


        If dgvMembresias.Columns.Contains(
            "tipo_membresia"
        ) Then

            dgvMembresias.Columns(
                "tipo_membresia"
            ).HeaderText = "Tipo"

        End If


        If dgvMembresias.Columns.Contains(
            "fecha_inicio"
        ) Then

            dgvMembresias.Columns(
                "fecha_inicio"
            ).HeaderText = "Inicio"

            dgvMembresias.Columns(
                "fecha_inicio"
            ).DefaultCellStyle.Format =
                "dd/MM/yyyy"

        End If


        If dgvMembresias.Columns.Contains(
            "fecha_vencimiento"
        ) Then

            dgvMembresias.Columns(
                "fecha_vencimiento"
            ).HeaderText = "Vencimiento"

            dgvMembresias.Columns(
                "fecha_vencimiento"
            ).DefaultCellStyle.Format =
                "dd/MM/yyyy"

        End If


        If dgvMembresias.Columns.Contains(
            "precio_pactado"
        ) Then

            dgvMembresias.Columns(
                "precio_pactado"
            ).HeaderText = "Precio"

            dgvMembresias.Columns(
                "precio_pactado"
            ).DefaultCellStyle.Format =
                "C2"

        End If


        If dgvMembresias.Columns.Contains(
            "estado"
        ) Then

            dgvMembresias.Columns(
                "estado"
            ).HeaderText = "Estado"

        End If

    End Sub


    ' ============================================================
    ' SELECCIONAR MEMBRESÍA
    ' ============================================================

    Private Sub dgvMembresias_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMembresias.SelectionChanged

        If dgvMembresias.CurrentRow IsNot Nothing Then
            Try
                ' Usamos .Trim y .ToUpper para evitar fallos por mayúsculas o espacios extras
                Dim estadoMembresia As String = dgvMembresias.CurrentRow.Cells("estado").Value.ToString().Trim().ToUpper()

                If estadoMembresia = "ACTIVA" Then
                    btnConstancia.Enabled = True
                Else
                    btnConstancia.Enabled = False
                End If
            Catch ex As Exception
                btnConstancia.Enabled = False
            End Try
        End If
    End Sub




    Private Sub SeleccionarMembresia(
        fila As DataGridViewRow
    )

        Try

            If fila Is Nothing Then

                Return

            End If


            If fila.Cells(
                "id_membresia"
            ).Value Is Nothing Then

                Return

            End If


            idMembresiaSeleccionada =
                Convert.ToInt32(
                    fila.Cells(
                        "id_membresia"
                    ).Value
                )


            If dgvMembresias.Columns.Contains(
                "precio_pactado"
            ) Then

                Dim precio As Decimal =
                    Convert.ToDecimal(
                        fila.Cells(
                            "precio_pactado"
                        ).Value
                    )


                lblTotal.Text =
                    "Total: " &
                    precio.ToString("C2")

            End If


            CargarPagos()

            btnRegistrarPago.Enabled = True


        Catch ex As Exception

            MessageBox.Show(
                "No se pudo seleccionar la membresía:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' REGISTRAR PAGO
    ' ============================================================

    Private Sub btnRegistrarPago_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRegistrarPago.Click

        Try

            If idMembresiaSeleccionada = 0 Then

                MessageBox.Show(
                    "Seleccione una membresía.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            Dim monto As Decimal


            If Not Decimal.TryParse(
                txtMonto.Text.Trim(),
                monto
            ) OrElse monto <= 0 Then

                MessageBox.Show(
                    "Ingrese un monto de pago válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                txtMonto.Focus()

                Return

            End If


            If cboMetodoPago.SelectedIndex = -1 Then

                MessageBox.Show(
                    "Seleccione el método de pago.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                cboMetodoPago.Focus()

                Return

            End If


            Dim idUsuario As Integer = Sesion.UsuarioId


            If idUsuario = 0 Then

                MessageBox.Show(
                   "No se pudo identificar al usuario que registra el pago." &
                   Environment.NewLine &
                   "Verifique que haya iniciado sesión correctamente en el sistema.",
                   "Error de Sesión",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
               )

                Return

            End If

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()


                Dim sql As String =
                    "INSERT INTO pagos " &
                    "(id_membresia, id_usuario_registro, " &
                    "monto, metodo_pago, referencia, " &
                    "observacion, fecha_pago, anulado) " &
                    "VALUES " &
                    "(@id_membresia, @id_usuario, @monto, " &
                    "@metodo, @referencia, @observacion, " &
                    "NOW(), 0)"


                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@id_membresia",
                        idMembresiaSeleccionada
                    )

                    cmd.Parameters.AddWithValue(
                        "@id_usuario",
                        idUsuario
                    )

                    cmd.Parameters.AddWithValue(
                        "@monto",
                        monto
                    )

                    cmd.Parameters.AddWithValue(
                        "@metodo",
                        cboMetodoPago.Text
                    )

                    cmd.Parameters.AddWithValue(
                        "@referencia",
                        txtReferencia.Text.Trim()
                    )

                    cmd.Parameters.AddWithValue(
                        "@observacion",
                        txtObservacion.Text.Trim()
                    )


                    cmd.ExecuteNonQuery()

                End Using

            End Using


            MessageBox.Show(
                "El pago se registró correctamente.",
                "Pago registrado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )


            LimpiarDatosPago()

            CargarPagos()

            If chkImprimirAlRegistrar.Checked Then

                Dim tamañoTicket As New Printing.PaperSize("Ticket80mm", 315, 600)
                pdRecibo.DefaultPageSettings.PaperSize = tamañoTicket
                pdRecibo.DefaultPageSettings.Margins = New Printing.Margins(10, 10, 10, 10)

                pdRecibo.Print()
            End If

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo registrar el pago:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' CARGAR PAGOS
    ' ============================================================

    Private Sub CargarPagos()

        Try

            If idMembresiaSeleccionada = 0 Then

                Return

            End If


            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()


                Dim sql As String =
                    "SELECT " &
                    "id_pago, " &
                    "id_membresia, " &
                    "id_usuario_registro, " &
                    "monto, " &
                    "metodo_pago, " &
                    "referencia, " &
                    "observacion, " &
                    "fecha_pago, " &
                    "anulado " &
                    "FROM pagos " &
                    "WHERE id_membresia = @id " &
                    "ORDER BY fecha_pago DESC"


                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@id",
                        idMembresiaSeleccionada
                    )


                    Using da As New MySqlDataAdapter(cmd)

                        dtPagos = New DataTable()

                        da.Fill(dtPagos)

                    End Using

                End Using

            End Using


            dgvPagos.DataSource = dtPagos


            ConfigurarColumnasPagos()

            CalcularTotales()


        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los pagos:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' CONFIGURAR COLUMNAS PAGOS
    ' ============================================================

    Private Sub ConfigurarColumnasPagos()

        If dgvPagos.Columns.Count = 0 Then

            Return

        End If


        If dgvPagos.Columns.Contains(
            "id_pago"
        ) Then

            dgvPagos.Columns(
                "id_pago"
            ).HeaderText = "ID"

        End If


        If dgvPagos.Columns.Contains(
            "id_membresia"
        ) Then

            dgvPagos.Columns(
                "id_membresia"
            ).Visible = False

        End If


        If dgvPagos.Columns.Contains(
            "id_usuario_registro"
        ) Then

            dgvPagos.Columns(
                "id_usuario_registro"
            ).Visible = False

        End If


        If dgvPagos.Columns.Contains(
            "monto"
        ) Then

            dgvPagos.Columns(
                "monto"
            ).HeaderText = "Monto"

            dgvPagos.Columns(
                "monto"
            ).DefaultCellStyle.Format =
                "C2"

        End If


        If dgvPagos.Columns.Contains(
            "metodo_pago"
        ) Then

            dgvPagos.Columns(
                "metodo_pago"
            ).HeaderText = "Método"

        End If


        If dgvPagos.Columns.Contains(
            "referencia"
        ) Then

            dgvPagos.Columns(
                "referencia"
            ).HeaderText = "Referencia"

        End If


        If dgvPagos.Columns.Contains(
            "observacion"
        ) Then

            dgvPagos.Columns(
                "observacion"
            ).HeaderText = "Observación"

        End If


        If dgvPagos.Columns.Contains(
            "fecha_pago"
        ) Then

            dgvPagos.Columns(
                "fecha_pago"
            ).HeaderText = "Fecha"

            dgvPagos.Columns(
                "fecha_pago"
            ).DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm"

        End If


        If dgvPagos.Columns.Contains(
            "anulado"
        ) Then

            dgvPagos.Columns(
                "anulado"
            ).HeaderText = "Anulado"

        End If

    End Sub


    ' ============================================================
    ' CALCULAR TOTALES
    ' ============================================================

    Private Sub CalcularTotales()

        Try

            Dim total As Decimal = 0

            Dim pagado As Decimal = 0


            If dgvMembresias.CurrentRow IsNot Nothing Then

                If dgvMembresias.Columns.Contains(
                    "precio_pactado"
                ) Then

                    If dgvMembresias.CurrentRow.Cells(
                        "precio_pactado"
                    ).Value IsNot Nothing Then

                        total =
                            Convert.ToDecimal(
                                dgvMembresias.CurrentRow.Cells(
                                    "precio_pactado"
                                ).Value
                            )

                    End If

                End If

            End If


            For Each fila As DataGridViewRow
                In dgvPagos.Rows

                If fila.IsNewRow Then

                    Continue For

                End If


                Dim anulado As Boolean = False


                If fila.Cells(
                    "anulado"
                ).Value IsNot Nothing AndAlso
                   Not IsDBNull(
                       fila.Cells("anulado").Value
                   ) Then

                    anulado =
                        Convert.ToBoolean(
                            fila.Cells("anulado").Value
                        )

                End If


                If Not anulado Then

                    If fila.Cells(
                        "monto"
                    ).Value IsNot Nothing Then

                        pagado +=
                            Convert.ToDecimal(
                                fila.Cells(
                                    "monto"
                                ).Value
                            )

                    End If

                End If

            Next


            Dim saldo As Decimal =
                total - pagado


            If saldo < 0 Then

                saldo = 0

            End If


            lblTotal.Text =
                "Total: " &
                total.ToString("C2")


            lblPagado.Text =
                "Pagado: " &
                pagado.ToString("C2")


            lblSaldo.Text =
                "Saldo: " &
                saldo.ToString("C2")


        Catch ex As Exception

            lblTotal.Text = "Total: C$0.00"

            lblPagado.Text = "Pagado: C$0.00"

            lblSaldo.Text = "Saldo: C$0.00"

        End Try

    End Sub


    ' ============================================================
    ' CANCELAR NUEVA MEMBRESÍA
    ' ============================================================

    Private Sub btnCancelarMembresia_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancelarMembresia.Click

        modoNuevaMembresia = False


        LimpiarDatosMembresia()


        btnNuevaMembresia.Enabled = True

        btnGuardarMembresia.Enabled = False

        btnCancelarMembresia.Enabled = False

    End Sub


    ' ============================================================
    ' LIMPIAR DATOS MEMBRESÍA
    ' ============================================================

    Private Sub LimpiarDatosMembresia()

        cboTipoMembresia.SelectedIndex = -1

        dtpFechaInicio.Value = Date.Today

        dtpFechaVencimiento.Value = Date.Today

        txtPrecioPactado.Clear()

        cboEstadoMembresia.SelectedIndex = 0

    End Sub


    ' ============================================================
    ' LIMPIAR DATOS PAGO
    ' ============================================================

    Private Sub LimpiarDatosPago()

        txtMonto.Clear()

        txtReferencia.Clear()

        txtObservacion.Clear()

        cboMetodoPago.SelectedIndex = 0

    End Sub


    ' ============================================================
    ' LIMPIAR CAMPOS
    ' ============================================================

    Private Sub LimpiarCampos()

        idSocioSeleccionado = 0

        idMembresiaSeleccionada = 0

        modoNuevaMembresia = False


        txtCedula.Clear()

        txtNombreSocio.Clear()


        LimpiarDatosMembresia()

        LimpiarDatosPago()


        dgvMembresias.DataSource = Nothing

        dgvPagos.DataSource = Nothing


        LimpiarTotales()


        btnNuevaMembresia.Enabled = True

        btnGuardarMembresia.Enabled = False

        btnCancelarMembresia.Enabled = False

        btnRegistrarPago.Enabled = False

    End Sub


    ' ============================================================
    ' LIMPIAR TOTALES
    ' ============================================================

    Private Sub LimpiarTotales()

        lblTotal.Text = "Total: C$0.00"

        lblPagado.Text = "Pagado: C$0.00"

        lblSaldo.Text = "Saldo: C$0.00"

    End Sub


    ' ============================================================
    ' NAVEGACIÓN
    ' ============================================================

    Private Sub NavegarPrimero(
        sender As Object,
        e As EventArgs
    )

        If dgvMembresias.Rows.Count = 0 Then

            Return

        End If


        dgvMembresias.ClearSelection()

        dgvMembresias.Rows(0).Selected = True

        dgvMembresias.CurrentCell =
            dgvMembresias.Rows(0).Cells(0)

    End Sub


    Private Sub NavegarAnterior(
        sender As Object,
        e As EventArgs
    )

        If dgvMembresias.CurrentRow Is Nothing Then

            Return

        End If


        Dim indice As Integer =
            dgvMembresias.CurrentRow.Index


        If indice > 0 Then

            dgvMembresias.ClearSelection()

            dgvMembresias.Rows(indice - 1).Selected = True

            dgvMembresias.CurrentCell =
                dgvMembresias.Rows(indice - 1).Cells(0)

        End If

    End Sub


    Private Sub NavegarSiguiente(
        sender As Object,
        e As EventArgs
    )

        If dgvMembresias.CurrentRow Is Nothing Then

            Return

        End If


        Dim indice As Integer =
            dgvMembresias.CurrentRow.Index


        If indice <
           dgvMembresias.Rows.Count - 1 Then

            dgvMembresias.ClearSelection()

            dgvMembresias.Rows(indice + 1).Selected = True

            dgvMembresias.CurrentCell =
                dgvMembresias.Rows(indice + 1).Cells(0)

        End If

    End Sub


    Private Sub NavegarUltimo(
        sender As Object,
        e As EventArgs
    )

        If dgvMembresias.Rows.Count = 0 Then

            Return

        End If


        Dim indice As Integer =
            dgvMembresias.Rows.Count - 1


        dgvMembresias.ClearSelection()

        dgvMembresias.Rows(indice).Selected = True

        dgvMembresias.CurrentCell =
            dgvMembresias.Rows(indice).Cells(0)

    End Sub

    Private Sub dgvPagos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPagos.SelectionChanged
        btnImprimirRecibo.Enabled = (dgvPagos.SelectedRows.Count > 0)
    End Sub

    Private Sub btnConstancia_Click(sender As Object, e As EventArgs) Handles btnConstancia.Click
        If dgvMembresias.CurrentRow IsNot Nothing Then
            ' CONFIGURACIÓN PARA HOJA TAMAÑO CARTA (LETTER)
            For Each tipoPapel As Printing.PaperSize In pdConstancia.PrinterSettings.PaperSizes
                If tipoPapel.Kind = Printing.PaperKind.Letter Then
                    pdConstancia.DefaultPageSettings.PaperSize = tipoPapel
                    Exit For
                End If
            Next

            ' Forzar márgenes estándar de oficina (1 pulgada = 100 centésimas)
            pdConstancia.DefaultPageSettings.Margins = New Printing.Margins(100, 100, 100, 100)

            ' Enlazar el documento de la constancia membretada
            ppdVista.Document = pdConstancia

            ' Forzar a que abra maximizado en pantalla completa
            CType(ppdVista, Form).WindowState = FormWindowState.Maximized

            ' Mostrar la vista previa
            ppdVista.ShowDialog()
        Else
            MessageBox.Show("Por favor, seleccione una membresía del historial superior.", "GymControl", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    ' DIBUJO MANUAL DEL REPORTE R02 (CONSTANCIA EN HOJA CARTA)
    Private Sub pdConstancia_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pdConstancia.PrintPage
        Dim g As Graphics = e.Graphics
        Dim y As Single = 120
        Dim anchoUtil As Single = 650

        Using fuenteTitulo As New Font("Arial", 18, FontStyle.Bold),
              fuenteSubtitulo As New Font("Arial", 13, FontStyle.Bold),
              fuenteCuerpo As New Font("Arial", 12, FontStyle.Regular),
              formatoCentro As New StringFormat() With {.Alignment = StringAlignment.Center}

            ' 1. Dibujar Encabezado Institucional (Hoja Membretada)
            g.DrawString("GIMNASIO TITÁN", fuenteTitulo, Brushes.Black, New RectangleF(100, y, anchoUtil, 30), formatoCentro)
            y += 35
            g.DrawString("CONSTANCIA DE MEMBRESÍA", fuenteSubtitulo, Brushes.Black, New RectangleF(100, y, anchoUtil, 25), formatoCentro)
            y += 80

            ' 2. Extracción y validación de datos de la tabla superior de membresías
            If dgvMembresias.CurrentRow IsNot Nothing Then
                Dim nombreSocio As String = txtNombreSocio.Text.Trim()

                Dim fechaInicio As DateTime = Convert.ToDateTime(dgvMembresias.CurrentRow.Cells("fecha_inicio").Value)
                Dim fechaVence As DateTime = Convert.ToDateTime(dgvMembresias.CurrentRow.Cells("fecha_vencimiento").Value)
                Dim estadoPlan As String = dgvMembresias.CurrentRow.Cells("estado").Value.ToString().Trim().ToUpper()

                ' Redacción del texto formal dinámico
                Dim textoConstancia As String =
                    $"Por medio de la presente, la administración del GIMNASIO TITÁN hace constar que el/la usuario(a) " &
                    $"{nombreSocio.ToUpper()}, se encuentra debidamente registrado(a) bajo una membresía con estado actual '{estadoPlan}' " &
                    $"en nuestro sistema de gestión.{Environment.NewLine}{Environment.NewLine}" &
                    $"Dicho plan cuenta con una vigencia oficial que dio inicio el {fechaInicio:dd 'de' MMMM 'del' yyyy} " &
                    $"y finalizará el próximo {fechaVence:dd 'de' MMMM 'del' yyyy}, gozando de pleno derecho de uso de nuestras salas " &
                    $"de musculación y áreas de entrenamiento.{Environment.NewLine}{Environment.NewLine}" &
                    $"Se extiende la presente a solicitud del interesado para los fines que estime convenientes, en la ciudad de Estelí, " &
                    $"Nicaragua, el {DateTime.Today:dd 'de' MMMM 'del' yyyy}."

                Dim rectCuerpo As New RectangleF(100, y, anchoUtil, 350)
                g.DrawString(textoConstancia, fuenteCuerpo, Brushes.Black, rectCuerpo)
                y += 280

                ' 3. Sección de Firma
                g.DrawString("___________________________", fuenteCuerpo, Brushes.Black, New RectangleF(100, y, anchoUtil, 20), formatoCentro)
                y += 25
                g.DrawString("Administración Gimnasio Titán", fuenteCuerpo, Brushes.Black, New RectangleF(100, y, anchoUtil, 20), formatoCentro)
            Else
                g.DrawString("Error: No hay datos de membresía disponibles para graficar.", fuenteCuerpo, Brushes.Red, 100, y)
            End If

            e.HasMorePages = False
        End Using
    End Sub


    Private Sub btnImprimirRecibo_Click(sender As Object, e As EventArgs) Handles btnImprimirRecibo.Click
        If dgvPagos.CurrentRow IsNot Nothing Then
            ' CONFIGURACIÓN PARA TICKET DE 80MM
            Dim tamanoTicket As New Printing.PaperSize("Ticket80mm", 315, 600)
            pdRecibo.DefaultPageSettings.PaperSize = tamanoTicket
            pdRecibo.DefaultPageSettings.Margins = New Printing.Margins(10, 10, 10, 10)

            ' Enlazar y abrir visor
            ppdVista.Document = pdRecibo
            CType(ppdVista, Form).WindowState = FormWindowState.Maximized
            ppdVista.ShowDialog()
        End If
    End Sub


    ' DIBUJO REPORTE R01 (TICKET DE 80MM)

    Private Sub pdRecibo_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pdRecibo.PrintPage

        Dim g As Graphics = e.Graphics
        Dim anchoTicket As Integer = 315 ' 80mm en centésimas de pulgada
        Dim y As Single = 15

        Using fuenteTitulo As New Font("Consolas", 12, FontStyle.Bold),
              fuenteRegular As New Font("Consolas", 9, FontStyle.Regular),
              formatoCentro As New StringFormat() With {.Alignment = StringAlignment.Center},
              formatoDerecha As New StringFormat() With {.Alignment = StringAlignment.Far}

            ' DIBUJAR LOGO CORPORATIVO 
            Dim imagenLogo As Image = Nothing

            Try

                Dim rutaLogo As String = IO.Path.Combine(Application.StartupPath, "..", "..", "Recursos", "Logo.png")

                If IO.File.Exists(rutaLogo) Then
                    imagenLogo = Image.FromFile(rutaLogo)
                Else

                    rutaLogo = IO.Path.Combine(Application.StartupPath, "Recursos", "Logo.png")
                    If IO.File.Exists(rutaLogo) Then imagenLogo = Image.FromFile(rutaLogo)
                End If
            Catch ex As Exception
                imagenLogo = Nothing
            End Try

            If imagenLogo IsNot Nothing Then
                g.DrawImage(imagenLogo, New Rectangle(132, CInt(y), 50, 50))
                y += 55
            End If


            ' --- ENCABEZADO ---
            g.DrawString("GIMNASIO TITÁN", fuenteTitulo, Brushes.Black, New RectangleF(0, y, anchoTicket, 20), formatoCentro)
            y += 20
            g.DrawString("Recibo de pago", fuenteRegular, Brushes.Black, New RectangleF(0, y, anchoTicket, 16), formatoCentro)
            y += 20

            g.DrawString("--------------------------------------------------", fuenteRegular, Brushes.Black, 10, y)
            y += 15

            ' --- DATOS DEL PAGO REAL ---
            If dgvPagos.CurrentRow IsNot Nothing Then
                Dim idRecibo As String = dgvPagos.CurrentRow.Cells("id_pago").Value.ToString().PadLeft(6, "0"c)
                Dim fechaPago As String = Convert.ToDateTime(dgvPagos.CurrentRow.Cells("fecha_pago").Value).ToString("dd/MM/yyyy HH:mm")
                Dim nombreSocio As String = txtNombreSocio.Text
                Dim montoPago As Decimal = Convert.ToDecimal(dgvPagos.CurrentRow.Cells("monto").Value)
                Dim metodo As String = dgvPagos.CurrentRow.Cells("metodo_pago").Value.ToString()

                ' Nota: Extraemos cédula y saldo si están en tu grilla, si no, dejamos valores por defecto o variables
                Dim cedula As String = "001-150398-0003K"
                Dim saldoPendiente As Decimal = 0.00
                Dim detallePlan As String = "Mensual 01/10 - 30/10/2026" ' Puedes concatenar fechas del formulario

                ' Fila 1: N.° Recibo
                g.DrawString("Recibo N.°", fuenteRegular, Brushes.Black, 15, y)
                g.DrawString(idRecibo, fuenteRegular, Brushes.Black, New RectangleF(15, y, anchoTicket - 30, 16), formatoDerecha)
                y += 16

                ' Fila 2: Fecha
                g.DrawString("Fecha", fuenteRegular, Brushes.Black, 15, y)
                g.DrawString(fechaPago, fuenteRegular, Brushes.Black, New RectangleF(15, y, anchoTicket - 30, 16), formatoDerecha)
                y += 16

                ' Fila 3: Socio
                g.DrawString($"Socio: {nombreSocio}", fuenteRegular, Brushes.Black, 15, y)
                y += 16

                ' Fila 4: Cédula
                g.DrawString($"Cédula: {cedula}", fuenteRegular, Brushes.Black, 15, y)
                y += 20

                g.DrawString("--------------------------------------------------", fuenteRegular, Brushes.Black, 10, y)
                y += 15

                ' --- CUERPO / ABONOS ---
                g.DrawString(detallePlan, fuenteRegular, Brushes.Black, 15, y)
                y += 16

                g.DrawString($"Abono ({metodo})", fuenteRegular, Brushes.Black, 15, y)
                g.DrawString($"C$ {montoPago:N2}", fuenteRegular, Brushes.Black, New RectangleF(15, y, anchoTicket - 30, 16), formatoDerecha)
                y += 16

                ' Monto en letras
                Dim montoEnLetras As String = ConvertirMontoALetras(montoPago)
                g.DrawString(montoEnLetras.Replace("«", "").Replace("»", ""), fuenteRegular, Brushes.Black, 15, y)
                y += 18

                ' Saldo Pendiente
                g.DrawString("Saldo pendiente", fuenteRegular, Brushes.Black, 15, y)
                g.DrawString($"C$ {saldoPendiente:N2}", fuenteRegular, Brushes.Black, New RectangleF(15, y, anchoTicket - 30, 16), formatoDerecha)
                y += 20

                g.DrawString("--------------------------------------------------", fuenteRegular, Brushes.Black, 10, y)
                y += 15

                ' --- PIE DE PÁGINA ---
                Dim usuarioActivo As String = If(Sesion.UsuarioId <> 0, "recepcion01", "recepcion01")
                g.DrawString($"Atendió: {usuarioActivo}", fuenteRegular, Brushes.Black, New RectangleF(0, y, anchoTicket, 16), formatoCentro)
                y += 16
                g.DrawString("¡Gracias por entrenar con nosotros!", fuenteRegular, Brushes.Black, New RectangleF(0, y, anchoTicket, 16), formatoCentro)
            End If

            e.HasMorePages = False
        End Using
    End Sub




    ' FUNCIÓN PARA CONVERTIR MONTOS DE DINERO A TEXTO

    Private Function ConvertirMontoALetras(ByVal total As Decimal) As String
        Dim entero As Long = Fix(total)
        Dim centavos As Integer = CInt((total - entero) * 100)
        Dim textoCentavos As String = $"{centavos:00}/100 C$"

        Dim textoEntero As String = ""
        Select Case entero
            Case 0 : textoEntero = "Cero"
            Case 50 : textoEntero = "Cincuenta"
            Case 80 : textoEntero = "Ochenta"
            Case 300 : textoEntero = "Trescientos"
            Case 500 : textoEntero = "Quinientos"
            Case 600 : textoEntero = "Seiscientos"
            Case 800 : textoEntero = "Ochocientos"
            Case 1000 : textoEntero = "Mil"
            Case Else : textoEntero = entero.ToString()
        End Select

        Return $"«{textoEntero.ToLower()} córdobas netos"
    End Function

End Class