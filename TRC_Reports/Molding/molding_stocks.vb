Public Class molding_stocks
    Private Sub molding_stocks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        Try
            Dim query As String = Nothing

            If txt_search.Text.Trim = "" Then
                query = "SELECT mm.partcode,mm.partname,IFNULL(mold.total,0) AS Molding,IFNULL(unit56.total,0) AS 'UNIT 5-6',IFNULL(sunbo.total,0) AS Sunbo
FROM molding_masterlist mm

LEFT JOIN (SELECT partcode, SUM(qty) AS total FROM molding_stock WHERE status=1 GROUP BY partcode) AS mold ON mold.partcode=mm.partcode
LEFT JOIN (SELECT partcode, SUM(qty) AS total FROM logistics_unit56 WHERE status=1 GROUP BY partcode) AS unit56 ON unit56.partcode=mm.partcode
LEFT JOIN (SELECT partcode, SUM(qty) AS total FROM logistics_sunbo WHERE status=1 GROUP BY partcode) AS sunbo ON sunbo.partcode=mm.partcode

"
            Else

                query = "SELECT mm.partcode,mm.partname,IFNULL(mold.total,0) AS Molding,IFNULL(unit56.total,0) AS 'UNIT 5-6',IFNULL(sunbo.total,0) AS Sunbo
FROM molding_masterlist mm

LEFT JOIN (SELECT partcode, SUM(qty) AS total FROM molding_stock WHERE status=1 GROUP BY partcode) AS mold ON mold.partcode=mm.partcode
LEFT JOIN (SELECT partcode, SUM(qty) AS total FROM logistics_unit56 WHERE status=1 GROUP BY partcode) AS unit56 ON unit56.partcode=mm.partcode
LEFT JOIN (SELECT partcode, SUM(qty) AS total FROM logistics_sunbo WHERE status=1 GROUP BY partcode) AS sunbo ON sunbo.partcode=mm.partcode
WHERE (mm.partcode='" & txt_search.Text & "' OR mm.partname REGEXP '" & txt_search.Text & "')
"

            End If




            reload(query, datagrid1)
        Catch ex As Exception
            Show_Error("Something went wrong...")
        End Try

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        exportExcel(datagrid1, "Molding Stocks", Date.Now.ToString("MMMM dd, yyyy"))
    End Sub
End Class