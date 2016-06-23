Imports DCE05.Ejemplos.EstrellaUno.AccesoDatos
Imports System.Data.Common

''' <summary>
''' Representa el catálogo de productos del sistema.
''' </summary>
Public Class CatalogoUsuarios

    ''' <summary>
    ''' Obtiene la lista de productos del sistema.
    ''' </summary>
    ''' <returns>La lista de productos.</returns>
    ''' <exception cref="ReglasNegocioException">Si ocurre un error de negocio.</exception>
    Public Function ObtenerUsuarios() As List(Of Usuario)
        Dim Usuarios As List(Of Usuario) = New List(Of Usuario)()
        Try
            Dim Sql As String = "SELECT Dni, Nombre, Apellido FROM Usuarios"
            Dim Db As BaseDatos = New BaseDatos()
            Db.Conectar()
            Db.CrearComando(Sql)
            Dim Datos As DbDataReader = Db.EjecutarConsulta()

            Dim u As Usuario = Nothing
            While Datos.Read()
                Try
                    u = New Usuario(Datos.GetInt32(0), Datos.GetString(1), Datos.GetString(2))
                    Usuarios.Add(u)
                Catch ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", ex)
                Catch ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", ex)
                End Try
            End While
            Datos.Close()
            Db.Desconectar()
        Catch ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener los productos.")
        Catch ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error a obtener los productos.")
        End Try
        Return Usuarios
    End Function

    ''' <summary>
    ''' Obtiene un usuario segun su DNI
    ''' </summary>
    ''' <param name="Dni">El código del producto.</param>
    ''' <returns>El producto encontrado.</returns>
    ''' <exception cref="ReglasNegocioException">Si ocurre un error de negocio.</exception>
    Public Function ObtenerUsuario(ByVal Dni As Integer) As Usuario
        Dim MiUsuario As Usuario = Nothing
        Try
            If (Dni <= 0) Then
                Throw New ReglasNegocioException("El código es inválido.")
            End If

            Dim Sql As String = "SELECT Dni, Nombre, Apellido FROM Productos WHERE Dni=@dni"
            Dim Db As BaseDatos = New BaseDatos()
            Db.Conectar()
            Db.CrearComando(Sql)
            Db.AsignarParametroEntero("@dni", Dni)
            Dim Datos As DbDataReader = Db.EjecutarConsulta()

            While Datos.Read()
                Try
                    MiUsuario = New Usuario(Datos.GetInt32(0), Datos.GetString(1), Datos.GetString(2))
                Catch Ex As InvalidCastException
                    Throw New ReglasNegocioException("Los tipos no coinciden.", Ex)
                Catch Ex As DataException
                    Throw New ReglasNegocioException("Error de ADO.NET.", Ex)
                End Try
            End While

            Datos.Close()
            Db.Desconectar()
        Catch Ex As BaseDatosException
            Throw New ReglasNegocioException("Error al acceder a la base de datos para obtener los usuarios.")
        Catch Ex As ReglasNegocioException
            Throw New ReglasNegocioException("Error a obtener los productos. " + Ex.Message)
        End Try
        Return MiUsuario
    End Function
End Class
