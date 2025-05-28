Public Class painting_stock


    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        Try
            Dim query As String = "SELECT mm.partcode,mm.partname,IFNULL(paint.total,0) AS Total
FROM painting_masterlist mm

LEFT JOIN (SELECT partcode, SUM(qty) AS total FROM painting_stock WHERE status='IN' GROUP BY partcode) AS paint ON paint.partcode=mm.partcode


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