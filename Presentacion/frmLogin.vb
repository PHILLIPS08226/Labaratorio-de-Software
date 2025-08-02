' Formulario de inicio de sesión del sistema
Public Class frmLogin

    ' Evento que se ejecuta al cargar el formulario
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dao As New UsuarioDAO()
        Dim movDao As New MovimientoDAO()

        Try
            ' Verifica si existen roles y tipos de movimiento, y los crea si no están definidos
            dao.VerificarYCrearRoles()
            movDao.VerificarYCrearTiposMovimiento()

            ' Comprueba si hay usuarios registrados en el sistema
            If Not dao.HayUsuariosRegistrados() Then
                MessageBox.Show("No hay usuarios registrados. Por favor, cree un usuario administrador.", "Configuración Inicial", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Solicita al usuario crear un nombre de usuario
                Dim nombre = InputBox("Ingrese nombre de usuario:", "Nuevo Usuario")
                If String.IsNullOrWhiteSpace(nombre) Then
                    MessageBox.Show("Nombre de usuario no puede estar vacío.")
                    Application.Exit()
                    Return
                End If

                ' Solicita contraseña y valida que no esté vacía
                Dim clave = InputBox("Ingrese contraseña:", "Nueva Contraseña")
                If String.IsNullOrWhiteSpace(clave) Then
                    txtPwd.UseSystemPasswordChar = True ' Opcional, visualiza caracteres seguros
                    MessageBox.Show("La contraseña no puede estar vacía.")
                    Application.Exit()
                    Return
                End If

                ' Crea el primer usuario como administrador (rolId = 1)
                dao.CrearPrimerUsuario(nombre, clave, rolId:=1)
                MessageBox.Show("Usuario administrador creado con éxito.")
            End If
        Catch ex As Exception
            ' Manejo de errores en la inicialización
            MessageBox.Show("Error al inicializar el sistema: " & ex.Message)
            Application.Exit()
        End Try
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón "Iniciar Sesión"
    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        ' Captura y limpia los datos ingresados
        Dim usuario As String = txtUsuario.Text.Trim()
        Dim contraseña As String = txtPwd.Text.Trim()

        ' Validación: campos no deben estar vacíos
        If usuario = "" OrElse contraseña = "" Then
            MessageBox.Show("Debe completar ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Instancia la capa de lógica para verificación de credenciales
        Dim bll As New UsuarioBLL()
        Dim resultado As Usuario = bll.Verificar(usuario, contraseña)

        ' Si el usuario fue autenticado correctamente...
        If resultado IsNot Nothing Then
            MessageBox.Show("Bienvenido, " & resultado.NombreUsuario, "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Abre el formulario principal y oculta el login
            Dim formPrincipal As New frmPrincipal(resultado)
            formPrincipal.Show()
            Me.Hide()
        Else
            ' Si las credenciales son incorrectas
            MessageBox.Show("Credenciales incorrectas.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class