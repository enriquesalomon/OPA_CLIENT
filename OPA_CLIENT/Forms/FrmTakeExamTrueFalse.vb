Imports MySql.Data.MySqlClient
Public Class FrmTakeExamTrueFalse


    Sub UpdateExamRecordToClose()
        runServer()
        MysqlConn.Open()
        'query = "insert into exam_answer_multiplechoice (studentid,studentno,examid,examsubjectid,questionnum,answer,answerdescription) values ('" & Globaluserid & "','" & studentno & "','" & examid & "','" & subjectid & "','" & questnum & "','" & "" & "','" & "" & "')"
        query = "update examinee set status='" & "CLOSED" & "',datetaken='" & Date.Now.ToShortDateString & "',startime='" & timelimit & "',timeend='" & tspn.Minutes.ToString + ":" + tspn.Seconds.ToString & "' where examid='" & examineeexamid & "' AND studentid='" & Globaluserid & "'"
        COMMAND = New MySqlCommand(query, MysqlConn)
        READER = COMMAND.ExecuteReader
        MysqlConn.Close()
    End Sub
    Private Sub FrmTakeExamTrueFalse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Visible = False
        lblexamtitle.Text = examcode.ToUpper()
        AnswerList()

        FrmExamStart.ShowDialog()
    End Sub
    Dim questnum As Integer = 0
    Dim totalquestions As Integer = 0

    Dim question As String = ""
    Dim opt1 As String = ""
    Dim opt2 As String = ""
    Dim opt3 As String = ""
    Dim opt4 As String = ""


    Sub getAnswersTable()

        If examtype = "True or False" Then
            Dim ldataset, xdataset As New DataSet

            dtgList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dtgList.Rows.Clear()
            mydataTable.Rows.Clear()
            ldataset.Clear()
            runServer()
            MysqlConn.Open()
            mycommand = MysqlConn.CreateCommand

            mycommand.CommandText = "Select  * from exam_answer_truefalse WHERE examsubjectid='" & subjectid & "' AND examid='" & examid & "' AND studentid='" & Globaluserid & "' ORDER BY questionnum ASC"

            myadapter.SelectCommand = mycommand
            myadapter.Fill(ldataset, "exam_answer_truefalse")
            mydataTable = ldataset.Tables("exam_answer_truefalse")

            dtgList.RowsDefaultCellStyle.BackColor = Color.White
            dtgList.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            dtgList.ColumnCount = 3
            dtgList.Columns(0).HeaderText = "ID"
            dtgList.Columns(0).Width = 0
            dtgList.Columns(0).Name = "id"

            dtgList.Columns(1).HeaderText = "Question #"
            dtgList.Columns(1).Width = 500
            dtgList.Columns(1).Name = "questnum"

            dtgList.Columns(2).HeaderText = "Answer"
            dtgList.Columns(2).Width = 200
            dtgList.Columns(2).Name = "answer"


            If mydataTable.Rows.Count > 0 Then
                For Each mrow As DataRow In mydataTable.Rows
                    Dim row As String() = New String() {mrow("id").ToString, mrow("questionnum").ToString, mrow("answer").ToString}
                    dtgList.Rows.Add(row)
                Next

            End If
        End If



    End Sub

    Dim myanwerpoints As String
    Sub getExamQuestion()


        query = "Select  COUNT(*) as totalcount from  (examsubject_truefalse inner join examquestion_truefalse on examquestion_truefalse.examsubjectid = examsubject_truefalse.id) WHERE examquestion_truefalse.examsubjectid='" & examid & "'"
        'query = "Select  COUNT(*) as totalcount from  examquestion WHERE examsubjectid='" & examineeexamid & "' AND examid='" & examid & "'"


        runServer()
        MysqlConn.Open()
        COMMAND = New MySqlCommand(query, MysqlConn)
        SDA.SelectCommand = COMMAND
        SDA.Fill(dbDataset)
        bSource.DataSource = dbDataset
        READER = COMMAND.ExecuteReader
        While READER.Read()
            totalquestions = READER("totalcount").ToString
        End While
        READER.Close()
        MysqlConn.Close()



        questnum += 1
        If questnum > totalquestions Then
            MsgBox("NO MORE QUESTION")
        End If




        Dim num As Integer
        num = 0

        query = "Select * from examquestion_truefalse  where examsubjectid='" & examid & "' AND num='" & questnum & "'"
        runServer()
        MysqlConn.Open()
        COMMAND = New MySqlCommand(query, MysqlConn)
        SDA.SelectCommand = COMMAND
        SDA.Fill(dbDataset)
        bSource.DataSource = dbDataset
        READER = COMMAND.ExecuteReader
        While READER.Read()
            question = READER("questiontitle").ToString
            opt1 = READER("option1").ToString
            opt2 = READER("option2").ToString

        End While
        READER.Close()
        MysqlConn.Close()
        txtQuestion.Text = question
        RadioButton1.Text = opt1
        RadioButton2.Text = opt2

        xdataTable.Rows.Clear()
        xdataset.Clear()


    End Sub
    Sub AnswerList()



        Try
            'FrmExamMaster.DataGridView1.Font = New Font("Arial", 16, FontStyle.Regular)
            'dtgListAnswer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dtgList.Rows.Clear()
            xdataTable.Rows.Clear()
            xdataset.Clear()
            runServer()
            MysqlConn.Open()
            mycommand = MysqlConn.CreateCommand

            mycommand.CommandText = "Select  * from  (exam inner join examcategory on exam.examcategoryid = examcategory.id) "

            myadapter.SelectCommand = mycommand
            myadapter.Fill(xdataset, "exam")
            mydataTable = xdataset.Tables("exam")

            dtgList.RowsDefaultCellStyle.BackColor = Color.White
            dtgList.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            dtgList.ColumnCount = 2
            dtgList.Columns(0).HeaderText = "#"
            dtgList.Columns(0).Width = 50
            dtgList.Columns(0).Name = "num"

            dtgList.Columns(1).HeaderText = "ANSWER"
            dtgList.Columns(1).Width = 200
            dtgList.Columns(1).Name = "answer"




            'If mydataTable.Rows.Count > 0 Then
            '    For Each mrow As DataRow In mydataTable.Rows

            '        Dim row As String() = New String() {mrow("id").ToString, mrow("sy").ToString + " " + mrow("examcategoryname").ToString, mrow("examtype").ToString, mrow("status").ToString}
            '        FrmExamMaster.dtgList.Rows.Add(row)
            '    Next

            'End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Data Error !!")
        End Try
    End Sub

    Sub deselectradtionbutton()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
    End Sub
    Sub GetAnswers_UpdateAnswer_multiplechoices()
        Dim answer As String = ""
        query = "Select * from exam_answer_multiplechoice where studentid= '" & Globaluserid & "' and examid= '" & examid & "' and examsubjectid= '" & subjectid & "'"
        runServer()
        MysqlConn.Open()
        COMMAND = New MySqlCommand(query, MysqlConn)
        SDA.SelectCommand = COMMAND
        SDA.Fill(dbDataset)
        bSource.DataSource = dbDataset
        READER = COMMAND.ExecuteReader
        While READER.Read()
            answer = READER("answer").ToString
        End While
        READER.Close()
        MysqlConn.Close()

        Select Case answer
            Case "A"
                RadioButton1.Checked = True
            Case "B"
                RadioButton2.Checked = True
            Case Else

        End Select

    End Sub

    Dim noanswer As Boolean
    Dim answerpoints, wrongpoints As String
    Sub UpdateAnswer_TrueFalse()


        Dim questioncorrectanswer As String = ""
        Dim questionid As String = ""
        Dim rightmark As String = ""
        xdataTable.Rows.Clear()
        xdataset.Clear()
        runServer()
        MysqlConn.Open()
        mycommand = MysqlConn.CreateCommand
        mycommand.CommandText = "Select  * from  examquestion_truefalse WHERE examsubjectid='" & examid & "' AND examid='" & examineeexamid & "' "

        myadapter.SelectCommand = mycommand
        myadapter.Fill(xdataset, "examquestion_truefalse")
        xdataTable = xdataset.Tables("examquestion_truefalse")
        If xdataTable.Rows.Count > 0 Then
            For Each str As DataRow In xdataTable.Rows
                questioncorrectanswer = str("answer").ToString
                answerpoints = str("rightmark").ToString
                wrongpoints = str("wrongmark").ToString
                questionid = str("id").ToString
            Next
        End If
        xdataTable.Rows.Clear()
        xdataset.Clear()

        Select Case True
            Case RadioButton1.Checked
                runServer()
                MysqlConn.Open()
                If questioncorrectanswer = "1" Then
                    myanwerpoints = answerpoints
                Else
                    myanwerpoints = wrongpoints
                End If
                ''---------------------------------need to update here examquestionid----------------------------------------------------------
                ''---------------------------------need to update here examquestionid----------------------------------------------------------

                ''---------------------------------need to update here examquestionid----------------------------------------------------------
                ''---------------------------------need to update here examquestionid----------------------------------------------------------
                query = "update exam_answer_truefalse set examquestionid='" & questionid & "', Correct='" & myanwerpoints & "', answer='" & "A" & "' where studentid='" & Globaluserid & "' AND examid='" & examid & "' AND examsubjectid='" & subjectid & "' AND questionnum='" & questnum & "' "
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader
                MysqlConn.Close()

                'runServer()
                'MysqlConn.Open()
                'query = "update exam_answer_multiplechoice set answer='" & "asdasdasd" & "' where id='32' "
                'COMMAND = New MySqlCommand(query, MysqlConn)
                'READER = COMMAND.ExecuteReader
                'MysqlConn.Close()

            Case RadioButton2.Checked
                If questioncorrectanswer = "2" Then
                    myanwerpoints = answerpoints
                Else
                    myanwerpoints = wrongpoints
                End If
                runServer()
                MysqlConn.Open()
                query = "update exam_answer_truefalse set examquestionid='" & questionid & "', Correct='" & myanwerpoints & "', answer='" & "B" & "' where studentid='" & Globaluserid & "' AND examid='" & examid & "' AND examsubjectid='" & subjectid & "' AND questionnum='" & questnum & "' "
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader
                MysqlConn.Close()
            Case Else

                Exit Sub
        End Select

    End Sub
    Dim questionid As String = ""

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to Exit the Exam?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            UpdateExamRecordToClose()
            MsgBox(" Examination Assessment Recorded", MsgBoxStyle.Information)
        Else
            Exit Sub
        End If
        Me.Close()
        MyExam.ExamList()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click


        If examtype = "True or False" Then
            UpdateAnswer_TrueFalse()
        End If
        getAnswersTable()
        If noanswer = True Then
            Exit Sub
        End If

        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MessageBox.Show("No Answer Selected, Please choose your Answer to Proceed to the next question.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        questnum += 1
        If questnum > totalquestions Then
            questnum -= 1
            GroupBox1.Visible = False
            MsgBox("NO MORE QUESTION")
            UpdateExamRecordToClose()
            Timer1.Enabled = False
            MsgBox(" Examination Assessment Recorded", MsgBoxStyle.Information)

            Me.Close()
            MyExam.ExamList()
        End If



        deselectradtionbutton()


        Dim num As Integer
        num = 0

        query = "Select * from examquestion where examsubjectid='" & examid & "' AND examid='" & examineeexamid & "' AND num='" & questnum & "'"
        runServer()
        MysqlConn.Open()
        COMMAND = New MySqlCommand(query, MysqlConn)
        SDA.SelectCommand = COMMAND
        SDA.Fill(dbDataset)
        bSource.DataSource = dbDataset
        READER = COMMAND.ExecuteReader
        While READER.Read()
            question = READER("questiontitle").ToString
            opt1 = READER("option1").ToString
            opt2 = READER("option2").ToString
            opt3 = READER("option3").ToString
            opt4 = READER("option4").ToString
            questionid = READER("id").ToString
        End While
        READER.Close()
        MysqlConn.Close()
        txtQuestion.Text = question
        RadioButton1.Text = opt1
        RadioButton2.Text = opt2

        xdataTable.Rows.Clear()
        xdataset.Clear()
    End Sub


    Public tspn As New TimeSpan()

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        gettime()
    End Sub

    Private Sub gettime()
        tspn = tspn.Subtract(New TimeSpan(0, 0, 1))



        lbltimer.Text = String.Format(" {0} mins : {1} secs", tspn.Minutes, tspn.Seconds)

        If tspn.Minutes = 0 AndAlso tspn.Seconds = 0 Then
            Timer1.Stop()
            MessageBox.Show("Time Ended")

        End If


    End Sub
End Class