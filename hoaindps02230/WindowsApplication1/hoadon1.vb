Imports System.Data.SqlClient
Imports System.Data.DataTable

Public Class hoadon1
    Dim chuoilienket As String = "workstation id=hoaindps02230.mssql.somee.com;packet size=4096;user id=hoaindps02230_SQLLogin_1;pwd=nj6iu6wtwu;data source=hoaindps02230.mssql.somee.com;persist security info=False;initial catalog=hoaindps02230"
    Dim KetNoi As SqlConnection = New SqlConnection(chuoilienket)
    Dim table As New DataTable
    Public Sub LoadData()
        Dim sqladapter As New SqlDataAdapter("select * from HoaDon", KetNoi)
        Try
            sqladapter.Fill(table)
        Catch ex As Exception

        End Try
        HoaDon.DataGridView1.DataSource = table
        KetNoi.Close()
    End Sub
    Private Sub hoadon1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        KetNoi.Open()
        Dim them As String = "insert into HoaDon Values(@MaHD,@KhachHang_MaKH,@NhanVien_MaNV,@SanPham_MaSP,@SoLuong,@DonGia,@NgayLapHoaDon,@TongTien)"
        Dim cmd As SqlCommand = New SqlCommand(them, KetNoi)
        Try
            cmd.Parameters.AddWithValue("@MaHD", TextBox1.Text)
            cmd.Parameters.AddWithValue("@KhachHang_MaKH", TextBox2.Text)
            cmd.Parameters.AddWithValue("@NhanVien_MaNV", TextBox3.Text)
            cmd.Parameters.AddWithValue("@SanPham_MaSP", TextBox4.Text)
            cmd.Parameters.AddWithValue("@SoLuong", TextBox5.Text)
            cmd.Parameters.AddWithValue("@DonGia", TextBox6.Text)
            cmd.Parameters.AddWithValue("@NgayLapHoaDon", TextBox8.Text)
            cmd.Parameters.AddWithValue("@TongTien", TextBox7.Text)
            cmd.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Thêm thành công hóa đơn có mã " & TextBox1.Text & "")
        Catch ex As Exception

        End Try
        TextBox1.Clear()
        TextBox2.Clear()

        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        table.Clear()
        HoaDon.DataGridView1.DataSource = table
        HoaDon.DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        KetNoi.Open()
        Dim sua As String = "UPDATE HoaDon SET MaHD = @MaHD, KhachHang_MaKH = @MaKH, NhanVien_MaNV = @MaNV, SanPham_MaSP = @MaSP, SoLuong = @SoLuong, DonGia = @DonGia, NgayLapHoaDon = @NgayLapHoaDon, TongTien = @TongTien where MaHD = @MaHD"
        Dim cmd As SqlCommand = New SqlCommand(sua, KetNoi)
        Try
            cmd.Parameters.AddWithValue("@MaHD", TextBox1.Text)
            cmd.Parameters.AddWithValue("@MaKH", TextBox2.Text)
            cmd.Parameters.AddWithValue("@MaNV", TextBox3.Text)
            cmd.Parameters.AddWithValue("@MaSP", TextBox4.Text)
            cmd.Parameters.AddWithValue("@SoLuong", TextBox5.Text)
            cmd.Parameters.AddWithValue("@DonGia", TextBox6.Text)
            cmd.Parameters.AddWithValue("@NgayLapHoaDon", TextBox8.Text)
            cmd.Parameters.AddWithValue("@TongTien", TextBox7.Text)
            cmd.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Sửa thành công hóa đơn có mã hóa đơn " & TextBox1.Text & "")
        Catch ex As Exception
            MessageBox.Show("Sửa không thành công")
        End Try
        table.Clear()
        HoaDon.DataGridView1.DataSource = table
        HoaDon.DataGridView1.DataSource = Nothing
        LoadData()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        HoaDon.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub
End Class