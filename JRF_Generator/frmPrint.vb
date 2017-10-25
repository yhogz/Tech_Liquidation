Imports LSM_Lib.LSM_Lib
Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying

Public Class frmPrint

    Private Sub frmPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboPETC.DropDownWidth = My.Settings.comboWidth


    End Sub



    Public Sub New(myDs As DsPETC.TPETCCompanyRecordDataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim myDict As New Dictionary(Of String, String)
        myDict.Add("", "")
        For Each row As DataRow In myDs.Rows
            myDict.Add(row.Item(2), row.Item(3))
        Next row
        cboPETC.DisplayMember = "Key"
        cboPETC.ValueMember = "Value"
        cboPETC.DataSource = New BindingSource(myDict, Nothing)

    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try

            Dim ds As New DsJRF
            Dim da As New DsJRFTableAdapters.tbljrfTableAdapter(My.Settings.ServerName)
            da.Fill(ds.tbljrf)

            'If (ds.tbljrf.Count = 0) Then
            '    MessageBox.Show("No JRF Generated!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Exit Sub
            'End If

            Dim report As New FastReport.Report()
            report.Load("..\..\resources\report.frx")
            report.RegisterData(ds)
            report.SetParameterValue("Parameter", radPETC.Checked)
            report.SetParameterValue("ParSoftware", radSoftware.Checked)
            report.SetParameterValue("ParHardware", radHardware.Checked)
            report.SetParameterValue("ParTroubleshooting", radTroubleshoot.Checked)
            report.SetParameterValue("ParBuilding", radBuilding.Checked)
            report.SetParameterValue("ParPETCName", cboPETC.Text)
            report.SetParameterValue("ParAddress", txtAddress.Text)
            report.SetParameterValue("ParDetails", txtDetails.Text)
            report.SetParameterValue("ParDepartment", txtDept.Text)
            report.SetParameterValue("ParReceived", txtReceived.Text)
            report.SetParameterValue("ParDeploy", txtDeploy.Text)
            report.Show()
            report.Dispose()
            'Dim rpt As New crJRFPortrait
            'rpt.SetDataSource(ds)
            'rpt.SetParameterValue("PETC Name", cboPETC.Text)
            'rpt.SetParameterValue("Address", txtAddress.Text)
            'rpt.SetParameterValue("Department", txtDept.Text)
            'rpt.SetParameterValue("Details", txtDetails.Text)
            'rpt.SetParameterValue("Received Date", txtReceived.Text)
            'rpt.SetParameterValue("Deployment Date", txtDeploy.Text)
            'Dim strC = If(Not (radPETC.Checked = True), "", "Y")
            'Dim strI = If(Not (radInhouse.Checked = True), "", "Y")
            'Dim strS = If(Not (radSoftware.Checked = True), "", "Y")
            'Dim strH = If(Not (radHardware.Checked = True), "", "Y")
            'Dim strT = If(Not (radTroubleshoot.Checked = True), "", "Y")
            'Dim strB = If(Not (radBuilding.Checked = True), "", "Y")
            'rpt.SetParameterValue("CHKPETC", strC)
            'rpt.SetParameterValue("CHKInHouse", strI)
            'rpt.SetParameterValue("ChkSoftware", strS)
            'rpt.SetParameterValue("ChkHardware", strH)
            'rpt.SetParameterValue("ChkTroubleshooting", strT)
            'rpt.SetParameterValue("ChkBuilding", strB)

            'CrystalReportViewer1.ReportSource = rpt
            'Tag_as_Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboPETC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPETC.SelectedIndexChanged
        txtAddress.Text = cboPETC.SelectedValue
    End Sub


    Public Sub Tag_as_Print()
        Try

            LoadConnection()
            Using uow = Lsconn.CreateUnitOfWork
                
                'Dim overdueDate As DateTime = DateTime.Now.AddMonths(-6)
                Dim notPrinted As New Query(GetType(Tbljrf), Entity.Attribute("Print") = 0)
                Dim changes As New Dictionary(Of String, Integer)
                changes.Add("Print", 1)
                uow.Update(notPrinted, changes)
                uow.SaveChanges()
            End Using
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

End Class