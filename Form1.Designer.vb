<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GBin = New System.Windows.Forms.TextBox()
        Me.BIG5in = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ZMTGB = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ZMTBIG5 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.XGBIG5 = New System.Windows.Forms.RadioButton()
        Me.XGGB = New System.Windows.Forms.RadioButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GBFile = New System.Windows.Forms.Button()
        Me.BIG5File = New System.Windows.Forms.Button()
        Me.OutFile = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Out = New System.Windows.Forms.TextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Detail = New System.Windows.Forms.Button()
        Me.DetailText = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("微软雅黑", 15.0!)
        Me.Button1.Location = New System.Drawing.Point(335, 230)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 52)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "懒癌发作"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GBin
        '
        Me.GBin.Font = New System.Drawing.Font("微软雅黑", 10.0!)
        Me.GBin.Location = New System.Drawing.Point(96, 32)
        Me.GBin.Name = "GBin"
        Me.GBin.Size = New System.Drawing.Size(645, 29)
        Me.GBin.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.GBin, "可使用单个""*""代替任何文本")
        '
        'BIG5in
        '
        Me.BIG5in.Font = New System.Drawing.Font("微软雅黑", 10.0!)
        Me.BIG5in.Location = New System.Drawing.Point(96, 95)
        Me.BIG5in.Name = "BIG5in"
        Me.BIG5in.Size = New System.Drawing.Size(645, 29)
        Me.BIG5in.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.BIG5in, "可使用单个""*""代替任何文本")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(26, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 27)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "GB:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(26, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 27)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "BIG5:"
        '
        'ZMTGB
        '
        Me.ZMTGB.AutoSize = True
        Me.ZMTGB.Checked = True
        Me.ZMTGB.Location = New System.Drawing.Point(17, 24)
        Me.ZMTGB.Name = "ZMTGB"
        Me.ZMTGB.Size = New System.Drawing.Size(50, 24)
        Me.ZMTGB.TabIndex = 5
        Me.ZMTGB.TabStop = True
        Me.ZMTGB.Text = "GB"
        Me.ZMTGB.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ZMTBIG5)
        Me.GroupBox1.Controls.Add(Me.ZMTGB)
        Me.GroupBox1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(21, 206)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(153, 54)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "字幕头"
        '
        'ZMTBIG5
        '
        Me.ZMTBIG5.AutoSize = True
        Me.ZMTBIG5.Location = New System.Drawing.Point(73, 24)
        Me.ZMTBIG5.Name = "ZMTBIG5"
        Me.ZMTBIG5.Size = New System.Drawing.Size(63, 24)
        Me.ZMTBIG5.TabIndex = 6
        Me.ZMTBIG5.TabStop = True
        Me.ZMTBIG5.Text = "BIG5"
        Me.ZMTBIG5.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.XGBIG5)
        Me.GroupBox2.Controls.Add(Me.XGGB)
        Me.GroupBox2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(180, 206)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(149, 54)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "字幕效果"
        '
        'XGBIG5
        '
        Me.XGBIG5.AutoSize = True
        Me.XGBIG5.Location = New System.Drawing.Point(73, 24)
        Me.XGBIG5.Name = "XGBIG5"
        Me.XGBIG5.Size = New System.Drawing.Size(63, 24)
        Me.XGBIG5.TabIndex = 6
        Me.XGBIG5.Text = "BIG5"
        Me.XGBIG5.UseVisualStyleBackColor = True
        '
        'XGGB
        '
        Me.XGGB.AutoSize = True
        Me.XGGB.Checked = True
        Me.XGGB.Location = New System.Drawing.Point(17, 24)
        Me.XGGB.Name = "XGGB"
        Me.XGGB.Size = New System.Drawing.Size(50, 24)
        Me.XGGB.TabIndex = 5
        Me.XGGB.TabStop = True
        Me.XGGB.Text = "GB"
        Me.XGGB.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GBFile
        '
        Me.GBFile.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GBFile.Location = New System.Drawing.Point(747, 28)
        Me.GBFile.Name = "GBFile"
        Me.GBFile.Size = New System.Drawing.Size(51, 34)
        Me.GBFile.TabIndex = 8
        Me.GBFile.Text = "..."
        Me.ToolTip1.SetToolTip(Me.GBFile, "单击右键以打开该文件")
        Me.GBFile.UseVisualStyleBackColor = True
        '
        'BIG5File
        '
        Me.BIG5File.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BIG5File.Location = New System.Drawing.Point(747, 91)
        Me.BIG5File.Name = "BIG5File"
        Me.BIG5File.Size = New System.Drawing.Size(51, 34)
        Me.BIG5File.TabIndex = 9
        Me.BIG5File.Text = "..."
        Me.ToolTip1.SetToolTip(Me.BIG5File, "单击右键以打开该文件")
        Me.BIG5File.UseVisualStyleBackColor = True
        '
        'OutFile
        '
        Me.OutFile.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OutFile.Location = New System.Drawing.Point(747, 153)
        Me.OutFile.Name = "OutFile"
        Me.OutFile.Size = New System.Drawing.Size(51, 34)
        Me.OutFile.TabIndex = 12
        Me.OutFile.Text = "..."
        Me.ToolTip1.SetToolTip(Me.OutFile, "单击右键以打开该文件")
        Me.OutFile.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(26, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 27)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "输出："
        '
        'Out
        '
        Me.Out.Font = New System.Drawing.Font("微软雅黑", 10.0!)
        Me.Out.Location = New System.Drawing.Point(96, 157)
        Me.Out.Name = "Out"
        Me.Out.Size = New System.Drawing.Size(645, 29)
        Me.Out.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.Out, "可使用单个""*""代替任何文本")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 270)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(197, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "ver 1.4.1     By _Thomasys-"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 0
        '
        'Detail
        '
        Me.Detail.Location = New System.Drawing.Point(693, 270)
        Me.Detail.Name = "Detail"
        Me.Detail.Size = New System.Drawing.Size(105, 33)
        Me.Detail.TabIndex = 14
        Me.Detail.Text = "▼显示详情"
        Me.Detail.UseVisualStyleBackColor = True
        Me.Detail.Visible = False
        '
        'DetailText
        '
        Me.DetailText.BackColor = System.Drawing.Color.White
        Me.DetailText.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DetailText.Location = New System.Drawing.Point(0, 314)
        Me.DetailText.Multiline = True
        Me.DetailText.Name = "DetailText"
        Me.DetailText.ReadOnly = True
        Me.DetailText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DetailText.Size = New System.Drawing.Size(798, 357)
        Me.DetailText.TabIndex = 15
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 729)
        Me.Controls.Add(Me.DetailText)
        Me.Controls.Add(Me.Detail)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Out)
        Me.Controls.Add(Me.OutFile)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BIG5File)
        Me.Controls.Add(Me.GBFile)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BIG5in)
        Me.Controls.Add(Me.GBin)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(8192, 1080)
        Me.MinimumSize = New System.Drawing.Size(580, 349)
        Me.Name = "Form1"
        Me.Text = "字幕替换"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents GBin As TextBox
    Friend WithEvents BIG5in As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ZMTGB As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ZMTBIG5 As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents XGBIG5 As RadioButton
    Friend WithEvents XGGB As RadioButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GBFile As Button
    Friend WithEvents BIG5File As Button
    Friend WithEvents OutFile As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Out As TextBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Detail As Button
    Friend WithEvents DetailText As TextBox
End Class
