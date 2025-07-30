Public Class MovimientoBLL
    Private dao As New MovimientoDAO()
    Private productoDao As New ProductosDAO()
    Private audBLL As New AuditoriaBLL()   ' Módulo de auditorías

    ''' <summary>
    ''' Registra un movimiento de inventario (entrada o salida), actualiza stock
    ''' y deja un registro en Auditorías.
    ''' </summary>
    Public Function RegistrarMovimiento(mov As Movimiento) As Boolean
        ' 1) Validar datos básicos
        If mov.IdProducto <= 0 OrElse mov.Cantidad <= 0 Then
            Throw New Exception("Datos inválidos para el movimiento.")
        End If

        ' 2) Leer stock actual y calcular nuevo stock
        Dim stockActual = productoDao.ObtenerStockActual(mov.IdProducto)
        Dim nuevoStock As Integer
        Dim tipoDesc As String

        If mov.IdTipo = 1 Then
            tipoDesc = "Entrada"
            nuevoStock = stockActual + mov.Cantidad
        ElseIf mov.IdTipo = 2 Then
            tipoDesc = "Salida"
            If mov.Cantidad > stockActual Then
                Throw New Exception("No hay suficiente stock para realizar la salida.")
            End If
            nuevoStock = stockActual - mov.Cantidad
        Else
            Throw New Exception("Tipo de movimiento no válido.")
        End If

        ' 3) Insertar movimiento
        Dim exito = dao.InsertarMovimiento(mov)

        If exito Then
            ' 4a) Actualizar stock en tabla Productos
            productoDao.ActualizarStock(mov.IdProducto, nuevoStock)

            ' 4b) Registrar auditoría con nombre de producto
            Dim nombreProd As String = productoDao.ObtenerNombreProducto(mov.IdProducto)
            Dim mensajeAud As String = $"{tipoDesc} de {mov.Cantidad} unidades del producto '{nombreProd}'"
            audBLL.Registrar(mov.IdUsuario, $"Se registró movimiento: {mensajeAud}")

            ' 4c) Alerta de stock mínimo en UI
            Dim minimo = productoDao.ObtenerStockMinimo(mov.IdProducto)
            If nuevoStock <= minimo Then
                MessageBox.Show(
                    "⚠ El stock del producto ha alcanzado o bajado del mínimo establecido.",
                    "Alerta de Stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )
            End If
        End If

        Return exito
    End Function

    ''' <summary>
    ''' Obtiene el ID del tipo de movimiento por nombre (p.e. "Entrada", "Salida").
    ''' </summary>
    Public Function ObtenerIdTipoMovimiento(nombreTipo As String) As Integer
        Return dao.ObtenerIdTipoMovimiento(nombreTipo)
    End Function

End Class
