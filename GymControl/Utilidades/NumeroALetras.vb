Public Module NumeroALetras
    Public Function ConvertirMontoALetras(ByVal total As Decimal) As String
        Dim entero As Integer = Math.Truncate(total)
        Dim textoLetras As String = ""

        If entero = 0 Then
            textoLetras = "CERO"
        ElseIf entero = 100 Then
            textoLetras = "CIEN"
        Else
            Select Case entero
                Case 1 To 19
                    Dim unidades() As String = {"", "UNO", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE", "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE", "DIECISEIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE"}
                    textoLetras = unidades(entero)
                Case 20 To 29
                    If entero = 20 Then textoLetras = "VEINTE" Else textoLetras = "VEINTI" & ConvertirMontoALetras(entero - 20)
                Case 30 To 39
                    If entero = 30 Then textoLetras = "TREINTA" Else textoLetras = "TREINTA Y " & ConvertirMontoALetras(entero - 30)
                Case 40 To 49
                    If entero = 40 Then textoLetras = "CUARENTA" Else textoLetras = "CUARENTA Y " & ConvertirMontoALetras(entero - 40)
                Case 50 To 59
                    If entero = 50 Then textoLetras = "CINCUENTA" Else textoLetras = "CINCUENTA Y " & ConvertirMontoALetras(entero - 50)
                Case 60 To 69
                    If entero = 60 Then textoLetras = "SESENTA" Else textoLetras = "SESENTA Y " & ConvertirMontoALetras(entero - 60)
                Case 70 To 79
                    If entero = 70 Then textoLetras = "SETENTA" Else textoLetras = "SETENTA Y " & ConvertirMontoALetras(entero - 70)
                Case 80 To 89
                    If entero = 80 Then textoLetras = "OCHENTA" Else textoLetras = "OCHENTA Y " & ConvertirMontoALetras(entero - 80)
                Case 90 To 99
                    If entero = 90 Then textoLetras = "NOVENTA" Else textoLetras = "NOVENTA Y " & ConvertirMontoALetras(entero - 90)
                Case 101 To 199
                    textoLetras = "CIENTO " & ConvertirMontoALetras(entero - 100)
                Case 200 To 299
                    If entero = 200 Then textoLetras = "DOSCIENTOS" Else textoLetras = "DOSCIENTOS " & ConvertirMontoALetras(entero - 200)
                Case 300 To 399
                    If entero = 300 Then textoLetras = "TRECIENTOS" Else textoLetras = "TRECIENTOS " & ConvertirMontoALetras(entero - 300)
                Case 500
                    textoLetras = "QUINIENTOS"
                Case Else
                    textoLetras = entero.ToString()
            End Select
        End If

        Return textoLetras & " CORDOBAS NETOS"
    End Function
End Module
