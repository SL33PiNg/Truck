<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchTruck
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
        Label1 = New Label()
        cbTypeSearch = New ComboBox()
        GroupBox3 = New GroupBox()
        txtSearch_Truck = New TextBox()
        cmdSearch = New Button()
        dg = New DataGridView()
        PictureBox1 = New PictureBox()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        CType(dg, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = SystemColors.AppWorkspace
        GroupBox1.Controls.Add(GroupBox3)
        GroupBox1.Controls.Add(GroupBox2)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(776, 119)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "ค้นหาข้อมูลรถบรรทุกก๊าซ"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(cbTypeSearch)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Location = New Point(6, 35)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(275, 67)
        GroupBox2.TabIndex = 0
        GroupBox2.TabStop = False
        GroupBox2.Text = "รูปแบบการค้นหา"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 32)
        Label1.Name = "Label1"
        Label1.Size = New Size(55, 14)
        Label1.TabIndex = 0
        Label1.Text = "ค้นหาจาก"
        ' 
        ' cbTypeSearch
        ' 
        cbTypeSearch.FormattingEnabled = True
        cbTypeSearch.Location = New Point(67, 29)
        cbTypeSearch.Name = "cbTypeSearch"
        cbTypeSearch.Size = New Size(202, 22)
        cbTypeSearch.TabIndex = 1
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(cmdSearch)
        GroupBox3.Controls.Add(txtSearch_Truck)
        GroupBox3.Location = New Point(307, 35)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(463, 67)
        GroupBox3.TabIndex = 2
        GroupBox3.TabStop = False
        GroupBox3.Text = "ข้อมูลที่ต้องการค้นหา"
        ' 
        ' txtSearch_Truck
        ' 
        txtSearch_Truck.Location = New Point(6, 29)
        txtSearch_Truck.Name = "txtSearch_Truck"
        txtSearch_Truck.Size = New Size(370, 22)
        txtSearch_Truck.TabIndex = 0
        ' 
        ' cmdSearch
        ' 
        cmdSearch.Location = New Point(382, 29)
        cmdSearch.Name = "cmdSearch"
        cmdSearch.Size = New Size(75, 23)
        cmdSearch.TabIndex = 1
        cmdSearch.Text = "ค้นหา"
        cmdSearch.UseVisualStyleBackColor = True
        ' 
        ' dg
        ' 
        dg.AllowUserToAddRows = False
        dg.AllowUserToDeleteRows = False
        dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dg.Location = New Point(12, 137)
        dg.Name = "dg"
        dg.ReadOnly = True
        dg.Size = New Size(776, 384)
        dg.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        'PictureBox1.Image = My.Resources.Resources.searchTruck
        PictureBox1.Location = New Point(1, -1)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(801, 535)
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' SearchTruck
        ' 
        AutoScaleDimensions = New SizeF(7F, 14F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 533)
        Controls.Add(dg)
        Controls.Add(GroupBox1)
        Controls.Add(PictureBox1)
        Font = New Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "SearchTruck"
        Text = "ค้นหาข้อมูลรถบรรทุกก๊าซ"
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        CType(dg, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmdSearch As Button
    Friend WithEvents txtSearch_Truck As TextBox
    Friend WithEvents cbTypeSearch As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dg As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
End Class
