Imports System.Security.Cryptography
Imports System.Text

Public Class Form1


    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        Cursor.Current = Cursors.WaitCursor


        If txtUser.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please Insert Correct Username and Password!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Else

            Dim e_pass As String = mf.EncryptData(txtPassword.Text.Trim, mytest)
            'Dim e_pass As String = "UsUyRiQV+Xc="

            Dim ds As New DataSet1.tblusersDataTable
            Dim da As New DataSet1TableAdapters.tblusersTableAdapter
            da.Connection.ConnectionString = mySQLConn
            da.Fill(ds, txtUser.Text, e_pass)

            If ds.Count > 0 Then

                If ds.Rows(0).Item("type").ToString = "TECH" Then
                    '  frmMenu.pan_reports.Visible = False
                    user_ = ds.Rows(0).Item("name").ToString
                    user_type = ds.Rows(0).Item("type").ToString
                    user_id = ds.Rows(0).Item("Uid").ToString
                    username = ds.Rows(0).Item("username").ToString
                    pass = ds.Rows(0).Item("password").ToString

                    frmMenu.pan_tech.Visible = True
                    frmMenu.pan_user.Visible = True
                    frmMenu.pan_Edit.Visible = True
                    frmMenu.pan_activity.Visible = True
                    OpenMainForm()

                ElseIf ds.Rows(0).Item("type").ToString.ToUpper = "USER" Then
                    user_ = ds.Rows(0).Item("name").ToString
                    user_type = ds.Rows(0).Item("type").ToString
                    user_id = ds.Rows(0).Item("Uid").ToString
                    username = ds.Rows(0).Item("username").ToString
                    pass = ds.Rows(0).Item("password").ToString

                    frmMenu.pan_user.Visible = True
                    frmMenu.pan_Edit.Visible = True

                    OpenMainForm()

                ElseIf ds.Rows(0).Item("type").ToString = "MK" Then

                ElseIf ds.Rows(0).Item("type").ToString = "SV" Then

                ElseIf ds.Rows(0).Item("type").ToString = "MC" Then

                    user_ = ds.Rows(0).Item("name").ToString
                    user_type = ds.Rows(0).Item("type").ToString
                    user_id = ds.Rows(0).Item("Uid").ToString
                    username = ds.Rows(0).Item("username").ToString
                    pass = ds.Rows(0).Item("password").ToString

                    frmMenu.pan_user.Visible = True
                    frmMenu.pan_release.Visible = True
                    frmMenu.pan_reports.Visible = True

                    OpenMainForm()
                ElseIf ds.Rows(0).Item("type").ToString = "Admin" Then
                    user_ = ds.Rows(0).Item("name").ToString
                    user_type = ds.Rows(0).Item("type").ToString
                    user_id = ds.Rows(0).Item("Uid").ToString
                    username = ds.Rows(0).Item("username").ToString
                    pass = ds.Rows(0).Item("password").ToString


                    frmMenu.pan_tech.Visible = True
                    frmMenu.pan_user.Visible = True
                    frmMenu.pan_Edit.Visible = True
                    frmMenu.pan_activity.Visible = True
                    ' frmMenu.pan_approval.Visible = True
                    'frmMenu.pan_check.Visible = True
                    frmMenu.pan_release.Visible = True
                    frmMenu.pan_reports.Visible = True
                    OpenMainForm()
                ElseIf ds.Rows(0).Item("type").ToString = "Admin-Tech" Then

                    user_ = ds.Rows(0).Item("name").ToString
                    user_type = ds.Rows(0).Item("type").ToString
                    user_id = ds.Rows(0).Item("Uid").ToString
                    username = ds.Rows(0).Item("username").ToString
                    pass = ds.Rows(0).Item("password").ToString

                    frmMenu.pan_tech.Visible = True
                    frmMenu.pan_user.Visible = True
                    ' frmMenu.pan_approval.Visible = True
                    'frmMenu.pan_check.Visible = True
                    '  frmMenu.pan_release.Visible = True
                    frmMenu.pan_reports.Visible = True
                    frmMenu.pan_Edit.Visible = True
                    frmMenu.pan_activity.Visible = True
                    OpenMainForm()

                End If

            Else
                MessageBox.Show("Invalid Username and Password!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtUser.Clear()
                txtPassword.Clear()
            End If
        End If
    End Sub

    Public Sub OpenMainForm()
        frmMenu.Panel1.Visible = True
        frmMenu.Panel2.Visible = True
        frmMenu.lblUser.Text = "User: " + txtUser.Text
        frmMenu.Label4.Text = "Login Time :" + TimeOfDay

        Me.Close()
    End Sub

    Private Function GetMD5HashData(data As String) As String
        'create new instance of md5
        Dim md5__1 As MD5 = MD5.Create()
        'convert the input text to array of bytes
        Dim hashData As Byte() = md5__1.ComputeHash(Encoding.[Default].GetBytes(data))

        'create new instance of StringBuilder to save hashed data
        Dim returnValue As New StringBuilder()

        'loop for each byte and add it to StringBuilder
        'For i As Integer = 0 To hashData.Length - 1
        '    returnValue.Append(hashData(i).ToString())
        'Next`

        ' return hexadecimal string
        '  Return returnValue.ToString
        Return Convert.ToBase64String(hashData).ToString

    End Function

  
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        frmMenu.Close()

        '        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

  
End Class
