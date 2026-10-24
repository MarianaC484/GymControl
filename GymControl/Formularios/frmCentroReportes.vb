Imports MySqlConnector

Public Class frmCentroReportes

    Private usuarioActual As String = Sesion.NombreUsuario
    Private reporteSeleccionado As String = ""

    Private Sub frmCentroReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Configuración de la barra de estado inferior
        tslUsuario.Text = "Usuario: " & usuarioActual
        tslEstado.Text = "Listo"
        tspProgreso.Visible = False

        ' 2. Ocultar todos los paneles de parámetros por defecto 
        OcultarTodosLosPaneles()

        ' 3. Inicializar y poblar el TreeView de Reportes
        ConfigurarArbolReportes()

        ' Cargar los socios en memoria al abrir el panel
        CargarSociosBusqueda()
    End Sub

    Private Sub ConfigurarArbolReportes()
        tvReportes.Nodes.Clear()

        ' Nodo Raíz 1: Impresión Directa
        Dim nodoImpresion As New TreeNode("Impresión Directa")
        nodoImpresion.Nodes.Add(New TreeNode("R01 · Constancia de Inscripción") With {.Tag = "R01"})
        nodoImpresion.Nodes.Add(New TreeNode("R02 · Recibo de Pago Corto") With {.Tag = "R02"})
        nodoImpresion.Nodes.Add(New TreeNode("R03 · Ticket de Caja") With {.Tag = "R03"})

        ' Nodo Raíz 2: Reportes en Visor
        Dim nodoVisor As New TreeNode("Reportes en Visor")
        nodoVisor.Nodes.Add(New TreeNode("R04 · Ingresos por Período") With {.Tag = "R04"})
        nodoVisor.Nodes.Add(New TreeNode("R05 · Vencimientos de Socios") With {.Tag = "R05"})
        nodoVisor.Nodes.Add(New TreeNode("R06 · Asistencia de Instructores") With {.Tag = "R06"})

        nodoVisor.Nodes.Add(New TreeNode("R08 · Reporte Estadístico Diario") With {.Tag = "R08"})
        nodoVisor.Nodes.Add(New TreeNode("R09 · Historial de Membresías") With {.Tag = "R09"})

        ' Nodo Raíz 3: Archivos (Excel/PDF)
        Dim nodoArchivos As New TreeNode("Exportación de Archivos")
        nodoArchivos.Nodes.Add(New TreeNode("R07 · Padrón de Socios Activos (Excel)") With {.Tag = "R07"})

        ' Agregamos las raíces al TreeView
        tvReportes.Nodes.Add(nodoImpresion)
        tvReportes.Nodes.Add(nodoVisor)
        tvReportes.Nodes.Add(nodoArchivos)

        tvReportes.ExpandAll()
    End Sub

    Private Sub tvReportes_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvReportes.AfterSelect

        OcultarTodosLosPaneles()

        If e.Node.Tag Is Nothing Then
            lblNombreReporte.Text = "Seleccione un reporte"
            lblDescripcion.Text = "Por favor, elija un reporte del listado de la izquierda."
            ConfigurarBotones(False, False, False, False)
            Exit Sub
        End If

        Dim codigoReporte As String = e.Node.Tag.ToString()
        Dim miRol As String = Sesion.Rol

        ' VALIDACIÓN DE MATRIZ DE PERMISOS POR ROL

        If miRol <> "1" Then
            If (codigoReporte = "R04" Or codigoReporte = "R07" Or codigoReporte = "R08" Or codigoReporte = "R09") Then
                MessageBox.Show("Su rol actual no tiene autorización para acceder a este reporte financiero.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ConfigurarBotones(False, False, False, False)
                Exit Sub
            End If

            If miRol = "3" AndAlso codigoReporte <> "R06" Then
                MessageBox.Show("Acceso denegado.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ConfigurarBotones(False, False, False, False)
                Exit Sub
            End If
        End If

        ' COMPORTAMIENTO DINÁMICO DE PANELES Y BOTONES

        Select Case codigoReporte
            Case "R01", "R02", "R03"
                lblNombreReporte.Text = e.Node.Text
                lblDescripcion.Text = "Formatos de impresión directa y comprobantes del sistema. Seleccione un registro para continuar."
                pnlParamSocio.Visible = True
                ConfigurarBotones(True, True, False, False)

            Case "R04"
                lblNombreReporte.Text = "R04 · Ingresos por Período"
                lblDescripcion.Text = "Muestra los pagos válidos agrupados por día y por método de pago."
                pnlParamFechas.Visible = True
                ConfigurarBotones(True, True, True, True)

            Case "R05"
                lblNombreReporte.Text = "R05 · Vencimientos de Socios"
                lblDescripcion.Text = "Listado de membresías próximas a vencer o ya vencidas."
                pnlParamDias.Visible = True
                ConfigurarBotones(True, True, True, False)

            Case "R06", "R08", "R09"
                lblNombreReporte.Text = e.Node.Text
                lblDescripcion.Text = "Reportes y estadísticas generales del sistema."
                pnlParamInstructor.Visible = True
                ConfigurarBotones(True, False, True, True)
        End Select
    End Sub

    Private Sub OcultarTodosLosPaneles()
        pnlParamFechas.Visible = False
        pnlParamSocio.Visible = False
        pnlParamDias.Visible = False
        pnlParamInstructor.Visible = False
    End Sub

    Private Sub ConfigurarBotones(vista As Boolean, imprimir As Boolean, pdf As Boolean, excel As Boolean)
        btnVistaPrevia.Enabled = vista
        btnImprimir.Enabled = imprimir
        btnExportarPdf.Enabled = pdf
        btnExportarExcel.Enabled = excel
    End Sub

    Private Sub CargarSociosBusqueda()

        Dim strConexion As String = "Server=localhost;Port=3307;Database=gimnasio_db;Uid=gym_app;Pwd=Gym#2026app;"
        Dim query As String = "SELECT id_socio, CONCAT(nombres, ' ', apellidos) As NombreCompleto FROM socios WHERE activo = 1 ORDER BY nombres ASC"

        Dim dt As New DataTable()

        Try
            Using conn As New MySqlConnection(strConexion)
                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using

            cboSocio.DataSource = dt
            cboSocio.DisplayMember = "NombreCompleto"
            cboSocio.ValueMember = "id_socio"

            cboSocio.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            cboSocio.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Error al cargar lista de socios (Puerto 3307): " & ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnVistaPrevia_Click(sender As Object, e As EventArgs) Handles btnVistaPrevia.Click
        If tvReportes.SelectedNode Is Nothing OrElse tvReportes.SelectedNode.Tag Is Nothing Then Exit Sub

        tslEstado.Text = "Generando vista previa... Por favor espere."
        tspProgreso.Visible = True
        Application.DoEvents()

        Try

            reporteSeleccionado = tvReportes.SelectedNode.Tag.ToString()

            Dim pd As New System.Drawing.Printing.PrintDocument()
            Dim prntDlg As New PrintPreviewDialog()

            If cboSocio.SelectedValue IsNot Nothing Then
                Dim idSocio As Integer = Convert.ToInt32(cboSocio.SelectedValue)
                Dim nombreSocio As String = cboSocio.Text

                Select Case reporteSeleccionado
                    Case "R01"
                        Dim r01 As New ImpresorConstancia(idSocio, nombreSocio)
                        AddHandler pd.PrintPage, AddressOf r01.DibujarTicket
                    Case "R02"
                        Dim r02 As New ImpresorRecibo(nombreSocio, 300.0)
                        AddHandler pd.PrintPage, AddressOf r02.DibujarTicket
                    Case "R03"
                        Dim r03 As New ImpresorVencimientos(idSocio, nombreSocio)
                        AddHandler pd.PrintPage, AddressOf r03.DibujarTicket
                End Select
            End If

            If reporteSeleccionado = "R01" OrElse reporteSeleccionado = "R02" OrElse reporteSeleccionado = "R03" Then
                Dim papelTicket As New System.Drawing.Printing.PaperSize("Ticket Gym", 314, 600)
                pd.DefaultPageSettings.PaperSize = papelTicket
                pd.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(5, 5, 5, 5)
            End If

            prntDlg.Document = pd
            prntDlg.WindowState = FormWindowState.Maximized
            prntDlg.Text = "GymControl - Vista Previa de Impresión: " & reporteSeleccionado

            prntDlg.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error al generar vista previa: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tslEstado.Text = "Listo"
            tspProgreso.Visible = False
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If tvReportes.SelectedNode Is Nothing OrElse tvReportes.SelectedNode.Tag Is Nothing Then Exit Sub

        tslEstado.Text = "Preparando documento para impresión física..."
        tspProgreso.Visible = True
        Application.DoEvents()

        Try
            reporteSeleccionado = tvReportes.SelectedNode.Tag.ToString()

            Dim pd As New System.Drawing.Printing.PrintDocument()
            Dim pDlg As New PrintDialog()

            If cboSocio.SelectedValue IsNot Nothing Then
                Dim idSocio As Integer = Convert.ToInt32(cboSocio.SelectedValue)
                Dim nombreSocio As String = cboSocio.Text

                Select Case reporteSeleccionado
                    Case "R01"
                        Dim r01 As New ImpresorConstancia(idSocio, nombreSocio)
                        AddHandler pd.PrintPage, AddressOf r01.DibujarTicket
                    Case "R02"
                        Dim r02 As New ImpresorRecibo(nombreSocio, 300.0)
                        AddHandler pd.PrintPage, AddressOf r02.DibujarTicket
                    Case "R03"
                        Dim r03 As New ImpresorVencimientos(idSocio, nombreSocio)
                        AddHandler pd.PrintPage, AddressOf r03.DibujarTicket
                End Select
            End If


            If reporteSeleccionado = "R01" OrElse reporteSeleccionado = "R02" OrElse reporteSeleccionado = "R03" Then
                Dim papelTicket As New System.Drawing.Printing.PaperSize("Ticket Gym", 314, 600)
                pd.DefaultPageSettings.PaperSize = papelTicket
                pd.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(5, 5, 5, 5)
            End If

            pDlg.Document = pd

            If pDlg.ShowDialog() = DialogResult.OK Then
                pd.Print() '
                MessageBox.Show("Documento enviado a la impresora con éxito.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al mandar a imprimir: " & ex.Message, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tslEstado.Text = "Listo"
            tspProgreso.Visible = False
        End Try

    End Sub

    Private Sub btnExportarPdf_Click(sender As Object, e As EventArgs) Handles btnExportarPdf.Click
        If tvReportes.SelectedNode Is Nothing OrElse tvReportes.SelectedNode.Tag Is Nothing Then Exit Sub

        tslEstado.Text = "Exportando a documento PDF..."
        tspProgreso.Visible = True

        Try

        Catch ex As Exception
            MessageBox.Show("Error al exportar a PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tslEstado.Text = "Listo"
            tspProgreso.Visible = False
        End Try
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If tvReportes.SelectedNode Is Nothing OrElse tvReportes.SelectedNode.Tag Is Nothing Then Exit Sub

        tslEstado.Text = "Generando archivo de Excel..."
        tspProgreso.Visible = True

        Try

        Catch ex As Exception
            MessageBox.Show("Error al exportar a Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tslEstado.Text = "Listo"
            tspProgreso.Visible = False
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close() '
    End Sub
End Class
