Public Class UsuarioBLL
    Public Function Verificar(usuario As String, contraseña As String) As Usuario
        If String.IsNullOrWhiteSpace(usuario) OrElse String.IsNullOrWhiteSpace(contraseña) Then
            Return Nothing
        End If

        Dim dao As New UsuarioDAO()
        Return dao.VerificarCredenciales(usuario, contraseña)
    End Function
End Class
