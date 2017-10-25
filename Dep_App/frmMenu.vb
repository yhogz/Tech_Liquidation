Public Class frmMenu


    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click

        Dim msgResult As MsgBoxResult = MessageBox.Show("Are you sure you want to Close this Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)


        If msgResult = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnDeploy_Click(sender As System.Object, e As System.EventArgs) Handles btnDeploy.Click
        Dim frm As New frmMain
        frm.ShowDialog()
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

 

    Private Sub frmMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblVersion.Text = lblVersion.Text + Application.ProductVersion.ToString()

        With Form1
            .Owner = Me
            .Show()

        End With
    End Sub

    Private Sub btnAddUser_Click(sender As System.Object, e As System.EventArgs) Handles btnAddUser.Click

        frmUser.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        frmReports.ShowDialog()

        'Dim login As New frmReports
        'With login
        '    x = (rect.Height / 2) - (.Height / 2)
        '    y = (rect.Width / 2) - (.Width / 2)
        '    .Owner = Me
        '    .Top = x
        '    .Left = y
        '    .Show()
        'End With
    End Sub


    Public rect As Rectangle = Screen.PrimaryScreen.WorkingArea
    Dim x As Integer = 0
    Dim y As Integer = 0

    Private Sub mainMenu_Load(sender As Object, e As System.EventArgs) Handles Me.Load
     
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblTime.Text = DateTime.Now
    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        frmUser.ShowDialog()
    End Sub


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Panel2.Visible = False
    End Sub

    Private Sub btnRelease_Click(sender As System.Object, e As System.EventArgs) Handles btnRelease.Click

        Try
            frmReleased.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        Try
            If (user_type.ToUpper = "TECH") Then
                frmEdit_liquidations.ShowDialog()
            Else
                frmLiquidation.ShowDialog()
            End If
            'frmEdit_liquidations.ShowDialog()
            'frmLiquidation.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try
            techActivityForm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Function IsitEmpty(str As String) As Boolean

    End Function

    Private Sub lblVersion_Click(sender As Object, e As EventArgs) Handles lblVersion.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmMenu_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
    End Sub
End Class