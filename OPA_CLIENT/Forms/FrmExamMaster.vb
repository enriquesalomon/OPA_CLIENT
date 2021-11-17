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


        'xdataTable.Rows.Clear()
        'xdataset.Clear()
        'runServer()
        'MysqlConn.Open()
        'mycommand = MysqlConn.CreateCommand
        'mycommand.CommandText = "Select  * from  (examsubject inner join subjects on examsubject.subjectid = subjects.id) WHERE examsubject.examid='" & examid.ToString & "'"

        'myadapter.SelectCommand = mycommand
        'myadapter.Fill(xdataset, "examsubject")
        'xdataTable = xdataset.Tables("examsubject")
        'If xdataTable.Rows.Count > 0 Then
        '    For Each str As DataRow In xdataTable.Rows
        '        subjectid = str("id")
        '    Next
        'End If
        'xdataTable.Rows.Clear()
        'xdataset.Clear()


    End Sub
    Dim totalquestion As Integer
    Private Sub dtgList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgList.CellClick

        If e.ColumnIndex = 7 Then


            Dim GridRow As DataGridViewRow = dtgList.CurrentRow
            Dim examstatus As String = ""
            For Each datagrd As DataGridViewRow In dtgList.SelectedRows

                examstatus = CStr(GridRow.Cells.Item("status").Value)
                examtype = CStr(GridRow.Cells.Item("type").Value)
                examid = CStr(GridRow.Cells.Item("id").Value)
                examineeexamid = CStr(GridRow.Cells.Item("examineeid").Value)

            Next datagrd
            If CInt(GridRow.Cells.Item("id").Value) < 1 Then
                MsgBox("Cannot Proceed to Exam, No time limit has been set")
                Exit Sub
            End If
            If examtype = "Multiple Choice" Then


                If examstatus = "CLOSED" Then
                    If MessageBox.Show("EXAM IS ALREADY CLOSED" & vbNewLine & " " & vbNewLine & "", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                        Exit Sub
                    End If
                Else
                    LoadData()
                    ''CHECK IF THERE IS A QUESTIONS
                    Dim hasquestionsnuymber As Integer = 0
                    query = "Select  COUNT(*) as totalcount from  (examsubject inner join examquestion on examquestion.examsubjectid = examsubject.id ) WHERE examquestion.examsubjectid='" & examid & "'"
                    runServer()
                    MysqlConn.Open()
                    COMMAND = New MySqlCommand(query, MysqlConn)
                    SDA.SelectCommand = COMMAND
                    SDA.Fill(dbDataset)
                    bSource.DataSource = dbDataset
                    READER = COMMAND.ExecuteReader
                    While READER.Read()
                        hasquestionsnuymber = READER("totalcount").ToString
                        totalquestion = hasquestionsnuymber
                    End While
                    READER.Close()
                    MysqlConn.Close()

                    If hasquestionsnuymber < 1 Then
                        MsgBox("No question")
                    Else
                        If MessageBox.Show("Are you sure you want to proceed? " & vbNewLine & " " & vbNewLine & "", " Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                            generateExamAnswerDb()

                            FrmTakeExamMultipleChoice.ShowDialog()
                        End If
                    End If
                End If
            End If


            If examtype = "Essay" Then

                If examstatus = "CLOSED" Then
                    If MessageBox.Show("EXAM IS ALREADY CLOSED" & vbNewLine & " " & vbNewLine & "", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                        Exit Sub
                    End If
                Else
                    LoadData()
                    ''CHECK IF THERE IS A QUESTIONS
                    Dim hasquestionsnuymber As Integer = 0

                    query = "Select  COUNT(*) as totalcount from  (examsubject_essay inner join examquestion_essay on examquestion_essay.examsubjectid = examsubject_essay.id) WHERE examquestion_essay.examsubjectid='" & examid & "'"

                    runServer()
                    MysqlConn.Open()
                    COMMAND = New MySqlCommand(query, MysqlConn)
                    SDA.SelectCommand = COMMAND
                    SDA.Fill(dbDataset)
                    bSource.DataSource = dbDataset
                    READER = COMMAND.ExecuteReader
                    While READER.Read()
                        hasquestionsnuymber = READER("totalcount").ToString
                        totalquestion = hasquestionsnuymber
                    End While
                    READER.Close()
                    MysqlConn.Close()

                    If hasquestionsnuymber < 1 Then
                        MsgBox("No question")
                    Else
                        If MessageBox.Show("Are you sure you want to proceed? " & vbNewLine & " " & vbNewLine & "", " Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                            generateExamAnswerDb()

                            FrmTakeExamEssay.ShowDialog()
                        End If
                    End If
                End If
            End If


            If examtype = "True or False" Then


                If examstatus = "CLOSED" Then
                    If MessageBox.Show("EXAM IS ALREADY CLOSED" & vbNewLine & " " & vbNewLine & "", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                        Exit Sub
                    End If
                Else
                    LoadData()
                    ''CHECK IF THERE IS A QUESTIONS
                    Dim hasquestionsnuymber As Integer = 0

                    'query = "Select COUNT(*) as totalcount from  (examsubject inner join examquestion_truefalse on examquestion_truefalse.examsubjectid = examsubject.id) WHERE examquestion_truefalse.examsubjectid='" & examid & "'"
                    query = "Select  COUNT(*) as totalcount from  (examsubject_truefalse inner join examquestion_truefalse on examquestion_truefalse.examsubjectid = examsubject_truefalse.id ) WHERE examquestion_truefalse.examsubjectid='" & examid & "'"

                    runServer()
                    MysqlConn.Open()
                    COMMAND = New MySqlCommand(query, MysqlConn)
                    SDA.SelectCommand = COMMAND
                    SDA.Fill(dbDataset)
                    bSource.DataSource = dbDataset
                    READER = COMMAND.ExecuteReader
                    While READER.Read()
                        hasquestionsnuymber = READER("totalcount").ToString
                        totalquestion = hasquestionsnuymber
                    End While
                    READER.Close()
                    MysqlConn.Close()

                    If hasquestionsnuymber < 1 Then
                        MsgBox("No question")
                    Else
                        If MessageBox.Show("Are you sure you want to proceed? " & vbNewLine & " " & vbNewLine & "", " Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                            generateExamAnswerDb()

                            FrmTakeExamMultipleChoice.ShowDialog()
                        End If
                    End If
                End If
            End If




        End If
    End Sub

    Sub generateExamAnswerDb()
        If examtype = "Multiple Choice" Then
            Dim correctanswer As String = ""
            Dim num As Integer = 0
            query = "Select COUNT(*) as num from exam_answer_multiplechoice where studentid= '" & Globaluserid & "' and examid= '" & examid & "' and examsubjectid= '" & subjectid & "'"
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
            If num = 0 Then
                Dim questnum As Integer = 1
                While questnum <= totalquestion


                    xdataTable.Rows.Clear()
                    xdataset.Clear()
                    runServer()
                    MysqlConn.Open()
                    mycommand = MysqlConn.CreateCommand
                    mycommand.CommandText = "Select  * from  (subjects inner join exammaster on subjects.id = exammaster.subjectid) WHERE exammaster.examid='" & examineeexamid & "'"

                    myadapter.SelectCommand = mycommand
                    myadapter.Fill(xdataset, "exammaster")
                    xdataTable = xdataset.Tables("exammaster")
                    If xdataTable.Rows.Count > 0 Then
                        For Each str As DataRow In xdataTable.Rows

                            examtype = str("examtype").ToString
                            subjectid = str("subjectid").ToString

                        Next
                    End If
                    xdataTable.Rows.Clear()
                    xdataset.Clear()




                    runServer()
                    MysqlConn.Open()
                    query = "insert into exam_answer_multiplechoice (studentid,studentno,examid,examsubjectid,questionnum,Correct,examquestionid) values ('" & Globaluserid & "','" & studentno & "','" & examid & "','" & subjectid & "','" & questnum & "','" & "" & "','" & "" & "')"
                    COMMAND = New MySqlCommand(query, MysqlConn)
                    READER = COMMAND.ExecuteReader
                    MysqlConn.Close()
                    questnum += 1
                End While
            End If
        End If



        If examtype = "Essay" Then
            Dim num As Integer = 0
            query = "Select COUNT(*) as num from exam_answer_essay where studentid= '" & Globaluserid & "' and examid= '" & examid & "' and examsubjectid= '" & subjectid & "'"
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

            If num = 0 Then
                Dim questnum As Integer = 1
                While questnum <= totalquestion
                    runServer()
                    MysqlConn.Open()
                    query = "insert into exam_answer_essay (studentid,studentno,examid,examsubjectid,questionnum,answer,answerdescription,points) values ('" & Globaluserid & "','" & studentno & "','" & examid & "','" & subjectid & "','" & questnum & "','" & "" & "','" & "" & "','" & "" & "')"
                    COMMAND = New MySqlCommand(query, MysqlConn)
                    READER = COMMAND.ExecuteReader
                    MysqlConn.Close()
                    questnum += 1
                End While
            End If
        End If

        If examtype = "True or False" Then
            Dim num As Integer = 0
            query = "Select COUNT(*) as num from exam_answer_truefalse where studentid= '" & Globaluserid & "' and examid= '" & examid & "' and examsubjectid= '" & subjectid & "'"
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

            If num = 0 Then
                Dim questnum As Integer = 1
                While questnum <= totalquestion
                    runServer()
                    MysqlConn.Open()
                    query = "insert into exam_answer_truefalse (studentid,studentno,examid,examsubjectid,questionnum,answer,answerdescription) values ('" & Globaluserid & "','" & studentno & "','" & examid & "','" & subjectid & "','" & questnum & "','" & "" & "','" & "" & "')"
                    COMMAND = New MySqlCommand(query, MysqlConn)
                    READER = COMMAND.ExecuteReader
                    MysqlConn.Close()
                    questnum += 1
                End While
            End If
        End If








    End Sub

    Private Sub dtgList_CellBorderStyleChanged(sender As Object, e As EventArgs) Handles dtgList.CellBorderStyleChanged

    End Sub
End Class