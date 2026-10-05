<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBitacora
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
        lblBuscar = New Label()
        txtBuscar = New TextBox()
        btnActualizar = New Button()
        btnLimpiar = New Button()
        dgvBitacora = New DataGridView()
        lblEstadoBitacora = New Label()
        pnlTitulo.SuspendLayout()
        CType(dgvBitacora, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlTitulo
        ' 
        pnlTitulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlTitulo.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        pnlTitulo.Controls.Add(lblTitulo)
        pnlTitulo.Location = New Point(-1, 1)
        pnlTitulo.Name = "pnlTitulo"
        pnlTitulo.Size = New Size(799, 99)
        pnlTitulo.TabIndex = 0
        ' 
        ' lblTitulo
        ' 
        lblTitulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblTitulo.Cursor = Cursors.SizeAll
        lblTitulo.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblTitulo.Location = New Point(276, 37)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(217, 25)
        lblTitulo.TabIndex = 0
        lblTitulo.Text = "BITACORA DE ACCESOS"
        ' 
        ' lblBuscar
        ' 
        lblBuscar.AutoSize = True
        lblBuscar.Location = New Point(12, 132)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New Size(130, 25)
        lblBuscar.TabIndex = 1
        lblBuscar.Text = "Buscar usuario:"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtBuscar.Location = New Point(148, 132)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(624, 31)
        txtBuscar.TabIndex = 2
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Location = New Point(549, 184)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(112, 34)
        btnActualizar.TabIndex = 3
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = True
        ' 
        ' btnLimpiar
        ' 
        btnLimpiar.Location = New Point(676, 184)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(112, 34)
        btnLimpiar.TabIndex = 4
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' dgvBitacora
        ' 
        dgvBitacora.AllowUserToAddRows = False
        dgvBitacora.AllowUserToDeleteRows = False
        dgvBitacora.AllowUserToResizeRows = False
        dgvBitacora.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBitacora.Location = New Point(-1, 237)
        dgvBitacora.MultiSelect = False
        dgvBitacora.Name = "dgvBitacora"
        dgvBitacora.ReadOnly = True
        dgvBitacora.RowHeadersWidth = 62
        dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBitacora.Size = New Size(799, 236)
        dgvBitacora.TabIndex = 5
        ' 
        ' lblEstadoBitacora
        ' 
        lblEstadoBitacora.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblEstadoBitacora.AutoSize = True
        lblEstadoBitacora.Location = New Point(6, 475)
        lblEstadoBitacora.Name = "lblEstadoBitacora"
        lblEstadoBitacora.Size = New Size(208, 25)
        lblEstadoBitacora.TabIndex = 6
        lblEstadoBitacora.Text = "Registros Encontrados: 0"
        ' 
        ' frmBitacora
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 505)
        Controls.Add(lblEstadoBitacora)
        Controls.Add(btnLimpiar)
        Controls.Add(dgvBitacora)
        Controls.Add(btnActualizar)
        Controls.Add(txtBuscar)
        Controls.Add(lblBuscar)
        Controls.Add(pnlTitulo)
        Name = "frmBitacora"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmBitacora"
        pnlTitulo.ResumeLayout(False)
        CType(dgvBitacora, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblBuscar As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents dgvBitacora As DataGridView
    Friend WithEvents lblEstadoBitacora As Label
End Class
