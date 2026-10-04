Public Class frmPrincipal

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    ' ==============================
    ' SOCIOS
    ' ==============================



    Private Sub mnuConsultarSocios_Click(sender As Object, e As EventArgs) Handles mnuConsultarSocios.Click
        Dim formulario As New frmPortalSocios()
        formulario.Show()
    End Sub


    ' ==============================
    ' MEMBRESÍAS
    ' ==============================

    Private Sub mnuGestionarMembresias_Click(sender As Object, e As EventArgs) Handles mnuGestionarMembresias.Click
        Dim formulario As New frmMembresiasPagos()
        formulario.Show()
    End Sub


    ' ==============================
    ' PAGOS
    ' ==============================

    Private Sub mnuRegistrarPagos_Click(sender As Object, e As EventArgs) Handles mnuRegistrarPago.Click
        Dim formulario As New frmMembresiasPagos()
        formulario.Show()
    End Sub


    ' ==============================
    ' HORARIOS
    ' ==============================

    Private Sub mnuGestionarHorarios_Click(sender As Object, e As EventArgs) Handles mnuGestionarHorarios.Click
        Dim formulario As New FrmHorarios()
        formulario.Show()
    End Sub


    ' ==============================
    ' TIPOS DE MEMBRESÍA
    ' ==============================

    Private Sub mnuTiposMembresia_Click(sender As Object, e As EventArgs) Handles mnuTiposMembresia.Click
        MessageBox.Show(
            "El formulario de Tipos de Membresía todavía no está disponible.",
            "Módulo pendiente",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub


    ' ==============================
    ' HISTORIAL DE PAGOS
    ' ==============================

    Private Sub mnuHistorialPagos_Click(sender As Object, e As EventArgs) Handles mnuHistorialPagos.Click
        MessageBox.Show(
            "El formulario de Historial de Pagos todavía no está disponible.",
            "Módulo pendiente",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub


    ' ==============================
    ' ACTIVIDADES
    ' ==============================

    Private Sub mnuActividades_Click(sender As Object, e As EventArgs) Handles mnuActividades.Click
        MessageBox.Show(
            "El formulario de Actividades todavía no está disponible.",
            "Módulo pendiente",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub


    ' ==============================
    ' INSTRUCTORES
    ' ==============================

    Private Sub mnuInstructores_Click(sender As Object, e As EventArgs) Handles mnuInstructores.Click
        MessageBox.Show(
            "El formulario de Instructores todavía no está disponible.",
            "Módulo pendiente",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub


    ' ==============================
    ' SALAS
    ' ==============================

    Private Sub mnuSalas_Click(sender As Object, e As EventArgs) Handles mnuSalas.Click
        MessageBox.Show(
            "El formulario de Salas todavía no está disponible.",
            "Módulo pendiente",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub


    Private Sub mnuBitacora_Click(sender As Object, e As EventArgs) Handles mnuBitacora.Click
        MessageBox.Show(
            "El formulario de Bitácora todavía no está disponible.",
            "Módulo pendiente",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub

    Private Sub mnuCambiarContrasena_Click(sender As Object, e As EventArgs) Handles mnuCambiarContrasena.Click
        MessageBox.Show(
            "El cambio de contraseña todavía no está disponible.",
            "Módulo pendiente",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub


    ' ==============================
    ' CERRAR SESIÓN
    ' ==============================

    Private Sub mnuCerrarSesion_Click(sender As Object, e As EventArgs) Handles mnuCerrarSesion.Click
        Dim respuesta As DialogResult = MessageBox.Show(
            "¿Desea cerrar la sesión actual?",
            "Cerrar sesión",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If respuesta = DialogResult.Yes Then
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub


    ' ==============================
    ' SALIR
    ' ==============================

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Application.Exit()
    End Sub

    Private Sub mnuGestionarSocios_Click(sender As Object, e As EventArgs) Handles mnuGestionarSocios.Click
        Dim formulario As New frmSocios()
        formulario.Show()
    End Sub

    Private Sub mnuUsuarios_Click(sender As Object, e As EventArgs) Handles mnuUsuarios.Click

        Dim formulario As New frmUsuarios()
        formulario.ShowDialog()

    End Sub
End Class

