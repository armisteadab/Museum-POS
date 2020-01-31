Imports System.Data.SqlClient
Imports IngenicoPOS
Public Class POSMain
    Dim nReceiptNumber As Integer
    Private nReceiptCurrent As Integer
    Private bSearchReady As Boolean

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        Dim fInventoryItem As New InventoryItem
        fInventoryItem.ShowDialog()
        fInventoryItem = Nothing

    End Sub

    Private Sub POSMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewReceiptID()
    End Sub

    Private Sub NewReceiptID()

        Dim sqlString As String, AlreadyInTable As Boolean = False
        Dim sqlConnect As New SqlConnection(), sConnectionString$
        Dim nReceiptCount As New Integer

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString
        sqlConnect.Open()

        Dim commandSQL As SqlCommand
        Dim bAnyRecordsAtAll As Boolean

        commandSQL = New SqlCommand()
        commandSQL.CommandType = CommandType.Text
        commandSQL.CommandText = "SELECT Count(ReceiptID) as CountID from Receipt"
        commandSQL.Connection = sqlConnect

        Dim reader = commandSQL.ExecuteReader()
        Try
            If reader.HasRows Then
                ' nReceiptCount = 0 + reader.Item("CountID")
                bAnyRecordsAtAll = (nReceiptCount > 0)
            End If
        Catch ex As ArgumentException

        End Try

        If bAnyRecordsAtAll Then
            sqlString = "SELECT Max(ReceiptID) as MaxID, Count(ReceiptID) as CountID from Receipt"
            commandSQL = New SqlCommand(sqlString, sqlConnect)

            Try
                If reader.HasRows Then
                    nReceiptCurrent = 0 + reader.Item("MaxID")
                    bAnyRecordsAtAll = True
                End If
            Catch ex As ArgumentException

            End Try
        End If

        nReceiptCurrent += 1
        Me.ReceiptNumber = (nReceiptCurrent)
        reader.Close()
        sqlConnect.Close()

    End Sub

    Public Property ReceiptNumber() As Integer
        Get
            Return nReceiptNumber
        End Get
        Set(ByVal value As Integer)
            lblReceiptNumber.Text = value.ToString.Trim
            nReceiptNumber = (value)

        End Set
    End Property

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim oPos As New POS(1)
        oPos.Connect()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim sEntry As String

        sEntry = txtEntry.Text.Trim
        If sEntry.Length >= 3 Then
            ' something to search for
            If bSearchReady Then RunSearch()
            bSearchReady = False ' until more characters added to search, this is it

        Else
            DataGridView2.Visible = False


        End If
        txtEntry.Focus()

    End Sub

    Private Sub RunSearch()

        Dim sqlConnect As New SqlConnection(), sSQL$
        Dim sConnectionString As String

        sConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\armis\source\repos\MuseumPOS\Museum POS\MuseumPOS\MuseumPOS.mdf;Integrated Security=True;Connect Timeout=30"

        sqlConnect.ConnectionString = sConnectionString

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        sSQL = "SELECT Id, InvUPC, InvName, InvType, Vendor, Department, InvPrice, InvCost, OnHandQuantity, InvNotes, UniqueID FROM InventoryItems"
        sSQL += " WHERE InvUPC LIKE " & QLike(txtEntry.Text)
        sSQL += " OR InvName LIKE " & QLike(txtEntry.Text)
        sSQL += " OR Id LIKE " & QLike(txtEntry.Text)

        cmd.CommandText = sSQL
        cmd.Connection = sqlConnect
        ' Create a SqlParameter for each parameter in the stored procedure.

        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState = sqlConnect.State
        Dim nPriceDisplayGrid As Double, sPriceDisplayGrid As String

        Me.DataGridView2.Rows.Clear()

        Try
            If sqlConnect.State = ConnectionState.Closed Then
                sqlConnect.Open()
            End If
            reader = cmd.ExecuteReader()
            Using reader
                While reader.Read
                    ' Process SprocResults datareader here.
                    nPriceDisplayGrid = reader.Item("InvPrice")
                    sPriceDisplayGrid = Strings.FormatNumber(reader.Item("InvPrice"), 2)

                    Me.DataGridView2.Rows.Add(reader.Item("InvName"), reader.Item("InvType"), reader.Item("Department"),
                                              reader.Item("Vendor"), sPriceDisplayGrid, reader.Item("InvCost"),
                                              reader.Item("OnHandQuantity"), reader.Item("Id"), reader.Item("InvUPC"), reader.Item("UniqueID"))
                End While
            End Using
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                sqlConnect.Close()
            End If
        End Try

        If DataGridView2.Rows.Count > 0 Then
            DataGridView2.Visible = True
            '       Me.DataGridView1.Rows.Remove(DataGridView1.Rows(DataGridView1.Rows.Count - 1))
        End If


    End Sub

    Private Sub txtEntry_TextChanged(sender As Object, e As EventArgs) Handles txtEntry.TextChanged
        DataGridView2.Visible = False
        bSearchReady = True ' new search now possible
    End Sub
End Class