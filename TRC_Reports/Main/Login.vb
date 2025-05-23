Imports MySql.Data.MySqlClient
Public Class Login
    Public testMode As Boolean = 0

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click

        Login(txt_idno.Text.Trim(), txt_password.Text.Trim())

    End Sub


    Private Sub Login(username As String, password As String)

        ' Check if fields are empty
        If username = "" Then
            Show_Error("Please enter ID number.", SOUND_NONE)
            txt_idno.Focus()
            Exit Sub
        End If


        If isLogin(username, EncryptPassword(password)) Then
            display_inMain(subframe)

            Me.Close()


        Else
            Show_Error("Access Denied.", SOUND_NONE)
            txt_idno.Focus()
        End If
    End Sub

    Private Sub txt_password_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_password.KeyDown, txt_idno.KeyDown

        If e.KeyCode = Keys.Enter Then
                Login(txt_idno.Text.Trim(), txt_password.Text.Trim())
            End If

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If testMode = True Then
            Dim query As String = "SELECT `password` FROM " & userTable & " WHERE IDno = @IDno "
            Using cmd As New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@IDno", "03200728")

                con.Close()
                con.Open()
                dr = cmd.ExecuteReader
                If dr.Read = True Then


                    If isLogin("03200728", (dr.GetString("password"))) Then
                        display_inMain(subframe)


                    End If
                End If

            End Using
        End If

    End Sub
End Class