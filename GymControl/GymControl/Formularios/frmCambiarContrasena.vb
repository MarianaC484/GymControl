Imports System.Windows.Forms

Public Class frmCambiarContrasena

    ' ============================================================
    ' CARGAR FORMULARIO
    ' ============================================================

    Private Sub frmCambiarContrasena_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        txtContrasenaActual.Clear()
        txtNuevaContrasena.Clear()
        txtConfirmarContrasena.Clear()

        txtContrasenaActual.UseSystemPasswordChar = True
        txtNuevaContrasena.UseSystemPasswordChar = True
        txtConfirmarContrasena.UseSystemPasswordChar = True

        txtContrasenaActual.Focus()

    End Sub


    ' ============================================================
    ' CAMBIAR CONTRASEÑA
    ' ============================================================

    Private Sub btnCambiar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCambiar.Click

        Try

            ' ----------------------------------------------------
            ' VALIDAR CONTRASEÑA ACTUAL
            ' ----------------------------------------------------

            If String.IsNullOrWhiteSpace(
                txtContrasenaActual.Text
            ) Then

                MessageBox.Show(
                    "Ingrese su contraseña actual.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                txtContrasenaActual.Focus()

                Return

            End If


            ' ----------------------------------------------------
            ' VALIDAR NUEVA CONTRASEÑA
            ' ----------------------------------------------------

            If String.IsNullOrWhiteSpace(
                txtNuevaContrasena.Text
            ) Then

                MessageBox.Show(
                    "Ingrese la nueva contraseña.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                txtNuevaContrasena.Focus()

                Return

            End If


            ' ----------------------------------------------------
            ' VALIDAR CONFIRMACIÓN
            ' ----------------------------------------------------

            If String.IsNullOrWhiteSpace(
                txtConfirmarContrasena.Text
            ) Then

                MessageBox.Show(
                    "Confirme la nueva contraseña.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                txtConfirmarContrasena.Focus()

                Return

            End If


            ' ----------------------------------------------------
            ' COMPARAR CONTRASEÑAS
            ' ----------------------------------------------------

            If txtNuevaContrasena.Text <>
               txtConfirmarContrasena.Text Then

                MessageBox.Show(
                    "La nueva contraseña y su confirmación no coinciden.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                txtConfirmarContrasena.Clear()
                txtConfirmarContrasena.Focus()

                Return

            End If


            ' ----------------------------------------------------
            ' VALIDAR LONGITUD
            ' ----------------------------------------------------

            If txtNuevaContrasena.Text.Length < 6 Then

                MessageBox.Show(
                    "La nueva contraseña debe tener al menos 6 caracteres.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                txtNuevaContrasena.Focus()

                Return

            End If
            ' ----------------------------------------------------
            ' VERIFICAR QUE HAYA UNA SESIÓN ACTIVA
            ' ----------------------------------------------------
            If Sesion.UsuarioId = 0 Then

                MessageBox.Show(
        "No hay un usuario autenticado.",
        "Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error
    )

                Return

            End If


            ' ----------------------------------------------------
            ' OBTENER DATOS DEL USUARIO ACTUAL
            ' ----------------------------------------------------

            Dim datosUsuario As DataTable =
    UsuarioDAO.ObtenerUsuarioPorNombre(
        Sesion.NombreUsuario
    )


            If datosUsuario Is Nothing OrElse
   datosUsuario.Rows.Count = 0 Then

                MessageBox.Show(
        "No se pudo encontrar el usuario actual.",
        "Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error
    )

                Return

            End If


            Dim fila As DataRow = datosUsuario.Rows(0)

            Dim hashGuardado As String =
    fila("contrasena_hash").ToString()

            Dim saltGuardado As String =
    fila("sal").ToString()


            ' ----------------------------------------------------
            ' VERIFICAR CONTRASEÑA ACTUAL
            ' ----------------------------------------------------

            If Not Seguridad.VerificarContrasena(
    txtContrasenaActual.Text,
    saltGuardado,
    hashGuardado
) Then

                MessageBox.Show(
        "La contraseña actual es incorrecta.",
        "Contraseña incorrecta",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning
    )

                txtContrasenaActual.Clear()
                txtContrasenaActual.Focus()

                Return

            End If


            ' ----------------------------------------------------
            ' CAMBIAR CONTRASEÑA
            ' ----------------------------------------------------

            Dim resultado As Boolean =
    UsuarioDAO.CambiarContrasena(
        Sesion.UsuarioId,
        txtNuevaContrasena.Text
    )


            If resultado Then

                MessageBox.Show(
        "La contraseña se cambió correctamente.",
        "Operación exitosa",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
    )

                txtContrasenaActual.Clear()
                txtNuevaContrasena.Clear()
                txtConfirmarContrasena.Clear()

                Me.Close()

            End If


        Catch ex As Exception

            MessageBox.Show(
                "Ocurrió un error:" &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    ' ============================================================
    ' CANCELAR
    ' ============================================================

    Private Sub btnCancelar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancelar.Click

        Me.Close()

    End Sub

End Class