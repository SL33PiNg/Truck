﻿Imports Oracle.ManagedDataAccess.Client

Public Class SearchTruck

    Private TypeSearch As String
    Private countrec As Long
    Private Sub SearchTruck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Truck.Enabled = False
    End Sub

    Private Sub cbTypeSearch_DropDown(sender As Object, e As EventArgs) Handles cbTypeSearch.DropDown
        AddTypeSearch()
    End Sub

    Private Sub SearchTruck_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.TopMost = True
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click

        setdg()
        dg.Refresh()

        If cbTypeSearch.Text = "" Then
            MessageBox.Show("กรุณาเลือกรูปแบบข้อมูลที่ต้องการจะค้นหา", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txtSearch_Truck.Text = "" Then
            MessageBox.Show("กรุณากรอกข้อมูลที่ต้องการจะค้นหา", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSearch_Truck.Focus()
            Exit Sub
        End If


        Select Case cbTypeSearch.Text
            Case "หมายเลขทะเบียนตัวถัง"
                TypeSearch = "SELECT * FROM TASLPGSK.TRUCK WHERE (TRUCK_NO like '%" & txtSearch_Truck.Text & "%')"
            Case "หมายเลขทะเบียนหัวลาก"
                TypeSearch = "SELECT * FROM TASLPGSK.TRUCK WHERE (TRUCK_NO_HEAD like '%" & txtSearch_Truck.Text & "%')"
            Case "เลขที่ถังโยธา"
                TypeSearch = "SELECT * FROM TASLPGSK.TRUCK WHERE (TRUCKTANK_NO like '%" & txtSearch_Truck.Text & "%')"
            Case "เลขที่ใบอนุญาติขนส่ง"
                TypeSearch = "SELECT * FROM TASLPGSK.TRUCK WHERE (TRUCK_LICENSE like '%" & txtSearch_Truck.Text & "%')"
            Case "ชนิดรถบรรทุกก๊าซ"
                TypeSearch = "SELECT * FROM TASLPGSK.TRUCK WHERE (TRUCK_TYPE like '%" & txtSearch_Truck.Text & "%')"
            Case "หมายเลขบัตร"
                TypeSearch = "SELECT * FROM TASLPGSK.TRUCK WHERE (CARD_NO like '%" & txtSearch_Truck.Text & "%')"
            Case "หมายเลข พขร."
                TypeSearch = "SELECT * FROM TASLPGSK.TRUCK WHERE (DRIVER_NO like '%" & txtSearch_Truck.Text & "%')"
            Case "รถของบริษัท"
                TypeSearch = "SELECT * FROM TASLPGSK.TRUCK WHERE (COMPANY like '%" & txtSearch_Truck.Text & "%')"
            Case "ความจุของรถตามปล.2"
                TypeSearch = "SELECT * FROM TASLPGSK.TRUCK WHERE (CAPACITY like '%" & txtSearch_Truck.Text & "%')"
            Case "ความจุของรถที่ 85 %"
                TypeSearch = "SELECT * FROM TASLPGSK.TRUCK WHERE (CAPACITY_85 like '%" & txtSearch_Truck.Text & "%')"
            Case "น้ำหนักรถเปล่า"
                TypeSearch = "SELECT * FROM TASLPGSK.TRUCK WHERE (WEIGHT like '%" & txtSearch_Truck.Text & "%')"
            Case "ชนิดของรถบรรทุกก๊าซ"
                TypeSearch = "SELECT * FROM TASLPGSK.TRUCK WHERE (WEIGHT like '%" & txtSearch_Truck.Text & "%')"
        End Select


        Dim rs_dt = ConnMyDB.ExecuteQuery(TypeSearch)

        If rs_dt.Rows.Count <= 0 Then
            MessageBox.Show("ยังไม่มีข้อมูลอยู่ในระบบ.", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSearch_Truck.Text = ""
            txtSearch_Truck.Focus()
            Exit Sub
        End If

        dg.Rows.Clear()
        dg.Rows.Add(rs_dt.Rows.Count)

        For rowIndex As Integer = 0 To rs_dt.Rows.Count - 1

            dg.Rows(rowIndex).Cells(0).Value = rs_dt.Rows(rowIndex)("TRUCK_NO").ToString()
            dg.Rows(rowIndex).Cells(1).Value = rs_dt.Rows(rowIndex)("TRUCK_NO_HEAD").ToString()
            dg.Rows(rowIndex).Cells(2).Value = rs_dt.Rows(rowIndex)("TRUCKTANK_NO").ToString()
            dg.Rows(rowIndex).Cells(3).Value = rs_dt.Rows(rowIndex)("TRUCK_LICENSE").ToString()
            dg.Rows(rowIndex).Cells(4).Value = rs_dt.Rows(rowIndex)("CARD_NO").ToString()
            dg.Rows(rowIndex).Cells(5).Value = rs_dt.Rows(rowIndex)("DRIVER_NO").ToString()
            dg.Rows(rowIndex).Cells(6).Value = rs_dt.Rows(rowIndex)("COMPANY").ToString()
            dg.Rows(rowIndex).Cells(7).Value = rs_dt.Rows(rowIndex)("CAL_DATE").ToString()
            dg.Rows(rowIndex).Cells(8).Value = rs_dt.Rows(rowIndex)("CAL_EXPIRE").ToString()
            dg.Rows(rowIndex).Cells(9).Value = rs_dt.Rows(rowIndex)("CAPACITY").ToString()
            dg.Rows(rowIndex).Cells(10).Value = rs_dt.Rows(rowIndex)("CAPACITY_85").ToString()
            dg.Rows(rowIndex).Cells(11).Value = rs_dt.Rows(rowIndex)("VAPOR").ToString()
            dg.Rows(rowIndex).Cells(12).Value = rs_dt.Rows(rowIndex)("WEIGHT").ToString()
            dg.Rows(rowIndex).Cells(13).Value = If(rs_dt.Rows(rowIndex)("TRUCK_TYPE").ToString() = "C", "รถลูกค้ารับเอง", "ปตท.จัดส่ง")
            dg.Rows(rowIndex).Cells(14).Value = If(rs_dt.Rows(rowIndex)("BLACKLIST").ToString() = "Y", "Yes", "No")
            dg.Rows(rowIndex).Cells(15).Value = If(rs_dt.Rows(rowIndex)("BLACKLIST").ToString() = "Y", If(rs_dt.Rows(rowIndex)("BLACKLIST_FROM").ToString() = "1", "รถสภาพต่ำกว่ามาตรฐาน", If(rs_dt.Rows(rowIndex)("BLACKLIST_FROM").ToString() = "2", "รถปล.2 หมดอายุ", "อื่นๆ")), "-")
            dg.Rows(rowIndex).Cells(16).Value = rs_dt.Rows(rowIndex)("CONFIRM_NAME").ToString()
            dg.Rows(rowIndex).Cells(17).Value = rs_dt.Rows(rowIndex)("REMARK").ToString()
            dg.Rows(rowIndex).Cells(18).Value = rs_dt.Rows(rowIndex)("CREATE_DATE").ToString()
            dg.Rows(rowIndex).Cells(19).Value = rs_dt.Rows(rowIndex)("UPDATE_DATE").ToString()

        Next

        txtSearch_Truck.Text = ""



    End Sub



    Private Sub setdg()
        With dg
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("TRUCK_NO", "หมายเลขทะเบียนตัวถัง")
            .Columns.Add("TRUCK_NO_HEAD", "หมายเลขทะเบียนหัวลาก")
            .Columns.Add("TRUCKTANK_NO", "เลขที่ถังโยธา")
            .Columns.Add("TRUCK_LICENSE", "เลขที่ใบอนุญาติขนส่ง")
            .Columns.Add("CARD_NO", "หมายเลขบัตร")
            .Columns.Add("DRIVER_NO", "หมายเลข พขร.")
            .Columns.Add("COMPANY", "รถของบริษัท")
            .Columns.Add("CAL_DATE", "วันที่วัด ปล.2")
            .Columns.Add("CAL_EXPIRE", "วันที่วัดปล.2 ครั้งถัดไป")
            .Columns.Add("CAPACITY", "ความจุของรถตามปล.2")
            .Columns.Add("CAPACITY_85", "ความจุของรถที่ 85 %")
            .Columns.Add("VAPOR", "Vapour Factor")
            .Columns.Add("WEIGHT", "น้ำหนักรถเปล่า")
            .Columns.Add("TRUCK_TYPE", "ชนิดรถบรรทุกก๊าซ")
            .Columns.Add("BLACKLIST", "Black List")
            .Columns.Add("BLACKLIST_REASON", "เหตุผลการ Black List")
            .Columns.Add("CONFIRM_NAME", "ชื่อผู้ยืนยันการ Black List")
            .Columns.Add("REMARK", "หมายเหตุ")
            .Columns.Add("CREATE_DATE", "Create Date")
            .Columns.Add("UPDATE_DATE", "Update Date")
        End With
    End Sub

    Private Sub AddTypeSearch()
        cbTypeSearch.Items.Clear()
        cbTypeSearch.Items.Add("หมายเลขทะเบียนตัวถัง")
        cbTypeSearch.Items.Add("หมายเลขทะเบียนหัวลาก")
        cbTypeSearch.Items.Add("เลขที่ถังโยธา")
        cbTypeSearch.Items.Add("เลขที่ใบอนุญาติขนส่ง")
        cbTypeSearch.Items.Add("หมายเลขบัตร")
        cbTypeSearch.Items.Add("หมายเลข พขร.")
        cbTypeSearch.Items.Add("รถของบริษัท")
        cbTypeSearch.Items.Add("ความจุของรถตามปล.2")
        cbTypeSearch.Items.Add("ความจุของรถที่ 85 %")
        cbTypeSearch.Items.Add("น้ำหนักรถเปล่า")
        cbTypeSearch.Items.Add("ชนิดของรถบรรทุกก๊าซ")
    End Sub

    Private Sub SearchTruck_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Truck.Enabled = True
        Truck.OptionButton_Click("Cancle")
    End Sub

    Private Sub txtSearch_Truck_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch_Truck.KeyPress
        If e.KeyChar = Chr(13) Then
            cmdSearch_Click(sender, e)
        End If
    End Sub

    Private Sub dg_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dg.CellMouseDown
        If SetGridSelect(dg, e) Then
            Dim truckNo = dg.SelectedRows(0).Cells(0).Value.ToString()
            Truck.RecordToScreen(truckNo)
        End If
    End Sub
End Class