<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnA_Add = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnA_Save = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtA_confirmpass = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbA_Type = New System.Windows.Forms.ComboBox()
        Me.txtA_Pass = New System.Windows.Forms.TextBox()
        Me.txtA_username = New System.Windows.Forms.TextBox()
        Me.txtA_Name = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnUpdate = New System.Windows.Forms.Label()
        Me.btnU_Update = New System.Windows.Forms.Button()
        Me.btnU_Clear = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblU_Save = New System.Windows.Forms.Label()
        Me.btnU_Save = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtU_ConPassword = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtU_NPassword = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbU_Type = New System.Windows.Forms.ComboBox()
        Me.txtU_CurrPassword = New System.Windows.Forms.TextBox()
        Me.txtU_Username = New System.Windows.Forms.TextBox()
        Me.txtU_Name = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnU_Search = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(616, 527)
        Me.Panel1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(8, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(596, 477)
        Me.TabControl1.TabIndex = 22
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnA_Add)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.btnClear)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.btnA_Save)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(588, 451)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Add User"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnA_Add
        '
        Me.btnA_Add.BackColor = System.Drawing.Color.Transparent
        Me.btnA_Add.BackgroundImage = Global.Dep_App.My.Resources.Resources._1
        Me.btnA_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnA_Add.Location = New System.Drawing.Point(41, 309)
        Me.btnA_Add.Name = "btnA_Add"
        Me.btnA_Add.Size = New System.Drawing.Size(58, 43)
        Me.btnA_Add.TabIndex = 0
        Me.btnA_Add.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(52, 357)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 16)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Add"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Transparent
        Me.btnClear.BackgroundImage = Global.Dep_App.My.Resources.Resources.edit_clear
        Me.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClear.Location = New System.Drawing.Point(179, 309)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(58, 43)
        Me.btnClear.TabIndex = 2
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(193, 359)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Clear"
        '
        'btnA_Save
        '
        Me.btnA_Save.BackColor = System.Drawing.Color.Transparent
        Me.btnA_Save.BackgroundImage = Global.Dep_App.My.Resources.Resources.save
        Me.btnA_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnA_Save.Location = New System.Drawing.Point(110, 309)
        Me.btnA_Save.Name = "btnA_Save"
        Me.btnA_Save.Size = New System.Drawing.Size(58, 43)
        Me.btnA_Save.TabIndex = 1
        Me.btnA_Save.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(121, 357)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Save"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Dep_App.My.Resources.Resources.Green_bkgd_72rgb11
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtA_confirmpass)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.cmbA_Type)
        Me.Panel2.Controls.Add(Me.txtA_Pass)
        Me.Panel2.Controls.Add(Me.txtA_username)
        Me.Panel2.Controls.Add(Me.txtA_Name)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(41, 55)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(507, 234)
        Me.Panel2.TabIndex = 30
        '
        'txtA_confirmpass
        '
        Me.txtA_confirmpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtA_confirmpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtA_confirmpass.Location = New System.Drawing.Point(143, 172)
        Me.txtA_confirmpass.Name = "txtA_confirmpass"
        Me.txtA_confirmpass.Size = New System.Drawing.Size(322, 26)
        Me.txtA_confirmpass.TabIndex = 4
        Me.txtA_confirmpass.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 16)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "ConfirmPassword :"
        '
        'cmbA_Type
        '
        Me.cmbA_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbA_Type.FormattingEnabled = True
        Me.cmbA_Type.Items.AddRange(New Object() {"MC", "MK", "SV", "TECH"})
        Me.cmbA_Type.Location = New System.Drawing.Point(143, 49)
        Me.cmbA_Type.Name = "cmbA_Type"
        Me.cmbA_Type.Size = New System.Drawing.Size(322, 28)
        Me.cmbA_Type.TabIndex = 1
        '
        'txtA_Pass
        '
        Me.txtA_Pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtA_Pass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtA_Pass.Location = New System.Drawing.Point(143, 131)
        Me.txtA_Pass.Name = "txtA_Pass"
        Me.txtA_Pass.Size = New System.Drawing.Size(322, 26)
        Me.txtA_Pass.TabIndex = 3
        Me.txtA_Pass.UseSystemPasswordChar = True
        '
        'txtA_username
        '
        Me.txtA_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtA_username.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtA_username.Location = New System.Drawing.Point(143, 93)
        Me.txtA_username.Name = "txtA_username"
        Me.txtA_username.Size = New System.Drawing.Size(322, 26)
        Me.txtA_username.TabIndex = 2
        '
        'txtA_Name
        '
        Me.txtA_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtA_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtA_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtA_Name.Location = New System.Drawing.Point(143, 14)
        Me.txtA_Name.Name = "txtA_Name"
        Me.txtA_Name.Size = New System.Drawing.Size(322, 26)
        Me.txtA_Name.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Type :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Password :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Username :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name :"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PictureBox1)
        Me.TabPage2.Controls.Add(Me.btnUpdate)
        Me.TabPage2.Controls.Add(Me.btnU_Update)
        Me.TabPage2.Controls.Add(Me.btnU_Clear)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.lblU_Save)
        Me.TabPage2.Controls.Add(Me.btnU_Save)
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(588, 451)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Update User"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Dep_App.My.Resources.Resources.username
        Me.PictureBox1.Location = New System.Drawing.Point(40, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(84, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 43
        Me.PictureBox1.TabStop = False
        '
        'btnUpdate
        '
        Me.btnUpdate.AutoSize = True
        Me.btnUpdate.BackColor = System.Drawing.Color.Transparent
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(37, 421)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(53, 16)
        Me.btnUpdate.TabIndex = 42
        Me.btnUpdate.Text = "Update"
        '
        'btnU_Update
        '
        Me.btnU_Update.BackColor = System.Drawing.Color.Transparent
        Me.btnU_Update.BackgroundImage = Global.Dep_App.My.Resources.Resources.edit
        Me.btnU_Update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnU_Update.Location = New System.Drawing.Point(34, 373)
        Me.btnU_Update.Name = "btnU_Update"
        Me.btnU_Update.Size = New System.Drawing.Size(58, 43)
        Me.btnU_Update.TabIndex = 0
        Me.btnU_Update.UseVisualStyleBackColor = False
        '
        'btnU_Clear
        '
        Me.btnU_Clear.BackColor = System.Drawing.Color.Transparent
        Me.btnU_Clear.BackgroundImage = Global.Dep_App.My.Resources.Resources.edit_clear
        Me.btnU_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnU_Clear.Location = New System.Drawing.Point(171, 373)
        Me.btnU_Clear.Name = "btnU_Clear"
        Me.btnU_Clear.Size = New System.Drawing.Size(58, 43)
        Me.btnU_Clear.TabIndex = 2
        Me.btnU_Clear.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(185, 423)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 16)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Clear"
        '
        'lblU_Save
        '
        Me.lblU_Save.AutoSize = True
        Me.lblU_Save.BackColor = System.Drawing.Color.Transparent
        Me.lblU_Save.Enabled = False
        Me.lblU_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblU_Save.Location = New System.Drawing.Point(113, 421)
        Me.lblU_Save.Name = "lblU_Save"
        Me.lblU_Save.Size = New System.Drawing.Size(40, 16)
        Me.lblU_Save.TabIndex = 38
        Me.lblU_Save.Text = "Save"
        '
        'btnU_Save
        '
        Me.btnU_Save.BackColor = System.Drawing.Color.Transparent
        Me.btnU_Save.BackgroundImage = Global.Dep_App.My.Resources.Resources.save
        Me.btnU_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnU_Save.Enabled = False
        Me.btnU_Save.Location = New System.Drawing.Point(102, 373)
        Me.btnU_Save.Name = "btnU_Save"
        Me.btnU_Save.Size = New System.Drawing.Size(58, 43)
        Me.btnU_Save.TabIndex = 1
        Me.btnU_Save.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.Dep_App.My.Resources.Resources.Green_bkgd_72rgb11
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtU_ConPassword)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.txtU_NPassword)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.cmbU_Type)
        Me.Panel3.Controls.Add(Me.txtU_CurrPassword)
        Me.Panel3.Controls.Add(Me.txtU_Username)
        Me.Panel3.Controls.Add(Me.txtU_Name)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Enabled = False
        Me.Panel3.Location = New System.Drawing.Point(33, 94)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(520, 268)
        Me.Panel3.TabIndex = 31
        '
        'txtU_ConPassword
        '
        Me.txtU_ConPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtU_ConPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtU_ConPassword.Location = New System.Drawing.Point(135, 205)
        Me.txtU_ConPassword.Name = "txtU_ConPassword"
        Me.txtU_ConPassword.Size = New System.Drawing.Size(322, 26)
        Me.txtU_ConPassword.TabIndex = 5
        Me.txtU_ConPassword.UseSystemPasswordChar = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(8, 210)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 16)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "Confirm Password :"
        '
        'txtU_NPassword
        '
        Me.txtU_NPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtU_NPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtU_NPassword.Location = New System.Drawing.Point(135, 169)
        Me.txtU_NPassword.Name = "txtU_NPassword"
        Me.txtU_NPassword.Size = New System.Drawing.Size(322, 26)
        Me.txtU_NPassword.TabIndex = 4
        Me.txtU_NPassword.UseSystemPasswordChar = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(7, 174)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "New Password :"
        '
        'cmbU_Type
        '
        Me.cmbU_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbU_Type.FormattingEnabled = True
        Me.cmbU_Type.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbU_Type.Location = New System.Drawing.Point(135, 49)
        Me.cmbU_Type.Name = "cmbU_Type"
        Me.cmbU_Type.Size = New System.Drawing.Size(322, 28)
        Me.cmbU_Type.TabIndex = 1
        '
        'txtU_CurrPassword
        '
        Me.txtU_CurrPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtU_CurrPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtU_CurrPassword.Location = New System.Drawing.Point(135, 131)
        Me.txtU_CurrPassword.Name = "txtU_CurrPassword"
        Me.txtU_CurrPassword.Size = New System.Drawing.Size(322, 26)
        Me.txtU_CurrPassword.TabIndex = 3
        Me.txtU_CurrPassword.UseSystemPasswordChar = True
        '
        'txtU_Username
        '
        Me.txtU_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtU_Username.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtU_Username.Location = New System.Drawing.Point(135, 93)
        Me.txtU_Username.Name = "txtU_Username"
        Me.txtU_Username.Size = New System.Drawing.Size(322, 26)
        Me.txtU_Username.TabIndex = 2
        '
        'txtU_Name
        '
        Me.txtU_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtU_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtU_Name.Location = New System.Drawing.Point(135, 14)
        Me.txtU_Name.Name = "txtU_Name"
        Me.txtU_Name.Size = New System.Drawing.Size(322, 26)
        Me.txtU_Name.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(3, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Type :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(6, 136)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 16)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Current Password :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(6, 98)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 16)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Username :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(3, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 16)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Name :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnU_Search)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(155, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(409, 78)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        '
        'btnU_Search
        '
        Me.btnU_Search.BackColor = System.Drawing.Color.Transparent
        Me.btnU_Search.BackgroundImage = Global.Dep_App.My.Resources.Resources.search
        Me.btnU_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnU_Search.Location = New System.Drawing.Point(341, 14)
        Me.btnU_Search.Name = "btnU_Search"
        Me.btnU_Search.Size = New System.Drawing.Size(58, 50)
        Me.btnU_Search.TabIndex = 1
        Me.btnU_Search.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(13, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 16)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Username :"
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(15, 35)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(320, 26)
        Me.txtSearch.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BackgroundImage = Global.Dep_App.My.Resources.Resources.x_button
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(569, 7)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(32, 27)
        Me.btnClose.TabIndex = 21
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(624, 536)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmUser"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnA_Add As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnA_Save As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtA_confirmpass As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbA_Type As System.Windows.Forms.ComboBox
    Friend WithEvents txtA_Pass As System.Windows.Forms.TextBox
    Friend WithEvents txtA_username As System.Windows.Forms.TextBox
    Friend WithEvents txtA_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtU_NPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbU_Type As System.Windows.Forms.ComboBox
    Friend WithEvents txtU_CurrPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtU_Username As System.Windows.Forms.TextBox
    Friend WithEvents txtU_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnU_Search As System.Windows.Forms.Button
    Friend WithEvents btnU_Clear As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnU_Save As System.Windows.Forms.Button
    Friend WithEvents lblU_Save As System.Windows.Forms.Label
    Friend WithEvents txtU_ConPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Label
    Friend WithEvents btnU_Update As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
