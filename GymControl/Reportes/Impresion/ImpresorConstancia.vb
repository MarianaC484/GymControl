Imports System.Drawing
Imports System.Drawing.Printing

Public Class ImpresorConstancia
    Private _idSocio As Integer
    Private _nombreSocio As String

    Public Sub New(idSocio As Integer, nombreSocio As String)
        _idSocio = idSocio
        _nombreSocio = nombreSocio
    End Sub

    Public Sub DibujarTicket(sender As Object, e As PrintPageEventArgs)
        Dim fTitulo As New Font("Arial", 13, FontStyle.Bold)
        Dim fSubtitulo As New Font("Arial", 9.5, FontStyle.Bold)
        Dim fTexto As New Font("Arial", 8.5, FontStyle.Regular)

        Dim g As Graphics = e.Graphics

        Dim x As Single = e.MarginBounds.Left
        Dim y As Single = e.MarginBounds.Top
        Dim anchoUtil As Single = e.MarginBounds.Width

        ' 1.LOGO CORPORATIVO 
        Dim logo As Image = My.Resources.Logo
        If logo IsNot Nothing Then
            Dim altoDeseado As Integer = 60
            Dim anchoProporcional As Integer = CInt((logo.Width / logo.Height) * altoDeseado)

            Dim centroLogoX As Single = x + (anchoUtil / 2) - (anchoProporcional / 2)
            g.DrawImage(logo, centroLogoX, y, anchoProporcional, altoDeseado)
            y += altoDeseado + 20
        End If

        ' 2. ENCABEZADO CENTRADO 
        Using formatoCentro As New StringFormat() With {.Alignment = StringAlignment.Center}

            Dim rectTitulo As New RectangleF(x, y, anchoUtil, 25)
            g.DrawString("GYMCONTROL FITNESS", fTitulo, Brushes.Black, rectTitulo, formatoCentro)
            y += 30

            Dim rectSub As New RectangleF(x, y, anchoUtil, 20)
            g.DrawString("CONSTANCIA DE INSCRIPCIÓN", fSubtitulo, Brushes.Black, rectSub, formatoCentro)
            y += 40
        End Using

        g.DrawString("----------------------------------------------------------------------", fTexto, Brushes.Black, x, y)
        y += 25

        ' 3. DATOS OPERATIVOS DEL SOCIO 
        g.DrawString("Fecha de Emisión: " & ConvertirFechaALetras(DateTime.Now), fTexto, Brushes.Black, x, y) : y += 22
        g.DrawString("ID Socio:        " & _idSocio, fTexto, Brushes.Black, x, y) : y += 22
        g.DrawString("Socio / Cliente: " & _nombreSocio.ToUpper(), fTexto, Brushes.Black, x, y) : y += 26
        g.DrawString("Estado Actual:   REGISTRADO ACTIVO", fSubtitulo, Brushes.Black, x, y)

        e.HasMorePages = False
    End Sub
End Class
