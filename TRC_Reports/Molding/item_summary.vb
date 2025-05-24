Public Class item_summary

    Dim selectedpartcode As String


    Public Sub getData(Partcode As String, partname As String)
        lbl_partcode.Text = Partcode
        lbl_partname.Text = partname
        selectedpartcode = Partcode
        loaddata()
    End Sub


    Sub loaddata()
        Dim fromDate As Date = dt_from.Value
        Dim toDate As Date = dt_to.Value

        Dim query As String = "
WITH combined_data AS (
    SELECT partcode, DATE(dateIN) AS trans_date, qty, 'moldingIN' AS type FROM molding_stock WHERE dateIN IS NOT NULL
    UNION ALL
    SELECT partcode, DATE(dateOUT) AS trans_date, qty, 'moldingOUT' FROM molding_stock WHERE dateOUT IS NOT NULL
    UNION ALL
    SELECT partcode, DATE(dateIN) AS trans_date, qty, 'logisticsIN' FROM logistics_unit56 WHERE dateIN IS NOT NULL
    UNION ALL
    SELECT partcode, DATE(dateOUT) AS trans_date, qty, 'logisticsOUT' FROM logistics_unit56 WHERE dateOUT IS NOT NULL
    UNION ALL
    SELECT partcode, DATE(dateIN) AS trans_date, qty, 'sunboIN' FROM logistics_sunbo WHERE dateIN IS NOT NULL
    UNION ALL
    SELECT partcode, DATE(dateOUT) AS trans_date, qty, 'sunboOUT' FROM logistics_sunbo WHERE dateOUT IS NOT NULL
),

daily_summary AS (
    SELECT 
        trans_date,
        partcode,
        SUM(CASE WHEN type = 'moldingIN' THEN qty ELSE 0 END) AS moldingIN,
        SUM(CASE WHEN type = 'moldingOUT' THEN qty ELSE 0 END) AS moldingOUT,
        SUM(CASE WHEN type = 'logisticsIN' THEN qty ELSE 0 END) AS logisticsIN,
        SUM(CASE WHEN type = 'logisticsOUT' THEN qty ELSE 0 END) AS logisticsOUT,
        SUM(CASE WHEN type = 'sunboIN' THEN qty ELSE 0 END) AS sunboIN,
        SUM(CASE WHEN type = 'sunboOUT' THEN qty ELSE 0 END) AS sunboOUT
    FROM combined_data
    GROUP BY trans_date, partcode
),

stock_with_balance AS (
    SELECT 
        ds.trans_date,
        ds.partcode,
        ds.moldingIN,
        ds.moldingOUT,
        ds.logisticsIN,
        ds.logisticsOUT,
        ds.sunboIN,
        ds.sunboOUT,
        (
            SELECT SUM(
                COALESCE(d2.moldingIN, 0) + COALESCE(d2.logisticsIN, 0) + COALESCE(d2.sunboIN, 0) -
                COALESCE(d2.moldingOUT, 0) - COALESCE(d2.logisticsOUT, 0) - COALESCE(d2.sunboOUT, 0)
            )
            FROM daily_summary d2
            WHERE d2.partcode = ds.partcode AND d2.trans_date <= ds.trans_date
        ) AS stock_balance
    FROM daily_summary ds
)

SELECT 
    swb.trans_date AS date,
    swb.moldingIN,
    swb.moldingOUT,
    swb.logisticsIN,
    swb.logisticsOUT,
    swb.sunboIN,
    swb.sunboOUT,
    swb.Stock_Balance
FROM stock_with_balance swb
JOIN molding_masterlist mm ON mm.partcode = swb.partcode
WHERE swb.partcode = '" & selectedpartcode & "'
  AND swb.trans_date BETWEEN '" & fromDate.ToString("yyyy-MM-dd") & "' AND '" & toDate.ToString("yyyy-MM-dd") & "'
ORDER BY swb.trans_date ASC
"

        reload(query, datagrid1)
        stockcolor()

    End Sub

    Sub stockcolor()
        If datagrid1.Columns.Contains("Stock_Balance") Then
            For Each row As DataGridViewRow In datagrid1.Rows
                If Not row.IsNewRow Then
                    row.Cells("stock_balance").Style.ForeColor = Color.Green
                    row.Cells("stock_balance").Style.Font = New Font(datagrid1.Font, FontStyle.Bold)
                End If
            Next
        End If
    End Sub




    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim fg As New molding_fg
        display_inSub(fg)
    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub


    Private Sub item_summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim today As Date = Date.Today
        dt_from.Value = New Date(today.Year, today.Month, 1)
        dt_to.Value = today
    End Sub

    Private Sub dt_to_ValueChanged(sender As Object, e As EventArgs) Handles dt_to.ValueChanged
        loaddata()

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        exportExcel(datagrid1, selectedpartcode & " Summary")
    End Sub
End Class