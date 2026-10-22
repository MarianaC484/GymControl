<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHorarios
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
        lblTitulo = New Label()
        lblInstructor = New Label()
        cboInstructor = New ComboBox()
        lblActividad = New Label()
        cboActividad = New ComboBox()
        lblSala = New Label()
        cboSala = New ComboBox()
        cboDia = New ComboBox()
        lblDia = New Label()
        lblHoraInicio = New Label()
        dtpHoraInicio = New DateTimePicker()
        lblHoraFin = New Label()
        dtpHoraFin = New DateTimePicker()
        btnNuevo = New Button()
        btnGuardar = New Button()
        btnEditar = New Button()
        btnEliminar = New Button()
        btnCancelar = New Button()
        dgvHorarios = New DataGridView()
        CType(dgvHorarios, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitulo.Location = New Point(224, 9)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(224, 25)
        lblTitulo.TabIndex = 0
        lblTitulo.Text = "GESTIÓN DE HORARIOS"
        ' 
        ' lblInstructor
        ' 
        lblInstructor.AutoSize = True
        lblInstructor.Location = New Point(23, 62)
        lblInstructor.Name = "lblInstructor"
        lblInstructor.Size = New Size(61, 15)
        lblInstructor.TabIndex = 1
        lblInstructor.Text = "Instructor:"
        ' 
        ' cboInstructor
        ' 
        cboInstructor.FormattingEnabled = True
        cboInstructor.Location = New Point(116, 62)
        cboInstructor.Name = "cboInstructor"
        cboInstructor.Size = New Size(233, 23)
        cboInstructor.TabIndex = 2
        ' 
        ' lblActividad
        ' 
        lblActividad.AutoSize = True
        lblActividad.Location = New Point(379, 59)
        lblActividad.Name = "lblActividad"
        lblActividad.Size = New Size(60, 15)
        lblActividad.TabIndex = 3
        lblActividad.Text = "Actividad:"
        ' 
        ' cboActividad
        ' 
        cboActividad.FormattingEnabled = True
        cboActividad.Location = New Point(454, 59)
        cboActividad.Name = "cboActividad"
        cboActividad.Size = New Size(233, 23)
        cboActividad.TabIndex = 4
        ' 
        ' lblSala
        ' 
        lblSala.AutoSize = True
        lblSala.Location = New Point(23, 112)
        lblSala.Name = "lblSala"
        lblSala.Size = New Size(31, 15)
        lblSala.TabIndex = 5
        lblSala.Text = "Sala:"
        ' 
        ' cboSala
        ' 
        cboSala.FormattingEnabled = True
        cboSala.Location = New Point(116, 107)
        cboSala.Name = "cboSala"
        cboSala.Size = New Size(233, 23)
        cboSala.TabIndex = 6
        ' 
        ' cboDia
        ' 
        cboDia.FormattingEnabled = True
        cboDia.Location = New Point(454, 104)
        cboDia.Name = "cboDia"
        cboDia.Size = New Size(233, 23)
        cboDia.TabIndex = 7
        ' 
        ' lblDia
        ' 
        lblDia.AutoSize = True
        lblDia.Location = New Point(379, 107)
        lblDia.Name = "lblDia"
        lblDia.Size = New Size(27, 15)
        lblDia.TabIndex = 8
        lblDia.Text = "Día:"
        ' 
        ' lblHoraInicio
        ' 
        lblHoraInicio.AutoSize = True
        lblHoraInicio.Location = New Point(26, 162)
        lblHoraInicio.Name = "lblHoraInicio"
        lblHoraInicio.Size = New Size(84, 15)
        lblHoraInicio.TabIndex = 9
        lblHoraInicio.Text = "Hora de inicio:"
        ' 
        ' dtpHoraInicio
        ' 
        dtpHoraInicio.Format = DateTimePickerFormat.Time
        dtpHoraInicio.Location = New Point(116, 156)
        dtpHoraInicio.Name = "dtpHoraInicio"
        dtpHoraInicio.ShowUpDown = True
        dtpHoraInicio.Size = New Size(233, 23)
        dtpHoraInicio.TabIndex = 10
        ' 
        ' lblHoraFin
        ' 
        lblHoraFin.AutoSize = True
        lblHoraFin.Location = New Point(379, 162)
        lblHoraFin.Name = "lblHoraFin"
        lblHoraFin.Size = New Size(69, 15)
        lblHoraFin.TabIndex = 11
        lblHoraFin.Text = "Hora de fin:"
        ' 
        ' dtpHoraFin
        ' 
        dtpHoraFin.Format = DateTimePickerFormat.Time
        dtpHoraFin.Location = New Point(454, 156)
        dtpHoraFin.Name = "dtpHoraFin"
        dtpHoraFin.ShowUpDown = True
        dtpHoraFin.Size = New Size(233, 23)
        dtpHoraFin.TabIndex = 12
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(76, 222)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(96, 25)
        btnNuevo.TabIndex = 13
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(190, 221)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(96, 27)
        btnGuardar.TabIndex = 14
        btnGuardar.Text = "Guardar:"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(310, 223)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(96, 26)
        btnEditar.TabIndex = 15
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Location = New Point(428, 223)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(96, 28)
        btnEliminar.TabIndex = 16
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(544, 221)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(96, 28)
        btnCancelar.TabIndex = 17
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' dgvHorarios
        ' 
        dgvHorarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvHorarios.Location = New Point(26, 273)
        dgvHorarios.Name = "dgvHorarios"
        dgvHorarios.Size = New Size(661, 304)
        dgvHorarios.TabIndex = 18
        ' 
        ' frmHorarios
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(724, 611)
        Controls.Add(dgvHorarios)
        Controls.Add(btnCancelar)
        Controls.Add(btnEliminar)
        Controls.Add(btnEditar)
        Controls.Add(btnGuardar)
        Controls.Add(btnNuevo)
        Controls.Add(dtpHoraFin)
        Controls.Add(lblHoraFin)
        Controls.Add(dtpHoraInicio)
        Controls.Add(lblHoraInicio)
        Controls.Add(lblDia)
        Controls.Add(cboDia)
        Controls.Add(cboSala)
        Controls.Add(lblSala)
        Controls.Add(cboActividad)
        Controls.Add(lblActividad)
        Controls.Add(cboInstructor)
        Controls.Add(lblInstructor)
        Controls.Add(lblTitulo)
        Name = "frmHorarios"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Gestión de Horarios"
        CType(dgvHorarios, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblInstructor As Label
    Friend WithEvents cboInstructor As ComboBox
    Friend WithEvents lblActividad As Label
    Friend WithEvents cboActividad As ComboBox
    Friend WithEvents lblSala As Label
    Friend WithEvents cboSala As ComboBox
    Friend WithEvents cboDia As ComboBox
    Friend WithEvents lblDia As Label
    Friend WithEvents lblHoraInicio As Label
    Friend WithEvents dtpHoraInicio As DateTimePicker
    Friend WithEvents lblHoraFin As Label
    Friend WithEvents dtpHoraFin As DateTimePicker
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents dgvHorarios As DataGridView
End Class
