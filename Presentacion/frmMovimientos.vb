Public Class frmMovimientos
    ' Usuario actualmente logueado en el sistema
    Private usuarioLogueado As Usuario

    ' Instancias de la lógica de negocio y acceso a datos
    Private bll As New MovimientoBLL()
    Private productoDAO As New ProductosDAO()

    Public Sub New(usuario As Usuario)
        InitializeComponent() ' Inicializa componentes gráficos del formulario
        Me.usuarioLogueado = usuario ' Asigna el usuario activo al formulario
    End Sub

    ' Carga inicial del formulario
    Private Sub frmMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Pobla ComboBox con los productos disponibles
        cmbProducto.DataSource = productoDAO.ObtenerProductos
        cmbProducto.DisplayMember = "Nombre"           ' Muestra el nombre del producto
        cmbProducto.ValueMember = "ID_Producto"        ' Internamente usa el ID
        cmbProducto.SelectedIndex = -1                 ' Ningún producto seleccionado inicialmente

        CargarMovimientosRecientes()                   ' Muestra últimos movimientos en la grilla
    End Sub

    ' Evento que guarda el movimiento en base de datos
    Private Sub btnGuardarMovimiento_Click(sender As Object, e As EventArgs) Handles btnGuardarMovimiento.Click
        ' Validar que se haya seleccionado un producto
        If cmbProducto.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione un producto.")
            Return
        End If

        ' Detectar el tipo de movimiento seleccionado (Entrada/Salida)
        Dim tipoNombre As String = ""
        If rdbEntrada.Checked Then
            tipoNombre = "Entrada"
        ElseIf rdbSalida.Checked Then
            tipoNombre = "Salida"
        Else
            MessageBox.Show("Seleccione tipo de movimiento (Entrada o Salida).")
            Return
        End If

        ' Obtener el ID numérico del tipo de movimiento desde la BLL
        Dim tipoId As Integer
        Try
            tipoId = bll.ObtenerIdTipoMovimiento(tipoNombre)
        Catch ex As Exception
            MessageBox.Show("Error al obtener el tipo de movimiento: " & ex.Message)
            Return
        End Try

        ' Crear y poblar el objeto Movimiento con los datos seleccionados
        Dim mov As New Movimiento With {
            .IdProducto = CInt(cmbProducto.SelectedValue),
            .IdUsuario = usuarioLogueado.IdUsuario,
            .IdTipo = tipoId,
            .Cantidad = CInt(nudCantidad.Value)
        }

        ' Registrar el movimiento en la BLL y validar resultado
        Try
            If bll.RegistrarMovimiento(mov) Then
                MessageBox.Show("Movimiento registrado correctamente.")
                CargarMovimientosRecientes() ' Refrescar la grilla
                LimpiarCampos()              ' Restablecer controles de entrada
            Else
                MessageBox.Show("Error al registrar movimiento.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Consulta y carga los movimientos recientes en el DataGridView
    Private Sub CargarMovimientosRecientes()
        Try
            Dim dao As New MovimientoDAO()
            Dim dt = dao.ObtenerMovimientosRecientes()
            dtgMovimientosRecientes.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error al cargar movimientos recientes: " & ex.Message)
        End Try
    End Sub

    ' Restablece los controles a su estado inicial
    Private Sub LimpiarCampos()
        cmbProducto.SelectedIndex = -1
        rdbEntrada.Checked = False
        rdbSalida.Checked = False
        nudCantidad.Value = 1
    End Sub

End Class