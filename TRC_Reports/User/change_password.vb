Imports MySql.Data.MySqlClient
Public Class change_password
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        UpdatePassword()
    End Sub

    Private Sub UpdatePassword()

        ' Ensure all fields are filled

        ' Validate new password and confirmation
        If txt_new.Text <> txt_confirm.Text Then
            MessageBox.Show("New password and confirmation do not match.")
            Exit Sub
        End If

        Try

            ' Check if current password is correct
            If EncryptPassword(txt_current.Text) <> user_Password Then
                MessageBox.Show("Current password is incorrect.")
                Exit Sub
            End If
            con.Close()
            con.Open()
            ' Update password
            Dim query As String = "UPDATE " & userTable & " SET password = @newPassword WHERE ID = @IDno"
            Using cmd As New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@newPassword", EncryptPassword(txt_new.Text))
                cmd.Parameters.AddWithValue("@IDno", user_ID)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Password changed successfully.")
            txt_current.Clear()
            txt_new.Clear()
            txt_confirm.Clear()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub
End Class
