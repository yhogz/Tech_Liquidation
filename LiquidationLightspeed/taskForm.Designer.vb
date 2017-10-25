<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class taskForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(taskForm))
        Me.btnLiquidation = New System.Windows.Forms.Button()
        Me.btnTechActivity = New System.Windows.Forms.Button()
        Me.btnJRFGeneration = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnLiquidation
        '
        Me.btnLiquidation.Font = New System.Drawing.Font("Adobe Fan Heiti Std B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiquidation.Location = New System.Drawing.Point(137, 203)
        Me.btnLiquidation.Name = "btnLiquidation"
        Me.btnLiquidation.Size = New System.Drawing.Size(154, 61)
        Me.btnLiquidation.TabIndex = 0
        Me.btnLiquidation.Text = "Liquidation Logger"
        Me.btnLiquidation.UseVisualStyleBackColor = True
        '
        'btnTechActivity
        '
        Me.btnTechActivity.Font = New System.Drawing.Font("Adobe Fan Heiti Std B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTechActivity.Location = New System.Drawing.Point(137, 123)
        Me.btnTechActivity.Name = "btnTechActivity"
        Me.btnTechActivity.Size = New System.Drawing.Size(154, 61)
        Me.btnTechActivity.TabIndex = 1
        Me.btnTechActivity.Text = "Tech Activity"
        Me.btnTechActivity.UseVisualStyleBackColor = True
        '
        'btnJRFGeneration
        '
        Me.btnJRFGeneration.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnJRFGeneration.Font = New System.Drawing.Font("Adobe Fan Heiti Std B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJRFGeneration.Location = New System.Drawing.Point(137, 45)
        Me.btnJRFGeneration.Name = "btnJRFGeneration"
        Me.btnJRFGeneration.Size = New System.Drawing.Size(154, 61)
        Me.btnJRFGeneration.TabIndex = 2
        Me.btnJRFGeneration.Text = "JRF Generation"
        Me.btnJRFGeneration.UseVisualStyleBackColor = False
        '
        'taskForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 308)
        Me.Controls.Add(Me.btnJRFGeneration)
        Me.Controls.Add(Me.btnTechActivity)
        Me.Controls.Add(Me.btnLiquidation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "taskForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick a task"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLiquidation As System.Windows.Forms.Button
    Friend WithEvents btnTechActivity As System.Windows.Forms.Button
    Friend WithEvents btnJRFGeneration As System.Windows.Forms.Button
End Class
