Imports MySql.Data.MySqlClient
Public Class FrmLogin
    Dim cn As New MySqlConnection
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If connectToDb() = True Then
            MsgBox("Connected")
        Else
            MsgBox("NOte COnnected")
        End If
    End Sub
    Function connectToDb() As Boolean
        Try
            With cn
                .ConnectionString = "server=localhost;user id=root;password=;database=ope;"
                .Open()

            End With
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
