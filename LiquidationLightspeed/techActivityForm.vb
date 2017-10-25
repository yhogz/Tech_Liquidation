Imports Lightspeed.Lightspeed
Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying

Public Class techActivityForm

    Dim lcode As String = GenerateRandomString(20).ToString
    Public Lsconn As New LightSpeedContext

    Public LsconnPetc As New LightSpeedContext

    Public Sub LSM_ConnectionPETC()
        LsconnPetc.ConnectionString = con2
        LsconnPetc.DataProvider = DataProvider.MySql5
        Lsconn.IdentityMethod = IdentityMethod.IdentityColumn

    End Sub

    Public Sub LSM_Connection()
        Lsconn.ConnectionString = con
        Lsconn.DataProvider = DataProvider.MySql5
        Lsconn.IdentityMethod = IdentityMethod.IdentityColumn
    End Sub
    Public Function GenerateRandomString(ByRef iLength As Integer) As String
        Dim rdm As New Random()
        Dim allowChrs() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
        Dim sResult As String = ""

        For i As Integer = 0 To iLength - 1
            sResult += allowChrs(rdm.Next(0, allowChrs.Length))
        Next

        Return sResult
    End Function

    Private Sub techActivityForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LSM_Connection()
        LSM_ConnectionPETC()

        Dim tbl As New Lightspeed.Lightspeed.Tbluser
        Dim tblPetc As New Lightspeed.Lightspeed.TblPetc

        Dim query As New Query

        comboTech.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        comboTech.DropDownStyle = ComboBoxStyle.DropDown
        comboTech.AutoCompleteSource = AutoCompleteSource.ListItems

        comboPETC.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        comboPETC.DropDownStyle = ComboBoxStyle.DropDown
        comboPETC.AutoCompleteSource = AutoCompleteSource.ListItems

        Using UnitOfWork = Lsconn.CreateUnitOfWork
            query.QueryExpression = Entity.Attribute("type") = "TECH"
            query.Order = Order.By(Entity.Attribute("name"))

            Dim list As IList(Of Tbluser) = UnitOfWork.Find(Of Tbluser)(query)
            If list.Count > 0 Then
                For i = 0 To list.Count - 1
                    tbl = list(i)
                    comboTech.Items.Add(tbl.Name)

                Next
            End If

        End Using


        Using UnitOfWork = LsconnPetc.CreateUnitOfWork
            Dim listPetc As IList(Of TblPetc) = UnitOfWork.Find(Of TblPetc)()
            If listPetc.Count > 0 Then
                For i = 0 To listPetc.Count - 1
                    tblPetc = listPetc(i)
                    comboPETC.Items.Add(tblPetc.Name)
                Next
            End If
        End Using

        

    End Sub

    Private Sub btnBack_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Close()
        taskForm.Show()
    End Sub

    Private Sub txtFirstname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtMiddlename_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim datePick = CDate(datePicker.Text)

        Dim formatDate As String = Format(datePick, "yyyy-MM-dd")

        Dim msgResult As MsgBoxResult

        If txtDestination.Text = "" Then
            ErrorProvider1.SetError(txtDestination, "Please type in destination")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If
        If txtJrf.Text = "" Then
            ErrorProvider1.SetError(txtJrf, "Please type in JRF Number")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If
        If txtTask.Text = "" Then
            ErrorProvider1.SetError(txtTask, "Please type in task of technician")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If


        msgResult = MessageBox.Show("Confirm submission?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Dim userCode As String
        If msgResult = MsgBoxResult.Yes Then
            Cursor.Current = Cursors.WaitCursor
            LSM_Connection()

            'search TblJRF
            Using UnitOfWork = Lsconn.CreateUnitOfWork


                Dim queryJRFSearch As New Query
                queryJRFSearch.QueryExpression = Entity.Attribute("JRF") = txtJrf.Text 'And Entity.Attribute("assignPerson") = comboTech.Text
                Dim lists As IList(Of Tbljrf) = UnitOfWork.Find(Of Tbljrf)(queryJRFSearch)

                If lists.Count > 0 Then


                    'Search tblLiquidation
                    Using UnitOfWorkSearchJRFLiquidation = Lsconn.CreateUnitOfWork


                        

                        Dim queryJrfLiquidation As New Query
                        queryJrfLiquidation.QueryExpression = Entity.Attribute("jrfNumber") = txtJrf.Text
                        Dim listLiquidation As IList(Of Tblliquidation) = UnitOfWork.Find(Of Tblliquidation)(queryJrfLiquidation)

                        If listLiquidation.Count > 0 Then
                            MessageBox.Show("JRF Number already exists.")
                        Else
                            'add data to tblLiquidation
                            'Using UnitOfWorkName = Lsconn.CreateUnitOfWork
                            '    Dim tbl As New Tbljrf
                            'End Using

                            'update jrf name
                            Dim queryJrf As New Query
                            queryJrf.QueryExpression = Entity.Attribute("JRF") = txtJrf.Text
                            
                            Using UnitOfWorkJrf = Lsconn.CreateUnitOfWork
                                Dim tbljrf As New Tbljrf
                                Dim listJRF As IList(Of Tbljrf) = UnitOfWorkJrf.Find(Of Tbljrf)(queryJrf)


                                For i = 0 To listJRF.Count - 1
                                    tbljrf = listJRF(i)
                                    tbljrf.AssignPerson = comboTech.Text
                                Next

                                If Tbljrf.Errors.Count = 0 Then
                                    UnitOfWorkJrf.Update(queryJrf, tbljrf)
                                    UnitOfWorkJrf.SaveChanges()
                                End If
                            End Using

                            'look for usercode

                            Using UnitOfWorkUserCode = Lsconn.CreateUnitOfWork
                                Dim tblCode As New Tbluser
                                Dim queryCode As New Query

                                queryCode.QueryExpression = Entity.Attribute("type") = "MK" Or Entity.Attribute("type") = "Admin"
                                Dim listCode As IList(Of Tbluser) = UnitOfWorkUserCode.Find(Of Tbluser)(queryCode)

                                If listCode.Count > 0 Then
                                    For i = 0 To listCode.Count - 1
                                        tblCode = listCode(i)
                                        userCode = tblCode.UserCode
                                        Using UnitOfWorkAdd = Lsconn.CreateUnitOfWork
                                            Dim tbl As New Tblliquidation




                                            tbl.UserCode = userCode
                                            tbl.Name = comboTech.Text
                                            tbl.DateEncoded = DateTime.Now
                                            tbl.DDate = formatDate
                                            tbl.Task = txtTask.Text
                                            tbl.Destination = txtDestination.Text
                                            tbl.PetcName = comboPETC.Text
                                            tbl.Checked = 0
                                            tbl.Approved = 0
                                            tbl.Released = 0
                                            tbl.Lcode = lcode
                                            tbl.JrfNumber = txtJrf.Text


                                            If tbl.Errors.Count = 0 Then

                                                UnitOfWork.Add(tbl)
                                                UnitOfWork.SaveChanges()
                                                MessageBox.Show("Successfully added")

                                                txtJrf.Text = ""
                                                txtTask.Text = ""
                                                txtDestination.Text = ""
                                                Me.Close()
                                                taskForm.Show()
                                                Exit Sub
                                            Else
                                                MessageBox.Show("Error in adding technician info, please check your submission.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                            End If
                                        End Using
                                    Next
                                End If

                            End Using

                            
                        End If

                    End Using

                Else
                    MessageBox.Show("That JRF Number is not valid.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            End Using

         
        ElseIf msgResult = MsgBoxResult.No Then

        End If

    End Sub

    Private Sub btnAddLiquidationBreakdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LSM_Connection()
        Dim tbl As New Lightspeed.Lightspeed.Tblbreakdown

        Using UnitOfWork = Lsconn.CreateUnitOfWork
            tbl.Lcode = lcode

            If tbl.Errors.Count = 0 Then
                UnitOfWork.Add(tbl)
                UnitOfWork.SaveChanges()

            End If

        End Using
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboTech.SelectedIndexChanged
        LSM_Connection()


    End Sub

    Private Sub comboPETC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboPETC.SelectedIndexChanged

    End Sub

    Private Sub datePicker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datePicker.ValueChanged

    End Sub
End Class