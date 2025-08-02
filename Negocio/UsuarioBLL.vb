' Capa de lógica de negocios (Business Logic Layer) para operaciones relacionadas con usuarios
Public Class UsuarioBLL

    ' Verifica las credenciales del usuario utilizando la lógica de negocio
    Public Function Verificar(usuario As String, contraseña As String) As Usuario
        ' Validación previa: usuario y contraseña no pueden estar vacíos
        If String.IsNullOrWhiteSpace(usuario) OrElse String.IsNullOrWhiteSpace(contraseña) Then
            Return Nothing
        End If

        Dim dao As New UsuarioDAO()

        ' Hashea la contraseña antes de enviar a la capa DAO
        Dim hash = Seguridad.ObtenerHashSHA256(contraseña)

        ' Llama a la capa de datos para verificar credenciales con hash
        Return dao.VerificarCredenciales(usuario, hash)
    End Function

    ' Obtiene todos los usuarios del sistema (utilizado para mostrar en formularios)
    Public Function ObtenerTodos() As DataTable
        Dim dao As New UsuarioDAO()
        Return dao.ObtenerTodos()
    End Function

    ' Inicializa configuraciones del sistema (como roles por defecto)
    Public Sub InicializarSistema()
        Dim dao As New UsuarioDAO()
        dao.VerificarYCrearRoles()
    End Sub

    Public Function BuscarUsuarios(nombre As String) As DataTable
        Dim dao As New UsuarioDAO()
        Return dao.BuscarPorNombre(nombre)
    End Function


End Class