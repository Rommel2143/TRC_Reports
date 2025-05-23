Public Class item_summary

    Dim selectedpartcode As String


    Public Sub getData(Partcode As String, partname As String)
        lbl_partcode.Text = Partcode
        lbl_partname.Text = partname
        selectedpartcode = Partcode
    End Sub

    Sub loaddata()
        Dim fromDate As Date = dt_from.Value
        Dim toDate As Date = dt_to.Value

        Dim query As String = "
    SELECT 
        summary.date_summary,
     
        -- Molding
        SUM(CASE WHEN summary.source = 'mold_in' THEN summary.qty ELSE 0 END) AS Molding_IN,
        SUM(CASE WHEN summary.source = 'mold_out' THEN summary.qty ELSE 0 END) AS Molding_OUT,
        SUM(CASE WHEN summary.source = 'mold_in' THEN summary.qty ELSE 0 END) -
        SUM(CASE WHEN summary.source = 'mold_out' THEN summary.qty ELSE 0 END) AS 'M( +/-)',

        -- Unit 56
        SUM(CASE WHEN summary.source = 'unit56_in' THEN summary.qty ELSE 0 END) AS Unit56_IN,
        SUM(CASE WHEN summary.source = 'unit56_out' THEN summary.qty ELSE 0 END) AS Unit56_OUT,
        SUM(CASE WHEN summary.source = 'unit56_in' THEN summary.qty ELSE 0 END) -
        SUM(CASE WHEN summary.source = 'unit56_out' THEN summary.qty ELSE 0 END) AS 'U( +/-)',

        -- Sunbo
        SUM(CASE WHEN summary.source = 'sunbo_in' THEN summary.qty ELSE 0 END) AS Sunbo_IN,
        SUM(CASE WHEN summary.source = 'sunbo_out' THEN summary.qty ELSE 0 END) AS Sunbo_OUT,
        SUM(CASE WHEN summary.source = 'sunbo_in' THEN summary.qty ELSE 0 END) -
        SUM(CASE WHEN summary.source = 'sunbo_out' THEN summary.qty ELSE 0 END) AS 'S( +/-)'

    
    FROM (
        SELECT partcode, DATE(dateIN) AS date_summary, qty, 'mold_in' AS source FROM molding_stock WHERE dateIN IS NOT NULL
        UNION ALL
        SELECT partcode, DATE(dateOUT) AS date_summary, qty, 'mold_out' FROM molding_stock WHERE dateOUT IS NOT NULL
        UNION ALL
        SELECT partcode, DATE(datein) AS date_summary, qty, 'unit56_in' FROM logistics_unit56 WHERE datein IS NOT NULL
        UNION ALL
        SELECT partcode, DATE(dateout) AS date_summary, qty, 'unit56_out' FROM logistics_unit56 WHERE dateout IS NOT NULL
        UNION ALL
        SELECT partcode, DATE(datein) AS date_summary, qty, 'sunbo_in' FROM logistics_sunbo WHERE datein IS NOT NULL
        UNION ALL
        SELECT partcode, DATE(dateout) AS date_summary, qty, 'sunbo_out' FROM logistics_sunbo WHERE dateout IS NOT NULL
    ) AS summary

    INNER JOIN molding_masterlist mm ON mm.partcode = summary.partcode
    WHERE summary.partcode = '" & selectedpartcode & "' 
    AND summary.date_summary BETWEEN '" & fromDate.ToString("yyyy-MM-dd") & "' AND '" & toDate.ToString("yyyy-MM-dd") & "'
    GROUP BY summary.date_summary, mm.partcode, mm.partname
    ORDER BY summary.date_summary ASC
    "

        reload(query, datagrid1)
    End Sub



    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        display_inSub(molding_fg)
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