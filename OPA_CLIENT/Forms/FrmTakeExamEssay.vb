Imports MySql.Data.MySqlClient
Public Class FrmTakeExamEssay
    Private Sub FrmTakeExamEssay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox2.Visible = False
        lblexamtitle.Text = examcode.ToUpper()
        'AnswerList()

        FrmExamStart.ShowDialog()


    End Sub


    Public tspn As New TimeSpan()
    Private Sub gettime()
        tspn = tspn.Subtract(New TimeSpan(0, 0, 1))



        lbltimer.Text = String.Format(" {0} mins : {1} secs", tspn.Minutes, tspn.Seconds)

        If tspn.Minutes = 0 AndAlso tspn.Seconds = 0 Then
            Timer1.Stop()


            If MessageBox.Show("YOUR TIME IS UP", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                UpdateExamRecordToClose()
                MsgBox(" Examination Assessment Recorded", MsgBoxStyle.Information)
                Me.Close()
                MyExam.ExamList()
            End If


        End If



    End Sub
    Dim questnum As Integer = 0
    Dim totalquestions As Integer = 0

    Dim question As String = ""
    Dim opt1 As String = ""
    Dim opt2 As String = ""
    Dim opt3 As String = ""
    Dim opt4 As String = ""
    Sub getExamQuestion()
        Try


            query = "Select  COUNT(*) as totalcount from  (examsubject_essay inner join examquestion_essay on examquestion_essay.examsubjectid = examsubject_essay.id) WHERE examquestion_essay.examsubjectid='" & examid & "'"

        'query = "Select  COUNT(*) as totalcount from  (examsubject inner join examquestion_essay on examquestion_essay.examsubjectid = examsubject.id) WHERE examquestion_essay.examsubjectid='" & examid & "'"
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
            questnum -= 1
        End If




        Dim num As Integer
        num = 0
        query = "Select * from examquestion_essay where examsubjectid='" & examid & "' AND num='" & questnum & "'"
        'query = "Select * from examquestion_essay where examsubjectid='" & subjectid & "' AND examid='" & examid & "' AND num='" & questnum & "'"
        runServer()
        MysqlConn.Open()
        COMMAND = New MySqlCommand(query, MysqlConn)
        SDA.SelectCommand = COMMAND
        SDA.Fill(dbDataset)
        bSource.DataSource = dbDataset
        READER = COMMAND.ExecuteReader
        While READER.Read()
            question = READER("questiontitle").ToString

        End While
        READER.Close()
        MysqlConn.Close()
        txtQuestion.Text = question


        xdataTable.Rows.Clear()
        xdataset.Clear()



        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        gettime()
    End Sub

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
    Dim noanswer As Boolean
    Dim answerpoints, wrongpoints As String

    Sub UpdateAnswer_Essay()
        Try

            Dim totalitems As String = ""
        Dim questioncorrectanswer As String = ""
        Dim questionid As String = ""
        Dim rightmark As String = ""
        xdataTable.Rows.Clear()
        xdataset.Clear()
        runServer()
        MysqlConn.Open()
        mycommand = MysqlConn.CreateCommand
        mycommand.CommandText = "Select  * from  examquestion_essay WHERE examsubjectid='" & examid & "' AND examid='" & examineeexamid & "' "

        myadapter.SelectCommand = mycommand
        myadapter.Fill(xdataset, "examquestion_essay")
        xdataTable = xdataset.Tables("examquestion_essay")
        If xdataTable.Rows.Count > 0 Then
            For Each str As DataRow In xdataTable.Rows
                answerpoints = str("highestmark").ToString
                questionid = str("id").ToString
                totalitems = answerpoints
            Next
        End If
        xdataTable.Rows.Clear()
        xdataset.Clear()


        query = "update exam_answer_essay set examquestionid='" & questionid & "', Correct='" & answerpoints & "', answer='" & txtAnswerEssay.Text.ToString & "', totalitems='" & totalitems & "' where studentid='" & Globaluserid & "' AND examid='" & examid & "' AND examsubjectid='" & subjectid & "' AND questionnum='" & questnum & "' "
        COMMAND = New MySqlCommand(query, MysqlConn)
        READER = COMMAND.ExecuteReader
        MysqlConn.Close()


        Catch ex As Exception

        End Try

    End Sub


    Sub UpdateExamRecordToClose()
        Try

            runServer()
        MysqlConn.Open()
        'query = "insert into exam_answer_multiplechoice (studentid,studentno,examid,examsubjectid,questionnum,answer,answerdescription) values ('" & Globaluserid & "','" & studentno & "','" & examid & "','" & subjectid & "','" & questnum & "','" & "" & "','" & "" & "')"
        query = "update examinee set status='" & "CLOSED" & "',datetaken='" & Date.Now.ToShortDateString & "',startime='" & timelimit & "',timeend='" & tspn.Minutes.ToString + ":" + tspn.Seconds.ToString & "' where examid='" & examineeexamid & "' AND studentid='" & Globaluserid & "'"

        COMMAND = New MySqlCommand(query, MysqlConn)
        READER = COMMAND.ExecuteReader
            MysqlConn.Close()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Try

            UpdateAnswer_Essay()

        If noanswer = True Then
            Exit Sub
        End If
        If txtAnswerEssay.Text = "" Then

            MessageBox.Show("No Answer Inputed, Please input your Answer to Proceed to the next question.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            txtAnswerEssay.Text = ""
        End If
        questnum += 1
        If questnum > totalquestions Then
            questnum -= 1
            GroupBox2.Visible = False
            MsgBox("NO MORE QUESTION")
            UpdateExamRecordToClose()
            Timer1.Enabled = False
            MsgBox(" Examination Assessment Recorded", MsgBoxStyle.Information)

            Me.Close()


            MyExam.ExamList()
        End If



        Dim num As Integer
        num = 0
        query = "Select * from examquestion_essay where examsubjectid='" & examid & "' AND num='" & questnum & "'"
        'query = "Select * from examquestion_essay where examsubjectid='" & subjectid & "' AND examid='" & examid & "' AND num='" & questnum & "'"
        runServer()
        MysqlConn.Open()
        COMMAND = New MySqlCommand(query, MysqlConn)
        SDA.SelectCommand = COMMAND
        SDA.Fill(dbDataset)
        bSource.DataSource = dbDataset
        READER = COMMAND.ExecuteReader
        While READER.Read()
            question = READER("questiontitle").ToString

        End While
        READER.Close()
        MysqlConn.Close()
        txtQuestion.Text = question


        xdataTable.Rows.Clear()
            xdataset.Clear()

        Catch ex As Exception

        End Try
    End Sub
End Class