Imports MySql.Data.MySqlClient

Public Class manage_users
    Private dt As DataTable
    Private adapter As MySqlDataAdapter
    Private builder As MySqlCommandBuilder

    Private Sub manage_users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadall()
    End Sub

    Sub loadall()
        Try
            datagrid1.DataSource = Nothing

            If datagrid1.Columns("Edit") Is Nothing Then
                Dim imgCol As New DataGridViewImageColumn()
                imgCol.Name = "Edit"
                imgCol.HeaderText = ""
                imgCol.Image = My.Resources.editBtn
                imgCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom
                datagrid1.Columns.Add(imgCol)
            End If

            con.Close()
            con.Open()
            dt = New DataTable()
            adapter = New MySqlDataAdapter("SELECT * FROM " & userTable & " WHERE ID <> 0", con)
            builder = New MySqlCommandBuilder(adapter)
            adapter.Fill(dt)
            datagrid1.DataSource = dt

            datagrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            ' Hide the "password" column
            If datagrid1.Columns.Contains("password") Then
                datagrid1.Columns("password").Visible = False
            End If

            Dim readonlyColumns As String() = {"id", "IDno", "Firstname", "Lastname"}

            For Each col As DataGridViewColumn In datagrid1.Columns
                If readonlyColumns.Contains(col.Name) Then
                    col.ReadOnly = True
                    col.Width = 200 ' or desired width for read-only columns
                Else
                    col.Width = 80   ' width for all other columns
                End If
            Next
            datagrid1.Columns("id").Width = 100

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub datagrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Check if the clicked cell is in the "editbtn" column
            If datagrid1.Columns(e.ColumnIndex).Name = "Edit" Then
                Dim selectedId As String = datagrid1.Rows(e.RowIndex).Cells("id").Value.ToString()
                Dim selectedIdno As String = datagrid1.Rows(e.RowIndex).Cells("IDno").Value.ToString()
                Dim selectedfirstname As String = datagrid1.Rows(e.RowIndex).Cells("firstname").Value.ToString()
                Dim selectedlastname As String = datagrid1.Rows(e.RowIndex).Cells("lastname").Value.ToString()

                update_name.loaddata(selectedId, selectedIdno, selectedfirstname, selectedlastname)
                update_name.ShowDialog()
                update_name.BringToFront()
            End If
        End If
    End Sub


    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try
            If dt IsNot Nothing Then
                adapter.Update(dt)
                MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No data found to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error saving changes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs)
        exportExcel(datagrid1, "Test title")
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class
