Imports System.Text
Imports Oracle.ManagedDataAccess.Client

' filepath: /d:/work/ข้อมูลรถบรรทุกก๊าซ/Truck.vb

Public Class Truck
    Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Private blnNewData As Boolean
    Private num_dates1 As Integer
    Private num_dates2 As Integer
    Private Login_Name_frmlogin As String
    Private PRIORITY_frmlogin As String
    Private p_click As String


    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cal_Date.Value = DateTime.Now
        Cal_Expire.Value = DateTime.Now

        Me.ContextMenuStrip = New ContextMenuStrip()
        Me.Show()

        OptionButton_Click("Cancle")
        Cal_Date.Value = DateTime.Now
        Cal_Expire.Value = DateTime.Now
        If Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1 Then
            MessageBox.Show("โปรแกรมนี้ถูกเปิดใช้งานแล้ว", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        End If
        OpenDataBase()
        'If Not Module1.CHECK_P Then
        '    MessageBox.Show("รหัสการเข้าถึงไม่ถูกต้อง", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End
        'End If
        If Not CHECK_LOGIN() Then
            End
        End If
        If Not CHECK_PRIORITY(PRIORITY, "VIEW", "ข้อมูลรถบรรทุก LPG") Then
            MessageBox.Show("สิทธิ์ในการเข้าถึงไม่เพียงพอ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        End If
        Show_Card()
        Show_Company()
        SetupgrdTruck()
        DisplaygrdTruck()
        ClearForm(Me)
        ClearOption()
    End Sub

    Private Sub cmdReportP_Click(sender As Object, e As EventArgs) Handles cmdReportP.Click
        ReportC.Show()
    End Sub

    Private Sub Image_Add_MouseDown(sender As Object, e As MouseEventArgs) Handles Btn_Add.MouseDown
        p_click = "new"
        If e.Button = MouseButtons.Left Then
            Me.ContextMenuStrip = menu_process
            Me.ContextMenuStrip.Show(Cursor.Position)
        End If
    End Sub

    Private Sub Image_Edit_MouseDown(sender As Object, e As MouseEventArgs) Handles Btn_Edit.MouseDown
        p_click = "edit"
        If e.Button = MouseButtons.Left Then
            Me.ContextMenuStrip = menu_process
            Me.ContextMenuStrip.Show(Cursor.Position)

        End If
    End Sub

    Private Sub menu_manual_Click(sender As Object, e As EventArgs) Handles menu_manual.Click
        If p_click = "new" Then
            If Not OpenDataBaseMasterData() Then
                MessageBox.Show("Connection ปกติ ไม่สามารถทำการสร้างแบบ Manual ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            str_calllogin = "created"
            Me.Enabled = False
            Login.Show()
        ElseIf p_click = "edit" Then
            If String.IsNullOrWhiteSpace(txtTruck_No.Text) Then
                MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการแก้ไข", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            str_calllogin = "edit"
            Me.Enabled = False
            Login.Show()
        End If
    End Sub

    Private Sub menu_sync_Click(sender As Object, e As EventArgs) Handles menu_sync.Click
        If Not OpenDataBaseMasterData() Then
            MessageBox.Show("ไม่สามารถเชื่อมต่อกับ Master Data ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        SyncData.Show()
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If String.IsNullOrWhiteSpace(txtTruck_No.Text) Then
            Exit Sub
        End If
        str_calllogin = "add_user"
        Me.Enabled = False
        Login.Show()
    End Sub

    Private Sub Command1_Click(sender As Object, e As EventArgs) Handles Command1.Click
        Me.Enabled = False
        Company.Show()
    End Sub

    Private Sub Bg_MouseMove(sender As Object, e As MouseEventArgs)
        'OptionButtonMove_Color("Load")
    End Sub

    Private Sub cmdAct_Click(sender As Object, e As EventArgs) Handles cmdAct.Click
        If String.IsNullOrWhiteSpace(txtTruck_No.Text) Then
            MessageBox.Show("กรุณากรอกข้อมูลลงในช่อง รหัสรถบรรทุกก๊าซ ก่อนที่จะกดปุ่มตกลง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        RecordToScreen(txtTruck_No.Text.Trim())
    End Sub

    Private Sub cmdConfirm_Click(sender As Object, e As EventArgs) Handles cmdConfirm.Click
        If String.IsNullOrWhiteSpace(txtTruck_No.Text) Then
            MessageBox.Show("กรุณาเลือกข้อมูลรถบรรทุก", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtUser.Text) Then
            MessageBox.Show("กรุณากรอก Username", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUser.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtPass.Text) Then
            MessageBox.Show("กรุณากรอก Password", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPass.Focus()
            Exit Sub
        End If

        Dim rs As New OracleDataAdapter("SELECT * FROM OPERATOR1 WHERE UPPER(TRIM(username)) = '" & txtUser.Text.Trim().ToUpper() & "' AND TRIM(password) ='" & encode(txtPass.Text.Trim().ToUpper()) & "'", ConnMyDB)
        Dim dt As New DataTable()
        rs.Fill(dt)
        If dt.Rows.Count <= 0 Then
            MessageBox.Show("รหัสยืนยันไม่ถูกต้อง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        PRIORITY_frmlogin = dt.Rows(0)("GROUP_NAME").ToString()
        Login_Name_frmlogin = dt.Rows(0)("NAME").ToString()
        txtConfirm_Name.Text = Login_Name_frmlogin

        If Not CHECK_PRIORITY(PRIORITY_frmlogin, "EDIT", "ข้อมูลรถบรรทุก LPG") Then
            MessageBox.Show("สิทธิ์ในการเข้าถึงไม่เพียงพอ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim op_check As Integer
        If OptBacklist_Yes.Checked Then
            If MessageBox.Show("คุณต้องการ Backlist รถบรรทุกทะเบียน" & txtTruck_No.Text & " ใช้หรือไม่", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Exit Sub
            End If
            If Opt1.Checked Then
                op_check = 1
            ElseIf Opt2.Checked Then
                op_check = 2
            Else
                op_check = 3
            End If
            Dim cmd As New OracleCommand("UPDATE truck SET BLACKLIST='Y', CONFIRM_CODE='" & txtUser.Text.Trim().ToUpper() & "', CONFIRM_NAME='" & txtConfirm_Name.Text & "', BLACKLIST_FROM = '" & op_check & "', BLACKLIST_DETIAL = '" & txtDetial.Text.Trim() & "' WHERE TRUCK_NO = '" & txtTruck_No.Text.Trim() & "'", ConnMyDB)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Backlist สำเร็จ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If MessageBox.Show("คุณต้องการยกเลิก Backlist รถบรรทุกทะเบียน" & txtTruck_No.Text & " ใช้หรือไม่", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Exit Sub
            End If
            Dim cmd As New OracleCommand("UPDATE truck SET BLACKLIST='N', CONFIRM_CODE='" & txtUser.Text.Trim().ToUpper() & "', CONFIRM_NAME='" & txtConfirm_Name.Text & "' WHERE TRUCK_NO = '" & txtTruck_No.Text.Trim() & "'", ConnMyDB)
            cmd.ExecuteNonQuery()
            MessageBox.Show("ยกเลิก Backlist สำเร็จ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    Private Sub SaveData()
        Dim cmd As New OracleCommand()
        cmd.Connection = ConnMyDB
        If blnNewData Then
            cmd.CommandText = "INSERT INTO TRUCK (TRUCK_NO, CREATE_DATE, BLACKLIST, TRUCK_NO_HEAD, TRUCKTANK_NO, TRUCK_LICENSE, CARD_NO, COMPANY, CAL_DATE, CAL_EXPIRE, CAPACITY, CAPACITY_85, VAPOR, WEIGHT, WEIGHT_OIL, TRUCK_TYPE, TRUCK_WEIGHT, REMARK, UPDATE_DATE, CALIBRATION_NO, LAST_UPDATEBY) " _
                                                & "VALUES (:TRUCK_NO, :CREATE_DATE, :BLACKLIST, :TRUCK_NO_HEAD, :TRUCKTANK_NO, :TRUCK_LICENSE, :CARD_NO, :COMPANY, :CAL_DATE, :CAL_EXPIRE, :CAPACITY, :CAPACITY_85, :VAPOR, :WEIGHT, :WEIGHT_OIL, :TRUCK_TYPE, :TRUCK_WEIGHT, :REMARK, :UPDATE_DATE, :CALIBRATION_NO, :LAST_UPDATEBY)"
            cmd.BindByName = True
            cmd.Parameters.Add("TRUCK_NO", txtTruck_No.Text)
            cmd.Parameters.Add("CREATE_DATE", DateTime.Now)
            cmd.Parameters.Add("BLACKLIST", "N")
            cmd.Parameters.Add("TRUCK_NO_HEAD", txtTruck_No_Head.Text)
            cmd.Parameters.Add("TRUCKTANK_NO", txtTruck_No_Tank.Text)
            cmd.Parameters.Add("TRUCK_LICENSE", txtTruck_No_License.Text)
            cmd.Parameters.Add("CARD_NO", txtCard_No.Text)
            cmd.Parameters.Add("COMPANY", txtTruck_Company.Text)
            cmd.Parameters.Add("CAL_DATE", Cal_Date.Value)
            cmd.Parameters.Add("CAL_EXPIRE", Cal_Expire.Value)
            cmd.Parameters.Add("CAPACITY", If(String.IsNullOrEmpty(txtCapacity.Text), 0, txtCapacity.Text))
            cmd.Parameters.Add("CAPACITY_85", If(String.IsNullOrEmpty(txtCapacity_85.Text), 0, txtCapacity_85.Text))
            cmd.Parameters.Add("VAPOR", If(String.IsNullOrEmpty(txtVapor.Text), 0, txtVapor.Text))
            cmd.Parameters.Add("WEIGHT", If(String.IsNullOrEmpty(txtWeight.Text), 0, txtWeight.Text))
            cmd.Parameters.Add("WEIGHT_OIL", If(String.IsNullOrEmpty(txtWeight_Oil.Text), 0, txtWeight_Oil.Text))
            cmd.Parameters.Add("TRUCK_TYPE", If(OptTruck_Cus.Checked, "C", If(OptTruck_Ptt.Checked, "P", "")))
            cmd.Parameters.Add("TRUCK_WEIGHT", If(OptWeight_Lpg.Checked, "L", If(OptWeight_Oil.Checked, "O", If(OptWeight_Other.Checked, "A", ""))))
            cmd.Parameters.Add("REMARK", txtSpecial.Text)
            cmd.Parameters.Add("UPDATE_DATE", DateTime.Now)
            cmd.Parameters.Add("CALIBRATION_NO", txtCalibration.Text)
            cmd.Parameters.Add("LAST_UPDATEBY", Login_Name_frmlogin)
            cmd.ExecuteNonQuery()
            Add_Event_lpg("Truck: User " & Login_Name_frmlogin & " เพิ่มข้อมูล รถบรรทุกก๊าซรหัส : " & txtTruck_No_Head.Text & " ตัวถังทะเบียน : " & txtTruck_No.Text & " ที่เครื่อง : " & get_name_pc(), "No", "PROGRAMS", "No", "No", "สร้าง", 0)
        Else
            cmd.CommandText = "UPDATE TRUCK SET TRUCK_NO_HEAD = :TRUCK_NO_HEAD, TRUCKTANK_NO = :TRUCKTANK_NO, TRUCK_LICENSE = :TRUCK_LICENSE, CARD_NO = :CARD_NO, COMPANY = :COMPANY, CAL_DATE = :CAL_DATE, CAL_EXPIRE = :CAL_EXPIRE, CAPACITY = :CAPACITY, CAPACITY_85 = :CAPACITY_85, VAPOR = :VAPOR, WEIGHT = :WEIGHT, WEIGHT_OIL = :WEIGHT_OIL, TRUCK_TYPE = :TRUCK_TYPE, TRUCK_WEIGHT = :TRUCK_WEIGHT, REMARK = :REMARK, UPDATE_DATE = :UPDATE_DATE, CALIBRATION_NO = :CALIBRATION_NO, LAST_UPDATEBY = :LAST_UPDATEBY WHERE TRUCK_NO = :TRUCK_NO"
            cmd.BindByName = True
            cmd.Parameters.Add("TRUCK_NO_HEAD", txtTruck_No_Head.Text)
            cmd.Parameters.Add("TRUCKTANK_NO", txtTruck_No_Tank.Text)
            cmd.Parameters.Add("TRUCK_LICENSE", txtTruck_No_License.Text)
            cmd.Parameters.Add("CARD_NO", txtCard_No.Text)
            cmd.Parameters.Add("COMPANY", txtTruck_Company.Text)
            cmd.Parameters.Add("CAL_DATE", Cal_Date.Value)
            cmd.Parameters.Add("CAL_EXPIRE", Cal_Expire.Value)
            cmd.Parameters.Add("CAPACITY", If(String.IsNullOrEmpty(txtCapacity.Text), 0, txtCapacity.Text))
            cmd.Parameters.Add("CAPACITY_85", If(String.IsNullOrEmpty(txtCapacity_85.Text), 0, txtCapacity_85.Text))
            cmd.Parameters.Add("VAPOR", If(String.IsNullOrEmpty(txtVapor.Text), 0, txtVapor.Text))
            cmd.Parameters.Add("WEIGHT", If(String.IsNullOrEmpty(txtWeight.Text), 0, txtWeight.Text))
            cmd.Parameters.Add("WEIGHT_OIL", If(String.IsNullOrEmpty(txtWeight_Oil.Text), 0, txtWeight_Oil.Text))
            cmd.Parameters.Add("TRUCK_TYPE", If(OptTruck_Cus.Checked, "C", If(OptTruck_Ptt.Checked, "P", "")))
            cmd.Parameters.Add("TRUCK_WEIGHT", If(OptWeight_Lpg.Checked, "L", If(OptWeight_Oil.Checked, "O", If(OptWeight_Other.Checked, "A", ""))))
            cmd.Parameters.Add("REMARK", txtSpecial.Text)
            cmd.Parameters.Add("UPDATE_DATE", DateTime.Now)
            cmd.Parameters.Add("CALIBRATION_NO", txtCalibration.Text)
            cmd.Parameters.Add("LAST_UPDATEBY", Login_Name_frmlogin)
            cmd.Parameters.Add("TRUCK_NO", txtTruck_No.Text)

            cmd.ExecuteNonQuery()
            Add_Event_lpg("Truck: User " & Login_Name_frmlogin & " แก้ไขข้อมูล รถบรรทุกก๊าซรหัส : " & txtTruck_No_Head.Text & " ตัวถังทะเบียน : " & txtTruck_No.Text & " ที่เครื่อง : " & get_name_pc(), "No", "PROGRAMS", "No", "No", "แก้ไข", 0)
        End If

        MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        cmd.CommandText = "UPDATE card SET truck_no = :truck_no WHERE card_no = :card_no"
        cmd.Parameters.Clear()
        cmd.Parameters.Add("truck_no", txtTruck_No.Text)
        cmd.Parameters.Add("card_no", txtCard_No.Text)
        cmd.ExecuteNonQuery()
        OptionButton_Click("Cancle")

        SetupgrdTruck()
        DisplaygrdTruck()
        ClearForm(Me)
        ClearOption()
        txtCalibration.BackColor = Color.White
        txtCapacity.BackColor = Color.White
        txtTruck_No.BackColor = Color.White
        txtTruck_No_Head.BackColor = Color.White
    End Sub

    Private Function check_dates() As Boolean
        check_dates = False
        Dim rs_ch As New OracleDataAdapter("SELECT NUM_DATE1, NUM_DATE2 FROM TRUCK_CONFIG", ConnMyDB)
        Dim dt As New DataTable()
        rs_ch.Fill(dt)
        If dt.Rows.Count <= 0 Then
            check_dates = True
            MessageBox.Show("กรุณาตรวจสอบการตั้งค่า Config", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If
        num_dates1 = If(IsDBNull(dt.Rows(0)("NUM_DATE1")), 0, dt.Rows(0)("NUM_DATE1"))
        num_dates2 = If(IsDBNull(dt.Rows(0)("NUM_DATE2")), 0, dt.Rows(0)("NUM_DATE2"))
    End Function
    Private Sub SetupgrdTruck()
        With grdTruck
            .Columns.Clear()
            .Rows.Clear()
            .ColumnCount = 24
            .Columns(0).Name = "หมายเลขทะเบียนตัวถัง"
            .Columns(1).Name = "หมายเลขทะเบียนหัวลาก"
            .Columns(2).Name = "เลขที่ถังโยธา"
            .Columns(3).Name = "เลขที่ใบอนุญาติขนส่ง"
            .Columns(4).Name = "หมายเลขบัตร"
            .Columns(5).Name = "หมายเลข พขร."
            .Columns(6).Name = "รถของบริษัท"
            .Columns(7).Name = "Calibration No."
            .Columns(8).Name = "วันที่วัด ปล.2"
            .Columns(9).Name = "วันที่วัดปล.2 ครั้งถัดไป"
            .Columns(10).Name = "ความจุของรถตามปล.2 (Kg.)"
            .Columns(11).Name = "ความจุของรถที่ 85 % (Kg.)"
            .Columns(12).Name = "Vapour Factor (Kg.)"
            .Columns(13).Name = "น้ำหนักรถเปล่า (Kg.)"
            .Columns(14).Name = "น้ำมันค้างถัง (Kg.)"
            .Columns(15).Name = "ชนิดรถ (ขึ้นตาชั่ง)"
            .Columns(16).Name = "ชนิดรถบรรทุกก๊าซ"
            .Columns(17).Name = "Black List"
            .Columns(18).Name = "เหตุผลการ Black List"
            .Columns(19).Name = "ชื่อผู้ยืนยันการ Black List"
            .Columns(20).Name = "หมายเหตุ"
            .Columns(21).Name = "Create Date"
            .Columns(22).Name = "Update Date"
            .Columns(23).Name = "Last update by"
        End With
    End Sub

    Public Sub DisplaygrdTruck()
        Dim col_wid(23) As Single
        Dim r As Integer
        Dim c As Integer
        Dim TotalRec As Integer

        Dim Statement As String = "SELECT * FROM TRUCK ORDER BY TRUCK_NO"
        Dim cmd As New OracleCommand(Statement)
        Dim dt As DataTable = ConnMyDB.ExecuteQuery(Statement)
        TotalRec = dt.Rows.Count

        If TotalRec <= 0 Then
            MsgBox("ยังไม่มีข้อมูลอยู่ในระบบ.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "รายงาน")
            l1.Text = "จำนวนรถบรรทุกก๊าซ : " & TotalRec & "  คัน"
            Exit Sub
        End If

        grdTruck.Rows.Add(TotalRec + 1)
        For i = 0 To TotalRec - 1
            grdTruck.Rows(i).Cells(0).Value = dt.Rows(i)("TRUCK_NO").ToString()
            grdTruck.Rows(i).Cells(1).Value = dt.Rows(i)("TRUCK_NO_HEAD").ToString()
            grdTruck.Rows(i).Cells(2).Value = dt.Rows(i)("TRUCKTANK_NO").ToString()
            grdTruck.Rows(i).Cells(3).Value = dt.Rows(i)("TRUCK_LICENSE").ToString()
            grdTruck.Rows(i).Cells(4).Value = dt.Rows(i)("CARD_NO").ToString()
            grdTruck.Rows(i).Cells(5).Value = dt.Rows(i)("DRIVER_NO").ToString()
            grdTruck.Rows(i).Cells(6).Value = dt.Rows(i)("COMPANY").ToString()
            grdTruck.Rows(i).Cells(7).Value = dt.Rows(i)("CALIBRATION_NO").ToString()
            grdTruck.Rows(i).Cells(8).Value = dt.Rows(i)("CAL_DATE").ToString()
            grdTruck.Rows(i).Cells(9).Value = dt.Rows(i)("CAL_EXPIRE").ToString()
            grdTruck.Rows(i).Cells(10).Value = dt.Rows(i)("CAPACITY").ToString()
            grdTruck.Rows(i).Cells(11).Value = dt.Rows(i)("CAPACITY_85").ToString()
            grdTruck.Rows(i).Cells(12).Value = dt.Rows(i)("VAPOR").ToString()
            grdTruck.Rows(i).Cells(13).Value = dt.Rows(i)("WEIGHT").ToString()
            grdTruck.Rows(i).Cells(14).Value = dt.Rows(i)("WEIGHT_OIL").ToString()

            If dt.Rows(i)("TRUCK_WEIGHT").ToString() = "L" Then
                grdTruck.Rows(i).Cells(15).Value = "รถบรรทุกก๊าซ"
                If dt.Rows(i)("TRUCK_TYPE").ToString() = "C" Then
                    grdTruck.Rows(i).Cells(16).Value = "รถลูกค้ารับเอง"
                ElseIf dt.Rows(i)("TRUCK_TYPE").ToString() = "P" Then
                    grdTruck.Rows(i).Cells(16).Value = "ปตท.จัดส่ง"
                End If
            ElseIf dt.Rows(i)("TRUCK_WEIGHT").ToString() = "O" Then
                grdTruck.Rows(i).Cells(15).Value = "รถบรรทุกน้ำมัน"
                grdTruck.Rows(i).Cells(16).Value = "-"
            ElseIf dt.Rows(i)("TRUCK_WEIGHT").ToString() = "A" Then
                grdTruck.Rows(i).Cells(16).Value = "-"
            Else
                grdTruck.Rows(i).Cells(15).Value = "-"
                grdTruck.Rows(i).Cells(16).Value = "-"
            End If

            If dt.Rows(i)("BLACKLIST").ToString() = "Y" Then
                grdTruck.Rows(i).Cells(17).Value = "Yes"
                If dt.Rows(i)("BLACKLIST_FROM").ToString() = "1" Then
                    grdTruck.Rows(i).Cells(18).Value = "รถสภาพต่ำกว่ามาตรฐาน"
                ElseIf dt.Rows(i)("BLACKLIST_FROM").ToString() = "2" Then
                    grdTruck.Rows(i).Cells(18).Value = "รถปล.2 หมดอายุ"
                ElseIf dt.Rows(i)("BLACKLIST_FROM").ToString() = "3" Then
                    grdTruck.Rows(i).Cells(18).Value = "อื่นๆ"
                End If
            ElseIf dt.Rows(i)("BLACKLIST").ToString() = "N" Then
                grdTruck.Rows(i).Cells(17).Value = "No"
                grdTruck.Rows(i).Cells(18).Value = "-"
            End If

            grdTruck.Rows(i).Cells(19).Value = dt.Rows(i)("CONFIRM_NAME").ToString()
            grdTruck.Rows(i).Cells(20).Value = dt.Rows(i)("REMARK").ToString()
            grdTruck.Rows(i).Cells(21).Value = dt.Rows(i)("CREATE_DATE").ToString()
            grdTruck.Rows(i).Cells(22).Value = dt.Rows(i)("UPDATE_DATE").ToString()
            grdTruck.Rows(i).Cells(23).Value = If(IsDBNull(dt.Rows(i)("LAST_UPDATEBY")), "", dt.Rows(i)("LAST_UPDATEBY").ToString())
        Next

        l1.Text = "จำนวนรถบรรทุกก๊าซ : " & TotalRec & "  คัน"

        For c = 0 To grdTruck.Columns.Count - 1
            For r = 0 To grdTruck.Rows.Count - 1
                col_wid(c) = If(TextRenderer.MeasureText(grdTruck.Rows(r).Cells(c).Value?.ToString(), grdTruck.Font).Width > col_wid(c), TextRenderer.MeasureText(grdTruck.Rows(r).Cells(c).Value?.ToString(), grdTruck.Font).Width, col_wid(c))
            Next
        Next

        For c = 0 To grdTruck.Columns.Count - 1
            grdTruck.Columns(c).Width = col_wid(c) + 240
            grdTruck.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Next
    End Sub

    Public Sub RecordToScreen(ID As String)
        Try
            Dim Statement As String = "SELECT * FROM TRUCK WHERE TRUCK_NO = :TRUCK_NO"
            Dim cmd As New OracleCommand(Statement, ConnMyDB)
            cmd.BindByName = True
            cmd.Parameters.Add("TRUCK_NO", ID)
            Dim rs As New OracleDataAdapter(cmd)
            Dim dt As New DataTable()
            rs.Fill(dt)

            If dt.Rows.Count <= 0 Then
                MsgBox("ไม่พบข้อมูลรถบรรทุกก๊าซรหัส " & ID & " ในระบบ TAS", MsgBoxStyle.Exclamation, "รายงาน")
                Exit Sub
            End If

            Dim row As DataRow = dt.Rows(0)
            txtTruck_No.Text = row("TRUCK_NO").ToString()
            txtTruck_No_Head.Text = row("TRUCK_NO_HEAD").ToString()
            txtTruck_No_Tank.Text = row("TRUCKTANK_NO").ToString()
            txtTruck_No_License.Text = row("TRUCK_LICENSE").ToString()
            txtCard_No.Text = row("CARD_NO").ToString()
            txtTruck_Company.Text = S_Company(row("COMPANY").ToString())

            If IsDBNull(row("CAL_DATE")) Then
                Cal_Date.Value = DateTime.Now
            Else
                Cal_Date.Value = Convert.ToDateTime(row("CAL_DATE"))
            End If

            If IsDBNull(row("CAL_EXPIRE")) Then
                Cal_Expire.Value = DateTime.Now
            Else
                Cal_Expire.Value = Convert.ToDateTime(row("CAL_EXPIRE"))
            End If

            txtCapacity.Text = row("CAPACITY").ToString()
            txtCapacity_85.Text = row("CAPACITY_85").ToString()
            txtVapor.Text = row("VAPOR").ToString()
            txtWeight.Text = row("WEIGHT").ToString()
            txtWeight_Oil.Text = row("WEIGHT_OIL").ToString()

            Select Case row("TRUCK_WEIGHT").ToString()
                Case "L"
                    OptWeight_Lpg.Checked = True
                    OptWeight_Lpg.Font = New Font(OptWeight_Lpg.Font, FontStyle.Bold)
                    OptWeight_Oil.Font = New Font(OptWeight_Oil.Font, FontStyle.Regular)
                    OptWeight_Other.Font = New Font(OptWeight_Other.Font, FontStyle.Regular)
                Case "O"
                    OptWeight_Oil.Checked = True
                    OptWeight_Lpg.Font = New Font(OptWeight_Lpg.Font, FontStyle.Regular)
                    OptWeight_Oil.Font = New Font(OptWeight_Oil.Font, FontStyle.Bold)
                    OptWeight_Other.Font = New Font(OptWeight_Other.Font, FontStyle.Regular)
                Case "A"
                    OptWeight_Other.Checked = True
                    OptWeight_Lpg.Font = New Font(OptWeight_Lpg.Font, FontStyle.Regular)
                    OptWeight_Oil.Font = New Font(OptWeight_Oil.Font, FontStyle.Regular)
                    OptWeight_Other.Font = New Font(OptWeight_Other.Font, FontStyle.Bold)
                Case Else
                    OptWeight_Lpg.Checked = False
                    OptWeight_Oil.Checked = False
                    OptWeight_Other.Checked = False
                    OptWeight_Lpg.Font = New Font(OptWeight_Lpg.Font, FontStyle.Regular)
                    OptWeight_Oil.Font = New Font(OptWeight_Oil.Font, FontStyle.Regular)
                    OptWeight_Other.Font = New Font(OptWeight_Other.Font, FontStyle.Regular)
            End Select

            Select Case row("TRUCK_TYPE").ToString()
                Case "C"
                    OptTruck_Cus.Checked = True
                    OptTruck_Cus.Font = New Font(OptTruck_Cus.Font, FontStyle.Bold)
                    OptTruck_Ptt.Font = New Font(OptTruck_Ptt.Font, FontStyle.Regular)
                Case "P"
                    OptTruck_Ptt.Checked = True
                    OptTruck_Cus.Font = New Font(OptTruck_Cus.Font, FontStyle.Regular)
                    OptTruck_Ptt.Font = New Font(OptTruck_Ptt.Font, FontStyle.Bold)
                Case Else
                    OptTruck_Cus.Checked = False
                    OptTruck_Ptt.Checked = False
                    OptTruck_Cus.Font = New Font(OptTruck_Cus.Font, FontStyle.Regular)
                    OptTruck_Ptt.Font = New Font(OptTruck_Ptt.Font, FontStyle.Regular)
            End Select

            Select Case row("BLACKLIST").ToString()
                Case "Y"
                    OptBacklist_Yes.Checked = True
                    OptBacklist_Yes.Font = New Font(OptBacklist_Yes.Font, FontStyle.Bold)
                    OptBacklist_No.Font = New Font(OptBacklist_No.Font, FontStyle.Regular)
                Case "N"
                    OptBacklist_No.Checked = True
                    OptBacklist_Yes.Font = New Font(OptBacklist_Yes.Font, FontStyle.Regular)
                    OptBacklist_No.Font = New Font(OptBacklist_No.Font, FontStyle.Bold)
                Case Else
                    OptBacklist_Yes.Font = New Font(OptBacklist_Yes.Font, FontStyle.Regular)
                    OptBacklist_No.Font = New Font(OptBacklist_No.Font, FontStyle.Regular)
            End Select

            txtConfirm_Name.Text = row("CONFIRM_NAME").ToString()

            Select Case row("BLACKLIST_FROM").ToString()
                Case "1"
                    Opt1.Checked = True
                Case "2"
                    Opt2.Checked = True
                Case "3"
                    Opt3.Checked = True
            End Select

            txtDetial.Text = row("BLACKLIST_DETIAL").ToString()
            txtSpecial.Text = row("REMARK").ToString()
            txtCreate.Text = row("CREATE_DATE").ToString()
            txtUpdate.Text = row("UPDATE_DATE").ToString()
            txtCalibration.Text = row("CALIBRATION_NO").ToString()
            txtUpdateBy.Text = If(IsDBNull(row("LAST_UPDATEBY")), "", row("LAST_UPDATEBY").ToString())
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub grdTruck_Click(sender As Object, e As EventArgs)
        btnCancel_click()
        RecordToScreen(Trim(grdTruck.Text))
    End Sub

    Private Sub Opt1_Click(sender As Object, e As EventArgs) Handles Opt1.Click
        If Opt1.Checked Then
            OptBacklist_Yes.Checked = True
            txtDetial.Text = ""
        End If
    End Sub

    Private Sub Opt2_Click(sender As Object, e As EventArgs) Handles Opt2.Click
        If Opt2.Checked Then
            OptBacklist_Yes.Checked = True
            txtDetial.Text = ""
        End If
    End Sub

    Private Sub Opt3_Click(sender As Object, e As EventArgs) Handles Opt3.Click
        If Opt3.Checked Then
            txtDetial.Enabled = True
        End If
    End Sub

    Private Sub OptBacklist_No_Click(sender As Object, e As EventArgs) Handles OptBacklist_No.Click
        Opt1.Checked = False
        Opt1.Enabled = False
        Opt2.Checked = False
        Opt2.Enabled = False
        Opt3.Checked = False
        Opt3.Enabled = False
        txtDetial.Text = ""
        set_chk3(2)
    End Sub

    Private Sub OptBacklist_Yes_Click(sender As Object, e As EventArgs) Handles OptBacklist_Yes.Click
        Opt1.Enabled = True
        Opt2.Enabled = True
        Opt3.Enabled = True
        txtDetial.Enabled = True
        set_chk3(1)
    End Sub

    Private Sub OptTruck_Cus_Click(sender As Object, e As EventArgs) Handles OptTruck_Cus.Click
        set_chk2(1)
    End Sub

    Private Sub OptTruck_Ptt_Click(sender As Object, e As EventArgs) Handles OptTruck_Ptt.Click
        set_chk2(2)
    End Sub

    Private Sub OptWeight_Lpg_Click(sender As Object, e As EventArgs) Handles OptWeight_Lpg.Click
        OptTruck_Cus.Enabled = True
        OptTruck_Ptt.Enabled = True
        set_chk1(1)
    End Sub

    Private Sub OptWeight_Oil_Click(sender As Object, e As EventArgs) Handles OptWeight_Oil.Click
        OptTruck_Cus.Enabled = False
        OptTruck_Cus.Checked = False
        OptTruck_Ptt.Enabled = False
        OptTruck_Ptt.Checked = False
        set_chk1(2)
    End Sub

    Private Sub OptWeight_Other_Click(sender As Object, e As EventArgs) Handles OptWeight_Other.Click
        OptTruck_Cus.Enabled = False
        OptTruck_Cus.Checked = False
        OptTruck_Ptt.Enabled = False
        OptTruck_Ptt.Checked = False
        set_chk1(3)
    End Sub

    Private Sub txtCapacity_Change(sender As Object, e As EventArgs) Handles txtCapacity.TextChanged
        txtCapacity_85.Text = Math.Round((Math.Round(If(txtCapacity.Text <> "", Convert.ToDouble(txtCapacity.Text), 0)) / 1.84) * 0.85).ToString()
    End Sub

    Private Sub Check_Code(TRUCK_ID As String)
        Using conn As New OracleConnection("Your Connection String Here")
            Dim cmd As New OracleCommand("SELECT TRUCK_NO FROM oiltruck WHERE (TRUCK_NO = :TRUCK_NO)", conn)
            cmd.BindByName = True
            cmd.Parameters.Add("TRUCK_NO", TRUCK_ID)
            conn.Open()
            Using reader As OracleDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    MessageBox.Show("มีการใช้รหัสพนักงานขับรถนี้ไปแล้ว", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End Using
    End Sub

    Private Function CheckNull(ChkStr As String, MsgStr As String) As Boolean
        If String.IsNullOrEmpty(ChkStr) Then
            MessageBox.Show(MsgStr, "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Image_Save.Enabled = True
            Image_Save.Visible = True
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Show_Card()

        Dim cmd As New OracleCommand("SELECT CARD_NO FROM CARD ORDER BY CARD_NO", ConnMyDB)

        Using reader As OracleDataReader = cmd.ExecuteReader()
            txtCard_No.Items.Clear()
            If Not reader.HasRows Then
                txtCard_No.Items.Add("0")
                Return
            End If
            txtCard_No.Items.Add("0")
            While reader.Read()
                txtCard_No.Items.Add(reader("CARD_NO").ToString())
            End While
        End Using

    End Sub


    Private Function S_Company(STR_COM As String) As String
        Try
            Dim STM As String = "SELECT COMPANY_NAME FROM COMPANY WHERE COMPANY_NAME = :COMPANY_NAME"
            Dim cmd As New OracleCommand(STM, ConnMyDB)
            cmd.BindByName = True
            cmd.Parameters.Add("COMPANY_NAME", STR_COM)
            Dim SCOM As New OracleDataAdapter(cmd)
            Dim dt As New DataTable()
            SCOM.Fill(dt)

            If dt.Rows.Count <= 0 Then
                Return " "
            End If

            Return dt.Rows(0)("COMPANY_NAME").ToString()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
            Return " "
        End Try
    End Function

    Private Sub Show_Company()
        Dim Statement As String = "SELECT COMPANY_NAME FROM COMPANY ORDER BY COMPANY_NAME"
        Dim cmd As New OracleCommand(Statement)

        Dim dt As DataTable = ConnMyDB.ExecuteQuery(cmd)
        If dt.Rows.Count <= 0 Then
            txtTruck_Company.Items.Clear()
            txtTruck_Company.Items.Add(" ")
            Exit Sub
        End If

        txtTruck_Company.Items.Clear()
        txtTruck_Company.Items.Add(" ")
        For Each row As DataRow In dt.Rows
            txtTruck_Company.Items.Add(row("COMPANY_NAME").ToString())
        Next row


        'rs = cmd.ExecuteReader()
        'If Not rs.HasRows Then
        '    txtTruck_Company.Items.Clear()
        '    txtTruck_Company.Items.Add(" ")
        '    Exit Sub
        'End If

        'txtTruck_Company.Items.Clear()
        'txtTruck_Company.Items.Add(" ")
        'While rs.Read()
        '    txtTruck_Company.Items.Add(rs("COMPANY_NAME").ToString())
        'End While
        'rs.Close()
    End Sub

    Public Sub Show_Driver()
        Dim Statement As String = "SELECT a.*, b.name, b.lastname FROM (SELECT a.truck_no, a.driver_no FROM relation_truck_driver a WHERE a.truck_no='" & txtTruck_No.Text & "') a INNER JOIN driver b ON a.driver_no = b.driver_no WHERE a.truck_no = '" & txtTruck_No.Text & "'"
        Dim cmd As New OracleCommand(Statement, ConnMyDB)
        BS = cmd.ExecuteReader()

        If Not BS.HasRows Then
            txtDriver_No.Items.Clear()
            Exit Sub
        End If

        txtDriver_No.Items.Clear()
        While BS.Read()
            txtDriver_No.Items.Add(Format(BS("DRIVER_NO"), "#_:_") & BS("NAME").ToString() & "  " & BS("LASTNAME").ToString())
        End While
        txtDriver_No.Text = txtDriver_No.Items(0).ToString()
        BS.Close()
    End Sub

    Public Sub OptionButton_Click(BCommand As String)
        Select Case BCommand
            Case "Add"
                Image_Cancle.Enabled = True
                Image_Save.Enabled = True
                Btn_Add.Enabled = False
                Btn_Delete.Enabled = False
                Btn_Edit.Enabled = False
                Btn_Print.Enabled = False
                Btn_Search.Enabled = False
            Case "Edit"
                Image_Cancle.Enabled = True
                Image_Save.Enabled = True
                Btn_Add.Enabled = False
                Btn_Print.Enabled = False
                Btn_Search.Enabled = False
                Btn_Delete.Enabled = False
            Case "Delete"
                Btn_Add.Enabled = False
                Btn_Edit.Enabled = False
                Btn_Print.Enabled = False
                Btn_Search.Enabled = False
                Image_Save.Enabled = False
                Image_Cancle.Enabled = True
            Case "Print"
                Btn_Add.Enabled = False
                Btn_Edit.Enabled = False
                Btn_Delete.Enabled = False
                Btn_Search.Enabled = False
                Image_Save.Enabled = False
                Image_Cancle.Enabled = True
            Case "Search"
                Btn_Add.Enabled = False
                Btn_Delete.Enabled = False
                Btn_Edit.Enabled = False
                Btn_Print.Enabled = False
                Image_Save.Enabled = False
                Image_Cancle.Enabled = True
            Case "Save"
                Image_Save.Enabled = False
                Image_Cancle.Enabled = True
                Btn_Add.Enabled = True
                Btn_Edit.Enabled = True
                Btn_Delete.Enabled = True
                Btn_Print.Enabled = True
                Btn_Search.Enabled = True
            Case "Cancle"
                Btn_Add.Enabled = True
                Btn_Edit.Enabled = True
                Btn_Delete.Enabled = True
                Btn_Print.Enabled = True
                Btn_Search.Enabled = True
                Image_Cancle.Enabled = True
                Image_Save.Enabled = False
        End Select
    End Sub

    Public Sub btnCreated_clicks()
        'Btn_Add.Visible = False
        'AddClick.Visible = True
        OptionButton_Click("Add")
        If Not CHECK_PRIORITY(PRIORITY_frmlogin, "CREATED", "ข้อมูลรถบรรทุก LPG") Then
            MessageBox.Show("สิทธิ์ในการเข้าถึงไม่เพียงพอ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Image_Cancle_Click()
            btnCancel_click()
            Exit Sub
        End If
        blnNewData = True
        ClearForm(Me)
        ClearOption()
        cmdConfirm.Enabled = True
        txtTruck_No.ReadOnly = False
        OptBacklist_No.Checked = True
    End Sub

    Private Sub Image_Cancle_Click(sender As Object, e As EventArgs) Handles Image_Cancle.Click
        btnCancel_click()
    End Sub

    Public Sub btnCancel_click()
        OptionButton_Click("Cancle")
        ClearForm(Me)
        ClearOption()
        txtTruck_No.Enabled = False
        Cal_Date.Value = DateTime.Now
        Cal_Expire.Value = DateTime.Now
        OptTruck_Cus.Enabled = False
        OptTruck_Ptt.Enabled = False
        txtTruck_Company.Enabled = True
        Cal_Date.Enabled = True
        txtCapacity.Enabled = False
        txtCalibration.Enabled = False

        txtTruck_No.BackColor = Color.White
        txtTruck_No_Head.BackColor = Color.White
        txtCapacity.BackColor = Color.White
        txtCalibration.BackColor = Color.White

        set_chk1(0)
        set_chk2(0)
        set_chk3(0)
    End Sub

    Private Sub Btn_Delete_Click(sender As Object, e As EventArgs)
        If txtTruck_No.Text = "" Then
            MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการลบ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        str_calllogin = "deleted"
        Me.Enabled = False
        Login.Show()
    End Sub

    Public Sub btnDeleted_clicks()
        If Not CHECK_PRIORITY(PRIORITY_frmlogin, "DELETE", "ข้อมูลรถบรรทุก LPG") Then
            MessageBox.Show("สิทธิ์ในการเข้าถึงไม่เพียงพอ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtTruck_No.Text = "" Then
            MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการลบ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Using conn As New OracleConnection("Your Connection String Here")
            conn.Open()
            Dim cmd As New OracleCommand("SELECT * FROM RELATION_TRUCK_DRIVER WHERE TRUCK_NO = :TruckNo", conn)
            cmd.BindByName = True
            cmd.Parameters.Add(":TruckNo", txtTruck_No.Text)
            Dim reader As OracleDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                MessageBox.Show("ไม่สามารถลบข้อมูลได้เนื่องจาก มีความสัมพันธ์กับข้อมูลอื่นอยู่", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End Using

        'Btn_Delete.Visible = False
        OptionButton_Click("Delete")

        If String.IsNullOrEmpty(grdTruck.Text) Then Exit Sub

        Using conn As New OracleConnection("Your Connection String Here")
            conn.Open()
            Dim cmd As New OracleCommand("SELECT * FROM TRUCK WHERE TRUCK_NO = :TruckNo", conn)
            cmd.BindByName = True
            cmd.Parameters.Add("TruckNo", txtTruck_No.Text)
            Dim reader As OracleDataReader = cmd.ExecuteReader()
            If Not reader.HasRows Then
                MessageBox.Show("ข้อมูลที่คุณต้องการลบยังไม่มีในระบบ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                OptionButton_Click("Cancle")
            ElseIf MessageBox.Show("คุณแน่ใจว่าต้องการลบข้อมูลรถบรรทุกก๊าซหมายเลขทะเบียน " & txtTruck_No.Text & " นี้?", "ยืนยันการลบข้อมูล", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel Then
                OptionButton_Click("Cancle")
                Btn_Delete.Visible = True
            Else
                reader.Close()
                cmd.CommandText = "DELETE FROM TRUCK WHERE TRUCK_NO = :TruckNo"
                cmd.Parameters.Add("TruckNo", txtTruck_No.Text)
                cmd.ExecuteNonQuery()
                MessageBox.Show("ลบข้อมูลรถบรรทุกก๊าซหมายเลขทะเบียน " & txtTruck_No.Text & " ออกจากระบบเรียบร้อยแล้ว.", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                OptionButton_Click("Cancle")
                Btn_Delete.Visible = True
                'Call Add_Event("", "", "User : " & Login_Name_frmlogin & " ทำการลบข้อมูล รถบรรทุกก๊าซทะเบียน: " & txtTruck_No_Head.Text & " ตัวถังทะเบียน : " & txtTruck_No.Text & " ออกจากระบบ TAS ที่เครื่อง : " & get_name_pc, E_LOCATION, "DELETE", "1")
                Add_Event_lpg("Truck: User " & Login_Name_frmlogin & " ลบข้อมูล รถบรรทุกก๊าซทะเบียน: " & txtTruck_No_Head.Text & " ตัวถังทะเบียน : " & txtTruck_No.Text & " ที่เครื่อง : " & get_name_pc(), "No", "PROGRAMS", "No", "No", "ลบ", 0)
            End If
        End Using

        ClearForm(Me)
        ClearOption()
        SetupgrdTruck()
        DisplaygrdTruck()
    End Sub

    Public Sub btnedit_clicks()
        'Btn_Edit.Visible = False
        OptionButton_Click("Edit")

        If Not CHECK_PRIORITY(PRIORITY_frmlogin, "EDIT", "ข้อมูลรถบรรทุก LPG") Then
            MessageBox.Show("สิทธิ์ในการเข้าถึงไม่เพียงพอ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnCancel_click()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtTruck_No.Text) Then
            MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการแก้ไข", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTruck_No.Focus()
            OptionButton_Click("Cancle")
            Exit Sub
        Else
            txtTruck_No.ReadOnly = True
            blnNewData = False
            txtTruck_No_Head.ReadOnly = True
            txtTruck_Company.Enabled = False
            Cal_Date.Enabled = False
            txtCapacity.ReadOnly = True
            txtCalibration.ReadOnly = True

            txtTruck_No.BackColor = Color.Red
            txtTruck_No_Head.BackColor = Color.Red
            txtCapacity.BackColor = Color.Red
            txtCalibration.BackColor = Color.Red
        End If
    End Sub

    Private Sub Btn_Print_Click(sender As Object, e As EventArgs) Handles Btn_Print.Click
        'Btn_Print.Visible = False
        OptionButton_Click("Print")
        If IO.File.Exists("C:\TASLPGSK\ReportDatabase.exe") Then
            Process.Start("C:\TASLPGSK\ReportDatabase.exe")
            btnCancel_click()
        Else
            MessageBox.Show("ไม่พบ Program ReportDatabase.exe ที่ Path C:\TASLPGSK", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnCancel_click()
        End If
        btnCancel_click()
    End Sub

    Private Sub Image_Save_Click(sender As Object, e As EventArgs) Handles Image_Save.Click
        'SaveClick.Visible = True

        If Not (OptWeight_Lpg.Checked Or OptWeight_Oil.Checked Or OptWeight_Other.Checked) Then
            MessageBox.Show("กรุณาเลือกชนิดของรถ (ขึ้นตาชั่ง)", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Image_Save.Enabled = True
            Image_Save.Visible = True
            Exit Sub
        End If

        If Not CheckNull(txtTruck_No_Head.Text, "หมายเลขทะเบียนหัวลากเป็นค่าว่างไม่ได้") Then
            txtTruck_No_Head.Focus()
            Exit Sub
        End If

        If Not CheckNull(txtTruck_No.Text, "หมายเลขทะเบียนตัวถังเป็นค่าว่างไม่ได้") Then
            txtTruck_No.Focus()
            Exit Sub
        End If

        If Not CheckNull(txtCard_No.Text, "หมายเลขบัตรเป็นค่าว่างไม่ได้") Then
            txtCard_No.Focus()
            Exit Sub
        End If

        If OptWeight_Lpg.Checked Then
            If Not CheckNull(txtTruck_No_Head.Text, "หมายเลขทะเบียนหัวลากเป็นค่าว่างไม่ได้") Then
                txtTruck_No_Head.Focus()
                Exit Sub
            End If

            If Not CheckNull(txtTruck_No_Tank.Text, "เลขที่ถังโยธาเป็นค่าว่างไม่ได้") Then
                txtTruck_No_Tank.Focus()
                Exit Sub
            End If

            If Not CheckNull(txtTruck_No_License.Text, "เลขที่ใบอนุญาติขนส่งเป็นค่าว่างไม่ได้") Then
                txtTruck_No_License.Focus()
                Exit Sub
            End If

            If Not CheckNull(txtCard_No.Text, "หมายเลขบัตรเป็นค่าว่างไม่ได้") Then
                txtCard_No.Focus()
                Exit Sub
            End If

            If Not CheckNull(txtTruck_Company.Text, "รถของบริษัทเป็นค่าว่างไม่ได้") Then
                txtTruck_Company.Focus()
                Exit Sub
            End If

            If Not CheckNull(txtWeight_Oil.Text, "ปริมาณน้ำมันค้างรถเป็นค่าว่างไม่ได้") Then
                txtWeight_Oil.Focus()
                Exit Sub
            End If

            If Cal_Date.Value > Cal_Expire.Value Then
                MessageBox.Show("วันที่วัดปล.2 น้อยกว่าวันที่หมดอายุปล.2 ไม่ได้", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Cal_Date.Focus()
                Image_Save.Enabled = True
                Image_Save.Visible = True
                Exit Sub
            End If

            If Cal_Date.Value = Cal_Expire.Value Then
                MessageBox.Show("วันที่วัดปล.2 เท่ากับวันที่หมดอายุปล.2 ไม่ได้", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Cal_Date.Focus()
                Image_Save.Enabled = True
                Image_Save.Visible = True
                Exit Sub
            End If

            If Not CheckNull(txtCapacity.Text, "ความจุของรถตามปล.2 (ลิตร) เป็นค่าว่างไม่ได้") Then
                txtCapacity.Focus()
                Exit Sub
            End If

            If Not CheckNull(txtCapacity_85.Text, "ความจุของรถที่ 85% เป็นค่าว่างไม่ได้") Then
                txtCapacity_85.Focus()
                Exit Sub
            End If

            If Not CheckNull(txtVapor.Text, "Vapor Factor เป็นค่าว่างไม่ได้") Then
                txtVapor.Focus()
                Exit Sub
            End If

            If Not CheckNull(txtWeight.Text, "น้ำหนักรถเปล่าเป็นค่าว่างไม่ได้") Then
                txtWeight.Focus()
                Exit Sub
            End If

            If Not (OptTruck_Cus.Checked Or OptTruck_Ptt.Checked) Then
                MessageBox.Show("กรุณาเลือกชนิดของรถ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Image_Save.Enabled = True
                Image_Save.Visible = True
                Exit Sub
            End If

            If Not blnNewData AndAlso txtDriver_No.Items.Count <= 0 Then
                MessageBox.Show("กรุณาเลือกพนักงานขับรถ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Image_Save.Enabled = True
                Image_Save.Visible = True
                Exit Sub
            End If

            If blnNewData Then
                Using DS As New OracleDataAdapter("SELECT * FROM TRUCK WHERE TRUCK_NO = '" & txtTruck_No.Text.Trim() & "'", ConnMyDB)
                    Dim dt As New DataTable()
                    DS.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Image_Save.Enabled = True
                        Image_Save.Visible = True
                        MessageBox.Show("มีทะเบียนนี้ในระบบแล้ว", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
            End If

            If Not (OptBacklist_Yes.Checked Or OptBacklist_No.Checked) Then
                MessageBox.Show("กรุณาเลือก Blacklist", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Image_Save.Enabled = True
                Image_Save.Visible = True
                Exit Sub
            End If

            If OptBacklist_Yes.Checked AndAlso Not (Opt1.Checked Or Opt2.Checked Or Opt3.Checked) Then
                MessageBox.Show("กรุณาเลือกเหตุผลของการ Blacklist", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Image_Save.Enabled = True
                Image_Save.Visible = True
                Exit Sub
            End If
        End If

        Using DS As New OracleDataAdapter("SELECT * FROM TRUCK WHERE TRUCK_NO <> '" & txtTruck_No.Text & "' AND CARD_NO <> 0 AND CARD_NO = " & txtCard_No.Text, ConnMyDB)
            Dim dt As New DataTable()
            DS.Fill(dt)
            If dt.Rows.Count > 0 Then
                Image_Save.Enabled = True
                Image_Save.Visible = True
                MessageBox.Show("มีการใช้ หมายเลขบัตรนี้แล้ว", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End Using

        SaveData()
        txtTruck_No_Head.ReadOnly = False
    End Sub

    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click
        'Btn_Search.Visible = False
        OptionButton_Click("Search")
        ClearForm(Me)
        ClearOption()
        SearchTruck.Show()
    End Sub


    Private Sub ClearOption()
        Opt1.Checked = False
        Opt2.Checked = False
        Opt3.Checked = False
        OptBacklist_No.Checked = False
        OptBacklist_Yes.Checked = False
        OptTruck_Cus.Checked = False
        OptTruck_Ptt.Checked = False
        OptWeight_Lpg.Checked = False
        OptWeight_Oil.Checked = False
        OptWeight_Other.Checked = False
    End Sub

    Private Sub txtTruck_No_Change(sender As Object, e As EventArgs) Handles txtTruck_No.TextChanged
        Show_Driver()
    End Sub

    Private Sub set_chk1(str_status As Integer)
        OptWeight_Lpg.Font = New Font(OptWeight_Lpg.Font.FontFamily, If(str_status = 1, 12, 10), If(str_status = 1, FontStyle.Bold, FontStyle.Regular))
        OptWeight_Oil.Font = New Font(OptWeight_Oil.Font.FontFamily, If(str_status = 2, 12, 10), If(str_status = 2, FontStyle.Bold, FontStyle.Regular))
        OptWeight_Other.Font = New Font(OptWeight_Other.Font.FontFamily, If(str_status = 3, 12, 10), If(str_status = 3, FontStyle.Bold, FontStyle.Regular))
    End Sub

    Private Sub set_chk2(str_status As Integer)
        OptTruck_Cus.Font = New Font(OptTruck_Cus.Font.FontFamily, If(str_status = 1, 12, 10), If(str_status = 1, FontStyle.Bold, FontStyle.Regular))
        OptTruck_Ptt.Font = New Font(OptTruck_Ptt.Font.FontFamily, If(str_status = 2, 12, 10), If(str_status = 2, FontStyle.Bold, FontStyle.Regular))
    End Sub

    Private Sub set_chk3(str_status As Integer)
        OptBacklist_Yes.Font = New Font(OptBacklist_Yes.Font.FontFamily, If(str_status = 1, 12, 10), If(str_status = 1, FontStyle.Bold, FontStyle.Regular))
        OptBacklist_No.Font = New Font(OptBacklist_No.Font.FontFamily, If(str_status = 2, 12, 10), If(str_status = 2, FontStyle.Bold, FontStyle.Regular))
    End Sub

    Private Sub grdTruck_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grdTruck.CellMouseDown
        If e.ColumnIndex <> -1 And e.RowIndex <> -1 Then

            grdTruck.ClearSelection()
            grdTruck.Rows(e.RowIndex).Selected = True
            Dim selectTruck As String = Trim(grdTruck.Rows(e.RowIndex).Cells(0).Value.ToString())
            RecordToScreen(selectTruck)
        End If
    End Sub
End Class
