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
        grpSocio.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        grpSocio.Location = New Point(12, 21)
        grpSocio.Name = "grpSocio"
        grpSocio.Size = New Size(367, 108)
        grpSocio.TabIndex = 0
        grpSocio.TabStop = False
        grpSocio.Text = "Socio"
        ' 
        ' txtNombreSocio
        ' 
        txtNombreSocio.BackColor = SystemColors.ButtonHighlight
        txtNombreSocio.Location = New Point(70, 64)
        txtNombreSocio.Name = "txtNombreSocio"
        txtNombreSocio.ReadOnly = True
        txtNombreSocio.Size = New Size(211, 23)
        txtNombreSocio.TabIndex = 4
        ' 
        ' lblNombreSocio
        ' 
        lblNombreSocio.AutoSize = True
        lblNombreSocio.Location = New Point(17, 72)
        lblNombreSocio.Name = "lblNombreSocio"
        lblNombreSocio.Size = New Size(39, 15)
        lblNombreSocio.TabIndex = 3
        lblNombreSocio.Text = "Socio:"
        ' 
        ' btnBuscarSocio
        ' 
        btnBuscarSocio.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnBuscarSocio.Location = New Point(287, 28)
        btnBuscarSocio.Name = "btnBuscarSocio"
        btnBuscarSocio.Size = New Size(65, 23)
        btnBuscarSocio.TabIndex = 2
        btnBuscarSocio.Text = "Buscar"
        btnBuscarSocio.UseVisualStyleBackColor = True
        ' 
        ' txtCedula
        ' 
        txtCedula.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCedula.Location = New Point(70, 28)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(211, 23)
        txtCedula.TabIndex = 1
        ' 
        ' lblCedula
        ' 
        lblCedula.AutoSize = True
        lblCedula.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCedula.Location = New Point(17, 36)
        lblCedula.Name = "lblCedula"
        lblCedula.Size = New Size(47, 15)
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
        grpMembresia.Location = New Point(12, 147)
        grpMembresia.Name = "grpMembresia"
        grpMembresia.Size = New Size(367, 271)
        grpMembresia.TabIndex = 1
        grpMembresia.TabStop = False
        grpMembresia.Text = "Membresía"
        ' 
        ' btnCancelarMembresia
        ' 
        btnCancelarMembresia.Location = New Point(239, 228)
        btnCancelarMembresia.Name = "btnCancelarMembresia"
        btnCancelarMembresia.Size = New Size(105, 28)
        btnCancelarMembresia.TabIndex = 12
        btnCancelarMembresia.Text = "Cancelar"
        btnCancelarMembresia.UseVisualStyleBackColor = True
        ' 
        ' btnGuardarMembresia
        ' 
        btnGuardarMembresia.Location = New Point(128, 228)
        btnGuardarMembresia.Name = "btnGuardarMembresia"
        btnGuardarMembresia.Size = New Size(105, 28)
        btnGuardarMembresia.TabIndex = 11
        btnGuardarMembresia.Text = "Guardar"
        btnGuardarMembresia.UseVisualStyleBackColor = True
        ' 
        ' btnNuevaMembresia
        ' 
        btnNuevaMembresia.Location = New Point(17, 228)
        btnNuevaMembresia.Name = "btnNuevaMembresia"
        btnNuevaMembresia.Size = New Size(105, 28)
        btnNuevaMembresia.TabIndex = 10
        btnNuevaMembresia.Text = "Nuevo"
        btnNuevaMembresia.UseVisualStyleBackColor = True
        ' 
        ' cboEstadoMembresia
        ' 
        cboEstadoMembresia.FormattingEnabled = True
        cboEstadoMembresia.Location = New Point(162, 193)
        cboEstadoMembresia.Name = "cboEstadoMembresia"
        cboEstadoMembresia.Size = New Size(196, 23)
        cboEstadoMembresia.TabIndex = 9
        ' 
        ' lblEstadoMembresia
        ' 
        lblEstadoMembresia.AutoSize = True
        lblEstadoMembresia.Location = New Point(23, 193)
        lblEstadoMembresia.Name = "lblEstadoMembresia"
        lblEstadoMembresia.Size = New Size(45, 15)
        lblEstadoMembresia.TabIndex = 8
        lblEstadoMembresia.Text = "Estado:"
        ' 
        ' txtPrecioPactado
        ' 
        txtPrecioPactado.BackColor = SystemColors.ButtonHighlight
        txtPrecioPactado.Location = New Point(162, 154)
        txtPrecioPactado.Name = "txtPrecioPactado"
        txtPrecioPactado.ReadOnly = True
        txtPrecioPactado.Size = New Size(196, 23)
        txtPrecioPactado.TabIndex = 7
        ' 
        ' lblPrecioPactado
        ' 
        lblPrecioPactado.AutoSize = True
        lblPrecioPactado.Location = New Point(23, 157)
        lblPrecioPactado.Name = "lblPrecioPactado"
        lblPrecioPactado.Size = New Size(89, 15)
        lblPrecioPactado.TabIndex = 6
        lblPrecioPactado.Text = "Precio pactado:"
        ' 
        ' dtpFechaVencimiento
        ' 
        dtpFechaVencimiento.Enabled = False
        dtpFechaVencimiento.Location = New Point(165, 114)
        dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        dtpFechaVencimiento.Size = New Size(160, 23)
        dtpFechaVencimiento.TabIndex = 5
        ' 
        ' lblFechaVencimiento
        ' 
        lblFechaVencimiento.AutoSize = True
        lblFechaVencimiento.Location = New Point(23, 114)
        lblFechaVencimiento.Name = "lblFechaVencimiento"
        lblFechaVencimiento.Size = New Size(126, 15)
        lblFechaVencimiento.TabIndex = 4
        lblFechaVencimiento.Text = "Fecha de vencimiento:"
        ' 
        ' dtpFechaInicio
        ' 
        dtpFechaInicio.Location = New Point(165, 78)
        dtpFechaInicio.Name = "dtpFechaInicio"
        dtpFechaInicio.Size = New Size(160, 23)
        dtpFechaInicio.TabIndex = 3
        ' 
        ' lblFechaInicio
        ' 
        lblFechaInicio.AutoSize = True
        lblFechaInicio.Location = New Point(23, 78)
        lblFechaInicio.Name = "lblFechaInicio"
        lblFechaInicio.Size = New Size(89, 15)
        lblFechaInicio.TabIndex = 2
        lblFechaInicio.Text = "Fecha de inicio:"
        ' 
        ' cboTipoMembresia
        ' 
        cboTipoMembresia.FormattingEnabled = True
        cboTipoMembresia.Location = New Point(162, 41)
        cboTipoMembresia.Name = "cboTipoMembresia"
        cboTipoMembresia.Size = New Size(199, 23)
        cboTipoMembresia.TabIndex = 1
        ' 
        ' lblTipoMembresia
        ' 
        lblTipoMembresia.AutoSize = True
        lblTipoMembresia.Location = New Point(23, 44)
        lblTipoMembresia.Name = "lblTipoMembresia"
        lblTipoMembresia.Size = New Size(112, 15)
        lblTipoMembresia.TabIndex = 0
        lblTipoMembresia.Text = "Tipo de membresía:"
        ' 
        ' dgvMembresias
        ' 
        dgvMembresias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMembresias.Location = New Point(409, 30)
        dgvMembresias.Name = "dgvMembresias"
        dgvMembresias.Size = New Size(508, 99)
        dgvMembresias.TabIndex = 2
        ' 
        ' lblTituloMembresias
        ' 
        lblTituloMembresias.AutoSize = True
        lblTituloMembresias.Location = New Point(598, 12)
        lblTituloMembresias.Name = "lblTituloMembresias"
        lblTituloMembresias.Size = New Size(121, 15)
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
        grpRegistrar.Location = New Point(412, 155)
        grpRegistrar.Name = "grpRegistrar"
        grpRegistrar.Size = New Size(502, 260)
        grpRegistrar.TabIndex = 4
        grpRegistrar.TabStop = False
        grpRegistrar.Text = "Registrar pago"
        ' 
        ' btnRegistrarPago
        ' 
        btnRegistrarPago.Location = New Point(398, 220)
        btnRegistrarPago.Name = "btnRegistrarPago"
        btnRegistrarPago.Size = New Size(80, 23)
        btnRegistrarPago.TabIndex = 8
        btnRegistrarPago.Text = "Registrar pago"
        btnRegistrarPago.UseVisualStyleBackColor = True
        ' 
        ' txtObservacion
        ' 
        txtObservacion.Location = New Point(134, 166)
        txtObservacion.Name = "txtObservacion"
        txtObservacion.Size = New Size(331, 23)
        txtObservacion.TabIndex = 7
        ' 
        ' lblObservacion
        ' 
        lblObservacion.AutoSize = True
        lblObservacion.Location = New Point(20, 174)
        lblObservacion.Name = "lblObservacion"
        lblObservacion.Size = New Size(76, 15)
        lblObservacion.TabIndex = 6
        lblObservacion.Text = "Observación:"
        ' 
        ' txtReferencia
        ' 
        txtReferencia.Location = New Point(134, 120)
        txtReferencia.Name = "txtReferencia"
        txtReferencia.Size = New Size(331, 23)
        txtReferencia.TabIndex = 5
        ' 
        ' lblReferencia
        ' 
        lblReferencia.AutoSize = True
        lblReferencia.Location = New Point(20, 123)
        lblReferencia.Name = "lblReferencia"
        lblReferencia.Size = New Size(65, 15)
        lblReferencia.TabIndex = 4
        lblReferencia.Text = "Referencia:"
        ' 
        ' cboMetodoPago
        ' 
        cboMetodoPago.FormattingEnabled = True
        cboMetodoPago.Location = New Point(134, 71)
        cboMetodoPago.Name = "cboMetodoPago"
        cboMetodoPago.Size = New Size(331, 23)
        cboMetodoPago.TabIndex = 3
        ' 
        ' lblMetodoPago
        ' 
        lblMetodoPago.AutoSize = True
        lblMetodoPago.Location = New Point(20, 73)
        lblMetodoPago.Name = "lblMetodoPago"
        lblMetodoPago.Size = New Size(98, 15)
        lblMetodoPago.TabIndex = 2
        lblMetodoPago.Text = "Método de pago:"
        ' 
        ' txtMonto
        ' 
        txtMonto.Location = New Point(134, 28)
        txtMonto.Name = "txtMonto"
        txtMonto.Size = New Size(331, 23)
        txtMonto.TabIndex = 1
        ' 
        ' lblMonto
        ' 
        lblMonto.AutoSize = True
        lblMonto.Location = New Point(20, 31)
        lblMonto.Name = "lblMonto"
        lblMonto.Size = New Size(46, 15)
        lblMonto.TabIndex = 0
        lblMonto.Text = "Monto:"
        ' 
        ' dgvPagos
        ' 
        dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPagos.Location = New Point(412, 439)
        dgvPagos.Name = "dgvPagos"
        dgvPagos.Size = New Size(502, 129)
        dgvPagos.TabIndex = 5
        ' 
        ' lblTituloPagos
        ' 
        lblTituloPagos.AutoSize = True
        lblTituloPagos.Location = New Point(617, 421)
        lblTituloPagos.Name = "lblTituloPagos"
        lblTituloPagos.Size = New Size(102, 15)
        lblTituloPagos.TabIndex = 6
        lblTituloPagos.Text = "Historial de pagos"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(456, 584)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(74, 15)
        lblTotal.TabIndex = 7
        lblTotal.Text = "Total: C$0.00"
        ' 
        ' lblSaldo
        ' 
        lblSaldo.AutoSize = True
        lblSaldo.Location = New Point(800, 584)
        lblSaldo.Name = "lblSaldo"
        lblSaldo.Size = New Size(77, 15)
        lblSaldo.TabIndex = 8
        lblSaldo.Text = "Saldo: C$0.00"
        ' 
        ' lblPagado
        ' 
        lblPagado.AutoSize = True
        lblPagado.Location = New Point(631, 584)
        lblPagado.Name = "lblPagado"
        lblPagado.Size = New Size(88, 15)
        lblPagado.TabIndex = 9
        lblPagado.Text = "Pagado: C$0.00"
        ' 
        ' frmMembresiasPagos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(966, 669)
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
        Name = "frmMembresiasPagos"
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
End Class
