<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Caronte
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.bt_EnviarCorreos = New System.Windows.Forms.Button()
        Me.lbl_Paciente = New System.Windows.Forms.Label()
        Me.dgv_Lista = New System.Windows.Forms.DataGridView()
        Me.Identificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Historia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Apellido1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Apellido2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ingreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EPS_cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EPS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eMail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eMailEps = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Servicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgv_Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bt_EnviarCorreos
        '
        Me.bt_EnviarCorreos.Location = New System.Drawing.Point(754, 226)
        Me.bt_EnviarCorreos.Name = "bt_EnviarCorreos"
        Me.bt_EnviarCorreos.Size = New System.Drawing.Size(128, 23)
        Me.bt_EnviarCorreos.TabIndex = 1
        Me.bt_EnviarCorreos.Text = "&Enviar correos EPS´s"
        Me.bt_EnviarCorreos.UseVisualStyleBackColor = True
        '
        'lbl_Paciente
        '
        Me.lbl_Paciente.AutoSize = True
        Me.lbl_Paciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Paciente.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_Paciente.Location = New System.Drawing.Point(91, 226)
        Me.lbl_Paciente.Name = "lbl_Paciente"
        Me.lbl_Paciente.Size = New System.Drawing.Size(14, 17)
        Me.lbl_Paciente.TabIndex = 2
        Me.lbl_Paciente.Text = "-"
        '
        'dgv_Lista
        '
        Me.dgv_Lista.AllowUserToAddRows = False
        Me.dgv_Lista.AllowUserToDeleteRows = False
        Me.dgv_Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Lista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Identificacion, Me.Historia, Me.Nombre1, Me.Nombre2, Me.Apellido1, Me.Apellido2, Me.Ingreso, Me.EPS_cod, Me.EPS, Me.eMail, Me.eMailEps, Me.Servicio})
        Me.dgv_Lista.Location = New System.Drawing.Point(12, 3)
        Me.dgv_Lista.MultiSelect = False
        Me.dgv_Lista.Name = "dgv_Lista"
        Me.dgv_Lista.ReadOnly = True
        Me.dgv_Lista.Size = New System.Drawing.Size(903, 210)
        Me.dgv_Lista.TabIndex = 4
        '
        'Identificacion
        '
        Me.Identificacion.DataPropertyName = "Identificacion"
        Me.Identificacion.HeaderText = "Identificación"
        Me.Identificacion.Name = "Identificacion"
        Me.Identificacion.ReadOnly = True
        '
        'Historia
        '
        Me.Historia.DataPropertyName = "Historia"
        Me.Historia.HeaderText = "Historia"
        Me.Historia.Name = "Historia"
        Me.Historia.ReadOnly = True
        '
        'Nombre1
        '
        Me.Nombre1.DataPropertyName = "Nombre1"
        Me.Nombre1.HeaderText = "Nombre 1"
        Me.Nombre1.Name = "Nombre1"
        Me.Nombre1.ReadOnly = True
        '
        'Nombre2
        '
        Me.Nombre2.DataPropertyName = "Nombre2"
        Me.Nombre2.HeaderText = "Nombre 2"
        Me.Nombre2.Name = "Nombre2"
        Me.Nombre2.ReadOnly = True
        '
        'Apellido1
        '
        Me.Apellido1.DataPropertyName = "Apellido1"
        Me.Apellido1.HeaderText = "Apellido 1"
        Me.Apellido1.Name = "Apellido1"
        Me.Apellido1.ReadOnly = True
        '
        'Apellido2
        '
        Me.Apellido2.DataPropertyName = "Apellido2"
        Me.Apellido2.HeaderText = "Apellido 2"
        Me.Apellido2.Name = "Apellido2"
        Me.Apellido2.ReadOnly = True
        '
        'Ingreso
        '
        Me.Ingreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Ingreso.DataPropertyName = "Ingreso"
        DataGridViewCellStyle3.Format = "G"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Ingreso.DefaultCellStyle = DataGridViewCellStyle3
        Me.Ingreso.HeaderText = "F. Ingreso"
        Me.Ingreso.Name = "Ingreso"
        Me.Ingreso.ReadOnly = True
        Me.Ingreso.Width = 77
        '
        'EPS_cod
        '
        Me.EPS_cod.DataPropertyName = "epseps"
        Me.EPS_cod.HeaderText = "EPS Cod"
        Me.EPS_cod.Name = "EPS_cod"
        Me.EPS_cod.ReadOnly = True
        '
        'EPS
        '
        Me.EPS.DataPropertyName = "EPS"
        Me.EPS.HeaderText = "EPS Nombre"
        Me.EPS.Name = "EPS"
        Me.EPS.ReadOnly = True
        Me.EPS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'eMail
        '
        Me.eMail.DataPropertyName = "eMail"
        Me.eMail.HeaderText = "eMail"
        Me.eMail.Name = "eMail"
        Me.eMail.ReadOnly = True
        '
        'eMailEps
        '
        Me.eMailEps.DataPropertyName = "eMailEps"
        Me.eMailEps.HeaderText = "eMail EPS"
        Me.eMailEps.Name = "eMailEps"
        Me.eMailEps.ReadOnly = True
        '
        'Servicio
        '
        Me.Servicio.DataPropertyName = "Servicio"
        Me.Servicio.HeaderText = "Servicio"
        Me.Servicio.Name = "Servicio"
        Me.Servicio.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 226)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "."
        '
        'Timer1
        '
        '
        'Caronte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 263)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv_Lista)
        Me.Controls.Add(Me.lbl_Paciente)
        Me.Controls.Add(Me.bt_EnviarCorreos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Caronte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Caronte"
        CType(Me.dgv_Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_EnviarCorreos As Button
    Friend WithEvents lbl_Paciente As Label
    Friend WithEvents dgv_Lista As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Identificacion As DataGridViewTextBoxColumn
    Friend WithEvents Historia As DataGridViewTextBoxColumn
    Friend WithEvents Nombre1 As DataGridViewTextBoxColumn
    Friend WithEvents Nombre2 As DataGridViewTextBoxColumn
    Friend WithEvents Apellido1 As DataGridViewTextBoxColumn
    Friend WithEvents Apellido2 As DataGridViewTextBoxColumn
    Friend WithEvents Ingreso As DataGridViewTextBoxColumn
    Friend WithEvents EPS_cod As DataGridViewTextBoxColumn
    Friend WithEvents EPS As DataGridViewTextBoxColumn
    Friend WithEvents eMail As DataGridViewTextBoxColumn
    Friend WithEvents eMailEps As DataGridViewTextBoxColumn
    Friend WithEvents Servicio As DataGridViewTextBoxColumn
End Class
