Imports MySqlConnector
Imports System.Data

Public Class frmUsuarios

    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            CargarRoles()
            CargarSocios()
            CargarInstructores()

            ' Mostrar la contraseña como puntos
            txtContrasena.UseSystemPasswordChar = True

            LimpiarFormulario()

        Catch ex As Exception
            MessageBox.Show(
                "No se pudieron cargar los datos del formulario." &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub


    ' =========================================================
    ' CARGAR ROLES
    ' =========================================================

    Private Sub CargarRoles()

        Dim tabla As New DataTable()

        Dim query As String =
            "SELECT id_rol, nombre " &
            "FROM roles " &
            "ORDER BY nombre"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                Try
                    conn.Open()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(tabla)
                    End Using

                Catch ex As MySqlException
                    MessageBox.Show(
                        "Error al cargar los roles: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                    Return
                End Try

            End Using
        End Using

        cboRol.DataSource = tabla
        cboRol.DisplayMember = "nombre"
        cboRol.ValueMember = "id_rol"
        cboRol.SelectedIndex = -1

    End Sub


    ' =========================================================
    ' CARGAR SOCIOS
    ' =========================================================

    Private Sub CargarSocios()

        Dim tabla As New DataTable()

        Dim query As String =
            "SELECT id_socio, cedula, nombres, apellidos " &
            "FROM socios " &
            "WHERE activo = 1 " &
            "ORDER BY apellidos, nombres"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                Try
                    conn.Open()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(tabla)
                    End Using

                Catch ex As MySqlException
                    MessageBox.Show(
                        "Error al cargar los socios: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                    Return
                End Try

            End Using
        End Using

        ' Agregamos una fila para permitir no asociar un socio
        Dim fila As DataRow = tabla.NewRow()
        fila("id_socio") = DBNull.Value
        fila("cedula") = ""
        fila("nombres") = "Sin socio"
        fila("apellidos") = ""
        tabla.Rows.InsertAt(fila, 0)

        cboSocio.DataSource = tabla
        cboSocio.DisplayMember = "nombres"
        cboSocio.ValueMember = "id_socio"
        cboSocio.SelectedIndex = 0

    End Sub


    ' =========================================================
    ' CARGAR INSTRUCTORES
    ' =========================================================

    Private Sub CargarInstructores()

        Dim tabla As New DataTable()

        Dim query As String =
            "SELECT id_instructor, nombres, apellidos " &
            "FROM instructores " &
            "WHERE activo = 1 " &
            "ORDER BY apellidos, nombres"

        Using conn As MySqlConnection = ConexionBD.ObtenerConexion()
            Using cmd As New MySqlCommand(query, conn)

                Try
                    conn.Open()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(tabla)
                    End Using

                Catch ex As MySqlException
                    MessageBox.Show(
                        "Error al cargar los instructores: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                    Return
                End Try

            End Using
        End Using

        ' Agregamos una opción para no asociar instructor
        Dim fila As DataRow = tabla.NewRow()
        fila("id_instructor") = DBNull.Value
        fila("nombres") = "Sin instructor"
        fila("apellidos") = ""
        tabla.Rows.InsertAt(fila, 0)

        cboInstructor.DataSource = tabla
        cboInstructor.DisplayMember = "nombres"
        cboInstructor.ValueMember = "id_instructor"
        cboInstructor.SelectedIndex = 0

    End Sub


    ' =========================================================
    ' GUARDAR USUARIO
    ' =========================================================

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        ' -----------------------------------------
        ' Validar nombre de usuario
        ' -----------------------------------------

        Dim nombreUsuario As String = txtNombreUsuario.Text.Trim()
        Dim contrasena As String = txtContrasena.Text

        If String.IsNullOrWhiteSpace(nombreUsuario) Then

            MessageBox.Show(
                "Ingrese un nombre de usuario.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtNombreUsuario.Focus()
            Return

        End If


        ' -----------------------------------------
        ' Validar contraseña
        ' -----------------------------------------

        If String.IsNullOrWhiteSpace(contrasena) Then

            MessageBox.Show(
                "Ingrese una contraseña.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtContrasena.Focus()
            Return

        End If


        ' -----------------------------------------
        ' Validar longitud mínima
        ' -----------------------------------------

        If contrasena.Length < 6 Then

            MessageBox.Show(
                "La contraseña debe tener al menos 6 caracteres.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtContrasena.Focus()
            Return

        End If


        ' -----------------------------------------
        ' Validar rol
        ' -----------------------------------------

        If cboRol.SelectedIndex = -1 OrElse cboRol.SelectedValue Is Nothing Then

            MessageBox.Show(
                "Seleccione un rol.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            cboRol.Focus()
            Return

        End If


        Try

            Dim idRol As Integer =
                Convert.ToInt32(cboRol.SelectedValue)


            ' -----------------------------------------
            ' Obtener socio seleccionado
            ' -----------------------------------------

            Dim idSocio As Integer? = Nothing

            If cboSocio.SelectedIndex > 0 AndAlso
               cboSocio.SelectedValue IsNot Nothing AndAlso
               Not IsDBNull(cboSocio.SelectedValue) Then

                idSocio = Convert.ToInt32(cboSocio.SelectedValue)

            End If


            ' -----------------------------------------
            ' Obtener instructor seleccionado
            ' -----------------------------------------

            Dim idInstructor As Integer? = Nothing

            If cboInstructor.SelectedIndex > 0 AndAlso
               cboInstructor.SelectedValue IsNot Nothing AndAlso
               Not IsDBNull(cboInstructor.SelectedValue) Then

                idInstructor = Convert.ToInt32(cboInstructor.SelectedValue)

            End If


            ' -----------------------------------------
            ' Registrar usuario
            '
            ' UsuarioDAO se encarga de:
            ' - Generar el salt
            ' - Generar el hash
            ' - Guardar ambos
            ' - Inicializar intentos en 0
            ' - Activar la cuenta
            ' -----------------------------------------

            Dim registrado As Boolean =
                UsuarioDAO.RegistrarUsuario(
                    nombreUsuario,
                    contrasena,
                    idRol,
                    idSocio,
                    idInstructor)


            If registrado Then

                MessageBox.Show(
                    "Usuario registrado correctamente." &
                    Environment.NewLine &
                    Environment.NewLine &
                    "Ya puede iniciar sesión con estas credenciales.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                LimpiarFormulario()

            End If

        Catch ex As Exception

            MessageBox.Show(
                "Ocurrió un error al registrar el usuario:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub


    ' =========================================================
    ' LIMPIAR FORMULARIO
    ' =========================================================

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        LimpiarFormulario()

    End Sub


    Private Sub LimpiarFormulario()

        txtNombreUsuario.Clear()
        txtContrasena.Clear()

        If cboRol.Items.Count > 0 Then
            cboRol.SelectedIndex = -1
        End If

        If cboSocio.Items.Count > 0 Then
            cboSocio.SelectedIndex = 0
        End If

        If cboInstructor.Items.Count > 0 Then
            cboInstructor.SelectedIndex = 0
        End If

        txtNombreUsuario.Focus()

    End Sub


    ' =========================================================
    ' CERRAR
    ' =========================================================

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Me.Close()

    End Sub

End Class