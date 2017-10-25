Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying
Imports LSM_Lib.LSM_Lib
Public Class frmLogin


    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim assVer As String = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString()
        Me.Text = Me.Text + assVer
        txtPassword.UseSystemPasswordChar = True
        LoadConnection()
    End Sub

    Dim ctr As Integer = 0
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'MsgBox(Environment.UserDomainName)
        'MsgBox(Environment.UserName)

        Login()
    End Sub

    Sub Login()
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please Insert Correct Username and Password!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Else

            Dim e_pass As String = mf.EncryptData(txtPassword.Text.Trim, mytest)
            Using uow = Lsconn.CreateUnitOfWork()
                Dim yUser As New Tbluser
                Dim yMod As New Tblusersmod
                yUser = uow.Tblusers.Where(Function(m) m.Username = txtUsername.Text And m.Password = e_pass).FirstOrDefault
                If yUser Is Nothing Then
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If (ctr > 1) Then
                        Application.Exit()
                    Else
                        ctr += 1
                        txtUsername.Clear()
                        txtPassword.Clear()
                        txtUsername.Focus()
                        Exit Sub
                    End If
                Else
                    yMod = uow.Tblusersmods.Where(Function(m) m.UserCode = yUser.UserCode).FirstOrDefault
                    If yMod Is Nothing Then
                        MessageBox.Show("Unauthorized user", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        If (ctr > 1) Then
                            Application.Exit()
                        Else
                            ctr += 1
                            txtUsername.Clear()
                            txtPassword.Clear()
                            txtUsername.Focus()
                            Exit Sub
                        End If
                    Else
                        If yMod.Jrf = False Or yMod.Jrf Is Nothing Then
                            MessageBox.Show("Unauthorized user", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            If (ctr > 1) Then
                                Application.Exit()
                            Else
                                ctr += 1
                                txtUsername.Clear()
                                txtPassword.Clear()
                                txtUsername.Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                    Dim frm As New Form1(txtUsername.Text)
                    frm.Show()
                    Me.Close()
                End If
            End Using
        End If

    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOK_Click(sender, e)
        End If
    End Sub
End Class