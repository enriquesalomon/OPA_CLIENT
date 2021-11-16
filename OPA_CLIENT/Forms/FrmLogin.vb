Imports MySql.Data.MySqlClient
Public Class FrmLogin



    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'connect()
        MyLogin.verifyUser()


    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub txtpassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            MyLogin.verifyUser()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        FormTestKey.Show()
    End Sub
End Class
