﻿Public Class FrmExamResult
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With Me
            Dispose()
        End With
    End Sub

    Private Sub cmbExamCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbExamCode.SelectedIndexChanged
        If cmbExamCode.Text <> "" Then

        End If
    End Sub

    Sub loadScoreExam()
        'Dim ldataset, xdataset As New DataSet
        ''Try
        ''FrmExamMaster.DataGridView1.Font = New Font("Arial", 16, FontStyle.Regular)
        'FrmExamMaster.dtgList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'FrmExamMaster.dtgList.Rows.Clear()
        'mydataTable.Rows.Clear()
        'ldataset.Clear()
        'runServer()
        'MysqlConn.Open()
        'mycommand = MysqlConn.CreateCommand

        ''mycommand.CommandText = "Select  * from  (exam inner join examcategory on exam.examcategoryid = examcategory.id)"
        'mycommand.CommandText = "SELECT *  exam_answer_multiplechoice WHERE ex.studentid='" & Globaluserid & "'"


        'myadapter.SelectCommand = mycommand
        'myadapter.Fill(ldataset, "exam")
        'mydataTable = ldataset.Tables("exam")

        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        DataGridView1.ColumnCount = 7
        DataGridView1.Columns(0).HeaderText = "EXAMINATION CODE"
        DataGridView1.Columns(0).Width = 90
        DataGridView1.Columns(0).Name = "examcode"

        DataGridView1.Columns(1).HeaderText = "SUBJECT"
        DataGridView1.Columns(1).Width = 500
        DataGridView1.Columns(1).Name = "subject"

        DataGridView1.Columns(2).HeaderText = "EXAM TYPE"
        DataGridView1.Columns(2).Width = 200
        DataGridView1.Columns(2).Name = "examtype"


        DataGridView1.Columns(3).HeaderText = "TYPE"
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(3).Name = "type"


        DataGridView1.Columns(4).HeaderText = "SCORE"
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(4).Name = "score"


        DataGridView1.Columns(5).HeaderText = "ITEMS"
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Columns(5).Name = "items"


        DataGridView1.Columns(6).HeaderText = "DATE"
        DataGridView1.Columns(6).Width = 100
        DataGridView1.Columns(6).Name = "date"




        'If mydataTable.Rows.Count > 0 Then
        '    For Each mrow As DataRow In mydataTable.Rows


        '        Dim examsubjectname As String = ""
        '        xdataTable.Rows.Clear()
        '        xdataset.Clear()
        '        runServer()
        '        MysqlConn.Open()
        '        mycommand = MysqlConn.CreateCommand
        '        mycommand.CommandText = "Select  * from  (subjects inner join exammaster on subjects.id = exammaster.subjectid) WHERE exammaster.id='" & mrow("id").ToString & "'"

        '        myadapter.SelectCommand = mycommand
        '        myadapter.Fill(xdataset, "exammaster")
        '        xdataTable = xdataset.Tables("exammaster")
        '        If xdataTable.Rows.Count > 0 Then
        '            For Each str As DataRow In xdataTable.Rows
        '                examsubjectname = str("subjectname").ToString
        '                subjectid = str("subjectid").ToString


        '            Next
        '        End If
        '        xdataTable.Rows.Clear()
        '        xdataset.Clear()



        '        Dim row As String() = New String() {mrow("id").ToString, mrow("examcategoryname").ToString, examsubjectname.ToString, mrow("examtype").ToString, timelimit.ToString, "OPEN", mrow("examid").ToString}
        '        FrmExamMaster.dtgList.Rows.Add(row)
        '    Next

        'End If
    End Sub
    Sub cmbLoaddataExam()
        Try

            xdataTable.Rows.Clear()
            xdataset.Clear()
            runServer()
            MysqlConn.Open()
            mycommand = MysqlConn.CreateCommand
            mycommand.CommandText = "SELECT e.id as id,e.examid as examid,e.subjectid as subjectid,ec.examcategoryname as examcategoryname,e.examtype as examtype FROM exammaster e INNER JOIN examcategory ec ON e.examcategoryid=ec.id INNER JOIN examinee ex ON ex.examid=e.examid WHERE ex.studentid='" & Globaluserid & "'"

            myadapter.SelectCommand = mycommand
            myadapter.Fill(xdataset, "examinee")
            xdataTable = xdataset.Tables("examinee")
            If xdataTable.Rows.Count > 0 Then
                For Each str As DataRow In xdataTable.Rows
                    'Dim row As String() = New String() {mrow("id").ToString, mrow("examcategoryname").ToString, examsubjectname.ToString, mrow("examtype").ToString, timelimit.ToString, "OPEN", mrow("examid").ToString}

                    cmbExamCode.Items.Add(str("id") + " " + str("examcategoryname") + " " + str("examtype"))
                Next
            End If
            xdataTable.Rows.Clear()
            xdataset.Clear()
        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.Exclamation, "Connection Error!")
            MysqlConn.Close()
        End Try
    End Sub

    Function setBoxExam()

        Try

            'xdataTable.Rows.Clear()
            'xdataset.Clear()
            'runServer()


            'MysqlConn.Open()
            'mycommand = MysqlConn.CreateCommand
            'mycommand.CommandText = "SELECT e.id as id,e.examid as examid,e.subjectid as subjectid,ec.examcategoryname as examcategoryname,e.examtype as examtype FROM exammaster e INNER JOIN examcategory ec ON e.examcategoryid=ec.id INNER JOIN examinee ex ON ex.examid=e.examid WHERE ex.studentid='" & Globaluserid & "'"
            ''mycommand.CommandText = "Select * from exammaster"
            'myadapter.SelectCommand = mycommand
            'myadapter.Fill(xdataset, "examinee")
            'xdataTable = xdataset.Tables("examinee")
            'If xdataTable.Rows.Count > 0 Then
            '    For Each str As DataRow In xdataTable.Rows



            '        Dim examsubjectname As String = ""
            '        xdataTable.Rows.Clear()
            '        xdataset.Clear()
            '        runServer()
            '        MysqlConn.Open()
            '        mycommand = MysqlConn.CreateCommand
            '        mycommand.CommandText = "Select  * from  (subjects inner join exammaster on subjects.id = exammaster.subjectid) WHERE exammaster.id='" & str("id").ToString & "'"

            '        myadapter.SelectCommand = mycommand
            '        myadapter.Fill(xdataset, "exammaster")
            '        xdataTable = xdataset.Tables("exammaster")
            '        If xdataTable.Rows.Count > 0 Then
            '            For Each strs As DataRow In xdataTable.Rows
            '                examsubjectname = strs("subjectname").ToString
            '                subjectid = strs("subjectid").ToString


            '            Next
            '        End If
            '        xdataTable.Rows.Clear()
            '        xdataset.Clear()


            '        'Dim row As String() = New String() {mrow("id").ToString, mrow("examcategoryname").ToString, examsubjectname.ToString, mrow("examtype").ToString, timelimit.ToString, "OPEN", mrow("examid").ToString}

            '        cmbExamCode.Items.Add(str("id") + " | " + str("examcategoryname") + " | " + examsubjectname + " | " + str("examtype"))
            '    Next
            'End If
            'xdataTable.Rows.Clear()
            'xdataset.Clear()






            Dim ldataset, xdataset As New DataSet
            mydataTable.Rows.Clear()
            ldataset.Clear()
            runServer()
            MysqlConn.Open()
            mycommand = MysqlConn.CreateCommand

            'mycommand.CommandText = "Select  * from  (exam inner join examcategory on exam.examcategoryid = examcategory.id)"
            mycommand.CommandText = "SELECT e.id as id,e.examid as examid,e.subjectid as subjectid,ec.examcategoryname as examcategoryname,e.examtype as examtype FROM exammaster e INNER JOIN examcategory ec ON e.examcategoryid=ec.id INNER JOIN examinee ex ON ex.examid=e.examid WHERE ex.studentid='" & Globaluserid & "'"


            myadapter.SelectCommand = mycommand
            myadapter.Fill(ldataset, "exam")
            mydataTable = ldataset.Tables("exam")

            If mydataTable.Rows.Count > 0 Then
                For Each mrow As DataRow In mydataTable.Rows
                    Dim examsubjectname As String = ""
                    xdataTable.Rows.Clear()
                    xdataset.Clear()
                    runServer()
                    MysqlConn.Open()
                    mycommand = MysqlConn.CreateCommand
                    mycommand.CommandText = "Select  * from  (subjects inner join exammaster on subjects.id = exammaster.subjectid) WHERE exammaster.id='" & mrow("id").ToString & "'"

                    myadapter.SelectCommand = mycommand
                    myadapter.Fill(xdataset, "exammaster")
                    xdataTable = xdataset.Tables("exammaster")
                    If xdataTable.Rows.Count > 0 Then
                        For Each str As DataRow In xdataTable.Rows
                            examsubjectname = str("subjectname").ToString
                            subjectid = str("subjectid").ToString


                        Next
                    End If
                    xdataTable.Rows.Clear()
                    xdataset.Clear()



                    cmbExamCode.Items.Add(mrow("id") + " | " + mrow("examcategoryname") + " | " + examsubjectname + " | " + mrow("examtype"))
                Next

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.Exclamation, "Connection Error!")
            MysqlConn.Close()
        End Try
    End Function

    Private Sub FrmExamResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadScoreExam()
        setBoxExam()
    End Sub
End Class