Public Class FrmWelcome
    Private Sub btnUpdateAccessCode_Click(sender As Object, e As EventArgs) Handles btnUpdateAccessCode.Click
        FrmMain.ShowDialog()
        Me.Close()
    End Sub
End Class