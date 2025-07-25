Imports System.Data.SqlClient
Public Class frmProductos
    Private dao As New ProductosDAO
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
        Dim producto As New Producto()
        producto.Nombre = txtNombre.Text
        producto.Descripcion = txtDescripcion.Text
        producto.StockActual = Integer.Parse(txtStockActual.Text)
        producto.StockMinimo = Integer.Parse(txtStockMinimo.Text)
        producto.FechaRegistro = dtpFecharegistro.Value

        dao.InsertarProducto(producto)
        MessageBox.Show("¡Producto guardado correctamente!")
        CargarProductos()
        LimpiarCampos()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If txtNombre.Text = "" Then
            MessageBox.Show("Ingresa el nombre del producto que deseas editar.")
            Exit Sub
        End If

        Dim producto As New Producto()
        producto.Nombre = txtNombre.Text
        producto.Descripcion = txtDescripcion.Text
        producto.StockActual = Integer.Parse(txtStockActual.Text)
        producto.StockMinimo = Integer.Parse(txtStockMinimo.Text)
        producto.FechaRegistro = dtpFecharegistro.Value


        MessageBox.Show("¡Producto editado correctamente!")
        LimpiarCampos()
    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtNombre.Text = "" Then
            MessageBox.Show("Especifica el nombre del producto que deseas eliminar.")
            Exit Sub
        End If

        dao.EliminarPorNombre(txtNombre.Text)
        MessageBox.Show("¡Producto eliminado exitosamente!")
        LimpiarCampos()
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