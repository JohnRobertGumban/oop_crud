Public Class Form2
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        dbconnection()
        LoadUserType()
        With dgvrecord
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .RowsDefaultCellStyle.BackColor = Color.Red
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Fuchsia
        End With
    End Sub

    Private Sub btnfind_Click(sender As Object, e As EventArgs) Handles btnfind.Click
        FindRecord(txtdata.Text, cbotype.SelectedIndex)
        If cbotype.SelectedIndex = 0 Then
            FindRecord(txtdata.Text, "Adviser")
        ElseIf cbotype.SelectedIndex = 1 Then
            FindRecord(txtdata.Text, "enlistment officer")
        ElseIf cbotype.SelectedIndex = 2 Then
            FindRecord(txtdata.Text, "finance officer")


        End If

    End Sub

    Private Sub dgvrecord_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvrecord.CellFormatting
        If dgvrecord.Columns(e.ColumnIndex).Index = 2 Then
            If e.Value <> " " Then
                e.Value = "**********"
                e.FormattingApplied = True
            End If
        End If
    End Sub
End Class