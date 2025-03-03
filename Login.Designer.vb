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
        Label1 = New Label()
        Label2 = New Label()
        txtUserName = New TextBox()
        txtPassword = New TextBox()
        cmdOK = New Button()
        cmdCancel = New Button()
        lbCom = New Label()
        txtCom = New TextBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("AngsanaUPC", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 4)
        Label1.Name = "Label1"
        Label1.Size = New Size(89, 33)
        Label1.TabIndex = 0
        Label1.Text = "User Name:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("AngsanaUPC", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(12, 50)
        Label2.Name = "Label2"
        Label2.Size = New Size(79, 33)
        Label2.TabIndex = 1
        Label2.Text = "Password:"
        ' 
        ' txtUserName
        ' 
        txtUserName.Font = New Font("AngsanaUPC", 14.25F)
        txtUserName.Location = New Point(107, 6)
        txtUserName.Name = "txtUserName"
        txtUserName.Size = New Size(180, 33)
        txtUserName.TabIndex = 2
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("AngsanaUPC", 14.25F)
        txtPassword.Location = New Point(107, 52)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(180, 33)
        txtPassword.TabIndex = 3
        ' 
        ' cmdOK
        ' 
        cmdOK.Location = New Point(63, 105)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New Size(87, 34)
        cmdOK.TabIndex = 4
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        ' 
        ' cmdCancel
        ' 
        cmdCancel.Location = New Point(176, 105)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New Size(87, 34)
        cmdCancel.TabIndex = 5
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        ' 
        ' lbCom
        ' 
        lbCom.AutoSize = True
        lbCom.Font = New Font("AngsanaUPC", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lbCom.Location = New Point(369, 9)
        lbCom.Name = "lbCom"
        lbCom.Size = New Size(161, 33)
        lbCom.TabIndex = 6
        lbCom.Text = "หมายเหตุการปลดล็อก"
        ' 
        ' txtCom
        ' 
        txtCom.Location = New Point(309, 45)
        txtCom.Multiline = True
        txtCom.Name = "txtCom"
        txtCom.Size = New Size(283, 80)
        txtCom.TabIndex = 7
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(602, 149)
        Controls.Add(txtCom)
        Controls.Add(lbCom)
        Controls.Add(cmdCancel)
        Controls.Add(cmdOK)
        Controls.Add(txtPassword)
        Controls.Add(txtUserName)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Login"
        StartPosition = FormStartPosition.CenterParent
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
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
