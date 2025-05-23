Public Class subframe
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btn_menu.Click
        If btn_menu.ContextMenuStrip IsNot Nothing Then
            btn_menu.ContextMenuStrip.Show(btn_menu, 0, btn_menu.Height)

        End If
    End Sub

    Private Sub btn_profile_Click(sender As Object, e As EventArgs) Handles btn_profile.Click
        btn_user.Text = "Hi, " & user_UserName
        btn_administrator.Visible = isAccess("admin") Or isSuperadmin

        If btn_profile.ContextMenuStrip IsNot Nothing Then
            btn_profile.ContextMenuStrip.Show(btn_profile, 0, btn_profile.Height)

        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click

        display_inMain(Login)

        Me.Close()
    End Sub


    Private Sub AddUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddUserToolStripMenuItem.Click
        display_inSub(add_user)
    End Sub

    Private Sub profile_menu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles profile_menu.Opening

    End Sub

    Private Sub btn_user_Click(sender As Object, e As EventArgs) Handles btn_user.Click

    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        display_inSub(change_password)
    End Sub

    Private Sub ManageUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageUsersToolStripMenuItem.Click
        display_inSub(New manage_users)
    End Sub

    Private Sub ChaneInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChaneInfoToolStripMenuItem.Click
        display_inSub(New update_name)
    End Sub

    Private Sub FGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FGToolStripMenuItem.Click
        display_inSub(molding_fg)
    End Sub
End Class