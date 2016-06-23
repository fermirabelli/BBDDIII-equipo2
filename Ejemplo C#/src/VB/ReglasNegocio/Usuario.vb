''' <summary>
''' Representa un producto genérico.
''' </summary>
Public Class Usuario
    Private _Dni As Integer
    Private _Nombre As String
    Private _Apellido As String

    ''' <summary>
    ''' Construye una instancia del producto con sus datos completos.
    ''' </summary>
    ''' <param name="dni">El código del producto.</param>
    ''' <param name="nombre">La descripción del producto.</param>
    ''' <param name="apellido">El precio del producto.</param>
    Public Sub New(ByVal Dni As Integer, ByVal Nombre As String, ByVal Apellido As String)
        Me.Dni = Dni
        _Nombre = Nombre
        _Apellido = Apellido

    End Sub

    ''' <summary>
    '''El ID
    ''' </summary>
    ''' <exception cref="ArgumentException">Si el parámetro es inválido.</exception>
    Public Property Dni() As Double
        Get
            Return Me._Dni
        End Get
        Private Set(ByVal Value As Double)
            If Value < 0.0F Then
                Throw New ArgumentException("El DNI es invalido")
            End If
            Me._Dni = Value
        End Set
    End Property

    ''' <summary>
    '''El nombre.
    ''' </summary>
    ''' <exception cref="ArgumentException">Si el parámetro es inválido.</exception>
    Public Property Nombre() As String
        Get
            Return Me._Nombre
        End Get
        Private Set(ByVal Value As String)
            If Value.Equals(String.Empty) Then
                Throw New ArgumentException("La descripción es inválida.")
            End If
            Me._Nombre = Value
        End Set
    End Property


    ''' <summary>
    '''El apellido.
    ''' </summary>
    ''' <exception cref="ArgumentException">Si el parámetro es inválido.</exception>
    Public Property Apellido() As String
        Get
            Return Me._Apellido
        End Get
        Private Set(ByVal Value As String)
            If Value.Equals(String.Empty) Then
                Throw New ArgumentException("La descripción es inválida.")
            End If
            Me._Apellido = Value
        End Set
    End Property



End Class


