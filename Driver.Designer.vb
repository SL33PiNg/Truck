<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Driver
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
        ListMain = New ListBox()
        Label1 = New Label()
        txts = New TextBox()
        cmdAdd = New Button()
        cmdDel = New Button()
        ListDriver = New ListBox()
        SuspendLayout()
        ' 
        ' ListMain
        ' 
        ListMain.Font = New Font("AngsanaUPC", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListMain.FormattingEnabled = True
        ListMain.Location = New Point(9, 9)
        ListMain.Margin = New Padding(0)
        ListMain.Name = "ListMain"
        ListMain.Size = New Size(633, 108)
        ListMain.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("AngsanaUPC", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(9, 139)
        Label1.Name = "Label1"
        Label1.Size = New Size(44, 27)
        Label1.TabIndex = 1
        Label1.Text = "ค้นหา"
        ' 
        ' txts
        ' 
        txts.Font = New Font("AngsanaUPC", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txts.Location = New Point(59, 137)
        txts.Name = "txts"
        txts.Size = New Size(411, 29)
        txts.TabIndex = 2
        ' 
        ' cmdAdd
        ' 
        cmdAdd.Font = New Font("AngsanaUPC", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmdAdd.Location = New Point(476, 138)
        cmdAdd.Name = "cmdAdd"
        cmdAdd.Size = New Size(75, 28)
        cmdAdd.TabIndex = 3
        cmdAdd.Text = "เพิ่ม"
        cmdAdd.UseVisualStyleBackColor = True
        ' 
        ' cmdDel
        ' 
        cmdDel.Font = New Font("AngsanaUPC", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmdDel.Location = New Point(557, 138)
        cmdDel.Name = "cmdDel"
        cmdDel.Size = New Size(75, 28)
        cmdDel.TabIndex = 4
        cmdDel.Text = "ลบ"
        cmdDel.UseVisualStyleBackColor = True
        ' 
        ' ListDriver
        ' 
        ListDriver.Font = New Font("AngsanaUPC", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListDriver.FormattingEnabled = True
        ListDriver.Location = New Point(9, 172)
        ListDriver.Name = "ListDriver"
        ListDriver.Size = New Size(630, 654)
        ListDriver.TabIndex = 5
        ' 
        ' Driver
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(651, 845)
        Controls.Add(ListDriver)
        Controls.Add(cmdDel)
        Controls.Add(cmdAdd)
        Controls.Add(txts)
        Controls.Add(Label1)
        Controls.Add(ListMain)
        Name = "Driver"
        Text = "Driver"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListMain As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txts As TextBox
    Friend WithEvents cmdAdd As Button
    Friend WithEvents cmdDel As Button
    Friend WithEvents ListDriver As ListBox
End Class
