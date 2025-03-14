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
        Me.ListMain = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txts = New System.Windows.Forms.TextBox()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.ListDriver = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ListMain
        '
        Me.ListMain.Font = New System.Drawing.Font("AngsanaUPC", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListMain.FormattingEnabled = True
        Me.ListMain.ItemHeight = 26
        Me.ListMain.Location = New System.Drawing.Point(8, 8)
        Me.ListMain.Margin = New System.Windows.Forms.Padding(0)
        Me.ListMain.Name = "ListMain"
        Me.ListMain.Size = New System.Drawing.Size(543, 82)
        Me.ListMain.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("AngsanaUPC", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Cyan
        Me.Label1.Location = New System.Drawing.Point(12, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 27)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ค้นหา"
        '
        'txts
        '
        Me.txts.Font = New System.Drawing.Font("AngsanaUPC", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txts.Location = New System.Drawing.Point(62, 109)
        Me.txts.Name = "txts"
        Me.txts.Size = New System.Drawing.Size(340, 29)
        Me.txts.TabIndex = 2
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.Color.SpringGreen
        Me.cmdAdd.Font = New System.Drawing.Font("AngsanaUPC", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmdAdd.Location = New System.Drawing.Point(408, 111)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(64, 29)
        Me.cmdAdd.TabIndex = 3
        Me.cmdAdd.Text = "เพิ่ม"
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'cmdDel
        '
        Me.cmdDel.BackColor = System.Drawing.Color.SpringGreen
        Me.cmdDel.Font = New System.Drawing.Font("AngsanaUPC", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDel.ForeColor = System.Drawing.Color.MediumBlue
        Me.cmdDel.Location = New System.Drawing.Point(478, 111)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(64, 29)
        Me.cmdDel.TabIndex = 4
        Me.cmdDel.Text = "ลบ"
        Me.cmdDel.UseVisualStyleBackColor = False
        '
        'ListDriver
        '
        Me.ListDriver.Font = New System.Drawing.Font("AngsanaUPC", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListDriver.FormattingEnabled = True
        Me.ListDriver.ItemHeight = 26
        Me.ListDriver.Location = New System.Drawing.Point(8, 149)
        Me.ListDriver.Name = "ListDriver"
        Me.ListDriver.Size = New System.Drawing.Size(541, 550)
        Me.ListDriver.TabIndex = 5
        '
        'Driver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(558, 732)
        Me.Controls.Add(Me.ListDriver)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.txts)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListMain)
        Me.Name = "Driver"
        Me.Text = "Driver"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListMain As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txts As TextBox
    Friend WithEvents cmdAdd As Button
    Friend WithEvents cmdDel As Button
    Friend WithEvents ListDriver As ListBox
End Class
