Public Class Logistics_unit56


    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        Try
            Dim query As String = "SELECT mm.partcode,mm.partname,IFNULL(logi.total,0) AS Total
FROM logistics_masterlist mm

LEFT JOIN (SELECT partcode, SUM(qty) AS total FROM logistics_unit56 WHERE status=1 GROUP BY partcode) AS logi ON logi.partcode=mm.partcode


"

            If txt_search.Text.Trim = "" Then
                reload(query, datagrid1)
            Else
                reload(query & "WHERE (mm.partcode='" & txt_search.Text & "' OR mm.partname REGEXP '" & txt_search.Text & "')", datagrid1)

            End If





        Catch ex As Exception
            Show_Error("Something went wrong...")
        End Try

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        exportExcel(datagrid1, "Warehouse Unit 5-6 FG Stocks", Date.Now.ToString("MMMM dd, yyyy"))
    End Sub
End Class