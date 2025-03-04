﻿
Imports Oracle.ManagedDataAccess.Client

Public Class DBManagement
    Inherits OracleConnection

    Public Shared ReadOnly TAS_DB As String = "OracleTASDbContext"
    Public Shared ReadOnly SAP_DB As String = "OracleSAPDbContext"


    Public Sub New(ByVal ContextDb As String)
        MyBase.New(Configuration.ConfigurationManager.ConnectionStrings(ContextDb).ToString())
    End Sub

    Public Sub CloseConnection()
        Try
            If Me IsNot Nothing Then
                If Me.State <> ConnectionState.Closed Then
                    Me.Close()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Function Execute(query As String) As Integer
        Dim command As New OracleCommand(query, Me)
        If Me.State <> ConnectionState.Open Then
            Try
                Me.Open()
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
        Dim command As New OracleCommand(query, Me)
        command.AddToStatementCache = False
        If Me.State <> ConnectionState.Open Then
            Try
                Me.Open()
            Catch
                Return New DataTable()
            End Try
        End If

        Try
            Me.FlushCache()
            Me.PurgeStatementCache()
            Dim da As New OracleDataAdapter(query, Me)
            Dim ds As New DataSet()
            da.Fill(ds, "Table1")
            Return ds.Tables(0)
        Catch ex As OracleException
            Console.WriteLine(ex.Message)
            Return Nothing
        Finally

        End Try

    End Function

    Public Function ExecuteQuery(query As OracleCommand) As DataTable
        query.Connection = Me
        query.AddToStatementCache = False
        If Me.State <> ConnectionState.Open Then
            Try
                Me.Open()
            Catch
                Return New DataTable()
            End Try
        End If

        Try
            Me.FlushCache()
            Me.PurgeStatementCache()
            Dim da As New OracleDataAdapter(query)
            Dim dt As New DataTable()
            da.Fill(dt)
            Return dt

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

End Class
