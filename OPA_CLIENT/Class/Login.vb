Imports MySql.Data.MySqlClient
Public Class Login

    Public Sub verifyUser()
        nickname = ""
        Globaluserid = ""
        query = "Select * from user where username= '" & FrmLogin.txtusername.Text & "' and password= '" & FrmLogin.txtpassword.Text & "'"
        runServer()
        MysqlConn.Open()
        COMMAND = New MySqlCommand(query, MysqlConn)
        SDA.SelectCommand = COMMAND
        SDA.Fill(dbDataset)
        bSource.DataSource = dbDataset
        READER = COMMAND.ExecuteReader
        While READER.Read()
            nickname = READER("nickname").ToString
            Globaluserid = READER("id").ToString
            'userinfo = READER("fname").ToString & " " & READER("lname").ToString

        End While
        READER.Close()
        MysqlConn.Close()
        If Globaluserid <> "" Then
            FrmMain.ShowDialog()
            FrmLogin.txtpassword.Clear()
            FrmLogin.txtusername.Clear()
        Else
            MsgBox("Invalid Username/Password")
            FrmLogin.txtpassword.Clear()
            FrmLogin.txtusername.Clear()
            FrmLogin.txtusername.Focus()
        End If

    End Sub
End Class
