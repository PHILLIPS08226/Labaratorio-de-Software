Public Class frmPrincipal

    Private currentForm As Form = Nothing
    Private usuarioActual As Usuario

    Public Sub New(usuario As Usuario)
        InitializeComponent()
        Me.usuarioActual = usuario
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 🚫 Si no es admin (ID_Rol ≠ 1), desactiva el menú de Usuarios
        If usuarioActual.RolId <> 1 Then
            UsuariosToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub OpenChildForm(childForm As Form)
        If currentForm IsNot Nothing Then
            currentForm.Close()
        End If
        currentForm = childForm
        childForm.MdiParent = Me
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        childForm.Show()
    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.Click
        Dim frmUsuarios As New frmUsuarios()
        OpenChildForm(frmUsuarios)
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim frmProductos As New frmProductos()
        OpenChildForm(frmProductos)
    End Sub

End Class
