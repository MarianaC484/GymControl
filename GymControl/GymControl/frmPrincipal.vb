Imports GymControl.Seguridad

Public Class frmPrincipal

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Mostrar información de la sesión actual
        lblBienvenida.Text = "Bienvenido/a, " & Sesion.NombreUsuario

        lblUsuario.Text = "Usuario: " & Sesion.NombreUsuario
        lblRol.Text = "Rol: " & ObtenerNombreRol(Sesion.Rol)

        ' Formulario principal maximizado
        Me.WindowState = FormWindowState.Maximized

        ' El panel ocupa el espacio disponible
        pnlContenido.Dock = DockStyle.Fill

    End Sub


    ' ==========================================
    ' CONVERTIR ID DEL ROL A NOMBRE
    ' ==========================================
    Private Function ObtenerNombreRol(idRol As String) As String

        Select Case idRol

            Case "1"
                Return "Administrador"

            Case "2"
                Return "Recepcionista"

            Case "3"
                Return "Instructor"

            Case Else
                Return "Usuario"

        End Select

    End Function


    ' ==========================================
    ' SOCIOS - GESTIONAR
    ' ==========================================
    Private Sub mnuGestionarSocios_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuGestionarSocios.Click

        Dim formulario As New frmSocios()

        formulario.ShowDialog()

    End Sub


    ' ==========================================
    ' SOCIOS - CONSULTAR
    ' ==========================================
    Private Sub mnuConsultarSocios_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuConsultarSocios.Click

        Dim formulario As New frmSocios()

        formulario.ShowDialog()

    End Sub


    ' ==========================================
    ' MEMBRESÍAS - GESTIONAR
    ' ==========================================
    Private Sub mnuGestionarMembresias_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuGestionarMembresias.Click

        MessageBox.Show(
            "El módulo de Membresías estará disponible próximamente.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    ' ==========================================
    ' TIPOS DE MEMBRESÍA
    ' ==========================================
    Private Sub mnuTiposMembresia_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuTiposMembresia.Click

        MessageBox.Show(
            "El módulo de Tipos de Membresía estará disponible próximamente.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    ' ==========================================
    ' PAGOS - REGISTRAR
    ' ==========================================
    Private Sub mnuRegistrarPago_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuRegistrarPago.Click

        MessageBox.Show(
            "El módulo de Pagos estará disponible próximamente.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    ' ==========================================
    ' PAGOS - HISTORIAL
    ' ==========================================
    Private Sub mnuHistorialPagos_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuHistorialPagos.Click

        MessageBox.Show(
            "El historial de pagos estará disponible próximamente.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    ' ==========================================
    ' HORARIOS - GESTIONAR
    ' ==========================================
    Private Sub mnuGestionarHorarios_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuGestionarHorarios.Click

        MessageBox.Show(
            "El módulo de Horarios estará disponible próximamente.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    ' ==========================================
    ' ACTIVIDADES
    ' ==========================================
    Private Sub mnuActividades_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuActividades.Click

        MessageBox.Show(
            "El módulo de Actividades estará disponible próximamente.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    ' ==========================================
    ' INSTRUCTORES
    ' ==========================================
    Private Sub mnuInstructores_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuInstructores.Click

        MessageBox.Show(
            "El módulo de Instructores estará disponible próximamente.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    ' ==========================================
    ' SALAS
    ' ==========================================
    Private Sub mnuSalas_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuSalas.Click

        MessageBox.Show(
            "El módulo de Salas estará disponible próximamente.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    ' ==========================================
    ' USUARIOS
    ' ==========================================
    Private Sub mnuUsuarios_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuUsuarios.Click

        MessageBox.Show(
            "El módulo de Usuarios estará disponible próximamente.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    ' ==========================================
    ' BITÁCORA
    ' ==========================================
    Private Sub mnuBitacora_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuBitacora.Click

        MessageBox.Show(
            "El módulo de Bitácora estará disponible próximamente.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    ' ==========================================
    ' CAMBIAR CONTRASEÑA
    ' ==========================================
    Private Sub mnuCambiarContrasena_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuCambiarContrasena.Click

        MessageBox.Show(
            "El cambio de contraseña estará disponible próximamente.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    ' ==========================================
    ' CERRAR SESIÓN
    ' ==========================================
    Private Sub mnuCerrarSesion_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuCerrarSesion.Click

        Dim respuesta As DialogResult = MessageBox.Show(
            "¿Está seguro de que desea cerrar la sesión?",
            "Cerrar sesión",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If respuesta = DialogResult.Yes Then

            Sesion.UsuarioId = 0
            Sesion.NombreUsuario = ""
            Sesion.Rol = ""

            Me.Hide()

            Dim login As New frmLogin()
            login.ShowDialog()

            Me.Close()

        End If

    End Sub


    ' ==========================================
    ' SALIR DEL SISTEMA
    ' ==========================================
    Private Sub mnuSalir_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuSalir.Click

        Dim respuesta As DialogResult = MessageBox.Show(
            "¿Está seguro de que desea salir de GymControl?",
            "Salir",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If respuesta = DialogResult.Yes Then
            Application.Exit()
        End If

    End Sub

End Class