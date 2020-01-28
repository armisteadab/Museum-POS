Imports System.Data.SqlClient
Public Class POSMain
    Dim nReceiptNumber As Integer
    Private nReceiptCurrent As Integer

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        InventoryItem.ShowDialog()
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
End Class