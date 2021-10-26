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
            MessageBox.Show("Time Ended")

        End If

        'ok---------------------------
        'lbltimer.Text = Format(stringServer, "00:") & Format(timelimit, "00:") & Format(vv, "00")
        'vv = vv + 1
        'If vv > 59 Then
        '    vv = 0
        '    tt = tt + 1
        'End If
        'If tt = CInt(timelimit) Then
        '    vv = 0
        '    tt = 0
        '    lbltimer.Text = "00:00:00"

        '    MessageBox.Show("Time Ended")
        '    lbltimer.Enabled = False
        '    lbltimer.Text = "00:00:00"
        '    Me.Dispose()
        'End If

        'Current = Current - 1
        'lbltimer.Text = Current.ToString

        'If lbltimer.Text = "0" Then

        '    Timer1.Stop()

        '    MessageBox.Show("Countdown Finished")

        'End If


    End Sub
    Dim questnum As Integer = 0
    Dim totalquestions As Integer = 0

    Dim question As String = ""
    Dim opt1 As String = ""
    Dim opt2 As String = ""
    Dim opt3 As String = ""
    Dim opt4 As String = ""
    Sub getExamQuestion()



        query = "Select  COUNT(*) as totalcount from  (examsubject inner join examquestion_essay on examquestion_essay.examsubjectid = examsubject.id) WHERE examquestion_essay.examid='" & examid & "'"
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

        query = "Select * from examquestion_essay where examsubjectid='" & subjectid & "' AND examid='" & examid & "' AND num='" & questnum & "'"
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
    Sub UpdateAnswer_Essay()
        runServer()
        MysqlConn.Open()
        query = "update exam_answer_essay set answer='" & txtAnswerEssay.Text & "',answerdescription='" & "" & "' where studentid='" & Globaluserid & "' AND examid='" & examid & "' AND examsubjectid='" & subjectid & "' AND questionnum='" & questnum & "'"
        COMMAND = New MySqlCommand(query, MysqlConn)
        READER = COMMAND.ExecuteReader
        MysqlConn.Close()


    End Sub
    Sub UpdateExamRecordToClose()
        runServer()
        MysqlConn.Open()
        'query = "insert into exam_answer_multiplechoice (studentid,studentno,examid,examsubjectid,questionnum,answer,answerdescription) values ('" & Globaluserid & "','" & studentno & "','" & examid & "','" & subjectid & "','" & questnum & "','" & "" & "','" & "" & "')"
        query = "update examinee set status='" & "CLOSED" & "',datetaken='" & Date.Now.ToShortDateString & "',startime='" & timelimit & "',timeend='" & tspn.Minutes.ToString + ":" + tspn.Seconds.ToString & "' where examid='" & examid & "' AND studentid='" & Globaluserid & "'"
        COMMAND = New MySqlCommand(query, MysqlConn)
        READER = COMMAND.ExecuteReader
        MysqlConn.Close()
    End Sub
    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        UpdateAnswer_Essay()

        If noanswer = True Then
            Exit Sub
        End If
        If txtAnswerEssay.Text = "" Then
            MessageBox.Show("No Answer Inputed, Please input your Answer to Proceed to the next question.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        questnum += 1
        If questnum > totalquestions Then
            questnum -= 1
            MsgBox("NO MORE QUESTION")
            MsgBox(" Examination Assessment Recorded", MsgBoxStyle.Information)
            UpdateExamRecordToClose()
            Me.Close()
            MyExam.ExamList()
        End If
    End Sub
End Class