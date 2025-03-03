Imports System.Data.Odbc
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared

Public Class Report
    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim Crystal As New ReportDocument()
        Dim Value1 As String = String.Empty
        Dim Value2 As String = String.Empty

        'Crystal.Load(Application.StartupPath & "\REPORT\Truck_Report.rpt")

        If ReportC.op1.Checked Then
            Value1 = "ครั้งที่ 1 "
        ElseIf ReportC.op2.Checked Then
            Value1 = "ครั้งที่ 2 "
        ElseIf ReportC.op3.Checked Then
            Value1 = "ครั้งที่ 3 "
        ElseIf ReportC.op4.Checked Then
            Value1 = "จากวันที่ " & ReportC.dt1.Value.ToString("dd/MM/yyyy") & " ถึง " & ReportC.dt2.Value.ToString("dd/MM/yyyy")
        ElseIf ReportC.op5.Checked Then
            Value1 = " "
        End If

        If ReportC.op_sort1.Checked Then
            Value2 = "ทะเบียนรถ"
        ElseIf ReportC.op_sort2.Checked Then
            Value2 = "ชื่อบริษัท"
        ElseIf ReportC.op_sort3.Checked Then
            Value2 = "วันคงเหลือ"
        End If

        'Crystal.SetParameterValue("str1", Value1)
        'Crystal.SetParameterValue("str2", Value2)

        'Dim connectionInfo As New ConnectionInfo()
        'connectionInfo.ServerName = "your_server_name"
        'connectionInfo.DatabaseName = "your_database_name"
        'connectionInfo.UserID = "taslpgsk"
        'connectionInfo.Password = "passwordtaslpgsk"

        'For Each table As Table In Crystal.Database.Tables
        '    Dim logonInfo As TableLogOnInfo = table.LogOnInfo
        '    logonInfo.ConnectionInfo = connectionInfo
        '    table.ApplyLogOnInfo(logonInfo)
        'Next

        'With CRViewer91
        '    .DisplayBorder = False
        '    .DisplayTabs = False
        '    .EnableDrillDown = False
        '    .EnableRefreshButton = True
        '    .ReportSource = Crystal
        '    .ViewReport()
        '    .Visible = True
        '    .Zoom(2)
        'End With
    End Sub
End Class