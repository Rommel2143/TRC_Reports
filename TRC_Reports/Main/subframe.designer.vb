<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subframe
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subframe))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnmenu_strip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MoldingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiveFGStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailySummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogisticsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Unit56ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SunboToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaintingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.profile_menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.lbl_FormName = New System.Windows.Forms.Label()
        Me.LiveFGStocksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonthlyReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailyReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_menu = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_profile = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_user = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChaneInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_administrator = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2.SuspendLayout()
        Me.btnmenu_strip.SuspendLayout()
        Me.profile_menu.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 107)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1168, 568)
        Me.Panel1.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.btn_menu)
        Me.Panel2.Controls.Add(Me.btn_profile)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1168, 51)
        Me.Panel2.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 30)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Inventory Reports"
        '
        'btnmenu_strip
        '
        Me.btnmenu_strip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmenu_strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoldingToolStripMenuItem, Me.LogisticsToolStripMenuItem, Me.PaintingToolStripMenuItem})
        Me.btnmenu_strip.Name = "ContextMenuStrip1"
        Me.btnmenu_strip.Size = New System.Drawing.Size(181, 104)
        '
        'MoldingToolStripMenuItem
        '
        Me.MoldingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FGToolStripMenuItem, Me.ResinToolStripMenuItem})
        Me.MoldingToolStripMenuItem.Name = "MoldingToolStripMenuItem"
        Me.MoldingToolStripMenuItem.Size = New System.Drawing.Size(180, 26)
        Me.MoldingToolStripMenuItem.Text = "Molding"
        '
        'FGToolStripMenuItem
        '
        Me.FGToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LiveFGStockToolStripMenuItem, Me.DailySummaryToolStripMenuItem})
        Me.FGToolStripMenuItem.Name = "FGToolStripMenuItem"
        Me.FGToolStripMenuItem.Size = New System.Drawing.Size(118, 26)
        Me.FGToolStripMenuItem.Text = "FG"
        '
        'LiveFGStockToolStripMenuItem
        '
        Me.LiveFGStockToolStripMenuItem.Name = "LiveFGStockToolStripMenuItem"
        Me.LiveFGStockToolStripMenuItem.Size = New System.Drawing.Size(187, 26)
        Me.LiveFGStockToolStripMenuItem.Text = "Live FG Stock"
        '
        'DailySummaryToolStripMenuItem
        '
        Me.DailySummaryToolStripMenuItem.Name = "DailySummaryToolStripMenuItem"
        Me.DailySummaryToolStripMenuItem.Size = New System.Drawing.Size(187, 26)
        Me.DailySummaryToolStripMenuItem.Text = "Daily Summary"
        '
        'ResinToolStripMenuItem
        '
        Me.ResinToolStripMenuItem.Name = "ResinToolStripMenuItem"
        Me.ResinToolStripMenuItem.Size = New System.Drawing.Size(118, 26)
        Me.ResinToolStripMenuItem.Text = "Resin"
        '
        'LogisticsToolStripMenuItem
        '
        Me.LogisticsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Unit56ToolStripMenuItem, Me.SunboToolStripMenuItem})
        Me.LogisticsToolStripMenuItem.Name = "LogisticsToolStripMenuItem"
        Me.LogisticsToolStripMenuItem.Size = New System.Drawing.Size(180, 26)
        Me.LogisticsToolStripMenuItem.Text = "Logistics"
        '
        'Unit56ToolStripMenuItem
        '
        Me.Unit56ToolStripMenuItem.Name = "Unit56ToolStripMenuItem"
        Me.Unit56ToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.Unit56ToolStripMenuItem.Text = "Unit 5-6"
        '
        'SunboToolStripMenuItem
        '
        Me.SunboToolStripMenuItem.Name = "SunboToolStripMenuItem"
        Me.SunboToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.SunboToolStripMenuItem.Text = "Sunbo"
        '
        'PaintingToolStripMenuItem
        '
        Me.PaintingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LiveFGStocksToolStripMenuItem, Me.MonthlyReportToolStripMenuItem, Me.DailyReportToolStripMenuItem})
        Me.PaintingToolStripMenuItem.Name = "PaintingToolStripMenuItem"
        Me.PaintingToolStripMenuItem.Size = New System.Drawing.Size(180, 26)
        Me.PaintingToolStripMenuItem.Text = "Painting"
        '
        'profile_menu
        '
        Me.profile_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_user, Me.ToolStripSeparator1, Me.btn_administrator, Me.LogoutToolStripMenuItem})
        Me.profile_menu.Name = "ContextMenuStrip1"
        Me.profile_menu.Size = New System.Drawing.Size(182, 100)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(178, 6)
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.lbl_FormName)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 51)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1168, 56)
        Me.Guna2Panel1.TabIndex = 8
        '
        'lbl_FormName
        '
        Me.lbl_FormName.AutoSize = True
        Me.lbl_FormName.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FormName.ForeColor = System.Drawing.Color.DimGray
        Me.lbl_FormName.Location = New System.Drawing.Point(33, 3)
        Me.lbl_FormName.Name = "lbl_FormName"
        Me.lbl_FormName.Size = New System.Drawing.Size(31, 25)
        Me.lbl_FormName.TabIndex = 9
        Me.lbl_FormName.Text = "➥"
        '
        'LiveFGStocksToolStripMenuItem
        '
        Me.LiveFGStocksToolStripMenuItem.Name = "LiveFGStocksToolStripMenuItem"
        Me.LiveFGStocksToolStripMenuItem.Size = New System.Drawing.Size(189, 26)
        Me.LiveFGStocksToolStripMenuItem.Text = "Live FG Stocks"
        '
        'MonthlyReportToolStripMenuItem
        '
        Me.MonthlyReportToolStripMenuItem.Name = "MonthlyReportToolStripMenuItem"
        Me.MonthlyReportToolStripMenuItem.Size = New System.Drawing.Size(189, 26)
        Me.MonthlyReportToolStripMenuItem.Text = "Monthly Report"
        '
        'DailyReportToolStripMenuItem
        '
        Me.DailyReportToolStripMenuItem.Name = "DailyReportToolStripMenuItem"
        Me.DailyReportToolStripMenuItem.Size = New System.Drawing.Size(189, 26)
        Me.DailyReportToolStripMenuItem.Text = "Daily Report"
        '
        'btn_menu
        '
        Me.btn_menu.BackColor = System.Drawing.Color.Transparent
        Me.btn_menu.ContextMenuStrip = Me.btnmenu_strip
        Me.btn_menu.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_menu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_menu.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_menu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_menu.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_menu.FillColor = System.Drawing.SystemColors.ControlLight
        Me.btn_menu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn_menu.ForeColor = System.Drawing.Color.DimGray
        Me.btn_menu.Image = CType(resources.GetObject("btn_menu.Image"), System.Drawing.Image)
        Me.btn_menu.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn_menu.Location = New System.Drawing.Point(1044, 0)
        Me.btn_menu.Name = "btn_menu"
        Me.btn_menu.Size = New System.Drawing.Size(62, 51)
        Me.btn_menu.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btn_menu, "Menu")
        Me.btn_menu.UseTransparentBackground = True
        '
        'btn_profile
        '
        Me.btn_profile.BackColor = System.Drawing.Color.Transparent
        Me.btn_profile.ContextMenuStrip = Me.profile_menu
        Me.btn_profile.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_profile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_profile.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_profile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_profile.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_profile.FillColor = System.Drawing.SystemColors.ControlLight
        Me.btn_profile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn_profile.ForeColor = System.Drawing.Color.DimGray
        Me.btn_profile.Image = CType(resources.GetObject("btn_profile.Image"), System.Drawing.Image)
        Me.btn_profile.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn_profile.Location = New System.Drawing.Point(1106, 0)
        Me.btn_profile.Name = "btn_profile"
        Me.btn_profile.Size = New System.Drawing.Size(62, 51)
        Me.btn_profile.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btn_profile, "Profile")
        '
        'btn_user
        '
        Me.btn_user.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem, Me.ChaneInfoToolStripMenuItem})
        Me.btn_user.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_user.ForeColor = System.Drawing.Color.Black
        Me.btn_user.Image = CType(resources.GetObject("btn_user.Image"), System.Drawing.Image)
        Me.btn_user.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_user.Name = "btn_user"
        Me.btn_user.Size = New System.Drawing.Size(181, 30)
        Me.btn_user.Text = "User"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(203, 26)
        Me.ChangePasswordToolStripMenuItem.Text = "Change Password"
        '
        'ChaneInfoToolStripMenuItem
        '
        Me.ChaneInfoToolStripMenuItem.Name = "ChaneInfoToolStripMenuItem"
        Me.ChaneInfoToolStripMenuItem.Size = New System.Drawing.Size(203, 26)
        Me.ChaneInfoToolStripMenuItem.Text = "Change Info"
        '
        'btn_administrator
        '
        Me.btn_administrator.BackColor = System.Drawing.Color.MistyRose
        Me.btn_administrator.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddUserToolStripMenuItem, Me.ManageUsersToolStripMenuItem})
        Me.btn_administrator.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_administrator.ForeColor = System.Drawing.Color.DimGray
        Me.btn_administrator.Image = CType(resources.GetObject("btn_administrator.Image"), System.Drawing.Image)
        Me.btn_administrator.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_administrator.Name = "btn_administrator"
        Me.btn_administrator.Size = New System.Drawing.Size(181, 30)
        Me.btn_administrator.Text = "Administrator"
        Me.btn_administrator.Visible = False
        '
        'AddUserToolStripMenuItem
        '
        Me.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem"
        Me.AddUserToolStripMenuItem.Size = New System.Drawing.Size(179, 26)
        Me.AddUserToolStripMenuItem.Text = "Add User"
        '
        'ManageUsersToolStripMenuItem
        '
        Me.ManageUsersToolStripMenuItem.Name = "ManageUsersToolStripMenuItem"
        Me.ManageUsersToolStripMenuItem.Size = New System.Drawing.Size(179, 26)
        Me.ManageUsersToolStripMenuItem.Text = "Manage Users"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogoutToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray
        Me.LogoutToolStripMenuItem.Image = CType(resources.GetObject("LogoutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LogoutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(181, 30)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'subframe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 675)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "subframe"
        Me.Text = "subframe"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.btnmenu_strip.ResumeLayout(False)
        Me.profile_menu.ResumeLayout(False)
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_menu As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents btn_profile As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents profile_menu As ContextMenuStrip
    Friend WithEvents btn_administrator As ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnmenu_strip As ContextMenuStrip
    Friend WithEvents btn_user As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Label1 As Label
    Friend WithEvents AddUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageUsersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lbl_FormName As Label
    Friend WithEvents ChaneInfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MoldingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FGToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResinToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LiveFGStockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DailySummaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogisticsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Unit56ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SunboToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PaintingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LiveFGStocksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MonthlyReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DailyReportToolStripMenuItem As ToolStripMenuItem
End Class
