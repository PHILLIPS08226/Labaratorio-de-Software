Imports System.Data.SqlClient
Imports System.Configuration

Public Class ProductosDAO
    ' Leer cadena de conexión desde app.config
    Private ReadOnly cadenaConexion As String

    Public Sub New()
        Dim settings = ConfigurationManager.ConnectionStrings("GestorProDB")
        If settings Is Nothing Then
            Throw New Exception("Falta la cadena de conexión 'GestorProDB' en App.config.")
        End If
        cadenaConexion = settings.ConnectionString
    End Sub



    ''' <summary>
    ''' Devuelve todos los productos (todas las columnas).
    ''' </summary>
    Public Function ObtenerTodosLosProductos() As DataTable
        Using conn As New SqlConnection(cadenaConexion),
              da As New SqlDataAdapter("SELECT * FROM Productos", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            Return dt
        End Using
    End Function

    ''' <summary>
    ''' Devuelve lista de productos para ComboBox (ID y Nombre).
    ''' </summary>
    Public Function ObtenerProductos() As DataTable
        Try
            Using conn As New SqlConnection(cadenaConexion),
                  da As New SqlDataAdapter(
                          "SELECT ID_Producto, Nombre FROM Productos", conn)
                Dim dt As New DataTable()
                da.Fill(dt)
                Return dt
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener productos: " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Inserta un nuevo producto. Retorna True si la operación fue exitosa.
    ''' </summary>
    Public Function InsertarProducto(prod As Producto) As Boolean
        Const sql As String =
            "INSERT INTO Productos (Nombre, Descripcion, StockActual, StockMinimo, FechaRegistro) " &
            "VALUES (@nombre, @descripcion, @stockActual, @stockMinimo, @fechaRegistro)"
        Try
            Using conn As New SqlConnection(cadenaConexion),
                  cmd As New SqlCommand(sql, conn)
                conn.Open()
                cmd.Parameters.AddWithValue("@nombre", prod.Nombre)
                cmd.Parameters.AddWithValue("@descripcion", prod.Descripcion)
                cmd.Parameters.AddWithValue("@stockActual", prod.StockActual)
                cmd.Parameters.AddWithValue("@stockMinimo", prod.StockMinimo)
                cmd.Parameters.AddWithValue("@fechaRegistro", prod.FechaRegistro)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            Throw New Exception("Error al insertar producto: " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Actualiza un producto por nombre. Retorna True si se modificó.
    ''' </summary>
    Public Function EditarProducto(prod As Producto) As Boolean
        Const sql As String =
            "UPDATE Productos " &
            "SET Descripcion=@descripcion, StockActual=@stockActual, " &
            "    StockMinimo=@stockMinimo, FechaRegistro=@fechaRegistro " &
            "WHERE Nombre=@nombre"
        Try
            Using conn As New SqlConnection(cadenaConexion),
                  cmd As New SqlCommand(sql, conn)
                conn.Open()
                cmd.Parameters.AddWithValue("@nombre", prod.Nombre)
                cmd.Parameters.AddWithValue("@descripcion", prod.Descripcion)
                cmd.Parameters.AddWithValue("@stockActual", prod.StockActual)
                cmd.Parameters.AddWithValue("@stockMinimo", prod.StockMinimo)
                cmd.Parameters.AddWithValue("@fechaRegistro", prod.FechaRegistro)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            Throw New Exception("Error al editar producto: " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Elimina un producto según su nombre. Retorna True si se eliminó.
    ''' </summary>
    Public Function EliminarProducto(nombre As String) As Boolean
        Const sql As String = "DELETE FROM Productos WHERE Nombre=@nombre"
        Try
            Using conn As New SqlConnection(cadenaConexion),
                  cmd As New SqlCommand(sql, conn)
                conn.Open()
                cmd.Parameters.AddWithValue("@nombre", nombre)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            Throw New Exception("Error al eliminar producto: " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Busca productos cuyo nombre contiene el texto dado.
    ''' </summary>
    Public Function BuscarPorNombre(nombre As String) As DataTable
        Const sql As String = "SELECT * FROM Productos WHERE Nombre LIKE @nombre"
        Using conn As New SqlConnection(cadenaConexion),
              cmd As New SqlCommand(sql, conn),
              da As New SqlDataAdapter(cmd)
            cmd.Parameters.AddWithValue("@nombre", "%" & nombre & "%")
            Dim dt As New DataTable()
            da.Fill(dt)
            Return dt
        End Using
    End Function

    ' (Métodos de stock sin cambios)
    Public Function ObtenerStockActual(idProducto As Integer) As Integer
        Try
            Using conn As New SqlConnection(cadenaConexion),
                  cmd As New SqlCommand(
                          "SELECT StockActual FROM Productos WHERE ID_Producto=@id", conn)
                conn.Open()
                cmd.Parameters.AddWithValue("@id", idProducto)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener stock actual: " & ex.Message)
        End Try
    End Function

    Public Function ObtenerStockMinimo(idProducto As Integer) As Integer
        Try
            Using conn As New SqlConnection(cadenaConexion),
                  cmd As New SqlCommand(
                          "SELECT StockMinimo FROM Productos WHERE ID_Producto=@id", conn)
                conn.Open()
                cmd.Parameters.AddWithValue("@id", idProducto)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener stock mínimo: " & ex.Message)
        End Try
    End Function

    Public Sub ActualizarStock(idProducto As Integer, nuevaCantidad As Integer)
        Try
            Using conn As New SqlConnection(cadenaConexion),
                  cmd As New SqlCommand(
                          "UPDATE Productos SET StockActual=@stock WHERE ID_Producto=@id", conn)
                conn.Open()
                cmd.Parameters.AddWithValue("@stock", nuevaCantidad)
                cmd.Parameters.AddWithValue("@id", idProducto)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw New Exception("Error al actualizar stock: " & ex.Message)
        End Try
    End Sub

    Public Function ObtenerNombreProducto(idProducto As Integer) As String
        Try
            Using conn As New SqlConnection(cadenaConexion)
                conn.Open()
                Const sql As String = "
                SELECT Nombre
                FROM Productos
                WHERE ID_Producto = @id
            "
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", idProducto)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return result.ToString()
                    Else
                        Throw New Exception($"No existe el producto con ID = {idProducto}")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener nombre de producto: " & ex.Message)
        End Try
    End Function
End Class
