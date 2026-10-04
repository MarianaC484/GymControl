<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        txtUsuario = New TextBox()
        lblUsuario = New Label()
        txtContrasena = New TextBox()
        chkMostrar = New CheckBox()
        lblMensaje = New Label()
        btnIngresar = New Button()
        btnSalir = New Button()
        stsConexion = New StatusStrip()
        lblContrasena = New Label()
        Panel1 = New Panel()
        lblTitulo = New Label()
        picPerfil = New PictureBox()
        Label1 = New Label()
        lblRestablecimientoContrasena = New LinkLabel()
        Panel1.SuspendLayout()
        CType(picPerfil, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtUsuario
        ' 
        txtUsuario.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtUsuario.Location = New Point(34, 252)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(715, 31)
        txtUsuario.TabIndex = 0
        ' 
        ' lblUsuario
        ' 
        lblUsuario.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblUsuario.AutoSize = True
        lblUsuario.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsuario.Location = New Point(34, 223)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(82, 25)
        lblUsuario.TabIndex = 1
        lblUsuario.Text = "Usuario:"
        ' 
        ' txtContrasena
        ' 
        txtContrasena.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtContrasena.Location = New Point(34, 322)
        txtContrasena.Name = "txtContrasena"
        txtContrasena.Size = New Size(715, 31)
        txtContrasena.TabIndex = 2
        txtContrasena.UseSystemPasswordChar = True
        ' 
        ' chkMostrar
        ' 
        chkMostrar.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        chkMostrar.AutoSize = True
        chkMostrar.Location = New Point(34, 376)
        chkMostrar.Name = "chkMostrar"
        chkMostrar.Size = New Size(191, 29)
        chkMostrar.TabIndex = 3
        chkMostrar.Text = "Mostrar contraseña"
        chkMostrar.UseVisualStyleBackColor = True
        ' 
        ' lblMensaje
        ' 
        lblMensaje.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblMensaje.AutoSize = True
        lblMensaje.FlatStyle = FlatStyle.Popup
        lblMensaje.ForeColor = Color.Red
        lblMensaje.Location = New Point(34, 408)
        lblMensaje.Name = "lblMensaje"
        lblMensaje.Size = New Size(0, 25)
        lblMensaje.TabIndex = 4
        lblMensaje.Visible = False
        ' 
        ' btnIngresar
        ' 
        btnIngresar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnIngresar.Location = New Point(91, 452)
        btnIngresar.Name = "btnIngresar"
        btnIngresar.Size = New Size(609, 33)
        btnIngresar.TabIndex = 5
        btnIngresar.Text = "Iniciar Sesión"
        btnIngresar.UseVisualStyleBackColor = True
        ' 
        ' btnSalir
        ' 
        btnSalir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnSalir.Location = New Point(91, 492)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(609, 33)
        btnSalir.TabIndex = 6
        btnSalir.Text = "Salir"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' stsConexion
        ' 
        stsConexion.ImageScalingSize = New Size(24, 24)
        stsConexion.Location = New Point(0, 573)
        stsConexion.Name = "stsConexion"
        stsConexion.Size = New Size(800, 22)
        stsConexion.TabIndex = 7
        ' 
        ' lblContrasena
        ' 
        lblContrasena.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblContrasena.AutoSize = True
        lblContrasena.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblContrasena.Location = New Point(34, 293)
        lblContrasena.Name = "lblContrasena"
        lblContrasena.Size = New Size(113, 25)
        lblContrasena.TabIndex = 8
        lblContrasena.Text = "Contraseña:"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.PaleTurquoise
        Panel1.Controls.Add(lblTitulo)
        Panel1.Controls.Add(picPerfil)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(800, 222)
        Panel1.TabIndex = 9
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitulo.Location = New Point(261, 58)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(276, 60)
        lblTitulo.TabIndex = 2
        lblTitulo.Text = "GymControl"
        ' 
        ' picPerfil
        ' 
        picPerfil.BackColor = Color.Transparent
        picPerfil.Image = CType(resources.GetObject("picPerfil.Image"), Image)
        picPerfil.Location = New Point(34, 47)
        picPerfil.Name = "picPerfil"
        picPerfil.Size = New Size(200, 123)
        picPerfil.SizeMode = PictureBoxSizeMode.Zoom
        picPerfil.TabIndex = 1
        picPerfil.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(261, 132)
        Label1.Name = "Label1"
        Label1.Size = New Size(299, 25)
        Label1.TabIndex = 0
        Label1.Text = "Gimnacio Titán . Sistema de gestión "
        ' 
        ' lblRestablecimientoContrasena
        ' 
        lblRestablecimientoContrasena.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblRestablecimientoContrasena.Location = New Point(141, 528)
        lblRestablecimientoContrasena.Name = "lblRestablecimientoContrasena"
        lblRestablecimientoContrasena.Size = New Size(547, 25)
        lblRestablecimientoContrasena.TabIndex = 10
        lblRestablecimientoContrasena.TabStop = True
        lblRestablecimientoContrasena.Text = "¿Olvidó su contraseña? Solicite el restablecimiento al administrador."
        lblRestablecimientoContrasena.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 595)
        Controls.Add(lblRestablecimientoContrasena)
        Controls.Add(Panel1)
        Controls.Add(lblContrasena)
        Controls.Add(stsConexion)
        Controls.Add(btnSalir)
        Controls.Add(btnIngresar)
        Controls.Add(lblMensaje)
        Controls.Add(chkMostrar)
        Controls.Add(txtContrasena)
        Controls.Add(lblUsuario)
        Controls.Add(txtUsuario)
        Name = "frmLogin"
        Text = "frmLogin"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(picPerfil, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents lblUsuario As Label
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents chkMostrar As CheckBox
    Friend WithEvents lblMensaje As Label
    Friend WithEvents btnIngresar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents stsConexion As StatusStrip
    Friend WithEvents lblContrasena As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents picPerfil As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblRestablecimientoContrasena As LinkLabel
    Friend WithEvents lblTitulo As Label

End Class
