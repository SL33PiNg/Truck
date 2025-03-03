' filepath: /d:/work/ข้อมูลรถบรรทุกก๊าซ/SyncData.vb

Imports System.Data.Odbc

Public Class SyncData
    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If dg.Text <> "" Then
            If RecordToTASDB(dg.Text) = True Then
                Truck.DisplaygrdTruck()
                Truck.btnCancel_click()
                Truck.RecordToScreen(Trim(dg.Rows(dg.CurrentRow.Index).Cells(1).Value.ToString()))
                Truck.txtTruck_No.ReadOnly = False
                Me.Close()
            End If
        End If
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        If cbTypeSearch.Text = "" Then
            MessageBox.Show("กรุณาเลือกรูปแบบของการค้นหา", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If txtSearchData.Text = "" Then
            MessageBox.Show("กรุณาใส่ข้อมูลที่ต้องการจะค้นหา", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim Statement As String = "SELECT a.veh_no, a.carrier, c.tu_max_volume, c.calibration_no, " &
                                  "c.calibration_date_from, c.calibration_date_to, c.compartments, b.tu_no, a.veh_status " &
                                  "FROM MASTER.sap_vehicle_master_data a " &
                                  "INNER JOIN MASTER.sap_tu_assignment_data b ON a.veh_no = b.veh_no " &
                                  "INNER JOIN MASTER.sap_tu_master_data c ON b.tu_no = c.tu_no " &
                                  "WHERE a.veh_type IN ('A110', 'A130') AND a.veh_no = @veh_no"

        Using cmd As New OdbcCommand(Statement, ConnMyDBMaster)
            cmd.Parameters.AddWithValue("@veh_no", txtSearchData.Text)
            rs = cmd.ExecuteReader()

            If Not rs.HasRows Then
                setdg()
                MessageBox.Show("ยังไม่มีข้อมูลอยู่ในระบบ.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                rs.Close()
                Exit Sub
            End If

            setdg()
            dg.Rows.Clear()
            While rs.Read()
                dg.Rows.Add(New String() {
                    If(IsDBNull(rs("veh_no")), "", rs("veh_no").ToString()),
                    If(IsDBNull(rs("tu_no")), "", rs("tu_no").ToString()),
                    If(IsDBNull(rs("carrier")), "", rs("carrier").ToString()),
                    If(IsDBNull(rs("tu_max_volume")), "", rs("tu_max_volume").ToString()),
                    If(IsDBNull(rs("compartments")), "", rs("compartments").ToString()),
                    If(IsDBNull(rs("calibration_no")), "", rs("calibration_no").ToString()),
                    If(IsDBNull(rs("calibration_date_from")), "", rs("calibration_date_from").ToString()),
                    If(IsDBNull(rs("calibration_date_to")), "", rs("calibration_date_to").ToString()),
                    If(IsDBNull(rs("veh_status")), "", rs("veh_status").ToString())
                })
            End While
            rs.Close()
        End Using
        txtSearchData.Text = ""
    End Sub

    Private Sub setdg()
        With dg
            .Columns.Clear()
            .Columns.Add("VEH_NO", "VEH_NO")
            .Columns.Add("TU_NO", "TU_NO")
            .Columns.Add("CARRIER", "CARRIER")
            .Columns.Add("TU_MAX_VOLUME", "TU_MAX_VOLUME")
            .Columns.Add("COMPARTMENTS", "COMPARTMENTS")
            .Columns.Add("CALIBRATION_NO", "CALIBRATION_NO")
            .Columns.Add("CALIBRATION_DATE_FROM", "CALIBRATION_DATE_FROM")
            .Columns.Add("CALIBRATION_DATE_TO", "CALIBRATION_DATE_TO")
            .Columns.Add("VEH_STATUS", "VEH_STATUS")
        End With
    End Sub

    Private Function RecordToTASDB(ID As String) As Boolean
        RecordToTASDB = False
        Dim C_MNT(10) As Long
        Dim COMPANY_N As String
        Dim str_tu_no As String

        If MessageBox.Show("คุณต้องการนำข้อมูลนี้เข้าระบบ TAS ใช่หรือไม่", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
            Return False
        End If

        Dim Statement As String = "SELECT a.veh_no, a.carrier, c.tu_max_volume, c.calibration_no, " &
                                  "c.calibration_date_from, c.calibration_date_to, c.compartments, b.tu_no, a.veh_status " &
                                  "FROM MASTER.sap_vehicle_master_data a " &
                                  "INNER JOIN MASTER.sap_tu_assignment_data b ON a.veh_no = b.veh_no " &
                                  "INNER JOIN MASTER.sap_tu_master_data c ON b.tu_no = c.tu_no " &
                                  "WHERE a.veh_type IN ('A110', 'A130') AND a.veh_no = @veh_no"

        Using cmd As New OdbcCommand(Statement, ConnMyDBMaster)
            cmd.Parameters.AddWithValue("@veh_no", ID)
            rs = cmd.ExecuteReader()

            If Not rs.HasRows Then
                MessageBox.Show("ไม่พบข้อมูลนี้ใน MASTER DATA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                rs.Close()
                Return False
            End If

            rs.Read()
            str_tu_no = If(IsDBNull(rs("tu_no")), "", rs("tu_no").ToString())
            If str_tu_no = "" Then
                MessageBox.Show("TU_NO เป็นค่าว่างไม่ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                rs.Close()
                Return False
            End If

            If IsDBNull(rs("carrier")) OrElse Trim(rs("carrier").ToString()) = "" Then
                MessageBox.Show("รหัสบริษัทใน MASTER DATA เป็นค่าว่างไม่ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                rs.Close()
                Return False
            End If

            If IsDBNull(rs("calibration_date_from")) OrElse Trim(rs("calibration_date_from").ToString()) = "" Then
                MessageBox.Show("CALIBRATION_DATE_FROM เป็นค่าว่างไม่ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                rs.Close()
                Return False
            End If

            If IsDBNull(rs("calibration_date_to")) OrElse Trim(rs("calibration_date_to").ToString()) = "" Then
                MessageBox.Show("CALIBRATION_DATE_TO เป็นค่าว่างไม่ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                rs.Close()
                Return False
            End If

            If Trim(rs("carrier").ToString()) <> "PHTDPRT" Then
                Dim Statement2 As String = "SELECT COMPANY_NO, COMPANY_NAME FROM COMPANY WHERE TRIM(COMPANY_NO) = @company_no"
                Using cmd2 As New OdbcCommand(Statement2, ConnMyDB)
                    cmd2.Parameters.AddWithValue("@company_no", Trim(rs("carrier").ToString()))
                    rs2 = cmd2.ExecuteReader()

                    If Not rs2.HasRows Then
                        MessageBox.Show("ไม่พบข้อมูลบริษัทขนส่ง รหัส " & Trim(rs("carrier").ToString()) & " ในระบบ TAS ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        rs2.Close()
                        rs.Close()
                        Return False
                    End If

                    rs2.Read()
                    COMPANY_N = If(IsDBNull(rs2("COMPANY_NAME")), "", rs2("COMPANY_NAME").ToString())
                    rs2.Close()
                End Using
            Else
                COMPANY_N = " "
            End If

            Dim Statement3 As String = "SELECT * FROM TRUCK WHERE TRUCK_NO = @truck_no"

            Using cmd3 As New OdbcCommand(Statement3, ConnMyDB)
                cmd3.Parameters.AddWithValue("@truck_no", str_tu_no)
                rs2 = cmd3.ExecuteReader()

                If Not rs2.HasRows Then
                    Dim InsertStatement As String = "INSERT INTO TRUCK (TRUCK_NO, TRUCK_NO_HEAD, TRUCKTANK_NO, CAL_DATE, CAL_EXPIRE, COMPANY, " &
                                                    "CAPACITY, CAPACITY_85, BLACKLIST, BLACKLIST_FROM, BLACKLIST_DETIAL, CREATE_DATE, UPDATE_DATE, LAST_USE, CALIBRATION_NO) " &
                                                    "VALUES (@truck_no, @veh_no, @truck_no, @cal_date_from, @cal_date_to, @company, @capacity, @capacity_85, @blacklist, @blacklist_from, @blacklist_detail, @create_date, @update_date, @last_use, @calibration_no)"

                    Using cmdInsert As New OdbcCommand(InsertStatement, ConnMyDB)
                        cmdInsert.Parameters.AddWithValue("@truck_no", str_tu_no)
                        cmdInsert.Parameters.AddWithValue("@veh_no", ID)
                        cmdInsert.Parameters.AddWithValue("@cal_date_from", Convert.ToDateTime(rs("calibration_date_from")).ToString("dd/MM/yyyy"))
                        cmdInsert.Parameters.AddWithValue("@cal_date_to", Convert.ToDateTime(rs("calibration_date_to")).ToString("dd/MM/yyyy"))
                        cmdInsert.Parameters.AddWithValue("@company", COMPANY_N)
                        cmdInsert.Parameters.AddWithValue("@capacity", If(IsDBNull(rs("tu_max_volume")), 0, rs("tu_max_volume")))
                        cmdInsert.Parameters.AddWithValue("@capacity_85", Math.Round((Math.Round(If(rs("tu_max_volume") <> "", rs("tu_max_volume"), 0)) / 1.84) * 0.85))
                        cmdInsert.Parameters.AddWithValue("@blacklist", If(IsDBNull(rs("veh_status")), "N", If(Trim(rs("veh_status").ToString()) = "", "N", "Y")))
                        cmdInsert.Parameters.AddWithValue("@blacklist_from", If(IsDBNull(rs("veh_status")), "0", If(Trim(rs("veh_status").ToString()) = "", "0", "3")))
                        cmdInsert.Parameters.AddWithValue("@blacklist_detail", If(IsDBNull(rs("veh_status")), "", If(Trim(rs("veh_status").ToString()) = "", "", "Black List From SAP")))
                        cmdInsert.Parameters.AddWithValue("@create_date", DateTime.Now)
                        cmdInsert.Parameters.AddWithValue("@update_date", DateTime.Now)
                        cmdInsert.Parameters.AddWithValue("@last_use", DateTime.Now)
                        cmdInsert.Parameters.AddWithValue("@calibration_no", If(IsDBNull(rs("calibration_no")), "", rs("calibration_no").ToString()))

                        Dim tra = ConnMyDB.BeginTransaction()
                        Try
                            cmdInsert.Transaction = tra
                            cmdInsert.ExecuteNonQuery()
                            tra.Commit()
                        Catch ex As Exception
                            tra.Rollback()
                            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        MessageBox.Show("บันทึกข้อมูลเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RecordToTASDB = True
                    End Using
                Else
                    MessageBox.Show("มีข้อมูลนี้ในระบบ TAS เรียบร้อยแล้ว ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If MessageBox.Show("คุณต้องการนำข้อมูลนี้แก้ไขในระบบ TAS ใช่หรือไม่", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                        rs2.Close()
                        rs.Close()
                        Return False
                    End If

                    Dim UpdateStatement As String = "UPDATE TRUCK SET COMPANY = @company, CAPACITY = @capacity, CAPACITY_85 = @capacity_85, " &
                                                    "BLACKLIST = @blacklist, BLACKLIST_FROM = @blacklist_from, BLACKLIST_DETIAL = @blacklist_detail, " &
                                                    "CAL_DATE = @cal_date_from, CAL_EXPIRE = @cal_date_to, CALIBRATION_NO = @calibration_no " &
                                                    "WHERE TRUCK_NO = @truck_no"

                    Using cmdUpdate As New OdbcCommand(UpdateStatement, ConnMyDB)
                        cmdUpdate.Parameters.AddWithValue("@company", COMPANY_N)
                        cmdUpdate.Parameters.AddWithValue("@capacity", If(IsDBNull(rs("tu_max_volume")), DBNull.Value, rs("tu_max_volume")))
                        cmdUpdate.Parameters.AddWithValue("@capacity_85", Math.Round((Math.Round(If(rs("tu_max_volume") <> "", rs("tu_max_volume"), 0)) / 1.84) * 0.85))
                        cmdUpdate.Parameters.AddWithValue("@blacklist", If(IsDBNull(rs("veh_status")), "N", If(Trim(rs("veh_status").ToString()) = "", "N", "Y")))
                        cmdUpdate.Parameters.AddWithValue("@blacklist_from", "3")
                        cmdUpdate.Parameters.AddWithValue("@blacklist_detail", If(IsDBNull(rs("veh_status")), "Cancel Black List From SAP", If(Trim(rs("veh_status").ToString()) = "", "Cancel Black List From SAP", "Black List From SAP")))
                        cmdUpdate.Parameters.AddWithValue("@cal_date_from", Convert.ToDateTime(rs("calibration_date_from")).ToString("dd/MM/yyyy"))
                        cmdUpdate.Parameters.AddWithValue("@cal_date_to", Convert.ToDateTime(rs("calibration_date_to")).ToString("dd/MM/yyyy"))
                        cmdUpdate.Parameters.AddWithValue("@calibration_no", If(IsDBNull(rs("calibration_no")), "", rs("calibration_no").ToString()))
                        cmdUpdate.Parameters.AddWithValue("@truck_no", str_tu_no)
                        Dim tra = ConnMyDB.BeginTransaction()
                        Try
                            cmdUpdate.Transaction = tra
                            cmdUpdate.ExecuteNonQuery()
                            tra.Commit()
                        Catch ex As Exception
                            tra.Rollback()
                            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        MessageBox.Show("แก้ไขข้อมูลเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RecordToTASDB = True
                    End Using
                End If
                rs2.Close()
            End Using
            rs.Close()
        End Using

        Return RecordToTASDB
    End Function

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not OpenDataBaseMasterData() Then
            Me.Close()
            Exit Sub
        End If
        setdg()
    End Sub

    Private Sub AddTypeSearch()
        cbTypeSearch.Items.Clear()
        cbTypeSearch.Items.Add("ทะเบียนรถ")
    End Sub

    Private Sub txtSearchData_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchData.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmdSearch_Click(sender, e)
        End If
    End Sub


End Class