﻿Imports MySql.Data.MySqlClient
Public Class ExamMaster

    'Sub ExamList()
    '    Dim examcategoryid As String = ""
    '    Dim status As String = ""
    '    'Globaluserid = ""
    '    query = "Select  * from examinee WHERE studentid='" & Globaluserid & "'"
    '    runServer()
    '    MysqlConn.Open()
    '    COMMAND = New MySqlCommand(query, MysqlConn)
    '    SDA.SelectCommand = COMMAND
    '    SDA.Fill(dbDataset)
    '    bSource.DataSource = dbDataset
    '    READER = COMMAND.ExecuteReader
    '    While READER.Read()


    '        FrmExamMaster.dtgList.RowsDefaultCellStyle.BackColor = Color.White
    '        FrmExamMaster.dtgList.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
    '        FrmExamMaster.dtgList.ColumnCount = 7
    '        FrmExamMaster.dtgList.Columns(0).HeaderText = "ID"
    '        FrmExamMaster.dtgList.Columns(0).Width = 90
    '        FrmExamMaster.dtgList.Columns(0).Name = "id"

    '        FrmExamMaster.dtgList.Columns(1).HeaderText = "EXAMINATION CODE"
    '        FrmExamMaster.dtgList.Columns(1).Width = 500
    '        FrmExamMaster.dtgList.Columns(1).Name = "examcode"

    '        FrmExamMaster.dtgList.Columns(2).HeaderText = "SUBJECT"
    '        FrmExamMaster.dtgList.Columns(2).Width = 200
    '        FrmExamMaster.dtgList.Columns(2).Name = "subject"


    '        FrmExamMaster.dtgList.Columns(3).HeaderText = "TYPE"
    '        FrmExamMaster.dtgList.Columns(3).Width = 100
    '        FrmExamMaster.dtgList.Columns(3).Name = "type"


    '        FrmExamMaster.dtgList.Columns(4).HeaderText = "TIMI LIMIT(Mins)"
    '        FrmExamMaster.dtgList.Columns(4).Width = 100
    '        FrmExamMaster.dtgList.Columns(4).Name = "timelimit"


    '        FrmExamMaster.dtgList.Columns(5).HeaderText = "STATUS"
    '        FrmExamMaster.dtgList.Columns(5).Width = 100
    '        FrmExamMaster.dtgList.Columns(5).Name = "status"

    '        FrmExamMaster.dtgList.Columns(6).HeaderText = ""
    '        FrmExamMaster.dtgList.Columns(6).Width = 0
    '        FrmExamMaster.dtgList.Columns(6).Name = "examineeid"

    '        Dim btn As New DataGridViewButtonColumn()
    '        FrmExamMaster.dtgList.Columns.Add(btn)
    '        btn.HeaderText = "ACTION"
    '        btn.Text = "TAKE"
    '        btn.Name = "btn"
    '        btn.UseColumnTextForButtonValue = True
    '        btn.FlatStyle = FlatStyle.Flat


    '        examineeexamid = READER("examid").ToString
    '        status = READER("status").ToString
    '        'Dim subjectid As String = ""

    '        Dim ldataset, xdataset As New DataSet
    '        'Try
    '        'FrmExamMaster.DataGridView1.Font = New Font("Arial", 16, FontStyle.Regular)
    '        FrmExamMaster.dtgList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    '        FrmExamMaster.dtgList.Rows.Clear()
    '        mydataTable.Rows.Clear()
    '        ldataset.Clear()
    '        runServer()
    '        MysqlConn.Open()
    '        mycommand = MysqlConn.CreateCommand

    '        'mycommand.CommandText = "Select  * from  (exam inner join examcategory on exam.examcategoryid = examcategory.id)"
    '        mycommand.CommandText = "SELECT * FROM exammaster"
    '        'mycommand.CommandText = "SELECT * FROM exammaster WHERE examid='" & examineeexamid & "'"

    '        myadapter.SelectCommand = mycommand
    '        myadapter.Fill(ldataset, "exammaster")
    '        mydataTable = ldataset.Tables("exammaster")
    '        Dim id As String = ""
    '        If mydataTable.Rows.Count > 0 Then
    '            For Each mrow As DataRow In mydataTable.Rows

    '                examtype = mrow("examtype").ToString




    '                Dim examsubjectname As String = ""
    '                xdataTable.Rows.Clear()
    '                xdataset.Clear()
    '                runServer()
    '                MysqlConn.Open()
    '                mycommand = MysqlConn.CreateCommand
    '                mycommand.CommandText = "Select  * from  (subjects inner join exammaster on subjects.id = exammaster.subjectid) WHERE exammaster.examid='" & examineeexamid & "'"

    '                myadapter.SelectCommand = mycommand
    '                myadapter.Fill(xdataset, "exammaster")
    '                xdataTable = xdataset.Tables("exammaster")
    '                If xdataTable.Rows.Count > 0 Then
    '                    For Each str As DataRow In xdataTable.Rows
    '                        examsubjectname = str("subjectname").ToString

    '                        subjectid = str("subjectid").ToString


    '                    Next
    '                End If
    '                xdataTable.Rows.Clear()
    '                xdataset.Clear()

    '                Dim examcategoryname As String = ""
    '                xdataTable.Rows.Clear()
    '                xdataset.Clear()
    '                runServer()
    '                MysqlConn.Open()
    '                mycommand = MysqlConn.CreateCommand
    '                mycommand.CommandText = "Select  * from  examcategory WHERE id='" & mrow("examcategoryid").ToString & "'"

    '                myadapter.SelectCommand = mycommand
    '                myadapter.Fill(xdataset, "exammaster")
    '                xdataTable = xdataset.Tables("exammaster")
    '                If xdataTable.Rows.Count > 0 Then
    '                    For Each str As DataRow In xdataTable.Rows
    '                        examcategoryname = str("examcategoryname").ToString


    '                    Next
    '                End If
    '                xdataTable.Rows.Clear()
    '                xdataset.Clear()

    '                Dim examstatus As String = ""


    '                If examtype = "Multiple Choice" Then

    '                    xdataTable.Rows.Clear()
    '                    xdataset.Clear()
    '                    runServer()
    '                    MysqlConn.Open()
    '                    mycommand = MysqlConn.CreateCommand
    '                    mycommand.CommandText = "Select  * from  examsubject WHERE examid='" & examineeexamid & "' AND subjectid='" & subjectid & "' "

    '                    myadapter.SelectCommand = mycommand
    '                    myadapter.Fill(xdataset, "exammaster")
    '                    xdataTable = xdataset.Tables("exammaster")
    '                    If xdataTable.Rows.Count > 0 Then
    '                        For Each str As DataRow In xdataTable.Rows
    '                            timelimit = str("timelimit").ToString
    '                        Next
    '                    End If
    '                    xdataTable.Rows.Clear()
    '                    xdataset.Clear()


    '                ElseIf examtype = "Essay" Then


    '                    xdataTable.Rows.Clear()
    '                    xdataset.Clear()
    '                    runServer()
    '                    MysqlConn.Open()
    '                    mycommand = MysqlConn.CreateCommand
    '                    mycommand.CommandText = "Select  * from  examsubject_essay WHERE examid='" & examineeexamid & "' AND subjectid='" & subjectid & "' "

    '                    myadapter.SelectCommand = mycommand
    '                    myadapter.Fill(xdataset, "exammaster")
    '                    xdataTable = xdataset.Tables("exammaster")
    '                    If xdataTable.Rows.Count > 0 Then
    '                        For Each str As DataRow In xdataTable.Rows
    '                            timelimit = str("timelimit").ToString
    '                        Next
    '                    End If
    '                    xdataTable.Rows.Clear()
    '                    xdataset.Clear()

    '                End If







    '                'MsgBox(mrow("id").ToString)
    '                'MsgBox(examtype.ToString)


    '                Dim row As String() = New String() {mrow("id").ToString, examcategoryname.ToString + " 2020-2021", examsubjectname.ToString, examtype.ToString, timelimit, status, examineeexamid}
    '                FrmExamMaster.dtgList.Rows.Add(row)


    '            Next

    '        End If












    '    End While
    '    READER.Close()
    '    MysqlConn.Close()


    '    'Catch ex As Exception
    '    '    MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Data Error !!")
    '    'End Try





    '    'Catch ex As Exception
    '    '    MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Data Error !!")
    '    'End Try



    'End Sub



    Sub ExamList()

        Dim ldataset, xdataset As New DataSet
        'Try
        'FrmExamMaster.DataGridView1.Font = New Font("Arial", 16, FontStyle.Regular)
        FrmExamMaster.dtgList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        FrmExamMaster.dtgList.Rows.Clear()
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

        FrmExamMaster.dtgList.RowsDefaultCellStyle.BackColor = Color.White
        FrmExamMaster.dtgList.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        FrmExamMaster.dtgList.ColumnCount = 7
        FrmExamMaster.dtgList.Columns(0).HeaderText = "ID"
        FrmExamMaster.dtgList.Columns(0).Width = 90
        FrmExamMaster.dtgList.Columns(0).Name = "id"

        FrmExamMaster.dtgList.Columns(1).HeaderText = "EXAMINATION CODE"
        FrmExamMaster.dtgList.Columns(1).Width = 500
        FrmExamMaster.dtgList.Columns(1).Name = "examcode"

        FrmExamMaster.dtgList.Columns(2).HeaderText = "SUBJECT"
        FrmExamMaster.dtgList.Columns(2).Width = 200
        FrmExamMaster.dtgList.Columns(2).Name = "subject"


        FrmExamMaster.dtgList.Columns(3).HeaderText = "TYPE"
        FrmExamMaster.dtgList.Columns(3).Width = 100
        FrmExamMaster.dtgList.Columns(3).Name = "type"


        FrmExamMaster.dtgList.Columns(4).HeaderText = "TIMI LIMIT(Mins)"
        FrmExamMaster.dtgList.Columns(4).Width = 100
        FrmExamMaster.dtgList.Columns(4).Name = "timelimit"


        FrmExamMaster.dtgList.Columns(5).HeaderText = "STATUS"
        FrmExamMaster.dtgList.Columns(5).Width = 100
        FrmExamMaster.dtgList.Columns(5).Name = "status"

        FrmExamMaster.dtgList.Columns(6).HeaderText = ""
        FrmExamMaster.dtgList.Columns(6).Width = 50
        FrmExamMaster.dtgList.Columns(6).Name = "examineeid"

        Dim btn As New DataGridViewButtonColumn()
        FrmExamMaster.dtgList.Columns.Add(btn)
        btn.HeaderText = "ACTION"
        btn.Text = "TAKE"
        btn.Name = "btn"
        btn.UseColumnTextForButtonValue = True
        btn.FlatStyle = FlatStyle.Flat


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

                If mrow("examtype").ToString = "Essay" Then
                    xdataTable.Rows.Clear()
                    xdataset.Clear()
                    runServer()
                    MysqlConn.Open()
                    mycommand = MysqlConn.CreateCommand
                    mycommand.CommandText = "Select  * from  examsubject_essay WHERE id='" & mrow("id").ToString & "'"

                    myadapter.SelectCommand = mycommand
                    myadapter.Fill(xdataset, "examsubject")
                    xdataTable = xdataset.Tables("examsubject")
                    If xdataTable.Rows.Count > 0 Then
                        For Each str As DataRow In xdataTable.Rows
                            timelimit = str("timelimit").ToString
                        Next
                    End If
                    xdataTable.Rows.Clear()
                    xdataset.Clear()

                ElseIf mrow("examtype").ToString = "Multiple Choice" Then

                    xdataTable.Rows.Clear()
                    xdataset.Clear()
                    runServer()
                    MysqlConn.Open()
                    mycommand = MysqlConn.CreateCommand
                    mycommand.CommandText = "Select  * from  examsubject WHERE id='" & mrow("id").ToString & "'"

                    myadapter.SelectCommand = mycommand
                    myadapter.Fill(xdataset, "examsubject")
                    xdataTable = xdataset.Tables("examsubject")
                    If xdataTable.Rows.Count > 0 Then
                        For Each str As DataRow In xdataTable.Rows
                            timelimit = str("timelimit").ToString
                        Next
                    End If
                    xdataTable.Rows.Clear()
                    xdataset.Clear()
                End If

                Dim examstatus As String = ""
                xdataTable.Rows.Clear()
                xdataset.Clear()
                runServer()
                MysqlConn.Open()
                mycommand = MysqlConn.CreateCommand
                mycommand.CommandText = "Select  * from  examinee WHERE examid='" & mrow("examid").ToString & "' and studentid='" & Globaluserid & "'"

                myadapter.SelectCommand = mycommand
                myadapter.Fill(xdataset, "examinee")
                xdataTable = xdataset.Tables("examinee")
                If xdataTable.Rows.Count > 0 Then
                    For Each str As DataRow In xdataTable.Rows
                        examstatus = str("status").ToString
                    Next
                End If
                xdataTable.Rows.Clear()
                xdataset.Clear()

                If examstatus = "" Then
                    examstatus = "OPEN"

                Else
                    examstatus = "CLOSED"
                End If


                Dim row As String() = New String() {mrow("id").ToString, mrow("examcategoryname").ToString, examsubjectname.ToString, mrow("examtype").ToString, timelimit.ToString, examstatus.ToString, mrow("examid").ToString}
                FrmExamMaster.dtgList.Rows.Add(row)
            Next

        End If

        'Catch ex As Exception
        '    MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Data Error !!")
        'End Try
    End Sub

    Sub ExamListCount()


        Dim num As Integer
        num = 0
        'Globaluserid = ""
        query = "Select COUNT(*) as num from exam"
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
        FrmDashboard.lblexamcount.Text = num

    End Sub
End Class
