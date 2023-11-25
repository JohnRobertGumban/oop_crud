Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient

Module dbaseInfo
    Dim conn As New MySqlConnection
    Dim Strquery, query As String
    Dim reader As MySqlDataReader
    Dim dbname, server, username, password As String
    Dim cmd As New MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim dataTable As New DataTable
    Dim dataset As DataSet

    Public Sub dbconnection()
        dbname = "it2a_oop"
        server = "127.0.0.1"
        username = "root"
        password = "password"

        If Not conn Is Nothing Then
            conn.Close()
            conn.ConnectionString = "server=" & server & ";" & "user id=" & username & ";password=" & password & ";database=" & dbname & ""
            Try
                conn.Open()
                MsgBox("Connected!")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
    Public Sub InsertRec()
        query = "INSERT INTO tbluser(uname, pass) VALUES(@Param1, @Param2)"
        cmd = New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@Param1", Form1.txtuname.Text)
        cmd.Parameters.AddWithValue("@Param2", Form1.txtpass.Text)
        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Record inserted succesfully!")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClearData()
        End Try

    End Sub

    Public Sub ClearData()
        Form1.txtuname.Clear()
        Form1.txtpass.Clear()
    End Sub

    Public Sub SearchRec()
        query = "SELECT * FROM tbluser WHERE userId= @Param1"
        cmd = New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@Param1", Form1.txtuid.Text)
        reader = cmd.ExecuteReader()
        Try

            If reader.Read() Then
                Form1.txtusername.Text = reader("uname").ToString()
                Form1.txtpassword.Text = reader("pass").ToString()
                Form1.btnupdate.Enabled = True
                Form1.btndelete.Enabled = True
                Form1.txtusername.Enabled = True
                Form1.txtpassword.Enabled = True
            Else
                MsgBox("No Record Found!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            reader.Close()
        End Try
    End Sub

    Public Sub LoadUserType()
        query = "SELECT usertype FROM tbluser"
        Try
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader()

            While reader.Read()
                Form2.cbotype.Items.Add(reader("usertype").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Public Sub FindRecord(searchData As String, utype As String)
        Form2.dgvrecord.DataSource = Nothing
        query = "SELECT * FROM tbluser WHERE userId = @uid or uname = @username and usertype = @utype;"
        adapter = New MySqlDataAdapter(query, conn)
        adapter.SelectCommand.Parameters.AddWithValue("@uid", searchData)
        adapter.SelectCommand.Parameters.AddWithValue("@username", searchData)
        adapter.SelectCommand.Parameters.AddWithValue("@utype", utype)

        Try
            adapter.Fill(dataTable)
            Form2.dgvrecord.DataSource = dataTable
            Form2.dgvrecord.AutoResizeColumns(DataGridViewAutoSizeColumnMode.AllCells)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Form2.txtdata.Clear()

        End Try
    End Sub
    Public Sub updateRecord(uid As String, uname As String, pass As String)
        query = "Update user SET uname = @uname, pass = @pass where userid = @ uid"
        Try
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@uname", uname)
                cmd.Parameters.AddWithValue("@pass", pass)
                cmd.Parameters.AddWithValue("@uid", uid)

            End Using
        Catch ex As Exception
            MessageBox.Show("Error" & ex.Message)
        Finally
            conn.Close()
            Form1.txtpassword.Clear()
            Form1.txtusername.Clear()
            Form1.txtuid.Clear()
            Form1.txtpassword.Enabled = False
            Form1.txtusername.Enabled = False
        End Try
    End Sub

    Public Sub DeleteRecord(uid As String)
        query = "Delete from tbluser where userid = @uid"
        Try
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@uid", uid)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Record deleted successfully!")
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
        Finally
            Form1.txtpassword.Clear()
            Form1.txtusername.Clear()
            Form1.txtuid.Clear()
            Form1.txtpassword.Enabled = False
            Form1.txtusername.Enabled = False
        End Try
    End Sub
    Public Sub loadRecord()
        Form3.dgvRecord.DataSource = Nothing
        Try
            query = ("SELECT * FROM tbluser")
            adapter = New MySqlDataAdapter(query, conn)
            dataset = New DataSet()
            adapter.Fill(dataset, "tbluser")
            Form3.dgvRecord.DataSource = dataset.Tables("tbluser")

            Dim updateButton As New DataGridViewButtonColumn()
            updateButton.Name = "UpdateButton"
            updateButton.Text = "Update"
            updateButton.UseColumnTextForButtonValue = True
            Form3.dgvRecord.Columns.Add(updateButton)

            Dim DeleteButton As New DataGridViewButtonColumn()
            DeleteButton.Name = "DeleteButton"
            DeleteButton.Text = "Delete"
            DeleteButton.UseColumnTextForButtonValue = True
            Form3.dgvRecord.Columns.Add(DeleteButton)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RecordUpdate(rowIndex As Integer, uname As String, pass As String)
        If rowIndex >= 0 Then
            Dim SelectedRow = Form3.dgvRecord.Rows(rowIndex)
            Dim id As Integer = CInt(selectedRow.Cells("userid").value)
            query = "UPDATE tbl user SET uname = @uname, pass = @pass,  where userid = @ID"
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@uname", uname)
                cmd.Parameters.AddWithValue("@pass", pass)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Record update successfully!")
                conn.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub RemoveRecord(rowIndex As Integer)
        If rowIndex >= 0 Then
            Dim SelectedRow = Form3.dgvRecord.Rows(rowIndex)
            Dim id As Integer = CInt(SelectedRow.Cells("userid").Value)
            query = "DELETE tbluser where userid = @ID"
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Record update successfully!")
                loadRecord()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub
End Module
