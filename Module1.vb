' filepath: /d:/work/ข้อมูลรถบรรทุกก๊าซ/Module1.vb
Imports System.Text
Imports Oracle.ManagedDataAccess.Client

Module Module1

    Public ConnMyDB As DBManagement    'สร้าง Connection เพื่อเชื่อมต่อกับฐานข้อมูล TAS
    Public ConnMyDBOutBound As DBManagement 'สร้าง Connection เพื่อเชื่อมต่อกับฐานข้อมูล OutBound
    Public ConnMyDBMaster As DBManagement 'สร้าง Connection เพื่อเชื่อมต่อกับฐานข้อมูล Master Data
    'Public rs As OracleDataReader 'สร้างการเชื่อมต่อเข้ากับตาราง (ตัวหลัก)
    Public rs2 As OracleDataReader
    Public rs3 As OracleDataReader
    Public rs4 As OracleDataReader
    Public DS As OracleDataReader  'สร้างการเชื่อมต่อเข้ากับตาราง (ตัวรอง 1)
    Public ES As OracleDataReader  'สร้างการเชื่อมต่อเข้ากับตาราง (ตัวรอง 2)
    Public JS As OracleDataReader  'สร้างการเชื่อมต่อเข้ากับตาราง (ตัวรอง 3)
    Public KS As OracleDataReader  'สร้างการเชื่อมต่อเข้ากับตาราง (ตัวรอง 4)
    Public BS As OracleDataReader 'สร้างการเชื่อมต่อเข้ากับตาราง (ตัวรอง 5)
    Public GS As OracleDataReader  'สร้างการเชื่อมต่อเข้ากับตาราง (ตัวรอง 6)
    Public FS As OracleDataReader  'สร้างการเชื่อมต่อเข้ากับตาราง (ตัวรอง 7)

    Public Statement As String 'สำหรับการประกาศ Statament
    Public Statement2 As String 'สำหรับการประกาศ Statament2
    Public Statement3 As String 'สำหรับการประกาศ Statament3
    Public Statement4 As String 'สำหรับการประกาศ Statament4
    Public Statement5 As String 'สำหรับการประกาศ Statament5
    Public Statement6 As String 'สำหรับการประกาศ Statament6
    Public Statement7 As String 'สำหรับการประกาศ Statament7
    Public Statement8 As String 'สำหรับการประกาศ Statament8
    Public blnNewData As Boolean
    Public name_user As String
    Public PRIORITY As String

    Public Login_Name_frmlogin As String
    Public PRIORITY_frmlogin As String
    Public str_calllogin As String
    Public Const E_LOCATION As String = "ข้อมูลรถบรรทุกก๊าซ"
    Public p_click As String

    Public num_dates1 As Integer
    Public num_dates2 As Integer
    Private Declare Function Decode_B64 Lib "dbase64.dll" Alias "decode_b64" (ByVal Ltb64 As Integer, ByVal LtPile As Integer, ByVal ScrmB64 As String, ByVal PileAStuff As String) As Integer
    Private Declare Function Dedel_Dedim Lib "dbase64.dll" Alias "dedel_dedim" () As Integer

    Function OpenDataBaseMasterData() As Boolean
        OpenDataBaseMasterData = False

        Try
            If ConnMyDBMaster Is Nothing Then
                ConnMyDBMaster = New DBManagement(DBManagement.SAP_DB)
                ConnMyDBMaster.Open()
                OpenDataBaseMasterData = True

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
            OpenDataBaseMasterData = False
        End Try

        If ConnMyDBMaster.State = ConnectionState.Open Then
            OpenDataBaseMasterData = True
        End If
    End Function

    Public Sub CloseDtatBaseMasterData()
        If ConnMyDBMaster.State = ConnectionState.Open Then
            ConnMyDBMaster.Close()
            ConnMyDBMaster = Nothing
        End If
    End Sub

    Public Sub OpenDataBase()
        Try
            If ConnMyDB Is Nothing Then
                ConnMyDB = New DBManagement(DBManagement.TAS_DB)
                ConnMyDB.Open()
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
        'If ConnMyDB.State = ConnectionState.Open Then
        '    OpenDataBase = True
        'End If
    End Sub

    Public Sub ClearForm(frm As Form)
        For Each Ctl As Control In frm.Controls
            If TypeOf Ctl Is TextBox Then
                Ctl.Text = ""
            End If
        Next
    End Sub

    Public Sub Clearopt(frm As Form)
        For Each Clropt As Control In frm.Controls
            If TypeOf Clropt Is RadioButton Then
                DirectCast(Clropt, RadioButton).Checked = False
            End If
        Next
    End Sub

    Public Sub Clearchk(frm As Form)
        For Each Clrchk As Control In frm.Controls
            If TypeOf Clrchk Is CheckBox Then
                DirectCast(Clrchk, CheckBox).Checked = False
            End If
        Next
    End Sub

    Public Sub CheckNull_Combo(frm As Form, Name_Object As ComboBox, Caption As String)
        For Each ConCombo As Control In frm.Controls
            If TypeOf ConCombo Is ComboBox Then
                If Name_Object.Text = "" Then
                    MsgBox(Caption)
                End If
            End If
        Next
    End Sub

    Public Function CHECK_LOGIN() As Boolean
        CHECK_LOGIN = False
        Try
            Dim CHECK_RS As New OracleDataAdapter("SELECT * FROM OPERATOR1 WHERE COMPUTER_NAME = '" & get_name_pc() & "'", ConnMyDB)
            Dim dt As New DataTable()
            CHECK_RS.Fill(dt)
            If dt.Rows.Count <= 0 Then
                MsgBox("คุณยังไม่ได้ทำการเข้าระบบ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "รายงาน")
                End
            End If
            name_user = dt.Rows(0)("NAME").ToString()
            PRIORITY = dt.Rows(0)("GROUP_NAME").ToString()
            If DateTime.Parse(dt.Rows(0)("PASSWORD_EXPIRE").ToString()) < Now Then
                MsgBox("Password expire ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "รายงาน")
                End
            End If
            CHECK_LOGIN = True
        Catch ex As Exception
            CHECK_LOGIN = False
        End Try
    End Function

    Public Function CHECK_PRIORITY(STR_P As String, str_Process As String, STR_LIST As String) As Boolean
        CHECK_PRIORITY = False
        Try
            Dim CHECK_P As New OracleDataAdapter("SELECT * FROM SET_PRIORITY1 WHERE GROUP_NAME = '" & STR_P & "' AND NAME= '" & STR_LIST & "'", ConnMyDB)
            Dim dt As New DataTable()
            CHECK_P.Fill(dt)
            If dt.Rows.Count <= 0 Then
                MsgBox("ไม่พบข้อมูลโปรแกรมใน ข้อมูลสิทธิการเข้าถึง", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "รายงาน")
                End
            End If
            Select Case str_Process
                Case "VIEW"
                    If dt.Rows(0)("P_VIEW").ToString() = "0" Then Exit Function
                Case "CREATED"
                    If dt.Rows(0)("P_CREATED").ToString() = "0" Then Exit Function
                Case "EDIT"
                    If dt.Rows(0)("P_EDIT").ToString() = "0" Then Exit Function
                Case "DELETE"
                    If dt.Rows(0)("P_DEL").ToString() = "0" Then Exit Function
                Case Else
                    Exit Function
            End Select
            CHECK_PRIORITY = True
        Catch ex As Exception
            CHECK_PRIORITY = False
        End Try
    End Function

    Function get_name_pc() As String
        Return Environment.MachineName
    End Function

    Sub Add_Event_lpg(str_Message As String, STR_USER As String, str_Device As String, str_Truck As String, str_Location As String, str_Process As String, str_Card As Integer)
        Using tra As OracleTransaction = ConnMyDB.BeginTransaction()
            Try
                Dim str_sqlex As String = "insert into t_event (e_no,e_date,e_message,e_user,e_device,e_truck,e_location,e_process,e_card) values " &
                                          " ((select nvl(max(e_no),0)+1 from t_event),sysdate,'" & str_Message & "','" & STR_USER & "','" & str_Device & "','" &
                                          str_Truck & "','" & str_Location & "','" & str_Process & "'," & str_Card & ")"
                Dim cmd As New OracleCommand(str_sqlex, ConnMyDB)
                cmd.Transaction = tra
                cmd.ExecuteNonQuery()
                tra.Commit()
            Catch ex As Exception
                tra.Rollback()
            End Try
        End Using

    End Sub

    Public Function decode(str_code As String, user_pass As String) As String
        decode = str_code
        For i As Integer = 1 To 3
            decode = Decode_dbase64(decode)
            If decode.Length - user_pass.Length <= 0 Then
                decode = ""
                Exit For
            Else
                decode = decode.Substring(user_pass.Length)
            End If
        Next
        If decode <> user_pass Then
            decode = ""
        End If
    End Function

    Public Function encode(str_code As String) As String
        encode = str_code
        For i As Integer = 1 To 3
            encode = str_code & encode & If(Len(encode) > 2, vbCrLf, "")
            encode = EncodeBase64String(encode)
        Next
        encode = encode
    End Function

    Public Function EncodeBase64String(ByRef str2Encode As String) As String

        Return Convert.ToBase64String(Encoding.UTF8.GetBytes(str2Encode))
    End Function

    Public Function Decode_dbase64(ByVal StSend As String) As String
        Return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(StSend))
    End Function

    Function CHECK_P() As Boolean
        CHECK_P = False
        Try
            Dim CHECK_RS As New OracleDataAdapter("select p_code from t_plant", ConnMyDB)
            Dim dt As New DataTable()
            CHECK_RS.Fill(dt)
            If dt.Rows.Count <= 0 Then Exit Function
            If dt.Rows(0)("p_code").ToString() <> "H541" Then Exit Function
            CHECK_P = True
        Catch ex As Exception
            CHECK_P = False
        End Try
    End Function

    Function CheckGridSelected(ByRef g As DataGridView) As Boolean
        Return g.SelectedRows.Count > 0
    End Function
End Module