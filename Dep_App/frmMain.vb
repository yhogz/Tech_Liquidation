
Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying
Imports LIQ_Lib.LIQ_Lib

Public Class frmMain

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub



    Private Sub btnMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBreakdown.ShowDialog()
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim cost As Decimal
        Try
            cost = Convert.ToDecimal(txtCost.Text.Trim)
        Catch ex As Exception
            MessageBox.Show("Please Insert Correct Cost!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtCost.Focus()
            Exit Sub
        End Try

        Try


            If cmbType.Text = "" Then
                ErrorProvider1.SetError(cmbType, "Please Select Type of Luquidation!")
                Exit Sub
            Else
                ErrorProvider1.Clear()
            End If

            If cmbType.Text = "Meal" Then

                ErrorProvider1.Clear()
            ElseIf cmbType IsNot "Meal" And txtDescription.Text = "" Then
                ErrorProvider1.SetError(txtDescription, "Please Input Liquidation Description!")
                Exit Sub
            End If


            Dim type As String = cmbType.Text.Trim
            Dim description As String = txtDescription.Text.Trim

            Dim item As New ListViewItem(cost)
            item.SubItems.Add(type)
            item.SubItems.Add(description)

            ListView1.Items.AddRange(New ListViewItem() {item})
            CountTotalCost()
            txtCost.Focus()
            Clear_BreakdownFields()
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub

    Public Sub CountTotalCost()
        Dim cost_ As Decimal
        For i = 0 To ListView1.Items.Count - 1

            cost_ = cost_ + Convert.ToDecimal(ListView1.Items(i).SubItems(0).Text)
        Next
        lbl_cost.Text = cost_

    End Sub
    Public Sub Clear_BreakdownFields()
        txtCost.Clear()
        txtDescription.Clear()
        '    cmbType.Text = ""
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        For Each item As ListViewItem In ListView1.SelectedItems
            ListView1.Items.RemoveAt(item.Index)
        Next
        CountTotalCost()
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Cursor.Current = Cursors.WaitCursor

        If Lid = "" Or Lid = Nothing Then
            MessageBox.Show("Please Search first the JRF Number!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End If


        If cmbTech.Text = "" Then
            ErrorProvider1.SetError(cmbTech, "Please Select Technician Name!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If

        If txtDestination.Text = "" Then
            ErrorProvider1.SetError(txtDestination, "Please Insert Destination!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If

        If cmbPETC.Text = "" Then
            ErrorProvider1.SetError(cmbPETC, "Please Select PETC Name!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If

        If txtTask.Text = "" Then
            ErrorProvider1.SetError(txtTask, "Please Insert Task!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If

        If txtSolution.Text = "" Then
            ErrorProvider1.SetError(txtSolution, "Please Insert Solution!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If

        If txtRemarks.Text = "" Then
            ErrorProvider1.SetError(txtRemarks, "Please Insert Remarks!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If

        If chkLiquidation.Checked = True Then
            If ListView1.Items.Count = 0 Then
                MessageBox.Show("Please Input your liquidation!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If





        Dim msg As MsgBoxResult = MessageBox.Show("Are you sure you want to save this Data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If msg = MsgBoxResult.Yes Then

            Try
                Dim count As Integer = ListView1.Items.Count
                Dim cost As Decimal
                Dim type As String
                Dim description As String

                Dim mycost As Decimal
                Dim lstat As Integer
                If chkLiquidation.Checked = True Then
                    For i = 0 To count - 1
                        cost = ListView1.Items(i).SubItems(0).Text
                        type = ListView1.Items(i).SubItems(1).Text
                        description = ListView1.Items(i).SubItems(2).Text
                        Save_Breakdown(cost, type, description)
                    Next
                    mycost = Convert.ToDecimal(lbl_cost.Text)
                    lstat = 1
                Else

                    mycost = 0.0
                    lstat = 0
                    Save_Breakdown(0.0, "NA", "No Liquidation")
                End If

                Update_TotalCost(mycost, txtSolution.Text, txtRemarks.Text, lstat)

                MessageBox.Show("Liquidation Successfully Saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Save_Liquidation(cmbTech.Text.Trim, dtpDate.Text, txtDestination.Text.Trim, cmbPETC.Text.Trim, txtTask.Text, Convert.ToDecimal(lbl_cost.Text), user_)
                Clear_LiquidationFields()
            Catch ex As Exception
                MessageBox.Show(Err.Description, "Saving Process", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  cmbTech.Text = user_

        txtJRFNumber.Text = ""


    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Clear_LiquidationFields()
    End Sub

    Public Sub Clear_LiquidationFields()
        txtJRFNumber.Focus()

        Lid = ""
        txtDestination.Clear()
        cmbPETC.Text = ""
        txtTask.Clear()
        txtCost.Clear()
        cmbType.Text = ""
        txtDescription.Clear()
        ListView1.Items.Clear()
        txtSolution.Clear()
        txtRemarks.Clear()
        ' lbl_JRFnumber.Text = ""
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim ds As New DataSet1.Search_JRFDataTable
        Dim da As New DataSet1TableAdapters.Search_JRFTableAdapter
        da.Connection.ConnectionString = mySQLConn
        da.Fill(ds, txtJRFNumber.Text.Trim)

        If ds.Count > 0 Then

            Dim ds_brk As New DataSet1.CheckBreakDownDataTable
            Dim da_brk As New DataSet1TableAdapters.CheckBreakDownTableAdapter
            da_brk.Connection.ConnectionString = mySQLConn
            da_brk.Fill(ds_brk, ds.Rows(0).Item("lcode").ToString)

            If ds_brk.Count > 0 Then
                MessageBox.Show("This JRF Number was already used!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Clear_LiquidationFields()
            Else

                lbl_jrfnumber.Text = txtJRFNumber.Text
                cmbTech.Text = ds.Rows(0).Item("name").ToString
                dtpDate.Text = ds.Rows(0).Item("d_date").ToString()
                txtDestination.Text = ds.Rows(0).Item("destination").ToString
                cmbPETC.Text = ds.Rows(0).Item("petc_name").ToString
                txtTask.Text = ds.Rows(0).Item("task").ToString
                lcode = ds.Rows(0).Item("lcode").ToString
                Lid = ds.Rows(0).Item("Lid").ToString
                txtSolution.Text = ds.Rows(0).Item("solutions").ToString
                txtJRFNumber.Clear()
                txtSolution.Focus()
            End If


        Else
            MessageBox.Show("No Record Found!", "Liquidation Logger", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick



        'Try
        '    For Each Item As ListViewItem In ListView1.SelectedItems

        '        b_cost = (ListView1.SelectedItems.Item(0).Text)
        '        b_type = (ListView1.SelectedItems.Item(0).SubItems(1).Text)
        '        b_description = (ListView1.SelectedItems.Item(0).SubItems(2).Text)



        '    Next
        '    FrmEdi.ShowDialog()
        'Catch ex As Exception
        '    MessageBox.Show(Err.Description)
        'End Try


    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub txtJRFNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJRFNumber.TextChanged
        Try
            LoadConnection()
            Dim mysource As New AutoCompleteStringCollection
            Dim list As New List(Of String)

            Using UnitOfWork = Lsconn.CreateUnitOfWork
                Dim tbl As New Tblliquidation
                Dim sql As New Query
                sql.Page = Page.Limit(10)
                sql.QueryExpression = Entity.Attribute("JrfNumber").Like(txtJRFNumber.Text + "%") And Entity.Attribute("Released") = "0"
                Dim LSMlist As IList(Of Tblliquidation) = UnitOfWork.Find(Of Tblliquidation)(sql)

                If LSMlist.Count > 0 Then

                    For i = 0 To LSMlist.Count - 1
                        list.Add(LSMlist(i).JrfNumber)
                    Next

                    mysource.AddRange(list.ToArray)
                    txtJRFNumber.AutoCompleteCustomSource = mysource
                    txtJRFNumber.AutoCompleteMode = AutoCompleteMode.Suggest
                    txtJRFNumber.AutoCompleteSource = AutoCompleteSource.CustomSource
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click

    End Sub

  
    Private Sub chkLiquidation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLiquidation.CheckedChanged
        If chkLiquidation.Checked = True Then
            pan_addliquidation.Enabled = True
            ListView1.Enabled = True
        Else
            pan_addliquidation.Enabled = False
            ListView1.Enabled = False
        End If
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class