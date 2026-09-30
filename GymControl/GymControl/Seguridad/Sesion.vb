Public Class Sesion
    Public Shared Property UsuarioId As Integer
    Public Shared Property NombreUsuario As String
    Public Shared Property Rol As String

    Public Shared Sub CerrarSesion()
        UsuarioId = 0
        NombreUsuario = String.Empty
        Rol = String.Empty
    End Sub
End Class
