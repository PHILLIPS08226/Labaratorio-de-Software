Public Class UsuarioBLL
    Public Function Verificar(usuario As String, contraseña As String) As Usuario
        If String.IsNullOrWhiteSpace(usuario) OrElse String.IsNullOrWhiteSpace(contraseña) Then
            Return Nothing
        End If

        Dim dao As New UsuarioDAO()
        Dim hash = Seguridad.ObtenerHashSHA256(contraseña)
        Return dao.VerificarCredenciales(usuario, hash)
    End Function

    Public Function ObtenerTodos() As DataTable
        Dim dao As New UsuarioDAO()
        Return dao.ObtenerTodos()
    End Function

    Public Sub InicializarSistema()
        Dim dao As New UsuarioDAO()
        dao.VerificarYCrearRoles()
    End Sub
End Class
