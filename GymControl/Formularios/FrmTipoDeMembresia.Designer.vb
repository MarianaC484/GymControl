<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTipoDeMembresia
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
        components = New ComponentModel.Container()
        lblTitulo = New Label()
        txtBuscar = New TextBox()
        lblBuscar = New Label()
        dgvTiposMembresia = New DataGridView()
        grpDatos = New GroupBox()
        chkActivo = New CheckBox()
        chkIncluyeClases = New CheckBox()
        txtDescripcion = New TextBox()
        txtNombre = New TextBox()
        nudPrecio = New NumericUpDown()
        lblIncluyeClases = New Label()
        lblPrecio = New Label()
        lblDescripcion = New Label()
        lblNombre = New Label()
        bsTiposMembresia = New BindingSource(components)
        btnNuevo = New Button()
        btnGuardar = New Button()
        btnEditar = New Button()
        btnEliminar = New Button()
        btnCancelar = New Button()
        nudDuracion = New NumericUpDown()
        lblDuracion = New Label()
        CType(dgvTiposMembresia, ComponentModel.ISupportInitialize).BeginInit()
        grpDatos.SuspendLayout()
        CType(nudPrecio, ComponentModel.ISupportInitialize).BeginInit()
        CType(bsTiposMembresia, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudDuracion, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Location = New Point(27, 22)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(173, 15)
        lblTitulo.TabIndex = 0
        lblTitulo.Text = "Gestión de Tipos de Membresía"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(78, 57)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(332, 23)
        txtBuscar.TabIndex = 1
        ' 
        ' lblBuscar
        ' 
        lblBuscar.AutoSize = True
        lblBuscar.Location = New Point(27, 60)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New Size(45, 15)
        lblBuscar.TabIndex = 2
        lblBuscar.Text = "Buscar:"
        ' 
        ' dgvTiposMembresia
        ' 
        dgvTiposMembresia.AllowUserToAddRows = False
        dgvTiposMembresia.AllowUserToDeleteRows = False
        dgvTiposMembresia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTiposMembresia.Location = New Point(27, 100)
        dgvTiposMembresia.MultiSelect = False
        dgvTiposMembresia.Name = "dgvTiposMembresia"
        dgvTiposMembresia.ReadOnly = True
        dgvTiposMembresia.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTiposMembresia.Size = New Size(383, 304)
        dgvTiposMembresia.TabIndex = 3
        ' 
        ' grpDatos
        ' 
        grpDatos.Controls.Add(lblDuracion)
        grpDatos.Controls.Add(nudDuracion)
        grpDatos.Controls.Add(chkActivo)
        grpDatos.Controls.Add(chkIncluyeClases)
        grpDatos.Controls.Add(txtDescripcion)
        grpDatos.Controls.Add(txtNombre)
        grpDatos.Controls.Add(nudPrecio)
        grpDatos.Controls.Add(lblIncluyeClases)
        grpDatos.Controls.Add(lblPrecio)
        grpDatos.Controls.Add(lblDescripcion)
        grpDatos.Controls.Add(lblNombre)
        grpDatos.Location = New Point(449, 60)
        grpDatos.Name = "grpDatos"
        grpDatos.Size = New Size(409, 224)
        grpDatos.TabIndex = 4
        grpDatos.TabStop = False
        grpDatos.Text = "Datos del tipo de membresía"
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.Location = New Point(182, 184)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(60, 19)
        chkActivo.TabIndex = 8
        chkActivo.Text = "Activo"
        chkActivo.UseVisualStyleBackColor = True
        ' 
        ' chkIncluyeClases
        ' 
        chkIncluyeClases.AutoSize = True
        chkIncluyeClases.Location = New Point(125, 184)
        chkIncluyeClases.Name = "chkIncluyeClases"
        chkIncluyeClases.Size = New Size(35, 19)
        chkIncluyeClases.TabIndex = 7
        chkIncluyeClases.Text = "Sí"
        chkIncluyeClases.UseVisualStyleBackColor = True
        ' 
        ' txtDescripcion
        ' 
        txtDescripcion.Location = New Point(110, 72)
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.Size = New Size(279, 23)
        txtDescripcion.TabIndex = 6
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(110, 35)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(279, 23)
        txtNombre.TabIndex = 5
        ' 
        ' nudPrecio
        ' 
        nudPrecio.DecimalPlaces = 2
        nudPrecio.Location = New Point(109, 106)
        nudPrecio.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        nudPrecio.Name = "nudPrecio"
        nudPrecio.Size = New Size(157, 23)
        nudPrecio.TabIndex = 4
        ' 
        ' lblIncluyeClases
        ' 
        lblIncluyeClases.AutoSize = True
        lblIncluyeClases.Location = New Point(26, 188)
        lblIncluyeClases.Name = "lblIncluyeClases"
        lblIncluyeClases.Size = New Size(82, 15)
        lblIncluyeClases.TabIndex = 3
        lblIncluyeClases.Text = "Incluye clases:"
        ' 
        ' lblPrecio
        ' 
        lblPrecio.AutoSize = True
        lblPrecio.Location = New Point(32, 114)
        lblPrecio.Name = "lblPrecio"
        lblPrecio.Size = New Size(43, 15)
        lblPrecio.TabIndex = 2
        lblPrecio.Text = "Precio:"
        ' 
        ' lblDescripcion
        ' 
        lblDescripcion.AutoSize = True
        lblDescripcion.Location = New Point(32, 75)
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.Size = New Size(72, 15)
        lblDescripcion.TabIndex = 1
        lblDescripcion.Text = "Descripción:"
        ' 
        ' lblNombre
        ' 
        lblNombre.AutoSize = True
        lblNombre.Location = New Point(31, 38)
        lblNombre.Name = "lblNombre"
        lblNombre.Size = New Size(54, 15)
        lblNombre.TabIndex = 0
        lblNombre.Text = "Nombre:"
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(475, 292)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(78, 32)
        btnNuevo.TabIndex = 5
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(574, 290)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(83, 34)
        btnGuardar.TabIndex = 6
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(680, 292)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(72, 32)
        btnEditar.TabIndex = 7
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Location = New Point(770, 295)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(72, 29)
        btnEliminar.TabIndex = 8
        btnEliminar.Text = "Desactivar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(631, 350)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(80, 33)
        btnCancelar.TabIndex = 9
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' nudDuracion
        ' 
        nudDuracion.Location = New Point(109, 142)
        nudDuracion.Maximum = New Decimal(New Integer() {3650, 0, 0, 0})
        nudDuracion.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudDuracion.Name = "nudDuracion"
        nudDuracion.Size = New Size(157, 23)
        nudDuracion.TabIndex = 9
        nudDuracion.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblDuracion
        ' 
        lblDuracion.AutoSize = True
        lblDuracion.Location = New Point(31, 144)
        lblDuracion.Name = "lblDuracion"
        lblDuracion.Size = New Size(58, 15)
        lblDuracion.TabIndex = 10
        lblDuracion.Text = "Duración "
        ' 
        ' FrmTipoDeMembresia
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(892, 450)
        Controls.Add(btnCancelar)
        Controls.Add(btnEliminar)
        Controls.Add(btnEditar)
        Controls.Add(btnGuardar)
        Controls.Add(btnNuevo)
        Controls.Add(grpDatos)
        Controls.Add(dgvTiposMembresia)
        Controls.Add(lblBuscar)
        Controls.Add(txtBuscar)
        Controls.Add(lblTitulo)
        Name = "FrmTipoDeMembresia"
        Text = "FrmTipoDeMembresia"
        CType(dgvTiposMembresia, ComponentModel.ISupportInitialize).EndInit()
        grpDatos.ResumeLayout(False)
        grpDatos.PerformLayout()
        CType(nudPrecio, ComponentModel.ISupportInitialize).EndInit()
        CType(bsTiposMembresia, ComponentModel.ISupportInitialize).EndInit()
        CType(nudDuracion, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents lblBuscar As Label
    Friend WithEvents dgvTiposMembresia As DataGridView
    Friend WithEvents grpDatos As GroupBox
    Friend WithEvents lblIncluyeClases As Label
    Friend WithEvents lblPrecio As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents nudPrecio As NumericUpDown
    Friend WithEvents chkIncluyeClases As CheckBox
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents bsTiposMembresia As BindingSource
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents nudDuracion As NumericUpDown
    Friend WithEvents lblDuracion As Label
End Class
