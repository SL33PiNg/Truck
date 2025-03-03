<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SyncData
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
        GroupBox1 = New GroupBox()
        GroupBox2 = New GroupBox()
        GroupBox3 = New GroupBox()
        Label1 = New Label()
        cbTypeSearch = New ComboBox()
        txtSearchData = New TextBox()
        cmdSearch = New Button()
        dg = New DataGridView()
        cmdOK = New Button()
        cmdCancel = New Button()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        CType(dg, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(GroupBox3)
        GroupBox1.Controls.Add(GroupBox2)
        GroupBox1.Location = New Point(12, 11)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(686, 108)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "ค้นหาข้อมูลรถบรรทุกก๊าซ จาก MASTER DATA"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(cbTypeSearch)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Location = New Point(6, 21)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(329, 81)
        GroupBox2.TabIndex = 0
        GroupBox2.TabStop = False
        GroupBox2.Text = "รูปแบบการค้นหา"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(cmdSearch)
        GroupBox3.Controls.Add(txtSearchData)
        GroupBox3.Location = New Point(341, 21)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(339, 81)
        GroupBox3.TabIndex = 1
        GroupBox3.TabStop = False
        GroupBox3.Text = "ข้อมูลที่ต้องการค้นหา"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 38)
        Label1.Name = "Label1"
        Label1.Size = New Size(55, 14)
        Label1.TabIndex = 0
        Label1.Text = "ค้นหาจาก"
        ' 
        ' cbTypeSearch
        ' 
        cbTypeSearch.BackColor = SystemColors.HotTrack
        cbTypeSearch.FormattingEnabled = True
        cbTypeSearch.Location = New Point(67, 35)
        cbTypeSearch.Name = "cbTypeSearch"
        cbTypeSearch.Size = New Size(249, 22)
        cbTypeSearch.TabIndex = 1
        ' 
        ' txtSearchData
        ' 
        txtSearchData.BackColor = SystemColors.HotTrack
        txtSearchData.Location = New Point(6, 35)
        txtSearchData.Name = "txtSearchData"
        txtSearchData.Size = New Size(246, 22)
        txtSearchData.TabIndex = 0
        ' 
        ' cmdSearch
        ' 
        cmdSearch.Location = New Point(258, 34)
        cmdSearch.Name = "cmdSearch"
        cmdSearch.Size = New Size(75, 23)
        cmdSearch.TabIndex = 1
        cmdSearch.Text = "ค้นหา"
        cmdSearch.UseVisualStyleBackColor = True
        ' 
        ' dg
        ' 
        dg.AllowUserToDeleteRows = False
        dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dg.Location = New Point(12, 125)
        dg.Name = "dg"
        dg.ReadOnly = True
        dg.Size = New Size(686, 507)
        dg.TabIndex = 1
        ' 
        ' cmdOK
        ' 
        cmdOK.Location = New Point(541, 640)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New Size(75, 23)
        cmdOK.TabIndex = 2
        cmdOK.Text = "ตกลง"
        cmdOK.UseVisualStyleBackColor = True
        ' 
        ' cmdCancel
        ' 
        cmdCancel.Location = New Point(623, 640)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New Size(75, 23)
        cmdCancel.TabIndex = 3
        cmdCancel.Text = "ยกเลิก"
        cmdCancel.UseVisualStyleBackColor = True
        ' 
        ' SyncData
        ' 
        AutoScaleDimensions = New SizeF(7F, 14F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(710, 675)
        Controls.Add(cmdCancel)
        Controls.Add(cmdOK)
        Controls.Add(dg)
        Controls.Add(GroupBox1)
        Font = New Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "SyncData"
        Text = "ค้นหาข้อมูลรถบรรทุกก๊าซ จาก MASTER DATA"
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        CType(dg, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbTypeSearch As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdSearch As Button
    Friend WithEvents txtSearchData As TextBox
    Friend WithEvents dg As DataGridView
    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdCancel As Button
End Class
