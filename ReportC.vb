﻿Imports CrystalDecisions.CrystalReports.Engine
Imports Oracle.ManagedDataAccess.Client

Public Class ReportC
    Private Sub cmb1_Click(sender As Object, e As EventArgs) Handles cmb1.Click
        If Not CheckRowSelected() Then
            MsgBox("ยังไม่ได้เลือกข้อมูล")
            Exit Sub
        End If
        str_calllogin = "Bypass1"
        Me.Enabled = False
        Login.Show()
    End Sub

    Private Sub cmb2_Click(sender As Object, e As EventArgs) Handles cmb2.Click
        If Not CheckRowSelected() Then
            MsgBox("ยังไม่ได้เลือกข้อมูล")
            Exit Sub
        End If
        str_calllogin = "Bypass2"
        Me.Enabled = False
        Login.Show()
    End Sub

    Private Sub cmb3_Click(sender As Object, e As EventArgs) Handles cmb3.Click
        If Not CheckRowSelected() Then
            MsgBox("ยังไม่ได้เลือกข้อมูล")
            Exit Sub
        End If
        str_calllogin = "Bypass3"
        Me.Enabled = False
        Login.Show()
    End Sub

    Private Sub cmd1_Click(sender As Object, e As EventArgs) Handles cmd1.Click
        Me.ContextMenuStrip = Me.mBypass1
        Me.ContextMenuStrip.Show(Cursor.Position)
    End Sub

    Private Sub cmd2_Click(sender As Object, e As EventArgs) Handles cmd2.Click
        Me.ContextMenuStrip = Me.mBypass2
        Me.ContextMenuStrip.Show(Cursor.Position)
    End Sub

    Private Sub cmdConfig_Click(sender As Object, e As EventArgs) Handles cmdConfig.Click
        Me.Enabled = False
        Config.Show()
    End Sub

    Private Sub cmdPrint_report_Click(sender As Object, e As EventArgs) Handles cmdPrint_report.Click
        Dim Value1 As String = String.Empty
        Dim Value2 As String = String.Empty

        If op1.Checked Then
            Value1 = "ครั้งที่ 1 "
        ElseIf op2.Checked Then
            Value1 = "ครั้งที่ 2 "
        ElseIf op3.Checked Then
            Value1 = "ครั้งที่ 3 "
        ElseIf op4.Checked Then
            Value1 = "จากวันที่ " & dt1.Value.ToString("dd/MM/yyyy") & " ถึง " & dt2.Value.ToString("dd/MM/yyyy")
        ElseIf op5.Checked Then
            Value1 = " "
        End If

        If op_sort1.Checked Then
            Value2 = "ทะเบียนรถ"
        ElseIf op_sort2.Checked Then
            Value2 = "ชื่อบริษัท"
        ElseIf op_sort3.Checked Then
            Value2 = "วันคงเหลือ"
        End If

        Dim report As New ReportDocument()
        report.Load(AppDomain.CurrentDomain.BaseDirectory & "\REPORT\Truck_Report2.rpt")

        Dim dt As DataTable = QueryTruckCheck()
        report.SetDataSource(dt)
        report.SetParameterValue("str1", Value1)
        report.SetParameterValue("str2", Value2)

        report.PrintToPrinter(1, True, 0, 0)
    End Sub
    Public Enum TruckQueryOptions
        OP1
        OP2
        OP3
        OP4
        OP5
        OP_MONTH
    End Enum

    Public Function GetOP() As TruckQueryOptions
        If op1.Checked Then
            Return TruckQueryOptions.OP1
        ElseIf op2.Checked Then
            Return TruckQueryOptions.OP2
        ElseIf op3.Checked Then
            Return TruckQueryOptions.OP3
        ElseIf op4.Checked Then
            Return TruckQueryOptions.OP4
        ElseIf opMonth.Checked Then
            Return TruckQueryOptions.OP_MONTH
        ElseIf op5.Checked Then
            Return TruckQueryOptions.OP5
        End If
        Throw New Exception("Option Not Select")

    End Function

    Public Function GetStrSort() As String
        If op_sort1.Checked Then
            Return "truck_no"
        ElseIf op_sort2.Checked Then
            Return "company"
        ElseIf op_sort3.Checked Then
            Return "cal_expire"
        End If
        Return ""
    End Function
    Public Function QueryTruckCheck() As DataTable
        Dim STR_SQL As String = String.Empty
        Dim str_sort = GetStrSort()
        Select Case GetOP()
            Case TruckQueryOptions.OP1
                STR_SQL = "SELECT truck_no, company, ROUND(cal_expire - SYSDATE) AS num_date, date1, date2, cal_expire, count_print_auto1, count_print_auto2, " &
                      "count_print_auto3, date_print1, date_print2, date_print3, count_print_manual1, count_print_manual2, count_print_manual3, ack_name1, " &
                      "ack_name2, ack_name3, ack1, ack2, ack3, comment_1, comment_2, comment_3 FROM truck WHERE ROUND(cal_expire - SYSDATE) <= " &
                      "(SELECT num_date1 FROM truck_config) AND ROUND(cal_expire - SYSDATE) > (SELECT num_date2 FROM truck_config) ORDER BY " & str_sort
            Case TruckQueryOptions.OP2
                STR_SQL = "SELECT truck_no, company, ROUND(cal_expire - SYSDATE) AS num_date, date1, date2, cal_expire, count_print_auto1, count_print_auto2, " &
                      "count_print_auto3, date_print1, date_print2, date_print3, count_print_manual1, count_print_manual2, count_print_manual3, ack_name1, " &
                      "ack_name2, ack_name3, ack1, ack2, ack3, comment_1, comment_2, comment_3 FROM truck WHERE ROUND(cal_expire - SYSDATE) <= " &
                      "(SELECT num_date2 FROM truck_config) AND ROUND(cal_expire - SYSDATE) >= 0 ORDER BY " & str_sort
            Case TruckQueryOptions.OP3
                STR_SQL = "SELECT truck_no, company, ROUND(cal_expire - SYSDATE) AS num_date, date1, date2, cal_expire, count_print_auto1, count_print_auto2, " &
                      "count_print_auto3, date_print1, date_print2, date_print3, count_print_manual1, count_print_manual2, count_print_manual3, ack_name1, " &
                      "ack_name2, ack_name3, ack1, ack2, ack3, comment_1, comment_2, comment_3 FROM truck WHERE ROUND(cal_expire - SYSDATE) < 0 ORDER BY " & str_sort
            Case TruckQueryOptions.OP4
                STR_SQL = "SELECT truck_no, company, ROUND(cal_expire - SYSDATE) AS num_date, date1, date2, cal_expire, count_print_auto1, count_print_auto2, " &
                      "count_print_auto3, date_print1, date_print2, date_print3, count_print_manual1, count_print_manual2, count_print_manual3, ack_name1, " &
                      "ack_name2, ack_name3, ack1, ack2, ack3, comment_1, comment_2, comment_3 FROM truck WHERE cal_expire BETWEEN TO_DATE('" & dt1.Value.ToString("dd/MM/yyyy") & "', 'dd/MM/yyyy') AND " &
                      "TO_DATE('" & dt2.Value.ToString("dd/MM/yyyy") & "', 'dd/MM/yyyy') ORDER BY " & str_sort
            Case TruckQueryOptions.OP5
                STR_SQL = "SELECT truck_no, company, ROUND(cal_expire - SYSDATE) AS num_date, date1, date2, cal_expire, count_print_auto1, count_print_auto2, " &
                      "count_print_auto3, date_print1, date_print2, date_print3, count_print_manual1, count_print_manual2, count_print_manual3, ack_name1, " &
                      "ack_name2, ack_name3, ack1, ack2, ack3, comment_1, comment_2, comment_3 FROM truck ORDER BY " & str_sort
            Case TruckQueryOptions.OP_MONTH
                STR_SQL = "SELECT truck_no, company, ROUND(cal_expire - SYSDATE) AS num_date, date1, date2, cal_expire, count_print_auto1, count_print_auto2, " &
                      "count_print_auto3, date_print1, date_print2, date_print3, count_print_manual1, count_print_manual2, count_print_manual3, ack_name1, " &
                      "ack_name2, ack_name3, ack1, ack2, ack3, comment_1, comment_2, comment_3 FROM truck WHERE TO_CHAR(date1, 'MM/yyyy') = '" & dtMonth.Value.ToString("MM/yyyy") & "' ORDER BY " & str_sort
        End Select

        Dim dt As DataTable = ConnMyDB.ExecuteQuery(STR_SQL)
        Return dt

    End Function

    Private Sub cmdVD_Click(sender As Object, e As EventArgs) Handles cmdVD.Click

        Dim rs_report As DataTable = QueryTruckCheck()

        set_header_grd()

        If rs_report.Rows.Count <= 0 Then
            MessageBox.Show("ไม่พบข้อมูลที่ต้องการแสดง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        grdComment.Rows.Clear()
        grdComment.Rows.Add(rs_report.Rows.Count)

        For i As Integer = 0 To rs_report.Rows.Count - 1
            grdComment.Rows(i).Cells(0).Value = i + 1
            grdComment.Rows(i).Cells(1).Value = rs_report.Rows(i)("truck_no")
            grdComment.Rows(i).Cells(2).Value = rs_report.Rows(i)("company")
            grdComment.Rows(i).Cells(3).Value = rs_report.Rows(i)("num_date")
            grdComment.Rows(i).Cells(4).Value = rs_report.Rows(i)("date1")
            grdComment.Rows(i).Cells(5).Value = rs_report.Rows(i)("date2")
            grdComment.Rows(i).Cells(6).Value = rs_report.Rows(i)("cal_expire")
            grdComment.Rows(i).Cells(7).Value = rs_report.Rows(i)("count_print_auto1")
            grdComment.Rows(i).Cells(8).Value = rs_report.Rows(i)("count_print_auto2")
            grdComment.Rows(i).Cells(9).Value = rs_report.Rows(i)("count_print_auto3")
            grdComment.Rows(i).Cells(10).Value = rs_report.Rows(i)("date_print1").ToString()
            grdComment.Rows(i).Cells(11).Value = rs_report.Rows(i)("date_print2").ToString()
            grdComment.Rows(i).Cells(12).Value = rs_report.Rows(i)("date_print3").ToString()
            grdComment.Rows(i).Cells(13).Value = rs_report.Rows(i)("count_print_manual1").ToString()
            grdComment.Rows(i).Cells(14).Value = rs_report.Rows(i)("count_print_manual2").ToString()
            grdComment.Rows(i).Cells(15).Value = rs_report.Rows(i)("count_print_manual3").ToString()
            grdComment.Rows(i).Cells(16).Value = rs_report.Rows(i)("ack_name1").ToString()
            grdComment.Rows(i).Cells(17).Value = rs_report.Rows(i)("ack_name2").ToString()
            grdComment.Rows(i).Cells(18).Value = rs_report.Rows(i)("ack_name3").ToString()
            grdComment.Rows(i).Cells(19).Value = rs_report.Rows(i)("comment_1").ToString()
            grdComment.Rows(i).Cells(20).Value = rs_report.Rows(i)("comment_2").ToString()
            grdComment.Rows(i).Cells(21).Value = rs_report.Rows(i)("comment_3").ToString()
        Next

    End Sub

    Private Sub set_header_grd()
        With grdComment
            .Columns.Clear()
            .Columns.Add("ลำดับ", "ลำดับ")
            .Columns.Add("ทะเบียนรถ", "ทะเบียนรถ")
            .Columns.Add("ชื่อบริษัท", "ชื่อบริษัท")
            .Columns.Add("จำนวนวันที่เหลือ", "จำนวนวันที่เหลือ")
            .Columns.Add("วันที่แจ้งเตือนครั้งที่ 1", "วันที่แจ้งเตือนครั้งที่ 1")
            .Columns.Add("วันที่แจ้งเตือนครั้งที่ 2", "วันที่แจ้งเตือนครั้งที่ 2")
            .Columns.Add("วันที่แจ้งเตือนครั้งที่ 3(หมดอายุ)", "วันที่แจ้งเตือนครั้งที่ 3(หมดอายุ)")
            .Columns.Add("จำนวนที่พิมพ์อัตโนมัติครั้งที่ 1", "จำนวนที่พิมพ์อัตโนมัติครั้งที่ 1")
            .Columns.Add("จำนวนที่พิมพ์อัตโนมัติครั้งที่ 2", "จำนวนที่พิมพ์อัตโนมัติครั้งที่ 2")
            .Columns.Add("จำนวนที่พิมพ์อัตโนมัติครั้งที่ 3", "จำนวนที่พิมพ์อัตโนมัติครั้งที่ 3")
            .Columns.Add("วันที่พิมพ์อัตโนมัติครั้งที่ 1", "วันที่พิมพ์อัตโนมัติครั้งที่ 1")
            .Columns.Add("วันที่พิมพ์อัตโนมัติครั้งที่ 2", "วันที่พิมพ์อัตโนมัติครั้งที่ 2")
            .Columns.Add("วันที่พิมพ์อัตโนมัติครั้งที่ 3", "วันที่พิมพ์อัตโนมัติครั้งที่ 3")
            .Columns.Add("จำนวนที่พิมพ์ซ้ำครั้งที่ 1", "จำนวนที่พิมพ์ซ้ำครั้งที่ 1")
            .Columns.Add("จำนวนที่พิมพ์ซ้ำครั้งที่ 2", "จำนวนที่พิมพ์ซ้ำครั้งที่ 2")
            .Columns.Add("จำนวนที่พิมพ์ซ้ำครั้งที่ 3", "จำนวนที่พิมพ์ซ้ำครั้งที่ 3")
            .Columns.Add("User unlock No.1", "User unlock No.1")
            .Columns.Add("User unlock No.2", "User unlock No.2")
            .Columns.Add("User unlock No.3", "User unlock No.3")
            .Columns.Add("หมายเหตุการปลดล็อคครั้งที่ 1", "หมายเหตุการปลดล็อคครั้งที่ 1")
            .Columns.Add("หมายเหตุการปลดล็อคครั้งที่ 2", "หมายเหตุการปลดล็อคครั้งที่ 2")
            .Columns.Add("หมายเหตุการปลดล็อคครั้งที่ 3", "หมายเหตุการปลดล็อคครั้งที่ 3")
        End With
    End Sub
    Private Sub cmdVR_Click(sender As Object, e As EventArgs) Handles cmdVR.Click
        Dim STR_SQL As String = String.Empty
        Dim str_sort As String = "truck_no"

        If op_sort1.Checked Then
            str_sort = "truck_no"
        ElseIf op_sort2.Checked Then
            str_sort = "company"
        ElseIf op_sort3.Checked Then
            str_sort = "cal_expire"
        End If

        If op1.Checked Then
            STR_SQL = "CREATE OR REPLACE VIEW view_truck_check AS SELECT truck_no, company, ROUND(cal_expire - SYSDATE) AS num_date, date1, date2, cal_expire, count_print_auto1, count_print_auto2, " &
                      "count_print_auto3, date_print1, date_print2, date_print3, count_print_manual1, count_print_manual2, count_print_manual3, ack_name1, " &
                      "ack_name2, ack_name3, ack1, ack2, ack3, comment_1, comment_2, comment_3 FROM truck WHERE ROUND(cal_expire - SYSDATE) <= " &
                      "(SELECT num_date1 FROM truck_config) AND ROUND(cal_expire - SYSDATE) > " &
                      "(SELECT num_date2 FROM truck_config) ORDER BY " & str_sort
        ElseIf op2.Checked Then
            STR_SQL = "CREATE OR REPLACE VIEW view_truck_check AS SELECT truck_no, company, ROUND(cal_expire - SYSDATE) AS num_date, date1, date2, cal_expire, count_print_auto1, count_print_auto2, " &
                      "count_print_auto3, date_print1, date_print2, date_print3, count_print_manual1, count_print_manual2, count_print_manual3, ack_name1, " &
                      "ack_name2, ack_name3, ack1, ack2, ack3, comment_1, comment_2, comment_3 FROM truck WHERE ROUND(cal_expire - SYSDATE) <= (SELECT num_date2 FROM truck_config) AND ROUND(cal_expire - SYSDATE) >= " &
                      "0 ORDER BY " & str_sort
        ElseIf op3.Checked Then
            STR_SQL = "CREATE OR REPLACE VIEW view_truck_check AS SELECT truck_no, company, ROUND(cal_expire - SYSDATE) AS num_date, date1, date2, cal_expire, count_print_auto1, count_print_auto2, " &
                      "count_print_auto3, date_print1, date_print2, date_print3, count_print_manual1, count_print_manual2, count_print_manual3, ack_name1, " &
                      "ack_name2, ack_name3, ack1, ack2, ack3, comment_1, comment_2, comment_3 FROM truck WHERE ROUND(cal_expire - SYSDATE) < 0 ORDER BY " & str_sort
        ElseIf op4.Checked Then
            STR_SQL = "CREATE OR REPLACE VIEW view_truck_check AS SELECT truck_no, company, ROUND(cal_expire - SYSDATE) AS num_date, date1, date2, cal_expire, count_print_auto1, count_print_auto2, " &
                      "count_print_auto3, date_print1, date_print2, date_print3, count_print_manual1, count_print_manual2, count_print_manual3, ack_name1, " &
                      "ack_name2, ack_name3, ack1, ack2, ack3, comment_1, comment_2, comment_3 FROM truck WHERE cal_expire BETWEEN TO_DATE('" & dt1.Value.ToString("dd/MM/yyyy") & "', 'dd/MM/yyyy') AND " &
                      "TO_DATE('" & dt2.Value.ToString("dd/MM/yyyy") & "', 'dd/MM/yyyy') ORDER BY " & str_sort
        ElseIf opMonth.Checked Then
            STR_SQL = "CREATE OR REPLACE VIEW view_truck_check AS SELECT truck_no, company, ROUND(cal_expire - SYSDATE) AS num_date, date1, date2, cal_expire, count_print_auto1, count_print_auto2, " &
                      "count_print_auto3, date_print1, date_print2, date_print3, count_print_manual1, count_print_manual2, count_print_manual3, ack_name1, " &
                      "ack_name2, ack_name3, ack1, ack2, ack3, comment_1, comment_2, comment_3 FROM truck WHERE " &
                      "TO_CHAR(date1, 'MM/yyyy') = '" & dtMonth.Value.ToString("MM/yyyy") & "' ORDER BY " & str_sort
        ElseIf op5.Checked Then
            STR_SQL = "CREATE OR REPLACE VIEW view_truck_check AS SELECT truck_no, company, ROUND(cal_expire - SYSDATE) AS num_date, date1, date2, cal_expire, count_print_auto1, count_print_auto2, " &
                      "count_print_auto3, date_print1, date_print2, date_print3, count_print_manual1, count_print_manual2, count_print_manual3, ack_name1, " &
                      "ack_name2, ack_name3, ack1, ack2, ack3, comment_1, comment_2, comment_3 FROM truck ORDER BY " & str_sort
        End If


        Using cmd As New OracleCommand(STR_SQL, ConnMyDB)
            cmd.ExecuteNonQuery()
        End Using


        Report.Show()
    End Sub

    Private Sub cp1_Click(sender As Object, e As EventArgs) Handles cp1.Click
        Call save_printManual(1)
    End Sub

    Private Sub cp2_Click(sender As Object, e As EventArgs) Handles cp2.Click
        Call save_printManual(2)
    End Sub

    Private Sub cp3_Click(sender As Object, e As EventArgs) Handles cp3.Click
        Call save_printManual(3)
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt1.Value = Now
        dt2.Value = Now
        dtMonth.Value = Now

    End Sub

    Private Sub grdComment_MouseDown(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub mb1_Click(sender As Object, e As EventArgs) Handles mb1.Click
        str_calllogin = "Bypass1"
        Me.Enabled = False
        Login.Show()
    End Sub

    Private Sub mb2_Click(sender As Object, e As EventArgs) Handles mb2.Click
        str_calllogin = "Bypass2"
        Me.Enabled = False
        Login.Show()
    End Sub

    Private Sub mb3_Click(sender As Object, e As EventArgs) Handles mb3.Click
        str_calllogin = "Bypass3"
        Me.Enabled = False
        Login.Show()
    End Sub

    Private Sub opMonth_Click(sender As Object, e As EventArgs) Handles opMonth.Click
        Call lock_fram(2)
    End Sub

    Private Sub P_1_Click(sender As Object, e As EventArgs) Handles P_1.Click
        Call save_printManual(1)
    End Sub

    Private Sub P_2_Click(sender As Object, e As EventArgs) Handles P_2.Click
        Call save_printManual(2)
    End Sub

    Private Sub P_3_Click(sender As Object, e As EventArgs) Handles P_3.Click
        Call save_printManual(3)
    End Sub

    Private Sub save_printManual(STR_S As Integer)
        If Not CheckRowSelected() Then
            MsgBox("ยังไม่ได้เลือกข้อมูล")
            Exit Sub
        End If

        If MessageBox.Show("คุณต้องการพิมพ์ใบแจ้งเตือนครั้งที่ " & STR_S & " ใช้หรือไม่", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
            Exit Sub
        End If

        Dim report As New ReportDocument()
        report.Load(AppDomain.CurrentDomain.BaseDirectory & "\REPORT\TruckAlarm.rpt")

        report.SetParameterValue("str1", STR_S.ToString()) 'ครั้งที่
        report.SetParameterValue("truck_no", Me.grdComment.SelectedRows(0).Cells(1).Value.ToString())  'ทะเบียน
        report.SetParameterValue("c_date", Me.grdComment.SelectedRows(0).Cells(3).Value.ToString())  'จำนวนวันคงเหลือ
        report.SetParameterValue("dates", Me.grdComment.SelectedRows(0).Cells(6).Value.ToString())  'วันหมดอายุ
        report.SetParameterValue("company", Me.grdComment.SelectedRows(0).Cells(2).Value.ToString())  'บริษัทขนส่ง

        report.PrintToPrinter(1, True, 0, 0)

        Dim str_sqls = "UPDATE truck SET COUNT_PRINT_MANUAL" & STR_S & " = COUNT_PRINT_MANUAL" & STR_S & " + 1 WHERE truck_no = '" & Me.grdComment.SelectedRows(0).Cells(1).Value.ToString() & "'"


        Using cmd As New OracleCommand(str_sqls, Module1.ConnMyDB)
            cmd.ExecuteNonQuery()
        End Using

        Call cmdVD_Click(cmdVD, New EventArgs)
    End Sub

    Private Function check_dates() As Boolean
        check_dates = False
        Dim rs_ch As New DataTable
        Dim Statement_ch As String = "SELECT NUM_DATE1, NUM_DATE2 FROM TRUCK_CONFIG"
        Using cmd As New OracleCommand(Statement_ch, Module1.ConnMyDB)
            Using adapter As New OracleDataAdapter(cmd)
                adapter.Fill(rs_ch)
            End Using
        End Using

        If rs_ch.Rows.Count <= 0 Then
            check_dates = True
            MessageBox.Show("กรุณาตรวจสอบการตั้งค่า Config", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return check_dates
        End If

        num_dates1 = If(IsDBNull(rs_ch.Rows(0)("NUM_DATE1")), 0, rs_ch.Rows(0)("NUM_DATE1"))
        num_dates2 = If(IsDBNull(rs_ch.Rows(0)("NUM_DATE2")), 0, rs_ch.Rows(0)("NUM_DATE2"))

        Return check_dates
    End Function

    Public Sub save_bypass(str_c As Integer, str_comment As String)

        Dim str_sqls As String

        If MessageBox.Show("คุณต้องการปลดล็อกการแจ้งเตือนครั้งที่ " & str_c, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
            Exit Sub
        End If

        str_sqls = "UPDATE truck SET ack" & str_c & " = 'Y', ack_name" & str_c & " = '" & Login_Name_frmlogin & "', comment_" & str_c & " = '" & str_comment & "' WHERE truck_no = '" & Me.grdComment.SelectedRows(0).Cells(1).Value.ToString() & "'"


        Using cmd As New OracleCommand(str_sqls, Module1.ConnMyDB)
            cmd.ExecuteNonQuery()
        End Using

        MessageBox.Show("สำเร็จ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call cmdVD_Click(cmdVD, New EventArgs)
    End Sub

    Private Sub op1_Click(sender As Object, e As EventArgs) Handles op1.Click
        Call lock_fram(0)
    End Sub

    Private Sub op2_Click(sender As Object, e As EventArgs) Handles op2.Click
        Call lock_fram(0)
    End Sub

    Private Sub op3_Click(sender As Object, e As EventArgs) Handles op3.Click
        Call lock_fram(0)
    End Sub

    Private Sub op4_Click(sender As Object, e As EventArgs) Handles op4.Click
        Call lock_fram(1)
    End Sub

    Private Sub op5_Click(sender As Object, e As EventArgs) Handles op5.Click
        Call lock_fram(0)
    End Sub

    Private Sub lock_fram(str_status As Integer)
        If str_status = 1 Then
            framTime.Visible = True
            framMonth.Visible = False
        ElseIf str_status = 2 Then
            framTime.Visible = False
            framMonth.Visible = True
        Else
            framTime.Visible = False
            framMonth.Visible = False
        End If
    End Sub

    Private Function CheckRowSelected() As Boolean
        Return grdComment.SelectedRows.Count > 0
    End Function


    Private Sub grdComment_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grdComment.CellMouseUp

        If e.ColumnIndex <> -1 And e.RowIndex <> -1 Then
            grdComment.ClearSelection()
            grdComment.Rows(e.RowIndex).Selected = True
        End If
        If e.Button = MouseButtons.Right Then

            Me.ContextMenuStrip = Me.mBypass
            Me.ContextMenuStrip.Show(Cursor.Position)
        End If
    End Sub
End Class