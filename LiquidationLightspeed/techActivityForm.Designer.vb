<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class techActivityForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(techActivityForm))
        Me.btnBack = New System.Windows.Forms.Button()
        Me.txtJrf = New System.Windows.Forms.TextBox()
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.txtTask = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.datePicker = New System.Windows.Forms.DateTimePicker()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.comboTech = New System.Windows.Forms.ComboBox()
        Me.comboPETC = New System.Windows.Forms.ComboBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(291, 462)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(106, 31)
        Me.btnBack.TabIndex = 8
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'txtJrf
        '
        Me.txtJrf.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtJrf.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJrf.Location = New System.Drawing.Point(115, 312)
        Me.txtJrf.Name = "txtJrf"
        Me.txtJrf.Size = New System.Drawing.Size(251, 19)
        Me.txtJrf.TabIndex = 5
        '
        'txtDestination
        '
        Me.txtDestination.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDestination.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDestination.Location = New System.Drawing.Point(115, 139)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(247, 19)
        Me.txtDestination.TabIndex = 2
        '
        'txtTask
        '
        Me.txtTask.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTask.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTask.Location = New System.Drawing.Point(113, 256)
        Me.txtTask.Name = "txtTask"
        Me.txtTask.Size = New System.Drawing.Size(249, 19)
        Me.txtTask.TabIndex = 4
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(173, 462)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(105, 32)
        Me.btnSubmit.TabIndex = 7
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'datePicker
        '
        Me.datePicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datePicker.Location = New System.Drawing.Point(113, 76)
        Me.datePicker.Name = "datePicker"
        Me.datePicker.Size = New System.Drawing.Size(253, 24)
        Me.datePicker.TabIndex = 1
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'comboTech
        '
        Me.comboTech.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboTech.Font = New System.Drawing.Font("Adobe Fan Heiti Std B", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboTech.FormattingEnabled = True
        Me.comboTech.Location = New System.Drawing.Point(113, 18)
        Me.comboTech.Name = "comboTech"
        Me.comboTech.Size = New System.Drawing.Size(253, 27)
        Me.comboTech.TabIndex = 0
        '
        'comboPETC
        '
        Me.comboPETC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboPETC.Font = New System.Drawing.Font("Adobe Fan Heiti Std B", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboPETC.FormattingEnabled = True
        Me.comboPETC.Location = New System.Drawing.Point(113, 191)
        Me.comboPETC.Name = "comboPETC"
        Me.comboPETC.Size = New System.Drawing.Size(253, 27)
        Me.comboPETC.TabIndex = 3
        '
        'techActivityForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(402, 500)
        Me.Controls.Add(Me.comboPETC)
        Me.Controls.Add(Me.comboTech)
        Me.Controls.Add(Me.datePicker)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtTask)
        Me.Controls.Add(Me.txtJrf)
        Me.Controls.Add(Me.txtDestination)
        Me.Controls.Add(Me.btnBack)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "techActivityForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Technician Activity Input"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents txtJrf As System.Windows.Forms.TextBox
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents txtTask As System.Windows.Forms.TextBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents datePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents comboTech As System.Windows.Forms.ComboBox
    Friend WithEvents comboPETC As System.Windows.Forms.ComboBox
End Class
