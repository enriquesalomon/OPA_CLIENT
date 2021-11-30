Imports MySql.Data.MySqlClient
Module GlobalVariable
    Public MyLogin As New Login
    Public MyExam As New ExamMaster

    Public globalDefaultID As String
    Public path, globalClock As String
    Public Globaluserid, studentno As String
    Public userinfo, usertype, nickname As String
    Public query As String
    Public examcode, examid, subjectid, examtype, subject As String
    Public examtotalquestion As Integer
    Public timelimit As String
    Public examineeexamid As String
    Public examdate As String
    Public mycommand As New MySqlCommand
    Public myadapter As New MySqlDataAdapter
    Public mysqlreader As MySqlDataReader
    Public mydataset, ndataset As New DataSet
    Public mydataTable, ntable As New DataTable

    Public adataset, xdataset, pdataset, cdataset As New DataSet
    Public xdataTable, atable, pdatatable, cdatable As New DataTable

    Public xYdataTable As New DataTable
    Public xYdataset As New DataSet

End Module
