Public Class structJRF

    Private newPropertyValue As String
    Public Property jrfCol() As String
        Get
            Return newPropertyValue
        End Get
        Set(ByVal value As String)
            newPropertyValue = value
        End Set
    End Property

End Class


