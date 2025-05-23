Imports MySql.Data.MySqlClient

Module userModules
    Public isSuperadmin As Boolean
    Public user_ID As Integer
    Public user_IDNumber As String
    Public user_UserName As String
    Public user_Password As String
    Public user_LastName As String
    Public user_PC As String = Environment.MachineName


    Public userTable As String = "trc_user.trc_reports"
    'SELECT `id`(primary), `IDno`(vachar,unique), `Firstname`(varchar), `Lastname`(varchar), `password`(varchar), `admin`(boolean) FROM `app_user`

    Public Function isLogin(IDno As String, pass As String) As Boolean

        If IDno = "admin" And pass = EncryptPassword("admin2143") Then
            isSuperadmin = 1
            Return 1
        End If

        Try
            Dim query As String = "SELECT `id`, `IDno`, `Firstname`, `Lastname`, `password` FROM " & userTable & " WHERE IDno = @IDno AND password = @password"
            Using cmd As New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@IDno", IDno)
                cmd.Parameters.AddWithValue("@password", pass)
                con.Close()
                con.Open()
                dr = cmd.ExecuteReader
                If dr.Read = True Then
                    user_ID = dr.GetInt32("ID")
                    user_IDNumber = dr.GetString("IDno")
                    user_UserName = dr.GetString("Firstname")
                    user_LastName = dr.GetString("Lastname")
                    user_Password = dr.GetString("password")

                    Return 1
                Else
                    Return 0
                End If
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function


    Public Function isAccess(column As String) As Boolean
        Try

            Dim query As String = "SELECT " & column & ",admin FROM " & userTable & " WHERE IDno = @IDno"


            Using cmd As New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@IDno", user_IDNumber)

                con.Close()
                con.Open()
                dr = cmd.ExecuteReader
                If dr.Read = True Then
                    If dr.GetBoolean(1) = True Then
                        Return 1
                    Else
                        Return dr.GetBoolean(0)
                    End If

                Else
                        Return 0
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Something went wrong. Please try again later.")
            Return 0
        End Try
    End Function

    Public Sub LogoutUser()
        user_ID = Nothing
        user_IDNumber = Nothing
        user_UserName = Nothing
        user_Password = Nothing
        user_LastName = Nothing
        user_PC = Nothing
    End Sub


End Module
