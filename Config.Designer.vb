<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Config
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
        Label1 = New Label()
        Label2 = New Label()
        txt1 = New TextBox()
        txt2 = New TextBox()
        Label3 = New Label()
        Label4 = New Label()
        cmdSave = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("AngsanaUPC", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(246, 33)
        Label1.TabIndex = 0
        Label1.Text = "จำนวนวันก่อนการแจ้งเตือนครั้งที่ 1"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("AngsanaUPC", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(12, 56)
        Label2.Name = "Label2"
        Label2.Size = New Size(246, 33)
        Label2.TabIndex = 1
        Label2.Text = "จำนวนวันก่อนการแจ้งเตือนครั้งที่ 2"
        ' 
        ' txt1
        ' 
        txt1.Font = New Font("AngsanaUPC", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txt1.Location = New Point(264, 9)
        txt1.Name = "txt1"
        txt1.Size = New Size(100, 40)
        txt1.TabIndex = 2
        ' 
        ' txt2
        ' 
        txt2.Font = New Font("AngsanaUPC", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txt2.Location = New Point(264, 53)
        txt2.Name = "txt2"
        txt2.Size = New Size(100, 40)
        txt2.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("AngsanaUPC", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(370, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(35, 33)
        Label3.TabIndex = 4
        Label3.Text = "วัน"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("AngsanaUPC", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(370, 56)
        Label4.Name = "Label4"
        Label4.Size = New Size(35, 33)
        Label4.TabIndex = 5
        Label4.Text = "วัน"
        ' 
        ' cmdSave
        ' 
        cmdSave.Font = New Font("AngsanaUPC", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmdSave.Location = New Point(289, 112)
        cmdSave.Name = "cmdSave"
        cmdSave.Size = New Size(75, 37)
        cmdSave.TabIndex = 6
        cmdSave.Text = "บันทึก"
        cmdSave.UseVisualStyleBackColor = True
        ' 
        ' Config
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(421, 162)
        Controls.Add(cmdSave)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(txt2)
        Controls.Add(txt1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Config"
        Text = "ตั้งค่าวันแจ้งเตือนวันหมดอายุปล.2"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txt1 As TextBox
    Friend WithEvents txt2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmdSave As Button
End Class
