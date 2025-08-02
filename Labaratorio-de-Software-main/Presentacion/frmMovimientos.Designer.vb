<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientos
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
        dtgMovimientosRecientes = New DataGridView()
        GroupBox2 = New GroupBox()
        nudCantidad = New NumericUpDown()
        Label2 = New Label()
        GroupBox3 = New GroupBox()
        rdbEntrada = New RadioButton()
        rdbSalida = New RadioButton()
        Label1 = New Label()
        cmbProducto = New ComboBox()
        btnGuardarMovimiento = New Button()
        GroupBox1.SuspendLayout()
        CType(dtgMovimientosRecientes, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        CType(nudCantidad, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox3.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Transparent
        GroupBox1.Controls.Add(dtgMovimientosRecientes)
        GroupBox1.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GroupBox1.Location = New Point(351, 31)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(527, 251)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Movimientos Recientes"
        ' 
        ' dtgMovimientosRecientes
        ' 
        dtgMovimientosRecientes.AllowUserToAddRows = False
        dtgMovimientosRecientes.AllowUserToDeleteRows = False
        dtgMovimientosRecientes.AllowUserToResizeColumns = False
        dtgMovimientosRecientes.AllowUserToResizeRows = False
        dtgMovimientosRecientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dtgMovimientosRecientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders
        dtgMovimientosRecientes.BackgroundColor = SystemColors.ActiveBorder
        dtgMovimientosRecientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dtgMovimientosRecientes.Location = New Point(6, 31)
        dtgMovimientosRecientes.Name = "dtgMovimientosRecientes"
        dtgMovimientosRecientes.ReadOnly = True
        dtgMovimientosRecientes.ShowEditingIcon = False
        dtgMovimientosRecientes.Size = New Size(502, 214)
        dtgMovimientosRecientes.TabIndex = 0
        ' 
        ' GroupBox2
        ' 
        GroupBox2.BackColor = Color.Transparent
        GroupBox2.Controls.Add(nudCantidad)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(GroupBox3)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(cmbProducto)
        GroupBox2.Font = New Font("Dutch801 Rm BT", 11.25F)
        GroupBox2.Location = New Point(12, 31)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(308, 183)
        GroupBox2.TabIndex = 2
        GroupBox2.TabStop = False
        GroupBox2.Text = "Registrar Movimiento"
        ' 
        ' nudCantidad
        ' 
        nudCantidad.Location = New Point(141, 145)
        nudCantidad.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        nudCantidad.Name = "nudCantidad"
        nudCantidad.Size = New Size(120, 26)
        nudCantidad.TabIndex = 8
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(22, 147)
        Label2.Name = "Label2"
        Label2.Size = New Size(66, 18)
        Label2.TabIndex = 7
        Label2.Text = "Cantidad"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(rdbEntrada)
        GroupBox3.Controls.Add(rdbSalida)
        GroupBox3.Location = New Point(16, 89)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(265, 50)
        GroupBox3.TabIndex = 5
        GroupBox3.TabStop = False
        GroupBox3.Text = "Tipo de Movimiento"
        ' 
        ' rdbEntrada
        ' 
        rdbEntrada.AutoSize = True
        rdbEntrada.BackColor = Color.Lime
        rdbEntrada.Location = New Point(6, 22)
        rdbEntrada.Name = "rdbEntrada"
        rdbEntrada.Size = New Size(77, 22)
        rdbEntrada.TabIndex = 2
        rdbEntrada.TabStop = True
        rdbEntrada.Text = "Entrada"
        rdbEntrada.UseVisualStyleBackColor = False
        ' 
        ' rdbSalida
        ' 
        rdbSalida.AutoSize = True
        rdbSalida.BackColor = Color.Red
        rdbSalida.Location = New Point(107, 22)
        rdbSalida.Name = "rdbSalida"
        rdbSalida.Size = New Size(64, 22)
        rdbSalida.TabIndex = 3
        rdbSalida.TabStop = True
        rdbSalida.Text = "Salida"
        rdbSalida.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(16, 45)
        Label1.Name = "Label1"
        Label1.Size = New Size(144, 18)
        Label1.TabIndex = 1
        Label1.Text = "Seleccionar Producto"
        ' 
        ' cmbProducto
        ' 
        cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList
        cmbProducto.FormattingEnabled = True
        cmbProducto.Location = New Point(166, 45)
        cmbProducto.Name = "cmbProducto"
        cmbProducto.Size = New Size(121, 26)
        cmbProducto.TabIndex = 0
        ' 
        ' btnGuardarMovimiento
        ' 
        btnGuardarMovimiento.BackColor = Color.Transparent
        btnGuardarMovimiento.Font = New Font("Dutch801 Rm BT", 11.25F)
        btnGuardarMovimiento.Location = New Point(12, 220)
        btnGuardarMovimiento.Name = "btnGuardarMovimiento"
        btnGuardarMovimiento.Size = New Size(99, 28)
        btnGuardarMovimiento.TabIndex = 3
        btnGuardarMovimiento.Text = "Registrar Movimiento"
        btnGuardarMovimiento.UseVisualStyleBackColor = False
        ' 
        ' frmMovimientos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.ImgMov
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(902, 450)
        Controls.Add(btnGuardarMovimiento)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Name = "frmMovimientos"
        Text = "frmMovimientos"
        GroupBox1.ResumeLayout(False)
        CType(dtgMovimientosRecientes, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(nudCantidad, ComponentModel.ISupportInitialize).EndInit()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtgMovimientosRecientes As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rdbSalida As RadioButton
    Friend WithEvents rdbEntrada As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents nudCantidad As NumericUpDown
    Friend WithEvents btnGuardarMovimiento As Button
End Class
