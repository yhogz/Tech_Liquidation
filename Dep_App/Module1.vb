Imports LIQ_Lib.LIQ_Lib
Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Querying
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices

Module Module1


    Public user_ As String

    Public myconn1 As String = My.Settings.conn1
    Public Conn As String = "Server=" + myconn1 + ";Database=dbLiquidation;Uid=rdms_user;Pwd=1r1d2m7s1d1atabase" '"Data Source=localhost\sqlexpress;Initial Catalog=dbLiquidation;Persist Security Info=True;User ID=rdms_user;Password=1r1d2m7s1d1atabase"

    Public myconn2 As String = My.Settings.conn2
    Public Conn2 As String = "Server=" + myconn2 + ";Database=rdms_db;Uid=rdms_user;Pwd=1r1d2m7s1d1atabase" '"Data Source=localhost\sqlexpress;Initial Catalog=dbLiquidation;Persist Security Info=True;User ID=rdms_user;Password=1r1d2m7s1d1atabase"

    Public mySQLConn As String = "server=" + My.Settings.ServerIP + ";User Id=rdms_user;Persist Security Info=True;database=dbliquidation;password=1r1d2m7s1d1atabase"
    Public msSQLConn As String = "server=" + My.Settings.ServerIP + ";User Id=rdms_user;password=1r1d2m7s1d1atabase;Persist Security Info=True;database=rdms_db"


    Public randomcode As String
    Public user_type As String
    Public user_id As String
    Public username As String
    Public pass As String

    Public lcode As String
    Public Lid As String
    Public print_lcode As String
    Public Login_id As String

    Public b_cost As String
    Public b_type As String
    Public b_description As String
    Public mf As New MyFunction.MyFunction
    Public mytest As String = "Rdms_DEV2013"

    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2

    <DllImportAttribute("user32.dll")> _
    Public Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function
    <DllImportAttribute("user32.dll")> _
    Public Function ReleaseCapture() As Boolean
    End Function


    Public Lsconn As New LightSpeedContext
    Public LsconnPetc As New LightSpeedContext
    Sub New()
        LoadConnection()
        LSM_ConnectionPETC()
    End Sub


    Public Sub LoadConnection()
        Lsconn.ConnectionString = Conn
        Lsconn.DataProvider = DataProvider.MySql5
        Lsconn.IdentityMethod = IdentityMethod.IdentityColumn

        Dim da As New DataSet1TableAdapters.CheckBreakDownTableAdapter
        da.Connection.ConnectionString = Conn

        Dim da2 As New DataSet2TableAdapters.byDeploymentTableAdapter
        da2.Connection.ConnectionString = Conn

        Dim da3 As New DataSet3TableAdapters.tbl_petcTableAdapter
        da3.Connection.ConnectionString = Conn2




    End Sub

    Public Sub LSM_ConnectionPETC()
        LsconnPetc.ConnectionString = Conn2
        LsconnPetc.DataProvider = DataProvider.MySql5
        Lsconn.IdentityMethod = IdentityMethod.IdentityColumn

    End Sub

    Public Function GetRandomString1(ByVal length As Integer) As String

        Const alphabet As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"

        Dim result As New System.Text.StringBuilder(length)

        Static rnd As New Random(Convert.ToInt32(DateTime.Now.Ticks And Integer.MaxValue))

        Dim prevChar As String = String.Empty
        Dim nextChar As String
        Do While result.Length < length
            nextChar = alphabet.Substring(rnd.[Next](0, alphabet.Length), 1)
            If nextChar.Equals(prevChar) = False Then
                result.Append(nextChar)
                prevChar = nextChar
            End If
        Loop
        Return result.ToString
    End Function


    Public Sub Update_TotalCost(ByVal Totalcost As Decimal, ByVal solution As String, ByVal Remarks As String, ByVal liquidation_status As Integer)
        Try
            Using UnitOfWork = Lsconn.CreateUnitOfWork
                Dim tbl As New Tblliquidation
                Dim sql As New Query
                sql.QueryExpression = Entity.Attribute("Id") = Lid

                Dim List As IList(Of Tblliquidation) = UnitOfWork.Find(Of Tblliquidation)(sql)
                If List.Count > 0 Then

                    For i = 0 To List.Count - 1
                        tbl = List(i)
                    Next

                    With tbl
                        .LTotal = Totalcost
                        .Solutions = solution
                        .Remarks = Remarks
                        .NoLiquidation = liquidation_status

                    End With
                    If tbl.Errors.Count = 0 Then
                        UnitOfWork.Update(sql, tbl)
                        UnitOfWork.SaveChanges()
                    End If

                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub


    Public Sub Save_Breakdown(cost As Decimal, type As String, description As String)
        LoadConnection()
        Try
            Using UnitOfWork_B = Lsconn.CreateUnitOfWork
                Dim tbl_b As New Tblbreakdown

                With tbl_b
                    .Cost = cost
                    .Ltype = type
                    .Description = description
                    .Lcode = lcode 'randomcode
                    .ViewOn = 1
                    .DateEncoded = DateTime.Now
                    .EncodedBy = username
                End With

                If tbl_b.Errors.Count = 0 Then
                    UnitOfWork_B.Add(tbl_b)
                    UnitOfWork_B.SaveChanges()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub


    Public Sub Save_Liquidation(TechName As String, ddate As Date, destination As String, petc_name As String, task As String, total As Decimal, usercode As String)
        LoadConnection()


        Dim aa = CDate(DateTime.Now)
        Dim bb As String = Format(aa, "MMddyyyy")
        Dim randomcode1 As String = GetRandomString(10) + bb + TimeOfDay
        randomcode = randomcode1


        Dim tbl As New Tblliquidation

        Using UnitOfWork = Lsconn.CreateUnitOfWork

            With tbl
                '  .FirstName(+" " + .MiddleName + ". " + .LastName = TechName)
                .DDate = ddate
                .Destination = destination
                .PetcName = petc_name
                .Task = task
                .LTotal = total
                .DateEncoded = DateTime.Now
                .UserCode = usercode
                .Checked = "0"
                .Approved = "0"
                .Released = "0"
                .Lcode = randomcode
            End With

            If tbl.Error.Count = 0 Then
                UnitOfWork.Add(tbl)
                UnitOfWork.SaveChanges()
                MessageBox.Show("Data Successfully Saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End Using



    End Sub

    Public Sub AddNotification()


        Try


            Using UnitOfWork = Lsconn.CreateUnitOfWork

                Dim tbl As New Tblnotification



                With tbl
                    .Targettype = "MK"
                    .Sourcetype = "TECH"

                End With



            End Using


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub



    Public Sub Load_Report(ByVal lcode As String, ByVal name As String, ByVal date_ As String)

        Dim ds As New DataSet1
        Dim da As New DataSet1TableAdapters.CheckBreakDownTableAdapter
        da.Connection.ConnectionString = mySQLConn
        da.Fill(ds.CheckBreakDown, lcode)

        Dim rpt As New Liquidation
        rpt.SetDataSource(ds)

        frmPrintLiquidation.CrystalReportViewer1.ReportSource = rpt

        rpt.SetParameterValue("@Name", name)
        rpt.SetParameterValue("@Date", date_)


        frmPrintLiquidation.Show()
        MessageBox.Show("Ready to Print Liquidation", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub



    Public Sub Update_User(ByVal Id As String, ByVal name As String, ByVal user As String, ByVal password As String, ByVal type As String, ByVal active As String)

        LoadConnection()
        Try

            Using UnitOfWork = Lsconn.CreateUnitOfWork

                Dim tbl As New Tbluser
                Dim sql As New Query
                sql.QueryExpression = Entity.Attribute("Id") = Id
                Dim list As IList(Of Tbluser) = UnitOfWork.Find(Of Tbluser)(sql)

                If list.Count > 0 Then


                    For i = 0 To list.Count - 1
                        tbl = list(i)
                    Next

                    With tbl
                        .Name = name
                        .Username = user
                        .Password = mf.EncryptData(password, mytest)
                        .Type = type
                        .Active = "1"
                    End With

                    If tbl.Errors.Count = 0 Then
                        UnitOfWork.Update(sql, tbl)
                        UnitOfWork.SaveChanges()

                        MessageBox.Show("Update User Account Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub


    Public Function GetRandomString(ByVal length As Integer) As String

        Const alphabet As String = "0123456789"

        Dim result As New System.Text.StringBuilder(length)

        Static rnd As New Random(Convert.ToInt32(DateTime.Now.Ticks And Integer.MaxValue))

        Dim prevChar As String = String.Empty
        Dim nextChar As String
        Do While result.Length < length
            nextChar = alphabet.Substring(rnd.[Next](0, alphabet.Length), 1)
            If nextChar.Equals(prevChar) = False Then
                result.Append(nextChar)
                prevChar = nextChar
            End If
        Loop
        Return result.ToString
    End Function

    Public Function ReturnUploadedCode(prefix As String)
        Try
            Dim myrandomcodes As String
            myrandomcodes = prefix & GenerateReferenceCode() ' & mf.GetRandomString(10)

            Return myrandomcodes
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.OkOnly, "ReturnUploadedCode")
            Return Nothing
        End Try
    End Function

    Public Function GenerateReferenceCode() As String

        Dim mydate As String = DateTime.Now

        Dim l1 As String = GetUniqueKey(1) '"U"
        Dim l2 As String = GetUniqueKey(1) '"B"
        Dim l3 As String = GetUniqueKey(1) '"E"
        Dim l4 As String = GetUniqueKey(1) '"R"



        Dim cleanString As String = Regex.Replace(mydate, "[^\w\\-]", "") & GetUniqueKey(6)

        ' Return cleanString


        'rich
        Dim mydate2 = CDate(mydate)
        Dim formatedate As String = Format(mydate2, "MM" & l1 & "dd" & l2 & "yyy" & "hh" & l3 & "mm" & l4 & "ss" & l1 & "ff" & GetUniqueKey(8))
        Return formatedate
    End Function

    Public Function GetUniqueKey(ByVal maxSize As Integer) As String
        Dim chars As Char() = New Char(61) {}
        Dim data As Byte() = New Byte(0) {}
        chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()
        Dim crypto As New RNGCryptoServiceProvider()
        crypto.GetNonZeroBytes(data)
        data = New Byte(maxSize - 1) {}
        crypto.GetNonZeroBytes(data)
        Dim result As New StringBuilder(maxSize)
        For Each b As Byte In data
            result.Append(chars(b Mod (chars.Length)))
        Next
        Return result.ToString()
    End Function


    Public errProv As New ErrorProvider
    Public Function IsFieldEmpty(ctl As Control) As Boolean
        Try
            If (ctl.Text = String.Empty Or ctl.Text = Nothing) Then
                errProv.SetError(ctl, "Required field.")
                Return True
            Else
                errProv.SetError(ctl, String.Empty)
                Return False
            End If
        Catch ex As Exception
            errProv.SetError(ctl, ex.Message)
            Return False
        End Try
    End Function


End Module
