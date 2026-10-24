Imports System.Drawing
Imports System.Drawing.Printing
Imports MySqlConnector

Public Class ImpresorVencimientos
    Private _idSocio As Integer
    Private _nombreSocio As String

    Public Sub New(idSocio As Integer, nombreSocio As String)
        _idSocio = idSocio
        _nombreSocio = nombreSocio
    End Sub

    Public Sub DibujarTicket(sender As Object, e As PrintPageEventArgs)
        Dim fTitulo As New Font("Courier New", 11, FontStyle.Bold)
        Dim fSubtitulo As New Font("Courier New", 9, FontStyle.Bold)
        Dim fTexto As New Font("Courier New", 9, FontStyle.Regular)
        Dim fPie As New Font("Courier New", 8, FontStyle.Italic)

        Dim g As Graphics = e.Graphics
        Dim y As Single = 15
        Dim x As Single = 15
        Dim anchoTicket As Single = 280
        Dim separador As String = "----------------------------------"

        ' 1. LOGO CORPORATIVO 
        Dim logo As Image = My.Resources.Logo
        If logo IsNot Nothing Then
            Dim altoDeseado As Integer = 50
            Dim anchoProporcional As Integer = CInt((logo.Width / logo.Height) * altoDeseado)

            Dim centroX As Single = (anchoTicket / 2) - (anchoProporcional / 2)
            g.DrawImage(logo, centroX, y, anchoProporcional, altoDeseado)
            y += altoDeseado + 15
        End If

        ' 2. TEXTOS DE CABECERA 
        Using formatoCentro As New StringFormat() With {.Alignment = StringAlignment.Center}
            Dim rectTitulo As New RectangleF(0, y, anchoTicket, 18)
            g.DrawString("GYMCONTROL", fTitulo, Brushes.Black, rectTitulo, formatoCentro) : y += 18

            Dim rectSub As New RectangleF(0, y, anchoTicket, 15)
            g.DrawString("ESTADO DE VENCIMIENTO", fSubtitulo, Brushes.Black, rectSub, formatoCentro) : y += 20
        End Using

        g.DrawString(separador, fTexto, Brushes.Black, x, y) : y += 12

        g.DrawString("Fecha Impresión: " & ConvertirFechaALetras(DateTime.Now), fTexto, Brushes.Black, x, y) : y += 15
        g.DrawString("Socio: " & _nombreSocio, fTexto, Brushes.Black, x, y) : y += 22

        ' 3. LÓGICA DE CONEXIÓN A BASE DE DATOS 
        Dim strConexion As String = "Server=localhost;Port=3307;Database=gimnasio_db;Uid=gym_app;Pwd=Gym#2026app;"
        Dim query As String = "SELECT m.id_membresia, 'Plan Gimnasio' AS nombre_plan, m.fecha_vencimiento, " &
                             "DATEDIFF(m.fecha_vencimiento, CURDATE()) AS dias " &
                             "FROM membresias m " &
                             "INNER JOIN socios s ON m.id_socio = s.id_socio " &
                             "WHERE m.id_socio = @idSocio " &
                             "ORDER BY m.fecha_vencimiento DESC LIMIT 1"

        Try
            Using conn As New MySqlConnection(strConexion)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idSocio", _idSocio)
                    conn.Open()

                    Using miReader As MySqlDataReader = cmd.ExecuteReader()
                        If miReader.Read() Then
                            Dim plan As String = miReader("nombre_plan").ToString()
                            Dim fVence As DateTime = Convert.ToDateTime(miReader("fecha_vencimiento"))
                            Dim diasRestantes As Integer = Convert.ToInt32(miReader("dias"))

                            g.DrawString("Plan Activo: " & plan, fTexto, Brushes.Black, x, y) : y += 15
                            g.DrawString("Vence el: " & ConvertirFechaALetras(fVence), fTexto, Brushes.Black, x, y) : y += 15
                            g.DrawString(separador, fTexto, Brushes.Black, x, y) : y += 12

                            If diasRestantes < 0 Then
                                g.DrawString("ESTADO: MEMBRESÍA VENCIDA", fSubtitulo, Brushes.Red, x, y) : y += 15
                                g.DrawString("Días vencidos: " & Math.Abs(diasRestantes), fTexto, Brushes.Red, x, y) : y += 20
                            Else
                                g.DrawString("ESTADO: MEMBRESÍA ACTIVA", fSubtitulo, Brushes.Green, x, y) : y += 15
                                g.DrawString("Días restantes: " & diasRestantes, fTexto, Brushes.Black, x, y) : y += 20
                            End If
                        Else
                            g.DrawString("El socio no cuenta con planes", fTexto, Brushes.Black, x, y) : y += 15
                            g.DrawString("o membresías registradas.", fTexto, Brushes.Black, x, y) : y += 20
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            g.DrawString("Error DB: No se pudieron leer", fTexto, Brushes.Red, x, y) : y += 15
            g.DrawString("los datos de vencimiento.", fTexto, Brushes.Red, x, y) : y += 20
        End Try

        g.DrawString(separador, fTexto, Brushes.Black, x, y) : y += 12
        g.DrawString("GymControl R03 - Puerto 3307", fPie, Brushes.Black, x + 15, y)
    End Sub
End Class
