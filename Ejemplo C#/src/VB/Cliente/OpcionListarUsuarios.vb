
Imports DCE05.Ejemplos.EstrellaUno.ReglasNegocio
Imports DCE05.Ejemplos.EstrellaUno.Cliente

Friend Class OpcionListarUsuarios
    Inherits Opcion

    ''' <summary>
    ''' Construye una instancia de la opción con sus datos básicos.
    ''' </summary>
    ''' <param name="codigo">El código de la opción.</param>
    Friend Sub New(ByVal Codigo As Integer)
        Me.Codigo = Codigo
        Descripcion = "Listar Clientes"
    End Sub

    ''' Construye una instancia de la opción vacía.
    ''' </summary>
    Friend Sub New()
        Me.New(0)
    End Sub

    ''' <summary>
    ''' Ejecuta la acción asociada a la opción.
    ''' </summary>
    Friend Overrides Sub EjecutarAccion()
        Try
            Dim Catalogo As CatalogoUsuarios = New CatalogoUsuarios()
            Dim Usuarios As List(Of Usuario) = Catalogo.ObtenerUsuarios()

            Console.WriteLine("Listado de Usuarios")
            Console.WriteLine("--------------------" + Chr(13))
            Console.WriteLine("DNI".PadRight(7) + Chr(7) + "Nombre".PadRight(30) + Chr(7) + "Apellido")
            For Each Usua As Usuario In Usuarios
                Console.WriteLine(Usua.Dni.ToString().PadRight(7) + Chr(7) + Usua.Nombre.PadRight(30) + Chr(7) + Usua.Apellido.PadRight(30))
            Next
            Console.WriteLine(Chr(13) + Chr(13))
        Catch Ex As ReglasNegocioException
            Console.WriteLine("Error al listar los productos: " + Ex.Message)
        End Try
    End Sub

End Class