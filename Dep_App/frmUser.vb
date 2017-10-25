Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying
Imports LIQ_Lib.LIQ_Lib

Public Class frmUser

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        If user_type = "Admin" Or user_type = "Admin-TECH" Then
        Else
            TabControl1.Controls.Remove(TabControl1.TabPages("TabPage1"))
            cmbU_Type.Enabled = False
            GroupBox1.Visible = False
            LoadUser()






        End If


    End Sub

    Public Sub LoadUser()
        Dim ds As New DataSet1.tblusersDataTable
        Dim da As New DataSet1TableAdapters.tblusersTableAdapter
        da.Connection.ConnectionString = mySQLConn
        da.Fill(ds, username, pass)

        If ds.Count > 0 Then

            With ds.Rows(0)
                txtU_Name.Text = .Item("name").ToString
                cmbU_Type.Text = .Item("type").ToString
                txtU_Username.Text = .Item("username").ToString
                ' txtU_CurrPassword.Text = .Item("password").ToString

            End With


        End If


    End Sub

    Private Sub btnU_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnU_Update.Click

        Panel3.Enabled = True
        btnU_Save.Enabled = True
        lblU_Save.Enabled = True
        txtU_CurrPassword.Focus()
    End Sub

    Private Sub btnU_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnU_Save.Click

        If txtU_Name.Text = "" Then : ErrorProvider1.SetError(txtU_Name, "Please Insert Update Name") : Exit Sub : Else : ErrorProvider1.Clear() : End If
        If txtU_Username.Text = "" Then : ErrorProvider1.SetError(txtU_Username, "Please Insert Updated Username") : Exit Sub : Else : ErrorProvider1.Clear() : End If
        If txtU_CurrPassword.Text = "" Then : ErrorProvider1.SetError(txtU_CurrPassword, "Please Insert your current Password") : Exit Sub : Else : ErrorProvider1.Clear() : End If
        If txtU_NPassword.Text = "" Then : ErrorProvider1.SetError(txtU_NPassword, "Please Insert your New Password") : Exit Sub : Else : ErrorProvider1.Clear() : End If
        If txtU_ConPassword.Text = "" Then : ErrorProvider1.SetError(txtU_ConPassword, "Please Insert your New Password for confrmation") : Exit Sub : Else : ErrorProvider1.Clear() : End If

        Try

            If mf.EncryptData(txtU_CurrPassword.Text, mytest) = pass Then
            Else

                MessageBox.Show("Invalid Password!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtU_CurrPassword.Clear()
                txtU_CurrPassword.Focus()

                Exit Sub
            End If


            If txtU_NPassword.Text.Trim = txtU_ConPassword.Text.Trim Then
            Else
                MessageBox.Show("Password not match!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtU_NPassword.Clear()
                txtU_ConPassword.Clear()
                txtU_NPassword.Focus()

                Exit Sub
            End If

            Update_User(user_id, txtU_Name.Text.Trim, txtU_Username.Text.Trim, txtU_ConPassword.Text, cmbU_Type.Text, "1")
            Panel3.Enabled = False
            btnU_Save.Enabled = False
            lblU_Save.Enabled = False
            ClearFields()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub



    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click
        txtU_CurrPassword.Focus()
    End Sub

    Private Sub btnU_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnU_Clear.Click
        ClearFields()
    End Sub

    Public Sub ClearFields()
        txtU_CurrPassword.Clear()
        txtU_NPassword.Clear()
        txtU_ConPassword.Clear()
    End Sub


    Private Sub btnU_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnU_Search.Click
        Dim ds As New DataSet1.Search_userDataTable
        Dim da As New DataSet1TableAdapters.Search_userTableAdapter
        da.Connection.ConnectionString = mySQLConn
        da.Fill(ds, txtSearch.Text.Trim)

        If ds.Count > 0 Then

            txtU_Name.Text = ds.Rows(0).Item("name").ToString
            cmbU_Type.Text = ds.Rows(0).Item("type").ToString
            txtU_Username.Text = ds.Rows(0).Item("username").ToString

        Else
            MessageBox.Show("No Record Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSearch.Clear()
        End If


    End Sub


    Private Sub btnA_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnA_Save.Click

        If txtA_Name.Text = "" Then
            ErrorProvider1.SetError(txtA_Name, "Please Insert Name")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If

        If cmbA_Type.Text = "" Then
            ErrorProvider1.SetError(cmbA_Type, "Please Select Type")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If

        If txtA_username.Text = "" Then
            ErrorProvider1.SetError(txtA_username, "Please Insert Username")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If

        If txtA_Pass.Text = "" Then
            ErrorProvider1.SetError(txtA_Pass, "Please Insert Password")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If

        If txtA_confirmpass.Text = "" Then
            ErrorProvider1.SetError(txtA_confirmpass, "Please Insert Password for confirmation")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If

        If txtA_Pass.Text = txtA_confirmpass.Text Then
        Else
            MessageBox.Show("Password not match!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtA_confirmpass.Clear()
            txtA_Pass.Clear()
            Exit Sub
        End If


        LoadConnection()
        Try

            Using UnitOfWork = Lsconn.CreateUnitOfWork
                Dim tbl As New Tbluser

                With tbl
                    .Name = txtA_Name.Text.Trim
                    .Type = cmbA_Type.Text.Trim
                    .Username = txtA_username.Text
                    .Password = mf.EncryptData(txtA_Pass.Text, mytest)
                    .DateCreated = Date.Now
                    .Active = "1"
                    .UserCode = GetRandomString(11)
                End With

                UnitOfWork.Add(tbl)
                UnitOfWork.SaveChanges()
                MessageBox.Show("New User Successfully Saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields_Add()

            End Using

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Public Sub ClearFields_Add()
        txtA_Name.Clear()
        cmbA_Type.Text = ""
        txtA_username.Clear()
        txtA_Pass.Clear()
        txtA_confirmpass.Clear()
        Panel2.Enabled = False
    End Sub


    Private Sub btnA_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnA_Add.Click
        Panel2.Enabled = True
    End Sub

    Private Sub btnClear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearFields_Add()
    End Sub

    Private Sub cmbA_Type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbA_Type.SelectedIndexChanged

    End Sub
End Class