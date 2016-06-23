Imports DCE05.Ejemplos.EstrellaUno.ReglasNegocio

''' <summary>
''' Representa la opcion de cancelar la venta actual.
''' </summary>
Public Class OpcionCancelarVenta
    Inherits Opcion

    ''' <summary>
    ''' Ejecuta la acci�n asociada a la opci�n.
    ''' </summary>
    Friend Overrides Sub EjecutarAccion()
        If PuntoDeVenta.VentaActual Is Nothing Then
            Throw New OpcionInvalidaException("La venta no fue iniciada.")
        End If

        Try
            Dim Catalogo As CatalogoVentas = New CatalogoVentas()
            Catalogo.CancelarVenta(PuntoDeVenta.VentaActual)
            PuntoDeVenta.VentaActual = Nothing
            Console.WriteLine("Venta cancelada." + Chr(13))
        Catch Ex As ReglasNegocioException
            Console.WriteLine("Error al cancelar la venta actual: " + Ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Construye una instancia de la opci�n con sus datos b�sicos.
    ''' </summary>
    ''' <param name="codigo">El c�digo de la opci�n.</param>
    Friend Sub New(ByVal Codigo As Integer)
        Me.Codigo = Codigo
        Descripcion = "Cancelar Venta Actual"
    End Sub

End Class
