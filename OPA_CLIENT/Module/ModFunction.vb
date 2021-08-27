Imports MySql.Data.MySqlClient

Module ModFunction
    Public Sub connect()
        Dim conn As New MySqlConnection
        Dim DatabaseName As String = "ope"
        Dim server As String = "localhost"
        Dim username As String = "root"
        Dim passwordserver As String = ""

        If Not conn Is Nothing Then conn.Close()
        conn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false;SslMode=none;", server, username, passwordserver, DatabaseName)
        Try
            conn.Open()

            MsgBox("Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()

        'Dim MySqlConnection As New MySqlConnection("host=127.0.0.1;user=root;password=;pooling=false;database=ope;SslMode=none;")
        'Try
        '    MySqlConnection.Open()
        '    MsgBox("Connected")
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'MySqlConnection.Close()

    End Sub
End Module
