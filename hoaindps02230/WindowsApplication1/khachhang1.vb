Imports System.Data.SqlClient
Imports System.Data.DataTable

Public Class khachhang1
    Dim chuoilienket As String = "workstation id=hoaindps02230.mssql.somee.com;packet size=4096;user id=hoaindps02230_SQLLogin_1;pwd=nj6iu6wtwu;data source=hoaindps02230.mssql.somee.com;persist security info=False;initial catalog=hoaindps02230"
    Dim KetNoi As SqlConnection = New SqlConnection(chuoilienket)
    Dim table As New DataTable
    Public Sub LoadData()
        Dim sqladapter As New SqlDataAdapter("select * from KhachHang", KetNoi)
        Try
            sqladapter.Fill(table)
        Catch ex As Exception

        End Try
        KhachHang.DataGridView1.DataSource = table
        KetNoi.Close()
    End Sub
    Private Sub khachhang1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        KetNoi.Open()
        Dim them As String = "insert into KhachHang values (@MaKH,@HoTen,@DiaChi,@SoDienThoai,@Email)"
        Dim cmd As SqlCommand = New SqlCommand(them, KetNoi)
        If TextBox1.Text = "" Then
            MessageBox.Show("Chưa nhập Mã Khách Hàng")
        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("Chưa nhập Họ Tên")
        Else
            Try
                cmd.Parameters.AddWithValue("@MaKH", TextBox1.Text)
                cmd.Parameters.AddWithValue("@HoTen", TextBox3.Text)
                cmd.Parameters.AddWithValue("@DiaChi", TextBox5.Text)
                cmd.Parameters.AddWithValue("@SoDienThoai", TextBox6.Text)
                cmd.Parameters.AddWithValue("@Email", TextBox7.Text)
                cmd.ExecuteNonQuery()
                KetNoi.Close()
                MessageBox.Show("Thành Công")

            Catch ex As Exception

            End Try
        End If
        TextBox1.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox7.Clear()
        TextBox6.Clear()
        table.Clear()
        NhanVien.DataGridView1.DataSource = table
        NhanVien.DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        KetNoi.Open()
        Dim sua As String = "UPDATE KhachHang SET MaKH = @MaKH, HoTen = @HoTen, DiaChi = @DiaChi, SoDienThoai = @SDT, Email = @Email where MaKH = @MaKH"
        Dim sua1 As New SqlCommand(sua, KetNoi)
        Try
            sua1.Parameters.AddWithValue("@MaKH", TextBox1.Text)
            sua1.Parameters.AddWithValue("@HoTen", TextBox3.Text)
            sua1.Parameters.AddWithValue("@DiaChi", TextBox5.Text)
            sua1.Parameters.AddWithValue("@SDT", TextBox6.Text)
            sua1.Parameters.AddWithValue("@Email", TextBox7.Text)
            sua1.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Thành Công")
        Catch ex As Exception
            MessageBox.Show("Sửa không thành công")
        End Try
        table.Clear()
        KhachHang.DataGridView1.DataSource = table
        KhachHang.DataGridView1.DataSource = Nothing
        LoadData()
        TextBox1.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        KhachHang.Show
    End Sub
End Class