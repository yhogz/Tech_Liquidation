Partial Class DsJRF
    Partial Class tbljrfDataTable

        Private Sub tbljrfDataTable_tbljrfRowChanging(sender As Object, e As tbljrfRowChangeEvent) Handles Me.tbljrfRowChanging

        End Sub

    End Class

End Class

Namespace DsJRFTableAdapters
    
    'Partial Public Class tbljrfTableAdapter
    '    Public Sub New(e As String)
    '        Me.Connection.ConnectionString = "server=" + e + ";User Id=rdms_user;password=1r1d2m7s1d1atabase;Persist Security Info=True;database=dbliquidation"
    '    End Sub
    'End Class
End Namespace

Namespace DsJRFTableAdapters

    Partial Public Class tbljrfTableAdapter
        Public Sub New(e As String)
            Me.Connection.ConnectionString = "server=" + e + ";User Id=rdms_user;password=1r1d2m7s1d1atabase;Persist Security Info=True;database=dbliquidation"
        End Sub
    End Class
End Namespace
