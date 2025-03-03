Imports Oracle.ManagedDataAccess.Client

Public Class Driver
    Private Function SP_DATA(ByVal STR_DATA As String) As String
        Dim STRBUFFER As String() = STR_DATA.Split(New String() {"_:_"}, StringSplitOptions.None)
        Return STRBUFFER(0)
    End Function

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Dim Statement As String = "SELECT * FROM RELATION_TRUCK_DRIVER WHERE TRUCK_NO = '" & Truck.txtTruck_No.Text & "' AND DRIVER_NO = '" & SP_DATA(ListDriver.Text) & "'"
        Dim cmd As New OracleCommand(Statement, ConnMyDB)
        BS = cmd.ExecuteReader()
        If BS.HasRows Then
            MessageBox.Show("มีพนักงานขับรถคนนี้ในความสัมพันธ์แล้ว")
            BS.Close()
            Exit Sub
        End If
        BS.Close()

        Dim transaction As OracleTransaction = ConnMyDB.BeginTransaction()
        cmd.Transaction = transaction
        Try
            cmd.CommandText = "INSERT INTO RELATION_TRUCK_DRIVER (TRUCK_NO, DRIVER_NO) VALUES ('" & Truck.txtTruck_No.Text & "','" & SP_DATA(ListDriver.Text) & "')"
            cmd.ExecuteNonQuery()
            transaction.Commit()
        Catch ex As Exception
            transaction.Rollback()
            Throw
        End Try

        Show_Main()
        Truck.Show_Driver()
    End Sub

    Private Sub cmdDel_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        Dim transaction As OracleTransaction = ConnMyDB.BeginTransaction()
        Dim cmd As New OracleCommand("DELETE FROM RELATION_TRUCK_DRIVER WHERE TRUCK_NO = '" & Truck.txtTruck_No.Text & "' AND DRIVER_NO = '" & SP_DATA(ListMain.Text) & "'", ConnMyDB)
        cmd.Transaction = transaction
        Try
            cmd.ExecuteNonQuery()
            transaction.Commit()
        Catch ex As Exception
            transaction.Rollback()
            Throw
        End Try

        Show_Main()
        Truck.Show_Driver()
    End Sub

    'Private Sub frmDriver_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
    '    SetWindowPos(Me.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOACTIVATE Or SWP_SHOWWINDOW Or SWP_NOMOVE Or SWP_NOSIZE)
    'End Sub

    Private Sub Show_Main()
        Dim Statement As String = "SELECT a.*, b.name, b.lastname FROM (SELECT a.truck_no, a.driver_no FROM relation_truck_driver a WHERE a.truck_no='" & Truck.txtTruck_No.Text & "') a INNER JOIN driver b ON a.driver_no = b.driver_no WHERE a.truck_no = '" & Truck.txtTruck_No.Text & "'"
        Dim cmd As New OracleCommand(Statement, ConnMyDB)
        BS = cmd.ExecuteReader()
        If Not BS.HasRows Then
            ListMain.Items.Clear()
            BS.Close()
            Exit Sub
        End If

        ListMain.Items.Clear()
        While BS.Read()
            ListMain.Items.Add(Format(BS("DRIVER_NO"), "#_:_") & BS("NAME") & "  " & BS("LASTNAME"))
        End While
        BS.Close()
    End Sub

    Private Sub Show_Driver(ByVal STR_SQL As String)
        Dim Statement As String = "SELECT * FROM (SELECT DRIVER_NO, NAME || '  ' || LASTNAME NAME_DRIVER FROM DRIVER ORDER BY NAME) WHERE DRIVER_NO IS NOT NULL " & STR_SQL
        Dim cmd As New OracleCommand(Statement, ConnMyDB)
        BS = cmd.ExecuteReader()
        If Not BS.HasRows Then
            ListDriver.Items.Clear()
            BS.Close()
            Exit Sub
        End If

        ListDriver.Items.Clear()
        While BS.Read()
            ListDriver.Items.Add(Format(BS("DRIVER_NO"), "#_:_") & BS("NAME_DRIVER"))
        End While
        BS.Close()
    End Sub

    Private Sub frmDriver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Show_Main()
        Show_Driver("")
        Me.Left = 9800
        Me.Top = 4000
        If Not CHECK_PRIORITY(PRIORITY_frmlogin, "EDIT", "ข้อมูลรถบรรทุก LPG") Then
            MessageBox.Show("สิทธิ์ในการเข้าถึงไม่เพียงพอ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Sub frmDriver_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Truck.Enabled = True
    End Sub

    Private Sub txts_TextChanged(sender As Object, e As EventArgs) Handles txts.TextChanged
        Dim STR_S As String = " AND NAME_DRIVER LIKE '%" & txts.Text & "%' "
        Show_Driver(STR_S)
    End Sub
End Class