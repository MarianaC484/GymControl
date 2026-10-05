<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInstructores
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
        txtBuscar = New TextBox()
        dgvInstructores = New DataGridView()
        grpDatos = New GroupBox()
        chkActivo = New CheckBox()
        LblFechaDeContratacion = New Label()
        dtpFechaContratacion = New DateTimePicker()
        txtCorreo = New TextBox()
        txtTelefono = New TextBox()
        txtApellidos = New TextBox()
        txtEspecialidad = New TextBox()
        txtNombres = New TextBox()
        txtCedula = New TextBox()
        lblCorreo = New Label()
        lblTelefono = New Label()
        lblEspecialidad = New Label()
        lblApellidos = New Label()
        lblNombes = New Label()
        LblCedula = New Label()
        bsInstructores = New BindingSource(components)
        stsEstado = New StatusStrip()
        lblEstadoInstructores = New ToolStripStatusLabel()
        lblBuscar = New Label()
        btnNuevo = New Button()
        btnGuardar = New Button()
        btnEditar = New Button()
        btnEliminar = New Button()
        btnCancelar = New Button()
        lblTitulo = New Label()
        CType(dgvInstructores, ComponentModel.ISupportInitialize).BeginInit()
        grpDatos.SuspendLayout()
        CType(bsInstructores, ComponentModel.ISupportInitialize).BeginInit()
        stsEstado.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(84, 44)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(374, 23)
        txtBuscar.TabIndex = 0
        ' 
        ' dgvInstructores
        ' 
        dgvInstructores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInstructores.Location = New Point(486, 83)
        dgvInstructores.Name = "dgvInstructores"
        dgvInstructores.Size = New Size(464, 407)
        dgvInstructores.TabIndex = 1
        ' 
        ' grpDatos
        ' 
        grpDatos.Controls.Add(chkActivo)
        grpDatos.Controls.Add(LblFechaDeContratacion)
        grpDatos.Controls.Add(dtpFechaContratacion)
        grpDatos.Controls.Add(txtCorreo)
        grpDatos.Controls.Add(txtTelefono)
        grpDatos.Controls.Add(txtApellidos)
        grpDatos.Controls.Add(txtEspecialidad)
        grpDatos.Controls.Add(txtNombres)
        grpDatos.Controls.Add(txtCedula)
        grpDatos.Controls.Add(lblCorreo)
        grpDatos.Controls.Add(lblTelefono)
        grpDatos.Controls.Add(lblEspecialidad)
        grpDatos.Controls.Add(lblApellidos)
        grpDatos.Controls.Add(lblNombes)
        grpDatos.Controls.Add(LblCedula)
        grpDatos.Location = New Point(37, 83)
        grpDatos.Name = "grpDatos"
        grpDatos.Size = New Size(421, 352)
        grpDatos.TabIndex = 2
        grpDatos.TabStop = False
        grpDatos.Text = "Datos"
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.Checked = True
        chkActivo.CheckState = CheckState.Checked
        chkActivo.Location = New Point(321, 313)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(60, 19)
        chkActivo.TabIndex = 14
        chkActivo.Text = "Activo"
        chkActivo.UseVisualStyleBackColor = True
        ' 
        ' LblFechaDeContratacion
        ' 
        LblFechaDeContratacion.AutoSize = True
        LblFechaDeContratacion.Location = New Point(30, 266)
        LblFechaDeContratacion.Name = "LblFechaDeContratacion"
        LblFechaDeContratacion.Size = New Size(124, 15)
        LblFechaDeContratacion.TabIndex = 13
        LblFechaDeContratacion.Text = "Fecha de contratacion"
        ' 
        ' dtpFechaContratacion
        ' 
        dtpFechaContratacion.Location = New Point(169, 266)
        dtpFechaContratacion.Name = "dtpFechaContratacion"
        dtpFechaContratacion.Size = New Size(212, 23)
        dtpFechaContratacion.TabIndex = 12
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Location = New Point(169, 226)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(212, 23)
        txtCorreo.TabIndex = 11
        ' 
        ' txtTelefono
        ' 
        txtTelefono.Location = New Point(169, 184)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(212, 23)
        txtTelefono.TabIndex = 10
        ' 
        ' txtApellidos
        ' 
        txtApellidos.Location = New Point(169, 99)
        txtApellidos.Name = "txtApellidos"
        txtApellidos.Size = New Size(212, 23)
        txtApellidos.TabIndex = 9
        ' 
        ' txtEspecialidad
        ' 
        txtEspecialidad.Location = New Point(169, 144)
        txtEspecialidad.Name = "txtEspecialidad"
        txtEspecialidad.Size = New Size(212, 23)
        txtEspecialidad.TabIndex = 8
        ' 
        ' txtNombres
        ' 
        txtNombres.Location = New Point(169, 58)
        txtNombres.Name = "txtNombres"
        txtNombres.Size = New Size(212, 23)
        txtNombres.TabIndex = 7
        ' 
        ' txtCedula
        ' 
        txtCedula.Location = New Point(169, 24)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(212, 23)
        txtCedula.TabIndex = 6
        ' 
        ' lblCorreo
        ' 
        lblCorreo.AutoSize = True
        lblCorreo.Location = New Point(39, 229)
        lblCorreo.Name = "lblCorreo"
        lblCorreo.Size = New Size(43, 15)
        lblCorreo.TabIndex = 5
        lblCorreo.Text = "Correo"
        ' 
        ' lblTelefono
        ' 
        lblTelefono.AutoSize = True
        lblTelefono.Location = New Point(39, 187)
        lblTelefono.Name = "lblTelefono"
        lblTelefono.Size = New Size(53, 15)
        lblTelefono.TabIndex = 4
        lblTelefono.Text = "Teléfono"
        ' 
        ' lblEspecialidad
        ' 
        lblEspecialidad.AutoSize = True
        lblEspecialidad.Location = New Point(36, 147)
        lblEspecialidad.Name = "lblEspecialidad"
        lblEspecialidad.Size = New Size(72, 15)
        lblEspecialidad.TabIndex = 3
        lblEspecialidad.Text = "Especialidad"
        ' 
        ' lblApellidos
        ' 
        lblApellidos.AutoSize = True
        lblApellidos.Location = New Point(36, 107)
        lblApellidos.Name = "lblApellidos"
        lblApellidos.Size = New Size(56, 15)
        lblApellidos.TabIndex = 2
        lblApellidos.Text = "Apellidos"
        ' 
        ' lblNombes
        ' 
        lblNombes.AutoSize = True
        lblNombes.Location = New Point(36, 66)
        lblNombes.Name = "lblNombes"
        lblNombes.Size = New Size(59, 15)
        lblNombes.TabIndex = 1
        lblNombes.Text = "Nombres:"
        ' 
        ' LblCedula
        ' 
        LblCedula.AutoSize = True
        LblCedula.Location = New Point(36, 32)
        LblCedula.Name = "LblCedula"
        LblCedula.Size = New Size(44, 15)
        LblCedula.TabIndex = 0
        LblCedula.Text = "Cédula"
        ' 
        ' stsEstado
        ' 
        stsEstado.Items.AddRange(New ToolStripItem() {lblEstadoInstructores})
        stsEstado.Location = New Point(0, 505)
        stsEstado.Name = "stsEstado"
        stsEstado.Size = New Size(977, 22)
        stsEstado.TabIndex = 3
        stsEstado.Text = "StatusStrip1"
        ' 
        ' lblEstadoInstructores
        ' 
        lblEstadoInstructores.Name = "lblEstadoInstructores"
        lblEstadoInstructores.Size = New Size(32, 17)
        lblEstadoInstructores.Text = "Listo"
        ' 
        ' lblBuscar
        ' 
        lblBuscar.AutoSize = True
        lblBuscar.Location = New Point(37, 44)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New Size(42, 15)
        lblBuscar.TabIndex = 4
        lblBuscar.Text = "Buscar"
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(37, 458)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(80, 32)
        btnNuevo.TabIndex = 5
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(123, 458)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(80, 32)
        btnGuardar.TabIndex = 6
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(209, 458)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(80, 32)
        btnEditar.TabIndex = 7
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Location = New Point(295, 458)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(80, 32)
        btnEliminar.TabIndex = 8
        btnEliminar.Text = "Eiminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(381, 458)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(80, 32)
        btnCancelar.TabIndex = 9
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitulo.Location = New Point(486, 44)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(119, 25)
        lblTitulo.TabIndex = 10
        lblTitulo.Text = "Instructores"
        ' 
        ' FrmInstructores
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(977, 527)
        Controls.Add(lblTitulo)
        Controls.Add(btnCancelar)
        Controls.Add(btnEliminar)
        Controls.Add(btnEditar)
        Controls.Add(btnGuardar)
        Controls.Add(btnNuevo)
        Controls.Add(lblBuscar)
        Controls.Add(stsEstado)
        Controls.Add(grpDatos)
        Controls.Add(dgvInstructores)
        Controls.Add(txtBuscar)
        Name = "FrmInstructores"
        Text = "FrmInstructores"
        CType(dgvInstructores, ComponentModel.ISupportInitialize).EndInit()
        grpDatos.ResumeLayout(False)
        grpDatos.PerformLayout()
        CType(bsInstructores, ComponentModel.ISupportInitialize).EndInit()
        stsEstado.ResumeLayout(False)
        stsEstado.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents dgvInstructores As DataGridView
    Friend WithEvents grpDatos As GroupBox
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtApellidos As TextBox
    Friend WithEvents txtEspecialidad As TextBox
    Friend WithEvents txtNombres As TextBox
    Friend WithEvents txtCedula As TextBox
    Friend WithEvents lblCorreo As Label
    Friend WithEvents lblTelefono As Label
    Friend WithEvents lblEspecialidad As Label
    Friend WithEvents lblApellidos As Label
    Friend WithEvents lblNombes As Label
    Friend WithEvents LblCedula As Label
    Friend WithEvents dtpFechaContratacion As DateTimePicker
    Friend WithEvents LblFechaDeContratacion As Label
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents bsInstructores As BindingSource
    Friend WithEvents stsEstado As StatusStrip
    Friend WithEvents lblEstadoInstructores As ToolStripStatusLabel
    Friend WithEvents lblBuscar As Label
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblTitulo As Label
End Class
