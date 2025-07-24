<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductos
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
        Label5 = New Label()
        dtpFecharegistro = New DateTimePicker()
        Label4 = New Label()
        txtStockMinimo = New TextBox()
        txtStockActual = New TextBox()
        txtDescripcion = New TextBox()
        txtNombre = New TextBox()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        dgvProductos = New DataGridView()
        btnGuardar = New Button()
        btnEditar = New Button()
        btnEliminar = New Button()
        btnActualizar = New Button()
        txtBuscar = New TextBox()
        btnBuscar = New Button()
        GroupBox1.SuspendLayout()
        CType(dgvProductos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Transparent
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(dtpFecharegistro)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(txtStockMinimo)
        GroupBox1.Controls.Add(txtStockActual)
        GroupBox1.Controls.Add(txtDescripcion)
        GroupBox1.Controls.Add(txtNombre)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(716, 142)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Ingresar Datos"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(319, 84)
        Label5.Name = "Label5"
        Label5.Size = New Size(125, 18)
        Label5.TabIndex = 9
        Label5.Text = "Fecha de Registro"
        ' 
        ' dtpFecharegistro
        ' 
        dtpFecharegistro.Location = New Point(462, 79)
        dtpFecharegistro.Name = "dtpFecharegistro"
        dtpFecharegistro.Size = New Size(228, 25)
        dtpFecharegistro.TabIndex = 8
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(344, 31)
        Label4.Name = "Label4"
        Label4.Size = New Size(100, 18)
        Label4.TabIndex = 7
        Label4.Text = "Stock Minimo"
        ' 
        ' txtStockMinimo
        ' 
        txtStockMinimo.Location = New Point(462, 28)
        txtStockMinimo.Name = "txtStockMinimo"
        txtStockMinimo.Size = New Size(228, 25)
        txtStockMinimo.TabIndex = 6
        ' 
        ' txtStockActual
        ' 
        txtStockActual.Location = New Point(123, 98)
        txtStockActual.Name = "txtStockActual"
        txtStockActual.Size = New Size(190, 25)
        txtStockActual.TabIndex = 5
        ' 
        ' txtDescripcion
        ' 
        txtDescripcion.Location = New Point(123, 61)
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.Size = New Size(190, 25)
        txtDescripcion.TabIndex = 4
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(122, 32)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(191, 25)
        txtNombre.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(37, 102)
        Label3.Name = "Label3"
        Label3.Size = New Size(77, 18)
        Label3.TabIndex = 2
        Label3.Text = "Stok Atual"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(29, 65)
        Label2.Name = "Label2"
        Label2.Size = New Size(85, 18)
        Label2.TabIndex = 1
        Label2.Text = "Descripción"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(47, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 18)
        Label1.TabIndex = 0
        Label1.Text = "Nombre"
        ' 
        ' dgvProductos
        ' 
        dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProductos.Location = New Point(12, 195)
        dgvProductos.Name = "dgvProductos"
        dgvProductos.Size = New Size(716, 231)
        dgvProductos.TabIndex = 1
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        btnGuardar.Location = New Point(775, 77)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(75, 39)
        btnGuardar.TabIndex = 2
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        btnEditar.Location = New Point(776, 121)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(75, 42)
        btnEditar.TabIndex = 3
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        btnEliminar.Location = New Point(776, 170)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(75, 39)
        btnEliminar.TabIndex = 4
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnActualizar.Location = New Point(771, 219)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(84, 38)
        btnActualizar.TabIndex = 5
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = True
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        txtBuscar.Location = New Point(29, 162)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(456, 25)
        txtBuscar.TabIndex = 6
        ' 
        ' btnBuscar
        ' 
        btnBuscar.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        btnBuscar.Location = New Point(491, 162)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(87, 24)
        btnBuscar.TabIndex = 7
        btnBuscar.Text = "Buscar"
        btnBuscar.UseVisualStyleBackColor = True
        ' 
        ' frmProductos
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.ImgProduc
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(920, 499)
        Controls.Add(btnBuscar)
        Controls.Add(txtBuscar)
        Controls.Add(btnActualizar)
        Controls.Add(btnEliminar)
        Controls.Add(btnEditar)
        Controls.Add(btnGuardar)
        Controls.Add(dgvProductos)
        Controls.Add(GroupBox1)
        DoubleBuffered = True
        Name = "frmProductos"
        Text = "frmProductos"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dgvProductos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpFecharegistro As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents txtStockMinimo As TextBox
    Friend WithEvents txtStockActual As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvProductos As DataGridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents btnBuscar As Button
End Class
