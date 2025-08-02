Public Class Auditoria
    Public Property IdAuditoria As Integer            ' Clave primaria (Identity)
    Public Property IdUsuario As Integer?             ' FK al usuario que hizo la acción
    Public Property Accion As String                  ' Descripción de la acción realizada
    Public Property FechaHora As DateTime?            ' Fecha y hora de la acción
End Class