Imports DCE05.Ejemplos.EstrellaUno.ReglasNegocio

Public Class OpcionSalir
    Inherits Opcion

    ''' <summary>
    ''' Ejecuta la acci�n asociada a la opci�n.
    ''' </summary>
    Friend Overrides Sub EjecutarAccion()
        Try
            Dim Catalogo As CatalogoVentas = New CatalogoVentas()
            If Not PuntoDeVenta.VentaActual Is Nothing Then
                Catalogo.CancelarVenta(PuntoDeVenta.VentaActual)
            End If
            Catalogo.CancelarVentasPendientes()
            PuntoDeVenta.Salir()
        Catch Ex As ReglasNegocioException
            Console.WriteLine("Error al cancelar las ventas : " + Ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Construye una instancia de la opci�n con sus datos b�sicos.
    ''' </summary>
    ''' <param name="MiCodigo">El c�digo de la opci�n.</param>
    Friend Sub New(ByVal MiCodigo As Integer)
        Me.Codigo = MiCodigo
        Descripcion = "Salir"
    End Sub

End Class
