﻿Imports MySql.Data.MySqlClient
Public Class ExamMaster



    Sub ExamList()

        Dim ldataset As New DataSet
        Dim schedtime As String
        Try
            FrmExamMaster.DataGridView1.Rows.Clear()
            mydataTable.Rows.Clear()
            ldataset.Clear()
            runServer()
            MysqlConn.Open()
            mycommand = MysqlConn.CreateCommand

            mycommand.CommandText = "Select  * from  (exam inner join examcategory on exam.examcategoryid = examcategory.id) "

            myadapter.SelectCommand = mycommand
            myadapter.Fill(ldataset, "exam")
            mydataTable = ldataset.Tables("exam")

            FrmExamMaster.DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
            FrmExamMaster.DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            FrmExamMaster.DataGridView1.ColumnCount = 3
            FrmExamMaster.DataGridView1.Columns(0).HeaderText = "ID"
            FrmExamMaster.DataGridView1.Columns(0).Width = 90
            FrmExamMaster.DataGridView1.Columns(0).Name = "id"

            FrmExamMaster.DataGridView1.Columns(1).HeaderText = "EXAMINATION CODE"
            FrmExamMaster.DataGridView1.Columns(1).Width = 500
            FrmExamMaster.DataGridView1.Columns(1).Name = "examcode"

            FrmExamMaster.DataGridView1.Columns(2).HeaderText = "STATUS"
            FrmExamMaster.DataGridView1.Columns(2).Width = 100
            FrmExamMaster.DataGridView1.Columns(2).Name = "status"

            Dim btn As New DataGridViewButtonColumn()
            FrmExamMaster.DataGridView1.Columns.Add(btn)
            btn.HeaderText = "ACTION"
            btn.Text = "TAKE"
            btn.Name = "btn"
            btn.UseColumnTextForButtonValue = True
            btn.FlatStyle = FlatStyle.Flat


            If mydataTable.Rows.Count > 0 Then
                For Each mrow As DataRow In mydataTable.Rows

                    Dim row As String() = New String() {mrow("id").ToString, mrow("sy").ToString + " " + mrow("examcategoryname").ToString, "TAKEN"}
                    FrmExamMaster.DataGridView1.Rows.Add(row)
                Next

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Data Error !!")
        End Try
    End Sub

    Sub ExamListCount()


        Dim num As Integer
        num = 0
        Globaluserid = ""
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
