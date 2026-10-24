Imports System.Drawing
Imports System.Drawing.Printing

Public Class ImpresorRecibo
    Private _nombreSocio As String
    Private _monto As Decimal

    Public Sub New(nombreSocio As String, monto As Decimal)
        _nombreSocio = nombreSocio
        _monto = monto
    End Sub

    Public Sub DibujarTicket(sender As Object, e As PrintPageEventArgs)
        Dim fTitulo As New Font("Courier New", 12, FontStyle.Bold)
        Dim fSubtitulo As New Font("Courier New", 9, FontStyle.Bold)
        Dim fTexto As New Font("Courier New", 9, FontStyle.Regular)
        Dim g As Graphics = e.Graphics
        Dim y As Single = 10
        Dim x As Single = 10
        Dim anchoTicket As Single = 280

        Dim logo As Image = My.Resources.Logo
        If logo IsNot Nothing Then
            Dim altoDeseado As Integer = 50
            Dim anchoProporcional As Integer = CInt((logo.Width / logo.Height) * altoDeseado)

            Dim centroX As Single = (anchoTicket / 2) - (anchoProporcional / 2)
            g.DrawImage(logo, centroX, y, anchoProporcional, altoDeseado)
            y += altoDeseado + 12
        End If


        g.DrawString("   GYMCONTROL    ", fTitulo, Brushes.Black, x, y) : y += 18
        g.DrawString("   COMPROBANTE DE PAGO  ", fSubtitulo, Brushes.Black, x, y) : y += 15
        g.DrawString("----------------------------------", fTexto, Brushes.Black, x, y) : y += 12

        g.DrawString("Socio: " & _nombreSocio, fTexto, Brushes.Black, x, y) : y += 15
        g.DrawString("TOTAL: " & _monto.ToString("C2"), fTitulo, Brushes.Black, x, y) : y += 18

        ' utilidad modular NumeroALetras
        g.DrawString("SON: " & ConvertirMontoALetras(_monto), fTexto, Brushes.Black, x, y)

    End Sub

End Class


