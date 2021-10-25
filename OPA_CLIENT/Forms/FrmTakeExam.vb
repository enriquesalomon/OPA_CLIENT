Imports MySql.Data.MySqlClient
Public Class FrmTakeExam
    Dim ss, tt, vv As Integer
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
    End Sub

    Private Sub FrmTakeExam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Visible = False
        lblexamtitle.Text = examcode.ToUpper()
        AnswerList()
        'lblquestion.Top = (lblquestion.Parent.Height \ 2) - (lblquestion.Height \ 2)
        'lblquestion.Left = (lblquestion.Parent.Width \ 2) - (lblquestion.Width \ 2)

        'RadioButton1.Top = (RadioButton1.Parent.Height \ 2) - (RadioButton1.Height \ 2)
        'RadioButton1.Left = (RadioButton1.Parent.Width \ 2) - (RadioButton1.Width \ 2)

        'RadioButton2.Top = (RadioButton2.Parent.Height \ 2) - (RadioButton2.Height \ 2)
        'RadioButton2.Left = (RadioButton2.Parent.Width \ 2) - (RadioButton2.Width \ 2)

        'RadioButton3.Top = (RadioButton3.Parent.Height \ 2) - (RadioButton3.Height \ 2)
        'RadioButton3.Left = (RadioButton3.Parent.Width \ 2) - (RadioButton3.Width \ 2)


        'RadioButton4.Top = (RadioButton4.Parent.Height \ 2) - (RadioButton4.Height \ 2)
        'RadioButton4.Left = (RadioButton4.Parent.Width \ 2) - (RadioButton4.Width \ 2)
        FrmExamStart.ShowDialog()
    End Sub
    Sub AnswerList()

        Dim ldataset As New DataSet
        Dim schedtime As String
        Try
            'FrmExamMaster.DataGridView1.Font = New Font("Arial", 16, FontStyle.Regular)
            'dtgListAnswer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dtgList.Rows.Clear()
            mydataTable.Rows.Clear()
            ldataset.Clear()
            runServer()
            MysqlConn.Open()
            mycommand = MysqlConn.CreateCommand

            mycommand.CommandText = "Select  * from  (exam inner join examcategory on exam.examcategoryid = examcategory.id) "

            myadapter.SelectCommand = mycommand
            myadapter.Fill(ldataset, "exam")
            mydataTable = ldataset.Tables("exam")

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

    Sub getExamQuestion()
        Dim question As String = ""
        Dim opt1 As String = ""
        Dim opt2 As String = ""
        Dim opt3 As String = ""
        Dim opt4 As String = ""

        Dim num As Integer
        num = 0
        Globaluserid = ""
        query = "Select * from examquestion where id='10'"
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

        End While
        READER.Close()
        MysqlConn.Close()
        txtQuestion.Text = question
        RadioButton1.Text = opt1
        RadioButton2.Text = opt2
        RadioButton3.Text = opt3
        RadioButton4.Text = opt4



    End Sub
    Private Sub btnstart_Click(sender As Object, e As EventArgs) Handles btnstart.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        'If RadioButton1.Checked = False Then
        '    RadioButton1.Checked = True
        'End If
        'If RadioButton2.Checked = True Then
        '    RadioButton2.Checked = False
        'End If
        'If RadioButton3.Checked = True Then
        '    RadioButton3.Checked = False
        'End If
        'If RadioButton4.Checked = True Then
        '    RadioButton4.Checked = False
        'End If








    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged



    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        'RadioButton1.Checked = False
        'RadioButton2.Checked = False
        'RadioButton3.Checked = True
        'RadioButton4.Checked = False
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        'RadioButton1.Checked = False
        'RadioButton2.Checked = False
        'RadioButton3.Checked = False
        'RadioButton4.Checked = True
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click

    End Sub

    Private Sub gettime()
        lbltimer.Text = Format(stringServer, "00:") & Format(tt, "00:") & Format(vv, "00")
        vv = vv + 1
        If vv > 59 Then
            vv = 0
            tt = tt + 1
        End If
        If tt = CInt(timelimit) Then
            vv = 0
            tt = 0
            lbltimer.Text = "00:00:00"
            lbltimer.Enabled = False
            MessageBox.Show("Time Ended")
            Me.Dispose()
        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        gettime()
    End Sub
End Class