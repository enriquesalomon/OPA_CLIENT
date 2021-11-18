Imports MySql.Data.MySqlClient
Public Class Login

    Public Sub verifyUser()
        Try

            nickname = ""
            Globaluserid = ""
            query = "Select * from student where studentno= '" & FrmLogin.txtusername.Text & "' and opepassword= '" & FrmLogin.txtpassword.Text & "'"
            runServer()
            MysqlConn.Open()
            COMMAND = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataset)
            bSource.DataSource = dbDataset
            READER = COMMAND.ExecuteReader
            While READER.Read()
                nickname = READER("firstname").ToString
                Globaluserid = READER("id").ToString
                studentno = READER("studentno").ToString
                'userinfo = READER("fname").ToString & " " & READER("lname").ToString

            End While
            READER.Close()
            MysqlConn.Close()
            If Globaluserid <> "" Then
                MsgBox(" Access Granted", MsgBoxStyle.Information)
            FrmMain.showd
                FrmLogin.txtpassword.Clear()
                FrmLogin.txtusername.Clear()
            Else
                MsgBox("Invalid StudentNo/Access Code")
                FrmLogin.txtpassword.Clear()
                FrmLogin.txtusername.Clear()
                FrmLogin.txtusername.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
