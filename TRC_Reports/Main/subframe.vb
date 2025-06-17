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

    End Sub

    Private Sub DailySummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailySummaryToolStripMenuItem.Click
        display_inSub(New molding_daily_summary)
    End Sub

    Private Sub LiveFGStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiveFGStockToolStripMenuItem.Click
        display_inSub(New molding_stocks)
    End Sub

    Private Sub SunboToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SunboToolStripMenuItem.Click
        display_inSub(New Logistics_sunbo)
    End Sub

    Private Sub Unit56ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Unit56ToolStripMenuItem.Click
        display_inSub(New Logistics_unit56)
    End Sub

    Private Sub PaintingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaintingToolStripMenuItem.Click

    End Sub

    Private Sub MonthlyReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthlyReportToolStripMenuItem.Click
        display_inSub(New painting_monthly)
    End Sub

    Private Sub DailyReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyReportToolStripMenuItem.Click
        display_inSub(New painting_daily)
    End Sub

    Private Sub LiveFGStocksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiveFGStocksToolStripMenuItem.Click
        display_inSub(New painting_stock)
    End Sub

    Private Sub InTransitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InTransitToolStripMenuItem.Click
        display_inSub(New molding_intransit)
    End Sub

    Private Sub CheckUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckUpdatesToolStripMenuItem.Click
        CheckUpdate()
    End Sub
    Private Sub subframe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Update_timer.Interval = 1800000 ' 30 minutes in milliseconds (30 * 60 * 1000)
        Update_timer.Start()
    End Sub

    Private Sub Update_timer_Tick(sender As Object, e As EventArgs) Handles Update_timer.Tick
        CheckUpdate(0)
    End Sub
End Class