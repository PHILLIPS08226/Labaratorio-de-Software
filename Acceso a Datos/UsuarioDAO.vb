Imports System.Data.SqlClient

' Clase de acceso a datos para operaciones con usuarios y roles en la base de datos
Public Class UsuarioDAO
    ' Cadena de conexión a la base de datos local
    Private ReadOnly _conexionString As String = "Data Source=localhost;Initial Catalog=GestorProDB;Integrated Security=True"

    ' Verifica si las credenciales proporcionadas coinciden con un registro en la base de datos
    Public Function VerificarCredenciales(usuario As String, hash As String) As Usuario
        Try
            Using conn As New SqlConnection(_conexionString)
                Dim query As String = "
                    SELECT ID_Usuario, Nombre_Usuario, ID_Rol 
                    FROM Usuarios 
                    WHERE Nombre_Usuario = @usuario AND Contrasena = @hash"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@usuario", usuario)
                    cmd.Parameters.AddWithValue("@hash", hash)

                    conn.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Si se encuentra el usuario, construir y retornar un objeto Usuario
                            Return New Usuario With {
                                .IdUsuario = Convert.ToInt32(reader("ID_Usuario")),
                                .NombreUsuario = reader("Nombre_Usuario").ToString(),
                                .RolId = Convert.ToInt32(reader("ID_Rol"))
                            }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al verificar credenciales: " & ex.Message)
        End Try

        ' Si no se encuentra el usuario, retornar Nothing
        Return Nothing
    End Function

    ' Verifica si existe al menos un usuario registrado en la base de datos
    Public Function HayUsuariosRegistrados() As Boolean
        Try
            Using conn As New SqlConnection(_conexionString)
                Dim query As String = "SELECT COUNT(*) FROM Usuarios"

                Using cmd As New SqlCommand(query, conn)
                    conn.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    ' Devuelve True si hay usuarios registrados
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al verificar usuarios: " & ex.Message)
        End Try
    End Function

    ' Verifica si existen roles en la tabla, y si no, los crea
    Public Sub VerificarYCrearRoles()
        Try
            Using conn As New SqlConnection(_conexionString)
                Dim queryCheck As String = "SELECT COUNT(*) FROM Roles"
                Dim queryInsert As String = "
                    INSERT INTO Roles (Nombre) VALUES ('Administrador');
                    INSERT INTO Roles (Nombre) VALUES ('Encargado');"

                Using cmdCheck As New SqlCommand(queryCheck, conn)
                    conn.Open()
                    Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())

                    ' Si no hay roles definidos, insertarlos
                    If count = 0 Then
                        Using cmdInsert As New SqlCommand(queryInsert, conn)
                            cmdInsert.ExecuteNonQuery()
                        End Using
                    End If
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al verificar roles: " & ex.Message)
        End Try
    End Sub

    ' Crea el primer usuario del sistema con el rol especificado
    Public Sub CrearPrimerUsuario(nombre As String, contraseña As String, rolId As Integer)
        ' Hashea la contraseña usando SHA256
        Dim hashPwd As String = Seguridad.ObtenerHashSHA256(contraseña)

        Try
            Using conn As New SqlConnection(_conexionString)
                conn.Open()
                Dim query As String = "
                    INSERT INTO Usuarios (Nombre_Usuario, Contrasena, ID_Rol) 
                    VALUES (@nombre, @clave, @rol)"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@clave", hashPwd)
                    cmd.Parameters.AddWithValue("@rol", rolId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al crear usuario inicial: " & ex.Message)
        End Try
    End Sub

    ' Obtiene todos los usuarios junto con el nombre de su rol
    Public Function ObtenerTodos() As DataTable
        Try
            Using da As New SqlDataAdapter("
                SELECT 
                    U.ID_Usuario, 
                    U.Nombre_Usuario, 
                    R.Nombre AS Nombre_Rol
                FROM Usuarios U
                INNER JOIN Roles R ON U.ID_Rol = R.ID_Rol
            ", _conexionString)
                Dim dt As New DataTable()
                da.Fill(dt)
                Return dt
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener usuarios: " & ex.Message)
        End Try
    End Function

    ' Inserta un nuevo usuario en la base de datos
    Public Function InsertarUsuario(nombreUsuario As String, hashPwd As String, idRol As Integer) As Boolean
        Try
            Using conn As New SqlConnection(_conexionString)
                conn.Open()
                Dim query As String = "
                    INSERT INTO Usuarios (Nombre_Usuario, Contrasena, ID_Rol) 
                    VALUES (@nombre, @pwd, @idRol)"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nombre", nombreUsuario)
                    cmd.Parameters.AddWithValue("@pwd", hashPwd)
                    cmd.Parameters.AddWithValue("@idRol", idRol)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al insertar usuario: " & ex.Message)
            Return False
        End Try
    End Function

    ' Elimina un usuario por su ID
    Public Function EliminarUsuario(ID_Usuario As Integer) As Boolean
        Try
            Using conexion As New SqlConnection(_conexionString)
                conexion.Open()

                Using cmd As New SqlCommand("DELETE FROM Usuarios WHERE ID_Usuario = @Id", conexion)
                    cmd.Parameters.AddWithValue("@Id", ID_Usuario)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al eliminar usuario: " & ex.Message)
        End Try
    End Function

    ' Actualiza los datos de un usuario existente
    Public Function ActualizarUsuario(ID_Usuario As Integer, nombreUsuario As String, hashPwd As String, idRol As Integer) As Boolean
        Try
            Using conexion As New SqlConnection(_conexionString)
                conexion.Open()

                Dim query As String = "
                    UPDATE Usuarios 
                    SET Nombre_Usuario = @Nombre,
                        Contrasena = @Pwd,
                        ID_Rol = @Rol
                    WHERE ID_Usuario = @Id"

                Using cmd As New SqlCommand(query, conexion)
                    cmd.Parameters.AddWithValue("@Id", ID_Usuario)
                    cmd.Parameters.AddWithValue("@Nombre", nombreUsuario)
                    cmd.Parameters.AddWithValue("@Pwd", hashPwd)
                    cmd.Parameters.AddWithValue("@Rol", idRol)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al actualizar usuario: " & ex.Message)
        End Try
    End Function

    ' Recupera un usuario por su ID
    Public Function ObtenerPorID(ID_Usuario As Integer) As Usuario
        Dim usuario As New Usuario()

        Try
            Using conexion As New SqlConnection(_conexionString)
                conexion.Open()

                Dim query As String = "
                    SELECT Nombre_Usuario, Contrasena, ID_Rol 
                    FROM Usuarios 
                    WHERE ID_Usuario = @Id"

                Using cmd As New SqlCommand(query, conexion)
                    cmd.Parameters.AddWithValue("@Id", ID_Usuario)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            usuario.IdUsuario = ID_Usuario
                            usuario.NombreUsuario = reader.GetString(0)
                            usuario.Contrasena = reader.GetString(1)
                            usuario.RolId = reader.GetInt32(2)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener usuario: " & ex.Message)
        End Try

        Return usuario
    End Function

    ' Verifica si un nombre de usuario ya existe en la base de datos
    Public Function ExisteUsuario(nombreUsuario As String) As Boolean
        Try
            Using conn As New SqlConnection(_conexionString)
                Dim query As String = "SELECT COUNT(*) FROM Usuarios WHERE Nombre_Usuario = @nombre"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nombre", nombreUsuario)
                    conn.Open()
                    Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al verificar existencia de usuario: " & ex.Message)
        End Try
    End Function

End Class