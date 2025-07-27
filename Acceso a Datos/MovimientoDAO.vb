Imports System.Data.SqlClient

Public Class MovimientoDAO
    ' Cadena de conexión a la base de datos local
    Private ReadOnly conexion As String = "Data Source=localhost;Initial Catalog=GestorProDB;Integrated Security=True"

    ' Inserta un nuevo registro de movimiento en la tabla Movimientos
    Public Function InsertarMovimiento(mov As Movimiento) As Boolean
        Try
            Using conn As New SqlConnection(conexion)
                conn.Open()

                ' Comando SQL parametrizado para insertar el movimiento
                Dim query As String = "
                    INSERT INTO Movimientos (ID_Producto, ID_Usuario, ID_Tipo, Cantidad, Fecha)
                    VALUES (@producto, @usuario, @tipo, @cantidad, GETDATE())"

                Using cmd As New SqlCommand(query, conn)
                    ' Cargar parámetros con los datos del movimiento
                    cmd.Parameters.AddWithValue("@producto", mov.IdProducto)
                    cmd.Parameters.AddWithValue("@usuario", mov.IdUsuario)
                    cmd.Parameters.AddWithValue("@tipo", mov.IdTipo)
                    cmd.Parameters.AddWithValue("@cantidad", mov.Cantidad)

                    ' Ejecutar e indicar si se afectó al menos una fila
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            ' Captura y lanza error específico de inserción
            Throw New Exception("Error al insertar movimiento: " & ex.Message)
        End Try
    End Function

    ' Verifica si existen los tipos de movimiento y los crea si no existen
    Public Sub VerificarYCrearTiposMovimiento()
        Try
            Using conn As New SqlConnection(conexion)
                conn.Open()

                ' Consulta cuántos registros existen en TiposMovimiento
                Dim queryCheck As String = "SELECT COUNT(*) FROM TiposMovimiento"
                Using cmdCheck As New SqlCommand(queryCheck, conn)
                    Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())

                    If count = 0 Then
                        ' Si no hay registros, insertar "Entrada" y "Salida"
                        Dim queryInsert As String = "
                            INSERT INTO TiposMovimiento (Nombre) VALUES ('Entrada');
                            INSERT INTO TiposMovimiento (Nombre) VALUES ('Salida');"

                        Using cmdInsert As New SqlCommand(queryInsert, conn)
                            cmdInsert.ExecuteNonQuery()
                        End Using
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Error al verificar o crear tipos
            Throw New Exception("Error al verificar tipos de movimiento: " & ex.Message)
        End Try
    End Sub

    ' Retorna el ID del tipo de movimiento según su nombre
    Public Function ObtenerIdTipoMovimiento(nombreTipo As String) As Integer
        Try
            Using conn As New SqlConnection(conexion)
                conn.Open()

                ' Consulta parametrizada por nombre del tipo
                Dim query As String = "SELECT ID_Tipo FROM TiposMovimiento WHERE Nombre = @nombre"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nombre", nombreTipo)

                    ' Ejecuta y valida el resultado
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return Convert.ToInt32(result)
                    Else
                        Throw New Exception("No se encontró el tipo de movimiento '" & nombreTipo & "'.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener ID del tipo de movimiento: " & ex.Message)
        End Try
    End Function

    ' Consulta y retorna tabla con los movimientos más recientes
    Public Function ObtenerMovimientosRecientes() As DataTable
        Try
            Using conn As New SqlConnection(conexion)
                ' SQL que une las tablas para mostrar detalle de cada movimiento
                Dim query As String = "
                    SELECT  
                        TM.Nombre AS TipoMovimiento,
                        P.Nombre AS Producto,
                        M.Cantidad,
                        M.Fecha
                    FROM Movimientos M
                    INNER JOIN TiposMovimiento TM ON M.ID_Tipo = TM.ID_Tipo
                    INNER JOIN Productos P ON M.ID_Producto = P.ID_Producto
                    ORDER BY M.Fecha DESC"

                ' Ejecuta la consulta y carga el resultado en un DataTable
                Dim da As New SqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                da.Fill(dt)

                Return dt
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener movimientos recientes: " & ex.Message)
        End Try
    End Function
End Class