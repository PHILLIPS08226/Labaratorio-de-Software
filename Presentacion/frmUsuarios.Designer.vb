﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
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
        dtgUsuarios = New DataGridView()
        Label1 = New Label()
        Label2 = New Label()
        GroupBox1 = New GroupBox()
        txtConfirmarPwd = New TextBox()
        txtIngresarPwd = New TextBox()
        cmbRol = New ComboBox()
        txtNombreUsuario = New TextBox()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        btnInsertarUsuario = New Button()
        btnEliminarUsuario = New Button()
        btnActualizarUsuario = New Button()
        CType(dtgUsuarios, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' dtgUsuarios
        ' 
        dtgUsuarios.AllowUserToAddRows = False
        dtgUsuarios.AllowUserToDeleteRows = False
        dtgUsuarios.AllowUserToResizeColumns = False
        dtgUsuarios.AllowUserToResizeRows = False
        dtgUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dtgUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders
        dtgUsuarios.BackgroundColor = SystemColors.ActiveBorder
        dtgUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dtgUsuarios.Location = New Point(365, 59)
        dtgUsuarios.Name = "dtgUsuarios"
        dtgUsuarios.ReadOnly = True
        dtgUsuarios.ShowEditingIcon = False
        dtgUsuarios.Size = New Size(441, 214)
        dtgUsuarios.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(404, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(116, 18)
        Label1.TabIndex = 1
        Label1.Text = "Usuarios Activos"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        Label2.Location = New Point(12, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(138, 18)
        Label2.TabIndex = 2
        Label2.Text = "Gestion de Usuarios"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Transparent
        GroupBox1.Controls.Add(txtConfirmarPwd)
        GroupBox1.Controls.Add(txtIngresarPwd)
        GroupBox1.Controls.Add(cmbRol)
        GroupBox1.Controls.Add(txtNombreUsuario)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.Location = New Point(12, 51)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(347, 223)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "Ingresar Datos"
        ' 
        ' txtConfirmarPwd
        ' 
        txtConfirmarPwd.Location = New Point(168, 124)
        txtConfirmarPwd.Name = "txtConfirmarPwd"
        txtConfirmarPwd.PasswordChar = "*"c
        txtConfirmarPwd.Size = New Size(140, 25)
        txtConfirmarPwd.TabIndex = 7
        ' 
        ' txtIngresarPwd
        ' 
        txtIngresarPwd.Location = New Point(168, 93)
        txtIngresarPwd.Name = "txtIngresarPwd"
        txtIngresarPwd.PasswordChar = "*"c
        txtIngresarPwd.Size = New Size(140, 25)
        txtIngresarPwd.TabIndex = 6
        ' 
        ' cmbRol
        ' 
        cmbRol.DropDownStyle = ComboBoxStyle.DropDownList
        cmbRol.FormattingEnabled = True
        cmbRol.Location = New Point(85, 60)
        cmbRol.Name = "cmbRol"
        cmbRol.Size = New Size(223, 26)
        cmbRol.TabIndex = 5
        ' 
        ' txtNombreUsuario
        ' 
        txtNombreUsuario.Location = New Point(85, 29)
        txtNombreUsuario.Name = "txtNombreUsuario"
        txtNombreUsuario.Size = New Size(223, 25)
        txtNombreUsuario.TabIndex = 4
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        Label6.Location = New Point(7, 125)
        Label6.Name = "Label6"
        Label6.Size = New Size(156, 18)
        Label6.TabIndex = 3
        Label6.Text = "Confirmar Contraseña"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        Label5.Location = New Point(19, 94)
        Label5.Name = "Label5"
        Label5.Size = New Size(143, 18)
        Label5.TabIndex = 2
        Label5.Text = "Ingresar Contraseña"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        Label4.Location = New Point(48, 60)
        Label4.Name = "Label4"
        Label4.Size = New Size(31, 18)
        Label4.TabIndex = 1
        Label4.Text = "Rol"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        Label3.Location = New Point(19, 29)
        Label3.Name = "Label3"
        Label3.Size = New Size(60, 18)
        Label3.TabIndex = 0
        Label3.Text = "Nombre"
        ' 
        ' btnInsertarUsuario
        ' 
        btnInsertarUsuario.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        btnInsertarUsuario.Location = New Point(31, 291)
        btnInsertarUsuario.Name = "btnInsertarUsuario"
        btnInsertarUsuario.Size = New Size(93, 36)
        btnInsertarUsuario.TabIndex = 4
        btnInsertarUsuario.Text = "Agregar"
        btnInsertarUsuario.UseVisualStyleBackColor = True
        ' 
        ' btnEliminarUsuario
        ' 
        btnEliminarUsuario.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        btnEliminarUsuario.Location = New Point(130, 291)
        btnEliminarUsuario.Name = "btnEliminarUsuario"
        btnEliminarUsuario.Size = New Size(93, 36)
        btnEliminarUsuario.TabIndex = 5
        btnEliminarUsuario.Text = "Eliminar"
        btnEliminarUsuario.UseVisualStyleBackColor = True
        ' 
        ' btnActualizarUsuario
        ' 
        btnActualizarUsuario.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        btnActualizarUsuario.Location = New Point(229, 291)
        btnActualizarUsuario.Name = "btnActualizarUsuario"
        btnActualizarUsuario.Size = New Size(93, 36)
        btnActualizarUsuario.TabIndex = 6
        btnActualizarUsuario.Text = "Actualizar"
        btnActualizarUsuario.UseVisualStyleBackColor = True
        ' 
        ' frmUsuarios
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.ImgUsu
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(842, 462)
        Controls.Add(btnActualizarUsuario)
        Controls.Add(btnEliminarUsuario)
        Controls.Add(btnInsertarUsuario)
        Controls.Add(GroupBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(dtgUsuarios)
        DoubleBuffered = True
        Name = "frmUsuarios"
        Text = "frmUsuarios"
        CType(dtgUsuarios, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dtgUsuarios As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtNombreUsuario As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbRol As ComboBox
    Friend WithEvents txtConfirmarPwd As TextBox
    Friend WithEvents txtIngresarPwd As TextBox
    Friend WithEvents btnInsertarUsuario As Button
    Friend WithEvents btnEliminarUsuario As Button
    Friend WithEvents btnActualizarUsuario As Button
End Class
