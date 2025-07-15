Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dao As New UsuarioDAO()
        dao.VerificarYCrearRoles() ' Verifica e inserta roles si no existen

        If Not dao.HayUsuariosRegistrados() Then
            MessageBox.Show("No hay usuarios registrados. Por favor, cree un usuario administrador.")
            Dim nombre = InputBox("Ingrese nombre de usuario:")
            Dim clave = InputBox("Ingrese contraseña:")

            dao.CrearPrimerUsuario(nombre, clave, rolId:=1)
            MessageBox.Show("Usuario creado con éxito. Ahora puede iniciar sesión.")
        End If
    End Sub

    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        Dim usuario As String = txtUsuario.Text.Trim()
        Dim contraseña As String = txtPwd.Text.Trim()

        Dim gestor As New UsuarioBLL()
        Dim resultado As Usuario = gestor.Verificar(usuario, contraseña)

        If resultado IsNot Nothing Then
            MessageBox.Show("Acceso válido. Usuario: " & resultado.NombreUsuario & ", Rol ID: " & resultado.RolId)

            Select Case resultado.RolId
                Case 1
                    MessageBox.Show("Acceso como Administrador")
                    Dim formPrincipal As New frmPrincipal()
                    formPrincipal.Show()
                    Me.Hide() ' Ocultar el formulario de inicio de sesión
                Case 2
                    MessageBox.Show("Acceso como Encargado de Inventario")
                    Dim formPrincipal As New frmPrincipal()
                    formPrincipal.Show()
                    Me.Hide() ' Ocultar el formulario de inicio de sesión
                Case Else
                    MessageBox.Show("Rol desconocido")
            End Select
        Else
            MessageBox.Show("Credenciales incorrectas")
        End If
    End Sub
End Class
