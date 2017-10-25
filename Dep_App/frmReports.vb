Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying
Imports LIQ_Lib.LIQ_Lib
Public Class frmReports

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click

        If cmbType.Text = "" Then
            MessageBox.Show("Please Select Type of Report!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            Cursor.Current = Cursors.WaitCursor


            If cmbType.Text = "Deployment" Then
                Dim ds As New DataSet2
                Dim da As New DataSet2TableAdapters.byDeploymentTableAdapter
                da.Fill(ds.byDeployment, dtpFrom.Text, dtpTo.Text)

                Dim rpt As New CR_ByDate
                rpt.SetDataSource(ds)
                frmGenerateReports.CrystalReportViewer1.ReportSource = rpt

                rpt.SetParameterValue("@DateFrom", dtpFrom.Text + " to " + dtpTo.Text)

            ElseIf cmbType.Text = "By PETC" Then
                Dim ds As New DataSet2
                Dim da As New DataSet2TableAdapters.byPETCTableAdapter
                da.Fill(ds.byPETC, cmbPETC_Name.Text.Trim)

                Dim rpt As New CR_byPETC
                rpt.SetDataSource(ds)
                frmGenerateReports.CrystalReportViewer1.ReportSource = rpt
                rpt.SetParameterValue("@PETC", cmbPETC_Name.Text)

            ElseIf cmbType.Text = "By Technician" Then
                Dim ds As New DataSet2
                Dim da As New DataSet2TableAdapters.byTechTableAdapter
                da.Fill(ds.byTech, cmbName.Text, dtpFrom.Text, dtpTo.Text)

                Dim rpt As New CR_byTECH
                rpt.SetDataSource(ds)
                frmGenerateReports.CrystalReportViewer1.ReportSource = rpt
                rpt.SetParameterValue("@TECH", cmbName.Text)


            ElseIf cmbType.Text = "Deployment (with Remarks)" Then

                Dim dfrom = CDate(dtpFrom.Text)
                Dim c_dfrom As String = Format(dfrom, "yyyy-MM-dd")

                Dim dto = CDate(dtpTo.Text)
                Dim c_dto As String = Format(dto, "yyyy-MM-dd")

                Using UnitOfWork = Lsconn.CreateUnitOfWork
                    Dim tbl As New Tblliquidation
                    Dim sql As New Query
                    sql.QueryExpression = Entity.Attribute(Tblliquidation.DDateField).Between(dfrom, dto)
                    Dim mylist As IList(Of Tblliquidation) = UnitOfWork.Find(Of Tblliquidation)(sql)

                    Dim liquidation As New List(Of Class_Liquidation)
                    If mylist.Count > 0 Then
                        For i = 0 To mylist.Count - 1
                            Dim mydata As New Class_Liquidation
                            With mylist(i)
                                mydata.Lid = .Id
                                mydata.Name = .Name
                                mydata.Ddate = .DDate
                                mydata.Destination = .Destination
                                mydata.petc_name = .PetcName
                                mydata.Task = .Task
                                mydata.L_Amount = .LTotal.GetValueOrDefault
                                mydata.Solution = .Solutions
                                mydata.Remarks = .Remarks
                                mydata.Status = .NoLiquidation.GetValueOrDefault
                            End With

                            liquidation.Add(mydata)
                        Next

                        Dim rpt As New CRL_Deployment
                        rpt.SetDataSource(liquidation)
                        frmGenerateReports.CrystalReportViewer1.ReportSource = rpt
                        rpt.SetParameterValue("@datefrom_to", dtpFrom.Text + " to " + dtpTo.Text)

                    End If


                End Using



            End If






            frmGenerateReports.Label1.Text = cmbType.Text
            Me.Close()
            frmGenerateReports.ShowDialog()




        End If


    End Sub


    Private Sub frmReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbPETC_Name.Items.Clear()
        cmbName.Items.Clear()
        Dim ds As New DataSet3.tbl_petcDataTable
        Dim da As New DataSet3TableAdapters.tbl_petcTableAdapter
        da.Fill(ds)

        If ds.Count > 0 Then
            For i = 0 To ds.Count - 1
                cmbPETC_Name.Items.Add(ds.Rows(i).Item("name").ToString)
            Next
        End If


        cmbName.Items.Clear()
        Dim ds_user As New DataSet1.Get_UsersDataTable
        Dim da_user As New DataSet1TableAdapters.Get_UsersTableAdapter
        da_user.Connection.ConnectionString = mySQLConn
        da_user.Fill(ds_user)

        If ds_user.Count > 0 Then
            For i2 = 0 To ds_user.Count - 1
                cmbName.Items.Add(ds_user.Rows(i2).Item("name").ToString)
            Next

        End If


    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        If cmbType.Text = "By Technician" Then
            cmbName.Enabled = True
            cmbPETC_Name.Enabled = False
            dtpFrom.Enabled = True
            dtpTo.Enabled = True

        ElseIf cmbType.Text = "By PETC" Then
            cmbName.Enabled = False
            cmbPETC_Name.Enabled = True
            dtpFrom.Enabled = True
            dtpTo.Enabled = True

        ElseIf cmbType.Text = "Deployment" Then
            cmbName.Enabled = False
            cmbPETC_Name.Enabled = False
            dtpFrom.Enabled = True
            dtpTo.Enabled = True

        End If
    End Sub
End Class