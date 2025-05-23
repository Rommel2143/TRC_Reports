Module frameModules

    Public Sub display_inMain(newForm As Form)

        With newForm
            .TopLevel = False
            .AutoScroll = True
            .AutoScrollMargin = New Size(50, 50)

            ' Optional: clear previous content
            Mainframe.Panel1.Controls.Clear()

            ' Add if not already present
            If Not Mainframe.Panel1.Controls.Contains(newForm) Then
                Mainframe.Panel1.Controls.Add(newForm)
            End If

            .BringToFront()
            .Show()
        End With
    End Sub



    Public Sub display_inSub(newForm As Form)
        With newForm
            .TopLevel = False
            .AutoScroll = True
            .AutoScrollMargin = New Size(50, 50)

            ' Optional: clear previous content
            subframe.Panel1.Controls.Clear()

            ' Add if not already present
            If Not subframe.Panel1.Controls.Contains(newForm) Then
                subframe.Panel1.Controls.Add(newForm)
            End If
            subframe.lbl_FormName.Text = "➥ " & .Text
            .BringToFront()
            .Show()
        End With
    End Sub

    Public Sub display_inSub(newForm As Form, column As String)
        If isAccess(column) OrElse isSuperadmin Then
        Else
            Show_Error("Access Denied.")
            Exit Sub
        End If

        With newForm
            .TopLevel = False
            .AutoScroll = True
            .AutoScrollMargin = New Size(50, 50)

            subframe.Panel1.Controls.Clear()

            If Not subframe.Panel1.Controls.Contains(newForm) Then
                subframe.Panel1.Controls.Add(newForm)
            End If

            subframe.lbl_FormName.Text = "➥ " & .Text
            .BringToFront()
            .Show()
        End With
    End Sub








End Module
