Public Class frmPrincipal

    Private currentForm As Form = Nothing
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
