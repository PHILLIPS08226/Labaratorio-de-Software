Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dao As New UsuarioDAO()

        Try
            dao.VerificarYCrearRoles()

            If Not dao.HayUsuariosRegistrados() Then
                MessageBox.Show("No hay usuarios registrados. Por favor, cree un usuario administrador.", "Configuración Inicial", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim nombre = InputBox("Ingrese nombre de usuario:", "Nuevo Usuario")
                If String.IsNullOrWhiteSpace(nombre) Then
                    MessageBox.Show("Nombre de usuario no puede estar vacío.")
                    Application.Exit()
                    Return
                End If

                Dim clave = InputBox("Ingrese contraseña:", "Nueva Contraseña")
                If String.IsNullOrWhiteSpace(clave) Then
                    MessageBox.Show("La contraseña no puede estar vacía.")
                    Application.Exit()
                    Return
                End If

                ' ✅ Se pasa la contraseña en texto plano, el DAO se encarga del hash
                dao.CrearPrimerUsuario(nombre, clave, rolId:=1)

                MessageBox.Show("Usuario administrador creado con éxito.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al inicializar el sistema: " & ex.Message)
            Application.Exit()
        End Try

        txtPwd.UseSystemPasswordChar = True
    End Sub

    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        Dim usuario As String = txtUsuario.Text.Trim()
        Dim contraseña As String = txtPwd.Text.Trim()

        If usuario = "" OrElse contraseña = "" Then
            MessageBox.Show("Debe completar ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim bll As New UsuarioBLL()
        Dim resultado As Usuario = bll.Verificar(usuario, contraseña)

        If resultado IsNot Nothing Then
            MessageBox.Show("Bienvenido, " & resultado.NombreUsuario, "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim formPrincipal As New frmPrincipal()
            formPrincipal.Show()
            Me.Hide()
        Else
            MessageBox.Show("Credenciales incorrectas.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
