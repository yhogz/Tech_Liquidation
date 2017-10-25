Public Class generationForm

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Hide()
        taskForm.Show()

    End Sub
    Public Function GenerateRandomString(ByRef iLength As Integer) As String
        Dim rdm As New Random()
        Dim allowChrs() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
        Dim sResult As String = ""

        For i As Integer = 0 To iLength - 1
            sResult += allowChrs(rdm.Next(0, allowChrs.Length))
        Next

        Return sResult
    End Function

    Public Function generateJrf() As String
        Dim int As New Integer
        'For i As Integer = 0 To 2
        '    i -= 1
        'Next

        Do
            int = int + 1

            While (int < 5)
                MsgBox(int)

            End While
        Loop

        Return int + 1


    End Function

    

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click

        'Dim result As String = GenerateRandomString(20).ToString
        'txtGenerate.Text = result
        'Dim int As Integer
        'While (int < 5)
        '    int = int + 1
        '    txtGenerate.Text = int
        '    MsgBox(int)
        'End While




    End Sub

    Private Sub generationForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class