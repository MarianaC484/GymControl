
Imports GymControl.Utilidades
Imports MySqlConnector
Public Class FrmListadoVencimientos

    Private paginaActual As Integer = 1
    Private registrosPorPagina As Integer = 20
    Private totalRegistros As Integer = 0
    Private totalPaginas As Integer = 1


    Private Sub frmListadoVencimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DeshabilitarBotonesImpresion()

        ppdListado.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub DeshabilitarBotonesImpresion()

        btnConfigurarPagina.Enabled = False
        btnVistaPrevia.Enabled = False
        btnImprimir.Enabled = False
    End Sub

    Private Sub HabilitarBotonesImpresion()
        btnConfigurarPagina.Enabled = True
        btnVistaPrevia.Enabled = True
        btnImprimir.Enabled = True
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click

        paginaActual = 1
        CargarListadoVencimientos()
    End Sub

    Private Sub CargarListadoVencimientos()

        Dim diasAtras As Integer = Convert.ToInt32(nudDiasAtras.Value)
        Dim diasAdelante As Integer = Convert.ToInt32(nudDiasAdelante.Value)
        Dim soloConSaldo As Boolean = chkSoloConSaldo.Checked

        Dim query As String = "SELECT m.id_membresia AS 'ID', " &
                             "CONCAT(s.nombres, ' ', s.apellidos) AS 'Cliente', " &
                             "m.fecha_vencimiento AS 'Vencimiento', " &
                             "m.precio_pactado AS 'Saldo', " &
                             "DATEDIFF(m.fecha_vencimiento, CURDATE()) AS 'DiasRestantes' " &
                             "FROM membresias m " &
                             "INNER JOIN socios s ON m.id_socio = s.id_socio " &
                             "WHERE m.fecha_vencimiento BETWEEN DATE_SUB(CURDATE(), INTERVAL @atras DAY) " &
                             "AND DATE_ADD(CURDATE(), INTERVAL @adelante DAY)"

        If soloConSaldo Then
            query &= " AND m.precio_pactado > 0"
        End If

        query &= " ORDER BY m.fecha_vencimiento ASC"

        Dim strConexion As String = "Server=localhost;Port=3307;Database=gimnasio_db;Uid=gym_app;Pwd=Gym#2026app;"
        Using conn As New MySqlConnection(strConexion)

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@atras", diasAtras)
                cmd.Parameters.AddWithValue("@adelante", diasAdelante)

                Dim dt As New DataTable()
                Try
                    Dim da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)

                    dgvVencimientos.DataSource = dt

                    totalRegistros = dt.Rows.Count
                    lblResumen.Text = "Registros encontrados: " & totalRegistros

                    If totalRegistros > 0 Then
                        HabilitarBotonesImpresion()
                    Else
                        DeshabilitarBotonesImpresion()
                        MsgBox("No se encontraron membresías que venzan en el rango seleccionado.", MsgBoxStyle.Information, "GymControl")
                    End If

                Catch ex As Exception
                    MsgBox("Error al extraer los datos de vencimientos: " & ex.Message, MsgBoxStyle.Critical, "GymControl")
                End Try
            End Using
        End Using
    End Sub

    ' 3. PROPIEDADES DINÁMICAS (DÍAS NEGATIVOS EN ROJO Y ORIENTACIÓN)

    Private Sub dgvVencimientos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvVencimientos.CellFormatting

        If dgvVencimientos.Columns(e.ColumnIndex).Name = "DiasRestantes" Then
            If e.Value IsNot Nothing AndAlso Not IsDBNull(e.Value) Then
                Dim dias As Integer
                If Integer.TryParse(e.Value.ToString(), dias) Then
                    If dias < 0 Then
                        e.CellStyle.ForeColor = Color.Red
                        e.CellStyle.Font = New Font(dgvVencimientos.Font, FontStyle.Bold)
                    Else
                        e.CellStyle.ForeColor = dgvVencimientos.ForeColor
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub chkHorizontal_CheckedChanged(sender As Object, e As EventArgs) Handles chkHorizontal.CheckedChanged

        If pdListado IsNot Nothing Then
            pdListado.DefaultPageSettings.Landscape = chkHorizontal.Checked
        End If
    End Sub

    Private Sub btnConfigurarPagina_Click(sender As Object, e As EventArgs) Handles btnConfigurarPagina.Click
        psdListado.ShowDialog()
    End Sub

    Private Sub btnVistaPrevia_Click(sender As Object, e As EventArgs) Handles btnVistaPrevia.Click
        ppdListado.ShowDialog()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If prdListado.ShowDialog() = DialogResult.OK Then
            pdListado.Print()
        End If
    End Sub

    ' EVENTOS DEL PRINTDOCUMENT

    Private filaInicialAsImpresion As Integer = 0

    Private Sub pdListado_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles pdListado.BeginPrint
        filaInicialAsImpresion = 0
    End Sub

    Private Sub pdListado_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pdListado.PrintPage

        ' Configuración de Fuentes y Estilos
        Dim fuenteTitulo As New Font("Arial", 16, FontStyle.Bold)
        Dim fuenteSub As New Font("Arial", 11, FontStyle.Regular)
        Dim fuenteEncabezado As New Font("Arial", 10, FontStyle.Bold)
        Dim fuenteCuerpo As New Font("Arial", 9, FontStyle.Regular)

        Dim lapizLineas As New Pen(Color.Black, 1)
        Dim pincelTexto As New SolidBrush(Color.Black)

        ' Gestión de Márgenes y Coordenadas
        Dim posX As Integer = e.MarginBounds.Left
        Dim posY As Integer = e.MarginBounds.Top
        Dim anchoPagina As Integer = e.MarginBounds.Width
        Dim altoPagina As Integer = e.MarginBounds.Height

        Dim logoGrafico As Image = My.Resources.Logo
        If logoGrafico IsNot Nothing Then
            Dim altoDeseado As Integer = 50

            Dim anchoProporcional As Integer = CInt((logoGrafico.Width / logoGrafico.Height) * altoDeseado)

            e.Graphics.DrawImage(logoGrafico, posX, posY, anchoProporcional, altoDeseado)
            posY += altoDeseado + 15
        Else
            e.Graphics.DrawString("[Logo aa]", New Font("Arial", 10, FontStyle.Bold), pincelTexto, posX, posY)
            posY += 30
        End If

        Dim titulo As String = "GYMCONTROL - REPORTES DE VENCIMIENTOS"
        Dim tamanoTitulo As SizeF = e.Graphics.MeasureString(titulo, fuenteTitulo)
        Dim centroX As Integer = posX + (anchoPagina / 2) - (tamanoTitulo.Width / 2)
        e.Graphics.DrawString(titulo, fuenteTitulo, pincelTexto, centroX, posY)

        posY += 35
        Dim infoFecha As String = ""

        Try

            infoFecha = "Fecha de Emisión: " & ConvertirFechaALetras(DateTime.Now)
        Catch ex As Exception

            infoFecha = "Fecha de Emisión: " & DateTime.Now.ToShortDateString()
        End Try

        e.Graphics.DrawString(infoFecha, fuenteSub, pincelTexto, posX, posY)

        posY += 25
        e.Graphics.DrawLine(lapizLineas, posX, posY, posX + anchoPagina, posY)

        posY += 15

        Dim colID As Integer = 50
        Dim colCliente As Integer = 250
        Dim colVencimiento As Integer = 120
        Dim colSaldo As Integer = 100
        Dim colDias As Integer = 100

        e.Graphics.DrawString("ID", fuenteEncabezado, pincelTexto, posX, posY)
        e.Graphics.DrawString("Socio / Cliente", fuenteEncabezado, pincelTexto, posX + colID, posY)
        e.Graphics.DrawString("Vencimiento", fuenteEncabezado, pincelTexto, posX + colID + colCliente, posY)
        e.Graphics.DrawString("Monto Saldo", fuenteEncabezado, pincelTexto, posX + colID + colCliente + colVencimiento, posY)
        e.Graphics.DrawString("Días Rest.", fuenteEncabezado, pincelTexto, posX + colID + colCliente + colVencimiento + colSaldo, posY)

        posY += 20
        e.Graphics.DrawLine(lapizLineas, posX, posY, posX + anchoPagina, posY)
        posY += 10

        Dim totalFilasGrid As Integer = dgvVencimientos.Rows.Count

        While filaInicialAsImpresion < totalFilasGrid

            If Not dgvVencimientos.Rows(filaInicialAsImpresion).IsNewRow Then
                Dim row As DataGridViewRow = dgvVencimientos.Rows(filaInicialAsImpresion)

                Dim id As String = row.Cells("ID").Value.ToString()
                Dim cliente As String = row.Cells("Cliente").Value.ToString()
                Dim vencimiento As String = Convert.ToDateTime(row.Cells("Vencimiento").Value).ToShortDateString()
                Dim saldoNum As Decimal = Convert.ToDecimal(row.Cells("Saldo").Value)
                Dim dias As String = row.Cells("DiasRestantes").Value.ToString()

                Dim saldoTexto As String = String.Format("{0:N2}", saldoNum)

                e.Graphics.DrawString(id, fuenteCuerpo, pincelTexto, posX, posY)
                e.Graphics.DrawString(cliente, fuenteCuerpo, pincelTexto, posX + colID, posY)
                e.Graphics.DrawString(vencimiento, fuenteCuerpo, pincelTexto, posX + colID + colCliente, posY)
                e.Graphics.DrawString(saldoTexto, fuenteCuerpo, pincelTexto, posX + colID + colCliente + colVencimiento, posY)

                ' Variación de color para días vencidos en la impresión 
                If Convert.ToInt32(dias) < 0 Then
                    Dim pincelRojo As New SolidBrush(Color.Red)
                    e.Graphics.DrawString(dias, New Font(fuenteCuerpo, FontStyle.Bold), pincelRojo, posX + colID + colCliente + colVencimiento + colSaldo, posY)
                Else
                    e.Graphics.DrawString(dias, fuenteCuerpo, pincelTexto, posX + colID + colCliente + colVencimiento + colSaldo, posY)
                End If

                posY += 22

                If posY > (e.MarginBounds.Bottom - 20) Then
                    filaInicialAsImpresion += 1
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If

            filaInicialAsImpresion += 1
        End While

        e.HasMorePages = False
    End Sub

End Class