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

    Function runServer()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = stringServer
    End Function

End Module
