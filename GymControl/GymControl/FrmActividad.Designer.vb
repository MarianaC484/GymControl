<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmActividad
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
        lblNombre = New Label()
        txtNombre = New TextBox()
        lblDescripcion = New Label()
        txtDescripcion = New TextBox()
        lblDuracion = New Label()
        nudDuracion = New NumericUpDown()
        lblCupo = New Label()
        nudCupo = New NumericUpDown()
        lblBuscar = New Label()
        txtBuscar = New TextBox()
        btnBuscar = New Button()
        btnLimpiar = New Button()
        dgvActividades = New DataGridView()
        lblEstado = New Label()
        lblEstadoValor = New Label()
        lblActividades = New Label()
        CType(nudDuracion, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudCupo, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvActividades, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitulo.Location = New Point(28, 29)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(205, 25)
        lblTitulo.TabIndex = 0
        lblTitulo.Text = "Gestón de actividades"
        ' 
        ' lblNombre
        ' 
        lblNombre.AutoSize = True
        lblNombre.Location = New Point(28, 89)
        lblNombre.Name = "lblNombre"
        lblNombre.Size = New Size(54, 15)
        lblNombre.TabIndex = 1
        lblNombre.Text = "Nombre:"
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(116, 86)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(247, 23)
        txtNombre.TabIndex = 2
        ' 
        ' lblDescripcion
        ' 
        lblDescripcion.AutoSize = True
        lblDescripcion.Location = New Point(28, 136)
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.Size = New Size(72, 15)
        lblDescripcion.TabIndex = 3
        lblDescripcion.Text = "Descripción:"
        ' 
        ' txtDescripcion
        ' 
        txtDescripcion.Location = New Point(116, 128)
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.Size = New Size(247, 23)
        txtDescripcion.TabIndex = 4
        ' 
        ' lblDuracion
        ' 
        lblDuracion.AutoSize = True
        lblDuracion.Location = New Point(28, 180)
        lblDuracion.Name = "lblDuracion"
        lblDuracion.Size = New Size(90, 15)
        lblDuracion.TabIndex = 5
        lblDuracion.Text = "Duración (min):"
        ' 
        ' nudDuracion
        ' 
        nudDuracion.Location = New Point(124, 180)
        nudDuracion.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        nudDuracion.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudDuracion.Name = "nudDuracion"
        nudDuracion.Size = New Size(109, 23)
        nudDuracion.TabIndex = 6
        nudDuracion.Value = New Decimal(New Integer() {60, 0, 0, 0})
        ' 
        ' lblCupo
        ' 
        lblCupo.AutoSize = True
        lblCupo.Location = New Point(28, 224)
        lblCupo.Name = "lblCupo"
        lblCupo.Size = New Size(85, 15)
        lblCupo.TabIndex = 7
        lblCupo.Text = "Cupo máximo:"
        ' 
        ' nudCupo
        ' 
        nudCupo.Location = New Point(124, 222)
        nudCupo.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        nudCupo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudCupo.Name = "nudCupo"
        nudCupo.Size = New Size(109, 23)
        nudCupo.TabIndex = 8
        nudCupo.Value = New Decimal(New Integer() {20, 0, 0, 0})
        ' 
        ' lblBuscar
        ' 
        lblBuscar.AutoSize = True
        lblBuscar.Location = New Point(28, 316)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New Size(45, 15)
        lblBuscar.TabIndex = 9
        lblBuscar.Text = "Buscar:"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(79, 308)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(284, 23)
        txtBuscar.TabIndex = 10
        ' 
        ' btnBuscar
        ' 
        btnBuscar.Location = New Point(369, 308)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(84, 21)
        btnBuscar.TabIndex = 11
        btnBuscar.Text = "Buscar"
        btnBuscar.UseVisualStyleBackColor = True
        ' 
        ' btnLimpiar
        ' 
        btnLimpiar.Location = New Point(459, 308)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(84, 21)
        btnLimpiar.TabIndex = 12
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' dgvActividades
        ' 
        dgvActividades.AllowUserToAddRows = False
        dgvActividades.AllowUserToDeleteRows = False
        dgvActividades.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvActividades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvActividades.Location = New Point(591, 61)
        dgvActividades.MultiSelect = False
        dgvActividades.Name = "dgvActividades"
        dgvActividades.ReadOnly = True
        dgvActividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvActividades.Size = New Size(350, 317)
        dgvActividades.TabIndex = 13
        ' 
        ' lblEstado
        ' 
        lblEstado.AutoSize = True
        lblEstado.Location = New Point(28, 273)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(45, 15)
        lblEstado.TabIndex = 14
        lblEstado.Text = "Estado:"
        ' 
        ' lblEstadoValor
        ' 
        lblEstadoValor.AutoSize = True
        lblEstadoValor.Location = New Point(124, 273)
        lblEstadoValor.Name = "lblEstadoValor"
        lblEstadoValor.Size = New Size(12, 15)
        lblEstadoValor.TabIndex = 15
        lblEstadoValor.Text = "-"
        ' 
        ' lblActividades
        ' 
        lblActividades.AutoSize = True
        lblActividades.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblActividades.Location = New Point(591, 29)
        lblActividades.Name = "lblActividades"
        lblActividades.Size = New Size(113, 25)
        lblActividades.TabIndex = 17
        lblActividades.Text = "Actividades"
        ' 
        ' FrmActividad
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(991, 450)
        Controls.Add(lblActividades)
        Controls.Add(lblEstadoValor)
        Controls.Add(lblEstado)
        Controls.Add(dgvActividades)
        Controls.Add(btnLimpiar)
        Controls.Add(btnBuscar)
        Controls.Add(txtBuscar)
        Controls.Add(lblBuscar)
        Controls.Add(nudCupo)
        Controls.Add(lblCupo)
        Controls.Add(nudDuracion)
        Controls.Add(lblDuracion)
        Controls.Add(txtDescripcion)
        Controls.Add(lblDescripcion)
        Controls.Add(txtNombre)
        Controls.Add(lblNombre)
        Controls.Add(lblTitulo)
        Name = "FrmActividad"
        Text = "FrmActividad"
        CType(nudDuracion, ComponentModel.ISupportInitialize).EndInit()
        CType(nudCupo, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvActividades, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents lblDuracion As Label
    Friend WithEvents nudDuracion As NumericUpDown
    Friend WithEvents lblCupo As Label
    Friend WithEvents nudCupo As NumericUpDown
    Friend WithEvents lblBuscar As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents dgvActividades As DataGridView
    Friend WithEvents lblEstado As Label
    Friend WithEvents lblEstadoValor As Label
    Friend WithEvents lblActividades As Label
End Class
