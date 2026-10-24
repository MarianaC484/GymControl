<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
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
        lblNombreUsuario = New Label()
        txtNombreUsuario = New TextBox()
        lblContrasena = New Label()
        txtContrasena = New TextBox()
        lblRol = New Label()
        cboRol = New ComboBox()
        lblSocio = New Label()
        cboSocio = New ComboBox()
        lblInstructor = New Label()
        cboInstructor = New ComboBox()
        btnGuardar = New Button()
        btnCerrar = New Button()
        btnLimpiar = New Button()
        lblTitulo = New Button()
        pnlTitulo = New Panel()
        pnlTitulo.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblNombreUsuario
        ' 
        lblNombreUsuario.AutoSize = True
        lblNombreUsuario.Location = New Point(27, 138)
        lblNombreUsuario.Name = "lblNombreUsuario"
        lblNombreUsuario.Size = New Size(170, 25)
        lblNombreUsuario.TabIndex = 0
        lblNombreUsuario.Text = "Nombre del usuario"
        ' 
        ' txtNombreUsuario
        ' 
        txtNombreUsuario.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtNombreUsuario.Location = New Point(27, 166)
        txtNombreUsuario.Name = "txtNombreUsuario"
        txtNombreUsuario.Size = New Size(714, 31)
        txtNombreUsuario.TabIndex = 1
        ' 
        ' lblContrasena
        ' 
        lblContrasena.AutoSize = True
        lblContrasena.Location = New Point(27, 225)
        lblContrasena.Name = "lblContrasena"
        lblContrasena.Size = New Size(101, 25)
        lblContrasena.TabIndex = 2
        lblContrasena.Text = "Contraseña"
        ' 
        ' txtContrasena
        ' 
        txtContrasena.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtContrasena.Location = New Point(27, 253)
        txtContrasena.Name = "txtContrasena"
        txtContrasena.Size = New Size(714, 31)
        txtContrasena.TabIndex = 3
        txtContrasena.UseSystemPasswordChar = True
        ' 
        ' lblRol
        ' 
        lblRol.AutoSize = True
        lblRol.Location = New Point(27, 319)
        lblRol.Name = "lblRol"
        lblRol.Size = New Size(37, 25)
        lblRol.TabIndex = 4
        lblRol.Text = "Rol"
        ' 
        ' cboRol
        ' 
        cboRol.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cboRol.FormattingEnabled = True
        cboRol.Location = New Point(27, 347)
        cboRol.Name = "cboRol"
        cboRol.Size = New Size(714, 33)
        cboRol.TabIndex = 5
        ' 
        ' lblSocio
        ' 
        lblSocio.AutoSize = True
        lblSocio.Location = New Point(27, 408)
        lblSocio.Name = "lblSocio"
        lblSocio.Size = New Size(56, 25)
        lblSocio.TabIndex = 6
        lblSocio.Text = "Socio"
        ' 
        ' cboSocio
        ' 
        cboSocio.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cboSocio.FormattingEnabled = True
        cboSocio.Location = New Point(27, 436)
        cboSocio.Name = "cboSocio"
        cboSocio.Size = New Size(714, 33)
        cboSocio.TabIndex = 7
        ' 
        ' lblInstructor
        ' 
        lblInstructor.AutoSize = True
        lblInstructor.Location = New Point(27, 493)
        lblInstructor.Name = "lblInstructor"
        lblInstructor.Size = New Size(88, 25)
        lblInstructor.TabIndex = 8
        lblInstructor.Text = "Instructor"
        ' 
        ' cboInstructor
        ' 
        cboInstructor.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cboInstructor.FormattingEnabled = True
        cboInstructor.Location = New Point(27, 521)
        cboInstructor.Name = "cboInstructor"
        cboInstructor.Size = New Size(714, 33)
        cboInstructor.TabIndex = 9
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnGuardar.Location = New Point(412, 659)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(112, 34)
        btnGuardar.TabIndex = 10
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnCerrar
        ' 
        btnCerrar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCerrar.Location = New Point(676, 659)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(112, 34)
        btnCerrar.TabIndex = 11
        btnCerrar.Text = "Cerrar"
        btnCerrar.UseVisualStyleBackColor = True
        ' 
        ' btnLimpiar
        ' 
        btnLimpiar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnLimpiar.Location = New Point(544, 659)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(112, 34)
        btnLimpiar.TabIndex = 12
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' lblTitulo
        ' 
        lblTitulo.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        lblTitulo.Dock = DockStyle.Fill
        lblTitulo.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblTitulo.Location = New Point(0, 0)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(800, 114)
        lblTitulo.TabIndex = 14
        lblTitulo.Text = "GESTION DE USUARIOS"
        lblTitulo.UseVisualStyleBackColor = False
        ' 
        ' pnlTitulo
        ' 
        pnlTitulo.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        pnlTitulo.Controls.Add(lblTitulo)
        pnlTitulo.Dock = DockStyle.Top
        pnlTitulo.Location = New Point(0, 0)
        pnlTitulo.Name = "pnlTitulo"
        pnlTitulo.Size = New Size(800, 114)
        pnlTitulo.TabIndex = 13
        ' 
        ' frmUsuarios
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 705)
        Controls.Add(pnlTitulo)
        Controls.Add(btnLimpiar)
        Controls.Add(btnCerrar)
        Controls.Add(btnGuardar)
        Controls.Add(cboInstructor)
        Controls.Add(lblInstructor)
        Controls.Add(cboSocio)
        Controls.Add(lblSocio)
        Controls.Add(cboRol)
        Controls.Add(lblRol)
        Controls.Add(txtContrasena)
        Controls.Add(lblContrasena)
        Controls.Add(txtNombreUsuario)
        Controls.Add(lblNombreUsuario)
        Name = "frmUsuarios"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmUsuarios"
        pnlTitulo.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblNombreUsuario As Label
    Friend WithEvents txtNombreUsuario As TextBox
    Friend WithEvents lblContrasena As Label
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents lblRol As Label
    Friend WithEvents cboRol As ComboBox
    Friend WithEvents lblSocio As Label
    Friend WithEvents cboSocio As ComboBox
    Friend WithEvents lblInstructor As Label
    Friend WithEvents cboInstructor As ComboBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents lblTitulo As Button
    Friend WithEvents pnlTitulo As Panel
End Class
