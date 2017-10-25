Imports Lightspeed.Lightspeed
Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying

Public Class loginForm
    Public lscontext As New LightSpeedContext

    Public Sub Lightspeed_Connection()
        lscontext.ConnectionString = con
        lscontext.DataProvider = DataProvider.MySql5
        lscontext.IdentityMethod = IdentityMethod.IdentityColumn
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim userType As String

        Cursor.Current = Cursors.WaitCursor
        Lightspeed_Connection()
        Dim tbl As New Lightspeed.Lightspeed.Tbluser
        Dim query As New Query


        Using UnitOfWork = lscontext.CreateUnitOfWork
            query.QueryExpression = Entity.Attribute("username") = txtUsername.Text.Trim And Entity.Attribute("password") = txtPassword.Text.Trim

            Dim list As IList(Of Tbluser) = UnitOfWork.Find(Of Tbluser)(query)
            If list.Count > 0 Then

                'For i = 0 To list.Count - 1
                '    tbl = list(i)
                'Next


                'check if type is MK
                Using UnitOfWorkCheckType = lscontext.CreateUnitOfWork
                    Dim tblUser As New Tbluser
                    Dim queryUser As New Query
                    queryUser.QueryExpression = Entity.Attribute("username") = txtUsername.Text
                    Dim listUser As IList(Of Tbluser) = UnitOfWorkCheckType.Find(Of Tbluser)(queryUser)

                    If listUser.Count > 0 Then
                        For i = 0 To listUser.Count - 1
                            tblUser = listUser(i)
                            userType = tblUser.Type
                            If userType = "MK" Or userType = "Admin" Then
                                Me.Hide()
                                taskForm.Show()
                            Else
                                Exit Sub
                            End If
                        Next
                    End If


                End Using


            Else
                MessageBox.Show("Invalid username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Clear()

            End If



        End Using


    End Sub


    Private Sub loginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnLogin.BackColor = Color.Transparent
    End Sub
End Class
