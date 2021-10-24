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
        FrmTakeExam.Timer1.Enabled = True
        FrmTakeExam.btnstart.Enabled = True
        FrmTakeExam.btnsubmit.Enabled = True
        FrmTakeExam.getExamQuestion()
        FrmTakeExam.GroupBox1.Visible = True
        Me.Close()
    End Sub
End Class