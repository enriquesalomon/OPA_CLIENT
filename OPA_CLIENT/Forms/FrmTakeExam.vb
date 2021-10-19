Public Class FrmTakeExam
    Dim ss, tt, vv As Integer
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
    End Sub

    Private Sub FrmTakeExam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblexamtitle.Text = FrmExamMaster.examcode

    End Sub

    Private Sub btnstart_Click(sender As Object, e As EventArgs) Handles btnstart.Click
        Timer1.Enabled = True
        btnstart.Enabled = False
        btnsubmit.Enabled = True
    End Sub

    Private Sub gettime()
        lbltimer.Text = Format(stringServer, "00:") & Format(tt, "00:") & Format(vv, "00")
        vv = vv + 1
        If vv > 59 Then
            vv = 0
            tt = tt + 1
        End If
        If tt = 2 Then
            vv = 0
            tt = 0
            lbltimer.Text = "00:00:00"
            lbltimer.Enabled = False
            MessageBox.Show("Time Ended")
        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        gettime()
    End Sub
End Class