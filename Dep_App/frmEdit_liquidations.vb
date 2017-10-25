Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying
Imports LIQ_Lib.LIQ_Lib

Public Class frmEdit_liquidations
    Private mylcode As String
    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            LoadConnection()
            Clear_Fields()
            Clear_bLiquidate2()
            Using UnitOfWork = Lsconn.CreateUnitOfWork

                Dim tbl As New Tblliquidation
                Dim sql As New Query
                sql.QueryExpression = Entity.Attribute("JrfNumber") = txtJRFNumber.Text.Trim And Entity.Attribute("Released") = 0

                Dim listLSM As IList(Of Tblliquidation) = UnitOfWork.Find(Of Tblliquidation)(sql)

                If listLSM.Count > 0 Then
                    With listLSM(0)
                        cmbTech.Text = .Name
                        dtpDate.Text = .DDate
                        txtDestination.Text = .Destination
                        cmbPETC.Text = .PetcName
                        txtTask.Text = .Task
                        mylcode = .Lcode
                        Get_Liquidation(.Lcode)
                    End With
                Else
                    ListView1.Items.Clear()
                    MessageBox.Show("No Record Found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Clear_Fields()
        Clear_bLiquidate2()
        Me.Close()
    End Sub


    Public Sub Get_Liquidation(code As String)

        Try
            LoadConnection()
            ListView1.Items.Clear()
            Using UnitOfWork = Lsconn.CreateUnitOfWork
                Dim tbl As New Tblbreakdown
                Dim sql As New Query
                sql.QueryExpression = Entity.Attribute("Lcode") = code And Entity.Attribute("ViewOn") = 1

                Dim listLSM As IList(Of Tblbreakdown) = UnitOfWork.Find(Of Tblbreakdown)(sql)


                If listLSM.Count > 0 Then
                    For i = 0 To listLSM.Count - 1

                        With listLSM(i)
                            Dim item As New ListViewItem(.Id)
                            item.SubItems.Add(.Cost)
                            item.SubItems.Add(.Ltype)
                            item.SubItems.Add(.Description)
                            item.SubItems.Add(.Lcode)
                            ListView1.Items.AddRange(New ListViewItem() {item})
                        End With
                    Next
                    CountTotalCost()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Public Sub Clear_Fields()
        mylcode = ""
        cmbTech.Clear()
        dtpDate.Text = DateTime.Now
        txtDestination.Clear()
        cmbPETC.Clear()
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

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If mylcode = "" Or mylcode = Nothing Then
            MessageBox.Show("Please Search the JRF number first!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        Dim msgResult As MsgBoxResult = MessageBox.Show("Are you sure you want to save all updates?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If msgResult = MsgBoxResult.Yes Then
            Try
                For ilist = 0 To ListView1.Items.Count - 1

                    Using UnitOfWork = Lsconn.CreateUnitOfWork

                        Dim tbl As New Tblbreakdown
                        Dim sql As New Query
                        sql.QueryExpression = Entity.Attribute("Id") = ListView1.Items(ilist).SubItems(0).Text

                        Dim listLSM As IList(Of Tblbreakdown) = UnitOfWork.Find(Of Tblbreakdown)(sql)

                        If listLSM.Count > 0 Then
                            For i = 0 To listLSM.Count - 1

                                tbl = listLSM(i)

                                With tbl
                                    .Cost = ListView1.Items(ilist).SubItems(1).Text
                                    .Ltype = ListView1.Items(ilist).SubItems(2).Text
                                    .Description = ListView1.Items(ilist).SubItems(3).Text
                                    .DateUpdated = DateTime.Now
                                    .UpdatedBy = username
                                End With

                                If tbl.Errors.Count = 0 Then
                                    UnitOfWork.Update(sql, tbl)
                                    UnitOfWork.SaveChanges()
                                    Update_Cost(listLSM(0).Lcode, Convert.ToDecimal(lbl_cost.Text))
                                End If

                            Next

                        Else

                            With tbl
                                .Cost = ListView1.Items(ilist).SubItems(1).Text
                                .Ltype = ListView1.Items(ilist).SubItems(2).Text
                                .Description = ListView1.Items(ilist).SubItems(3).Text
                                .Lcode = ListView1.Items(ilist).SubItems(4).Text
                                .EncodedBy = username
                                .DateEncoded = DateTime.Now
                                .ViewOn = 1
                            End With

                            If tbl.Errors.Count = 0 Then
                                UnitOfWork.Add(tbl)
                                UnitOfWork.SaveChanges()
                            End If

                        End If
                    End Using
                Next

                Delete_expense(pendingTo_delete)
                Clear_Fields()
                Clear_bLiquidate2()
                MessageBox.Show("Liquidation successfully Updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

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


        Dim msgResult As MsgBoxResult = MessageBox.Show("Are you sure you want to add this liquidation as new?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If msgResult = MsgBoxResult.Yes Then
        Else
            Exit Sub
        End If


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

                    Using UnitOfWork = Lsconn.CreateUnitOfWork

                        Dim tbl As New Tblbreakdown
                        Dim sql As New Query
                        sql.QueryExpression = Entity.Attribute("Id") = item.SubItems(0).Text

                        Dim listLSm As IList(Of Tblbreakdown) = UnitOfWork.Find(Of Tblbreakdown)(sql)
                        If listLSm.Count > 0 Then
                            pendingTo_delete.Add(item.SubItems(0).Text)
                            ListView1.Items.RemoveAt(item.Index)
                            MessageBox.Show("Removed Successfully!, changes will effect after clicking Save All Updates button", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            ListView1.Items.RemoveAt(item.Index)
                            MessageBox.Show("Removed Successfully!, changes will effect after clicking Save All Updates button", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                Next

            End If
            CountTotalCost()
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Public Sub Update_Cost(lcode As String, cost As Decimal)
        LoadConnection()
        Try
            Using UnitOfWork = Lsconn.CreateUnitOfWork

                Dim tbl As New Tblliquidation
                Dim sql As New Query
                sql.QueryExpression = Entity.Attribute("Lcode") = lcode
                Dim listLSM As IList(Of Tblliquidation) = UnitOfWork.Find(Of Tblliquidation)(sql)

                If listLSM.Count > 0 Then
                    For i = 0 To listLSM.Count - 1
                        tbl = listLSM(i)

                        With tbl
                            .LTotal = cost
                        End With

                        If tbl.Errors.Count = 0 Then
                            UnitOfWork.Update(sql, tbl)
                            UnitOfWork.SaveChanges()
                        End If

                    Next
                End If


            End Using
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub


    Public Sub Delete_expense(plist As IList(Of String))
        LoadConnection()
        If plist.Count > 0 Then
            For i = 0 To plist.Count - 1
                Using UnitOfWork = Lsconn.CreateUnitOfWork

                    Dim tbl As New Tblbreakdown
                    Dim sql As New Query
                    sql.QueryExpression = Entity.Attribute("Id") = plist.Item(i)

                    Dim listLSm As IList(Of Tblbreakdown) = UnitOfWork.Find(Of Tblbreakdown)(sql)
                    If listLSm.Count > 0 Then

                        tbl = listLSm(0)

                        With tbl
                            .ViewOn = 0
                            .UpdatedBy = username
                            .DateUpdated = DateTime.Now
                        End With

                        UnitOfWork.Update(sql, tbl)
                        UnitOfWork.SaveChanges()
                    Else
                    End If
                End Using
            Next
        End If
    End Sub

End Class