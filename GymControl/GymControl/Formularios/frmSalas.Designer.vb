<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalas
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
        lblNombre = New Label()
        lblCapacidad = New Label()
        txtNombre = New TextBox()
        txtCapacidad = New TextBox()
        lblTitulo = New Label()
        pnlTitulo = New Panel()
        chkActivo = New CheckBox()
        btnNuevo = New Button()
        btnEditar = New Button()
        btnGuardar = New Button()
        btnCancelar = New Button()
        btnEliminar = New Button()
        dgvSalas = New DataGridView()
        lblEstadoSalas = New Label()
        pnlTitulo.SuspendLayout()
        CType(dgvSalas, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblNombre
        ' 
        lblNombre.AutoSize = True
        lblNombre.Location = New Point(12, 166)
        lblNombre.Name = "lblNombre"
        lblNombre.Size = New Size(82, 25)
        lblNombre.TabIndex = 0
        lblNombre.Text = "Nombre:"
        ' 
        ' lblCapacidad
        ' 
        lblCapacidad.AutoSize = True
        lblCapacidad.Location = New Point(12, 216)
        lblCapacidad.Name = "lblCapacidad"
        lblCapacidad.Size = New Size(99, 25)
        lblCapacidad.TabIndex = 1
        lblCapacidad.Text = "Capacidad:"
        ' 
        ' txtNombre
        ' 
        txtNombre.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtNombre.Location = New Point(130, 160)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(607, 31)
        txtNombre.TabIndex = 2
        ' 
        ' txtCapacidad
        ' 
        txtCapacidad.Location = New Point(130, 213)
        txtCapacidad.Name = "txtCapacidad"
        txtCapacidad.Size = New Size(607, 31)
        txtCapacidad.TabIndex = 3
        ' 
        ' lblTitulo
        ' 
        lblTitulo.Dock = DockStyle.Fill
        lblTitulo.Font = New Font("Segoe UI", 10F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblTitulo.Location = New Point(0, 0)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(984, 109)
        lblTitulo.TabIndex = 4
        lblTitulo.Text = "GESTION DE SALAS"
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlTitulo
        ' 
        pnlTitulo.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        pnlTitulo.Controls.Add(lblTitulo)
        pnlTitulo.Location = New Point(-1, 0)
        pnlTitulo.Name = "pnlTitulo"
        pnlTitulo.Size = New Size(984, 109)
        pnlTitulo.TabIndex = 5
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.Checked = True
        chkActivo.CheckState = CheckState.Checked
        chkActivo.Location = New Point(23, 271)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(88, 29)
        chkActivo.TabIndex = 6
        chkActivo.Text = "Activo"
        chkActivo.UseVisualStyleBackColor = True
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(363, 361)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(112, 34)
        btnNuevo.TabIndex = 7
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(481, 361)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(112, 34)
        btnEditar.TabIndex = 8
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(599, 361)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(112, 34)
        btnGuardar.TabIndex = 9
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(717, 361)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(112, 34)
        btnCancelar.TabIndex = 10
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Location = New Point(835, 361)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(112, 34)
        btnEliminar.TabIndex = 11
        btnEliminar.Text = "Desactivar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' dgvSalas
        ' 
        dgvSalas.AllowUserToAddRows = False
        dgvSalas.AllowUserToDeleteRows = False
        dgvSalas.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvSalas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSalas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSalas.Location = New Point(-1, 420)
        dgvSalas.MultiSelect = False
        dgvSalas.Name = "dgvSalas"
        dgvSalas.ReadOnly = True
        dgvSalas.RowHeadersVisible = False
        dgvSalas.RowHeadersWidth = 62
        dgvSalas.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSalas.Size = New Size(984, 229)
        dgvSalas.TabIndex = 12
        ' 
        ' lblEstadoSalas
        ' 
        lblEstadoSalas.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblEstadoSalas.AutoSize = True
        lblEstadoSalas.Location = New Point(12, 681)
        lblEstadoSalas.Name = "lblEstadoSalas"
        lblEstadoSalas.Size = New Size(173, 25)
        lblEstadoSalas.TabIndex = 13
        lblEstadoSalas.Text = "Salas encontradas: 0"
        ' 
        ' frmSalas
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(982, 715)
        Controls.Add(lblEstadoSalas)
        Controls.Add(dgvSalas)
        Controls.Add(btnEliminar)
        Controls.Add(btnCancelar)
        Controls.Add(btnGuardar)
        Controls.Add(btnEditar)
        Controls.Add(btnNuevo)
        Controls.Add(chkActivo)
        Controls.Add(pnlTitulo)
        Controls.Add(txtCapacidad)
        Controls.Add(txtNombre)
        Controls.Add(lblCapacidad)
        Controls.Add(lblNombre)
        Name = "frmSalas"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmSalas"
        pnlTitulo.ResumeLayout(False)
        CType(dgvSalas, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblNombre As Label
    Friend WithEvents lblCapacidad As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtCapacidad As TextBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents dgvSalas As DataGridView
    Friend WithEvents lblEstadoSalas As Label
End Class
