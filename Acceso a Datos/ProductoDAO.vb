Imports System.Data.SqlClient


Public Class ProductosDAO
    Private conexion As New SqlConnection("Server=Localhost;Database=GestorProDb;Trusted_Connection=True;")




    Public Function ObtenerTodosLosProductos() As DataTable
        Dim tabla As New DataTable()
        Dim adaptador As New SqlDataAdapter("SELECT * FROM Productos", conexion)
        adaptador.Fill(tabla)
        Return tabla
    End Function

    Public Function ObtenerProductos() As DataTable
        Try
            Using da As New SqlDataAdapter("SELECT ID_Producto, Nombre FROM Productos", conexion)
                Dim dt As New DataTable()
                da.Fill(dt)
                Return dt
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener productos: " & ex.Message)
        End Try
    End Function

    Public Sub InsertarProducto(producto As Producto)
        Dim query As String = "INSERT INTO Productos (Nombre, Descripcion, StockActual, StockMinimo, FechaRegistro) " &
                              "VALUES (@nombre, @descripcion, @stockActual, @stockMinimo, @fechaRegistro)"
        Dim comando As New SqlCommand(query, conexion)
        comando.Parameters.AddWithValue("@nombre", producto.Nombre)
        comando.Parameters.AddWithValue("@descripcion", producto.Descripcion)
        comando.Parameters.AddWithValue("@stockActual", producto.StockActual)
        comando.Parameters.AddWithValue("@stockMinimo", producto.StockMinimo)
        comando.Parameters.AddWithValue("@fechaRegistro", producto.FechaRegistro)

        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
    End Sub


    Public Sub EditarPorNombre(producto As Producto)
        Dim query As String = "UPDATE Productos SET Descripcion=@descripcion, StockActual=@stockActual, StockMinimo=@stockMinimo, FechaRegistro=@fechaRegistro WHERE Nombre=@nombre"
        Dim comando As New SqlCommand(query, conexion)
        comando.Parameters.AddWithValue("@nombre", producto.Nombre)
        comando.Parameters.AddWithValue("@descripcion", producto.Descripcion)
        comando.Parameters.AddWithValue("@stockActual", producto.StockActual)
        comando.Parameters.AddWithValue("@stockMinimo", producto.StockMinimo)
        comando.Parameters.AddWithValue("@fechaRegistro", producto.FechaRegistro)

        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
    End Sub

    Public Sub EliminarPorNombre(nombre As String)
        Dim query As String = "DELETE FROM Productos WHERE Nombre=@nombre"
        Dim comando As New SqlCommand(query, conexion)
        comando.Parameters.AddWithValue("@nombre", nombre)

        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
    End Sub

    Public Sub ActualizarProductoPorNombre(producto As Producto)
        Dim query As String = "UPDATE Productos SET Descripcion=@descripcion, StockActual=@stockActual, StockMinimo=@stockMinimo, FechaRegistro=@fechaRegistro WHERE Nombre=@nombre"
        Dim comando As New SqlCommand(query, conexion)
        comando.Parameters.AddWithValue("@nombre", producto.Nombre)
        comando.Parameters.AddWithValue("@descripcion", producto.Descripcion)
        comando.Parameters.AddWithValue("@stockActual", producto.StockActual)
        comando.Parameters.AddWithValue("@stockMinimo", producto.StockMinimo)
        comando.Parameters.AddWithValue("@fechaRegistro", producto.FechaRegistro)

        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
    End Sub

    Public Function BuscarPorNombre(nombre As String) As DataTable
        Dim tabla As New DataTable()
        Dim query As String = "SELECT * FROM Productos WHERE Nombre LIKE @nombre"
        Dim comando As New SqlCommand(query, conexion)
        comando.Parameters.AddWithValue("@nombre", "%" & nombre & "%")
        Dim adaptador As New SqlDataAdapter(comando)
        adaptador.Fill(tabla)
        Return tabla
    End Function



    Public Function ObtenerStockActual(idProducto As Integer) As Integer
        Try
            conexion.Open()
            Dim query As String = "SELECT StockActual FROM Productos WHERE ID_Producto = @id"
            Using cmd As New SqlCommand(query, conexion)
                cmd.Parameters.AddWithValue("@id", idProducto)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener stock actual: " & ex.Message)
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function ObtenerStockMinimo(idProducto As Integer) As Integer
        Try
            conexion.Open()
            Dim query As String = "SELECT StockMinimo FROM Productos WHERE ID_Producto = @id"
            Using cmd As New SqlCommand(query, conexion)
                cmd.Parameters.AddWithValue("@id", idProducto)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener stock mínimo: " & ex.Message)
        Finally
            conexion.Close()
        End Try
    End Function

    Public Sub ActualizarStock(idProducto As Integer, nuevaCantidad As Integer)
        Try
            conexion.Open()
            Dim query As String = "UPDATE Productos SET StockActual = @stock WHERE ID_Producto = @id"
            Using cmd As New SqlCommand(query, conexion)
                cmd.Parameters.AddWithValue("@stock", nuevaCantidad)
                cmd.Parameters.AddWithValue("@id", idProducto)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw New Exception("Error al actualizar stock: " & ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

End Class
