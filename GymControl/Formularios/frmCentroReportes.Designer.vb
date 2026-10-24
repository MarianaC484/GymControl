<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCentroReportes
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
        pnlEncabezado = New Panel()
        Label1 = New Label()
        picLogo = New PictureBox()
        tvReportes = New TreeView()
        lblNombreReporte = New Label()
        lblDescripcion = New Label()
        grpParametros = New GroupBox()
        pnlParamFechas = New Panel()
        pnlParamSocio = New Panel()
        cboSocio = New ComboBox()
        lblSocio = New Label()
        pnlParamDias = New Panel()
        pnlParamInstructor = New Panel()
        btnVistaPrevia = New Button()
        btnImprimir = New Button()
        btnExportarPdf = New Button()
        btnExportarExcel = New Button()
        btnCerrar = New Button()
        stsEstado = New StatusStrip()
        tslEstado = New ToolStripStatusLabel()
        tspProgreso = New ToolStripProgressBar()
        tslUsuario = New ToolStripStatusLabel()
        pnlEncabezado.SuspendLayout()
        CType(picLogo, ComponentModel.ISupportInitialize).BeginInit()
        pnlParamSocio.SuspendLayout()
        stsEstado.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlEncabezado
        ' 
        pnlEncabezado.BackColor = Color.FromArgb(CByte(25), CByte(61), CByte(136))
        pnlEncabezado.Controls.Add(Label1)
        pnlEncabezado.Controls.Add(picLogo)
        pnlEncabezado.Dock = DockStyle.Top
        pnlEncabezado.Location = New Point(0, 0)
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Size = New Size(1273, 64)
        pnlEncabezado.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 14F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(140, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(257, 38)
        Label1.TabIndex = 2
        Label1.Text = "Centro de reportes"
        ' 
        ' picLogo
        ' 
        picLogo.Image = My.Resources.Resources.Logo
        picLogo.Location = New Point(0, 0)
        picLogo.Name = "picLogo"
        picLogo.Size = New Size(113, 61)
        picLogo.SizeMode = PictureBoxSizeMode.Zoom
        picLogo.TabIndex = 1
        picLogo.TabStop = False
        ' 
        ' tvReportes
        ' 
        tvReportes.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        tvReportes.FullRowSelect = True
        tvReportes.HideSelection = False
        tvReportes.Location = New Point(12, 82)
        tvReportes.Name = "tvReportes"
        tvReportes.ShowLines = False
        tvReportes.Size = New Size(436, 582)
        tvReportes.TabIndex = 1
        ' 
        ' lblNombreReporte
        ' 
        lblNombreReporte.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblNombreReporte.Location = New Point(464, 64)
        lblNombreReporte.Name = "lblNombreReporte"
        lblNombreReporte.Size = New Size(809, 38)
        lblNombreReporte.TabIndex = 2
        lblNombreReporte.Text = "Nombre Reporte"
        ' 
        ' lblDescripcion
        ' 
        lblDescripcion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblDescripcion.Location = New Point(464, 102)
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.Size = New Size(809, 38)
        lblDescripcion.TabIndex = 3
        lblDescripcion.Text = "Descripcion"
        ' 
        ' grpParametros
        ' 
        grpParametros.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        grpParametros.Location = New Point(464, 143)
        grpParametros.Name = "grpParametros"
        grpParametros.Size = New Size(790, 163)
        grpParametros.TabIndex = 4
        grpParametros.TabStop = False
        grpParametros.Text = "Parámetros"
        ' 
        ' pnlParamFechas
        ' 
        pnlParamFechas.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlParamFechas.Location = New Point(485, 197)
        pnlParamFechas.Name = "pnlParamFechas"
        pnlParamFechas.Size = New Size(769, 78)
        pnlParamFechas.TabIndex = 5
        pnlParamFechas.Visible = False
        ' 
        ' pnlParamSocio
        ' 
        pnlParamSocio.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlParamSocio.Controls.Add(cboSocio)
        pnlParamSocio.Controls.Add(lblSocio)
        pnlParamSocio.Location = New Point(485, 183)
        pnlParamSocio.Name = "pnlParamSocio"
        pnlParamSocio.Size = New Size(766, 89)
        pnlParamSocio.TabIndex = 6
        pnlParamSocio.Visible = False
        ' 
        ' cboSocio
        ' 
        cboSocio.AutoCompleteSource = AutoCompleteSource.ListItems
        cboSocio.DropDownStyle = ComboBoxStyle.DropDownList
        cboSocio.FormattingEnabled = True
        cboSocio.Location = New Point(292, 20)
        cboSocio.Name = "cboSocio"
        cboSocio.Size = New Size(342, 36)
        cboSocio.TabIndex = 1
        ' 
        ' lblSocio
        ' 
        lblSocio.AutoSize = True
        lblSocio.Location = New Point(15, 20)
        lblSocio.Name = "lblSocio"
        lblSocio.Size = New Size(259, 28)
        lblSocio.TabIndex = 0
        lblSocio.Text = "Seleccione el Socio / Recibo:"
        ' 
        ' pnlParamDias
        ' 
        pnlParamDias.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlParamDias.Location = New Point(485, 186)
        pnlParamDias.Name = "pnlParamDias"
        pnlParamDias.Size = New Size(769, 100)
        pnlParamDias.TabIndex = 7
        pnlParamDias.Visible = False
        ' 
        ' pnlParamInstructor
        ' 
        pnlParamInstructor.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlParamInstructor.Location = New Point(485, 189)
        pnlParamInstructor.Name = "pnlParamInstructor"
        pnlParamInstructor.Size = New Size(769, 100)
        pnlParamInstructor.TabIndex = 8
        pnlParamInstructor.Visible = False
        ' 
        ' btnVistaPrevia
        ' 
        btnVistaPrevia.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnVistaPrevia.AutoSize = True
        btnVistaPrevia.BackColor = SystemColors.Highlight
        btnVistaPrevia.ForeColor = Color.White
        btnVistaPrevia.Location = New Point(464, 341)
        btnVistaPrevia.Name = "btnVistaPrevia"
        btnVistaPrevia.Size = New Size(123, 38)
        btnVistaPrevia.TabIndex = 9
        btnVistaPrevia.Text = "Vista Previa"
        btnVistaPrevia.UseVisualStyleBackColor = False
        ' 
        ' btnImprimir
        ' 
        btnImprimir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnImprimir.AutoSize = True
        btnImprimir.Location = New Point(611, 341)
        btnImprimir.Name = "btnImprimir"
        btnImprimir.Size = New Size(112, 38)
        btnImprimir.TabIndex = 10
        btnImprimir.Text = "Imprimir"
        btnImprimir.UseVisualStyleBackColor = True
        ' 
        ' btnExportarPdf
        ' 
        btnExportarPdf.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnExportarPdf.AutoSize = True
        btnExportarPdf.Location = New Point(745, 341)
        btnExportarPdf.Name = "btnExportarPdf"
        btnExportarPdf.Size = New Size(129, 38)
        btnExportarPdf.TabIndex = 11
        btnExportarPdf.Text = "Exportar Pdf"
        btnExportarPdf.UseVisualStyleBackColor = True
        ' 
        ' btnExportarExcel
        ' 
        btnExportarExcel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnExportarExcel.AutoSize = True
        btnExportarExcel.Location = New Point(890, 341)
        btnExportarExcel.Name = "btnExportarExcel"
        btnExportarExcel.Size = New Size(147, 38)
        btnExportarExcel.TabIndex = 12
        btnExportarExcel.Text = "Exportar Excel"
        btnExportarExcel.UseVisualStyleBackColor = True
        ' 
        ' btnCerrar
        ' 
        btnCerrar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCerrar.AutoSize = True
        btnCerrar.Location = New Point(1139, 341)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(112, 38)
        btnCerrar.TabIndex = 13
        btnCerrar.Text = "Cerrar"
        btnCerrar.UseVisualStyleBackColor = True
        ' 
        ' stsEstado
        ' 
        stsEstado.ImageScalingSize = New Size(24, 24)
        stsEstado.Items.AddRange(New ToolStripItem() {tslEstado, tspProgreso, tslUsuario})
        stsEstado.Location = New Point(0, 667)
        stsEstado.Name = "stsEstado"
        stsEstado.Size = New Size(1273, 32)
        stsEstado.TabIndex = 14
        stsEstado.Text = "StatusStrip1"
        ' 
        ' tslEstado
        ' 
        tslEstado.Name = "tslEstado"
        tslEstado.Size = New Size(1078, 25)
        tslEstado.Spring = True
        tslEstado.Text = "ToolStripStatusLabel1"
        ' 
        ' tspProgreso
        ' 
        tspProgreso.Name = "tspProgreso"
        tspProgreso.Size = New Size(100, 24)
        tspProgreso.Style = ProgressBarStyle.Marquee
        tspProgreso.Visible = False
        ' 
        ' tslUsuario
        ' 
        tslUsuario.Name = "tslUsuario"
        tslUsuario.Size = New Size(180, 25)
        tslUsuario.Text = "ToolStripStatusLabel1"
        ' 
        ' frmCentroReportes
        ' 
        AcceptButton = btnVistaPrevia
        AutoScaleDimensions = New SizeF(11F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCerrar
        ClientSize = New Size(1273, 699)
        Controls.Add(stsEstado)
        Controls.Add(btnCerrar)
        Controls.Add(btnExportarExcel)
        Controls.Add(btnExportarPdf)
        Controls.Add(btnImprimir)
        Controls.Add(btnVistaPrevia)
        Controls.Add(pnlParamInstructor)
        Controls.Add(pnlParamDias)
        Controls.Add(pnlParamSocio)
        Controls.Add(pnlParamFechas)
        Controls.Add(grpParametros)
        Controls.Add(lblDescripcion)
        Controls.Add(lblNombreReporte)
        Controls.Add(tvReportes)
        Controls.Add(pnlEncabezado)
        Font = New Font("Segoe UI", 10F)
        MinimumSize = New Size(988, 665)
        Name = "frmCentroReportes"
        StartPosition = FormStartPosition.CenterParent
        Text = "Centro de reportes — GymControl"
        pnlEncabezado.ResumeLayout(False)
        pnlEncabezado.PerformLayout()
        CType(picLogo, ComponentModel.ISupportInitialize).EndInit()
        pnlParamSocio.ResumeLayout(False)
        pnlParamSocio.PerformLayout()
        stsEstado.ResumeLayout(False)
        stsEstado.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tvReportes As TreeView
    Friend WithEvents lblNombreReporte As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents grpParametros As GroupBox
    Friend WithEvents pnlParamFechas As Panel
    Friend WithEvents pnlParamSocio As Panel
    Friend WithEvents pnlParamDias As Panel
    Friend WithEvents pnlParamInstructor As Panel
    Friend WithEvents btnVistaPrevia As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents btnExportarPdf As Button
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents stsEstado As StatusStrip
    Friend WithEvents tslEstado As ToolStripStatusLabel
    Friend WithEvents tspProgreso As ToolStripProgressBar
    Friend WithEvents tslUsuario As ToolStripStatusLabel
    Friend WithEvents cboSocio As ComboBox
    Friend WithEvents lblSocio As Label
End Class
