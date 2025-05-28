Imports MySql.Data.MySqlClient
Public Class painting_daily
    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs)
        loaddata()
    End Sub


    Private Sub loaddata()
        Dim setdate As String = dtpicker1.Value.ToString("yyyy-MM-dd")
        Dim settime As String = If(chk_630.Checked = True, "6:31:00", Date.Now.ToString("HH:mm:ss"))
        Dim selectedDT As String = setdate & " " & settime
        Dim startOfMonth As String = dtpicker1.Value.ToString("yyyy-MM-01")
        Dim endOfMonth As String = dtpicker1.Value.ToString("yyyy-MM-31") ' Not used, can be removed if unnecessary

        Dim query As String = "
SELECT 
    pm.partcode,
    pm.partname,

    -- Total IN for current day
    IFNULL(SUM(CASE 
        WHEN ps.datein = '" & setdate & "' 
        THEN ps.qty 
        ELSE 0 
    END), 0) AS totalIN_today,

    -- Total OUT for current day
    IFNULL(SUM(CASE 
        WHEN ps.dateout = '" & setdate & "' 
        THEN ps.qty 
        ELSE 0 
    END), 0) AS totalOUT_today,

    -- Total stock (all-time IN - all-time OUT)
    IFNULL(SUM(CASE WHEN ps.datein <= '" & setdate & "'  THEN ps.qty ELSE 0 END), 0) -
    IFNULL(SUM(CASE WHEN ps.dateout <= '" & setdate & "'  THEN ps.qty ELSE 0 END), 0) AS total_stock

FROM 
    painting_masterlist pm
LEFT JOIN 
    painting_stock ps ON ps.partcode = pm.partcode 

GROUP BY 
    pm.partcode, pm.partname
ORDER BY 
    pm.partcode;

"

        reload(query, datagrid1)

    End Sub






    Private Sub fg_monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpicker1.Value = Date.Now

    End Sub

    Private Sub dtpicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker1.ValueChanged, chk_630.CheckedChanged
        loaddata()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        exportExcel(datagrid1, "Painting FG Stocks", dtpicker1.Value.ToString("MMMM dd, yyyy"))
    End Sub





End Class