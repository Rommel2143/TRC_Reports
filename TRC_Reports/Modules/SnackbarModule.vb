﻿Module SnackbarModule

    Public Const SOUND_NONE As Integer = 0
    Public Const SOUND_ERROR As Integer = 1
    Public Const SOUND_DUPLICATE As Integer = 2

    ' Overload with sound selection
    Public Sub Show_Error(text As String, sound As Integer)
        ShowSnackbar(text)

        Select Case sound
            Case SOUND_NONE Or 0
                ' No sound
            Case SOUND_ERROR Or 1
                My.Computer.Audio.Play(My.Resources.errorsound, AudioPlayMode.Background)
            Case SOUND_DUPLICATE Or 2
                My.Computer.Audio.Play(My.Resources.duplicate, AudioPlayMode.Background)
        End Select
    End Sub

    ' Overload without sound selection (defaults to no sound)
    Public Sub Show_Error(text As String)
        ShowSnackbar(text)
        ' No sound
    End Sub




    Private Sub ShowSnackbar(message As String)
        ' Create a new Form to act as the snackbar
        Dim snackbarForm As New Form()

        ' Set basic properties
        snackbarForm.FormBorderStyle = FormBorderStyle.None
        snackbarForm.StartPosition = FormStartPosition.Manual
        snackbarForm.BackColor = Color.FromArgb(60, 63, 65) ' Dark background
        snackbarForm.ForeColor = Color.White ' White text
        snackbarForm.Height = 40 ' Set the height of the snackbar
        snackbarForm.Width = Screen.PrimaryScreen.Bounds.Width ' Set the width to screen width
        snackbarForm.TopMost = True ' Ensure it's on top
        snackbarForm.ShowInTaskbar = False

        ' Set the position at the top of the screen (90 pixels from the top)
        snackbarForm.Location = New Point(0, 90)

        ' Add a label to display the message
        Dim messageLabel As New Label()
        messageLabel.Text = message
        messageLabel.Font = New Font("Segoe UI", 10)
        messageLabel.ForeColor = Color.White
        messageLabel.AutoSize = False
        messageLabel.TextAlign = ContentAlignment.MiddleCenter
        messageLabel.Dock = DockStyle.Fill
        snackbarForm.Controls.Add(messageLabel)

        snackbarForm.Show()

        ' Set up a timer to close the snackbar after a few seconds
        Dim closeTimer As New Timer()
        AddHandler closeTimer.Tick, Sub(sender, e)
                                        For i As Integer = 10 To 0 Step -1
                                            snackbarForm.Opacity = i / 10.0
                                            Threading.Thread.Sleep(30)
                                        Next
                                        snackbarForm.Close()
                                        closeTimer.Stop()
                                    End Sub
        closeTimer.Interval = 3000
        closeTimer.Start()
    End Sub





End Module
