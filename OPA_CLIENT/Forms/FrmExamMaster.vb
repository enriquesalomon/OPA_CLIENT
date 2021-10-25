Imports MySql.Data.MySqlClient
Public Class FrmExamMaster
    Private Sub FrmExamMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyExam.ExamList()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With Me
            Dispose()
        End With
    End Sub

    Public Sub LoadData()
        Dim GridRow As DataGridViewRow = dtgList.CurrentRow

        For Each datagrd As DataGridViewRow In dtgList.SelectedRows
            examcode = CStr(GridRow.Cells.Item("examcode").Value) + " | " + CStr(GridRow.Cells.Item("subject").Value) + " | " + CStr(GridRow.Cells.Item("type").Value)
            examid = CStr(GridRow.Cells.Item("id").Value)
            'examtype = CStr(GridRow.Cells.Item("type").Value)
            'subject = CStr(GridRow.Cells.Item("subject").Value)
        Next datagrd

        If examtype = "Essay" Then
            Dim num As Integer
            num = 0
            Globaluserid = ""
            query = "Select COUNT(*) as num from examquestion_essay"
            runServer()
            MysqlConn.Open()
            COMMAND = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataset)
            bSource.DataSource = dbDataset
            READER = COMMAND.ExecuteReader
            While READER.Read()
                num = READER("num").ToString


            End While
            READER.Close()
            MysqlConn.Close()
        End If
        If examtype = "Multiple Choice" Then

        End If
        If examtype = "True or False" Then

        End If
    End Sub

    Private Sub dtgList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgList.CellClick
        examcode = ""
        If e.ColumnIndex = 6 Then
            If MessageBox.Show("Are you sure you want to proceed? " & vbNewLine & " " & vbNewLine & "", " Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                LoadData()
                FrmTakeExam.ShowDialog()
            End If

        End If
    End Sub
End Class