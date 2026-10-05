Public Class Sesion

    Public Shared Property UsuarioId As Integer = 0
    Public Shared Property NombreUsuario As String = String.Empty
    Public Shared Property Rol As String = String.Empty

    Public Shared Sub CerrarSesion()
        UsuarioId = 0
        NombreUsuario = String.Empty
        Rol = String.Empty
    End Sub

End Class
