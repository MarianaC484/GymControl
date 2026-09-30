Imports System.Security.Cryptography

Public Class Seguridad

    Public Shared Function GenerarSalt() As String
        Dim saltBytes(15) As Byte
        RandomNumberGenerator.Create().GetBytes(saltBytes)
        Return Convert.ToBase64String(saltBytes)
    End Function

    Public Shared Function HashContrasena(contrasena As String, saltBase64 As String) As String
        Dim saltBytes() As Byte = Convert.FromBase64String(saltBase64)

        Using pbkdf2 As New Rfc2898DeriveBytes(contrasena, saltBytes, 10000, HashAlgorithmName.SHA256)
            Dim hashBytes() As Byte = pbkdf2.GetBytes(32)
            Return Convert.ToBase64String(hashBytes)
        End Using
    End Function

    Public Shared Function VerificarContrasena(contrasenaIngresada As String, saltBase64 As String, hashGuardado As String) As Boolean
        Dim nuevoHash As String = HashContrasena(contrasenaIngresada, saltBase64)
        Return nuevoHash = hashGuardado
    End Function

End Class
