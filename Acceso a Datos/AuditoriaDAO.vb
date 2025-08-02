Imports System.Configuration
Imports System.Data.SqlClient

Public Class AuditoriaDAO
    Private ReadOnly cadenaConexion As String =
        ConfigurationManager.ConnectionStrings("GestorProDB").ConnectionString
    Public Sub New()
        Dim settings = ConfigurationManager.ConnectionStrings("GestorProDB")
        If settings Is Nothing Then
            Throw New Exception("Falta la cadena de conexión 'GestorProDB' en App.config.")
        End If
        cadenaConexion = settings.ConnectionString
    End Sub

    ''' Inserta un nuevo registro de auditoría. '''
    Public Function Insertar(aud As Auditoria) As Boolean
        Const sql = "
            INSERT INTO Auditorias (ID_Usuario, Accion, FechaHora)
            VALUES (@usuario, @accion, @fecha)"
        Try
            Using conn As New SqlConnection(cadenaConexion),
                  cmd As New SqlCommand(sql, conn)
                conn.Open()
                cmd.Parameters.AddWithValue("@usuario", If(aud.IdUsuario, DBNull.Value))
                cmd.Parameters.AddWithValue("@accion", aud.Accion)
                cmd.Parameters.AddWithValue("@fecha", aud.FechaHora)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            Throw New Exception("Error al insertar auditoría: " & ex.Message)
        End Try
    End Function
    Public Function ObtenerPorFiltros(
            idUsuario As Integer?,
            fechaInicio As DateTime?,
            fechaFin As DateTime?
        ) As DataTable

        Const sql As String = "
            SELECT ID_Auditoria, ID_Usuario, Accion, FechaHora
              FROM Auditorias
             WHERE (@usuario    IS NULL OR ID_Usuario = @usuario)
               AND (@fechaInicio IS NULL OR FechaHora >= @fechaInicio)
               AND (@fechaFin    IS NULL OR FechaHora <= @fechaFin)
             ORDER BY FechaHora DESC"

        Try
            Using conn As New SqlConnection(cadenaConexion),
                  cmd As New SqlCommand(sql, conn),
                  da As New SqlDataAdapter(cmd)

                cmd.Parameters.AddWithValue("@usuario", If(idUsuario, DBNull.Value))
                cmd.Parameters.AddWithValue("@fechaInicio", If(fechaInicio, DBNull.Value))
                cmd.Parameters.AddWithValue("@fechaFin", If(fechaFin, DBNull.Value))

                Dim dt As New DataTable()
                da.Fill(dt)
                Return dt
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener auditorías con filtros: " & ex.Message)
        End Try
    End Function
End Class