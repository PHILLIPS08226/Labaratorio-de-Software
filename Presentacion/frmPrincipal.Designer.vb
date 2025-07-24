<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
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
        MenuStrip1 = New MenuStrip()
        UsuariosToolStripMenuItem = New ToolStripMenuItem()
        ProductosToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.White
        MenuStrip1.Items.AddRange(New ToolStripItem() {UsuariosToolStripMenuItem, ProductosToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(859, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' UsuariosToolStripMenuItem
        ' 
        UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        UsuariosToolStripMenuItem.Size = New Size(64, 20)
        UsuariosToolStripMenuItem.Text = "Usuarios"
        ' 
        ' ProductosToolStripMenuItem
        ' 
        ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        ProductosToolStripMenuItem.Size = New Size(73, 20)
        ProductosToolStripMenuItem.Text = "Productos"
        ' 
        ' frmPrincipal
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkGray
        BackgroundImage = My.Resources.Resources.imgPrin
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(859, 482)
        Controls.Add(MenuStrip1)
        IsMdiContainer = True
        MainMenuStrip = MenuStrip1
        Name = "frmPrincipal"
        Text = "Menu Principal"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents UsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
End Class
