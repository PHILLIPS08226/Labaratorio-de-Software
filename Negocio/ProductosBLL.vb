Public Class ProductosBLL
    Private dao As New ProductosDAO()
    Private audit As New AuditoriaBLL()

    ''' <summary>Devuelve todos los productos completos.</summary>
    Public Function ObtenerTodosProductos() As DataTable
        Return dao.ObtenerTodosLosProductos()
    End Function

    ''' <summary>Devuelve ID y Nombre de productos para listas.</summary>
    Public Function ObtenerProductos() As DataTable
        Return dao.ObtenerProductos()
    End Function

    ''' <summary>Inserta un producto y registra auditoría.</summary>
    Public Function InsertarProducto(prod As Producto, idUsuario As Integer) As Boolean
        Dim exito = dao.InsertarProducto(prod)
        If exito Then
            audit.Registrar(idUsuario, $"Se agregó producto '{prod.Nombre}'")
        End If
        Return exito
    End Function

    ''' <summary>Edita un producto existente y registra auditoría.</summary>
    Public Function EditarProducto(prod As Producto, idUsuario As Integer) As Boolean
        Dim exito = dao.EditarProducto(prod)
        If exito Then
            audit.Registrar(idUsuario, $"Se editó producto '{prod.Nombre}'")
        End If
        Return exito
    End Function

    ''' <summary>Elimina un producto por nombre y registra auditoría.</summary>
    Public Function EliminarProducto(nombre As String, idUsuario As Integer) As Boolean
        Dim exito = dao.EliminarProducto(nombre)
        If exito Then
            audit.Registrar(idUsuario, $"Se eliminó producto '{nombre}'")
        End If
        Return exito
    End Function

    ''' <summary>Busca productos por fragmento de nombre.</summary>
    Public Function BuscarProductos(nombre As String) As DataTable
        Return dao.BuscarPorNombre(nombre)
    End Function
End Class
