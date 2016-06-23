Imports DCE05.Ejemplos.EstrellaUno.ReglasNegocio

''' <summary>
''' Representa la opci�n de finalizar una venta.
''' </summary>
Public Class OpcionConfirmarVenta
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
            Catalogo.ConfirmarVenta(PuntoDeVenta.VentaActual)
            Console.WriteLine("Venta confirmada." + Chr(13) + " Total: {0}" + Chr(13), PuntoDeVenta.VentaActual.Total())
            PuntoDeVenta.VentaActual = Nothing
        Catch Ex As ReglasNegocioException
            Console.WriteLine("Error al finalizar la venta: " + Ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Construye una instancia de la opci�n con sus datos b�sicos.
    ''' </summary>
    ''' <param name="Codigo">El c�digo de la opci�n.</param>
    Friend Sub New(ByVal Codigo As Integer)
        Me.Codigo = Codigo
        Descripcion = "Confirmar Venta Actual"
    End Sub

End Class
