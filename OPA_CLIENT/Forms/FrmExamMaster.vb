Public Class FrmExamMaster
    Private Sub FrmExamMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyExam.ExamList()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With Me
            Dispose()
        End With
    End Sub
    Public examcode As String
    Public Sub LoadData()
        Dim GridRow As DataGridViewRow = dtgList.CurrentRow

        For Each datagrd As DataGridViewRow In dtgList.SelectedRows
            examcode = CStr(GridRow.Cells.Item("examcode").Value)
        Next datagrd

    End Sub

    Private Sub dtgList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgList.CellClick
        examcode = ""
        If e.ColumnIndex = 3 Then
            If MessageBox.Show("Are you sure you want to proceed? " & vbNewLine & " " & vbNewLine & "", " Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                LoadData()
                FrmTakeExam.ShowDialog()
            End If

        End If
    End Sub
End Class