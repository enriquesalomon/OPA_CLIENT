﻿Imports MySql.Data.MySqlClient
Public Class ExamMaster
    'Sub ExamList()
    '    runServer()
    '    Dim SDA As New MySqlDataAdapter
    '    Dim dbDataset As New DataTable
    '    Dim bSource As New BindingSource

    '    query = "Select * from  ope.exam"

    '    Try
    '        MysqlConn.Open()
    '        COMMAND = New MySqlCommand(query, MysqlConn)
    '        SDA.SelectCommand = COMMAND
    '        SDA.Fill(dbDataset)
    '        bSource.DataSource = dbDataset
    '        FrmExamMaster.DataGridView1.DataSource = bSource
    '        SDA.Update(dbDataset)
    '        MysqlConn.Close()
    '        FrmExamMaster.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    '        FrmExamMaster.Label1.Text = FrmExamMaster.DataGridView1.Rows.Count & " Records"

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        MysqlConn.Dispose()

    '    End Try

    'End Sub


    Sub ExamList()

        Dim ldataset As New DataSet
        Dim schedtime As String
        Try
            FrmExamMaster.DataGridView1.Rows.Clear()
            mydataTable.Rows.Clear()
            ldataset.Clear()
            runServer()
            mycommand = MysqlConn.CreateCommand

            mycommand.CommandText = "Select * from  ope.exam"

            myadapter.SelectCommand = mycommand
            myadapter.Fill(ldataset, "exam")
            mydataTable = ldataset.Tables("exam")

            FrmExamMaster.DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
            FrmExamMaster.DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            FrmExamMaster.DataGridView1.ColumnCount = 4
            FrmExamMaster.DataGridView1.Columns(0).HeaderText = "ID"
            FrmExamMaster.DataGridView1.Columns(0).Width = 90
            FrmExamMaster.DataGridView1.Columns(0).Name = "id"

            FrmExamMaster.DataGridView1.Columns(1).HeaderText = "EXAMCATID"
            FrmExamMaster.DataGridView1.Columns(1).Width = 90
            FrmExamMaster.DataGridView1.Columns(1).Name = "examcategoryid"

            FrmExamMaster.DataGridView1.Columns(2).HeaderText = "CLASSID"
            FrmExamMaster.DataGridView1.Columns(2).Width = 130
            FrmExamMaster.DataGridView1.Columns(2).Name = "classnameid"

            FrmExamMaster.DataGridView1.Columns(3).HeaderText = "SY"
            FrmExamMaster.DataGridView1.Columns(3).Width = 90
            FrmExamMaster.DataGridView1.Columns(3).Name = "sy"


            Dim id, examcategoryid, classnameid, sy As String
            If mydataTable.Rows.Count > 0 Then
                For Each mrow As DataRow In mydataTable.Rows


                    id = mrow("id").ToString
                    examcategoryid = mrow("examcategoryid").ToString
                    classnameid = mrow("classnameid").ToString
                    sy = mrow("sy").ToString

                    ''temptime1 = Format(CInt(Mid(mrow("TimeofExam"), 1, 4)), "0#:00").ToString()

                    'temptime2 = Mid(mrow("TimeofExam"), 5, 6).ToString
                    'temptime2 = Format(CInt(Mid(temptime2, 1, 4)), "0#:00").ToString
                    'temptime3 = Mid(mrow("TimeofExam"), 9, 10).ToString
                    'schedtime = temptime1 & Space(2) & "-" & Space(2) & temptime2 & Space(1) & temptime3

                    Dim row As String() = New String() {mrow("id").ToString, mrow("examcategoryid").ToString, mrow("classnameid").ToString, mrow("sy").ToString}
                    FrmExamMaster.DataGridView1.Rows.Add(row)
                Next

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Data Error !!")
        End Try
    End Sub
End Class