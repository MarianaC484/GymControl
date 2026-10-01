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
        If String.IsNullOrWhiteSpace(txtUsuario.Text) OrElse String.IsNullOrWhiteSpace(txtContrasena.Text) Then
            lblMensaje.Text = "Por favor, llene todos los campos."
            lblMensaje.ForeColor = Color.Orange
            lblMensaje.Visible = True
            Return
        End If

        ' 2. Llamamos al DAO para que busque al usuario en MariaDB de forma limpia
        Dim dtUsuario As DataTable = UsuarioDAO.ObtenerUsuarioPorNombre(txtUsuario.Text.Trim())

        ' Si el DataTable tiene filas, el usuario sí existe
        If dtUsuario.Rows.Count > 0 Then
            Dim row As DataRow = dtUsuario.Rows(0)
            Dim idUsuario As Integer = Convert.ToInt32(row("id_usuario"))
            Dim hashGuardado As String = row("contrasena_hash").ToString()
            Dim saltGuardado As String = row("sal").ToString()
            Dim intentos As Integer = Convert.ToInt32(row("intentos_fallidos"))
            Dim esActivo As Integer = Convert.ToInt32(row("activo"))
            Dim idRol As Integer = Convert.ToInt32(row("id_rol"))

            ' 3. Verificar si la cuenta está bloqueada
            If esActivo = 0 OrElse intentos >= 3 Then
                lblMensaje.Text = "Cuenta bloqueada. Contacte al administrador."
                lblMensaje.ForeColor = Color.Red
                lblMensaje.Visible = True
                Return
            End If

            ' 4. Verificar la contraseña con la clase de Seguridad
            If Seguridad.VerificarContrasena(txtContrasena.Text, saltGuardado, hashGuardado) Then
                ' ¡CONTRASEÑA CORRECTA! Restablecemos intentos en la BD usando el DAO
                UsuarioDAO.ActualizarIntentosYEstado(idUsuario, 0, 1)

                ' Guardamos los datos de la sesión global
                Sesion.UsuarioId = idUsuario
                Sesion.NombreUsuario = txtUsuario.Text.Trim()
                Sesion.Rol = idRol.ToString()

                MessageBox.Show("¡Bienvenido al sistema! Ingreso exitoso.", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim principal As New frmPrincipal()
                principal.Show()
                Me.Hide()

            Else
                ' ¡CONTRASEÑA INCORRECTA! Incrementar intentos mediante el DAO
                intentos += 1
                Dim intentosRestantes As Integer = 3 - intentos

                If intentos >= 3 Then
                    UsuarioDAO.ActualizarIntentosYEstado(idUsuario, intentos, 0) ' Bloquear
                    lblMensaje.Text = "Cuenta bloqueada por seguridad. Contacte al administrador."
                Else
                    UsuarioDAO.ActualizarIntentosYEstado(idUsuario, intentos, 1) ' Mantener activo con fallo
                    lblMensaje.Text = $"Usuario o contraseña incorrectos. Intentos restantes: {intentosRestantes}"
                End If

                lblMensaje.ForeColor = Color.Red
                lblMensaje.Visible = True
            End If
        Else
            ' El usuario no existe en la base de datos
            lblMensaje.Text = "Usuario o contraseña incorrectos."
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
        End If
    End Sub

    Private Sub ActualizarIntentosYEstado(idUsuario As Integer, intentos As Integer, nuevoEstado As Integer)
        Dim queryUpdate As String = "UPDATE usuarios SET intentos_fallidos = @intentos, activo = @activo WHERE id_usuario = @id"
        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(queryUpdate, conn)
                cmd.Parameters.AddWithValue("@intentos", intentos)
                cmd.Parameters.AddWithValue("@activo", nuevoEstado)
                cmd.Parameters.AddWithValue("@id", idUsuario)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As MySqlException
                    Console.WriteLine("Error al actualizar estado en MariaDB: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub lblRestablecimientoContrasena_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRestablecimientoContrasena.LinkClicked
        MessageBox.Show("Por favor, póngase en contacto con el administrador del sistema en la oficina central o envíe un correo a soporte@gymcontrol.com para restablecer sus credenciales.",
                  "Recuperación de Cuenta",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
