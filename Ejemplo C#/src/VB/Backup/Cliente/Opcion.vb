''' <summary>
''' Representa una opci�n gen�rica.
''' Todas las opciones del sistema deben heredar de esta opci�n.
''' </summary>
Public MustInherit Class Opcion

    Protected _Codigo As Integer = 0
    Protected _Descripcion As String

    ''' <summary>
    ''' El c�digo de la opci�n.
    ''' </summary>
    Protected Friend Property Codigo() As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal Value As Integer)
            _Codigo = Value
        End Set
    End Property

    ''' <summary>
    ''' La descripci�n de la opci�n.
    ''' </summary>
    Protected Friend Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Protected Set(ByVal Value As String)
            _Descripcion = Value
        End Set
    End Property

    ''' <summary>
    ''' Ejecuta la acci�n asociada a la opci�n.
    ''' </summary>
    Friend MustOverride Sub EjecutarAccion()

End Class
