﻿Imports MySql.Data.MySqlClient
Public Class FrmExamResult
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
        Dim ldataset, xdataset As New DataSet
        'Try
        'FrmExamMaster.DataGridView1.Font = New Font("Arial", 16, FontStyle.Regular)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Rows.Clear()
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

        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        DataGridView1.ColumnCount = 6
        DataGridView1.Columns(0).HeaderText = "EXAMINATION CODE"
        DataGridView1.Columns(0).Width = 90
        DataGridView1.Columns(0).Name = "examcode"

        DataGridView1.Columns(1).HeaderText = "SUBJECT"
        DataGridView1.Columns(1).Width = 500
        DataGridView1.Columns(1).Name = "subject"

        DataGridView1.Columns(2).HeaderText = "EXAM TYPE"
        DataGridView1.Columns(2).Width = 200
        DataGridView1.Columns(2).Name = "examtype"


        DataGridView1.Columns(3).HeaderText = "SCORE"
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(3).Name = "score"


        DataGridView1.Columns(4).HeaderText = "ITEMS"
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(4).Name = "items"


        DataGridView1.Columns(5).HeaderText = "DATE"
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Columns(5).Name = "date"



        Dim TotalPoints, Items As Integer
        TotalPoints = 0
        If mydataTable.Rows.Count > 0 Then
            For Each mrow As DataRow In mydataTable.Rows
                Dim examidexaminee As String = ""
                examidexaminee = mrow("id").ToString
                Dim examsubjectid As String = ""
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
                        examsubjectid = str("id").ToString
                        examsubjectname = str("subjectname").ToString
                        subjectid = str("examcategoryid").ToString
                    Next
                End If
                xdataTable.Rows.Clear()
                xdataset.Clear()

                If mrow("examtype") <> "" Then
                    If mrow("examtype") = "Multiple Choice" Then
                        TotalPoints = 0
                        Items = 0
                        'Globaluserid = ""
                        query = "Select * from exam_answer_multiplechoice WHERE examid='" & mrow("id").ToString & "' and studentid='" & Globaluserid & "' and examsubjectid='" & examsubjectid & "'"
                        runServer()
                        MysqlConn.Open()
                        COMMAND = New MySqlCommand(query, MysqlConn)
                        SDA.SelectCommand = COMMAND
                        SDA.Fill(dbDataset)
                        bSource.DataSource = dbDataset
                        READER = COMMAND.ExecuteReader
                        While READER.Read()
                            TotalPoints += CDbl(READER("Correct"))
                            Items += 1
                        End While
                        READER.Close()
                        MysqlConn.Close()


                    ElseIf mrow("examtype") = "Essay" Then
                        TotalPoints = 0
                        Items = 0
                        'Globaluserid = ""
                        query = "Select * from exam_answer_essay WHERE examid='" & mrow("id").ToString & "' and studentid='" & Globaluserid & "' and examsubjectid='" & examsubjectid & "'"
                        runServer()
                        MysqlConn.Open()
                        COMMAND = New MySqlCommand(query, MysqlConn)
                        SDA.SelectCommand = COMMAND
                        SDA.Fill(dbDataset)
                        bSource.DataSource = dbDataset
                        READER = COMMAND.ExecuteReader
                        While READER.Read()
                            TotalPoints += CDbl(READER("Correct"))
                            Items += 1
                        End While
                        READER.Close()
                        MysqlConn.Close()


                    ElseIf mrow("examtype") = "True or False" Then
                        TotalPoints = 0
                        Items = 0
                        query = "Select * from exam_answer_truefalse WHERE examid='" & mrow("id").ToString & "' and studentid='" & Globaluserid & "' and examsubjectid='" & examsubjectid & "'"
                        runServer()
                        MysqlConn.Open()
                        COMMAND = New MySqlCommand(query, MysqlConn)
                        SDA.SelectCommand = COMMAND
                        SDA.Fill(dbDataset)
                        bSource.DataSource = dbDataset
                        READER = COMMAND.ExecuteReader
                        While READER.Read()
                            TotalPoints += CDbl(READER("Correct"))
                            Items += 1
                        End While
                        READER.Close()
                        MysqlConn.Close()

                    End If
                Else
                    Exit Sub
                End If

                Dim datetaken As String = ""
                xdataTable.Rows.Clear()
                xdataset.Clear()
                runServer()
                MysqlConn.Open()
                mycommand = MysqlConn.CreateCommand
                mycommand.CommandText = "SELECT ex.datetaken as datetaken FROM exammaster e INNER JOIN examcategory ec ON e.examcategoryid=ec.id INNER JOIN examinee ex ON ex.examid=e.examid WHERE ex.studentid='" & Globaluserid & "' and ex.examid='" & mrow("id").ToString & "'"

                myadapter.SelectCommand = mycommand
                myadapter.Fill(xdataset, "examinee")
                xdataTable = xdataset.Tables("examinee")
                If xdataTable.Rows.Count > 0 Then
                    For Each str As DataRow In xdataTable.Rows
                        'Dim row As String() = New String() {mrow("id").ToString, mrow("examcategoryname").ToString, examsubjectname.ToString, mrow("examtype").ToString, timelimit.ToString, "OPEN", mrow("examid").ToString}

                        datetaken = str("datetaken").ToString
                    Next
                End If
                xdataTable.Rows.Clear()
                xdataset.Clear()


                Dim row As String() = New String() {mrow("examcategoryname").ToString, examsubjectname.ToString, mrow("examtype").ToString, TotalPoints, Items, datetaken}
                'Dim row As String() = New String() {mrow("examid").ToString, mrow("examtype").ToString}
                DataGridView1.Rows.Add(row)
            Next

        End If
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