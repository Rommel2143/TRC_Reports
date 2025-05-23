Imports MySql.Data.MySqlClient
Public Class molding_fg
    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs)
        loaddata()
    End Sub


    Private Sub loaddata()
        Dim setdate As String = dtpicker1.Value.ToString("yyyy-MM-dd")
        Dim settime As String = If(chk_630.Checked = True, "6:31:00", "23:59:59")
        Dim selectedDT As String = setdate & " " & settime

        Dim query As String = "
    SELECT 
        mm.partcode,
        mm.partname,

        IFNULL(mold.total_in, 0) AS Molding_IN,
        IFNULL(mold.total_out, 0) AS Molding_OUT,
        IFNULL(mold.box_count, 0) AS Molding_BoxCount,
        IFNULL(mold.total_in, 0) - IFNULL(mold.total_out, 0) AS Molding_Total,

        IFNULL(unit56.total_in, 0) AS Unit56_IN,
        IFNULL(unit56.total_out, 0) AS Unit56_OUT,
        IFNULL(unit56.box_count, 0) AS Unit56_BoxCount,
        IFNULL(unit56.total_in, 0) - IFNULL(unit56.total_out, 0) AS Unit56_Total,

        IFNULL(sunbo.total_in, 0) AS Sunbo_IN,
        IFNULL(sunbo.total_out, 0) AS Sunbo_OUT,
        IFNULL(sunbo.box_count, 0) AS Sunbo_BoxCount,
        IFNULL(sunbo.total_in, 0) - IFNULL(sunbo.total_out, 0) AS Sunbo_Total,

        (IFNULL(mold.total_in, 0) - IFNULL(mold.total_out, 0) +
         IFNULL(unit56.total_in, 0) - IFNULL(unit56.total_out, 0) +
         IFNULL(sunbo.total_in, 0) - IFNULL(sunbo.total_out, 0)) AS 'Grand Total',

        (IFNULL(mold.box_count, 0) +
         IFNULL(unit56.box_count, 0) +
         IFNULL(sunbo.box_count, 0)) AS 'Grand Box Count'

    FROM molding_masterlist mm

    LEFT JOIN (
        SELECT partcode,
            SUM(CASE WHEN CONCAT(dateIN, ' ', timeIN) < '" & selectedDT & "' THEN qty ELSE 0 END) AS total_in,
            SUM(CASE WHEN CONCAT(dateOUT, ' ', timeOUT) < '" & selectedDT & "' THEN qty ELSE 0 END) AS total_out,
            (SUM(CASE WHEN CONCAT(dateIN, ' ', timeIN) < '" & selectedDT & "' THEN 1 ELSE 0 END) -
             SUM(CASE WHEN CONCAT(dateOUT, ' ', timeOUT) < '" & selectedDT & "' THEN 1 ELSE 0 END)) AS box_count
        FROM molding_stock
        GROUP BY partcode
    ) AS mold ON mm.partcode = mold.partcode

    LEFT JOIN (
        SELECT partcode,
            SUM(CASE WHEN CONCAT(datein, ' ', timeIN) < '" & selectedDT & "' THEN qty ELSE 0 END) AS total_in,
            SUM(CASE WHEN CONCAT(dateout, ' ', timeOUT) < '" & selectedDT & "' THEN qty ELSE 0 END) AS total_out,
            (SUM(CASE WHEN CONCAT(datein, ' ', timeIN) < '" & selectedDT & "' THEN 1 ELSE 0 END) -
             SUM(CASE WHEN CONCAT(dateout, ' ', timeOUT) < '" & selectedDT & "' THEN 1 ELSE 0 END)) AS box_count
        FROM logistics_unit56
        GROUP BY partcode
    ) AS unit56 ON mm.partcode = unit56.partcode

    LEFT JOIN (
        SELECT partcode,
            SUM(CASE WHEN CONCAT(datein, ' ', timeIN) < '" & selectedDT & "' THEN qty ELSE 0 END) AS total_in,
            SUM(CASE WHEN CONCAT(dateout, ' ', timeOUT) < '" & selectedDT & "' THEN qty ELSE 0 END) AS total_out,
            (SUM(CASE WHEN CONCAT(datein, ' ', timeIN) < '" & selectedDT & "' THEN 1 ELSE 0 END) -
             SUM(CASE WHEN CONCAT(dateout, ' ', timeOUT) < '" & selectedDT & "' THEN 1 ELSE 0 END)) AS box_count
        FROM logistics_sunbo
        GROUP BY partcode
    ) AS sunbo ON mm.partcode = sunbo.partcode
    "

        reload(query, datagrid1)
        StyleDataGrid()
    End Sub




    Private Sub StyleDataGrid()
        Dim moldingColor As Color = Color.LightSkyBlue
        Dim unit56Color As Color = Color.LightGreen
        Dim sunboColor As Color = Color.LightSalmon

        With datagrid1
            ' Molding group header colors
            If .Columns.Contains("Molding_IN") Then
                .Columns("Molding_IN").HeaderText = "M_IN"
                .Columns("Molding_IN").HeaderCell.Style.BackColor = moldingColor
                .Columns("Molding_IN").HeaderCell.Style.ForeColor = Color.Black
            End If
            If .Columns.Contains("Molding_OUT") Then
                .Columns("Molding_OUT").HeaderText = "M_OUT"
                .Columns("Molding_OUT").HeaderCell.Style.BackColor = moldingColor
                .Columns("Molding_OUT").HeaderCell.Style.ForeColor = Color.Black
            End If
            If .Columns.Contains("Molding_Total") Then
                .Columns("Molding_Total").HeaderText = "Molding Total"
                .Columns("Molding_Total").HeaderCell.Style.BackColor = moldingColor
                .Columns("Molding_Total").HeaderCell.Style.ForeColor = Color.Black
            End If
            If .Columns.Contains("Molding_BoxCount") Then
                .Columns("Molding_BoxCount").HeaderText = "M_Boxes"
                .Columns("Molding_BoxCount").HeaderCell.Style.BackColor = moldingColor
                .Columns("Molding_BoxCount").HeaderCell.Style.ForeColor = Color.Black
            End If

            ' Unit56 group header colors
            If .Columns.Contains("Unit56_IN") Then
                .Columns("Unit56_IN").HeaderText = "U_IN"
                .Columns("Unit56_IN").HeaderCell.Style.BackColor = unit56Color
                .Columns("Unit56_IN").HeaderCell.Style.ForeColor = Color.Black
            End If
            If .Columns.Contains("Unit56_OUT") Then
                .Columns("Unit56_OUT").HeaderText = "U_OUT"
                .Columns("Unit56_OUT").HeaderCell.Style.BackColor = unit56Color
                .Columns("Unit56_OUT").HeaderCell.Style.ForeColor = Color.Black
            End If
            If .Columns.Contains("Unit56_Total") Then
                .Columns("Unit56_Total").HeaderText = "Unit 5-6 Total"
                .Columns("Unit56_Total").HeaderCell.Style.BackColor = unit56Color
                .Columns("Unit56_Total").HeaderCell.Style.ForeColor = Color.Black
            End If
            If .Columns.Contains("Unit56_BoxCount") Then
                .Columns("Unit56_BoxCount").HeaderText = "U_Boxes"
                .Columns("Unit56_BoxCount").HeaderCell.Style.BackColor = unit56Color
                .Columns("Unit56_BoxCount").HeaderCell.Style.ForeColor = Color.Black
            End If

            ' Sunbo group header colors
            If .Columns.Contains("Sunbo_IN") Then
                .Columns("Sunbo_IN").HeaderText = "S_IN"
                .Columns("Sunbo_IN").HeaderCell.Style.BackColor = sunboColor
                .Columns("Sunbo_IN").HeaderCell.Style.ForeColor = Color.Black
            End If
            If .Columns.Contains("Sunbo_OUT") Then
                .Columns("Sunbo_OUT").HeaderText = "S_OUT"
                .Columns("Sunbo_OUT").HeaderCell.Style.BackColor = sunboColor
                .Columns("Sunbo_OUT").HeaderCell.Style.ForeColor = Color.Black
            End If
            If .Columns.Contains("Sunbo_Total") Then
                .Columns("Sunbo_Total").HeaderText = "Sunbo Total"
                .Columns("Sunbo_Total").HeaderCell.Style.BackColor = sunboColor
                .Columns("Sunbo_Total").HeaderCell.Style.ForeColor = Color.Black
            End If
            If .Columns.Contains("Sunbo_BoxCount") Then
                .Columns("Sunbo_BoxCount").HeaderText = "S_Boxes"
                .Columns("Sunbo_BoxCount").HeaderCell.Style.BackColor = sunboColor
                .Columns("Sunbo_BoxCount").HeaderCell.Style.ForeColor = Color.Black
            End If


            .EnableHeadersVisualStyles = False ' Important to allow header style changes to show
            .AutoResizeColumns()
        End With
    End Sub

    Private Sub fg_monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpicker1.Value = Date.Now

    End Sub

    Private Sub dtpicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker1.ValueChanged, chk_630.CheckedChanged
        loaddata()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        exportExcel(datagrid1, "Molding FG Stocks", dtpicker1.Value.ToString("MMMM dd, yyyy"))
    End Sub


    Private Sub datagrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

            Dim selectedpartcode As String = datagrid1.Rows(e.RowIndex).Cells("partcode").Value.ToString()
            Dim selectedpartNAME As String = datagrid1.Rows(e.RowIndex).Cells("partname").Value.ToString()
            item_summary.getData(selectedpartcode, selectedpartNAME)
            display_inSub(item_summary)
        End If
    End Sub


End Class