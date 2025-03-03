
Imports Oracle.ManagedDataAccess.Client

Public Class DBManagement
    Public Shared ReadOnly TAS_DB As String = "OracleTASDbContext"
    Public Shared ReadOnly SAP_DB As String = "OracleSAPDbContext"

    Public conn_ As OracleConnection

    Public Sub New(ByVal ContextDb As String)
        Dim strConnection As String = System.Configuration.ConfigurationManager.ConnectionStrings(ContextDb).ToString()
        conn_ = New OracleConnection(strConnection)
    End Sub

    Public Sub CloseConnection()
        Try
            If conn_ IsNot Nothing Then
                If conn_.State <> ConnectionState.Closed Then
                    conn_.Close()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Function Execute(query As String) As Integer
        Dim command As New OracleCommand(query, conn_)
        If conn_.State <> ConnectionState.Open Then
            Try
                conn_.Open()
            Catch
                Return -1
            End Try
        End If

        Try
            Return command.ExecuteNonQuery()

        Catch ex As OracleException
            Console.WriteLine(ex.Message)
            Return -1
        Finally

        End Try

    End Function

    Public Function ExecuteQuery(query As String) As DataTable
        Dim command As New OracleCommand(query, conn_)
        command.AddToStatementCache = False
        If conn_.State <> ConnectionState.Open Then
            Try
                conn_.Open()
            Catch
                Return New DataTable()
            End Try
        End If

        Try
            conn_.FlushCache()
            conn_.PurgeStatementCache()
            Dim da As New OracleDataAdapter(query, conn_)
            Dim ds As New DataSet()
            da.Fill(ds, "Table1")
            Return ds.Tables(0)
        Catch ex As OracleException
            Console.WriteLine(ex.Message)
            Return Nothing
        Finally

        End Try

    End Function

End Class
