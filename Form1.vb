Imports MySql.Data.MySqlClient
Public Class Form1

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        InsertRec()
    End Sub


    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        SearchRec()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        dbconnection()
        btnupdate.Enabled = False
        btndelete.Enabled = False
        txtusername.Enabled = False
        txtpassword.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim result As DialogResult = MessageBox.Show("Do you really want to update the record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            updateRecord(txtuid.Text, txtusername.Text, txtpassword.Text)
        Else 'update cancelled by the user
            MessageBox.Show("update cancelled by the user")
            txtuid.Clear()
            txtusername.Clear()
            txtpassword.Clear()
        End If
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Dim result As DialogResult = MessageBox.Show("Do you really want to delete the record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            DeleteRecord(txtuid.Text)
        Else 'deletion cancelled by the user
            MessageBox.Show("deletion cancelled by the user")
            txtuid.Clear()
            txtusername.Clear()
            txtpassword.Clear()
        End If
    End Sub
End Class

