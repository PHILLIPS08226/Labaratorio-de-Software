<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuditorias
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        GroupBox1 = New GroupBox()
        btnAuditar = New Button()
        dtpFechaFin = New DateTimePicker()
        Label3 = New Label()
        Label2 = New Label()
        dtpFechaInicio = New DateTimePicker()
        btnBuscarUsuario = New Button()
        txtBusquedaNombre = New TextBox()
        Label1 = New Label()
        cmbUsuario = New ComboBox()
        dtgAuditoria = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(dtgAuditoria, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnAuditar)
        GroupBox1.Controls.Add(dtpFechaFin)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(dtpFechaInicio)
        GroupBox1.Controls.Add(btnBuscarUsuario)
        GroupBox1.Controls.Add(txtBusquedaNombre)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(cmbUsuario)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(776, 167)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos a Auditar"
        ' 
        ' btnAuditar
        ' 
        btnAuditar.Location = New Point(6, 129)
        btnAuditar.Name = "btnAuditar"
        btnAuditar.Size = New Size(81, 23)
        btnAuditar.TabIndex = 8
        btnAuditar.Text = "Auditar"
        btnAuditar.UseVisualStyleBackColor = True
        ' 
        ' dtpFechaFin
        ' 
        dtpFechaFin.Location = New Point(82, 91)
        dtpFechaFin.Name = "dtpFechaFin"
        dtpFechaFin.Size = New Size(200, 23)
        dtpFechaFin.TabIndex = 7
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(6, 97)
        Label3.Name = "Label3"
        Label3.Size = New Size(57, 15)
        Label3.TabIndex = 6
        Label3.Text = "Fecha Fin"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(6, 66)
        Label2.Name = "Label2"
        Label2.Size = New Size(70, 15)
        Label2.TabIndex = 5
        Label2.Text = "Fecha Inicio"
        ' 
        ' dtpFechaInicio
        ' 
        dtpFechaInicio.Location = New Point(82, 58)
        dtpFechaInicio.Name = "dtpFechaInicio"
        dtpFechaInicio.Size = New Size(200, 23)
        dtpFechaInicio.TabIndex = 4
        ' 
        ' btnBuscarUsuario
        ' 
        btnBuscarUsuario.Location = New Point(387, 22)
        btnBuscarUsuario.Name = "btnBuscarUsuario"
        btnBuscarUsuario.Size = New Size(100, 23)
        btnBuscarUsuario.TabIndex = 3
        btnBuscarUsuario.Text = "Buscar Usuario"
        btnBuscarUsuario.UseVisualStyleBackColor = True
        ' 
        ' txtBusquedaNombre
        ' 
        txtBusquedaNombre.Location = New Point(202, 22)
        txtBusquedaNombre.Name = "txtBusquedaNombre"
        txtBusquedaNombre.PlaceholderText = "Busqueda por nombre"
        txtBusquedaNombre.Size = New Size(179, 23)
        txtBusquedaNombre.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 15)
        Label1.TabIndex = 1
        Label1.Text = "Usuario"
        ' 
        ' cmbUsuario
        ' 
        cmbUsuario.FormattingEnabled = True
        cmbUsuario.Location = New Point(59, 22)
        cmbUsuario.Name = "cmbUsuario"
        cmbUsuario.Size = New Size(121, 23)
        cmbUsuario.TabIndex = 0
        ' 
        ' dtgAuditoria
        ' 
        dtgAuditoria.AllowUserToAddRows = False
        dtgAuditoria.AllowUserToDeleteRows = False
        dtgAuditoria.AllowUserToResizeRows = False
        dtgAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dtgAuditoria.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders
        dtgAuditoria.BackgroundColor = SystemColors.ActiveBorder
        'dtgAuditoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dtgAuditoria.Location = New Point(12, 185)
        dtgAuditoria.Name = "dtgAuditoria"
        dtgAuditoria.ReadOnly = True
        dtgAuditoria.ShowEditingIcon = False
        dtgAuditoria.Size = New Size(776, 253)
        dtgAuditoria.TabIndex = 0
        ' 
        ' frmAuditorias
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(dtgAuditoria)
        Controls.Add(GroupBox1)
        Name = "frmAuditorias"
        Text = "frmAuditorias"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dtgAuditoria, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbUsuario As ComboBox
    Friend WithEvents txtBusquedaNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBuscarUsuario As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents btnAuditar As Button
    Friend WithEvents dtgAuditoria As DataGridView
End Class
