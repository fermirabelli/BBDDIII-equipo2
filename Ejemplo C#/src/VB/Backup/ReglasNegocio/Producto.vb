''' <summary>
''' Representa un producto gen�rico.
''' </summary>
Public Class Producto
    Private _Codigo As Integer
    Private _Descripcion As String
    Private _Precio As Double

    ''' <summary>
    ''' Construye una instancia del producto con sus datos completos.
    ''' </summary>
    ''' <param name="codigo">El c�digo del producto.</param>
    ''' <param name="descripcion">La descripci�n del producto.</param>
    ''' <param name="precio">El precio del producto.</param>
    Public Sub New(ByVal Codigo As Integer, ByVal Descripcion As String, ByVal Precio As Double)
        Me.Codigo = Codigo
        Me.Precio = Precio
        _Descripcion = Descripcion
    End Sub

    ''' <summary>
    ''' El precio del producto.
    ''' </summary>
    ''' <exception cref="ArgumentException">Si el par�metro es inv�lido.</exception>
    Public Property Precio() As Double
        Get
            Return Me._Precio
        End Get
        Private Set(ByVal Value As Double)
            If Value < 0.0F Then
                Throw New ArgumentException("El precio es inv�lido.")
            End If
            Me._Precio = Value
        End Set
    End Property

    ''' <summary>
    ''' El codigo del producto.
    ''' </summary>
    ''' <exception cref="ArgumentException">Si el par�metro es inv�lido.</exception>
    Public Property Codigo() As Integer
        Get
            Return Me._Codigo
        End Get
        Private Set(ByVal Value As Integer)
            If Value <= 0 Then
                Throw New ArgumentException("El c�digo es inv�lido.")
            End If
            Me._Codigo = Value
        End Set
    End Property

    ''' <summary>
    ''' La descripcion del producto.
    ''' </summary>
    ''' <exception cref="ArgumentException">Si el par�metro es inv�lido.</exception>
    Public Property Descripcion() As String
        Get
            Return Me._Descripcion
        End Get
        Private Set(ByVal Value As String)
            If Value.Equals(String.Empty) Then
                Throw New ArgumentException("La descripci�n es inv�lida.")
            End If
            Me._Descripcion = Value
        End Set
    End Property

End Class
