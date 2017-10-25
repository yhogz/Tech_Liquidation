<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.radBuilding = New System.Windows.Forms.CheckBox()
        Me.radTroubleshoot = New System.Windows.Forms.CheckBox()
        Me.radHardware = New System.Windows.Forms.CheckBox()
        Me.radSoftware = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radInhouse = New System.Windows.Forms.RadioButton()
        Me.radPETC = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblName = New System.Windows.Forms.Label()
        Me.cboPETC = New System.Windows.Forms.ComboBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDept = New System.Windows.Forms.TextBox()
        Me.txtDeploy = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDetails = New System.Windows.Forms.TextBox()
        Me.txtReceived = New System.Windows.Forms.TextBox()
        Me.lblDetails = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btnGenerate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(238, 612)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radBuilding)
        Me.GroupBox2.Controls.Add(Me.radTroubleshoot)
        Me.GroupBox2.Controls.Add(Me.radHardware)
        Me.GroupBox2.Controls.Add(Me.radSoftware)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.DarkGreen
        Me.GroupBox2.Location = New System.Drawing.Point(6, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(223, 84)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Nature of Request"
        '
        'radBuilding
        '
        Me.radBuilding.AutoSize = True
        Me.radBuilding.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radBuilding.ForeColor = System.Drawing.Color.Black
        Me.radBuilding.Location = New System.Drawing.Point(124, 50)
        Me.radBuilding.Name = "radBuilding"
        Me.radBuilding.Size = New System.Drawing.Size(73, 20)
        Me.radBuilding.TabIndex = 3
        Me.radBuilding.Text = "Building"
        Me.radBuilding.UseVisualStyleBackColor = True
        '
        'radTroubleshoot
        '
        Me.radTroubleshoot.AutoSize = True
        Me.radTroubleshoot.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radTroubleshoot.ForeColor = System.Drawing.Color.Black
        Me.radTroubleshoot.Location = New System.Drawing.Point(17, 50)
        Me.radTroubleshoot.Name = "radTroubleshoot"
        Me.radTroubleshoot.Size = New System.Drawing.Size(101, 20)
        Me.radTroubleshoot.TabIndex = 2
        Me.radTroubleshoot.Text = "Troubleshoot"
        Me.radTroubleshoot.UseVisualStyleBackColor = True
        '
        'radHardware
        '
        Me.radHardware.AutoSize = True
        Me.radHardware.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radHardware.ForeColor = System.Drawing.Color.Black
        Me.radHardware.Location = New System.Drawing.Point(124, 24)
        Me.radHardware.Name = "radHardware"
        Me.radHardware.Size = New System.Drawing.Size(81, 20)
        Me.radHardware.TabIndex = 1
        Me.radHardware.Text = "Hardware"
        Me.radHardware.UseVisualStyleBackColor = True
        '
        'radSoftware
        '
        Me.radSoftware.AutoSize = True
        Me.radSoftware.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSoftware.ForeColor = System.Drawing.Color.Black
        Me.radSoftware.Location = New System.Drawing.Point(17, 24)
        Me.radSoftware.Name = "radSoftware"
        Me.radSoftware.Size = New System.Drawing.Size(77, 20)
        Me.radSoftware.TabIndex = 0
        Me.radSoftware.Text = "Software"
        Me.radSoftware.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radInhouse)
        Me.GroupBox1.Controls.Add(Me.radPETC)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkGreen
        Me.GroupBox1.Location = New System.Drawing.Point(8, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(223, 42)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Requestor"
        '
        'radInhouse
        '
        Me.radInhouse.AutoSize = True
        Me.radInhouse.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radInhouse.ForeColor = System.Drawing.Color.Black
        Me.radInhouse.Location = New System.Drawing.Point(116, 14)
        Me.radInhouse.Name = "radInhouse"
        Me.radInhouse.Size = New System.Drawing.Size(77, 20)
        Me.radInhouse.TabIndex = 2
        Me.radInhouse.TabStop = True
        Me.radInhouse.Text = "In House"
        Me.radInhouse.UseVisualStyleBackColor = True
        '
        'radPETC
        '
        Me.radPETC.AutoSize = True
        Me.radPETC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radPETC.ForeColor = System.Drawing.Color.Black
        Me.radPETC.Location = New System.Drawing.Point(30, 14)
        Me.radPETC.Name = "radPETC"
        Me.radPETC.Size = New System.Drawing.Size(60, 20)
        Me.radPETC.TabIndex = 1
        Me.radPETC.TabStop = True
        Me.radPETC.Text = "PETC"
        Me.radPETC.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblName)
        Me.Panel2.Controls.Add(Me.cboPETC)
        Me.Panel2.Controls.Add(Me.txtAddress)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtDept)
        Me.Panel2.Controls.Add(Me.txtDeploy)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtDetails)
        Me.Panel2.Controls.Add(Me.txtReceived)
        Me.Panel2.Controls.Add(Me.lblDetails)
        Me.Panel2.Location = New System.Drawing.Point(6, 172)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(223, 396)
        Me.Panel2.TabIndex = 12
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(11, 17)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(88, 16)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "PETC Name :"
        '
        'cboPETC
        '
        Me.cboPETC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPETC.FormattingEnabled = True
        Me.cboPETC.Location = New System.Drawing.Point(11, 39)
        Me.cboPETC.Name = "cboPETC"
        Me.cboPETC.Size = New System.Drawing.Size(201, 24)
        Me.cboPETC.TabIndex = 0
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(11, 85)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(201, 51)
        Me.txtAddress.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Address :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 342)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Deployment Date :"
        '
        'txtDept
        '
        Me.txtDept.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDept.Location = New System.Drawing.Point(11, 163)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.Size = New System.Drawing.Size(201, 22)
        Me.txtDept.TabIndex = 2
        '
        'txtDeploy
        '
        Me.txtDeploy.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeploy.Location = New System.Drawing.Point(11, 362)
        Me.txtDeploy.Name = "txtDeploy"
        Me.txtDeploy.Size = New System.Drawing.Size(201, 22)
        Me.txtDeploy.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Department :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 293)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Recieved Date :"
        '
        'txtDetails
        '
        Me.txtDetails.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetails.Location = New System.Drawing.Point(11, 212)
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.Size = New System.Drawing.Size(201, 73)
        Me.txtDetails.TabIndex = 3
        '
        'txtReceived
        '
        Me.txtReceived.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceived.Location = New System.Drawing.Point(11, 312)
        Me.txtReceived.Name = "txtReceived"
        Me.txtReceived.Size = New System.Drawing.Size(201, 22)
        Me.txtReceived.TabIndex = 4
        '
        'lblDetails
        '
        Me.lblDetails.AutoSize = True
        Me.lblDetails.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetails.Location = New System.Drawing.Point(11, 193)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(48, 16)
        Me.lblDetails.TabIndex = 7
        Me.lblDetails.Text = "Details"
        '
        'btnGenerate
        '
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGenerate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(70, 574)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(99, 29)
        Me.btnGenerate.TabIndex = 6
        Me.btnGenerate.Text = "Preview"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(743, 118)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(126, 87)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(238, 0)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.PageOffset = New System.Drawing.Point(10, 10)
        Me.PreviewControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PreviewControl1.Size = New System.Drawing.Size(679, 612)
        Me.PreviewControl1.TabIndex = 3
        '
        'frmPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 612)
        Me.Controls.Add(Me.PreviewControl1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print JRF"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDeploy As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtReceived As System.Windows.Forms.TextBox
    Friend WithEvents lblDetails As System.Windows.Forms.Label
    Friend WithEvents txtDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents cboPETC As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radInhouse As System.Windows.Forms.RadioButton
    Friend WithEvents radPETC As System.Windows.Forms.RadioButton
    Friend WithEvents radBuilding As System.Windows.Forms.CheckBox
    Friend WithEvents radTroubleshoot As System.Windows.Forms.CheckBox
    Friend WithEvents radHardware As System.Windows.Forms.CheckBox
    Friend WithEvents radSoftware As System.Windows.Forms.CheckBox
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
End Class
