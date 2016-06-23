Imports DCE05.Ejemplos.EstrellaUno.ReglasNegocio

''' <summary>
''' Representa la opci�n de listar el carrito de compras.
''' </summary>
Public Class OpcionListarCarrito
    Inherits Opcion

    ''' <summary>
    ''' Construye una instancia de la opci�n con sus datos b�sicos.
    ''' </summary>
    ''' <param name="codigo">El c�digo de la opci�n.</param>
    Friend Sub New(ByVal Codigo As Integer)
        Me.Codigo = Codigo
        Descripcion = "Listar Carrito de Compras"
    End Sub

    ''' <summary>
    ''' Ejecuta la acci�n asociada a la opci�n.
    ''' </summary>
    ''' <exception cref="OpcionInvalidaException">Si la opci�n no fue ejecutada exitosamente.</exception>
    Friend Overrides Sub EjecutarAccion()
        If PuntoDeVenta.VentaActual Is Nothing Then
            Throw New OpcionInvalidaException("La venta no fue iniciada.")
        End If

        If PuntoDeVenta.VentaActual.Items.Count.Equals(0) Then
            Console.WriteLine("Carrito vac�o.")
        Else
            Console.WriteLine("Carrito de Compras")
            Console.WriteLine("------------------" + Chr(13))

            Console.WriteLine("Items: " + PuntoDeVenta.VentaActual.Items.Count.ToString())
            Console.WriteLine("Codigo".PadRight(7) + Chr(7) + "Producto".PadRight(30) + Chr(7) + "Cantidad".PadRight(9) + Chr(7) + "Sub Total")

            For Each Item As ItemVenta In PuntoDeVenta.VentaActual.Items
                Console.WriteLine(Item.Codigo.ToString().PadRight(7) + Chr(7) + Item.Producto.Descripcion.PadRight(30) + Chr(7) + Item.Cantidad.ToString().PadRight(9) + Chr(7) + Item.CalcularTotal().ToString())
            Next
            Console.WriteLine(Chr(13))
        End If
    End Sub
End Class
