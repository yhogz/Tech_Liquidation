Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying

Imports LIQ_Lib.LIQ_Lib
Public Class frmReleased

    Private Sub btnReleased_Click(sender As System.Object, e As System.EventArgs) Handles btnReleased.Click
        Cursor.Current = Cursors.WaitCursor
        If Lid_loc = "" Then
            MessageBox.Show("Please Select Liquidation Data First!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Dim msgResult As MsgBoxResult = MessageBox.Show("Are you sure you want to Release this Liguidation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If msgResult = MsgBoxResult.Yes Then
                Dim i As Integer = DataGridView1.CurrentRow.Index
                print_lcode = DataGridView1.Item("lcode", i).Value.ToString

                Dim ddate = CDate(DataGridView1.Item("d_date", i).Value.ToString)
                Dim c_cddate As String = Format(ddate, "mm/dd/yyyy")
                UpdateRelease_Status()

                Load_Report(print_lcode, DataGridView1.Item("name", i).Value.ToString, ddate)
                Clear()
                LoadData()



            End If

        End If
    End Sub

   

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        CountNotif()
    End Sub

    Public Sub CountNotif()

        Dim ds As New DataSet1.CountForReleaseDataTable
        Dim da As New DataSet1TableAdapters.CountForReleaseTableAdapter
        da.Connection.ConnectionString = mySQLConn

        Dim df As String = Format(Date.Now, "yyyy-MM-dd")
        Dim dt As String = Format(Date.Now, "yyyy-MM-dd")


        da.Fill(ds)

        If ds.Count > 0 Then

            If ds.Rows(0).Item(0).ToString = 0 Then
                PictureBox1.Image = My.Resources.preferences_desktop_notification 'Dep_App.My.Resources.Resources.preferences_desktop_notification
                lbl_count.Text = "0"
            Else
                PictureBox1.Image = My.Resources.preferences_desktop_notification2 ' Dep_App.My.Resources.Resources.preferences_desktop_notification2
                lbl_count.Text = ds.Rows(0).Item(0).ToString
            End If

        End If

    End Sub

    Public Sub CheckBreakDown()

    End Sub




    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Cursor.Current = Cursors.WaitCursor
        LoadData()
      
    End Sub


    Public Sub LoadData()
        Try

            Dim ds As New DataSet1.CheckforReleasedDataTable
            Dim da As New DataSet1TableAdapters.CheckforReleasedTableAdapter
            da.Connection.ConnectionString = mySQLConn
            da.Fill(ds)
            If ds.Count > 0 Then
                DataGridView1.DataSource = ds
            Else
                MessageBox.Show("No Liquidation Pending for Released!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DataGridView1.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub


    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click

        Cursor.Current = Cursors.WaitCursor


        If cmbSearchBy.Text = "JRF Number" Then

            Dim ds As New DataSet1.Search_JRFDataTable
            Dim da As New DataSet1TableAdapters.Search_JRFTableAdapter
            da.Connection.ConnectionString = mySQLConn
            da.Fill(ds, txtJRFNumber.Text.Trim)

            If ds.Count > 0 Then
                If ds.Rows(0).Item("Released").ToString = "1" Then
                    MessageBox.Show("This JRF Number is already Released!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    DataGridView1.DataSource = ds
                End If
            Else
                DataGridView1.DataSource = Nothing
                MessageBox.Show("JRF Not Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        ElseIf cmbSearchBy.Text = "Name" Then


            Dim ds1 As New DataSet1.Search_NameDataTable
            Dim da1 As New DataSet1TableAdapters.Search_NameTableAdapter
            da1.Connection.ConnectionString = mySQLConn
            da1.Fill(ds1, txtJRFNumber.Text + "%", 1, 0)

            If ds1.Count > 0 Then

                DataGridView1.DataSource = ds1
            Else
                DataGridView1.DataSource = Nothing
                MessageBox.Show("Name Not Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        End If



    End Sub

    Dim lcode As String
    Dim Lid_loc As String
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.SelectionChanged

        Clear()
        Dim i As Integer
        Try
            i = DataGridView1.CurrentRow.Index

        Catch ex As Exception

        End Try
       
        Try

            lcode = DataGridView1.Item("lcode", i).Value.ToString
            txtTotal.Text = DataGridView1.Item("l_total", i).Value.ToString
            Lid_loc = DataGridView1.Item("Lid", i).Value.ToString




            Dim ds As New DataSet1.CheckBreakDownDataTable
            Dim da As New DataSet1TableAdapters.CheckBreakDownTableAdapter
            da.Connection.ConnectionString = mySQLConn
            da.Fill(ds, lcode)

            If ds.Count > 0 Then

                For i2 = 0 To ds.Count - 1
                    Dim item As New ListViewItem(ds.Rows(i2).Item("cost").ToString)
                    item.SubItems.Add(ds.Rows(i2).Item("ltype").ToString)
                    item.SubItems.Add(ds.Rows(i2).Item("description").ToString)

                    ListView1.Items.AddRange(New ListViewItem() {item})
                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Public Sub UpdateRelease_Status()
        Try
            LoadConnection()


            Using UnitOfWork = Lsconn.CreateUnitOfWork
                Dim tbl As New Tblliquidation
                Dim sql As New Query
                sql.QueryExpression = Entity.Attribute("Id") = Lid_loc

                Dim List As IList(Of Tblliquidation) = UnitOfWork.Find(Of Tblliquidation)(sql)
                If List.Count > 0 Then

                    For i = 0 To List.Count - 1
                        tbl = List(i)
                    Next

                    With tbl
                        .Released = "1"
                        .ReleasedDate = Date.Now
                    End With
                    If tbl.Errors.Count = 0 Then
                        UnitOfWork.Update(sql, tbl)
                        UnitOfWork.SaveChanges()
                        ' MessageBox.Show("Liquidation Successfully Tag as Released!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Public Sub Clear()
        txtTotal.Clear()
        ListView1.Items.Clear()
        Lid_loc = ""

    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        DataGridView1.DataSource = Nothing
        DataGridView2.DataSource = Nothing
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        Me.Close()
    End Sub

   
    Private Sub btnR_Search_Click(sender As System.Object, e As System.EventArgs) Handles btnR_Search.Click
        Cursor.Current = Cursors.WaitCursor
        Try

            If R_CmbSearchby.Text = "JRF Number" Then
                Dim ds As New DataSet1.Search_JRFDataTable
                Dim da As New DataSet1TableAdapters.Search_JRFTableAdapter
                da.Connection.ConnectionString = mySQLConn
                da.Fill(ds, txtR_JRFNumber.Text.Trim)

                If ds.Count > 0 Then
                    If ds.Rows(0).Item("Released").ToString = "0" Then
                        MessageBox.Show("This JRF Number is not yet Released!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Else
                        DataGridView2.DataSource = ds
                    End If

                Else
                    DataGridView2.DataSource = Nothing
                    MessageBox.Show("JRF Not Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf R_CmbSearchby.Text = "Name" Then

                Dim ds As New DataSet1.Search_NameDataTable
                Dim da As New DataSet1TableAdapters.Search_NameTableAdapter
                da.Connection.ConnectionString = mySQLConn
                da.Fill(ds, txtR_JRFNumber.Text + "%", 1, 1)

                If ds.Count > 0 Then
                    If ds.Rows(0).Item("Released").ToString = "0" Then
                        MessageBox.Show("This JRF Number is not yet Released!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Else
                        DataGridView2.DataSource = ds
                    End If

                Else
                    DataGridView2.DataSource = Nothing
                    MessageBox.Show("Name Not Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If


            End If


        Catch ex As Exception

        End Try
      
    End Sub

    Dim released_lcode As String
    Dim released_name As String
    Dim released_date As String
    Private Sub DataGridView2_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataGridView2.SelectionChanged


        Dim i As Integer

        Try
            i = DataGridView2.CurrentRow.Index
        Catch ex As Exception

        End Try

        ListView2.Items.Clear()
        released_lcode = ""
        released_name = ""
        released_date = ""
        Try

            lcode = DataGridView2.Item("lcode", i).Value.ToString
            txtR_Total.Text = DataGridView2.Item("l_total", i).Value.ToString
            released_lcode = DataGridView2.Item("lcode", i).Value.ToString
            released_name = DataGridView2.Item("name", i).Value.ToString
            released_date = DataGridView2.Item("d_date", i).Value.ToString
            ' Lid_loc = DataGridView2.Item("Lid", i).Value.ToString


            Dim ds As New DataSet1.CheckBreakDownDataTable
            Dim da As New DataSet1TableAdapters.CheckBreakDownTableAdapter
            da.Connection.ConnectionString = mySQLConn
            da.Fill(ds, lcode)

            If ds.Count > 0 Then

                For i2 = 0 To ds.Count - 1
                    Dim item As New ListViewItem(ds.Rows(i2).Item("cost").ToString)
                    item.SubItems.Add(ds.Rows(i2).Item("ltype").ToString)
                    item.SubItems.Add(ds.Rows(i2).Item("description").ToString)

                    ListView2.Items.AddRange(New ListViewItem() {item})
                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
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

                If cmbSearchBy.Text = "JRF Number" Then
                    sql.QueryExpression = Entity.Attribute("JrfNumber").Like(txtJRFNumber.Text + "%") And Entity.Attribute("Checked") = "1" And Entity.Attribute("Released") = "0"
                ElseIf cmbSearchBy.Text = "Name" Then
                    sql.QueryExpression = Entity.Attribute("Name").Like(txtJRFNumber.Text + "%") And Entity.Attribute("Checked") = "1" And Entity.Attribute("Released") = "0"
                Else
                    Exit Sub
                End If

             
                Dim LSMlist As IList(Of Tblliquidation) = UnitOfWork.Find(Of Tblliquidation)(sql)

                If LSMlist.Count > 0 Then

                    For i = 0 To LSMlist.Count - 1
                        If cmbSearchBy.Text = "JRF Number" Then
                            list.Add(LSMlist(i).JrfNumber)
                        ElseIf cmbSearchBy.Text = "Name" Then
                            list.Add(LSMlist(i).Name)
                        End If

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

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txtR_JRFNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtR_JRFNumber.TextChanged
        Try
            LoadConnection()
            Dim mysource As New AutoCompleteStringCollection
            Dim list As New List(Of String)

            Using UnitOfWork = Lsconn.CreateUnitOfWork

                Dim tbl As New Tblliquidation
                Dim sql As New Query
                sql.Page = Page.Limit(10)

                If R_CmbSearchby.Text = "JRF Number" Then
                    sql.QueryExpression = Entity.Attribute("JrfNumber").Like(txtR_JRFNumber.Text + "%") And Entity.Attribute("Checked") = "1" And Entity.Attribute("Released") = "1"
                ElseIf R_CmbSearchby.Text = "Name" Then
                    sql.QueryExpression = Entity.Attribute("Name").Like(txtR_JRFNumber.Text + "%") And Entity.Attribute("Checked") = "1" And Entity.Attribute("Released") = "1"
                Else
                    Exit Sub
                End If


                Dim LSMlist As IList(Of Tblliquidation) = UnitOfWork.Find(Of Tblliquidation)(sql)

                If LSMlist.Count > 0 Then

                    For i = 0 To LSMlist.Count - 1
                        If R_CmbSearchby.Text = "JRF Number" Then
                            list.Add(LSMlist(i).JrfNumber)
                        ElseIf R_CmbSearchby.Text = "Name" Then
                            list.Add(LSMlist(i).Name)
                        End If

                    Next

                    mysource.AddRange(list.ToArray)
                    txtR_JRFNumber.AutoCompleteCustomSource = mysource
                    txtR_JRFNumber.AutoCompleteMode = AutoCompleteMode.Suggest
                    txtR_JRFNumber.AutoCompleteSource = AutoCompleteSource.CustomSource
                End If


            End Using


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim mydate = CDate(released_date)
            Dim c_ddate As String = Format(mydate, "MM/dd/yyyy")
            Load_Report(released_lcode, released_name, c_ddate)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class