Imports MySql.Data.MySqlClient
Module GlobalVariable
    Public MyLogin As New Login
    Public MyExam As New ExamMaster

    Public globalDefaultID As String
    Public path, globalClock As String
    Public Globaluserid, GlobalitemID, GlobalCatID As String
    Public userinfo, usertype, nickname As String
    Public query As String

    Public mycommand As New MySqlCommand
    Public myadapter As New MySqlDataAdapter
    Public mysqlreader As MySqlDataReader
    Public mydataset, ndataset As New DataSet
    Public mydataTable, ntable As New DataTable

End Module
