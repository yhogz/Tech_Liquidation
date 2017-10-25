Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying
Imports LSM_Lib.LSM_Lib
Imports FastReport.Data

Public Class Form1

    Dim yhogz As New Yhogz.Utility("J8i7a2n0a1R6aine")

    Public Sub New(e As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'FastReport.Utils.RegisteredObjects.AddConnection(GetType(MySqlDataConnection))
        sysUsername = e

    End Sub

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        'If (txtNum.TextLength = 0 Or txtNum.Text = "0") Then
        '    MessageBox.Show("Please input how many JRF Forms to generate", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtNum.Clear()
        '    txtNum.Focus()
        '    Exit Sub
        'End If
        Cursor.Current = Cursors.WaitCursor
        lvJRF.Items.Clear()
        'Cursor.Current = Cursors.WaitCursor
        For i = 0 To Val(txtNum.Text) - 1

            Dim aa As String = GetRandomString(7)
            Save_JRFCode(aa)
            'Dim item As New ListViewItem(aa)
            'lvJRF.Items.AddRange(New ListViewItem() {item})
            Dim lvi = New ListViewItem(aa)
            lvJRF.Items.Add(lvi)
        Next
        MessageBox.Show("JRF Successfully Added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'btnPrint.Enabled = True
        'btnGenerate.Enabled = False
    End Sub


    Public Sub Save_JRFCode(Jrfcode As String)

        LoadConnection()
        Using UnitOfWork = Lsconn.CreateUnitOfWork


            Dim tbl As New Tbljrf

            With tbl
                .Jrf = Jrfcode
                .DateCreated = Date.Now
                .AssignPerson = ""
                .Active = 1
                .Print = 0
                .GeneratedBy = sysUsername
            End With


            If tbl.Errors.Count = 0 Then
                UnitOfWork.Add(tbl)
                UnitOfWork.SaveChanges()
            End If
        End Using


    End Sub






    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Cursor.Current = Cursors.WaitCursor



        Try
            ''Dim ds As New DataSet2
            ''Dim da As New DataSet2TableAdapters.tbljrfTableAdapter
            'Dim ds As New DsJRF
            'Dim da As New DsJRFTableAdapters.tbljrfTableAdapter
            'da.Fill(ds.tbljrf)
            ''edited by ogie
            ''Dim rpt As New CrystalReport1
            'Dim rpt As New crJRFPortrait
            'rpt.SetDataSource(ds)
            'frmPrintNew.CrystalReportViewer1.ReportSource = rpt
            'Dim frm As New frmPrintNew(DsPETC)
            'frm.Show()
            'Tag_as_Print()

            If lvJRF.Items.Count = 0 Then
                MessageBox.Show("Please generate JRF first", "No JRF Generated", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim rpt As New crJRFPortrait
            'Dim ds As New DsJRF
            'Dim da As New DsJRFTableAdapters.tbljrfTableAdapter

            Dim myList As New List(Of structJRF)
            myList = listofForPrinting()

            rpt.SetDataSource(myList)
            rpt.SetParameterValue("PETC Name", cboPETC.Text)
            rpt.SetParameterValue("Address", txtAddress.Text)
            rpt.SetParameterValue("Department", txtDept.Text)
            rpt.SetParameterValue("Details", txtDetails.Text)
            rpt.SetParameterValue("Received Date", txtReceived.Text)
            rpt.SetParameterValue("Deployment Date", txtDeploy.Text)
            Dim strC = If(Not (radPETC.Checked = True), "", "Y")
            Dim strI = If(Not (radInhouse.Checked = True), "", "Y")
            Dim strS = If(Not (radSoftware.Checked = True), "", "Y")
            Dim strH = If(Not (radHardware.Checked = True), "", "Y")
            Dim strT = If(Not (radTroubleshoot.Checked = True), "", "Y")
            Dim strB = If(Not (radBuilding.Checked = True), "", "Y")
            rpt.SetParameterValue("CHKPETC", strC)
            rpt.SetParameterValue("CHKInHouse", strI)
            rpt.SetParameterValue("ChkSoftware", strS)
            rpt.SetParameterValue("ChkHardware", strH)
            rpt.SetParameterValue("ChkTroubleshooting", strT)
            rpt.SetParameterValue("ChkBuilding", strB)

            frmPrintNew.CrystalReportViewer1.ReportSource = rpt
            frmPrintNew.ShowDialog()
            Tag_as_Print_New()
            clearTXT()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'lvJRF.Items.Clear()
        'txtNum.Clear()
        'btnGenerate.Enabled = True
        'btnPrint.Enabled = False
    End Sub



    Public Sub Tag_as_Print()
        Try


            LoadConnection()

            Dim jrf_code As String
            For i = 0 To lvJRF.Items.Count - 1
                jrf_code = lvJRF.Items(i).SubItems(0).Text
                Using UnitOfWork = Lsconn.CreateUnitOfWork
                    Dim tbl As New Tbljrf
                    Dim sql As New Query
                    sql.QueryExpression = Entity.Attribute("Jrf") = jrf_code
                    Dim list As IList(Of Tbljrf) = UnitOfWork.Find(Of Tbljrf)(sql)

                    For i2 = 0 To list.Count - 1
                        tbl = list(i2)

                        With tbl

                            .Print = "1"

                        End With
                    Next

                    If tbl.Errors.Count = 0 Then
                        UnitOfWork.Update(sql, tbl)
                        UnitOfWork.SaveChanges()
                    End If
                End Using
            Next


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim assVer As String = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString()
            Dim pcName As String = Environment.UserName
            Me.Text = Me.Text + assVer
            'Dim tempName As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
            'Dim flag As Boolean = checkIfActive(assVer, tempName, pcName)
            'If Not flag Then
            '    MessageBox.Show("Unauthorized Software", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    MessageBox.Show(pcName, "Computer Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Application.Exit()
            'End If
            GetPETCNames()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub LoadComboPETC(myDs As DsPETC.TPETCCompanyRecordDataTable)
        Dim myDict As New Dictionary(Of String, String)
        myDict.Add("", "")
        For Each row As DataRow In myDs.Rows
            myDict.Add(row.Item(2), row.Item(3))
        Next row
        cboPETC.DisplayMember = "Key"
        cboPETC.ValueMember = "Value"
        cboPETC.DataSource = New BindingSource(myDict, Nothing)
    End Sub



    Private Sub GetPETCNames()
        Try
            Dim dsPETC As New DsPETC.TPETCCompanyRecordDataTable
            Dim da As New DsPETCTableAdapters.TPETCCompanyRecordTableAdapter(My.Settings.PANA)
            da.FillActive(dsPETC)
            LoadComboPETC(dsPETC)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function checkIfActive(_version As String, _productName As String, _pcName As String) As Boolean
        Dim retval As Boolean = False
        Try
            LoadConnection()
            Using uow = Lsconn.CreateUnitOfWork
                Dim listCont As New List(Of TblController)
                listCont = uow.TblControllers.Where(Function(m) m.ProductVersion = _version AndAlso m.ProductName = _productName AndAlso m.AuthorizedUser = _pcName).ToList()
                If listCont.Count > 0 Then
                    For Each r In listCont
                        If r.Isactive = True Then
                            retval = True
                        Else
                            retval = False
                        End If
                    Next
                Else
                    retval = False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            retval = False
        End Try
        Return retval
    End Function
    Private Sub txtNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNum.KeyPress
        e.Handled = yhogz.numberInputFilter(e.KeyChar)
    End Sub

    Private Function listofForPrinting() As List(Of structJRF)
        Dim list As New List(Of Tbljrf)
        Dim retVal As New List(Of structJRF)
        Using uow = Lsconn.CreateUnitOfWork
            list = uow.Tbljrves.Where(Function(m) m.Print = 0).ToList()
            If list.Count > 0 Then
                For Each r In list
                    Dim tbl As New structJRF
                    tbl.jrfCol = r.Jrf
                    retVal.Add(tbl)
                Next
            End If
        End Using
        Return retVal
    End Function


    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        'Dim ds As New DsJRF
        'Dim da As New DsJRFTableAdapters.tbljrfTableAdapter(My.Settings.ServerName)
        'da.Fill(ds.tbljrf)

        Dim myList As New List(Of structJRF)
        myList = listofForPrinting()

        'Dim report1 As New FastReport.Report()

        'report1.RegisterData(myList, "structJRF")


        'report1.Design()


        'report1.Dispose()

        'Exit Sub

        If (myList.Count = 0) Then
            MessageBox.Show("No JRF Generated!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim report As New FastReport.Report()
        'report.Load("..\..\resources\report.frx")
        report.Load(Application.StartupPath + "\report.frx")
        report.RegisterData(myList, "structJRF")
        report.SetParameterValue("Parameter", radPETC.Checked)
        report.SetParameterValue("ParInhouse", radInhouse.Checked)
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
        report.SetParameterValue("ParFormCode", My.Settings.FormCode)
        report.Show()
        report.Dispose()
        Tag_as_Print_New()
        clearTXT()

    End Sub

    Public Sub Tag_as_Print_New()
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

    Public Sub clearTXT()

        cboPETC.SelectedIndex = 0
        txtDeploy.Clear()
        txtDept.Clear()
        txtDetails.Clear()
        'txtNum.Clear()
        txtReceived.Clear()
        lvJRF.Items.Clear()
        radBuilding.Checked = False
        radHardware.Checked = False
        radSoftware.Checked = False
        radTroubleshoot.Checked = False
        radInhouse.Checked = False
        radPETC.Checked = False

    End Sub

    Private Sub txtDetails_TextChanged(sender As Object, e As EventArgs) Handles txtDetails.TextChanged
        'Me.Text = txtDetails.TextLength.ToString()
    End Sub

    Private Sub cboPETC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPETC.SelectedIndexChanged
        txtAddress.Text = cboPETC.SelectedValue
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click


    End Sub
End Class
