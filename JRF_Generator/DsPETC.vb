Partial Class DsPETC
End Class

Namespace DsPETCTableAdapters
    
    Partial Public Class TPETCCompanyRecordTableAdapter
        Public Sub New(e As String)
            Me.Connection.ConnectionString = "server=" + e + ";User Id=rdmsviewer;password=v2i0e0w4;Persist Security Info=True;database=RDMSCLEANAIR2007"
        End Sub
    End Class
End Namespace
