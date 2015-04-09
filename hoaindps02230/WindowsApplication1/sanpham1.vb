Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class sanpham1
    Dim chuoilienket As String = "workstation id=hoaindps02230.mssql.somee.com;packet size=4096;user id=hoaindps02230_SQLLogin_1;pwd=nj6iu6wtwu;data source=hoaindps02230.mssql.somee.com;persist security info=False;initial catalog=hoaindps02230"
    Dim KetNoi As SqlConnection = New SqlConnection(chuoilienket)
    Dim table As New DataTable
    Dim table1 As New DataTable
    Public Sub LoadData()
        Dim sqladapter As New SqlDataAdapter("select * from SanPham", KetNoi)
        Try
            sqladapter.Fill(table)
        Catch ex As Exception

        End Try
        SanPham.DataGridView1.DataSource = table
        KetNoi.Close()
    End Sub
    Public Sub LoadDataMaLoaiSP()
        Dim sqladapter As New SqlDataAdapter("select * from LoaiSanPham", KetNoi)
        Try
            sqladapter.Fill(table1)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = table1
        KetNoi.Close()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        KetNoi.Open()
        Dim them As String = "insert into LoaiSanPham values (@MaLoai,@TenLoai)"
        Dim cmd As SqlCommand = New SqlCommand(them, KetNoi)
        Try
            cmd.Parameters.AddWithValue("@MaLoai", TextBox9.Text)
            cmd.Parameters.AddWithValue("@TenLoai", TextBox10.Text)
            cmd.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Thêm thành công Mã Loai Sản Phẩm " & TextBox9.Text & "")
        Catch ex As Exception
        End Try
        TextBox9.Clear()
        TextBox10.Clear()
        table1.Clear()
        DataGridView1.DataSource = table1
        DataGridView1.DataSource = Nothing
        LoadDataMaLoaiSP()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim click As Integer = DataGridView1.CurrentCell.RowIndex
        TextBox9.Text = DataGridView1.Item(0, click).Value
        TextBox10.Text = DataGridView1.Item(1, click).Value
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        KetNoi.Open()
        Dim sua As String = "UPDATE LoaiSanPham SET TenLoaiSP = @TenLoai where MaLoai = @MaLoai"
        Dim com As New SqlCommand(sua, KetNoi)
        Try
            com.Parameters.AddWithValue("@TenLoai", TextBox10.Text)
            com.Parameters.AddWithValue("@MaLoai", TextBox9.Text)
            com.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Sửa thành công sản phẩm có mã loại " & TextBox9.Text & "")
        Catch ex As Exception
            MessageBox.Show("Khong")
        End Try
        table1.Clear()
        DataGridView1.DataSource = table1
        DataGridView1.DataSource = Nothing
        LoadDataMaLoaiSP()
        TextBox9.Clear()
        TextBox10.Clear()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        KetNoi.Open()

        Dim them As String = "UPDATE SanPham SET LoaiSanPham_MaLoai = @MaLoai, MaSP = @MaSP, TenSP = @TenSP, SoLuong = @SoLuong, DonGia = @DonGia, HangSanXuat = @HangSX, ChiTietSP = @ChitietSP"
        Dim cmd As New SqlCommand(them, KetNoi)
        Try
            cmd.Parameters.AddWithValue("@MaLoai", ComboBox1.DataSource = table1)
            cmd.Parameters.AddWithValue("@MaSP", TextBox2.Text)
            cmd.Parameters.AddWithValue("@TenSP", TextBox4.Text)
            cmd.Parameters.AddWithValue("@SoLuong", TextBox1.Text)
            cmd.Parameters.AddWithValue("@DonGia", TextBox6.Text)
            cmd.Parameters.AddWithValue("@HangSX", TextBox7.Text)
            cmd.Parameters.AddWithValue("@ChitietSP", TextBox8.Text)
            cmd.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Thêm thành Công sản phẩm '" & TextBox4.Text & "'")
        Catch ex As Exception
            If ComboBox1.Text = "" Then
                MessageBox.Show("Chưa chọn Mã Loại Sản Phẩm")
            ElseIf TextBox2.Text Then
                MessageBox.Show("Chưa nhập mã sản phẩm")
            ElseIf TextBox4.Text Then
                MessageBox.Show("Chưa nhập tên sản phẩm")
            End If
        End Try
        ComboBox1.Text.Clone()
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox1.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        table.Clear()
        SanPham.DataGridView1.DataSource = table
        SanPham.DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Hide()
        SanPham.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub sanpham1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqladapter As New SqlDataAdapter("select * from LoaiSanPham", KetNoi)
        Try
            KetNoi.Open()
            sqladapter.Fill(table1)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = table1
        KetNoi.Close()

        KetNoi.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select * from LoaiSanPham", KetNoi)
        Dim rd As SqlDataReader = cmd.ExecuteReader()
        While rd.Read
            ComboBox1.Items.Add(rd.GetValue(0).ToString)
        End While
        rd.Close()
        KetNoi.Close()
        table1.Clear()
        DataGridView1.DataSource = table1
        DataGridView1.DataSource = Nothing
        LoadDataMaLoaiSP()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    
    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        KetNoi.Open()
        Dim dieukien As Integer = DataGridView1.CurrentCell.RowIndex
        Dim dk As String = DataGridView1.Item(0, dieukien).Value
        Dim xoa As String = "Delete from LoaiSanPham where MaLoai = @MaLoai"
        Dim com As New SqlCommand(xoa, KetNoi)
        Try
            com.Parameters.AddWithValue("@MaLoai", dk)
            com.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Bạn có muốn xóa sản phẩm")
            Button4.Enabled = True
            TextBox4.Enabled = True
        Catch ex As Exception
        End Try
        table1.Clear()
        DataGridView1.DataSource = table1
        DataGridView1.DataSource = Nothing
        LoadDataMaLoaiSP()
        TextBox9.Clear()
        TextBox10.Clear()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        SanPham.Show()
        ComboBox1.SelectedIndex = -1
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        KetNoi.Open()
        Dim them As String = "insert into SanPham Values(@LoaiSanPham_MaLoai,@MaSP,@TenSP,@SoLuong,@DonGia,@HangSanXuat,@ChiTietSP)"
        Dim cmd As SqlCommand = New SqlCommand(them, KetNoi)
        Try
            cmd.Parameters.AddWithValue("@LoaiSanPham_MaLoai", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@MaSP", TextBox2.Text)
            cmd.Parameters.AddWithValue("@TenSP", TextBox4.Text)
            cmd.Parameters.AddWithValue("@SoLuong", TextBox1.Text)
            cmd.Parameters.AddWithValue("@DonGia", TextBox6.Text)
            cmd.Parameters.AddWithValue("@HangSanXuat", TextBox7.Text)
            cmd.Parameters.AddWithValue("@ChiTietSP", TextBox8.Text)
            cmd.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Thêm thành công sản phẩm " & TextBox2.Text & "")
        Catch ex As Exception
            MessageBox.Show("Thêm không thành công")
        End Try
        table.Clear()
        SanPham.DataGridView1.DataSource = table
        SanPham.DataGridView1.DataSource = Nothing
        LoadData()
        ComboBox1.SelectedIndex = -1
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        KetNoi.Open()
        Dim sua As String = "UPDATE SanPham SET LoaiSanPham_MaLoai = @MaLoai, MaSP = @MaSP, TenSP = @TenSP, SoLuong = @SoLuong, DonGia = @DonGia, HangSanXuat = @HangSanXuat, ChiTietSP = @ChiTietSP where MaSP = @MaSP"
        Dim sua1 As New SqlCommand(sua, KetNoi)
        Try
            sua1.Parameters.AddWithValue("@MaLoai", ComboBox1.Text)
            sua1.Parameters.AddWithValue("@MaSP", TextBox2.Text)
            sua1.Parameters.AddWithValue("@TenSP", TextBox4.Text)
            sua1.Parameters.AddWithValue("@SoLuong", TextBox1.Text)
            sua1.Parameters.AddWithValue("@DonGia", TextBox6.Text)
            sua1.Parameters.AddWithValue("@HangSanXuat", TextBox7.Text)
            sua1.Parameters.AddWithValue("@ChiTietSP", TextBox8.Text)
            sua1.ExecuteNonQuery()
            KetNoi.Close()
            MessageBox.Show("Sửa thành công sản phẩm " & TextBox2.Text & "")
        Catch ex As Exception
            MessageBox.Show("Sửa không thành công")
        End Try
        table.Clear()
        SanPham.DataGridView1.DataSource = table
        SanPham.DataGridView1.DataSource = Nothing
        LoadData()
        ComboBox1.SelectedIndex = -1
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        Me.Hide()
    End Sub
End Class