Imports MySql.Data.MySqlClient
Public Class FrmChangeAccessCode
    Private Sub FrmChangeAccessCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
    Sub SaveUpdateAccessCode()
        runServer()
        Try
            MysqlConn.Open()

            If MessageBox.Show("Are you sure you want to update the Access Code?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                query = "update student set opepassword='" & Trim(txtNewAccessCode.Text) & "' where id='" & Globaluserid & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader
                MsgBox("Access Code successfully updated!", MsgBoxStyle.Information)
                txtNewAccessCode.Clear()
                txtNewAccessCode.Clear()
                txtRetypeNewAccessCode.Clear()
                Me.Dispose()
                FrmMain.Close()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()

        End Try


    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnUpdateAccessCode.Click
        If Trim(txtOldAccessCode.Text) = "" Then
            Exit Sub
        End If
        If Trim(txtNewAccessCode.Text) = "" Then
            Exit Sub
        End If
        If Trim(txtRetypeNewAccessCode.Text) = "" Then
            Exit Sub
        End If
        If Trim(txtNewAccessCode.Text) = Trim(txtRetypeNewAccessCode.Text) Then
            SaveUpdateAccessCode()
        Else
            MsgBox("New Access Code did not Match!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With Me
            Dispose()
        End With
    End Sub
End Class