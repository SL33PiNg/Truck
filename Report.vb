Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Report
    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Value1 As String = String.Empty
        Dim Value2 As String = String.Empty

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

        Dim report As New ReportDocument()
        report.Load(AppDomain.CurrentDomain.BaseDirectory & "\REPORT\Truck_Report2.rpt")

        Dim dt As DataTable = ReportC.QueryTruckCheck()
        report.SetDataSource(dt)
        report.SetParameterValue("str1", Value1)
        report.SetParameterValue("str2", Value2)


        CRViewer.ReportSource = report
        CRViewer.Refresh()

    End Sub
End Class