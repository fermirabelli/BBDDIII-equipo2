Imports DCE05.Ejemplos.EstrellaUno.Cliente
Imports DCE05.Ejemplos.EstrellaUno.ReglasNegocio

Public Class OpcionAgregarUsuario
    Inherits Opcion

    ''' <summary>
    ''' Construye una instancia de la opción con sus datos básicos.
    ''' </summary>
    ''' <param name="codigo">El código de la opción.</param>
    Friend Sub New(ByVal Codigo As Integer)
        Me.Codigo = Codigo
        Descripcion = "Agregar Cliente"
    End Sub

    Friend Overrides Sub EjecutarAccion()

        Try
            Dim catalogoUsua As CatalogoUsuarios = New CatalogoUsuarios()
            Dim usuario As Usuario = Nothing
            Console.Write("Ingrese el DNI")
            Try
                Dim Dni As Integer = Integer.Parse(Console.ReadLine())
                Usuario = catalogoUsua.ObtenerUsuario(Dni)
                If Usuario IsNot Nothing Then
                    Throw New OpcionInvalidaException("DNI invalido")
                End If
            Catch ex As FormatException
                Throw New OpcionInvalidaException("DNI inválido !")
            End Try

            Console.Write("Ingrese el ombre: ")
            Try
                Dim Nombre As String  = Console.ReadLine()
            Catch Ex As FormatException
                Throw New OpcionInvalidaException("Cantidad inválida !")
            End Try

            Console.Write("Ingrese el Apellido: ")
            Try
                Dim Apellido As String = Console.ReadLine()
            Catch Ex As FormatException
                Throw New OpcionInvalidaException("Cantidad inválida !")
            End Try

            PuntoDeVenta.VentaActual.AgregarItem(New ItemVenta(producto, Cantidad))

            Console.Clear()
            Console.WriteLine("Agregados {0} unidades del producto {1}." + Chr(13), Cantidad, producto.Descripcion)

        Catch Ex As ReglasNegocioException
            Console.Clear()
            Console.WriteLine("Error al agregar un ítem a la venta actual: " + Ex.Message)
        Catch Ex As OpcionInvalidaException
            Console.Clear()
            Console.WriteLine(Ex.Message)
        Catch Ex As Exception
            Console.Clear()
            Console.WriteLine("Error al agregar un ítem a la venta actual.")
        End Try
    End Sub
End Class
