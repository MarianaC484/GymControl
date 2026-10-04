<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        menuPrincipal = New MenuStrip()
        mnuSocios = New ToolStripMenuItem()
        mnuGestionarSocios = New ToolStripMenuItem()
        mnuConsultarSocios = New ToolStripMenuItem()
        mnuMembresias = New ToolStripMenuItem()
        mnuGestionarMembresias = New ToolStripMenuItem()
        mnuTiposMembresia = New ToolStripMenuItem()
        mnuPagos = New ToolStripMenuItem()
        mnuRegistrarPago = New ToolStripMenuItem()
        mnuHistorialPagos = New ToolStripMenuItem()
        mnuHorarios = New ToolStripMenuItem()
        mnuGestionarHorarios = New ToolStripMenuItem()
        mnuActividades = New ToolStripMenuItem()
        mnuInstructores = New ToolStripMenuItem()
        mnuSalas = New ToolStripMenuItem()
        mnuSistema = New ToolStripMenuItem()
        mnuUsuarios = New ToolStripMenuItem()
        mnuBitacora = New ToolStripMenuItem()
        mnuCambiarContrasena = New ToolStripMenuItem()
        mnuCerrarSesion = New ToolStripMenuItem()
        mnuSalir = New ToolStripMenuItem()
        stsPrincipal = New StatusStrip()
        lblUsuario = New ToolStripStatusLabel()
        lblRol = New ToolStripStatusLabel()
        pnlContenido = New Panel()
        lblBienvenida = New Label()
        menuPrincipal.SuspendLayout()
        stsPrincipal.SuspendLayout()
        pnlContenido.SuspendLayout()
        SuspendLayout()
        ' 
        ' menuPrincipal
        ' 
        menuPrincipal.ImageScalingSize = New Size(24, 24)
        menuPrincipal.Items.AddRange(New ToolStripItem() {mnuSocios, mnuMembresias, mnuPagos, mnuHorarios, mnuSistema})
        menuPrincipal.Location = New Point(0, 0)
        menuPrincipal.Name = "menuPrincipal"
        menuPrincipal.Padding = New Padding(9, 3, 0, 3)
        menuPrincipal.Size = New Size(1143, 35)
        menuPrincipal.TabIndex = 0
        menuPrincipal.Text = "MenuStrip1"
        ' 
        ' mnuSocios
        ' 
        mnuSocios.DropDownItems.AddRange(New ToolStripItem() {mnuGestionarSocios, mnuConsultarSocios})
        mnuSocios.Name = "mnuSocios"
        mnuSocios.Size = New Size(80, 29)
        mnuSocios.Text = "Socios"
        ' 
        ' mnuGestionarSocios
        ' 
        mnuGestionarSocios.Name = "mnuGestionarSocios"
        mnuGestionarSocios.Size = New Size(270, 34)
        mnuGestionarSocios.Text = "Gestionar socios"
        ' 
        ' mnuConsultarSocios
        ' 
        mnuConsultarSocios.Name = "mnuConsultarSocios"
        mnuConsultarSocios.Size = New Size(270, 34)
        mnuConsultarSocios.Text = "Consultar socios"
        ' 
        ' mnuMembresias
        ' 
        mnuMembresias.DropDownItems.AddRange(New ToolStripItem() {mnuGestionarMembresias, mnuTiposMembresia})
        mnuMembresias.Name = "mnuMembresias"
        mnuMembresias.Size = New Size(124, 29)
        mnuMembresias.Text = "Membresías"
        ' 
        ' mnuGestionarMembresias
        ' 
        mnuGestionarMembresias.Name = "mnuGestionarMembresias"
        mnuGestionarMembresias.Size = New Size(295, 34)
        mnuGestionarMembresias.Text = " Gestionar membresías"
        ' 
        ' mnuTiposMembresia
        ' 
        mnuTiposMembresia.Name = "mnuTiposMembresia"
        mnuTiposMembresia.Size = New Size(295, 34)
        mnuTiposMembresia.Text = "Tipos de membresía"
        ' 
        ' mnuPagos
        ' 
        mnuPagos.DropDownItems.AddRange(New ToolStripItem() {mnuRegistrarPago, mnuHistorialPagos})
        mnuPagos.Name = "mnuPagos"
        mnuPagos.Size = New Size(76, 29)
        mnuPagos.Text = "Pagos"
        ' 
        ' mnuRegistrarPago
        ' 
        mnuRegistrarPago.Name = "mnuRegistrarPago"
        mnuRegistrarPago.Size = New Size(259, 34)
        mnuRegistrarPago.Text = "Registrar pagos"
        ' 
        ' mnuHistorialPagos
        ' 
        mnuHistorialPagos.Name = "mnuHistorialPagos"
        mnuHistorialPagos.Size = New Size(259, 34)
        mnuHistorialPagos.Text = "Historial de pagos"
        ' 
        ' mnuHorarios
        ' 
        mnuHorarios.DropDownItems.AddRange(New ToolStripItem() {mnuGestionarHorarios, mnuActividades, mnuInstructores, mnuSalas})
        mnuHorarios.Name = "mnuHorarios"
        mnuHorarios.Size = New Size(96, 29)
        mnuHorarios.Text = "Horarios"
        ' 
        ' mnuGestionarHorarios
        ' 
        mnuGestionarHorarios.Name = "mnuGestionarHorarios"
        mnuGestionarHorarios.Size = New Size(259, 34)
        mnuGestionarHorarios.Text = "Gestionar horarios"
        ' 
        ' mnuActividades
        ' 
        mnuActividades.Name = "mnuActividades"
        mnuActividades.Size = New Size(259, 34)
        mnuActividades.Text = "Actividades"
        ' 
        ' mnuInstructores
        ' 
        mnuInstructores.Name = "mnuInstructores"
        mnuInstructores.Size = New Size(259, 34)
        mnuInstructores.Text = "Instructores"
        ' 
        ' mnuSalas
        ' 
        mnuSalas.Name = "mnuSalas"
        mnuSalas.Size = New Size(259, 34)
        mnuSalas.Text = "Salas"
        ' 
        ' mnuSistema
        ' 
        mnuSistema.DropDownItems.AddRange(New ToolStripItem() {mnuUsuarios, mnuBitacora, mnuCambiarContrasena, mnuCerrarSesion, mnuSalir})
        mnuSistema.Name = "mnuSistema"
        mnuSistema.Size = New Size(90, 29)
        mnuSistema.Text = "Sistema"
        ' 
        ' mnuUsuarios
        ' 
        mnuUsuarios.Name = "mnuUsuarios"
        mnuUsuarios.Size = New Size(271, 34)
        mnuUsuarios.Text = "Usuarios"
        ' 
        ' mnuBitacora
        ' 
        mnuBitacora.Name = "mnuBitacora"
        mnuBitacora.Size = New Size(271, 34)
        mnuBitacora.Text = "Bitácora"
        ' 
        ' mnuCambiarContrasena
        ' 
        mnuCambiarContrasena.Name = "mnuCambiarContrasena"
        mnuCambiarContrasena.Size = New Size(271, 34)
        mnuCambiarContrasena.Text = "Cambiar contraseña"
        ' 
        ' mnuCerrarSesion
        ' 
        mnuCerrarSesion.Name = "mnuCerrarSesion"
        mnuCerrarSesion.Size = New Size(271, 34)
        mnuCerrarSesion.Text = "Cerrar sesión "
        ' 
        ' mnuSalir
        ' 
        mnuSalir.Name = "mnuSalir"
        mnuSalir.Size = New Size(271, 34)
        mnuSalir.Text = "Salir"
        ' 
        ' stsPrincipal
        ' 
        stsPrincipal.ImageScalingSize = New Size(24, 24)
        stsPrincipal.Items.AddRange(New ToolStripItem() {lblUsuario, lblRol})
        stsPrincipal.Location = New Point(0, 718)
        stsPrincipal.Name = "stsPrincipal"
        stsPrincipal.Padding = New Padding(1, 0, 20, 0)
        stsPrincipal.Size = New Size(1143, 32)
        stsPrincipal.TabIndex = 1
        stsPrincipal.Text = "StatusStrip1"
        ' 
        ' lblUsuario
        ' 
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(76, 25)
        lblUsuario.Text = "Usuario:"
        ' 
        ' lblRol
        ' 
        lblRol.Name = "lblRol"
        lblRol.Size = New Size(41, 25)
        lblRol.Text = "Rol:"
        ' 
        ' pnlContenido
        ' 
        pnlContenido.Controls.Add(lblBienvenida)
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(0, 35)
        pnlContenido.Margin = New Padding(4, 5, 4, 5)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Size = New Size(1143, 683)
        pnlContenido.TabIndex = 2
        ' 
        ' lblBienvenida
        ' 
        lblBienvenida.AutoSize = True
        lblBienvenida.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblBienvenida.Location = New Point(326, 32)
        lblBienvenida.Margin = New Padding(4, 0, 4, 0)
        lblBienvenida.Name = "lblBienvenida"
        lblBienvenida.Size = New Size(424, 48)
        lblBienvenida.TabIndex = 3
        lblBienvenida.Text = "Bienvenido a GymControl"
        ' 
        ' frmPrincipal
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1143, 750)
        Controls.Add(pnlContenido)
        Controls.Add(stsPrincipal)
        Controls.Add(menuPrincipal)
        MainMenuStrip = menuPrincipal
        Margin = New Padding(4, 5, 4, 5)
        Name = "frmPrincipal"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GymControl - Sistema de Gestión"
        WindowState = FormWindowState.Maximized
        menuPrincipal.ResumeLayout(False)
        menuPrincipal.PerformLayout()
        stsPrincipal.ResumeLayout(False)
        stsPrincipal.PerformLayout()
        pnlContenido.ResumeLayout(False)
        pnlContenido.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents menuPrincipal As MenuStrip
    Friend WithEvents stsPrincipal As StatusStrip
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents lblBienvenida As Label
    Friend WithEvents mnuSocios As ToolStripMenuItem
    Friend WithEvents mnuMembresias As ToolStripMenuItem
    Friend WithEvents mnuPagos As ToolStripMenuItem
    Friend WithEvents mnuHorarios As ToolStripMenuItem
    Friend WithEvents mnuSistema As ToolStripMenuItem
    Friend WithEvents lblUsuario As ToolStripStatusLabel
    Friend WithEvents lblRol As ToolStripStatusLabel
    Friend WithEvents mnuGestionarSocios As ToolStripMenuItem
    Friend WithEvents mnuConsultarSocios As ToolStripMenuItem
    Friend WithEvents mnuGestionarMembresias As ToolStripMenuItem
    Friend WithEvents mnuTiposMembresia As ToolStripMenuItem
    Friend WithEvents mnuRegistrarPago As ToolStripMenuItem
    Friend WithEvents mnuHistorialPagos As ToolStripMenuItem
    Friend WithEvents mnuGestionarHorarios As ToolStripMenuItem
    Friend WithEvents mnuActividades As ToolStripMenuItem
    Friend WithEvents mnuInstructores As ToolStripMenuItem
    Friend WithEvents mnuSalas As ToolStripMenuItem
    Friend WithEvents mnuUsuarios As ToolStripMenuItem
    Friend WithEvents mnuBitacora As ToolStripMenuItem
    Friend WithEvents mnuCambiarContrasena As ToolStripMenuItem
    Friend WithEvents mnuCerrarSesion As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
End Class
