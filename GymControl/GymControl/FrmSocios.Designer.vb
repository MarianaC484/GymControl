<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSocios
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
        btnNuevo = New Button()
        btnGuardar = New Button()
        btnEditar = New Button()
        btnEliminar = New Button()
        btnCancelar = New Button()
        lblBuscar = New Label()
        txtBuscar = New TextBox()
        dgvSocios = New DataGridView()
        grpDatos = New GroupBox()
        lblCedula = New Label()
        txtCedula = New TextBox()
        lblNombres = New Label()
        lblApellidos = New Label()
        lblFechaNacimiento = New Label()
        lblGenero = New Label()
        lblTelefono = New Label()
        lblCorreo = New Label()
        lblDireccion = New Label()
        txtNombres = New TextBox()
        txtApellidos = New TextBox()
        dtpFechaNacimiento = New DateTimePicker()
        cboGenero = New ComboBox()
        txtTelefono = New TextBox()
        txtCorreo = New TextBox()
        txtDireccion = New TextBox()
        chkActivo = New CheckBox()
        bsSocios = New BindingSource(components)
        stsEstado = New StatusStrip()
        lblEstadoSocios = New ToolStripStatusLabel()
        CType(dgvSocios, ComponentModel.ISupportInitialize).BeginInit()
        grpDatos.SuspendLayout()
        CType(bsSocios, ComponentModel.ISupportInitialize).BeginInit()
        stsEstado.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(44, 586)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(108, 34)
        btnNuevo.TabIndex = 0
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(158, 586)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(108, 34)
        btnGuardar.TabIndex = 1
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(272, 586)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(108, 34)
        btnEditar.TabIndex = 2
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Location = New Point(386, 586)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(108, 34)
        btnEliminar.TabIndex = 3
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(500, 586)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(108, 34)
        btnCancelar.TabIndex = 4
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' lblBuscar
        ' 
        lblBuscar.AutoSize = True
        lblBuscar.Location = New Point(44, 63)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New Size(76, 15)
        lblBuscar.TabIndex = 5
        lblBuscar.Text = "Buscar socio:"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(126, 60)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(482, 23)
        txtBuscar.TabIndex = 6
        ' 
        ' dgvSocios
        ' 
        dgvSocios.AllowUserToAddRows = False
        dgvSocios.AllowUserToDeleteRows = False
        dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSocios.Location = New Point(44, 99)
        dgvSocios.MultiSelect = False
        dgvSocios.Name = "dgvSocios"
        dgvSocios.ReadOnly = True
        dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSocios.Size = New Size(564, 466)
        dgvSocios.TabIndex = 7
        ' 
        ' grpDatos
        ' 
        grpDatos.Controls.Add(chkActivo)
        grpDatos.Controls.Add(txtDireccion)
        grpDatos.Controls.Add(txtCorreo)
        grpDatos.Controls.Add(txtTelefono)
        grpDatos.Controls.Add(cboGenero)
        grpDatos.Controls.Add(dtpFechaNacimiento)
        grpDatos.Controls.Add(txtApellidos)
        grpDatos.Controls.Add(txtNombres)
        grpDatos.Controls.Add(lblDireccion)
        grpDatos.Controls.Add(lblCorreo)
        grpDatos.Controls.Add(lblTelefono)
        grpDatos.Controls.Add(lblGenero)
        grpDatos.Controls.Add(lblFechaNacimiento)
        grpDatos.Controls.Add(lblApellidos)
        grpDatos.Controls.Add(lblNombres)
        grpDatos.Controls.Add(txtCedula)
        grpDatos.Controls.Add(lblCedula)
        grpDatos.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        grpDatos.Location = New Point(639, 63)
        grpDatos.Name = "grpDatos"
        grpDatos.Size = New Size(459, 391)
        grpDatos.TabIndex = 8
        grpDatos.TabStop = False
        grpDatos.Text = "Datos del socio"
        ' 
        ' lblCedula
        ' 
        lblCedula.AutoSize = True
        lblCedula.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCedula.Location = New Point(20, 41)
        lblCedula.Name = "lblCedula"
        lblCedula.Size = New Size(51, 17)
        lblCedula.TabIndex = 9
        lblCedula.Text = "Cédula:"
        ' 
        ' txtCedula
        ' 
        txtCedula.Location = New Point(156, 36)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(287, 27)
        txtCedula.TabIndex = 10
        ' 
        ' lblNombres
        ' 
        lblNombres.AutoSize = True
        lblNombres.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNombres.Location = New Point(20, 84)
        lblNombres.Name = "lblNombres"
        lblNombres.Size = New Size(66, 17)
        lblNombres.TabIndex = 11
        lblNombres.Text = "Nombres:"
        ' 
        ' lblApellidos
        ' 
        lblApellidos.AutoSize = True
        lblApellidos.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblApellidos.Location = New Point(20, 125)
        lblApellidos.Name = "lblApellidos"
        lblApellidos.Size = New Size(65, 17)
        lblApellidos.TabIndex = 12
        lblApellidos.Text = "Apellidos:"
        ' 
        ' lblFechaNacimiento
        ' 
        lblFechaNacimiento.AutoSize = True
        lblFechaNacimiento.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblFechaNacimiento.Location = New Point(20, 169)
        lblFechaNacimiento.Name = "lblFechaNacimiento"
        lblFechaNacimiento.Size = New Size(130, 17)
        lblFechaNacimiento.TabIndex = 13
        lblFechaNacimiento.Text = "Fecha de nacimiento:"
        ' 
        ' lblGenero
        ' 
        lblGenero.AutoSize = True
        lblGenero.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblGenero.Location = New Point(278, 169)
        lblGenero.Name = "lblGenero"
        lblGenero.Size = New Size(54, 17)
        lblGenero.TabIndex = 14
        lblGenero.Text = "Género:"
        ' 
        ' lblTelefono
        ' 
        lblTelefono.AutoSize = True
        lblTelefono.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTelefono.Location = New Point(20, 209)
        lblTelefono.Name = "lblTelefono"
        lblTelefono.Size = New Size(65, 17)
        lblTelefono.TabIndex = 15
        lblTelefono.Text = " Teléfono:"
        ' 
        ' lblCorreo
        ' 
        lblCorreo.AutoSize = True
        lblCorreo.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCorreo.Location = New Point(20, 257)
        lblCorreo.Name = "lblCorreo"
        lblCorreo.Size = New Size(52, 17)
        lblCorreo.TabIndex = 16
        lblCorreo.Text = "Correo:"
        ' 
        ' lblDireccion
        ' 
        lblDireccion.AutoSize = True
        lblDireccion.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDireccion.Location = New Point(21, 307)
        lblDireccion.Name = "lblDireccion"
        lblDireccion.Size = New Size(65, 17)
        lblDireccion.TabIndex = 17
        lblDireccion.Text = "Dirección:"
        ' 
        ' txtNombres
        ' 
        txtNombres.Location = New Point(156, 79)
        txtNombres.Name = "txtNombres"
        txtNombres.Size = New Size(287, 27)
        txtNombres.TabIndex = 18
        ' 
        ' txtApellidos
        ' 
        txtApellidos.Location = New Point(156, 120)
        txtApellidos.Name = "txtApellidos"
        txtApellidos.Size = New Size(287, 27)
        txtApellidos.TabIndex = 19
        ' 
        ' dtpFechaNacimiento
        ' 
        dtpFechaNacimiento.Location = New Point(156, 162)
        dtpFechaNacimiento.Name = "dtpFechaNacimiento"
        dtpFechaNacimiento.Size = New Size(109, 27)
        dtpFechaNacimiento.TabIndex = 20
        ' 
        ' cboGenero
        ' 
        cboGenero.FormattingEnabled = True
        cboGenero.Location = New Point(338, 165)
        cboGenero.Name = "cboGenero"
        cboGenero.Size = New Size(105, 28)
        cboGenero.TabIndex = 21
        ' 
        ' txtTelefono
        ' 
        txtTelefono.Location = New Point(156, 209)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(287, 27)
        txtTelefono.TabIndex = 22
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Location = New Point(156, 252)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(287, 27)
        txtCorreo.TabIndex = 23
        ' 
        ' txtDireccion
        ' 
        txtDireccion.Location = New Point(156, 302)
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(287, 27)
        txtDireccion.TabIndex = 24
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.Checked = True
        chkActivo.CheckState = CheckState.Checked
        chkActivo.Location = New Point(334, 351)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(109, 24)
        chkActivo.TabIndex = 25
        chkActivo.Text = "Socio activo"
        chkActivo.UseVisualStyleBackColor = True
        ' 
        ' stsEstado
        ' 
        stsEstado.Items.AddRange(New ToolStripItem() {lblEstadoSocios})
        stsEstado.Location = New Point(0, 727)
        stsEstado.Name = "stsEstado"
        stsEstado.Size = New Size(1123, 22)
        stsEstado.TabIndex = 9
        stsEstado.Text = "StatusStrip1"
        ' 
        ' lblEstadoSocios
        ' 
        lblEstadoSocios.Name = "lblEstadoSocios"
        lblEstadoSocios.Size = New Size(32, 17)
        lblEstadoSocios.Text = "Listo"
        ' 
        ' FrmSocios
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1123, 749)
        Controls.Add(stsEstado)
        Controls.Add(grpDatos)
        Controls.Add(dgvSocios)
        Controls.Add(txtBuscar)
        Controls.Add(lblBuscar)
        Controls.Add(btnCancelar)
        Controls.Add(btnEliminar)
        Controls.Add(btnEditar)
        Controls.Add(btnGuardar)
        Controls.Add(btnNuevo)
        Name = "FrmSocios"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Gestión de Socios - GymControl"
        WindowState = FormWindowState.Maximized
        CType(dgvSocios, ComponentModel.ISupportInitialize).EndInit()
        grpDatos.ResumeLayout(False)
        grpDatos.PerformLayout()
        CType(bsSocios, ComponentModel.ISupportInitialize).EndInit()
        stsEstado.ResumeLayout(False)
        stsEstado.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblBuscar As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents dgvSocios As DataGridView
    Friend WithEvents grpDatos As GroupBox
    Friend WithEvents lblCedula As Label
    Friend WithEvents txtCedula As TextBox
    Friend WithEvents txtNombres As TextBox
    Friend WithEvents lblDireccion As Label
    Friend WithEvents lblCorreo As Label
    Friend WithEvents lblTelefono As Label
    Friend WithEvents lblGenero As Label
    Friend WithEvents lblFechaNacimiento As Label
    Friend WithEvents lblApellidos As Label
    Friend WithEvents lblNombres As Label
    Friend WithEvents txtApellidos As TextBox
    Friend WithEvents dtpFechaNacimiento As DateTimePicker
    Friend WithEvents cboGenero As ComboBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents bsSocios As BindingSource
    Friend WithEvents stsEstado As StatusStrip
    Friend WithEvents lblEstadoSocios As ToolStripStatusLabel
End Class
