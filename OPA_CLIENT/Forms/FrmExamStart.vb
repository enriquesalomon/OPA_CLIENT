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
        If examtype = "Multiple Choice" Then
            If IsNumeric(timelimit) AndAlso CInt(timelimit) > 0 Then
                FrmTakeExamMultipleChoice.tspn = New TimeSpan(0, CInt(timelimit), 0)
                FrmTakeExamMultipleChoice.Timer1.Enabled = True
            Else
                MessageBox.Show("Please enter a numeric value in the text box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            'FrmTakeExam.Timer1.Enabled = True
            FrmTakeExamMultipleChoice.btnBack.Enabled = True
            FrmTakeExamMultipleChoice.btnsubmits.Enabled = True
            FrmTakeExamMultipleChoice.getAnswersTable()
            FrmTakeExamMultipleChoice.getExamQuestion()
            FrmTakeExamMultipleChoice.GroupBox1.Visible = True
            Me.Close()

        End If

        If examtype = "Essay" Then
            If IsNumeric(timelimit) AndAlso CInt(timelimit) > 0 Then
                FrmTakeExamEssay.tspn = New TimeSpan(0, CInt(timelimit), 0)
                FrmTakeExamEssay.Timer1.Enabled = True
            Else
                MessageBox.Show("Please enter a numeric value in the text box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            'FrmTakeExam.Timer1.Enabled = True
            FrmTakeExamEssay.btnBack.Enabled = True
            FrmTakeExamEssay.btnsubmit.Enabled = True
            'FrmTakeExamEssay.getAnswersTable()
            FrmTakeExamEssay.getExamQuestion()
            FrmTakeExamEssay.GroupBox2.Visible = True
            Me.Close()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmTakeExamMultipleChoice.Dispose()
        FrmTakeExamEssay.Dispose()
    End Sub
End Class