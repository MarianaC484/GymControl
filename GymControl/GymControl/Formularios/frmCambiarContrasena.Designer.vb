<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambiarContrasena
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
        pnlTitulo = New Panel()
        lblTitulo = New Label()
        lblContrasenaActual = New Label()
        txtContrasenaActual = New TextBox()
        lblNuevacontrasena = New Label()
        txtNuevaContrasena = New TextBox()
        lblConfirmarContrasena = New Label()
        txtConfirmarContrasena = New TextBox()
        btnCambiar = New Button()
        btnCancelar = New Button()
        pnlTitulo.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlTitulo
        ' 
        pnlTitulo.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        pnlTitulo.Controls.Add(lblTitulo)
        pnlTitulo.Location = New Point(-3, 1)
        pnlTitulo.Name = "pnlTitulo"
        pnlTitulo.Size = New Size(803, 94)
        pnlTitulo.TabIndex = 0
        ' 
        ' lblTitulo
        ' 
        lblTitulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblTitulo.Location = New Point(280, 39)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(222, 25)
        lblTitulo.TabIndex = 0
        lblTitulo.Text = "CAMBIAR CONTRASEÑA"
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblContrasenaActual
        ' 
        lblContrasenaActual.AutoSize = True
        lblContrasenaActual.Location = New Point(32, 135)
        lblContrasenaActual.Name = "lblContrasenaActual"
        lblContrasenaActual.Size = New Size(156, 25)
        lblContrasenaActual.TabIndex = 1
        lblContrasenaActual.Text = "Contraseña actual:"
        ' 
        ' txtContrasenaActual
        ' 
        txtContrasenaActual.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtContrasenaActual.Location = New Point(224, 132)
        txtContrasenaActual.Name = "txtContrasenaActual"
        txtContrasenaActual.Size = New Size(547, 31)
        txtContrasenaActual.TabIndex = 2
        txtContrasenaActual.UseSystemPasswordChar = True
        ' 
        ' lblNuevacontrasena
        ' 
        lblNuevacontrasena.AutoSize = True
        lblNuevacontrasena.Location = New Point(32, 194)
        lblNuevacontrasena.Name = "lblNuevacontrasena"
        lblNuevacontrasena.Size = New Size(157, 25)
        lblNuevacontrasena.TabIndex = 3
        lblNuevacontrasena.Text = "Nueva contraseña:"
        ' 
        ' txtNuevaContrasena
        ' 
        txtNuevaContrasena.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtNuevaContrasena.Location = New Point(224, 188)
        txtNuevaContrasena.Name = "txtNuevaContrasena"
        txtNuevaContrasena.Size = New Size(547, 31)
        txtNuevaContrasena.TabIndex = 4
        txtNuevaContrasena.UseSystemPasswordChar = True
        ' 
        ' lblConfirmarContrasena
        ' 
        lblConfirmarContrasena.AutoSize = True
        lblConfirmarContrasena.Location = New Point(32, 248)
        lblConfirmarContrasena.Name = "lblConfirmarContrasena"
        lblConfirmarContrasena.Size = New Size(186, 25)
        lblConfirmarContrasena.TabIndex = 5
        lblConfirmarContrasena.Text = "Confirmar contraseña:"
        ' 
        ' txtConfirmarContrasena
        ' 
        txtConfirmarContrasena.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtConfirmarContrasena.Location = New Point(224, 242)
        txtConfirmarContrasena.Name = "txtConfirmarContrasena"
        txtConfirmarContrasena.Size = New Size(547, 31)
        txtConfirmarContrasena.TabIndex = 6
        txtConfirmarContrasena.UseSystemPasswordChar = True
        ' 
        ' btnCambiar
        ' 
        btnCambiar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCambiar.Location = New Point(472, 404)
        btnCambiar.Name = "btnCambiar"
        btnCambiar.Size = New Size(186, 34)
        btnCambiar.TabIndex = 7
        btnCambiar.Text = "Cambiar contraseña"
        btnCambiar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCancelar.Location = New Point(676, 404)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(112, 34)
        btnCancelar.TabIndex = 8
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' frmCambiarContrasena
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnCancelar)
        Controls.Add(btnCambiar)
        Controls.Add(txtConfirmarContrasena)
        Controls.Add(lblConfirmarContrasena)
        Controls.Add(txtNuevaContrasena)
        Controls.Add(lblNuevacontrasena)
        Controls.Add(txtContrasenaActual)
        Controls.Add(lblContrasenaActual)
        Controls.Add(pnlTitulo)
        Name = "frmCambiarContrasena"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmCambiarContrasena"
        pnlTitulo.ResumeLayout(False)
        pnlTitulo.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblContrasenaActual As Label
    Friend WithEvents txtContrasenaActual As TextBox
    Friend WithEvents lblNuevacontrasena As Label
    Friend WithEvents txtNuevaContrasena As TextBox
    Friend WithEvents lblConfirmarContrasena As Label
    Friend WithEvents txtConfirmarContrasena As TextBox
    Friend WithEvents btnCambiar As Button
    Friend WithEvents btnCancelar As Button
End Class
