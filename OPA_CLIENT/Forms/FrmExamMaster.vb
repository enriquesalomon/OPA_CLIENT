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

            'Dim num As Integer
            'num = 0
            'Globaluserid = ""
            'query = "Select *  from examquestion_essay"
            'runServer()
            'MysqlConn.Open()
            'COMMAND = New MySqlCommand(query, MysqlConn)
            'SDA.SelectCommand = COMMAND
            'SDA.Fill(dbDataset)
            'bSource.DataSource = dbDataset
            'READER = COMMAND.ExecuteReader
            'While READER.Read()
            '    num = READER("num").ToString


            'End While
            'READER.Close()
            'MysqlConn.Close()
        Next datagrd



        Dim num As Integer = 0
        query = "Select  COUNT(*) as totalcount from  (examsubject inner join examquestion on examquestion.examsubjectid = examsubject.id) WHERE examquestion.examid='" & examid & "'"
        runServer()
        MysqlConn.Open()
        COMMAND = New MySqlCommand(query, MysqlConn)
        SDA.SelectCommand = COMMAND
        SDA.Fill(dbDataset)
        bSource.DataSource = dbDataset
        READER = COMMAND.ExecuteReader
        While READER.Read()
            num = READER("totalcount")
        End While
        READER.Close()
        MysqlConn.Close()


        xdataTable.Rows.Clear()
        xdataset.Clear()
        runServer()
        MysqlConn.Open()
        mycommand = MysqlConn.CreateCommand
        mycommand.CommandText = "Select  * from  (examsubject inner join subjects on examsubject.subjectid = subjects.id) WHERE examsubject.examid='" & examid.ToString & "'"

        myadapter.SelectCommand = mycommand
        myadapter.Fill(xdataset, "examsubject")
        xdataTable = xdataset.Tables("examsubject")
        If xdataTable.Rows.Count > 0 Then
            For Each str As DataRow In xdataTable.Rows
                subjectid = str("id")
            Next
        End If
        xdataTable.Rows.Clear()
        xdataset.Clear()


    End Sub

    Private Sub dtgList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgList.CellClick

        If e.ColumnIndex = 6 Then


            Dim GridRow As DataGridViewRow = dtgList.CurrentRow
            Dim examstatus As String = ""
            For Each datagrd As DataGridViewRow In dtgList.SelectedRows

                examstatus = CStr(GridRow.Cells.Item("status").Value)

            Next datagrd

            If examstatus = "CLOSED" Then


                If MessageBox.Show("EXAM IS ALREADY CLOSED" & vbNewLine & " " & vbNewLine & "", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                    Exit Sub
                End If



            Else


                LoadData()
                ''CHECK IF THERE IS A QUESTIONS
                Dim hasquestionsnuymber As Integer = 0
                query = "Select  COUNT(*) as totalcount from  (examsubject inner join examquestion on examquestion.examsubjectid = examsubject.id) WHERE examquestion.examid='" & examid & "'"
                runServer()
                MysqlConn.Open()
                COMMAND = New MySqlCommand(query, MysqlConn)
                SDA.SelectCommand = COMMAND
                SDA.Fill(dbDataset)
                bSource.DataSource = dbDataset
                READER = COMMAND.ExecuteReader
                While READER.Read()
                    hasquestionsnuymber = READER("totalcount").ToString
                End While
                READER.Close()
                MysqlConn.Close()

                If hasquestionsnuymber < 1 Then
                    MsgBox("No question")
                Else
                    If MessageBox.Show("Are you sure you want to proceed? " & vbNewLine & " " & vbNewLine & "", " Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                        FrmTakeExam.ShowDialog()
                    End If
                End If
            End If





        End If
    End Sub
End Class