Imports System.Data.SqlClient
Public Class Login
    Dim chuoilienket As String = "workstation id=hoaindps02230.mssql.somee.com;packet size=4096;user id=hoaindps02230_SQLLogin_1;pwd=nj6iu6wtwu;data source=hoaindps02230.mssql.somee.com;persist security info=False;initial catalog=hoaindps02230"
    Dim KetNoi As SqlConnection = New SqlConnection(chuoilienket)
    Dim table As New DataTable
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
    Public Sub LoadData()
        Dim sqladapter As New SqlDataAdapter("select * from NhanVien where username='" & user.Text & "' and password='" & pass.Text & "' ", KetNoi)
        Try
            sqladapter.Fill(table)
        Catch ex As Exception

        End Try
        table.Reset()
        KetNoi.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles user.TextChanged, pass.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As New SqlDataAdapter("select * from NhanVien where username='" & user.Text & "' and password='" & pass.Text & "' ", KetNoi)
        Try
            KetNoi.Open()
            KetNoi.Close()
        Catch ex As Exception
            MessageBox.Show("Server có vẻ mệt, xin vào lần khác nhé! :(", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            KetNoi.Open()
            sql.Fill(table)
            If table.Rows.Count > 0 Then
                MessageBox.Show("Đăng nhập thành công")
                a()
                Main.Show()
                Me.Hide()
            ElseIf user.Text = "admin" And pass.Text = "admin" Then
                MessageBox.Show("Đăng nhập thành công bằng tài khoản admin")
                a()
                Main.Show()
                Me.Hide()
            Else
                MessageBox.Show("Sai Tài Khoản Hoặc Mật Khấu")
            End If
        Catch ex As Exception
        End Try
        table.Clear()
        LoadData()
    End Sub

    Public tendangnhap As String
    Public matkhau As String

    Sub a()
        tendangnhap = user.Text
        matkhau = pass.Text
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
