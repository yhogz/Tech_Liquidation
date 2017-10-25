Imports Mindscape.LightSpeed

Module Module1
    Public Function GetRandomString(ByVal length As Integer) As String

        Const alphabet As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"

        Dim result As New System.Text.StringBuilder(length)

        Static rnd As New Random(Convert.ToInt32(DateTime.Now.Ticks And Integer.MaxValue))

        Dim prevChar As String = String.Empty
        Dim nextChar As String
        Do While result.Length < length
            nextChar = alphabet.Substring(rnd.[Next](0, alphabet.Length), 1)
            If nextChar.Equals(prevChar) = False Then
                result.Append(nextChar)
                prevChar = nextChar
            End If
        Loop
        Return result.ToString
    End Function


    Public Conn As String = "server=" + My.Settings.ServerName + ";User Id=rdms_user;password=1r1d2m7s1d1atabase;Persist Security Info=True;database=dbliquidation"
    Public Lsconn As New LightSpeedContext(Of LSM_Lib.LSM_Lib.LightSpeedModel1UnitOfWork)
    Public mytest As String = "Rdms_DEV2013"
    Public mf As New MyFunction.MyFunction
    Public sysUsername = ""

    Public Sub LoadConnection()
        'Lsconn.ConnectionString = "server=" + My.Settings.ServerName + ";User Id=rdms_user;password=1r1d2m7s1d1atabase;Persist Security Info=True;database=dbliquidation"
        Lsconn.ConnectionString = Conn
        Lsconn.DataProvider = DataProvider.MySql5
        Lsconn.IdentityMethod = IdentityMethod.IdentityColumn
    End Sub



End Module
