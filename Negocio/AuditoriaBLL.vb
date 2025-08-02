Public Class AuditoriaBLL
    Private dao As New AuditoriaDAO()

    ''' <summary>
    ''' Registra una acción en auditoría.
    ''' </summary>
    Public Function Registrar(idUsuario As Integer?, accion As String) As Boolean
        Dim aud = New Auditoria With {
            .IdUsuario = idUsuario,
            .Accion = accion,
            .FechaHora = DateTime.Now
        }
        Return dao.Insertar(aud)
    End Function

    ''' <summary>
    ''' Obtiene auditorías filtradas por usuario y rango de fecha.
    ''' </summary>
    Public Function ObtenerPorFiltros(
            idUsuario As Integer?,
            fechaInicio As DateTime?,
            fechaFin As DateTime?
        ) As DataTable

        Return dao.ObtenerPorFiltros(idUsuario, fechaInicio, fechaFin)
    End Function
End Class