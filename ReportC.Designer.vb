<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportC
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.op5 = New System.Windows.Forms.RadioButton()
        Me.opMonth = New System.Windows.Forms.RadioButton()
        Me.op4 = New System.Windows.Forms.RadioButton()
        Me.op3 = New System.Windows.Forms.RadioButton()
        Me.op2 = New System.Windows.Forms.RadioButton()
        Me.op1 = New System.Windows.Forms.RadioButton()
        Me.framTime = New System.Windows.Forms.GroupBox()
        Me.framMonth = New System.Windows.Forms.GroupBox()
        Me.dtMonth = New System.Windows.Forms.DateTimePicker()
        Me.dt2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dt1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.op_sort3 = New System.Windows.Forms.RadioButton()
        Me.op_sort2 = New System.Windows.Forms.RadioButton()
        Me.op_sort1 = New System.Windows.Forms.RadioButton()
        Me.cmdConfig = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdVD = New System.Windows.Forms.Button()
        Me.cmdVR = New System.Windows.Forms.Button()
        Me.cmdPrint_report = New System.Windows.Forms.Button()
        Me.grdComment = New System.Windows.Forms.DataGridView()
        Me.cmd1 = New System.Windows.Forms.Button()
        Me.cmd2 = New System.Windows.Forms.Button()
        Me.mBypass = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Locks = New System.Windows.Forms.ToolStripMenuItem()
        Me.mb1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mb2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mb3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.P_main = New System.Windows.Forms.ToolStripMenuItem()
        Me.P_1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.P_2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.P_3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mBypass1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmb1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmb2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmb3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mBypass2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cp1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cp2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cp3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.framTime.SuspendLayout()
        Me.framMonth.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdComment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mBypass.SuspendLayout()
        Me.mBypass1.SuspendLayout()
        Me.mBypass2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.op5)
        Me.GroupBox1.Controls.Add(Me.opMonth)
        Me.GroupBox1.Controls.Add(Me.op4)
        Me.GroupBox1.Controls.Add(Me.op3)
        Me.GroupBox1.Controls.Add(Me.op2)
        Me.GroupBox1.Controls.Add(Me.op1)
        Me.GroupBox1.Font = New System.Drawing.Font("AngsanaUPC", 15.75!)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 185)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "เลือกรายงาน"
        '
        'op5
        '
        Me.op5.AutoSize = True
        Me.op5.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.op5.Location = New System.Drawing.Point(5, 150)
        Me.op5.Name = "op5"
        Me.op5.Size = New System.Drawing.Size(73, 33)
        Me.op5.TabIndex = 5
        Me.op5.TabStop = True
        Me.op5.Text = "ทั้งหมด"
        Me.op5.UseVisualStyleBackColor = True
        '
        'opMonth
        '
        Me.opMonth.AutoSize = True
        Me.opMonth.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opMonth.Location = New System.Drawing.Point(5, 123)
        Me.opMonth.Name = "opMonth"
        Me.opMonth.Size = New System.Drawing.Size(355, 33)
        Me.opMonth.TabIndex = 4
        Me.opMonth.TabStop = True
        Me.opMonth.Text = "รายงานตามเดือนที่กำหนด ในเงื่อนไขการแจ้งเตื่อนครั้งที่ 1"
        Me.opMonth.UseVisualStyleBackColor = True
        '
        'op4
        '
        Me.op4.AutoSize = True
        Me.op4.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.op4.Location = New System.Drawing.Point(5, 97)
        Me.op4.Name = "op4"
        Me.op4.Size = New System.Drawing.Size(242, 33)
        Me.op4.TabIndex = 3
        Me.op4.TabStop = True
        Me.op4.Text = "รายงานวันหมดอายุวัดน้ำ ตามช่วงเวลา"
        Me.op4.UseVisualStyleBackColor = True
        '
        'op3
        '
        Me.op3.AutoSize = True
        Me.op3.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.op3.Location = New System.Drawing.Point(5, 71)
        Me.op3.Name = "op3"
        Me.op3.Size = New System.Drawing.Size(380, 33)
        Me.op3.TabIndex = 2
        Me.op3.TabStop = True
        Me.op3.Text = "รายงานแสดงรถที่อยู่ในเงื่อนไข การแจ้งเตือนครั้งที่ 3(หมดอายุ)"
        Me.op3.UseVisualStyleBackColor = True
        '
        'op2
        '
        Me.op2.AutoSize = True
        Me.op2.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.op2.Location = New System.Drawing.Point(5, 45)
        Me.op2.Name = "op2"
        Me.op2.Size = New System.Drawing.Size(323, 33)
        Me.op2.TabIndex = 1
        Me.op2.TabStop = True
        Me.op2.Text = "รายงานแสดงรถที่อยู่ในเงื่อนไข การแจ้งเตือนครั้งที่ 2"
        Me.op2.UseVisualStyleBackColor = True
        '
        'op1
        '
        Me.op1.AutoSize = True
        Me.op1.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.op1.Location = New System.Drawing.Point(5, 19)
        Me.op1.Name = "op1"
        Me.op1.Size = New System.Drawing.Size(323, 33)
        Me.op1.TabIndex = 0
        Me.op1.TabStop = True
        Me.op1.Text = "รายงานแสดงรถที่อยู่ในเงื่อนไข การแจ้งเตือนครั้งที่ 1"
        Me.op1.UseVisualStyleBackColor = True
        '
        'framTime
        '
        Me.framTime.Controls.Add(Me.dt2)
        Me.framTime.Controls.Add(Me.Label1)
        Me.framTime.Controls.Add(Me.dt1)
        Me.framTime.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.framTime.Location = New System.Drawing.Point(471, 12)
        Me.framTime.Name = "framTime"
        Me.framTime.Size = New System.Drawing.Size(437, 84)
        Me.framTime.TabIndex = 1
        Me.framTime.TabStop = False
        Me.framTime.Text = "เลือกวันที่"
        '
        'framMonth
        '
        Me.framMonth.Controls.Add(Me.dtMonth)
        Me.framMonth.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.framMonth.Location = New System.Drawing.Point(465, 12)
        Me.framMonth.Name = "framMonth"
        Me.framMonth.Size = New System.Drawing.Size(443, 84)
        Me.framMonth.TabIndex = 3
        Me.framMonth.TabStop = False
        Me.framMonth.Text = "เลือกเดือน"
        '
        'dtMonth
        '
        Me.dtMonth.CustomFormat = "MMMM yyyy"
        Me.dtMonth.Location = New System.Drawing.Point(5, 30)
        Me.dtMonth.Name = "dtMonth"
        Me.dtMonth.Size = New System.Drawing.Size(172, 36)
        Me.dtMonth.TabIndex = 0
        '
        'dt2
        '
        Me.dt2.Location = New System.Drawing.Point(211, 29)
        Me.dt2.Name = "dt2"
        Me.dt2.Size = New System.Drawing.Size(172, 36)
        Me.dt2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(182, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ถึง"
        '
        'dt1
        '
        Me.dt1.Location = New System.Drawing.Point(5, 30)
        Me.dt1.Name = "dt1"
        Me.dt1.Size = New System.Drawing.Size(172, 36)
        Me.dt1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.op_sort3)
        Me.GroupBox3.Controls.Add(Me.op_sort2)
        Me.GroupBox3.Controls.Add(Me.op_sort1)
        Me.GroupBox3.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(465, 99)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(443, 87)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "เรียงตาม"
        '
        'op_sort3
        '
        Me.op_sort3.AutoSize = True
        Me.op_sort3.Location = New System.Drawing.Point(234, 33)
        Me.op_sort3.Name = "op_sort3"
        Me.op_sort3.Size = New System.Drawing.Size(93, 33)
        Me.op_sort3.TabIndex = 2
        Me.op_sort3.TabStop = True
        Me.op_sort3.Text = "วันคงเหลือ"
        Me.op_sort3.UseVisualStyleBackColor = True
        '
        'op_sort2
        '
        Me.op_sort2.AutoSize = True
        Me.op_sort2.Location = New System.Drawing.Point(145, 33)
        Me.op_sort2.Name = "op_sort2"
        Me.op_sort2.Size = New System.Drawing.Size(65, 33)
        Me.op_sort2.TabIndex = 1
        Me.op_sort2.TabStop = True
        Me.op_sort2.Text = "บริษัท"
        Me.op_sort2.UseVisualStyleBackColor = True
        '
        'op_sort1
        '
        Me.op_sort1.AutoSize = True
        Me.op_sort1.Location = New System.Drawing.Point(27, 33)
        Me.op_sort1.Name = "op_sort1"
        Me.op_sort1.Size = New System.Drawing.Size(93, 33)
        Me.op_sort1.TabIndex = 0
        Me.op_sort1.TabStop = True
        Me.op_sort1.Text = "ทะเบียนรถ"
        Me.op_sort1.UseVisualStyleBackColor = True
        '
        'cmdConfig
        '
        Me.cmdConfig.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConfig.Location = New System.Drawing.Point(10, 200)
        Me.cmdConfig.Name = "cmdConfig"
        Me.cmdConfig.Size = New System.Drawing.Size(147, 33)
        Me.cmdConfig.TabIndex = 3
        Me.cmdConfig.Text = "ตั้งค่าวันแจ้งเตือน"
        Me.cmdConfig.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(163, 198)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "หมายเหตุ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(163, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(367, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "เลือกรายการที่ต้องการ แล้วทำการคลิ๊กขวาที่รายการนั้น ๆ เพื่อดำเนินการต่อไป"
        '
        'cmdVD
        '
        Me.cmdVD.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVD.Location = New System.Drawing.Point(636, 192)
        Me.cmdVD.Name = "cmdVD"
        Me.cmdVD.Size = New System.Drawing.Size(82, 38)
        Me.cmdVD.TabIndex = 6
        Me.cmdVD.Text = "View display"
        Me.cmdVD.UseVisualStyleBackColor = True
        '
        'cmdVR
        '
        Me.cmdVR.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVR.Location = New System.Drawing.Point(723, 192)
        Me.cmdVR.Name = "cmdVR"
        Me.cmdVR.Size = New System.Drawing.Size(82, 38)
        Me.cmdVR.TabIndex = 7
        Me.cmdVR.Text = "View report"
        Me.cmdVR.UseVisualStyleBackColor = True
        '
        'cmdPrint_report
        '
        Me.cmdPrint_report.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint_report.Location = New System.Drawing.Point(811, 192)
        Me.cmdPrint_report.Name = "cmdPrint_report"
        Me.cmdPrint_report.Size = New System.Drawing.Size(97, 38)
        Me.cmdPrint_report.TabIndex = 8
        Me.cmdPrint_report.Text = "Print report"
        Me.cmdPrint_report.UseVisualStyleBackColor = True
        '
        'grdComment
        '
        Me.grdComment.AllowUserToAddRows = False
        Me.grdComment.AllowUserToDeleteRows = False
        Me.grdComment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdComment.Location = New System.Drawing.Point(10, 238)
        Me.grdComment.Name = "grdComment"
        Me.grdComment.ReadOnly = True
        Me.grdComment.Size = New System.Drawing.Size(898, 442)
        Me.grdComment.TabIndex = 9
        '
        'cmd1
        '
        Me.cmd1.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd1.Location = New System.Drawing.Point(471, 686)
        Me.cmd1.Name = "cmd1"
        Me.cmd1.Size = New System.Drawing.Size(145, 38)
        Me.cmd1.TabIndex = 10
        Me.cmd1.Text = "ปลดล็อกการแจ้งเตือน"
        Me.cmd1.UseVisualStyleBackColor = True
        '
        'cmd2
        '
        Me.cmd2.Font = New System.Drawing.Font("AngsanaUPC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd2.Location = New System.Drawing.Point(621, 686)
        Me.cmd2.Name = "cmd2"
        Me.cmd2.Size = New System.Drawing.Size(130, 38)
        Me.cmd2.TabIndex = 11
        Me.cmd2.Text = "พิมพ์ใบแจ้งเตือน"
        Me.cmd2.UseVisualStyleBackColor = True
        '
        'mBypass
        '
        Me.mBypass.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Locks, Me.P_main})
        Me.mBypass.Name = "ContextMenuStrip1"
        Me.mBypass.Size = New System.Drawing.Size(171, 48)
        Me.mBypass.Text = "menu_bypass"
        '
        'Locks
        '
        Me.Locks.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mb1, Me.mb2, Me.mb3})
        Me.Locks.Name = "Locks"
        Me.Locks.Size = New System.Drawing.Size(170, 22)
        Me.Locks.Text = "ปลดล็อกการแจ้งเตือน"
        '
        'mb1
        '
        Me.mb1.Name = "mb1"
        Me.mb1.Size = New System.Drawing.Size(203, 22)
        Me.mb1.Text = "ปลดล็อกการแจ้งเตือนครั้งที่ 1"
        '
        'mb2
        '
        Me.mb2.Name = "mb2"
        Me.mb2.Size = New System.Drawing.Size(203, 22)
        Me.mb2.Text = "ปลดล็อกการแจ้งเตือนครั้งที่ 2"
        '
        'mb3
        '
        Me.mb3.Name = "mb3"
        Me.mb3.Size = New System.Drawing.Size(203, 22)
        Me.mb3.Text = "ปลดล็อกการแจ้งเตือนครั้งที่ 3"
        '
        'P_main
        '
        Me.P_main.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.P_1, Me.P_2, Me.P_3})
        Me.P_main.Name = "P_main"
        Me.P_main.Size = New System.Drawing.Size(170, 22)
        Me.P_main.Text = "พิมพ์ใบแจ้งเตือน"
        '
        'P_1
        '
        Me.P_1.Name = "P_1"
        Me.P_1.Size = New System.Drawing.Size(182, 22)
        Me.P_1.Text = "พิมพ์ใบแจ้งเตือนครั้งที่ 1"
        '
        'P_2
        '
        Me.P_2.Name = "P_2"
        Me.P_2.Size = New System.Drawing.Size(182, 22)
        Me.P_2.Text = "พิมพ์ใบแจ้งเตือนครั้งที่ 2"
        '
        'P_3
        '
        Me.P_3.Name = "P_3"
        Me.P_3.Size = New System.Drawing.Size(182, 22)
        Me.P_3.Text = "พิมพ์ใบแจ้งเตือนครั้งที่ 3"
        '
        'mBypass1
        '
        Me.mBypass1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmb1, Me.cmb2, Me.cmb3})
        Me.mBypass1.Name = "ContextMenuStrip1"
        Me.mBypass1.Size = New System.Drawing.Size(204, 70)
        '
        'cmb1
        '
        Me.cmb1.Name = "cmb1"
        Me.cmb1.Size = New System.Drawing.Size(203, 22)
        Me.cmb1.Text = "ปลดล็อกการแจ้งเตือนครั้งที่ 1"
        '
        'cmb2
        '
        Me.cmb2.Name = "cmb2"
        Me.cmb2.Size = New System.Drawing.Size(203, 22)
        Me.cmb2.Text = "ปลดล็อกการแจ้งเตือนครั้งที่ 2"
        '
        'cmb3
        '
        Me.cmb3.Name = "cmb3"
        Me.cmb3.Size = New System.Drawing.Size(203, 22)
        Me.cmb3.Text = "ปลดล็อกการแจ้งเตือนครั้งที่ 3"
        '
        'mBypass2
        '
        Me.mBypass2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cp1, Me.cp2, Me.cp3})
        Me.mBypass2.Name = "ContextMenuStrip1"
        Me.mBypass2.Size = New System.Drawing.Size(183, 70)
        Me.mBypass2.Text = "menu_bypass2"
        '
        'cp1
        '
        Me.cp1.Name = "cp1"
        Me.cp1.Size = New System.Drawing.Size(182, 22)
        Me.cp1.Text = "พิมพ์ใบแจ้งเตือนครั้งที่ 1"
        '
        'cp2
        '
        Me.cp2.Name = "cp2"
        Me.cp2.Size = New System.Drawing.Size(182, 22)
        Me.cp2.Text = "พิมพ์ใบแจ้งเตือนครั้งที่ 2"
        '
        'cp3
        '
        Me.cp3.Name = "cp3"
        Me.cp3.Size = New System.Drawing.Size(182, 22)
        Me.cp3.Text = "พิมพ์ใบแจ้งเตือนครั้งที่ 3"
        '
        'ReportC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 734)
        Me.Controls.Add(Me.framMonth)
        Me.Controls.Add(Me.cmd2)
        Me.Controls.Add(Me.cmd1)
        Me.Controls.Add(Me.grdComment)
        Me.Controls.Add(Me.cmdPrint_report)
        Me.Controls.Add(Me.cmdVR)
        Me.Controls.Add(Me.cmdVD)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdConfig)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.framTime)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ReportC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "รายงาน ปล.2"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.framTime.ResumeLayout(False)
        Me.framTime.PerformLayout()
        Me.framMonth.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grdComment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mBypass.ResumeLayout(False)
        Me.mBypass1.ResumeLayout(False)
        Me.mBypass2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents op3 As RadioButton
    Friend WithEvents op2 As RadioButton
    Friend WithEvents op1 As RadioButton
    Friend WithEvents op5 As RadioButton
    Friend WithEvents opMonth As RadioButton
    Friend WithEvents op4 As RadioButton
    Friend WithEvents framTime As GroupBox
    Friend WithEvents dt2 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents dt1 As DateTimePicker
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents op_sort1 As RadioButton
    Friend WithEvents op_sort3 As RadioButton
    Friend WithEvents op_sort2 As RadioButton
    Friend WithEvents cmdConfig As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmdVD As Button
    Friend WithEvents cmdVR As Button
    Friend WithEvents cmdPrint_report As Button
    Friend WithEvents grdComment As DataGridView
    Friend WithEvents cmd1 As Button
    Friend WithEvents cmd2 As Button
    Friend WithEvents mBypass As ContextMenuStrip
    Friend WithEvents Locks As ToolStripMenuItem
    Friend WithEvents mb1 As ToolStripMenuItem
    Friend WithEvents mb2 As ToolStripMenuItem
    Friend WithEvents mb3 As ToolStripMenuItem
    Friend WithEvents mBypass1 As ContextMenuStrip
    Friend WithEvents cmb1 As ToolStripMenuItem
    Friend WithEvents cmb2 As ToolStripMenuItem
    Friend WithEvents cmb3 As ToolStripMenuItem
    Friend WithEvents mBypass2 As ContextMenuStrip
    Friend WithEvents cp1 As ToolStripMenuItem
    Friend WithEvents cp2 As ToolStripMenuItem
    Friend WithEvents cp3 As ToolStripMenuItem
    Friend WithEvents framMonth As GroupBox
    Friend WithEvents dtMonth As DateTimePicker
    Friend WithEvents P_main As ToolStripMenuItem
    Friend WithEvents P_1 As ToolStripMenuItem
    Friend WithEvents P_2 As ToolStripMenuItem
    Friend WithEvents P_3 As ToolStripMenuItem
End Class
