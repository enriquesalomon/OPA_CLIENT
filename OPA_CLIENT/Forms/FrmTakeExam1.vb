Public Class FrmTakeExam1
    Private Sub FrmTakeExam1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.dtgList.Font = New Font("Verdana", 12)
        Me.dtgList.BackgroundColor = System.Drawing.Color.White
        Me.dtgList.RowsDefaultCellStyle.BackColor = Color.Bisque
        Me.dtgList.AlternatingRowsDefaultCellStyle.BackColor = Color.White
        Me.dtgList.AlternatingRowsDefaultCellStyle.Font = New Font("Arial", 22)
        Me.dtgList.RowTemplate.Height = 35
        Me.dtgList.DefaultCellStyle.SelectionBackColor = Color.Navy
        Me.dtgList.DefaultCellStyle.SelectionForeColor = Color.Red


        ExamQuestion()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
    End Sub

    Sub ExamQuestion()

        Dim ldataset As New DataSet
        Dim schedtime As String
        Try
            'dtgList.Font = New Font("Arial", 30, FontStyle.Regular)
            dtgList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dtgList.Rows.Clear()
            mydataTable.Rows.Clear()
            ldataset.Clear()
            runServer()
            MysqlConn.Open()
            mycommand = MysqlConn.CreateCommand

            mycommand.CommandText = "Select * from examquestion"

            myadapter.SelectCommand = mycommand
            myadapter.Fill(ldataset, "exam")
            mydataTable = ldataset.Tables("exam")

            dtgList.RowsDefaultCellStyle.BackColor = Color.White
            dtgList.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            dtgList.ColumnCount = 6
            dtgList.Columns(0).HeaderText = "ID"
            dtgList.Columns(0).Width = 90
            dtgList.Columns(0).Name = "id"

            dtgList.Columns(1).HeaderText = "Question"
            dtgList.Columns(1).Width = 500
            dtgList.Columns(1).Name = "question"

            dtgList.Columns(2).HeaderText = "A"
            dtgList.Columns(2).Width = 100
            dtgList.Columns(2).Name = "status"

            dtgList.Columns(3).HeaderText = "B"
            dtgList.Columns(3).Width = 100
            dtgList.Columns(3).Name = "status"

            dtgList.Columns(4).HeaderText = "C"
            dtgList.Columns(4).Width = 100
            dtgList.Columns(4).Name = "status"

            dtgList.Columns(5).HeaderText = "D"
            dtgList.Columns(5).Width = 100
            dtgList.Columns(5).Name = "status"

            Dim btn As New DataGridViewButtonColumn()
            dtgList.Columns.Add(btn)
            btn.HeaderText = "ACTION"
            btn.Text = "TAKE"
            btn.Name = "btn"
            btn.UseColumnTextForButtonValue = True
            btn.FlatStyle = FlatStyle.Flat


            If mydataTable.Rows.Count > 0 Then
                For Each mrow As DataRow In mydataTable.Rows

                    Dim row As String() = New String() {mrow("id").ToString, mrow("questiontitle").ToString, mrow("option1").ToString, mrow("option2").ToString, mrow("option3").ToString, mrow("option4").ToString}
                    dtgList.Rows.Add(row)
                Next

            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, MsgBoxStyle.OkOnly, "Data Error !!")
        End Try


    End Sub
End Class