Public Class Logistics_sunbo

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        Try
            Dim query As String = Nothing

            If txt_search.Text.Trim = "" Then
                query = "SELECT mm.partcode,mm.partname,IFNULL(logi.total,0) AS Total
FROM logistics_masterlist mm

LEFT JOIN (SELECT partcode, SUM(qty) AS total FROM logistics_sunbo WHERE status=1 GROUP BY partcode) AS logi ON logi.partcode=mm.partcode


"
            Else

                query = "SELECT mm.partcode,mm.partname,IFNULL(sunbo.total,0) AS Sunbo
FROM logistics_masterlist mm

LEFT JOIN (SELECT partcode, SUM(qty) AS total FROM logistics_sunbo WHERE status=1 GROUP BY partcode) AS logi ON logi.partcode=mm.partcode
WHERE (mm.partcode='" & txt_search.Text & "' OR mm.partname REGEXP '" & txt_search.Text & "')
"

            End If




            reload(query, datagrid1)
        Catch ex As Exception
            Show_Error("Something went wrong...")
        End Try

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        exportExcel(datagrid1, "Sunbo FG Stocks", Date.Now.ToString("MMMM dd, yyyy"))
    End Sub
End Class