''' <summary>
''' Representa la lista de opciones de la aplicaci�n.
''' </summary>
Public Class ListaOpciones

    ''' <summary>
    ''' La lista de opciones disponibles.
    ''' </summary>
    Private Shared _Opciones As List(Of Opcion) = New List(Of Opcion)()

    ''' <summary>
    ''' Construye est�ticamente la lista de opciones.
    ''' </summary>
    Shared Sub New()
        _Opciones.Add(New OpcionListarProductos(1))
        _Opciones.Add(New OpcionIniciarVenta(2))
        _Opciones.Add(New OpcionAgregarItemVenta(3))
        _Opciones.Add(New OpcionListarCarrito(4))
        _Opciones.Add(New OpcionConfirmarVenta(5))
        _Opciones.Add(New OpcionCancelarVenta(6))
        _Opciones.Add(New OpcionSalir(99))
    End Sub

    ''' <summary>
    ''' Obtiene el listado de opciones disponibles.
    ''' </summary>
    ''' <returns>El listado de opciones.</returns>
    Friend Shared Function ObtenerOpciones() As List(Of Opcion)
        Return _Opciones
    End Function

    ''' <summary>
    ''' Permite obtener una opci�n seg�n su c�digo.
    ''' </summary>
    ''' <param name="codigo">El c�digo de la opci�n</param>
    ''' <returns>La opci�n encontrada.</returns>
    ''' <exception cref="OpcionInvalidaException">Si la opci�n no existe.</exception>
    Friend Shared Function Obtener(ByVal Codigo As Integer) As Opcion
        Dim MiOpcion As Opcion = Nothing
        For Each Op As Opcion In _Opciones
            If (Op.Codigo.Equals(Codigo)) Then
                MiOpcion = Op
            End If
        Next

        If MiOpcion Is Nothing Then
            Throw New OpcionInvalidaException("Opci�n inv�lida.")
        End If

        Return MiOpcion
    End Function
End Class
