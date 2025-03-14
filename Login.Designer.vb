<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lbCom = New System.Windows.Forms.Label()
        Me.txtCom = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("AngsanaUPC", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Cyan
        Me.Label1.Location = New System.Drawing.Point(10, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("AngsanaUPC", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Cyan
        Me.Label2.Location = New System.Drawing.Point(10, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 33)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password:"
        '
        'txtUserName
        '
        Me.txtUserName.Font = New System.Drawing.Font("AngsanaUPC", 14.25!)
        Me.txtUserName.Location = New System.Drawing.Point(92, 5)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(155, 33)
        Me.txtUserName.TabIndex = 2
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("AngsanaUPC", 14.25!)
        Me.txtPassword.Location = New System.Drawing.Point(92, 45)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(155, 33)
        Me.txtPassword.TabIndex = 3
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.SpringGreen
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.Blue
        Me.cmdOK.Location = New System.Drawing.Point(91, 88)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 29)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.SpringGreen
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Blue
        Me.cmdCancel.Location = New System.Drawing.Point(172, 88)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 29)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'lbCom
        '
        Me.lbCom.AutoSize = True
        Me.lbCom.BackColor = System.Drawing.Color.Black
        Me.lbCom.Font = New System.Drawing.Font("AngsanaUPC", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCom.ForeColor = System.Drawing.Color.Cyan
        Me.lbCom.Location = New System.Drawing.Point(316, 8)
        Me.lbCom.Name = "lbCom"
        Me.lbCom.Size = New System.Drawing.Size(161, 33)
        Me.lbCom.TabIndex = 6
        Me.lbCom.Text = "หมายเหตุการปลดล็อก"
        '
        'txtCom
        '
        Me.txtCom.Location = New System.Drawing.Point(265, 39)
        Me.txtCom.Multiline = True
        Me.txtCom.Name = "txtCom"
        Me.txtCom.Size = New System.Drawing.Size(243, 70)
        Me.txtCom.TabIndex = 7
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(516, 129)
        Me.Controls.Add(Me.txtCom)
        Me.Controls.Add(Me.lbCom)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents lbCom As Label
    Friend WithEvents txtCom As TextBox
End Class
