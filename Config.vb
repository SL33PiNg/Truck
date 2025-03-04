Imports Oracle.ManagedDataAccess.Client

Public Class Config
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If MessageBox.Show("คุณต้องการบันทึกการเปลี่ยนแปลงการกำหนดค่าวันแจ้งเตือนใช้หรือไม่", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
            Exit Sub
        End If

        Using transaction As OracleTransaction = ConnMyDB.BeginTransaction()
            Try
                Dim cmd As New OracleCommand("UPDATE truck_config SET num_date1 = :num_date1, num_date2 = :num_date2", ConnMyDB)
                cmd.BindByName = True
                cmd.Parameters.Add("num_date1", Val(txt1.Text))
                cmd.Parameters.Add("num_date2", Val(txt2.Text))
                cmd.Transaction = transaction
                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE truck SET date1 = CAL_EXPIRE - :date1, date2 = CAL_EXPIRE - :date2"
                cmd.Parameters.Clear()
                cmd.BindByName = True
                cmd.Parameters.Add("date1", Val(txt1.Text))
                cmd.Parameters.Add("date2", Val(txt2.Text))
                cmd.Transaction = transaction
                cmd.ExecuteNonQuery()

                transaction.Commit()
                MessageBox.Show("สำเร็จ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub frmConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not check_dates() Then
            txt1.Text = Module1.num_dates1.ToString()
            txt2.Text = Module1.num_dates2.ToString()
        Else
            txt1.Text = "0"
            txt2.Text = "0"
        End If
    End Sub

    Private Sub frmConfig_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ReportC.Enabled = True
    End Sub

    Private Function check_dates() As Boolean
        Dim _check_dates As Boolean = False
        Dim rs_ch As OracleDataReader
        Dim Statement_ch As String = "SELECT NUM_DATE1, NUM_DATE2 FROM TRUCK_CONFIG"

        Using cmd As New OracleCommand(Statement_ch, ConnMyDB)
            rs_ch = cmd.ExecuteReader()
            If Not rs_ch.HasRows Then
                _check_dates = True
                MessageBox.Show("กรุณาตรวจสอบการตั้งค่า Config", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return _check_dates
            End If

            If rs_ch.Read() Then
                num_dates1 = If(IsDBNull(rs_ch("NUM_DATE1")), 0, rs_ch("NUM_DATE1"))
                num_dates2 = If(IsDBNull(rs_ch("NUM_DATE2")), 0, rs_ch("NUM_DATE2"))
            End If
        End Using

        Return _check_dates
    End Function
End Class