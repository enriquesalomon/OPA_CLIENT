Public Class FrmTakeExamTrueFalse
    Private Sub FrmTakeExamTrueFalse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Visible = False
        lblexamtitle.Text = examcode.ToUpper()
        AnswerList()

        FrmExamStart.ShowDialog()
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
End Class