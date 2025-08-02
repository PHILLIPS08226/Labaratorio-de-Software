' Formulario de administración de usuarios del sistema
Public Class frmUsuarios
    ' DAO para operaciones directas con la base de datos de usuarios
    Private Usuario As New UsuarioDAO()

    ' DAO para cargar los roles disponibles desde la base de datos
    Private Rol As New RolDAO()

    ' BLL para lógica de negocios relacionada con usuarios
    Private bll As New UsuarioBLL()

    ' Se ejecuta al cargar el formulario
    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarUsuarios() ' Llena el DataGridView con los usuarios registrados
        bll.InicializarSistema() ' Inicializa configuraciones necesarias del sistema
        cmbRol.DataSource = Rol.CargarRoles() ' Carga los roles disponibles en el ComboBox
        cmbRol.DisplayMember = "Nombre"
        cmbRol.ValueMember = "ID_Rol"
        LimpiarCampos() ' Limpia los controles del formulario
    End Sub

    ' Carga los datos de todos los usuarios en el DataGridView
    Private Sub CargarUsuarios()
        dtgUsuarios.DataSource = bll.ObtenerTodos()
        dtgUsuarios.ClearSelection()
    End Sub

    ' Configura el comportamiento del DataGridView para selección y edición
    Private Sub ConfigurarDataGridView()
        dtgUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dtgUsuarios.MultiSelect = False
        dtgUsuarios.ReadOnly = True
    End Sub

    ' Muestra un mensaje de error estándar
    Private Sub MostrarError(mensaje As String)
        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ' Muestra un mensaje de éxito estándar
    Private Sub MensajeExito(mensaje As String)
        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Variable para guardar el ID del usuario actualmente seleccionado
    Private usuarioSeleccionadoId As Integer = -1

    ' Limpia los campos del formulario para nueva inserción o edición
    Private Sub LimpiarCampos()
        txtIngresarPwd.Clear()
        txtNombreUsuario.Clear()
        txtConfirmarPwd.Clear()
        cmbRol.SelectedIndex = -1
        usuarioSeleccionadoId = -1
        dtgUsuarios.ClearSelection()
    End Sub

    ' Inserta un nuevo usuario al hacer clic en "Insertar"
    Private Sub btnInsertarUsuario_Click(sender As Object, e As EventArgs) Handles btnInsertarUsuario.Click
        Dim nombreUsuario As String = txtNombreUsuario.Text.Trim()

        If String.IsNullOrWhiteSpace(nombreUsuario) Then
            MostrarError("El nombre de usuario es obligatorio.")
            Return
        End If

        ' Valida contraseñas ingresadas
        If Not ValidarContrasena() Then Return

        ' Verifica si el usuario ya existe
        If Usuario.ExisteUsuario(nombreUsuario) Then
            MostrarError("Ya existe un usuario con ese nombre.")
            Return
        End If

        ' Hashea la contraseña y la inserta junto con el rol
        Dim idRol As Integer = CInt(cmbRol.SelectedValue)
        Dim hash = Seguridad.ObtenerHashSHA256(txtIngresarPwd.Text)
        Dim exito As Boolean = Usuario.InsertarUsuario(nombreUsuario, hash, idRol)

        If exito Then
            MensajeExito("Usuario insertado correctamente.")
            LimpiarCampos()
            CargarUsuarios()
        End If
    End Sub

    ' Elimina el usuario seleccionado en el DataGridView
    Private Sub btnEliminarUsuario_Click(sender As Object, e As EventArgs) Handles btnEliminarUsuario.Click
        If dtgUsuarios.SelectedRows.Count = 0 Then
            MostrarError("Seleccione un Usuario")
            Return
        End If

        ' Confirma la acción de eliminación
        If MessageBox.Show("¿Eliminar usuario seleccionado?", "Confirmar",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Try
            Dim Id = CInt(dtgUsuarios.SelectedRows(0).Cells("ID_Usuario").Value)
            If Usuario.EliminarUsuario(Id) Then
                MensajeExito("Usuario eliminado")
                CargarUsuarios()
            End If
        Catch ex As Exception
            MostrarError("Error al eliminar: " & ex.Message)
        End Try
        LimpiarCampos()
    End Sub

    ' Actualiza el usuario seleccionado con nueva información
    Private Sub btnActualizarUsuario_Click(sender As Object, e As EventArgs) Handles btnActualizarUsuario.Click
        If usuarioSeleccionadoId <= 0 Then
            MostrarError("Seleccione un usuario para modificar.")
            Return
        End If

        Dim nombreUsuario As String = txtNombreUsuario.Text.Trim()
        Dim contrasena1 As String = txtIngresarPwd.Text
        Dim contrasena2 As String = txtConfirmarPwd.Text
        Dim idRol As Integer = CInt(cmbRol.SelectedValue)

        If String.IsNullOrWhiteSpace(nombreUsuario) Then
            MostrarError("El nombre de usuario es obligatorio.")
            Return
        End If

        Dim hashPwdFinal As String

        If String.IsNullOrWhiteSpace(contrasena1) AndAlso String.IsNullOrWhiteSpace(contrasena2) Then
            ' Si no se ingresó nueva contraseña, conservar la anterior
            Dim actual = Usuario.ObtenerPorID(usuarioSeleccionadoId)
            hashPwdFinal = actual.Contrasena
        Else
            ' Validar la nueva contraseña antes de actualizar
            If Not ValidarContrasena() Then Return
            hashPwdFinal = Seguridad.ObtenerHashSHA256(contrasena1)
        End If

        ' Ejecuta la actualización
        Dim exito As Boolean = Usuario.ActualizarUsuario(usuarioSeleccionadoId, nombreUsuario, hashPwdFinal, idRol)

        If exito Then
            MensajeExito("Usuario actualizado correctamente.")
            LimpiarCampos()
            CargarUsuarios()
        Else
            MostrarError("No se pudo actualizar el usuario.")
        End If
    End Sub

    ' Se ejecuta al cambiar la selección en el DataGridView
    Private Sub dtgUsuarios_SelectionChanged(sender As Object, e As EventArgs) Handles dtgUsuarios.SelectionChanged
        If dtgUsuarios.SelectedRows.Count = 0 Then Return

        Try
            ' Extrae datos del usuario seleccionado y los carga en el formulario
            Dim fila = dtgUsuarios.SelectedRows(0)
            usuarioSeleccionadoId = CInt(fila.Cells("ID_Usuario").Value)

            Dim datos = Usuario.ObtenerPorID(usuarioSeleccionadoId)

            txtNombreUsuario.Text = datos.NombreUsuario
            txtIngresarPwd.Clear()
            txtConfirmarPwd.Clear()
            cmbRol.SelectedValue = datos.RolId
        Catch ex As Exception
            MostrarError("Error al cargar datos del usuario: " & ex.Message)
        End Try
    End Sub

    ' Valida las contraseñas ingresadas antes de insertar o actualizar
    Private Function ValidarContrasena() As Boolean
        Dim contrasena1 As String = txtIngresarPwd.Text
        Dim contrasena2 As String = txtConfirmarPwd.Text

        If String.IsNullOrWhiteSpace(contrasena1) OrElse String.IsNullOrWhiteSpace(contrasena2) Then
            MostrarError("Debe ingresar y confirmar la contraseña.")
            Return False
        End If

        If contrasena1 <> contrasena2 Then
            MostrarError("Las contraseñas no coinciden.")
            Return False
        End If

        If contrasena1.Length < 8 Then
            MostrarError("La contraseña debe tener al menos 8 caracteres.")
            Return False
        End If

        Dim contieneEspecial As Boolean = contrasena1.Any(Function(c) Not Char.IsLetterOrDigit(c))
        If Not contieneEspecial Then
            MostrarError("La contraseña debe contener al menos un carácter especial.")
            Return False
        End If

        Return True
    End Function


End Class