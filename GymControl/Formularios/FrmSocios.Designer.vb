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
        chkActivo = New CheckBox()
        txtDireccion = New TextBox()
        txtCorreo = New TextBox()
        txtTelefono = New TextBox()
        cboGenero = New ComboBox()
        dtpFechaNacimiento = New DateTimePicker()
        txtApellidos = New TextBox()
        txtNombres = New TextBox()
        lblDireccion = New Label()
        lblCorreo = New Label()
        lblTelefono = New Label()
        lblGenero = New Label()
        lblFechaNacimiento = New Label()
        lblApellidos = New Label()
        lblNombres = New Label()
        txtCedula = New TextBox()
        lblCedula = New Label()
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
        btnNuevo.Location = New Point(63, 968)
        btnNuevo.Margin = New Padding(4, 5, 4, 5)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(155, 45)
        btnNuevo.TabIndex = 0
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(226, 968)
        btnGuardar.Margin = New Padding(4, 5, 4, 5)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(155, 45)
        btnGuardar.TabIndex = 1
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(389, 968)
        btnEditar.Margin = New Padding(4, 5, 4, 5)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(139, 45)
        btnEditar.TabIndex = 2
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Location = New Point(536, 968)
        btnEliminar.Margin = New Padding(4, 5, 4, 5)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(154, 45)
        btnEliminar.TabIndex = 3
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(713, 968)
        btnCancelar.Margin = New Padding(4, 5, 4, 5)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(154, 45)
        btnCancelar.TabIndex = 4
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' lblBuscar
        ' 
        lblBuscar.AutoSize = True
        lblBuscar.Location = New Point(63, 105)
        lblBuscar.Margin = New Padding(4, 0, 4, 0)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New Size(114, 25)
        lblBuscar.TabIndex = 5
        lblBuscar.Text = "Buscar socio:"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(180, 100)
        txtBuscar.Margin = New Padding(4, 5, 4, 5)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(687, 31)
        txtBuscar.TabIndex = 6
        ' 
        ' dgvSocios
        ' 
        dgvSocios.AllowUserToAddRows = False
        dgvSocios.AllowUserToDeleteRows = False
        dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSocios.Location = New Point(63, 165)
        dgvSocios.Margin = New Padding(4, 5, 4, 5)
        dgvSocios.MultiSelect = False
        dgvSocios.Name = "dgvSocios"
        dgvSocios.ReadOnly = True
        dgvSocios.RowHeadersWidth = 62
        dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSocios.Size = New Size(806, 777)
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
        grpDatos.Location = New Point(913, 105)
        grpDatos.Margin = New Padding(4, 5, 4, 5)
        grpDatos.Name = "grpDatos"
        grpDatos.Padding = New Padding(4, 5, 4, 5)
        grpDatos.Size = New Size(656, 652)
        grpDatos.TabIndex = 8
        grpDatos.TabStop = False
        grpDatos.Text = "Datos del socio"
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.Checked = True
        chkActivo.CheckState = CheckState.Checked
        chkActivo.Location = New Point(477, 585)
        chkActivo.Margin = New Padding(4, 5, 4, 5)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(162, 35)
        chkActivo.TabIndex = 25
        chkActivo.Text = "Socio activo"
        chkActivo.UseVisualStyleBackColor = True
        ' 
        ' txtDireccion
        ' 
        txtDireccion.Location = New Point(223, 503)
        txtDireccion.Margin = New Padding(4, 5, 4, 5)
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(408, 37)
        txtDireccion.TabIndex = 24
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Location = New Point(223, 420)
        txtCorreo.Margin = New Padding(4, 5, 4, 5)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(408, 37)
        txtCorreo.TabIndex = 23
        ' 
        ' txtTelefono
        ' 
        txtTelefono.Location = New Point(223, 348)
        txtTelefono.Margin = New Padding(4, 5, 4, 5)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(408, 37)
        txtTelefono.TabIndex = 22
        ' 
        ' cboGenero
        ' 
        cboGenero.FormattingEnabled = True
        cboGenero.Location = New Point(483, 275)
        cboGenero.Margin = New Padding(4, 5, 4, 5)
        cboGenero.Name = "cboGenero"
        cboGenero.Size = New Size(148, 39)
        cboGenero.TabIndex = 21
        ' 
        ' dtpFechaNacimiento
        ' 
        dtpFechaNacimiento.Location = New Point(223, 270)
        dtpFechaNacimiento.Margin = New Padding(4, 5, 4, 5)
        dtpFechaNacimiento.Name = "dtpFechaNacimiento"
        dtpFechaNacimiento.Size = New Size(154, 37)
        dtpFechaNacimiento.TabIndex = 20
        ' 
        ' txtApellidos
        ' 
        txtApellidos.Location = New Point(223, 200)
        txtApellidos.Margin = New Padding(4, 5, 4, 5)
        txtApellidos.Name = "txtApellidos"
        txtApellidos.Size = New Size(408, 37)
        txtApellidos.TabIndex = 19
        ' 
        ' txtNombres
        ' 
        txtNombres.Location = New Point(223, 132)
        txtNombres.Margin = New Padding(4, 5, 4, 5)
        txtNombres.Name = "txtNombres"
        txtNombres.Size = New Size(408, 37)
        txtNombres.TabIndex = 18
        ' 
        ' lblDireccion
        ' 
        lblDireccion.AutoSize = True
        lblDireccion.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDireccion.Location = New Point(30, 512)
        lblDireccion.Margin = New Padding(4, 0, 4, 0)
        lblDireccion.Name = "lblDireccion"
        lblDireccion.Size = New Size(98, 28)
        lblDireccion.TabIndex = 17
        lblDireccion.Text = "Dirección:"
        ' 
        ' lblCorreo
        ' 
        lblCorreo.AutoSize = True
        lblCorreo.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCorreo.Location = New Point(29, 428)
        lblCorreo.Margin = New Padding(4, 0, 4, 0)
        lblCorreo.Name = "lblCorreo"
        lblCorreo.Size = New Size(76, 28)
        lblCorreo.TabIndex = 16
        lblCorreo.Text = "Correo:"
        ' 
        ' lblTelefono
        ' 
        lblTelefono.AutoSize = True
        lblTelefono.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTelefono.Location = New Point(29, 348)
        lblTelefono.Margin = New Padding(4, 0, 4, 0)
        lblTelefono.Name = "lblTelefono"
        lblTelefono.Size = New Size(95, 28)
        lblTelefono.TabIndex = 15
        lblTelefono.Text = " Teléfono:"
        ' 
        ' lblGenero
        ' 
        lblGenero.AutoSize = True
        lblGenero.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblGenero.Location = New Point(397, 282)
        lblGenero.Margin = New Padding(4, 0, 4, 0)
        lblGenero.Name = "lblGenero"
        lblGenero.Size = New Size(80, 28)
        lblGenero.TabIndex = 14
        lblGenero.Text = "Género:"
        ' 
        ' lblFechaNacimiento
        ' 
        lblFechaNacimiento.AutoSize = True
        lblFechaNacimiento.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblFechaNacimiento.Location = New Point(29, 282)
        lblFechaNacimiento.Margin = New Padding(4, 0, 4, 0)
        lblFechaNacimiento.Name = "lblFechaNacimiento"
        lblFechaNacimiento.Size = New Size(195, 28)
        lblFechaNacimiento.TabIndex = 13
        lblFechaNacimiento.Text = "Fecha de nacimiento:"
        ' 
        ' lblApellidos
        ' 
        lblApellidos.AutoSize = True
        lblApellidos.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblApellidos.Location = New Point(29, 208)
        lblApellidos.Margin = New Padding(4, 0, 4, 0)
        lblApellidos.Name = "lblApellidos"
        lblApellidos.Size = New Size(98, 28)
        lblApellidos.TabIndex = 12
        lblApellidos.Text = "Apellidos:"
        ' 
        ' lblNombres
        ' 
        lblNombres.AutoSize = True
        lblNombres.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNombres.Location = New Point(29, 140)
        lblNombres.Margin = New Padding(4, 0, 4, 0)
        lblNombres.Name = "lblNombres"
        lblNombres.Size = New Size(97, 28)
        lblNombres.TabIndex = 11
        lblNombres.Text = "Nombres:"
        ' 
        ' txtCedula
        ' 
        txtCedula.Location = New Point(223, 60)
        txtCedula.Margin = New Padding(4, 5, 4, 5)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(408, 37)
        txtCedula.TabIndex = 10
        ' 
        ' lblCedula
        ' 
        lblCedula.AutoSize = True
        lblCedula.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCedula.Location = New Point(29, 68)
        lblCedula.Margin = New Padding(4, 0, 4, 0)
        lblCedula.Name = "lblCedula"
        lblCedula.Size = New Size(76, 28)
        lblCedula.TabIndex = 9
        lblCedula.Text = "Cédula:"
        ' 
        ' bsSocios
        ' 
        ' 
        ' stsEstado
        ' 
        stsEstado.ImageScalingSize = New Size(24, 24)
        stsEstado.Items.AddRange(New ToolStripItem() {lblEstadoSocios})
        stsEstado.Location = New Point(0, 1018)
        stsEstado.Name = "stsEstado"
        stsEstado.Padding = New Padding(1, 0, 20, 0)
        stsEstado.Size = New Size(1604, 32)
        stsEstado.TabIndex = 9
        stsEstado.Text = "StatusStrip1"
        ' 
        ' lblEstadoSocios
        ' 
        lblEstadoSocios.Name = "lblEstadoSocios"
        lblEstadoSocios.Size = New Size(49, 25)
        lblEstadoSocios.Text = "Listo"
        ' 
        ' frmSocios
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1604, 1050)
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
        Margin = New Padding(4, 5, 4, 5)
        Name = "frmSocios"
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
