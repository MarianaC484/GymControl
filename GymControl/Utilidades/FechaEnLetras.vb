Public Module FechaEnLetras
    Public Function ConvertirFechaALetras(ByVal fecha As DateTime) As String
        Dim meses() As String = {"", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"}
        Return fecha.Day & " de " & meses(fecha.Month) & " de " & fecha.Year
    End Function
End Module
