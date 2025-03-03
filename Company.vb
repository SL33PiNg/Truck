Imports System.Data.OleDb

Public Class Company
    Private Sub Company_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Truck.Enabled = True
    End Sub

    Private Sub Company_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Show_Company("")
    End Sub

    Private Sub Show_Company(STR_SQL As String)
        Dim Statement As String = "SELECT * FROM COMPANY WHERE COMPANY_NAME IS NOT NULL " & STR_SQL & " ORDER BY COMPANY_NAME"
        Dim cmd As New OleDbCommand(Statement, ConnMyDB)

        Try
            ConnMyDB.Open()
            BS = cmd.ExecuteReader()

            If Not BS.HasRows Then
                ListCompany.Items.Clear()
                Exit Sub
            End If

            ListCompany.Items.Clear()
            While BS.Read()
                ListCompany.Items.Add(BS("COMPANY_NAME").ToString())
            End While
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If BS IsNot Nothing Then BS.Close()
            ConnMyDB.Close()
        End Try
        'Mockup Data
        'ListCompany.Items.Add("PT. A")
        'ListCompany.Items.Add("PT. B")
        'ListCompany.Items.Add("PT. C")
    End Sub

    Private Sub ListCompany_DoubleClick(sender As Object, e As EventArgs) Handles ListCompany.DoubleClick
        Truck.txtTruck_Company.Text = ListCompany.Text
        Me.Close()
    End Sub

    Private Sub txts_TextChanged(sender As Object, e As EventArgs) Handles txts.TextChanged
        Dim STR_S As String
        STR_S = " AND COMPANY_NAME LIKE '%" & txts.Text & "%' "
        Show_Company(STR_S)
    End Sub
End Class