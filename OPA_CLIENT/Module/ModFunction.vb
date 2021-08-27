Imports MySql.Data.MySqlClient

Module ModFunction

    Public MysqlConn As MySqlConnection
    Public COMMAND As MySqlCommand
    Public stringServer = "server=localhost;userid=root;password=;database=ope;pooling=false;SslMode=none;"
    ';database=sakila
    Public READER As MySqlDataReader
    Public SDA As New MySqlDataAdapter
    Public dbDataset As New DataTable
    Public bSource As New BindingSource
    'Public Sub connect()
    '    Dim conn As New MySqlConnection
    '    Dim DatabaseName As String = "ope"
    '    Dim server As String = "localhost"
    '    Dim username As String = "root"
    '    Dim passwordserver As String = ""

    '    If Not conn Is Nothing Then conn.Close()
    '    conn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false;SslMode=none;", server, username, passwordserver, DatabaseName)
    '    Try
    '        conn.Open()

    '        MsgBox("Connected")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    conn.Close()

    '    'Dim MySqlConnection As New MySqlConnection("host=127.0.0.1;user=root;password=;pooling=false;database=ope;SslMode=none;")
    '    'Try
    '    '    MySqlConnection.Open()
    '    '    MsgBox("Connected")
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    'End Try
    '    'MySqlConnection.Close()
    'End Sub
    Function runServer()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = stringServer
    End Function

End Module
