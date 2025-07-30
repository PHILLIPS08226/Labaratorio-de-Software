Public Class frmAuditorias
    Private usuarioBLL As New UsuarioBLL()
    Private auditoriaBLL As New AuditoriaBLL()

    Private Sub frmAuditorias_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load

        ' Inicial: llenar combo con todos los usuarios
        CargarComboUsuarios(Nothing)
    End Sub

    ''' <summary>
    ''' Llena cmbUsuario con un DataTable de usuarios, insertando opción "<Todos>".
    ''' </summary>
    Private Sub CargarComboUsuarios(dt As DataTable)
        If dt Is Nothing Then
            ' Carga todos los usuarios si dt es Nothing
            dt = usuarioBLL.BuscarUsuarios(String.Empty)
        End If

        ' Insertar opción "Todos"
        Dim rowTodos = dt.NewRow()
        rowTodos("ID_Usuario") = DBNull.Value
        rowTodos("Nombre") = "<Todos>"
        dt.Rows.InsertAt(rowTodos, 0)

        cmbUsuario.DataSource = dt
        cmbUsuario.ValueMember = "ID_Usuario"
        cmbUsuario.DisplayMember = "Nombre"
        cmbUsuario.SelectedIndex = 0
    End Sub

    ' Botón para buscar usuarios por nombre
    Private Sub btnBuscarUsuario_Click(sender As Object, e As EventArgs) _
        Handles btnBuscarUsuario.Click

        Try
            Dim texto = txtBusquedaNombre.Text.Trim()
            Dim dt = usuarioBLL.BuscarUsuarios(texto)
            CargarComboUsuarios(dt)
        Catch ex As Exception
            MessageBox.Show("Error al buscar usuarios: " & ex.Message)
        End Try
    End Sub

    ' Botón para filtrar y mostrar auditorías
    Private Sub btnAuditar_Click(sender As Object, e As EventArgs) _
        Handles btnAuditar.Click

        Try
            ' Determinar filtro de usuario
            Dim idUsr As Integer? = Nothing
            If cmbUsuario.SelectedValue IsNot Nothing AndAlso
               Not TypeOf cmbUsuario.SelectedValue Is DBNull Then
                idUsr = CInt(cmbUsuario.SelectedValue)
            End If

            ' Fechas de filtro
            Dim fechaIni As New DateTime(
                dtpFechaInicio.Value.Year,
                dtpFechaInicio.Value.Month,
                dtpFechaInicio.Value.Day, 0, 0, 0)

            Dim fechaFin As New DateTime(
                dtpFechaFin.Value.Year,
                dtpFechaFin.Value.Month,
                dtpFechaFin.Value.Day, 23, 59, 59)

            ' Obtener y mostrar auditorías
            Dim dtAud = auditoriaBLL.ObtenerPorFiltros(idUsr, fechaIni, fechaFin)
            dtgAuditoria.DataSource = dtAud
        Catch ex As Exception
            MessageBox.Show("Error al cargar auditorías: " & ex.Message)
        End Try
    End Sub
End Class