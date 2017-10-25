Public Class structBreakDown
    
    Private _itemType As String
    Public Property ItemType() As String
        Get
            Return _itemType
        End Get
        Set(ByVal value As String)
            _itemType = value
        End Set
    End Property

    Private _desc As String
    Public Property ItDescription() As String
        Get
            Return _desc
        End Get
        Set(ByVal value As String)
            _desc = value
        End Set
    End Property

    Private _amount As String
    Public Property Amount() As Double
        Get
            Return _amount
        End Get
        Set(ByVal value As Double)
            _amount = value
        End Set
    End Property


End Class
