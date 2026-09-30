Imports GymControl.Seguridad
Imports MySqlConnector
Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Conexion.ProbarConexion() Then

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

        Dim query As String = "SELECT id_usuario, contrasena_hash, sal, intentos_fallidos, activo, id_rol FROM usuarios WHERE nombre_usuario = @usuario"

        Using conn As MySqlConnection = Conexion.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim())

                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()

                        ' Si el usuario existe en MariaDB
                        If reader.Read() Then
                            Dim idUsuario As Integer = Convert.ToInt32(reader("id_usuario"))
                            Dim hashGuardado As String = reader("contrasena_hash").ToString()
                            Dim saltGuardado As String = reader("sal").ToString()
                            Dim intentos As Integer = Convert.ToInt32(reader("intentos_fallidos"))
                            Dim esActivo As Integer = Convert.ToInt32(reader("activo"))
                            Dim idRol As Integer = Convert.ToInt32(reader("id_rol"))

                            ' 2. Verificar si la cuenta está bloqueada (si activo es 0 o intentos es igual o mayor a 3)
                            If esActivo = 0 OrElse intentos >= 3 Then
                                lblMensaje.Text = "Cuenta bloqueada. Contacte al administrador."
                                lblMensaje.ForeColor = Color.Red
                                lblMensaje.Visible = True
                                Return
                            End If

                            ' 3. Verificar la contraseña usando la clase Seguridad (PBKDF2)
                            If Seguridad.VerificarContrasena(txtContrasena.Text, saltGuardado, hashGuardado) Then

                                reader.Close()

                                ActualizarIntentosYEstado(idUsuario, 0, 1)

                                Sesion.UsuarioId = idUsuario
                                Sesion.NombreUsuario = txtUsuario.Text.Trim()
                                Sesion.Rol = idRol.ToString()

                                MessageBox.Show($"¡Bienvenido al sistema! Ingreso exitoso.", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Else

                                reader.Close()
                                intentos += 1
                                Dim intentosRestantes As Integer = 3 - intentos

                                If intentos >= 3 Then

                                    ActualizarIntentosYEstado(idUsuario, intentos, 0)
                                    lblMensaje.Text = "Cuenta bloqueada por seguridad. Contacte al administrador."
                                Else

                                    ActualizarIntentosYEstado(idUsuario, intentos, 1)
                                    lblMensaje.Text = $"Usuario o contraseña incorrectos. Intentos restantes: {intentosRestantes}"
                                End If

                                lblMensaje.ForeColor = Color.Red
                                lblMensaje.Visible = True
                            End If

                        Else

                            lblMensaje.Text = "Usuario o contraseña incorrectos."
                            lblMensaje.ForeColor = Color.Red
                            lblMensaje.Visible = True
                        End If

                    End Using
                Catch ex As MySqlException
                    MessageBox.Show("Error crítico en la base de datos: " & ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ActualizarIntentosYEstado(idUsuario As Integer, intentos As Integer, nuevoEstado As Integer)
        Dim queryUpdate As String = "UPDATE usuarios SET intentos_fallidos = @intentos, activo = @activo WHERE id_usuario = @id"
        Using conn As MySqlConnection = Conexion.ObtenerConexion()
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
End Class
