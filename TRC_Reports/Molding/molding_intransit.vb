Public Class molding_intransit
    Private Sub molding_intransit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reload("SELECT lu.partcode AS Partcode, lm.partname, COUNT(lu.id) AS 'Boxes', SUM(lu.qty) AS 'TOTAL' " &
               "FROM molding_masterlist lm " &
               "JOIN molding_stock_intransit lu ON lu.partcode = lm.partcode " &
               "WHERE lu.status = 1 " &
               "GROUP BY lu.partcode, lm.partname " &
               "ORDER BY lu.partcode DESC", datagrid1)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        exportExcel(datagrid1, "Molding-In-Transit")
    End Sub
End Class
