' filepath: /d:/work/ข้อมูลรถบรรทุกก๊าซ/SyncData.vb

Imports Oracle.ManagedDataAccess.Client

Public Class SyncData
    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If Not CheckGridSelected(dg) Then
            MsgBox("กรุณาเลือกข้อมูล")
            Exit Sub
        End If

        Dim SelectR = dg.SelectedRows(0).Cells(0).Value.ToString()
        If Not String.IsNullOrEmpty(SelectR) Then
            If RecordToTASDB(SelectR) = True Then
                Truck.DisplaygrdTruck()
                Truck.btnCancel_click()
                Truck.RecordToScreen(Trim(SelectR))
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
                                  "WHERE a.veh_type IN ('A110', 'A130') AND a.veh_no = :veh_no"

        Using cmd As New OracleCommand(Statement, ConnMyDBMaster)
            cmd.BindByName = True
            cmd.Parameters.Add("veh_no", txtSearchData.Text)
            Dim rs As DataTable = ConnMyDBMaster.ExecuteQuery(cmd)

            If rs.Rows.Count <= 0 Then
                setdg()
                MessageBox.Show("ยังไม่มีข้อมูลอยู่ในระบบ.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            setdg()
            dg.Rows.Clear()
            For i As Integer = 0 To rs.Rows.Count - 1
                Dim r = rs.Rows(i)

                dg.Rows.Add(New String() {
                    If(IsDBNull(r("veh_no")), "", r("veh_no").ToString()),
                    If(IsDBNull(r("tu_no")), "", r("tu_no").ToString()),
                    If(IsDBNull(r("carrier")), "", r("carrier").ToString()),
                    If(IsDBNull(r("tu_max_volume")), "", r("tu_max_volume").ToString()),
                    If(IsDBNull(r("compartments")), "", r("compartments").ToString()),
                    If(IsDBNull(r("calibration_no")), "", r("calibration_no").ToString()),
                    If(IsDBNull(r("calibration_date_from")), "", r("calibration_date_from").ToString()),
                    If(IsDBNull(r("calibration_date_to")), "", r("calibration_date_to").ToString()),
                    If(IsDBNull(r("veh_status")), "", r("veh_status").ToString())
                })

            Next


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
                                  "WHERE a.veh_type IN ('A110', 'A130') AND a.veh_no = :veh_no"

        Using cmd As New OracleCommand(Statement, ConnMyDBMaster)
            cmd.BindByName = True
            cmd.Parameters.Add("veh_no", ID)
            Dim rs = ConnMyDBMaster.ExecuteQuery(cmd)

            If  rs.Rows.Count <= 0 Then
                MessageBox.Show("ไม่พบข้อมูลนี้ใน MASTER DATA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            Dim r = rs.Rows(0)
            str_tu_no = If(IsDBNull(r("tu_no")), "", r("tu_no").ToString())
            If str_tu_no = "" Then
                MessageBox.Show("TU_NO เป็นค่าว่างไม่ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Return False
            End If

            If IsDBNull(r("carrier")) OrElse Trim(r("carrier").ToString()) = "" Then
                MessageBox.Show("รหัสบริษัทใน MASTER DATA เป็นค่าว่างไม่ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Return False
            End If

            If IsDBNull(r("calibration_date_from")) OrElse Trim(r("calibration_date_from").ToString()) = "" Then
                MessageBox.Show("CALIBRATION_DATE_FROM เป็นค่าว่างไม่ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Return False
            End If

            If IsDBNull(r("calibration_date_to")) OrElse Trim(r("calibration_date_to").ToString()) = "" Then
                MessageBox.Show("CALIBRATION_DATE_TO เป็นค่าว่างไม่ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            If Trim(r("carrier").ToString()) <> "PHTDPRT" Then
                Dim Statement2 As String = "SELECT COMPANY_NO, COMPANY_NAME FROM COMPANY WHERE TRIM(COMPANY_NO) = :company_no"
                Using cmd2 As New OracleCommand(Statement2, ConnMyDB)
                    cmd2.BindByName = True
                    cmd2.Parameters.Add("company_no", Trim(r("carrier").ToString()))
                    Dim rs2 = ConnMyDB.ExecuteQuery(cmd2)

                    If Not rs2.Rows.Count <= 0 Then
                        MessageBox.Show("ไม่พบข้อมูลบริษัทขนส่ง รหัส " & Trim(r("carrier").ToString()) & " ในระบบ TAS ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Return False
                    End If

                    Dim r2 = rs2.Rows(0)
                    COMPANY_N = If(IsDBNull(r2("COMPANY_NAME")), "", r2("COMPANY_NAME").ToString())

                End Using
            Else
                COMPANY_N = " "
            End If

            Dim Statement3 As String = "SELECT * FROM TRUCK WHERE TRUCK_NO = :truck_no"

            Using cmd3 As New OracleCommand(Statement3, ConnMyDB)
                cmd3.BindByName = True
                cmd3.Parameters.Add("truck_no", str_tu_no)
                Dim rs2 = ConnMyDB.ExecuteQuery(cmd3)

                If rs2.Rows.Count <= 0 Then
                    Dim InsertStatement As String = "INSERT INTO TRUCK (TRUCK_NO, TRUCK_NO_HEAD, TRUCKTANK_NO, CAL_DATE, CAL_EXPIRE, COMPANY, " &
                                                    "CAPACITY, CAPACITY_85, BLACKLIST, BLACKLIST_FROM, BLACKLIST_DETIAL, CREATE_DATE, UPDATE_DATE, LAST_USE, CALIBRATION_NO) " &
                                                    "VALUES (:truck_no, :veh_no, :truck_no, :cal_date_from, :cal_date_to, :company, :capacity, :capacity_85, :blacklist, :blacklist_from, :blacklist_detail, :create_date, :update_date, :last_use, :calibration_no)"

                    Using cmdInsert As New OracleCommand(InsertStatement, ConnMyDB)
                        cmd.BindByName = True
                        cmdInsert.Parameters.Add("truck_no", str_tu_no)
                        cmdInsert.Parameters.Add("veh_no", ID)
                        cmdInsert.Parameters.Add("cal_date_from", Convert.ToDateTime(r("calibration_date_from")).ToString("dd/MM/yyyy"))
                        cmdInsert.Parameters.Add("cal_date_to", Convert.ToDateTime(r("calibration_date_to")).ToString("dd/MM/yyyy"))
                        cmdInsert.Parameters.Add("company", COMPANY_N)
                        cmdInsert.Parameters.Add("capacity", If(IsDBNull(r("tu_max_volume")), 0, r("tu_max_volume")))
                        cmdInsert.Parameters.Add("capacity_85", Math.Round(Math.Round(If(r("tu_max_volume") <> "", Double.Parse(r("tu_max_volume")), 0)) / 1.84 * 0.85)) ' TODO: cast string to double
                        cmdInsert.Parameters.Add("blacklist", If(IsDBNull(r("veh_status")), "N", If(Trim(r("veh_status").ToString()) = "", "N", "Y")))
                        cmdInsert.Parameters.Add("blacklist_from", If(IsDBNull(r("veh_status")), "0", If(Trim(r("veh_status").ToString()) = "", "0", "3")))
                        cmdInsert.Parameters.Add("blacklist_detail", If(IsDBNull(r("veh_status")), "", If(Trim(r("veh_status").ToString()) = "", "", "Black List From SAP")))
                        cmdInsert.Parameters.Add("create_date", DateTime.Now)
                        cmdInsert.Parameters.Add("update_date", DateTime.Now)
                        cmdInsert.Parameters.Add("last_use", DateTime.Now)
                        cmdInsert.Parameters.Add("calibration_no", If(IsDBNull(r("calibration_no")), "", r("calibration_no").ToString()))

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

                        Return False
                    End If

                    Dim UpdateStatement As String = "UPDATE TRUCK SET COMPANY = :company, CAPACITY = :capacity, CAPACITY_85 = :capacity_85, " &
                                                    "BLACKLIST = :blacklist, BLACKLIST_FROM = :blacklist_from, BLACKLIST_DETIAL = :blacklist_detail, " &
                                                    "CAL_DATE = :cal_date_from, CAL_EXPIRE = :cal_date_to, CALIBRATION_NO = :calibration_no " &
                                                    "WHERE TRUCK_NO = :truck_no"

                    Using cmdUpdate As New OracleCommand(UpdateStatement, ConnMyDB)
                        cmd.BindByName = True
                        cmdUpdate.Parameters.Add("company", COMPANY_N)
                        cmdUpdate.Parameters.Add("capacity", If(IsDBNull(r("tu_max_volume")), DBNull.Value, r("tu_max_volume")))
                        cmdUpdate.Parameters.Add("capacity_85", Math.Round((Math.Round(If(r("tu_max_volume") <> "", Double.Parse(r("tu_max_volume")), 0)) / 1.84) * 0.85))
                        cmdUpdate.Parameters.Add("blacklist", If(IsDBNull(r("veh_status")), "N", If(Trim(r("veh_status").ToString()) = "", "N", "Y")))
                        cmdUpdate.Parameters.Add("blacklist_from", "3")
                        cmdUpdate.Parameters.Add("blacklist_detail", If(IsDBNull(r("veh_status")), "Cancel Black List From SAP", If(Trim(r("veh_status").ToString()) = "", "Cancel Black List From SAP", "Black List From SAP")))
                        cmdUpdate.Parameters.Add("cal_date_from", Convert.ToDateTime(r("calibration_date_from")).ToString("dd/MM/yyyy"))
                        cmdUpdate.Parameters.Add("cal_date_to", Convert.ToDateTime(r("calibration_date_to")).ToString("dd/MM/yyyy"))
                        cmdUpdate.Parameters.Add("calibration_no", If(IsDBNull(r("calibration_no")), "", r("calibration_no").ToString()))
                        cmdUpdate.Parameters.Add("truck_no", str_tu_no)
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

            End Using

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

    Private Sub cbTypeSearch_DropDown(sender As Object, e As EventArgs) Handles cbTypeSearch.DropDown
        AddTypeSearch()
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

    Private Sub dg_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dg.CellMouseClick
        If e.ColumnIndex <> -1 And e.RowIndex <> -1 Then
            dg.ClearSelection()
            dg.Rows(e.RowIndex).Selected = True
        End If
    End Sub
End Class