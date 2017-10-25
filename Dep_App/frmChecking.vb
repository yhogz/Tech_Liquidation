Public Class frmChecking

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        PictureBox1.Image = My.Resources.Resources.preferences_desktop_notification2 ' Dep_App.My.Resources.Resources.preferences_desktop_notification2
        Label2.Text = "1"
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        PictureBox1.Image = My.Resources.Resources.preferences_desktop_notification 'Dep_App.My.Resources.Resources.preferences_desktop_notification
        Label2.Text = "0"
    End Sub
End Class