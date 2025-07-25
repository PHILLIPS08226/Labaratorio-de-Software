Imports System.Data.SqlClient


Public Class ProductosDAO
    Private conexion As New SqlConnection("Server=PC;Database=GestorProDb;Trusted_Connection=True;")




    Public Function ObtenerTodosLosProductos() As DataTable
        Dim tabla As New DataTable()
        Dim adaptador As New SqlDataAdapter("SELECT * FROM Productos", conexion)
        adaptador.Fill(tabla)
        Return tabla
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

End Class
