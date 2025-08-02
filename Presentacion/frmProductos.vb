Imports System.Data.SqlClient
Public Class frmProductos
    Private dao As New ProductosDAO
    Private usuarioLogueado As Usuario
    Private bll As New ProductosBLL()

    Public Sub New(usuario As Usuario)
        InitializeComponent()
        Me.usuarioLogueado = usuario
    End Sub

    Private Sub CargarProductos()
        Dim dt As DataTable = dao.ObtenerTodosLosProductos()
        dgvProductos.DataSource = dt

    End Sub


    Private Sub frmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductos()
    End Sub

    Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = dgvProductos.Rows(e.RowIndex)
            txtNombre.Text = fila.Cells("Nombre").Value.ToString()
            txtDescripcion.Text = fila.Cells("Descripcion").Value.ToString()
            txtStockActual.Text = fila.Cells("StockActual").Value.ToString()
            txtStockMinimo.Text = fila.Cells("StockMinimo").Value.ToString()
            dtpFecharegistro.Value = Convert.ToDateTime(fila.Cells("FechaRegistro").Value)
        End If
    End Sub

    Private Sub LimpiarCampos()

        txtNombre.Clear()
        txtDescripcion.Clear()
        txtStockActual.Clear()
        txtStockMinimo.Clear()
        dtpFecharegistro.Value = DateTime.Now
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim prod As New Producto() With {
            .Nombre = txtNombre.Text,
            .Descripcion = txtDescripcion.Text,
            .StockActual = Integer.Parse(txtStockActual.Text),
            .StockMinimo = Integer.Parse(txtStockMinimo.Text),
            .FechaRegistro = dtpFecharegistro.Value
        }

        If bll.InsertarProducto(prod, usuarioLogueado.IdUsuario) Then
            MessageBox.Show("¡Producto guardado correctamente!")
            CargarProductos()
            LimpiarCampos()
        Else
            MessageBox.Show("Error al guardar producto.")
        End If
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("Ingresa el nombre del producto a editar.")
            Return
        End If

        Dim prod As New Producto() With {
            .Nombre = txtNombre.Text,
            .Descripcion = txtDescripcion.Text,
            .StockActual = Integer.Parse(txtStockActual.Text),
            .StockMinimo = Integer.Parse(txtStockMinimo.Text),
            .FechaRegistro = dtpFecharegistro.Value
        }

        If bll.EditarProducto(prod, usuarioLogueado.IdUsuario) Then
            MessageBox.Show("¡Producto editado correctamente!")
            CargarProductos()
            LimpiarCampos()
        Else
            MessageBox.Show("Error al editar producto.")
        End If
    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("Especifica el nombre del producto a eliminar.")
            Return
        End If

        If bll.EliminarProducto(txtNombre.Text, usuarioLogueado.IdUsuario) Then
            MessageBox.Show("¡Producto eliminado exitosamente!")
            CargarProductos()
            LimpiarCampos()
        Else
            MessageBox.Show("Error al eliminar producto.")
        End If
    End Sub




    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim nombreBuscado As String = txtBuscar.Text.Trim()

        If nombreBuscado = "" Then
            MessageBox.Show("Escribe un nombre para buscar.")
            Exit Sub
        End If

        Dim resultados As DataTable = dao.BuscarPorNombre(nombreBuscado)
        dgvProductos.DataSource = resultados


    End Sub








End Class