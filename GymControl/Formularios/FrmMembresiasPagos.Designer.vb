<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMembresiasPagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMembresiasPagos))
        grpSocio = New GroupBox()
        txtNombreSocio = New TextBox()
        lblNombreSocio = New Label()
        btnBuscarSocio = New Button()
        txtCedula = New TextBox()
        lblCedula = New Label()
        grpMembresia = New GroupBox()
        btnCancelarMembresia = New Button()
        btnGuardarMembresia = New Button()
        btnNuevaMembresia = New Button()
        cboEstadoMembresia = New ComboBox()
        lblEstadoMembresia = New Label()
        txtPrecioPactado = New TextBox()
        lblPrecioPactado = New Label()
        dtpFechaVencimiento = New DateTimePicker()
        lblFechaVencimiento = New Label()
        dtpFechaInicio = New DateTimePicker()
        lblFechaInicio = New Label()
        cboTipoMembresia = New ComboBox()
        lblTipoMembresia = New Label()
        dgvMembresias = New DataGridView()
        lblTituloMembresias = New Label()
        grpRegistrar = New GroupBox()
        btnRegistrarPago = New Button()
        txtObservacion = New TextBox()
        lblObservacion = New Label()
        txtReferencia = New TextBox()
        lblReferencia = New Label()
        cboMetodoPago = New ComboBox()
        lblMetodoPago = New Label()
        txtMonto = New TextBox()
        lblMonto = New Label()
        dgvPagos = New DataGridView()
        lblTituloPagos = New Label()
        lblTotal = New Label()
        lblSaldo = New Label()
        lblPagado = New Label()
        pdRecibo = New Printing.PrintDocument()
        pdConstancia = New Printing.PrintDocument()
        ppdVista = New PrintPreviewDialog()
        psdPagina = New PageSetupDialog()
        prdImpresora = New PrintDialog()
        btnImprimirRecibo = New Button()
        btnConstancia = New Button()
        chkImprimirAlRegistrar = New CheckBox()
        grpSocio.SuspendLayout()
        grpMembresia.SuspendLayout()
        CType(dgvMembresias, ComponentModel.ISupportInitialize).BeginInit()
        grpRegistrar.SuspendLayout()
        CType(dgvPagos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' grpSocio
        ' 
        grpSocio.Controls.Add(txtNombreSocio)
        grpSocio.Controls.Add(lblNombreSocio)
        grpSocio.Controls.Add(btnBuscarSocio)
        grpSocio.Controls.Add(txtCedula)
        grpSocio.Controls.Add(lblCedula)
        grpSocio.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
        grpSocio.Location = New Point(17, 35)
        grpSocio.Margin = New Padding(4, 5, 4, 5)
        grpSocio.Name = "grpSocio"
        grpSocio.Padding = New Padding(4, 5, 4, 5)
        grpSocio.Size = New Size(524, 180)
        grpSocio.TabIndex = 0
        grpSocio.TabStop = False
        grpSocio.Text = "Socio"
        ' 
        ' txtNombreSocio
        ' 
        txtNombreSocio.BackColor = SystemColors.ButtonHighlight
        txtNombreSocio.Location = New Point(100, 107)
        txtNombreSocio.Margin = New Padding(4, 5, 4, 5)
        txtNombreSocio.Name = "txtNombreSocio"
        txtNombreSocio.ReadOnly = True
        txtNombreSocio.Size = New Size(300, 31)
        txtNombreSocio.TabIndex = 4
        ' 
        ' lblNombreSocio
        ' 
        lblNombreSocio.AutoSize = True
        lblNombreSocio.Location = New Point(24, 120)
        lblNombreSocio.Margin = New Padding(4, 0, 4, 0)
        lblNombreSocio.Name = "lblNombreSocio"
        lblNombreSocio.Size = New Size(60, 25)
        lblNombreSocio.TabIndex = 3
        lblNombreSocio.Text = "Socio:"
        ' 
        ' btnBuscarSocio
        ' 
        btnBuscarSocio.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
        btnBuscarSocio.Location = New Point(410, 47)
        btnBuscarSocio.Margin = New Padding(4, 5, 4, 5)
        btnBuscarSocio.Name = "btnBuscarSocio"
        btnBuscarSocio.Size = New Size(93, 38)
        btnBuscarSocio.TabIndex = 2
        btnBuscarSocio.Text = "Buscar"
        btnBuscarSocio.UseVisualStyleBackColor = True
        ' 
        ' txtCedula
        ' 
        txtCedula.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtCedula.Location = New Point(100, 47)
        txtCedula.Margin = New Padding(4, 5, 4, 5)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(300, 31)
        txtCedula.TabIndex = 1
        ' 
        ' lblCedula
        ' 
        lblCedula.AutoSize = True
        lblCedula.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblCedula.Location = New Point(24, 60)
        lblCedula.Margin = New Padding(4, 0, 4, 0)
        lblCedula.Name = "lblCedula"
        lblCedula.Size = New Size(70, 25)
        lblCedula.TabIndex = 0
        lblCedula.Text = "Cédula:"
        ' 
        ' grpMembresia
        ' 
        grpMembresia.Controls.Add(btnCancelarMembresia)
        grpMembresia.Controls.Add(btnGuardarMembresia)
        grpMembresia.Controls.Add(btnNuevaMembresia)
        grpMembresia.Controls.Add(cboEstadoMembresia)
        grpMembresia.Controls.Add(lblEstadoMembresia)
        grpMembresia.Controls.Add(txtPrecioPactado)
        grpMembresia.Controls.Add(lblPrecioPactado)
        grpMembresia.Controls.Add(dtpFechaVencimiento)
        grpMembresia.Controls.Add(lblFechaVencimiento)
        grpMembresia.Controls.Add(dtpFechaInicio)
        grpMembresia.Controls.Add(lblFechaInicio)
        grpMembresia.Controls.Add(cboTipoMembresia)
        grpMembresia.Controls.Add(lblTipoMembresia)
        grpMembresia.Location = New Point(17, 245)
        grpMembresia.Margin = New Padding(4, 5, 4, 5)
        grpMembresia.Name = "grpMembresia"
        grpMembresia.Padding = New Padding(4, 5, 4, 5)
        grpMembresia.Size = New Size(524, 452)
        grpMembresia.TabIndex = 1
        grpMembresia.TabStop = False
        grpMembresia.Text = "Membresía"
        ' 
        ' btnCancelarMembresia
        ' 
        btnCancelarMembresia.Location = New Point(341, 380)
        btnCancelarMembresia.Margin = New Padding(4, 5, 4, 5)
        btnCancelarMembresia.Name = "btnCancelarMembresia"
        btnCancelarMembresia.Size = New Size(150, 47)
        btnCancelarMembresia.TabIndex = 12
        btnCancelarMembresia.Text = "Cancelar"
        btnCancelarMembresia.UseVisualStyleBackColor = True
        ' 
        ' btnGuardarMembresia
        ' 
        btnGuardarMembresia.Location = New Point(183, 380)
        btnGuardarMembresia.Margin = New Padding(4, 5, 4, 5)
        btnGuardarMembresia.Name = "btnGuardarMembresia"
        btnGuardarMembresia.Size = New Size(150, 47)
        btnGuardarMembresia.TabIndex = 11
        btnGuardarMembresia.Text = "Guardar"
        btnGuardarMembresia.UseVisualStyleBackColor = True
        ' 
        ' btnNuevaMembresia
        ' 
        btnNuevaMembresia.Location = New Point(24, 380)
        btnNuevaMembresia.Margin = New Padding(4, 5, 4, 5)
        btnNuevaMembresia.Name = "btnNuevaMembresia"
        btnNuevaMembresia.Size = New Size(150, 47)
        btnNuevaMembresia.TabIndex = 10
        btnNuevaMembresia.Text = "Nuevo"
        btnNuevaMembresia.UseVisualStyleBackColor = True
        ' 
        ' cboEstadoMembresia
        ' 
        cboEstadoMembresia.FormattingEnabled = True
        cboEstadoMembresia.Location = New Point(231, 322)
        cboEstadoMembresia.Margin = New Padding(4, 5, 4, 5)
        cboEstadoMembresia.Name = "cboEstadoMembresia"
        cboEstadoMembresia.Size = New Size(278, 33)
        cboEstadoMembresia.TabIndex = 9
        ' 
        ' lblEstadoMembresia
        ' 
        lblEstadoMembresia.AutoSize = True
        lblEstadoMembresia.Location = New Point(33, 322)
        lblEstadoMembresia.Margin = New Padding(4, 0, 4, 0)
        lblEstadoMembresia.Name = "lblEstadoMembresia"
        lblEstadoMembresia.Size = New Size(70, 25)
        lblEstadoMembresia.TabIndex = 8
        lblEstadoMembresia.Text = "Estado:"
        ' 
        ' txtPrecioPactado
        ' 
        txtPrecioPactado.BackColor = SystemColors.ButtonHighlight
        txtPrecioPactado.Location = New Point(231, 257)
        txtPrecioPactado.Margin = New Padding(4, 5, 4, 5)
        txtPrecioPactado.Name = "txtPrecioPactado"
        txtPrecioPactado.ReadOnly = True
        txtPrecioPactado.Size = New Size(278, 31)
        txtPrecioPactado.TabIndex = 7
        ' 
        ' lblPrecioPactado
        ' 
        lblPrecioPactado.AutoSize = True
        lblPrecioPactado.Location = New Point(33, 262)
        lblPrecioPactado.Margin = New Padding(4, 0, 4, 0)
        lblPrecioPactado.Name = "lblPrecioPactado"
        lblPrecioPactado.Size = New Size(134, 25)
        lblPrecioPactado.TabIndex = 6
        lblPrecioPactado.Text = "Precio pactado:"
        ' 
        ' dtpFechaVencimiento
        ' 
        dtpFechaVencimiento.Enabled = False
        dtpFechaVencimiento.Location = New Point(236, 190)
        dtpFechaVencimiento.Margin = New Padding(4, 5, 4, 5)
        dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        dtpFechaVencimiento.Size = New Size(227, 31)
        dtpFechaVencimiento.TabIndex = 5
        ' 
        ' lblFechaVencimiento
        ' 
        lblFechaVencimiento.AutoSize = True
        lblFechaVencimiento.Location = New Point(33, 190)
        lblFechaVencimiento.Margin = New Padding(4, 0, 4, 0)
        lblFechaVencimiento.Name = "lblFechaVencimiento"
        lblFechaVencimiento.Size = New Size(187, 25)
        lblFechaVencimiento.TabIndex = 4
        lblFechaVencimiento.Text = "Fecha de vencimiento:"
        ' 
        ' dtpFechaInicio
        ' 
        dtpFechaInicio.Location = New Point(236, 130)
        dtpFechaInicio.Margin = New Padding(4, 5, 4, 5)
        dtpFechaInicio.Name = "dtpFechaInicio"
        dtpFechaInicio.Size = New Size(227, 31)
        dtpFechaInicio.TabIndex = 3
        ' 
        ' lblFechaInicio
        ' 
        lblFechaInicio.AutoSize = True
        lblFechaInicio.Location = New Point(33, 130)
        lblFechaInicio.Margin = New Padding(4, 0, 4, 0)
        lblFechaInicio.Name = "lblFechaInicio"
        lblFechaInicio.Size = New Size(132, 25)
        lblFechaInicio.TabIndex = 2
        lblFechaInicio.Text = "Fecha de inicio:"
        ' 
        ' cboTipoMembresia
        ' 
        cboTipoMembresia.FormattingEnabled = True
        cboTipoMembresia.Location = New Point(231, 68)
        cboTipoMembresia.Margin = New Padding(4, 5, 4, 5)
        cboTipoMembresia.Name = "cboTipoMembresia"
        cboTipoMembresia.Size = New Size(283, 33)
        cboTipoMembresia.TabIndex = 1
        ' 
        ' lblTipoMembresia
        ' 
        lblTipoMembresia.AutoSize = True
        lblTipoMembresia.Location = New Point(33, 73)
        lblTipoMembresia.Margin = New Padding(4, 0, 4, 0)
        lblTipoMembresia.Name = "lblTipoMembresia"
        lblTipoMembresia.Size = New Size(169, 25)
        lblTipoMembresia.TabIndex = 0
        lblTipoMembresia.Text = "Tipo de membresía:"
        ' 
        ' dgvMembresias
        ' 
        dgvMembresias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMembresias.Location = New Point(584, 50)
        dgvMembresias.Margin = New Padding(4, 5, 4, 5)
        dgvMembresias.Name = "dgvMembresias"
        dgvMembresias.RowHeadersWidth = 62
        dgvMembresias.Size = New Size(726, 165)
        dgvMembresias.TabIndex = 2
        ' 
        ' lblTituloMembresias
        ' 
        lblTituloMembresias.AutoSize = True
        lblTituloMembresias.Location = New Point(854, 20)
        lblTituloMembresias.Margin = New Padding(4, 0, 4, 0)
        lblTituloMembresias.Name = "lblTituloMembresias"
        lblTituloMembresias.Size = New Size(184, 25)
        lblTituloMembresias.TabIndex = 3
        lblTituloMembresias.Text = "Membresías del socio"
        ' 
        ' grpRegistrar
        ' 
        grpRegistrar.Controls.Add(btnRegistrarPago)
        grpRegistrar.Controls.Add(txtObservacion)
        grpRegistrar.Controls.Add(lblObservacion)
        grpRegistrar.Controls.Add(txtReferencia)
        grpRegistrar.Controls.Add(lblReferencia)
        grpRegistrar.Controls.Add(cboMetodoPago)
        grpRegistrar.Controls.Add(lblMetodoPago)
        grpRegistrar.Controls.Add(txtMonto)
        grpRegistrar.Controls.Add(lblMonto)
        grpRegistrar.Location = New Point(589, 258)
        grpRegistrar.Margin = New Padding(4, 5, 4, 5)
        grpRegistrar.Name = "grpRegistrar"
        grpRegistrar.Padding = New Padding(4, 5, 4, 5)
        grpRegistrar.Size = New Size(717, 433)
        grpRegistrar.TabIndex = 4
        grpRegistrar.TabStop = False
        grpRegistrar.Text = "Registrar pago"
        ' 
        ' btnRegistrarPago
        ' 
        btnRegistrarPago.Location = New Point(569, 367)
        btnRegistrarPago.Margin = New Padding(4, 5, 4, 5)
        btnRegistrarPago.Name = "btnRegistrarPago"
        btnRegistrarPago.Size = New Size(114, 38)
        btnRegistrarPago.TabIndex = 8
        btnRegistrarPago.Text = "Registrar pago"
        btnRegistrarPago.UseVisualStyleBackColor = True
        ' 
        ' txtObservacion
        ' 
        txtObservacion.Location = New Point(191, 277)
        txtObservacion.Margin = New Padding(4, 5, 4, 5)
        txtObservacion.Name = "txtObservacion"
        txtObservacion.Size = New Size(471, 31)
        txtObservacion.TabIndex = 7
        ' 
        ' lblObservacion
        ' 
        lblObservacion.AutoSize = True
        lblObservacion.Location = New Point(29, 290)
        lblObservacion.Margin = New Padding(4, 0, 4, 0)
        lblObservacion.Name = "lblObservacion"
        lblObservacion.Size = New Size(115, 25)
        lblObservacion.TabIndex = 6
        lblObservacion.Text = "Observación:"
        ' 
        ' txtReferencia
        ' 
        txtReferencia.Location = New Point(191, 200)
        txtReferencia.Margin = New Padding(4, 5, 4, 5)
        txtReferencia.Name = "txtReferencia"
        txtReferencia.Size = New Size(471, 31)
        txtReferencia.TabIndex = 5
        ' 
        ' lblReferencia
        ' 
        lblReferencia.AutoSize = True
        lblReferencia.Location = New Point(29, 205)
        lblReferencia.Margin = New Padding(4, 0, 4, 0)
        lblReferencia.Name = "lblReferencia"
        lblReferencia.Size = New Size(96, 25)
        lblReferencia.TabIndex = 4
        lblReferencia.Text = "Referencia:"
        ' 
        ' cboMetodoPago
        ' 
        cboMetodoPago.FormattingEnabled = True
        cboMetodoPago.Location = New Point(191, 118)
        cboMetodoPago.Margin = New Padding(4, 5, 4, 5)
        cboMetodoPago.Name = "cboMetodoPago"
        cboMetodoPago.Size = New Size(471, 33)
        cboMetodoPago.TabIndex = 3
        ' 
        ' lblMetodoPago
        ' 
        lblMetodoPago.AutoSize = True
        lblMetodoPago.Location = New Point(29, 122)
        lblMetodoPago.Margin = New Padding(4, 0, 4, 0)
        lblMetodoPago.Name = "lblMetodoPago"
        lblMetodoPago.Size = New Size(152, 25)
        lblMetodoPago.TabIndex = 2
        lblMetodoPago.Text = "Método de pago:"
        ' 
        ' txtMonto
        ' 
        txtMonto.Location = New Point(191, 47)
        txtMonto.Margin = New Padding(4, 5, 4, 5)
        txtMonto.Name = "txtMonto"
        txtMonto.Size = New Size(471, 31)
        txtMonto.TabIndex = 1
        ' 
        ' lblMonto
        ' 
        lblMonto.AutoSize = True
        lblMonto.Location = New Point(29, 52)
        lblMonto.Margin = New Padding(4, 0, 4, 0)
        lblMonto.Name = "lblMonto"
        lblMonto.Size = New Size(70, 25)
        lblMonto.TabIndex = 0
        lblMonto.Text = "Monto:"
        ' 
        ' dgvPagos
        ' 
        dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPagos.Location = New Point(589, 732)
        dgvPagos.Margin = New Padding(4, 5, 4, 5)
        dgvPagos.Name = "dgvPagos"
        dgvPagos.RowHeadersWidth = 62
        dgvPagos.Size = New Size(717, 215)
        dgvPagos.TabIndex = 5
        ' 
        ' lblTituloPagos
        ' 
        lblTituloPagos.AutoSize = True
        lblTituloPagos.Location = New Point(881, 702)
        lblTituloPagos.Margin = New Padding(4, 0, 4, 0)
        lblTituloPagos.Name = "lblTituloPagos"
        lblTituloPagos.Size = New Size(157, 25)
        lblTituloPagos.TabIndex = 6
        lblTituloPagos.Text = "Historial de pagos"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(651, 973)
        lblTotal.Margin = New Padding(4, 0, 4, 0)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(113, 25)
        lblTotal.TabIndex = 7
        lblTotal.Text = "Total: C$0.00"
        ' 
        ' lblSaldo
        ' 
        lblSaldo.AutoSize = True
        lblSaldo.Location = New Point(1143, 973)
        lblSaldo.Margin = New Padding(4, 0, 4, 0)
        lblSaldo.Name = "lblSaldo"
        lblSaldo.Size = New Size(121, 25)
        lblSaldo.TabIndex = 8
        lblSaldo.Text = "Saldo: C$0.00"
        ' 
        ' lblPagado
        ' 
        lblPagado.AutoSize = True
        lblPagado.Location = New Point(901, 973)
        lblPagado.Margin = New Padding(4, 0, 4, 0)
        lblPagado.Name = "lblPagado"
        lblPagado.Size = New Size(136, 25)
        lblPagado.TabIndex = 9
        lblPagado.Text = "Pagado: C$0.00"
        ' 
        ' pdRecibo
        ' 
        pdRecibo.DocumentName = "Recibo GymControl "
        ' 
        ' pdConstancia
        ' 
        pdConstancia.DocumentName = "Constancia de membresía"
        ' 
        ' ppdVista
        ' 
        ppdVista.AutoScrollMargin = New Size(0, 0)
        ppdVista.AutoScrollMinSize = New Size(0, 0)
        ppdVista.ClientSize = New Size(400, 300)
        ppdVista.Enabled = True
        ppdVista.Icon = CType(resources.GetObject("ppdVista.Icon"), Icon)
        ppdVista.Name = "ppdVista"
        ppdVista.ShowIcon = False
        ppdVista.UseAntiAlias = True
        ppdVista.Visible = False
        ' 
        ' psdPagina
        ' 
        psdPagina.Document = pdConstancia
        psdPagina.EnableMetric = True
        ' 
        ' prdImpresora
        ' 
        prdImpresora.UseEXDialog = True
        ' 
        ' btnImprimirRecibo
        ' 
        btnImprimirRecibo.Enabled = False
        btnImprimirRecibo.Location = New Point(41, 762)
        btnImprimirRecibo.Name = "btnImprimirRecibo"
        btnImprimirRecibo.Size = New Size(169, 34)
        btnImprimirRecibo.TabIndex = 10
        btnImprimirRecibo.Text = "Imprimir Recibo"
        btnImprimirRecibo.UseVisualStyleBackColor = True
        ' 
        ' btnConstancia
        ' 
        btnConstancia.Enabled = False
        btnConstancia.Location = New Point(228, 762)
        btnConstancia.Name = "btnConstancia"
        btnConstancia.Size = New Size(112, 34)
        btnConstancia.TabIndex = 11
        btnConstancia.Text = "Constancia"
        btnConstancia.UseVisualStyleBackColor = True
        ' 
        ' chkImprimirAlRegistrar
        ' 
        chkImprimirAlRegistrar.AutoSize = True
        chkImprimirAlRegistrar.Checked = True
        chkImprimirAlRegistrar.CheckState = CheckState.Checked
        chkImprimirAlRegistrar.Location = New Point(41, 822)
        chkImprimirAlRegistrar.Name = "chkImprimirAlRegistrar"
        chkImprimirAlRegistrar.Size = New Size(258, 29)
        chkImprimirAlRegistrar.TabIndex = 12
        chkImprimirAlRegistrar.Text = "Imprimir  recibo al registrar "
        chkImprimirAlRegistrar.UseVisualStyleBackColor = True
        ' 
        ' FrmMembresiasPagos
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1380, 1050)
        Controls.Add(chkImprimirAlRegistrar)
        Controls.Add(btnConstancia)
        Controls.Add(btnImprimirRecibo)
        Controls.Add(lblPagado)
        Controls.Add(lblSaldo)
        Controls.Add(lblTotal)
        Controls.Add(lblTituloPagos)
        Controls.Add(dgvPagos)
        Controls.Add(grpRegistrar)
        Controls.Add(lblTituloMembresias)
        Controls.Add(dgvMembresias)
        Controls.Add(grpMembresia)
        Controls.Add(grpSocio)
        Margin = New Padding(4, 5, 4, 5)
        Name = "FrmMembresiasPagos"
        Text = "FrmMembresiasPagos"
        grpSocio.ResumeLayout(False)
        grpSocio.PerformLayout()
        grpMembresia.ResumeLayout(False)
        grpMembresia.PerformLayout()
        CType(dgvMembresias, ComponentModel.ISupportInitialize).EndInit()
        grpRegistrar.ResumeLayout(False)
        grpRegistrar.PerformLayout()
        CType(dgvPagos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents grpSocio As GroupBox
    Friend WithEvents lblNombreSocio As Label
    Friend WithEvents btnBuscarSocio As Button
    Friend WithEvents txtCedula As TextBox
    Friend WithEvents lblCedula As Label
    Friend WithEvents txtNombreSocio As TextBox
    Friend WithEvents grpMembresia As GroupBox
    Friend WithEvents dtpFechaVencimiento As DateTimePicker
    Friend WithEvents lblFechaVencimiento As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents lblFechaInicio As Label
    Friend WithEvents cboTipoMembresia As ComboBox
    Friend WithEvents lblTipoMembresia As Label
    Friend WithEvents cboEstadoMembresia As ComboBox
    Friend WithEvents lblEstadoMembresia As Label
    Friend WithEvents txtPrecioPactado As TextBox
    Friend WithEvents lblPrecioPactado As Label
    Friend WithEvents btnCancelarMembresia As Button
    Friend WithEvents btnGuardarMembresia As Button
    Friend WithEvents btnNuevaMembresia As Button
    Friend WithEvents dgvMembresias As DataGridView
    Friend WithEvents lblTituloMembresias As Label
    Friend WithEvents grpRegistrar As GroupBox
    Friend WithEvents lblObservacion As Label
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents lblReferencia As Label
    Friend WithEvents cboMetodoPago As ComboBox
    Friend WithEvents lblMetodoPago As Label
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents lblMonto As Label
    Friend WithEvents btnRegistrarPago As Button
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents dgvPagos As DataGridView
    Friend WithEvents lblTituloPagos As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblSaldo As Label
    Friend WithEvents lblPagado As Label
    Friend WithEvents pdRecibo As Printing.PrintDocument
    Friend WithEvents pdConstancia As Printing.PrintDocument
    Friend WithEvents ppdVista As PrintPreviewDialog
    Friend WithEvents psdPagina As PageSetupDialog
    Friend WithEvents prdImpresora As PrintDialog
    Friend WithEvents btnImprimirRecibo As Button
    Friend WithEvents btnConstancia As Button
    Friend WithEvents chkImprimirAlRegistrar As CheckBox
End Class
