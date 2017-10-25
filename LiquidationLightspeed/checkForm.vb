Imports Lightspeed.Lightspeed
Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying

Public Class liquidationLoggerForm

    Public lscontext As New LightSpeedContext

    Dim jrfNumber As String
    Dim lcode As String

    Public Sub findJrf()


        Dim dataSet As New DataSet1.tblLiquidationJrfInputDataTable
        Dim dataAdapter As New DataSet1TableAdapters.tblLiquidationJrfInputTableAdapter
        dataAdapter.Fill(dataSet, txtJrfInput.Text)
        If dataSet.Count > 0 Then

            DataGridView1.DataSource = dataSet
        Else
            DataGridView1.DataSource = Nothing
        End If





    End Sub

    Public Sub findlcode()
        DataGridView2.DataSource = Nothing
        Dim ls As New DataSet1.breakdownAdapterDataTable
        Dim la As New DataSet1TableAdapters.tblbreakdownTableAdapter
        la.Fill(ls, lcode)

        If ls.Count > 0 Then


            DataGridView2.DataSource = ls
        Else
            DataGridView2.DataSource = Nothing
        End If


        

    End Sub

    Public Sub loadData()

        Dim ds As New DataSet1.tblliquidationDataTable
        Dim da As New DataSet1TableAdapters.tblliquidationTableAdapter
        da.Fill(ds)

        DataGridView1.DataSource = ds

    End Sub
    Public Sub Lightspeed_Connection()
        lscontext.ConnectionString = con
        lscontext.DataProvider = DataProvider.MySql5
        lscontext.IdentityMethod = IdentityMethod.IdentityColumn
    End Sub

    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        Dim index As Integer
        Try
            index = DataGridView1.CurrentRow.Index
        Catch ex As Exception

        End Try

        Cursor.Current = Cursors.WaitCursor
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Please input JRF number.", "Warning.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim messageResult As MsgBoxResult = MessageBox.Show("Confirm?", "Please confirm checking", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Dim id = DataGridView1.Item("Lid", index).Value.ToString



        If messageResult = MsgBoxResult.Yes Then
            Lightspeed_Connection()
            Using UnitOfWork_david = lscontext.CreateUnitOfWork
                Dim tbl As New Tblliquidation
                Dim query As New Query

                query.QueryExpression = Entity.Attribute("Id") = id

                Dim listLSM As IList(Of Tblliquidation) = UnitOfWork_david.Find(Of Tblliquidation)(query)

                If listLSM.Count > 0 Then
                    For i = 0 To listLSM.Count - 1
                        tbl = listLSM(i)
                        tbl.Checked = 1
                        tbl.Approved = 1
                        tbl.CheckedDate = Date.Now
                        tbl.ApprovedDate = Date.Now
                    Next

                    If tbl.Errors.Count = 0 And DataGridView2.RowCount > 0 Then
                        UnitOfWork_david.Update(query, tbl)
                        UnitOfWork_david.SaveChanges()
                        MessageBox.Show("Checking successful.")
                    Else
                        MessageBox.Show("Cannot verify when breakdown is empty.", "Warning.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End Using
            'loadData()
            findJrf()

        End If



        DataGridView2.DataSource = Nothing
        DataGridView1.ClearSelection()



    End Sub

    Private Sub checkForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Cursor = Cursors.WaitCursor
        txtJrfInput.Text = ""
        findJrf()

        taskForm.Show()
        Me.Close()
        GroupBox1.Enabled = False
        Cursor = Cursors.Default


    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Cursor.Current = Cursors.WaitCursor

        findJrf()
        btnRefresh.Enabled = False
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged



        If DataGridView1.RowCount > 0 Then

            Dim i As Integer = Nothing

            Try
                i = DataGridView1.CurrentRow.Index
            Catch ex As Exception
                Exit Sub
            End Try
            'Dim middleInitial = DataGridView1.Item("middle_name", i).Value.ToString
            'Dim middleInitialFirstLetter = middleInitial.Substring(0, 1)

            Dim firstName = DataGridView1.Item("name", i).Value.ToString
            Dim firstNameCapitalized As String = StrConv(firstName, vbProperCase)

            'Dim middleInitialCapitalized As String = StrConv(middleInitialFirstLetter, VbStrConv.ProperCase)

            'Dim lastName = DataGridView1.Item("last_name", i).Value.ToString
            'Dim lastNameCapitalized As String = StrConv(lastName, vbProperCase)


            lcode = DataGridView1.Item("lcode", i).Value.ToString
            'txtTech.Text = DataGridView1.Item("first_name", i).Value.ToString & " " & middleInitial.Substring(0, 1) & ". " & DataGridView1.Item("last_name", i).Value.ToString
            txtTech.Text = firstNameCapitalized
            ' &" " & middleInitialCapitalized & ". " & lastNameCapitalized

            txtDeployment.Text = DataGridView1.Item("d_date", i).Value.ToString
            txtDestination.Text = DataGridView1.Item("destination", i).Value.ToString
            txtBoxPETC.Text = DataGridView1.Item("petc_name", i).Value.ToString
            txtLiquidation.Text = DataGridView1.Item("l_total", i).Value.ToString
            txtEncoded.Text = DataGridView1.Item("date_encoded", i).Value.ToString
            txtTask.Text = DataGridView1.Item("task", i).Value.ToString
            txtJrfSeries.Text = DataGridView1.Item("jrf_number", i).Value.ToString
            txtTech.Text = DataGridView1.Item("name", i).Value.ToString

            findlcode()
        Else
            DataGridView2.DataSource = Nothing
        End If





    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor.Current = Cursors.WaitCursor
        DataGridView1.DataSource = Nothing
        DataGridView2.DataSource = Nothing
        findJrf()



        GroupBox1.Enabled = True
        btnRefresh.Enabled = False
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txtJrfInput_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJrfInput.TextChanged
        btnRefresh.Enabled = True
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class