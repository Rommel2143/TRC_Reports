Imports MySql.Data.MySqlClient

Public Class update_name

    Dim dataid

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If txt_idno.Text.Trim() = "" OrElse txt_firstname.Text.Trim() = "" OrElse txt_lastname.Text.Trim() = "" Then
            MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Try
            con.Close()
            con.Open()
            Dim cmd As New MySqlCommand("UPDATE " & userTable & " SET Firstname = @fname, Lastname = @lname,IDno = @idno WHERE id='" & dataid & "'", con)
            cmd.Parameters.AddWithValue("@fname", txt_firstname.Text.Trim())
            cmd.Parameters.AddWithValue("@lname", txt_lastname.Text.Trim())
            cmd.Parameters.AddWithValue("@idno", txt_idno.Text.Trim())

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("User information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                display_inSub(New manage_users)
                Me.Close()

            Else
                MessageBox.Show("No matching record found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub loaddata(id As Integer, idno As String, firstname As String, lastname As String)
        dataid = id
        txt_idno.Text = idno
        txt_firstname.Text = firstname
        txt_lastname.Text = lastname
    End Sub






    Private Sub update_name_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Try

            If MessageBox.Show("Are you sure you want to reset the password?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            con.Close()
            con.Open()

            Dim query As String = "UPDATE " & userTable & " SET password = '8TUIs5Kns6c3+XEbV2pTFQ==' WHERE id = @id"
            Using cmd As New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@id", dataid)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Password has been reset.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("No matching record found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

End Class
