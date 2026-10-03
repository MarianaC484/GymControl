<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPortalSocios
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
        lblTitulo = New Label()
        lblCedula = New Label()
        txtCedula = New TextBox()
        btnBuscar = New Button()
        lblNombre = New Label()
        lblNombreValor = New Label()
        lblMembresia = New Label()
        lblMembresiaValor = New Label()
        lblVencimiento = New Label()
        lblVencimientoValor = New Label()
        lblEstado = New Label()
        lblEstadoValor = New Label()
        Label4 = New Label()
        dgvPagos = New DataGridView()
        dgvHorarios = New DataGridView()
        btnCerrar = New Button()
        CType(dgvPagos, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvHorarios, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitulo.Location = New Point(12, 18)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(234, 32)
        lblTitulo.TabIndex = 0
        lblTitulo.Text = "PORTAL DE SOCIOS"
        ' 
        ' lblCedula
        ' 
        lblCedula.AutoSize = True
        lblCedula.Location = New Point(29, 76)
        lblCedula.Name = "lblCedula"
        lblCedula.Size = New Size(47, 15)
        lblCedula.TabIndex = 1
        lblCedula.Text = "Cédula:"
        ' 
        ' txtCedula
        ' 
        txtCedula.Location = New Point(100, 68)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(184, 23)
        txtCedula.TabIndex = 2
        ' 
        ' btnBuscar
        ' 
        btnBuscar.Location = New Point(290, 67)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(70, 23)
        btnBuscar.TabIndex = 3
        btnBuscar.Text = "Buscar"
        btnBuscar.UseVisualStyleBackColor = True
        ' 
        ' lblNombre
        ' 
        lblNombre.AutoSize = True
        lblNombre.Location = New Point(29, 115)
        lblNombre.Name = "lblNombre"
        lblNombre.Size = New Size(54, 15)
        lblNombre.TabIndex = 4
        lblNombre.Text = "Nombre:"
        ' 
        ' lblNombreValor
        ' 
        lblNombreValor.AutoSize = True
        lblNombreValor.Location = New Point(127, 115)
        lblNombreValor.Name = "lblNombreValor"
        lblNombreValor.Size = New Size(19, 15)
        lblNombreValor.TabIndex = 5
        lblNombreValor.Text = "—"
        ' 
        ' lblMembresia
        ' 
        lblMembresia.AutoSize = True
        lblMembresia.Location = New Point(29, 147)
        lblMembresia.Name = "lblMembresia"
        lblMembresia.Size = New Size(69, 15)
        lblMembresia.TabIndex = 6
        lblMembresia.Text = "Membresía:"
        ' 
        ' lblMembresiaValor
        ' 
        lblMembresiaValor.AutoSize = True
        lblMembresiaValor.Location = New Point(124, 147)
        lblMembresiaValor.Name = "lblMembresiaValor"
        lblMembresiaValor.Size = New Size(22, 15)
        lblMembresiaValor.TabIndex = 7
        lblMembresiaValor.Text = " —"
        ' 
        ' lblVencimiento
        ' 
        lblVencimiento.AutoSize = True
        lblVencimiento.Location = New Point(29, 186)
        lblVencimiento.Name = "lblVencimiento"
        lblVencimiento.Size = New Size(76, 15)
        lblVencimiento.TabIndex = 8
        lblVencimiento.Text = "Vencimiento:"
        ' 
        ' lblVencimientoValor
        ' 
        lblVencimientoValor.AutoSize = True
        lblVencimientoValor.Location = New Point(127, 186)
        lblVencimientoValor.Name = "lblVencimientoValor"
        lblVencimientoValor.Size = New Size(19, 15)
        lblVencimientoValor.TabIndex = 9
        lblVencimientoValor.Text = "—"
        ' 
        ' lblEstado
        ' 
        lblEstado.AutoSize = True
        lblEstado.Location = New Point(31, 223)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(45, 15)
        lblEstado.TabIndex = 10
        lblEstado.Text = "Estado:"
        ' 
        ' lblEstadoValor
        ' 
        lblEstadoValor.AutoSize = True
        lblEstadoValor.Location = New Point(127, 223)
        lblEstadoValor.Name = "lblEstadoValor"
        lblEstadoValor.Size = New Size(19, 15)
        lblEstadoValor.TabIndex = 11
        lblEstadoValor.Text = "—"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(501, 441)
        Label4.Name = "Label4"
        Label4.Size = New Size(0, 15)
        Label4.TabIndex = 12
        ' 
        ' dgvPagos
        ' 
        dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPagos.Location = New Point(29, 261)
        dgvPagos.Name = "dgvPagos"
        dgvPagos.Size = New Size(430, 200)
        dgvPagos.TabIndex = 13
        ' 
        ' dgvHorarios
        ' 
        dgvHorarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvHorarios.Location = New Point(521, 261)
        dgvHorarios.Name = "dgvHorarios"
        dgvHorarios.Size = New Size(430, 200)
        dgvHorarios.TabIndex = 14
        ' 
        ' btnCerrar
        ' 
        btnCerrar.Location = New Point(895, 476)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(56, 21)
        btnCerrar.TabIndex = 15
        btnCerrar.Text = "Cerrar"
        btnCerrar.UseVisualStyleBackColor = True
        ' 
        ' frmPortalSocios
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(984, 611)
        Controls.Add(btnCerrar)
        Controls.Add(dgvHorarios)
        Controls.Add(dgvPagos)
        Controls.Add(Label4)
        Controls.Add(lblEstadoValor)
        Controls.Add(lblEstado)
        Controls.Add(lblVencimientoValor)
        Controls.Add(lblVencimiento)
        Controls.Add(lblMembresiaValor)
        Controls.Add(lblMembresia)
        Controls.Add(lblNombreValor)
        Controls.Add(lblNombre)
        Controls.Add(btnBuscar)
        Controls.Add(txtCedula)
        Controls.Add(lblCedula)
        Controls.Add(lblTitulo)
        Location = New Point(30, 20)
        Name = "frmPortalSocios"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Portal de Socios"
        CType(dgvPagos, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvHorarios, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblCedula As Label
    Friend WithEvents txtCedula As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblNombreValor As Label
    Friend WithEvents lblMembresia As Label
    Friend WithEvents lblMembresiaValor As Label
    Friend WithEvents lblVencimiento As Label
    Friend WithEvents lblVencimientoValor As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents lblEstadoValor As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvPagos As DataGridView
    Friend WithEvents dgvHorarios As DataGridView
    Friend WithEvents btnCerrar As Button
End Class
