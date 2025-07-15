Imports System.Data.SqlClient

Public Class UsuarioDAO
    Private ReadOnly _conexionString As String = "Data Source=localhost;Initial Catalog=GestorProDB;Integrated Security=True"

    Public Function VerificarCredenciales(usuario As String, contraseña As String) As Usuario
        Try
            Using conn As New SqlConnection(_conexionString)
                Dim query As String = "
                SELECT ID_Usuario, Nombre_Usuario, ID_Rol 
                FROM Usuarios 
                WHERE Nombre_Usuario = @usuario AND Contrasena = @contraseña"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@usuario", usuario)
                    cmd.Parameters.AddWithValue("@contraseña", contraseña)

                    conn.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return New Usuario With {
                                .IdUsuario = Convert.ToInt32(reader("ID_Usuario")),
                                .NombreUsuario = reader("Nombre_Usuario").ToString(),
                                .RolId = Convert.ToInt32(reader("ID_Rol"))
                            }
                        Else
                            Return Nothing
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al verificar credenciales: " & ex.Message)
        End Try
    End Function

    Public Function HayUsuariosRegistrados() As Boolean
        Try
            Using conn As New SqlConnection(_conexionString)
                Dim query As String = "SELECT COUNT(*) FROM Usuarios"

                Using cmd As New SqlCommand(query, conn)
                    conn.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al verificar usuarios: " & ex.Message)
        End Try
    End Function

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
    Public Sub CrearPrimerUsuario(nombre As String, contraseña As String, rolId As Integer)
        Try
            Using conn As New SqlConnection(_conexionString)
                Dim query As String = "
                    INSERT INTO Usuarios (Nombre_Usuario, Contrasena, ID_Rol) 
                    VALUES (@nombre, @clave, @rol)"

                ' Asumiendo que no tenés IDENTITY:
                Dim idQuery As String = "SELECT ISNULL(MAX(ID_Usuario), 0) + 1 FROM Usuarios"
                Using cmdId As New SqlCommand(idQuery, conn)
                    conn.Open()
                    Dim nuevoId As Integer = Convert.ToInt32(cmdId.ExecuteScalar())

                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", nuevoId)
                        cmd.Parameters.AddWithValue("@nombre", nombre)
                        cmd.Parameters.AddWithValue("@clave", contraseña)
                        cmd.Parameters.AddWithValue("@rol", rolId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al crear usuario inicial: " & ex.Message)
        End Try
    End Sub

End Class
