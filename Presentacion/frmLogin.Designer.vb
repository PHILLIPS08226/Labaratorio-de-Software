<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        txtUsuario = New TextBox()
        txtPwd = New TextBox()
        btnIniciarSesion = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        Label1.Location = New Point(44, 163)
        Label1.Name = "Label1"
        Label1.Size = New Size(59, 18)
        Label1.TabIndex = 0
        Label1.Text = "Usuario"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Dutch801 Rm BT", 11.25F, FontStyle.Bold)
        Label2.Location = New Point(19, 198)
        Label2.Name = "Label2"
        Label2.Size = New Size(84, 18)
        Label2.TabIndex = 1
        Label2.Text = "Contraseña"
        ' 
        ' txtUsuario
        ' 
        txtUsuario.Location = New Point(109, 163)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(131, 23)
        txtUsuario.TabIndex = 2
        ' 
        ' txtPwd
        ' 
        txtPwd.Location = New Point(109, 198)
        txtPwd.Name = "txtPwd"
        txtPwd.PasswordChar = "*"c
        txtPwd.Size = New Size(131, 23)
        txtPwd.TabIndex = 3
        ' 
        ' btnIniciarSesion
        ' 
        btnIniciarSesion.Font = New Font("Dutch801 Rm BT", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnIniciarSesion.Location = New Point(121, 247)
        btnIniciarSesion.Name = "btnIniciarSesion"
        btnIniciarSesion.Size = New Size(75, 23)
        btnIniciarSesion.TabIndex = 4
        btnIniciarSesion.Text = "Entrar"
        btnIniciarSesion.UseVisualStyleBackColor = True
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.imgLog
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(685, 402)
        Controls.Add(btnIniciarSesion)
        Controls.Add(txtPwd)
        Controls.Add(txtUsuario)
        Controls.Add(Label2)
        Controls.Add(Label1)
        DoubleBuffered = True
        Name = "frmLogin"
        Text = "Inicio de Sesion"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtPwd As TextBox
    Friend WithEvents btnIniciarSesion As Button

End Class
