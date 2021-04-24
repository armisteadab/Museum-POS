Imports System.Data.SqlClient
Imports IngenicoPOS
Imports Ingenico
Imports System.IO
Imports Microsoft.Reporting
Imports MuseumPOS.My
Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing
Imports System.Xml
Imports Microsoft.VisualBasic.CompilerServices

Module Module1

    Public APPConnectionString As String
    Public BluePay_AccountID As String
    Public BluePay_SecretKey As String
    Public BluePay_Mode As String = "LIVE" '"TEST"

    Public Function QTrim(ByVal sPar As String) As String
        sPar = "" & sPar
        Return "'" & sPar.Trim & "'"
    End Function
    Public Function AddLikeSymbol(ByVal sPar As String) As String
        sPar = "" & sPar
        Return "%" & sPar.Trim & "%"
    End Function

    Public Function QLike(ByVal sPar As String) As String
        sPar = "" & sPar
        Return "'%" & sPar.Trim & "%'"
    End Function

    Public Sub BigMsgBox(ByVal sMessage As String)
        Dim fMessage As New Dialog1

        fMessage.TextBox1.Text = "" & sMessage
        fMessage.ShowDialog()
        fMessage = Nothing

    End Sub

    Public Sub SaveCCAuthInfo(ByVal sAuthorizationCode As String, ByVal sTransactionID As String)
        Dim commandSQL1 As SqlCommand
        Dim sConnectionString As String

        sConnectionString = APPConnectionString
        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()
        Dim sqlConnect1 As New SqlConnection(sConnectionString)

        sqlString = "INSERT INTO CCAuth(AuthCode, TransactionID, AuthDateTime) VALUES ("
        sqlString += QTrim(sAuthorizationCode) + "," + QTrim(sTransactionID) + ", CURRENT_TIMESTAMP)"

        Try

            sqlConnect1.Open()
            commandSQL1 = New SqlCommand(sqlString, sqlConnect1)
            'commandSQL1.CommandType = CommandType.Text
            commandSQL1.ExecuteNonQuery()
            commandSQL1.Dispose()
            sqlConnect1.Close()

        Catch ex As ArgumentException
            BigMsgBox("" & ex.Message)

        Finally

        End Try
        Debug.Print(sqlString)


    End Sub

    Public Function GetTransactionCodeByCCAuthCode(ByVal sAuthorizationCode As String) As String
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String, sReturnValue As String

        sConnectionString = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "SELECT AuthCode, TransactionID FROM CCAuth WHERE AuthCode = " + QTrim(sAuthorizationCode)
        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

        sReturnValue = ""
        If reader.HasRows Then
            On Error Resume Next

            reader.Read()
            sReturnValue = 0 + reader.Item("AuthCode")
        End If

        reader.Close()

        sqlConnect.Close()
        Return sReturnValue
    End Function

    Public Function GetSumByDatePayType(ByVal sPayType As String, ByVal sDate As String) As Double
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String
        Dim nReturnSum As Double

        sConnectionString = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "SELECT SUM(Paid) as SumReturn FROM Receipt WHERE ReceiptDate = "
        sqlString += QTrim(sDate)
        sqlString += " And PayType = "
        sqlString += QTrim(sPayType)
        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            On Error Resume Next

            reader.Read()
            nReturnSum = (reader.Item("SumReturn"))
        End If

        reader.Close()

        sqlConnect.Close()

        Return (nReturnSum)
    End Function

    Public Function GetSumTicketsByDate(ByVal sDate As String) As Double
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String
        Dim nReturnSum As Double

        sConnectionString = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "SELECT SUM(a.Paid) as SumReturn, b.InvName FROM Receipt AS a INNER JOIN InventoryItems AS b"
        sqlString += " ON a.UPC = b.InvUPC "
        sqlString += "WHERE ReceiptDate = "
        sqlString += QTrim(sDate)
        sqlString += " AND b.Department = 'Tickets'"
        sqlString += " GROUP BY b.InvName"

        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            On Error Resume Next

            While reader.Read()
                nReturnSum += (reader.Item("SumReturn"))
            End While
        End If

        reader.Close()

        sqlConnect.Close()

        Return (nReturnSum)
    End Function

    Public Function GetSumTimeAttendanceByDateRange(ByVal sDate1 As String, sDate2 As String) As Double
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String
        Dim nReturnSum As Double, nRunningTotal As Double

        sConnectionString = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "SELECT Worker, TimeIN, TimeOUT "
        sqlString += "FROM Attendance "
        sqlString += "WHERE TimeIN >= " & QTrim(sDate1)
        sqlString += " AND TimeOUT <= " & QTrim(sDate2)
        sqlString += " AND isnull(TimeOUT,'') <> ''" ' no incomplete checkout
        sqlString += " ORDER BY Id"

        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            On Error Resume Next

            While reader.Read()
                nRunningTotal = Math.Abs(DateDiff("n", reader.Item("TimeIN"), reader.Item("TimeOUT")))
                nReturnSum += nRunningTotal
            End While
        End If

        reader.Close()

        sqlConnect.Close()
        Return (nReturnSum)
    End Function
    Public Function GetSumTimeAttendanceForWorkerByDateRange(ByVal sWorker As String, ByVal sDate1 As String, sDate2 As String) As Double
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String
        Dim nReturnSum As Double, nRunningTotal As Double

        sConnectionString = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "SELECT Worker, TimeIN, TimeOUT "
        sqlString += "FROM Attendance "
        sqlString += "WHERE TimeIN >= " & QTrim(sDate1)
        sqlString += " AND TimeOUT <= " & QTrim(sDate2)
        sqlString += " AND Worker = " & sWorker.Trim
        sqlString += " ORDER BY Id"

        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            On Error Resume Next

            While reader.Read()
                nRunningTotal = Math.Abs(DateDiff("n", reader.Item("TimeIN"), reader.Item("TimeOUT")))
                nReturnSum += nRunningTotal
            End While
        End If

        reader.Close()

        sqlConnect.Close()
        Return (nReturnSum)
    End Function


    Public Function GetMaxItemNumber() As Long
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String
        Dim nReturnMAX As Long

        sConnectionString = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        '        sqlString = "SELECT MAX(Id) as MAXId FROM InventoryItems"
        sqlString = "SELECT TOP 1 Id as MAXId FROM InventoryItems ORDER BY Id DESC"

        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            On Error Resume Next

            While reader.Read()
                nReturnMAX += (reader.Item("MAXId"))
            End While
        End If

        reader.Close()

        sqlConnect.Close()

        Return (nReturnMAX)

    End Function

    Public Sub LoadComboBox(ByVal sComboType$, parObject As ComboBox)

        Dim sqlConnect As New SqlConnection(), sSQL$, sConnectionString$

        sConnectionString = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        sSQL = "SELECT ListOrder, ListValue, ListType, Id FROM ListSetup"
        sSQL += " WHERE ListType = " & QTrim(sComboType)
        sSQL += " ORDER BY ListOrder, Id"

        cmd.CommandText = sSQL
        cmd.Connection = sqlConnect
        ' Create a SqlParameter for each parameter in the stored procedure.

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        Try
            If sqlConnect.State = ConnectionState.Closed Then
                sqlConnect.Open()
            End If
            reader = cmd.ExecuteReader()
            Using reader
                While reader.Read
                    ' Process SprocResults datareader here.
                    parObject.Items.Add(reader.Item("ListValue").ToString.Trim)

                End While
            End Using
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                sqlConnect.Close()
            End If
        End Try

    End Sub

    Public Sub CashTillSetupForToday()
        Dim sqlString As String, sLastDate As String, dLastDate As Date
        Dim sqlConnect As New SqlConnection(), commandSQL As SqlCommand
        Dim sConnectionString As String = APPConnectionString

        ' get previous values
        sqlConnect.ConnectionString = sConnectionString
        sqlString = "SELECT TOP 1 CashDate FROM CASH ORDER BY CashDate DESC"

        commandSQL = New SqlCommand
        commandSQL.Connection = sqlConnect
        commandSQL.CommandText = sqlString

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State
        sLastDate = Today.AddDays(-1).ToShortDateString.Trim
        Try
            If sqlConnect.State = ConnectionState.Closed Then
                sqlConnect.Open()
            End If
            reader = commandSQL.ExecuteReader()
            Using reader
                While reader.Read
                    dLastDate = reader.Item("CashDate")
                    sLastDate = dLastDate.ToShortDateString.Trim
                End While
            End Using
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                sqlConnect.Close()
            End If
        End Try

        If Today.ToShortDateString.Trim = sLastDate Then Exit Sub ' already there

        ' get last cash drawer amount
        sqlString = "EXEC InsertCashTillSetupForToday " + QTrim(sLastDate) + ", " +
                        QTrim(Today.ToShortDateString.Trim)

        Try

            sqlConnect.ConnectionString = sConnectionString
            sqlConnect.Open()
            commandSQL = New SqlCommand(sqlString, sqlConnect)
            commandSQL.ExecuteNonQuery()
            commandSQL.Dispose()

            sqlConnect.Close()

        Catch ex As ArgumentException
            BigMsgBox("" & ex.Message)

        Finally

        End Try
    End Sub

    Public Sub ReConnectUPCsInReceipts(Optional ByVal noMessage As Boolean = False)
        Dim sqlString$

        sqlString = "select a.UPC, a.paid,a.ReceiptDate, b.InvUPC, b.InvName, b.Id from receipt "
        sqlString += "AS a LEFT OUTER JOIN InventoryItems AS b ON a.UPC = b.InvUPC"
        sqlString += " ORDER BY b.InvUPC  "

        Dim nFixedRecords As Long
        nFixedRecords = ReConnectUPCsBySQL(sqlString)

        sqlString = "select a.UPC, a.paid,a.ReceiptDate, b.InvUPC, b.InvName, a.Id, a.Description from receipt AS a LEFT JOIN InventoryItems AS b ON a.Description = b.InvName WHERE a.Paid > 0 AND a.UPC <> b.InvUPC AND LEN(a.UPC) < 7 ORDER BY a.Id  "

        nFixedRecords = nFixedRecords + (ReConnectUPCsBySQL(sqlString))

        If Not noMessage Then
            If Not (nFixedRecords > 0) Then
                BigMsgBox("No Unlinked Records Found.")
            Else
                BigMsgBox(nFixedRecords.ToString.Trim + " Posts Linked.")
            End If
        End If

    End Sub
    Public Function ReConnectUPCsBySQL(Optional ByVal sqlString As String = "") As Long
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String
        Dim sNewUPC As String
        Dim sItemNumber As String, sID As String = ""

        sConnectionString = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        Dim bFixedRecords As Boolean, nFixedRecords As Long

        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State
        Dim sInvUPC As String, sUPCinPost As String

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            '            On Error Resume Next

            While reader.Read()

                sInvUPC = ("" + reader.Item("InvUPC").ToString.Trim)
                sUPCinPost = ("" + reader.Item("UPC").ToString.Trim)
                sItemNumber = ("" + reader.Item("Id").ToString.Trim)

                If sUPCinPost <> sInvUPC Then
                    If sItemNumber.Trim <> "" Then
                        If sInvUPC.Trim = "" Then
                            sNewUPC = GetUPCByItemNumber(sItemNumber)
                        Else
                            sNewUPC = sInvUPC
                        End If

                        sNewUPC = sNewUPC.Trim
                        sUPCinPost = sUPCinPost.Trim

                        If sNewUPC.Trim <> "" Then
                            UpdateReceiptUPC(sNewUPC, sUPCinPost)
                            bFixedRecords = True
                            nFixedRecords += 1
                        End If
                    End If
                End If
            End While
        Else
        End If

        reader.Close()

        sqlConnect.Close()

        Return nFixedRecords
    End Function


    Public Function GetUPCByItemNumber(ByVal parItemNumber As String) As String
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String
        Dim sReturnUPC As String

        sReturnUPC = ""

        sConnectionString = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "select a.Id, a.InvUPC FROM InventoryItems a WHERE a.Id = " + parItemNumber

        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            On Error Resume Next

            While reader.Read()
                sReturnUPC = (reader.Item("InvUPC"))
            End While
        End If

        reader.Close()

        sqlConnect.Close()

        Return sReturnUPC

    End Function



    Public Function UpdateReceiptUPC(ByVal sNewUPC As String, ByVal sOldUPC As String) As Long
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String
        Dim nReturnMAX As Long

        sConnectionString = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "UPDATE Receipt SET UPC = " + QTrim(sNewUPC) + " WHERE UPC = " + QTrim(sOldUPC)

        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect
        Try

            sqlConnect.Open()
            cmd = New SqlCommand(sqlString, sqlConnect)
            'commandSQL1.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            sqlConnect.Close()

        Catch ex As ArgumentException
            BigMsgBox("" & ex.Message)

        Finally

        End Try
        Debug.Print(sqlString)


        Return (nReturnMAX)

    End Function

    Public Function GetItemPriceNameByUPC(ByVal pUPC As String) As String
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String
        Dim sReturnString As String


        sConnectionString = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand, nPrice As Double
        cmd.CommandType = CommandType.Text

        sqlString = "SELECT InvName, InvPrice  FROM InventoryItems WHERE InvUPC = " + QTrim(pUPC)

        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()
        sReturnString = ""
        If reader.HasRows Then
            On Error Resume Next

            While reader.Read()
                sReturnString += (reader.Item("InvName"))
                sReturnString += Chr(10) + Chr(13)
                nPrice = (reader.Item("InvPrice"))
                sReturnString += String.Format("{0,-10:C}", nPrice)

            End While
        End If

        reader.Close()

        sqlConnect.Close()

        Return (sReturnString)

    End Function

    Public Sub ArchiveReceipts()
        ' archive receipts more than 4 months old

        Dim MaxARCHIVEDReceiptNumber As Long = GetMaxARCHIVEDReceiptNumber()


        Dim commandSQL1 As SqlCommand
        Dim sConnectionString As String

        sConnectionString = APPConnectionString
        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection()
        Dim sqlConnect1 As New SqlConnection(sConnectionString)

        sqlString = "INSERT INTO ReceiptsReporting"
        sqlString += "(UPC, Price,Paid, TaxPaid, ReceiptID, Quantity,  TaxRate, Description, ReceiptDateTime, ReceiptDate, PayType,  CardType) "

        sqlString += " SELECT UPC, Price,Paid, TaxPaid, ReceiptID, Quantity, TaxRate, Description, ReceiptDateTime, ReceiptDate, PayType, CardType"
        sqlString += "  FROM Receipt a WHERE DATEDIFF(dd, a.ReceiptDate, '" + Today.Date + "') > 1"
        ''        sqlString += "  FROM Receipt a WHERE DATEDIFF(dd, a.ReceiptDate, '" + Today.Date.AddMonths(-2) + "') > 1"
        sqlString += " AND a.ReceiptID > " + MaxARCHIVEDReceiptNumber.ToString.Trim

        Debug.Print(sqlString)

        Try

            sqlConnect1.Open()
            commandSQL1 = New SqlCommand(sqlString, sqlConnect1)
            'commandSQL1.CommandType = CommandType.Text
            commandSQL1.ExecuteNonQuery()
            commandSQL1.Dispose()
            sqlConnect1.Close()

        Catch ex As ArgumentException
            BigMsgBox("" & ex.Message)

        Finally

        End Try
        Debug.Print(sqlString)


    End Sub

    Public Function GetMaxARCHIVEDReceiptNumber() As Long
        Dim sqlConnect As New SqlConnection()
        Dim sConnectionString As String, sqlString As String
        Dim nReturnMAX As Long

        sConnectionString = APPConnectionString

        sqlConnect.ConnectionString = sConnectionString
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        sqlString = "SELECT TOP 1 ReceiptID as MAXId FROM ReceiptsReporting ORDER BY ReceiptID DESC"

        cmd.CommandText = sqlString
        cmd.Connection = sqlConnect

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State

        If sqlConnect.State = ConnectionState.Closed Then
            sqlConnect.Open()
        End If
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            On Error Resume Next

            While reader.Read()
                nReturnMAX += (reader.Item("MAXId"))
            End While
        End If

        reader.Close()

        sqlConnect.Close()

        Return (nReturnMAX)

    End Function


End Module
