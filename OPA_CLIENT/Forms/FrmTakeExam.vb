Public Class FrmTakeExam
    Dim ss, tt, vv As Integer
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
    End Sub

    Private Sub FrmTakeExam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblexamtitle.Text = FrmExamMaster.examcode

        lblquestion.Top = (lblquestion.Parent.Height \ 2) - (lblquestion.Height \ 2)
        lblquestion.Left = (lblquestion.Parent.Width \ 2) - (lblquestion.Width \ 2)

        RadioButton1.Top = (RadioButton1.Parent.Height \ 2) - (RadioButton1.Height \ 2)
        RadioButton1.Left = (RadioButton1.Parent.Width \ 2) - (RadioButton1.Width \ 2)

        RadioButton2.Top = (RadioButton2.Parent.Height \ 2) - (RadioButton2.Height \ 2)
        RadioButton2.Left = (RadioButton2.Parent.Width \ 2) - (RadioButton2.Width \ 2)

        RadioButton3.Top = (RadioButton3.Parent.Height \ 2) - (RadioButton3.Height \ 2)
        RadioButton3.Left = (RadioButton3.Parent.Width \ 2) - (RadioButton3.Width \ 2)


        RadioButton4.Top = (RadioButton4.Parent.Height \ 2) - (RadioButton4.Height \ 2)
        RadioButton4.Left = (RadioButton4.Parent.Width \ 2) - (RadioButton4.Width \ 2)

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