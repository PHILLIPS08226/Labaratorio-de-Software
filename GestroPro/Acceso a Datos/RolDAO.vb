Imports System.Data.SqlClient

Public Class RolDAO
    Private ReadOnly _conexionString As String = "Data Source=localhost;Initial Catalog=GestorProDB;Integrated Security=True"

    ' Función para obtener los roles desde la base de datos
    Public Function CargarRoles() As List(Of Rol)
        Dim listaRoles As New List(Of Rol)

        Try
            Using conexion As New SqlConnection(_conexionString)
                conexion.Open()

                Dim query As String = "SELECT ID_Rol, Nombre FROM Roles"
                Using comando As New SqlCommand(query, conexion)
                    Using reader As SqlDataReader = comando.ExecuteReader()
                        While reader.Read()
                            Dim rol As New Rol()
                            rol.ID_Rol = reader.GetInt32(0)
                            rol.Nombre = reader.GetString(1)
                            listaRoles.Add(rol)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los roles: " & ex.Message)
        End Try

        Return listaRoles
    End Function
End Class

