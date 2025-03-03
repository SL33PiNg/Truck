Imports System.Data.Odbc

Public Class Login
    Public LoginSucceeded As Boolean
    Dim status_from As Boolean

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        status_from = False
        If str_calllogin = "Bypass1" Or str_calllogin = "Bypass2" Or str_calllogin = "Bypass3" Then

        Else
            lbcom.Visible = False
            txtCom.Visible = False

        End If
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If status_from = False Then
            If str_calllogin = "Bypass1" Or str_calllogin = "Bypass2" Or str_calllogin = "Bypass3" Then
                ReportC.Enabled = True
            Else
                Truck.Enabled = True
            End If
        Else
            Truck.Enabled = False
        End If
    End Sub
    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If CHECK_LOGIN_FRM_LOGIN(txtUserName.Text, txtPassword.Text) Then
            LoginSucceeded = True
            Select Case str_calllogin
                Case "add_user"
                    If Not CHECK_PRIORITY(PRIORITY_frmlogin, "EDIT", "ข้อมูลรถบรรทุก LPG") Then
                        MessageBox.Show("สิทธิ์ในการเข้าถึงไม่เพียงพอ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        status_from = False
                        Me.Close()
                        Exit Sub
                    End If
                    status_from = True
                    Driver.Show()
                Case "edit"
                    status_from = False
                    Truck.btnedit_clicks()
                Case "created"
                    status_from = False
                    Truck.btnCreated_clicks()
                Case "deleted"
                    status_from = False
                    Truck.btnDeleted_clicks()
                Case "Bypass1"
                    If String.IsNullOrWhiteSpace(txtCom.Text) Then
                        MessageBox.Show("กรุณาใส่หมายเหตุการปลดล็อก", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    status_from = False
                    ReportC.save_bypass(1, txtCom.Text)
                Case "Bypass2"
                    If String.IsNullOrWhiteSpace(txtCom.Text) Then
                        MessageBox.Show("กรุณาใส่หมายเหตุการปลดล็อก", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    status_from = False
                    ReportC.save_bypass(2, txtCom.Text)
                Case "Bypass3"
                    If String.IsNullOrWhiteSpace(txtCom.Text) Then
                        MessageBox.Show("กรุณาใส่หมายเหตุการปลดล็อก", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    status_from = False
                    ReportC.save_bypass(3, txtCom.Text)
            End Select
            Me.Close()
        Else
            MessageBox.Show("Invalid Password, try again!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Focus()
            txtPassword.SelectAll()
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        ' Set the global var to false to denote a failed login
        LoginSucceeded = False
        status_from = False
        Me.Close()
    End Sub
    Public Function CHECK_LOGIN_FRM_LOGIN(STR_USER As String, STR_PASSWORD As String) As Boolean
        CHECK_LOGIN_FRM_LOGIN = False
        Dim CHECK_RS As OdbcDataReader
        Dim CHECK_Statement As String

        Dim cmd As New OdbcCommand()

        Try
            ConnMyDB.Open()
            CHECK_Statement = "SELECT NAME, GROUP_NAME, PASSWORD_EXPIRE FROM OPERATOR1 WHERE UPPER(USERNAME) = @username AND TRIM(PASSWORD) = @password"
            cmd.Connection = ConnMyDB
            cmd.CommandText = CHECK_Statement
            cmd.Parameters.AddWithValue("@username", STR_USER.ToUpper())
            cmd.Parameters.AddWithValue("@password", Trim(encode(Trim(STR_PASSWORD.ToUpper()))))

            CHECK_RS = cmd.ExecuteReader()

            If Not CHECK_RS.HasRows Then
                Return False
            End If

            CHECK_RS.Read()
            Login_Name_frmlogin = CHECK_RS("NAME").ToString()
            PRIORITY_frmlogin = CHECK_RS("GROUP_NAME").ToString()

            If DateTime.Parse(CHECK_RS("PASSWORD_EXPIRE").ToString()) < DateTime.Now Then
                MessageBox.Show("Password expire", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End
            End If

            CHECK_RS.Close()
            CHECK_LOGIN_FRM_LOGIN = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ConnMyDB.Close()
        End Try

        Return CHECK_LOGIN_FRM_LOGIN
    End Function
End Class