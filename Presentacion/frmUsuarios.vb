Public Class frmUsuarios
    Private Usuario As New UsuarioDAO()
    Private Rol As New RolDAO()
    Private bll As New UsuarioBLL()

    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarUsuarios()
        bll.InicializarSistema()
        cmbRol.DataSource = Rol.CargarRoles()
        cmbRol.DisplayMember = "Nombre"
        cmbRol.ValueMember = "ID_Rol"
        LimpiarCampos()
    End Sub

    Private Sub CargarUsuarios()
        dtgUsuarios.DataSource = bll.ObtenerTodos()
        dtgUsuarios.ClearSelection()
    End Sub

    Private Sub ConfigurarDataGridView()
        dtgUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dtgUsuarios.MultiSelect = False
        dtgUsuarios.ReadOnly = True
    End Sub

    Private Sub MostrarError(mensaje As String)
        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub MensajeExito(mensaje As String)
        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private usuarioSeleccionadoId As Integer = -1

    Private Sub LimpiarCampos()
        txtIngresarPwd.Clear()
        txtNombreUsuario.Clear()
        txtConfirmarPwd.Clear()
        cmbRol.SelectedIndex = -1
        usuarioSeleccionadoId = -1
        dtgUsuarios.ClearSelection()
    End Sub

    Private Sub btnInsertarUsuario_Click(sender As Object, e As EventArgs) Handles btnInsertarUsuario.Click
        Dim nombreUsuario As String = txtNombreUsuario.Text.Trim()
        Dim contrasena1 As String = txtIngresarPwd.Text
        Dim contrasena2 As String = txtConfirmarPwd.Text

        If String.IsNullOrWhiteSpace(nombreUsuario) OrElse String.IsNullOrWhiteSpace(contrasena1) OrElse String.IsNullOrWhiteSpace(contrasena2) Then
            MostrarError("Todos los campos son obligatorios.")
            Return
        End If

        If contrasena1 <> contrasena2 Then
            MostrarError("Las contraseñas no coinciden.")
            Return
        End If

        ' Verificar duplicado
        If Usuario.ExisteUsuario(nombreUsuario) Then
            MostrarError("Ya existe un usuario con ese nombre.")
            Return
        End If

        Dim idRol As Integer = CInt(cmbRol.SelectedValue)
        Dim hash = Seguridad.ObtenerHashSHA256(contrasena1)
        Dim exito As Boolean = Usuario.InsertarUsuario(nombreUsuario, hash, idRol)

        If exito Then
            MensajeExito("Usuario insertado correctamente.")
            LimpiarCampos()
            CargarUsuarios()
        End If
    End Sub

    Private Sub btnEliminarUsuario_Click(sender As Object, e As EventArgs) Handles btnEliminarUsuario.Click
        If dtgUsuarios.SelectedRows.Count = 0 Then
            MostrarError("Seleccione un Usuario")
            Return
        End If

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
    End Sub

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
            ' No actualizar contraseña
            Dim actual = Usuario.ObtenerPorID(usuarioSeleccionadoId)
            hashPwdFinal = actual.Contrasena
        Else
            ' Validar y actualizar contraseña
            If contrasena1 <> contrasena2 Then
                MostrarError("Las contraseñas no coinciden.")
                Return
            End If
            hashPwdFinal = Seguridad.ObtenerHashSHA256(contrasena1)
            MessageBox.Show("Original: [" & txtIngresarPwd.Text & "]")
            MessageBox.Show("Hash: " & Seguridad.ObtenerHashSHA256(txtIngresarPwd.Text))
        End If

        Dim exito As Boolean = Usuario.ActualizarUsuario(usuarioSeleccionadoId, nombreUsuario, hashPwdFinal, idRol)

        If exito Then
            MensajeExito("Usuario actualizado correctamente.")
            LimpiarCampos()
            CargarUsuarios()
        Else
            MostrarError("No se pudo actualizar el usuario.")
        End If
    End Sub


    Private Sub dtgUsuarios_SelectionChanged(sender As Object, e As EventArgs) Handles dtgUsuarios.SelectionChanged
        If dtgUsuarios.SelectedRows.Count = 0 Then Return

        Try
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


End Class
