Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying
Imports LIQ_Lib.LIQ_Lib

Public Class frmLiquidation
    Private mylcode As String
    Private lsConnYhogz As New LightSpeedContext(Of LightSpeedModel1UnitOfWork)

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Clear_Fields()
        Clear_bLiquidate2()
        Me.Close()
    End Sub


    Public Sub Clear_Fields()
       

        dtpDate.Text = DateTime.Now
        txtDestination.Clear()
        txtTask.Clear()
        ListView1.Items.Clear()
    End Sub
    Dim lst_index As Integer
    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Clear_bLiquidate2()
        For Each item As ListViewItem In ListView1.SelectedItems

            With item
                lst_index = .Index
                cmbType.Text = .SubItems(2).Text
                txtCost.Text = .SubItems(1).Text
                txtDescription.Text = .SubItems(3).Text
                '  MsgBox(.Index)
                ' MsgBox(.SubItems(0).Text)
            End With
        Next
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        'If mylcode = "" Or mylcode = Nothing Then
        '    MessageBox.Show("Please Search or Generate a JRF number first!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If
        If ListView1.Items.Count = 0 Then
            MessageBox.Show("List must have atleast 1 record before saving.", "No Value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            errProv.SetError(ListView1, "Required")
            Exit Sub
        Else
            errProv.SetError(ListView1, String.Empty)
        End If

        Dim b2, b3 As Boolean

        b3 = IsFieldEmpty(txtName)
        b2 = IsFieldEmpty(txtDestination)


        If b2 = True Or b3 = True Then Return

        Dim msgResult As MsgBoxResult = MessageBox.Show("Print Liquidation?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If msgResult = MsgBoxResult.Yes Then
            Try
                Dim listBreakDown As New List(Of structBreakDown)()
                For r = 0 To ListView1.Items.Count - 1
                    Dim tblbrk As New structBreakDown
                    With tblbrk
                        .ItemType = ListView1.Items(r).SubItems(2).Text
                        .ItDescription = ListView1.Items(r).SubItems(3).Text
                        .Amount = Convert.ToDouble(ListView1.Items(r).SubItems(1).Text)
                    End With
                    listBreakDown.Add(tblbrk)
                Next
             
                MessageBox.Show("Liquidation successfully Saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim rpt As New newLiquidation
                rpt.SetDataSource(listBreakDown)
                rpt.SetParameterValue("EmpName", txtName.Text)
                rpt.SetParameterValue("EmpDate", dtpDate.Text)
                rpt.SetParameterValue("EmpDest", txtDestination.Text)
                rpt.SetParameterValue("EmpTask", txtTask.Text)
                frmPrintLiquidation.CrystalReportViewer1.ReportSource = rpt
                frmPrintLiquidation.ShowDialog()
                Clear_Fields()
                Clear_bLiquidate2()
            Catch ex As Exception
                MessageBox.Show(Err.Description)
            End Try
        End If
    End Sub


    Public Sub Clear_bLiquidate()
        txtCost.Clear()
        txtDescription.Clear()
    End Sub

    Public Sub Clear_bLiquidate2()
        txtCost.Clear()
        txtDescription.Clear()
        cmbType.Text = ""
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Dim cost As Decimal
        Try
            cost = Convert.ToDecimal(txtCost.Text.Trim)
        Catch ex As Exception
            MessageBox.Show("Please Insert Correct Cost!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtCost.Focus()
            Exit Sub
        End Try

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


        Try
            With ListView1
                .Items(lst_index).SubItems(1).Text = txtCost.Text
                .Items(lst_index).SubItems(2).Text = cmbType.Text
                .Items(lst_index).SubItems(3).Text = txtDescription.Text
                ListView1.Focus()
                ListView1.Items(lst_index).Selected = True
            End With
            CountTotalCost()
            Clear_bLiquidate2()
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Private Sub btnAddNew_Click(sender As System.Object, e As System.EventArgs) Handles btnAddNew.Click



        Dim cost As Decimal
        Try
            cost = Convert.ToDecimal(txtCost.Text.Trim)
        Catch ex As Exception
            MessageBox.Show("Please Insert Correct Cost!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtCost.Focus()
            Exit Sub
        End Try

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


        'Dim msgResult As MsgBoxResult = MessageBox.Show("Are you sure you want to add this liquidation as new?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'If msgResult = MsgBoxResult.Yes Then
        'Else
        '    Exit Sub
        'End If


        Try
            Dim item As New ListViewItem(0)
            item.SubItems.Add(cost)
            item.SubItems.Add(cmbType.Text)
            item.SubItems.Add(txtDescription.Text)
            item.SubItems.Add(mylcode)
            ListView1.Items.AddRange(New ListViewItem() {item})
            CountTotalCost()
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        Clear_bLiquidate()
    End Sub

    Public Function CountTotalCost()
        Dim cost_ As Decimal
        For i = 0 To ListView1.Items.Count - 1

            cost_ = cost_ + Convert.ToDecimal(ListView1.Items(i).SubItems(1).Text)
        Next
        lbl_cost.Text = cost_
        Return cost_
    End Function


    Dim pendingTo_delete As New List(Of String)


    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            Dim msgResult As MsgBoxResult = MessageBox.Show("Are you sure you want to remove this expense?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If msgResult = MsgBoxResult.Yes Then
                For Each item As ListViewItem In ListView1.SelectedItems
                     
                            ListView1.Items.RemoveAt(item.Index)
                            MessageBox.Show("Removed Successfully!, changes will effect after clicking Save All Updates button", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Next

            End If
            CountTotalCost()
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Private Sub frmLiquidation_Load(sender As Object, e As EventArgs) Handles Me.Load
        'dtpDate.MaxDate = DateTime.Now

        txtName.Text = user_
    End Sub

    'Private Function GenerateJRF(ByVal length As Integer) As String

    '    Const alphabet As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"

    '    Dim result As New System.Text.StringBuilder(length)

    '    Static rnd As New Random(Convert.ToInt32(DateTime.Now.Ticks And Integer.MaxValue))

    '    Dim prevChar As String = String.Empty
    '    Dim nextChar As String
    '    Do While result.Length < length
    '        nextChar = alphabet.Substring(rnd.[Next](0, alphabet.Length), 1)
    '        If nextChar.Equals(prevChar) = False Then
    '            result.Append(nextChar)
    '            prevChar = nextChar
    '        End If
    '    Loop
    '    Return result.ToString
    'End Function

  


    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        If dtpDate.Value.Date > Today Then
            dtpDate.Value = Today
        End If
    End Sub

    Private Sub txtTask_TextChanged(sender As Object, e As EventArgs) Handles txtTask.TextChanged
        lblTaskCharCount.Text = (220 - txtTask.TextLength).ToString()
    End Sub

    Private Sub lblTaskCharCount_TextChanged(sender As Object, e As EventArgs) Handles lblTaskCharCount.TextChanged
        If CInt(lblTaskCharCount.Text) < 11 Then
            lblTaskCharCount.ForeColor = Color.Red
        Else
            lblTaskCharCount.ForeColor = Color.Black
        End If

    End Sub
End Class