Public Class MovimientoBLL
    Private dao As New MovimientoDAO()
    Private productoDao As New ProductosDAO()

    Public Function RegistrarMovimiento(mov As Movimiento) As Boolean
        ' Validar que el producto y la cantidad sean válidos (>0)
        If mov.IdProducto <= 0 OrElse mov.Cantidad <= 0 Then
            Throw New Exception("Datos inválidos para el movimiento.")
        End If

        ' Obtener el stock actual del producto
        Dim stockActual = productoDao.ObtenerStockActual(mov.IdProducto)
        Dim nuevoStock As Integer

        ' Determinar si el movimiento es entrada o salida
        If mov.IdTipo = 1 Then ' Entrada → aumenta stock
            nuevoStock = stockActual + mov.Cantidad
        ElseIf mov.IdTipo = 2 Then ' Salida → reduce stock
            If mov.Cantidad > stockActual Then
                Throw New Exception("No hay suficiente stock para realizar la salida.")
            End If
            nuevoStock = stockActual - mov.Cantidad
        Else
            ' Validar que el tipo de movimiento sea válido
            Throw New Exception("Tipo de movimiento no válido.")
        End If

        ' Registrar el movimiento en la base de datos
        Dim exito = dao.InsertarMovimiento(mov)

        If exito Then
            ' Actualizar el stock del producto según el movimiento
            productoDao.ActualizarStock(mov.IdProducto, nuevoStock)

            ' Comprobar si el nuevo stock está por debajo del mínimo permitido
            Dim minimo = productoDao.ObtenerStockMinimo(mov.IdProducto)
            If nuevoStock <= minimo Then
                ' Mostrar alerta de stock bajo en la UI
                MessageBox.Show("⚠ El stock del producto ha alcanzado o bajado del mínimo establecido.", "Alerta de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

        Return exito ' Retornar si el movimiento fue exitoso
    End Function

    Public Function ObtenerIdTipoMovimiento(nombreTipo As String) As Integer
        ' Obtener el ID numérico del tipo de movimiento según su nombre
        Dim dao As New MovimientoDAO()
        Return dao.ObtenerIdTipoMovimiento(nombreTipo)
    End Function

End Class