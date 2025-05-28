Imports MySql.Data.MySqlClient

Public Class painting_monthly
    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs)
        loaddata()
    End Sub

    Private Sub loaddata()
        If cmb_box.SelectedIndex = -1 Then
            MessageBox.Show("Please select a month.")
            Exit Sub
        End If

        Dim selectedMonth As Integer = cmb_box.SelectedIndex + 1
        Dim selectedYear As Integer = Guna2NumericUpDown1.Value

        ' Compute the last day of the selected month
        Dim endOfMonth As New DateTime(selectedYear, selectedMonth, DateTime.DaysInMonth(selectedYear, selectedMonth))
        Dim endOfMonthStr As String = endOfMonth.ToString("yyyy-MM-dd")

        Dim query As String = "
        SELECT 
            mm.partcode,
            mm.partname,
            IFNULL(painting.total_in, 0) AS Molding_IN,
            IFNULL(painting.total_out, 0) AS Molding_OUT,
            IFNULL(painting.box_count, 0) AS Molding_BoxCount,
            IFNULL(painting.total, 0) AS Molding_Total
        FROM painting_masterlist mm
        LEFT JOIN (
            SELECT partcode,
              SUM(CASE WHEN MONTH(dateIN) = " & selectedMonth & " AND YEAR(dateIN) = " & selectedYear & " THEN qty ELSE 0 END) AS total_in,
              SUM(CASE WHEN MONTH(dateOUT) = " & selectedMonth & " AND YEAR(dateOUT) = " & selectedYear & " THEN qty ELSE 0 END) AS total_out,

                (SUM(CASE WHEN dateIN <= '" & endOfMonthStr & "' THEN 1 ELSE 0 END) -
                 SUM(CASE WHEN dateOUT <= '" & endOfMonthStr & "' THEN 1 ELSE 0 END)) AS box_count,
                (SUM(CASE WHEN dateIN <= '" & endOfMonthStr & "' THEN qty ELSE 0 END) -
                 SUM(CASE WHEN dateOUT <= '" & endOfMonthStr & "' THEN qty ELSE 0 END)) AS total
            FROM painting_stock
            GROUP BY partcode
        ) AS painting ON mm.partcode = painting.partcode
    "

        reload(query, datagrid1)
    End Sub




    Private Sub fg_monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmb_box.SelectedItem = Date.Now.ToString("MMMM")
        Guna2NumericUpDown1.Value = Date.Now.ToString("yyyy")
    End Sub



    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        exportExcel(datagrid1, "Molding FG Stocks", cmb_box.Text)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        loaddata()
    End Sub
End Class