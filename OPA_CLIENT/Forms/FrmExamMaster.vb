Public Class FrmExamMaster
    Private Sub FrmExamMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyExam.ExamList()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With Me
            Dispose()
        End With
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = 3 Then
            If MessageBox.Show("Are you sure you want to take the exam  " & vbNewLine & " " & vbNewLine & "", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then



            End If

        End If
    End Sub
End Class