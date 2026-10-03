Imports GymControl.Seguridad
Imports MySqlConnector
Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ConexionBD.ProbarConexion() Then

            stsConexion.Items.Clear()
            Dim lblStatus As New ToolStripStatusLabel("Servidor: localhost:3307  |  BD: gimnasio_db  |  v1.0")
            stsConexion.Items.Add(lblStatus)
        Else
            stsConexion.Items.Clear()
            Dim lblStatus As New ToolStripStatusLabel("Servidor: DESCONECTADO")
            stsConexion.Items.Add(lblStatus)
        End If
    End Sub

    Private Sub chkMostrar_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrar.CheckedChanged
        If chkMostrar.Checked Then
            txtContrasena.UseSystemPasswordChar = False
        Else
            txtContrasena.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Application.Exit()
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click

        ' 1. Validar campos vacíos
        If String.IsNullOrWhiteSpace(txtUsuario.Text) OrElse
       String.IsNullOrWhiteSpace(txtContrasena.Text) Then

            lblMensaje.Text = "Por favor, llene todos los campos."
            lblMensaje.ForeColor = Color.Orange
            lblMensaje.Visible = True
            Return
        End If

        Dim nombreUsuario As String = txtUsuario.Text.Trim()

        ' 2. Buscar usuario mediante UsuarioDAO
        Dim dtUsuario As DataTable = UsuarioDAO.ObtenerUsuarioPorNombre(nombreUsuario)

        ' USUARIO NO EXISTE
        If dtUsuario.Rows.Count = 0 Then

            RegistrarIntentoBitacora(
            nombreUsuario,
            "Fallido"
        )

            lblMensaje.Text = "Usuario o contraseña incorrectos."
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True

            Return
        End If

        ' OBTENER DATOS DEL USUARIO

        Dim row As DataRow = dtUsuario.Rows(0)

        Dim idUsuario As Integer = Convert.ToInt32(row("id_usuario"))
        Dim hashGuardado As String = row("contrasena_hash").ToString()
        Dim saltGuardado As String = row("sal").ToString()
        Dim intentos As Integer = Convert.ToInt32(row("intentos_fallidos"))
        Dim esActivo As Integer = Convert.ToInt32(row("activo"))
        Dim idRol As Integer = Convert.ToInt32(row("id_rol"))

        ' CUENTA BLOQUEADA

        If esActivo = 0 OrElse intentos >= 3 Then

            RegistrarBitacora(
            idUsuario,
            nombreUsuario,
            "Bloqueado"
        )

            lblMensaje.Text = "Cuenta bloqueada. Contacte al administrador."
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True

            Return
        End If

        ' VERIFICAR CONTRASEÑA

        If Seguridad.VerificarContrasena(
        txtContrasena.Text,
        saltGuardado,
        hashGuardado) Then

            ' LOGIN CORRECTO

            UsuarioDAO.ActualizarIntentosYEstado(
            idUsuario,
            0,
            1
        )

            RegistrarBitacora(
            idUsuario,
            nombreUsuario,
            "Exitoso"
        )

            ' Guardar datos de sesión
            Sesion.UsuarioId = idUsuario
            Sesion.NombreUsuario = nombreUsuario
            Sesion.Rol = idRol.ToString()

            MessageBox.Show(
            "¡Bienvenido al sistema! Ingreso exitoso.",
            "Acceso Concedido",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

            Dim principal As New frmPrincipal()
            principal.Show()
            Me.Hide()

        Else

            ' CONTRASEÑA INCORRECTA

            intentos += 1

            If intentos >= 3 Then

                ' Bloquear usuario
                UsuarioDAO.ActualizarIntentosYEstado(
                idUsuario,
                intentos,
                0
            )

                RegistrarBitacora(
                idUsuario,
                nombreUsuario,
                "Bloqueado"
            )

                lblMensaje.Text =
                "Cuenta bloqueada por seguridad. Contacte al administrador."

            Else

                ' Mantener cuenta activa
                UsuarioDAO.ActualizarIntentosYEstado(
                idUsuario,
                intentos,
                1
            )

                RegistrarBitacora(
                idUsuario,
                nombreUsuario,
                "Fallido"
            )

                Dim intentosRestantes As Integer = 3 - intentos

                lblMensaje.Text =
                $"Usuario o contraseña incorrectos. Intentos restantes: {intentosRestantes}"

            End If

            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True

        End If

    End Sub

    Private Sub lblRestablecimientoContrasena_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRestablecimientoContrasena.LinkClicked
        MessageBox.Show("Por favor, póngase en contacto con el administrador del sistema en la oficina central o envíe un correo a soporte@gymcontrol.com para restablecer sus credenciales.",
                  "Recuperación de Cuenta",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information)
    End Sub

    Private Sub RegistrarBitacora(idUsuario As Integer,
                              usuarioIntento As String,
                              resultado As String)

        Dim bitacora As New BitacoraDAO()

        Try
            bitacora.Registrar(
                idUsuario,
                usuarioIntento,
                DateTime.Now,
                resultado,
                Environment.MachineName
            )
        Catch ex As Exception
            ' No impedir el login si falla el registro de bitácora
            Console.WriteLine("Error al registrar bitácora: " & ex.Message)
        End Try

    End Sub

    Private Sub RegistrarIntentoBitacora(usuarioIntento As String,
                                     resultado As String)

        Dim bitacora As New BitacoraDAO()

        Try
            bitacora.RegistrarIntento(
                usuarioIntento,
                DateTime.Now,
                resultado,
                Environment.MachineName
            )
        Catch ex As Exception
            Console.WriteLine("Error al registrar intento: " & ex.Message)
        End Try

    End Sub
End Class
