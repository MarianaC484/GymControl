Imports System.Data
Imports MySqlConnector

Public Class frmPortalSocios

    Private idSocioActual As Integer = 0

    '==========================================================
    ' CARGA DEL FORMULARIO
    '==========================================================
    Private Sub frmPortalSocios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblNombreValor.Text = "—"
        lblMembresiaValor.Text = "—"
        lblVencimientoValor.Text = "—"
        lblEstadoValor.Text = "—"

        ConfigurarTablas()
        LimpiarInformacion()

    End Sub


    '==========================================================
    ' CONFIGURAR DATAGRIDVIEW
    '==========================================================
    Private Sub ConfigurarTablas()

        'Tabla de pagos
        dgvPagos.AutoGenerateColumns = True
        dgvPagos.ReadOnly = True
        dgvPagos.AllowUserToAddRows = False
        dgvPagos.AllowUserToDeleteRows = False
        dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPagos.MultiSelect = False
        dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Tabla de horarios
        dgvHorarios.AutoGenerateColumns = True
        dgvHorarios.ReadOnly = True
        dgvHorarios.AllowUserToAddRows = False
        dgvHorarios.AllowUserToDeleteRows = False
        dgvHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvHorarios.MultiSelect = False
        dgvHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    End Sub


    '==========================================================
    ' BOTÓN BUSCAR
    '==========================================================
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        If String.IsNullOrWhiteSpace(txtCedula.Text) Then

            MessageBox.Show(
                "Ingrese la cédula del socio.",
                "Portal de Socios",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtCedula.Focus()
            Return

        End If

        BuscarSocio()

    End Sub


    '==========================================================
    ' BUSCAR SOCIO
    '==========================================================
    Private Sub BuscarSocio()

        Try

            Dim cedula As String = txtCedula.Text.Trim()

            Dim resultado As DataTable = SocioDAO.Buscar(cedula)

            If resultado Is Nothing OrElse resultado.Rows.Count = 0 Then

                MessageBox.Show(
                    "No se encontró ningún socio con esa cédula.",
                    "Portal de Socios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                LimpiarInformacion()
                Return

            End If

            Dim fila As DataRow = resultado.Rows(0)

            idSocioActual = ObtenerEntero(fila, "id_socio")

            lblNombreValor.Text = ObtenerNombreSocio(fila)

            CargarMembresia()
            CargarPagos()
            CargarHorarios()

        Catch ex As Exception

            MessageBox.Show(
                "Ocurrió un error al buscar el socio:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub


    '==========================================================
    ' OBTENER NOMBRE DEL SOCIO
    '==========================================================
    Private Function ObtenerNombreSocio(fila As DataRow) As String

        Dim nombre As String = ""
        Dim apellido As String = ""

        If fila.Table.Columns.Contains("nombres") Then
            nombre = fila("nombres").ToString()
        ElseIf fila.Table.Columns.Contains("nombre") Then
            nombre = fila("nombre").ToString()
        End If

        If fila.Table.Columns.Contains("apellidos") Then
            apellido = fila("apellidos").ToString()
        ElseIf fila.Table.Columns.Contains("apellido") Then
            apellido = fila("apellido").ToString()
        End If

        Dim nombreCompleto As String =
            (nombre & " " & apellido).Trim()

        If nombreCompleto = "" Then
            nombreCompleto = "Socio encontrado"
        End If

        Return nombreCompleto

    End Function


    '==========================================================
    ' CARGAR MEMBRESÍA
    '==========================================================
    Private Sub CargarMembresia()

        lblMembresiaValor.Text = "—"
        lblVencimientoValor.Text = "—"
        lblEstadoValor.Text = "—"

        If idSocioActual <= 0 Then
            Return
        End If

        Try

            Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()

                conexion.Open()

                Dim sql As String =
                    "SELECT " &
                    "m.id_membresia, " &
                    "m.fecha_inicio, " &
                    "m.fecha_vencimiento, " &
                    "m.precio_pactado, " &
                    "m.estado, " &
                    "tm.nombre AS tipo_membresia " &
                    "FROM membresias m " &
                    "LEFT JOIN tipos_membresia tm " &
                    "ON m.id_tipo = tm.id_tipo " &
                    "WHERE m.id_socio = @id_socio " &
                    "ORDER BY m.id_membresia DESC " &
                    "LIMIT 1"

                Using comando As New MySqlCommand(sql, conexion)

                    comando.Parameters.AddWithValue(
                        "@id_socio",
                        idSocioActual)

                    Using lector As MySqlDataReader =
                        comando.ExecuteReader()

                        If lector.Read() Then

                            If Not IsDBNull(lector("tipo_membresia")) Then
                                lblMembresiaValor.Text =
                                    lector("tipo_membresia").ToString()
                            Else
                                lblMembresiaValor.Text = "Sin tipo"
                            End If


                            If Not IsDBNull(lector("fecha_vencimiento")) Then

                                Dim fechaVencimiento As DateTime =
                                    Convert.ToDateTime(
                                        lector("fecha_vencimiento"))

                                lblVencimientoValor.Text =
                                    fechaVencimiento.ToString("dd/MM/yyyy")

                            End If


                            If Not IsDBNull(lector("estado")) Then
                                lblEstadoValor.Text =
                                    lector("estado").ToString()
                            End If

                        Else

                            lblMembresiaValor.Text = "Sin membresía"
                            lblVencimientoValor.Text = "—"
                            lblEstadoValor.Text = "—"

                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo cargar la membresía:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub


    '==========================================================
    ' CARGAR PAGOS
    '==========================================================
    Private Sub CargarPagos()

        dgvPagos.DataSource = Nothing

        If idSocioActual <= 0 Then
            Return
        End If

        Try

            Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()

                conexion.Open()

                Dim sql As String =
                    "SELECT " &
                    "p.id_pago AS ID, " &
                    "p.monto AS Monto, " &
                    "p.metodo_pago AS `Método de pago`, " &
                    "p.referencia AS Referencia, " &
                    "p.observacion AS Observación, " &
                    "p.fecha_pago AS `Fecha de pago` " &
                    "FROM pagos p " &
                    "INNER JOIN membresias m " &
                    "ON p.id_membresia = m.id_membresia " &
                    "WHERE m.id_socio = @id_socio " &
                    "AND (p.anulado = 0 OR p.anulado IS NULL) " &
                    "ORDER BY p.fecha_pago DESC"

                Using comando As New MySqlCommand(sql, conexion)

                    comando.Parameters.AddWithValue(
                        "@id_socio",
                        idSocioActual)

                    Using adaptador As New MySqlDataAdapter(comando)

                        Dim tablaPagos As New DataTable()

                        adaptador.Fill(tablaPagos)

                        dgvPagos.DataSource = tablaPagos

                    End Using

                End Using

            End Using

            ConfigurarDgvPagos()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los pagos:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub


    '==========================================================
    ' CONFIGURAR TABLA DE PAGOS
    '==========================================================
    Private Sub ConfigurarDgvPagos()

        If dgvPagos.Columns.Count = 0 Then
            Return
        End If

        If dgvPagos.Columns.Contains("ID") Then
            dgvPagos.Columns("ID").Visible = False
        End If

        If dgvPagos.Columns.Contains("Monto") Then
            dgvPagos.Columns("Monto").DefaultCellStyle.Format = "C2"
        End If

        If dgvPagos.Columns.Contains("Fecha de pago") Then
            dgvPagos.Columns("Fecha de pago").DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm"
        End If

    End Sub


    '==========================================================
    ' CARGAR HORARIOS
    '==========================================================
    Private Sub CargarHorarios()

        dgvHorarios.DataSource = Nothing

        Try

            Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()

                conexion.Open()

                'IMPORTANTE:
                'Las horas se convierten a texto desde SQL.
                'Así evitamos el error TimeSpan del DataGridView.

                Dim sql As String =
                    "SELECT " &
                    "id_horario AS ID, " &
                    "id_instructor AS Instructor, " &
                    "id_actividad AS Actividad, " &
                    "id_sala AS Sala, " &
                    "dia_semana AS `Día`, " &
                    "TIME_FORMAT(hora_inicio, '%H:%i') AS `Hora inicio`, " &
                    "TIME_FORMAT(hora_fin, '%H:%i') AS `Hora fin` " &
                    "FROM horarios " &
                    "WHERE activo = 1 " &
                    "ORDER BY " &
                    "FIELD(dia_semana, " &
                    "'Lunes','Martes','Miércoles','Jueves','Viernes','Sábado','Domingo'), " &
                    "hora_inicio"

                Using comando As New MySqlCommand(sql, conexion)

                    Using adaptador As New MySqlDataAdapter(comando)

                        Dim tablaHorarios As New DataTable()

                        adaptador.Fill(tablaHorarios)

                        dgvHorarios.DataSource = tablaHorarios

                    End Using

                End Using

            End Using

            ConfigurarDgvHorarios()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los horarios:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub


    '==========================================================
    ' CONFIGURAR TABLA DE HORARIOS
    '==========================================================
    Private Sub ConfigurarDgvHorarios()

        If dgvHorarios.Columns.Count = 0 Then
            Return
        End If

        If dgvHorarios.Columns.Contains("ID") Then
            dgvHorarios.Columns("ID").Visible = False
        End If

        'NO ponemos DefaultCellStyle.Format a las horas.
        'Ya vienen como texto desde MariaDB.

    End Sub


    '==========================================================
    ' LIMPIAR INFORMACIÓN
    '==========================================================
    Private Sub LimpiarInformacion()

        idSocioActual = 0

        lblNombreValor.Text = "—"
        lblMembresiaValor.Text = "—"
        lblVencimientoValor.Text = "—"
        lblEstadoValor.Text = "—"

        dgvPagos.DataSource = Nothing
        dgvHorarios.DataSource = Nothing

    End Sub


    '==========================================================
    ' BOTÓN CERRAR
    '==========================================================
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Me.Close()

    End Sub


    '==========================================================
    ' OBTENER ID DEL SOCIO
    '==========================================================
    Private Function ObtenerEntero(
        fila As DataRow,
        nombreColumna As String) As Integer

        If fila Is Nothing Then
            Return 0
        End If

        If Not fila.Table.Columns.Contains(nombreColumna) Then
            Return 0
        End If

        If IsDBNull(fila(nombreColumna)) Then
            Return 0
        End If

        Dim valor As Integer

        If Integer.TryParse(
            fila(nombreColumna).ToString(),
            valor) Then

            Return valor

        End If

        Return 0

    End Function

End Class