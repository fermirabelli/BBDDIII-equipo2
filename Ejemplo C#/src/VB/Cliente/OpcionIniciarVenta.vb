Imports DCE05.Ejemplos.EstrellaUno.ReglasNegocio

''' <summary>
''' Representa la opci�n de iniciar una venta.
''' </summary>
Public Class OpcionIniciarVenta
    Inherits Opcion

    ''' <summary>
    ''' Construye una instancia de la opci�n con sus datos b�sicos.
    ''' </summary>
    ''' <param name="codigo">El c�digo de la opci�n.</param>
    Friend Sub New(ByVal Codigo As Integer)
        Me.Codigo = Codigo
        Descripcion = "Iniciar Venta"
    End Sub

    ''' <summary>
    ''' Ejecuta la acci�n asociada a la opci�n.
    ''' </summary>
    Friend Overrides Sub EjecutarAccion()
        If Not PuntoDeVenta.VentaActual Is Nothing Then
            Throw New OpcionInvalidaException("La venta ya fue iniciada.")
        End If

        Try
            Dim catalogo As CatalogoVentas = New CatalogoVentas()
            PuntoDeVenta.VentaActual = catalogo.IniciarVenta()
            Console.WriteLine("Venta iniciada.")
        Catch ex As ReglasNegocioException
            Console.WriteLine("Error al iniciar una venta: " + ex.Message)
        End Try
    End Sub
End Class
