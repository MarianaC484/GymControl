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
        txtUsuario.Location = New Point(24, 151)
        txtUsuario.Margin = New Padding(2, 2, 2, 2)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(502, 23)
        txtUsuario.TabIndex = 0
        ' 
        ' lblUsuario
        ' 
        lblUsuario.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblUsuario.AutoSize = True
        lblUsuario.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsuario.Location = New Point(24, 134)
        lblUsuario.Margin = New Padding(2, 0, 2, 0)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(52, 15)
        lblUsuario.TabIndex = 1
        lblUsuario.Text = "Usuario:"
        ' 
        ' txtContrasena
        ' 
        txtContrasena.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtContrasena.Location = New Point(24, 193)
        txtContrasena.Margin = New Padding(2, 2, 2, 2)
        txtContrasena.Name = "txtContrasena"
        txtContrasena.Size = New Size(502, 23)
        txtContrasena.TabIndex = 2
        txtContrasena.UseSystemPasswordChar = True
        ' 
        ' chkMostrar
        ' 
        chkMostrar.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        chkMostrar.AutoSize = True
        chkMostrar.Location = New Point(31, 215)
        chkMostrar.Margin = New Padding(2, 2, 2, 2)
        chkMostrar.Name = "chkMostrar"
        chkMostrar.Size = New Size(128, 19)
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
        lblMensaje.Location = New Point(24, 245)
        lblMensaje.Margin = New Padding(2, 0, 2, 0)
        lblMensaje.Name = "lblMensaje"
        lblMensaje.Size = New Size(0, 15)
        lblMensaje.TabIndex = 4
        lblMensaje.Visible = False
        ' 
        ' btnIngresar
        ' 
        btnIngresar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnIngresar.Location = New Point(64, 271)
        btnIngresar.Margin = New Padding(2, 2, 2, 2)
        btnIngresar.Name = "btnIngresar"
        btnIngresar.Size = New Size(426, 20)
        btnIngresar.TabIndex = 5
        btnIngresar.Text = "Iniciar Sesión"
        btnIngresar.UseVisualStyleBackColor = True
        ' 
        ' btnSalir
        ' 
        btnSalir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnSalir.Location = New Point(64, 295)
        btnSalir.Margin = New Padding(2, 2, 2, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(426, 20)
        btnSalir.TabIndex = 6
        btnSalir.Text = "Salir"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' stsConexion
        ' 
        stsConexion.ImageScalingSize = New Size(24, 24)
        stsConexion.Location = New Point(0, 335)
        stsConexion.Name = "stsConexion"
        stsConexion.Padding = New Padding(1, 0, 10, 0)
        stsConexion.Size = New Size(560, 22)
        stsConexion.TabIndex = 7
        ' 
        ' lblContrasena
        ' 
        lblContrasena.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblContrasena.AutoSize = True
        lblContrasena.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblContrasena.Location = New Point(24, 176)
        lblContrasena.Margin = New Padding(2, 0, 2, 0)
        lblContrasena.Name = "lblContrasena"
        lblContrasena.Size = New Size(72, 15)
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
        Panel1.Margin = New Padding(2, 2, 2, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(560, 133)
        Panel1.TabIndex = 9
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitulo.Location = New Point(183, 35)
        lblTitulo.Margin = New Padding(2, 0, 2, 0)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(188, 41)
        lblTitulo.TabIndex = 2
        lblTitulo.Text = "GymControl"
        ' 
        ' picPerfil
        ' 
        picPerfil.BackColor = Color.Transparent
        picPerfil.Image = CType(resources.GetObject("picPerfil.Image"), Image)
        picPerfil.Location = New Point(24, 28)
        picPerfil.Margin = New Padding(2, 2, 2, 2)
        picPerfil.Name = "picPerfil"
        picPerfil.Size = New Size(140, 74)
        picPerfil.SizeMode = PictureBoxSizeMode.Zoom
        picPerfil.TabIndex = 1
        picPerfil.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(183, 79)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(199, 15)
        Label1.TabIndex = 0
        Label1.Text = "Gimnacio Titán . Sistema de gestión "
        ' 
        ' lblRestablecimientoContrasena
        ' 
        lblRestablecimientoContrasena.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblRestablecimientoContrasena.Location = New Point(99, 317)
        lblRestablecimientoContrasena.Margin = New Padding(2, 0, 2, 0)
        lblRestablecimientoContrasena.Name = "lblRestablecimientoContrasena"
        lblRestablecimientoContrasena.Size = New Size(383, 15)
        lblRestablecimientoContrasena.TabIndex = 10
        lblRestablecimientoContrasena.TabStop = True
        lblRestablecimientoContrasena.Text = "¿Olvidó su contraseña? Solicite el restablecimiento al administrador."
        lblRestablecimientoContrasena.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(560, 357)
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
        Margin = New Padding(2, 2, 2, 2)
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
