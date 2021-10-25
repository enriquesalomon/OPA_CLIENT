Imports MySql.Data.MySqlClient
Public Class FrmExamStart
    Private Sub FrmTakeExam1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Me.dtgList.Font = New Font("Verdana", 12)
        'Me.dtgList.BackgroundColor = System.Drawing.Color.White
        'Me.dtgList.RowsDefaultCellStyle.BackColor = Color.Bisque
        'Me.dtgList.AlternatingRowsDefaultCellStyle.BackColor = Color.White
        'Me.dtgList.AlternatingRowsDefaultCellStyle.Font = New Font("Arial", 22)
        'Me.dtgList.RowTemplate.Height = 35
        'Me.dtgList.DefaultCellStyle.SelectionBackColor = Color.Navy
        'Me.dtgList.DefaultCellStyle.SelectionForeColor = Color.Red


        'ExamQuestion()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNumeric(timelimit) AndAlso CInt(timelimit) > 0 Then
            FrmTakeExam.tspn = New TimeSpan(0, CInt(timelimit), 0)
            FrmTakeExam.Timer1.Enabled = True
        Else
            MessageBox.Show("Please enter a numeric value in the text box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'FrmTakeExam.Timer1.Enabled = True
        FrmTakeExam.btnBack.Enabled = True
        FrmTakeExam.btnsubmit.Enabled = True
        FrmTakeExam.getAnswersTable()
        FrmTakeExam.getExamQuestion()
        FrmTakeExam.GroupBox1.Visible = True
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmTakeExam.Dispose()
    End Sub
End Class