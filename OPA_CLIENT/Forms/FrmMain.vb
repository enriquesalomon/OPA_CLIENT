﻿Public Class FrmMain
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
        FrmLogin.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With FrmExamMaster
            .TopLevel = False
            Panel5.Controls.Add(FrmExamMaster)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        With FrmDashboard
            .TopLevel = False
            Panel5.Controls.Add(FrmDashboard)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyExam.ExamListCount()
        MyExam.ExamList()
        lblname.Text = nickname
        With FrmDashboard
            .TopLevel = False
            Panel5.Controls.Add(FrmDashboard)
            .BringToFront()
            .Show()
        End With
    End Sub
End Class