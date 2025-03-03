<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Company
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
        txts = New TextBox()
        ListCompany = New ListBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(1, 13)
        Label1.Name = "Label1"
        Label1.Size = New Size(54, 25)
        Label1.TabIndex = 0
        Label1.Text = "ค้นหา"
        ' 
        ' txts
        ' 
        txts.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txts.Location = New Point(61, 10)
        txts.Name = "txts"
        txts.Size = New Size(443, 33)
        txts.TabIndex = 1
        ' 
        ' ListCompany
        ' 
        ListCompany.FormattingEnabled = True
        ListCompany.Location = New Point(12, 49)
        ListCompany.Name = "ListCompany"
        ListCompany.Size = New Size(492, 619)
        ListCompany.TabIndex = 2
        ' 
        ' Company
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(516, 677)
        Controls.Add(ListCompany)
        Controls.Add(txts)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "Company"
        Text = "ข้อมูลบริษัท"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txts As TextBox
    Friend WithEvents ListCompany As ListBox
End Class
