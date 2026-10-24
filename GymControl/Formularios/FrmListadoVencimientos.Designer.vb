<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListadoVencimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListadoVencimientos))
        nudDiasAdelante = New NumericUpDown()
        chkSoloConSaldo = New CheckBox()
        nudDiasAtras = New NumericUpDown()
        chkHorizontal = New CheckBox()
        lblVencimiento1 = New Label()
        lblVencimiento2 = New Label()
        lblVencimiento3 = New Label()
        grpFiltros = New GroupBox()
        btnCargar = New Button()
        dgvVencimientos = New DataGridView()
        btnConfigurarPagina = New Button()
        btnVistaPrevia = New Button()
        btnImprimir = New Button()
        lblResumen = New Label()
        pdListado = New Printing.PrintDocument()
        ppdListado = New PrintPreviewDialog()
        prdListado = New PrintDialog()
        psdListado = New PageSetupDialog()
        CType(nudDiasAdelante, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudDiasAtras, ComponentModel.ISupportInitialize).BeginInit()
        grpFiltros.SuspendLayout()
        CType(dgvVencimientos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' nudDiasAdelante
        ' 
        nudDiasAdelante.Location = New Point(223, 37)
        nudDiasAdelante.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        nudDiasAdelante.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudDiasAdelante.Name = "nudDiasAdelante"
        nudDiasAdelante.Size = New Size(61, 31)
        nudDiasAdelante.TabIndex = 0
        nudDiasAdelante.Value = New Decimal(New Integer() {7, 0, 0, 0})
        ' 
        ' chkSoloConSaldo
        ' 
        chkSoloConSaldo.AutoSize = True
        chkSoloConSaldo.Location = New Point(628, 41)
        chkSoloConSaldo.Name = "chkSoloConSaldo"
        chkSoloConSaldo.Size = New Size(156, 29)
        chkSoloConSaldo.TabIndex = 1
        chkSoloConSaldo.Text = "Solo con saldo"
        chkSoloConSaldo.UseVisualStyleBackColor = True
        ' 
        ' nudDiasAtras
        ' 
        nudDiasAtras.Location = New Point(510, 37)
        nudDiasAtras.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        nudDiasAtras.Name = "nudDiasAtras"
        nudDiasAtras.Size = New Size(61, 31)
        nudDiasAtras.TabIndex = 2
        nudDiasAtras.Value = New Decimal(New Integer() {15, 0, 0, 0})
        ' 
        ' chkHorizontal
        ' 
        chkHorizontal.AutoSize = True
        chkHorizontal.Location = New Point(790, 41)
        chkHorizontal.Name = "chkHorizontal"
        chkHorizontal.Size = New Size(159, 29)
        chkHorizontal.TabIndex = 3
        chkHorizontal.Text = "Hoja horizontal"
        chkHorizontal.UseVisualStyleBackColor = True
        ' 
        ' lblVencimiento1
        ' 
        lblVencimiento1.AutoSize = True
        lblVencimiento1.Location = New Point(17, 39)
        lblVencimiento1.Name = "lblVencimiento1"
        lblVencimiento1.Size = New Size(200, 25)
        lblVencimiento1.TabIndex = 4
        lblVencimiento1.Text = "Vencen en los próximos"
        ' 
        ' lblVencimiento2
        ' 
        lblVencimiento2.AutoSize = True
        lblVencimiento2.Location = New Point(290, 39)
        lblVencimiento2.Name = "lblVencimiento2"
        lblVencimiento2.Size = New Size(214, 25)
        lblVencimiento2.TabIndex = 5
        lblVencimiento2.Text = "días · vencidas hace hasta"
        ' 
        ' lblVencimiento3
        ' 
        lblVencimiento3.AutoSize = True
        lblVencimiento3.Location = New Point(578, 42)
        lblVencimiento3.Name = "lblVencimiento3"
        lblVencimiento3.Size = New Size(44, 25)
        lblVencimiento3.TabIndex = 6
        lblVencimiento3.Text = "días"
        ' 
        ' grpFiltros
        ' 
        grpFiltros.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        grpFiltros.Controls.Add(btnCargar)
        grpFiltros.Controls.Add(lblVencimiento1)
        grpFiltros.Controls.Add(chkHorizontal)
        grpFiltros.Controls.Add(lblVencimiento3)
        grpFiltros.Controls.Add(chkSoloConSaldo)
        grpFiltros.Controls.Add(nudDiasAdelante)
        grpFiltros.Controls.Add(lblVencimiento2)
        grpFiltros.Controls.Add(nudDiasAtras)
        grpFiltros.Location = New Point(32, 12)
        grpFiltros.Name = "grpFiltros"
        grpFiltros.Size = New Size(1002, 131)
        grpFiltros.TabIndex = 7
        grpFiltros.TabStop = False
        grpFiltros.Text = "Filtros"
        ' 
        ' btnCargar
        ' 
        btnCargar.AutoSize = True
        btnCargar.BackColor = SystemColors.Highlight
        btnCargar.Location = New Point(17, 86)
        btnCargar.Name = "btnCargar"
        btnCargar.Size = New Size(112, 35)
        btnCargar.TabIndex = 8
        btnCargar.Text = "Cargar"
        btnCargar.UseVisualStyleBackColor = False
        ' 
        ' dgvVencimientos
        ' 
        dgvVencimientos.AllowUserToAddRows = False
        dgvVencimientos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvVencimientos.BackgroundColor = SystemColors.Control
        dgvVencimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvVencimientos.Location = New Point(32, 172)
        dgvVencimientos.Name = "dgvVencimientos"
        dgvVencimientos.ReadOnly = True
        dgvVencimientos.RowHeadersVisible = False
        dgvVencimientos.RowHeadersWidth = 62
        dgvVencimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvVencimientos.Size = New Size(1002, 251)
        dgvVencimientos.TabIndex = 8
        ' 
        ' btnConfigurarPagina
        ' 
        btnConfigurarPagina.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnConfigurarPagina.AutoSize = True
        btnConfigurarPagina.Enabled = False
        btnConfigurarPagina.Location = New Point(32, 468)
        btnConfigurarPagina.Name = "btnConfigurarPagina"
        btnConfigurarPagina.Size = New Size(173, 35)
        btnConfigurarPagina.TabIndex = 9
        btnConfigurarPagina.Text = "Configurar Pagina"
        btnConfigurarPagina.UseVisualStyleBackColor = True
        ' 
        ' btnVistaPrevia
        ' 
        btnVistaPrevia.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnVistaPrevia.AutoSize = True
        btnVistaPrevia.BackColor = SystemColors.Highlight
        btnVistaPrevia.Enabled = False
        btnVistaPrevia.Location = New Point(211, 468)
        btnVistaPrevia.Name = "btnVistaPrevia"
        btnVistaPrevia.Size = New Size(112, 35)
        btnVistaPrevia.TabIndex = 10
        btnVistaPrevia.Text = "Vista Previa"
        btnVistaPrevia.UseVisualStyleBackColor = False
        ' 
        ' btnImprimir
        ' 
        btnImprimir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnImprimir.AutoSize = True
        btnImprimir.Enabled = False
        btnImprimir.Location = New Point(338, 468)
        btnImprimir.Name = "btnImprimir"
        btnImprimir.Size = New Size(112, 35)
        btnImprimir.TabIndex = 11
        btnImprimir.Text = "Imprimir"
        btnImprimir.UseVisualStyleBackColor = True
        ' 
        ' lblResumen
        ' 
        lblResumen.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblResumen.AutoSize = True
        lblResumen.ForeColor = Color.DimGray
        lblResumen.Location = New Point(843, 473)
        lblResumen.Name = "lblResumen"
        lblResumen.Size = New Size(88, 25)
        lblResumen.TabIndex = 12
        lblResumen.Text = "Resumen:"
        ' 
        ' pdListado
        ' 
        pdListado.DocumentName = "Vencimientos"
        ' 
        ' ppdListado
        ' 
        ppdListado.AutoScrollMargin = New Size(0, 0)
        ppdListado.AutoScrollMinSize = New Size(0, 0)
        ppdListado.ClientSize = New Size(400, 300)
        ppdListado.Document = pdListado
        ppdListado.Enabled = True
        ppdListado.Icon = CType(resources.GetObject("ppdListado.Icon"), Icon)
        ppdListado.Name = "ppdListado"
        ppdListado.UseAntiAlias = True
        ppdListado.Visible = False
        ' 
        ' prdListado
        ' 
        prdListado.AllowSomePages = True
        prdListado.Document = pdListado
        prdListado.UseEXDialog = True
        ' 
        ' psdListado
        ' 
        psdListado.Document = pdListado
        psdListado.EnableMetric = True
        ' 
        ' FrmListadoVencimientos
        ' 
        AcceptButton = btnCargar
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1064, 544)
        Controls.Add(lblResumen)
        Controls.Add(btnImprimir)
        Controls.Add(btnVistaPrevia)
        Controls.Add(btnConfigurarPagina)
        Controls.Add(dgvVencimientos)
        Controls.Add(grpFiltros)
        Name = "FrmListadoVencimientos"
        StartPosition = FormStartPosition.CenterParent
        Text = "Listado de vencimientos"
        CType(nudDiasAdelante, ComponentModel.ISupportInitialize).EndInit()
        CType(nudDiasAtras, ComponentModel.ISupportInitialize).EndInit()
        grpFiltros.ResumeLayout(False)
        grpFiltros.PerformLayout()
        CType(dgvVencimientos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents nudDiasAdelante As NumericUpDown
    Friend WithEvents chkSoloConSaldo As CheckBox
    Friend WithEvents nudDiasAtras As NumericUpDown
    Friend WithEvents chkHorizontal As CheckBox
    Friend WithEvents lblVencimiento1 As Label
    Friend WithEvents lblVencimiento2 As Label
    Friend WithEvents lblVencimiento3 As Label
    Friend WithEvents grpFiltros As GroupBox
    Friend WithEvents btnCargar As Button
    Friend WithEvents dgvVencimientos As DataGridView
    Friend WithEvents btnConfigurarPagina As Button
    Friend WithEvents btnVistaPrevia As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents lblResumen As Label
    Friend WithEvents pdListado As Printing.PrintDocument
    Friend WithEvents ppdListado As PrintPreviewDialog
    Friend WithEvents prdListado As PrintDialog
    Friend WithEvents psdListado As PageSetupDialog
End Class
