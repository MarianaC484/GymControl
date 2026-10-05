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

    Private Sub mnuTiposMembresia_Click(
    sender As Object,
    e As EventArgs
) Handles mnuTiposMembresia.Click

        Dim formulario As New FrmTipoDeMembresia()

        formulario.Show()

    End Sub

    ' ==============================
    ' ACTIVIDADES
    ' ==============================

    Private Sub mnuActividades_Click(sender As Object, e As EventArgs) Handles mnuActividades.Click

        Dim formulario As New FrmActividad()
        formulario.Show()

    End Sub


    ' ==============================
    ' INSTRUCTORES
    ' ==============================

    Private Sub mnuInstructores_Click(sender As Object, e As EventArgs) Handles mnuInstructores.Click

        Dim formulario As New FrmInstructores()
        formulario.Show()

    End Sub


    Private Sub mnuBitacora_Click(sender As Object, e As EventArgs) Handles mnuBitacora.Click

        Dim formulario As New frmBitacora()
        formulario.ShowDialog()

    End Sub

    Private Sub mnuCambiarContrasena_Click(sender As Object, e As EventArgs) Handles mnuCambiarContrasena.Click

        Dim formulario As New frmCambiarContrasena()
        formulario.ShowDialog()

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

    Private Sub mnuSalas_Click(sender As Object, e As EventArgs) Handles mnuSalas.Click

        Dim formulario As New frmSalas()
        formulario.ShowDialog()

    End Sub


    Private Sub mnuCerrarSesion_Click(
    sender As Object,
    e As EventArgs
) Handles mnuCerrarSesion.Click

        Dim respuesta As DialogResult =
            MessageBox.Show(
                "¿Desea cerrar la sesión actual?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

        If respuesta = DialogResult.Yes Then

            Sesion.CerrarSesion()

            Dim login As New frmLogin()
            login.Show()

            Me.Close()

        End If

    End Sub

End Class

